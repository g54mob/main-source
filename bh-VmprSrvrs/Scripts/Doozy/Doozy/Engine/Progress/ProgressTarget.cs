using System;
using UnityEngine;

namespace Doozy.Engine.Progress
{
	[Serializable]
	public abstract class ProgressTarget : MonoBehaviour
	{
		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void UpdateTarget(Progressor progressor)
		{
		}
	}
}
