using System;
using UnityEngine;

namespace Lean.Common
{
	public abstract class LeanSelectableBehaviour : MonoBehaviour
	{
		[NonSerialized]
		private LeanSelectable selectable;

		public LeanSelectable Selectable => null;

		[ContextMenu("Register")]
		public void Register()
		{
		}

		public void Register(LeanSelectable newSelectable)
		{
		}

		[ContextMenu("Unregister")]
		public void Unregister()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void OnSelected(LeanSelect select)
		{
		}

		protected virtual void OnDeselected(LeanSelect select)
		{
		}
	}
}
