using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CW.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/Common#CwInputManager")]
	[AddComponentMenu("Common/CW Input Manager")]
	public class CwInputManager : MonoBehaviour
	{
		public enum AxisGesture
		{
			HorizontalDrag = 0,
			VerticalDrag = 1,
			Twist = 2,
			HorizontalPull = 3,
			VerticalPull = 4
		}

		[Serializable]
		public struct Axis
		{
			public int FingerCount;

			public bool FingerInvert;

			public AxisGesture FingerGesture;

			public float FingerSensitivity;

			public KeyCode KeyNegative;

			public KeyCode KeyPositive;

			public KeyCode KeyNegativeAlt;

			public KeyCode KeyPositiveAlt;

			public float KeySensitivity;

			public Axis(int fCount, bool fInvert, AxisGesture fGesture, float fSensitivty, KeyCode kNegative, KeyCode kPositive, KeyCode kNegativeAlt, KeyCode kPositiveAlt, float kSensitivity)
			{
				FingerCount = 0;
				FingerInvert = false;
				FingerGesture = default(AxisGesture);
				FingerSensitivity = 0f;
				KeyNegative = default(KeyCode);
				KeyPositive = default(KeyCode);
				KeyNegativeAlt = default(KeyCode);
				KeyPositiveAlt = default(KeyCode);
				KeySensitivity = 0f;
			}

			public float GetValue(float delta)
			{
				return 0f;
			}
		}

		[Serializable]
		public struct Trigger
		{
			public bool UseFinger;

			public bool UseMouse;

			public KeyCode UseKey;

			public Trigger(bool uFinger, bool uMouse, KeyCode uKey)
			{
				UseFinger = false;
				UseMouse = false;
				UseKey = default(KeyCode);
			}

			public bool WentDown(Finger finger)
			{
				return false;
			}

			public bool IsDown(Finger finger)
			{
				return false;
			}

			public bool WentUp(Finger finger, bool useAnyFinger = false)
			{
				return false;
			}
		}

		public abstract class Link
		{
			public Finger Finger;

			public static T Find<T>(List<T> links, Finger finger) where T : new()
			{
				return default(T);
			}

			public static T Create<T>(ref List<T> links, Finger finger) where T : new()
			{
				return default(T);
			}

			public static void ClearAll<T>(List<T> links)
			{
			}

			public static void ClearAndRemove<T>(List<T> links, T link)
			{
			}

			public virtual void Clear()
			{
			}
		}

		public class Finger
		{
			public int Index;

			public float Pressure;

			public bool Down;

			public bool Up;

			public float Age;

			public bool StartedOverGui;

			public Vector2 StartScreenPosition;

			public Vector2 ScreenPosition;

			public Vector2 ScreenPositionOld;

			public Vector2 ScreenPositionOldOld;

			public Vector2 ScreenPositionOldOldOld;

			public float SmoothScreenPositionDelta => 0f;

			public Vector2 GetSmoothScreenPosition(float t)
			{
				return default(Vector2);
			}
		}

		[SerializeField]
		private LayerMask guiLayers;

		public const int MOUSE_FINGER_INDEX = -1;

		public const int HOVER_FINGER_INDEX = -1337;

		private static List<RaycastResult> tempRaycastResults;

		private static PointerEventData tempPointerEventData;

		private static EventSystem tempEventSystem;

		private static List<Finger> fingers;

		private static List<Finger> filteredFingers;

		private static Stack<Finger> pool;

		public LayerMask GuiLayers
		{
			get
			{
				return default(LayerMask);
			}
			set
			{
			}
		}

		public static List<Finger> Fingers => null;

		public static float ScaleFactor => 0f;

		public static event Action<Finger> OnFingerDown
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<Finger> OnFingerUpdate
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<Finger> OnFingerUp
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static List<Finger> GetFingers(bool ignoreStartedOverGui = false, bool ignoreHover = false)
		{
			return null;
		}

		public static bool PointOverGui(Vector2 screenPosition, int guiLayers = 32)
		{
			return false;
		}

		public static List<RaycastResult> RaycastGui(Vector2 screenPosition, int guiLayers = 32)
		{
			return null;
		}

		public static Vector2 GetAveragePosition(List<Finger> fingers)
		{
			return default(Vector2);
		}

		public static Vector2 GetAverageOldPosition(List<Finger> fingers)
		{
			return default(Vector2);
		}

		public static Vector2 GetAveragePullScaled(List<Finger> fingers)
		{
			return default(Vector2);
		}

		public static Vector2 GetAverageDeltaScaled(List<Finger> fingers)
		{
			return default(Vector2);
		}

		public static float GetAverageTwistRadians(List<Finger> fingers)
		{
			return 0f;
		}

		public static void EnsureThisComponentExists()
		{
		}

		protected virtual void Update()
		{
		}

		private Finger FindFinger(int index)
		{
			return null;
		}

		private void AddFinger(int index, Vector2 screenPosition, float pressure, bool set)
		{
		}

		private static Vector2 Hermite(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
		{
			return default(Vector2);
		}

		private static float HermiteInterpolate(float y0, float y1, float y2, float y3, float mu, float mu2, float mu3)
		{
			return 0f;
		}

		private static float GetRadians(Vector2 screenPosition, Vector2 referencePoint)
		{
			return 0f;
		}

		private static float GetDeltaRadians(Finger finger, Vector2 referencePoint, Vector2 lastReferencePoint)
		{
			return 0f;
		}
	}
}
