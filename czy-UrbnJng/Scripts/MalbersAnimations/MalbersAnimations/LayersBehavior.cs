using UnityEngine;

namespace MalbersAnimations
{
	public class LayersBehavior : StateMachineBehaviour
	{
		public LayersActivation[] layers;

		private AnimatorTransitionInfo transition;

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			LayersActivation[] array = layers;
			foreach (LayersActivation layersActivation in array)
			{
				int layerIndex2 = animator.GetLayerIndex(layersActivation.layer);
				transition = animator.GetAnimatorTransitionInfo(layerIndex);
				if (animator.IsInTransition(layerIndex))
				{
					if (layersActivation.activate)
					{
						if (layersActivation.transA == StateTransition.First && stateInfo.normalizedTime <= 0.5f)
						{
							animator.SetLayerWeight(layerIndex2, transition.normalizedTime);
						}
						if (layersActivation.transA == StateTransition.Last && stateInfo.normalizedTime >= 0.5f)
						{
							animator.SetLayerWeight(layerIndex2, transition.normalizedTime);
						}
					}
					if (layersActivation.deactivate)
					{
						if (layersActivation.transD == StateTransition.First && stateInfo.normalizedTime <= 0.5f)
						{
							animator.SetLayerWeight(layerIndex2, 1f - transition.normalizedTime);
						}
						if (layersActivation.transD == StateTransition.Last && stateInfo.normalizedTime >= 0.5f)
						{
							animator.SetLayerWeight(layerIndex2, 1f - transition.normalizedTime);
						}
					}
				}
				else
				{
					if (layersActivation.activate && layersActivation.transA == StateTransition.First)
					{
						animator.SetLayerWeight(layerIndex2, 1f);
					}
					if (layersActivation.deactivate && layersActivation.transD == StateTransition.First)
					{
						animator.SetLayerWeight(layerIndex2, 0f);
					}
				}
			}
		}

		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			LayersActivation[] array = layers;
			foreach (LayersActivation layersActivation in array)
			{
				int layerIndex2 = animator.GetLayerIndex(layersActivation.layer);
				if (layersActivation.activate && layersActivation.transA == StateTransition.Last)
				{
					animator.SetLayerWeight(layerIndex2, 1f);
				}
				if (layersActivation.deactivate && layersActivation.transD == StateTransition.Last)
				{
					animator.SetLayerWeight(layerIndex2, 0f);
				}
			}
		}
	}
}
