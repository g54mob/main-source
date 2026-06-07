using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class Refriger : MonoBehaviour, IInteractable
{
	private LocalizedString openText = new LocalizedString("MyTable", "interaction-open");

	private LocalizedString closeText = new LocalizedString("MyTable", "interaction-close");

	public List<GameObject> foods;

	[SerializeField]
	private Transform door;

	private Animator animator;

	private bool isOpened;

	private float doorInteractionDelayDelta;

	private float doorInteractionDelay = 1.1f;

	private Outline outLine;

	public string InteractionText
	{
		get
		{
			if (openText != null && !openText.IsEmpty)
			{
				if (!isOpened)
				{
					return openText.GetLocalizedString();
				}
				return closeText.GetLocalizedString();
			}
			if (!isOpened)
			{
				return "Open";
			}
			return "Close";
		}
	}

	private void Awake()
	{
		animator = door.GetComponent<Animator>();
		foods = new List<GameObject>();
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
		if (doorInteractionDelayDelta < doorInteractionDelay)
		{
			doorInteractionDelayDelta += Time.deltaTime;
		}
	}

	public void Interact()
	{
		if (!(doorInteractionDelayDelta < doorInteractionDelay))
		{
			doorInteractionDelayDelta = 0f;
			if (!isOpened)
			{
				isOpened = true;
				AudioManager.S.PlaySFX(AudioManager.S.refridgeOpen);
			}
			else
			{
				isOpened = false;
			}
			animator.SetBool("Opened", isOpened);
		}
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
