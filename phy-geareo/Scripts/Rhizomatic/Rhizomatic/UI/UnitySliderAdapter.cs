using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rhizomatic.UI
{
	public class UnitySliderAdapter : SliderAdapter, IPointerUpHandler, IEventSystemHandler
	{
		public Slider component;

		private bool changed;

		private bool cooking;

		public override float minValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override float maxValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override bool wholeNumbers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void WithCooking(Action action)
		{
		}

		private void Awake()
		{
		}

		protected override void UpdateView()
		{
		}

		private void Reset()
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		private void OnDisable()
		{
		}
	}
}
