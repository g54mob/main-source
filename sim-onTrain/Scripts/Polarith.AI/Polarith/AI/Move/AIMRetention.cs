using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Processing/AIM Retention")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-retention.html")]
	public sealed class AIMRetention : AIMBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Retention Retention = new Retention();

		private int i;

		public override MoveBehaviour Behaviour => Retention;

		public override bool ThreadSafe => true;

		public override void PrepareEvaluation()
		{
			base.PrepareEvaluation();
			for (i = 0; i < Retention.TargetObjectives.Count; i++)
			{
				if (Retention.TargetObjectives[i] < 0 || Retention.TargetObjectives[i] >= context.Problem.ObjectiveCount)
				{
					Debug.LogWarning("(" + typeof(AIMRetention).Name + ") " + base.gameObject.name + ": the set target objective no. '" + i + "' with value '" + Retention.TargetObjectives[i] + "' is not valid");
				}
			}
		}

		protected override void Reset()
		{
			Retention.TargetObjectives = GetDefaultTargetObjectives();
			Order = 1000;
			base.Reset();
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			CheckFirstAndCentralOrder(typeof(AIMRetention));
		}
	}
}
