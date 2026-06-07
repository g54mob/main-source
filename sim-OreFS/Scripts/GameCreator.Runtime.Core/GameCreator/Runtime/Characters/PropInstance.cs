using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	internal class PropInstance : IProp
	{
		private readonly IBone m_Bone;

		private readonly Vector3 m_OffsetPosition;

		private readonly Quaternion m_OffsetRotation;

		private readonly Vector3 m_LocalScale;

		[field: NonSerialized]
		public Transform Bone { get; private set; }

		[field: NonSerialized]
		public GameObject Instance { get; }

		public PropInstance(IBone bone, GameObject instance, Vector3 position, Quaternion rotation)
		{
			m_Bone = bone;
			Instance = instance;
			m_OffsetPosition = position;
			m_OffsetRotation = rotation;
			m_LocalScale = ((instance != null) ? instance.transform.localScale : Vector3.one);
		}

		public void Create(Animator animator)
		{
			if (!(animator == null) && !(Instance == null))
			{
				Bone = m_Bone?.GetTransform(animator);
				if (!(Bone == null))
				{
					Instance.transform.localScale = m_LocalScale;
					Instance.transform.SetParent(Bone, worldPositionStays: true);
					Instance.transform.localPosition = m_OffsetPosition;
					Instance.transform.localRotation = m_OffsetRotation;
				}
			}
		}

		public void Destroy()
		{
			if (!(Instance == null))
			{
				UnityEngine.Object.Destroy(Instance);
			}
		}

		public void Drop()
		{
			if (!(Instance == null))
			{
				Instance.transform.SetParent(null, worldPositionStays: true);
			}
		}
	}
}
