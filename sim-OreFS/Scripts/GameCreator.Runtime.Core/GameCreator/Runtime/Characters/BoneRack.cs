using System;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class BoneRack
	{
		[SerializeField]
		private Skeleton m_Skeleton;

		public bool HasSkeleton => m_Skeleton != null;

		public Skeleton Skeleton
		{
			get
			{
				return m_Skeleton;
			}
			set
			{
				m_Skeleton = value;
				this.EventChangeSkeleton?.Invoke();
			}
		}

		public event Action EventChangeSkeleton;

		internal void DrawGizmos(Animator animator)
		{
			if (!(animator == null) && !(Skeleton == null))
			{
				Skeleton.DrawGizmos(animator, Volumes.Display.Solid);
			}
		}
	}
}
