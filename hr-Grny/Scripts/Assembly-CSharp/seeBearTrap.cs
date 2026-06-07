using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class seeBearTrap : MonoBehaviour
{
	public LayerMask layerMask;

	public Image button;

	public Image removeBar;

	public GameObject SeeRay;

	public bool destroyTrap;

	public bool playerTaken;

	public GameObject player;

	public GameObject crawlButton;

	public GameObject allBedButtons;

	public AudioClip removeBeartrapSound;

	public AudioClip removeBeartrapOrganicSound;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
