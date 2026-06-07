using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Craft.Parts.Events;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Design;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.Flight;
using Assets.Scripts.Levels;
using Assets.Scripts.Multiplayer.SyncData;
using Cysharp.Threading.Tasks;
using FishNet.Serializing;
using Jundroo.Common.Expressions;
using Jundroo.Common.Platform;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	[SelectionBase]
	public class PartScript : MonoBehaviour
	{
		public class PartScriptEventArgs : EventArgs
		{
			public PartScript PartScript { get; }

			public PartScriptEventArgs(PartScript partScript)
			{
				PartScript = partScript;
			}
		}

		private static class Profile
		{
			public static readonly ProfilerMarker OnPreStartDecalAndPaintInitialization = new ProfilerMarker("PartScript.OnPreStartDecalAndPaintInitialization");

			public static readonly ProfilerMarker OnPreStartLayerUpdates = new ProfilerMarker("PartScript.OnPreStartLayerUpdates");
		}

		public AudioClip JointBreakClip;

		private static float[] _partDamageLevelThresholds = new float[4] { 0.01f, 0.3f, 0.6f, 0.9f };

		private GameObject _attachPointsGameObject;

		private List<IPartCollisionHandler> _collisionHandlers;

		private List<DecalTargetScript> _decalTargets;

		private IPartDragPhysics _dragPhysics;

		private Context _expressionContext;

		private bool _initialized;

		private bool _isDragging;

		private Collider _partCollider;

		private Matrix4x4? _partToCraftOriginMatrix;

		private bool _selected;

		private bool _underWater;

		private float _waterHeightDisplacement;

		private Action<float> _waterHeightQueryCallback;

		public AircraftScript Aircraft { get; private set; }

		public List<AttachPointScript> AttachPointScripts { get; private set; }

		public BodyScript Body { get; set; }

		public bool ConnectedToMainCockpit { get; set; }

		public bool Culled { get; set; }

		public IReadOnlyList<DecalTargetScript> DecalTargets => _decalTargets;

		public List<EditorCollider> EditorColliders { get; private set; }

		public float EstimateOfUnderwaterPercent { get; private set; }

		public Context ExpressionContext => Aircraft.ExpressionContext;

		public bool InPlaneDesigner => LoadContext == CraftLoadContext.Designer;

		public bool IsDragging
		{
			get
			{
				return _isDragging;
			}
			set
			{
				if (_isDragging != value)
				{
					_isDragging = value;
					this.DraggingChanged?.Invoke(value);
				}
			}
		}

		public bool IsInteractable => PartMaterialScript.Visible;

		public bool IsSelected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
					RefreshAttachPointVisibility();
				}
			}
		}

		public CraftLoadContext LoadContext => Part.LoadContext;

		public float MaxHealth { get; private set; }

		public List<PartModifierScript> Modifiers { get; private set; }

		[field: SerializeField]
		public PartData Part { get; private set; }

		public float PartDamage { get; protected set; }

		public PartDamageLevel PartDamageLevel { get; private set; }

		public PartGroupScript PartGroup { get; set; }

		public PartMaterialScript PartMaterialScript { get; set; }

		public Matrix4x4 PartToCraftOriginMatrix => _partToCraftOriginMatrix ?? base.transform.localToWorldMatrix;

		public bool PhysicsEnabled => !Part.PartCreationInfoUsedForInitialization.RemoteAircraft;

		public Collider PrimaryPartCollider
		{
			get
			{
				return _partCollider;
			}
			set
			{
				_partCollider = value;
			}
		}

		public Collider PrimaryPlacementCollider { get; set; }

		public IPartSyncData SyncData { get; private set; }

		public bool ThudSoundDisabled { get; set; }

		public event Action<bool> DraggingChanged;

		public event EventHandler<EventArgs> LayerAssignmentsCompleted;

		public event EventHandler<PartConnectionChangedEventArgs> PartConnectionChanged;

		public event EventHandler<PartScriptEventArgs> PartDeleted;

		public PartScript()
		{
			AttachPointScripts = new List<AttachPointScript>();
			EditorColliders = new List<EditorCollider>();
			Modifiers = new List<PartModifierScript>();
			_decalTargets = new List<DecalTargetScript>();
		}

		public void AssignDecal(ICraftDecal decal)
		{
			if (!Part.AssignDecal(decal))
			{
				return;
			}
			foreach (DecalTargetScript decalTarget in _decalTargets)
			{
				decalTarget.OnDecalAssigned(decal);
			}
		}

		public void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			plan.Register(this, OnPreStart);
			plan.Register(OnPreStartLayerUpdates, PreStartInitializationFlags.FlightDefault, 600);
			plan.Register(OnPreStartDecalAndPaintInitialization, PreStartInitializationFlags.FlightDefault | PreStartInitializationFlags.MenuScene, 700);
			PartMaterialScript.BuildPreStartInitializationPlan(plan);
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.BuildPreStartInitializationPlan(plan);
			}
		}

		public void ConnectToPart(AttachPointScript thisAttachPointScript, AttachPointScript targetAttachPointScript, bool isSymmetryOperation = false)
		{
			PartData part = targetAttachPointScript.PartScript.Part;
			PartConnection partConnection = Part.GetPartConnection(part);
			if (partConnection == null)
			{
				partConnection = new PartConnection(Part, part);
			}
			else if (partConnection.AttachPointsA.Contains(thisAttachPointScript.AttachPoint) && partConnection.AttachPointsB.Contains(targetAttachPointScript.AttachPoint))
			{
				Debug.LogError($"Attempting to add duplicate attachment from {Part?.Name}#{Part?.Id} AP#{thisAttachPointScript.AttachPoint.Id} to {part?.Name}#{part?.Id} AP#{targetAttachPointScript.AttachPoint.Id}");
			}
			partConnection.AddAttachPointA(thisAttachPointScript.AttachPoint);
			partConnection.AddAttachPointB(targetAttachPointScript.AttachPoint);
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnConnectedToPart(thisAttachPointScript.AttachPoint, part, targetAttachPointScript.AttachPoint, isSymmetryOperation);
			}
			foreach (PartModifierScript modifier2 in part.PartScript.Modifiers)
			{
				modifier2.OnConnectedToPart(targetAttachPointScript.AttachPoint, Part, thisAttachPointScript.AttachPoint, isSymmetryOperation);
			}
			thisAttachPointScript.PartScript.OnPartConnectionChanged(partConnection, isSymmetryOperation);
			targetAttachPointScript.PartScript.OnPartConnectionChanged(partConnection, isSymmetryOperation);
		}

		public void CreateAttachPoints()
		{
			_attachPointsGameObject = new GameObject("AttachPoints");
			_attachPointsGameObject.transform.parent = base.transform;
			_attachPointsGameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			_attachPointsGameObject.transform.localRotation = Quaternion.identity;
			_attachPointsGameObject.transform.localPosition = default(Vector3);
			foreach (AttachPointData attachPoint in Part.AttachPoints)
			{
				if (attachPoint.IsSurfaceAttachPoint)
				{
					Collider firstChild = Utilities.GetFirstChild<Collider>(attachPoint.Surface, this);
					if (firstChild != null)
					{
						firstChild.gameObject.layer = 15;
						AttachPointScript attachPointScript = (attachPoint.AttachPointScript = firstChild.gameObject.AddComponent<AttachPointScript>());
						attachPointScript.AttachPoint = attachPoint;
						attachPointScript.PartScript = this;
						AttachPointScripts.Add(attachPointScript);
					}
					else if (attachPoint.Surface == ".")
					{
						AttachPointScript attachPointScript3 = (attachPoint.AttachPointScript = base.gameObject.AddComponent<AttachPointScript>());
						attachPointScript3.AttachPoint = attachPoint;
						attachPointScript3.PartScript = this;
						AttachPointScripts.Add(attachPointScript3);
					}
				}
				else
				{
					GameObject obj = new GameObject("AttachPoint");
					obj.layer = 14;
					obj.transform.parent = _attachPointsGameObject.transform;
					obj.transform.localPosition = attachPoint.Position;
					obj.transform.localRotation = Quaternion.FromToRotation(Vector3.forward, attachPoint.Normal);
					obj.AddComponent<BoxCollider>().size = new Vector3(0.25f, 0.25f, 0.05f);
					AttachPointScript attachPointScript5 = (attachPoint.AttachPointScript = obj.AddComponent<AttachPointScript>());
					attachPointScript5.AttachPoint = attachPoint;
					attachPointScript5.PartScript = this;
					AttachPointScripts.Add(attachPointScript5);
				}
			}
		}

		public float GetAltitudeAgl(float raycastHeight = 0f)
		{
			Vector3 position = base.transform.position;
			if (Physics.Raycast(position + new Vector3(0f, raycastHeight, 0f), Vector3.down, out var hitInfo, float.PositiveInfinity, 9441296))
			{
				return hitInfo.distance - raycastHeight;
			}
			return position.y - (GameWorld.Instance.FloatingOriginSeaLevel ?? (0f - GameWorld.Instance.FloatingOriginOffset.y));
		}

		public void GetForwardAndUpVectorsForRayHit(Vector3 attachPointNormal, bool preferUp, out Vector3 forward, out Vector3 up)
		{
			up = attachPointNormal;
			forward = (preferUp ? Vector3.up : Vector3.forward);
			if (Mathf.Abs(Vector3.Dot(up, forward)) >= 0.9f)
			{
				forward = (preferUp ? Vector3.forward : Vector3.up);
			}
		}

		public T GetModifier<T>() where T : PartModifierScript
		{
			foreach (PartModifierScript modifier in Modifiers)
			{
				T val = modifier as T;
				if (val != null)
				{
					return val;
				}
			}
			return null;
		}

		public List<T> GetModifiers<T>() where T : PartModifierScript
		{
			List<T> list = new List<T>();
			foreach (PartModifierScript modifier in Modifiers)
			{
				T val = modifier as T;
				if (val != null)
				{
					list.Add(val);
				}
			}
			return list;
		}

		public T GetModifierWithInterface<T>() where T : class
		{
			foreach (PartModifierScript modifier in Modifiers)
			{
				if (modifier is T result)
				{
					return result;
				}
			}
			return null;
		}

		public bool HasModifier<T>() where T : PartModifierScript
		{
			return GetModifier<T>() != null;
		}

		public void Initialize(PartData part, AircraftScript aircraft)
		{
			Part = part;
			Aircraft = aircraft;
			MaxHealth = Mathf.Max(part.Health, 1f);
			PartMaterialScript = base.gameObject.AddComponent<PartMaterialScript>();
			PartMaterialScript.Initialize(aircraft);
			if (LoadContext == CraftLoadContext.Designer && Part.PartScale.HasValue)
			{
				base.transform.localScale = Part.PartScale.Value;
			}
			if (base.isActiveAndEnabled)
			{
				Aircraft.CraftUpdate.Register(this);
			}
			Aircraft.CraftUpdate.RegisterUpdate(CraftUpdateType.Start, this, OnStart, CraftUpdateFlags.Default, -800);
			_initialized = true;
		}

		public void InitializePartSyncData(PartSyncData syncData)
		{
			SyncData = syncData;
		}

		public void OnBeginReposition()
		{
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnBeginReposition();
			}
		}

		public bool OnCollision(Collision collision, in ContactPoint contactPoint)
		{
			if (_collisionHandlers != null)
			{
				foreach (IPartCollisionHandler collisionHandler in _collisionHandlers)
				{
					if (collisionHandler.OnCollision(this, collision, in contactPoint))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual void OnDamaged(int? attackerPlayerId, float damage, Vector3 position, Vector3 direction)
		{
			if (Aircraft.RemoteAircraft)
			{
				return;
			}
			PartDamage += damage;
			Aircraft.OnDamaged(attackerPlayerId, damage);
			if (Aircraft.Damage >= (((float?)Aircraft.Aircraft.DamageLimit) ?? float.MaxValue))
			{
				Aircraft.QueueExplosion(Aircraft.MainCockpit, 100f);
			}
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnDamaged(damage, position, direction);
			}
			if (PartDamageLevel == PartDamageLevel.Critical)
			{
				Body.OnPartDamageLevelIncreased(this);
			}
			for (int i = (int)PartDamageLevel; i < _partDamageLevelThresholds.Length; i++)
			{
				float num = _partDamageLevelThresholds[i] * MaxHealth;
				if (!(PartDamage > num) && !Mathf.Approximately(PartDamage, num))
				{
					break;
				}
				OnDamageLevelIncreased((PartDamageLevel)(i + 1), damage, position, direction);
			}
			Aircraft.LogDamageMessage(this);
			PartMaterialScript.OnPartDamaged();
		}

		public virtual void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			PartDamageLevel = level;
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnDamageLevelIncreased(level, lastDamage, lastDamagePosition, lastDamageDirection);
			}
			Body.OnPartDamageLevelIncreased(this);
		}

		public void OnEndReposition()
		{
			OnExitWater();
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnEndReposition();
			}
		}

		public void OnEnterWater()
		{
			LevelBase.CurrentLevel.OnPartEnterWater(this);
			Aircraft.PartEnteredWater(this);
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnEnterWater();
			}
		}

		public void OnExitWater()
		{
			LevelBase.CurrentLevel.OnPartExitedWater(this);
			Aircraft.PartExitedWater(this);
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnExitWater();
			}
		}

		public virtual void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			_dragPhysics.FixedUpdate();
		}

		public void OnJointBreak(float breakForce)
		{
			AudioSource.PlayClipAtPoint(JointBreakClip, base.transform.position, 10f);
		}

		public virtual void OnLateUpdate(in CraftUpdateFrameData frame)
		{
			float? floatingOriginSeaLevel = GameWorld.Instance.FloatingOriginSeaLevel;
			if (!(_partCollider != null) || !floatingOriginSeaLevel.HasValue || !(Time.deltaTime > 0f))
			{
				return;
			}
			Bounds bounds = _partCollider.bounds;
			float num = floatingOriginSeaLevel.Value + _waterHeightDisplacement;
			FlightSceneScript.Instance.WaterQueryManager.QueryHeightDisplacement(bounds.center, _waterHeightQueryCallback);
			float num2 = bounds.min.y - num;
			if (num2 <= 0f)
			{
				if (!_underWater)
				{
					_underWater = true;
					OnEnterWater();
				}
			}
			else if (_underWater)
			{
				_underWater = false;
				OnExitWater();
				EstimateOfUnderwaterPercent = 0f;
			}
			if (_underWater)
			{
				float num3 = bounds.max.y - num - num2;
				EstimateOfUnderwaterPercent = Mathf.Clamp(Mathf.Abs(num2) / num3, 0f, 1000f);
			}
			_dragPhysics.Update(EstimateOfUnderwaterPercent);
		}

		public void OnPartAdded()
		{
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnPartAdded();
			}
		}

		public virtual void OnPartConnectionChanged(PartConnection connection, bool isSymmetryOperation = false)
		{
			this.PartConnectionChanged?.Invoke(this, new PartConnectionChangedEventArgs(connection, isSymmetryOperation));
			RefreshAttachPointVisibility();
		}

		public void OnPartDeleted()
		{
			this.PartDeleted?.Invoke(this, new PartScriptEventArgs(this));
		}

		public void OnReceiveNetworkMessage(byte messageType, PooledReader reader)
		{
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnReceiveNetworkMessage(messageType, reader);
			}
		}

		public void PreviewDesignerPlacement(AttachPointData myAttachPointBeingUsed, AttachPointData theirAttachPointToPreviewConnectionTo, PartSelection selection)
		{
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.PreviewPartPlacement(myAttachPointBeingUsed, theirAttachPointToPreviewConnectionTo, selection);
			}
		}

		public void RegisterDecalTarget(DecalTargetScript decalTarget)
		{
			if (!_decalTargets.Contains(decalTarget))
			{
				_decalTargets.Add(decalTarget);
			}
			else
			{
				Debug.LogError("Attempted to register a decal target with a part script but it was already registered.");
			}
		}

		public void RegisterModifier(PartModifierScript modifier, bool scriptOnly)
		{
			Modifiers.Add(modifier);
			if (!scriptOnly)
			{
				Part.RegisterModifier(modifier.PartModifier);
			}
			if (modifier is IPartCollisionHandler handler)
			{
				RegisterCollisionHandler(handler);
			}
		}

		public void ReinitializeCraftDecalRenderers()
		{
			foreach (DecalTargetScript decalTarget in _decalTargets)
			{
				decalTarget.ReinitializeRenderers();
			}
		}

		public void SetAttachPointsVisible(bool visible)
		{
			foreach (AttachPointScript attachPointScript in AttachPointScripts)
			{
				Renderer[] componentsInChildren = attachPointScript.gameObject.GetComponentsInChildren<Renderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = visible;
				}
			}
		}

		public void UnassignDecal(ICraftDecal decal)
		{
			if (!Part.UnassignDecal(decal))
			{
				return;
			}
			foreach (DecalTargetScript decalTarget in _decalTargets)
			{
				decalTarget.OnDecalUnassigned(decal);
			}
		}

		public void UnregisterDecalTarget(DecalTargetScript decalTarget)
		{
			if (!_decalTargets.Remove(decalTarget))
			{
				Debug.LogError("Attempted to unregister a decal target with a part script but it was not registered.");
			}
		}

		public void UnregisterModifier(PartModifierScript modifier, bool scriptOnly)
		{
			Modifiers.Remove(modifier);
			if (!scriptOnly)
			{
				Part.UnregisterModifier(modifier.PartModifier);
			}
			if (modifier is IPartCollisionHandler handler)
			{
				UnregisterCollisionHandler(handler);
			}
		}

		public void UpdateRotationForAttachment(Quaternion rotation)
		{
			base.transform.rotation = rotation;
		}

		public void UpdateRotationForAttachment(Vector3 forward, Vector3 up)
		{
			UpdateRotationForAttachment(Quaternion.LookRotation(forward, up));
		}

		protected virtual void OnDisable()
		{
			if (_initialized)
			{
				Aircraft.CraftUpdate.Unregister(this);
			}
		}

		protected virtual void OnEnable()
		{
			if (_initialized)
			{
				Aircraft.CraftUpdate.Register(this);
			}
		}

		[ContextMenu("Debug Break")]
		private void DebugBreakPart()
		{
			Debug.Log("Set breakpoint here");
		}

		private Collider GetPrimaryPartCollider()
		{
			Collider collider = null;
			PartColliderScript[] componentsInChildren = GetComponentsInChildren<PartColliderScript>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].IsPrimary)
				{
					if ((object)collider != null)
					{
						Debug.LogWarning($"More than one collider was specified as a primary collider for part {Part.Id} ({Part.PartType.Name}).", this);
						break;
					}
					collider = componentsInChildren[i].Collider;
				}
			}
			return collider;
		}

		private void MoveCollidersToLayer(int layer)
		{
			Collider[] componentsInChildren = GetComponentsInChildren<Collider>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].gameObject.layer = layer;
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			if (loadContext == CraftLoadContext.Flight)
			{
				_waterHeightQueryCallback = delegate(float x)
				{
					_waterHeightDisplacement = x;
				};
				_dragPhysics = Body.DragPhysics.CreatePartDragPhysics(this);
			}
			bool num = loadContext != CraftLoadContext.Designer && Part.PartScale.HasValue;
			Vector3 localScale = Vector3.one;
			if (num)
			{
				localScale = base.transform.localScale;
				base.transform.localScale = Part.PartScale.Value;
			}
			if (loadContext != CraftLoadContext.Studio)
			{
				PartMaterialScript.InitializeBakedMeshData(Aircraft.MainCockpit.transform);
			}
			if (loadContext != CraftLoadContext.Designer)
			{
				_partToCraftOriginMatrix = UnityTransformUtility.GetTargetToAncestorTransformMatrix(base.transform, Aircraft.transform);
			}
			if (num)
			{
				base.transform.localScale = localScale;
			}
			return UniTask.CompletedTask;
		}

		private UniTask OnPreStartDecalAndPaintInitialization(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			using (Profile.OnPreStartDecalAndPaintInitialization.Auto())
			{
				PartMaterialScript.BakeMeshData();
				if (loadContext == CraftLoadContext.Flight)
				{
					List<DecalTargetScript> value;
					using (CollectionPool<List<DecalTargetScript>, DecalTargetScript>.Get(out value))
					{
						GetComponentsInChildren(includeInactive: true, value);
						foreach (DecalTargetScript item in value)
						{
							item.Initialize(this);
						}
					}
				}
				return UniTask.CompletedTask;
			}
		}

		private UniTask OnPreStartLayerUpdates(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			using (Profile.OnPreStartLayerUpdates.Auto())
			{
				LayerUtility.SetLayerRecursive(base.gameObject, 21, 19);
				if (Aircraft.RemoteAircraft)
				{
					MoveCollidersToLayer(26);
				}
				else if (Part.DisableAircraftCollisions)
				{
					MoveCollidersToLayer(25);
				}
				this.LayerAssignmentsCompleted?.Invoke(this, EventArgs.Empty);
				return UniTask.CompletedTask;
			}
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			if (_partCollider == null)
			{
				_partCollider = GetPrimaryPartCollider();
			}
			if (PrimaryPlacementCollider == null)
			{
				PrimaryPlacementCollider = _partCollider;
			}
			bool flag = LoadContext == CraftLoadContext.Flight && Device.IsUnityEditor;
			if ((object)_partCollider == null && flag && Part.PartType.RequiresPrimaryPartCollider)
			{
				Debug.LogWarning($"No primary collider could be found for part {Part.Id} ({Part.PartType.Name}).", this);
			}
			if (LoadContext != CraftLoadContext.Designer && Part.PartScale.HasValue)
			{
				base.transform.localScale = Part.PartScale.Value;
				if (this == Aircraft.MainCockpit)
				{
					Vector3 com = Vector3.Scale(Aircraft.OrientedCenterOfMassRigidBodies.transform.localPosition, new Vector3(1f / base.transform.localScale.x, 1f / base.transform.localScale.y, 1f / base.transform.localScale.z));
					Aircraft.SetPositionOfCenterOfMass(com, local: true);
				}
			}
		}

		private void RefreshAttachPointVisibility()
		{
			foreach (AttachPointScript attachPointScript in AttachPointScripts)
			{
				if (attachPointScript.AttachPoint.Display && attachPointScript.AttachPoint.IsAvailable)
				{
					attachPointScript.ShowGizmo(_selected);
				}
				else
				{
					attachPointScript.ShowGizmo(show: false);
				}
			}
		}

		private void RegisterCollisionHandler(IPartCollisionHandler handler)
		{
			(_collisionHandlers ?? (_collisionHandlers = new List<IPartCollisionHandler>())).Add(handler);
		}

		private void UnregisterCollisionHandler(IPartCollisionHandler handler)
		{
			_collisionHandlers?.Remove(handler);
		}
	}
}
