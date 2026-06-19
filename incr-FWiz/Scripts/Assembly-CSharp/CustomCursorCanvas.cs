using System.Collections.Generic;
using UnityEngine;

public class CustomCursorCanvas : MonoBehaviour
{
	private List<CustomCursor> _customCursors;

	private CustomCursor _activeCustomCursor;

	[SerializeField]
	private DefaultCustomCursor _defaultCursor;

	[SerializeField]
	public DefaultCustomCursor LockCursor;

	private bool CustomCursorsOn;

	public static CustomCursorCanvas Instance { get; private set; }

	[field: SerializeField]
	public CursorGraphic CursorGraphic { get; private set; }

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	public void AddCustomCursor(CustomCursor customCursor)
	{
	}

	public void RemoveCustomCursor(CustomCursor customCursor)
	{
	}
}
