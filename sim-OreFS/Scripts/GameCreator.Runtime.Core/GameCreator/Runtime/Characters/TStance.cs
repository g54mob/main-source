using System;

namespace GameCreator.Runtime.Characters
{
	public abstract class TStance : IStance
	{
		[NonSerialized]
		private bool m_IsBlocking;

		[NonSerialized]
		private float m_BlockStartTime;

		[NonSerialized]
		private float m_Defense;

		public abstract int Id { get; }

		public abstract Character Character { get; set; }

		[field: NonSerialized]
		protected bool IsEnabled { get; private set; }

		public virtual void OnEnable(Character character)
		{
			IsEnabled = true;
		}

		public virtual void OnDisable(Character character)
		{
			IsEnabled = false;
		}

		public abstract void OnUpdate();
	}
}
