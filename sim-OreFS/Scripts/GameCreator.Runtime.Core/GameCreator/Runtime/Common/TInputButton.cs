using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Input Button")]
	public abstract class TInputButton : TInput
	{
		public event Action EventStart;

		public event Action EventCancel;

		public event Action EventPerform;

		protected void ExecuteEventStart()
		{
			this.EventStart?.Invoke();
		}

		protected void ExecuteEventCancel()
		{
			this.EventCancel?.Invoke();
		}

		protected void ExecuteEventPerform()
		{
			this.EventPerform?.Invoke();
		}
	}
}
