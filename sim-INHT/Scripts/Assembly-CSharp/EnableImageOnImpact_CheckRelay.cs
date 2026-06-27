using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class EnableImageOnImpact_CheckRelay : MonoBehaviour
{
	[Header("Relay Target Discovery")]
	[Tooltip("Unity Tag used to find GameObjects containing EnableImageOnImpact_TaggedRects components that should be checked when this relay fires.\nDefault: 'Target'.\nSetup:\n- Assign this tag to each GameObject that has an EnableImageOnImpact_TaggedRects component you want checked.\nNotes:\n- Tag must exist in Project Settings > Tags and Layers.\n- Searching uses GameObject.FindGameObjectsWithTag on each fire.")]
	public string targetTag;

	[Header("Fire Behavior")]
	[Tooltip("If true, the relay will automatically fire once in OnEnable. If false, you must fire it manually via script (TriggerRelayCheck) or an input action if configured.")]
	public bool fireOnEnable;

	[Tooltip("If > 0 seconds, the relay will keep re-firing checks repeatedly at this interval while it stays enabled. Set to 0 to disable repeated firing. Avoid very small intervals to reduce overhead.")]
	[Min(0f)]
	public float repeatIntervalSeconds;

	[Tooltip("If true, the relay disables itself immediately after the first successful fire (regardless of whether any targets enabled their images). Ignored if repeatIntervalSeconds > 0.")]
	public bool autoDisableAfterFirstFire;

	[Header("Manual Input Trigger (Optional)")]
	[Tooltip("Optional Input Action (Button) used to manually fire the relay while enabled.\nSetup:\n- Assign an InputActionReference with Action Type = Button.\nBehavior:\n- Each Performed event invokes a single relay firing (same as TriggerRelayCheck()).\nLeave empty to skip manual input triggering.")]
	public InputActionReference manualTriggerAction;

	[Header("Debug")]
	[Tooltip("If true, logs relay firing attempts, number of targets found, and any warnings (e.g., missing tag).")]
	public bool debugLogs;

	private float _nextRepeatTime;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnManualPerformed(InputAction.CallbackContext ctx)
	{
	}

	public void TriggerRelayCheck()
	{
	}

	private void FireRelay()
	{
	}
}
