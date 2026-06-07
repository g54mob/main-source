using System;
using UnityEngine;

namespace Coherence.Cloud.Coroutines
{
	public class WaitForPredicate : CustomYieldInstruction
	{
		private Func<bool> predicate;

		public override bool keepWaiting => false;

		public WaitForPredicate(Func<bool> predicate)
		{
		}
	}
}
