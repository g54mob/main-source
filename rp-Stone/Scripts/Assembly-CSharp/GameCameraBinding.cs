using UnityEngine;

public class GameCameraBinding : MonoBehaviour
{
	public GameCamera gameCamera { get; set; }

	private void OnDestroy()
	{
		gameCamera = null;
	}
}
