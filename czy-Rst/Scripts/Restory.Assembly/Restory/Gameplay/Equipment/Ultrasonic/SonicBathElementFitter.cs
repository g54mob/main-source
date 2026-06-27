using System;
using Restory.Gameplay.Elements;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathElementFitter : MonoBehaviour
	{
		[SerializeField]
		private BoxCollider placementCollider;

		private Transform planeTransform;

		private Vector3 planeCenter;

		private float planeSizeX;

		private float planeSizeZ;

		private ElementBase targetElement;

		private ElementFitData elementFit;

		public bool HasTarget => targetElement;

		public event Action OnTargetChanged;

		private void Start()
		{
			planeTransform = placementCollider.transform;
			planeCenter = placementCollider.center;
			Vector3 lossyScale = planeTransform.lossyScale;
			planeSizeX = Mathf.Abs(placementCollider.size.x * lossyScale.x);
			planeSizeZ = Mathf.Abs(placementCollider.size.z * lossyScale.z);
		}

		public bool TryFitElement(ElementBase element, Vector3 hitPosition)
		{
			if (!targetElement || targetElement != element)
			{
				targetElement = element;
				elementFit = GetElementFit(element);
				if (elementFit.FitScaleFactor < 1f)
				{
					element.transform.localScale *= elementFit.FitScaleFactor;
				}
				this.OnTargetChanged?.Invoke();
			}
			Vector3 vector = planeTransform.InverseTransformPoint(hitPosition) - planeCenter;
			float num = Mathf.Clamp(vector.x, elementFit.OffsetRangeX.x, elementFit.OffsetRangeX.y);
			float num2 = Mathf.Clamp(vector.z, elementFit.OffsetRangeZ.x, elementFit.OffsetRangeZ.y);
			Vector3 position = new Vector3(num + planeCenter.x, planeCenter.y, num2 + planeCenter.z);
			element.transform.position = planeTransform.TransformPoint(position);
			return true;
		}

		public bool TryGetInsertedElementFitData(ElementBase element, out ElementFitData elementFitData)
		{
			elementFitData = elementFit;
			if (element != targetElement)
			{
				Debug.LogError("Current targetElement is not equal to inserted element " + element.Info.ID);
				return false;
			}
			targetElement = null;
			elementFit = null;
			this.OnTargetChanged?.Invoke();
			return true;
		}

		public void ResetElement()
		{
			if ((bool)targetElement)
			{
				targetElement.transform.localScale = elementFit.OriginalScale;
				targetElement = null;
				elementFit = null;
				this.OnTargetChanged?.Invoke();
			}
		}

		private ElementFitData GetElementFit(ElementBase element)
		{
			ElementPlacementPositionData placementPositionData = element.PlacementPositionHandler.PlacementPositionData;
			GetProjectedSize(placementPositionData, out var sizeX, out var sizeZ);
			float a = ((sizeX > planeSizeX) ? (planeSizeX / sizeX) : 1f);
			float b = ((sizeZ > planeSizeZ) ? (planeSizeZ / sizeZ) : 1f);
			float num = Mathf.Min(a, b);
			float num2 = sizeX * num;
			float num3 = sizeZ * num;
			float num4 = Mathf.Max(0f, planeSizeZ * 0.5f - num3 * 0.5f);
			float num5 = planeSizeX * 0.5f - num2 * 0.5f;
			if (num5 < 0f)
			{
				Debug.LogError($"Element projected X ({num2:F4}) exceeds plane X ({planeSizeX:F4}) after scaling");
				return new ElementFitData
				{
					ElementInfo = element.Info,
					OriginalScale = element.transform.localScale,
					FitScaleFactor = num,
					OffsetRangeX = Vector2.zero,
					OffsetRangeZ = new Vector2(0f - num4, num4)
				};
			}
			return new ElementFitData
			{
				ElementInfo = element.Info,
				OriginalScale = element.transform.localScale,
				FitScaleFactor = num,
				OffsetRangeX = new Vector2(0f - num5, num5),
				OffsetRangeZ = new Vector2(0f - num4, num4)
			};
		}

		private void GetProjectedSize(ElementPlacementPositionData placementData, out float sizeX, out float sizeZ)
		{
			Vector3 boxColliderSize = placementData.BoxColliderSize;
			Quaternion placementRotation = placementData.PlacementRotation;
			Vector3 lhs = placementRotation * Vector3.right * boxColliderSize.x;
			Vector3 lhs2 = placementRotation * Vector3.up * boxColliderSize.y;
			Vector3 lhs3 = placementRotation * Vector3.forward * boxColliderSize.z;
			Vector3 right = planeTransform.right;
			Vector3 forward = planeTransform.forward;
			sizeX = Mathf.Abs(Vector3.Dot(lhs, right)) + Mathf.Abs(Vector3.Dot(lhs2, right)) + Mathf.Abs(Vector3.Dot(lhs3, right));
			sizeZ = Mathf.Abs(Vector3.Dot(lhs, forward)) + Mathf.Abs(Vector3.Dot(lhs2, forward)) + Mathf.Abs(Vector3.Dot(lhs3, forward));
		}
	}
}
