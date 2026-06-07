using System;
using LocoSim.Implementations.Wheels;
using UnityEngine;

namespace DV.Wheels
{
	public class PoweredWheelRotationViaAnimation : PoweredWheelRotationBase
	{
		[Serializable]
		public class AnimatorStartTimeOffsetPair
		{
			public Animator animator;

			[Range(0f, 1f)]
			public float startTimeOffset;
		}

		private const string SPEED = "SpeedMultiplier";

		private static readonly int SPEED_ID = Animator.StringToHash("SpeedMultiplier");

		public AnimatorStartTimeOffsetPair[] animatorSetups;

		protected override void Awake()
		{
			base.Awake();
			AnimatorStartTimeOffsetPair[] array = animatorSetups;
			foreach (AnimatorStartTimeOffsetPair animatorStartTimeOffsetPair in array)
			{
				Animator animator = animatorStartTimeOffsetPair.animator;
				animator.Play(animator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, animatorStartTimeOffsetPair.startTimeOffset);
			}
		}

		private void Update()
		{
			bool flag = true;
			PoweredWheel[] poweredWheels = poweredWheelsManager.poweredWheels;
			for (int i = 0; i < poweredWheels.Length; i++)
			{
				if (!poweredWheels[i].IsPowered)
				{
					flag = false;
					break;
				}
			}
			float value = (flag ? GetRPS() : GetRollingRPS());
			AnimatorStartTimeOffsetPair[] array = animatorSetups;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].animator.SetFloat(SPEED_ID, value);
			}
		}

		private void OnDisable()
		{
			AnimatorStartTimeOffsetPair[] array = animatorSetups;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].animator.SetFloat(SPEED_ID, 0f);
			}
		}
	}
}
