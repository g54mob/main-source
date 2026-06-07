using System;
using LocoSim.Definitions;

namespace LocoSim.Implementations
{
	public class Fuse
	{
		public readonly string id;

		public readonly float offValue;

		private bool state;

		public bool State
		{
			get
			{
				return state;
			}
			private set
			{
				if (state != value)
				{
					state = value;
					this.StateUpdated?.Invoke(state);
				}
			}
		}

		public event Action<bool> StateUpdated;

		public Fuse(string compId, FuseDefinition fuseDef)
		{
			id = SimConsts.GetFullId(compId, fuseDef.id);
			State = fuseDef.initialState;
			offValue = fuseDef.offValue;
		}

		public void ChangeState(bool newState)
		{
			State = newState;
		}

		public float ProcessInput(float input)
		{
			if (!State)
			{
				return offValue;
			}
			return input;
		}
	}
}
