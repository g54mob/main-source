using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HSVPicker
{
	[RequireComponent(typeof(BoxSlider), typeof(RawImage))]
	[DefaultExecutionOrder(10)]
	[ExecuteInEditMode]
	public class SVBoxSlider : MonoBehaviour, IEndDragHandler, IEventSystemHandler
	{
		public ColorPicker picker;

		private BoxSlider slider;

		private RawImage image;

		private int textureWidth;

		private int textureHeight;

		private float lastH;

		private bool listen;

		[Header("Event")]
		public SliderOnChangeEndEvent onSliderChangeEndEvent;

		public RectTransform rectTransform => null;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void SliderChanged(float saturation, float value)
		{
		}

		private void HSVChanged(float h, float s, float v)
		{
		}

		private void RegenerateSVTexture()
		{
		}

		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}
	}
}
