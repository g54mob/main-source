using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class SunButton : UIBehaviour, UiMaster.IUiSetup
	{
		[SerializeField]
		public UiMaster master;

		[SerializeField]
		private RectTransform handleX;

		[SerializeField]
		private RectTransform handleX1;

		[SerializeField]
		private RectTransform handleY;

		[SerializeField]
		private RectTransform handleBoth;

		[SerializeField]
		private RectTransform handleBoth1;

		[SerializeField]
		private RectTransform circle0;

		[SerializeField]
		private RectTransform circle1;

		[SerializeField]
		private RectTransform horizontalLine;

		[SerializeField]
		private RectTransform bothContainer;

		[SerializeField]
		private SunSlider sliderX;

		[SerializeField]
		private SunSlider sliderY;

		[SerializeField]
		public SunSlider sliderBoth;

		[SerializeField]
		private Vector2 current;

		[SerializeField]
		private Vector2 start;

		[SerializeField]
		private UpdateState handle0scale;

		[SerializeField]
		private UpdateState handle1scale;

		[SerializeField]
		private UpdateState sunX;

		[SerializeField]
		private UpdateState sunY;

		[SerializeField]
		private Gradient bulbColor;

		[SerializeField]
		private SunSlider currentSlider;

		private float scale1;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		public void OnClick(PointerEventData eventData, SunSlider slider)
		{
		}

		public void OnBeginDrag(PointerEventData eventData, SunSlider slider)
		{
		}

		public void OnDrag(PointerEventData eventData, SunSlider slider)
		{
		}

		private void PushValues()
		{
		}

		private void PushBulbColors()
		{
		}

		public void SetGamepad(bool isEnabled)
		{
		}

		public void OnEndDrag(PointerEventData eventData, SunSlider slider)
		{
		}

		public void ImportSunValues()
		{
		}

		private void Update()
		{
		}
	}
}
