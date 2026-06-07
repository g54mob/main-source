using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Selector
{
	private static Selector _instance;

	private readonly UIManager _uiManager;

	private Vector3 _anchor;

	private Vector3 _cursor;

	private SelectionLink _cursorSelectionLink;

	public SelectionLink SelectedObject { get; private set; }

	public ObjectType SelectedObjectType { get; private set; }

	public static SelectionLink Selection
	{
		get
		{
			if (_instance != null)
			{
				return _instance.SelectedObject;
			}
			return null;
		}
	}

	public static ObjectType SelectedType
	{
		get
		{
			if (_instance != null)
			{
				return _instance.SelectedObjectType;
			}
			return ObjectType.None;
		}
	}

	public static event UnityAction SelectedObjectsUpdatedEvent;

	private Selector()
	{
		_uiManager = GameManager.UIManager;
	}

	public void Update(Vector3 cursor, SelectionLink cursorSelectionLink)
	{
		_cursor = cursor;
		_cursorSelectionLink = cursorSelectionLink;
		if (FlotsamInputManager.GetButtonDown(93) && _uiManager.UIState == UIState.Normal && !EventSystem.current.IsPointerOverGameObject())
		{
			_anchor = FlotsamInputManager.MousePosition;
			_uiManager.SelectionFrame.InitializeFrame(_anchor);
			UIManager.SetState(UIState.Selecting);
		}
		if (_uiManager.UIState != UIState.Selecting)
		{
			return;
		}
		if (FlotsamInputManager.GetButton(93))
		{
			_cursor = FlotsamInputManager.MousePosition;
			_uiManager.SelectionFrame.DrawSelectionFrame(_cursor);
		}
		if (!FlotsamInputManager.GetButtonDown(43) && !FlotsamInputManager.GetButtonUp(93))
		{
			return;
		}
		_uiManager.SelectionFrame.HideFrame();
		UIManager.SetState(UIState.Normal);
		if (TryToSelectObjectInFrame())
		{
			if (Selector.SelectedObjectsUpdatedEvent != null)
			{
				Selector.SelectedObjectsUpdatedEvent();
			}
		}
		else if (TryToSelectSingleObjectFromRaycast())
		{
			if (Selector.SelectedObjectsUpdatedEvent != null)
			{
				Selector.SelectedObjectsUpdatedEvent();
			}
		}
		else
		{
			DeselectAll();
		}
	}

	public void Destroy()
	{
		Selector.SelectedObjectsUpdatedEvent = null;
	}

	private bool TryToSelectObjectInFrame()
	{
		if (TryToSelectDriftersInFrame())
		{
			return true;
		}
		if (TryToSelectCommunityMembersInFrame())
		{
			return true;
		}
		if (TryToSelectBirdsInFrame())
		{
			return true;
		}
		if (TryToSelectMarkerInFrame())
		{
			return true;
		}
		if (TryToSelectBuildablesInFrame())
		{
			return true;
		}
		if (TryToSelectLandmarkInFrame())
		{
			return true;
		}
		return false;
	}

	private bool TryToSelectObjectInFrame(ObjectType objectType)
	{
		SelectionLink selectionLink = ReturnFirstSelectionLinkInFrame(_anchor, _cursor, objectType);
		if (selectionLink == null)
		{
			return false;
		}
		if (SelectedObject == selectionLink)
		{
			return true;
		}
		if (selectionLink.Type == ObjectType.None)
		{
			return false;
		}
		SelectObject(selectionLink, objectType);
		return true;
	}

	private bool TryToSelectCommunityMembersInFrame()
	{
		return TryToSelectObjectInFrame(ObjectType.CommunityMember);
	}

	private bool TryToSelectBuildablesInFrame()
	{
		return TryToSelectObjectInFrame(ObjectType.Buildable);
	}

	private bool TryToSelectMarkerInFrame()
	{
		return TryToSelectObjectInFrame(ObjectType.Marker);
	}

	private bool TryToSelectLandmarkInFrame()
	{
		return TryToSelectObjectInFrame(ObjectType.Landmark);
	}

	private bool TryToSelectDriftersInFrame()
	{
		return TryToSelectObjectInFrame(ObjectType.Agent);
	}

	private bool TryToSelectBirdsInFrame()
	{
		return TryToSelectObjectInFrame(ObjectType.Bird);
	}

	public void SelectObject(SelectionLink selectionLink)
	{
		SelectObject(selectionLink, selectionLink.Type);
	}

	public void SelectObject(SelectionLink selectionLink, ObjectType selectedType, bool playSelectionSound = true)
	{
		if (!(selectionLink == null) && !(selectionLink == SelectedObject) && selectedType != ObjectType.None)
		{
			DeselectObject(SelectedObject);
			SelectedObject = selectionLink;
			SelectedObjectType = selectedType;
			selectionLink.Select(playSelectionSound);
			GameManager.HighlightManager.HighlightObject(selectionLink.OutlineRenderer);
			if (Selector.SelectedObjectsUpdatedEvent != null)
			{
				Selector.SelectedObjectsUpdatedEvent();
			}
		}
	}

	public void DeselectObject(SelectionLink objectToDeselect)
	{
		if (!(objectToDeselect == null) && SelectedObject == objectToDeselect)
		{
			SelectedObject = null;
			SelectedObjectType = ObjectType.None;
			objectToDeselect.Deselect();
			if (Selector.SelectedObjectsUpdatedEvent != null)
			{
				Selector.SelectedObjectsUpdatedEvent();
			}
		}
	}

	public void DeselectSelection()
	{
		DeselectObject(SelectedObject);
		if (Selector.SelectedObjectsUpdatedEvent != null)
		{
			Selector.SelectedObjectsUpdatedEvent();
		}
	}

	private bool TryToSelectSingleObjectFromRaycast()
	{
		if (_cursorSelectionLink == null)
		{
			return false;
		}
		if (_cursorSelectionLink.Type == ObjectType.None)
		{
			return false;
		}
		SelectedObjectType = _cursorSelectionLink.Type;
		SelectObject(_cursorSelectionLink, _cursorSelectionLink.Type);
		return true;
	}

	public static Selector CreateInstance()
	{
		if (_instance == null)
		{
			_instance = new Selector();
		}
		else
		{
			Debug.LogWarning("An instance of Selector has already been instantiated! Did you forget to call Selector.DestroyInstance()?");
		}
		return _instance;
	}

	public static void DestroyInstance()
	{
		if (_instance != null)
		{
			_instance.Destroy();
			_instance = null;
		}
	}

	public static void Select(SelectionLink selectionLink)
	{
		_instance?.SelectObject(selectionLink, selectionLink.Type);
	}

	public static void Select(GameObject objectToSelect, ObjectType objectType, bool playSelectionSound = true)
	{
		if (_instance != null && objectType != ObjectType.None)
		{
			_instance.SelectObject(objectToSelect.GetComponentInChildren<SelectionLink>(), objectType, playSelectionSound);
		}
	}

	public static void Deselect(SelectionLink selectionLink)
	{
		if (_instance != null)
		{
			_instance.DeselectObject(selectionLink);
		}
	}

	public static void Deselect(GameObject gameObject)
	{
		if (_instance != null && !(gameObject == null))
		{
			_instance.DeselectObject(gameObject.GetComponentInChildren<SelectionLink>());
		}
	}

	public static void Deselect(SelectionLink[] selectionLinks)
	{
		if (_instance != null && !selectionLinks.IsNullOrEmpty())
		{
			foreach (SelectionLink objectToDeselect in selectionLinks)
			{
				_instance.DeselectObject(objectToDeselect);
			}
		}
	}

	public static void DeselectAll()
	{
		if (_instance != null)
		{
			_instance.DeselectSelection();
		}
	}

	private SelectionLink ReturnFirstSelectionLinkInFrame(Vector3 startPos, Vector3 endPos, ObjectType objectType)
	{
		Camera main = Camera.main;
		Vector3 vector = new Vector3(Mathf.Min(startPos.x, endPos.x), Mathf.Min(startPos.y, endPos.y), Mathf.Min(startPos.z, endPos.z));
		Vector3 vector2 = new Vector3(Mathf.Max(startPos.x, endPos.x), Mathf.Max(startPos.y, endPos.y), Mathf.Max(startPos.z, endPos.z));
		List<SelectionLink> selectionLinks = SelectionLink.SelectionLinks;
		int count = selectionLinks.Count;
		for (int i = 0; i < count; i++)
		{
			SelectionLink selectionLink = selectionLinks[i];
			if (selectionLink.Type == objectType && selectionLink.IsSelectable)
			{
				Vector3 vector3 = main.WorldToScreenPoint(selectionLink.transform.position);
				if (vector3.z > 0f && vector3.x > vector.x && vector3.x < vector2.x && vector3.y > vector.y && vector3.y < vector2.y)
				{
					return selectionLink;
				}
			}
		}
		return null;
	}

	public static bool ReturnIsSelected(GameObject gameObject)
	{
		if (_instance == null)
		{
			return false;
		}
		SelectionLink componentInChildren = gameObject.GetComponentInChildren<SelectionLink>();
		if (componentInChildren == null)
		{
			return false;
		}
		return _instance.SelectedObject == componentInChildren;
	}

	public static T ReturnSelectedObjectComponent<T>(ObjectType objectType) where T : Component
	{
		if (_instance == null || _instance.SelectedObject == null)
		{
			return null;
		}
		if (_instance.SelectedObjectType != objectType && objectType != ObjectType.None)
		{
			return null;
		}
		if (_instance.SelectedObject.ObjectToSelect.TryGetComponent<T>(out var component))
		{
			return component;
		}
		return null;
	}
}
