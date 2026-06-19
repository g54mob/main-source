using UnityEngine;

[DisallowMultipleComponent]
public class TriggerEffectAuthoring : MonoBehaviour
{
	[field: SerializeField]
	public TriggerEffectType EffectType { get; private set; }

	[field: SerializeField]
	public RewiredPS5TriggerEffectWeaponProxy Weapon { get; private set; }

	[field: SerializeField]
	public RewiredPS5TriggerEffectVibrationProxy Vibration { get; private set; }

	[field: SerializeField]
	public RewiredPS5TriggerEffectMultiplePositionVibrationProxy MultiplePositionVibration { get; private set; }

	[field: SerializeField]
	public RewiredPS5TriggerEffectMultiplePositionFeedbackProxy MultiplePositionFeedback { get; private set; }

	[field: SerializeField]
	public RewiredPS5TriggerEffectSlopeFeedbackProxy SlopeFeedback { get; private set; }

	[field: SerializeField]
	public RewiredPS5TriggerEffectFeedbackProxy Feedback { get; private set; }
}
