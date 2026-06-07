using System;
using System.Collections.Generic;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using Assets.Scripts.Design;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.MapView;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Social.Achievements;
using ModApi;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Propulsion;
using ModApi.Design;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Settings;
using ModApi.Ui.Inspector;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Craft.Parts
{
	[GameLoopExecutionOrder(-4700)]
	public class PartScript : MonoBehaviourBase, IPartScript, IDesignerStart, IGameLoopItem, IFlightStart, IFlightPostStart, IFlightFixedUpdate, IFlightFixedUpdateWarp, INavSphereTarget
	{
		private struct FrameDamage
		{
			public float Basic;

			public float Explosion;

			public float Heat;

			public float GForce;

			public float Overexpansion;

			public float Overspin;

			public float Pressure;

			public float Total => Basic + Heat + Overexpansion + Overspin + Pressure + Explosion;

			public void Clear()
			{
				Explosion = (Pressure = (Overexpansion = (Overspin = (Heat = (Basic = 0f)))));
			}
		}

		private class InertiaTensorCollider
		{
			public bool EnabledStateToggled { get; set; }

			public GameObject GameObject { get; set; }

			public bool RequiredForCalculation { get; set; }
		}

		private static bool _achievementUnlockedIcarus = false;

		private static FlightSettings _flightSettings;

		private static List<Collider> _tempListCalculateBoundsColliders = new List<Collider>();

		private GameObject _attachPointsGameObject;

		private IBodyScript _bodyScript;

		private Vector3 _cachedPosition = Vector3.zero;

		[SerializeField]
		private CommandPodScript _commandPod;

		private PartDesignerInteractionMode _designerInteractionMode;

		private FrameDamage _frameDamage;

		private List<IHeatSource> _heatSources = new List<IHeatSource>();

		private List<InertiaTensorCollider> _inertiaTensorColliders = new List<InertiaTensorCollider>();

		private DateTime? _lastExplodeButtonClick;

		private float _maxDrag;

		private List<PartModifierScript> _modifiers;

		private ICraftScript _oldCraftScript;

		private bool _positionIsDirty = true;

		[SerializeField]
		[Range(0f, 100f)]
		private float _reentryEffectStrength;

		[SerializeField]
		private bool _reentryEffectStrengthOverride;

		private IReferenceFrame _referenceFrame;

		[SerializeField]
		[Range(0f, 100f)]
		private float _vaporTrailStrength;

		public List<AttachPointScript> AttachPointScripts { get; private set; }

		public bool AttachPointsEnabled => _attachPointsGameObject.activeSelf;

		public IFuelSource BatteryFuelSource
		{
			get
			{
				if (CommandPod != null)
				{
					return CommandPod.BatteryFuelSource;
				}
				return EmptyFuelSource.GetOrCreate(FuelType.Battery);
			}
		}

		public IBodyScript BodyScript
		{
			get
			{
				return _bodyScript;
			}
			set
			{
				_bodyScript = value;
			}
		}

		public Vector3 CachedPosition
		{
			get
			{
				if (_positionIsDirty)
				{
					_cachedPosition = Transform.position;
					_positionIsDirty = false;
				}
				return _cachedPosition;
			}
		}

		public bool CanRefuseConnection { get; private set; }

		public List<PartColliderScript> Colliders { get; private set; }

		public bool CollisionSoundsEnabled { get; set; }

		public ICommandPod CommandPod => _commandPod;

		public ICraftScript CraftScript { get; private set; }

		public PartData Data { get; protected set; }

		public PartDesignerInteractionMode DesignerInteractionMode
		{
			get
			{
				return _designerInteractionMode;
			}
			set
			{
				if (_designerInteractionMode == value)
				{
					return;
				}
				_designerInteractionMode = value;
				switch (_designerInteractionMode)
				{
				case PartDesignerInteractionMode.Normal:
				{
					PartMaterialScript.IsDisabled = false;
					Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						componentsInChildren[i].enabled = true;
					}
					_attachPointsGameObject.SetActive(value: true);
					break;
				}
				case PartDesignerInteractionMode.Disabled:
				{
					PartMaterialScript.IsDisabled = true;
					_attachPointsGameObject.SetActive(value: false);
					Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						componentsInChildren[i].enabled = false;
					}
					break;
				}
				default:
					Debug.LogError($"Unknown PartDesignerInteractionMode: {_designerInteractionMode}");
					break;
				}
			}
		}

		public bool Disconnected { get; set; }

		public float FluidDisplacementVolume { get; private set; }

		public GameObject GameObject { get; private set; }

		public bool HasFlightProgram => HasModifier<FlightProgramScript>();

		public IReadOnlyList<IHeatSource> HeatSources => _heatSources;

		bool INavSphereTarget.IsDestroyed => Data.IsDestroyed;

		public List<PartModifierScript> Modifiers => _modifiers;

		string INavSphereTarget.Name => CraftScript.CraftNode.Name + " - " + Data.Name;

		IOrbitNode INavSphereTarget.OrbitNode => CraftScript.CraftNode;

		IPlanetNode INavSphereTarget.Parent => CraftScript.CraftNode.Parent;

		public IPartGroupScript PartGroup { get; private set; }

		public IPartMaterialScript PartMaterialScript { get; set; }

		Vector3d INavSphereTarget.Position => _referenceFrame.FrameToPlanetPosition(base.transform.position);

		public Collider PrimaryCollider { get; private set; }

		public float ReEntryEffectStrength => _reentryEffectStrength;

		Vector3d INavSphereTarget.SolarPosition => ((INavSphereTarget)this).Position + ((INavSphereTarget)this).Parent.Position;

		public ISymmetrySlice SymmetrySlice { get; set; }

		public float Temperature { get; set; }

		public float ThermalMass { get; private set; }

		public Transform Transform { get; private set; }

		public float VaporTrailStrength => _vaporTrailStrength;

		Vector3d INavSphereTarget.Velocity => _referenceFrame.FrameToPlanetVelocity(BodyScript.RigidBody.velocity);

		public IPartWaterPhysics WaterPhysics { get; set; }

		public event CommandPodChangedHandler CommandPodChanged;

		public event PartScriptConnectedDelegate ConnectedToPart;

		public event PartMovedToNewCraftDelegate MovedToNewCraft;

		public event PartScriptDestroyedDelegate PartDestroyed;

		public static PartConnection ConnectParts(AttachPointScript attachPointScriptA, AttachPointScript attachPointScriptB, bool processingSymmetry)
		{
			PartScript partScript = attachPointScriptA.PartScript as PartScript;
			PartScript partScript2 = attachPointScriptB.PartScript as PartScript;
			bool newConnection = false;
			PartConnection partConnection = partScript.Data.GetPartConnection(partScript2.Data);
			if (partConnection == null)
			{
				newConnection = true;
				partConnection = new PartConnection(partScript.Data, partScript2.Data);
				partScript.CraftScript.Data.Assembly.AddPartConnection(partConnection);
			}
			else if (partScript.Data == partConnection.PartB)
			{
				PartScript partScript3 = partScript;
				partScript = partScript2;
				partScript2 = partScript3;
				AttachPointScript attachPointScript = attachPointScriptA;
				attachPointScriptA = attachPointScriptB;
				attachPointScriptB = attachPointScript;
			}
			partConnection.AddAttachment(attachPointScriptA.AttachPoint, attachPointScriptB.AttachPoint);
			PartConnectedEventData e = new PartConnectedEventData(attachPointScriptA.AttachPoint, partScript2.Data, attachPointScriptB.AttachPoint, processingSymmetry, newConnection, processedFirst: true);
			foreach (PartModifierScript modifier in partScript._modifiers)
			{
				modifier.OnConnectedToPart(e);
			}
			if (partScript.ConnectedToPart != null)
			{
				partScript.ConnectedToPart(e);
			}
			PartConnectedEventData e2 = new PartConnectedEventData(attachPointScriptB.AttachPoint, partScript.Data, attachPointScriptA.AttachPoint, processingSymmetry, newConnection, processedFirst: false);
			foreach (PartModifierScript modifier2 in partScript2._modifiers)
			{
				modifier2.OnConnectedToPart(e2);
			}
			if (partScript2.ConnectedToPart != null)
			{
				partScript2.ConnectedToPart(e2);
			}
			return partConnection;
		}

		public static void ConnectPartsAndUpdateSymmetry(AttachPointScript attachPointScriptA, AttachPointScript attachPointScriptB)
		{
			PartScript partScript = attachPointScriptA.PartScript as PartScript;
			ConnectParts(attachPointScriptA, attachPointScriptB, processingSymmetry: false);
			Symmetry.SynchronizePartConnections(partScript);
			Symmetry.SynchronizePartModifiers(partScript);
			Symmetry.SynchronizePartModifiers(attachPointScriptB.PartScript);
		}

		public virtual bool AcceptConnection(AttachPointScript ourAttachPoint, AttachPointScript targetAttachPoint)
		{
			if (CanRefuseConnection)
			{
				foreach (PartModifierScript modifier in Modifiers)
				{
					if (!modifier.AcceptConnection(ourAttachPoint, targetAttachPoint))
					{
						return false;
					}
				}
			}
			return true;
		}

		public void Activate()
		{
			if (Data.Activated)
			{
				return;
			}
			Data.Activated = true;
			Data.PreviouslyActivated = true;
			RecalculateMaxDrag();
			foreach (PartModifierScript modifier in _modifiers)
			{
				modifier.OnActivated();
			}
		}

		public void AssignToPartGroup(PartGroupScript partGroup)
		{
			if (PartGroup == null)
			{
				PartGroup = partGroup;
				return;
			}
			throw new InvalidOperationException("PartScript is already assigned to a PartGroup.");
		}

		public Bounds CalculateBounds()
		{
			Vector3 vector = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			Vector3 vector2 = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			_tempListCalculateBoundsColliders.Clear();
			bool flag = false;
			GetComponentsInChildren(_tempListCalculateBoundsColliders);
			foreach (Collider tempListCalculateBoundsCollider in _tempListCalculateBoundsColliders)
			{
				int layer = tempListCalculateBoundsCollider.gameObject.layer;
				if (layer == 31 || layer == 13 || layer == 2)
				{
					flag = true;
					Bounds bounds = tempListCalculateBoundsCollider.bounds;
					vector = Vector3.Max(vector, bounds.max);
					vector2 = Vector3.Min(vector2, bounds.min);
				}
			}
			_tempListCalculateBoundsColliders.Clear();
			Bounds result = default(Bounds);
			if (flag)
			{
				result.SetMinMax(vector2, vector);
			}
			return result;
		}

		public void CreateAttachPoints()
		{
			_attachPointsGameObject = new GameObject("AttachPoints");
			_attachPointsGameObject.transform.parent = base.transform;
			_attachPointsGameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			_attachPointsGameObject.transform.localRotation = Quaternion.identity;
			_attachPointsGameObject.transform.localPosition = default(Vector3);
			foreach (AttachPoint attachPoint in Data.AttachPoints)
			{
				if (attachPoint.IsSurfaceAttachPoint)
				{
					Collider firstChild = Utilities.GetFirstChild<Collider>(attachPoint.Surface, this);
					if (firstChild != null)
					{
						firstChild.gameObject.layer = 13;
						AttachPointScript attachPointScript = firstChild.gameObject.AddComponent<AttachPointScript>();
						attachPointScript.Initialize(attachPoint, this, Color.black);
						AttachPointScripts.Add(attachPointScript);
					}
					continue;
				}
				GameObject gameObject = (attachPoint.Hidden ? Game.Instance.ResourceLoader.InstantiatePrefab("Design/Tools/AttachPointHidden") : ((!attachPoint.AllowRotation || attachPoint.IgnoreSurfaces) ? Game.Instance.ResourceLoader.InstantiatePrefab("Design/Tools/AttachPoint") : Game.Instance.ResourceLoader.InstantiatePrefab("Design/Tools/AttachPointRotating")));
				if (attachPoint.ConnectionType == AttachPointConnectionType.Legacy)
				{
					gameObject.name = "LegacyAttachPoint";
				}
				else
				{
					gameObject.name = "AttachPoint";
				}
				gameObject.transform.parent = _attachPointsGameObject.transform;
				gameObject.transform.SetLocalPositionAndRotation(attachPoint.Position, Quaternion.Euler(attachPoint.Rotation));
				gameObject.transform.localScale = Vector3.one * attachPoint.Scale;
				gameObject.GetComponent<SphereCollider>().radius = 0.25f;
				Color color = ((attachPoint.JointType != JointType.Designer) ? (attachPoint.ConnectionType switch
				{
					AttachPointConnectionType.Normal => Constants.Colors.Complementary.Gamma, 
					AttachPointConnectionType.Shell => Constants.Colors.Complementary.Gamma, 
					AttachPointConnectionType.Fairing => new Color32(198, 0, byte.MaxValue, byte.MaxValue), 
					AttachPointConnectionType.Eva => Constants.Colors.Primary.Gamma, 
					_ => Color.black, 
				}) : Color.white);
				color.a = 0.95f;
				AttachPointScript attachPointScript2 = gameObject.AddComponent<AttachPointScript>();
				attachPointScript2.Initialize(attachPoint, this, color);
				AttachPointScripts.Add(attachPointScript2);
			}
		}

		public void Deactivate()
		{
			if (!Data.Activated)
			{
				return;
			}
			Data.Activated = false;
			RecalculateMaxDrag();
			foreach (PartModifierScript modifier in _modifiers)
			{
				modifier.OnDeactivated();
			}
		}

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			ReCalculateThermalMass();
		}

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			_positionIsDirty = true;
			if (_bodyScript.WaterPhysicsEnabled)
			{
				WaterPhysics?.Update();
			}
			if (_maxDrag > 0f && !BodyScript.RigidBody.isKinematic && BodyScript.EstimatePartDragForce(Data.PartDrag) > _maxDrag)
			{
				BodyScript.QueuePartGroupForDisconnect(PartGroup);
				_maxDrag = 0f;
			}
			ProcessFrameDamage();
		}

		void IFlightFixedUpdateWarp.FlightFixedUpdateWarp(in FlightFrameData frame)
		{
			ProcessFrameDamage();
		}

		void IFlightPostStart.FlightPostStart(in FlightFrameData frame)
		{
			if (Data.Config.SupportsActivation && Data.Config.AutoActivateIfNoStageOrActivationGroup && Data.ActivationGroup == 0 && Data.Config.StageActivationType == StageActivationType.None && !Data.Activated && !Data.PreviouslyActivated)
			{
				Activate();
			}
			ReCalculateThermalMass();
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_referenceFrame = frame.FlightScene.ViewManager.GameView.ReferenceFrame;
			_flightSettings = Game.Instance.Settings.Game.Flight;
			Temperature = 288.706f;
			RecalculateMaxDrag();
			if (((Data.Config.PartCollisionHandling == PartCollisionHandlingMethod.Default) ? Data.PartType.PartCollisionHandling : Data.Config.PartCollisionHandling) == PartCollisionHandlingMethod.Never)
			{
				Collider[] componentsInChildren = GetComponentsInChildren<Collider>(includeInactive: true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].gameObject.layer = 30;
				}
			}
			if (Data.Config.CastShadows)
			{
				return;
			}
			MeshRenderer[] componentsInChildren2 = GetComponentsInChildren<MeshRenderer>(includeInactive: true);
			foreach (MeshRenderer meshRenderer in componentsInChildren2)
			{
				if (meshRenderer != null)
				{
					meshRenderer.shadowCastingMode = ShadowCastingMode.Off;
				}
			}
		}

		public void FocusCameraOnPart(bool focus)
		{
			Game.Instance.FlightScene.ViewManager.GameView.GameCamera.Recenter();
			if (focus)
			{
				CraftScript.CameraFocus = base.transform;
			}
			else
			{
				CraftScript.CameraFocus = null;
			}
		}

		public InspectorModel GenerateInspectorModel()
		{
			IconButtonRowModel iconButtonRowModel = new IconButtonRowModel();
			PartInspectorModel partInspectorModel = new PartInspectorModel(Data.Name, iconButtonRowModel);
			TextModel textModel = new TextModel("Craft", () => CraftScript?.CraftNode?.Name ?? "None");
			textModel.DetermineVisibility = delegate
			{
				ICommandPod commandPod = CommandPod;
				return commandPod == null || !commandPod.IsEva;
			};
			partInspectorModel.Add(textModel);
			if (Application.isEditor)
			{
				partInspectorModel.Add(new TextModel("CraftTrackID", () => CraftScript?.CraftNode?.ContractTrackingId ?? "None"));
			}
			if (Data.Payload?.PayloadId != null && Game.IsCareer)
			{
				Contract contract = Game.Instance.GameState.Career.Contracts.GetContractFromPayloadTrackingId(Data.Payload.PayloadTrackingId);
				partInspectorModel.Add(new TextModel("Contract", () => ((contract == null) ? "None" : $"{contract.Name.Substring(0, Mathf.Min(10, contract.Name.Length))}#{contract.ContractNumber}") ?? ""));
			}
			TextModel textModel2 = new TextModel("Part ID", () => Data.Id.ToString());
			partInspectorModel.Add(textModel2);
			partInspectorModel.Add(new TextModel("Mass", () => Units.GetMassString(Data.Mass)));
			if (DragPhysics.HeatDamageEnabled || Game.Instance.QualitySettings.ImageEffects.ReEntry.Value != ImageEffectsQualitySettings.ReEntryQuality.Off)
			{
				partInspectorModel.Add(new TextModel("Temp", () => Units.GetTemperatureString(Temperature)));
				partInspectorModel.Add(new TextModel("Heat Shield", () => Data.Config.HeatShield.ToString("0.0"), null, null, () => Data.Config.HeatShield > 0f));
				partInspectorModel.Add(new TextModel("Damage", () => Data.Damage.ToString("0.0"), null, null, () => Data.Damage > 0f));
			}
			partInspectorModel.Add(new TextModel("Est. Drag Force", () => Units.GetForceString(GetEstimatedDragForce()) ?? ""));
			if (Data.Config.SupportsActivation)
			{
				IconButtonModel activateButton = new IconButtonModel("Ui/Sprites/Flight/IconPartInspectorActivate", delegate
				{
					ToggleActivationStateFromInspector();
				});
				activateButton.UpdateAction = delegate
				{
					activateButton.Tooltip = (Data.Activated ? "Deactivate this part" : "Activate this part");
					activateButton.Style = (Data.Activated ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
				};
				iconButtonRowModel.Add(activateButton);
			}
			if (FlightSceneScript.Instance.CraftNode.CraftScript == CraftScript)
			{
				iconButtonRowModel.Add(new IconButtonModel("Ui/Sprites/Flight/IconPartInspectorFocus", delegate(IconButtonModel x)
				{
					OnSetCameraFocus(x);
				}, "Center camera on this part"));
			}
			if (Data.PartType.Id != "Eva" && Data.PartType.Id != "Eva-Tourist")
			{
				IconButtonModel iconButtonModel = new IconButtonModel("Ui/Sprites/Flight/IconPartInspectorExplode", delegate
				{
					OnExplodePartClicked();
				}, "Explode this part. Use with caution. Or not. Your call.");
				iconButtonModel.Style = ButtonModel.ButtonStyle.Warning;
				iconButtonRowModel.Add(iconButtonModel);
			}
			if (!Data.PartType.IsCommandPod)
			{
				IconButtonModel iconButtonModel2 = new IconButtonModel("Ui/Sprites/Flight/IconPartInspectorSelectPod", delegate
				{
					SelectCommandPodClicked();
				}, "Select the command pod controlling this part.");
				iconButtonModel2.Style = ButtonModel.ButtonStyle.Default;
				iconButtonRowModel.Add(iconButtonModel2);
			}
			IconButtonModel toggleTargetButton = new IconButtonModel("Ui/Sprites/MapView/IconSetTarget", delegate
			{
				OnToggleTargetClicked();
			}, "Target this part in particular.");
			toggleTargetButton.ElementCreated += delegate(IItemElement e)
			{
				e.GameObject.name = "PartInspectorPanel.TargetPart";
			};
			toggleTargetButton.UpdateAction = delegate
			{
				if (Game.Instance.FlightScene.FlightSceneUI.NavSphere.Target == this)
				{
					toggleTargetButton.Style = ButtonModel.ButtonStyle.Primary;
				}
				else
				{
					toggleTargetButton.Style = ButtonModel.ButtonStyle.Default;
				}
			};
			toggleTargetButton.DetermineVisibility = () => Game.Instance.FlightScene.CraftNode != CraftScript.CraftNode;
			partInspectorModel.IconButtonRow.Add(toggleTargetButton);
			foreach (PartModifierScript modifier in _modifiers)
			{
				if (modifier.GetData().InspectorEnabled)
				{
					modifier.OnGenerateInspectorModel(partInspectorModel);
				}
			}
			partInspectorModel.Add(iconButtonRowModel, "Actions");
			textModel2.UpdateAction = delegate(ItemModel m)
			{
				if (Data.IsDestroyed || this == null)
				{
					m.InspectorModel.Panel?.Close();
				}
			};
			return partInspectorModel;
		}

		public float GetEstimatedDragForce()
		{
			float num = 0f;
			foreach (PartModifierScript modifier in Modifiers)
			{
				num += modifier.GetEstimatedDragForce();
			}
			return BodyScript.EstimatePartDragForce(Data.PartDrag) + num;
		}

		public T GetModifier<T>() where T : PartModifierScript
		{
			foreach (PartModifierScript modifier in _modifiers)
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
			foreach (PartModifierScript modifier in _modifiers)
			{
				T val = modifier as T;
				if (val != null)
				{
					list.Add(val);
				}
			}
			return list;
		}

		public List<T> GetModifiersWithInterface<T>() where T : class
		{
			List<T> list = new List<T>();
			Type typeFromHandle = typeof(T);
			if (!typeFromHandle.IsInterface)
			{
				Debug.LogError(typeFromHandle.FullName + " is not an interface");
				return list;
			}
			foreach (PartModifierScript modifier in _modifiers)
			{
				if (modifier is T item)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public T GetModifierWithInterface<T>() where T : class
		{
			Type typeFromHandle = typeof(T);
			if (!typeFromHandle.IsInterface)
			{
				Debug.LogError(typeFromHandle.FullName + " is not an interface");
				return null;
			}
			foreach (PartModifierScript modifier in _modifiers)
			{
				if (modifier is T result)
				{
					return result;
				}
			}
			return null;
		}

		public bool GetModifierWithInterface<T>(out T modifier) where T : class
		{
			modifier = null;
			Type typeFromHandle = typeof(T);
			if (!typeFromHandle.IsInterface)
			{
				Debug.LogError(typeFromHandle.FullName + " is not an interface");
				return false;
			}
			foreach (PartModifierScript modifier2 in _modifiers)
			{
				if (modifier2 is T val)
				{
					modifier = val;
					return true;
				}
			}
			return false;
		}

		IGameViewPointerEventHandler IPartScript.HandleGameViewPointerEvent(GameViewPointerEvent pointerEvent)
		{
			foreach (PartModifierScript modifier in _modifiers)
			{
				IGameViewPointerEventHandler gameViewPointerEventHandler = modifier.HandleGameViewPointerEvent(pointerEvent);
				if (gameViewPointerEventHandler != null)
				{
					return gameViewPointerEventHandler;
				}
			}
			return null;
		}

		public bool HasModifier<T>() where T : PartModifierScript
		{
			return GetModifier<T>() != null;
		}

		public void Initialize(PartData part, ICraftScript craftScript)
		{
			Data = part;
			CraftScript = craftScript;
			InitializeMaterials();
		}

		public void InitializeColliders()
		{
			PrimaryCollider = null;
			Colliders = new List<PartColliderScript>();
			PartColliderScript[] componentsInChildren = GetComponentsInChildren<PartColliderScript>(includeInactive: true);
			foreach (PartColliderScript partColliderScript in componentsInChildren)
			{
				Colliders.Add(partColliderScript);
				if (partColliderScript.IsPrimary && PrimaryCollider == null)
				{
					PrimaryCollider = partColliderScript.Collider;
				}
			}
			if (PrimaryCollider == null && Colliders.Count > 0)
			{
				PrimaryCollider = Colliders[0].Collider;
			}
			if (PrimaryCollider != null && !PrimaryCollider.enabled)
			{
				Debug.LogWarning("Primary collider (" + PrimaryCollider.name + " is disabled for part: " + base.name);
			}
		}

		public void OnAttachmentDestroyed(PartConnection.Attachment attachment)
		{
			foreach (PartModifierScript modifier in _modifiers)
			{
				modifier.OnAttachmentDestroyed(attachment);
			}
		}

		public void OnCloned()
		{
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnCloned();
			}
		}

		public void OnCommandPodChanged()
		{
			_commandPod = Data.CommandPod?.PartScript?.GetModifier<CommandPodScript>();
			this.CommandPodChanged?.Invoke(this);
		}

		public void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			foreach (PartModifierScript modifier in _modifiers)
			{
				modifier.OnCraftLoaded(craftScript, movedToNewCraft);
			}
		}

		public void OnCraftStructureChanged()
		{
			foreach (PartModifierScript modifier in _modifiers)
			{
				modifier.OnCraftStructureChanged(CraftScript);
			}
			ReCalculateThermalMass();
		}

		public virtual void OnDesignerPullout(Assembly assembly)
		{
			Game.Instance.Designer.ActiveCraftConfiguration.OnDesignerPartPullout(this, assembly);
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnDesignerPullout(assembly);
			}
		}

		public void OnEnterHeatSource(IHeatSource heatSource)
		{
			_heatSources.Add(heatSource);
		}

		public void OnExitHeatSource(IHeatSource heatSource)
		{
			_heatSources.Remove(heatSource);
		}

		public void OnInertiaTensorCalculation(bool starting)
		{
			foreach (InertiaTensorCollider inertiaTensorCollider in _inertiaTensorColliders)
			{
				if (starting)
				{
					if (inertiaTensorCollider.GameObject.activeSelf != inertiaTensorCollider.RequiredForCalculation)
					{
						inertiaTensorCollider.GameObject.SetActive(inertiaTensorCollider.RequiredForCalculation);
						inertiaTensorCollider.EnabledStateToggled = true;
					}
					else
					{
						inertiaTensorCollider.EnabledStateToggled = false;
					}
				}
				else if (inertiaTensorCollider.EnabledStateToggled)
				{
					inertiaTensorCollider.GameObject.SetActive(!inertiaTensorCollider.GameObject.activeSelf);
					inertiaTensorCollider.EnabledStateToggled = false;
				}
			}
		}

		public void OnInitialLaunch()
		{
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnInitialLaunch();
			}
		}

		public void OnModifiersCreated()
		{
			InitializeColliders();
			if (Game.InFlightScene)
			{
				InitializeWaterPhysics();
			}
			CanRefuseConnection = false;
			foreach (PartModifierScript modifier in Modifiers)
			{
				modifier.OnModifiersCreated();
				if (modifier.CanRefuseConnection)
				{
					CanRefuseConnection = true;
				}
			}
		}

		public void OnMovedToNewCraft(ICraftScript craftScript)
		{
			if (CraftScript?.CameraFocus == base.transform)
			{
				CraftScript.CameraFocus = null;
			}
			(PartMaterialScript as PartMaterialScript).OnMovedToNewPartScript(craftScript);
			this.MovedToNewCraft?.Invoke(_oldCraftScript, craftScript);
			_oldCraftScript = null;
		}

		public void OnMovingToNewCraft(ICraftScript craftScript)
		{
			_oldCraftScript = CraftScript;
			CraftScript = craftScript;
		}

		public void OnNodeLoaded()
		{
			foreach (PartModifierScript modifier in _modifiers)
			{
				modifier.OnNodeLoaded();
			}
		}

		public void OnPartDestroyed()
		{
			this.PartDestroyed?.Invoke(this);
			_heatSources.Clear();
			if (CraftScript?.CameraFocus == base.transform)
			{
				UnityEventDispatcher.Instance.ExecuteWaitForSeconds(delegate
				{
					if (CraftScript?.CameraFocus == base.transform)
					{
						CraftScript.CameraFocus = null;
					}
				}, 3f);
			}
			foreach (PartModifierScript modifier in _modifiers)
			{
				modifier.OnPartDestroyed();
			}
		}

		public void OnPreNodeLoaded()
		{
			foreach (PartModifierScript modifier in _modifiers)
			{
				modifier.OnPreNodeLoaded();
			}
		}

		public void RegisterInertiaTensorCollider(GameObject colliderGameObject, bool required)
		{
			InertiaTensorCollider item = new InertiaTensorCollider
			{
				GameObject = colliderGameObject,
				RequiredForCalculation = required
			};
			_inertiaTensorColliders.Add(item);
		}

		[Obsolete("Use TakeDamage(float, PartDamageType) instead.")]
		public void TakeDamage(float damage, bool heatDamage)
		{
			TakeDamage(damage, heatDamage ? PartDamageType.Heat : PartDamageType.Basic);
		}

		public void TakeDamage(float damage, PartDamageType type = PartDamageType.Basic)
		{
			float num = 1f;
			float num2 = 1f;
			if (!Game.IsCareer || Game.Instance.GameState.Validator.IsItemAvailable("Cheats.FlightCheats"))
			{
				num = _flightSettings.ImpactDamageScale.Value;
				num2 = _flightSettings.HeatDamageScale.Value;
			}
			switch (type)
			{
			case PartDamageType.Basic:
				_frameDamage.Basic += damage * num;
				break;
			case PartDamageType.Heat:
				_frameDamage.Heat += damage * num2;
				break;
			case PartDamageType.GForce:
				_frameDamage.GForce += damage * num;
				break;
			case PartDamageType.Overexpansion:
				_frameDamage.Overexpansion += damage * num2;
				break;
			case PartDamageType.Overspin:
				_frameDamage.Overspin += damage * num;
				break;
			case PartDamageType.Pressure:
				_frameDamage.Pressure += damage * num;
				break;
			case PartDamageType.Explosion:
				_frameDamage.Explosion += damage * num2;
				break;
			default:
				Debug.LogError($"Unknown damage type '{type}'");
				break;
			}
		}

		public void ToggleActivationState()
		{
			if (Data.Config.SupportsActivation)
			{
				if (!Data.Activated)
				{
					Activate();
				}
				else
				{
					Deactivate();
				}
			}
		}

		public void UnregisterInertiaTensorCollider(GameObject colliderGameObject)
		{
			foreach (InertiaTensorCollider inertiaTensorCollider in _inertiaTensorColliders)
			{
				if (inertiaTensorCollider.GameObject == colliderGameObject)
				{
					_inertiaTensorColliders.Remove(inertiaTensorCollider);
					break;
				}
			}
		}

		public void UpdateAttachPoints()
		{
			foreach (AttachPointScript attachPointScript in AttachPointScripts)
			{
				attachPointScript.UpdateLayer();
			}
		}

		public void UpdateReentryEffectValues(float reentryEffectStrength, float vaporTrailStrength)
		{
			if (!_reentryEffectStrengthOverride)
			{
				_reentryEffectStrength = reentryEffectStrength;
				_vaporTrailStrength = vaporTrailStrength;
			}
		}

		protected virtual void Awake()
		{
			Disconnected = true;
			CollisionSoundsEnabled = true;
			AttachPointScripts = new List<AttachPointScript>();
			_modifiers = new List<PartModifierScript>();
			Transform = base.transform;
			GameObject = base.gameObject;
		}

		protected virtual void OnDestroy()
		{
			if (Game.Instance?.FlightScene?.FlightSceneUI?.NavSphere?.Target == this)
			{
				IFlightScene flightScene = Game.Instance?.FlightScene;
				if (flightScene != null)
				{
					IMapView mapView = flightScene.ViewManager?.MapViewManager?.MapView;
					if (mapView != null)
					{
						flightScene.IocContainer.Resolve<INavigationTargetProvider>((mapView as MapViewScript).Context)?.SetNavSphereTarget(null);
					}
				}
			}
			List<PartModifierData> modifiers = Data.Modifiers;
			int count = modifiers.Count;
			for (int i = 0; i < count; i++)
			{
				PartModifierData partModifierData = modifiers[i];
				((IDisposable)partModifierData.GetScript())?.Dispose();
				((IDisposable)partModifierData).Dispose();
			}
			WaterPhysics?.Dispose();
		}

		private void CalculateDisplacementVolume()
		{
			if (PrimaryCollider != null)
			{
				Bounds bounds = PrimaryCollider.bounds;
				float fluidDisplacementVolume = bounds.size.x * bounds.size.y * bounds.size.z;
				FluidDisplacementVolume = fluidDisplacementVolume;
			}
			else
			{
				FluidDisplacementVolume = 0f;
			}
		}

		private void InitializeMaterials()
		{
			PartMaterialScript partMaterialScript = base.gameObject.AddComponent<PartMaterialScript>();
			partMaterialScript.Initialize(CraftScript, this);
			PartMaterialScript = partMaterialScript;
		}

		private void InitializeWaterPhysics()
		{
			if (Data.BuoyancyScale > 0f || Data.Config.RaiseWaterEventsEvenIfNotBuoyant)
			{
				WaterPhysics = new PartWaterPhysics(this);
				if (Data.Config.RaiseWaterEventsEvenIfNotBuoyant)
				{
					WaterPhysics.PrecisionMode = PrecisionModeType.NotifyOnly;
				}
			}
		}

		private void OnExplodePartClicked()
		{
			if (_lastExplodeButtonClick.HasValue && (DateTime.UtcNow - _lastExplodeButtonClick.Value).TotalSeconds < 5.0)
			{
				if (CraftScript.PrimaryCommandPod?.Part == Data)
				{
					foreach (PartData part in BodyScript.Data.Parts)
					{
						BodyScript.ExplodePart(part.PartScript, 10f);
					}
				}
				else
				{
					BodyScript.ExplodePart(this, 10f);
				}
				Game.Instance.FlightScene.FlightSceneUI.FlightLog.AddLog(Data.Name + " [ID " + Data.Id + "] destroyed.", FlightLogEntryCategory.CraftDamage, isDynamic: false, this);
				string message = Data.Name + " destroyed.";
				if (Game.Instance.FlightScene.TimeManager.Paused)
				{
					message = Data.Name + " will be destroyed as soon as you unpause.";
				}
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage(message);
			}
			else
			{
				_lastExplodeButtonClick = DateTime.UtcNow;
				Game.Instance.FlightScene.FlightSceneUI.ShowMessage("Click again to destroy this part.");
			}
		}

		private void OnSetCameraFocus(IconButtonModel button)
		{
			bool flag = button.Style != ButtonModel.ButtonStyle.Primary;
			FocusCameraOnPart(flag);
			button.Style = (flag ? ButtonModel.ButtonStyle.Primary : ButtonModel.ButtonStyle.Default);
		}

		private void OnToggleTargetClicked()
		{
			INavSphere navSphere = Game.Instance.FlightScene.FlightSceneUI.NavSphere;
			INavigationTargetProvider navigationTargetProvider = Game.Instance.FlightScene.IocContainer.Resolve<INavigationTargetProvider>((Game.Instance.FlightScene.ViewManager.MapViewManager.MapView as MapViewScript).Context);
			if (navSphere.Target == this)
			{
				navigationTargetProvider.SetNavSphereTarget(null);
			}
			else
			{
				navigationTargetProvider.SetNavSphereTarget(this);
			}
		}

		private void ProcessFrameDamage()
		{
			float total = _frameDamage.Total;
			if (!(total > 0f))
			{
				return;
			}
			Data.Damage += total;
			bool flag = Data.Damage >= Data.Config.MaxDamage;
			if (flag)
			{
				BodyScript.ExplodePart(this, 10f);
				if (!_achievementUnlockedIcarus && AchievementHelper.InFlightSceneDefaultSystem && _frameDamage.Heat > 0f && CraftScript.CraftNode.Parent.Name == "Juno" && CraftScript.FlightData.SolarRadiationIntensity > 75000.0)
				{
					_achievementUnlockedIcarus = true;
					Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.Icarus);
				}
			}
			IFlightLog flightLog = Game.Instance.FlightScene.FlightSceneUI.FlightLog;
			float deltaTime = Time.deltaTime;
			flightLog.LogPartDamage(this, _frameDamage.Basic, PartDamageType.Basic, flag);
			flightLog.LogPartDamage(this, _frameDamage.Heat, PartDamageType.Heat, flag, deltaTime);
			flightLog.LogPartDamage(this, _frameDamage.GForce, PartDamageType.GForce, flag, deltaTime);
			flightLog.LogPartDamage(this, _frameDamage.Overexpansion, PartDamageType.Overexpansion, flag, deltaTime);
			flightLog.LogPartDamage(this, _frameDamage.Overspin, PartDamageType.Overspin, flag, deltaTime);
			flightLog.LogPartDamage(this, _frameDamage.Pressure, PartDamageType.Pressure, flag, deltaTime);
			flightLog.LogPartDamage(this, _frameDamage.Explosion, PartDamageType.Explosion, flag);
			_frameDamage.Clear();
		}

		private void RecalculateMaxDrag()
		{
			float num = MathUtils.AverageComponentLength(Data.Config.PartScale);
			_maxDrag = (Data.Activated ? Data.Config.MaxDragActive : Data.Config.MaxDrag) * num * num;
		}

		private void ReCalculateThermalMass()
		{
			float num = Data.PartType.Mass * Data.Config.MassScale * Data.Config.PartThermalMassRatio;
			foreach (PartModifierScript modifier in _modifiers)
			{
				PartModifierData data = modifier.GetData();
				num += data.Mass * data.ThermalMassRatio;
			}
			ThermalMass = num;
		}

		private void SelectCommandPodClicked()
		{
			Game.Instance.FlightScene.ViewManager.GameView.SelectedPart = CommandPod?.Part?.PartScript;
		}

		private void ToggleActivationStateFromInspector()
		{
			if (!Data.Activated)
			{
				Activate();
			}
			else
			{
				Deactivate();
			}
		}
	}
}
