using System;
using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class RoomSelection : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private RoomBuilding _room;

		[SerializeField]
		[Inject(false)]
		private OutlineRendererCollection _rendererCollection;

		private readonly List<Component> _selectedComponents = new List<Component>();

		private bool _isHoverActive;

		public RoomBuilding Room => _room;

		public static event Action<RoomBuilding, bool> RoomSelected;

		public static event Action<RoomBuilding, bool> RoomHovered;

		public void AddRenderer(Renderer rend)
		{
			_rendererCollection.AddRenderer(rend);
		}

		public void RemoveRenderer(Renderer rend)
		{
			_rendererCollection.RemoveRenderer(rend);
		}

		public void AddSelectedObject(Component component)
		{
			if (!_selectedComponents.Contains(component))
			{
				_selectedComponents.Add(component);
				if (_selectedComponents.Count == 1)
				{
					_rendererCollection.EnableOutline(EOutline.Select);
					RoomSelection.RoomSelected?.Invoke(_room, arg2: true);
				}
			}
		}

		public void SetHoverActive(bool value)
		{
			if (_isHoverActive != value)
			{
				_isHoverActive = value;
				_rendererCollection.SetOutlineActive(EOutline.Hover, value);
				RoomSelection.RoomHovered?.Invoke(_room, value);
			}
		}

		public void RemoveSelectedObject(Component component)
		{
			if (_selectedComponents.Contains(component))
			{
				_selectedComponents.Remove(component);
				if (_selectedComponents.Count <= 0)
				{
					_rendererCollection.DisableOutline(EOutline.Select);
					RoomSelection.RoomSelected?.Invoke(_room, arg2: false);
				}
			}
		}
	}
}
