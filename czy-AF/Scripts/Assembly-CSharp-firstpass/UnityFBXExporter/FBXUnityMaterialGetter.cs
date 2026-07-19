using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UnityFBXExporter
{
	public class FBXUnityMaterialGetter
	{
		public static void GetAllMaterialsToString(GameObject gameObj, string newPath, bool copyMaterials, bool copyTextures, out Material[] materials, out string matObjects, out string connections)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			Renderer[] componentsInChildren = gameObj.GetComponentsInChildren<Renderer>();
			List<Material> list = new List<Material>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				for (int j = 0; j < componentsInChildren[i].sharedMaterials.Length; j++)
				{
					Material material = componentsInChildren[i].sharedMaterials[j];
					if (!list.Contains(material) && material != null)
					{
						list.Add(material);
					}
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				Material material2 = list[k];
				string text = material2.name.Replace(" ", "").Replace("(Instance)", "");
				int num = Mathf.Abs(material2.GetInstanceID());
				stringBuilder.AppendLine();
				stringBuilder.AppendLine("\tMaterial: " + num + ", \"Material::" + text + "\", \"\" {");
				stringBuilder.AppendLine("\t\tVersion: 102");
				stringBuilder.AppendLine("\t\tShadingModel: \"phong\"");
				stringBuilder.AppendLine("\t\tMultiLayer: 0");
				stringBuilder.AppendLine("\t\tProperties70:  {");
				stringBuilder.AppendFormat("\t\t\tP: \"Diffuse\", \"Vector3D\", \"Vector\", \"\",{0},{1},{2}", material2.color.r, material2.color.g, material2.color.b);
				stringBuilder.AppendLine();
				stringBuilder.AppendFormat("\t\t\tP: \"DiffuseColor\", \"Color\", \"\", \"A\",{0},{1},{2}", material2.color.r, material2.color.g, material2.color.b);
				stringBuilder.AppendLine();
				if (material2.HasProperty("_SpecColor"))
				{
					Color color = material2.GetColor("_SpecColor");
					stringBuilder.AppendFormat("\t\t\tP: \"Specular\", \"Vector3D\", \"Vector\", \"\",{0},{1},{2}", color.r, color.g, color.r);
					stringBuilder.AppendLine();
					stringBuilder.AppendFormat("\t\t\tP: \"SpecularColor\", \"ColorRGB\", \"Color\", \" \",{0},{1},{2}", color.r, color.g, color.b);
					stringBuilder.AppendLine();
				}
				if (material2.HasProperty("_Mode"))
				{
					Color white = Color.white;
					switch ((int)material2.GetFloat("_Mode"))
					{
					case 2:
						white = material2.GetColor("_Color");
						stringBuilder.AppendFormat("\t\t\tP: \"TransparentColor\", \"Color\", \"\", \"A\",{0},{1},{2}", white.r, white.g, white.b);
						stringBuilder.AppendLine();
						stringBuilder.AppendFormat("\t\t\tP: \"Opacity\", \"double\", \"Number\", \"\",{0}", white.a);
						stringBuilder.AppendLine();
						break;
					case 3:
						white = material2.GetColor("_Color");
						stringBuilder.AppendFormat("\t\t\tP: \"TransparentColor\", \"Color\", \"\", \"A\",{0},{1},{2}", white.r, white.g, white.b);
						stringBuilder.AppendLine();
						stringBuilder.AppendFormat("\t\t\tP: \"Opacity\", \"double\", \"Number\", \"\",{0}", white.a);
						stringBuilder.AppendLine();
						break;
					}
				}
				if (material2.HasProperty("_EmissionColor"))
				{
					Color color2 = material2.GetColor("_EmissionColor");
					stringBuilder.AppendFormat("\t\t\tP: \"Emissive\", \"Vector3D\", \"Vector\", \"\",{0},{1},{2}", color2.r, color2.g, color2.b);
					stringBuilder.AppendLine();
					float num2 = (color2.r + color2.g + color2.b) / 3f;
					stringBuilder.AppendFormat("\t\t\tP: \"EmissiveFactor\", \"Number\", \"\", \"A\",{0}", num2);
					stringBuilder.AppendLine();
				}
				stringBuilder.AppendLine("\t\t}");
				stringBuilder.AppendLine("\t}");
				SerializedTextures(gameObj, newPath, material2, text, copyTextures, out var objects, out var connections2);
				stringBuilder.Append(objects);
				stringBuilder2.Append(connections2);
			}
			materials = Enumerable.ToArray(list);
			matObjects = stringBuilder.ToString();
			connections = stringBuilder2.ToString();
		}

		private static void SerializedTextures(GameObject gameObj, string newPath, Material material, string materialName, bool copyTextures, out string objects, out string connections)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			int materialId = Mathf.Abs(material.GetInstanceID());
			Texture texture = material.GetTexture("_MainTex");
			string objects2 = null;
			string connections2 = null;
			if (texture != null)
			{
				SerializeOneTexture(gameObj, newPath, material, materialName, materialId, copyTextures, "_MainTex", "DiffuseColor", out objects2, out connections2);
				stringBuilder.AppendLine(objects2);
				stringBuilder2.AppendLine(connections2);
			}
			if (SerializeOneTexture(gameObj, newPath, material, materialName, materialId, copyTextures, "_BumpMap", "NormalMap", out objects2, out connections2))
			{
				stringBuilder.AppendLine(objects2);
				stringBuilder2.AppendLine(connections2);
			}
			connections = stringBuilder2.ToString();
			objects = stringBuilder.ToString();
		}

		private static bool SerializeOneTexture(GameObject gameObj, string newPath, Material material, string materialName, int materialId, bool copyTextures, string unityExtension, string textureType, out string objects, out string connections)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			Texture texture = null;
			if (material.HasProperty(unityExtension))
			{
				texture = material.GetTexture(unityExtension);
			}
			if (texture == null)
			{
				objects = "";
				connections = "";
				return false;
			}
			string dataPath = Application.dataPath;
			string value = "Textures/" + materialName + ".png";
			string text = Path.GetFileNameWithoutExtension("");
			string extension = Path.GetExtension("");
			if (copyTextures)
			{
				int num = dataPath.LastIndexOf("/Assets");
				dataPath = dataPath.Remove(num, dataPath.Length - num);
				string text2 = newPath.Remove(newPath.LastIndexOf('/') + 1, newPath.Length - newPath.LastIndexOf('/') - 1);
				text = gameObj.name + "_" + material.name + unityExtension;
				value = dataPath + "/" + text2 + text + extension;
			}
			long randomFBXId = FBXExporter.GetRandomFBXId();
			stringBuilder.AppendLine("\tTexture: " + randomFBXId + ", \"Texture::" + materialName + "\", \"\" {");
			stringBuilder.AppendLine("\t\tType: \"TextureVideoClip\"");
			stringBuilder.AppendLine("\t\tVersion: 202");
			stringBuilder.AppendLine("\t\tTextureName: \"Texture::" + materialName + "\"");
			stringBuilder.AppendLine("\t\tProperties70:  {");
			stringBuilder.AppendLine("\t\t\tP: \"CurrentTextureBlendMode\", \"enum\", \"\", \"\",0");
			stringBuilder.AppendLine("\t\t\tP: \"UVSet\", \"KString\", \"\", \"\", \"map1\"");
			stringBuilder.AppendLine("\t\t\tP: \"UseMaterial\", \"bool\", \"\", \"\",1");
			stringBuilder.AppendLine("\t\t}");
			stringBuilder.AppendLine("\t\tMedia: \"Video::" + materialName + "\"");
			stringBuilder.Append("\t\tFileName: \"");
			stringBuilder.Append(value);
			stringBuilder.AppendLine("\"");
			if (copyTextures)
			{
				stringBuilder.AppendLine("\t\tRelativeFilename: \"/Textures/" + text + extension + "\"");
			}
			stringBuilder.AppendLine("\t\tModelUVTranslation: 0,0");
			stringBuilder.AppendLine("\t\tModelUVScaling: 1,1");
			stringBuilder.AppendLine("\t\tTexture_Alpha_Source: \"None\"");
			stringBuilder.AppendLine("\t\tCropping: 0,0,0,0");
			stringBuilder.AppendLine("\t}");
			stringBuilder2.AppendLine("\t;Texture::" + text + ", Material::" + materialName + "\"");
			stringBuilder2.AppendLine("\tC: \"OP\"," + randomFBXId + "," + materialId + ", \"" + textureType + "\"");
			stringBuilder2.AppendLine();
			objects = stringBuilder.ToString();
			connections = stringBuilder2.ToString();
			return true;
		}
	}
}
