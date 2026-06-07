using System;
using UnityEngine;

[Serializable]
public class DeliverShotgunParts : MonoBehaviour
{
	public GameObject gameController;

	public bool shotgunPart1;

	public bool shotgunPart2;

	public bool shotgunPart3;

	public GameObject shotgunPart1Table;

	public GameObject shotgunPart2Table;

	public GameObject shotgunPart3Table;

	public GameObject shotgunPart1Hand;

	public GameObject shotgunPart2Hand;

	public GameObject shotgunPart3Hand;

	public GameObject dropObjectButton;

	public GameObject Shotgun;

	public GameObject moreAmmo;

	public AudioClip placeObjectSound;

	public virtual void OnTriggerStay(Collider other)
	{
	}
}
