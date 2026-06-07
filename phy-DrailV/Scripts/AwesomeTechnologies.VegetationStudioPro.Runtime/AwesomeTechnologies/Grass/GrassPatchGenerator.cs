using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.Grass
{
	[HelpURL("http://www.awesometech.no/index.php/grass-patch-generator")]
	public class GrassPatchGenerator : MonoBehaviour
	{
		public GrassPatchLod GrassPatchLod;

		public int PlaneCount = 15;

		public float Size = 0.4f;

		public float MinScale = 0.8f;

		public float MaxScale = 1.2f;

		public float PlaneHeight = 0.4f;

		public float PlaneMaxHeight = 0.5f;

		public float PlaneWidth = 0.4f;

		public float PlaneMaxWidth = 0.5f;

		public int PlaneWidthSegments = 2;

		public int PlaneHeightSegments = 2;

		public int RandomSeed = 1;

		public float MaxBendDistance = 0.25f;

		public float CurveOffset = 0.25f;

		public Material GrassMaterial;

		public Texture2D GrassTexture;

		public Material CustomMaterial;

		public float MinBendHeight = 0.05f;

		public AnimationCurve WindBend = new AnimationCurve();

		public AnimationCurve AmbientOcclusion = new AnimationCurve();

		public bool BakePhase = true;

		public bool BakeBend = true;

		public bool BakeAo = true;

		public bool ShowVertexColors;

		public bool GenerateBackside;

		public Color ColorTint1 = Color.white;

		public Color ColorTint2 = Color.white;

		public float RandomDarkening = 0.31f;

		public float RootAmbient = 0.63f;

		public float TextureCutoff = 0.1f;

		private Material _vertexColorMaterial;

		public List<ProceduralGrassPlane> GrassPlaneList;

		private void Reset()
		{
			WindBend.AddKey(0f, 0f);
			WindBend.AddKey(1f, 1f);
			AmbientOcclusion.AddKey(0f, 0f);
			AmbientOcclusion.AddKey(1f, 1f);
			if (GrassTexture == null)
			{
				GrassTexture = Resources.Load("GrassTextures/GrassFrond01") as Texture2D;
				UpdateTexture();
			}
			GenerateGrassPatch();
		}

		public void UpdateTexture()
		{
			if (CustomMaterial == null)
			{
				Material material = new Material(Shader.Find("AwesomeTechnologies/Release/Grass/Grass"));
				material.SetTexture("_MainTex", GrassTexture);
				material.SetVector("_AG_ColorNoiseArea", new Vector4(0f, 30f, 0f, 1f));
				material.SetTexture("_AG_ColorNoiseTex", Resources.Load("PerlinSeamless") as Texture2D);
				material.SetColor("_Color", ColorTint1);
				material.SetColor("_ColorB", ColorTint2);
				material.SetFloat("_Cutoff", TextureCutoff);
				material.SetFloat("_RandomDarkening", RandomDarkening);
				material.SetFloat("_RootAmbient", RootAmbient);
				material.enableInstancing = true;
				material.EnableKeyword("_ALPHATEST_ON");
				GrassMaterial = material;
			}
			else
			{
				Material material2 = new Material(CustomMaterial);
				material2.SetTexture("_MainTex", GrassTexture);
				GrassMaterial = material2;
			}
			GenerateGrassPatch();
		}

		private void ClearGrassPlanes()
		{
			if (GrassPlaneList == null)
			{
				GrassPlaneList = new List<ProceduralGrassPlane>();
			}
			for (int i = 0; i <= GrassPlaneList.Count - 1; i++)
			{
				Object.DestroyImmediate(GrassPlaneList[i].gameObject);
			}
			GrassPlaneList.Clear();
			Transform[] componentsInChildren = base.transform.GetComponentsInChildren<Transform>();
			foreach (Transform transform in componentsInChildren)
			{
				if ((bool)transform && transform.gameObject.name.StartsWith("Plane_"))
				{
					Object.DestroyImmediate(transform.gameObject);
				}
			}
		}

		public int GetMeshVertexCount()
		{
			int num = 0;
			for (int i = 0; i <= GrassPlaneList.Count - 1; i++)
			{
				MeshFilter component = GrassPlaneList[i].gameObject.GetComponent<MeshFilter>();
				if ((bool)component)
				{
					num += component.sharedMesh.vertexCount;
				}
			}
			return num;
		}

		public int GetMeshTriangleCount()
		{
			int num = 0;
			for (int i = 0; i <= GrassPlaneList.Count - 1; i++)
			{
				MeshFilter component = GrassPlaneList[i].gameObject.GetComponent<MeshFilter>();
				if ((bool)component)
				{
					num += component.sharedMesh.triangles.Length / 3;
				}
			}
			return num;
		}

		public void GenerateGrassPatch()
		{
			_vertexColorMaterial = Resources.Load("GrassPatchVertexColor") as Material;
			ClearGrassPlanes();
			Random.InitState(RandomSeed);
			for (int i = 0; i <= PlaneCount - 1; i++)
			{
				GameObject obj = new GameObject();
				obj.hideFlags = HideFlags.HideInHierarchy;
				obj.name = "Plane_" + i;
				obj.transform.SetParent(base.transform);
				float num = Random.Range(MinScale, MaxScale);
				float width = PlaneWidth * num;
				float num2 = PlaneHeight * num;
				ProceduralGrassPlane proceduralGrassPlane = obj.AddComponent<ProceduralGrassPlane>();
				proceduralGrassPlane.CurveOffset = Random.Range(0f - CurveOffset, CurveOffset);
				proceduralGrassPlane.Offset1 = Random.Range(0f - MaxBendDistance, MaxBendDistance);
				proceduralGrassPlane.Offset2 = Random.Range(0f - MaxBendDistance, MaxBendDistance);
				proceduralGrassPlane.height = num2;
				proceduralGrassPlane.width = width;
				proceduralGrassPlane.BakeBend = BakeBend;
				proceduralGrassPlane.BakePhase = BakePhase;
				proceduralGrassPlane.BakeAO = BakeAo;
				proceduralGrassPlane.BendCurve = WindBend;
				proceduralGrassPlane.AmbientOcclusionCurve = AmbientOcclusion;
				proceduralGrassPlane.Phase = (float)i * (1f / (float)PlaneCount);
				proceduralGrassPlane.GenerateBackside = GenerateBackside;
				proceduralGrassPlane.Index = i;
				if (i % 4 == 1)
				{
					proceduralGrassPlane.LODLevel = 2;
				}
				else if (i % 2 == 1)
				{
					proceduralGrassPlane.LODLevel = 1;
				}
				else
				{
					proceduralGrassPlane.LODLevel = 0;
				}
				if (ShowVertexColors)
				{
					proceduralGrassPlane.Material = _vertexColorMaterial;
				}
				else
				{
					proceduralGrassPlane.Material = GrassMaterial;
				}
				proceduralGrassPlane.MinimumBendHeight = MinBendHeight;
				proceduralGrassPlane.heightSegments = PlaneHeightSegments;
				proceduralGrassPlane.widthSegments = PlaneWidthSegments;
				obj.transform.localRotation = Quaternion.Euler(new Vector3(0f, Random.Range(0, 364), 0f));
				obj.transform.localPosition = new Vector3(Random.Range((0f - Size) / 2f, Size / 2f), num2 / 2f, Random.Range((0f - Size) / 2f, Size / 2f));
				GrassPlaneList.Add(proceduralGrassPlane);
				proceduralGrassPlane.CreateGrassPlane(0);
			}
		}

		private Mesh GetCombinedMesh(int lod)
		{
			MeshFilter[] componentsInChildren = base.gameObject.GetComponentsInChildren<MeshFilter>();
			List<MeshFilter> list = new List<MeshFilter>();
			for (int i = 0; i <= componentsInChildren.Length - 1; i++)
			{
				ProceduralGrassPlane component = componentsInChildren[i].gameObject.GetComponent<ProceduralGrassPlane>();
				component.CreateGrassPlane(lod);
				if (component.LODLevel >= lod)
				{
					list.Add(componentsInChildren[i]);
				}
			}
			CombineInstance[] array = new CombineInstance[list.Count];
			for (int j = 0; j <= list.Count - 1; j++)
			{
				array[j].mesh = list[j].sharedMesh;
				array[j].transform = list[j].transform.localToWorldMatrix;
			}
			Mesh mesh = new Mesh();
			mesh.CombineMeshes(array);
			return mesh;
		}

		public void BuildPrefab()
		{
		}

		public void BuildPrefabLod()
		{
		}

		private LOD CreateLOD(GameObject go, float screenRelativeTransitionHeight)
		{
			Renderer[] renderers = ((!go) ? new Renderer[0] : new Renderer[1] { go.GetComponent<Renderer>() });
			return new LOD(screenRelativeTransitionHeight, renderers);
		}
	}
}
