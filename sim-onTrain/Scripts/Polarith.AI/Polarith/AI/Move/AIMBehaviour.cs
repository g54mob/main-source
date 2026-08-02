using System;
using System.Collections.Generic;
using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[RequireComponent(typeof(AIMContext))]
	public abstract class AIMBehaviour : MonoBehaviour, IEvaluationPreparer
	{
		[Tooltip("Specifies the execution order of this behaviour. If changed at runtime, the internal hold behaviour collections need to be re-sorted.")]
		public int Order;

		[Tooltip("Name to identify this component, e.g. within a state machine.")]
		public string Label;

		protected AIMContext aimContext;

		protected Context context;

		[SerializeField]
		[HideInInspector]
		private bool initialized;

		[SerializeField]
		[HideInInspector]
		private TabState tabState;

		[SerializeField]
		[HideInInspector]
		private bool advancedInspector;

		public abstract MoveBehaviour Behaviour { get; }

		public virtual bool ThreadSafe => false;

		public bool Enabled
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

		public virtual void PrepareEvaluation()
		{
			if (Order != Behaviour.Order)
			{
				Behaviour.Order = Order;
				UnregisterBehaviour();
				RegisterBehaviour();
			}
		}

		protected virtual void Reset()
		{
			Behaviour.Order = Order;
			initialized = true;
			aimContext = GetComponent<AIMContext>();
			context = aimContext.Context;
		}

		protected virtual void Awake()
		{
			aimContext = GetComponent<AIMContext>();
			aimContext.EvaluationPreparers.Add(this);
			context = aimContext.Context;
			Behaviour.Context = context;
			Behaviour.Order = Order;
			RegisterBehaviour();
			if (!initialized)
			{
				Reset();
			}
			base.gameObject.GetComponents<AIMSeek>();
		}

		protected virtual void OnEnable()
		{
			Behaviour.Enabled = true;
		}

		protected virtual void OnDisable()
		{
			Behaviour.Enabled = false;
		}

		protected virtual void OnDestroy()
		{
			aimContext.EvaluationPreparers.Remove(this);
			UnregisterBehaviour();
		}

		protected virtual void OnValidate()
		{
			if (!Application.isPlaying)
			{
				aimContext = GetComponent<AIMContext>();
			}
		}

		protected List<int> GetDefaultTargetObjectives()
		{
			List<int> list = new List<int>();
			AIMContext component = GetComponent<AIMContext>();
			if (component != null)
			{
				if (component.Context.Problem.ObjectiveCount == 0)
				{
					component.BuildContext();
				}
				for (int i = 0; i < component.Context.Problem.ObjectiveCount; i++)
				{
					list.Add(i);
				}
			}
			return list;
		}

		protected void CheckFirstAndCentralOrder(Type type)
		{
			if (Order >= 2000)
			{
				Order = 1999;
				Debug.Log("(" + type.Name + ") " + base.gameObject.name + ": 'Order' needs to be lesser than " + 2000);
			}
		}

		protected void CheckLastOrder(Type type)
		{
			if (Order < 2000)
			{
				Order = 2000;
				Debug.Log("(" + type.Name + ") " + base.gameObject.name + ": 'Order' needs to be greater than or equal to " + 2000);
			}
		}

		private void RegisterBehaviour()
		{
			aimContext.Behaviours.Add(this);
			aimContext.BehaviourSortRequired = true;
			aimContext.ThreadSafetyCheckRequired = true;
			context.Behaviours.Add(Behaviour);
		}

		private void UnregisterBehaviour()
		{
			aimContext.Behaviours.Remove(this);
			aimContext.ThreadSafetyCheckRequired = true;
			context.Behaviours.Remove(Behaviour);
		}
	}
}
