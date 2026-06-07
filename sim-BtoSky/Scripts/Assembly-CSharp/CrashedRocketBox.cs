using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Localization;

public class CrashedRocketBox : MonoBehaviour, IInteractable, ITrash
{
	public Rocket rocket;

	protected virtual LocalizedString interactionText { get; } = new LocalizedString("MyTable", "interaction-grab");

	public virtual string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				return interactionText.GetLocalizedString();
			}
			return "Grab";
		}
	}

	public event Action<ITrash> OnStatusChanged;

	public void Interact()
	{
		if (GameManager.S.player.itemOnHand == null)
		{
			GameManager.S.player.GrabItem(base.gameObject);
			this.OnStatusChanged?.Invoke(this);
			rocket.ResetLiquid();
		}
	}

	private void OnEnable()
	{
		if (rocket != null)
		{
			rocket.gameObject.SetActive(value: true);
		}
	}

	private IEnumerator InitRocket()
	{
		rocket.gameObject.SetActive(value: true);
		yield return null;
		rocket.gameObject.SetActive(value: false);
	}

	public void OnDetected()
	{
	}

	public void OnLost()
	{
	}

	public void PutRocketInBox(Rocket rocketTemp)
	{
		rocket = rocketTemp;
		if (rocket.crashedPartPaint != null)
		{
			foreach (GameObject item in rocketTemp.crashedPartPaint)
			{
				MeshRenderer component = item.GetComponent<MeshRenderer>();
				if (component != null)
				{
					if (component.material.mainTexture is Texture2D obj)
					{
						UnityEngine.Object.Destroy(obj);
					}
					UnityEngine.Object.Destroy(component.material);
				}
				UnityEngine.Object.Destroy(item);
			}
			rocketTemp.crashedPartPaint.Clear();
		}
		if (rocket.crashedPartsNonPaint != null)
		{
			foreach (GameObject item2 in rocketTemp.crashedPartsNonPaint)
			{
				UnityEngine.Object.Destroy(item2);
			}
			rocketTemp.crashedPartsNonPaint.Clear();
		}
		Rigidbody component2 = GetComponent<Rigidbody>();
		Rigidbody component3 = rocket.GetComponent<Rigidbody>();
		component2.mass = component3.mass * 2f;
		component3.isKinematic = true;
		foreach (GameObject item3 in rocketTemp.rocketWing)
		{
			item3.transform.localScale = Vector3.one;
		}
		rocketTemp.head.gameObject.transform.localScale = Vector3.one;
		rocketTemp.rocketNozzle.gameObject.transform.localScale = Vector3.one;
		rocketTemp.gameObject.SetActive(value: false);
		rocketTemp.gameObject.transform.position = base.transform.position;
		rocketTemp.transform.parent = base.transform;
		rocketTemp.crashed = false;
		rocketTemp.currentHealth = rocketTemp.maxHealth;
		if (rocketTemp.parachute != null)
		{
			UnityEngine.Object.Destroy(rocketTemp.parachute.gameObject);
		}
	}
}
