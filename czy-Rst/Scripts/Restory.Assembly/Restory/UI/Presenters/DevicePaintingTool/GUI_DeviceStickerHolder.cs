using System;
using UnityEngine;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_DeviceStickerHolder : MonoBehaviour
	{
		public Action<GUI_DeviceStickerHolder> OnStickerStartDrag;

		public Action<GUI_DeviceStickerHolder> OnStickerStopDrag;

		[SerializeField]
		private GUI_DeviceSticker sticker;

		[SerializeField]
		private GUI_DeviceStickerVisualizer visualizer;

		[SerializeField]
		private Transform stickerPivot;

		public GUI_DeviceSticker Sticker => sticker;

		public GUI_DeviceStickerVisualizer Visualizer => visualizer;

		private void OnEnable()
		{
			GUI_DeviceSticker gUI_DeviceSticker = sticker;
			gUI_DeviceSticker.OnStartDrag = (Action)Delegate.Combine(gUI_DeviceSticker.OnStartDrag, new Action(ResolveStickerStartDrag));
			GUI_DeviceSticker gUI_DeviceSticker2 = sticker;
			gUI_DeviceSticker2.OnStopDrag = (Action)Delegate.Combine(gUI_DeviceSticker2.OnStopDrag, new Action(ResolveStickerStopDrag));
			visualizer.PlayScaleAnimation();
		}

		private void OnDisable()
		{
			GUI_DeviceSticker gUI_DeviceSticker = sticker;
			gUI_DeviceSticker.OnStartDrag = (Action)Delegate.Remove(gUI_DeviceSticker.OnStartDrag, new Action(ResolveStickerStartDrag));
			GUI_DeviceSticker gUI_DeviceSticker2 = sticker;
			gUI_DeviceSticker2.OnStopDrag = (Action)Delegate.Remove(gUI_DeviceSticker2.OnStopDrag, new Action(ResolveStickerStopDrag));
		}

		public void PickSticker(Transform parent)
		{
			base.transform.SetAsLastSibling();
			sticker.transform.SetParent(parent);
		}

		public void ReleaseSticker()
		{
			sticker.transform.SetParent(stickerPivot);
			sticker.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
		}

		private void ResolveStickerStartDrag()
		{
			OnStickerStartDrag?.Invoke(this);
		}

		private void ResolveStickerStopDrag()
		{
			OnStickerStopDrag?.Invoke(this);
		}
	}
}
