using System;
using UnityEngine;

[Serializable]
public abstract class CustomCursor
{
	private CustomCursorCanvas _cursorUI;

	[field: SerializeField]
	public int Priority { get; private set; }

	protected CursorGraphic _cursorGraphic => null;

	protected bool _active => false;

	public CustomCursor(int priority)
	{
	}

	public void SetActive(CustomCursorCanvas cursorUI)
	{
	}

	public void SetInactive(CustomCursorCanvas cursorUI)
	{
	}

	protected abstract void Apply();

	protected abstract void Unapply();

	public virtual void Update()
	{
	}
}
