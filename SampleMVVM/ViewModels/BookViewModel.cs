using SampleMVVM.Models;
using SampleMVVM.Commands;
using System.Windows.Input;
using System.Windows;

namespace SampleMVVM.ViewModels
{
    class BookViewModel : DependencyObject
    {
        private static readonly DependencyProperty TitleProperty;
        private static readonly DependencyProperty AuthorProperty;
        private static readonly DependencyProperty CountProperty;

        static BookViewModel()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(BookViewModel));
            AuthorProperty = DependencyProperty.Register("Author", typeof(string), typeof(BookViewModel));
            CountProperty = DependencyProperty.Register("Count", typeof(int), typeof(BookViewModel));
        }

        public BookViewModel(Book book)
        {
            Title = book.Title;
            Author = book.Author;
            Count = book.Count;
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Author
        {
            get { return (string)GetValue(AuthorProperty); }
            set { SetValue(AuthorProperty, value); }
        }

        public int Count
        {
            get { return (int)GetValue(CountProperty); }
            set { SetValue(CountProperty, value); }
        }

        private DelegateCommand getItemCommand;

        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand == null)
                {
                    getItemCommand = new DelegateCommand(param => this.GetItem(), null);
                }
                return getItemCommand;
            }
        }

        private void GetItem()
        {
            Count++;
        }


        private DelegateCommand giveItemCommand;

        public ICommand GiveItemCommand
        {
            get
            {
                if (giveItemCommand == null)
                {
                    giveItemCommand = new DelegateCommand(param => GiveItem(), param => CanGiveItem());
                }
                return giveItemCommand;
            }
        }

        private void GiveItem()
        {
            Count--;
        }

        private bool CanGiveItem()
        {
            return Count > 0;
        }

    }
}
