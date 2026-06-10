using Rewired.Components;
using Rewired.Integration.UnityUI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualCursorController : MonoBehaviour
{
	public enum StartingMousePosition
	{
		usePrevious = 0,
		centreScreen = 1,
		coordinate = 2
	}

	private static VirtualCursorController _instance;

	public StandaloneInputModule standardInput;

	public RewiredStandaloneInputModule rewiredInput;

	public PlayerMouse mouse;

	public bool isActive;

	public bool animatingTransition;

	public float alpha;

	private bool activatedBefore;

	public Transform animationTransform;

	public AnimationCurve animateActiveScale;

	public AnimationCurve animateInactiveScale;

	public GameObject cursorObject;

	public Image cursorImage;

	public RawImage cursorRaw;

	public Vector2 lastKnownPos;

	public static VirtualCursorController Instance { get; private set; }

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void TryActivateVirtualCursor(StartingMousePosition startingPos = StartingMousePosition.usePrevious, RectTransform setToRectTransform = null)
	{
	}

	public void UpdateCursorSpeed()
	{
	}

	public void SetCursorPosition(Vector2 screenPosition)
	{
	}

	public void SetCursorPosition(RectTransform objectRect)
	{
	}

	public void DeactivateVirtualCursor()
	{
	}
}
