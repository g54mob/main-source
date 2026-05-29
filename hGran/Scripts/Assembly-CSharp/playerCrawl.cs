using System;
using UnityEngine;

[Serializable]
public class playerCrawl : MonoBehaviour
{
	public GameObject player;

	public GameObject playerHead;

	public GameObject grannyParent;

	public GameObject granny;

	public GameObject soundHolder;

	public bool PlayerHukarSig;

	public bool playerIsStuck;

	public virtual void Start()
	{
	}

	public virtual void crouching()
	{
	}

	public virtual void standUp()
	{
	}
}
