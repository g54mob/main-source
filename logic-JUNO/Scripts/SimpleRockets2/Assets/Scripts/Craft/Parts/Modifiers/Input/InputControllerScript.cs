using System;
using System.Linq;
using Assets.Scripts.Design;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Input;
using ModApi.Data;
using ModApi.Design;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Input
{
	public class InputControllerScript : PartModifierScript<InputControllerData>, IInputController, IInputControllerInput, IFlightStart, IGameLoopItem, IFlightUpdate
	{
		private EventMigrator<ICommandPod> _craftControlsChangedMigrator;

		private bool _initialized;

		private IInputControllerInput _overrideInput;

		private IInputControllerInput _primaryInput;

		public bool Active { get; private set; }

		public bool? ActiveOverride { get; set; }

		bool IInputControllerInput.Enabled => Active;

		public string InputId => base.Data.InputId;

		public bool InvertOnMirror
		{
			get
			{
				return base.Data.InvertOnMirror;
			}
			set
			{
				base.Data.InvertOnMirror = value;
			}
		}

		public IInputControllerInput OverrideInput => _overrideInput;

		public IInputControllerInput PrimaryInput => _primaryInput;

		public float Value { get; private set; }

		float IInputControllerInput.Value => Value;

		public bool Visible
		{
			get
			{
				if (base.Data.PartPropertiesEnabled)
				{
					return base.Data.InspectorEnabled;
				}
				return false;
			}
			set
			{
				InputControllerData data = base.Data;
				bool partPropertiesEnabled = (base.Data.InspectorEnabled = value);
				data.PartPropertiesEnabled = partPropertiesEnabled;
			}
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			Value = base.Data.CurrentValue;
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			IInputControllerInput inputControllerInput = null;
			if (_overrideInput != null && _overrideInput.Enabled)
			{
				inputControllerInput = _overrideInput;
			}
			else
			{
				if (_primaryInput == null || !_primaryInput.Enabled)
				{
					return;
				}
				inputControllerInput = _primaryInput;
			}
			InputControllerData data = base.Data;
			bool flag;
			if (ActiveOverride.HasValue)
			{
				flag = ActiveOverride.Value;
			}
			else
			{
				flag = base.Data.IgnorePartActivationState || base.PartScript.Data.Activated;
				if (data.ActivationGroup != 0)
				{
					flag &= base.PartScript.CommandPod?.Controls.GetActivationGroup(data.ActivationGroup) ?? false;
				}
			}
			if (flag)
			{
				float num = inputControllerInput.Value;
				InputControllerInputRange inputAxisRange = data.InputAxisRange;
				if (inputAxisRange != null)
				{
					num = inputAxisRange.RemapInput(num);
				}
				if (data.Invert && data.InvertType == InvertType.Axis)
				{
					num = 0f - num;
				}
				if (data.Type == InputControllerType.Standard)
				{
					if (num < 0f)
					{
						Value = (0f - num) * data.MinValue;
					}
					else
					{
						Value = num * data.MaxValue;
					}
				}
				else if (data.Type == InputControllerType.LerpFullAxis)
				{
					Value = Mathf.Lerp(data.MinValue, data.MaxValue, Mathf.Clamp01(num * 0.5f + 0.5f));
				}
				else if (data.Type == InputControllerType.LerpPositiveAxis)
				{
					Value = Mathf.Lerp(data.MinValue, data.MaxValue, Mathf.Clamp01(num));
				}
				else if (data.Type == InputControllerType.LerpNegativeAxis)
				{
					Value = Mathf.Lerp(data.MinValue, data.MaxValue, Mathf.Clamp01(num + 1f));
				}
				else
				{
					if (data.Type != InputControllerType.Curve)
					{
						throw new NotSupportedException($"InputControllerType.{data.Type} is not supported by the InputController.");
					}
					UserCurve outputCurve = data.OutputCurve;
					if (outputCurve == null)
					{
						Debug.LogError("The input controller type is set to 'Curve' but the output curve was not defined or not found.");
						_primaryInput = null;
						_overrideInput = null;
						return;
					}
					Value = outputCurve.GetValueAtTime(data.OutputCurveOffset + num);
				}
				if (data.Invert && data.InvertType == InvertType.Output)
				{
					Value = 0f - Value;
				}
			}
			else if (data.ZeroOnDeactivate)
			{
				Value = 0f;
			}
			Active = flag;
			data.CurrentValue = Value;
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			if (Game.InFlightScene)
			{
				if (!_initialized)
				{
					Initialize();
				}
				OnCraftLoadedOrChanged();
			}
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			OnCraftLoadedOrChanged();
		}

		public override void OnPartDestroyed()
		{
			base.OnPartDestroyed();
			_craftControlsChangedMigrator?.Dispose();
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
				InputControllerScript inputControllerScript = originalPart.GetModifiers<InputControllerScript>().FirstOrDefault(delegate(InputControllerScript x)
				{
					Guid? symmetryId = x.Data.SymmetryId;
					Guid? symmetryId2 = base.Data.SymmetryId;
					if (symmetryId.HasValue != symmetryId2.HasValue)
					{
						return false;
					}
					return !symmetryId.HasValue || symmetryId.GetValueOrDefault() == symmetryId2.GetValueOrDefault();
				});
				base.Data.Invert = !inputControllerScript.Data.Invert;
				return;
			}
			base.Data.Invert = originalPart.GetModifiers<InputControllerScript>().FirstOrDefault(delegate(InputControllerScript x)
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

		private void Initialize()
		{
			_initialized = true;
			_primaryInput = InputControllerInput.Create(base.Data.Input);
			_overrideInput = InputControllerInput.Create(base.Data.OverrideInput);
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
			base.PartScript.MovedToNewCraft += OnMovedToNewCraft;
		}

		private void OnCommandPodControlsChanged(ICommandPod source, bool adjustControlsToCom)
		{
			UpdateInputs();
		}

		private void OnCraftLoadedOrChanged()
		{
			UpdateInputs();
		}

		private void OnMovedToNewCraft(ICraftScript oldCraft, ICraftScript newCraft)
		{
			UpdateInputs();
		}

		private void UpdateInput(IInputControllerInput input)
		{
			if (input != null)
			{
				if (input is InputControllerInput inputControllerInput)
				{
					inputControllerInput.RefreshInput(base.PartScript);
				}
				else if (input is InputControllerInputPartModifierWrapper inputControllerInputPartModifierWrapper)
				{
					inputControllerInputPartModifierWrapper.RefreshInput(base.PartScript);
				}
				else if (input is InputControllerExpression inputControllerExpression)
				{
					inputControllerExpression.RefreshInput(base.PartScript);
				}
			}
		}

		private void UpdateInputs()
		{
			UpdateInput(_primaryInput);
			UpdateInput(_overrideInput);
		}
	}
}
