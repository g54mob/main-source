using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionUnloadMachineConstructor : ActionConstructor<WorkerActionUnloadMachine>
	{
		[SerializeField]
		private SoftReference<MachineBase> _machineToUnload;

		[SerializeField]
		private bool _shouldVictimBeControlledAfter;

		protected override WorkerActionUnloadMachine ConstructAction()
		{
			return new WorkerActionUnloadMachine(_machineToUnload, _shouldVictimBeControlledAfter);
		}
	}
}
