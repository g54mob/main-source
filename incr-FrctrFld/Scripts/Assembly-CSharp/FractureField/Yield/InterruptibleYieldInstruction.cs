using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace FractureField.Yield
{
	public class InterruptibleYieldInstruction : CustomYieldInstruction
	{
		private bool stop;

		public override bool keepWaiting => false;

		public event Action<InterruptibleYieldInstruction> OnKeepWaiting
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Stop(bool condition)
		{
		}
	}
}
