using UnityEngine.UI;

namespace Dorfromantik.UI.Components
{
	public class UiSlider : Slider
	{
		private UiBiomeAffectedUpdater uiBiomeAffectedUpdater;

		protected override void Start()
		{
			base.Start();
			uiBiomeAffectedUpdater = GetComponent<UiBiomeAffectedUpdater>();
		}

		public void UpdateBiomeAffectedColors()
		{
			uiBiomeAffectedUpdater.UpdateBiomeAffectedColors();
		}
	}
}
