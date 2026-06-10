using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval_Pooling;
using UnityEngine;
using UnityEngine.UI.Extensions;

namespace NSMedieval.Tutorial
{
	public class ScreenPointerManager : MonoSingleton<ScreenPointerManager>
	{
		private readonly struct ScreenPointerData
		{
			public readonly Vector3 Offset;

			public readonly RectTransform RectTransform;

			public readonly Vector3 TargetPosition;

			public readonly bool HideIfTargetOnScreen;

			public ScreenPointerData(Vector3 targetPosition, Vector3 offset, RectTransform rectTransform, bool hideIfTargetOnScreen)
			{
				TargetPosition = targetPosition;
				Offset = offset;
				RectTransform = rectTransform;
				HideIfTargetOnScreen = hideIfTargetOnScreen;
			}
		}

		private const string PointerPrefabAddress = "ScreenPointer";

		[SerializeField]
		private Transform pointerParent;

		[SerializeField]
		private float offsetTop = 150f;

		[SerializeField]
		private float offsetBottom = 250f;

		[SerializeField]
		private float offsetLeft = 50f;

		[SerializeField]
		private float offsetRight = 50f;

		private Camera cam;

		private readonly Dictionary<Vector3, ScreenPointerData> targetOffsets = new Dictionary<Vector3, ScreenPointerData>();

		public void AddTarget(Vector3 targetPosition)
		{
			AddTarget(targetPosition, Vector3.zero);
		}

		public void AddTarget(Vector3 targetPosition, Vector3 offset, bool hideIfTargetOnScreen = false)
		{
			RectTransform component = GameObjectPool.Get("ScreenPointer").GetComponent<RectTransform>();
			bool isEnabled;
			if (!targetOffsets.TryAdd(targetPosition, new ScreenPointerData(targetPosition, offset, component, hideIfTargetOnScreen)))
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ScreenPointerManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Target position ");
					messageBuilder.AppendFormatted(targetPosition);
					messageBuilder.AppendLiteral(" already added");
				}
				Log.Error(messageBuilder);
				GameObjectPool.Return(component.gameObject);
				return;
			}
			FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(36, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ScreenPointerManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Adding target ");
				messageBuilder2.AppendFormatted(targetPosition);
				messageBuilder2.AppendLiteral(" with offset ");
				messageBuilder2.AppendFormatted(offset);
				messageBuilder2.AppendLiteral(". Scale: ");
				messageBuilder2.AppendFormatted(component.localScale);
			}
			Log.Debug(messageBuilder2);
			component.transform.SetParent(pointerParent, worldPositionStays: false);
			messageBuilder2 = new FVLogDebugInterpolationHandler(28, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\ScreenPointerManager.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("Scale after setting parent: ");
				messageBuilder2.AppendFormatted(component.localScale);
			}
			Log.Debug(messageBuilder2);
		}

		public void TryRemoveTarget(Vector3 targetPosition)
		{
			if (targetOffsets.TryGetValue(targetPosition, out var value))
			{
				GameObjectPool.Return(value.RectTransform.gameObject);
				targetOffsets.Remove(targetPosition);
			}
		}

		private void UpdatePointers()
		{
			if ((object)cam == null)
			{
				return;
			}
			foreach (ScreenPointerData value in targetOffsets.Values)
			{
				if (!value.RectTransform || !value.RectTransform)
				{
					continue;
				}
				float num = (float)Screen.width / 2f;
				float num2 = (float)Screen.height / 2f;
				Vector2 vector = new Vector2(0f, 0f);
				Vector3 vector2 = cam.WorldToScreenPoint(value.TargetPosition + value.Offset * (MonoSingleton<RtsCamera>.Instance.CurrentHeightNormalized * 0.5f + 0.6f));
				if (vector2.z < 0f)
				{
					vector2 *= -1f;
				}
				Vector2 vector3 = new Vector2(vector2.x - num, vector2.y - num2);
				Vector2 normalized = (vector3 - vector).normalized;
				bool num3 = vector2.x <= offsetLeft || vector2.x >= (float)Screen.width - offsetRight || vector2.y <= offsetBottom || vector2.y >= (float)Screen.height - offsetTop;
				Vector2 vector4 = vector3;
				if (num3)
				{
					if (vector2.x <= offsetLeft)
					{
						vector4.x = 0f - num + offsetLeft;
					}
					if (vector2.x >= (float)Screen.width - offsetRight)
					{
						vector4.x = num - offsetRight;
					}
					if (vector2.y <= offsetBottom)
					{
						vector4.y = 0f - num2 + offsetBottom;
					}
					if (vector2.y >= (float)Screen.height - offsetTop)
					{
						vector4.y = num2 - offsetTop;
					}
					value.RectTransform.gameObject.SetActive(value: true);
					float z = Mathf.Atan2(normalized.y, normalized.x) * 57.29578f;
					value.RectTransform.rotation = Quaternion.Euler(0f, 0f, z);
				}
				else
				{
					if (value.HideIfTargetOnScreen)
					{
						value.RectTransform.gameObject.SetActive(value: false);
					}
					value.RectTransform.rotation = Quaternion.Euler(0f, 0f, -90f);
				}
				float scaleFactor = value.RectTransform.GetParentCanvas().scaleFactor;
				value.RectTransform.anchoredPosition = vector4 / scaleFactor;
			}
		}

		private void Update()
		{
			UpdatePointers();
		}

		private void Start()
		{
			cam = MonoSingleton<CameraManager>.Instance.GameplayCamera;
		}
	}
}
