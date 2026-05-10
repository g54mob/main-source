using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionLoadMachineConstructor : ActionConstructor<WorkerActionLoadMachine>, IGive<MachineBase>
	{
		[SerializeField]
		private SoftReference<MachineBase> _machineToLoad;

		[SerializeField]
		private SoftReference<Customer> _victimToLoad;

		protected override WorkerActionLoadMachine ConstructAction()
		{
			return new WorkerActionLoadMachine(_machineToLoad, _victimToLoad);
		}

		public MachineBase Get()
		{
			return _machineToLoad.Get();
		}
	}
}
