using System;
using UnityEngine;

[Serializable]
public class playerVevar : MonoBehaviour
{
	public int layerMask;

	public bool playerHoldButton;

	public GameObject brunnsVevButton;

	public GameObject doorRay;

	public bool playerTaken;

	public bool playSound;

	public GameObject rope;

	public GameObject winch;

	public bool noMoreVev;

	public bool vevInPlace;

	public GameObject brunnsLjud;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
