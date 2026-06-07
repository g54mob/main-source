using System;
using Lean.Common;
using UnityEngine;

namespace Lean.Touch
{
	public abstract class LeanSelectableByFingerBehaviour : MonoBehaviour
	{
		[NonSerialized]
		private LeanSelectableByFinger selectable;

		public LeanSelectableByFinger Selectable => null;

		[ContextMenu("Register")]
		public void Register()
		{
		}

		public void Register(LeanSelectableByFinger newSelectable)
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

		protected virtual void OnSelectedSelectFinger(LeanSelectByFinger select, LeanFinger finger)
		{
		}

		protected virtual void OnSelectedSelectFingerUp(LeanSelectByFinger select, LeanFinger finger)
		{
		}

		protected virtual void OnDeselected(LeanSelect select)
		{
		}
	}
}
