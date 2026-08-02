using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Processing/AIM Stabilization")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-stabilization.html")]
	public sealed class AIMStabilization : AIMBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Stabilization Stabilization = new Stabilization();

		private AIMFilter<SteeringPercept> filter;

		public override MoveBehaviour Behaviour => Stabilization;

		public override bool ThreadSafe => true;

		public override void PrepareEvaluation()
		{
			base.PrepareEvaluation();
			if (Stabilization.TargetObjective < 0 || Stabilization.TargetObjective >= context.Problem.ObjectiveCount)
			{
				Debug.LogWarning("(" + typeof(AIMStabilization).Name + ") " + base.gameObject.name + ": the set target objective with value '" + Stabilization.TargetObjective + "' is not valid");
			}
			else if (filter != null)
			{
				Stabilization.Self = filter.Self;
			}
			else
			{
				Stabilization.Self.Receive(base.gameObject);
			}
		}

		protected override void Reset()
		{
			Order = 1000;
			base.Reset();
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			CheckFirstAndCentralOrder(typeof(AIMStabilization));
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			filter = GetComponent<AIMFilter<SteeringPercept>>();
		}
	}
}
