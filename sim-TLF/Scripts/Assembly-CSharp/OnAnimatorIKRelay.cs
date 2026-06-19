using UnityEngine;

public class OnAnimatorIKRelay : MonoBehaviour
{
	public ReactiveRider Saddle;

	private void OnAnimatorIK(int layerIndex)
	{
		Saddle.OnRelayedAnimatorIK();
	}
}
