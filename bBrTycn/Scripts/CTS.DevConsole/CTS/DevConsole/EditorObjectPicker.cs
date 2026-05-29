using System;
using UnityEngine;

namespace CTS.DevConsole
{
	public class EditorObjectPicker : ObjectPicker
	{
		public override bool TryGetSelectedObject(Type type, out Component outComponent, bool searchIfNothingSelected)
		{
			if (searchIfNothingSelected)
			{
				UnityEngine.Object obj = UnityEngine.Object.FindObjectOfType(type);
				if (obj is Component)
				{
					DeveloperConsole.LogWarning("Nothing selected but found " + obj.name + " in the scene!");
					outComponent = (Component)obj;
					return true;
				}
			}
			outComponent = null;
			return false;
		}
	}
}
