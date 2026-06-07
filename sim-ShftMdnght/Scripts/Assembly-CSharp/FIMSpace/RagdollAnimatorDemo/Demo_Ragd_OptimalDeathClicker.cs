using System.Collections;
using FIMSpace.FProceduralAnimation;
using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	public class Demo_Ragd_OptimalDeathClicker : MonoBehaviour
	{
		public float Impact = 4f;

		public LayerMask RaycastMask;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo, float.PositiveInfinity, RaycastMask, QueryTriggerInteraction.Collide))
			{
				RagdollAnimator2 component = hitInfo.transform.GetComponent<RagdollAnimator2>();
				if ((bool)component)
				{
					component.Handler.Mecanim.enabled = false;
					component.enabled = true;
					StartCoroutine(CallImpulse(component));
				}
			}
		}

		private IEnumerator CallImpulse(RagdollAnimator2 rag)
		{
			yield return null;
			yield return new WaitForFixedUpdate();
			foreach (RagdollBonesChain chain in rag.Handler.Chains)
			{
				foreach (RagdollChainBone boneSetup in chain.BoneSetups)
				{
					Rigidbody component = boneSetup.SourceBone.GetComponent<Rigidbody>();
					if (!(component == null))
					{
						RagdollHandlerUtilities.ApplyLimbImpact(component, Camera.main.transform.forward * Impact, ForceMode.Force);
					}
				}
			}
		}
	}
}
