using System;
using System.Collections;
using UnityEngine;

public class RocketBox : Item
{
	[SerializeField]
	private GameObject rocket;

	[SerializeField]
	private GameObject rocketBody;

	[SerializeField]
	private GameObject rocketParticle;

	[SerializeField]
	private GameObject rocketHead;

	[SerializeField]
	private GameObject rocketNozzle;

	[SerializeField]
	private GameObject rocketMotor;

	private bool hasGrabbed;

	private bool beingDestroyed;

	public static event Action OnRocketBoxInteracted;

	private void Start()
	{
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		canGrab = true;
	}

	private void Update()
	{
	}

	public override void Interact()
	{
		if (canGrab && GameManager.S.player.itemOnHand == null)
		{
			GameManager.S.player.GrabItem(base.gameObject);
			hasGrabbed = true;
			RocketBox.OnRocketBoxInteracted?.Invoke();
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (hasGrabbed && !beingDestroyed && collision.gameObject.layer != LayerMask.NameToLayer("Player"))
		{
			StartCoroutine(AssembleRocket());
			beingDestroyed = true;
		}
	}

	private IEnumerator AssembleRocket()
	{
		Debug.Log("Box Opened");
		GameObject gameObject = UnityEngine.Object.Instantiate(rocket, base.gameObject.transform.position, base.transform.rotation);
		Debug.Log("rocketMain");
		Rocket rocketCompo = gameObject.GetComponent<Rocket>();
		UnityEngine.Object.Instantiate(rocketBody, rocketCompo.rocketVisualPos);
		yield return null;
		UnityEngine.Object.Instantiate(rocketHead, rocketCompo.rocketHeadPos);
		if (rocketMotor != null)
		{
			UnityEngine.Object.Instantiate(rocketMotor, rocketCompo.motorPos);
		}
		UnityEngine.Object.Instantiate(rocketNozzle, rocketCompo.motorPos);
		UnityEngine.Object.Destroy(base.gameObject);
	}

	public void CraftingTableInit()
	{
		StartCoroutine(AssembleRocket());
	}
}
