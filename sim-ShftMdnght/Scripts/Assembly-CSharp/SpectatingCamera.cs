using System.Collections.Generic;
using UnityEngine;

public class SpectatingCamera : MonoBehaviour
{
	public List<Transform> players;

	public int curPlayerIndex;

	private void OnEnable()
	{
		players.Clear();
		GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] array2 = array;
		foreach (GameObject gameObject in array2)
		{
			if (gameObject != ClientPlayer.Instance.gameObject && !gameObject.GetComponent<PlayerManager>().dead && !gameObject.GetComponent<PlayerManager>().downed)
			{
				players.Add(gameObject.transform);
			}
		}
		if (players.Count == 0)
		{
			base.enabled = false;
			array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].GetComponent<PlayerManager>().EveryoneDied();
			}
		}
	}

	private void Update()
	{
		base.transform.position = Vector3.Lerp(base.transform.position, players[curPlayerIndex].position, Time.deltaTime * 50f);
		if (Input.GetButtonDown("Fire1"))
		{
			curPlayerIndex++;
			if (curPlayerIndex >= players.Count)
			{
				curPlayerIndex = 0;
			}
		}
	}
}
