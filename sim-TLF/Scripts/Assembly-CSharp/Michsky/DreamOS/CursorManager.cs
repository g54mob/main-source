using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.DreamOS
{
	[DisallowMultipleComponent]
	[AddComponentMenu("DreamOS/System/Cursor Manager")]
	public class CursorManager : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public enum CursorSource
		{
			Custom = 0,
			WindowsNative = 1
		}

		public enum WindowsCursor
		{
			StandardArrowAndSmallHourglass = 32650,
			StandardArrow = 32512,
			Crosshair = 32515,
			Hand = 32649,
			ArrowAndQuestionMark = 32651,
			IBeam = 32513,
			SlashedCircle = 32648,
			FourPointedArrowPointingNorthSouthEastAndWest = 32646,
			DoublePointedArrowPointingNortheastAndSouthwest = 32643,
			DoublePointedArrowPointingNorthAndSouth = 32645,
			DoublePointedArrowPointingNorthwestAndSoutheast = 32642,
			DoublePointedArrowPointingWestAndEast = 32644,
			VerticalArrow = 32516,
			Hourglass = 32514
		}

		[Header("Settings")]
		public CursorSource cursorSource;

		public Vector2 cursorHotspot = Vector2.zero;

		public bool applyOnEnable;

		public bool applyOnMouseEnter = true;

		public bool revertOnMouseExit = true;

		[Header("Cursor")]
		public Texture2D cursorTexture;

		public WindowsCursor windowsCursorType = WindowsCursor.StandardArrow;

		[DllImport("user32.dll", EntryPoint = "SetCursor")]
		public static extern IntPtr ChangeWindowsCursor(IntPtr hCursor);

		[DllImport("user32.dll", EntryPoint = "LoadCursor")]
		public static extern IntPtr LoadWindowsCursor(IntPtr hInstance, int lpCursorName);

		public static void SetWindowsCursor(WindowsCursor cursor)
		{
			ChangeWindowsCursor(LoadWindowsCursor(IntPtr.Zero, (int)cursor));
		}

		private void OnEnable()
		{
			if (applyOnEnable)
			{
				ApplyCursor();
			}
		}

		public static void SetCustomCursor(Texture2D cursor, Vector2 hetspot)
		{
			Cursor.SetCursor(cursor, hetspot, CursorMode.Auto);
		}

		public static void SetDefaultCursor()
		{
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}

		private void ApplyCursor()
		{
			if (cursorSource == CursorSource.Custom)
			{
				SetCustomCursor(cursorTexture, cursorHotspot);
			}
			else if (cursorSource == CursorSource.WindowsNative)
			{
				SetDefaultCursor();
				SetWindowsCursor(windowsCursorType);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (applyOnMouseEnter)
			{
				ApplyCursor();
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (revertOnMouseExit)
			{
				SetDefaultCursor();
			}
		}
	}
}
