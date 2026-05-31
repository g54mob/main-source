using System;
using CTS.Core;
using CTS.DevConsole;
using UnityEngine;

namespace CTS
{
	public class SelectionObjectPicker : EditorObjectPicker
	{
		public override bool TryGetSelectedObject(Type type, out Component outComponent, bool searchIfNothingSelected)
		{
			SelectableObject lastSelected = WorldSelector.GetLastSelected();
			if ((bool)lastSelected)
			{
				if ((bool)lastSelected.SelectionTarget)
				{
					outComponent = lastSelected.SelectionTarget.GetComponent(type);
					if ((bool)outComponent)
					{
						return true;
					}
					outComponent = lastSelected.SelectionTarget.GetComponentInChildren(type, includeInactive: true);
					if ((bool)outComponent)
					{
						return true;
					}
				}
				else
				{
					outComponent = lastSelected.GetComponent(type);
					if ((bool)outComponent)
					{
						return true;
					}
					outComponent = lastSelected.GetComponentInChildren(type, includeInactive: true);
					if ((bool)outComponent)
					{
						return true;
					}
				}
			}
			return base.TryGetSelectedObject(type, out outComponent, searchIfNothingSelected);
		}
	}
}
