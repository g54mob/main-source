using System;

namespace LocoSim.Implementations
{
	public class FuseReference
	{
		public readonly string fuseId;

		private Fuse fuse;

		public bool State => fuse.State;

		public FuseReference(string fuseId)
		{
			this.fuseId = fuseId;
		}

		public void SubToStateChangedEvent(Action<bool> handler, bool on)
		{
			if (on)
			{
				fuse.StateUpdated += handler;
			}
			else
			{
				fuse.StateUpdated -= handler;
			}
		}

		public void SetFuse(Fuse fuse)
		{
			this.fuse = fuse;
		}

		public void ChangeState(bool newState)
		{
			fuse.ChangeState(newState);
		}

		public float ProcessInput(float input)
		{
			return fuse.ProcessInput(input);
		}
	}
}
