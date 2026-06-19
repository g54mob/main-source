using UnityEngine;

public class MainController : MonoBehaviour
{
	public enum MainState
	{
		None = 0,
		Lobby = 1,
		Loading = 2,
		Playing = 3,
		EndScreen = 4
	}

	public static bool isHost;

	public static MainState state;
}
