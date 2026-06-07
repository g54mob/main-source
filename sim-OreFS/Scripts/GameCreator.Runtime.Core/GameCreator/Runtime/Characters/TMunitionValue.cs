using System;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public abstract class TMunitionValue : ICloneable
	{
		public event Action EventChange;

		protected void ExecuteEventChange()
		{
			this.EventChange?.Invoke();
		}

		public abstract override string ToString();

		public abstract object Clone();
	}
}
