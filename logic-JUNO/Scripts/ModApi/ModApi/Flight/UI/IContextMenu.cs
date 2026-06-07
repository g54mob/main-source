using System;
using UnityEngine;

namespace ModApi.Flight.UI
{
	public interface IContextMenu
	{
		bool IsVisible { get; }

		void AddContextMenuItem(string name, Sprite icon, Color? iconColor, Action action, bool autoCloseOnClick = true);

		void HideContextMenu();

		void ShowContextMenu(Vector2 position);
	}
}
