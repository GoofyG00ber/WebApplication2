using WinFormsAppForWeb.BookModels;

namespace WinFormsAppForWeb
{
    public partial class Form1 : Form
    {

        FunnyDatabaseContext context = new FunnyDatabaseContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bookBindingSource.DataSource = context.Books.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the search term from the TextBox
            string filterText = textBox1.Text.ToLower();

            // Filter the books based on the Title column
            var filteredBooks = context.Books
                .Where(book => book.Title.ToLower().Contains(filterText))
                .ToList();

            // Update the BindingSource
            bookBindingSource.DataSource = filteredBooks;
        }
    }
}
