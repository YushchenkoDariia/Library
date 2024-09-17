using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{

    public partial class Form1 : Form
    {
        private Library library = new Library();

        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        // Ініціалізація стовпців DataGridView
        private void InitializeDataGridView()
        {
            dgvBooks.ColumnCount = 4;
            dgvBooks.Columns[0].Name = "Title";
            dgvBooks.Columns[1].Name = "Author";
            dgvBooks.Columns[2].Name = "Year";
            dgvBooks.Columns[3].Name = "ISBN";
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Автоматичне підлаштування ширини стовпців
        }

        // Оновлення DataGridView на основі даних бібліотеки
        private void RefreshDataGridView()
        {
            dgvBooks.Rows.Clear(); // Очищення існуючих рядків
            var books = library.GetAllBooks(); // Отримання всіх книг з бібліотеки
            foreach (var book in books)
            {
                dgvBooks.Rows.Add(book.Title, book.Author, book.Year, book.ISBN); // Додавання рядків у DataGridView
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var book = new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Year = Convert.ToInt32(txtYear.Text),
                ISBN = txtISBN.Text
            };
            library.AddBook(book);
            RefreshDataGridView();
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var isbn = txtISBN.Text;
            library.RemoveBook(isbn);
            RefreshDataGridView();
        }

        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = txtSearch.Text;
            var searchResults = library.SearchBooks(searchTerm);

            dgvBooks.Rows.Clear(); // Очищення існуючих рядків перед додаванням результатів пошуку
            foreach (var book in searchResults)
            {
                dgvBooks.Rows.Add(book.Title, book.Author, book.Year, book.ISBN); // Додавання результатів пошуку в таблицю
            }
        }
    }
}
