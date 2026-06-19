using OUSystems.Basics.Effects;
using UnityEngine;

public class ClickDummyBumpAnimator : MonoBehaviour
{
	[SerializeField]
	private ClickHitDummy _clickDummy;

	[SerializeField]
	private ShakeReceiver _shakeReciever;

	[SerializeField]
	private float _stressPerHit;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnHit(bool finished)
	{
	}
}
