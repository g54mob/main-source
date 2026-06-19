using System;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.DataStructures;
using OUSystems.Basics.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Components;

public abstract class TrackingHUDItem : MonoBehaviour
{
	public BoolContainer Open;

	public TextMeshProUGUI CompactedText;

	public LocalizeStringEvent CompactedTextEvent;

	public ClickListener ToggleButton;

	public EventReference ToggleSound;

	[SerializeField]
	protected TextMeshProUGUI _condensedTitle;

	[SerializeField]
	private SimpleFillBar _progressBar;

	public GameObject Content;

	protected TrackingHUD _hud;

	public bool Compact { get; private set; }

	public static event Action<TrackingHUDItem> AnnounceSelect
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public abstract bool CanHandle(object obj);

	public abstract void Handle(object obj);

	public void Initiate(TrackingHUD hud)
	{
	}

	public void Wipe()
	{
	}

	public void Select()
	{
	}

	public void SetCompact(bool compact)
	{
	}

	public void ToggleCompact()
	{
	}

	public void SetProgress(float progress)
	{
	}

	public virtual void OnInitiate()
	{
	}

	public virtual void OnWipe()
	{
	}
}
