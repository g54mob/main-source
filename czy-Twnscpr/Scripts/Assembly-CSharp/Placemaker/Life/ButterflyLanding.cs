using Placemaker.Props;
using UnityEngine;

namespace Placemaker.Life
{
	public class ButterflyLanding : MonoBehaviour, IPropEnable
	{
		public Butterfly butterfly;

		void IPropEnable.OnEnable(WorldMaster master)
		{
		}

		void IPropEnable.OnFirstEnable(WorldMaster master)
		{
		}

		void IPropEnable.OnDisable(WorldMaster master)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
