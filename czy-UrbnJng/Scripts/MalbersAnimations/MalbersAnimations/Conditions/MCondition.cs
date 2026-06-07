using System;
using UnityEngine;

namespace MalbersAnimations.Conditions
{
	[Serializable]
	public abstract class MCondition : MonoBehaviour
	{
		[HideInInspector]
		[Tooltip("Name-Description of the Condition")]
		public string Name = "Condition";

		[HideInInspector]
		[Tooltip("Inverts the result of the condition")]
		public bool invert;

		[HideInInspector]
		[Tooltip("Or = true . And = False")]
		public bool OrAnd;

		[Tooltip("The Target will be updated when calling Set Target")]
		public bool UpdateTarget = true;

		public abstract string DisplayName { get; }

		public abstract bool _Evaluate();

		protected abstract void _SetTarget(UnityEngine.Object target);

		public virtual void SetTarget(UnityEngine.Object target)
		{
			if (UpdateTarget)
			{
				_SetTarget(target);
			}
		}

		public void VerifyTarget<T>(UnityEngine.Object obj, ref T component) where T : UnityEngine.Object
		{
			if (component == obj)
			{
				return;
			}
			if (obj == null)
			{
				component = null;
				return;
			}
			Type typeFromHandle = typeof(T);
			if (typeFromHandle.IsAssignableFrom(obj.GetType()))
			{
				component = obj as T;
			}
			else if (obj is GameObject)
			{
				component = (obj as GameObject).GetComponent(typeFromHandle) as T;
				if (component == null)
				{
					component = (obj as GameObject).GetComponentInParent(typeFromHandle) as T;
				}
				if (component == null)
				{
					component = (obj as GameObject).GetComponentInChildren(typeFromHandle) as T;
				}
			}
			if (component == null && obj is Component)
			{
				component = (obj as Component).GetComponent(typeFromHandle) as T;
				if (component == null)
				{
					component = (obj as Component).GetComponentInParent(typeFromHandle) as T;
				}
				if (component == null)
				{
					component = (obj as Component).GetComponentInChildren(typeFromHandle) as T;
				}
			}
		}

		public bool Evaluate()
		{
			if (!invert)
			{
				return _Evaluate();
			}
			return !_Evaluate();
		}

		protected virtual void OnValidate()
		{
			base.hideFlags = HideFlags.HideInInspector;
		}
	}
}
