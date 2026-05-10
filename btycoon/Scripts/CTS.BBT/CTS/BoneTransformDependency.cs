using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class BoneTransformDependency : MonoBehaviour, IDependencyResolver
	{
		[SerializeField]
		private EBone _bone;

		[SerializeField]
		private ReceiverReference<Transform> _Test;

		[SerializeField]
		private List<ReceiverReference<Transform>> _receivers;

		public void ResolveDependencies(GameObject obj)
		{
			IGive<EBone, Transform> componentInParent = obj.GetComponentInParent<IGive<EBone, Transform>>();
			if (componentInParent == null)
			{
				return;
			}
			Transform obj2 = componentInParent.Get(_bone);
			foreach (ReceiverReference<Transform> receiver in _receivers)
			{
				receiver.Give(obj2);
			}
		}
	}
}
