using UnityEngine;

[RequireComponent(typeof(Summon))]
public class SummonJumpBack : MonoBehaviour
{
	public int jumpAmount = -6;

	private Summon mySummon;

	private void HandleStateChange(Summon summon, Summon.State newState, Summon.State oldState)
	{
		if (oldState == Summon.State.Attacking && newState != Summon.State.Attacking)
		{
			int positionX = mySummon.PositionX + jumpAmount;
			mySummon.PositionX = positionX;
		}
	}

	private void Awake()
	{
		mySummon = GetComponent<Summon>();
		mySummon.OnSummonStateChange += HandleStateChange;
	}

	private void OnDestroy()
	{
		mySummon.OnSummonStateChange -= HandleStateChange;
	}
}
