using Assets.Nimbatus.Scripts.Persistence;
using Spine.Unity;
using UnityEngine;

public class ResourceContainerTransparency : MonoBehaviour
{
	public SkeletonAnimation Animation;

	private int _dronePartCounter;

	private bool _isInvisible;

	public void Start()
	{
		Animation.AnimationState.SetAnimation(2, "visible", false);
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == RuntimeGlobals.NimbatusPlayer.gameObject.layer)
		{
			_dronePartCounter++;
			if (!_isInvisible)
			{
				_isInvisible = true;
				Animation.AnimationState.SetAnimation(2, "invisible", false);
			}
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.layer == RuntimeGlobals.NimbatusPlayer.gameObject.layer)
		{
			_dronePartCounter--;
			if (_dronePartCounter <= 0)
			{
				_isInvisible = false;
				Animation.AnimationState.SetAnimation(2, "visible", false);
			}
		}
	}
}
