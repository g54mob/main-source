using System.Collections.Generic;
using Os.Utils;
using UnityEngine;

namespace Placemaker
{
	public class Sandbanker : MonoBehaviour
	{
		private enum State : byte
		{
			Reset = 0,
			Gather = 1,
			Smooth = 2,
			ApplyWater = 3,
			ApplySand = 4,
			Done = 5
		}

		[SerializeField]
		private WorldMaster master;

		public List<float> coverage;

		public List<Vector3> verts;

		public List<int> tris;

		private State state;

		[SerializeField]
		public MeshFilter sandMf;

		[SerializeField]
		public MeshFilter waterMf;

		[SerializeField]
		public ByteFloat2 uvPos;

		[SerializeField]
		public ByteFloat2 uvSize;

		private int index;

		private Dictionary<int, int> dict;

		public void Reset()
		{
		}

		public void Clear()
		{
		}

		private void OnEnable()
		{
		}

		private void UpdateShadeUvs()
		{
		}

		private void OnValidate()
		{
		}

		public void OnStart()
		{
		}

		public bool Iterate()
		{
			return false;
		}

		private void OnDrawGizmos()
		{
		}
	}
}
