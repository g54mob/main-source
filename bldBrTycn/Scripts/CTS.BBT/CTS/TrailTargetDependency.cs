using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class TrailTargetDependency : MonoBehaviour, IDependencyResolver<VFXData>
	{
		[SerializeField]
		private ReceiverReference<Transform>[] _receivers;

		public void ResolveDependencies(GameObject obj, VFXData vfxData)
		{
			TrailTarget trailTarget = obj.GetComponentInParent<IGive<VFXData, TrailTarget>>().Get(vfxData);
			if ((object)trailTarget.Target == null)
			{
				throw new NullReferenceException("Trail needs a target, but couldn't find any");
			}
			ReceiverReference<Transform>[] receivers = _receivers;
			foreach (ReceiverReference<Transform> receiverReference in receivers)
			{
				receiverReference.Give(trailTarget.Target);
			}
		}
	}
}
