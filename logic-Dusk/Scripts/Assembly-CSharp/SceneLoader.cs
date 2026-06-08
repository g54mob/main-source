using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	public static int LoadDest = -1;

	private int updateCount;

	private void Update()
	{
		switch (updateCount)
		{
		case 0:
			Resources.UnloadUnusedAssets();
			break;
		case 1:
			if (LoadDest == 1)
			{
				SceneManager.LoadScene("GalaxyMapScene");
			}
			else if (LoadDest == 2)
			{
				SceneManager.LoadScene("DungeonScene_Generated_Pro");
			}
			break;
		default:
			LoadDest = -1;
			return;
		}
		updateCount++;
	}
}
