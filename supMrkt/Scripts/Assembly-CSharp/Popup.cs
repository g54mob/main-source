using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class Popup : MonoBehaviour
{
	private Canvas m_Canvas;

	public PopupType Type { get; set; }

	public bool IsShown => false;

	public event Action Shown
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

	public event Action Hidden
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

	protected virtual void Awake()
	{
	}

	public void Show()
	{
	}

	public void Hide()
	{
	}

	protected virtual void OnShown()
	{
	}

	protected virtual void OnHidden()
	{
	}
}
