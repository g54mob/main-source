using System.Collections.Generic;
using ModApi.Flight;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	public class SubStructureRigidBodyScript : MonoBehaviour
	{
		private Vector3 _com;

		private float _totalMass;

		public void Initialize(SubStructure subStructure)
		{
			List<SubStructure> list = new List<SubStructure>();
			GetChildrenWithMass(subStructure, list);
			Vector3 zero = Vector3.zero;
			float num = 0f;
			foreach (SubStructure item in list)
			{
				float num2 = (float)item.Mass * 0.01f;
				num += num2;
				zero += num2 * item.LoadedGameObject.transform.position;
			}
			_totalMass = num;
			_com = base.transform.InverseTransformPoint(zero / num);
		}

		protected virtual void OnDestroy()
		{
			if (FlightSceneScript.Instance?.TimeManager != null)
			{
				FlightSceneScript.Instance.TimeManager.TimeMultiplierModeChanged -= OnTimeMultiplierModeChanged;
			}
		}

		protected virtual void Start()
		{
			MeshCollider[] componentsInChildren = GetComponentsInChildren<MeshCollider>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].convex = true;
			}
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.mass = _totalMass;
			rigidbody.centerOfMass = _com;
			rigidbody.useGravity = true;
			rigidbody.drag = 0.1f;
			rigidbody.angularDrag = 0.1f;
			rigidbody.maxDepenetrationVelocity = 1f;
			FlightSceneScript.Instance.TimeManager.TimeMultiplierModeChanged += OnTimeMultiplierModeChanged;
		}

		private static void GetChildrenWithMass(SubStructure subStructure, List<SubStructure> results)
		{
			if (subStructure.Mass > 0.0 && subStructure.LoadedGameObject != null)
			{
				results.Add(subStructure);
			}
			foreach (SubStructure subStructure2 in subStructure.SubStructures)
			{
				GetChildrenWithMass(subStructure2, results);
			}
		}

		private void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			Rigidbody component = GetComponent<Rigidbody>();
			if (component != null)
			{
				component.isKinematic = e.CurrentMode.WarpMode;
			}
		}
	}
}
