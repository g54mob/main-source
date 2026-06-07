using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	[Serializable]
	[Title("Twitching")]
	[Category("Twitching")]
	[Image(typeof(IconTwitching), ColorTheme.Type.Green)]
	[Description("Subtly rotates the arms, fingers and hand bones to make them appear alive")]
	public class RigTwitching : TRigAnimatorIK
	{
		private const int RANDOM_MIN = 0;

		private const int RANDOM_MAX = 999;

		public const string RIG_NAME = "RigTwitching";

		[SerializeField]
		private PropertyGetDecimal m_Speed = new PropertyGetDecimal(0.2f);

		[SerializeField]
		private PropertyGetDecimal m_Intensity = new PropertyGetDecimal(5f);

		[SerializeField]
		private PropertyGetDecimal m_ArmsTwitch = new PropertyGetDecimal(1f);

		[SerializeField]
		private PropertyGetDecimal m_HandsTwitch = new PropertyGetDecimal(1f);

		[SerializeField]
		private PropertyGetDecimal m_FingersTwitch = new PropertyGetDecimal(1f);

		[NonSerialized]
		private Dictionary<HumanBodyBones, Vector3> m_Noises = new Dictionary<HumanBodyBones, Vector3>();

		[NonSerialized]
		private readonly HumanBodyBones[] m_Arms = new HumanBodyBones[4]
		{
			HumanBodyBones.LeftLowerArm,
			HumanBodyBones.LeftUpperArm,
			HumanBodyBones.RightLowerArm,
			HumanBodyBones.RightUpperArm
		};

		[NonSerialized]
		private readonly HumanBodyBones[] m_Hands = new HumanBodyBones[2]
		{
			HumanBodyBones.LeftHand,
			HumanBodyBones.RightHand
		};

		[NonSerialized]
		private readonly HumanBodyBones[] m_Fingers = new HumanBodyBones[10]
		{
			HumanBodyBones.LeftIndexProximal,
			HumanBodyBones.LeftMiddleProximal,
			HumanBodyBones.LeftRingProximal,
			HumanBodyBones.LeftLittleProximal,
			HumanBodyBones.LeftThumbProximal,
			HumanBodyBones.RightIndexProximal,
			HumanBodyBones.RightMiddleProximal,
			HumanBodyBones.RightRingProximal,
			HumanBodyBones.RightLittleProximal,
			HumanBodyBones.RightThumbProximal
		};

		public override string Title => "Twitch";

		public override string Name => "RigTwitching";

		public override bool RequiresHuman => true;

		public override bool DisableOnBusy => false;

		protected override void DoStartup(Character character)
		{
			base.DoStartup(character);
			HumanBodyBones[] arms = m_Arms;
			foreach (HumanBodyBones key in arms)
			{
				Vector3 value = new Vector3(UnityEngine.Random.Range(0, 999), UnityEngine.Random.Range(0, 999), UnityEngine.Random.Range(0, 999));
				m_Noises.TryAdd(key, value);
			}
			arms = m_Hands;
			foreach (HumanBodyBones key2 in arms)
			{
				Vector3 value2 = new Vector3(UnityEngine.Random.Range(0, 999), UnityEngine.Random.Range(0, 999), UnityEngine.Random.Range(0, 999));
				m_Noises.TryAdd(key2, value2);
			}
			arms = m_Fingers;
			foreach (HumanBodyBones key3 in arms)
			{
				Vector3 value3 = new Vector3(UnityEngine.Random.Range(0, 999), UnityEngine.Random.Range(0, 999), UnityEngine.Random.Range(0, 999));
				m_Noises.TryAdd(key3, value3);
			}
		}

		protected override void DoEnable(Character character)
		{
			base.DoEnable(character);
			character.EventBeforeLateUpdate -= OnLateUpdate;
			character.EventBeforeLateUpdate += OnLateUpdate;
		}

		protected override void DoDisable(Character character)
		{
			base.DoDisable(character);
			character.EventBeforeLateUpdate -= OnLateUpdate;
		}

		private void OnLateUpdate()
		{
			float time = base.Character.Time.Time * (float)m_Speed.Get(base.Args);
			float num = (float)m_Intensity.Get(base.Args);
			float num2 = (float)m_ArmsTwitch.Get(base.Args);
			float num3 = (float)m_HandsTwitch.Get(base.Args);
			float num4 = (float)m_FingersTwitch.Get(base.Args);
			ApplyTwitch(in m_Arms, time, num2 * num);
			ApplyTwitch(in m_Hands, time, num3 * num);
			ApplyTwitch(in m_Fingers, time, num4 * num);
		}

		private void ApplyTwitch(in HumanBodyBones[] bones, float time, float twitch)
		{
			if (!(twitch <= 0f))
			{
				HumanBodyBones[] array = bones;
				foreach (HumanBodyBones humanBodyBones in array)
				{
					float num = Mathf.PerlinNoise(time + m_Noises[humanBodyBones].x, time + m_Noises[humanBodyBones].y) * 2f - 1f;
					float num2 = Mathf.PerlinNoise(time + m_Noises[humanBodyBones].y, time + m_Noises[humanBodyBones].z) * 2f - 1f;
					float num3 = Mathf.PerlinNoise(time + m_Noises[humanBodyBones].z, time + m_Noises[humanBodyBones].x) * 2f - 1f;
					Quaternion quaternion = Quaternion.Euler(num * twitch, num2 * twitch, num3 * twitch);
					base.Character.Animim.Animator.GetBoneTransform(humanBodyBones).localRotation *= quaternion;
				}
			}
		}
	}
}
