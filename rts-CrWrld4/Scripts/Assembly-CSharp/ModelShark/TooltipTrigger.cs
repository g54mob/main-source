using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModelShark
{
	public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, IPointerDownHandler, IPointerUpHandler
	{
		[HideInInspector]
		public TooltipStyle tooltipStyle;

		[HideInInspector]
		public List<ParameterizedTextField> parameterizedTextFields;

		[HideInInspector]
		public List<DynamicImageField> dynamicImageFields;

		[HideInInspector]
		public List<DynamicSectionField> dynamicSectionFields;

		[HideInInspector]
		public bool isRemotelyActivated;

		public Color backgroundTint;

		public TipPosition tipPosition;

		public int minTextWidth;

		public int maxTextWidth;

		[HideInInspector]
		public bool staysOpen;

		[HideInInspector]
		public bool neverRotate;

		[HideInInspector]
		public bool isBlocking;

		private float hoverTimer;

		private float popupTimer;

		private float tooltipDelay;

		private float popupTime;

		private bool isInitialized;

		private bool isMouseOver;

		private bool isMouseDown;

		public Tooltip Tooltip { get; private set; }

		public void Start()
		{
		}

		private void Initialize()
		{
		}

		private void Update()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnMouseOver()
		{
		}

		public void OnMouseDown()
		{
		}

		public void OnMouseExit()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnMouseUp()
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public void StartHover()
		{
		}

		public void ForceHideTooltip()
		{
		}

		public void StopHover()
		{
		}

		public void Popup(float duration, GameObject triggeredBy)
		{
		}

		public void SetText(string parameterName, string text)
		{
		}

		public void SetImage(string parameterName, Sprite sprite)
		{
		}

		public void TurnSectionOn(string parameterName)
		{
		}

		public void TurnSectionOff(string parameterName)
		{
		}

		private void ToggleSection(string parameterName, bool isOn)
		{
		}

		public void OnDisable()
		{
		}
	}
}
