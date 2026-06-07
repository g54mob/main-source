using System.Collections.Generic;
using UnityEngine;

public class ReactiveCursor : MonoBehaviour
{
	public enum CursorInteractableType
	{
		isClickable = 0
	}

	public Texture2D defaultCursor;

	public Texture2D dragableCursor;

	public static ReactiveCursor instance;

	public static List<CursorInteractableType> interactables = new List<CursorInteractableType>();

	private bool doShowClickable;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		SetDefault();
	}

	public void Update()
	{
		if (interactables.Count > 0 && !doShowClickable)
		{
			doShowClickable = true;
			SetClickable();
		}
		if (interactables.Count < 1 && doShowClickable)
		{
			doShowClickable = false;
			SetDefault();
		}
	}

	public void SetDefault()
	{
		Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
	}

	public void SetClickable()
	{
		Cursor.SetCursor(dragableCursor, Vector2.zero, CursorMode.ForceSoftware);
	}
}
