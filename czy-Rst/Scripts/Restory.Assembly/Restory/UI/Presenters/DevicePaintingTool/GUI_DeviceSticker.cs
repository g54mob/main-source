using System;
using Restory.Data.Stickers;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters.DevicePaintingTool
{
	public class GUI_DeviceSticker : MonoBehaviour
	{
		public Action OnStartDrag;

		public Action OnStopDrag;

		[SerializeField]
		private Image stickerImage;

		[SerializeField]
		private DeviceStickerInfo stickerInfo;

		[Space]
		[Header("Drag Settings")]
		[SerializeField]
		private Vector3 dragScale = new Vector3(1.2f, 1.2f, 1.2f);

		[SerializeField]
		private float dragRotationSpeed = 400f;

		public DeviceStickerInfo StickerInfo => stickerInfo;

		public void StartDrag()
		{
			OnStartDrag?.Invoke();
			base.transform.localScale = dragScale;
		}

		public void Drag(Vector2 screenPosition, float deltaTime)
		{
			base.transform.position = screenPosition;
			base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.identity, dragRotationSpeed * deltaTime);
		}

		public void StopDrag()
		{
			OnStopDrag?.Invoke();
			base.transform.localScale = Vector3.one;
		}
	}
}
