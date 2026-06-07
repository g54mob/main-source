using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceGraphicsToolkit
{
	public class SgtInputManager : SgtLinkedBehaviour<SgtInputManager>
	{
		public class Finger
		{
			public int Index;

			public bool Marked;

			public float Age;

			public bool StartedOverGui;

			public Vector2 StartScreenPosition;

			public Vector2 LastScreenPosition;

			public Vector2 ScreenPosition;
		}

		public bool SimulateMultiFingers;

		public KeyCode PinchTwistKey;

		public KeyCode MultiDragKey;

		public static List<Finger> Fingers;

		public static Action<Finger> OnFingerTap;

		private static List<RaycastResult> tempRaycastResults;

		private static PointerEventData tempPointerEventData;

		private static EventSystem tempEventSystem;

		private static List<Finger> filteredFingers;

		public static bool AnyMouseButtonSet => false;

		public static void UpdateExists()
		{
		}

		public static List<Finger> GetFingers(bool ignoreIfStartedOverGui)
		{
			return null;
		}

		public static Vector2 GetScaledDelta(List<Finger> fingers)
		{
			return default(Vector2);
		}

		public static Vector2 GetLastScreenCenter(List<Finger> fingers)
		{
			return default(Vector2);
		}

		public static Vector2 GetScreenCenter(List<Finger> fingers)
		{
			return default(Vector2);
		}

		public static float GetScreenDistance(List<Finger> fingers, Vector2 center)
		{
			return 0f;
		}

		public static float GetLastScreenDistance(List<Finger> fingers, Vector2 center)
		{
			return 0f;
		}

		public static float GetPinchScale(List<Finger> fingers, float wheelSensitivity = 0f)
		{
			return 0f;
		}

		public static bool PointOverGui(Vector2 screenPosition)
		{
			return false;
		}

		public static List<RaycastResult> RaycastGui(Vector2 screenPosition)
		{
			return null;
		}

		public static List<RaycastResult> RaycastGui(Vector2 screenPosition, LayerMask layerMask)
		{
			return null;
		}

		protected override void OnEnable()
		{
		}

		protected virtual void Update()
		{
		}

		private void Mark()
		{
		}

		private void Poll()
		{
		}

		private void AddFinger(int index, Vector2 screenPosition)
		{
		}

		private Finger FindFinger(int index)
		{
			return null;
		}

		private void Sweep()
		{
		}
	}
}
