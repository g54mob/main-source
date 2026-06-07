using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SkywardRay.FileBrowser
{
	public class SfbEntry : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
	{
		private enum State
		{
			Normal = 0,
			Highlighted = 1,
			Selected = 2,
			Pressed = 3
		}

		public SfbEntryType type;

		public Graphic targetGraphic;

		public SfbFileSystemEntry fileSystemEntry;

		public Color normalColor;

		public Color highlightedColor;

		public Color selectedColor;

		public Color pressedColor;

		public float fadeDuration;

		private bool _selected;

		private bool _pressed;

		private bool isPointerDown;

		private bool isPointerInside;

		private State state;

		internal SfbEntryWrapper wrapper;

		private SfbPanel parentPanel;

		public bool Selected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Pressed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnEnable()
		{
		}

		private void UpdateState()
		{
		}

		private void UpdateColor(bool instant = false)
		{
		}

		private void StartColorTween(Color targetColor, bool instant)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnDrop(PointerEventData eventData)
		{
		}
	}
}
