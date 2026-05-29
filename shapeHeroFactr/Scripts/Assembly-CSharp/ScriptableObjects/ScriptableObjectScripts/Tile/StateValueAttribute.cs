using System;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	public class StateValueAttribute : Attribute
	{
		public int StateValue { get; protected set; }

		public StateValueAttribute(int value)
		{
		}
	}
}
