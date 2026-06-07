using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class removeBeartrap : MonoBehaviour
{
	public int layerMask;

	public Image removeBar;

	public bool PressButton;

	public GameObject rayHolder;

	public GameObject player;

	public bool seeTrap;

	public bool playerTaken;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
