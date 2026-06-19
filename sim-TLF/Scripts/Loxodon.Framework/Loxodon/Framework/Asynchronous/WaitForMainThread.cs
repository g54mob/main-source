using UnityEngine;

namespace Loxodon.Framework.Asynchronous
{
	public class WaitForMainThread : CustomYieldInstruction
	{
		public static readonly WaitForMainThread Default = new WaitForMainThread();

		public override bool keepWaiting => false;
	}
}
