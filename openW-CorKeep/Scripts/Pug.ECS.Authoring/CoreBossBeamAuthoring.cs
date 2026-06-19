using Pug.UnityExtensions;
using UnityEngine;

public class CoreBossBeamAuthoring : MonoBehaviour
{
	public float startDuration;

	public float loopDuration;

	public float endDuration;

	public float hiddenEndDuration;

	public int internalState;

	public ThreadSafeTimerSimple timer;

	public ThreadSafeTimerSimple dealDamageTimer;
}
