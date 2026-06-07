using System;
using DV.CabControls;
using UnityEngine;

namespace DV.Items
{
	public class ItemSimulationSpace : MonoBehaviour
	{
		private ItemBase item;

		private ItemReparentingBase itemReparentingBase;

		private Transform parent;

		public Transform SimulationSpace { get; private set; }

		public event Action<Transform, Transform> SimulationSpaceChanged;

		private void Start()
		{
			item = GetComponent<ItemBase>();
			itemReparentingBase = GetComponent<ItemReparentingBase>();
			itemReparentingBase.ItemParented += delegate(Transform parent)
			{
				this.parent = parent;
				Refresh();
			};
			item.Grabbed += delegate
			{
				Refresh();
			};
			item.Ungrabbed += delegate
			{
				Refresh();
			};
			item.ItemInventoryStateChanged += delegate
			{
				Refresh();
			};
			Refresh();
		}

		private void OnCarChanged(TrainCar _)
		{
			Refresh();
		}

		private void Refresh()
		{
			bool num = item.IsGrabbed() || item.IsInBelt();
			PlayerManager.CarChanged -= OnCarChanged;
			if (num)
			{
				PlayerManager.CarChanged += OnCarChanged;
			}
			Transform transform = ((!num) ? parent : ((PlayerManager.Car != null && PlayerManager.Car.interior != null) ? PlayerManager.Car.interior : null));
			if (SimulationSpace != transform)
			{
				this.SimulationSpaceChanged?.Invoke(SimulationSpace, transform);
				SimulationSpace = transform;
			}
		}

		private void OnDestroy()
		{
			PlayerManager.CarChanged -= OnCarChanged;
		}

		public Vector3 InverseTransformPoint(Vector3 point)
		{
			if (!SimulationSpace)
			{
				return point;
			}
			return SimulationSpace.InverseTransformPoint(point);
		}

		public Vector3 InverseTransformDirection(Vector3 point)
		{
			if (!SimulationSpace)
			{
				return point;
			}
			return SimulationSpace.InverseTransformDirection(point);
		}

		public Quaternion InverseTransformRotation(Quaternion rot)
		{
			if (!SimulationSpace)
			{
				return rot;
			}
			return Quaternion.Inverse(SimulationSpace.rotation) * rot;
		}

		public Vector3 TransformPoint(Vector3 point)
		{
			if (!SimulationSpace)
			{
				return point;
			}
			return SimulationSpace.TransformPoint(point);
		}

		public Vector3 TransformDirection(Vector3 point)
		{
			if (!SimulationSpace)
			{
				return point;
			}
			return SimulationSpace.TransformDirection(point);
		}

		public Quaternion TransformRotation(Quaternion rot)
		{
			if (!SimulationSpace)
			{
				return rot;
			}
			return SimulationSpace.rotation * rot;
		}
	}
}
