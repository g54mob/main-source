using System;
using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[Serializable]
	[AddComponentMenu("")]
	public class RagdollAnimatorDummyReference : MonoBehaviour
	{
		public MonoBehaviour ParentComponent { get; private set; }

		public bool WasInitialized => ParentComponent != null;

		public RagdollHandler RagdollHandler { get; private set; }

		public void Initialize(MonoBehaviour creator, RagdollHandler handler)
		{
			if (!(ParentComponent != null))
			{
				ParentComponent = creator;
				RagdollHandler = handler;
			}
		}
	}
}
