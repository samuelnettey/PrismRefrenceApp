using PrismRefrenceApp.Infrastructure;

namespace ModuleA
{
    public class ContentViewViewModel : IContentViewViewModel
    {

        public IView View { get; set; }

        public ContentViewViewModel(IContentView view)
        {
            View = view;
            View.ViewModel = this;
        }
    }
}
