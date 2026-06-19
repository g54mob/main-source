using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;

namespace SimplySVG
{
	public class SimplySVGImporter
	{
		public string name;

		public ImportSettings importSettings;

		private Object svgFile;

		public SVGDocument document;

		public List<SVGDocument> svgDocumentLayers = new List<SVGDocument>();

		public string svgData;

		public Mesh mesh;

		public List<Mesh> meshLayers = new List<Mesh>();

		public List<string> names = new List<string>();

		public CollisionShapeData collisionShapeData;

		public List<CollisionShapeData> collisionShapeDataLayers = new List<CollisionShapeData>();

		public string errors = "";

		private Dictionary<string, List<int>> unsupportedElements;

		public SimplySVGImporter(string svgData, string name, ImportSettings settings = null)
		{
			this.svgData = svgData;
			this.name = name;
			importSettings = settings;
			if (importSettings == null)
			{
				importSettings = ScriptableObject.CreateInstance<ImportSettings>();
			}
		}

		public void Import()
		{
			if (string.IsNullOrEmpty(svgData))
			{
				Debug.LogError("SVG data was null or empty");
				return;
			}
			DocumentParser documentParser = new DocumentParser();
			List<DocumentParser> list = new List<DocumentParser>();
			DocumentParser documentParser2 = null;
			XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
			xmlReaderSettings.DtdProcessing = DtdProcessing.Parse;
			xmlReaderSettings.XmlResolver = null;
			int num = 0;
			using (XmlReader xmlReader = XmlReader.Create(new StringReader(svgData), xmlReaderSettings))
			{
				while (xmlReader.Read())
				{
					switch (xmlReader.NodeType)
					{
					case XmlNodeType.Element:
					{
						if (xmlReader.Name == "svg")
						{
							document = documentParser.BeginDocument();
							break;
						}
						string text = xmlReader.Name;
						bool isEmptyElement = xmlReader.IsEmptyElement;
						bool num2 = documentParser.BeginElement(text);
						if (text == "g")
						{
							num++;
						}
						if (documentParser2 == null)
						{
							if (text == "g")
							{
								documentParser2 = new DocumentParser();
								list.Add(documentParser2);
								svgDocumentLayers.Add(documentParser2.BeginDocument());
								documentParser2.BeginElement(text);
							}
						}
						else
						{
							documentParser2.BeginElement(text);
						}
						if (!num2)
						{
							WarnAboutUnsupportedFeature(text + " element", xmlReader);
							if (isEmptyElement)
							{
								documentParser.EndElement();
								documentParser2?.EndElement();
							}
							break;
						}
						while (xmlReader.MoveToNextAttribute())
						{
							string text2 = xmlReader.Name;
							string value = xmlReader.Value;
							if (!documentParser.AddAttribute(text2, value))
							{
								WarnAboutUnsupportedFeature(text2 + " attribute", xmlReader);
							}
							documentParser2?.AddAttribute(text2, value);
						}
						if (isEmptyElement)
						{
							documentParser.EndElement();
							documentParser2?.EndElement();
						}
						break;
					}
					case XmlNodeType.EndElement:
						if (xmlReader.Name == "svg")
						{
							documentParser.EndDocument();
							break;
						}
						if (xmlReader.Name == "g")
						{
							num--;
							if (num == 0)
							{
								documentParser2.EndElement();
								documentParser2.EndDocument();
								documentParser2 = null;
							}
						}
						documentParser2?.EndElement();
						documentParser.EndElement();
						break;
					}
				}
			}
			ShowUnsupportedFeatureIfNeeded();
		}

		private void ShowUnsupportedFeatureIfNeeded()
		{
			if (unsupportedElements == null)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder("Unsupported SVG features detected while importing the SVG document at:\n" + name + "\n\nRead the documentation and check your graphics production software's SVG exporter settings. Unless fixed, the graphic may not appear in Unity as intended.\n\nUnsupported features are:\n\n");
			int num = 0;
			int maxUnsupportedFeatureWarningCount = GlobalSettings.Get().maxUnsupportedFeatureWarningCount;
			if (maxUnsupportedFeatureWarningCount == 0)
			{
				unsupportedElements = null;
				return;
			}
			foreach (KeyValuePair<string, List<int>> unsupportedElement in unsupportedElements)
			{
				if (++num > maxUnsupportedFeatureWarningCount)
				{
					stringBuilder.Append("Showing only first " + maxUnsupportedFeatureWarningCount + " warnings...\n");
					break;
				}
				stringBuilder.Append(unsupportedElement.Key + " at lines:");
				int num2 = 6;
				for (int i = 0; i < unsupportedElement.Value.Count; i++)
				{
					stringBuilder.Append(((i == 0) ? " " : ", ") + unsupportedElement.Value[i]);
					if (i >= num2)
					{
						int num3 = unsupportedElement.Value.Count - num2 - 1;
						if (num3 > 0)
						{
							stringBuilder.Append(" and " + num3 + " more lines.");
						}
						break;
					}
				}
				stringBuilder.Append("\n\n");
			}
			errors = stringBuilder.ToString();
			unsupportedElements = null;
		}

		public void WarnAboutUnsupportedFeature(string featureDescription, XmlReader reader = null)
		{
			if (GlobalSettings.Get().levelOfLog >= LogLevel.ERRORS_AND_WARNINGS && reader != null)
			{
				if (featureDescription.Contains(":"))
				{
					featureDescription = "namespaces are not supported. Using namespace " + featureDescription.Substring(0, featureDescription.IndexOf(":"));
				}
				if (unsupportedElements == null)
				{
					unsupportedElements = new Dictionary<string, List<int>>();
				}
				if (!unsupportedElements.ContainsKey(featureDescription))
				{
					unsupportedElements.Add(featureDescription, new List<int>());
				}
				unsupportedElements[featureDescription].Add(((IXmlLineInfo)reader).LineNumber);
			}
		}

		public bool Build()
		{
			if (document == null)
			{
				Debug.LogError("Document has not been imported");
				return false;
			}
			if (!BuildMeshFromDocument(document, out mesh, out collisionShapeData, moveByPivot: true))
			{
				Debug.LogError("Failed to build a mesh from the document at " + name);
				return false;
			}
			meshLayers.Clear();
			collisionShapeDataLayers.Clear();
			if (importSettings.splitMeshesByLayers)
			{
				for (int i = 0; i < svgDocumentLayers.Count; i++)
				{
					Mesh item = null;
					CollisionShapeData collisionData = null;
					if (!BuildMeshFromDocument(svgDocumentLayers[i], out item, out collisionData, moveByPivot: false))
					{
						Debug.LogError("Failed to build a mesh from the layer at " + name + " layer " + i);
					}
					meshLayers.Add(item);
					collisionShapeDataLayers.Add(collisionData);
					names.Add(svgDocumentLayers[i].GetRootID());
				}
			}
			return true;
		}

		public bool BuildMeshFromDocument(SVGDocument document, out Mesh mesh, out CollisionShapeData collisionData, bool moveByPivot)
		{
			mesh = null;
			collisionData = null;
			List<Vector3> meshVertices = new List<Vector3>();
			List<int> meshTriangles = new List<int>();
			List<Color> meshVertexColors = new List<Color>();
			if (!document.Triangulate(importSettings, ref meshVertices, ref meshTriangles, ref meshVertexColors))
			{
				Debug.LogError("Triangulating the document failed");
				return false;
			}
			if (meshVertices.Count > 65534)
			{
				Debug.LogError("Triangulation produced a mesh with more than 65534 vertices. This is a limit imposed by Unity. Cannot continue. " + name);
				return false;
			}
			if (meshVertices.Count < 3)
			{
				Debug.LogError("Less than 3 vertices were produced when triangulating the document. A mesh cannot be created.");
				return false;
			}
			Vector3 vector = meshVertices[0];
			Vector3 vector2 = meshVertices[0];
			for (int i = 0; i < meshVertices.Count; i++)
			{
				Vector3 vector3 = meshVertices[i];
				vector2.x = Mathf.Min(vector2.x, vector3.x);
				vector2.y = Mathf.Min(vector2.y, vector3.y);
				vector2.z = Mathf.Min(vector2.z, vector3.z);
				vector.x = Mathf.Max(vector.x, vector3.x);
				vector.y = Mathf.Max(vector.y, vector3.y);
				vector.z = Mathf.Max(vector.z, vector3.z);
			}
			Vector3 vector4 = new Vector3(Mathf.Abs(vector.x - vector2.x), Mathf.Abs(vector.y - vector2.y), 0f);
			Vector3 vector5 = new Vector3(vector2.x + importSettings.pivot.x * vector4.x, vector.y - importSettings.pivot.y * vector4.y, 0f);
			Vector3 vector6 = vector2 - vector5;
			Vector3 vector7 = vector - vector5;
			List<Vector2> list = new List<Vector2>(meshVertices.Count);
			for (int j = 0; j < meshVertices.Count; j++)
			{
				list.Add(new Vector2((meshVertices[j].x - vector2.x) / vector4.x, (meshVertices[j].y - vector2.y) / vector4.y));
				if (moveByPivot)
				{
					meshVertices[j] -= vector5;
				}
				meshVertices[j] *= importSettings.scale;
			}
			Color32[] array = new Color32[meshVertexColors.Count];
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = meshVertexColors[k];
			}
			mesh = new Mesh();
			mesh.SetVertices(meshVertices);
			mesh.SetTriangles(meshTriangles, 0);
			mesh.colors32 = array;
			mesh.SetUVs(0, list);
			if (moveByPivot)
			{
				mesh.bounds = new Bounds((vector6 + (vector7 - vector6) / 2f) * importSettings.scale, vector4 * importSettings.scale);
			}
			else
			{
				mesh.bounds = new Bounds((vector2 + (vector - vector2) / 2f) * importSettings.scale, vector4 * importSettings.scale);
			}
			List<Vector2> polygon = ConvexHullUtility.QuickHull(meshVertices);
			collisionData = ScriptableObject.CreateInstance<CollisionShapeData>();
			collisionData.Add(polygon);
			return true;
		}
	}
}
