using Assets.Scripts.Actors.Player;
using UnityEngine;

public class CryptDetectStart : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		GameObject gameObject = other.gameObject;
		GameObject gameObject2 = MyPlayer.Instance.gameObject;
		if (gameObject == gameObject2 && GameManager.Instance != null)
		{
			GameManager instance = GameManager.Instance;
			if (!instance._003CisDungeonTimerStarted_003Ek__BackingField)
			{
				instance._003CisDungeonTimerStarted_003Ek__BackingField = true;
			}
		}
	}
}
