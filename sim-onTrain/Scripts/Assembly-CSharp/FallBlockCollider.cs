using UnityEngine;

public class FallBlockCollider : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		TSPlayerController tSPlayerController = other.GetComponent<TSPlayerController>();
		if (tSPlayerController == null)
		{
			tSPlayerController = other.GetComponentInParent<TSPlayerController>();
		}
		if (!(tSPlayerController == null) && tSPlayerController.isOwned)
		{
			TeleportPlayerToTrain(tSPlayerController);
		}
	}

	private void TeleportPlayerToTrain(TSPlayerController player)
	{
		TrainController trainController = Object.FindObjectOfType<TrainController>();
		if (trainController == null || trainController.spawnPoints.Count == 0)
		{
			Debug.LogError("[FallBlockCollider] TrainController veya spawn noktaları bulunamadı!");
			return;
		}
		Transform transform = trainController.spawnPoints[Random.Range(0, trainController.spawnPoints.Count)];
		CharacterController component = player.GetComponent<CharacterController>();
		if (component != null)
		{
			component.enabled = false;
		}
		player.transform.position = transform.position;
		player.transform.rotation = transform.rotation;
		if (component != null)
		{
			component.enabled = true;
		}
		Debug.Log("[FallBlockCollider] Oyuncu trene geri ışınlandı: " + transform.name);
	}
}
