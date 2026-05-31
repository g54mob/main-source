using System;

namespace CTS
{
	[Serializable]
	public abstract class VFXUpdater
	{
		public bool Enabled = true;

		public bool OnStartOnly;

		public float Delay;

		public virtual void Setup()
		{
		}

		public virtual void OnEnable()
		{
		}

		public abstract void Execute();
	}
}
