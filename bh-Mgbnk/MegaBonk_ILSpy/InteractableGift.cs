using System;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableGift : BaseInteractable
{
	public LocalizedString localizationOpenGift;

	public GameObject hatFloating;

	public GameObject fx;

	private bool done;

	public override bool Interact()
	{
		//IL_014f: Expected I4, but got O
		if (!done)
		{
			done = true;
			if ((object)fx != null)
			{
				Transform transform = fx.transform;
				if ((object)transform != null)
				{
					transform.parentInternal = null;
					if ((object)hatFloating != null)
					{
						Transform transform2 = hatFloating.transform;
						if ((object)transform2 != null)
						{
							transform2.parentInternal = null;
							if ((object)fx != null)
							{
								fx.SetActive(value: true);
								if ((object)hatFloating != null)
								{
									hatFloating.SetActive(value: true);
									GameObject obj = base.gameObject;
									UnityEngine.Object.Destroy(obj);
									return true;
								}
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public override string GetInteractString()
	{
		if (localizationOpenGift != null)
		{
			return localizationOpenGift.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public InteractableGift()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
