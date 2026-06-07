using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class UITPDeath : MonoBehaviour
	{
		[SerializeField]
		public Image deathMask;

		[SerializeField]
		public List<Image> deathCape;

		[SerializeField]
		public List<Image> glitch;

		[SerializeField]
		public Image leftHand;

		[SerializeField]
		public Image rightHand;

		[SerializeField]
		public Image leftCracks;

		[SerializeField]
		public Image rightCracks;

		[SerializeField]
		public Image leftEye;

		[SerializeField]
		public Image rightEye;

		[SerializeField]
		public List<Image> leftJoints;

		[SerializeField]
		public List<Image> rightJoints;

		private MultiTargetTween _armTween;

		[NonSerialized]
		public int glitchIndex;

		[NonSerialized]
		public float glitchYOffset;

		[NonSerialized]
		public float leftHandOffset;

		[NonSerialized]
		public float rightHandOffset;

		[NonSerialized]
		public bool leftHandScale;

		[NonSerialized]
		public bool rightHandScale;

		private float _crawlTimer;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void StartMovingArms()
		{
		}

		protected void Update()
		{
		}

		private void UpdateJoints(Image arm, List<Image> armSprites, bool shouldScale)
		{
		}

		private float FindNextJointT(float2 start, float2 end, float2 lastJointPos, float lastJointT, float desiredDistance, float iterationStep = -0.01f)
		{
			return 0f;
		}

		private float2 ArmSample(float2 start, float2 end, float t)
		{
			return default(float2);
		}

		private void OnDestroy()
		{
		}
	}
}
