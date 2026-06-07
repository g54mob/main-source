using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public class Phases
	{
		public static readonly int[] HASH_PHASES = new int[4]
		{
			Animator.StringToHash("Phase-0"),
			Animator.StringToHash("Phase-1"),
			Animator.StringToHash("Phase-2"),
			Animator.StringToHash("Phase-3")
		};

		private const float GROUND_THRESHOLD = 0.1f;

		[NonSerialized]
		private Animator m_Animator;

		[NonSerialized]
		private int m_LastChangeFrame = -1;

		[NonSerialized]
		private Phase[] m_Phases;

		public static int Count => HASH_PHASES.Length;

		internal void Setup(Animator animator)
		{
			m_Animator = animator;
			m_Phases = new Phase[Count];
			for (int i = 0; i < Count; i++)
			{
				m_Phases[i] = new Phase();
			}
		}

		internal void Reset()
		{
			Phase[] phases = m_Phases;
			for (int i = 0; i < phases.Length; i++)
			{
				phases[i].Reset();
			}
		}

		internal void Set(int phase, float value, float weight)
		{
			if (Time.frameCount != m_LastChangeFrame)
			{
				Reset();
			}
			m_Phases[phase].Add(value, weight);
			m_LastChangeFrame = Time.frameCount;
		}

		public bool IsGround(int index)
		{
			return Get(index) >= 0.1f;
		}

		public float Get(int index)
		{
			float source = ((m_Animator != null) ? m_Animator.GetFloat(HASH_PHASES[index]) : 0f);
			if (index < 0 || index >= Count)
			{
				return 0f;
			}
			return m_Phases[index].Get(source);
		}
	}
}
