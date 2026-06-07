using UnityEngine;

[AddComponentMenu("Wwise/Spatial Audio/AkReverbZone")]
public class AkReverbZone : MonoBehaviour
{
	[Tooltip("Set this Room as a Reverb Zone. Sound propagates between the Reverb Zone and its parent Room as if it were the same Room without the need for a connecting Portal. This is automatically populated by the current GameObject's Room component, if available.")]
	public AkRoom ReverbZone;

	[Tooltip("Set this Room as the parent of the Reverb Zone. Sound propagates between the Reverb Zone and its parent Room as if it were the same Room without the need for a connecting Portal. A parent Room can have multiple Reverb Zones, but a Reverb Zone can only have a single Parent. A Room cannot be its own parent. Leave this set to None to attach the Reverb Zone to the automatically created 'Outdoors' Room.")]
	public AkRoom ParentRoom;

	[Tooltip("Width of the transition region between the Reverb Zone and its parent. The transition region is centered around the Reverb Zone geometry. It only applies where triangle transmission loss is set to 0.")]
	public float TransitionRegionWidth;

	private bool needsUpdate;

	public static void SetReverbZone(AkRoom reverbZone, AkRoom parentRoom, float transitionRegionWidth)
	{
	}

	public static void RemoveReverbZone(AkRoom reverbZone)
	{
	}

	public void SetReverbZone()
	{
	}

	public void RemoveReverbZone()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnValidate()
	{
	}

	private void Update()
	{
	}
}
