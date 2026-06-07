using System;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Car
{
	public class ConnectingAssemblyScript : MonoBehaviour
	{
		[Serializable]
		public class ConnectingComponent
		{
			[field: SerializeField]
			public float Length { get; set; }

			[field: SerializeField]
			public float Overhang { get; set; }

			[field: SerializeField]
			public float Pivot { get; set; }

			[field: SerializeField]
			public Transform Transform { get; set; }
		}

		[SerializeField]
		private ConnectingComponent _componentEnd;

		[SerializeField]
		private ConnectingComponent _componentStart;

		[SerializeField]
		private ConnectingComponent _componentStretch;

		[SerializeField]
		private Transform _pointEnd;

		[SerializeField]
		private Transform _pointStart;

		public ConnectingComponent ComponentStart => _componentStart;

		public void UpdateComponents()
		{
			if (_pointStart == null || _pointEnd == null)
			{
				return;
			}
			Vector3 position = _pointStart.position;
			Vector3 position2 = _pointEnd.position;
			if (_pointStart != base.transform)
			{
				base.transform.position = position;
			}
			Vector3 forward = position2 - position;
			if (forward.sqrMagnitude < 0.0001f)
			{
				return;
			}
			float num = forward.magnitude / base.transform.lossyScale.x;
			float num2 = num;
			if (_componentEnd != null)
			{
				_componentEnd.Transform.localPosition = new Vector3(0f, 0f, num - _componentEnd.Length * _componentEnd.Pivot + _componentEnd.Overhang);
				num2 -= _componentEnd.Length - _componentEnd.Overhang;
			}
			if (_componentStart != null)
			{
				if (_componentStart.Transform != null)
				{
					_componentStart.Transform.localPosition = new Vector3(0f, 0f, _componentStart.Length * _componentStart.Pivot - _componentStart.Overhang);
				}
				num2 -= _componentStart.Length - _componentStart.Overhang;
			}
			if (_componentStretch.Length <= 0f)
			{
				MeshRenderer component = _componentStretch.Transform.GetComponent<MeshRenderer>();
				_componentStretch.Length = component.localBounds.size.z;
			}
			base.transform.rotation = Quaternion.LookRotation(forward, base.transform.up);
			_componentStretch.Transform.localScale = new Vector3(1f, 1f, num2 / _componentStretch.Length);
			_componentStretch.Transform.localPosition = new Vector3(0f, 0f, (_componentStart?.Length ?? 0f) + num2 * _componentStretch.Pivot);
		}

		[ContextMenu("Display Component Lengths")]
		private void DisplayMeshLengths()
		{
			Transform[] array = new Transform[3] { _componentStart.Transform, _componentStretch.Transform, _componentEnd.Transform };
			foreach (Transform transform in array)
			{
				if (transform != null)
				{
					float z = transform.GetComponent<MeshRenderer>().localBounds.size.z;
					Debug.Log($"{transform.gameObject.name} length: {z}");
				}
			}
		}
	}
}
