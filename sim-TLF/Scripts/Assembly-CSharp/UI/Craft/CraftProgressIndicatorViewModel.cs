using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;

namespace UI.Craft
{
	public class CraftProgressIndicatorViewModel : ViewModelBase
	{
		public ObservableProperty<bool> IndicatorActive = new ObservableProperty<bool>();
	}
}
