using UnityEngine;
using UnityEngine.VFX;

namespace Logic.Lighting
{
	public class DayNightMomentVisualEffect : ActivateDuringDayNightMoment
	{
		[SerializeField]
		private VisualEffect _visualEffect;

		protected override void Activate(bool setActive)
		{
			if (setActive)
			{
				_visualEffect.Play();
			}
			else
			{
				_visualEffect.Stop();
			}
		}
	}
}
