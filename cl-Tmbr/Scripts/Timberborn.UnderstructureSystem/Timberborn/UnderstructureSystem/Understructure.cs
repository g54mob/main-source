using System;
using Timberborn.BaseComponentSystem;
using Timberborn.BlockSystem;
using Timberborn.EntitySystem;

namespace Timberborn.UnderstructureSystem
{
	internal class Understructure : BaseComponent, IDeletableEntity, IFinishedStateListener
	{
		public event EventHandler Deleted;

		public event EventHandler EnteredFinishedState;

		public void DeleteEntity()
		{
			this.Deleted?.Invoke(this, EventArgs.Empty);
		}

		public void OnEnterFinishedState()
		{
			this.EnteredFinishedState?.Invoke(this, EventArgs.Empty);
		}

		public void OnExitFinishedState()
		{
		}
	}
}
