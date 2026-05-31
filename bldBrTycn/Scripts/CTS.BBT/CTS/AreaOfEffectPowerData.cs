using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public abstract class AreaOfEffectPowerData : ScriptableObject
	{
		[field: SerializeField]
		public AreaOfEffectCursor CursorPrefab { get; private set; }

		[field: SerializeField]
		public OrderedSelectionMode SelectionMode { get; private set; }

		[field: SerializeField]
		public LayerMask SphereCastLayerMask { get; private set; }

		[field: SerializeField]
		public VFXTimer EffectPrefab { get; private set; }

		[field: SerializeField]
		public float PhysicsScanDelay { get; private set; }

		public abstract void CastPower(List<Collider> colliders);
	}
}
