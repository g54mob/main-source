using System;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	public class AreaOfEffectCursor : CTSBehaviour, IPoolable
	{
		[SerializeField]
		[Inject(false)]
		private SphereCollider _sphereCollider;

		[SerializeField]
		[Inject(false)]
		private BoxCollider _boxCollider;

		PoolGuid IPoolable.PoolGuid { get; set; }

		public int OverlapNonAlloc(Collider[] alloc, int layerMask, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			if ((bool)_sphereCollider)
			{
				return _sphereCollider.OverlapNonAlloc(alloc, layerMask, queryTriggerInteraction);
			}
			if ((bool)_boxCollider)
			{
				return _boxCollider.OverlapNonAlloc(alloc, layerMask, queryTriggerInteraction);
			}
			throw new NullReferenceException("No collider is referenced");
		}
	}
}
