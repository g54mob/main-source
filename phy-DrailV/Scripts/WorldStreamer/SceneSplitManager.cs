using UnityEngine;

public class SceneSplitManager : MonoBehaviour
{
	public string sceneName;

	public Color color;

	[HideInInspector]
	public Vector3 position;

	[HideInInspector]
	public Vector3 size = new Vector3(10f, 10f, 10f);

	private void Start()
	{
		AddToStreamer();
	}

	private void AddToStreamer()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag(Streamer.STREAMERTAG);
		for (int i = 0; i < array.Length; i++)
		{
			Streamer component = array[i].GetComponent<Streamer>();
			if (!(component != null))
			{
				continue;
			}
			string[] names = component.sceneCollection.names;
			for (int j = 0; j < names.Length; j++)
			{
				if (names[j].Replace(".unity", "") == sceneName)
				{
					component.AddSceneGO(sceneName, base.gameObject);
					return;
				}
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = color;
		Gizmos.DrawWireCube(position + size * 0.5f, size);
	}
}
