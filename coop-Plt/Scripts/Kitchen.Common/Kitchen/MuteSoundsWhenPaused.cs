using Kitchen.Components;

namespace Kitchen
{
	public class MuteSoundsWhenPaused : GenericSystemBase
	{
		protected override void OnUpdate()
		{
			VolumeManagement.SoundIsPaused = base.Time.IsPaused;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
