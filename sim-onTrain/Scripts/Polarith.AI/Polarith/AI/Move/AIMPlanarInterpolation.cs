using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Processing/AIM Planar Interpolation")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-planarinterpolation.html")]
	[DisallowMultipleComponent]
	public sealed class AIMPlanarInterpolation : AIMBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public PlanarInterpolation PlanarInterpolation = new PlanarInterpolation();

		public override MoveBehaviour Behaviour => PlanarInterpolation;

		public override bool ThreadSafe => true;

		public override void PrepareEvaluation()
		{
			base.PrepareEvaluation();
			if (PlanarInterpolation.TargetObjective < 0 || PlanarInterpolation.TargetObjective >= context.Problem.ObjectiveCount)
			{
				Debug.LogWarning("(" + typeof(AIMPlanarInterpolation).Name + ") " + base.gameObject.name + ": the set target objective with value '" + PlanarInterpolation.TargetObjective + "' is not valid");
			}
		}

		protected override void Reset()
		{
			Order = 2000;
			base.Reset();
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			CheckLastOrder(typeof(AIMPlanarInterpolation));
		}
	}
}
