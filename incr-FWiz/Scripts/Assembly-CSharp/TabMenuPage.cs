using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TabMenuPage : MonoBehaviour
{
	public bool Selected { get; private set; }

	[field: SerializeField]
	public TabMenu TabMenu { get; private set; }

	public event Action AnnounceSelected
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

	public event Action AnnounceEndSelected
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

	public virtual void Start()
	{
	}

	public void OnSelected()
	{
	}

	public void OnEndSelected()
	{
	}
}
