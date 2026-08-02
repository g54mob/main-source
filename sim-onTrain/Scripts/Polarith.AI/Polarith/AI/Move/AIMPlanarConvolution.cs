using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Behaviours/Processing/AIM Planar Convolution")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-planarconvolution.html")]
	public sealed class AIMPlanarConvolution : AIMBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public PlanarConvolution PlanarConvolution = new PlanarConvolution();

		private int i;

		public override MoveBehaviour Behaviour => PlanarConvolution;

		public override bool ThreadSafe => true;

		public override void PrepareEvaluation()
		{
			base.PrepareEvaluation();
			for (i = 0; i < PlanarConvolution.TargetObjectives.Count; i++)
			{
				if (PlanarConvolution.TargetObjectives[i] < 0 || PlanarConvolution.TargetObjectives[i] >= context.Problem.ObjectiveCount)
				{
					Debug.LogWarning("(" + typeof(AIMPlanarConvolution).Name + ") " + base.gameObject.name + ": the set target objective no. '" + i + "' with value '" + PlanarConvolution.TargetObjectives[i] + "' is not valid");
				}
			}
		}

		protected override void Reset()
		{
			PlanarConvolution.TargetObjectives = GetDefaultTargetObjectives();
			PlanarConvolution.ComputeGaussianKernel(3, 0.7f);
			Order = 1000;
			base.Reset();
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			CheckFirstAndCentralOrder(typeof(AIMPlanarConvolution));
		}
	}
}
