using Pug.UnityExtensions;
using UnityEngine;

public class DestroyTimerAuthoring : MonoBehaviour
{
	public PlatformDependentValue<float> lifetime;

	public bool dontDropLootAfterTimerRunsOut;

	public float disablePhysicsAfterDuration;

	public int startTimerWhenVariation;
}
