using System;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class StickyNote : MonoBehaviour, IInteractable
{
	private LocalizedString interactionText = new LocalizedString("MyTable", "interaction-read");

	public LocalizedSprite localizedSprite;

	public Image targetImage;

	public Outline outLine;

	public string InteractionText
	{
		get
		{
			if (interactionText != null && !interactionText.IsEmpty)
			{
				return interactionText.GetLocalizedString();
			}
			return "Read";
		}
	}

	public static event Action OnReadStickyNote;

	private void OnEnable()
	{
		localizedSprite.AssetChanged += LocalizedSprite_AssetChanged;
	}

	private void OnDisable()
	{
		localizedSprite.AssetChanged -= LocalizedSprite_AssetChanged;
	}

	private void LocalizedSprite_AssetChanged(Sprite value)
	{
		if (targetImage != null)
		{
			targetImage.sprite = value;
		}
	}

	private void Start()
	{
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}

	private void Update()
	{
	}

	public void Interact()
	{
		StickyNote.OnReadStickyNote?.Invoke();
		AudioManager.S.PlaySFX(AudioManager.S.memoCheck);
	}

	public void OnDetected()
	{
		if (outLine != null)
		{
			outLine.enabled = true;
		}
	}

	public void OnLost()
	{
		if (outLine != null)
		{
			outLine.enabled = false;
		}
	}
}
