using System;
using Restory.Gameplay.Elements;

namespace Restory.Gameplay.Disassemble.StateMachine
{
	public struct ElementToInventoryTransferData
	{
		public ElementBase ElementInTransfer;

		public Func<ElementBase, bool> TryToSendElementToInventory;

		public Action CancelElementTransfer;
	}
}
