using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class AgentSkeletonData : MonoBehaviour, IReceive<EBone, Transform>
	{
		[SerializeField]
		private SerializableDictionary<EBone, Transform> _boneList;

		public bool TryGetBone(EBone boneType, out Transform boneTransform)
		{
			return _boneList.TryGetValue(boneType, out boneTransform);
		}

		private void OnEnable()
		{
			if (!base.transform.parent)
			{
				return;
			}
			AgentSkeletonData componentInParent = base.transform.parent.GetComponentInParent<AgentSkeletonData>();
			if (!componentInParent)
			{
				return;
			}
			foreach (var (key, obj) in _boneList)
			{
				componentInParent.OnReceive(key, obj);
			}
		}

		public void OnReceive(EBone key, Transform obj)
		{
			_boneList[key] = obj;
		}
	}
}
