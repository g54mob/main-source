using UnityEngine;

namespace UniversalInventorySystem
{
	[RequireComponent(typeof(InventoryUI))]
	public class BaseUIModifier : MonoBehaviour
	{
		protected InventoryUI target;

		protected InventoryUI OriginalTarget { get; private set; }

		public InventoryUI GetTarget()
		{
			return target;
		}

		public InventoryUI GetOriginalTarget()
		{
			return OriginalTarget;
		}

		public InventoryUI SetTarget(InventoryUI _target)
		{
			return target = _target;
		}

		public void Start()
		{
			target = GetComponent<InventoryUI>();
			OriginalTarget = target;
		}

		public void OnEnable()
		{
			target = GetComponent<InventoryUI>();
			OriginalTarget = target;
		}
	}
}
