using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace Panteleymonov
{
	[ExecuteInEditMode]
	[AddComponentMenu("Space/Star/SunGenerator")]
	public class SunGenerator : MonoBehaviour
	{
		public enum EModeSM
		{
			LIGHT_CPU = 0,
			LIGHT_SM3 = 1,
			LIGHT_SM4 = 2,
			CPU_SM3 = 3,
			CPU_2SM3 = 4,
			SM3 = 5,
			CPU_SM4 = 6,
			SM4 = 7
		}

		public enum EMeshType
		{
			Billboard = 0,
			Prisma = 1
		}

		[Header("Base")]
		[Tooltip("Shader version and type")]
		public EModeSM ShaderMode = EModeSM.SM3;

		[Tooltip("Model of mesh for view body, Billboard, Prisma")]
		public EMeshType MeshType = EMeshType.Prisma;

		[Header("Body")]
		[Tooltip("Body radius")]
		public float Radius = 0.5f;

		[Tooltip("Rays radius")]
		public float RayString = 1f;

		[Tooltip("Full scale, object radius is ( Radius + RayString ) * Zoom")]
		public float Zoom = 1f;

		[Tooltip("Details of elements")]
		public int Detail = 2;

		[Tooltip("Seed")]
		public float Seed;

		[Header("Elements")]
		[Tooltip("Glowing around body, it is inverse parameter")]
		public float Glow = 4f;

		[Tooltip("The intensity of rays, with more details, it is inverse parameter")]
		public float Rays = 2f;

		[Tooltip("The intensity of the bunches of rays, forming a wave")]
		public float RayRing = 1f;

		[Tooltip("Brigtness of rays, it is inverse parameter")]
		public float RayGlow = 2f;

		[Header("Colors")]
		[Tooltip("Color of body glare")]
		public Color Light = new Vector4(1f, 1f, 1f, 1f);

		[Tooltip("Color of body")]
		public Color Color = new Vector4(1f, 1f, 0f, 1f);

		[Tooltip("Color of body ground")]
		public Color BaseColor = new Vector4(1f, 0f, 0f, 1f);

		[Tooltip("Color of shadow ground")]
		public Color DarkColor = new Vector4(1f, 0f, 1f, 1f);

		[Tooltip("Color of rays")]
		public Color RayLight = new Vector4(1f, 0.95f, 1f, 1f);

		[Tooltip("Color of edge rays")]
		public Color RayColor = new Vector4(1f, 0.6f, 0.1f, 1f);

		[Header("Animation")]
		[Tooltip("Motion of big elements")]
		public float SpeedLow = 2f;

		[Tooltip("Motion of little elements")]
		public float SpeedHi = 2f;

		[Tooltip("Motion of rays")]
		public float SpeedRay = 5f;

		[Tooltip("Motion of wave rays rings")]
		public float SpeedRing = 2f;

		[Header("Noise Generator")]
		[Tooltip("Brigtness of body layers")]
		public Vector4 BodyNoiseLight = new Vector4(0.625f, 0.125f, 0.0625f, 1f / 32f);

		[Tooltip("Scale of body layers")]
		public Vector4 BodyNoiseScale = new Vector4(3.6864f, 61.44f, 307.2f, 600f);

		[Tooltip("Scale of ray layers")]
		public Vector4 RayNoiseScale = new Vector4(1f, 10f, 5f, 3f);

		private static Texture3D RNDt;

		private static Texture2D RNDt2;

		private static Mesh Board;

		private static Mesh BoardDouble;

		private static Mesh Prizm;

		private static Mesh PrizmDouble;

		private void Start()
		{
			Build();
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
			float num = (Radius + RayString) * Zoom;
			float x = base.transform.localScale.x;
			if (num == x)
			{
				return;
			}
			MeshRenderer component = GetComponent<MeshRenderer>();
			if (!(component == null))
			{
				Zoom = x / (Radius + RayString);
				float value = 1f / Zoom;
				if (ShaderMode == EModeSM.CPU_SM3 || ShaderMode == EModeSM.SM3)
				{
					component.sharedMaterials[0].SetFloat("_Zoom", value);
					component.sharedMaterials[1].SetFloat("_Zoom", value);
				}
				else
				{
					component.sharedMaterials[0].SetFloat("_Zoom", value);
				}
			}
		}

		private void OnValidate()
		{
			Build();
		}

		public void Build()
		{
			if (Radius < 0f)
			{
				Radius = 0f;
			}
			if (RayString < 0f)
			{
				RayString = 0f;
			}
			if (ShaderMode == EModeSM.CPU_SM3)
			{
				GenSSM3();
			}
			if (ShaderMode == EModeSM.CPU_2SM3)
			{
				Gen2SM3();
			}
			if (ShaderMode == EModeSM.SM3)
			{
				GenSM3();
			}
			if (ShaderMode == EModeSM.CPU_SM4)
			{
				GenSSM4();
			}
			if (ShaderMode == EModeSM.SM4)
			{
				GenSM4();
			}
			if (ShaderMode == EModeSM.LIGHT_CPU)
			{
				GenLS();
			}
			if (ShaderMode == EModeSM.LIGHT_SM3)
			{
				GenLSM3();
			}
			if (ShaderMode == EModeSM.LIGHT_SM4)
			{
				GenLSM4();
			}
		}

		private void OnDrawGizmos()
		{
		}

		private MeshFilter PrepeareMesh()
		{
			MeshFilter meshFilter = GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = base.gameObject.AddComponent<MeshFilter>();
			}
			meshFilter.sharedMesh = new Mesh();
			meshFilter.sharedMesh.Clear();
			return meshFilter;
		}

		public static Mesh GetBilboard(float r = 1.2f)
		{
			if (Board == null)
			{
				Board = new Mesh();
				Vector3[] vertices = new Vector3[4]
				{
					new Vector3(0f - r, 0f - r, 0f),
					new Vector3(r, 0f - r, 0f),
					new Vector3(r, r, 0f),
					new Vector3(0f - r, r, 0f)
				};
				Vector3[] normals = new Vector3[4];
				Vector2[] uv = new Vector2[4];
				Board.subMeshCount = 1;
				Board.vertices = vertices;
				Board.normals = normals;
				Board.uv = uv;
				Board.triangles = new int[6] { 1, 0, 2, 3, 2, 0 };
				Board.bounds = new Bounds(new Vector3(0f, 0f, 0f), new Vector3(r, r, r) * 2f);
			}
			return Board;
		}

		private void MeshBillboard(float r)
		{
			MeshFilter meshFilter = PrepeareMesh();
			GetBilboard(r);
			meshFilter.sharedMesh = Board;
		}

		private void MeshDoubleBillboard(float r)
		{
			MeshFilter meshFilter = PrepeareMesh();
			if (BoardDouble == null)
			{
				BoardDouble = new Mesh();
				Vector3[] vertices = new Vector3[8]
				{
					new Vector3(0f - r, 0f - r, 0f),
					new Vector3(r, 0f - r, 0f),
					new Vector3(r, r, 0f),
					new Vector3(0f - r, r, 0f),
					new Vector3(0f - r, 0f - r, (0f - r) * 0.1f),
					new Vector3(r, 0f - r, (0f - r) * 0.1f),
					new Vector3(r, r, (0f - r) * 0.1f),
					new Vector3(0f - r, r, (0f - r) * 0.1f)
				};
				Vector3[] normals = new Vector3[8];
				Vector2[] uv = new Vector2[8];
				BoardDouble.subMeshCount = 2;
				BoardDouble.vertices = vertices;
				BoardDouble.normals = normals;
				BoardDouble.uv = uv;
				int[] triangles = new int[6] { 1, 0, 2, 3, 2, 0 };
				BoardDouble.SetTriangles(triangles, 0);
				triangles = new int[6] { 5, 4, 6, 7, 6, 4 };
				BoardDouble.SetTriangles(triangles, 1);
				BoardDouble.bounds = new Bounds(new Vector3(0f, 0f, 0f), new Vector3(r, r, r) * 2f);
			}
			meshFilter.sharedMesh = BoardDouble;
		}

		public static Mesh GetPrisma(float r = 1f)
		{
			if (Prizm == null)
			{
				Prizm = new Mesh();
				Vector3[] vertices = new Vector3[6]
				{
					new Vector3(0f - r, 0f - r, 0f - r),
					new Vector3(r, 0f - r, 0f - r),
					new Vector3(r, r, 0f - r),
					new Vector3(0f - r, r, 0f - r),
					new Vector3(0f, 0f, 0f),
					new Vector3(0f, 0f, (0f - r) * 2f)
				};
				Vector3[] normals = new Vector3[6];
				Vector2[] uv = new Vector2[6];
				Prizm.subMeshCount = 1;
				Prizm.vertices = vertices;
				Prizm.normals = normals;
				Prizm.uv = uv;
				Prizm.triangles = new int[24]
				{
					1, 0, 4, 2, 1, 4, 3, 2, 4, 0,
					3, 4, 0, 1, 5, 1, 2, 5, 2, 3,
					5, 3, 0, 5
				};
				Prizm.bounds = new Bounds(new Vector3(0f, 0f, 0f), new Vector3(r, r, r) * 2f);
			}
			return Prizm;
		}

		private void MeshPrisma(float r)
		{
			PrepeareMesh().sharedMesh = GetPrisma(r);
		}

		private void MeshDoublePrisma(float r)
		{
			MeshFilter meshFilter = PrepeareMesh();
			if (PrizmDouble == null)
			{
				PrizmDouble = new Mesh();
				Vector3[] vertices = new Vector3[10]
				{
					new Vector3(0f - r, 0f - r, 0f - r),
					new Vector3(r, 0f - r, 0f - r),
					new Vector3(r, r, 0f - r),
					new Vector3(0f - r, r, 0f - r),
					new Vector3((0f - r) * 0.9f, (0f - r) * 0.9f, 0f - r),
					new Vector3(r * 0.9f, (0f - r) * 0.9f, 0f - r),
					new Vector3(r * 0.9f, r * 0.9f, 0f - r),
					new Vector3((0f - r) * 0.9f, r * 0.9f, 0f - r),
					new Vector3(0f, 0f, 0f),
					new Vector3(0f, 0f, (0f - r) * 2f)
				};
				Vector3[] normals = new Vector3[10];
				Vector2[] uv = new Vector2[10];
				PrizmDouble.subMeshCount = 2;
				PrizmDouble.vertices = vertices;
				PrizmDouble.normals = normals;
				PrizmDouble.uv = uv;
				int[] triangles = new int[24]
				{
					1, 0, 8, 2, 1, 8, 3, 2, 8, 0,
					3, 8, 0, 1, 9, 1, 2, 9, 2, 3,
					9, 3, 0, 9
				};
				PrizmDouble.SetTriangles(triangles, 0);
				triangles = new int[24]
				{
					5, 4, 8, 6, 5, 8, 7, 6, 8, 4,
					7, 8, 4, 5, 9, 5, 6, 9, 6, 7,
					9, 7, 4, 9
				};
				PrizmDouble.SetTriangles(triangles, 1);
				PrizmDouble.bounds = new Bounds(new Vector3(0f, 0f, 0f), new Vector3(r, r, r) * 2f);
			}
			meshFilter.sharedMesh = PrizmDouble;
		}

		public void fillShaderData(Material material)
		{
			material.SetFloat("_Radius", Radius);
			material.SetFloat("_Detail", Detail);
			material.SetFloat("_RayString", RayString);
			material.SetFloat("_Glow", Glow);
			material.SetFloat("_Rays", Rays);
			material.SetFloat("_RayRing", RayRing);
			material.SetFloat("_RayGlow", RayGlow);
			material.SetFloat("_Zoom", 1f / Zoom);
			material.SetVector("_Light", Light);
			material.SetVector("_Color", Color);
			material.SetVector("_Base", BaseColor);
			material.SetVector("_Dark", DarkColor);
			material.SetVector("_RayLight", RayLight);
			material.SetVector("_Ray", RayColor);
			material.SetFloat("_SpeedHi", SpeedHi);
			material.SetFloat("_SpeedLow", SpeedLow);
			material.SetFloat("_SpeedRay", SpeedRay);
			material.SetFloat("_SpeedRing", SpeedRing);
			material.SetFloat("_Seed", Seed);
			material.SetVector("_BodyNoiseL", BodyNoiseLight);
			material.SetVector("_BodyNoiseS", BodyNoiseScale);
			material.SetVector("_RayNoiseS", RayNoiseScale);
		}

		private void fillShaderDataS(Material[] materials)
		{
			materials[0].SetFloat("_Radius", Radius);
			materials[1].SetFloat("_Radius", Radius);
			materials[0].SetFloat("_Detail", Detail);
			materials[1].SetFloat("_Detail", Detail);
			materials[1].SetFloat("_RayString", RayString);
			materials[1].SetFloat("_Glow", Glow);
			materials[1].SetFloat("_Rays", Rays);
			materials[1].SetFloat("_RayRing", RayRing);
			materials[1].SetFloat("_RayGlow", RayGlow);
			materials[0].SetFloat("_Zoom", 1f / Zoom);
			materials[1].SetFloat("_Zoom", 1f / Zoom);
			materials[0].SetVector("_Light", Light);
			materials[0].SetVector("_Color", Color);
			materials[0].SetVector("_Base", BaseColor);
			materials[0].SetVector("_Dark", DarkColor);
			materials[1].SetVector("_RayLight", RayLight);
			materials[1].SetVector("_Ray", RayColor);
			materials[0].SetFloat("_SpeedHi", SpeedHi);
			materials[0].SetFloat("_SpeedLow", SpeedLow);
			materials[1].SetFloat("_SpeedRay", SpeedRay);
			materials[1].SetFloat("_SpeedRing", SpeedRing);
			materials[0].SetFloat("_Seed", Seed);
			materials[1].SetFloat("_Seed", Seed);
			materials[0].SetVector("_BodyNoiseL", BodyNoiseLight);
			materials[0].SetVector("_BodyNoiseS", BodyNoiseScale);
			materials[1].SetVector("_RayNoiseS", RayNoiseScale);
		}

		private void CreateTexture()
		{
			if (!(RNDt == null))
			{
				return;
			}
			int num = 128;
			RNDt = new Texture3D(num, num, num, TextureFormat.ARGB32, mipChain: true);
			Color[] array = new Color[num * num * num];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					for (int k = 0; k < num; k++)
					{
						float num2 = (float)i * 1f + (float)j * 113f + (float)k * 157f;
						float num3 = Mathf.Sin(num2) * (4397487f / MathF.PI);
						num3 = Mathf.Abs(num3 - Mathf.Floor(num3));
						float num4 = Mathf.Sin(num2 + 228.25f) * (4397487f / MathF.PI);
						num4 = Mathf.Abs(num4 - Mathf.Floor(num4));
						float num5 = Mathf.Sin(num2 + 456.5f) * (4397487f / MathF.PI);
						num5 = Mathf.Abs(num5 - Mathf.Floor(num5));
						float num6 = Mathf.Sin(num2 + 684.75f) * (4397487f / MathF.PI);
						num6 = Mathf.Abs(num6 - Mathf.Floor(num6));
						array[i + j * num + k * num * num] = new Color(num3, num4, num5, num6);
					}
				}
			}
			RNDt.SetPixels(array);
			RNDt.Apply();
			num = 512;
			RNDt2 = new Texture2D(num, num, TextureFormat.ARGB32, mipChain: true);
			for (int l = 0; l < num; l++)
			{
				for (int m = 0; m < num; m++)
				{
					float num7 = (float)l * 1f + (float)m * 113f;
					float num8 = Mathf.Sin(num7) * (4397487f / MathF.PI);
					num8 = Mathf.Abs(num8 - Mathf.Floor(num8));
					float num9 = Mathf.Sin(num7 + 228.25f) * (4397487f / MathF.PI);
					num9 = Mathf.Abs(num9 - Mathf.Floor(num9));
					float num10 = Mathf.Sin(num7 + 456.5f) * (4397487f / MathF.PI);
					num10 = Mathf.Abs(num10 - Mathf.Floor(num10));
					float num11 = Mathf.Sin(num7 + 684.75f) * (4397487f / MathF.PI);
					num11 = Mathf.Abs(num11 - Mathf.Floor(num11));
					array[l + m * num] = new Color(num8, num9, num10, num11);
				}
			}
			RNDt2.SetPixels(array);
			RNDt2.Apply();
		}

		private void GenLS()
		{
			CreateTexture();
			float num = (Radius + RayString) * Zoom;
			if (MeshType == EMeshType.Billboard)
			{
				MeshBillboard(1.2f);
			}
			if (MeshType == EMeshType.Prisma)
			{
				MeshPrisma(1f);
			}
			MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
			base.transform.localScale = new Vector3(num, num, num);
			if (meshRenderer == null)
			{
				meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			Material[] array = new Material[1]
			{
				new Material(Shader.Find("Space/Star/Sun_soft_rnd"))
			};
			fillShaderData(array[0]);
			array[0].SetTexture("_RND", RNDt);
			meshRenderer.sharedMaterials = array;
			meshRenderer.receiveShadows = false;
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}

		private void GenSSM3()
		{
			CreateTexture();
			float num = (Radius + RayString) * Zoom;
			if (MeshType == EMeshType.Billboard)
			{
				MeshBillboard(1.2f);
			}
			if (MeshType == EMeshType.Prisma)
			{
				MeshPrisma(1f);
			}
			MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
			base.transform.localScale = new Vector3(num, num, num);
			if (meshRenderer == null)
			{
				meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			Material[] array = new Material[1]
			{
				new Material(Shader.Find("Space/Star/Sun_rnd_low"))
			};
			fillShaderData(array[0]);
			array[0].SetTexture("_RND", RNDt);
			meshRenderer.sharedMaterials = array;
			meshRenderer.receiveShadows = false;
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}

		private void Gen2SM3()
		{
			CreateTexture();
			float num = (Radius + RayString) * Zoom;
			if (MeshType == EMeshType.Billboard)
			{
				MeshBillboard(1.2f);
			}
			if (MeshType == EMeshType.Prisma)
			{
				MeshPrisma(1f);
			}
			MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
			base.transform.localScale = new Vector3(num, num, num);
			if (meshRenderer == null)
			{
				meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			Material[] array = new Material[1]
			{
				new Material(Shader.Find("Space/Star/Sun_rnd2_low"))
			};
			fillShaderData(array[0]);
			array[0].SetTexture("_RND", RNDt2);
			array[0].SetTextureScale("_RND", Vector2.one * 1f / RNDt2.width);
			meshRenderer.sharedMaterials = array;
			meshRenderer.receiveShadows = false;
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}

		private void GenSSM4()
		{
			CreateTexture();
			float num = (Radius + RayString) * Zoom;
			if (MeshType == EMeshType.Billboard)
			{
				MeshBillboard(1.2f);
			}
			if (MeshType == EMeshType.Prisma)
			{
				MeshPrisma(1f);
			}
			MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
			base.transform.localScale = new Vector3(num, num, num);
			if (meshRenderer == null)
			{
				meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			Material[] array = new Material[1]
			{
				new Material(Shader.Find("Space/Star/Sun_rnd"))
			};
			fillShaderData(array[0]);
			array[0].SetTexture("_RND", RNDt);
			meshRenderer.sharedMaterials = array;
			meshRenderer.receiveShadows = false;
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}

		private void GenLSM3()
		{
			float num = (Radius + RayString) * Zoom;
			if (MeshType == EMeshType.Billboard)
			{
				MeshBillboard(1.2f);
			}
			if (MeshType == EMeshType.Prisma)
			{
				MeshPrisma(1f);
			}
			MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
			base.transform.localScale = new Vector3(num, num, num);
			if (meshRenderer == null)
			{
				meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			Material[] array = new Material[1]
			{
				new Material(Shader.Find("Space/Star/Sun_soft_low"))
			};
			fillShaderData(array[0]);
			meshRenderer.sharedMaterials = array;
			meshRenderer.receiveShadows = false;
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}

		private void GenLSM4()
		{
			float num = (Radius + RayString) * Zoom;
			if (MeshType == EMeshType.Billboard)
			{
				MeshBillboard(1.2f);
			}
			if (MeshType == EMeshType.Prisma)
			{
				MeshPrisma(1f);
			}
			MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
			base.transform.localScale = new Vector3(num, num, num);
			if (meshRenderer == null)
			{
				meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			Material[] array = new Material[1]
			{
				new Material(Shader.Find("Space/Star/Sun_soft"))
			};
			fillShaderData(array[0]);
			meshRenderer.sharedMaterials = array;
			meshRenderer.receiveShadows = false;
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}

		private void GenSM3()
		{
			float num = (Radius + RayString) * Zoom;
			if (MeshType == EMeshType.Billboard)
			{
				MeshBillboard(1.2f);
			}
			if (MeshType == EMeshType.Prisma)
			{
				MeshPrisma(1f);
			}
			MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
			base.transform.localScale = new Vector3(num, num, num);
			if (meshRenderer == null)
			{
				meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			Material[] array = new Material[1]
			{
				new Material(Shader.Find("Space/Star/Sun_low"))
			};
			fillShaderData(array[0]);
			meshRenderer.sharedMaterials = array;
			meshRenderer.receiveShadows = false;
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}

		private void GenSM4()
		{
			float num = (Radius + RayString) * Zoom;
			if (MeshType == EMeshType.Billboard)
			{
				MeshBillboard(1.2f);
			}
			if (MeshType == EMeshType.Prisma)
			{
				MeshPrisma(1f);
			}
			MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
			base.transform.localScale = new Vector3(num, num, num);
			if (meshRenderer == null)
			{
				meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			Material[] array = new Material[1]
			{
				new Material(Shader.Find("Space/Star/Sun"))
			};
			fillShaderData(array[0]);
			meshRenderer.sharedMaterials = array;
			meshRenderer.receiveShadows = false;
			meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
		}
	}
}
