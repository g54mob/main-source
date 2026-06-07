using UnityEngine;

namespace Motorways.UI
{
	[RequireComponent(typeof(DelegateCanvasGroup))]
	public class MapButtonCard : MonoBehaviour
	{
		private DelegateCanvasGroup _delegateCanvasGroup;

		public float Alpha
		{
			get
			{
				return _delegateCanvasGroup.Alpha;
			}
			set
			{
				_delegateCanvasGroup.Alpha = value;
			}
		}

		private void Awake()
		{
			_delegateCanvasGroup = GetComponent<DelegateCanvasGroup>();
		}

		public virtual void SetVisible(bool isVisible)
		{
			base.gameObject.SetActive(isVisible);
			SetSelected(isVisible);
		}

		public virtual void SetSelected(bool isSelected)
		{
			_delegateCanvasGroup.SetInteractable(isSelected);
			_delegateCanvasGroup.SetBlocksRaycasts(isSelected);
		}

		public virtual void OnMapButtonSelected(bool isMapButtonSelected)
		{
		}
	}
}
