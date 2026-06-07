using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft.Parts.Events;
using ModApi.Craft.Parts.Modifiers;
using ModApi.Craft.Parts.Styles;
using ModApi.Design;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class PartData
	{
		public delegate void PropertyChangedHandler();

		private PartData _commandPod;

		private bool _enabled;

		private List<PartModifierData> _modifiers;

		private string _preferredNodeName;

		public bool Activated { get; set; }

		public int ActivationGroup { get; set; }

		public int ActivationStage { get; set; }

		public bool ActivationStageOverride { get; set; }

		public List<AttachPoint> AttachPoints { get; private set; }

		public float BuoyancyScale => Config.BuoyancyUserScale * Config.BuoyancyBaseScale;

		public PartData CommandPod
		{
			get
			{
				return _commandPod;
			}
			set
			{
				if (PartType.IsCommandPod && _commandPod != this)
				{
					_commandPod = this;
					PartScript?.OnCommandPodChanged();
				}
				else if (_commandPod != value)
				{
					_commandPod = value;
					PartScript?.OnCommandPodChanged();
				}
			}
		}

		public int? CommandPodId { get; private set; }

		public virtual IConfigData Config { get; private set; }

		public float Damage { get; set; }

		public float DragScale
		{
			get
			{
				if (!Config.IncludeInDrag)
				{
					return 0f;
				}
				return Config.DragScale * (Activated ? Config.DragScaleActive : 1f);
			}
		}

		public bool Enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				bool num = value != _enabled;
				_enabled = value;
				if (num)
				{
					this.EnabledChanged?.Invoke();
				}
			}
		}

		public Guid? GroupId { get; set; }

		public int Id { get; set; }

		public float InertiaTensorScale => Config.InertiaTensorUserScale * Config.InertiaTensorBaseScale;

		public bool IsDestroyed { get; private set; }

		public bool IsRootPart { get; set; }

		public bool IsSpawned { get; set; }

		public List<XElement> LoadModifierFailures { get; set; }

		public float Mass => PartMass.Total;

		public List<int> MaterialIds { get; set; }

		public bool Mirrored { get; set; }

		public List<PartModifierData> Modifiers => _modifiers;

		public string Name { get; set; }

		public List<PartConnection> PartConnections { get; private set; }

		public bool PartConnectionsEnabled { get; set; }

		public Drag PartDrag { get; private set; }

		public PartMass PartMass
		{
			get
			{
				PartMass result = default(PartMass);
				result.Dry += PartType.Mass;
				foreach (PartModifierData modifier in _modifiers)
				{
					result.Dry += modifier.MassDry;
					result.Wet += modifier.MassWet;
				}
				result.Dry *= Config.MassScale;
				result.Wet *= Config.MassScale;
				return result;
			}
		}

		public virtual IPartScript PartScript { get; set; }

		public bool PartStyleEnabled { get; set; }

		public PartType PartType { get; set; }

		public virtual IPayload Payload { get; private set; }

		public Vector3 Position { get; private set; }

		public string PreferredNodeName
		{
			get
			{
				return _preferredNodeName;
			}
			set
			{
				if (value != _preferredNodeName && PartType.UsePreferredNodeName)
				{
					_preferredNodeName = value;
				}
			}
		}

		public bool PreviouslyActivated { get; set; }

		public long Price
		{
			get
			{
				long num = PartType.Price;
				foreach (PartModifierData modifier in _modifiers)
				{
					num += modifier.Price;
				}
				return (long)((float)num * Config.PriceScale);
			}
		}

		public Vector3 Rotation { get; private set; }

		public IReadOnlyList<PartStyleData> Styles { get; private set; }

		public Guid? SymmetryId { get; set; }

		public SymmetryMode SymmetryMode { get; set; }

		public string Tag { get; set; }

		public ThemeData ThemeData { get; set; }

		public Guid? ThemeDataId { get; set; }

		public static event EventHandler<CreatedPartEventArgs> Created;

		public static event EventHandler<CreatingPartEventArgs> Creating;

		public event PropertyChangedHandler EnabledChanged;

		public PartData(XElement xml, int xmlVersion, PartType partType)
		{
			CreatingPartEventArgs.RaiseStaticEvent(PartData.Creating, this, partType, xml, xmlVersion);
			PartType = partType;
			PartConnections = new List<PartConnection>();
			Enabled = true;
			AttachPoints = PartType.CreateAttachPoints();
			MaterialIds = new List<int>();
			_modifiers = new List<PartModifierData>();
			LoadXML(xml, xmlVersion);
			CreatedPartEventArgs.RaiseStaticEvent(PartData.Created, this, partType, xml, xmlVersion);
		}

		public PartData()
		{
		}

		public static bool operator !=(PartData a, PartData b)
		{
			return (object)a != b;
		}

		public static bool operator ==(PartData a, PartData b)
		{
			return (object)a == b;
		}

		public static List<IPartScript> ToPartScriptList(List<PartData> parts)
		{
			List<IPartScript> list = new List<IPartScript>();
			foreach (PartData part in parts)
			{
				list.Add(part.PartScript);
			}
			return list;
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public XElement GenerateXml(Transform craftTransform, bool optimizeXml)
		{
			if (craftTransform != null)
			{
				Synchronize(craftTransform);
			}
			XElement xElement = new XElement("Part", string.IsNullOrEmpty(Tag) ? null : new XAttribute("tag", Tag), new XAttribute("id", Id), new XAttribute("partType", PartType.Id), new XAttribute("position", Utilities.Vector3ToString(Position)), new XAttribute("rotation", Utilities.Vector3ToString(Rotation)), PartDrag.GenerateXml());
			if ((Name != PartType.Name || !optimizeXml) && !string.IsNullOrEmpty(Name))
			{
				xElement.Add(new XAttribute("name", Name));
			}
			if (!string.IsNullOrEmpty(PreferredNodeName))
			{
				xElement.Add(new XAttribute("preferredNodeName", PreferredNodeName));
			}
			if (Game.InFlightScene && ThemeData != null)
			{
				xElement.Add(new XAttribute("themeId", ThemeData.Id));
			}
			if (Activated || !optimizeXml)
			{
				xElement.Add(new XAttribute("activated", Activated));
			}
			if (ActivationGroup > 0 || !optimizeXml)
			{
				xElement.Add(new XAttribute("activationGroup", ActivationGroup));
			}
			if (PreviouslyActivated || !optimizeXml)
			{
				xElement.Add(new XAttribute("previouslyActivated", PreviouslyActivated));
			}
			if (Config.StageActivationType != StageActivationType.None || !optimizeXml)
			{
				xElement.Add(new XAttribute("activationStage", ActivationStage));
			}
			if (ActivationStageOverride || !optimizeXml)
			{
				xElement.Add(new XAttribute("stageOverride", ActivationStageOverride));
			}
			if (IsRootPart)
			{
				xElement.Add(new XAttribute("rootPart", IsRootPart));
			}
			if (CommandPod != null)
			{
				xElement.Add(new XAttribute("commandPodId", CommandPod.Id));
			}
			string text = string.Empty;
			foreach (int materialId in MaterialIds)
			{
				text = text + DataIO.ToString(materialId) + ",";
			}
			text = text.TrimEnd(',');
			xElement.Add(new XAttribute("materials", text));
			if (SymmetryId.HasValue)
			{
				xElement.Add(new XAttribute("symmetryId", SymmetryId.Value.ToString()));
			}
			if (GroupId.HasValue)
			{
				xElement.Add(new XAttribute("groupId", GroupId.Value.ToString()));
			}
			if (Mirrored)
			{
				xElement.Add(new XAttribute("mirrored", Mirrored));
			}
			if (Damage > 0f || !optimizeXml)
			{
				xElement.Add(new XAttribute("damage", Damage));
			}
			if (!PartConnectionsEnabled)
			{
				xElement.Add(new XAttribute("partConnectionsEnabled", false));
			}
			if (!PartStyleEnabled)
			{
				xElement.Add(new XAttribute("partStyleEnabled", false));
			}
			if (IsSpawned)
			{
				xElement.Add(new XAttribute("spawned", IsSpawned));
			}
			List<AttachPoint> list = null;
			foreach (AttachPoint attachPoint in AttachPoints)
			{
				if (attachPoint.IsCustomized)
				{
					if (list == null)
					{
						list = new List<AttachPoint>();
					}
					list.Add(attachPoint);
				}
			}
			if (list != null)
			{
				XElement xElement2 = new XElement("AttachPoints");
				xElement.Add(xElement2);
				foreach (AttachPoint item in list)
				{
					XElement xElement3 = new XElement("AttachPoint");
					xElement2.Add(xElement3);
					item.SaveCustomizedSettings(xElement3);
				}
			}
			foreach (PartModifierData modifier in _modifiers)
			{
				XElement xElement4 = modifier.GenerateStateXml(optimizeXml);
				if (xElement4 != null)
				{
					xElement.Add(xElement4);
				}
			}
			IPartStyleManager partStyleManager = Game.Instance.PartStyleManager;
			if (PartType.SubpartsSharePartStyle)
			{
				PartStyleData partStyleData = Styles[0];
				IPartStyle style = partStyleManager.GetStyle(PartType.Id, 0, null);
				if (partStyleData.Style.Id != style.Id || !optimizeXml)
				{
					xElement.SetAttributeValue("partStyle", partStyleData.Style.Id);
				}
			}
			IReadOnlyList<SubpartType> subparts = PartType.Subparts;
			for (int i = 0; i < subparts.Count; i++)
			{
				SubpartType.SubpartTypeXmlNames xmlNames = subparts[i].XmlNames;
				PartStyleData partStyleData2 = Styles[i];
				IPartStyle style2 = partStyleManager.GetStyle(PartType.Id, i, null);
				IPartTextureStyle partTextureStyle = ((partStyleData2.Style.Textures.Count > 0) ? partStyleData2.Style.Textures[0] : partStyleManager.DefaultTextureStyle);
				if (!PartType.SubpartsSharePartStyle && (partStyleData2.Style.Id != style2.Id || !optimizeXml))
				{
					xElement.SetAttributeValue(xmlNames.Style, partStyleData2.Style.Id);
				}
				if (partStyleData2.TextureStyle.Id != partTextureStyle.Id || !optimizeXml)
				{
					xElement.SetAttributeValue(xmlNames.TextureStyle, partStyleData2.TextureStyle.Id);
				}
				if (partStyleData2.TextureTiling != Vector2.one || !optimizeXml)
				{
					xElement.SetAttribute(xmlNames.TextureTiling, partStyleData2.TextureTiling);
				}
				if (partStyleData2.TextureOffset != Vector2.zero || !optimizeXml)
				{
					xElement.SetAttribute(xmlNames.TextureOffset, partStyleData2.TextureOffset);
				}
			}
			return xElement;
		}

		public AttachPoint GetAttachPoint(string name)
		{
			foreach (AttachPoint attachPoint in AttachPoints)
			{
				if (attachPoint.Name == name)
				{
					return attachPoint;
				}
			}
			return null;
		}

		public AttachPoint GetAttachPoint(int attachPointId)
		{
			foreach (AttachPoint attachPoint in AttachPoints)
			{
				if (attachPoint.Id == attachPointId)
				{
					return attachPoint;
				}
			}
			return null;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public PartMaterial GetMaterial(PartMeshMaterialLevel level)
		{
			return ThemeData.GetMaterial(MaterialIds[(int)level]);
		}

		public T GetModifier<T>() where T : PartModifierData
		{
			foreach (PartModifierData modifier in _modifiers)
			{
				if (modifier is T result)
				{
					return result;
				}
			}
			return null;
		}

		public PartModifierData GetModifierById(string id)
		{
			foreach (PartModifierData modifier in _modifiers)
			{
				if (modifier.Id == id)
				{
					return modifier;
				}
			}
			return null;
		}

		public PartModifierData GetModifierByTypeId(string typeId)
		{
			foreach (PartModifierData modifier in _modifiers)
			{
				if (modifier.TypeId == typeId)
				{
					return modifier;
				}
			}
			return null;
		}

		public int GetModifierCount(Type type, bool inherit)
		{
			int num = 0;
			foreach (PartModifierData modifier in _modifiers)
			{
				Type type2 = modifier.GetType();
				if (inherit ? type.IsAssignableFrom(type2) : (type == type2))
				{
					num++;
				}
			}
			return num;
		}

		public void GetModifiers<T>(List<T> modifiers) where T : PartModifierData
		{
			foreach (PartModifierData modifier in _modifiers)
			{
				if (modifier is T item)
				{
					modifiers.Add(item);
				}
			}
		}

		public void GetModifiers(Type type, bool inherit, List<PartModifierData> modifiers)
		{
			foreach (PartModifierData modifier in _modifiers)
			{
				Type type2 = modifier.GetType();
				if (inherit ? type.IsAssignableFrom(type2) : (type == type2))
				{
					modifiers.Add(modifier);
				}
			}
		}

		public PartConnection GetPartConnection(PartData part)
		{
			foreach (PartConnection partConnection in PartConnections)
			{
				if (partConnection.PartA == part || partConnection.PartB == part)
				{
					return partConnection;
				}
			}
			return null;
		}

		public bool HasTransparentMaterial()
		{
			foreach (int materialId in MaterialIds)
			{
				if (ThemeData.GetMaterial(materialId).TransparencyStrength != 0f)
				{
					return true;
				}
			}
			return false;
		}

		public void LoadXML(XElement xml, int xmlVersion)
		{
			PartType partType = PartType;
			Tag = Utilities.GetStringAttribute(xml, "tag", null);
			Id = (int)xml.Attribute("id");
			PreferredNodeName = Utilities.GetStringAttribute(xml, "preferredNodeName", null);
			Name = Utilities.GetStringAttribute(xml, "name", null);
			if (string.IsNullOrEmpty(Name))
			{
				Name = partType.Name;
			}
			ThemeDataId = Utilities.GetGuidAttribute(xml, "themeId", null);
			PartDrag = new Drag(xml.Element("Drag"));
			Activated = Utilities.GetBoolAttribute(xml, "activated", defaultValue: false);
			PreviouslyActivated = Utilities.GetBoolAttribute(xml, "previouslyActivated", defaultValue: false);
			IsRootPart = Utilities.GetBoolAttribute(xml, "rootPart", defaultValue: false);
			if (xml.Attribute("commandPodId") != null)
			{
				CommandPodId = (int)xml.Attribute("commandPodId");
			}
			else
			{
				CommandPodId = null;
			}
			Position = Utilities.ParseVector3(xml.Attribute("position").Value);
			Rotation = Utilities.ParseVector3(xml.Attribute("rotation").Value);
			SymmetryId = Utilities.GetGuidAttribute(xml, "symmetryId", null);
			GroupId = Utilities.GetGuidAttribute(xml, "groupId", null);
			Mirrored = Utilities.GetBoolAttribute(xml, "mirrored", defaultValue: false);
			ActivationStage = Mathf.Clamp(Utilities.GetIntAttribute(xml, "activationStage", 0), 0, 100);
			ActivationGroup = Mathf.Clamp(Utilities.GetIntAttribute(xml, "activationGroup", 0), 0, 20);
			ActivationStageOverride = Utilities.GetBoolAttribute(xml, "stageOverride", defaultValue: false);
			Damage = Utilities.GetFloatAttribute(xml, "damage", 0f);
			PartConnectionsEnabled = Application.isEditor || Utilities.GetBoolAttribute(xml, "partConnectionsEnabled", defaultValue: true);
			PartStyleEnabled = Utilities.GetBoolAttribute(xml, "partStyleEnabled", defaultValue: true);
			IsSpawned = Utilities.GetBoolAttribute(xml, "spawned", defaultValue: false);
			MaterialIds.Clear();
			MaterialIds.AddRange(Utilities.GetIntListAttribute(xml, "materials"));
			if (MaterialIds.Count < PartType.DefaultMaterialIds.Count)
			{
				for (int i = MaterialIds.Count; i < PartType.DefaultMaterialIds.Count; i++)
				{
					MaterialIds.Add(PartType.DefaultMaterialIds[i]);
				}
			}
			try
			{
				IEnumerable<XElement> enumerable = xml.Element("AttachPoints")?.Elements();
				if (enumerable != null)
				{
					foreach (XElement item in enumerable)
					{
						int intAttribute = item.GetIntAttribute("id");
						if (intAttribute < AttachPoints.Count)
						{
							AttachPoints[intAttribute].RestoreCustomizedSettings(item);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogErrorFormat("Failed to load customized attach points for part {0}, ID={1}. Message: {2}", Name, Id, ex.ToString());
			}
			_modifiers.Clear();
			PartType.CreateModifiers(this, xml, xmlVersion);
			InitializeConfigModifier();
			LoadStyleData(xml);
			foreach (PartModifierData modifier in _modifiers)
			{
				modifier.OnPartLoaded();
			}
		}

		public void OnDesignerPullout(string designerPartName, Assembly assembly, bool skipStartPartScale)
		{
			foreach (PartModifierData modifier in Modifiers)
			{
				modifier.OnDesignerPullout(designerPartName, assembly, skipStartPartScale);
			}
		}

		public void OnPartDestroyed()
		{
			if (!IsDestroyed)
			{
				IsDestroyed = true;
				return;
			}
			Debug.LogErrorFormat("Part {0} ({1}) is already destroyed.", Id, PartType.Name);
		}

		public void OnPartRecovered()
		{
			foreach (PartModifierData modifier in Modifiers)
			{
				modifier.OnPartRecovered();
			}
		}

		internal void OnModifierAdded(PartModifierData partModifierData)
		{
			_modifiers.Add(partModifierData);
		}

		internal void OnModifierRemoved(PartModifierData modifier)
		{
			_modifiers.Remove(modifier);
		}

		private void InitializeConfigModifier()
		{
			foreach (PartModifierData modifier in _modifiers)
			{
				if (modifier is IConfigData config)
				{
					Config = config;
				}
				else if (modifier is PayloadData payload)
				{
					Payload = payload;
				}
			}
			if (Config == null)
			{
				Debug.LogErrorFormat("Part is missing ConfigData: {0}", Name);
			}
			PartDrag.OcclusionCalculation = Config.OcclusionCalculation;
		}

		private void LoadStyleData(XElement xml)
		{
			IPartStyleManager partStyleManager = Game.Instance.PartStyleManager;
			IReadOnlyList<SubpartType> subparts = PartType.Subparts;
			if (subparts.Count > 0)
			{
				string text = null;
				if (PartType.SubpartsSharePartStyle)
				{
					text = (string)xml.Attribute("partStyle");
				}
				PartStyleData[] array = (PartStyleData[])(Styles = new PartStyleData[subparts.Count]);
				for (int i = 0; i < subparts.Count; i++)
				{
					SubpartType subpartType = subparts[i];
					string text2 = text ?? ((string)xml.Attribute(subpartType.XmlNames.Style));
					string id = (string)xml.Attribute(subpartType.XmlNames.TextureStyle);
					Vector2 vector2Attribute = xml.GetVector2Attribute(subpartType.XmlNames.TextureTiling, Vector2.one);
					Vector2 vector2Attribute2 = xml.GetVector2Attribute(subpartType.XmlNames.TextureOffset, Vector2.zero);
					IPartStyle style = partStyleManager.GetStyle(PartType.Id, i, text2);
					IPartTextureStyle partTextureStyle = partStyleManager.GetTextureStyle(id);
					if (partTextureStyle == null)
					{
						if (style.Textures.Count > 0)
						{
							partTextureStyle = style.Textures[0];
						}
						else
						{
							foreach (PartModifierData modifier in Modifiers)
							{
								if (modifier is IPartTextureStyleProvider partTextureStyleProvider)
								{
									IReadOnlyList<IPartTextureStyle> availablePartTextureStyles = partTextureStyleProvider.GetAvailablePartTextureStyles(PartType.Id, i, text2);
									if (availablePartTextureStyles != null && availablePartTextureStyles.Count > 0)
									{
										partTextureStyle = availablePartTextureStyles[0];
										break;
									}
								}
							}
							if (partTextureStyle == null)
							{
								partTextureStyle = partStyleManager.DefaultTextureStyle;
							}
						}
					}
					array[i] = new PartStyleData(this, style, partTextureStyle, vector2Attribute, vector2Attribute2);
				}
			}
			else
			{
				IPartStyle style2 = partStyleManager.GetStyle(PartType.Id, 0, null);
				IPartTextureStyle textureStyle = ((style2.Textures.Count > 0) ? style2.Textures[0] : partStyleManager.DefaultTextureStyle);
				Styles = new List<PartStyleData>(1)
				{
					new PartStyleData(this, style2, textureStyle)
				};
			}
		}

		private void Synchronize(Transform craftTransform)
		{
			Position = craftTransform.InverseTransformPoint(PartScript.Transform.position);
			Rotation = (Quaternion.Inverse(craftTransform.rotation) * PartScript.Transform.rotation).eulerAngles;
		}
	}
}
