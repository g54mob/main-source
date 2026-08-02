using System;
using UnityEngine;

namespace CritiasFoliage
{
	[Serializable]
	public class FoliageCollisionSettings
	{
		[Tooltip("Defaults to 'Camera.main.transform'")]
		public Transform m_WatchedTransform;

		[Tooltip("How many meters around the watched transform we are going to add colliders")]
		[Range(0f, 100f)]
		public float m_CollisionDistance = 7f;

		[Tooltip("After how many walked meters we are going to refresh the colliders")]
		[Range(0f, 50f)]
		public float m_CollisionRefreshDistance = 5f;

		[Tooltip("What layer we are going to use for the GameObject colliders")]
		public string m_UsedLayer = "Default";
	}
}
