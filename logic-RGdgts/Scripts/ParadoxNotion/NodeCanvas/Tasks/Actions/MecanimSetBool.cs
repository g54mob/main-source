using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class MecanimSetBool : ActionTask<Animator>
	{
		public BBParameter<string> parameter;

		public BBParameter<int> parameterHashID;

		public BBParameter<bool> setTo;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
