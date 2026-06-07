using System;
using Assets.Scripts.Flight;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class LightScript : PartModifierScript
	{
		private bool _active;

		private bool _blinkProgramLightOn;

		private int _blinkProgramStep;

		private float _blinkProgramStepDuration;

		private Transform _cameraTransform;

		private MeshRenderer _haloRenderer;

		private Transform _haloTransform;

		private Func<float> _inputAxis;

		private Color _lightColor;

		private float _lightTime;

		private GameObject _litMeshGameObject;

		private MeshRenderer _litMeshRenderer;

		private GameObject _unlitMeshGameObject;

		public bool Active
		{
			get
			{
				return _active;
			}
			set
			{
				if (_active != value)
				{
					_active = value;
					_litMeshGameObject.SetActive(_active);
					_haloTransform.gameObject.SetActive(_active && BeaconLight.ShowHalo);
					_unlitMeshGameObject.SetActive(!_active);
				}
			}
		}

		public BeaconLightData BeaconLight { get; set; }

		public bool IsDamaged { get; protected set; }

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void Initialize(BeaconLightData light)
		{
			BeaconLight = light;
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light)
			{
				IsDamaged = true;
				Active = false;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightDefault);
		}

		private Color GetLightColorFromPartMaterial()
		{
			int materialId = base.PartScript.Part.MaterialIds[0];
			return base.PartScript.Aircraft.Theme.Theme.GetMaterial(materialId).PrimaryColor;
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("Halo", base.PartScript.gameObject);
			_haloTransform = gameObject.transform;
			_litMeshGameObject = Utilities.FindFirstGameObjectMyselfOrChildren("LitMesh", base.PartScript.gameObject);
			_unlitMeshGameObject = Utilities.FindFirstGameObjectMyselfOrChildren("UnlitMesh", base.PartScript.gameObject);
			if (loadContext == CraftLoadContext.Flight)
			{
				_cameraTransform = FlightSceneScript.Instance.CameraScript.transform;
				_litMeshRenderer = _litMeshGameObject.GetComponent<MeshRenderer>();
				Color lightColorFromPartMaterial = GetLightColorFromPartMaterial();
				_haloRenderer = gameObject.GetComponent<MeshRenderer>();
				SetLightColor(lightColorFromPartMaterial);
				if (BeaconLight.Input != "None")
				{
					_inputAxis = base.PartScript.Aircraft.Controls.GetAxisGetter(BeaconLight.Input, 0f, base.PartScript);
				}
				else
				{
					_inputAxis = null;
				}
				_blinkProgramStep = 0;
				_blinkProgramLightOn = true;
				_blinkProgramStepDuration = BeaconLight.GetDurationForBlinkProgramStep(_blinkProgramStep);
			}
			gameObject.SetActive(value: false);
			_litMeshGameObject.SetActive(value: false);
			_unlitMeshGameObject.SetActive(value: true);
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (IsDamaged)
			{
				return;
			}
			bool flag = BeaconLight.ActivationGroup == 0 || base.Controls.GetActivationState(BeaconLight.ActivationGroup);
			if (_inputAxis != null)
			{
				flag = flag && _inputAxis() != 0f;
			}
			if (flag)
			{
				_lightTime += frame.DeltaTime;
				if (_lightTime >= _blinkProgramStepDuration)
				{
					_lightTime = 0f;
					_blinkProgramLightOn = !_blinkProgramLightOn;
					_blinkProgramStep++;
					_blinkProgramStepDuration = BeaconLight.GetDurationForBlinkProgramStep(_blinkProgramStep);
				}
			}
			Active = flag && _blinkProgramLightOn;
			if (Active && BeaconLight.ShowHalo)
			{
				float magnitude = (base.transform.position - _cameraTransform.position).magnitude;
				float value = magnitude / 250f;
				value = Mathf.Clamp(value, 1f, 10f);
				_haloTransform.localScale = new Vector3(value, value, value);
				_haloTransform.LookAt(_cameraTransform.position, _cameraTransform.up);
				float num = Mathf.Clamp(magnitude, 10f, 150f);
				_haloRenderer.material.SetColor("_TintColor", new Color(_lightColor.r, _lightColor.g, _lightColor.b, num / 255f));
			}
		}

		private void SetLightColor(Color lightColor)
		{
			_lightColor = lightColor;
			_haloRenderer.material.SetColor("_TintColor", new Color(lightColor.r, lightColor.g, lightColor.b, 0.11764706f));
			_litMeshRenderer.material.color = lightColor;
		}
	}
}
