using System.Runtime.CompilerServices;
using Infrastructure.Project.Registration;
using UnityEngine;

namespace Player.GodInventoryItems.Spawnable
{
	public abstract class SpawnableGodInventoryItem<T> : kf, kn where T : g
	{
		[SerializeField]
		private Vector3 m_inHandPivotOffset;

		[SerializeField]
		private Vector3 m_inHandRotationOffset;

		private bex qkp;

		public abstract PrefabID xaw { get; }

		public g xbb => null;

		public Vector3 xbc => default(Vector3);

		public Vector3 xbd => default(Vector3);

		protected T qkq
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public virtual T feh(Vector3 a, Quaternion b)
		{
			return null;
		}

		public void feb(bex a, g b)
		{
		}
	}
}
