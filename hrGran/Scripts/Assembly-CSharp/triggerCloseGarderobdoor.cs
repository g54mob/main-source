using System;
using UnityEngine;

[Serializable]
public class triggerCloseGarderobdoor : MonoBehaviour
{
	public GameObject doorV;

	public GameObject doorH;

	public bool playerInLocker;

	public GameObject doorButton;

	public GameObject nos;

	public GameObject player;

	public AudioClip gardeDoorsClose;

	public virtual void Start()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
