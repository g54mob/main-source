using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lean.Touch
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Lean/Touch/Lean Touch")]
	[HelpURL("https://carloswilkes.com/Documentation/LeanTouch#LeanTouch")]
	[DefaultExecutionOrder(-100)]
	[ExecuteInEditMode]
	public class LeanTouch : MonoBehaviour
	{
		public const string ComponentPathPrefix = "Lean/Touch/Lean ";

		public const string HelpUrlPrefix = "https://carloswilkes.com/Documentation/LeanTouch#";

		public const string PlusHelpUrlPrefix = "https://carloswilkes.com/Documentation/LeanTouchPlus#";

		public const int MOUSE_FINGER_INDEX = -1;

		public const int HOVER_FINGER_INDEX = -42;

		private const int DEFAULT_REFERENCE_DPI = 200;

		private const int DEFAULT_GUI_LAYERS = 32;

		private const float DEFAULT_TAP_THRESHOLD = 0.2f;

		private const float DEFAULT_SWIPE_THRESHOLD = 100f;

		private const float DEFAULT_RECORD_LIMIT = 10f;

		public static List<LeanTouch> Instances;

		public static List<LeanFinger> Fingers;

		public static List<LeanFinger> InactiveFingers;

		[SerializeField]
		private float tapThreshold;

		[SerializeField]
		private float swipeThreshold;

		[SerializeField]
		private int referenceDpi;

		[SerializeField]
		private LayerMask guiLayers;

		[SerializeField]
		private bool useTouch;

		[SerializeField]
		private bool useHover;

		[SerializeField]
		private bool useMouse;

		[SerializeField]
		private bool useSimulator;

		[SerializeField]
		private bool disableMouseEmulation;

		[SerializeField]
		private bool recordFingers;

		[SerializeField]
		private float recordThreshold;

		[SerializeField]
		private float recordLimit;

		private static List<RaycastResult> tempRaycastResults;

		private static List<LeanFinger> filteredFingers;

		private static PointerEventData tempPointerEventData;

		private static EventSystem tempEventSystem;

		private static LeanFinger simulatedTapFinger;

		private static HashSet<LeanFinger> missingFingers;

		private static List<LeanFinger> tempFingers;

		public float TapThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static float CurrentTapThreshold => 0f;

		public float SwipeThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static float CurrentSwipeThreshold => 0f;

		public int ReferenceDpi
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public static int CurrentReferenceDpi => 0;

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

		public static LayerMask CurrentGuiLayers => default(LayerMask);

		public bool UseTouch
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseHover
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseMouse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseSimulator
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DisableMouseEmulation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool RecordFingers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float RecordThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float RecordLimit
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static LeanTouch Instance => null;

		public static float ScalingFactor => 0f;

		public static float ScreenFactor => 0f;

		public static bool GuiInUse => false;

		public static event Action<LeanFinger> OnFingerDown
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

		public static event Action<LeanFinger> OnFingerUpdate
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

		public static event Action<LeanFinger> OnFingerUp
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

		public static event Action<LeanFinger> OnFingerOld
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

		public static event Action<LeanFinger> OnFingerTap
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

		public static event Action<LeanFinger> OnFingerSwipe
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

		public static event Action<List<LeanFinger>> OnGesture
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

		public static event Action<LeanFinger> OnFingerExpired
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

		public static event Action<LeanFinger> OnFingerInactive
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

		public event Action OnSimulateFingers
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

		public static bool ElementOverlapped(GameObject element, Vector2 screenPosition)
		{
			return false;
		}

		public static EventSystem GetEventSystem()
		{
			return null;
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

		public static List<LeanFinger> GetFingers(bool ignoreIfStartedOverGui, bool ignoreIfOverGui, int requiredFingerCount = 0, bool ignoreHoverFinger = true)
		{
			return null;
		}

		public static void SimulateTap(Vector2 screenPosition, float pressure = 1f, int tapCount = 1)
		{
		}

		public void Clear()
		{
		}

		public void UpdateMouseEmulation()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void Update()
		{
		}

		private void UpdateFingers(float deltaTime, bool poll)
		{
		}

		private void BeginFingers(float deltaTime)
		{
		}

		private void EndFingers(float deltaTime)
		{
		}

		private void PollFingers()
		{
		}

		private void UpdateEvents()
		{
		}

		public LeanFinger AddFinger(int index, Vector2 screenPosition, float pressure, bool set)
		{
			return null;
		}

		private LeanFinger FindFinger(int index)
		{
			return null;
		}

		private int FindInactiveFingerIndex(int index)
		{
			return 0;
		}
	}
}
