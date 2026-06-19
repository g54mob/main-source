using System.Collections.Specialized;
using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;

namespace UI.Sites.SellOrWaste
{
	public class CategoriesViewModel : ViewModelBase
	{
		public ObservableList<CategoryViewModel> Categories { get; } = new ObservableList<CategoryViewModel>();

		public CategoriesViewModel()
		{
			Categories.CollectionChanged += OnCollectionChanged;
		}

		private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			}
		}
	}
}
