using NodeCanvas.Framework;

namespace NodeCanvas.BehaviourTrees
{
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
