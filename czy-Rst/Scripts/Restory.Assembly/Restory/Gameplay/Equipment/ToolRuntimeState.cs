using System;
using Restory.Data.Equipment;

namespace Restory.Gameplay.Equipment
{
	[Serializable]
	public struct ToolRuntimeState
	{
		public ToolInfo Tool;

		public int Count;

		public float CurrentUsesLeft;
	}
}
