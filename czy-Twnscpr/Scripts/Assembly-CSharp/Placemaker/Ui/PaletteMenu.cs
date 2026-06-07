using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class PaletteMenu : UIBehaviour, UiMaster.IUiSetup, IDragHandler, IEventSystemHandler, IEndDragHandler, IBeginDragHandler
	{
		public interface IPaletteSetup
		{
			void OnSetup();
		}

		[SerializeField]
		private UiMaster master;

		[SerializeField]
		private Palette palette;

		public sbyte selectedPickerIndex;

		[SerializeField]
		public List<PalettePicker> palettePickers;

		[SerializeField]
		private float targetScroll;

		[SerializeField]
		private float currentScroll;

		[SerializeField]
		private RectTransform t0;

		[SerializeField]
		private RectTransform t1;

		[SerializeField]
		private RectTransform verticalAnchor0;

		[SerializeField]
		private RectTransform verticalAnchor1;

		[SerializeField]
		private RectTransform horizontalAnchor0;

		[SerializeField]
		private RectTransform horizontalAnchor1;

		[SerializeField]
		private RectTransform toucher;

		private Vector2 p0;

		private Vector2 p1;

		private Vector2 dir;

		private float dist;

		private float pickerSize;

		private float lossyScale;

		private float invLossyScale;

		private RapidButton rapidButton;

		[SerializeField]
		private bool updating;

		[SerializeField]
		private bool snap;

		private void Update()
		{
		}

		private void SetNewTargetScroll(float newTargetScroll)
		{
		}

		public void PushColor(PalettePicker picker)
		{
		}

		public void ColorPick(Voxel voxel)
		{
		}

		private void SelectPicker(PalettePicker picker)
		{
		}

		private void FramePicker(PalettePicker picker)
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		private void OnDimensionsChange(RectTransform rt)
		{
		}

		public void SelectPicker(int index)
		{
		}

		public void SelectNextPicker(int delta = 1)
		{
		}

		public void HoldSelectNextPicker(int delta = 1)
		{
		}

		public void PickerClicked(PalettePicker picker)
		{
		}

		private void OnDrawGizmos()
		{
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
		}

		private void ClampTargetScroll()
		{
		}

		private void UpdateAnchors()
		{
		}

		public void ResetPickers()
		{
		}
	}
}
