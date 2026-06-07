using UnityEngine;

namespace Placemaker.Life
{
	public class ButterflyFlock : MonoBehaviour
	{
		public enum State : byte
		{
			Flying = 0,
			Stopping = 1,
			Stopped = 2
		}

		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		private Butterfly srcButterfly;

		[SerializeField]
		private Mesh flapMesh;

		[SerializeField]
		private Mesh sitMesh;

		[SerializeField]
		private Mesh sitFlapMesh;

		[SerializeField]
		private Transform activeButterflies;

		[SerializeField]
		private Transform disabledButterflies;

		private const int absoluteMaxButterflyCount = 32;

		private const float dt = 0.3f;

		public int landingCount;

		public void OnReset()
		{
		}

		public void OnUpdate()
		{
		}

		private void SetButterfly(ButterflyLanding landing, Butterfly butterfly)
		{
		}

		private void SetLanding(Butterfly butterfly, ButterflyLanding landing)
		{
		}

		public void AddLanding(ButterflyLanding landing)
		{
		}

		public void RemoveLanding(ButterflyLanding landing)
		{
		}
	}
}
