using System.Collections.Generic;
using UnityEngine;

namespace Polarith.AI.Move
{
	[RequireComponent(typeof(AIMContext))]
	[DisallowMultipleComponent]
	public abstract class AIMFilter<T> : MonoBehaviour, IEvaluationPreparer where T : IPercept<GameObject>, new()
	{
		public readonly T Self = new T();

		protected AIMContext aimContext;

		[SerializeField]
		[HideInInspector]
		private bool environmentFoldout;

		public abstract AIMPerceiver<T> Perceiver { get; }

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

		public abstract void GetPercepts(IList<string> environments, IList<T> percepts);

		public virtual void PrepareEvaluation()
		{
			Self.Receive(aimContext.SelfObject);
		}

		protected virtual void Awake()
		{
			aimContext = GetComponent<AIMContext>();
			aimContext.EvaluationPreparers.Insert(0, this);
		}

		protected virtual void OnDestroy()
		{
			aimContext.EvaluationPreparers.Remove(this);
		}
	}
}
