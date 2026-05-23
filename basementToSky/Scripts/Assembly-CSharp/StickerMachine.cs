using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class StickerMachine : MonoBehaviour, IInteractable
{
	public class InteractableDetectedArgs : EventArgs
	{
		public bool isdetected;

		public string interactionText;
	}

	[SerializeField]
	private List<Sprite> decals;

	private bool usable = true;

	[SerializeField]
	private Animator handleAnimator;

	[SerializeField]
	private Animator slotAnimator;

	[SerializeField]
	private GameObject stickerPrefab;

	[SerializeField]
	private Transform slotPos;

	private Outline outline;

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

	public static event EventHandler<InteractableDetectedArgs> InteractableDetected;

	public static event Action<Sprite> OnNewDecalUnlocked;

	private void Awake()
	{
		ES3.Load("DecalList", decals);
	}

	private void Start()
	{
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
		outline = GetComponent<Outline>();
		if (outline != null)
		{
			outline.enabled = false;
		}
	}

	private void OnDestroy()
	{
		ES3AutoSaveMgr.OnBeforeSave -= ES3AutoSaveMgr_OnBeforeSave;
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		ES3.Save("DecalList", decals);
	}

	public void Interact()
	{
		if (FirstPersonController.S.ticket >= 1)
		{
			if (usable)
			{
				if (decals.Count > 0)
				{
					FirstPersonController.S.ticket--;
					GameManager.S.TicketUpdated();
					handleAnimator.Play("Roll");
					usable = false;
					StartCoroutine(ResetTimer());
					AudioManager.S.PlaySFX(AudioManager.S.stickerMachine);
					AudioManager.S.PlaySFX(AudioManager.S.money);
				}
				else
				{
					GameManager.S.DecalEmpty();
				}
			}
		}
		else
		{
			GameManager.S.NotEnoughMoney();
		}
	}

	private IEnumerator ResetTimer()
	{
		yield return new WaitForSeconds(1f);
		slotAnimator.Play("Open");
		usable = true;
		GameObject obj = UnityEngine.Object.Instantiate(stickerPrefab, slotPos.transform.position, slotPos.transform.rotation);
		int index = UnityEngine.Random.Range(0, decals.Count);
		Sprite sprite = decals[index];
		SpriteRenderer componentInChildren = obj.GetComponentInChildren<SpriteRenderer>();
		componentInChildren.sprite = sprite;
		FitSpriteToSize(componentInChildren, 0.22f);
		StickerMachine.OnNewDecalUnlocked?.Invoke(sprite);
		decals.RemoveAt(index);
		UnityEngine.Object.Destroy(obj, 0.5f);
	}

	private void FitSpriteToSize(SpriteRenderer sr, float targetSize)
	{
		sr.transform.localScale = new Vector3(targetSize, targetSize, 1f);
	}

	public void OnDetected()
	{
		if (outline != null)
		{
			outline.enabled = true;
		}
	}

	public void OnLost()
	{
		if (outline != null)
		{
			outline.enabled = false;
		}
	}
}
