using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	internal class WaypointLevelLink : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _nameText;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private Sprite _activeSprite;

		[SerializeField]
		private Sprite _lockedSprite;

		[SerializeField]
		private Image _lockImage;

		[SerializeField]
		private Image[] _stars;

		[SerializeField]
		private Sprite _awardedStarSprite;

		public void Initialise(LevelConfig levelConfig, MetagameMap metagameMap, SelectedWaypointMenu selectedWaypointMenu)
		{
			MetagameHospitalRecord hospitalRecord = metagameMap.Metagame.GetHospitalRecord(levelConfig);
			_nameText.text = levelConfig.DisplayNameLocalised.Translation;
			if (levelConfig.IsPlayable(metagameMap.Metagame))
			{
				_button.interactable = true;
				_button.image.sprite = _activeSprite;
				_lockImage.gameObject.SetActive(value: false);
				if (hospitalRecord == null)
				{
					return;
				}
				for (int i = 0; i < _stars.Length; i++)
				{
					if (hospitalRecord.HasStarPreviouslyBeenAwarded(i))
					{
						_stars[i].sprite = _awardedStarSprite;
					}
				}
				_button.onPrimaryDown.RemoveAllListeners();
				_button.onPrimaryDown.AddListener(delegate
				{
					MapPinHospital pinForLevelUniqueId = metagameMap.MapUI.GetPinForLevelUniqueId(levelConfig.UniqueId);
					metagameMap.CameraLogic.TrackObject(pinForLevelUniqueId.transform);
					pinForLevelUniqueId.OnSelected();
					selectedWaypointMenu.CloseMenu();
				});
			}
			else
			{
				_button.interactable = false;
				_button.image.sprite = _lockedSprite;
				_lockImage.gameObject.SetActive(value: true);
			}
		}
	}
}
