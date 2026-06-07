using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Common.Events;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using UnityEngine;
using UnityFS;

namespace Assets.Scripts.Craft.Parts.Modifiers.Wing
{
	public class ControlSurfaceScript : PartModifierScript<ControlSurfaceData>, IFlightUpdate, IGameLoopItem, IDesignerStart
	{
		private Vector3 _autoAxisContributions;

		private MeshCollider _collider;

		private EventMigrator<ICommandPod> _craftControlsChangedMigrator;

		private float _currentInputValue;

		private float _deflectionAngle;

		private Vector3 _hingeAxis;

		private IInputController _input;

		private int _inputAdjustment;

		private MeshFilter _meshFilter;

		private bool _recalculateInputs;

		public Collider Collider => _collider;

		public ControlSurface ControlSurfacePhysics { get; set; }

		public float DeflectionAngle
		{
			get
			{
				return _deflectionAngle;
			}
			set
			{
				if (DeflectionAngle != value)
				{
					_deflectionAngle = value;
					base.transform.localRotation = Quaternion.AngleAxis(_deflectionAngle, HingeAxis);
				}
			}
		}

		public Vector3 HingeAxis
		{
			get
			{
				return _hingeAxis;
			}
			set
			{
				_hingeAxis = value;
				base.transform.localRotation = Quaternion.AngleAxis(_deflectionAngle, HingeAxis);
			}
		}

		public Mesh Mesh
		{
			get
			{
				return _meshFilter.mesh;
			}
			set
			{
				_meshFilter.mesh = value;
				if (Game.InDesignerScene)
				{
					_collider.sharedMesh = value;
				}
			}
		}

		public MeshRenderer MeshRenderer { get; private set; }

		public WingScript WingScript { get; set; }

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			base.Data.AutoPropertyChanged += OnAutoPropertyChanged;
			base.PartScript.ConnectedToPart += OnConnectedToNewPart;
			WingScript.WingUpdated += OnWingUpdated;
			if (Game.InDesignerScene)
			{
				UpdateDesignerAutoControlInfo();
			}
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			float num = 0f;
			if (base.PartScript.Data.Activated)
			{
				if (_recalculateInputs)
				{
					_input = GetInputController(_autoAxisContributions, out _inputAdjustment);
					_recalculateInputs = false;
				}
				num = GetInputValue();
			}
			if (!float.IsNaN(num))
			{
				float step = base.Data.DeflectionSpeed * 3.33f * frame.DeltaTime;
				_currentInputValue = Utilities.StepTowards(_currentInputValue, step, num);
				DeflectionAngle = _currentInputValue * base.Data.MaxDeflectionDegree;
				if (ControlSurfacePhysics != null)
				{
					ControlSurfacePhysics.CurrentDeflection = DeflectionAngle;
				}
			}
			else
			{
				this.LogError("Control surface input is NaN for: {0}", base.Data.Input);
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			if (movedToNewCraft)
			{
				return;
			}
			_autoAxisContributions = CalculateControlAxisContributions();
			_recalculateInputs = true;
			UpdateDesignerAutoControlInfo();
			if (Game.InFlightScene)
			{
				_craftControlsChangedMigrator = new EventMigrator<ICommandPod>(() => base.PartScript.CommandPod, delegate(ICommandPod commandPod)
				{
					commandPod.ControlsChanged += OnCommandPodControlsChanged;
				}, delegate(ICommandPod commandPod)
				{
					commandPod.ControlsChanged -= OnCommandPodControlsChanged;
				});
				_craftControlsChangedMigrator.AddMigrationTrigger(() => base.PartScript, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
				{
					partScript.CommandPodChanged += migrator.MigrateEvent;
				}, delegate(EventMigrator<ICommandPod> migrator, IPartScript partScript)
				{
					partScript.CommandPodChanged -= migrator.MigrateEvent;
				});
			}
		}

		public override void OnPartDestroyed()
		{
			DisposeControlSurface();
		}

		public override void OnSymmetry(SymmetryMode mode, IPartScript originalPart, bool created)
		{
			if (!base.Data.InvertOnMirror || !Game.InDesignerScene)
			{
				return;
			}
			if (mode == SymmetryMode.Mirror)
			{
				if (!created)
				{
					originalPart = Symmetry.GetSymmetricPartScripts(base.PartScript).FirstOrDefault((IPartScript x) => x != base.PartScript);
					if (originalPart == null)
					{
						return;
					}
				}
				ControlSurfaceScript controlSurfaceScript = originalPart.GetModifiers<ControlSurfaceScript>().FirstOrDefault(delegate(ControlSurfaceScript x)
				{
					Guid? symmetryId = x.Data.SymmetryId;
					Guid? symmetryId2 = base.Data.SymmetryId;
					if (symmetryId.HasValue != symmetryId2.HasValue)
					{
						return false;
					}
					return !symmetryId.HasValue || symmetryId.GetValueOrDefault() == symmetryId2.GetValueOrDefault();
				});
				base.Data.Invert = !controlSurfaceScript.Data.Invert;
				return;
			}
			base.Data.Invert = originalPart.GetModifiers<ControlSurfaceScript>().FirstOrDefault(delegate(ControlSurfaceScript x)
			{
				Guid? symmetryId = x.Data.SymmetryId;
				Guid? symmetryId2 = base.Data.SymmetryId;
				if (symmetryId.HasValue != symmetryId2.HasValue)
				{
					return false;
				}
				return !symmetryId.HasValue || symmetryId.GetValueOrDefault() == symmetryId2.GetValueOrDefault();
			}).Data.Invert;
		}

		protected virtual void Awake()
		{
			MeshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			_meshFilter = base.gameObject.AddComponent<MeshFilter>();
			if (Game.InDesignerScene)
			{
				_collider = _meshFilter.gameObject.AddComponent<MeshCollider>();
				_collider.convex = true;
				_meshFilter.gameObject.AddComponent<PartColliderScript>();
			}
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			WingScript = base.PartScript.GameObject.GetComponent<WingScript>();
			base.transform.parent = WingScript.WingRoot;
			WingScript.RegisterControlSurface(this);
			base.PartScript.PartMaterialScript.AddRenderer(MeshRenderer, true);
			if (Game.InFlightScene && WingScript.Data.WingPhysicsEnabled)
			{
				CreateControlSurfacePhysics();
			}
		}

		protected override void OnRemoveModifier()
		{
			DisposeControlSurface();
		}

		private Vector3 CalculateControlAxisContributions()
		{
			return MathUtils.ComputeRotationContributions(base.transform.position, WingScript.LiftUp, base.PartScript.CraftScript.CenterOfMass, WingScript.OnRightSide, base.Data.SingleAxisWhenAuto);
		}

		private void CreateControlSurfacePhysics()
		{
			UnityFS.Wing wingPhysicsScript = WingScript.WingPhysicsScript;
			ControlSurfacePhysics = wingPhysicsScript.gameObject.AddComponent<ControlSurface>();
			ControlSurfacePhysics.MaxDeflectionDegrees = base.Data.MaxDeflectionDegree;
			ControlSurfacePhysics.RootHingeDistanceFromTrailingEdge = WingScript.Data.HingeDistanceFromTrailingEdge;
			ControlSurfacePhysics.TipHingeDistanceFromTrailingEdge = WingScript.Data.HingeDistanceFromTrailingEdge;
			ControlSurfacePhysics.AxisName = base.Data.Input;
			ControlSurfacePhysics.SetControllable(enable: true);
			ControlSurfacePhysics.AffectedSections = new bool[wingPhysicsScript.SectionCount];
			for (int i = base.Data.Start; i < base.Data.End; i++)
			{
				if (i < ControlSurfacePhysics.AffectedSections.Length)
				{
					ControlSurfacePhysics.AffectedSections[i] = true;
				}
			}
		}

		private void DisposeControlSurface()
		{
			_craftControlsChangedMigrator?.Dispose();
			WingScript.UnregisterControlSurface(this);
			WingScript.WingUpdated -= OnWingUpdated;
			base.PartScript.ConnectedToPart -= OnConnectedToNewPart;
			base.PartScript.PartMaterialScript.RemoveRenderer(MeshRenderer);
		}

		private IInputController GetAutoInputController(Vector3 axisContributions, out int inputAdjustment)
		{
			inputAdjustment = 1;
			if (base.PartScript.CommandPod == null)
			{
				return new SimpleInputControllerGeneric<ControlSurfaceScript>(base.Data.Input, this, (ControlSurfaceScript x) => 0f);
			}
			float pitch = axisContributions.x;
			float yaw = axisContributions.y;
			float roll = axisContributions.z;
			CraftControls controls = base.PartScript.CommandPod.Controls;
			return new SimpleInputControllerGeneric<ControlSurfaceScript>(base.Data.Input, this, (ControlSurfaceScript x) => AutoInput());
			float AutoInput()
			{
				return Mathf.Clamp(controls.Pitch * pitch + controls.Yaw * yaw + controls.Roll * roll, -1f, 1f);
			}
		}

		private IInputController GetInputController(Vector3 autoAxisContributions, out int inputAdjustment)
		{
			inputAdjustment = ((!(base.Data.Invert ^ (WingScript.OnRightSide && base.Data.Input == "Pitch"))) ? 1 : (-1));
			return base.Data.Input switch
			{
				"Roll" => GetInputController((CraftControls x) => x.Roll), 
				"Pitch" => GetInputController((CraftControls x) => x.Pitch), 
				"Yaw" => GetInputController((CraftControls x) => x.Yaw), 
				"Throttle" => GetInputController((CraftControls x) => x.Throttle), 
				"Brake" => GetInputController((CraftControls x) => x.Brake), 
				"Slider1" => GetInputController((CraftControls x) => x.Slider1), 
				"Slider2" => GetInputController((CraftControls x) => x.Slider2), 
				"Slider3" => GetInputController((CraftControls x) => x.Slider3), 
				"Slider4" => GetInputController((CraftControls x) => x.Slider4), 
				_ => GetAutoInputController(autoAxisContributions, out inputAdjustment), 
			};
		}

		private float GetInputValue()
		{
			return Mathf.Clamp(_input.Value * (float)_inputAdjustment, -1f, 1f);
		}

		private void OnAutoPropertyChanged(ControlSurfaceData source)
		{
			UpdateDesignerAutoControlInfo();
		}

		private void OnCommandPodControlsChanged(ICommandPod source, bool adjustControlsToCom)
		{
			if (adjustControlsToCom)
			{
				_autoAxisContributions = CalculateControlAxisContributions();
			}
			_recalculateInputs = true;
		}

		private void OnConnectedToNewPart(PartConnectedEventData e)
		{
			UpdateDesignerAutoControlInfo();
		}

		private void OnWingUpdated(WingScript wing)
		{
			if (Game.InDesignerScene)
			{
				UpdateDesignerAutoControlInfo();
			}
		}

		private void UpdateDesignerAutoControlInfo()
		{
			Vector3 vector = CalculateControlAxisContributions();
			base.Data.DesignerAutoAxesInfo = $"Pitch: {vector.x}, Yaw: {vector.y}, Roll: {vector.z}";
		}
	}
}
