using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Simulator
{
	public struct AnimationPath : IEnumerable<Vector3>, IEnumerable
	{
		private List<Vector3> m_positions;

		public bool IsValid { get; private set; }

		public int Count => m_positions.Count;

		public Vector3 First => m_positions[0];

		public Vector3 Last
		{
			get
			{
				List<Vector3> positions = m_positions;
				return positions[positions.Count - 1];
			}
		}

		public AnimationPath(Vector3 firstStep)
		{
			m_positions = new List<Vector3> { firstStep };
			IsValid = true;
		}

		public AnimationPath(params Vector3[] firstSteps)
		{
			m_positions = new List<Vector3>(firstSteps);
			IsValid = true;
		}

		public void Init()
		{
			m_positions = new List<Vector3>();
			IsValid = true;
		}

		public void Add(Vector3 pos)
		{
			m_positions.Add(pos);
		}

		public void Insert(Vector3 pos)
		{
			m_positions.Insert(0, pos);
		}

		public void Insert(Vector3 pos, int index)
		{
			m_positions.Insert(index, pos);
		}

		public readonly IEnumerator<Vector3> GetEnumerator()
		{
			foreach (Vector3 position in m_positions)
			{
				yield return position;
			}
		}

		readonly IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public static implicit operator Vector3[](AnimationPath path)
		{
			return path.m_positions.ToArray();
		}
	}
}
