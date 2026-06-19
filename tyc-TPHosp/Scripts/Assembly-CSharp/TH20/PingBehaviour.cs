using System.Collections;

namespace TH20
{
	public abstract class PingBehaviour
	{
		public abstract void OnPingReset(Pingable pingable);

		public abstract IEnumerator PingCoroutine(Pingable pingable);
	}
}
