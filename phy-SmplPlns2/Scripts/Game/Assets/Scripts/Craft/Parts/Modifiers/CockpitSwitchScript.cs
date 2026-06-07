using System;
using System.Collections.Generic;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Craft.Parts.Modifiers.XR;
using Assets.Scripts.Input;
using Assets.Scripts.Input.Events;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Settings;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CockpitSwitchScript : PartModifierScript, IInteractablePartModifier, IVariableDeclarations, IVariableOutput
	{
		private enum AudioClipIndex
		{
			SwitchOff = 0,
			SwitchOn = 1
		}

		public class SwitchComponent
		{
			public BoxCollider Collider;

			public GameObject GameObject;

			public MeshRenderer MeshRenderer;

			public Transform Transform;
		}

		private AudioRandomiser _audio;

		private Func<float> _input;

		private bool _inputActive;

		private AircraftControls.InputOverride _output;

		private float _outputValueActive;

		private float _outputValueInactive;

		private AircraftVariable _outputVariable;

		private int _outputVariablePriority;

		private bool _switchActivatedStateChanged;

		private SwitchComponent _switchComponentBase = new SwitchComponent();

		private SwitchComponent _switchComponentMain = new SwitchComponent();

		private float _switchPositionState;

		private float _switchPositionTransitionTime;

		private bool _targetStateOnRelease;

		public Vector3 GlobalPivotPosition => _switchComponentMain.Transform.position;

		public bool InteractionDisabled => false;

		public bool IsOutlined
		{
			get
			{
				return base.PartScript.PartMaterialScript.IsOutlined;
			}
			set
			{
				base.PartScript.PartMaterialScript.IsOutlined = value;
			}
		}

		public bool IsSwitchActivated { get; private set; }

		public CockpitSwitchData Modifier { get; private set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
			plan.Register(OnPreStartLayerUpdates, PreStartInitializationFlags.FlightDefault, 600);
		}

		PartTooltipPosition IInteractablePartModifier.GetTooltipPosition()
		{
			if (Modifier.Tooltip != null)
			{
				return new PartTooltipPosition(_switchComponentMain.MeshRenderer);
			}
			return default(PartTooltipPosition);
		}

		IEnumerator<string> IVariableDeclarations.GetVariableOutputs()
		{
			string inputId = Modifier.Input.InputId;
			if (GameInputs.Instance.FindById(inputId) == null)
			{
				int num = inputId.IndexOf(':');
				if (num != -1)
				{
					yield return inputId.Substring(0, num);
				}
				else
				{
					yield return inputId;
				}
			}
		}

		bool IInteractablePartModifier.HandleInput(IInputEvent e, bool isPartStillTarget)
		{
			if (!isPartStillTarget || e.InputState == InputState.End)
			{
				_switchActivatedStateChanged = IsSwitchActivated != _targetStateOnRelease;
				IsSwitchActivated = _targetStateOnRelease;
			}
			else if (e.InputState == InputState.Begin)
			{
				_targetStateOnRelease = Modifier.SwitchInteractionType == CockpitSwitchData.InteractionType.Toggle && !IsSwitchActivated;
				_switchActivatedStateChanged = true;
				IsSwitchActivated = !IsSwitchActivated;
			}
			return isPartStillTarget;
		}

		public void Initialize(CockpitSwitchData modifier)
		{
			Modifier = modifier;
			OnStyleChanged(modifier.Style);
		}

		string IInteractablePartModifier.OnHover()
		{
			return Modifier.Tooltip;
		}

		public void OnSizeChanged()
		{
			float scale = Modifier.Scale;
			Vector3 localScale = new Vector3(scale, scale, scale);
			_switchComponentBase.Transform.localScale = localScale;
			_switchComponentMain.Transform.localScale = localScale;
		}

		public void OnStyleChanged(CockpitSwitchData.CockpitSwitchStyle style)
		{
			LoadComponent(_switchComponentBase, "Base", style);
			LoadComponent(_switchComponentMain, "Main", style);
			if (_switchComponentBase.GameObject != null && _switchComponentMain.GameObject != null)
			{
				CockpitSwitchInteractableCollider componentInChildren = _switchComponentBase.GameObject.GetComponentInChildren<CockpitSwitchInteractableCollider>();
				if (componentInChildren != null)
				{
					componentInChildren.TransformTopEdge = _switchComponentMain.Transform.Find("TopEdge");
					componentInChildren.TransformBottomEdge = _switchComponentMain.Transform.Find("BottomEdge");
				}
			}
			base.PartScript.PrimaryPartCollider = _switchComponentBase.Collider;
			OnSizeChanged();
			base.PartScript.PartMaterialScript.InitializeMaterial();
		}

		void IVariableOutput.UpdateOutputs()
		{
			if (_outputVariable != null && Modifier.SwitchInteractionType == CockpitSwitchData.InteractionType.Continuous && IsSwitchActivated)
			{
				_outputVariable.SetValue(_outputValueActive, _outputVariablePriority);
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStartDesigner, CraftUpdateFlags.DesignerDefault);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightLocal);
		}

		private void LoadComponent(SwitchComponent component, string type, CockpitSwitchData.CockpitSwitchStyle style)
		{
			UnloadComponent(component);
			GameObject gameObject = Resources.Load<GameObject>($"Craft/Parts/CockpitSwitch/CockpitSwitch_{type}_{style}");
			if (gameObject != null)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject, base.transform);
				MeshRenderer component2 = gameObject2.GetComponent<MeshRenderer>();
				BoxCollider component3 = gameObject2.GetComponent<BoxCollider>();
				base.PartScript.PartMaterialScript.AddRenderer(component2);
				component.GameObject = gameObject2;
				component.Transform = gameObject2.transform;
				component.Collider = component3;
				component.MeshRenderer = component2;
				component.Transform.localPosition = Vector3.zero;
				component.Transform.localRotation = Quaternion.identity;
				component.Transform.localScale = Vector3.one;
			}
		}

		private void OnInputStateChanged()
		{
			IsSwitchActivated = _inputActive;
			_audio.Play(IsSwitchActivated ? 1 : 0, randomise: true);
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			UpdateSwitchPositionImmediately(_switchPositionState);
			if (loadContext == CraftLoadContext.Flight)
			{
				CockpitSwitchData.CockpitSwitchInput input = Modifier.Input;
				string text = input.InputId;
				NumericSetting<float> interactablePartColliderScale = Game.Instance.Settings.Gameplay.General.InteractablePartColliderScale;
				_switchComponentBase.Collider.size *= (float)interactablePartColliderScale;
				_switchComponentMain.Collider.size *= (float)interactablePartColliderScale;
				_outputValueInactive = 1f;
				_outputValueActive = Modifier.OutputValue;
				_output = new AircraftControls.InputOverride();
				_output.Active = false;
				if (GameInputs.Instance.FindById(text) != null)
				{
					base.PartScript.Aircraft.Controls.AddRawOverrideInput(text, _output);
				}
				else if (!string.IsNullOrWhiteSpace(text))
				{
					try
					{
						int num = text.IndexOf(':');
						if (num != -1 && int.TryParse(text.AsSpan(num + 1), out var result))
						{
							_outputVariablePriority = result;
							text = text.Substring(0, num);
						}
						else
						{
							_outputVariablePriority = 0;
						}
						_outputVariable = base.PartScript.Aircraft.VariableSystem.AddVariable(text);
						_outputValueInactive = 0f;
					}
					catch (Exception ex)
					{
						Debug.LogWarning("Switch input '" + text + "': " + ex.Message);
					}
				}
				if (text == Game.Inputs.LandingGear.Id)
				{
					text = "-" + text;
					_outputValueInactive = 0f;
				}
				if (input.DefaultInteractionType == CockpitSwitchData.InteractionType.Toggle && Modifier.SwitchInteractionType == CockpitSwitchData.InteractionType.Toggle)
				{
					_input = base.PartScript.Aircraft.Controls.GetAxisGetter(text, -1f, null, returnNull: true);
				}
				else if (_outputVariable != null && Modifier.SwitchInteractionType == CockpitSwitchData.InteractionType.Toggle)
				{
					AircraftVariable v = _outputVariable;
					_input = () => v.Value;
				}
				if (_input == null)
				{
					_input = () => IsSwitchActivated ? 1 : (-1);
				}
				AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
				audioSource.outputAudioMixerGroup = AudioStore.KnobAudio.MixerGroup;
				audioSource.volume = AudioStore.KnobAudio.DefaultVolume;
				audioSource.minDistance = AudioStore.KnobAudio.MinDistance;
				audioSource.maxDistance = AudioStore.KnobAudio.MaxDistance;
				audioSource.dopplerLevel = AudioStore.KnobAudio.Doppler;
				audioSource.spatialBlend = 1f;
				_audio = new AudioRandomiser(2, audioSource);
				for (int num2 = 1; num2 <= 5; num2++)
				{
					_audio.AddFiles($"Sound/Switch/Switch_OFF_{num2}", $"Sound/Switch/Switch_ON_{num2}");
				}
			}
			return UniTask.CompletedTask;
		}

		private UniTask OnPreStartLayerUpdates(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_switchComponentBase.GameObject.layer = 16;
			_switchComponentMain.GameObject.layer = 16;
			return UniTask.CompletedTask;
		}

		private void OnStartDesigner(in CraftUpdateFrameData frame)
		{
			base.PartScript.EditorColliders.Clear();
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			UpdateVisualStates(Time.deltaTime);
			CockpitSwitchData.InteractionType switchInteractionType = Modifier.SwitchInteractionType;
			if (_outputVariable != null)
			{
				switch (switchInteractionType)
				{
				case CockpitSwitchData.InteractionType.Toggle:
					if (_switchActivatedStateChanged)
					{
						_outputVariable.SetValue((!_inputActive) ? _outputValueActive : _outputValueInactive, _outputVariablePriority);
					}
					break;
				case CockpitSwitchData.InteractionType.Once:
					if (_switchActivatedStateChanged && IsSwitchActivated)
					{
						_outputVariable.SetValue(_outputValueActive, _outputVariablePriority);
					}
					break;
				}
			}
			else
			{
				switch (Modifier.Input.DefaultInteractionType)
				{
				case CockpitSwitchData.InteractionType.Toggle:
					switch (switchInteractionType)
					{
					case CockpitSwitchData.InteractionType.Toggle:
						_output.Active = _switchActivatedStateChanged;
						break;
					case CockpitSwitchData.InteractionType.Once:
						_output.Active = IsSwitchActivated && _switchActivatedStateChanged;
						break;
					default:
						_output.Active = _switchActivatedStateChanged;
						break;
					}
					break;
				case CockpitSwitchData.InteractionType.Once:
					switch (switchInteractionType)
					{
					case CockpitSwitchData.InteractionType.Toggle:
						_output.Active = IsSwitchActivated && _switchActivatedStateChanged;
						break;
					case CockpitSwitchData.InteractionType.Once:
						_output.Active = IsSwitchActivated && _switchActivatedStateChanged;
						break;
					default:
						_output.Active = IsSwitchActivated && _switchActivatedStateChanged;
						break;
					}
					break;
				default:
					switch (switchInteractionType)
					{
					case CockpitSwitchData.InteractionType.Toggle:
						_output.Active = IsSwitchActivated;
						break;
					case CockpitSwitchData.InteractionType.Once:
						_output.Active = IsSwitchActivated && _switchActivatedStateChanged;
						break;
					default:
						_output.Active = IsSwitchActivated;
						break;
					}
					break;
				}
				_output.Value = (IsSwitchActivated ? _outputValueActive : _outputValueInactive);
			}
			_switchActivatedStateChanged = false;
		}

		private void UnloadComponent(SwitchComponent component)
		{
			if (!(component.GameObject == null))
			{
				if (component.MeshRenderer != null)
				{
					base.PartScript.PartMaterialScript.RemoveRenderer(component.MeshRenderer, destroy: true);
				}
				UnityEngine.Object.Destroy(component.GameObject);
				component.GameObject = null;
				component.Transform = null;
				component.Collider = null;
				component.MeshRenderer = null;
			}
		}

		private void UpdateSwitchPositionImmediately(float positionState)
		{
			CockpitSwitchData modifier = Modifier;
			float angle = Mathf.Lerp(modifier.AngleOff, modifier.AngleOn, positionState);
			_switchComponentMain.Transform.localRotation = Quaternion.AngleAxis(angle, modifier.Axis);
		}

		private void UpdateSwitchPositionState(float deltaTime)
		{
			CockpitSwitchData modifier = Modifier;
			int num = (_inputActive ? 1 : 0);
			if ((float)num != _switchPositionState)
			{
				_switchPositionTransitionTime += deltaTime;
				if (!(_switchPositionTransitionTime < modifier.SwitchPositionTransitionDelay))
				{
					float switchPositionTransitionTime = modifier.SwitchPositionTransitionTime;
					float num2 = ((switchPositionTransitionTime <= Mathf.Epsilon) ? 1f : (deltaTime / switchPositionTransitionTime));
					num2 *= (float)(((float)num > _switchPositionState) ? 1 : (-1));
					_switchPositionState = Mathf.Clamp01(_switchPositionState + num2);
					UpdateSwitchPositionImmediately(_switchPositionState);
				}
			}
		}

		private void UpdateVisualStates(float deltaTime)
		{
			bool flag = _input() > 0f;
			if (flag != _inputActive)
			{
				_inputActive = flag;
				OnInputStateChanged();
			}
			UpdateSwitchPositionState(deltaTime);
		}
	}
}
