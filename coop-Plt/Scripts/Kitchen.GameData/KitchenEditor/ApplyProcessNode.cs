using System;
using KitchenData;
using XNode;

namespace KitchenEditor
{
	[NodeTint("#8A5164")]
	[CreateNodeMenu("Apply Process")]
	public class ApplyProcessNode : Node, IProcessNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public Item Input;

		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false)]
		public ProcessConnection Result;

		public Process Process;

		public float Duration;

		public bool IsBad;

		private void OnValidate()
		{
			if (Process == null)
			{
				base.name = "Apply Process";
				return;
			}
			try
			{
				base.name = $"{Process.name} ({Duration}s)";
			}
			catch (Exception)
			{
			}
		}

		public override object GetValue(NodePort port)
		{
			return null;
		}

		public Item.ItemProcess Build(IGameDataObjectMap map)
		{
			if (GetOutputPort("Result").GetConnection(0).node is IGameDataReference gameDataReference)
			{
				return new Item.ItemProcess
				{
					Duration = Duration,
					IsBad = IsBad,
					Process = Process,
					Result = map.Get((Item)gameDataReference.RefersTo)
				};
			}
			throw new Exception("Process not linked to Item");
		}
	}
}
