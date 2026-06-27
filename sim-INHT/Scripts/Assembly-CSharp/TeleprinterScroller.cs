using UnityEngine;

[DisallowMultipleComponent]
public class TeleprinterScroller : MonoBehaviour
{
	[Header("Teleprinter")]
	[Tooltip("Which registered Teleprinter instance this scroller controls.\nMust match the 'Teleprinter Type' field on the target Teleprinter component.")]
	public Teleprinter.Teleprinters teleprinterType;

	[Header("Scroll Control")]
	[Range(0f, 1f)]
	[Tooltip("Test slider — drag this at runtime to scroll the paper.\n0 = print position (no offset); 1 = fully scrolled up by Max Scroll Up local units.\nHas NO effect while the printer is actively printing.")]
	public float scrollT;

	[Tooltip("Maximum distance in LOCAL units the paper moves when Scroll T = 1.\nSet this to the height of your text viewport so that Scroll T = 1 brings the very\ntop of the printed content into view.\nExample: 5 = the paper shifts 5 local units upward at full scroll.")]
	public float maxScrollUp;

	[Tooltip("When true, the paper smoothly moves to match the slider value each frame using\n'Smooth Speed' rather than snapping instantly.")]
	public bool smoothScroll;

	[Tooltip("Local units per second used to lerp toward the target offset when Smooth Scroll\nis enabled. Higher = snappier. Only used when Smooth Scroll is true.")]
	public float smoothSpeed;

	[Header("Debug")]
	[Tooltip("Log offset and lock-state changes to the Console.")]
	public bool debugScroll;

	private Teleprinter _printer;

	private Vector3 _basePaperLocal;

	private float _currentOffsetLocal;

	public float ScrollOffset => 0f;

	public bool ScrollEnabled => false;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void TryBindPrinter()
	{
	}

	private void HandlePrintingWillStart()
	{
	}

	private void Update()
	{
	}

	private void ApplyOffset()
	{
	}

	public void ResetScroll()
	{
	}
}
