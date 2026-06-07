using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Menu.LevelMenuVR
{
	public class ShowTooltipScript : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public Vector3 _offset = new Vector3(0f, 20f, -0.5f);

		private TooltipScript _tooltip;

		[SerializeField]
		private string _tooltipText = string.Empty;

		public Vector3 Offset => _offset;

		public string TooltipText
		{
			get
			{
				return _tooltipText;
			}
			set
			{
				_tooltipText = value;
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (_tooltip == null)
			{
				_tooltip = TooltipScript.Create(this, _tooltipText);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_tooltip?.Dismiss();
			_tooltip = null;
		}

		protected virtual void OnDisable()
		{
			_tooltip?.Dismiss();
			_tooltip = null;
		}
	}
}
