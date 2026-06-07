using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Colliders/Trigger Enter")]
	[SelectionBase]
	public class TriggerEnter : MonoBehaviour
	{
		public LayerReference Layer = new LayerReference(-1);

		[SerializeField]
		private QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

		[Tooltip("On Trigger Enter only works with the first colliders that enters")]
		public bool UseOnce;

		[Tooltip("Search only Tags")]
		public Tag[] Tags;

		public ColliderEvent onTriggerEnter = new ColliderEvent();

		public GameObjectEvent onCoreObject = new GameObjectEvent();

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

		private void OnEnable()
		{
			OwnCollider = GetComponent<Collider>();
			Active = true;
			if ((bool)OwnCollider)
			{
				OwnCollider.isTrigger = true;
				return;
			}
			Active = false;
			Debug.LogError("This Script requires a Collider, please add any type of collider", this);
		}

		public bool TrueConditions(Collider other)
		{
			if (!Active)
			{
				return false;
			}
			if (Tags != null && Tags.Length != 0 && !other.gameObject.HasMalbersTagInParent(Tags))
			{
				return false;
			}
			if (OwnCollider == null)
			{
				return false;
			}
			if (other == null)
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
			if (other.transform.SameHierarchy(base.transform))
			{
				return false;
			}
			return true;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (TrueConditions(other))
			{
				IObjectCore componentInParent = other.GetComponentInParent<IObjectCore>();
				onCoreObject.Invoke((componentInParent != null) ? componentInParent.transform.gameObject : other.transform.root.gameObject);
				onTriggerEnter.Invoke(other);
				if (UseOnce)
				{
					Active = false;
					OwnCollider.enabled = false;
					base.gameObject.SetActive(value: false);
				}
			}
		}
	}
}
