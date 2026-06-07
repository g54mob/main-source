using System.Collections;
using DV.HUD;

namespace DV.Simulation.Controllers
{
	public class PowerOffControl : OverridableBaseControl
	{
		public bool signalClearedBySim;

		public override InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.FuelCutoff;

		public override void Set(float value)
		{
			if (value > 0.5f)
			{
				if (signalClearedBySim)
				{
					base.Set(1f);
				}
				else
				{
					StartCoroutine(PowerOffCoro());
				}
			}
			else
			{
				base.Set(0f);
			}
		}

		private IEnumerator PowerOffCoro()
		{
			base.Set(1f);
			yield return null;
			base.Set(0f);
		}
	}
}
