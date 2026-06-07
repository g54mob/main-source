using System;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Utilities/Colliders/Trigger Proxy")]
	public class TriggerProxy : MonoBehaviour
	{
		[Tooltip("Hit Layer for the Trigger Proxy")]
		[SerializeField]
		private LayerReference hitLayer = new LayerReference(-1);

		[SerializeField]
		private QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

		[Tooltip("Search only Tags")]
		public Tag[] Tags;

		public ColliderEvent OnTrigger_Enter = new ColliderEvent();

		public ColliderEvent OnTrigger_Exit = new ColliderEvent();

		public ColliderEvent OnTrigger_Stay = new ColliderEvent();

		public GameObjectEvent OnGameObjectEnter = new GameObjectEvent();

		public GameObjectEvent OnGameObjectExit = new GameObjectEvent();

		public GameObjectEvent OnGameObjectStay = new GameObjectEvent();

		public UnityEvent OnEmpty = new UnityEvent();

		[SerializeField]
		private bool m_debug;

		public BoolReference useOnTriggerStay = new BoolReference();

		[Tooltip("Trigger will be disabled the first time it finds a valid collider")]
		public BoolReference OneTimeUse = new BoolReference();

		[Tooltip("Do not Interact with static colliders")]
		public BoolReference ignoreStatic = new BoolReference();

		protected internal List<Collider> m_colliders = new List<Collider>();

		protected internal List<GameObject> EnteringGameObjects = new List<GameObject>();

		public Action<GameObject, Collider> EnterTriggerInteraction = delegate
		{
		};

		public Action<GameObject, Collider> ExitTriggerInteraction = delegate
		{
		};

		[RequiredField]
		public Collider trigger;

		[HideInInspector]
		public int Editor_Tabs1;

		public LayerMask Layer
		{
			get
			{
				return hitLayer.Value;
			}
			set
			{
				hitLayer.Value = value;
			}
		}

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

		public Transform Owner { get; set; }

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
			if (trigger == null)
			{
				return false;
			}
			if (other == null)
			{
				return false;
			}
			if (other.gameObject.isStatic && ignoreStatic.Value)
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
			if (Owner != null && other.transform.IsChildOf(Owner))
			{
				return false;
			}
			return true;
		}

		public void OnTriggerEnter(Collider other)
		{
			if (!TrueConditions(other))
			{
				return;
			}
			GameObject gameObject = MTools.FindRealRoot(other);
			OnTrigger_Enter.Invoke(other);
			if (m_debug)
			{
				Debug.Log("<b>" + base.name + "</b> [Entering Collider] -> [" + other.name + "]", this);
			}
			if (m_colliders.Find((Collider coll) => coll == other) == null)
			{
				m_colliders.Add(other);
				AddTarget(other);
			}
			if (!EnteringGameObjects.Contains(gameObject))
			{
				EnterTriggerInteraction(gameObject, other);
				EnteringGameObjects.Add(gameObject);
				OnGameObjectEnter.Invoke(gameObject);
				if (m_debug)
				{
					Debug.Log("<b>" + base.name + "</b> [Entering GameObject] -> [" + gameObject.name + "]", this);
				}
				if (OneTimeUse.Value)
				{
					base.enabled = false;
				}
			}
		}

		public void OnTriggerExit(Collider other)
		{
			TriggerExit(other, remove: true);
		}

		public void TriggerExit(Collider other, bool remove)
		{
			if (TrueConditions(other))
			{
				RemoveTrigger(other, remove);
			}
		}

		public virtual void RemoveTrigger(Collider other, bool remove)
		{
			GameObject realRoot = MTools.FindRealRoot(other);
			OnTrigger_Exit.Invoke(other);
			m_colliders.Remove(other);
			RemoveTarget(other, remove);
			if (m_debug)
			{
				Debug.Log("<b>" + base.name + "</b> [Exit Collider] -> [" + other.name + "]", this);
			}
			if (EnteringGameObjects.Contains(realRoot) && !m_colliders.Exists((Collider c) => c != null && c.transform.SameHierarchy(realRoot.transform)))
			{
				EnteringGameObjects.Remove(realRoot);
				OnGameObjectExit.Invoke(realRoot);
				ExitTriggerInteraction(realRoot, other);
				if (m_debug)
				{
					Debug.Log("<b>" + base.name + "</b> [Leaving Gameobject] -> [" + realRoot.name + "]", this);
				}
			}
			if (m_colliders.Count == 0)
			{
				ResetTrigger();
			}
		}

		private void CheckMissingColliders()
		{
			for (int num = m_colliders.Count - 1; num > -1; num--)
			{
				if (m_colliders[num] == null || !m_colliders[num].enabled)
				{
					m_colliders.RemoveAt(num);
				}
			}
			if (m_colliders.Count == 0)
			{
				EnteringGameObjects = new List<GameObject>();
			}
		}

		private void AddTarget(Collider other)
		{
			if (TriggerTarget.set == null)
			{
				TriggerTarget.set = new List<TriggerTarget>();
			}
			(TriggerTarget.set.Find((TriggerTarget x) => x.m_collider == other) ?? other.gameObject.AddComponent<TriggerTarget>()).AddProxy(this, other);
		}

		protected virtual void RemoveTarget(Collider other, bool remove)
		{
			TriggerTarget triggerTarget = TriggerTarget.set.Find((TriggerTarget x) => x.m_collider == other);
			if ((bool)triggerTarget && remove)
			{
				triggerTarget.RemoveProxy(this);
			}
		}

		public virtual void ResetTrigger()
		{
			m_colliders = new List<Collider>();
			EnteringGameObjects = new List<GameObject>();
			OnEmpty.Invoke();
		}

		protected void OnDisable()
		{
			if (m_colliders.Count > 0)
			{
				foreach (Collider collider in m_colliders)
				{
					if ((bool)collider)
					{
						OnTrigger_Exit.Invoke(collider);
						RemoveTarget(collider, remove: true);
					}
				}
			}
			if (EnteringGameObjects.Count > 0)
			{
				foreach (GameObject enteringGameObject in EnteringGameObjects)
				{
					if ((bool)enteringGameObject)
					{
						OnGameObjectExit.Invoke(enteringGameObject);
					}
				}
			}
			if (m_debug)
			{
				Debug.Log("<b>" + base.name + "</b> [Exit All Colliders and Triggers] ", this);
			}
			ResetTrigger();
		}

		protected void OnEnable()
		{
			ResetTrigger();
		}

		protected void Awake()
		{
			if (trigger == null)
			{
				trigger = GetComponent<Collider>();
			}
			if ((bool)trigger)
			{
				trigger.isTrigger = true;
			}
			else
			{
				Debug.LogWarning("This Script requires a Collider, please add any type of collider", this);
			}
			if (Owner == null)
			{
				Owner = base.transform;
			}
			ResetTrigger();
		}

		protected void Update()
		{
			CheckOntriggerStay();
		}

		protected virtual void CheckOntriggerStay()
		{
			if (!useOnTriggerStay.Value)
			{
				return;
			}
			foreach (GameObject enteringGameObject in EnteringGameObjects)
			{
				OnGameObjectStay.Invoke(enteringGameObject);
			}
			foreach (Collider collider in m_colliders)
			{
				OnTrigger_Stay.Invoke(collider);
			}
		}

		public virtual void SetLayer(LayerMask mask, QueryTriggerInteraction triggerInteraction, Transform Owner, Tag[] tags = null)
		{
			TriggerInteraction = triggerInteraction;
			Tags = tags;
			Layer = mask;
			this.Owner = Owner;
		}

		public static TriggerProxy CheckTriggerProxy(Collider trigger, LayerMask Layer, QueryTriggerInteraction TriggerInteraction, Transform Owner)
		{
			TriggerProxy component = null;
			if (trigger != null)
			{
				if (!trigger.TryGetComponent<TriggerProxy>(out component))
				{
					component = trigger.gameObject.AddComponent<TriggerProxy>();
					component.SetLayer(Layer, TriggerInteraction, Owner);
				}
				else
				{
					TriggerProxy triggerProxy = component;
					triggerProxy.Layer = (int)triggerProxy.Layer | (int)Layer;
				}
				if (TriggerInteraction != QueryTriggerInteraction.Ignore)
				{
					component.TriggerInteraction = TriggerInteraction;
				}
				trigger.gameObject.SetLayer(2, includeChildren: false);
				trigger.isTrigger = true;
				component.Active = true;
			}
			return component;
		}
	}
}
