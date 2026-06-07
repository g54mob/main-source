using System;
using RootMotion.FinalIK;
using UnityEngine;

public class bpy : MonoBehaviour
{
	[Serializable]
	public class EffectorLink
	{
		public bool enabled;

		public FullBodyBipedEffector effectorType;

		public bms interactionObject;

		public Transform spherecastFrom;

		public float spherecastRadius;

		public float minDistance;

		public float distanceMlp;

		public LayerMask touchLayers;

		public float lerpSpeed;

		public float minSwitchTime;

		public float releaseDistance;

		public bool sliding;

		private Vector3 ukh;

		private float uki;

		private bool ukj;

		private RaycastHit ukk;

		private Vector3 ukl;

		private Quaternion ukm;

		private bool ukn;

		private float uko;

		private float ukp;

		public void lgk(InteractionSystem a)
		{
		}

		private bool lgl(Vector3 a)
		{
			return false;
		}

		public void lgm(InteractionSystem a)
		{
		}

		private void lgn(InteractionSystem a)
		{
		}

		private void lgo(FullBodyBipedEffector a, bms b)
		{
		}

		private void lgp(FullBodyBipedEffector a, bms b)
		{
		}

		private void lgq(FullBodyBipedEffector a, bms b)
		{
		}

		public void lgr(InteractionSystem a)
		{
		}
	}

	public InteractionSystem interactionSystem;

	public EffectorLink[] effectorLinks;

	private void Start()
	{
	}

	private void eom()
	{
	}

	private void FixedUpdate()
	{
	}

	private void eve()
	{
	}

	private void OnDestroy()
	{
	}
}
