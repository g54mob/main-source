using Assets.Scripts.Actors.Player;
using Assets.Scripts.Objects.Pooling;
using UnityEngine;

public class PickupEffect : MonoBehaviour
{
	private float time = 0.3f;

	private void OnEnable()
	{
		MyPlayer player = GameManager.Instance.GetPlayer();
		if (player != null)
		{
			Transform transform = base.transform;
			Transform parentInternal = player.transform;
			transform.parentInternal = parentInternal;
		}
		Invoke("DisableSelf", time);
	}

	private void DisableSelf()
	{
		GameObject gameObject = base.gameObject;
		if (gameObject.activeInHierarchy)
		{
			Transform transform = base.transform;
			transform.parentInternal = null;
			GameObject gameObject2 = base.gameObject;
			gameObject2.SetActive(value: false);
			PoolManager instance = PoolManager.Instance;
			GameObject element = base.gameObject;
			instance.pickupeffectPool.Release(element);
		}
	}
}
