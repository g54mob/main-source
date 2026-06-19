using System;
using System.Runtime.CompilerServices;
using FMODUnity;
using OUSystems.Basics.DataStructures;
using UnityEngine;

public abstract class PlayerActionMode : MonoBehaviour
{
	[SerializeField]
	public EventReference _onActivateSound;

	[SerializeField]
	public EventReference _onDeactivateSound;

	public BoolContainer Enabled;

	public string DisplayTitle;

	public abstract bool PlayerCanMove { get; }

	public bool Active { get; private set; }

	public static event Action<PlayerActionMode> AnnounceModeActive
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

	public event Action AnnounceActive
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

	public event Action AnnounceInactive
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

	public bool PlayActivationSound()
	{
		return false;
	}

	public bool PlayDeactivationSound()
	{
		return false;
	}

	public void Toggle()
	{
	}

	public void Initiate()
	{
	}

	public void Cleanup()
	{
	}

	public virtual void OnInitiate()
	{
	}

	public virtual void StartMode(bool silent = false)
	{
	}

	public virtual void EndMode(bool silent = false)
	{
	}

	protected abstract void OnActivate();

	protected abstract void OnDeactivate();
}
