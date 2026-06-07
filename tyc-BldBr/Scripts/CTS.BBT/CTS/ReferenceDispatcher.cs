using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ReferenceDispatcher : CTSBehaviour
	{
		[SerializeField]
		private ParticleSystem _reaperVFX;

		[Header("Targets")]
		[SerializeField]
		private AgentCollider targetHeadDispatch;

		[SerializeField]
		private Agent targetAgentVisual;

		[SerializeField]
		private Animator animator;

		[Tooltip("Agent Collider - HeadBone")]
		[field: SerializeField]
		public Transform headBone { get; private set; }

		[Tooltip("Customer")]
		[field: SerializeField]
		public GameObject agentVisual { get; private set; }

		[Tooltip("Animator")]
		[field: SerializeField]
		public Avatar animatorAvatar { get; private set; }

		[Tooltip("AgentProceduralAnimator")]
		[field: SerializeField]
		public AgentProceduralAnimations agentProceduralAnimator { get; private set; }

		[field: SerializeField]
		public AgentToolUsage tools { get; private set; }

		[field: SerializeField]
		public bool HasDeepVoice { get; private set; }

		[field: Inject(false)]
		public MeshChanger MeshChanger { get; private set; }

		public void SetReferences(ref CharacterData generateData)
		{
			MeshChanger.GenerateHeadNBody(ref generateData);
			targetHeadDispatch.SetHeadBoneFormReferenceDispatcher(headBone);
			targetAgentVisual.SetVisualFormReferenceDispatcher(agentVisual, agentProceduralAnimator);
			targetAgentVisual.HasDeepVoice = HasDeepVoice;
			if (HasDeepVoice)
			{
				targetAgentVisual.Animator.EnableOverride("Man");
			}
			else
			{
				targetAgentVisual.Animator.DisableOverride("Man");
			}
			targetAgentVisual.Tools = tools;
			targetAgentVisual.MeshChanger = MeshChanger;
			targetAgentVisual.ReaperTarget.VFX = _reaperVFX;
		}

		public void RemoveReferences()
		{
			if ((bool)MeshChanger)
			{
				MeshChanger.ClearRenderers();
			}
		}
	}
}
