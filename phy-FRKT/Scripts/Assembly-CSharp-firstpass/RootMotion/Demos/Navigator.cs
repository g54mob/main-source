using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace RootMotion.Demos
{
	[Serializable]
	public class Navigator
	{
		public enum State
		{
			Idle = 0,
			Seeking = 1,
			OnPath = 2
		}

		public bool activeTargetSeeking;

		public float cornerRadius;

		public float recalculateOnPathDistance;

		public float maxSampleDistance;

		public float nextPathInterval;

		private Transform unx;

		private int uny;

		private Vector3[] unz;

		private NavMeshPath uoa;

		private Vector3 uob;

		private bool uoc;

		private float uod;

		public Vector3 unv
		{
			[CompilerGenerated]
			get
			{
				return default(Vector3);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public State unw
		{
			[CompilerGenerated]
			get
			{
				return default(State);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public void lip(Transform a)
		{
		}

		public void liq(Vector3 a)
		{
		}

		private void lir(Vector3 a)
		{
		}

		private bool lis(Vector3 a)
		{
			return false;
		}

		private void Stop()
		{
		}

		private float lit(Vector3 a, Vector3 b)
		{
			return 0f;
		}

		public void liu()
		{
		}
	}
}
