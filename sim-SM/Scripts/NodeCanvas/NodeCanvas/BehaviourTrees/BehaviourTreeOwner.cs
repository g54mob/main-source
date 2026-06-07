using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[AddComponentMenu("NodeCanvas/Behaviour Tree Owner")]
	public class BehaviourTreeOwner : GraphOwner<BehaviourTree>
	{
		public bool repeat
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float updateInterval
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Status rootStatus => default(Status);

		public Status Tick()
		{
			return default(Status);
		}
	}
}
