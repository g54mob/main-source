using System.Collections.Generic;
using Dreamteck.Splines;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Splines
{
	[RequireComponent(typeof(SplineMesh))]
	public class SplineMeshBuilderScript : MonoBehaviour
	{
		private const string DefaultGeneratedAssetsPath = "Assets/Content/Flight/WorldObjects/";

		[SerializeField]
		private SplineMeshBuilderConfig _config;

		public SplineMeshBuilderConfig Config => _config;

		public static SplineMeshBuilderScript Create(Transform parent, SplineComputer spline, string generatedAssetsRootPath = null)
		{
			GameObject obj = new GameObject("MeshBuilder");
			SplineMeshBuilderScript splineMeshBuilderScript = obj.AddComponent<SplineMeshBuilderScript>();
			splineMeshBuilderScript._config = new SplineMeshBuilderConfig
			{
				SegmentRootTransform = parent,
				SaveGeneratedAssets = true,
				GeneratedAssetsRootPath = (generatedAssetsRootPath ?? "Assets/Content/Flight/WorldObjects/"),
				MeshData = SplineMeshBuilderMeshDataFlags.UV0,
				SplineMesh = splineMeshBuilderScript.GetComponent<SplineMesh>(),
				Passes = new List<SplineMeshBuilderPass>
				{
					CreateEmptyPass(SplineMeshBuilderPassType.Lod0),
					CreateEmptyPass(SplineMeshBuilderPassType.Lod1),
					CreateEmptyPass(SplineMeshBuilderPassType.Lod2),
					CreateEmptyPass(SplineMeshBuilderPassType.Collider)
				}
			};
			splineMeshBuilderScript._config.SplineMesh.spline = spline;
			ComponentUtility.SetComponentIndex(splineMeshBuilderScript, 1);
			ComponentUtility.SetComponentIndex(splineMeshBuilderScript._config.SplineMesh, 2);
			obj.transform.SetParent(parent, worldPositionStays: false);
			return splineMeshBuilderScript;
		}

		protected virtual void Awake()
		{
			if (Application.isPlaying)
			{
				base.gameObject.SetActive(value: false);
			}
			Object.Destroy(base.gameObject);
		}

		private static SplineMeshBuilderPass CreateEmptyPass(SplineMeshBuilderPassType type)
		{
			return new SplineMeshBuilderPass
			{
				Type = type,
				Channels = new List<SplineMeshBuilderChannel>
				{
					new SplineMeshBuilderChannel
					{
						Scale = Vector3.one,
						Meshes = new List<SplineMeshBuilderMesh>
						{
							new SplineMeshBuilderMesh
							{
								Scale = Vector3.one
							}
						}
					}
				}
			};
		}
	}
}
