using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro.PrefabModule
{
	[DefaultExecutionOrder(-200)]
	public class GPUIRigidbodySimulator : GPUIColliderHelper<GPUIRigidbodyReplacer>
	{
		private static List<GPUIRigidbodySimulator> _Instances;

		protected override void OnEnable()
		{
			base.OnEnable();
			if (_Instances == null)
			{
				_Instances = new List<GPUIRigidbodySimulator>();
			}
			if (!_Instances.Contains(this))
			{
				_Instances.Add(this);
			}
		}

		public static void InitializeInstance(GPUIRigidbodyReplacer instance)
		{
			if (_Instances == null)
			{
				return;
			}
			foreach (GPUIRigidbodySimulator instance2 in _Instances)
			{
				Rigidbody component;
				if (instance2.IsInsideCollider(instance))
				{
					instance2._enteredInstances.Add(instance);
					instance2.OnEnteredCollider(instance);
				}
				else if (instance.TryGetComponent<Rigidbody>(out component))
				{
					instance.ReplaceRigidbody(component);
				}
			}
		}

		protected override void OnEnteredCollider(GPUIRigidbodyReplacer instance)
		{
			instance.AddRigidbody();
			instance.gpuiPrefab.UpdateTransformData();
		}

		protected override bool OnExitedCollider(GPUIRigidbodyReplacer instance)
		{
			if (instance.TryGetComponent<Rigidbody>(out var component))
			{
				if (!component.IsSleeping())
				{
					return false;
				}
				instance.ReplaceRigidbody(component);
			}
			instance.gpuiPrefab.UpdateTransformData();
			return true;
		}

		protected override void OnUpdate(GPUIRigidbodyReplacer instance)
		{
			instance.gpuiPrefab.UpdateTransformData();
		}
	}
}
