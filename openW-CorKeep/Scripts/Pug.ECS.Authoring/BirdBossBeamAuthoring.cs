using Pug.UnityExtensions;
using Unity.Mathematics;
using UnityEngine;

public class BirdBossBeamAuthoring : MonoBehaviour
{
	public float startDuration;

	public float loopDuration;

	public float endDuration;

	public float hiddenEndDuration;

	public float startDamageDelay;

	public float3 moveDirection;

	public float moveSpeed;

	public bool moveSideWays;

	public int internalState;

	public ThreadSafeTimerSimple timer;

	public ThreadSafeTimerSimple dealDamageTimer;
}
