using System;
using UnityEngine;

namespace FullInspector.Internal
{
	[Serializable]
	public class fiUnityObjectReference
	{
		[SerializeField]
		private UnityEngine.Object _target;

		public UnityEngine.Object Target;

		public bool IsValid => Target != null;

		public fiUnityObjectReference()
		{
		}

		public fiUnityObjectReference(UnityEngine.Object target, bool tryRestore)
		{
			Target = target;
			if (tryRestore)
			{
				TryRestoreFromInstanceId();
			}
		}

		private void TryRestoreFromInstanceId()
		{
			if (_target == null && (object)_target != null)
			{
				int instanceID = _target.GetInstanceID();
				_target = fiLateBindings.EditorUtility.InstanceIDToObject(instanceID);
			}
		}

		public override int GetHashCode()
		{
			if (!IsValid)
			{
				return 0;
			}
			return Target.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is fiUnityObjectReference fiUnityObjectReference2)
			{
				return fiUnityObjectReference2.Target == Target;
			}
			return false;
		}
	}
}
