using System;
using Placemaker.Props;
using UnityEngine;

namespace Placemaker.Life
{
	public class BirdLanding : MonoBehaviour, IPropEnable, IComparable<BirdLanding>, IComparable<Vector3>
	{
		public Bird bird;

		public byte neighbourCount;

		public Vector3 normal;

		public Vector3 pos => default(Vector3);

		public Vector3 sortPos => default(Vector3);

		public Vector3 targetPos => default(Vector3);

		int IComparable<BirdLanding>.CompareTo(BirdLanding other)
		{
			return 0;
		}

		int IComparable<Vector3>.CompareTo(Vector3 other)
		{
			return 0;
		}

		void IPropEnable.OnDisable(WorldMaster master)
		{
		}

		void IPropEnable.OnEnable(WorldMaster master)
		{
		}

		void IPropEnable.OnFirstEnable(WorldMaster master)
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void AddNeighbour(BirdLanding landing)
		{
		}

		public void RemoveNeighbour(BirdLanding landing)
		{
		}

		public void ClearNeighbours()
		{
		}
	}
}
