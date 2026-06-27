using System;
using System.Collections.Generic;
using Restory.Data.GuiElementTypes;
using UnityEngine;

namespace Restory.UserInterface
{
	public class ActiveGuiRegistry : MonoBehaviour, IDisposable
	{
		private readonly Dictionary<string, GameObject> activeItems = new Dictionary<string, GameObject>();

		public event Action<GuiElementType> OnItemAdded = delegate
		{
		};

		public event Action<GuiElementType> OnItemRemoved = delegate
		{
		};

		public void Dispose()
		{
			activeItems.Clear();
			this.OnItemAdded = delegate
			{
			};
			this.OnItemRemoved = delegate
			{
			};
		}

		public void Register(GuiElementType type, GameObject root)
		{
			activeItems[type.ID] = root;
			this.OnItemAdded(type);
		}

		public void Unregister(GuiElementType type)
		{
			activeItems.Remove(type.ID);
			this.OnItemRemoved(type);
		}

		public bool IsActive(GuiElementType type)
		{
			return activeItems.ContainsKey(type.ID);
		}

		public bool TryGetRoot(GuiElementType targetType, out GameObject root)
		{
			return activeItems.TryGetValue(targetType.ID, out root);
		}
	}
}
