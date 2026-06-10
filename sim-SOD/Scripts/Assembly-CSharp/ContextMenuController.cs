using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextMenuController : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public enum MenuFlag
	{
		none = 0,
		pinnedSelected = 1
	}

	[Serializable]
	public class ContextMenuButtonSetup
	{
		public string commandString;

		[Space(5f)]
		public bool useText;

		public string overrideText;

		[Space(5f)]
		public bool useColour;

		public Color colour;

		[Space(5f)]
		public bool devOnly;

		public bool disableForRatModifier;
	}

	public delegate void OpenedMenu();

	[Header("Usage")]
	public bool useLeftButton;

	[Header("Positioning & Size")]
	public Vector2 pos;

	public bool useCursorPos;

	[EnableIf("useCursorPos")]
	public Vector2 cursorPosOffset;

	public bool useGlobalWidth;

	[DisableIf("useGlobalWidth")]
	public float width;

	[Header("Configuration")]
	public MenuFlag flag;

	[ReorderableList]
	public List<ContextMenuButtonSetup> menuButtons;

	[Tooltip("Disabled items")]
	public List<string> disabledItems;

	public MonoBehaviour commandObject;

	[Header("Spawned")]
	public static ContextMenuController activeMenu;

	public ContextButtonController lastButton;

	public GameObject spawnedMenu;

	private RectTransform menuRect;

	public event OpenedMenu OnOpenMenu
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

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void OpenMenu()
	{
	}

	public void OnCommand(ContextButtonController button)
	{
	}

	public void ForceClose()
	{
	}

	private Vector2 ClampToWindow(Vector2 rawPointerPosition)
	{
		return default(Vector2);
	}

	public void SetScreenPosition(Vector2 pointerPosition)
	{
	}
}
