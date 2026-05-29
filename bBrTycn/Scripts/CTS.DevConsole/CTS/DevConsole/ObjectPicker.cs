using System;
using UnityEngine;

namespace CTS.DevConsole
{
	public abstract class ObjectPicker : MonoBehaviour
	{
		public abstract bool TryGetSelectedObject(Type type, out Component outComponent, bool searchIfNothingSelected);
	}
}
