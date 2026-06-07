using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization;

public class RocketMount : Furniture
{
	private LocalizedString launchText = new LocalizedString("MyTable", "interaction-launch");

	public Transform rocketMount;

	private GameObject rocketReady;

	private bool isRocketMounted;

	public RocketType rocketType;

	private bool canLaunched;

	protected override LocalizedString interactionText { get; } = new LocalizedString("MyTable", "interaction-place");

	public override string InteractionText
	{
		get
		{
			if (!isRocketMounted)
			{
				if (GameManager.S.player.itemOnHand != null)
				{
					if (GameManager.S.player.itemOnHand.TryGetComponent<Rocket>(out var component))
					{
						if (component.rocketBody.GetComponent<RocketBody>().type == rocketType)
						{
							return interactionText.GetLocalizedString();
						}
						return "";
					}
					return "";
				}
				return "Grab";
			}
			return launchText.GetLocalizedString();
		}
	}

	public static event Action OnRocketMounted;

	private void Start()
	{
		StartCoroutine(DelayedEnable());
		BusStopUI.OnRocketRetrived += BusStopUI_OnRocketRetrived;
		GameManager.S.isRocketMountExist = true;
		InitMount();
	}

	private void OnDestroy()
	{
		BusStopUI.OnRocketRetrived -= BusStopUI_OnRocketRetrived;
		GameManager.S.isRocketMountExist = false;
	}

	private void BusStopUI_OnRocketRetrived()
	{
		if (!isRocketMounted)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
	}

	private IEnumerator DelayedEnable()
	{
		yield return new WaitForSeconds(0.1f);
		canLaunched = true;
	}

	public override void Interact()
	{
		if (!canLaunched)
		{
			return;
		}
		if (!isRocketMounted)
		{
			if (GameManager.S.player.itemOnHand != null && GameManager.S.player.itemOnHand.TryGetComponent<Rocket>(out var component) && component.rocketBody.GetComponent<RocketBody>().type == rocketType)
			{
				GameManager.S.player.itemOnHand = null;
				isRocketMounted = true;
				component.transform.SetParent(rocketMount);
				rocketReady = component.gameObject;
				component.transform.localPosition = Vector3.zero;
				Vector3 vector = rocketMount.position - component.motorPos.position;
				component.transform.localPosition += vector;
				FirstPersonController.S.ItemOutHand();
			}
		}
		else
		{
			rocketReady.GetComponent<Rocket>().LaunchRocket();
			rocketReady = null;
			isRocketMounted = false;
		}
	}

	public void MountRocket()
	{
		if (GameManager.S.player.itemOnHand.TryGetComponent<Rocket>(out var component) && component.rocketBody.GetComponent<RocketBody>().type == rocketType)
		{
			GameManager.S.player.itemOnHand = null;
			isRocketMounted = true;
			component.transform.SetParent(rocketMount);
			rocketReady = component.gameObject;
			component.transform.localPosition = Vector3.zero;
			component.transform.localRotation = Quaternion.identity;
			Vector3 vector = component.transform.position - component.motorPos.position;
			Debug.Log(vector);
			component.transform.position += vector;
			FirstPersonController.S.ItemOutHand();
			if (component.cameraModule != null)
			{
				GameManager.S.isRocketCamInstalled = true;
				component.cameraModule.GetComponentInChildren<RocketRecoreder>().cam.enabled = true;
			}
			else
			{
				GameManager.S.isRocketCamInstalled = false;
			}
			RocketMount.OnRocketMounted?.Invoke();
			Collider[] componentsInChildren = component.GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
		}
	}

	public void InitMount()
	{
		if (!(rocketReady != null))
		{
			return;
		}
		Rocket component = rocketReady.GetComponent<Rocket>();
		if (component.rocketBody.GetComponent<RocketBody>().type == rocketType)
		{
			GameManager.S.player.itemOnHand = null;
			isRocketMounted = true;
			component.transform.SetParent(rocketMount);
			rocketReady = component.gameObject;
			component.transform.localPosition = Vector3.zero;
			component.transform.localRotation = Quaternion.identity;
			Vector3 vector = component.transform.position - component.motorPos.position;
			Debug.Log(vector);
			component.transform.position += vector;
			FirstPersonController.S.ItemOutHand();
			if (component.cameraModule != null)
			{
				GameManager.S.isRocketCamInstalled = true;
			}
			else
			{
				GameManager.S.isRocketCamInstalled = false;
			}
			RocketMount.OnRocketMounted?.Invoke();
			Collider[] componentsInChildren = component.GetComponentsInChildren<Collider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
		}
	}
}
