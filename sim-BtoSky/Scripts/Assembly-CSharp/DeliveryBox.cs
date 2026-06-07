using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DeliveryBox : Item
{
	private bool hasGrabbed;

	private bool beingDestroyed;

	public List<GameObject> contents = new List<GameObject>();

	[SerializeField]
	private GameObject foam;

	public float strength;

	private void Start()
	{
		canGrab = true;
	}

	public override void Interact()
	{
		if (canGrab && GameManager.S.player.itemOnHand == null)
		{
			outLine = GetComponent<Outline>();
			outLine.enabled = false;
			GameManager.S.player.GrabItem(base.gameObject);
			hasGrabbed = true;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!hasGrabbed || beingDestroyed || collision.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			return;
		}
		foreach (GameObject content in contents)
		{
			Object.Instantiate(content, base.gameObject.transform.position, quaternion.identity);
		}
		beingDestroyed = true;
		if (foam != null)
		{
			for (int i = 0; i < 50; i++)
			{
				Vector3 position = base.transform.position + UnityEngine.Random.insideUnitSphere * 0.2f;
				Rigidbody component = Object.Instantiate(foam, position, UnityEngine.Random.rotation).GetComponent<Rigidbody>();
				if (component != null)
				{
					Vector3 onUnitSphere = UnityEngine.Random.onUnitSphere;
					component.AddForce(onUnitSphere * strength, ForceMode.Impulse);
				}
			}
		}
		Object.Destroy(base.gameObject);
	}
}
