using System;
using UnityEngine;

namespace DV
{
	public sealed class CameraTrigger : MonoBehaviour
	{
		private static Vector3 cameraPoint;

		private static bool cameraIsNull;

		private static int frameTimestamp;

		public BoxCollider box;

		private float boundingRadiusSqr;

		public bool IsMainCameraInside { get; private set; }

		public event Action OnMainCameraEnter;

		public event Action OnMainCameraExit;

		public bool IsPointInside(Vector3 worldPoint)
		{
			Vector3 vector = base.transform.InverseTransformPoint(worldPoint) - box.center;
			float num = box.size.x * 0.5f;
			float num2 = box.size.y * 0.5f;
			float num3 = box.size.z * 0.5f;
			if (vector.x.IsInRange(0f - num, num) && vector.y.IsInRange(0f - num2, num2))
			{
				return vector.z.IsInRange(0f - num3, num3);
			}
			return false;
		}

		private void Start()
		{
			UpdateBoundingRadius();
		}

		private void LateUpdate()
		{
			if (frameTimestamp != Time.frameCount)
			{
				UpdateCameraData();
			}
			Vector3 position = base.transform.position;
			if (cameraIsNull || (position.x - cameraPoint.x) * (position.x - cameraPoint.x) + (position.y - cameraPoint.y) * (position.y - cameraPoint.y) + (position.z - cameraPoint.z) * (position.z - cameraPoint.z) > boundingRadiusSqr)
			{
				if (IsMainCameraInside)
				{
					IsMainCameraInside = false;
					this.OnMainCameraExit?.Invoke();
				}
				return;
			}
			position = base.transform.InverseTransformPoint(cameraPoint) - box.center;
			float num = box.size.x * 0.5f;
			float num2 = box.size.y * 0.5f;
			float num3 = box.size.z * 0.5f;
			bool flag = position.x.IsInRange(0f - num, num) && position.y.IsInRange(0f - num2, num2) && position.z.IsInRange(0f - num3, num3);
			if (IsMainCameraInside != flag)
			{
				IsMainCameraInside = flag;
				(flag ? this.OnMainCameraEnter : this.OnMainCameraExit)?.Invoke();
			}
		}

		private void UpdateBoundingRadius()
		{
			float num = (box.size.x + Mathf.Abs(box.center.x)) * base.transform.localScale.x;
			float num2 = (box.size.y + Mathf.Abs(box.center.y)) * base.transform.localScale.y;
			float num3 = (box.size.z + Mathf.Abs(box.center.z)) * base.transform.localScale.z;
			boundingRadiusSqr = num * num + num2 * num2 + num3 * num3;
		}

		private void UpdateCameraData()
		{
			frameTimestamp = Time.frameCount;
			Camera activeCamera = PlayerManager.ActiveCamera;
			cameraIsNull = activeCamera == null;
			if (!cameraIsNull)
			{
				cameraPoint = activeCamera.transform.position;
			}
		}
	}
}
