using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StarIcons : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		[SerializeField]
		private Image[] _starImages;

		[SerializeField]
		private Image[] _progressImages;

		[SerializeField]
		private Color _starFullColor = Color.white;

		[SerializeField]
		private Color _starEmptyColor = Color.white;

		[SerializeField]
		private Sprite _starFullSprite;

		[SerializeField]
		private Sprite _starEmptySprite;

		[SerializeField]
		private Sprite _starReadyForPromotion;

		[SerializeField]
		private Color _xpCircleInProgressColor;

		[SerializeField]
		private Color _xpCircleInCompletedColor;

		public Action OnPromoteClicked;

		private Image _promoteStar;

		public Action OnRowClicked;

		public void SetLevel(int level, bool readyForPromotion, float experience = 0f)
		{
			for (int i = 0; i < _starImages.Length; i++)
			{
				_starImages[i].color = ((i <= level) ? _starFullColor : _starEmptyColor);
				GameObjectUtils.SetImageSprite(_starImages[i], (i <= level) ? _starFullSprite : _starEmptySprite);
			}
			if (readyForPromotion && level < _starImages.Length - 1)
			{
				_promoteStar = _starImages[level + 1];
				GameObjectUtils.SetImageSprite(_promoteStar, _starReadyForPromotion);
			}
			else
			{
				_promoteStar = null;
			}
			if (_progressImages == null)
			{
				return;
			}
			for (int j = 0; j < _progressImages.Length; j++)
			{
				if (j <= level)
				{
					_progressImages[j].fillAmount = 1f;
					_progressImages[j].color = _xpCircleInCompletedColor;
				}
				else if (j == level + 1)
				{
					_progressImages[j].fillAmount = experience;
					_progressImages[j].color = _xpCircleInProgressColor;
				}
				else if (j > level + 1)
				{
					_progressImages[j].fillAmount = 0f;
				}
				_progressImages[j].raycastTarget = false;
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			bool flag = false;
			if (_promoteStar != null && eventData.button == PointerEventData.InputButton.Left && _promoteStar.gameObject == eventData.pointerEnter)
			{
				OnPromoteClicked.InvokeSafe();
				flag = true;
			}
			if (!flag)
			{
				OnRowClicked.InvokeSafe();
			}
		}
	}
}
