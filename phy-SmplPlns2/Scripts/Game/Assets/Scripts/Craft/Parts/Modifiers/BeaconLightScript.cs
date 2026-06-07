using System;
using Assets.Scripts.Flight;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class BeaconLightScript : PartModifierScript
	{
		private bool _active;

		private bool _blinkProgramLightOn;

		private int _blinkProgramStep;

		private float _blinkProgramStepDuration;

		private Transform _cameraTransform;

		private Func<bool> _inputAxis;

		private Color _lightColor;

		private float _lightTime;

		private Material _litMaterial;

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

		protected virtual void OnDestroy()
		{
			if (_litMaterial != null)
			{
				UnityEngine.Object.Destroy(_litMaterial);
				_litMaterial = null;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterLateUpdate(OnLateUpdate, CraftUpdateFlags.FlightDefault);
		}

		private Color GetLightColorFromPartMaterial()
		{
			int materialId = base.PartScript.Part.MaterialIds[0];
			return base.PartScript.Aircraft.Theme.Theme.GetMaterial(materialId).PrimaryColor;
		}

		private void OnLateUpdate(in CraftUpdateFrameData frame)
		{
			if (IsDamaged)
			{
				return;
			}
			bool flag = BeaconLight.ActivationGroup == 0 || base.Controls.GetActivationState(BeaconLight.ActivationGroup);
			if (_inputAxis != null)
			{
				flag = flag && _inputAxis();
			}
			if (flag)
			{
				_lightTime += Time.deltaTime;
				if (_lightTime >= _blinkProgramStepDuration)
				{
					_lightTime = 0f;
					_blinkProgramLightOn = !_blinkProgramLightOn;
					_blinkProgramStep++;
					_blinkProgramStepDuration = BeaconLight.GetDurationForBlinkProgramStep(_blinkProgramStep);
				}
			}
			Active = flag && _blinkProgramLightOn;
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_litMeshGameObject = Utilities.FindFirstGameObjectMyselfOrChildren("LitMesh", base.PartScript.gameObject);
			_unlitMeshGameObject = Utilities.FindFirstGameObjectMyselfOrChildren("UnlitMesh", base.PartScript.gameObject);
			if (loadContext == CraftLoadContext.Flight)
			{
				_cameraTransform = FlightSceneScript.Instance.CameraScript.transform;
				_litMeshRenderer = _litMeshGameObject.GetComponent<MeshRenderer>();
				Color lightColorFromPartMaterial = GetLightColorFromPartMaterial();
				SetLightColor(lightColorFromPartMaterial);
				if (BeaconLight.Input != "None")
				{
					_inputAxis = base.PartScript.Aircraft.Controls.GetBoolGetter(BeaconLight.Input, base.PartScript);
				}
				else
				{
					_inputAxis = null;
				}
				_blinkProgramStep = 0;
				_blinkProgramLightOn = true;
				_blinkProgramStepDuration = BeaconLight.GetDurationForBlinkProgramStep(_blinkProgramStep);
			}
			_litMeshGameObject.SetActive(value: false);
			_unlitMeshGameObject.SetActive(value: true);
			return UniTask.CompletedTask;
		}

		private void SetLightColor(Color lightColor)
		{
			_lightColor = lightColor;
			if ((object)_litMaterial == null)
			{
				_litMaterial = _litMeshRenderer.material;
			}
			_litMaterial.SetFloat("_Emission", BeaconLight.Intensity);
			_litMaterial.SetColor("_MainColor", lightColor);
		}
	}
}
