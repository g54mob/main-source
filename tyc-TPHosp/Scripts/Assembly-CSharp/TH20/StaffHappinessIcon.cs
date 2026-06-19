using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffHappinessIcon : MonoBehaviour
	{
		[SerializeField]
		private Sprite _faceVeryUnhappySprite;

		[SerializeField]
		private Color _faceVeryUnhappyColor;

		[SerializeField]
		private Sprite _faceUnhappySprite;

		[SerializeField]
		private Color _faceUnhappyColor;

		[SerializeField]
		private Sprite _faceSatisfiedSprite;

		[SerializeField]
		private Color _faceSatisfiedColor;

		[SerializeField]
		private Sprite _faceHappySprite;

		[SerializeField]
		private Color _faceHappyColor;

		[SerializeField]
		private Sprite _faceVeryHappySprite;

		[SerializeField]
		private Color _faceVeryHappyColor;

		[SerializeField]
		private Sprite _faceModificationContentSprite;

		[SerializeField]
		private Sprite _faceModificationHappySprite;

		[SerializeField]
		private Sprite _faceModificationUnhappySprite;

		[SerializeField]
		private Image _icon;

		public void UpdateFrom(StaffDefinition.Satisfaction satisfaction, bool modification = false)
		{
			if (modification)
			{
				switch (satisfaction)
				{
				case StaffDefinition.Satisfaction.VeryUnhappy:
				case StaffDefinition.Satisfaction.Unhappy:
					_icon.overrideSprite = _faceModificationUnhappySprite;
					break;
				case StaffDefinition.Satisfaction.Satisfied:
					_icon.overrideSprite = _faceModificationContentSprite;
					break;
				case StaffDefinition.Satisfaction.Happy:
				case StaffDefinition.Satisfaction.VeryHappy:
					_icon.overrideSprite = _faceModificationHappySprite;
					break;
				default:
					throw new ArgumentOutOfRangeException("satisfaction", satisfaction, null);
				}
				return;
			}
			switch (satisfaction)
			{
			case StaffDefinition.Satisfaction.VeryUnhappy:
				_icon.color = _faceVeryUnhappyColor;
				_icon.overrideSprite = _faceVeryUnhappySprite;
				break;
			case StaffDefinition.Satisfaction.Unhappy:
				_icon.color = _faceUnhappyColor;
				_icon.overrideSprite = _faceUnhappySprite;
				break;
			case StaffDefinition.Satisfaction.Satisfied:
				_icon.color = _faceSatisfiedColor;
				_icon.overrideSprite = _faceSatisfiedSprite;
				break;
			case StaffDefinition.Satisfaction.Happy:
				_icon.color = _faceHappyColor;
				_icon.overrideSprite = _faceHappySprite;
				break;
			case StaffDefinition.Satisfaction.VeryHappy:
				_icon.color = _faceVeryHappyColor;
				_icon.overrideSprite = _faceVeryHappySprite;
				break;
			default:
				throw new ArgumentOutOfRangeException("satisfaction", satisfaction, null);
			}
		}
	}
}
