using System.Collections.Generic;
using UnityEngine;

public class BodySchematic
{
	public enum UnityColliderType
	{
		Box = 0,
		Capsule = 1,
		Sphere = 2
	}

	private Material mainMaterial;

	private Material transparentMaterial;

	public Schematic ParentSchematic { get; set; }

	public int Index { get; set; }

	public Mesh ModelMesh { get; set; }

	public List<Mesh> MeshColliderList { get; private set; }

	public List<Mesh> BoxColliderList { get; private set; }

	public List<UnityColliderType> UnityColliderList { get; private set; }

	public Texture2D Texture { get; set; }

	public Texture2D Specular { get; set; }

	public Texture2D NormalMap { get; set; }

	public Texture2D HeightMap { get; set; }

	public Texture2D Occlussion { get; set; }

	public Texture2D Emission { get; set; }

	public float HeightMapValue { get; set; }

	public float OcclusionValue { get; set; }

	public bool IsTwoPointBlock { get; set; }

	public TwoPointBlockSchematic TwoPointBlockSchematic { get; set; }

	public Properties TwoPointProperties { get; private set; }

	public Dictionary<string, ComponentSchematic> ComponentSchematics { get; private set; }

	public List<Vector3> DefaultConnectors { get; private set; }

	public List<Vector3> PointsConnectors { get; private set; }

	public List<Vector3> RectangleFConnectors { get; private set; }

	public List<Vector3> RectangleSConnectors { get; private set; }

	public Material MainMaterial
	{
		get
		{
			if (mainMaterial == null)
			{
				mainMaterial = new Material(Shader.Find("Standard (Specular setup)"));
				mainMaterial.mainTexture = Texture;
				if (Specular != null)
				{
					mainMaterial.SetTexture("_SpecGlossMap", Specular);
					mainMaterial.EnableKeyword("_SPECGLOSSMAP");
				}
				if (NormalMap != null)
				{
					mainMaterial.SetTexture("_BumpMap", NormalMap);
					mainMaterial.EnableKeyword("_NORMALMAP");
				}
				if (HeightMap != null)
				{
					mainMaterial.SetTexture("_ParallaxMap", HeightMap);
					if (HeightMapValue >= 0f)
					{
						mainMaterial.SetFloat("_Parallax", HeightMapValue);
					}
					mainMaterial.EnableKeyword("_PARALLAXMAP");
				}
				if (Occlussion != null)
				{
					if (OcclusionValue >= 0f)
					{
						mainMaterial.SetFloat("_OcclusionStrength", OcclusionValue);
					}
					mainMaterial.SetTexture("_OcclusionMap", Occlussion);
				}
				if (Emission != null)
				{
					mainMaterial.SetTexture("_EmissionMap", Emission);
					mainMaterial.SetColor("_EmissionColor", Color.white * 5f);
					mainMaterial.EnableKeyword("_EMISSION");
				}
			}
			return mainMaterial;
		}
		set
		{
			mainMaterial = value;
		}
	}

	public Material TransparentMaterial
	{
		get
		{
			if (transparentMaterial == null)
			{
				transparentMaterial = new Material(MainMaterial);
				Util.TurnStandardMaterialToFade(transparentMaterial);
			}
			return transparentMaterial;
		}
		set
		{
			transparentMaterial = value;
		}
	}

	public BodySchematic()
	{
		DefaultConnectors = new List<Vector3>();
		PointsConnectors = new List<Vector3>();
		RectangleFConnectors = new List<Vector3>();
		RectangleSConnectors = new List<Vector3>();
		MeshColliderList = new List<Mesh>();
		BoxColliderList = new List<Mesh>();
		UnityColliderList = new List<UnityColliderType>();
		TwoPointProperties = new Properties();
		ComponentSchematics = new Dictionary<string, ComponentSchematic>();
		HeightMapValue = -1f;
		OcclusionValue = -1f;
		Index = 0;
	}
}
