using System;
using System.Collections.Generic;
using UnityEngine;

public class MaterialBank : MonoBehaviour
{
	public class MaterialHolder
	{
		public Material[] Materials;

		public int[] MapTo;

		public bool FullColor;

		private Color color1;

		private Color color2;

		private Color color3;

		public Color this[string key]
		{
			get
			{
				return Materials[0].GetColor(key);
			}
			set
			{
				for (int i = 0; i < Materials.Length; i++)
				{
					Materials[i].SetColor(key, value);
				}
			}
		}

		public Color Color
		{
			get
			{
				return color1;
			}
			set
			{
				color1 = value;
				for (int i = 0; i < Materials.Length; i++)
				{
					Materials[i].color = value;
				}
			}
		}

		public Color Color1
		{
			get
			{
				return color1;
			}
			set
			{
				color1 = value;
				for (int i = 0; i < Materials.Length; i++)
				{
					Materials[i].SetColor("_Color1", value);
				}
			}
		}

		public Color Color2
		{
			get
			{
				return color2;
			}
			set
			{
				color2 = value;
				for (int i = 0; i < Materials.Length; i++)
				{
					Materials[i].SetColor("_Color2", value);
				}
			}
		}

		public Color Color3
		{
			get
			{
				return color3;
			}
			set
			{
				color3 = value;
				if (!FullColor)
				{
					for (int i = 0; i < Materials.Length; i++)
					{
						Materials[i].SetColor("_Color3", value);
					}
				}
			}
		}

		public MaterialHolder(MaterialHolder source)
		{
			color1 = source.color1;
			color2 = source.color2;
			color3 = source.color3;
			Materials = source.Materials.SelectInPlace((Material x) => new Material(x));
			MapTo = source.MapTo.ToArray();
			FullColor = source.FullColor;
		}

		public MaterialHolder(Material[] mat, Color c1, Color c2, Color c3, bool fullColor)
		{
			List<Material> list = new List<Material>();
			List<int> list2 = new List<int>();
			for (int i = 0; i < mat.Length; i++)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (mat[i] == list[j])
					{
						list2.Add(j);
						break;
					}
				}
				if (list2.Count <= i)
				{
					list.Add(new Material(mat[i]));
					list2.Add(i);
				}
			}
			Materials = list.ToArray();
			MapTo = list2.ToArray();
			FullColor = fullColor;
			if (fullColor)
			{
				Color = c1;
				return;
			}
			Color1 = c1;
			Color2 = c2;
			Color3 = c3;
		}
	}

	public class BuildMaterial
	{
		public Material Mat;

		public int Count;

		public BuildMaterial(Material mat)
		{
			Mat = mat;
		}
	}

	[Serializable]
	public class WallMaterial
	{
		public string Name;

		public string Category;

		public Texture2D Base;

		public Texture2D Bump;

		public Texture2D Occlusion;

		public Texture2D Overlay;

		public float Metallic;

		public float Smoothness;

		public float BumpScale;

		public Material GenerateMaterial(Material baseMat)
		{
			Material material = new Material(baseMat);
			material.SetTexture("_MainTex", Base);
			material.SetTexture("_BumpMap", Bump);
			material.SetTexture("_OcclusionMap", Occlusion);
			material.SetTexture("_Overlay", Overlay);
			material.SetFloat("_Metallic", Metallic);
			material.SetFloat("_Glossiness", Smoothness);
			material.SetFloat("_BumpScale", BumpScale);
			return material;
		}
	}

	public Material BaseMat;

	public Material Darkness;

	public Material Dust;

	public Material DustFog;

	public Material Blackness;

	public Material TopWall;

	public string[] Category;

	public GameObject SmokeParticleSystem;

	public static MaterialBank Instance;

	public int DarknessCount = 25;

	public int DustCount = 10;

	public float MaxDarkness = 0.8f;

	public float DustFogFactor = 0.15f;

	private Material[] DarknessMats;

	private Material[][] DustMats;

	private void Start()
	{
		Instance = this;
		DarknessMats = new Material[DarknessCount];
		float num = DarknessMats.Length - 1;
		for (int i = 0; i < DarknessMats.Length; i++)
		{
			float num2 = (float)i / num;
			DarknessMats[i] = new Material(Darkness);
			DarknessMats[i].SetFloat("_Transparency", num2 * MaxDarkness);
		}
		DustMats = new Material[DustCount][];
		num = DustMats.Length - 1;
		for (int j = 0; j < DustMats.Length; j++)
		{
			float num3 = (float)j / num;
			DustMats[j] = new Material[2];
			DustMats[j][0] = new Material(Dust);
			DustMats[j][0].SetFloat("_Density", num3);
			DustMats[j][1] = new Material(DustFog);
			DustMats[j][1].SetFloat("_Fog", num3 * DustFogFactor);
		}
	}

	public Material[] GetDust(float dust)
	{
		return GetMat(dust, DustMats);
	}

	public Material GetDarkness(float darkness)
	{
		return GetMat(darkness, DarknessMats);
	}

	private static T GetMat<T>(float value, T[] mats)
	{
		if (float.IsPositiveInfinity(value) || float.IsNaN(value))
		{
			return mats[mats.Length - 1];
		}
		if (!float.IsNegativeInfinity(value))
		{
			return mats[Mathf.RoundToInt(Mathf.Clamp01(value) * (float)(mats.Length - 1))];
		}
		return mats[0];
	}
}
