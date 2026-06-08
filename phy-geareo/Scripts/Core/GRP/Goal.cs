using System;
using UnityEngine;

namespace GRP
{
	public abstract class Goal : MonoBehaviour
	{
		public bool completed;

		public Action onChanged;

		public GoalConfig config { get; private set; }

		public void _Setup(GoalConfig config)
		{
		}

		protected virtual void Setup()
		{
		}

		public void Complete()
		{
		}

		public void UnComplete()
		{
		}
	}
}
