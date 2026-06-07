using System.Collections.Generic;
using HumanAPI;
using UnityEngine;

public class GiftParachute : MonoBehaviour
{
	public GameObject master;

	public Sound2 sound;

	public static GiftParachute instance;

	private Queue<GameObject> queue = new Queue<GameObject>();

	private void Awake()
	{
		instance = this;
		master.SetActive(false);
	}

	public GameObject Allocate()
	{
		GameObject gameObject = ((queue.Count <= 1) ? Object.Instantiate(master, base.transform, true) : queue.Dequeue());
		gameObject.SetActive(true);
		return gameObject;
	}

	public void Release(GameObject chute)
	{
		chute.SetActive(false);
		queue.Enqueue(chute);
	}

	public void PlaySound(Vector3 pos)
	{
		sound.PlayOneShot(pos);
	}
}
