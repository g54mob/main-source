using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Combat;
using Assets.Nimbatus.Scripts.Common.Cursor;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.DroneSkins;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.World.Terrain.Common;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainData;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks.Effects;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using I2.Loc;
using UnityEngine;
using Vectrosity;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	[Serializable]
	[RequireComponent(typeof(HealthPool))]
	public abstract class DronePart : NimbatusItem
	{
		public bool HasRadiusDisplay;

		[NonSerialized]
		internal bool ShowRadius;

		[NonSerialized]
		internal float DisplayRadius;

		public const string CollisionSound = "DronePartCollision";

		[HideInInspector]
		public string PersistentId;

		public EDronePartType DronePartType;

		public NimbatusParticleEffect ExplosionEffect;

		protected bool DontDestroyOnBreak;

		public float FlipAngle;

		public bool ClearCenter;

		internal SpriteRenderer SkinRenderer;

		[HideInInspector]
		public DroneSkin SelectedSkin;

		[HideInInspector]
		public bool SkinFlippedX;

		[HideInInspector]
		public bool SkinFlippedY;

		[HideInInspector]
		public int SkinRotation;

		[HideInInspector]
		public float SkinPivotX;

		[HideInInspector]
		public float SkinPivotY;

		[HideInInspector]
		public float SkinZOrder;

		protected int HierarchyDepth;

		protected NimbatusDrone RootDrone;

		internal bool IndividualJoint;

		internal bool CustomLineRenderer;

		internal LineRenderer LineRenderer;

		internal HealthPool HealthPool;

		internal bool IsOverlapping;

		internal float MaxChildRange = 14f;

		internal bool IsBroken;

		internal bool Activated;

		internal bool DeleteOnDrop;

		internal bool IgnoreOffset;

		internal DronePart ParentDronePart;

		internal List<DronePart> Children = new List<DronePart>();

		internal Joint Joint;

		internal bool CanControlDrone;

		internal bool IsDragging;

		private Vector3 _fixedPosition;

		private Quaternion _fixedRotation;

		private bool _hasBeenRotated;

		private float _lastRotateTime;

		private Quaternion _targetRotation;

		private bool _showSkin;

		private float _healRate;

		private bool _trackingWaypoint;

		[NonSerialized]
		private ResourceHub _currentResourceHub;

		protected EventKeyHub KeyEventHub;

		private bool _ignoreJointBreak;

		protected bool NoInput;

		private VectorLine _radiusVectorLine;

		[HideInInspector]
		internal bool IsSelected;

		[HideInInspector]
		internal bool IsPreselected;

		[HideInInspector]
		internal bool HasColorChanged;

		[HideInInspector]
		internal bool IsInRectangle;

		internal ResourceHub CurrentResourceHub
		{
			get
			{
				if (_currentResourceHub == null)
				{
					_currentResourceHub = FindResourceHubRecursive(false);
				}
				return _currentResourceHub;
			}
			set
			{
				_currentResourceHub = value;
			}
		}

		protected virtual void Validate()
		{
		}

		public override void InitStackSettings()
		{
			IsStackable = true;
			CurrentStackSize = 0;
		}

		public override void InitDronePerkSettings(List<DroneEffect> effects)
		{
			HealthPool = base.gameObject.AddMissingComponent<HealthPool>();
			HealthPool.Init();
			HealthPool.ResetModifier(EHealthModifier.DronePerk);
			if (effects != null)
			{
				DronePartHealthEffect dronePartHealthEffect = effects.OfType<DronePartHealthEffect>().FirstOrDefault();
				if (dronePartHealthEffect != null)
				{
					float value = (float)(100 + dronePartHealthEffect.HealthIncrease) / 100f;
					HealthPool.SetHealthModifier(EHealthModifier.DronePerk, value);
				}
				ImprovedHealing improvedHealing = effects.OfType<ImprovedHealing>().FirstOrDefault();
				_healRate = (((float?)((improvedHealing != null) ? new int?(improvedHealing.HealPercentage) : ((int?)null))) ?? 0.1f) / 100f;
			}
			GameModeSettings gameModeSettings = RuntimeGlobals.GameModeSettings;
			if (SaveManager.LoadedSave == null && SaveManager.SelectedSave != null)
			{
				gameModeSettings = SaveManager.SelectedSave.Settings;
			}
			HealthPool.SetHealthModifier(EHealthModifier.SandboxSetting, (float)((gameModeSettings != null) ? gameModeSettings.DronePartHealth : 100) / 100f);
		}

		public void ValidateDroneRecursive()
		{
			Validate();
			foreach (DronePart child in Children)
			{
				child.ValidateDroneRecursive();
			}
		}

		protected override void Awake()
		{
			base.Awake();
			Children = new List<DronePart>();
			_ignoreJointBreak = false;
			Rigidbody = base.gameObject.AddMissingComponent<Rigidbody>();
			if (Rigidbody != null)
			{
				Rigidbody.isKinematic = true;
			}
			ApplyPhysicMaterial(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DronePhysicMaterial);
			StartDrag = 1.5f;
			StartAngularDrag = 3f;
			HealthPool = base.gameObject.AddMissingComponent<HealthPool>();
			if (!CustomLineRenderer)
			{
				LineRenderer = base.gameObject.AddMissingComponent<LineRenderer>();
				LineRenderer.startWidth = 0.75f;
				LineRenderer.endWidth = 0.75f;
				LineRenderer.material = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DroneJointMaterial;
				StartCoroutine(_UpdateLineRenderer());
			}
			if (Rigidbody != null)
			{
				HealthPool.Heal(HealthPool.ActiveMaxHealth);
				if ((this is RootDronePart && RuntimeGlobals.NimbatusPlayer != null) || (!(this is RootDronePart) && !IndividualJoint))
				{
					ConfigurableJoint configurableJoint = base.gameObject.AddMissingComponent<ConfigurableJoint>();
					configurableJoint.angularXMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularYMotion = ConfigurableJointMotion.Locked;
					configurableJoint.angularZMotion = ConfigurableJointMotion.Locked;
					configurableJoint.yMotion = ConfigurableJointMotion.Locked;
					configurableJoint.xMotion = ConfigurableJointMotion.Locked;
					configurableJoint.zMotion = ConfigurableJointMotion.Locked;
					configurableJoint.rotationDriveMode = RotationDriveMode.XYAndZ;
					Joint = configurableJoint;
					Joint.enableCollision = true;
					Joint.enablePreprocessing = false;
					Joint.breakForce = 50000f * Rigidbody.mass;
					Joint.anchor = Vector3.zero;
				}
			}
			InitDronePerkSettings(SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.ActiveEffects);
			IsBroken = false;
			IsDraggable = true;
			Activated = false;
		}

		public void ApplyPhysicMaterial(PhysicMaterial material)
		{
			Collider[] components = GetComponents<Collider>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].material = material;
			}
		}

		public void PrepareForImageRecursive()
		{
			PrepareForImage();
			foreach (DronePart child in Children)
			{
				child.PrepareForImageRecursive();
			}
		}

		public virtual void PrepareForImage()
		{
		}

		protected override void Start()
		{
			Rigidbody.drag = 1.5f;
			Rigidbody.angularDrag = 2f;
			base.Start();
			_targetRotation = base.transform.rotation;
			CanControlDrone = RunningModeSpecifics.Can(ERunningModeSpecific.ControlDrone);
			if (_currentResourceHub == null)
			{
				_currentResourceHub = FindResourceHubRecursive(false);
			}
			if (RunningModeSpecifics.Can(ERunningModeSpecific.ControlDrone))
			{
				KeyEventHub = FindEventKeyHubRecursive();
			}
			NoInput = false;
			List<DronePrecondition> preconditions = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetPreconditions();
			if (preconditions != null && preconditions.Any((DronePrecondition c) => c is Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions.NoInputAllowed) && !RunningModeSpecifics.Has(ERunningModeSpecific.AlwaysAllowInput))
			{
				NoInput = true;
			}
			_showSkin = true;
			if (SkinRenderer == null && SelectedSkin != null)
			{
				SkinRenderer = UnityEngine.Object.Instantiate(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SkinRendererPrefab, base.transform);
			}
			if (SkinRenderer != null)
			{
				SkinRenderer.transform.localPosition = Vector3.zero + new Vector3(0f, 0f, 0f - (2f + SkinZOrder));
				SkinRenderer.transform.localScale = Vector3.one;
				SkinRenderer.gameObject.layer = base.gameObject.layer;
			}
			UpdateSkin();
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization && HasRadiusDisplay && DronePartRangeManager.Instance != null)
			{
				Vector3[] linePoints = new Vector3[51];
				_radiusVectorLine = new VectorLine("Line", linePoints, DronePartRangeManager.Instance.RadiusLineMaterial, 4f, LineType.Continuous);
			}
		}

		public override void WakeUp()
		{
			base.WakeUp();
			if (RunningModeSpecifics.Has(ERunningModeSpecific.ContinuousCollisionDetection))
			{
				Rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
			}
			if (HealthPool != null && RuntimeGlobals.WorldController != null && RuntimeGlobals.WorldController.ForeGroundTerrain != null)
			{
				NimbatusTerrainData? data = RuntimeGlobals.WorldController.ForeGroundTerrain.GetData(base.transform.position);
				if (data.HasValue && data.Value.Volume > 0.5f)
				{
					Break(true);
				}
			}
		}

		public void CheckOverlap()
		{
			if (CheckCollision())
			{
				if (!IsOverlapping)
				{
					IsOverlapping = true;
					ItemSelector.UpdateOverlappingColor(this);
				}
			}
			else if (IsOverlapping)
			{
				IsOverlapping = false;
				ItemSelector.UpdateOverlappingColor(this);
			}
		}

		public void HideOverlapDisplay()
		{
			if (IsOverlapping)
			{
				IsOverlapping = false;
				ItemSelector.UpdateOverlappingColor(this);
			}
		}

		public bool CheckCollision()
		{
			if (DragAndDropHelper.DraggedItem == this)
			{
				return false;
			}
			if (this == null)
			{
				return false;
			}
			IEnumerable<BoxCollider> enumerable = from c in GetComponents<BoxCollider>()
				where !c.isTrigger
				select c;
			IEnumerable<CapsuleCollider> enumerable2 = from c in GetComponents<CapsuleCollider>()
				where !c.isTrigger
				select c;
			IEnumerable<SphereCollider> enumerable3 = from c in GetComponents<SphereCollider>()
				where !c.isTrigger
				select c;
			int layerMask = -1;
			foreach (BoxCollider item in enumerable)
			{
				RaycastHit[] array = Physics.BoxCastAll(base.transform.TransformPoint(item.center) + new Vector3(0f, 0f, -100f), item.size / 2f * 0.95f, Vector3.forward, base.transform.rotation, 200f, layerMask, QueryTriggerInteraction.Ignore);
				for (int num = 0; num < array.Length; num++)
				{
					RaycastHit raycastHit = array[num];
					if (raycastHit.collider.gameObject != base.gameObject && raycastHit.collider.gameObject.GetComponent<DronePart>() != null)
					{
						return true;
					}
				}
			}
			foreach (CapsuleCollider item2 in enumerable2)
			{
				RaycastHit[] array = Physics.SphereCastAll(base.transform.TransformPoint(item2.center), item2.radius * 0.95f, Vector3.forward, 200f, layerMask, QueryTriggerInteraction.Ignore);
				for (int num = 0; num < array.Length; num++)
				{
					RaycastHit raycastHit2 = array[num];
					if (raycastHit2.collider.gameObject != base.gameObject && raycastHit2.collider.gameObject.GetComponent<DronePart>() != null)
					{
						return true;
					}
				}
			}
			foreach (SphereCollider item3 in enumerable3)
			{
				RaycastHit[] array = Physics.SphereCastAll(base.transform.TransformPoint(item3.center), item3.radius * 0.95f, Vector3.forward, 200f, layerMask, QueryTriggerInteraction.Ignore);
				for (int num = 0; num < array.Length; num++)
				{
					RaycastHit raycastHit3 = array[num];
					if (raycastHit3.collider.gameObject != base.gameObject && raycastHit3.collider.gameObject.GetComponent<DronePart>() != null)
					{
						return true;
					}
				}
			}
			return false;
		}

		public int GetCollisionCount()
		{
			if (DragAndDropHelper.DraggedItem == this)
			{
				return 0;
			}
			if (this == null)
			{
				return 0;
			}
			IEnumerable<BoxCollider> enumerable = from c in GetComponents<BoxCollider>()
				where !c.isTrigger
				select c;
			IEnumerable<CapsuleCollider> enumerable2 = from c in GetComponents<CapsuleCollider>()
				where !c.isTrigger
				select c;
			IEnumerable<SphereCollider> enumerable3 = from c in GetComponents<SphereCollider>()
				where !c.isTrigger
				select c;
			int layerMask = -1;
			int num = 0;
			foreach (BoxCollider item in enumerable)
			{
				RaycastHit[] array = Physics.BoxCastAll(base.transform.TransformPoint(item.center) + new Vector3(0f, 0f, -100f), item.size / 2f * 0.95f, Vector3.forward, base.transform.rotation, 200f, layerMask, QueryTriggerInteraction.Ignore);
				for (int num2 = 0; num2 < array.Length; num2++)
				{
					RaycastHit raycastHit = array[num2];
					if (raycastHit.collider.gameObject != base.gameObject && raycastHit.collider.gameObject.GetComponent<DronePart>() != null)
					{
						num++;
					}
				}
			}
			foreach (CapsuleCollider item2 in enumerable2)
			{
				RaycastHit[] array = Physics.SphereCastAll(base.transform.TransformPoint(item2.center), item2.radius * 0.95f, Vector3.forward, 200f, layerMask, QueryTriggerInteraction.Ignore);
				for (int num2 = 0; num2 < array.Length; num2++)
				{
					RaycastHit raycastHit2 = array[num2];
					if (raycastHit2.collider.gameObject != base.gameObject && raycastHit2.collider.gameObject.GetComponent<DronePart>() != null)
					{
						num++;
					}
				}
			}
			foreach (SphereCollider item3 in enumerable3)
			{
				RaycastHit[] array = Physics.SphereCastAll(base.transform.TransformPoint(item3.center), item3.radius * 0.95f, Vector3.forward, 200f, layerMask, QueryTriggerInteraction.Ignore);
				for (int num2 = 0; num2 < array.Length; num2++)
				{
					RaycastHit raycastHit3 = array[num2];
					if (raycastHit3.collider.gameObject != base.gameObject && raycastHit3.collider.gameObject.GetComponent<DronePart>() != null)
					{
						num++;
					}
				}
			}
			return num;
		}

		public virtual void OnCollisionEnter(Collision other)
		{
			HandleCollision(other, true);
		}

		public void HandleCollision(Collision other, bool removeTerrain)
		{
			if (other.relativeVelocity.magnitude > 20f && other.gameObject.layer != base.gameObject.layer && other.gameObject.layer != RootDrone.ProjectileLayer && other.gameObject.layer != BaseSingleton<CollisionLayerManager>.Instance.EnemyProjectileLayer && !other.gameObject.CompareTag("Projectile"))
			{
				AudioController.Play("DronePartCollision", base.transform, other.relativeVelocity.magnitude / 200f);
			}
			if (removeTerrain && other.relativeVelocity.magnitude > 30f && BaseSingleton<CollisionLayerManager>.Instance.IsTerrainLayer(other.gameObject.layer))
			{
				ContactPoint contact = other.GetContact(0);
				TerrainModificationHelper.LerpRemoveTerrainSphere(RuntimeGlobals.WorldController.ForeGroundTerrain, contact.point, 2f, 1f);
			}
			if (IsBroken && other.rigidbody != null && 3000f <= other.rigidbody.velocity.sqrMagnitude)
			{
				Break(true);
			}
		}

		public virtual void OnEnable()
		{
			HealthPool.HasDied += HealthPool_HasDied;
		}

		public void SetDrone(NimbatusDrone drone)
		{
			if (string.IsNullOrEmpty(PersistentId))
			{
				PersistentId = Guid.NewGuid().ToString();
			}
			RootDrone = drone;
			foreach (DronePart child in Children)
			{
				child.SetDrone(drone);
			}
		}

		protected void HealthPool_HasDied(object sender, EventArgs e)
		{
			HealthPool_HasDied();
			Break(true);
		}

		protected virtual void HealthPool_HasDied()
		{
		}

		public override string GetDetailedTooltip()
		{
			string detailedTooltip = base.GetDetailedTooltip();
			detailedTooltip = detailedTooltip + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/HP") + ": " + LabelHelper.Orange + GetComponent<HealthPool>().ActiveMaxHealth.ToString("##0.##") + " ";
			return detailedTooltip + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Mass") + ": " + LabelHelper.Orange + GetComponent<Rigidbody>().mass.ToString("##0.###");
		}

		public bool IsActive()
		{
			if (!IsBroken && Activated && !RuntimeGlobals.IsMovementBlocked && !RuntimeGlobals.IsGameLoading && !RuntimeGlobals.IsGamePaused)
			{
				return CanControlDrone;
			}
			return false;
		}

		public void OnJointBreak(float breakforce)
		{
			if (!_ignoreJointBreak)
			{
				Break();
			}
		}

		public virtual void FlipVertically(Vector3 flipPos)
		{
			foreach (DronePart child in Children)
			{
				child.FlipVertically(flipPos);
			}
			if (!(this is RootDronePart))
			{
				base.transform.position = new Vector3(base.transform.position.x, flipPos.y + (flipPos.y - base.transform.position.y), base.transform.position.z);
				float z = base.transform.rotation.eulerAngles.z;
				float z2 = FlipAngle - z;
				base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, base.transform.eulerAngles.y, z2);
			}
			FlipSkinY();
			SkinRotation = (int)Mathf.LerpAngle(SkinRotation, SkinRotation + 180, 1f);
		}

		public virtual void FlipHorizontally(Vector3 flipPos)
		{
			foreach (DronePart child in Children)
			{
				child.FlipHorizontally(flipPos);
			}
			if (!(this is RootDronePart))
			{
				base.transform.position = new Vector3(flipPos.x + (flipPos.x - base.transform.position.x), base.transform.position.y, base.transform.position.z);
				float z = base.transform.rotation.eulerAngles.z;
				float z2 = FlipAngle - 180f - z;
				base.transform.eulerAngles = new Vector3(base.transform.eulerAngles.x, base.transform.eulerAngles.y, z2);
			}
			FlipSkinY();
			SkinRotation = (int)Mathf.LerpAngle(SkinRotation, SkinRotation + 180, 1f);
		}

		public void FlipSkinX()
		{
			SkinFlippedX = !SkinFlippedX;
		}

		public void FlipSkinY()
		{
			SkinFlippedY = !SkinFlippedY;
		}

		public void Unparent()
		{
			if (!(this is RootDronePart))
			{
				base.transform.parent = null;
			}
			foreach (DronePart child in Children)
			{
				child.Unparent();
			}
		}

		public void Reparent()
		{
			if (!(this is RootDronePart))
			{
				base.transform.SetParent(ParentDronePart.transform, true);
				_targetRotation = base.transform.rotation;
				_fixedPosition = base.transform.localPosition;
				_fixedRotation = base.transform.localRotation;
			}
			foreach (DronePart child in Children)
			{
				child.Reparent();
			}
		}

		public EventKeyHub FindEventKeyHubRecursive()
		{
			if (KeyEventHub != null)
			{
				return KeyEventHub;
			}
			if (this is IHasEventKeyHub)
			{
				return ((IHasEventKeyHub)this).KeyEventHub;
			}
			if (ParentDronePart != null)
			{
				return ParentDronePart.FindEventKeyHubRecursive();
			}
			if (RootDrone == null)
			{
				return null;
			}
			return RootDrone.RootDronePart.KeyEventHub;
		}

		public ResourceHub FindResourceHubRecursive(bool ignoreSelf)
		{
			IHasResourceHub hasResourceHub = this as IHasResourceHub;
			if (hasResourceHub != null && !ignoreSelf)
			{
				return hasResourceHub.ResourceHub;
			}
			if (ParentDronePart != null)
			{
				return ParentDronePart.FindResourceHubRecursive(false);
			}
			if (RootDrone == null)
			{
				return null;
			}
			return RootDrone.RootDronePart.ResourceHub;
		}

		protected void Break(bool force = false)
		{
			if (ParentDronePart == null && !force && IsBroken)
			{
				return;
			}
			DronePartBreak();
			if (this is RootDronePart)
			{
				SetBroken(true);
				foreach (DronePart item in Children.ToList())
				{
					item.Break();
				}
				Children.Clear();
				return;
			}
			if (ExplosionEffect != null)
			{
				ExplosionEffect.PlayEffect(base.transform);
			}
			if (ParentDronePart != null && ParentDronePart.Children.Contains(this))
			{
				ParentDronePart.Children.Remove(this);
			}
			base.transform.parent = null;
			if (Joint != null)
			{
				Joint.autoConfigureConnectedAnchor = true;
				Joint.connectedBody = null;
				if (!CustomLineRenderer)
				{
					LineRenderer.enabled = false;
				}
				UnityEngine.Object.Destroy(Joint);
			}
			ParentDronePart = null;
			SetBroken(true);
			foreach (DronePart child in Children)
			{
				child.transform.parent = null;
			}
			Children.Clear();
			if (!DontDestroyOnBreak)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		protected virtual void DronePartBreak()
		{
		}

		public virtual void SetBroken(bool isBroken)
		{
			IsBroken = isBroken;
			foreach (DronePart child in Children)
			{
				if (child != null)
				{
					child.SetBroken(isBroken);
				}
			}
			if (isBroken && base.gameObject != null)
			{
				base.gameObject.layer = 11;
			}
		}

		public virtual void ActivatePhysics(int layer)
		{
			if (!RunningModeSpecifics.Can(ERunningModeSpecific.ControlDrone))
			{
				return;
			}
			Activated = true;
			if (Joint != null && this is RootDronePart && RuntimeGlobals.NimbatusPlayer != null)
			{
				Joint.autoConfigureConnectedAnchor = true;
				Joint.connectedBody = RuntimeGlobals.NimbatusPlayer.Rigidbody;
			}
			if (Rigidbody != null)
			{
				Rigidbody.isKinematic = false;
			}
			base.gameObject.layer = layer;
			foreach (DronePart child in Children)
			{
				child.ActivatePhysics(layer);
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (Rigidbody.velocity.magnitude > 300f)
			{
				Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, Rigidbody.velocity.normalized * 300f, Time.fixedDeltaTime * 10f);
			}
			if (Time.time - HealthPool.LastDamageTime > 10f)
			{
				HealthPool.Heal(HealthPool.ActiveMaxHealth * _healRate * Time.fixedDeltaTime);
			}
		}

		public override void Update()
		{
			base.Update();
			IsInRectangle = false;
			HasColorChanged = false;
			if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.HideSkins))
			{
				_showSkin = !_showSkin;
				if (SkinRenderer != null)
				{
					SkinRenderer.gameObject.SetActive(_showSkin);
				}
			}
			if (RuntimeGlobals.RunningMode != ERunningMode.DroneCustomization)
			{
				return;
			}
			UpdateSkin();
			if (base.transform.rotation != _targetRotation)
			{
				base.transform.rotation = _targetRotation;
			}
			if (Time.time - _lastRotateTime > 0.1f && _hasBeenRotated)
			{
				BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.Rotate, this);
				_hasBeenRotated = false;
				_lastRotateTime = Time.time;
			}
			CheckRotation();
			if (DragAndDropHelper.DraggedItem != this)
			{
				if (base.transform.localPosition != _fixedPosition)
				{
					base.transform.localPosition = _fixedPosition;
				}
			}
			else
			{
				_fixedPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, 0f);
			}
			if (!ItemSelector.IsSelected(this) && DragAndDropHelper.DraggedItem != this)
			{
				if (base.transform.localRotation != _fixedRotation)
				{
					base.transform.localRotation = _fixedRotation;
				}
			}
			else
			{
				_fixedRotation = base.transform.localRotation;
			}
			if (!RuntimeGlobals.StopInteraction)
			{
				if (Input.GetMouseButtonDown(1) && DragAndDropHelper.DraggedItem == this && DeleteOnDrop)
				{
					Delete();
					BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.Delete);
				}
				if (DragAndDropHelper.DraggedItem != null && DragAndDropHelper.DraggedItem == this)
				{
					DronePart onlySelection = ItemSelector.GetOnlySelection();
					if (onlySelection != null && onlySelection != this)
					{
						DronePartRangeManager.SelectedItem = onlySelection;
					}
					else if (ParentDronePart == null)
					{
						DronePartRangeManager.SelectedItem = RootDrone.RootDronePart;
					}
					else
					{
						DronePartRangeManager.SelectedItem = ParentDronePart;
					}
					if (DronePartRangeManager.SelectedItem != null && DronePartRangeManager.SelectedItem != ParentDronePart)
					{
						if (ParentDronePart != null && ParentDronePart.Children.Contains(this))
						{
							ParentDronePart.Children.Remove(this);
						}
						ParentDronePart = DronePartRangeManager.SelectedItem;
						if (DronePartRangeManager.SelectedItem != null)
						{
							DronePartRangeManager.SelectedItem.AddChild(this);
						}
					}
				}
				else if (DragAndDropHelper.DraggedItem == null)
				{
					DronePartRangeManager.SelectedItem = null;
				}
			}
			if (HasRadiusDisplay)
			{
				DronePart dronePart = DragAndDropHelper.DraggedItem as DronePart;
				if (ItemSelector.IsSelected(this) && ShowRadius && dronePart == null)
				{
					float displayRadius = DisplayRadius;
					_radiusVectorLine.active = true;
					_radiusVectorLine.MakeEllipse(base.transform.position + new Vector3(0f, 0f, -50f), displayRadius, displayRadius, 50, 0);
					_radiusVectorLine.Draw3D();
				}
				else
				{
					_radiusVectorLine.active = false;
				}
			}
		}

		private void UpdateSkin()
		{
			if (SelectedSkin != null)
			{
				if (SkinRenderer == null)
				{
					SkinRenderer = UnityEngine.Object.Instantiate(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SkinRendererPrefab, base.transform);
					SkinRenderer.transform.localPosition = Vector3.zero + new Vector3(0f, 0f, 0f - (2f + SkinZOrder));
					SkinRenderer.transform.localScale = Vector3.one;
					SkinRenderer.gameObject.layer = base.gameObject.layer;
				}
				SkinRenderer.transform.localPosition = new Vector3(SkinPivotX * (float)SelectedSkin.Width * 0.75f, SkinPivotY * (float)SelectedSkin.Height * 0.75f, 0f - (2f + SkinZOrder));
				SkinRenderer.transform.localEulerAngles = new Vector3(0f, 0f, -SkinRotation);
				SkinRenderer.sprite = SelectedSkin.SkinTexture;
				SkinRenderer.flipX = SkinFlippedX;
				SkinRenderer.flipY = SkinFlippedY;
				SkinRenderer.sprite.texture.mipMapBias = -1.5f;
				if (BaseSingleton<DroneSkinManager>.Instance.IsSetUnlocked(SelectedSkin.Set) || RootDrone.ShowLockedSkins)
				{
					SkinRenderer.enabled = true;
				}
				else
				{
					SkinRenderer.enabled = false;
				}
				if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
				{
					SkinRenderer.color = new Color(1f, 1f, 1f, RuntimeGlobals.Settings.DroneSkinTransparency);
				}
				else
				{
					SkinRenderer.color = new Color(1f, 1f, 1f, 1f);
				}
			}
			else if (SkinRenderer != null)
			{
				SkinRenderer.sprite = null;
			}
		}

		public virtual Vector3 GetChildAttachPosition(Transform childTransform)
		{
			if (ClearCenter)
			{
				Vector3 position = childTransform.position;
				Vector3 position2 = base.transform.position;
				position.z = 1f;
				position2.z = 1f;
				return position2 + (position - position2).normalized * 1.1f;
			}
			return base.transform.position;
		}

		private IEnumerator _UpdateLineRenderer()
		{
			while (!CustomLineRenderer)
			{
				bool flag = ParentDronePart != null;
				if ((flag || DronePartRangeManager.SelectedItem != null) && !(this is RootDronePart))
				{
					Vector3 vector = ((!flag) ? DronePartRangeManager.SelectedItem.GetChildAttachPosition(base.transform) : ParentDronePart.GetChildAttachPosition(base.transform));
					Vector3 position = base.transform.position;
					position.z = 1f;
					vector.z = 1f;
					if (ClearCenter)
					{
						position += (vector - position).normalized * 1.1f;
					}
					LineRenderer.SetPosition(0, position);
					LineRenderer.SetPosition(1, vector);
					LineRenderer.enabled = true;
				}
				else
				{
					LineRenderer.enabled = false;
				}
				yield return true;
			}
		}

		public void CheckRotation()
		{
			if (RuntimeGlobals.RunningMode != ERunningMode.DroneCustomization || ((!ItemSelector.IsSelected(this) || !(DragAndDropHelper.DraggedItem == null)) && !(DragAndDropHelper.DraggedItem == this)))
			{
				return;
			}
			float num = Input.GetAxis("Mouse ScrollWheel") * 100f;
			if (UICamera.hoveredObject != null && UICamera.hoveredObject.CompareTag("Scrollable"))
			{
				num = 0f;
			}
			if (RuntimeGlobals.StopInteraction || (!(Math.Abs(num) > 1f) && !BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.RotateDronePartLeft) && !BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.RotateDronePartRight)))
			{
				return;
			}
			float z = _targetRotation.eulerAngles.z;
			z = (int)z;
			float num2 = z + ((num > 0f) ? 11.25f : (-11.25f));
			num2 = Mathf.Round(num2 / 11.25f) * 11.25f;
			if (!RuntimeGlobals.StopInteraction)
			{
				if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.RotateDronePartLeft))
				{
					num2 = z + 45f;
					num2 = Mathf.Round(num2 / 45f) * 45f;
					if (DragAndDropHelper.DraggedItem != this)
					{
						BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.Rotate, this);
					}
				}
				else if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.RotateDronePartRight))
				{
					num2 = z - 45f;
					num2 = Mathf.Round(num2 / 45f) * 45f;
					if (DragAndDropHelper.DraggedItem != this)
					{
						BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.Rotate, this);
					}
				}
			}
			Quaternion rotation = Quaternion.Euler(0f, 0f, num2);
			base.transform.rotation = rotation;
			ApplyRotation();
			if (DragAndDropHelper.DraggedItem != this)
			{
				_hasBeenRotated = true;
			}
		}

		public void ApplyRotation()
		{
			_targetRotation = base.transform.rotation;
			_fixedRotation = base.transform.localRotation;
			foreach (DronePart child in Children)
			{
				child.ApplyRotation();
			}
		}

		public bool FindDronePartWithId(out DronePart part, string id)
		{
			if (PersistentId == id)
			{
				part = this;
				return true;
			}
			foreach (DronePart child in Children)
			{
				if (child.FindDronePartWithId(out part, id))
				{
					return true;
				}
			}
			part = null;
			return false;
		}

		public void AddChild(DronePart childDronePart)
		{
			if (!(ParentDronePart == childDronePart) && !(childDronePart == null))
			{
				if (!Children.Contains(childDronePart))
				{
					Children.Add(childDronePart);
				}
				childDronePart.SetParent(this);
			}
		}

		public void SetParent(DronePart parentPart)
		{
			if (parentPart != null)
			{
				HierarchyDepth = parentPart.HierarchyDepth + 1;
				base.gameObject.layer = parentPart.gameObject.layer;
				ParentDronePart = parentPart;
				base.transform.parent = parentPart.transform;
				base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, ParentDronePart.transform.position.z - 0.01f);
				if (Joint != null)
				{
					Rigidbody parentRigidBody = GetParentRigidBody();
					if (parentRigidBody != null)
					{
						Joint.connectedBody = parentRigidBody;
						Joint.autoConfigureConnectedAnchor = false;
						Joint.anchor = Vector3.zero;
						Joint.connectedAnchor = base.transform.localPosition;
					}
				}
			}
			else
			{
				ParentDronePart = null;
				if (Joint != null)
				{
					Joint.autoConfigureConnectedAnchor = true;
					Joint.connectedBody = null;
				}
				base.transform.parent = null;
			}
		}

		protected Rigidbody GetParentRigidBody()
		{
			if (ParentDronePart == null)
			{
				if (RootDrone != null)
				{
					return RootDrone.RootDronePart.Rigidbody;
				}
				return null;
			}
			if (ParentDronePart.Rigidbody != null)
			{
				return ParentDronePart.Rigidbody;
			}
			return ParentDronePart.GetParentRigidBody();
		}

		public override bool ShouldBePlaced()
		{
			if (DronePartRangeManager.SelectedItem == null)
			{
				return false;
			}
			Vector2 a = base.transform.position;
			Vector2 b = DronePartRangeManager.SelectedItem.transform.position;
			return Vector2.Distance(a, b) <= DronePartRangeManager.SelectedItem.MaxChildRange + 2E-05f;
		}

		public void Delete()
		{
			if (_radiusVectorLine != null)
			{
				_radiusVectorLine.active = false;
				UnityEngine.Object.DestroyImmediate(_radiusVectorLine.vectorObject.gameObject);
				_radiusVectorLine = null;
			}
			if (DronePartRangeManager.SelectedItem == this)
			{
				DronePartRangeManager.SelectedItem = null;
			}
			if (DragAndDropHelper.DraggedItem == this)
			{
				DragAndDropHelper.DraggedItem = null;
			}
			if (RuntimeGlobals.RunningMode != ERunningMode.DroneCustomization)
			{
				return;
			}
			RemoveFromUsedTags();
			if (!(this is RootDronePart))
			{
				ItemSelector.Deselect(this);
				OnTooltip(false);
			}
			foreach (DronePart child in Children)
			{
				UnityEngine.Object.Destroy(child.gameObject);
			}
			Children.Clear();
			if (!(this is RootDronePart) || CanControlDrone)
			{
				if (ParentDronePart != null && ParentDronePart.Children.Contains(this))
				{
					ParentDronePart.Children.Remove(this);
				}
				ParentDronePart = null;
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void RemoveFromUsedTags()
		{
			BindableDronePart bindableDronePart;
			if ((object)(bindableDronePart = this as BindableDronePart) != null)
			{
				foreach (KeyBinding keyBinding in bindableDronePart.KeyBindings)
				{
					keyBinding.RemoveFromUsedTags();
				}
			}
			SensorPart sensorPart;
			if ((object)(sensorPart = this as SensorPart) != null)
			{
				foreach (EventKeyBinding eventBinding in sensorPart.EventBindings)
				{
					eventBinding.RemoveFromUsedTags();
				}
			}
			foreach (DronePart child in Children)
			{
				child.RemoveFromUsedTags();
			}
		}

		private void ReplaceWith(DronePart part)
		{
			if (this is RootDronePart || part == null || DragAndDropHelper.DraggedItem == this || ParentDronePart == null || ParentDronePart == part || part == this)
			{
				return;
			}
			if (part.ParentDronePart != null)
			{
				if (part.ParentDronePart.Children.Contains(part))
				{
					part.ParentDronePart.Children.Remove(part);
				}
				part.ParentDronePart = null;
			}
			ParentDronePart.AddChild(part);
			part.transform.position = base.transform.position;
			part.transform.rotation = base.transform.rotation;
			part._targetRotation = _targetRotation;
			part._fixedPosition = _fixedPosition;
			part._fixedRotation = _fixedRotation;
			part.ApplyRotation();
			ItemSelector.Reset();
			DragAndDropHelper.DraggedItem = null;
			DronePartRangeManager.SelectedItem = null;
			foreach (DronePart item in Children.ToList())
			{
				part.AddChild(item);
			}
			Children.Clear();
			if (ParentDronePart != null && ParentDronePart.Children.Contains(this))
			{
				ParentDronePart.Children.Remove(this);
			}
			ParentDronePart.Children.RemoveAll((DronePart c) => c == null);
			ParentDronePart = null;
			base.gameObject.SetActive(false);
			UnityEngine.Object.Destroy(base.gameObject);
			NimbatusCursor.Clear();
			part.EnableColliders(true);
			ItemSelector.Select(part);
			BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.ReplaceItem);
		}

		public override void OnClick()
		{
			if (IsDragging)
			{
				return;
			}
			if (DragAndDropHelper.DraggedItem != this)
			{
				if (BaseSingleton<KeybindManager>.Instance.GetKey(EKeybinding.MultiSelect))
				{
					if (ItemSelector.IsSelected(this))
					{
						ItemSelector.Deselect(this);
					}
					else
					{
						ItemSelector.AddToSelection(this);
					}
				}
				else
				{
					ItemSelector.Select(this);
				}
				DronePartRangeManager.SelectedItem = this;
			}
			if (DragAndDropHelper.DraggedItem != null && BaseSingleton<KeybindManager>.Instance.GetKey(EKeybinding.ReplaceDronePart))
			{
				ReplaceWith(DragAndDropHelper.DraggedItem as DronePart);
			}
		}

		public void OnDrop(GameObject o)
		{
			if (DragAndDropHelper.DraggedItem != null && !IsDragging)
			{
				ItemSelector.Select(this);
				DronePartRangeManager.SelectedItem = this;
				if (BaseSingleton<KeybindManager>.Instance.GetKey(EKeybinding.ReplaceDronePart))
				{
					ReplaceWith(DragAndDropHelper.DraggedItem as DronePart);
				}
			}
		}

		public void OnHover(bool isOver)
		{
			if (DragAndDropHelper.DraggedItem is DronePart && !IsDragging)
			{
				((DronePart)DragAndDropHelper.DraggedItem).PreviewParenting(isOver);
			}
		}

		public void OnDragOver()
		{
			if (DragAndDropHelper.DraggedItem is DronePart && !IsDragging)
			{
				((DronePart)DragAndDropHelper.DraggedItem).PreviewParenting(true);
			}
		}

		public void OnDragOut()
		{
			if (DragAndDropHelper.DraggedItem is DronePart && !IsDragging)
			{
				((DronePart)DragAndDropHelper.DraggedItem).PreviewParenting(false);
			}
		}

		public void PreviewParenting(bool active)
		{
			if (active)
			{
				ItemSelector.SetAlphaOnItem(this, 0.5f);
				if (BaseSingleton<KeybindManager>.Instance.GetKey(EKeybinding.ReplaceDronePart))
				{
					NimbatusCursor.ShowReplaceCursor();
				}
				else
				{
					NimbatusCursor.ShowConnectCursor();
				}
			}
			else
			{
				ItemSelector.SetAlphaOnItem(this, 1f);
				NimbatusCursor.ShowNormalCursor();
			}
		}

		public virtual void Place()
		{
			if (this != RootDrone.RootDronePart)
			{
				DronePart onlySelection = ItemSelector.GetOnlySelection();
				if (onlySelection != null && onlySelection != this && !onlySelection.IsDragging)
				{
					onlySelection.AddChild(this);
				}
				else if (ParentDronePart == null)
				{
					RootDrone.RootDronePart.AddChild(this);
				}
				else
				{
					SetParent(ParentDronePart);
				}
			}
		}

		public override void IsDragged(bool isDragged)
		{
			SetDraggedRecursive(isDragged);
			if (isDragged)
			{
				ItemSelector.Select(this);
				if (Rigidbody != null)
				{
					Rigidbody.isKinematic = true;
				}
			}
			else
			{
				DeleteOnDrop = false;
				((DronePart)DragAndDropHelper.DraggedItem).PreviewParenting(false);
			}
			base.IsDragged(isDragged);
		}

		public void SetDraggedRecursive(bool dragged)
		{
			IsDragging = dragged;
			EnableColliders(!dragged);
			foreach (DronePart child in Children)
			{
				child.SetDraggedRecursive(dragged);
			}
		}

		public void CollectUsedParts(ref List<string> usedParts)
		{
			usedParts.Add(UniqueId);
			foreach (DronePart child in Children)
			{
				child.CollectUsedParts(ref usedParts);
			}
		}

		public void DecoupleFromParent(ResourceHub newResourceHub = null)
		{
			base.transform.parent = null;
			if (Joint != null)
			{
				LineRenderer.enabled = false;
				_ignoreJointBreak = true;
				UnityEngine.Object.DestroyImmediate(Joint);
			}
			ParentDronePart = null;
			if (newResourceHub != null)
			{
				SetHubRecursive(newResourceHub);
			}
		}

		internal void SetHubRecursive(ResourceHub hub)
		{
			IHasResourceHub hasResourceHub;
			if ((hasResourceHub = this as IHasResourceHub) != null)
			{
				hasResourceHub.ChangeParentHub(hub);
				return;
			}
			if (this is IHasResources)
			{
				((IHasResources)this).ChangeResourceHub(_currentResourceHub, hub);
			}
			_currentResourceHub = hub;
			foreach (DronePart child in Children)
			{
				child.SetHubRecursive(_currentResourceHub);
			}
		}

		protected bool GetDirection(ESensorDirectionTarget target, Vector2 mousePos, Vector2 myPos, out Vector2 gravitydir)
		{
			gravitydir = Vector2.zero;
			switch (target)
			{
			case ESensorDirectionTarget.Gravity:
				gravitydir = GetGravityDirection(base.transform.position);
				return true;
			case ESensorDirectionTarget.Cursor:
				if (!NoInput)
				{
					gravitydir = mousePos - myPos;
					return true;
				}
				return false;
			case ESensorDirectionTarget.OwnDrone:
				gravitydir = (Vector2)RootDrone.RootDronePart.transform.position - new Vector2(base.transform.position.x, base.transform.position.y);
				return true;
			case ESensorDirectionTarget.Container:
				if (RuntimeGlobals.ResourceContainer != null)
				{
					gravitydir = (Vector2)(RuntimeGlobals.ResourceContainer.transform.position + new Vector3(0f, 60f, 0f)) - myPos;
					return true;
				}
				return false;
			case ESensorDirectionTarget.SumoEnemy:
			{
				Vector2 direction3;
				if (TransformHelper.GetDirectionToOpponent(RootDrone, base.transform.position, out direction3))
				{
					gravitydir = direction3;
					return true;
				}
				return false;
			}
			case ESensorDirectionTarget.NextWaypoint:
			{
				Vector2 direction;
				if (TransformHelper.GetDirectionToWaypoint(RootDrone, this, base.transform.position, out direction))
				{
					gravitydir = direction;
					return true;
				}
				return false;
			}
			case ESensorDirectionTarget.NearestEnemy:
			{
				LayerMask layerMask = RootDrone.SensorLayerMasks[ESensorDetectionType.Enemies];
				LayerMask layerMask2 = RootDrone.SensorLayerMasks[ESensorDetectionType.EnemyStructures];
				int num = layerMask.value | layerMask2.value;
				Vector2 direction4;
				if (TransformHelper.GetDirectionToNearestEnemy(base.transform.position, num, 100, out direction4))
				{
					gravitydir = direction4;
					return true;
				}
				return false;
			}
			case ESensorDirectionTarget.MissionTarget:
			{
				Vector3 direction2;
				if (BaseSingleton<MissionTargetManager>.Instance.GetDirectionToNearestMissionTarget(base.transform.position, out direction2))
				{
					gravitydir = direction2;
					return true;
				}
				return false;
			}
			case ESensorDirectionTarget.PositionTracker:
			{
				PositionTracker nearestActiveTracker = PositionTracker.GetNearestActiveTracker(base.transform.position);
				if (nearestActiveTracker != null)
				{
					gravitydir = (Vector2)nearestActiveTracker.transform.position - myPos;
					return true;
				}
				return false;
			}
			default:
				return false;
			}
		}

		public Bounds CalculateDroneBounds()
		{
			Bounds result = new Bounds(base.transform.position, Vector3.one);
			List<Renderer> list = new List<Renderer>(GetComponentsInChildren<MeshRenderer>());
			list.AddRange(GetComponentsInChildren<SpriteRenderer>());
			foreach (Renderer item in list.Where((Renderer r) => r.enabled))
			{
				result.Encapsulate(item.bounds);
			}
			return result;
		}

		public void EnableRenderers(bool enable)
		{
			List<Renderer> list = new List<Renderer>(GetComponentsInChildren<MeshRenderer>());
			list.AddRange(GetComponentsInChildren<SpriteRenderer>());
			list.AddRange(GetComponentsInChildren<LineRenderer>());
			list.ForEach(delegate(Renderer r)
			{
				r.enabled = enable;
			});
		}

		public void EnableLineRenderer(bool enable)
		{
			if (LineRenderer != null)
			{
				LineRenderer.enabled = enable;
			}
		}

		public void TrackWaypoint(bool register)
		{
			if (_trackingWaypoint != register && RootDrone != null && RootDrone.TrackerManager != null)
			{
				if (register)
				{
					RootDrone.TrackerManager.AddDronePart(this);
				}
				else
				{
					RootDrone.TrackerManager.RemoveDronePart(this);
				}
				_trackingWaypoint = register;
			}
		}

		public override void OnDisable()
		{
			base.OnDisable();
			HealthPool.HasDied -= HealthPool_HasDied;
			if (_trackingWaypoint)
			{
				TrackWaypoint(false);
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			DronePartData dronePartData = data as DronePartData;
			if (dronePartData == null)
			{
				return;
			}
			base.transform.position = dronePartData.CurrentPosition;
			base.transform.rotation = dronePartData.CurrentRotation;
			_fixedPosition = dronePartData.OriginalPosition;
			_fixedRotation = dronePartData.OriginalRotation;
			_targetRotation = base.transform.rotation;
			PersistentId = dronePartData.PersistentId;
			if (!(data is FactoryPartData))
			{
				foreach (DronePartData child in dronePartData.Children)
				{
					DronePart childDronePart = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.InstantiateItemFromData(child) as DronePart;
					AddChild(childDronePart);
				}
			}
			SkinRotation = dronePartData.SkinRotation;
			SkinFlippedX = dronePartData.SkinFlippedX;
			SkinFlippedY = dronePartData.SkinFlippedY;
			SkinPivotX = dronePartData.SkinPivotX;
			SkinPivotY = dronePartData.SkinPivotY;
			SkinZOrder = dronePartData.SkinZOrder;
			if (!string.IsNullOrEmpty(dronePartData.SkinId))
			{
				SelectedSkin = BaseSingleton<DroneSkinManager>.Instance.GetDroneSkin(dronePartData.SkinId);
			}
		}

		public override NimbatusItemData CreateData()
		{
			return new DronePartData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			DronePartData dronePartData = data as DronePartData;
			if (dronePartData == null)
			{
				return;
			}
			dronePartData.CurrentPosition = base.transform.position;
			dronePartData.CurrentRotation = base.transform.rotation;
			dronePartData.OriginalPosition = _fixedPosition;
			dronePartData.OriginalRotation = _fixedRotation;
			base.transform.rotation = _targetRotation;
			dronePartData.PersistentId = PersistentId;
			dronePartData.SkinZOrder = SkinZOrder;
			dronePartData.Children = new List<DronePartData>();
			foreach (DronePart child in Children)
			{
				DronePartData item = (DronePartData)child.GenerateData();
				dronePartData.Children.Add(item);
			}
			dronePartData.SkinRotation = SkinRotation;
			dronePartData.SkinPivotX = SkinPivotX;
			dronePartData.SkinPivotY = SkinPivotY;
			dronePartData.SkinFlippedX = SkinFlippedX;
			dronePartData.SkinFlippedY = SkinFlippedY;
			if (SelectedSkin != null)
			{
				dronePartData.SkinId = SelectedSkin.UniqueId;
			}
		}
	}
}
