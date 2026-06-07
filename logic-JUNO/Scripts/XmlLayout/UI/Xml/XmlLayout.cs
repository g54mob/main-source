using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using ModApi;
using ModApi.Common;
using ModApi.State;
using ModApi.Ui;
using UI.Xml.Tags;
using UnityEngine;

namespace UI.Xml
{
	[ExecuteInEditMode]
	public class XmlLayout : MonoBehaviour, IXmlLayout
	{
		public XmlLayoutLocalization LocalizationFile;

		public bool editor_showLocalization;

		public List<XmlElementDataSource> ElementDataSources = new List<XmlElementDataSource>();

		[Tooltip("If this is set to true, then XmlLayout will preload some of its functionality in advance. This will mean that there will be a slight performance hit the first time an XmlLayout is loaded. Without the preload, there will be a minor performance hit each time a new Xml Tag type is parsed.")]
		public bool PreloadXmlLayoutCache = true;

		public TextAsset XmlFile;

		[Tooltip("Automatically reload Xml file if it is changed? Note: This will override the Xml property, and it will only work in the Unity Editor.")]
		public bool AutomaticallyReloadXmlFileIfItChanges = true;

		[Tooltip("If set to true, this XmlLayout will automatically rebuild when Awake() is called. This should always be set if this XmlLayout loads data dynamically.")]
		public bool ForceRebuildOnAwake = true;

		[Tooltip("If set to true, this XmlLayout will automatically reload the Xml from the XmlFile when Awake() is called.")]
		public bool ForceReloadXmlFileOnAwake;

		[TextArea]
		public string Xml = "<XmlLayout>\r\n</XmlLayout>";

		[Tooltip("An optional list of Xml files which contain default values (such as element styles).")]
		public List<TextAsset> DefaultsFiles;

		[SerializeField]
		[HideInInspector]
		public List<string> IncludedFiles = new List<string>();

		public bool editor_showXml;

		public Vector2 editor_xmlScrollPosition;

		[SerializeField]
		private string previousXml = string.Empty;

		[SerializeField]
		public ElementDictionary ElementsById = new ElementDictionary();

		private XmlLayoutController _xmlLayoutController;

		private XmlElement m_XmlElement;

		[SerializeField]
		public DefaultAttributeValueDictionary defaultAttributeValues = new DefaultAttributeValueDictionary();

		private bool m_awake;

		protected XmlLayoutTooltip m_Tooltip;

		[SerializeField]
		protected AttributeDictionary m_defaultTooltipAttributes = new AttributeDictionary();

		public ColorDictionary namedColors = new ColorDictionary();

		public MaterialDictionary textMeshProMaterials = new MaterialDictionary();

		[SerializeField]
		protected bool m_useUnscaledTime = true;

		public List<string> ChildElementXmlFiles = new List<string>();

		private Dictionary<string, List<KeyValuePair<string, AttributeDictionary>>> cachedPotentialSelectors = new Dictionary<string, List<KeyValuePair<string, AttributeDictionary>>>();

		private Regex SelectorSplitter = new Regex("(?<=[>:])");

		private Dictionary<string, string[]> cachedSelectorParts = new Dictionary<string, string[]>();

		private AttributeDictionary defaultAttributesMergedCache = new AttributeDictionary();

		private static int _tooltipId = 0;

		protected XmlElement m_CurrentTooltipElement;

		GameObject IXmlLayout.GameObject => base.gameObject;

		IXmlLayout IXmlLayout.ParentLayout => ParentLayout;

		string IXmlLayout.Xml
		{
			get
			{
				return Xml;
			}
			set
			{
				Xml = value;
			}
		}

		IXmlLayoutController IXmlLayout.XmlLayoutController => XmlLayoutController;

		public XmlLayoutController XmlLayoutController
		{
			get
			{
				if (_xmlLayoutController == null)
				{
					_xmlLayoutController = GetComponent<XmlLayoutController>();
				}
				return _xmlLayoutController;
			}
		}

		public XmlElement XmlElement
		{
			get
			{
				if (m_XmlElement == null)
				{
					InitialiseXmlElement();
				}
				return m_XmlElement;
			}
		}

		public XmlLayout ParentLayout { get; internal set; }

		public bool IsReady { get; protected set; }

		public XmlLayoutTooltip Tooltip
		{
			get
			{
				if (m_Tooltip == null)
				{
					CreateTooltipObject();
				}
				return m_Tooltip;
			}
		}

		public bool rebuildInProgress { get; private set; }

		protected bool rebuildScheduled { get; private set; }

		public bool UseUnscaledTime
		{
			get
			{
				return m_useUnscaledTime;
			}
			internal set
			{
				m_useUnscaledTime = value;
			}
		}

		public static bool TooltipsEnabled { get; set; } = true;

		IXmlElement IXmlLayout.GetElementById(string id)
		{
			return GetElementById(id);
		}

		private bool PreprocessNode(string typeName, AttributeDictionary attributes)
		{
			string value = null;
			if (attributes.TryGetValue("device", out value))
			{
				bool flag = false;
				if (value.StartsWith("-"))
				{
					flag = true;
					value = value.Substring(1);
				}
				bool flag2 = true;
				if (value.Equals("ios", StringComparison.OrdinalIgnoreCase))
				{
					flag2 = Device.IsIosBuild;
				}
				else if (value.Equals("android", StringComparison.OrdinalIgnoreCase))
				{
					flag2 = Device.IsAndroidBuild;
				}
				else if (value.Equals("mobile", StringComparison.OrdinalIgnoreCase))
				{
					flag2 = Device.IsMobileBuild;
				}
				else if (value.Equals("mac", StringComparison.OrdinalIgnoreCase))
				{
					flag2 = Device.IsOsxBuild;
				}
				else if (value.Equals("windows", StringComparison.OrdinalIgnoreCase))
				{
					flag2 = Device.IsWindowsBuild;
				}
				else if (value.Equals("desktop", StringComparison.OrdinalIgnoreCase))
				{
					flag2 = !Device.IsMobileBuild;
				}
				return flag != flag2;
			}
			if (attributes.TryGetValue("gameMode", out var value2))
			{
				if (value2 == "sandbox")
				{
					return Game.Instance.GameState.Mode == GameStateMode.Sandbox;
				}
				if (value2 == "career")
				{
					return Game.Instance.GameState.Mode == GameStateMode.Career;
				}
			}
			return true;
		}

		protected string HandleLocalization(string xml)
		{
			if (LocalizationFile != null)
			{
				StringBuilder stringBuilder = new StringBuilder(xml);
				foreach (KeyValuePair<string, string> @string in LocalizationFile.strings)
				{
					stringBuilder.Replace("{" + $"{@string.Key}" + "}", @string.Value);
				}
				xml = stringBuilder.ToString();
			}
			return xml;
		}

		public void SetLocalizationFile(XmlLayoutLocalization newLocalizationFile)
		{
			LocalizationFile = newLocalizationFile;
			RebuildLayout(forceEvenIfXmlUnchanged: true);
		}

		public List<XmlElement> GetElementsForDataSource(string dataSource, string additionalDataSource = null)
		{
			return (from ed in ElementDataSources
				where ed.Matches(dataSource, additionalDataSource)
				where ed.XmlElement != null
				select ed.XmlElement).Distinct().ToList();
		}

		private void InitialiseXmlElement()
		{
			if (m_XmlElement == null)
			{
				m_XmlElement = GetComponent<XmlElement>();
			}
			if (m_XmlElement == null)
			{
				m_XmlElement = base.gameObject.AddComponent<XmlElement>();
				m_XmlElement.Initialise(this, base.transform as RectTransform, XmlLayoutUtilities.GetXmlTagHandler("XmlLayout"));
			}
		}

		private void Awake()
		{
			m_awake = true;
			if (Application.isPlaying)
			{
				if (PreloadXmlLayoutCache)
				{
					HandlePreload();
				}
				if (ForceRebuildOnAwake)
				{
					if (XmlFile != null && ForceReloadXmlFileOnAwake)
					{
						ReloadXmlFile();
					}
					else
					{
						RebuildLayout(forceEvenIfXmlUnchanged: true);
					}
				}
				XmlLayoutSelectableNavigator xmlLayoutSelectableNavigator = UnityEngine.Object.FindObjectOfType<XmlLayoutSelectableNavigator>();
				if (xmlLayoutSelectableNavigator != null && xmlLayoutSelectableNavigator.gameObject == base.gameObject)
				{
					UnityEngine.Object.DestroyImmediate(xmlLayoutSelectableNavigator);
					xmlLayoutSelectableNavigator = null;
				}
				if (xmlLayoutSelectableNavigator == null)
				{
					CreateSelectableNavigator();
				}
			}
			if (Application.isPlaying && !ForceRebuildOnAwake)
			{
				SetupElementEventHandlers();
				if (XmlLayoutController != null)
				{
					XmlLayoutTimer.DelayedCall(0.1f, delegate
					{
						XmlLayoutController.LayoutRebuilt(ParseXmlResult.Changed);
					}, this);
				}
			}
			IsReady = true;
		}

		public void ReloadXmlFile()
		{
			if (XmlFile != null)
			{
				Xml = XmlFile.text;
				RebuildLayout(forceEvenIfXmlUnchanged: true);
			}
		}

		private void CreateTooltipObject()
		{
			GameObject original = XmlLayoutUtilities.LoadResource<GameObject>("XmlLayout Prefabs/Tooltip");
			m_Tooltip = UnityEngine.Object.Instantiate(original).GetComponent<XmlLayoutTooltip>();
			m_Tooltip.transform.SetParent(base.transform);
			m_Tooltip.transform.localPosition = Vector3.zero;
			m_Tooltip.transform.localScale = Vector3.one;
			m_Tooltip.name = "Tooltip";
			m_Tooltip.gameObject.SetActive(value: false);
		}

		private void _Destroy(GameObject o)
		{
			if (!(o == null))
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(o);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(o);
				}
			}
		}

		private void CreateSelectableNavigator()
		{
			new GameObject("XmlLayoutSelectableNavigator", typeof(XmlLayoutSelectableNavigator)).transform.SetAsLastSibling();
		}

		private void ClearContents()
		{
			if (this == null)
			{
				return;
			}
			List<Transform> list = new List<Transform>();
			for (int i = 0; i < base.transform.childCount; i++)
			{
				Transform child = base.transform.GetChild(i);
				list.Add(child);
				child.transform.SetParent(null);
			}
			foreach (Transform item in list)
			{
				_Destroy(item.gameObject);
			}
			IncludedFiles.Clear();
			ElementsById.Clear();
			ElementDataSources.Clear();
			defaultAttributeValues.Clear();
			cachedPotentialSelectors.Clear();
			if (m_Tooltip != null)
			{
				_Destroy(m_Tooltip.gameObject);
			}
		}

		public void RebuildLayout(bool forceEvenIfXmlUnchanged = false, bool throwExceptionIfXmlIsInvalid = false)
		{
			if ((!forceEvenIfXmlUnchanged && (!base.gameObject.activeInHierarchy || !m_awake)) || rebuildInProgress)
			{
				return;
			}
			rebuildInProgress = true;
			XmlElement.childElements.Clear();
			ChildElementXmlFiles.Clear();
			try
			{
				ParseXmlResult parseResult = ParseXml(null, clearContents: true, loadDefaultsFiles: true, forceEvenIfXmlUnchanged, throwExceptionIfXmlIsInvalid);
				if (XmlLayoutController != null)
				{
					XmlLayoutController.ViewModelUpdated(triggerLayoutRebuild: false);
					XmlLayoutController.NotifyXmlElementReferencesOfLayoutRebuild();
					XmlLayoutController.PreLayoutRebuilt();
					XmlLayoutController.LayoutRebuilt(parseResult);
					XmlLayoutController.PostLayoutRebuilt();
				}
			}
			finally
			{
				rebuildInProgress = false;
			}
		}

		private ParseXmlResult ParseXml(string xmlToParse = null, bool clearContents = true, bool loadDefaultsFiles = true, bool forceEvenIfXmlUnchanged = false, bool throwExceptionIfXmlIsInvalid = false)
		{
			if (xmlToParse == null)
			{
				if (!forceEvenIfXmlUnchanged && previousXml.Equals(Xml))
				{
					return ParseXmlResult.Unchanged;
				}
				previousXml = Xml;
				xmlToParse = Xml;
			}
			if (XmlLayoutController != null)
			{
				xmlToParse = XmlLayoutController.ProcessViewModel(xmlToParse);
			}
			if (LocalizationFile != null)
			{
				xmlToParse = HandleLocalization(xmlToParse);
			}
			if (clearContents)
			{
				for (int i = 0; i < 2; i++)
				{
					ClearContents();
				}
			}
			if (loadDefaultsFiles && DefaultsFiles != null)
			{
				defaultAttributeValues.Clear();
				DefaultsFiles.ForEach(delegate(TextAsset f)
				{
					if (f != null)
					{
						ParseXml(f.text, clearContents: false, loadDefaultsFiles: false, forceEvenIfXmlUnchanged: true);
					}
				});
			}
			RectTransform rectTransform = base.transform as RectTransform;
			using (StringReader input = new StringReader(xmlToParse))
			{
				XmlReaderSettings settings = new XmlReaderSettings
				{
					IgnoreWhitespace = true,
					IgnoreComments = true,
					IgnoreProcessingInstructions = true
				};
				using XmlReader xmlReader = XmlReader.Create(input, settings);
				xmlReader.ReadToFollowing("XmlLayout");
				ParseNode(xmlReader, rectTransform, rectTransform);
			}
			return ParseXmlResult.Changed;
		}

		private string CleanupTextAttribute(string text)
		{
			text = text.Trim();
			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}
			while (text.Contains("\r\n "))
			{
				text = text.Replace("\r\n ", "\r\n");
			}
			return text;
		}

		internal List<KeyValuePair<string, AttributeDictionary>> GetPotentialSelectors(string elementType, string _class)
		{
			string key = $"{elementType}>{_class}";
			if (cachedPotentialSelectors.ContainsKey(key))
			{
				return cachedPotentialSelectors[key];
			}
			List<KeyValuePair<string, AttributeDictionary>> list = new List<KeyValuePair<string, AttributeDictionary>>();
			string value = $"@{elementType}";
			if (defaultAttributeValues.ContainsKey(elementType))
			{
				foreach (KeyValuePair<string, AttributeDictionary> item in defaultAttributeValues[elementType])
				{
					if (item.Key.EndsWith(_class, StringComparison.OrdinalIgnoreCase) || item.Key.EndsWith(value, StringComparison.OrdinalIgnoreCase))
					{
						list.Add(item);
					}
				}
			}
			cachedPotentialSelectors.Add(key, list);
			return list;
		}

		internal string[] GetSelectorParts(string selector)
		{
			if (cachedSelectorParts.ContainsKey(selector))
			{
				return cachedSelectorParts[selector];
			}
			string[] array = SelectorSplitter.Split(selector);
			Array.Reverse(array);
			cachedSelectorParts.Add(selector, array);
			return array;
		}

		internal string GetAttributeValueForNode_IncludingDefaults(string type, AttributeDictionary attributes, string attributeName, XmlElement parentElement)
		{
			string value = attributes.GetValue(attributeName);
			if (string.IsNullOrEmpty(value) && defaultAttributeValues.ContainsKey(type))
			{
				if (defaultAttributeValues[type].ContainsKey("all"))
				{
					value = defaultAttributeValues[type]["all"].GetValue(attributeName);
				}
				List<string> list = (attributes.ContainsKey("class") ? attributes["class"].ToClassList() : new List<string>());
				list.Remove("all");
				list.Insert(0, "all");
				foreach (string item in list)
				{
					foreach (KeyValuePair<string, AttributeDictionary> potentialSelector in GetPotentialSelectors(type, item))
					{
						if (!potentialSelector.Value.ContainsKey(attributeName))
						{
							continue;
						}
						bool flag = true;
						string[] selectorParts = GetSelectorParts(potentialSelector.Key);
						if (selectorParts.Count() == 1)
						{
							if (!selectorParts[0].StripChars('>', ':').Equals(item, StringComparison.OrdinalIgnoreCase))
							{
								flag = false;
							}
						}
						else
						{
							bool flag2 = true;
							XmlElement xmlElement = null;
							string text = type;
							string[] array = selectorParts;
							foreach (string text2 in array)
							{
								string text3 = text2.StripChars('>', ':');
								bool flag3 = text3.StartsWith("@");
								if (flag3)
								{
									text3 = text3.Substring(1);
								}
								if (text2.EndsWith(">"))
								{
									xmlElement = ((!(xmlElement == null)) ? xmlElement.parentElement : (xmlElement = parentElement));
								}
								else if (text2.EndsWith(":"))
								{
									bool flag4 = false;
									bool flag5 = true;
									while (!flag4 && (flag5 || xmlElement != null))
									{
										xmlElement = ((!flag5 || !(xmlElement == null)) ? xmlElement.parentElement : (xmlElement = parentElement));
										if (xmlElement != null)
										{
											if (xmlElement != null)
											{
												text = xmlElement.tagType;
											}
											flag4 = ((!flag3) ? xmlElement.HasClass(text3) : text.Equals(text3, StringComparison.OrdinalIgnoreCase));
										}
										flag5 = false;
									}
								}
								if (!flag2 && xmlElement == null)
								{
									flag = false;
									break;
								}
								if (xmlElement != null)
								{
									text = xmlElement.tagType;
								}
								if (flag3)
								{
									if (!text.Equals(text3, StringComparison.OrdinalIgnoreCase))
									{
										flag = false;
									}
								}
								else if (flag2)
								{
									if (!list.Contains(text3))
									{
										flag = false;
									}
								}
								else if (xmlElement != null && !xmlElement.HasClass(text3))
								{
									flag = false;
								}
								flag2 = false;
							}
						}
						if (flag)
						{
							value = potentialSelector.Value.GetValue(attributeName);
						}
					}
				}
			}
			return value;
		}

		internal AttributeDictionary MergeDefaultAttributesWithElementAttributes(XmlElement xmlElement, string elementType, AttributeDictionary elementAttributes)
		{
			defaultAttributesMergedCache.Clear();
			AttributeDictionary attributeDictionary = defaultAttributesMergedCache;
			AttributeDictionary result = elementAttributes;
			if (defaultAttributeValues.ContainsKey(elementType))
			{
				if (defaultAttributeValues[elementType].ContainsKey("all"))
				{
					attributeDictionary = defaultAttributeValues[elementType]["all"].Clone();
				}
				List<string> obj = (elementAttributes.ContainsKey("class") ? elementAttributes["class"].ToClassList() : new List<string>());
				List<string> classes = xmlElement.classes;
				List<string> list = obj;
				list.AddRange(classes);
				list.Remove("all");
				if (list.Count > 1 && defaultAttributeValues.ContainsKey(elementType))
				{
					list = (from c in list.Distinct()
						orderby (!defaultAttributeValues[elementType].order.ContainsKey(c)) ? int.MaxValue : defaultAttributeValues[elementType].order[c]
						select c).ToList();
				}
				list.Insert(0, "all");
				foreach (string item in list)
				{
					foreach (KeyValuePair<string, AttributeDictionary> potentialSelector in GetPotentialSelectors(elementType, item))
					{
						bool flag = true;
						string[] selectorParts = GetSelectorParts(potentialSelector.Key);
						if (selectorParts.Count() == 1)
						{
							if (!selectorParts[0].StripChars('>', ':').Equals(item, StringComparison.OrdinalIgnoreCase))
							{
								flag = false;
							}
						}
						else
						{
							XmlElement xmlElement2 = xmlElement;
							string[] array = selectorParts;
							foreach (string text in array)
							{
								string text2 = text.StripChars('>', ':');
								bool flag2 = text2.StartsWith("@");
								if (flag2)
								{
									text2 = text2.Substring(1);
								}
								if (text.EndsWith(">"))
								{
									xmlElement2 = xmlElement2.parentElement;
								}
								else if (text.EndsWith(":"))
								{
									bool flag3 = false;
									while (!flag3 && xmlElement2 != null)
									{
										xmlElement2 = xmlElement2.parentElement;
										if (xmlElement2 != null)
										{
											flag3 = ((!flag2) ? xmlElement2.HasClass(text2) : xmlElement2.tagType.Equals(text2, StringComparison.OrdinalIgnoreCase));
										}
									}
								}
								if (xmlElement2 == null)
								{
									flag = false;
									break;
								}
								if (flag2)
								{
									if (!xmlElement2.tagType.Equals(text2, StringComparison.OrdinalIgnoreCase))
									{
										flag = false;
									}
								}
								else if (!xmlElement2.HasClass(text2))
								{
									flag = false;
								}
							}
						}
						if (flag)
						{
							attributeDictionary.Merge(potentialSelector.Value);
						}
					}
				}
				result = XmlLayoutUtilities.MergeAttributes(attributeDictionary, elementAttributes);
			}
			return result;
		}

		private bool ElementMatchesSelectorPattern(XmlElement element, string pattern)
		{
			if (pattern.StartsWith("@"))
			{
				return element.tagType == pattern.Replace("@", string.Empty);
			}
			return element.HasClass(pattern);
		}

		private void LoadIncludeFile(string path)
		{
			TextAsset textAsset = Resources.Load(path) as TextAsset;
			if (textAsset == null)
			{
				Debug.LogError("[XmlLayout] Unable to locate xml file using path '" + path + "'. Please ensure that the file is located within a Resources folder.");
				return;
			}
			ParseXml(textAsset.text, clearContents: false, loadDefaultsFiles: false, forceEvenIfXmlUnchanged: true);
			if (!IncludedFiles.Contains(path))
			{
				IncludedFiles.Add(path);
			}
		}

		private void LoadInlineIncludeFile(string path, RectTransform parent)
		{
			path = path.Replace(".xml", string.Empty);
			TextAsset textAsset = XmlLayoutResourceDatabase.instance.LoadXml(path);
			if (textAsset == null)
			{
				Debug.LogError($"[XmlLayout][{base.name}] Error locating include file : '{path}'.");
				return;
			}
			ChildElementXmlFiles.Add(path);
			using StringReader input = new StringReader(textAsset.text);
			XmlReaderSettings settings = new XmlReaderSettings
			{
				IgnoreWhitespace = true,
				IgnoreComments = true,
				IgnoreProcessingInstructions = true
			};
			using XmlReader xmlReader = XmlReader.Create(input, settings);
			xmlReader.MoveToContent();
			while (xmlReader.Read())
			{
				if (xmlReader.IsStartElement())
				{
					using XmlReader xmlReader2 = xmlReader.ReadSubtree();
					xmlReader2.Read();
					ParseNode(xmlReader2, parent);
				}
			}
		}

		internal void ParseNode(XmlReader reader, RectTransform parent, RectTransform element = null, bool parseChildren = true, XmlElement parentXmlElement = null)
		{
			string text = reader.Name;
			if (text.Equals("Defaults", StringComparison.OrdinalIgnoreCase))
			{
				HandleDefaults(reader);
				return;
			}
			AttributeDictionary attributeDictionary = reader.GetAttributeDictionary();
			if (!PreprocessNode(text, attributeDictionary))
			{
				return;
			}
			if (text.Equals("Include", StringComparison.OrdinalIgnoreCase))
			{
				LoadInlineIncludeFile(attributeDictionary.GetValue("path"), parent);
				return;
			}
			ElementTagHandler xmlTagHandler = XmlLayoutUtilities.GetXmlTagHandler(text);
			if (xmlTagHandler == null)
			{
				return;
			}
			xmlTagHandler.SetInstance(element, this);
			XmlElement xmlElement = null;
			if (element == null)
			{
				string attributeValueForNode_IncludingDefaults = GetAttributeValueForNode_IncludingDefaults(text, attributeDictionary, "prefabPath", parentXmlElement);
				xmlElement = xmlTagHandler.GetInstance(parent, this, attributeValueForNode_IncludingDefaults);
				if (parentXmlElement != null)
				{
					parentXmlElement.AddChildElement(xmlElement, adjustRectTransform: false);
				}
			}
			RectTransform instanceTransform = element ?? xmlElement.rectTransform;
			xmlTagHandler.SetInstance(instanceTransform, this);
			if (xmlElement != null)
			{
				xmlElement.attributes = attributeDictionary;
				xmlElement.DataSource = xmlElement.GetAttribute("vm-dataSource");
			}
			xmlTagHandler.Open(attributeDictionary);
			if (xmlTagHandler.UseParseChildElements)
			{
				reader.MoveToContent();
				XmlNode xmlNode = new XmlDocument().ReadNode(reader);
				xmlTagHandler.ParseChildElements(xmlNode);
				parseChildren = false;
			}
			if (parseChildren)
			{
				while (reader.Read())
				{
					if (reader.IsStartElement())
					{
						using XmlReader xmlReader = reader.ReadSubtree();
						xmlReader.Read();
						xmlTagHandler.SetInstance(instanceTransform, this);
						ParseNode(xmlReader, xmlTagHandler.transformToAddChildrenTo, null, parseChildren: true, xmlElement);
					}
					else if (reader.NodeType != XmlNodeType.EndElement)
					{
						attributeDictionary["text"] = CleanupTextAttribute(reader.ReadContentAsString());
					}
				}
			}
			xmlTagHandler.SetInstance(instanceTransform, this);
			if (attributeDictionary.ContainsKey("id"))
			{
				if (ElementsById.ContainsKey(attributeDictionary["id"]))
				{
					Debug.LogError("[XmlLayout] Ignoring duplicate id value '" + attributeDictionary["id"] + ". Id values must be unique.");
				}
				else if (xmlElement != null)
				{
					ElementsById.Add(attributeDictionary["id"], xmlElement);
				}
			}
			if (xmlElement != null)
			{
				xmlElement.elementAttributes = attributeDictionary.Keys.ToList();
			}
			attributeDictionary = MergeDefaultAttributesWithElementAttributes(xmlElement, text, attributeDictionary);
			if (xmlElement != null)
			{
				if (xmlElement.HasAttribute("class"))
				{
					xmlElement.classes = xmlElement.GetAttribute("class").ToClassList();
				}
				if (attributeDictionary.ContainsKey("hoverClass"))
				{
					List<string> hoverClasses = (from s in attributeDictionary["hoverClass"].Split(',', ' ')
						select s.Trim().ToLower() into c
						where !string.IsNullOrEmpty(c)
						select c).ToList();
					xmlElement.hoverClasses = hoverClasses;
				}
				if (attributeDictionary.ContainsKey("selectClass"))
				{
					List<string> selectClasses = (from s in attributeDictionary["selectClass"].Split(',', ' ')
						select s.Trim().ToLower() into c
						where !string.IsNullOrEmpty(c)
						select c).ToList();
					xmlElement.selectClasses = selectClasses;
				}
				if (attributeDictionary.ContainsKey("pressClass"))
				{
					List<string> pressClasses = (from s in attributeDictionary["pressClass"].Split(',', ' ')
						select s.Trim().ToLower() into c
						where !string.IsNullOrEmpty(c)
						select c).ToList();
					xmlElement.pressClasses = pressClasses;
				}
				xmlElement.ApplyAttributes(attributeDictionary);
			}
			else
			{
				xmlTagHandler.ApplyAttributes(attributeDictionary);
			}
			xmlTagHandler.Close();
			if (!xmlTagHandler.renderElement)
			{
				xmlTagHandler.RemoveElement();
			}
		}

		private void HandleDefaults(XmlReader defaultsReader)
		{
			while (defaultsReader.Read())
			{
				if (defaultsReader.IsStartElement())
				{
					string text = defaultsReader.Name;
					AttributeDictionary attributeDictionary = defaultsReader.GetAttributeDictionary();
					switch (text)
					{
					case "Color":
						HandleColorNode(attributeDictionary);
						break;
					case "Tooltip":
						HandleDefaultTooltipNode(attributeDictionary);
						break;
					case "TextMeshProMaterial":
						HandleTextMeshProMaterialNode(attributeDictionary);
						break;
					default:
						HandleDefaultNode(text, attributeDictionary);
						break;
					}
				}
			}
		}

		private void HandleDefaultTooltipNode(AttributeDictionary attributes)
		{
			if (PreprocessNode("Tooltip", attributes))
			{
				m_defaultTooltipAttributes = attributes;
			}
		}

		private void HandleDefaultNode(string type, AttributeDictionary attributes)
		{
			if (!PreprocessNode(type, attributes) || XmlLayoutUtilities.GetXmlTagHandler(type) == null)
			{
				return;
			}
			foreach (string item in attributes.ContainsKey("class") ? attributes["class"].ToClassList() : new List<string> { "all" })
			{
				if (!defaultAttributeValues.ContainsKey(type))
				{
					defaultAttributeValues.Add(type, new ClassAttributeCollectionDictionary());
				}
				if (!defaultAttributeValues[type].ContainsKey(item))
				{
					defaultAttributeValues[type].Add(item, new AttributeDictionary());
				}
				defaultAttributeValues[type][item] = XmlLayoutUtilities.MergeAttributes(defaultAttributeValues[type][item], attributes);
				defaultAttributeValues[type][item].Remove("class");
			}
		}

		private void HandleTextMeshProMaterialNode(AttributeDictionary attributes)
		{
			Material material = TextMeshProMaterialTagHandler.CreateMaterial(this, attributes);
			if (material != null)
			{
				textMeshProMaterials.SetValue(attributes["name"], material);
			}
		}

		private void HandleColorNode(AttributeDictionary attributes)
		{
			if (!attributes.ContainsKey("name") || !attributes.ContainsKey("color"))
			{
				Debug.LogWarning("[XmlLayout] Warning: Named Color tag without a name and/or color - both are required.");
			}
			else if (namedColors.ContainsKey(attributes["name"]))
			{
				namedColors[attributes["name"]] = attributes["color"].ToColor(this);
			}
			else
			{
				namedColors.Add(attributes["name"], attributes["color"].ToColor(this));
			}
		}

		public XmlElement GetElementById(string id)
		{
			if (ElementsById.ContainsKey(id))
			{
				return ElementsById[id];
			}
			return null;
		}

		public T GetElementById<T>(string id)
		{
			if (ElementsById.ContainsKey(id))
			{
				T component = ElementsById[id].GetComponent<T>();
				if (component != null)
				{
					return component;
				}
			}
			return default(T);
		}

		public List<XmlElement> GetElementsByClass(string _class)
		{
			return XmlElement.GetChildElementsWithClass(_class);
		}

		public string GetElementId(RectTransform element)
		{
			if (ElementsById.Any((KeyValuePair<string, XmlElement> e) => e.Value.rectTransform == element))
			{
				return ElementsById.First((KeyValuePair<string, XmlElement> kvp) => kvp.Value.rectTransform == element).Key;
			}
			return null;
		}

		public Dictionary<string, string> GetFormData()
		{
			return XmlElement.GetFormData(XmlElement.eLocateElementsBy.Id);
		}

		private void RebuildLayoutDelayed()
		{
			if (rebuildScheduled)
			{
				return;
			}
			rebuildScheduled = true;
			XmlLayoutTimer.AtEndOfFrame(delegate
			{
				try
				{
					RebuildLayout(forceEvenIfXmlUnchanged: true);
				}
				finally
				{
					rebuildScheduled = false;
				}
			}, this);
		}

		public void Show(Action onCompleteCallback = null, bool forceEvenIfVisible = false)
		{
			XmlElement.Show(recursiveCall: false, onCompleteCallback, forceEvenIfVisible);
		}

		public void Hide(Action onCompleteCallback = null, bool forceEvenIfNotVisible = false)
		{
			XmlElement.Hide(recursiveCall: false, onCompleteCallback, forceEvenIfNotVisible);
		}

		private void HandlePreload()
		{
			XmlLayoutPreloader xmlLayoutPreloader = GetComponent<XmlLayoutPreloader>();
			if (xmlLayoutPreloader == null)
			{
				xmlLayoutPreloader = UnityEngine.Object.FindObjectOfType<XmlLayoutPreloader>();
			}
			if (xmlLayoutPreloader == null)
			{
				xmlLayoutPreloader = base.gameObject.AddComponent<XmlLayoutPreloader>();
				xmlLayoutPreloader.Preload();
			}
		}

		public void ShowTooltip(XmlElement element, string tooltipContent)
		{
			if (!TooltipsEnabled)
			{
				return;
			}
			m_CurrentTooltipElement = element;
			if (ParentLayout != null)
			{
				ParentLayout.ShowTooltip(element, tooltipContent);
				return;
			}
			int tooltipId = ++_tooltipId;
			AttributeDictionary attributeDictionary = XmlLayoutUtilities.MergeAttributes(m_defaultTooltipAttributes, element.attributes);
			attributeDictionary.AddIfKeyNotExists("tooltipFontSize", "12");
			attributeDictionary.AddIfKeyNotExists("tooltipTextColor", "rgb(1,1,1)");
			attributeDictionary.AddIfKeyNotExists("tooltipUseTextMeshPro", "true");
			Tooltip.LoadAttributes(attributeDictionary);
			XmlLayoutTimer.DelayedCall(Tooltip.showDelayTime, delegate
			{
				if (!(m_CurrentTooltipElement != element) && tooltipId == _tooltipId)
				{
					Tooltip.FadeIn();
					Tooltip.SetText(tooltipContent);
					if (!Tooltip.followMouse)
					{
						Tooltip.SetPositionAdjacentTo(element);
						XmlLayoutTimer.AtEndOfFrame(delegate
						{
							Tooltip.SetPositionAdjacentTo(element);
						}, this);
					}
				}
			}, this);
		}

		internal void NotifyElementHidden(XmlElement element)
		{
			if (element == m_CurrentTooltipElement)
			{
				HideTooltip(element);
			}
		}

		public void HideTooltip(XmlElement sourceElement)
		{
			_tooltipId++;
			if (ParentLayout != null)
			{
				ParentLayout.HideTooltip(sourceElement);
			}
			if (sourceElement == m_CurrentTooltipElement)
			{
				Tooltip.FadeOut();
				m_CurrentTooltipElement = null;
			}
		}

		private void SetupElementEventHandlers()
		{
			SetupElementEventHandlers(XmlElement);
		}

		private void SetupElementEventHandlers(XmlElement element)
		{
			foreach (XmlElement childElement in element.childElements)
			{
				SetupElementEventHandlers(childElement);
			}
			element.tagHandler.SetInstance(element);
			element.tagHandler.ApplyEventAttributes();
		}
	}
}
