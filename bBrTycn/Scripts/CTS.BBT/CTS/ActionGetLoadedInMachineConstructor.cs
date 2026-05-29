using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionGetLoadedInMachineConstructor : ActionConstructor<CustomerActionGetLoadedInMachine>
	{
		[SerializeField]
		private SoftReference<MachineBase> _machineToLoad;

		protected override CustomerActionGetLoadedInMachine ConstructAction()
		{
			return new CustomerActionGetLoadedInMachine(_machineToLoad);
		}
	}
}
