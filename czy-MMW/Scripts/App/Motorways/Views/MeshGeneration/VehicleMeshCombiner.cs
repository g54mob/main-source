using Motorways.Constants;
using UnityEngine;

namespace Motorways.Views.MeshGeneration
{
	public class VehicleMeshCombiner
	{
		private const string CombinedVehicleMeshName = "Combined Vehicle Mesh";

		public readonly GameObject combinedMeshVehiclePrefab;

		public VehicleMeshCombiner(GameObject vehiclePrefab)
		{
			combinedMeshVehiclePrefab = Object.Instantiate(vehiclePrefab);
			combinedMeshVehiclePrefab.SetActive(value: false);
			combinedMeshVehiclePrefab.hideFlags = HideFlags.HideAndDontSave;
			GameObject gameObject = new GameObject("Combined Vehicle Mesh");
			gameObject.transform.parent = combinedMeshVehiclePrefab.transform;
			VehicleMesh[] componentsInChildren = combinedMeshVehiclePrefab.GetComponentsInChildren<VehicleMesh>();
			Mesh sharedMesh = CombineVehicleMesh(componentsInChildren);
			MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
			meshFilter.sharedMesh = sharedMesh;
			meshFilter.gameObject.layer = LayerConstants.HeadlightOcclusionLayerId;
			VehicleView componentInChildren = combinedMeshVehiclePrefab.GetComponentInChildren<VehicleView>();
			Material vehicleMaterial = componentInChildren.vehicleMaterial;
			VehicleMesh[] array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(value: false);
			}
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			meshRenderer.material = vehicleMaterial;
			componentInChildren.CombinedMeshVehicleRenderer = meshRenderer;
		}

		private Mesh CombineVehicleMesh(VehicleMesh[] vehicleMeshes)
		{
			CombineInstance[] combineInstances = new CombineInstance[vehicleMeshes.Length];
			for (int i = 0; i < combineInstances.Length; i++)
			{
				Combine(i, vehicleMeshes[i], in combineInstances);
			}
			Mesh mesh = new Mesh();
			mesh.name = "Combined Vehicle Mesh";
			mesh.CombineMeshes(combineInstances);
			return mesh;
		}

		private void Combine(int index, VehicleMesh vehicleMesh, in CombineInstance[] combineInstances)
		{
			MeshFilter component = vehicleMesh.GetComponent<MeshFilter>();
			Mesh mesh = Object.Instantiate(component.sharedMesh);
			CombinedMeshThemeComponent.SetRelativeVertexColorIndexForMesh(mesh, vehicleMesh.groupTarget);
			combineInstances[index].mesh = mesh;
			combineInstances[index].transform = component.transform.localToWorldMatrix;
		}
	}
}
