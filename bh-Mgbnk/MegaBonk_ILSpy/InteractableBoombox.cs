using System;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableBoombox : BaseInteractable
{
	public LocalizedString interactString;

	public GameObject alertIcon;

	private bool done;

	public GameObject fx;

	public AudioSource music;

	public Animator animator;

	public MusicPauseZone pauseZone;

	public override bool Interact()
	{
		//IL_00f1: Expected I4, but got O
		if (!done)
		{
			done = true;
			if ((object)fx != null)
			{
				fx.SetActive(value: true);
				if ((object)music != null)
				{
					music.Play();
					if ((object)animator != null)
					{
						animator.Play("Play");
						UnityEngine.Object.Destroy(alertIcon);
						if ((object)pauseZone != null)
						{
							pauseZone.enabled = true;
							return true;
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public override bool CanInteract()
	{
		return !done;
	}

	public override string GetInteractString()
	{
		if (interactString != null)
		{
			return interactString.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public InteractableBoombox()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
