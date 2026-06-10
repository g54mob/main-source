using NSEipix.Base;
using NSMedieval.Heraldry;

namespace NSMedieval.UI
{
	public class HeraldryContentView : ClosableUIView
	{
		public override void Show()
		{
			if (MonoSingleton<HeraldryManager>.IsInstantiated())
			{
				MonoSingleton<HeraldryManager>.Instance.CaptureCameraEnabled = true;
			}
			base.Show();
		}

		public override void Hide()
		{
			if (MonoSingleton<HeraldryManager>.IsInstantiated())
			{
				MonoSingleton<HeraldryManager>.Instance.CaptureCameraEnabled = false;
			}
			base.Hide();
		}
	}
}
