using System;
using System.Collections;
using FIMSpace.FLook;
using NSMedieval.State;
using NSMedieval.View;
using UnityEngine;

namespace NSMedieval.LookAt
{
	public class AgentLookAtHelper : MonoBehaviour
	{
		[SerializeField]
		private Transform lookAtPoint;

		[NonSerialized]
		private FLookAnimator lookAnimator;

		[NonSerialized]
		private CreatureBase creatureBase;

		private const float ClearTargetAfter = 15f;

		public Transform LookAtPoint => lookAtPoint;

		private void Start()
		{
			TryGetComponent<FLookAnimator>(out var component);
			lookAnimator = component;
			TryGetComponent<AnimatedAgentView>(out var component2);
			creatureBase = component2.GetAsCreature();
			creatureBase.ProximityInteractionEvent += UpdateLookTarget;
		}

		public void UpdateLookTarget(CreatureBase val, CreatureBase target)
		{
			if (lookAnimator != null)
			{
				StopCoroutine(ClearTarget());
				lookAnimator.ObjectToFollow = target.GetTransform().GetComponent<AgentLookAtHelper>().lookAtPoint;
				StartCoroutine(ClearTarget());
			}
		}

		private IEnumerator ClearTarget()
		{
			yield return new WaitForSeconds(15f);
			lookAnimator.ObjectToFollow = null;
		}

		private void OnDestroy()
		{
			creatureBase = null;
			lookAnimator = null;
		}
	}
}
