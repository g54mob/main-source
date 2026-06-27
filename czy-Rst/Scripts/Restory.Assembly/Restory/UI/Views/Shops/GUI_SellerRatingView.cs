using Restory.UserInterface.ElementPresets;
using UnityEngine;

namespace Restory.UI.Views.Shops
{
	public class GUI_SellerRatingView : MonoBehaviour
	{
		[SerializeField]
		private GUI_PresetSwitcher firstStarPresetSwitcher;

		[SerializeField]
		private GUI_PresetSwitcher secondStarPresetSwitcher;

		[SerializeField]
		private GUI_PresetSwitcher thirdStarPresetSwitcher;

		[SerializeField]
		private GUI_PresetSwitcher fourthStarPresetSwitcher;

		[SerializeField]
		private GUI_PresetSwitcher fifthStarPresetSwitcher;

		[SerializeField]
		private PresetName normalPreset = PresetName.Normal;

		[SerializeField]
		private PresetName disabledPreset = PresetName.Disabled;

		public void SetRating(int rating)
		{
			fifthStarPresetSwitcher.ActivatePreset((rating > 0) ? PresetName.Normal : PresetName.Disabled);
			secondStarPresetSwitcher.ActivatePreset((rating > 1) ? PresetName.Normal : PresetName.Disabled);
			thirdStarPresetSwitcher.ActivatePreset((rating > 2) ? PresetName.Normal : PresetName.Disabled);
			fourthStarPresetSwitcher.ActivatePreset((rating > 3) ? PresetName.Normal : PresetName.Disabled);
			fifthStarPresetSwitcher.ActivatePreset((rating > 4) ? PresetName.Normal : PresetName.Disabled);
		}
	}
}
