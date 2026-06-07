using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Craft.Parts.Styles.Editor
{
	public class PartDefinitionStyles : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("A value indicating if the subparts all share a single part style header in the part properties flyout in the designer.")]
		private bool _stylesShareHeader;

		[SerializeField]
		[Tooltip("The collection of subparts and the subpart styles definined for this part.")]
		private List<PartDefinitionSubpart> _styleSubparts = new List<PartDefinitionSubpart>();

		[SerializeField]
		[Tooltip("A value indicating if all subparts of this part share a single part style.")]
		private bool _subpartsSharePartStyle;

		public bool StylesShareHeader => _stylesShareHeader;

		public List<PartDefinitionSubpart> StyleSubparts => _styleSubparts;

		public bool SubpartsSharePartStyle => _subpartsSharePartStyle;

		public XElement GeneratePartStylesXml()
		{
			XElement xElement = new XElement("PartStyles");
			for (int i = 0; i < StyleSubparts.Count; i++)
			{
				XElement xElement2 = new XElement("SubpartStyles", new XAttribute("subpartIndex", i));
				xElement.Add(xElement2);
				PartDefinitionSubpart partDefinitionSubpart = StyleSubparts[i];
				foreach (PartStyleDefinition item in partDefinitionSubpart?.Styles?.Styles ?? new List<PartStyleDefinition>(0))
				{
					if (item == null)
					{
						continue;
					}
					XElement xElement3 = new XElement("Style", new XAttribute("id", item.Id), new XAttribute("displayName", item.DisplayName));
					if (item.Hidden)
					{
						xElement3.Add(new XAttribute("hidden", item.Hidden));
					}
					xElement2.Add(xElement3);
					List<string> list = partDefinitionSubpart.Styles?.DataKeys ?? new List<string>(0);
					if (list.Count > 0)
					{
						XElement xElement4 = new XElement("Data");
						xElement3.Add(xElement4);
						for (int j = 0; j < list.Count; j++)
						{
							string value = list[j];
							string value2 = (((item.DataValues?.Count ?? 0) > j) ? item.DataValues[j] : null);
							xElement4.Add(new XElement("DataItem", new XAttribute("key", value), new XAttribute("value", value2)));
						}
					}
					List<PartTextureStyleDefinition> list2 = item.Textures ?? new List<PartTextureStyleDefinition>(0);
					if (list2.Count > 0)
					{
						xElement3.Add(new XElement("TextureStyles", from x in list2
							where x != null
							select new XElement("TextureStyle", new XAttribute("id", x.Id))));
					}
				}
			}
			return xElement;
		}

		public XElement GeneratePartTypeStylesXml()
		{
			XElement xElement = new XElement("PartTypeStyles", new XAttribute("subpartsSharePartStyle", _subpartsSharePartStyle), new XAttribute("stylesShareHeader", _stylesShareHeader));
			SubpartType.SaveToXml(xElement, StyleSubparts.Select((PartDefinitionSubpart x) => SubpartType.Create(x.XmlName, x.DisplayName)).ToList());
			return xElement;
		}

		public void Load(PartType partType, XElement partStyles)
		{
			List<Transform> list = new List<Transform>(base.transform.childCount);
			foreach (Transform item in base.transform)
			{
				list.Add(item);
			}
			list.ForEach(delegate(Transform x)
			{
				UnityEngine.Object.DestroyImmediate(x.gameObject);
			});
			_stylesShareHeader = partType.StylesShareHeader;
			_subpartsSharePartStyle = partType.SubpartsSharePartStyle;
			Dictionary<string, PartTextureStyleDefinition> dictionary = AssetDatabase.FindAssets<PartTextureStyleDefinition>(Array.Empty<string>()).ToDictionary((PartTextureStyleDefinition x) => x.Id, (PartTextureStyleDefinition x) => x);
			_styleSubparts = new List<PartDefinitionSubpart>(partType.Subparts.Count);
			int i = 0;
			while (i < partType.Subparts.Count)
			{
				SubpartType subpartType = partType.Subparts[i];
				GameObject obj = new GameObject(subpartType.DisplayName);
				obj.transform.SetParent(base.transform, worldPositionStays: false);
				PartStyleSetDefinition partStyleSetDefinition = PartStyleSetDefinition.Create(obj);
				_styleSubparts.Add(new PartDefinitionSubpart(subpartType.XmlNames.Base, subpartType.DisplayName, partStyleSetDefinition));
				XElement xElement = partStyles.Elements("SubpartStyles").FirstOrDefault((XElement x) => (int)x.Attribute("subpartIndex") == i);
				if (xElement == null)
				{
					Debug.LogError($"Unable to find the subpart style for subpart index '{i}'.");
				}
				else
				{
					List<string> collection = (from x in xElement.Element("Style")?.Element("Data")?.Elements("DataItem")
						select (string)x.Attribute("key")).ToList() ?? new List<string>(0);
					partStyleSetDefinition.DataKeys.AddRange(collection);
					foreach (XElement item2 in xElement.Elements("Style"))
					{
						PartStyleDefinition partStyleDefinition = PartStyleDefinition.Create((string)item2.Attribute("id"), (string)item2.Attribute("displayName"), (bool?)item2.Attribute("hidden") == true);
						partStyleSetDefinition.Styles.Add(partStyleDefinition);
						List<string> collection2 = (from x in item2?.Element("Data")?.Elements("DataItem")
							select (string)x.Attribute("value")).ToList() ?? new List<string>(0);
						partStyleDefinition.DataValues.AddRange(collection2);
						foreach (string item3 in (from x in item2.Elements("TextureStyles").Elements("TextureStyle")
							select (string)x.Attribute("id")).ToList())
						{
							if (dictionary.TryGetValue(item3, out var value))
							{
								partStyleDefinition.Textures.Add(value);
							}
							else
							{
								Debug.LogError("Unable to find part texture style with ID '" + item3 + "'");
							}
						}
					}
				}
				int num = i + 1;
				i = num;
			}
		}
	}
}
