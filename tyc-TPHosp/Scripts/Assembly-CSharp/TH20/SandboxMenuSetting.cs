using I2.Loc;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class SandboxMenuSetting : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text Name;

		[SerializeField]
		private TooltipSpawner TooltipName;

		[SerializeField]
		protected TooltipSpawner TooltipSetting;

		[SerializeField]
		private GameObject _disabledOverlay;

		private bool _canBeEditedWhenPlayingLevel;

		public bool CanBeEditedWhenPlayingLevel => _canBeEditedWhenPlayingLevel;

		public GameObject DisabledOverlay => _disabledOverlay;

		public void Setup(LocalisedString settingName, LocalisedString settingTooltip, bool canBeEditedWhenPlayingLevel)
		{
			_canBeEditedWhenPlayingLevel = canBeEditedWhenPlayingLevel;
			if (Name != null && !settingName.IsNull())
			{
				Localize component = Name.GetComponent<Localize>();
				if (component == null)
				{
					Name.text = settingName.Translation;
				}
				else
				{
					component.Term = settingName.Term;
				}
			}
			if (TooltipName != null)
			{
				TooltipName.TooltipText = (settingTooltip.IsNull() ? null : settingTooltip.Translation);
			}
		}

		public virtual void SetActive(bool active)
		{
		}

		public virtual void OnSettingChanged()
		{
		}
	}
}
