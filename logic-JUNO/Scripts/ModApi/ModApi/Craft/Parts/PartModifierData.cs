using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Jundroo.ModTools;
using Jundroo.ModTools.Serialization.Xml;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Parts.Events;
using ModApi.Design;
using ModApi.Design.PartProperties;
using ModApi.Mods;
using UnityEngine;

namespace ModApi.Craft.Parts
{
	[Serializable]
	public abstract class PartModifierData : IDesignerPartModifierData, IDisposable
	{
		private class MembersToSerialize
		{
			public string[] MemberNames { get; set; }

			public Dictionary<string, PartModifierPropertyStatePreservationMode> StatePreservationModes { get; set; }

			public bool AllowOptimization(XAttribute attribute)
			{
				if (StatePreservationModes.TryGetValue(attribute.Name.LocalName, out var value))
				{
					switch (value)
					{
					case PartModifierPropertyStatePreservationMode.SaveAlways:
						return false;
					case PartModifierPropertyStatePreservationMode.SaveAlwaysIfNonEmpty:
						if (!string.IsNullOrEmpty((string)attribute))
						{
							return false;
						}
						break;
					}
				}
				return true;
			}
		}

		private static readonly IEnumerable<int> _EmptyEnumerableInt = Enumerable.Empty<int>();

		private static Dictionary<Type, MembersToSerialize> _allPropertiesLookup = new Dictionary<Type, MembersToSerialize>();

		private static Dictionary<Type, XElement> _createFromStateDefaultXmlLookup = new Dictionary<Type, XElement>();

		private static Dictionary<Type, ILoadedMod> _partModifierModMap = new Dictionary<Type, ILoadedMod>();

		private static Dictionary<string, Type> _partModifierTypes = new Dictionary<string, Type>();

		private static List<System.Reflection.Assembly> _registeredAssemblies = new List<System.Reflection.Assembly>();

		private static UnityXmlSerializer _serializer = new UnityXmlSerializer(new UnityXmlSerializerContext(saveTypeInfo: false, ignoreUnderscorePrefix: true));

		private static Dictionary<Type, MembersToSerialize> _statePropertiesLookup = new Dictionary<Type, MembersToSerialize>();

		private static Dictionary<Type, string> _typeIDLookup = new Dictionary<Type, string>();

		private PartModifierDataDesignerPartProperties _designerPartProperties;

		private bool _disposed;

		private bool _forceAllowSerializationOptimization;

		[SerializeField]
		[HideInInspector]
		[PartModifierProperty(true, false)]
		private string _id = string.Empty;

		[SerializeField]
		[PartModifierProperty(true, false, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlwaysIfNonEmpty)]
		private string _inputId = string.Empty;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _inspectorEnabled = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _partPropertiesEnabled = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _staticPriceAndMass;

		[SerializeField]
		[HideInInspector]
		[PartModifierProperty(true, false)]
		private Guid? _symmetryId;

		private string _typeId;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _version = 1;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _versionLast = 1;

		[SerializeField]
		[PartModifierProperty(true, false, SerializationOptions = XmlSerializationFlags.SingleAttribute)]
		private int[] _versionsAllowed;

		public XElement DefaultXml { get; private set; }

		IDesignerPartPropertiesDesignerInterface IDesignerPartModifierData.DesignerPartProperties => _designerPartProperties;

		public string Id => _id;

		public string InputId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_inputId))
				{
					return GetDefaultInputId();
				}
				return _inputId;
			}
			private set
			{
				_inputId = value;
			}
		}

		public bool InspectorEnabled
		{
			get
			{
				return _inspectorEnabled;
			}
			set
			{
				_inspectorEnabled = value;
			}
		}

		public float Mass => MassDry + MassWet;

		public virtual float MassDry => 0f;

		public virtual float MassWet => 0f;

		public ILoadedMod Mod
		{
			get
			{
				_partModifierModMap.TryGetValue(GetType(), out var value);
				return value;
			}
		}

		public string Name { get; private set; }

		public PartData Part { get; protected set; }

		PartModifierData IDesignerPartModifierData.PartModifierData => this;

		public bool PartPropertiesEnabled
		{
			get
			{
				return _partPropertiesEnabled;
			}
			set
			{
				_partPropertiesEnabled = value;
			}
		}

		public virtual long Price => 0L;

		public virtual float Scale { get; set; }

		public virtual string ScaleCareerID => string.Empty;

		public bool StaticPriceAndMass
		{
			get
			{
				return _staticPriceAndMass;
			}
			set
			{
				_staticPriceAndMass = value;
			}
		}

		public Guid? SymmetryId
		{
			get
			{
				return _symmetryId;
			}
			set
			{
				_symmetryId = value;
			}
		}

		public virtual float ThermalMassRatio => 1f;

		public string TypeId
		{
			get
			{
				if (string.IsNullOrEmpty(_typeId))
				{
					_typeId = GetTypeId();
				}
				return _typeId;
			}
		}

		public int Version => _version;

		public int VersionUpToDate
		{
			get
			{
				if (_version != _versionLast)
				{
					int[] versionsAllowed = _versionsAllowed;
					if (versionsAllowed == null || !versionsAllowed.Contains(_version))
					{
						return -1;
					}
					return 0;
				}
				return 1;
			}
			set
			{
				_version = _versionLast;
			}
		}

		protected bool CreatedFromStateElement { get; private set; }

		protected IDesignerPartPropertiesModifierInterface DesignerPartProperties => _designerPartProperties;

		public static event EventHandler<CreatedPartModifierDataEventArgs> Created;

		public static event EventHandler<CreatingPartModifierDataEventArgs> Creating;

		public PartModifierData()
		{
			Name = GetType().Name;
		}

		public static PartModifierData CreateForEditor(XElement partModifierXml, XElement partModifierStateXml)
		{
			if (partModifierXml == null)
			{
				partModifierXml = partModifierStateXml;
				if (partModifierStateXml == null)
				{
					throw new ArgumentException("Both the part modifier XML and the state XML cannot be null");
				}
			}
			string localName = partModifierXml.Name.LocalName;
			if (!_partModifierTypes.TryGetValue(localName, out var value) || value == null)
			{
				throw new Exception($"Part modifier with type ID '{localName}' could not be found.");
			}
			PartModifierData partModifierData = (PartModifierData)Activator.CreateInstance(value);
			MembersToSerialize membersToSerialize = GetMembersToSerialize(value, stateMembersOnly: false);
			if (membersToSerialize.MemberNames.Length != 0)
			{
				_serializer.Deserialize(partModifierXml, value, partModifierData, restoreMissingValuesAsNull: false, membersToSerialize.MemberNames);
			}
			if (partModifierStateXml != null)
			{
				membersToSerialize = GetMembersToSerialize(value, stateMembersOnly: true);
				if (membersToSerialize.MemberNames.Length != 0)
				{
					_serializer.Deserialize(partModifierStateXml, value, partModifierData, restoreMissingValuesAsNull: false, membersToSerialize.MemberNames);
				}
			}
			return partModifierData;
		}

		public static T CreateFromDefaultXml<T>(PartData part) where T : PartModifierData
		{
			XElement defaultXmlForType = GetDefaultXmlForType(typeof(T));
			return (T)CreateFromXml(null, defaultXmlForType, part, 15);
		}

		public static PartModifierData CreateFromStateXml(XElement partModifierStateXml, PartData part, int xmlVersion)
		{
			return CreateFromXml(null, partModifierStateXml, part, xmlVersion);
		}

		public static PartModifierData CreateFromXml(XElement partModifierXml, XElement partModifierStateXml, PartData part, int xmlVersion, bool restoreAllState = false)
		{
			bool flag = false;
			if (partModifierXml == null)
			{
				flag = true;
				partModifierXml = partModifierStateXml;
				if (partModifierStateXml == null)
				{
					throw new ArgumentException("Both the part modifier XML and the state XML cannot be null");
				}
			}
			CreatingPartModifierDataEventArgs.RaiseStaticEvent(PartModifierData.Creating, partModifierXml, partModifierStateXml, part, xmlVersion);
			string localName = partModifierXml.Name.LocalName;
			if (!_partModifierTypes.TryGetValue(localName, out var value) || value == null)
			{
				throw new Exception($"Part modifier with type ID '{localName}' could not be found.");
			}
			PartModifierData partModifierData = (PartModifierData)Activator.CreateInstance(value);
			partModifierData.Part = part;
			partModifierData.CreatedFromStateElement = flag;
			partModifierData.DefaultXml = (flag ? GetDefaultXmlForType(value) : partModifierXml);
			bool flag2 = xmlVersion != 15;
			if (flag && flag2)
			{
				partModifierData.OnXmlUpgrade(xmlVersion, partModifierXml);
			}
			partModifierData.OnCreated(partModifierXml);
			if (partModifierStateXml != null)
			{
				if (flag2)
				{
					partModifierData.OnXmlUpgrade(xmlVersion, partModifierStateXml);
				}
				partModifierData.RestoreFromState(partModifierStateXml, restoreAllState);
			}
			if (flag2)
			{
				partModifierData.OnUpgrade(xmlVersion);
			}
			if (Game.InDesignerScene)
			{
				partModifierData._designerPartProperties = new PartModifierDataDesignerPartProperties(partModifierData);
			}
			partModifierData.OnInitialized();
			CreatedPartModifierDataEventArgs.RaiseStaticEvent(PartModifierData.Created, partModifierXml, partModifierStateXml, part, xmlVersion, partModifierData);
			return partModifierData;
		}

		public static List<Type> GetRegisteredPartModifierTypes()
		{
			return _partModifierTypes.Values.ToList();
		}

		public static string GetTypeId(Type type)
		{
			if (_typeIDLookup.TryGetValue(type, out var value))
			{
				return value;
			}
			object[] customAttributes = type.GetCustomAttributes(typeof(PartModifierTypeIdAttribute), inherit: false);
			if (customAttributes.Length != 0)
			{
				string text = null;
				string text2 = null;
				object[] array = customAttributes;
				for (int i = 0; i < array.Length; i++)
				{
					PartModifierTypeIdAttribute partModifierTypeIdAttribute = (PartModifierTypeIdAttribute)array[i];
					if (partModifierTypeIdAttribute.IsLegacyId)
					{
						text = partModifierTypeIdAttribute.Id;
					}
					else
					{
						text2 = partModifierTypeIdAttribute.Id;
					}
				}
				value = text2 ?? text;
			}
			else
			{
				value = GetDefaultTypeId(type);
			}
			_typeIDLookup.Add(type, value);
			return value;
		}

		public static void Register(System.Reflection.Assembly assembly, ILoadedMod mod)
		{
			if (_registeredAssemblies.Contains(assembly))
			{
				return;
			}
			_registeredAssemblies.Add(assembly);
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (!typeof(PartModifierData).IsAssignableFrom(type) || type.IsAbstract)
				{
					continue;
				}
				object[] customAttributes = type.GetCustomAttributes(typeof(PartModifierTypeIdAttribute), inherit: false);
				if (customAttributes.Length != 0)
				{
					object[] array = customAttributes;
					for (int j = 0; j < array.Length; j++)
					{
						PartModifierTypeIdAttribute partModifierTypeIdAttribute = (PartModifierTypeIdAttribute)array[j];
						_partModifierTypes[partModifierTypeIdAttribute.Id] = type;
						_partModifierModMap[type] = mod;
					}
				}
				else
				{
					_partModifierTypes[GetDefaultTypeId(type)] = type;
					_partModifierModMap[type] = mod;
				}
			}
		}

		public virtual void CopyFrom(PartModifierData sourcePartModifier, XElement sourcePartModifierStateElement)
		{
			RestoreFromState(sourcePartModifierStateElement, restoreAll: true);
		}

		public abstract PartModifierScript CreateScript();

		public abstract void DestroyScript();

		void IDisposable.Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
				_designerPartProperties?.Dispose();
				OnDisposed();
			}
		}

		public virtual XElement GenerateCompleteXml()
		{
			XElement xElement = new XElement(TypeId);
			MembersToSerialize membersToSerialize = GetMembersToSerialize(GetType(), stateMembersOnly: false);
			if (membersToSerialize.MemberNames.Length != 0)
			{
				_serializer.Serialize(xElement, this, membersToSerialize.MemberNames);
			}
			foreach (XAttribute item in xElement.Attributes().ToList())
			{
				string key = item.Name.LocalName.TrimStart('_');
				if (membersToSerialize.StatePreservationModes.ContainsKey(key) && membersToSerialize.StatePreservationModes[key] == PartModifierPropertyStatePreservationMode.SaveAlwaysIfNonEmpty && string.IsNullOrEmpty((string)item))
				{
					item.Remove();
				}
			}
			return xElement;
		}

		public XElement GenerateDesignerPartModfierXml(XElement partTypeModifierXml)
		{
			XElement defaultXml = DefaultXml;
			_forceAllowSerializationOptimization = true;
			try
			{
				DefaultXml = partTypeModifierXml;
				return GenerateStateXml();
			}
			finally
			{
				_forceAllowSerializationOptimization = false;
				DefaultXml = defaultXml;
			}
		}

		public virtual XElement GenerateStateXml(bool optimizeXml = true)
		{
			XElement xElement = new XElement(TypeId);
			MembersToSerialize membersToSerialize = GetMembersToSerialize(GetType(), stateMembersOnly: true);
			if (membersToSerialize.MemberNames.Length != 0)
			{
				_serializer.Serialize(xElement, this, membersToSerialize.MemberNames);
				if (optimizeXml && DefaultXml != null)
				{
					foreach (XAttribute item in xElement.Attributes().ToList())
					{
						if (membersToSerialize.AllowOptimization(item) || _forceAllowSerializationOptimization)
						{
							string text = ((string)DefaultXml.Attribute(item.Name)) ?? string.Empty;
							if (item.Value == text)
							{
								item.Remove();
							}
						}
					}
				}
			}
			return xElement;
		}

		public virtual IEnumerable<int> GetAssociatedActivationGroups()
		{
			return _EmptyEnumerableInt;
		}

		public virtual void GetModRequirements(AddModRequirementDelegate addModRequirement)
		{
			if (Mod != null)
			{
				addModRequirement(Mod.ModInfo, requiresCodeExecution: true);
			}
		}

		public abstract PartModifierScript GetScript();

		public virtual void OnDesignerPullout(string designerPartName, Assembly assembly, bool skipStartPartScale)
		{
		}

		public virtual void OnPartLoaded()
		{
		}

		public virtual void OnPartRecovered()
		{
		}

		public void RemoveModifier()
		{
			DestroyScript();
			OnRemoveModifier();
			Part.OnModifierRemoved(this);
			((IDisposable)this).Dispose();
		}

		public virtual void RestoreFromState(XElement stateElement, bool restoreAll)
		{
			Type type = GetType();
			MembersToSerialize membersToSerialize = GetMembersToSerialize(type, stateMembersOnly: true);
			if (membersToSerialize.MemberNames.Length != 0)
			{
				_serializer.Deserialize(stateElement, type, this, restoreAll, membersToSerialize.MemberNames);
			}
		}

		protected virtual string GetDefaultInputId()
		{
			string name = GetType().Name;
			if (!name.EndsWith("Data", StringComparison.Ordinal))
			{
				return name;
			}
			return name.Remove(name.Length - 4);
		}

		protected virtual void OnCreated(XElement partModifierXml)
		{
			if (partModifierXml != null)
			{
				Type type = GetType();
				MembersToSerialize membersToSerialize = GetMembersToSerialize(type, stateMembersOnly: false);
				if (membersToSerialize.MemberNames.Length != 0)
				{
					_serializer.Deserialize(partModifierXml, type, this, restoreMissingValuesAsNull: false, membersToSerialize.MemberNames);
				}
			}
			Part.OnModifierAdded(this);
		}

		protected virtual void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
		}

		protected virtual void OnDisposed()
		{
		}

		protected virtual void OnInitialized()
		{
		}

		protected virtual void OnRemoveModifier()
		{
		}

		protected virtual void OnUpgrade(int xmlVersion)
		{
		}

		protected virtual void OnXmlUpgrade(int xmlVersion, XElement xml)
		{
		}

		private static string GetDefaultTypeId(Type type)
		{
			string text = type.Name;
			if (text.EndsWith("Data", StringComparison.Ordinal))
			{
				text = text.Remove(text.Length - 4);
			}
			return text;
		}

		private static XElement GetDefaultXmlForType(Type modifierType)
		{
			if (!_createFromStateDefaultXmlLookup.TryGetValue(modifierType, out var value))
			{
				value = ((PartModifierData)Activator.CreateInstance(modifierType)).GenerateCompleteXml();
				_createFromStateDefaultXmlLookup[modifierType] = value;
			}
			return value;
		}

		private static void GetMembersToSerialize(List<string> memberNames, Dictionary<string, PartModifierPropertyStatePreservationMode> statePreservationModes, Type type, bool stateMembersOnly)
		{
			if (type != typeof(PartModifierData))
			{
				Type baseType = type.BaseType;
				if (baseType != null)
				{
					GetMembersToSerialize(memberNames, statePreservationModes, baseType, stateMembersOnly);
				}
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				List<PartModifierPropertyAttribute> list = fieldInfo.GetCustomAttributes(typeof(PartModifierPropertyAttribute), inherit: false).Cast<PartModifierPropertyAttribute>().ToList();
				if (list.Count > 1)
				{
					Debug.LogErrorFormat("Multiple PartModifierProperty attributes found on {0}.{1}. Designer attributes inherit from this attribute so both are not needed.", type.FullName, fieldInfo.Name);
				}
				PartModifierPropertyAttribute partModifierPropertyAttribute = list.FirstOrDefault();
				if (partModifierPropertyAttribute != null && (!stateMembersOnly || partModifierPropertyAttribute.PreserveState) && !partModifierPropertyAttribute.NeverSerialize)
				{
					string name = fieldInfo.Name;
					if (!memberNames.Contains(name))
					{
						memberNames.Add(name);
					}
					if (partModifierPropertyAttribute.PreserveStateMode != PartModifierPropertyStatePreservationMode.Default)
					{
						statePreservationModes[name.TrimStart('_')] = partModifierPropertyAttribute.PreserveStateMode;
					}
				}
			}
		}

		private static MembersToSerialize GetMembersToSerialize(Type type, bool stateMembersOnly)
		{
			if (stateMembersOnly ? (!_statePropertiesLookup.TryGetValue(type, out var value)) : (!_allPropertiesLookup.TryGetValue(type, out value)))
			{
				value = new MembersToSerialize();
				value.StatePreservationModes = new Dictionary<string, PartModifierPropertyStatePreservationMode>();
				List<string> list = new List<string>();
				GetMembersToSerialize(list, value.StatePreservationModes, type, stateMembersOnly);
				value.MemberNames = list.ToArray();
				if (stateMembersOnly)
				{
					_statePropertiesLookup[type] = value;
				}
				else
				{
					_allPropertiesLookup[type] = value;
				}
			}
			return value;
		}

		private string GetTypeId()
		{
			return GetTypeId(GetType());
		}
	}
	[Serializable]
	public abstract class PartModifierData<T> : PartModifierData where T : PartModifierScript
	{
		public T Script { get; private set; }

		public static event EventHandler<CreatedPartModifierScriptEventArgs> CreatedScript;

		public sealed override PartModifierScript CreateScript()
		{
			if (Script != null)
			{
				throw new Exception("The part modifier already has a script.");
			}
			IPartScript partScript = base.Part.PartScript;
			T val = CreateScriptComponent(partScript);
			if (val != null)
			{
				val.Initialize(this);
				Script = val;
				partScript.Modifiers.Add(val);
			}
			if (Game.InDesignerScene)
			{
				OnDesignerInitialization(base.DesignerPartProperties);
			}
			CreatedPartModifierScriptEventArgs.RaiseStaticEvent(PartModifierData<T>.CreatedScript, this, Script);
			return val;
		}

		public sealed override void DestroyScript()
		{
			T script = Script;
			if (!(script == null))
			{
				script.OnRemoveModifier();
				IPartScript partScript = base.Part.PartScript;
				partScript.Modifiers.Remove(script);
				DestroyScriptComponent(partScript);
				((IDisposable)script).Dispose();
				Script = null;
			}
		}

		public override PartModifierScript GetScript()
		{
			return Script;
		}

		protected virtual T CreateScriptComponent(IPartScript partScript)
		{
			return partScript.GameObject.AddComponent<T>();
		}

		protected virtual void DestroyScriptComponent(IPartScript partScript)
		{
			UnityEngine.Object.Destroy(Script);
		}
	}
}
