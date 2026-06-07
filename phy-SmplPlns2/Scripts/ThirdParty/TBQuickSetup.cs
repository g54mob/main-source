using UnityEngine;

[AddComponentMenu("FingerGestures/Toolbox/Quick Setup")]
public class TBQuickSetup : MonoBehaviour
{
	public GameObject MessageTarget;

	public int MaxSimultaneousGestures = 2;

	private ScreenRaycaster screenRaycaster;

	public FingerDownDetector FingerDown { get; set; }

	public FingerUpDetector FingerUp { get; set; }

	public FingerHoverDetector FingerHover { get; set; }

	public FingerMotionDetector FingerMotion { get; set; }

	public DragRecognizer Drag { get; set; }

	public LongPressRecognizer LongPress { get; set; }

	public SwipeRecognizer Swipe { get; set; }

	public TapRecognizer Tap { get; set; }

	public TapRecognizer DoubleTap { get; set; }

	public PinchRecognizer Pinch { get; set; }

	public TwistRecognizer Twist { get; set; }

	public DragRecognizer TwoFingerDrag { get; set; }

	public TapRecognizer TwoFingerTap { get; set; }

	public SwipeRecognizer TwoFingerSwipe { get; set; }

	public LongPressRecognizer TwoFingerLongPress { get; set; }

	private GameObject CreateChildNode(string name)
	{
		GameObject obj = new GameObject(name);
		Transform obj2 = obj.transform;
		obj2.parent = base.transform;
		obj2.localPosition = Vector3.zero;
		obj2.localRotation = Quaternion.identity;
		return obj;
	}

	private void Start()
	{
		if (!MessageTarget)
		{
			MessageTarget = base.gameObject;
		}
		screenRaycaster = GetComponent<ScreenRaycaster>();
		if (!screenRaycaster)
		{
			screenRaycaster = base.gameObject.AddComponent<ScreenRaycaster>();
		}
		if (!FingerGestures.Instance)
		{
			base.gameObject.AddComponent<FingerGestures>();
		}
		GameObject node = CreateChildNode("Finger Event Detectors");
		FingerDown = AddFingerEventDetector<FingerDownDetector>(node);
		FingerUp = AddFingerEventDetector<FingerUpDetector>(node);
		FingerMotion = AddFingerEventDetector<FingerMotionDetector>(node);
		FingerHover = AddFingerEventDetector<FingerHoverDetector>(node);
		GameObject node2 = CreateChildNode("Single Finger Gestures");
		Drag = AddSingleFingerGesture<DragRecognizer>(node2);
		Tap = AddSingleFingerGesture<TapRecognizer>(node2);
		Swipe = AddSingleFingerGesture<SwipeRecognizer>(node2);
		LongPress = AddSingleFingerGesture<LongPressRecognizer>(node2);
		DoubleTap = AddSingleFingerGesture<TapRecognizer>(node2);
		DoubleTap.RequiredTaps = 2;
		DoubleTap.EventMessageName = "OnDoubleTap";
		GameObject node3 = CreateChildNode("Two-Finger Gestures");
		Pinch = AddTwoFingerGesture<PinchRecognizer>(node3);
		Twist = AddTwoFingerGesture<TwistRecognizer>(node3);
		TwoFingerDrag = AddTwoFingerGesture<DragRecognizer>(node3, "OnTwoFingerDrag");
		TwoFingerTap = AddTwoFingerGesture<TapRecognizer>(node3, "OnTwoFingerTap");
		TwoFingerSwipe = AddTwoFingerGesture<SwipeRecognizer>(node3, "OnTwoFingerSwipe");
		TwoFingerLongPress = AddTwoFingerGesture<LongPressRecognizer>(node3, "OnTwoFingerLongPress");
	}

	private T AddFingerEventDetector<T>(GameObject node) where T : FingerEventDetector
	{
		T val = node.AddComponent<T>();
		val.Raycaster = screenRaycaster;
		val.MessageTarget = MessageTarget;
		return val;
	}

	private T AddGesture<T>(GameObject node) where T : GestureRecognizer
	{
		T val = node.AddComponent<T>();
		val.Raycaster = screenRaycaster;
		val.EventMessageTarget = MessageTarget;
		if (val.SupportFingerClustering)
		{
			val.MaxSimultaneousGestures = MaxSimultaneousGestures;
		}
		return val;
	}

	private T AddSingleFingerGesture<T>(GameObject node) where T : GestureRecognizer
	{
		T val = AddGesture<T>(node);
		val.RequiredFingerCount = 1;
		return val;
	}

	private T AddTwoFingerGesture<T>(GameObject node) where T : GestureRecognizer
	{
		T val = AddGesture<T>(node);
		val.RequiredFingerCount = 2;
		return val;
	}

	private T AddTwoFingerGesture<T>(GameObject node, string eventName) where T : GestureRecognizer
	{
		T val = AddTwoFingerGesture<T>(node);
		val.EventMessageName = eventName;
		return val;
	}
}
