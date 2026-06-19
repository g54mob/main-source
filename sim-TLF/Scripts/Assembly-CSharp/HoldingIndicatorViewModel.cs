using Loxodon.Framework.Observables;
using Loxodon.Framework.ViewModels;

public class HoldingIndicatorViewModel : ViewModelBase
{
	public ObservableProperty<float> Progress = new ObservableProperty<float>();

	private bool _enabled;

	public bool Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			Set(ref _enabled, value, "Enabled");
		}
	}
}
