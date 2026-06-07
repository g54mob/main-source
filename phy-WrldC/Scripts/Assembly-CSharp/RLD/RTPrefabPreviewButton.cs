using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RLD
{
	public class RTPrefabPreviewButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public delegate void HoverEnterHandler(RTPrefab prefab);

		public delegate void HoverExitHandler(RTPrefab prefab);

		private Text _text;

		private RTPrefab _prefab;

		public RTPrefab Prefab
		{
			get
			{
				return _prefab;
			}
			set
			{
				if (value != null)
				{
					_prefab = value;
				}
			}
		}

		public string Text
		{
			get
			{
				if (!(_text != null))
				{
					return string.Empty;
				}
				return _text.text;
			}
			set
			{
				if (_text != null && value != null)
				{
					_text.text = value;
				}
			}
		}

		public event HoverEnterHandler HoverEnter;

		public event HoverExitHandler HoverExit;

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.HoverEnter != null)
			{
				this.HoverEnter(_prefab);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (this.HoverExit != null)
			{
				this.HoverExit(_prefab);
			}
		}

		private void OnEnable()
		{
			_text = base.gameObject.GetComponentInChildren<Text>();
		}
	}
}
