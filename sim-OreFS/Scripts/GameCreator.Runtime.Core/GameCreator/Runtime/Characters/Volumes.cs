using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Volumes : TPolymorphicList<TVolume>
	{
		public enum Display
		{
			None = 0,
			Outline = 1,
			Solid = 2
		}

		[SerializeReference]
		private IVolume[] m_Volumes;

		public override int Length => m_Volumes.Length;

		public Volumes()
		{
			m_Volumes = Array.Empty<IVolume>();
		}

		public Volumes(params IVolume[] volumes)
		{
			List<IVolume> list = new List<IVolume>();
			foreach (IVolume volume in volumes)
			{
				if (volume != null)
				{
					list.Add(volume);
				}
			}
			m_Volumes = list.ToArray();
		}

		public GameObject[] Update(Animator animator, float mass, Skeleton skeleton)
		{
			GameObject[] array = new GameObject[m_Volumes.Length];
			float weightDistribution = GetWeightDistribution();
			for (int i = 0; i < m_Volumes.Length; i++)
			{
				float mass2 = mass * (m_Volumes[i].Weight / weightDistribution);
				array[i] = m_Volumes[i].UpdatePass1Physics(animator, mass2, skeleton);
			}
			for (int j = 0; j < m_Volumes.Length; j++)
			{
				if (!(array[j] == null))
				{
					m_Volumes[j].UpdatePass2Joints(array[j], animator, skeleton);
				}
			}
			return array;
		}

		private float GetWeightDistribution()
		{
			float num = 0f;
			IVolume[] volumes = m_Volumes;
			foreach (IVolume volume in volumes)
			{
				num += volume.Weight;
			}
			return num;
		}

		public void DrawGizmos(Animator animator, Display display)
		{
			Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
			IVolume[] volumes = m_Volumes;
			for (int i = 0; i < volumes.Length; i++)
			{
				volumes[i].DrawGizmos(animator, display);
			}
		}
	}
}
