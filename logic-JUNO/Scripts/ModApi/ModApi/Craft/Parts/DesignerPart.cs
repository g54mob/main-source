using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Jundroo.ModTools;
using ModApi.Craft.Parts.Editor;
using ModApi.Craft.Parts.Editor.Attributes;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	[Serializable]
	public class DesignerPart
	{
		[Serializable]
		public struct XmlAttribute
		{
			public string Name;

			public string Value;
		}

		[SerializeField]
		[Range(0f, 20f)]
		[UnityInspectorPart(70)]
		[Tooltip("The default activation group for the part.")]
		private int _activationGroup;

		[SerializeField]
		[UnityInspectorPart(40)]
		[Tooltip("The designer category of the part.")]
		private DesignerPartCategory _category;

		[SerializeField]
		[TextArea(1, 10)]
		[UnityInspectorPart(20)]
		[Tooltip("The short description for the part that will be displayed to the user in the designer.")]
		private string _description;

		[SerializeField]
		[UnityInspectorPart(30)]
		[Tooltip("The order to display this part in the part list.")]
		private int _displayOrder;

		[SerializeField]
		[UnityInspectorPart(120, Label = "Image Path")]
		[Tooltip("This is the path to the designer part icon image. For auto-generated icons, this is unnecessary, however it may still be specified for manual control of the file name. For 'File' type icons, this is the path (relative to the part icon folder) where the part icon image is located. For both cases if left blank, the name of the designer part will be used. For 'Resource' type icons, this is a required field and should point to the asset path in the mod where the icon image can be loaded.")]
		private string _iconPath;

		private Sprite _iconSprite;

		private Texture2D _iconTexture;

		[SerializeField]
		[UnityInspectorPart(80, Label = "Icon Type", Space = 1, Header = "Part Icon")]
		[Tooltip("The method used for obtaining a part icon for the designer part.")]
		private DesignerPartIconType _iconType;

		[SerializeField]
		[UnityInspectorPart(10, Label = "Display Name", Space = 2)]
		[Tooltip("The name of the part as it will appear to the user in the designer.")]
		private string _name;

		[SerializeField]
		[UnityInspectorPart(130, Label = "Part Type Overrides", Space = 1)]
		[Tooltip("Part type overrides are used to set attributes on the part's XML that override the part type's XML attributes.")]
		private XmlAttribute[] _partTypeOverrides;

		[SerializeField]
		[UnityInspectorPart(50)]
		[Tooltip("The default position of the part.")]
		private Vector3 _position;

		[SerializeField]
		[UnityInspectorPart(60)]
		[Tooltip("The default rotation of the part.")]
		private Vector3 _rotation;

		[SerializeField]
		[UnityInspectorPart(0, Space = 0)]
		[Tooltip("If unchecked, the part will not show up in the designer. This is typically used to support legacy parts.")]
		private bool _showInDesigner;

		[SerializeField]
		[UnityInspectorPart(90, Label = "Distance Scaler")]
		[Tooltip("The adjustment for distance to the camera when taking a picture for this part.")]
		private float _snapshotDistanceScaler;

		[SerializeField]
		[UnityInspectorPart(110, Label = "Part Offset")]
		[Tooltip("Moves the part by this vector before taking the picture.")]
		private Vector3 _snapshotPartOffset;

		[SerializeField]
		[UnityInspectorPart(110, Label = "Part Rotation")]
		[Tooltip("The rotation of the part from the default position to be used when taking a part icon snapshot.")]
		private Vector3 _snapshotPartRotation;

		[SerializeField]
		[UnityInspectorPart(100, Label = "Camera Rotation")]
		[Tooltip("The rotation of the camera from the default position to be used when taking a part icon snapshot.")]
		private Vector3 _snapshotRotation;

		public XElement AssemblyElement { get; set; }

		public DesignerPartCategory Category
		{
			get
			{
				return _category;
			}
			set
			{
				_category = value;
			}
		}

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		public int DisplayOrder
		{
			get
			{
				return _displayOrder;
			}
			set
			{
				_displayOrder = value;
			}
		}

		public string IconPath
		{
			get
			{
				return _iconPath;
			}
			set
			{
				_iconPath = value;
			}
		}

		public DesignerPartIconType IconType
		{
			get
			{
				return _iconType;
			}
			set
			{
				_iconType = value;
			}
		}

		public bool IsSubassembly => Category.Id == "Sub Assemblies";

		public float Mass { get; set; }

		public ILoadedMod Mod { get; set; }

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public XmlAttribute[] PartTypeOverrides => _partTypeOverrides;

		public IReadOnlyList<PartType> PartTypes { get; set; }

		public IReadOnlyList<string> PayloadIds { get; set; }

		public long Price { get; set; }

		public bool ShowInDesigner
		{
			get
			{
				return _showInDesigner;
			}
			set
			{
				_showInDesigner = value;
			}
		}

		public float SnapshotDistanceScaler
		{
			get
			{
				return _snapshotDistanceScaler;
			}
			set
			{
				_snapshotDistanceScaler = value;
			}
		}

		public Vector3 SnapshotPartOffset
		{
			get
			{
				return _snapshotPartOffset;
			}
			set
			{
				_snapshotPartOffset = value;
			}
		}

		public Vector3 SnapshotPartRotation
		{
			get
			{
				return _snapshotPartRotation;
			}
			set
			{
				_snapshotPartRotation = value;
			}
		}

		public Vector3 SnapshotRotation
		{
			get
			{
				return _snapshotRotation;
			}
			set
			{
				_snapshotRotation = value;
			}
		}

		public string SubassemblyFilePath { get; set; }

		public bool VariableProperties { get; set; }

		public DesignerPart()
		{
			_showInDesigner = true;
			_iconType = DesignerPartIconType.Auto;
			_snapshotDistanceScaler = 1f;
			_snapshotRotation = new Vector3(30f, 30f, 0f);
			_snapshotPartRotation = new Vector3(0f, 0f, 0f);
		}

		public DesignerPart(XElement xml)
		{
			Name = (string)xml.Attribute("name");
			Description = (string)xml.Attribute("description");
			DisplayOrder = (int)xml.Attribute("order");
			ShowInDesigner = (bool)xml.Attribute("showInDesigner");
			IconType = Utilities.GetEnumAttribute(xml, "iconType", DesignerPartIconType.Auto);
			IconPath = (string)xml.Attribute("iconPath");
			SnapshotDistanceScaler = (float)xml.Attribute("snapshotDistanceScaler");
			SnapshotPartRotation = Utilities.GetVectorAttribute(xml, "snapshotPartRotation", Vector3.zero);
			SnapshotPartOffset = Utilities.GetVectorAttribute(xml, "snapshotPartOffset", Vector3.zero);
			SnapshotRotation = Utilities.GetVectorAttribute(xml, "snapshotRotation", Vector3.zero);
			string category = (string)xml.Attribute("category");
			Category = (Application.isPlaying ? DesignerPartCategories.GetCategory(category, create: true) : AssetDatabase.FindAssets<DesignerPartCategory>(Array.Empty<string>()).FirstOrDefault((DesignerPartCategory x) => x.Id == category));
			XElement xElement = xml.Element("Assembly")?.Element("Parts")?.Element("Part");
			if (xElement == null)
			{
				Debug.LogError("Unable to find the part XML in the designer part XML.");
				return;
			}
			_position = Utilities.GetVectorAttribute(xElement, "position", Vector3.zero);
			_rotation = Utilities.GetVectorAttribute(xElement, "rotation", Vector3.zero);
			_activationGroup = ((int?)xml.Attribute("activationGroup")).GetValueOrDefault();
		}

		public static DesignerPartEditorScript CreateEditorScript(GameObject obj, string partName)
		{
			DesignerPartEditorScript designerPartEditorScript = obj.AddComponent<DesignerPartEditorScript>();
			DesignerPart designerPart = designerPartEditorScript.Data;
			if (designerPart == null)
			{
				designerPart = (designerPartEditorScript.Data = new DesignerPart());
			}
			designerPart._name = partName;
			return designerPartEditorScript;
		}

		public string CalculateIconPath()
		{
			return Utilities.CombinePaths(Game.PersistentDataPath, "GameData/Parts/Icons/", string.IsNullOrWhiteSpace(_iconPath) ? (Name + ".png") : _iconPath);
		}

		public XElement GenerateDesignerPartXml(string partTypeId, IEnumerable<XElement> modifiersXml)
		{
			XElement xElement = new XElement("Part", new XAttribute("id", 1), new XAttribute("partType", partTypeId), new XAttribute("position", Utilities.Vector3ToString(_position)), new XAttribute("rotation", Utilities.Vector3ToString(_rotation)), (_activationGroup > 0) ? new XAttribute("activationGroup", _activationGroup) : null, (modifiersXml == null || modifiersXml.Count() == 0) ? null : modifiersXml);
			if (_partTypeOverrides != null)
			{
				XmlAttribute[] partTypeOverrides = _partTypeOverrides;
				for (int i = 0; i < partTypeOverrides.Length; i++)
				{
					XmlAttribute xmlAttribute = partTypeOverrides[i];
					xElement.Add(new XAttribute(xmlAttribute.Name, xmlAttribute.Value));
				}
			}
			return new XElement("DesignerPart", new XAttribute("name", Name), new XAttribute("category", Category?.Id ?? "Other"), new XAttribute("description", Description), new XAttribute("order", DisplayOrder), new XAttribute("showInDesigner", ShowInDesigner), (IconType == DesignerPartIconType.Auto) ? null : new XAttribute("iconType", IconType), string.IsNullOrWhiteSpace(IconPath) ? null : new XAttribute("iconPath", IconPath), new XAttribute("snapshotDistanceScaler", SnapshotDistanceScaler), (_snapshotPartRotation == Vector3.zero) ? null : new XAttribute("snapshotPartRotation", Utilities.Vector3ToString(SnapshotPartRotation)), (_snapshotPartOffset == Vector3.zero) ? null : new XAttribute("snapshotPartOffset", Utilities.Vector3ToString(SnapshotPartOffset)), new XAttribute("snapshotRotation", Utilities.Vector3ToString(SnapshotRotation)), new XElement("Assembly", new XElement("Parts", xElement)));
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("DesignerPart");
			xElement.SetAttributeValue("name", Name);
			xElement.SetAttributeValue("category", Category.Id);
			xElement.SetAttributeValue("description", Description);
			xElement.SetAttributeValue("order", DisplayOrder);
			xElement.SetAttributeValue("showInDesigner", ShowInDesigner);
			xElement.Add(AssemblyElement);
			return xElement;
		}

		public Sprite GetIcon()
		{
			if (_iconSprite == null)
			{
				LoadIcon();
			}
			return _iconSprite;
		}

		public void UnloadIcon()
		{
			if (_iconType != DesignerPartIconType.Resource)
			{
				if (_iconSprite != null)
				{
					UnityEngine.Object.Destroy(_iconSprite);
					_iconSprite = null;
				}
				if (_iconTexture != null)
				{
					UnityEngine.Object.Destroy(_iconTexture);
					_iconTexture = null;
				}
			}
		}

		private void LoadIcon()
		{
			UnloadIcon();
			try
			{
				if (_iconType == DesignerPartIconType.Resource)
				{
					if (string.IsNullOrWhiteSpace(_iconPath))
					{
						Debug.LogError("Unable to load designer part icon for designer part '" + (Name ?? string.Empty) + "' because the icon resource path was not specified.");
						return;
					}
					UnityEngine.Object obj = ((Mod == null) ? Game.Instance.ResourceLoader.Load<UnityEngine.Object>(_iconPath) : Mod.ResourceLoader.LoadAsset<UnityEngine.Object>(_iconPath));
					if (obj == null)
					{
						Debug.LogError("Unable to load designer part icon for designer part '" + (Name ?? string.Empty) + "' because the icon resource could not be found at path '" + _iconPath + "'.");
					}
					else if (obj is Texture2D iconTexture)
					{
						_iconTexture = iconTexture;
						_iconSprite = Sprite.Create(_iconTexture, new Rect(0f, 0f, _iconTexture.width, _iconTexture.height), new Vector2(0.5f, 0.5f), 100f);
					}
					else if (obj is Sprite iconSprite)
					{
						_iconSprite = iconSprite;
					}
					else
					{
						Debug.LogError("Unable to load designer part icon for designer part '" + (Name ?? string.Empty) + "' because the icon resource at path '" + _iconPath + "' was not a Sprite or Texture2D.");
					}
				}
				else
				{
					string path = CalculateIconPath();
					byte[] data = File.ReadAllBytes(path);
					_iconTexture = new Texture2D(1, 1, TextureFormat.ARGB32, mipChain: false, linear: false);
					_iconTexture.wrapMode = TextureWrapMode.Clamp;
					_iconTexture.LoadImage(data, markNonReadable: true);
					_iconSprite = Sprite.Create(_iconTexture, new Rect(0f, 0f, _iconTexture.width, _iconTexture.height), new Vector2(0.5f, 0.5f), 100f);
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
					_iconTexture.name = "PartIconTexture_" + fileNameWithoutExtension;
					_iconSprite.name = "PartIconSprite_" + fileNameWithoutExtension;
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Debug.LogError("Unable to load designer part icon for designer part '" + (Name ?? string.Empty) + "'.");
				_iconSprite = null;
			}
		}
	}
}
