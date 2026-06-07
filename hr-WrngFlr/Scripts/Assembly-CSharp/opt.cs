using UnityEngine;

public class opt : MonoBehaviour
{
	public Transform pl;

	public GameObject[] room;

	public int[] on;

	public void a()
	{
		for (int i = 0; i < room.Length; i++)
		{
			if (on[i] > 0)
			{
				room[i].SetActive(value: true);
			}
			else
			{
				room[i].SetActive(value: false);
			}
		}
	}
}
