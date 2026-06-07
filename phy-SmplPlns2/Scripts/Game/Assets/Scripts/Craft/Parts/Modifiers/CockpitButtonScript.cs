using System;
using System.Collections.Generic;
using Assets.Scripts.Audio;
using Assets.Scripts.Craft.Parts.Modifiers.Variables;
using Assets.Scripts.Craft.Parts.Modifiers.XR;
using Assets.Scripts.Design;
using Assets.Scripts.Input;
using Assets.Scripts.Input.Events;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Settings;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CockpitButtonScript : PartModifierScript, IInteractablePartModifier, IVariableDeclarations, IVariableOutput
	{
		private enum AudioClipIndex
		{
			SwitchOn_Press = 0,
			SwitchOn_Release = 1,
			SwitchOff_Press = 2,
			SwitchOff_Release = 3
		}

		private class ButtonComponent
		{
			public BoxCollider Collider;

			public Vector3 DefaultScale;

			public GameObject GameObject;

			public MeshRenderer MeshRenderer;

			public PartMaterialScript.RendererMaterialMap RendererMaterialMap;

			public Transform Transform;
		}

		private AudioRandomiser _audio;

		private bool _buttonActivatedStateChanged;

		private ButtonComponent _buttonComponentBase = new ButtonComponent();

		private ButtonComponent _buttonComponentMain = new ButtonComponent();

		private float _buttonLightState;

		private float _buttonLightTransitionTime;

		private float _buttonPositionState;

		private float _buttonPositionTransitionTime;

		private Func<float> _input;

		private bool _inputActive;

		private CockpitButtonInteractableCollider _interactableCollider;

		private LabelScript _label;

		private AircraftControls.InputOverride _output;

		private float _outputValueActive;

		private float _outputValueInactive;

		private AircraftVariable _outputVariable;

		private int _outputVariablePriority;

		private bool _targetStateOnRelease;

		public bool InteractionDisabled => false;

		public bool IsButtonActivated { get; private set; }

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

		public CockpitButtonData Modifier { get; private set; }

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
				return new PartTooltipPosition(_buttonComponentMain.MeshRenderer);
			}
			return default(PartTooltipPosition);
		}

		IEnumerator<string> IVariableDeclarations.GetVariableOutputs()
		{
			string inputId = Modifier.Input.InputId;
			if (!string.IsNullOrWhiteSpace(inputId) && GameInputs.Instance.FindById(inputId) == null)
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
				_buttonActivatedStateChanged = IsButtonActivated != _targetStateOnRelease;
				IsButtonActivated = _targetStateOnRelease;
				if (!_buttonActivatedStateChanged)
				{
					_audio.Play(1, randomise: false);
				}
			}
			else if (e.InputState == InputState.Begin)
			{
				_targetStateOnRelease = Modifier.ButtonInteractionType == CockpitButtonData.InteractionType.Toggle && !IsButtonActivated;
				_buttonActivatedStateChanged = !IsButtonActivated;
				IsButtonActivated = true;
				if (!_buttonActivatedStateChanged)
				{
					_audio.Play(2, randomise: false);
				}
			}
			return isPartStillTarget;
		}

		public void Initialize(CockpitButtonData modifier)
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
			CockpitButtonData modifier = Modifier;
			_buttonComponentBase.GameObject.SetActive(modifier.Padding != 0f && modifier.DepthBase != 0f);
			float y = _buttonComponentBase.DefaultScale.y;
			float y2 = _buttonComponentMain.DefaultScale.y;
			float num = modifier.DepthBase / y;
			float y3 = num + modifier.DepthOff / y2;
			float num2 = modifier.Padding / 2f;
			_buttonComponentBase.Transform.localScale = new Vector3(modifier.Width, num, modifier.Height) / 1000f;
			_buttonComponentMain.Transform.localScale = new Vector3(modifier.Width - num2, y3, modifier.Height - num2) / 1000f;
			UpdateComponentPosition(_buttonComponentBase);
			UpdateComponentPosition(_buttonComponentMain);
			UpdateLabelPosition();
			UpdateBaseCollider();
		}

		public void OnStyleChanged(CockpitButtonData.CockpitButtonStyle style)
		{
			LoadComponent(_buttonComponentBase, "Base", style);
			LoadComponent(_buttonComponentMain, "Main", style);
			_interactableCollider = _buttonComponentMain.GameObject.GetComponentInChildren<CockpitButtonInteractableCollider>();
			OnSizeChanged();
			base.PartScript.PartMaterialScript.InitializeMaterial();
		}

		void IVariableOutput.UpdateOutputs()
		{
			if (_outputVariable != null && Modifier.ButtonInteractionType == CockpitButtonData.InteractionType.Continuous && IsButtonActivated)
			{
				_outputVariable.SetValue(_outputValueActive, _outputVariablePriority);
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStartDesigner, CraftUpdateFlags.DesignerDefault);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightLocal);
		}

		private void LoadComponent(ButtonComponent component, string type, CockpitButtonData.CockpitButtonStyle style)
		{
			UnloadComponent(component);
			GameObject gameObject = Resources.Load<GameObject>($"Craft/Parts/CockpitButton/CockpitButton_{type}_{style}");
			if (gameObject != null)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject);
				MeshRenderer component2 = gameObject2.GetComponent<MeshRenderer>();
				BoxCollider component3 = gameObject2.GetComponent<BoxCollider>();
				gameObject2.transform.SetParent(base.transform, worldPositionStays: false);
				PartMaterialScript.RendererMaterialMap rendererMaterialMap = base.PartScript.PartMaterialScript.AddRenderer(component2);
				component.GameObject = gameObject2;
				component.Transform = gameObject2.transform;
				component.Collider = component3;
				component.MeshRenderer = component2;
				component.RendererMaterialMap = rendererMaterialMap;
				component.DefaultScale = ((style == CockpitButtonData.CockpitButtonStyle.Circular) ? new Vector3(1f, 2f, 1f) : Vector3.one);
			}
		}

		private void OnInputStateChanged()
		{
			_buttonLightTransitionTime = 0f;
			_buttonPositionTransitionTime = 0f;
			IsButtonActivated = _inputActive;
			_audio.Play((!IsButtonActivated) ? 3 : 0, IsButtonActivated);
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_label = base.PartScript.GetModifier<LabelScript>();
			UpdateLabelPosition();
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				CockpitButtonData.CockpitButtonInput input = Modifier.Input;
				string text = input.InputId;
				NumericSetting<float> interactablePartColliderScale = Game.Instance.Settings.Gameplay.General.InteractablePartColliderScale;
				_buttonComponentMain.Collider.size *= (float)interactablePartColliderScale;
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
						Debug.LogWarning("Button input '" + text + "': " + ex.Message);
					}
				}
				if (text == Game.Inputs.LandingGear.Id)
				{
					text = "-" + text;
					_outputValueInactive = 0f;
				}
				if (input.DefaultInteractionType == CockpitButtonData.InteractionType.Toggle && Modifier.ButtonInteractionType == CockpitButtonData.InteractionType.Toggle)
				{
					_input = base.PartScript.Aircraft.Controls.GetAxisGetter(text, -1f, null, returnNull: true);
				}
				else if (_outputVariable != null && Modifier.ButtonInteractionType == CockpitButtonData.InteractionType.Toggle)
				{
					AircraftVariable v = _outputVariable;
					_input = () => v.Value;
				}
				if (_input == null)
				{
					_input = () => IsButtonActivated ? 1 : (-1);
				}
				AudioSource source = base.gameObject.AddComponent<AudioSource>();
				AudioStore.SetupAudioSource(source, AudioStore.KnobAudio, null, loop: false);
				_audio = new AudioRandomiser(4, source);
				for (int num2 = 1; num2 <= 3; num2++)
				{
					_audio.AddFiles($"Sound/Button/Button_ON_IN_{num2}", $"Sound/Button/Button_ON_OUT_{num2}", $"Sound/Button/Button_OFF_IN_{num2}", $"Sound/Button/Button_OFF_OUT_{num2}");
				}
			}
			return UniTask.CompletedTask;
		}

		private UniTask OnPreStartLayerUpdates(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_buttonComponentMain.GameObject.layer = 16;
			return UniTask.CompletedTask;
		}

		private void OnStartDesigner(in CraftUpdateFrameData frame)
		{
			base.PartScript.EditorColliders.RemoveAll((EditorCollider x) => x.Collider == _buttonComponentMain.Collider || x.Collider == _buttonComponentBase.Collider);
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			UpdateVisualStates(Time.deltaTime);
			CockpitButtonData.InteractionType buttonInteractionType = Modifier.ButtonInteractionType;
			if (_outputVariable != null)
			{
				switch (buttonInteractionType)
				{
				case CockpitButtonData.InteractionType.Toggle:
					if (_buttonActivatedStateChanged)
					{
						_outputVariable.SetValue((!_inputActive) ? _outputValueActive : _outputValueInactive, _outputVariablePriority);
					}
					break;
				case CockpitButtonData.InteractionType.Once:
					if (_buttonActivatedStateChanged && IsButtonActivated)
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
				case CockpitButtonData.InteractionType.Toggle:
					switch (buttonInteractionType)
					{
					case CockpitButtonData.InteractionType.Toggle:
						_output.Active = _buttonActivatedStateChanged;
						break;
					case CockpitButtonData.InteractionType.Once:
						_output.Active = IsButtonActivated && _buttonActivatedStateChanged;
						break;
					default:
						_output.Active = _buttonActivatedStateChanged;
						break;
					}
					break;
				case CockpitButtonData.InteractionType.Once:
					switch (buttonInteractionType)
					{
					case CockpitButtonData.InteractionType.Toggle:
						_output.Active = IsButtonActivated && _buttonActivatedStateChanged;
						break;
					case CockpitButtonData.InteractionType.Once:
						_output.Active = IsButtonActivated && _buttonActivatedStateChanged;
						break;
					default:
						_output.Active = IsButtonActivated && _buttonActivatedStateChanged;
						break;
					}
					break;
				default:
					switch (buttonInteractionType)
					{
					case CockpitButtonData.InteractionType.Toggle:
						_output.Active = IsButtonActivated;
						break;
					case CockpitButtonData.InteractionType.Once:
						_output.Active = IsButtonActivated && _buttonActivatedStateChanged;
						break;
					default:
						_output.Active = IsButtonActivated;
						break;
					}
					break;
				}
				_output.Value = (IsButtonActivated ? _outputValueActive : _outputValueInactive);
			}
			_buttonActivatedStateChanged = false;
		}

		private void UnloadComponent(ButtonComponent component)
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
				component.RendererMaterialMap = null;
				component.DefaultScale = Vector3.zero;
			}
		}

		private void UpdateBaseCollider()
		{
			BoxCollider component = GetComponent<BoxCollider>();
			BoxCollider boxCollider = _buttonComponentBase?.Collider;
			if (!(boxCollider != null))
			{
				return;
			}
			boxCollider.enabled = false;
			component.center = base.transform.InverseTransformPoint(boxCollider.transform.TransformPoint(boxCollider.center));
			Vector3 size = base.transform.InverseTransformVector(boxCollider.transform.TransformVector(boxCollider.size));
			if (size.y < 0f)
			{
				size.y = 0f;
			}
			component.size = size;
			foreach (EditorCollider editorCollider in base.PartScript.EditorColliders)
			{
				if (editorCollider.Collider == component)
				{
					editorCollider.Update();
				}
			}
		}

		private void UpdateButtonLightState(float deltaTime)
		{
			float lightStrength = Modifier.LightStrength;
			if (lightStrength <= 0f)
			{
				return;
			}
			int num = (_inputActive ? 1 : 0);
			if ((float)num == _buttonLightState)
			{
				return;
			}
			_buttonLightTransitionTime += deltaTime;
			if (!(_buttonLightTransitionTime < Modifier.ButtonLightTransitionDelay))
			{
				float buttonLightTransitionTime = Modifier.ButtonLightTransitionTime;
				float num2 = ((buttonLightTransitionTime <= Mathf.Epsilon) ? 1f : (deltaTime / buttonLightTransitionTime));
				num2 *= (float)(((float)num > _buttonLightState) ? 1 : (-1));
				_buttonLightState = Mathf.Clamp01(_buttonLightState + num2);
				PartMaterialScript.RendererMaterialMap rendererMaterialMap = _buttonComponentMain?.RendererMaterialMap;
				if (rendererMaterialMap != null)
				{
					rendererMaterialMap.EmissiveOverride = ((_buttonLightState == 0f) ? ((float?)null) : new float?(_buttonLightState * lightStrength));
				}
			}
		}

		private void UpdateButtonPositionState(float deltaTime)
		{
			CockpitButtonData modifier = Modifier;
			bool flag = false;
			if (_buttonPositionState < _interactableCollider.ButtonPressAmount)
			{
				_buttonPositionState = _interactableCollider.ButtonPressAmount;
				flag = true;
			}
			else
			{
				int num = (_inputActive ? 1 : 0);
				if ((float)num != _buttonPositionState)
				{
					_buttonPositionTransitionTime += deltaTime;
					if (_buttonPositionTransitionTime >= modifier.ButtonPositionTransitionDelay)
					{
						float buttonPositionTransitionTime = modifier.ButtonPositionTransitionTime;
						float num2 = ((buttonPositionTransitionTime <= Mathf.Epsilon) ? 1f : (deltaTime / buttonPositionTransitionTime));
						num2 *= (float)(((float)num > _buttonPositionState) ? 1 : (-1));
						_buttonPositionState = Mathf.Clamp01(_buttonPositionState + num2);
						flag = true;
					}
				}
			}
			if (_interactableCollider.ButtonPressAmount > _buttonPositionState || flag)
			{
				float y = _buttonComponentBase.Transform.localScale.y;
				float num3 = Mathf.Lerp(modifier.DepthOff, modifier.DepthOn, _buttonPositionState) / 1000f / _buttonComponentMain.DefaultScale.y;
				Vector3 localScale = _buttonComponentMain.Transform.localScale;
				_buttonComponentMain.Transform.localScale = new Vector3(localScale.x, y + num3, localScale.z);
				UpdateComponentPosition(_buttonComponentMain);
				UpdateLabelPosition();
			}
		}

		private void UpdateComponentPosition(ButtonComponent component)
		{
			Vector3 localPosition = component.Transform.localPosition;
			Vector3 localScale = component.Transform.localScale;
			component.Transform.localPosition = new Vector3(localPosition.x, localScale.y * (component.DefaultScale.y / 2f), localPosition.z);
		}

		private void UpdateLabelPosition()
		{
			if (_label != null)
			{
				_label.transform.position = _buttonComponentMain.Transform.TransformPoint(new Vector3(0f, _buttonComponentMain.DefaultScale.y * 0.52f, 0f));
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
			UpdateButtonLightState(deltaTime);
			UpdateButtonPositionState(deltaTime);
		}
	}
}
