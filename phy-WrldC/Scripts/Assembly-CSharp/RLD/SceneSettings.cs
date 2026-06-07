using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class SceneSettings : Settings
	{
		[SerializeField]
		private ScenePhysicsMode _physicsMode = ScenePhysicsMode.RLD;

		[SerializeField]
		private float _nonMeshObjectSize = 1f;

		public ScenePhysicsMode PhysicsMode
		{
			get
			{
				return _physicsMode;
			}
			set
			{
				if (!Application.isPlaying)
				{
					_physicsMode = value;
				}
			}
		}

		public float NonMeshObjectSize
		{
			get
			{
				return _nonMeshObjectSize;
			}
			set
			{
				if (!Application.isPlaying)
				{
					_nonMeshObjectSize = Mathf.Max(0.1f, value);
				}
			}
		}
	}
}
