using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class AgentDependencies : MonoBehaviour, IGive<EBone, Transform>
	{
		private Agent _agent;

		public AgentSkeletonData SkeletonData => _agent.SkeletonData;

		private void Awake()
		{
			_agent = GetComponentInParent<Agent>();
		}

		public Transform Get(EBone key)
		{
			if (!SkeletonData.TryGetBone(key, out var boneTransform))
			{
				return null;
			}
			return boneTransform;
		}
	}
}
