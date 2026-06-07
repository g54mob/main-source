using System;
using DV.Customization.Gadgets;
using UnityEngine;

namespace DV.Customization
{
	public class CustomizationPlacementMeshes : MonoBehaviour
	{
		private const string ROOT = "[GadgetMeshColliders]";

		private const string DRILLING_DISABLERS = "[drilling disablers]";

		private static int _lastFramePlacing = int.MinValue;

		[Tooltip("Create mesh colliders from these")]
		public MeshFilter[] collisionMeshes;

		[Tooltip("Create mesh colliders from these, but don't allow drilling")]
		public MeshFilter[] drillDisableMeshes;

		[Header("Optional")]
		public bool generateFromTrainInteriorCols;

		public static bool ShouldBePlacing => Time.frameCount <= _lastFramePlacing + 1;

		public static event Action StartPlacingEvent;

		public static void EnsurePlacingMeshesAreActive()
		{
			bool num = !ShouldBePlacing;
			_lastFramePlacing = Time.frameCount;
			if (num)
			{
				CustomizationPlacementMeshes.StartPlacingEvent?.Invoke();
			}
		}

		public void TryGenerateInteriorCols(TrainCar car, Transform collidersRoot)
		{
			if (generateFromTrainInteriorCols)
			{
				GadgetColliderHolder gadgetColliderHolder = FindRoot(car);
				int layer = Layers.DVLayer.Gadget_Mesh_Placing.ToInt();
				Collider[] componentsInChildren = collidersRoot.GetComponentsInChildren<Collider>();
				foreach (Collider collider in componentsInChildren)
				{
					GameObject obj = UnityEngine.Object.Instantiate(collider.gameObject, gadgetColliderHolder.holderTransform);
					obj.name = "[GadgetCollider][" + collider.name + "]";
					obj.layer = layer;
				}
				Transform transform = collidersRoot.Find("[drilling disablers]");
				if ((bool)transform)
				{
					UnityEngine.Object.Destroy(transform.gameObject);
				}
			}
		}

		public void GenerateCustomizationMeshes(TrainCar car)
		{
			bool flag = GetComponentInParent<TrainCarInteriorObject>() != null;
			int layer = Layers.DVLayer.Gadget_Mesh_Placing.ToInt();
			GadgetColliderHolder root = FindRoot(car);
			if (!flag || !root.interiorProcessed)
			{
				if (flag)
				{
					root.interiorProcessed = true;
				}
				MeshFilter[] array = collisionMeshes;
				foreach (MeshFilter mf in array)
				{
					Create(mf);
				}
				array = drillDisableMeshes;
				foreach (MeshFilter mf2 in array)
				{
					Create(mf2).AddComponent<DrillingDisabler>();
				}
			}
			GameObject Create(MeshFilter meshFilter)
			{
				GameObject obj = new GameObject("[GadgetMeshCollider][" + meshFilter.name + "]");
				obj.transform.SetParent(root.holderTransform, worldPositionStays: false);
				Vector3 position = base.transform.InverseTransformPoint(meshFilter.transform.position);
				Quaternion quaternion = Quaternion.Inverse(base.transform.rotation) * meshFilter.transform.rotation;
				obj.transform.position = root.holderTransform.TransformPoint(position);
				obj.transform.rotation = root.holderTransform.rotation * quaternion;
				obj.layer = layer;
				MeshCollider meshCollider = obj.AddComponent<MeshCollider>();
				meshCollider.sharedMesh = meshFilter.sharedMesh;
				if (meshFilter.gameObject.TryGetComponent<LocoWindowMesh>(out var _))
				{
					meshCollider.gameObject.AddComponent<LocoWindowMesh>();
				}
				return obj;
			}
		}

		private GadgetColliderHolder FindRoot(TrainCar car)
		{
			Transform transform = car.interior.Find("[GadgetMeshColliders]");
			if (transform == null)
			{
				transform = new GameObject("[GadgetMeshColliders]").transform;
				transform.SetParent(car.interior, worldPositionStays: false);
				return transform.gameObject.AddComponent<GadgetColliderHolder>();
			}
			return transform.GetComponent<GadgetColliderHolder>();
		}
	}
}
