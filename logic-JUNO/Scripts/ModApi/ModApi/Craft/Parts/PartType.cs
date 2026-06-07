using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Jundroo.ModTools;
using ModApi.Craft.Parts.Editor;
using ModApi.Craft.Parts.Editor.Attributes;
using ModApi.Craft.Parts.Events;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	[Serializable]
	public class PartType
	{
		[SerializeField]
		[UnityInspectorPart(50)]
		[Tooltip("A value indicating whether to allow re-orientation when switching build modes in the designer when the part is initially pulled out.")]
		private bool _allowDesignerReorientationOnPullout;

		[SerializeField]
		[UnityInspectorPart(40)]
		[Tooltip("A value indicating whether this part type requires the ability to be removed individually (i.e. not only with entire Part Group).")]
		private bool _allowIndividualPartRemoval;

		private XElement _attachPointsElement;

		[SerializeField]
		[Range(-1f, 24f)]
		[UnityInspectorPart(120, Label = "Primary", Space = 2, Header = "Default Material Color Index Values", HeaderTooltip = "Configuration of the default color values for the part.")]
		[Tooltip("The index of the color value in the player's current theme for the default primary color of the part. Use -1 for an unchangeable black value (or default texture).")]
		private short _defaultColorIndexPrimary;

		[SerializeField]
		[Range(-1f, 24f)]
		[UnityInspectorPart(121, Label = "Trim 1")]
		[Tooltip("The index of the color value in the player's current theme for the default trim 1 color of the part. Use -1 for an unchangeable black value (or default texture).")]
		private short _defaultColorIndexTrim1 = 1;

		[SerializeField]
		[Range(-1f, 24f)]
		[UnityInspectorPart(122, Label = "Trim 2")]
		[Tooltip("The index of the color value in the player's current theme for the default trim 2 color of the part. Use -1 for an unchangeable black value (or default texture).")]
		private short _defaultColorIndexTrim2 = 2;

		[SerializeField]
		[Range(-1f, 24f)]
		[UnityInspectorPart(123, Label = "Trim 3")]
		[Tooltip("The index of the color value in the player's current theme for the default trim 3 color of the part. Use -1 for an unchangeable black value (or default texture).")]
		private short _defaultColorIndexTrim3 = 3;

		[SerializeField]
		[Range(-1f, 24f)]
		[UnityInspectorPart(124, Label = "Trim 4")]
		[Tooltip("The index of the color value in the player's current theme for the default trim 4 color of the part. Use -1 for an unchangeable black value (or default texture).")]
		private short _defaultColorIndexTrim4 = 4;

		[SerializeField]
		[UnityInspectorPart(0, Space = 1)]
		[Tooltip("The identifier for the part type.")]
		private string _id;

		[SerializeField]
		[UnityInspectorPart(60)]
		[Tooltip("Gets a value indicating whether to include this part's calculated drag in the body's overall drag. This is used for parts that compute their own drag so they can excuse themselves from the body's drag and avoid having a double-drag calculation.")]
		private bool _includeInBodyDrag;

		private Func<GameObject> _instantiatePrefab;

		[SerializeField]
		[UnityInspectorPart(80)]
		private PartTypeMirrorConfig _mirrorConfig;

		private XElement _modifiersElement;

		[SerializeField]
		[UnityInspectorPart(10)]
		[Tooltip("The name of the part type.")]
		private string _name;

		[SerializeField]
		[UnityInspectorPart(70)]
		[Tooltip("The part collision handling method. Default: The default method for handling collisions.AutoDisablePerPart: Part collisions are automatically disabled for all colliders between two colliding parts.AutoDisablePerCollider: Part collisions are automatically disabled for each collider involved in a collision between two parts.Never: Part collisions should never occur.Always: Part collisions should always occur.")]
		private PartCollisionHandlingMethod _partCollisionHandling;

		[SerializeField]
		[UnityInspectorPart(30)]
		[Tooltip("The price of the part.")]
		private long _price;

		private bool _stylesShareHeader;

		private List<SubpartType> _subparts;

		private bool _subpartsSharePartStyle;

		[SerializeField]
		[UnityInspectorPart(20, Label = "Mass")]
		[Tooltip("The mass of the part type in kilograms.")]
		private float _unscaledMass;

		[SerializeField]
		[UnityInspectorPart(0)]
		[Tooltip("A value indicating whether this part type should use PartData.PreferredNodeName.")]
		private bool _usePreferredNodeName = true;

		public bool AllowDesignerReorientationOnPullout
		{
			get
			{
				return _allowDesignerReorientationOnPullout;
			}
			private set
			{
				_allowDesignerReorientationOnPullout = value;
			}
		}

		public bool AllowIndividualPartRemoval
		{
			get
			{
				return _allowIndividualPartRemoval;
			}
			private set
			{
				_allowIndividualPartRemoval = value;
			}
		}

		public List<int> DefaultMaterialIds { get; private set; }

		public bool HasModPrefab { get; private set; }

		public string Id
		{
			get
			{
				return _id;
			}
			private set
			{
				_id = value;
			}
		}

		public bool IncludeInBodyDrag
		{
			get
			{
				return _includeInBodyDrag;
			}
			private set
			{
				_includeInBodyDrag = value;
			}
		}

		public bool IsCommandPod { get; private set; }

		public float Mass { get; private set; }

		public PartTypeMirrorConfig MirrorConfig
		{
			get
			{
				return _mirrorConfig;
			}
			private set
			{
				_mirrorConfig = value;
			}
		}

		public ILoadedMod Mod { get; set; }

		public bool MustBeBySelfInPartGroup => AllowIndividualPartRemoval;

		public string Name
		{
			get
			{
				return _name;
			}
			private set
			{
				_name = value;
			}
		}

		public PartCollisionHandlingMethod PartCollisionHandling
		{
			get
			{
				return _partCollisionHandling;
			}
			private set
			{
				_partCollisionHandling = value;
			}
		}

		public string PrefabPath { get; private set; }

		public long Price
		{
			get
			{
				return _price;
			}
			private set
			{
				_price = value;
			}
		}

		public bool StylesShareHeader
		{
			get
			{
				return _stylesShareHeader;
			}
			private set
			{
				_stylesShareHeader = value;
			}
		}

		public IReadOnlyList<SubpartType> Subparts => _subparts;

		public bool SubpartsSharePartStyle
		{
			get
			{
				return _subpartsSharePartStyle;
			}
			private set
			{
				_subpartsSharePartStyle = value;
			}
		}

		public bool UsePreferredNodeName
		{
			get
			{
				return _usePreferredNodeName;
			}
			set
			{
				_usePreferredNodeName = value;
			}
		}

		public static event EventHandler<CreatedPartModifiersEventArgs> CreatedPartModifiers;

		public static event EventHandler<CreatingPartModifiersEventArgs> CreatingPartModifiers;

		public PartType(XElement xml)
			: this(xml, null)
		{
		}

		public PartType(XElement xml, ILoadedMod mod)
		{
			Id = (string)xml.Attribute("id");
			Name = (string)xml.Attribute("name");
			PrefabPath = (string)xml.Attribute("prefabPath");
			Mass = (_unscaledMass = (float)xml.Attribute("mass")) * 0.01f;
			IncludeInBodyDrag = Utilities.GetBoolAttribute(xml, "includeInBodyDrag", defaultValue: true);
			PartCollisionHandling = Utilities.GetEnumAttribute(xml, "partCollisions", PartCollisionHandlingMethod.Default);
			Price = Utilities.GetIntAttribute(xml, "price", 0);
			AllowIndividualPartRemoval = Utilities.GetBoolAttribute(xml, "allowIndividualPartRemoval", defaultValue: false);
			AllowDesignerReorientationOnPullout = Utilities.GetBoolAttribute(xml, "allowDesignerReorientationOnPullout", defaultValue: true);
			MirrorConfig = new PartTypeMirrorConfig(xml);
			_subparts = SubpartType.CreateFromXml(xml, createDefault: true);
			SubpartsSharePartStyle = Utilities.GetBoolAttribute(xml, "subpartsSharePartStyle", defaultValue: false);
			StylesShareHeader = Utilities.GetBoolAttribute(xml, "stylesShareHeader", defaultValue: false);
			Mod = mod;
			UsePreferredNodeName = Utilities.GetBoolAttribute(xml, "usePreferredNodeName", defaultValue: true);
			DefaultMaterialIds = new List<int>();
			DefaultMaterialIds.AddRange(Utilities.GetIntListAttribute(xml, "defaultMaterials"));
			if (DefaultMaterialIds.Count == 0)
			{
				DefaultMaterialIds.Add(0);
			}
			_attachPointsElement = xml.Element("AttachPoints");
			_modifiersElement = xml.Element("Modifiers");
			IsCommandPod = _modifiersElement?.Element("CommandPod") != null;
			InitializePrefab();
		}

		private PartType()
		{
			_allowDesignerReorientationOnPullout = true;
			_includeInBodyDrag = true;
			_defaultColorIndexPrimary = 0;
			_defaultColorIndexTrim1 = 1;
			_defaultColorIndexTrim2 = 2;
			_defaultColorIndexTrim3 = 3;
			_defaultColorIndexTrim4 = 4;
		}

		public static PartTypeEditorScript CreateEditorScript(GameObject obj, string partTypeId)
		{
			PartTypeEditorScript partTypeEditorScript = obj.AddComponent<PartTypeEditorScript>();
			PartType partType = partTypeEditorScript.Data;
			if (partType == null)
			{
				partType = (partTypeEditorScript.Data = new PartType());
			}
			partType._id = partTypeId;
			partType._name = partTypeId;
			return partTypeEditorScript;
		}

		public List<AttachPoint> CreateAttachPoints()
		{
			List<AttachPoint> list = new List<AttachPoint>();
			if (_attachPointsElement != null)
			{
				IEnumerable<XElement> source = _attachPointsElement.Elements("AttachPoint");
				for (int i = 0; i < source.Count(); i++)
				{
					XElement element = source.ElementAt(i);
					AttachPoint item = new AttachPoint(i, element);
					list.Add(item);
				}
				foreach (AttachPoint item2 in list)
				{
					if (!(Mathf.Abs(item2.Position.x) > 0f))
					{
						continue;
					}
					Vector3 vector = new Vector3(0f - item2.Position.x, item2.Position.y, item2.Position.z);
					foreach (AttachPoint item3 in list)
					{
						if (item2 != item3 && vector == item3.Position)
						{
							item2.MirrorId = item3.Id;
						}
					}
				}
			}
			return list;
		}

		public List<PartModifierData> CreateModifiers(PartData part, XElement partElement, int xmlVersion)
		{
			CreatingPartModifiersEventArgs.RaiseStaticEvent(PartType.CreatingPartModifiers, this, part, partElement, xmlVersion);
			List<PartModifierData> list = new List<PartModifierData>();
			List<XElement> list2 = partElement.Elements().ToList();
			if (_modifiersElement != null)
			{
				XElement xElement = null;
				foreach (XElement element in _modifiersElement.Elements())
				{
					try
					{
						xElement = list2.FirstOrDefault((XElement x) => x.Name.LocalName == element.Name.LocalName);
						if (xElement != null)
						{
							list2.Remove(xElement);
							PartModifierData partModifierData = PartModifierData.CreateFromXml(element, xElement, part, xmlVersion);
							if (partModifierData != null)
							{
								list.Add(partModifierData);
							}
						}
					}
					catch (Exception exception)
					{
						Debug.LogError($"Unable to create modifier '{element.Name.LocalName}' for part '{part.Id}'. {Environment.NewLine}{element}");
						Debug.LogException(exception);
						if (part.LoadModifierFailures == null)
						{
							part.LoadModifierFailures = new List<XElement>();
						}
						part.LoadModifierFailures.Add(xElement);
					}
				}
			}
			foreach (XElement item in list2)
			{
				try
				{
					if (item.Name != "Drag" && item.Name != "AttachPoints")
					{
						PartModifierData partModifierData2 = PartModifierData.CreateFromStateXml(item, part, xmlVersion);
						if (partModifierData2 != null)
						{
							list.Add(partModifierData2);
						}
					}
				}
				catch (Exception exception2)
				{
					Debug.LogError($"Unable to create modifier '{item.Name.LocalName}' for part '{part.Id}'. {Environment.NewLine}{item}");
					Debug.LogException(exception2);
					if (part.LoadModifierFailures == null)
					{
						part.LoadModifierFailures = new List<XElement>();
					}
					part.LoadModifierFailures.Add(item);
				}
			}
			CreatedPartModifiersEventArgs.RaiseStaticEvent(PartType.CreatedPartModifiers, this, part, partElement, xmlVersion, list);
			return list;
		}

		public XElement GeneratePartTypeXml(string prefabPath, XElement styles, List<XElement> modifiers, List<XElement> attachPoints)
		{
			if (DefaultMaterialIds != null && DefaultMaterialIds.Count == 5)
			{
				_defaultColorIndexPrimary = (short)DefaultMaterialIds[0];
				_defaultColorIndexTrim1 = (short)DefaultMaterialIds[1];
				_defaultColorIndexTrim2 = (short)DefaultMaterialIds[2];
				_defaultColorIndexTrim3 = (short)DefaultMaterialIds[3];
				_defaultColorIndexTrim4 = (short)DefaultMaterialIds[4];
			}
			XElement xElement = new XElement("PartType", new XAttribute("id", Id), new XAttribute("includeInBodyDrag", IncludeInBodyDrag), new XAttribute("name", Name), new XAttribute("prefabPath", prefabPath), new XAttribute("mass", _unscaledMass), new XAttribute("price", Price), new XAttribute("partCollisions", PartCollisionHandling), AllowIndividualPartRemoval ? new XAttribute("allowIndividualPartRemoval", AllowIndividualPartRemoval) : null, (!UsePreferredNodeName) ? new XAttribute("usePreferredNodeName", UsePreferredNodeName) : null, (!AllowDesignerReorientationOnPullout) ? new XAttribute("allowDesignerReorientationOnPullout", AllowDesignerReorientationOnPullout) : null, new XAttribute("defaultMaterials", DataIO.ToString(_defaultColorIndexPrimary) + "," + DataIO.ToString(_defaultColorIndexTrim1) + "," + DataIO.ToString(_defaultColorIndexTrim2) + "," + DataIO.ToString(_defaultColorIndexTrim3) + "," + DataIO.ToString(_defaultColorIndexTrim4)), new XAttribute("subpartsSharePartStyle", (string)styles.Attribute("subpartsSharePartStyle")), new XAttribute("stylesShareHeader", (string)styles.Attribute("stylesShareHeader")), (modifiers.Count == 0) ? null : new XElement("Modifiers", modifiers), (attachPoints.Count == 0) ? null : new XElement("AttachPoints", attachPoints));
			MirrorConfig.Save(xElement);
			xElement.Add(styles.Element("SubpartTypes"));
			return xElement;
		}

		public GameObject InstantiatePrefab()
		{
			return _instantiatePrefab();
		}

		private void InitializePrefab()
		{
			HasModPrefab = false;
			string prefabPath = PrefabPath;
			if (!string.IsNullOrEmpty(prefabPath))
			{
				if (Mod != null && prefabPath.StartsWith("Assets/", StringComparison.Ordinal))
				{
					HasModPrefab = true;
					IModResourceLoader resourceLoader = (Application.isPlaying ? Mod.ResourceLoader : null);
					_instantiatePrefab = delegate
					{
						GameObject gameObject = resourceLoader.LoadAsset<GameObject>(prefabPath);
						return (!(gameObject == null)) ? UnityEngine.Object.Instantiate(gameObject) : null;
					};
				}
				else
				{
					prefabPath = prefabPath.Replace(".prefab", string.Empty);
					IResourceLoader resourceLoader2 = (Application.isPlaying ? Game.Instance.ResourceLoader : null);
					_instantiatePrefab = () => resourceLoader2.InstantiatePrefab(prefabPath);
				}
			}
			if (_instantiatePrefab == null)
			{
				_instantiatePrefab = () => (GameObject)null;
			}
		}
	}
}
