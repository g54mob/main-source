using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("FingerGestures/Finger Gestures Singleton")]
public class FingerGestures : MonoBehaviour
{
	public enum FingerPhase
	{
		None = 0,
		Begin = 1,
		Moving = 2,
		Stationary = 3
	}

	public delegate void EventHandler();

	public class InputProviderEvent
	{
		public FGInputProvider inputProviderPrefab;
	}

	public class Finger
	{
		private int index;

		private FingerPhase phase;

		private FingerPhase prevPhase;

		private Vector2 pos = Vector2.zero;

		private Vector2 startPos = Vector2.zero;

		private Vector2 prevPos = Vector2.zero;

		private Vector2 deltaPos = Vector2.zero;

		private float startTime;

		private float lastMoveTime;

		private float distFromStart;

		private bool moved;

		private bool filteredOut = true;

		private Collider collider;

		private Collider prevCollider;

		private float elapsedTimeStationary;

		private List<GestureRecognizer> gestureRecognizers = new List<GestureRecognizer>();

		private Dictionary<string, object> extendedProperties = new Dictionary<string, object>();

		public int Index => index;

		public bool IsDown => phase != FingerPhase.None;

		public FingerPhase Phase => phase;

		public FingerPhase PreviousPhase => prevPhase;

		public bool WasDown => prevPhase != FingerPhase.None;

		public bool IsMoving => phase == FingerPhase.Moving;

		public bool WasMoving => prevPhase == FingerPhase.Moving;

		public bool IsStationary => phase == FingerPhase.Stationary;

		public bool WasStationary => prevPhase == FingerPhase.Stationary;

		public bool Moved => moved;

		public float StarTime => startTime;

		public Vector2 StartPosition => startPos;

		public Vector2 Position => pos;

		public Vector2 PreviousPosition => prevPos;

		public Vector2 DeltaPosition => deltaPos;

		public float DistanceFromStart => distFromStart;

		public bool IsFiltered => filteredOut;

		public float TimeStationary => elapsedTimeStationary;

		public List<GestureRecognizer> GestureRecognizers => gestureRecognizers;

		public Dictionary<string, object> ExtendedProperties => extendedProperties;

		public Finger(int index)
		{
			this.index = index;
		}

		public override string ToString()
		{
			return "Finger" + index;
		}

		public static implicit operator bool(Finger finger)
		{
			return finger != null;
		}

		internal void Update(bool newDownState, Vector2 newPos)
		{
			if (filteredOut && !newDownState)
			{
				filteredOut = false;
			}
			if (!IsDown && newDownState && !instance.ShouldProcessTouch(index, newPos))
			{
				filteredOut = true;
				newDownState = false;
			}
			prevPhase = phase;
			if (newDownState)
			{
				if (!WasDown)
				{
					phase = FingerPhase.Begin;
					pos = newPos;
					startPos = pos;
					prevPos = pos;
					deltaPos = Vector2.zero;
					moved = false;
					lastMoveTime = 0f;
					startTime = Time.time;
					elapsedTimeStationary = 0f;
					distFromStart = 0f;
					return;
				}
				prevPos = pos;
				pos = newPos;
				distFromStart = Vector3.Distance(startPos, pos);
				deltaPos = pos - prevPos;
				if (deltaPos.sqrMagnitude > 0f)
				{
					lastMoveTime = Time.time;
					phase = FingerPhase.Moving;
				}
				else if (!IsMoving || Time.time - lastMoveTime > 0.05f)
				{
					phase = FingerPhase.Stationary;
				}
				if (IsMoving)
				{
					moved = true;
				}
				else if (!WasStationary)
				{
					elapsedTimeStationary = 0f;
				}
				else
				{
					elapsedTimeStationary += Time.unscaledDeltaTime;
				}
			}
			else
			{
				phase = FingerPhase.None;
			}
		}
	}

	public delegate bool GlobalTouchFilterDelegate(int fingerIndex, Vector2 position);

	public interface IFingerList : IEnumerable<Finger>, IEnumerable
	{
		Finger this[int index] { get; }

		int Count { get; }

		Vector2 GetAverageStartPosition();

		Vector2 GetAveragePosition();

		Vector2 GetAveragePreviousPosition();

		float GetAverageDistanceFromStart();

		Finger GetOldest();

		bool AllMoving();

		bool MovingInSameDirection(float tolerance);
	}

	[Serializable]
	public class FingerList : IFingerList, IEnumerable<Finger>, IEnumerable
	{
		public delegate T FingerPropertyGetterDelegate<T>(Finger finger);

		[SerializeField]
		private List<Finger> list;

		private static FingerPropertyGetterDelegate<Vector2> delGetFingerStartPosition = GetFingerStartPosition;

		private static FingerPropertyGetterDelegate<Vector2> delGetFingerPosition = GetFingerPosition;

		private static FingerPropertyGetterDelegate<Vector2> delGetFingerPreviousPosition = GetFingerPreviousPosition;

		private static FingerPropertyGetterDelegate<float> delGetFingerDistanceFromStart = GetFingerDistanceFromStart;

		public Finger this[int index] => list[index];

		public int Count => list.Count;

		public FingerList()
		{
			list = new List<Finger>();
		}

		public FingerList(List<Finger> list)
		{
			this.list = list;
		}

		public IEnumerator<Finger> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(Finger touch)
		{
			list.Add(touch);
		}

		public bool Remove(Finger touch)
		{
			return list.Remove(touch);
		}

		public bool Contains(Finger touch)
		{
			return list.Contains(touch);
		}

		public void AddRange(IEnumerable<Finger> touches)
		{
			list.AddRange(touches);
		}

		public void Clear()
		{
			list.Clear();
		}

		public Vector2 AverageVector(FingerPropertyGetterDelegate<Vector2> getProperty)
		{
			Vector2 zero = Vector2.zero;
			if (Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					zero += getProperty(list[i]);
				}
				zero /= (float)Count;
			}
			return zero;
		}

		public float AverageFloat(FingerPropertyGetterDelegate<float> getProperty)
		{
			float num = 0f;
			if (Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					num += getProperty(list[i]);
				}
				num /= (float)Count;
			}
			return num;
		}

		private static Vector2 GetFingerStartPosition(Finger finger)
		{
			return finger.StartPosition;
		}

		private static Vector2 GetFingerPosition(Finger finger)
		{
			return finger.Position;
		}

		private static Vector2 GetFingerPreviousPosition(Finger finger)
		{
			return finger.PreviousPosition;
		}

		private static float GetFingerDistanceFromStart(Finger finger)
		{
			return finger.DistanceFromStart;
		}

		public Vector2 GetAverageStartPosition()
		{
			return AverageVector(delGetFingerStartPosition);
		}

		public Vector2 GetAveragePosition()
		{
			return AverageVector(delGetFingerPosition);
		}

		public Vector2 GetAveragePreviousPosition()
		{
			return AverageVector(delGetFingerPreviousPosition);
		}

		public float GetAverageDistanceFromStart()
		{
			return AverageFloat(delGetFingerDistanceFromStart);
		}

		public Finger GetOldest()
		{
			Finger finger = null;
			foreach (Finger item in list)
			{
				if (finger == null || item.StarTime < finger.StarTime)
				{
					finger = item;
				}
			}
			return finger;
		}

		public bool MovingInSameDirection(float tolerance)
		{
			if (Count < 2)
			{
				return true;
			}
			float num = Mathf.Max(0.1f, 1f - tolerance);
			Vector2 lhs = this[0].Position - this[0].StartPosition;
			lhs.Normalize();
			for (int i = 1; i < Count; i++)
			{
				Vector2 rhs = this[i].Position - this[i].StartPosition;
				rhs.Normalize();
				if (Vector2.Dot(lhs, rhs) < num)
				{
					return false;
				}
			}
			return true;
		}

		public bool AllMoving()
		{
			if (Count == 0)
			{
				return false;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (!list[i].IsMoving)
				{
					return false;
				}
			}
			return true;
		}
	}

	[Flags]
	public enum SwipeDirection
	{
		Right = 1,
		Left = 2,
		Up = 4,
		Down = 8,
		UpperLeftDiagonal = 0x10,
		UpperRightDiagonal = 0x20,
		LowerRightDiagonal = 0x40,
		LowerLeftDiagonal = 0x80,
		None = 0,
		Vertical = 0xC,
		Horizontal = 3,
		Cross = 0xF,
		UpperDiagonals = 0x30,
		LowerDiagonals = 0xC0,
		Diagonals = 0xF0,
		All = 0xFF
	}

	public static readonly RuntimePlatform[] TouchScreenPlatforms = new RuntimePlatform[2]
	{
		RuntimePlatform.IPhonePlayer,
		RuntimePlatform.Android
	};

	public bool makePersistent = true;

	public bool detectUnityRemote = true;

	public FGInputProvider mouseInputProviderPrefab;

	public FGInputProvider touchInputProviderPrefab;

	private FingerClusterManager fingerClusterManager;

	private FGInputProvider inputProvider;

	private static List<GestureRecognizer> gestureRecognizers = new List<GestureRecognizer>();

	private static FingerGestures instance;

	private Finger[] fingers;

	private FingerList touches;

	private GlobalTouchFilterDelegate globalTouchFilterFunc;

	private Transform[] fingerNodes;

	private static readonly SwipeDirection[] AngleToDirectionMap = new SwipeDirection[8]
	{
		SwipeDirection.Right,
		SwipeDirection.UpperRightDiagonal,
		SwipeDirection.Up,
		SwipeDirection.UpperLeftDiagonal,
		SwipeDirection.Left,
		SwipeDirection.LowerLeftDiagonal,
		SwipeDirection.Down,
		SwipeDirection.LowerRightDiagonal
	};

	private const float DESKTOP_SCREEN_STANDARD_DPI = 96f;

	private const float INCHES_TO_CENTIMETERS = 2.54f;

	private const float CENTIMETERS_TO_INCHES = 0.39370078f;

	private static float screenDPI = 0f;

	public static FingerClusterManager DefaultClusterManager => Instance.fingerClusterManager;

	public static FingerGestures Instance => instance;

	public FGInputProvider InputProvider => inputProvider;

	public int MaxFingers => inputProvider.MaxSimultaneousFingers;

	public static IFingerList Touches => instance.touches;

	public static List<GestureRecognizer> RegisteredGestureRecognizers => gestureRecognizers;

	public static GlobalTouchFilterDelegate GlobalTouchFilter
	{
		get
		{
			return instance.globalTouchFilterFunc;
		}
		set
		{
			instance.globalTouchFilterFunc = value;
		}
	}

	public static float ScreenDPI
	{
		get
		{
			if (screenDPI <= 0f)
			{
				screenDPI = Screen.dpi;
				if (screenDPI <= 0f)
				{
					screenDPI = 96f;
				}
			}
			return screenDPI;
		}
		set
		{
			screenDPI = value;
		}
	}

	public static event Gesture.EventHandler OnGestureEvent;

	public static event FingerEventDetector<FingerEvent>.FingerEventHandler OnFingerEvent;

	public static event EventHandler OnInputProviderChanged;

	internal static void FireEvent(Gesture gesture)
	{
		if (FingerGestures.OnGestureEvent != null)
		{
			FingerGestures.OnGestureEvent(gesture);
		}
	}

	internal static void FireEvent(FingerEvent eventData)
	{
		if (FingerGestures.OnFingerEvent != null)
		{
			FingerGestures.OnFingerEvent(eventData);
		}
	}

	private void Init()
	{
		InitInputProvider();
		fingerClusterManager = GetComponent<FingerClusterManager>();
		if (!fingerClusterManager)
		{
			fingerClusterManager = base.gameObject.AddComponent<FingerClusterManager>();
		}
	}

	public static bool IsTouchScreenPlatform(RuntimePlatform platform)
	{
		for (int i = 0; i < TouchScreenPlatforms.Length; i++)
		{
			if (platform == TouchScreenPlatforms[i])
			{
				return true;
			}
		}
		return false;
	}

	private void InitInputProvider()
	{
		InputProviderEvent inputProviderEvent = new InputProviderEvent();
		if (IsTouchScreenPlatform(Application.platform))
		{
			inputProviderEvent.inputProviderPrefab = touchInputProviderPrefab;
		}
		else
		{
			inputProviderEvent.inputProviderPrefab = mouseInputProviderPrefab;
		}
		base.gameObject.SendMessage("OnSelectInputProvider", inputProviderEvent, SendMessageOptions.DontRequireReceiver);
		InstallInputProvider(inputProviderEvent.inputProviderPrefab);
	}

	public void InstallInputProvider(FGInputProvider inputProviderPrefab)
	{
		if (!inputProviderPrefab)
		{
			Debug.LogError("Invalid InputProvider (null)");
			return;
		}
		Debug.Log("FingerGestures: using " + inputProviderPrefab.name);
		if ((bool)inputProvider)
		{
			UnityEngine.Object.Destroy(inputProvider.gameObject);
		}
		inputProvider = UnityEngine.Object.Instantiate(inputProviderPrefab);
		inputProvider.name = inputProviderPrefab.name;
		inputProvider.transform.parent = base.transform;
		InitFingers(MaxFingers);
		if (FingerGestures.OnInputProviderChanged != null)
		{
			FingerGestures.OnInputProviderChanged();
		}
	}

	public static Finger GetFinger(int index)
	{
		return instance.fingers[index];
	}

	public static void Register(GestureRecognizer recognizer)
	{
		if (!gestureRecognizers.Contains(recognizer))
		{
			gestureRecognizers.Add(recognizer);
		}
	}

	public static void Unregister(GestureRecognizer recognizer)
	{
		gestureRecognizers.Remove(recognizer);
	}

	private void Awake()
	{
		CheckInit();
	}

	private void Start()
	{
		if (makePersistent)
		{
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}
	}

	private void OnEnable()
	{
		CheckInit();
	}

	private void CheckInit()
	{
		if (instance == null)
		{
			instance = this;
			Init();
		}
		else if (instance != this)
		{
			Debug.LogWarning("There is already an instance of FingerGestures created (" + instance.name + "). Destroying new one.");
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if ((bool)inputProvider)
		{
			UpdateFingers();
		}
	}

	private void InitFingers(int count)
	{
		fingers = new Finger[count];
		for (int i = 0; i < count; i++)
		{
			fingers[i] = new Finger(i);
		}
		touches = new FingerList();
	}

	private void UpdateFingers()
	{
		touches.Clear();
		for (int i = 0; i < fingers.Length; i++)
		{
			Finger finger = fingers[i];
			Vector2 position = Vector2.zero;
			bool down = false;
			inputProvider.GetInputState(finger.Index, out down, out position);
			finger.Update(down, position);
			if (finger.IsDown)
			{
				touches.Add(finger);
			}
		}
	}

	protected bool ShouldProcessTouch(int fingerIndex, Vector2 position)
	{
		if (globalTouchFilterFunc != null)
		{
			return globalTouchFilterFunc(fingerIndex, position);
		}
		return true;
	}

	private Transform CreateNode(string name, Transform parent)
	{
		GameObject obj = new GameObject(name);
		obj.transform.parent = parent;
		return obj.transform;
	}

	private void InitNodes()
	{
		int num = fingers.Length;
		if (fingerNodes != null)
		{
			Transform[] array = fingerNodes;
			for (int i = 0; i < array.Length; i++)
			{
				UnityEngine.Object.Destroy(array[i].gameObject);
			}
		}
		fingerNodes = new Transform[num];
		for (int j = 0; j < fingerNodes.Length; j++)
		{
			fingerNodes[j] = CreateNode("Finger" + j, base.transform);
		}
	}

	public static SwipeDirection GetSwipeDirection(Vector2 dir, float tolerance)
	{
		float num = Mathf.Max(Mathf.Clamp01(tolerance) * 22.5f, 0.0001f);
		float num2 = NormalizeAngle360(57.29578f * Mathf.Atan2(dir.y, dir.x));
		if (num2 >= 337.5f)
		{
			num2 -= 360f;
		}
		for (int i = 0; i < 8; i++)
		{
			float num3 = 45f * (float)i;
			if (num2 <= num3 + 22.5f)
			{
				float num4 = num3 - num;
				float num5 = num3 + num;
				if (!(num2 >= num4) || !(num2 <= num5))
				{
					break;
				}
				return AngleToDirectionMap[i];
			}
		}
		return SwipeDirection.None;
	}

	public static SwipeDirection GetSwipeDirection(Vector2 dir)
	{
		return GetSwipeDirection(dir, 1f);
	}

	public static bool UsingUnityRemote()
	{
		return false;
	}

	public static bool AllFingersMoving(Finger finger0, Finger finger1)
	{
		if (finger0.IsMoving)
		{
			return finger1.IsMoving;
		}
		return false;
	}

	public static bool FingersMovedInOppositeDirections(Finger finger0, Finger finger1, float minDOT)
	{
		return Vector2.Dot(finger0.DeltaPosition.normalized, finger1.DeltaPosition.normalized) < minDOT;
	}

	public static float SignedAngle(Vector2 from, Vector2 to)
	{
		return Mathf.Atan2(from.x * to.y - from.y * to.x, Vector2.Dot(from, to));
	}

	public static float NormalizeAngle360(float angleInDegrees)
	{
		angleInDegrees %= 360f;
		if (angleInDegrees < 0f)
		{
			angleInDegrees += 360f;
		}
		return angleInDegrees;
	}

	public static float Convert(float distance, DistanceUnit fromUnit, DistanceUnit toUnit)
	{
		float num = ScreenDPI;
		float num2 = fromUnit switch
		{
			DistanceUnit.Centimeters => distance * 0.39370078f * num, 
			DistanceUnit.Inches => distance * num, 
			_ => distance, 
		};
		return toUnit switch
		{
			DistanceUnit.Inches => num2 / num, 
			DistanceUnit.Centimeters => num2 / num * 2.54f, 
			DistanceUnit.Pixels => num2, 
			_ => num2, 
		};
	}

	public static Vector2 Convert(Vector2 v, DistanceUnit fromUnit, DistanceUnit toUnit)
	{
		return new Vector2(Convert(v.x, fromUnit, toUnit), Convert(v.y, fromUnit, toUnit));
	}
}
