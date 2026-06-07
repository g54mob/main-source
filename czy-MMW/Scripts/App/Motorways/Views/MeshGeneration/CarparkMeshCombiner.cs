using System.Collections.Generic;
using Motorways.Models;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views.MeshGeneration
{
	public class CarparkMeshCombiner
	{
		private readonly CarparkMeshCombineInfo _meshInfo;

		public readonly GameObject combinedCarparkPrefab;

		public Mesh HorizontalSingleCarparkLeftEntrance { get; }

		public Mesh HorizontalSingleCarparkRightEntrance { get; }

		public Mesh HorizontalDoubleCarpark { get; }

		public Mesh ReversedHorizontalDoubleCarpark { get; }

		public Mesh BoatTerminalCarpark { get; }

		public CarparkMeshCombiner(GameObject carparkPrefab)
		{
			_meshInfo = carparkPrefab.GetComponentInChildren<CarparkMeshCombineInfo>();
			HorizontalSingleCarparkLeftEntrance = GenerateCarparkMesh(supportsTwoDestinations: false, CarparkEntrance.TopLeft, reversed: false);
			HorizontalSingleCarparkRightEntrance = GenerateCarparkMesh(supportsTwoDestinations: false, CarparkEntrance.BottomRight, reversed: false);
			HorizontalDoubleCarpark = GenerateCarparkMesh(supportsTwoDestinations: true, CarparkEntrance.TopLeftAndBottomRight, reversed: false);
			ReversedHorizontalDoubleCarpark = GenerateCarparkMesh(supportsTwoDestinations: true, CarparkEntrance.TopLeftAndBottomRight, reversed: true);
			BoatTerminalCarpark = GenerateCarparkMesh(supportsTwoDestinations: true, CarparkEntrance.TopLeftAndBottomRight, reversed: false, supportsBoats: true);
			combinedCarparkPrefab = Object.Instantiate(carparkPrefab);
			combinedCarparkPrefab.gameObject.SetActive(value: false);
			combinedCarparkPrefab.name = carparkPrefab.name;
			combinedCarparkPrefab.hideFlags = HideFlags.HideAndDontSave;
			combinedCarparkPrefab.GetComponentInChildren<CarparkMeshCombineInfo>().Remove();
		}

		private Mesh GenerateCarparkMesh(bool supportsTwoDestinations, CarparkEntrance carparkEntrance, bool reversed, bool supportsBoats = false)
		{
			Mesh mesh = new Mesh
			{
				name = "Combined Carpark Mesh"
			};
			List<CarparkMesh> list = new List<CarparkMesh>();
			CarparkMesh carparkMesh;
			CarparkMesh carparkMesh2;
			CarparkMesh carparkMesh3;
			CarparkMesh carparkMesh4;
			CarparkMesh[] array;
			if (supportsTwoDestinations)
			{
				if (reversed)
				{
					carparkMesh = _meshInfo.reversedDoubleCarparkTopLeftOpen;
					carparkMesh2 = _meshInfo.reversedDoubleCarparkTopLeftClosed;
					carparkMesh3 = _meshInfo.reversedDoubleCarparkBottomRightOpen;
					carparkMesh4 = _meshInfo.reversedDoubleCarparkBottomRightClosed;
					array = _meshInfo.reversedDoubleCarparkTiles;
				}
				else
				{
					carparkMesh = _meshInfo.doubleCarparkTopLeftOpen;
					carparkMesh2 = _meshInfo.doubleCarparkTopLeftClosed;
					carparkMesh3 = _meshInfo.doubleCarparkBottomRightOpen;
					carparkMesh4 = _meshInfo.doubleCarparkBottomRightClosed;
					array = _meshInfo.doubleCarparkTiles;
				}
			}
			else
			{
				carparkMesh = _meshInfo.singleCarparkTopLeftOpen;
				carparkMesh2 = _meshInfo.singleCarparkTopLeftClosed;
				carparkMesh3 = _meshInfo.singleCarparkBottomRightOpen;
				carparkMesh4 = _meshInfo.singleCarparkBottomRightClosed;
				array = _meshInfo.singleCarparkMeshes;
			}
			if (supportsBoats)
			{
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == _meshInfo.doubleCarparkTopLeftCorner)
					{
						array[i] = _meshInfo.boatTopLeftCorner;
					}
					else if (array[i] == _meshInfo.doubleCarparkTopRightCorner)
					{
						array[i] = _meshInfo.boatTopRightCorner;
					}
				}
				list.Add(_meshInfo.boatTopLeftEntrance);
				list.Add(_meshInfo.boatTopRightEntrance);
			}
			else
			{
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j] == _meshInfo.boatTopLeftCorner)
					{
						array[j] = _meshInfo.doubleCarparkTopLeftCorner;
					}
					else if (array[j] == _meshInfo.boatTopRightCorner)
					{
						array[j] = _meshInfo.doubleCarparkTopRightCorner;
					}
				}
			}
			list.Add(carparkEntrance.HasFlag(CarparkEntrance.TopLeft) ? carparkMesh : carparkMesh2);
			list.Add(carparkEntrance.HasFlag(CarparkEntrance.BottomRight) ? carparkMesh3 : carparkMesh4);
			list.AddRange(array);
			List<CombineInstance> list2 = new List<CombineInstance>();
			foreach (CarparkMesh item in list)
			{
				foreach (CarparkMesh.ThemedMesh mesh2 in item.meshes)
				{
					CombineMesh(mesh2.meshRenderer, mesh2.themedMaterialType, list2);
				}
			}
			mesh.CombineMeshes(list2.ToArray());
			return mesh;
		}

		private void CombineMesh(MeshRenderer meshRenderer, ThemedMaterialType themedMaterialType, List<CombineInstance> combineInstances)
		{
			MeshFilter component = meshRenderer.GetComponent<MeshFilter>();
			Mesh mesh = Object.Instantiate(component.sharedMesh);
			CombinedMeshThemeComponent.SetAbsoluteVertexColorIndexForMesh(mesh, themedMaterialType);
			CombineInstance item = new CombineInstance
			{
				mesh = mesh,
				transform = component.transform.localToWorldMatrix
			};
			combineInstances.Add(item);
		}
	}
}
