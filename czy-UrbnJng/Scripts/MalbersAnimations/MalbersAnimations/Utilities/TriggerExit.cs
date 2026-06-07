using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Colliders/Trigger Exit")]
	public class TriggerExit : MonoBehaviour
	{
		public LayerReference Layer = new LayerReference(-1);

		[SerializeField]
		private QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

		public ColliderEvent onTriggerExit = new ColliderEvent();

		public Collider OwnCollider { get; private set; }

		public bool Active
		{
			get
			{
				return base.enabled;
			}
			set
			{
				base.enabled = value;
			}
		}

		public QueryTriggerInteraction TriggerInteraction
		{
			get
			{
				return triggerInteraction;
			}
			set
			{
				triggerInteraction = value;
			}
		}

		public bool TrueConditions(Collider other)
		{
			if (!Active)
			{
				return false;
			}
			if (triggerInteraction == QueryTriggerInteraction.Ignore && other.isTrigger)
			{
				return false;
			}
			if (!MTools.Layer_in_LayerMask(other.gameObject.layer, Layer))
			{
				return false;
			}
			if (base.transform.IsChildOf(other.transform))
			{
				return false;
			}
			return true;
		}

		private void OnTriggerExit(Collider other)
		{
			if (TrueConditions(other))
			{
				onTriggerExit.Invoke(other);
			}
		}

		private void Start()
		{
			OwnCollider = GetComponent<Collider>();
			Active = true;
			if ((bool)OwnCollider)
			{
				OwnCollider.isTrigger = true;
			}
			else
			{
				Debug.LogError("This Script requires a Collider, please add any type of collider");
			}
		}
	}
}
