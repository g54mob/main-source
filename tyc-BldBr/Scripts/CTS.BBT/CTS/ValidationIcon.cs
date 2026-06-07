using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class ValidationIcon : MonoBehaviour
	{
		[SerializeField]
		[Required(null)]
		private Sprite _warningSprite;

		[SerializeField]
		[Required(null)]
		private Sprite _lockedSprite;

		private Image _validationIcon;

		private void Awake()
		{
			_validationIcon = GetComponent<Image>();
		}

		public void SetIconState(AbsLockableItemSO absLockableItemSO)
		{
			if (_validationIcon == null)
			{
				_validationIcon = GetComponent<Image>();
			}
			switch (absLockableItemSO.GetValidationState)
			{
			case AbsLockableItemSO.ELockState.Locked:
				_validationIcon.enabled = true;
				_validationIcon.sprite = _lockedSprite;
				break;
			case AbsLockableItemSO.ELockState.OnTesting:
				_validationIcon.enabled = true;
				_validationIcon.sprite = _warningSprite;
				break;
			case AbsLockableItemSO.ELockState.Validated:
				_validationIcon.enabled = false;
				break;
			}
		}
	}
}
