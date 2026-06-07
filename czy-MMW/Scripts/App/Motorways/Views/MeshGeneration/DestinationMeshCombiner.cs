using System;
using System.Collections.Generic;
using UnityEngine;

namespace Motorways.Views.MeshGeneration
{
	public class DestinationMeshCombiner
	{
		private static readonly TileDirection[] DoorDirectionsForStations = new TileDirection[4]
		{
			TileDirection.North,
			TileDirection.South,
			TileDirection.East,
			TileDirection.West
		};

		private static readonly TileDirection[] DoorDirections = new TileDirection[2]
		{
			TileDirection.South,
			TileDirection.West
		};

		private readonly Dictionary<(DestinationMesh.Type, TileDirection, int groupIndex, int visualVariantIndex), Mesh> _meshForDirection = new Dictionary<(DestinationMesh.Type, TileDirection, int, int), Mesh>();

		public Mesh GetCombinedMesh(DestinationMesh.Type type, TileDirection direction, int groupIndex, int visualVariantIndex)
		{
			Diagnostics.Verify(_meshForDirection.ContainsKey((type, direction, groupIndex, visualVariantIndex)), $"Couldn't get cached destination mesh for parameters: ({type}, {direction}, {groupIndex}, {visualVariantIndex}). Total meshes in cache: {_meshForDirection.Count}");
			return _meshForDirection[(type, direction, groupIndex, visualVariantIndex)];
		}

		public DestinationMeshCombiner(GameObject destinationPrefab)
		{
			List<DestinationVisualVariant> list = new List<DestinationVisualVariant>();
			for (int i = 0; i < destinationPrefab.transform.childCount; i++)
			{
				DestinationVisualVariant component = destinationPrefab.transform.GetChild(i).GetComponent<DestinationVisualVariant>();
				if (component != null)
				{
					list.Add(component);
				}
				else
				{
					Debug.LogError("No DestinationVisualVariant component found in a top level child (" + destinationPrefab.transform.GetChild(i).name + ") on Destination prefab. Please add a DestinationVisualVariant component to each child of the Destination prefab.");
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				DestinationMesh[] componentsInChildren = list[j].gameObject.GetComponentsInChildren<DestinationMesh>(includeInactive: true);
				Array.Sort(componentsInChildren, delegate(DestinationMesh meshA, DestinationMesh meshB)
				{
					float z = meshA.transform.position.z;
					float z2 = meshB.transform.position.z;
					if (z > z2)
					{
						return -1;
					}
					return (z < z2) ? 1 : 0;
				});
				foreach (DestinationMesh.Type value in Enum.GetValues(typeof(DestinationMesh.Type)))
				{
					CreateMergedMesh(value, componentsInChildren, j);
				}
				DestinationMesh[] array = componentsInChildren;
				for (int num = 0; num < array.Length; num++)
				{
					array[num].gameObject.SetActive(value: false);
				}
			}
		}

		private void CreateMergedMesh(DestinationMesh.Type type, DestinationMesh[] destinationMeshes, int visualVariantIndex)
		{
			Mesh baseMesh = CreateBaseDestinationMesh(type, destinationMeshes);
			TileDirection[] array = DoorDirections;
			if (type == DestinationMesh.Type.StationHorizontal || type == DestinationMesh.Type.StationVertical)
			{
				array = DoorDirectionsForStations;
			}
			TileDirection[] array2 = array;
			foreach (TileDirection direction in array2)
			{
				CreateDestinationMeshesForDirection(type, destinationMeshes, baseMesh, direction, visualVariantIndex);
			}
		}

		private Mesh CreateBaseDestinationMesh(DestinationMesh.Type type, DestinationMesh[] destinationMeshes)
		{
			Mesh mesh = new Mesh();
			List<CombineInstance> combineInstances = new List<CombineInstance>();
			foreach (DestinationMesh destinationMesh in destinationMeshes)
			{
				if (destinationMesh.type == type && destinationMesh.direction == TileDirection.None)
				{
					CombineMesh(destinationMesh, in combineInstances);
				}
			}
			mesh.CombineMeshes(combineInstances.ToArray());
			return mesh;
		}

		private void CreateDestinationMeshesForDirection(DestinationMesh.Type type, DestinationMesh[] destinationMeshes, Mesh baseMesh, TileDirection direction, int visualVariantIndex)
		{
			List<CombineInstance> combineInstances = new List<CombineInstance>
			{
				new CombineInstance
				{
					mesh = baseMesh,
					transform = Matrix4x4.identity
				}
			};
			foreach (DestinationMesh destinationMesh in destinationMeshes)
			{
				if (destinationMesh.type == type && destinationMesh.direction == direction)
				{
					CombineMesh(destinationMesh, in combineInstances);
				}
			}
			Mesh mesh = new Mesh
			{
				name = $"Destination ({type.ToString()}, {direction.ToString()} Door)"
			};
			mesh.CombineMeshes(combineInstances.ToArray());
			List<Color> list = new List<Color>();
			mesh.GetColors(list);
			for (int j = 0; j < MotorwaysThemeDatabase.MAX_THEME_COLOR_GROUPS; j++)
			{
				Mesh mesh2 = UnityEngine.Object.Instantiate(mesh);
				Color[] array = new Color[mesh.vertexCount];
				int num = CombinedMeshThemeComponent.RelativeThemeComponentGroupTargetOffsetForGroup(j);
				for (int k = 0; k < array.Length; k++)
				{
					float r = list[k].r;
					array[k] = new Color((float)num + r, list[k].g, list[k].b, list[k].a);
				}
				mesh2.SetColors(array);
				_meshForDirection[(type, direction, j, visualVariantIndex)] = mesh2;
			}
		}

		private void CombineMesh(DestinationMesh destinationMesh, in List<CombineInstance> combineInstances)
		{
			MeshFilter component = destinationMesh.GetComponent<MeshFilter>();
			Mesh mesh = UnityEngine.Object.Instantiate(component.sharedMesh);
			CombinedMeshThemeComponent.SetRelativeVertexColorIndexForMesh(mesh, destinationMesh.groupTarget);
			CombineInstance item = new CombineInstance
			{
				mesh = mesh,
				transform = component.transform.localToWorldMatrix
			};
			combineInstances.Add(item);
		}
	}
}
