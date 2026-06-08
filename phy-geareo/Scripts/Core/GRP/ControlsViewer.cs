using System;
using System.Collections.Generic;
using Rhizomatic.ImUI;
using UnityEngine.InputSystem;

namespace GRP
{
	public class ControlsViewer : IExpositorUI
	{
		public Project project;

		public List<Key> keys;

		public KeyBuilder builder;

		private Action updateItems;

		private Action updateItem;

		private List<Key> availableKeys;

		public ControlsViewer(Project project)
		{
		}

		public void OnExpositorUI(ImUIBuilder ui)
		{
		}

		public void CheckControllablePart(Part part)
		{
		}

		public void UpdateItems(Key previousKey, Key newKey)
		{
		}

		public void UpdateItem(KeyField field, Key newKey)
		{
		}
	}
}
