using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ActionHypnotizeConstructor : ActionConstructor<WorkerActionHypnotize>
	{
		[SerializeField]
		private SoftReference<Customer> _target;

		protected override WorkerActionHypnotize ConstructAction()
		{
			return new WorkerActionHypnotize(_target);
		}
	}
}
