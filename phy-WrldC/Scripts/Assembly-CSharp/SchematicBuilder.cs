using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public static class SchematicBuilder
{
	private const string TAG_SCHEMATIC = "schematic";

	private const string ATTR_ID = "id";

	private const string TAG_BODY = "body";

	private const string TAG_RESOURCES = "resources";

	private const string TAG_MESH_MODEL_PATH = "meshModelPath";

	private const string TAG_COLLIDERS_PATH = "collidersPath";

	private const string TAG_TEXTURE_PATH = "texturePath";

	private const string TAG_SPECULAR_PATH = "specularPath";

	private const string TAG_NORMAL_MAP_PATH = "normalMapPath";

	private const string TAG_HEIGHT_MAP_PATH = "heightMapPath";

	private const string TAG_OCCLUSION_PATH = "occlusionPath";

	private const string TAG_EMISSION_PATH = "emissionPath";

	private const string TAG_HEIGHT_MAP_VALUE = "heightMapValue";

	private const string TAG_OCCLUSION_VALUE = "occlusionValue";

	private const string TAG_PROPERTIES = "properties";

	private const string TAG_CONNECTORS = "connectors";

	private const string TAG_DEFAULT = "default";

	private const string TAG_POINT = "point";

	private const string TAG_RECTANGLE_FULL = "rectangleFull";

	private const string TAG_RECTANGLE_SEMI = "rectangleSemi";

	private const string TAG_TWO_POINT = "twoPoint";

	private const string TAG_COMPONENTS = "components";

	private const string TAG_COMPONENT = "component";

	private const string ATTR_TYPE = "type";

	private const string ATTR_NAME = "name";

	private const string ATTR_LABEL = "label";

	private const string ATTR_VALUE = "value";

	public static Schematic CreateSchematic(string schematicPath, MaterialSchematicCollection materialSchematicCollection)
	{
		Schematic schematic = new Schematic();
		string schematicFolder = (schematic.FolderPath = new FileInfo(schematicPath).Directory.FullName);
		XDocument xDocument = XDocument.Load(schematicPath);
		schematic.HashSHA256 = Util.GetHashSHA256(xDocument.ToString());
		XElement xElement = xDocument.Element("schematic");
		SchematicParse(schematic, xElement);
		SchematicPropertiesParse(schematic, xElement.Element("properties"));
		foreach (XElement item in xElement.Elements("body"))
		{
			BodySchematic bodySchematic = new BodySchematic();
			schematic.AddBodySchematic(bodySchematic);
			BodyResourcesParse(bodySchematic, item.Element("resources"), schematicFolder, materialSchematicCollection);
			ConnectorsParse(bodySchematic, item.Element("connectors"));
			TwoPointParse(bodySchematic, item.Element("twoPoint"));
			ComponentsParse(bodySchematic, item.Element("components"));
		}
		GameObject gameObject = Resources.Load<GameObject>("Blocks/" + schematic.Id);
		if (gameObject != null)
		{
			SyncPrefabAndSchematic(gameObject, schematic);
		}
		return schematic;
	}

	private static void SyncPrefabAndSchematic(GameObject blockPrefab, Schematic schematic)
	{
		schematic.Prefab = blockPrefab;
		foreach (BodySchematic allBodySchematic in schematic.GetAllBodySchematics())
		{
			GameObject gameObject = blockPrefab.transform.GetChild(allBodySchematic.Index).gameObject;
			allBodySchematic.ModelMesh = gameObject.GetComponent<MeshFilter>().sharedMesh;
			MeshCollider[] components = gameObject.GetComponents<MeshCollider>();
			foreach (MeshCollider meshCollider in components)
			{
				allBodySchematic.MeshColliderList.Add(meshCollider.sharedMesh);
			}
			MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
			allBodySchematic.Texture = component.sharedMaterial.mainTexture as Texture2D;
			allBodySchematic.MainMaterial = component.sharedMaterial;
		}
	}

	private static void SetModelMeshAndColliders(BodySchematic bodySchematic, string schematicFolder, string modelMeshPath, string collidersPath)
	{
		if (modelMeshPath == collidersPath)
		{
			Mesh item = (bodySchematic.ModelMesh = Util.ImportMesh(schematicFolder + "\\" + modelMeshPath));
			bodySchematic.MeshColliderList.Add(item);
			return;
		}
		bodySchematic.ModelMesh = Util.ImportMesh(schematicFolder + "\\" + modelMeshPath);
		string[] array = collidersPath.Split(' ');
		foreach (string text in array)
		{
			switch (text)
			{
			case "box":
			case "Box":
				bodySchematic.UnityColliderList.Add(BodySchematic.UnityColliderType.Box);
				continue;
			case "capsule":
			case "Capsule":
				bodySchematic.UnityColliderList.Add(BodySchematic.UnityColliderType.Capsule);
				continue;
			case "sphere":
			case "Sphere":
				bodySchematic.UnityColliderList.Add(BodySchematic.UnityColliderType.Sphere);
				continue;
			}
			List<Mesh> list = new List<Mesh>();
			List<Mesh> list2 = new List<Mesh>();
			Util.ImportCollidersMeshes(schematicFolder + "\\" + text, list, list2);
			bodySchematic.MeshColliderList.AddRange(list);
			bodySchematic.BoxColliderList.AddRange(list2);
		}
	}

	private static void SchematicParse(Schematic schematic, XElement xSchematic)
	{
		schematic.Id = xSchematic.GetAttributeAsString("id");
	}

	private static void SchematicPropertiesParse(Schematic schematic, XElement xProperties)
	{
		Properties properties = new Properties();
		if (xProperties == null)
		{
			schematic.Properties = properties;
			return;
		}
		PropertiesBuilder.ConcatenateProperties(properties, xProperties);
		schematic.Properties = properties;
	}

	private static void BodyResourcesParse(BodySchematic bodySchematic, XElement xResources, string schematicFolder, MaterialSchematicCollection materialSchematicCollection)
	{
		if (xResources != null)
		{
			string text = null;
			string text2 = null;
			if (xResources.Element("meshModelPath") != null)
			{
				text = xResources.Element("meshModelPath").Value;
			}
			if (xResources.Element("collidersPath") != null)
			{
				text2 = xResources.Element("collidersPath").Value;
			}
			if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
			{
				SetModelMeshAndColliders(bodySchematic, schematicFolder, text, text2);
			}
			if (xResources.Element("texturePath") != null)
			{
				bodySchematic.Texture = LoadTexture(schematicFolder + "\\" + xResources.Element("texturePath").Value);
			}
			if (xResources.Element("specularPath") != null)
			{
				bodySchematic.Specular = LoadTexture(schematicFolder + "\\" + xResources.Element("specularPath").Value);
			}
			if (xResources.Element("normalMapPath") != null)
			{
				bodySchematic.NormalMap = LoadTexture(schematicFolder + "\\" + xResources.Element("normalMapPath").Value);
			}
			if (xResources.Element("heightMapPath") != null)
			{
				bodySchematic.HeightMap = Util.LoadPNG(schematicFolder + "\\" + xResources.Element("heightMapPath").Value);
			}
			if (xResources.Element("occlusionPath") != null)
			{
				bodySchematic.Occlussion = Util.LoadPNG(schematicFolder + "\\" + xResources.Element("occlusionPath").Value);
			}
			if (xResources.Element("emissionPath") != null)
			{
				bodySchematic.Emission = Util.LoadPNG(schematicFolder + "\\" + xResources.Element("emissionPath").Value);
			}
			bodySchematic.HeightMapValue = xResources.GetChildTagValueAsFloat("heightMapValue", -1f);
			bodySchematic.OcclusionValue = xResources.GetChildTagValueAsFloat("occlusionValue", -1f);
		}
	}

	private static Texture2D LoadTexture(string texturePath)
	{
		if (texturePath.EndsWith(".png", ignoreCase: true, CultureInfo.CurrentCulture))
		{
			return Util.LoadPNG(texturePath);
		}
		if (texturePath.EndsWith(".tga", ignoreCase: true, CultureInfo.CurrentCulture))
		{
			return TGALoader.LoadTGA(texturePath);
		}
		return null;
	}

	[Obsolete("Agora o Unity converte PNG direto para NormalMap.")]
	private static Texture2D LoadNormalMapPNG(string texturePath)
	{
		Texture2D result = null;
		if (File.Exists(texturePath))
		{
			byte[] data = File.ReadAllBytes(texturePath);
			result = new Texture2D(2, 2);
			result.LoadImage(data);
			Texture2D texture2D = new Texture2D(result.width, result.height, TextureFormat.ARGB32, mipChain: false);
			Color32[] pixels = result.GetPixels32();
			for (int i = 0; i < pixels.Length; i++)
			{
				Color32 color = pixels[i];
				color.a = color.r;
				color.r = color.g;
				color.b = color.g;
				pixels[i] = color;
			}
			texture2D.SetPixels32(pixels);
			texture2D.Apply();
			return texture2D;
		}
		return result;
	}

	private static void ConnectorsParse(BodySchematic bodySchematic, XElement xConnectors)
	{
		if (xConnectors != null)
		{
			if (xConnectors.Element("default") != null)
			{
				Util.TripleVector3Parser(xConnectors.Element("default").Value, bodySchematic.DefaultConnectors);
			}
			if (xConnectors.Element("point") != null)
			{
				Util.TripleVector3Parser(xConnectors.Element("point").Value, bodySchematic.PointsConnectors);
			}
			if (xConnectors.Element("rectangleFull") != null)
			{
				Util.DubleVector3Parser(xConnectors.Element("rectangleFull").Value, bodySchematic.RectangleFConnectors);
			}
			if (xConnectors.Element("rectangleSemi") != null)
			{
				Util.DubleVector3Parser(xConnectors.Element("rectangleSemi").Value, bodySchematic.RectangleSConnectors);
			}
		}
	}

	private static void TwoPointParse(BodySchematic bodySchematic, XElement xTwoPoint)
	{
		if (xTwoPoint == null)
		{
			bodySchematic.IsTwoPointBlock = false;
			return;
		}
		PropertiesBuilder.ConcatenateProperties(bodySchematic.TwoPointProperties, xTwoPoint);
		bodySchematic.IsTwoPointBlock = true;
		TwoPointBlockSchematic twoPointBlockSchematic = default(TwoPointBlockSchematic);
		string folderPath = bodySchematic.ParentSchematic.FolderPath;
		twoPointBlockSchematic.startMesh = Util.ImportMesh(folderPath + "\\" + bodySchematic.TwoPointProperties.GetProperty("startPointModelPath"));
		twoPointBlockSchematic.endMesh = Util.ImportMesh(folderPath + "\\" + bodySchematic.TwoPointProperties.GetProperty("endPointModelPath"));
		twoPointBlockSchematic.barMesh = Util.ImportMesh(folderPath + "\\" + bodySchematic.TwoPointProperties.GetProperty("barModelPath"));
		bodySchematic.TwoPointBlockSchematic = twoPointBlockSchematic;
	}

	private static void ComponentsParse(BodySchematic bodySchematic, XElement xComponents)
	{
		if (xComponents == null)
		{
			return;
		}
		foreach (XElement item in xComponents.Elements("component"))
		{
			string value = item.Attribute("name").Value;
			ComponentSchematic componentSchematic = new ComponentSchematic
			{
				Name = value
			};
			if (item.Attribute("type") != null)
			{
				string value2 = item.Attribute("type").Value;
				if (value2 == "motor" || value2 == "Motor")
				{
					componentSchematic.Type = ComponentType.Motor;
				}
			}
			PropertiesBuilder.ConcatenateProperties(componentSchematic.Properties, item.Element("properties"));
			bodySchematic.ComponentSchematics.Add(value, componentSchematic);
		}
	}
}
