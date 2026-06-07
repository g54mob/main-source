using System;
using System.Collections.Generic;
using ModApi.Common.Events;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using ModApi.Scripts.State.Validation;
using ModApi.Services.Purchasing;
using UnityEngine;

namespace ModApi.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Additional Settings", PanelOrder = 2000, HeaderCollapsed = true)]
	public class ConfigData : PartModifierData<ConfigScript>, IConfigData
	{
		[DesignerPropertyCenterButton(Label = "Add Flight Program", Order = 99, Tooltip = "Adds a flight program to this part.")]
		private bool _addFlightProgramButton;

		[SerializeField]
		[DesignerPropertyToggleButton(Order = 6, Label = "Autoactivation", Tooltip = "Automatically activates the part if it isn't assigned to any Activation Group or Stage.")]
		private bool _autoActivateIfNoStageOrActivationGroup = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _buoyancyBaseScale = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2f, 41, Label = "Buoyancy", Order = 107, Tooltip = "Changes how buoyant the part is in water.")]
		private float _buoyancyUserScale = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(Order = 122, Label = "Cast shadows", Tooltip = "Define if the part group should cast shadows on other parts and the terrain while in flight.")]
		private bool _castShadows = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _centerOfMass = Vector3.zero;

		[DesignerPropertyCenterButton(Label = "Change Command Pod", Order = 17, Tooltip = "Change the command pod that controls this part.")]
		private bool _changeCommandPod;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _collisionDisconnectImpulse = 1000f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _collisionDisconnectVelocity = 15f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _collisionExplodeImpulse = 2000f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _collisionExplodeVelocity = 30f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _collisionPreventExternalDisconnections;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private PartCollisionVelocityMode _collisionVelocityMode = PartCollisionVelocityMode.NormalOnly;

		[DesignerPropertyLabel(PreserveState = false, NeverSerialize = true, Order = 101)]
		private string _descriptionLabel = string.Empty;

		[SerializeField]
		[DesignerPropertySlider(0f, 2f, 41, Label = "Drag Scale", Order = 115, Tooltip = "Changes this part's contribution to the craft's overall drag force.")]
		private float _dragScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _dragScaleActive = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _dragScaleAngular = 1f;

		[SerializeField]
		[DesignerPropertySlider(-1f, 1f, 101, Label = "Explosiveness", Order = 119, Tooltip = "Changes how much explosiveness this part has.")]
		private float _explosiveness;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Fuel Line", Order = 5, Tooltip = "Allow connected engines to search this part and its connected parts for fuel tanks.")]
		private bool _fuelLine;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _heatShield;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _heatShieldBaseScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _heatShieldMass;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 101, Label = "Heat Shield", Order = 11, Tooltip = "A heat shield layer that prevents heat damage until it gets depleted.", TechTreeIdForMaxValue = "Config.HeatShield")]
		private float _heatShieldScale = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _heatShieldValidation = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _ignoreValidation;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Include in Drag", Order = 120, Tooltip = "Determines whether or not to include this part in the drag model.")]
		private bool _includeInDrag = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _inertiaTensorBaseScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _inertiaTensorMin = 0.05f;

		[SerializeField]
		[DesignerPropertySlider(1f, 50f, 50, IsHidden = true, Label = "Stability Modifier", Order = 102, Tooltip = "Increase to strengthen movable joints which are wobbly. Increase slowly, and only as much as necessary until the joint is stable as it can dramatically slow down rotation, or cause other issues if raised too much. Note: It is irrelevant which part within a group is adjusted; values are summed between parts in a group and applied to the group as a whole.")]
		private float _inertiaTensorUserScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _initialCraftNodeId = -1;

		[SerializeField]
		[DesignerPropertySlider(0f, 5f, 101, Label = "Mass Scale", Order = 105, Tooltip = "Handy way to trick the laws of physics and increase or decrease the mass of this part.")]
		private float _massScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxDamage = 100f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxDrag;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxDragActive;

		[SerializeField]
		[DesignerPropertySlider(0f, 3000f, 61, Label = "Max Temperature", Order = 110, Tooltip = "The maximum temperature, in Kelvin, that this part can withstand before taking heat damage or depleting its heat shield.")]
		private float _maxTemperature = 1500f;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Occlusion", Order = 150, Tooltip = "Changes how the occlusion state of the part is calculated. Some parts will not function if they are occluded, such as wings and inlets. Auto will calculate if the part is occluded by other surrounding parts. Always will always consider the part as occluded. Never will never consider the part as occluded.")]
		private OcclusionCalculationType _occlusion;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Part Collisions", Order = 150, Tooltip = "Determines how collisions are handled when two parts bump into each other.")]
		private PartCollisionHandlingMethod _partCollisionHandling;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Collision Response", Order = 155, Tooltip = "Determines how this part reacts when it takes a solid hit.")]
		private PartCollisionResponseType _partCollisionResponse = PartCollisionResponseType.Default;

		[DesignerPropertyLabel(Order = 0, PreserveState = false, NeverSerialize = true)]
		private string _partIdLabel = string.Empty;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _partScale = Vector3.one;

		[DesignerPropertySlider(0.05f, 5f, 100, Label = "Part Scale", Order = 103, NeverSerialize = true, PreserveState = false, Tooltip = "Changes the size of the part. This can cause odd behavior, so for parts that have a dedicated size setting or tool we recommend you use that instead of this.")]
		private float _partScaleMagnitude = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _partSelectionEnabled = true;

		[SerializeField]
		[DesignerPropertyToggleButton(Order = 121, Label = "Prevent Debris", Tooltip = "Prevent this part (and connected parts) from being automatically removed when separated from the player's craft.")]
		private bool _preventDebris;

		[SerializeField]
		[DesignerPropertySlider(0f, 2f, 101, Label = "Price Scale", Order = 106, Tooltip = "Handy way to adjust the cost of this part to fit your budget.")]
		private float _priceScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _raiseWaterEventsEvenIfNotBuoyant;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Render Queue", Order = 190, Tooltip = "The render queue for the part. Rendering before the depth mask will allow some parts to be visible inside of cockpits where they might not otherwise be visible. Transparent objects may not display correctly.")]
		private PartMeshRenderQueue _renderQueue;

		[DesignerPropertyToggleButton(PreserveState = false, NeverSerialize = true, Order = 9, Label = "Show Advanced Properties")]
		private bool _showHiddenPartProperties;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Stage Activation", Order = 11, Tooltip = "Changes the current stage activation type of the part.")]
		private StageActivationType _stageActivationType;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _supportsActivation;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Supports Transparency", Order = 122, Tooltip = "When enabled this part will respond to transparent materials. Note that this can cause some parts to render in strange and mysterious ways, so use with caution.")]
		private bool _supportsTransparency = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _thermalMassRatio = 1f;

		[DesignerPropertyToggleButton(PreserveState = false, NeverSerialize = true, Order = 100, Header = "Tinker Panel", HeaderCollapsed = true, Label = "Enabled")]
		private bool _tinkerPanelEnabled;

		[DesignerPropertyUpgrade(PreserveState = false, NeverSerialize = true, Order = 101)]
		private string _tinkerPanelUpgradeLabel = string.Empty;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private string _tutorialId;

		[DesignerPropertyCenterButton(Label = "View Command Pod", Order = 18, Tooltip = "View the command pod that controls this part.")]
		private bool _viewCommandPod;

		[DesignerPropertyCenterButton(Label = "Edit Hidden Properties", Order = 999, Tooltip = "Opens a window that shows all the parameters in the different modifiers found in the part, with all its available parameters.")]
		private bool _xmlEditButton;

		public bool AutoActivateIfNoStageOrActivationGroup => _autoActivateIfNoStageOrActivationGroup;

		public float BuoyancyBaseScale => _buoyancyBaseScale;

		public float BuoyancyUserScale => _buoyancyUserScale;

		public bool CanExplode => PartCollisionResponse == PartCollisionResponseType.Default;

		public bool CastShadows
		{
			get
			{
				return _castShadows;
			}
			set
			{
				_castShadows = value;
			}
		}

		public Vector3 CenterOfMass
		{
			get
			{
				return _centerOfMass;
			}
			set
			{
				_centerOfMass = value;
			}
		}

		public float CollisionDisconnectImpulse
		{
			get
			{
				return _collisionDisconnectImpulse;
			}
			set
			{
				_collisionDisconnectImpulse = value;
			}
		}

		public float CollisionDisconnectVelocity => _collisionDisconnectVelocity;

		public float CollisionExplodeImpulse
		{
			get
			{
				return _collisionExplodeImpulse;
			}
			set
			{
				_collisionExplodeImpulse = value;
			}
		}

		public float CollisionExplodeVelocity => _collisionExplodeVelocity;

		public bool CollisionPreventExternalDisconnections => _collisionPreventExternalDisconnections;

		public PartCollisionVelocityMode CollisionVelocityMode => _collisionVelocityMode;

		public float DragScale
		{
			get
			{
				return _dragScale;
			}
			set
			{
				_dragScale = value;
			}
		}

		public float DragScaleActive => _dragScaleActive;

		public float DragScaleAngular => _dragScaleAngular;

		public float Explosiveness => Mathf.Pow(10f, _explosiveness);

		public bool FuelLineOverride
		{
			get
			{
				return _fuelLine;
			}
			set
			{
				_fuelLine = value;
			}
		}

		public float HeatShield
		{
			get
			{
				return _heatShield;
			}
			set
			{
				_heatShield = value;
			}
		}

		public float HeatShieldScale => _heatShieldScale;

		public bool HeatShieldValidation => _heatShieldValidation;

		public bool IgnoreValidation => _ignoreValidation;

		public bool IncludeInDrag
		{
			get
			{
				return _includeInDrag;
			}
			set
			{
				_includeInDrag = value;
			}
		}

		public float InertiaTensorBaseScale => _inertiaTensorBaseScale;

		public float InertiaTensorMin => _inertiaTensorMin;

		public float InertiaTensorUserScale => _inertiaTensorUserScale;

		public int InitialCraftNodeId
		{
			get
			{
				return _initialCraftNodeId;
			}
			set
			{
				_initialCraftNodeId = value;
			}
		}

		public override float MassDry => _heatShieldMass;

		public float MassScale
		{
			get
			{
				return _massScale;
			}
			set
			{
				_massScale = value;
			}
		}

		public float MaxDamage => _maxDamage;

		public float MaxDrag => _maxDrag;

		public float MaxDragActive => _maxDragActive;

		public float MaxTemperature
		{
			get
			{
				return _maxTemperature;
			}
			set
			{
				_maxTemperature = value;
			}
		}

		public OcclusionCalculationType OcclusionCalculation => _occlusion;

		public PartCollisionHandlingMethod PartCollisionHandling => _partCollisionHandling;

		public PartCollisionResponseType PartCollisionResponse => _partCollisionResponse;

		public Vector3 PartScale
		{
			get
			{
				return _partScale;
			}
			set
			{
				_partScale = value;
			}
		}

		public bool PartSelectionEnabled
		{
			get
			{
				if (!_partSelectionEnabled)
				{
					return Application.isEditor;
				}
				return true;
			}
		}

		public float PartThermalMassRatio => _thermalMassRatio;

		public bool PreventDebris
		{
			get
			{
				return _preventDebris;
			}
			set
			{
				_preventDebris = value;
			}
		}

		public override long Price => (int)(10f * _heatShield);

		public float PriceScale
		{
			get
			{
				return _priceScale;
			}
			set
			{
				_priceScale = value;
			}
		}

		public bool RaiseWaterEventsEvenIfNotBuoyant => _raiseWaterEventsEvenIfNotBuoyant;

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

		public bool ShowHiddenPartProperties
		{
			get
			{
				return Game.Instance.Settings.Game.Designer.ShowHiddenPartProperties;
			}
			set
			{
				Game.Instance.Settings.Game.Designer.ShowHiddenPartProperties.UpdateAndCommit(value);
			}
		}

		public StageActivationType StageActivationType => _stageActivationType;

		public bool SupportsActivation
		{
			get
			{
				return _supportsActivation;
			}
			set
			{
				_supportsActivation = value;
			}
		}

		public bool SupportsTransparency => _supportsTransparency;

		public bool TinkerPanelEnabled
		{
			get
			{
				return Game.Instance.Settings.Game.Designer.EnableTinkerPanel;
			}
			set
			{
				Game.Instance.Settings.Game.Designer.EnableTinkerPanel.UpdateAndCommit(value);
			}
		}

		public string TutorialId
		{
			get
			{
				return _tutorialId;
			}
			set
			{
				_tutorialId = value;
			}
		}

		public event EventHandler<EventArgs> RenderQueueChanged;

		public void OnDesignerCraftStructureChanged()
		{
			base.DesignerPartProperties?.GetProperty(this, "_partIdLabel")?.RefreshUI();
			UpdateHeatShield();
		}

		protected override ConfigScript CreateScriptComponent(IPartScript partScript)
		{
			if (Game.InDesignerScene)
			{
				return base.CreateScriptComponent(partScript);
			}
			return null;
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _partIdLabel, (string x) => $"Part: {base.Part.Id}, Group: {base.Script.GetBodyId()}");
			d.OnValueLabelRequested(() => _buoyancyUserScale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _massScale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _priceScale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _dragScale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _inertiaTensorUserScale, (float x) => _inertiaTensorUserScale.ToString("n0"));
			d.OnVisibilityRequested(() => _addFlightProgramButton, (bool x) => !base.Part.PartScript.HasFlightProgram);
			d.OnVisibilityRequested(() => _stageActivationType, (bool x) => SupportsActivation);
			d.OnPropertyActivated(() => _partScaleMagnitude, delegate
			{
				_partScaleMagnitude = _partScale.x;
			});
			d.OnValueLabelRequested(() => _partScaleMagnitude, (float x) => Utilities.FormatPercentage(_partScale.x));
			d.OnPropertyChanged(() => _partScaleMagnitude, delegate(float newVal, float oldVal)
			{
				UpdatePartScale(newVal);
			});
			d.OnPropertyChanged(() => _fuelLine, delegate
			{
				UpdateSymmetryAndCraftStructure();
			});
			d.OnPropertyChanged(() => _massScale, delegate
			{
				UpdateSymmetryAndCraftStructure();
			});
			d.OnPropertyChanged(() => _priceScale, delegate
			{
				UpdateSymmetryAndCraftStructure();
			});
			d.OnPropertyChanged(() => _renderQueue, delegate
			{
				RaiseOnRenderQueueChangedEvent();
			});
			d.OnSpinnerValuesRequested(() => _partCollisionHandling, delegate(List<string> x)
			{
				x.Clear();
				x.Add(PartCollisionHandlingMethod.Default.ToString());
				x.Add(PartCollisionHandlingMethod.Never.ToString());
			});
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			if (validator.IsCareerMode)
			{
				d.OnVisibilityRequested(() => _fuelLine, (bool x) => validator.IsItemAvailable("Config.FuelLine"));
			}
			IInAppPurchaseFeature tinkerPanelFeature = Game.Instance.InAppPurchases.Features.DesignerTinkerPanel;
			bool tinkerPanelSupported = !validator.IsCareerMode || validator.IsItemAvailable("Cheats.TinkerPanel");
			bool tinkerPanelAvailable = tinkerPanelSupported && tinkerPanelFeature.Unlocked;
			d.OnVisibilityRequested(() => _tinkerPanelEnabled, (bool x) => tinkerPanelAvailable);
			d.OnVisibilityRequested(() => _tinkerPanelUpgradeLabel, (bool x) => tinkerPanelSupported && !tinkerPanelFeature.Unlocked);
			d.OnValueLabelRequested(() => _tinkerPanelUpgradeLabel, (string x) => "Upgrade to the " + tinkerPanelFeature.ProductName + " to unlock the Tinker Panel.");
			d.OnPropertyChanged(() => _tinkerPanelUpgradeLabel, delegate
			{
				Game.Instance.InAppPurchases.CreatePurchaseDialog(tinkerPanelFeature.ProductId);
			});
			if (!tinkerPanelAvailable)
			{
				TinkerPanelEnabled = false;
			}
			d.OnVisibilityRequested(() => _preventDebris, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _partScaleMagnitude, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _massScale, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _priceScale, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _dragScale, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _includeInDrag, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _maxTemperature, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _partCollisionHandling, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _partCollisionResponse, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _occlusion, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _supportsTransparency, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _renderQueue, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _castShadows, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _xmlEditButton, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _explosiveness, (bool x) => TinkerPanelEnabled);
			d.OnVisibilityRequested(() => _buoyancyUserScale, (bool x) => TinkerPanelEnabled && _buoyancyBaseScale > 0f);
			d.OnValueLabelRequested(() => _descriptionLabel, delegate
			{
				d.GetLabelProperty(() => _descriptionLabel);
				if (TinkerPanelEnabled)
				{
					_descriptionLabel = "These settings are not fully supported. Use at your own risk!";
				}
				else if (validator.IsCareerMode && !validator.IsItemAvailable("Cheats.TinkerPanel"))
				{
					_descriptionLabel = "These are extra advanced settings and are not fully supported, so we have disabled them in Career Mode. You can go to a Sandbox game to use them.";
				}
				else
				{
					_descriptionLabel = "These are extra advanced settings and are not fully supported, but they are fun to tinker with so we included them. Use at your own risk!";
				}
				return _descriptionLabel;
			});
			d.OnValueLabelRequested(() => _explosiveness, (float x) => Utilities.FormatPercentage(Explosiveness));
			d.OnValueLabelRequested(() => _heatShieldScale, (float x) => ((int)_heatShield).ToString());
			d.OnPropertyChanged(() => _heatShieldScale, delegate
			{
				d.Manager.RefreshUI();
				base.Part.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnPropertyActivated(() => _tinkerPanelEnabled, delegate
			{
				_tinkerPanelEnabled = TinkerPanelEnabled;
			});
			d.OnPropertyChanged(() => _tinkerPanelEnabled, delegate(bool newVal, bool oldVal)
			{
				TinkerPanelEnabled = newVal;
				ILabelProperty labelProperty = d.GetLabelProperty(() => _descriptionLabel);
				if (!newVal && ShowHiddenPartProperties)
				{
					ShowHiddenPartProperties = false;
					base.DesignerPartProperties.Manager.Flyout.RefreshUI();
				}
				labelProperty.RefreshUI();
			});
			d.OnPropertyActivated(() => _showHiddenPartProperties, delegate
			{
				_showHiddenPartProperties = ShowHiddenPartProperties;
			});
			d.OnPropertyChanged(() => _showHiddenPartProperties, delegate(bool newVal, bool oldVal)
			{
				ShowHiddenPartProperties = newVal;
				base.DesignerPartProperties.Manager.Flyout.RefreshUI();
			});
			d.OnPropertyChanged(() => _addFlightProgramButton, delegate
			{
				Game.Instance.Designer.DesignerUi.EditFlightProgram(base.Part);
				base.DesignerPartProperties.Manager.Flyout.RefreshUI();
			});
			d.OnPropertyChanged(() => _viewCommandPod, delegate
			{
				IPartScript commandPod = base.Part.PartScript?.CommandPod?.Part?.PartScript;
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					Game.Instance.Designer.SelectPart(commandPod, null, justAdded: false);
				});
			});
			d.OnVisibilityRequested(() => _viewCommandPod, (bool x) => !base.Part.PartType.IsCommandPod);
			d.OnVisibilityRequested(() => _changeCommandPod, (bool x) => !base.Part.PartType.IsCommandPod);
			d.OnPropertyChanged(() => _changeCommandPod, delegate
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					ChangeCommandPod();
				});
			});
			d.OnPropertyChanged(() => _supportsTransparency, delegate
			{
				base.Part.PartScript?.PartMaterialScript.UpdateRenderers();
			});
			d.OnPropertyChanged(() => _xmlEditButton, delegate
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					Game.Instance.Designer.DesignerUi.SelectedFlyout = Game.Instance.Designer.DesignerUi.Flyouts.XMLedit;
				});
			});
		}

		private void ChangeCommandPod()
		{
			Game.Instance.Designer.SelectPartTool.Activate((PartData p) => p.PartType.IsCommandPod, base.Part.CommandPod, delegate(PartData p)
			{
				base.Part.CommandPod = p;
			}, null);
		}

		private void RaiseOnRenderQueueChangedEvent()
		{
			this.RenderQueueChanged?.Invoke(this, new EventArgs());
		}

		private void UpdateHeatShield()
		{
			if (_heatShieldScale >= 0f)
			{
				float magnitude = base.Part.PartScript.CalculateBounds().size.magnitude;
				if (magnitude > 0f && !float.IsInfinity(magnitude))
				{
					_heatShield = _heatShieldScale * _heatShieldBaseScale * magnitude * 100f;
				}
				_heatShieldMass = 0.25f * _heatShield * 0.01f;
			}
		}

		private void UpdatePartScale(float scale)
		{
			scale = Mathf.Max(0.05f, scale);
			_partScale = new Vector3(scale, scale, scale);
			base.Part.PartScript.Transform.localScale = _partScale;
			foreach (IPartScript symmetricPartScript in Game.Instance.Designer.Symmetry.GetSymmetricPartScripts(base.Part.PartScript))
			{
				symmetricPartScript.Transform.localScale = _partScale;
			}
		}

		private void UpdateSymmetryAndCraftStructure()
		{
			Game.Instance.Designer.Symmetry.SynchronizePartModifiers(base.Script.PartScript);
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
