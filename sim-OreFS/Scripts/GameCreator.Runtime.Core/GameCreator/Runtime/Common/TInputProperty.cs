using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TInputProperty
	{
		protected abstract TInput Input { get; }

		public void OnStartup()
		{
			Input.OnStartup();
		}

		public void OnDispose()
		{
			Input.OnDispose();
		}

		public void OnUpdate()
		{
			Input.OnUpdate();
		}

		public abstract override string ToString();
	}
}
