using UnityEngine;

public class GlobalAudioListener : MonoBehaviour
{
	public static GlobalAudioListener instance;

	private PlayerInteraction bufferedPlayerInteraction;

	private Transform bufferedTargetTransform;

	private Vector3 offset = new Vector3(0f, 2f, 0f);

	private void Awake()
	{
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Update()
	{
		PlayerInteraction playerInteraction = PlayerInteraction.instance;
		if (bufferedPlayerInteraction != playerInteraction)
		{
			if (playerInteraction == null)
			{
				bufferedTargetTransform = null;
			}
			else
			{
				bufferedTargetTransform = playerInteraction.transform;
			}
		}
		if (bufferedTargetTransform != null)
		{
			base.transform.position = bufferedTargetTransform.position + offset;
		}
		else
		{
			base.transform.position = Vector3.zero;
		}
		bufferedPlayerInteraction = playerInteraction;
	}
}
