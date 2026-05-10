using System;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class ActionDiscardJunkConstructor : ActionConstructor<WorkerChoreDiscardJunk>
	{
		[SerializeField]
		private JunkObject _junk;

		protected override WorkerChoreDiscardJunk ConstructAction()
		{
			if (_junk.CurrentChore == null)
			{
				throw new Exception("Specified junk has no cleaning chore");
			}
			return _junk.CurrentChore;
		}
	}
}
