using UnityEngine;

namespace NSEipix.TaskManager
{
	public abstract class Step
	{
		private float timer;

		private float unScaledTimer;

		public float Timer => timer;

		public float UnScaledTimer => unScaledTimer;

		public void Update()
		{
			timer += Time.deltaTime;
			unScaledTimer += Time.unscaledDeltaTime;
			OnUpdate();
		}

		public abstract bool IsCompleted();

		public virtual void OnCompleted()
		{
		}

		protected virtual void OnUpdate()
		{
		}
	}
}
