using FullInspector.Generated.SharedInstance;
using TMPro;
using UnityEngine;

namespace TH20
{
	internal class SelectedWaypointMenu : AnimatedMenuBase
	{
		[SerializeField]
		private TMP_Text _hospitalNameText;

		[SerializeField]
		private TMP_Text _hospitalDescriptionText;

		[SerializeField]
		private WaypointLevelLink[] _waypointLeveLinks;

		public void Setup(SharedInstance_TH20TH20_LevelConfig[] levelConfigs, MetagameMap metagameMap, LocalisedString guiName, LocalisedString guiDescription)
		{
			_hospitalNameText.text = guiName.Translation;
			_hospitalDescriptionText.text = guiDescription.Translation;
			for (int i = 0; i < _waypointLeveLinks.Length; i++)
			{
				_waypointLeveLinks[i].Initialise(levelConfigs[i].Instance, metagameMap, this);
			}
		}
	}
}
