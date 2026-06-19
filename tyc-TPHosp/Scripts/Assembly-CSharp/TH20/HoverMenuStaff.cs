using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HoverMenuStaff : HoverMenuCharacter
	{
		private Staff _staff;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private TMP_Text _stateText;

		[SerializeField]
		private Image _statusIcon;

		[SerializeField]
		private TMP_Text _jobText;

		[SerializeField]
		private ProgressBarMaskable _energyBar;

		[SerializeField]
		private ProgressBarMaskable _happinessBar;

		public override void Setup(Character character, Level level)
		{
			base.Setup(character, level);
			_staff = (Staff)character;
			Update();
		}

		protected override void Update()
		{
			base.Update();
			if (_staff == null)
			{
				return;
			}
			if (_name != null)
			{
				_name.text = _staff.NameWithTitle;
			}
			if (_jobText != null && _staff.RankDefinition != null)
			{
				_jobText.text = _staff.RankDefinition.GetTitleLocalised(_staff.Gender).Translation;
			}
			if (_happinessBar != null)
			{
				_happinessBar.Progress = ((_staff.Happiness != null) ? (_staff.Happiness.Value() / 100f) : 0f);
			}
			if (_energyBar != null)
			{
				_energyBar.Progress = _staff.Energy.Value() / 100f;
			}
			if (_statusIcon != null)
			{
				Sprite statusSprite = _staff.GetStatusSprite();
				if (statusSprite != null)
				{
					_statusIcon.sprite = statusSprite;
				}
				_statusIcon.gameObject.SetActive(statusSprite != null);
			}
			if (_stateText != null)
			{
				_stateText.text = _staff.GetStatusText();
			}
		}
	}
}
