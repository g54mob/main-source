using System;
using UnityEngine;

namespace Coherence.Toolkit
{
	[Serializable]
	internal class ArchetypeLODStep
	{
		[SerializeField]
		private float distance;

		public float Distance => 0f;

		public ArchetypeLODStep()
		{
		}

		public void SetDistance(float newDistance)
		{
		}

		public ArchetypeLODStep(ArchetypeLODStep other)
		{
		}
	}
}
