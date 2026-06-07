using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class MecanimSetFloat : ActionTask<Animator>
	{
		public BBParameter<string> parameter;

		public BBParameter<int> parameterHashID;

		public BBParameter<float> setTo;

		public float transitTime;

		private float currentValue;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}

		private float Get()
		{
			return 0f;
		}

		private void Set(float newValue)
		{
		}
	}
}
