using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Multiplayer.SyncData;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	[Serializable]
	public class PartData
	{
		public class PartCreationInfo
		{
			public bool CreateChildren { get; set; }

			public bool CreateHingeJoints { get; set; }

			public bool CreateRigidBody { get; set; }

			public bool EnableWingScript { get; set; }

			public bool IsNonFlyableAircraft { get; set; }

			public bool IsRigidBodyKinematic { get; set; }

			public bool RemoteAircraft { get; set; }

			public PartCreationInfo()
			{
				CreateChildren = true;
				CreateHingeJoints = true;
				CreateRigidBody = true;
				EnableWingScript = true;
				IsRigidBodyKinematic = false;
				IsNonFlyableAircraft = false;
				RemoteAircraft = false;
			}
		}

		private List<ICraftDecal> _decals;

		private DetacherData _detacher;

		private float _loadedMassCached;

		private PartCreationInfo _partCreationInfo;

		private bool _recalculateLoadedMass;

		private PartMeshRenderQueue _renderQueue;

		public bool AllowTransformation => Modifiers.TrueForAll((PartModifierData modifier) => modifier.AllowTransformation);

		public List<AttachPointData> AttachPoints { get; private set; }

		public Vector3 CenterOfMass { get; set; }

		public IReadOnlyList<ICraftDecal> Decals => _decals;

		public bool DisableAircraftCollisions { get; set; }

		public float DragScale { get; set; }

		public PartDragType DragType
		{
			get
			{
				if (DragTypeAsConfigured != PartDragType.Default)
				{
					return DragTypeAsConfigured;
				}
				return DragTypeDefault;
			}
			set
			{
				DragTypeAsConfigured = value;
			}
		}

		public PartDragType DragTypeAsConfigured { get; set; }

		public PartDragType DragTypeDefault { get; set; }

		public float EmptyMass => PartType.Mass * MassScale;

		public bool Enabled { get; set; }

		public Guid? GroupId { get; set; }

		public float Health { get; private set; }

		[field: SerializeField]
		public int Id { get; set; }

		public bool InitiallyConnectedToMainCockpit { get; set; }

		public Vector3? InitialRotationMirrored { get; private set; }

		public bool IsCockpit => GetModifier<CockpitData>() != null;

		public bool IsPowertrainPart { get; private set; }

		public bool IsUsingConstantDrag => PartType.ConstantDrag > 0f;

		public CraftLoadContext LoadContext { get; }

		public float LoadedMass
		{
			get
			{
				if (_recalculateLoadedMass)
				{
					_recalculateLoadedMass = false;
					_loadedMassCached = (PartType.Mass + ModifierMass) * MassScale;
				}
				return _loadedMassCached;
			}
		}

		public float MassScale { get; set; }

		public List<int> MaterialIds { get; set; }

		public float ModifierMass
		{
			get
			{
				float num = 0f;
				for (int i = 0; i < Modifiers.Count; i++)
				{
					num += Modifiers[i].Mass;
				}
				return num;
			}
		}

		public List<PartModifierData> Modifiers { get; private set; }

		public string Name { get; set; }

		public PartCollisionResponseType PartCollisionResponse { get; private set; }

		public List<PartConnection> PartConnections { get; private set; }

		public PartCreationInfo PartCreationInfoUsedForInitialization => _partCreationInfo;

		public PartDrag PartDrag { get; private set; }

		public Vector3? PartScale { get; set; }

		public PartScript PartScript { get; private set; }

		public PartType PartType { get; set; }

		public Vector3 Position { get; private set; }

		public PartMeshRenderQueue RenderQueue
		{
			get
			{
				return _renderQueue;
			}
			set
			{
				if (_renderQueue != value)
				{
					_renderQueue = value;
					RaiseOnRenderQueueChangedEvent();
				}
			}
		}

		public Vector3 Rotation { get; private set; }

		public bool SharesRigidBody
		{
			get
			{
				if (_detacher == null || !_detacher.Enabled)
				{
					return PartType.SharesRigidBody;
				}
				return false;
			}
		}

		[field: SerializeField]
		public bool SymmetryDisabled { get; set; }

		[field: SerializeField]
		public uint SymmetryId { get; set; }

		public float UnderwaterDragScalar => PartType.UnderwaterDragScalar;

		public bool VisibleInDesigner { get; set; }

		public event EventHandler<EventArgs> RenderQueueChanged;

		public PartData(XElement element, int aircraftXmlVersion, CraftLoadContext loadContext)
		{
			LoadContext = loadContext;
			PartConnections = new List<PartConnection>();
			UpgradePartData(element, aircraftXmlVersion);
			Enabled = true;
			InitiallyConnectedToMainCockpit = false;
			DisableAircraftCollisions = element.GetBoolAttribute("disableAircraftCollisions");
			PartType = Game.Instance.PartTypes.GetPartType(element.Attribute("partType").Value);
			AttachPoints = PartType.CreateAttachPoints();
			AttachPointConnectionType attachPointConnectionType = (AttachPointConnectionType)176;
			foreach (AttachPointData attachPoint in AttachPoints)
			{
				if ((attachPoint.SeekType & attachPointConnectionType) != AttachPointConnectionType.None || (attachPoint.ReceiveType & attachPointConnectionType) != AttachPointConnectionType.None)
				{
					IsPowertrainPart = true;
					break;
				}
			}
			PartDrag = new PartDrag(element);
			Id = int.Parse(element.Attribute("id").Value);
			Name = element.GetStringAttribute("name");
			if (string.IsNullOrEmpty(Name))
			{
				Name = PartType.Name;
			}
			Health = element.GetFloatAttribute("health", PartType.Health);
			Position = element.GetVector3Attribute("position");
			Rotation = element.GetVector3Attribute("rotation");
			CenterOfMass = element.GetVector3Attribute("centerOfMass", PartType.CenterOfMass);
			MassScale = element.GetFloatAttribute("massScale", 1f);
			PartCollisionResponse = element.GetEnumAttribute("partCollisionResponse", PartCollisionResponseType.Default);
			RenderQueue = element.GetEnumAttribute("renderQueue", PartMeshRenderQueue.Default);
			GroupId = element.GetGuidAttributeOrNull("groupId");
			_recalculateLoadedMass = true;
			if (MassScale < 0f)
			{
				MassScale = 0f;
			}
			SymmetryDisabled = element.GetBoolAttribute("symmetryDisabled");
			SymmetryId = element.GetUintAttribute("symmetryId");
			VisibleInDesigner = element.GetBoolAttribute("visibleInDesigner", defaultValue: true);
			DragTypeDefault = PartType.DragType;
			DragType = (PartDragType)(((int?)element.GetEnumAttributeOrNull<PartDragType>("dragType")) ?? (element.TryGetBoolAttribute("calculateDrag", out var value) ? ((!value) ? 3 : 0) : 0));
			DragScale = element.GetFloatAttribute("dragScale", 1f);
			if (DragScale < 0f)
			{
				DragScale = 0f;
			}
			if (element.Attribute("initialRotationMirrored") != null)
			{
				InitialRotationMirrored = element.GetVector3Attribute("initialRotationMirrored");
			}
			PartScale = element.GetVector3AttributeOrNull("scale");
			if (PartScale == Vector3.one)
			{
				PartScale = null;
			}
			List<PartModifierData> value2;
			using (CollectionPool<List<PartModifierData>, PartModifierData>.Get(out value2))
			{
				PartType.CreateModifiers(this, element, aircraftXmlVersion, value2);
				Modifiers = new List<PartModifierData>(value2.Count);
				foreach (PartModifierData item in value2)
				{
					RegisterModifier(item);
				}
				MaterialIds = new List<int>();
				MaterialIds.AddRange(element.GetIntListAttribute("materials"));
				if (MaterialIds.Count < PartType.DefaultMaterialIds.Count)
				{
					for (int i = 0; i < MaterialIds.Count; i++)
					{
						if ((MaterialIds[i] < 0 && PartType.DefaultMaterialIds[i] >= 0) || (MaterialIds[i] >= 0 && PartType.DefaultMaterialIds[i] < 0))
						{
							MaterialIds[i] = PartType.DefaultMaterialIds[i];
						}
					}
					for (int j = MaterialIds.Count; j < PartType.DefaultMaterialIds.Count; j++)
					{
						MaterialIds.Add(PartType.DefaultMaterialIds[j]);
					}
				}
				else if (!PartType.DynamicMaterialIds && MaterialIds.Count > PartType.DefaultMaterialIds.Count)
				{
					MaterialIds.Clear();
					MaterialIds.AddRange(PartType.DefaultMaterialIds);
				}
				_decals = new List<ICraftDecal>();
			}
		}

		public static List<PartScript> ToPartScriptList(List<PartData> parts)
		{
			List<PartScript> list = new List<PartScript>();
			foreach (PartData part in parts)
			{
				list.Add(part.PartScript);
			}
			return list;
		}

		public bool AssignDecal(ICraftDecal decal)
		{
			if (!_decals.Contains(decal))
			{
				_decals.Add(decal);
				return true;
			}
			return false;
		}

		public PartScript CreateGameObject(AircraftScript aircraftScript, PartCreationInfo partCreationInfo)
		{
			GameObject gameObject = null;
			if (!string.IsNullOrEmpty(PartType.PrefabId))
			{
				gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/" + PartType.PrefabId, aircraftScript.Children);
			}
			else if (PartType.Mod != null && !string.IsNullOrEmpty(PartType.ModPrefabPath))
			{
				gameObject = PartType.Mod.ResourceLoader.LoadAsset<GameObject>(PartType.ModPrefabPath);
				gameObject.transform.SetParent(aircraftScript.Children, worldPositionStays: false);
			}
			return CreateGameObject(gameObject, aircraftScript, partCreationInfo);
		}

		public async UniTask<PartScript> CreateGameObjectAsync(AircraftScript aircraftScript, PartCreationInfo partCreationInfo)
		{
			GameObject gameObject = null;
			if (!string.IsNullOrEmpty(PartType.PrefabId))
			{
				gameObject = await Game.Instance.ResourceLoader.InstantiatePrefabAsync("Craft/Parts/" + PartType.PrefabId, aircraftScript.Children);
			}
			else if (PartType.Mod != null && !string.IsNullOrEmpty(PartType.ModPrefabPath))
			{
				gameObject = await PartType.Mod.ResourceLoader.LoadAssetAsync<GameObject>(PartType.ModPrefabPath);
				gameObject.transform.SetParent(aircraftScript.Children, worldPositionStays: false);
			}
			return CreateGameObject(gameObject, aircraftScript, partCreationInfo);
		}

		public void EnableModifiers()
		{
			foreach (PartModifierData modifier in Modifiers)
			{
				if ((!PartScript.Aircraft.IsNonFlyableAircraft || modifier.UsedInPropMode) && (modifier.EnabledForRemoteAircraft || !PartCreationInfoUsedForInitialization.RemoteAircraft))
				{
					PartModifierScript partModifierScript = modifier.Initialize(PartScript.gameObject, _partCreationInfo, PartScript.Aircraft);
					if (partModifierScript != null)
					{
						modifier.InitVariables(partModifierScript);
						PartScript.RegisterModifier(partModifierScript, scriptOnly: true);
						partModifierScript.Initialize(modifier, PartScript);
					}
				}
			}
			if (PartScript.Aircraft.LoadContext == CraftLoadContext.Flight)
			{
				PartSyncData syncData = new PartSyncData();
				foreach (PartModifierScript modifier2 in PartScript.Modifiers)
				{
					modifier2.InitializePartSyncData(syncData);
				}
				PartScript.InitializePartSyncData(syncData);
			}
			foreach (PartModifierData modifier3 in Modifiers)
			{
				modifier3.OnModifiersCreated();
			}
		}

		public XElement GenerateXml()
		{
			XElement xElement = new XElement("Part", new XAttribute("id", Id), new XAttribute("partType", PartType.PartTypeId), new XAttribute("position", PartScript.transform.position.ToXAttributeValue()), new XAttribute("rotation", PartScript.transform.eulerAngles.ToXAttributeValue()));
			PartDrag.WriteToXml(xElement);
			if (Name != PartType.Name && !string.IsNullOrEmpty(Name))
			{
				xElement.Add(new XAttribute("name", Name));
			}
			if (!Utilities.CompareVector3s(CenterOfMass, PartType.CenterOfMass))
			{
				xElement.Add(new XAttribute("centerOfMass", CenterOfMass.ToXAttributeValue()));
			}
			string text = string.Empty;
			foreach (int materialId in MaterialIds)
			{
				text = text + materialId + ",";
			}
			text = text.TrimEnd(',');
			xElement.Add(new XAttribute("materials", text));
			if (DisableAircraftCollisions)
			{
				xElement.Add(new XAttribute("disableAircraftCollisions", DisableAircraftCollisions.ToString().ToLower()));
			}
			if (PartScale.HasValue)
			{
				xElement.Add(new XAttribute("scale", PartScale.Value.ToXAttributeValue()));
			}
			if (MassScale != 1f)
			{
				xElement.Add(new XAttribute("massScale", MassScale));
			}
			if (SymmetryDisabled)
			{
				xElement.Add(new XAttribute("symmetryDisabled", SymmetryDisabled));
			}
			if (SymmetryId != 0)
			{
				xElement.Add(new XAttribute("symmetryId", SymmetryId));
			}
			if (!VisibleInDesigner)
			{
				xElement.Add(new XAttribute("visibleInDesigner", VisibleInDesigner));
			}
			if (DragTypeAsConfigured != PartDragType.Default)
			{
				xElement.Add(new XAttribute("dragType", DragTypeAsConfigured));
			}
			if (DragScale != 1f)
			{
				xElement.Add(new XAttribute("dragScale", DragScale));
			}
			if (Health != PartType.Health)
			{
				xElement.Add(new XAttribute("health", Health));
			}
			xElement.Add(new XAttribute("partCollisionResponse", PartCollisionResponse));
			if (RenderQueue != PartMeshRenderQueue.Default)
			{
				xElement.Add(new XAttribute("renderQueue", RenderQueue));
			}
			if (GroupId.HasValue)
			{
				xElement.Add(new XAttribute("groupId", GroupId.Value.ToString()));
			}
			foreach (PartModifierData modifier in Modifiers)
			{
				XElement xElement2 = modifier.GenerateStateXml();
				if (xElement2 != null && (xElement2.HasAttributes || xElement2.HasElements))
				{
					xElement.Add(xElement2);
				}
			}
			return xElement;
		}

		public AttachPointData GetAttachPoint(int attachPointId)
		{
			foreach (AttachPointData attachPoint in AttachPoints)
			{
				if (attachPoint.Id == attachPointId)
				{
					return attachPoint;
				}
			}
			return null;
		}

		public T GetModifier<T>() where T : PartModifierData
		{
			foreach (PartModifierData modifier in Modifiers)
			{
				if (modifier is T result)
				{
					return result;
				}
			}
			return null;
		}

		public PartModifierData GetModifier(Type type)
		{
			foreach (PartModifierData modifier in Modifiers)
			{
				if (modifier.GetType() == type)
				{
					return modifier;
				}
			}
			return null;
		}

		public List<T> GetModifiers<T>() where T : PartModifierData
		{
			List<T> list = new List<T>();
			foreach (PartModifierData modifier in Modifiers)
			{
				if (modifier is T item)
				{
					list.Add(item);
				}
			}
			return list;
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

		public void OnPartCloned(PartData sourcePart)
		{
			foreach (PartModifierData modifier in Modifiers)
			{
				modifier.OnPartCloned(sourcePart);
			}
		}

		public void RecalculateLoadedMass(bool recalculateModifierMass)
		{
			_recalculateLoadedMass = true;
			if (!recalculateModifierMass)
			{
				return;
			}
			foreach (PartModifierData modifier in Modifiers)
			{
				modifier.RecalculateMass(recalculatePartMass: false);
			}
		}

		public void RegisterModifier(PartModifierData modifier)
		{
			Modifiers.Add(modifier);
			if (modifier is DetacherData detacher)
			{
				_detacher = detacher;
			}
		}

		public override string ToString()
		{
			return base.ToString() + $" (Id: {Id}, Name: {Name})";
		}

		public bool TryGetModifier<T>(out T result) where T : PartModifierData
		{
			foreach (PartModifierData modifier in Modifiers)
			{
				if (modifier is T val)
				{
					result = val;
					return true;
				}
			}
			result = null;
			return false;
		}

		public bool UnassignDecal(ICraftDecal decal)
		{
			if (_decals.Contains(decal))
			{
				_decals.Remove(decal);
				return true;
			}
			return false;
		}

		public void UnregisterModifier(PartModifierData modifier)
		{
			Modifiers.Remove(modifier);
			if (modifier == _detacher)
			{
				_detacher = null;
			}
		}

		private static void SetBehaviorEnabledInChildren<T>(GameObject gameObject, bool enabled) where T : MonoBehaviour
		{
			for (int i = 0; i < gameObject.transform.childCount; i++)
			{
				if (gameObject.transform.GetChild(i).TryGetComponent<T>(out var component))
				{
					component.enabled = enabled;
				}
				SetBehaviorEnabledInChildren<T>(gameObject.transform.GetChild(i).gameObject, enabled);
			}
		}

		private static void SetColliderEnabledInChildren(GameObject gameObject, bool enabled)
		{
			for (int i = 0; i < gameObject.transform.childCount; i++)
			{
				if (gameObject.transform.GetChild(i).TryGetComponent<Collider>(out var component))
				{
					component.enabled = enabled;
				}
				SetColliderEnabledInChildren(gameObject.transform.GetChild(i).gameObject, enabled);
			}
		}

		private static void SetRendererEnableldInChildren(GameObject gameObject, bool enabled)
		{
			for (int i = 0; i < gameObject.transform.childCount; i++)
			{
				if (gameObject.transform.GetChild(i).TryGetComponent<Renderer>(out var component))
				{
					component.enabled = enabled;
				}
				SetRendererEnableldInChildren(gameObject.transform.GetChild(i).gameObject, enabled);
			}
		}

		private PartScript CreateGameObject(GameObject instantiatedPrefab, AircraftScript aircraftScript, PartCreationInfo partCreationInfo)
		{
			if (instantiatedPrefab == null)
			{
				Debug.LogErrorFormat("Unable to load part '{0}' because its prefab could not be found", PartType.PartTypeId);
				return null;
			}
			instantiatedPrefab.name = PartType.Name;
			instantiatedPrefab.transform.SetPositionAndRotation(Position + aircraftScript.transform.position, Quaternion.Euler(Rotation));
			PartScript partScript = instantiatedPrefab.AddComponent<PartScript>();
			bool flag = aircraftScript.LoadContext == CraftLoadContext.Designer;
			EnabledScript[] componentsInChildren = partScript.transform.GetComponentsInChildren<EnabledScript>(includeInactive: true);
			foreach (EnabledScript enabledScript in componentsInChildren)
			{
				enabledScript.gameObject.SetActive(enabledScript.EnabledInDesigner == flag);
				if (!enabledScript.gameObject.activeSelf && !flag)
				{
					UnityEngine.Object.Destroy(enabledScript.gameObject);
				}
			}
			partScript.Initialize(this, aircraftScript);
			if (flag)
			{
				partScript.CreateAttachPoints();
			}
			_partCreationInfo = partCreationInfo;
			PartScript = partScript;
			return partScript;
		}

		private void RaiseOnRenderQueueChangedEvent()
		{
			this.RenderQueueChanged?.Invoke(this, new EventArgs());
		}

		private void UpgradePartData(XElement xml, int xmlVersion)
		{
			if (xmlVersion == 8 && xml.GetStringAttribute("partType") == "Decal-1")
			{
				xml.SetAttributeValue("partType", "TextureDecal-1");
				XElement xElement = xml.Element("Decal.State");
				if (xElement != null)
				{
					xElement.Name = "TextureDecal.State";
				}
			}
			if (xmlVersion >= 22)
			{
				return;
			}
			XElement xElement2 = xml.Element("Button.State");
			if (xElement2 != null)
			{
				string stringAttribute = xElement2.GetStringAttribute("inputId");
				if (stringAttribute != null)
				{
					stringAttribute = stringAttribute.Replace("ActivateCatapult", "Interact");
					xElement2.SetAttributeValue("inputId", stringAttribute);
				}
			}
		}
	}
}
