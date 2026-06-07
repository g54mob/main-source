using Assets.Scripts.Audio;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class JetEngineComponentsScript : MonoBehaviour, IJetEngineComponents
	{
		[SerializeField]
		private JetEngineComponentScript _afterburner;

		private AttachPointScript _attachPointFront;

		[SerializeField]
		private AudioSource _audioFanBuzz;

		[SerializeField]
		private AudioSource _audioFanHigh;

		[SerializeField]
		private AudioSource _audioFanLow;

		[SerializeField]
		private AudioSource _audioNozzleBurner;

		[SerializeField]
		private AudioSource _audioNozzleWind;

		[SerializeField]
		private LPFbyDistance _audioNozzleWindLPFDriver;

		[SerializeField]
		private float _audioNozzleWindPitch = 1f;

		[SerializeField]
		private Transform _colliderCore;

		private Transform _componentsRoot;

		[SerializeField]
		private JetEngineComponentScript _coreEnd;

		[SerializeField]
		private JetEngineComponentScript _coreMiddle;

		[SerializeField]
		private Transform _coreRoot;

		[SerializeField]
		private JetEngineComponentScript _coreStart;

		[SerializeField]
		private Transform _fan;

		[SerializeField]
		private Transform _fanCoreFront;

		[SerializeField]
		private Transform _fanCoreRear;

		private string _fanId;

		[SerializeField]
		private Transform _fanMainFront;

		[SerializeField]
		private MeshRenderer _fanShroud;

		private float _fanSpeed;

		private string _inletConeId;

		[SerializeField]
		private Transform _inletConeParent;

		private JetEngineScript _jet;

		private bool _materialDirty;

		[SerializeField]
		private Transform _nozzle;

		private string _nozzleId;

		private GameObject _subPartFan;

		private GameObject _subPartInletCone;

		private GameObject _subPartNozzle;

		private VariableNozzleAnimationScript _variableNozzleScript;

		public Vector3 DesignerCenterOfThrust => _subPartNozzle.transform.position;

		public PartScript PartScript { get; private set; }

		public void AnimateComponents(bool active, float throttle, float afterburner)
		{
			float b = 0f;
			if (active)
			{
				b = 0.25f + throttle;
			}
			_fanSpeed = Mathf.Lerp(_fanSpeed, b, Time.deltaTime * 0.5f);
			if (_fanSpeed > 0f)
			{
				float num = (0f - _fanSpeed) * 360f * 3f * Time.deltaTime;
				_fanMainFront.Rotate(0f, 0f, num);
				if (_fanCoreFront != null)
				{
					_fanCoreFront.Rotate(0f, 0f, num * 0.5f);
				}
				if (_fanCoreRear != null)
				{
					_fanCoreRear.Rotate(0f, 0f, num);
				}
			}
			if (_variableNozzleScript != null)
			{
				float expansion = Mathf.Lerp(1f, 0f, throttle);
				if (afterburner > 0.05f)
				{
					expansion = 1f;
				}
				_variableNozzleScript.SetExpansion(expansion);
			}
			float num2 = 1f;
			if (_audioNozzleWindLPFDriver != null)
			{
				bool flag = _jet.Data.HasReverseThrust && _jet.BrakeValue > 0.01f;
				num2 = Mathf.Lerp(0.5f, 1f, (float)(flag ? 1 : (-1)) * Vector3.Dot(_audioNozzleWindLPFDriver.Distance.normalized, base.transform.forward));
			}
			_audioNozzleWind.volume = ((active ? 0.4f : Mathf.Min(0.4f, _fanSpeed)) + 0.6f * Mathf.Sqrt(throttle)) * num2;
			_audioNozzleWind.pitch = 0.5f + _audioNozzleWindPitch * throttle * (float)_jet.Data.MathParams.Output.ExitVelocityCore / 300f;
			float num3 = throttle * throttle * (3f - 2f * throttle);
			_audioFanLow.volume = Mathf.Sqrt(1f - num3);
			_audioFanHigh.volume = Mathf.Sqrt(num3);
			AudioSource audioFanHigh = _audioFanHigh;
			float pitch = (_audioFanLow.pitch = _fanSpeed / _jet.Data.FanRadius);
			audioFanHigh.pitch = pitch;
			if (_audioFanBuzz != null && _jet.Data.FanRadius > 0.4f && (throttle > 0.75f || _audioFanBuzz.volume != 0f))
			{
				float num5 = Mathf.Max(0f, 4f * throttle - 3f);
				num5 *= num5 * (3f - 2f * num5);
				_audioFanBuzz.volume = num5 * Mathf.Max(0f, _jet.Data.FanRadius - 0.3f);
			}
			if (_audioNozzleBurner != null && (afterburner > 0f || _audioNozzleBurner.volume != 0f))
			{
				_audioNozzleBurner.volume = ((afterburner == 0f) ? 0f : (0.3f + Mathf.Sqrt(0.7f * afterburner)));
				_audioNozzleBurner.pitch = 0.75f * afterburner / _jet.Data.CoreRadius;
			}
		}

		public void Initialize(JetEngineScript jetEngine, AttachPointScript attachPointFront)
		{
			_jet = jetEngine;
			PartScript = jetEngine.PartScript;
			_componentsRoot = _coreRoot.parent;
			_attachPointFront = attachPointFront;
			UpdateStyles();
			UpdateComponents();
		}

		public void UpdateComponents()
		{
			JetEngineData data = _jet.Data;
			_ = _fanShroud != null;
			_fan.localPosition = Vector3.zero;
			float fanRadius = data.FanRadius;
			_fan.localScale = new Vector3(fanRadius, fanRadius, fanRadius);
			_coreRoot.localPosition = Vector3.zero;
			float coreVisualRadius = data.CoreVisualRadius;
			float num = (data.NozzlePrefab.supportsAfterburner ? fanRadius : coreVisualRadius);
			_coreRoot.localScale = new Vector3(num, num, coreVisualRadius);
			Vector3 zero = Vector3.zero;
			zero = _coreStart.SetStartPosition(zero);
			_coreMiddle.transform.localScale = new Vector3(1f, 1f, data.CompressorLength * 0.5f);
			zero = _coreMiddle.SetStartPosition(zero);
			zero = _coreEnd.SetStartPosition(zero);
			if (data.HasAfterburner && _afterburner != null)
			{
				zero = _afterburner.SetStartPosition(zero);
			}
			_colliderCore.localScale = new Vector3(_colliderCore.localScale.x, _colliderCore.localScale.y, 0f - zero.z);
			_colliderCore.localPosition = new Vector3(0f, 0f, (0f - _colliderCore.localScale.z) / 2f);
			_nozzle.localPosition = zero;
			VariableNozzleAnimationScript componentInChildren = _nozzle.GetComponentInChildren<VariableNozzleAnimationScript>(includeInactive: true);
			if (componentInChildren != null)
			{
				if (_jet.PartScript.Part.LoadContext == CraftLoadContext.Designer)
				{
					componentInChildren.SetExpansion(1f, animate: false);
				}
				componentInChildren.SetLengthScale(_jet.Data.NozzleLength);
			}
			if (PartScript.LoadContext == CraftLoadContext.Flight)
			{
				float num2 = 0.5f * Mathf.Sqrt(data.CalculateThrustAtSeaLevel());
				_audioNozzleWind.minDistance = num2;
				_audioNozzleWind.maxDistance = num2 * 10f;
				if (_audioNozzleBurner != null)
				{
					_audioNozzleBurner.minDistance = num2;
					_audioNozzleBurner.maxDistance = num2 * 15f;
				}
				num2 *= data.FanRadius;
				AudioSource audioFanHigh = _audioFanHigh;
				float minDistance = (_audioFanLow.minDistance = num2);
				audioFanHigh.minDistance = minDistance;
				AudioSource audioFanHigh2 = _audioFanHigh;
				minDistance = (_audioFanLow.maxDistance = num2 * 10f);
				audioFanHigh2.maxDistance = minDistance;
				if (_audioFanBuzz != null)
				{
					_audioFanBuzz.minDistance = num2;
					_audioFanBuzz.maxDistance = num2 * 10f;
					_audioFanBuzz.pitch = 0.6f + 0.3f / data.FanRadius;
				}
			}
			if (_afterburner != null)
			{
				_afterburner.gameObject.SetActive(data.HasAfterburner);
			}
		}

		public void UpdateStyles()
		{
			LoadFan(_jet.Data.FanPrefab);
			LoadNozzle(_jet.Data.NozzlePrefab);
			LoadInletCone(_jet.Data.InletConePrefab);
			_variableNozzleScript = base.gameObject.GetComponentInChildren<VariableNozzleAnimationScript>();
			if (_materialDirty)
			{
				_materialDirty = false;
				PartScript.PartMaterialScript.InitializeMaterial();
			}
		}

		private void DestroySubPart(GameObject subPart)
		{
			if (subPart != null)
			{
				MeshRenderer[] componentsInChildren = subPart.GetComponentsInChildren<MeshRenderer>();
				foreach (MeshRenderer renderer in componentsInChildren)
				{
					PartScript.PartMaterialScript.RemoveRenderer(renderer, destroy: true);
				}
				Object.DestroyImmediate(subPart);
			}
		}

		private void LoadFan(JetEnginePrefabs.FanPrefab fanPrefab)
		{
			if (_fanId != fanPrefab.Id)
			{
				_fanId = fanPrefab.Id;
				DestroySubPart(_subPartFan);
				_subPartFan = LoadSubPart(fanPrefab.prefab, _fanMainFront);
				_subPartFan.name = fanPrefab.name;
			}
		}

		private void LoadInletCone(JetEnginePrefabs.InletConePrefab inletConePrefab)
		{
			if (_inletConeId != inletConePrefab.Id)
			{
				_inletConeId = inletConePrefab.Id;
				DestroySubPart(_subPartInletCone);
				_subPartInletCone = LoadSubPart(inletConePrefab.prefab, _inletConeParent);
				_subPartInletCone.name = inletConePrefab.name;
			}
		}

		private void LoadNozzle(JetEnginePrefabs.NozzlePrefab nozzlePrefab)
		{
			if (_nozzleId != nozzlePrefab.Id)
			{
				_nozzleId = nozzlePrefab.Id;
				DestroySubPart(_subPartNozzle);
				_subPartNozzle = LoadSubPart(nozzlePrefab.prefab, _nozzle.transform);
				_subPartNozzle.name = nozzlePrefab.name;
				ExhaustSystemScript componentInChildren = _subPartNozzle.GetComponentInChildren<ExhaustSystemScript>(includeInactive: true);
				if (componentInChildren != null)
				{
					componentInChildren.Color = _jet.Data.AfterburnerBaseColor;
					componentInChildren.ColorFlame = _jet.Data.AfterburnerBaseColor;
					componentInChildren.ColorTip = _jet.Data.AfterburnerTipColor;
					componentInChildren.SetUp();
				}
			}
		}

		private GameObject LoadSubPart(GameObject prefab, Transform parent)
		{
			_materialDirty = true;
			GameObject gameObject = Object.Instantiate(prefab, parent);
			gameObject.layer = parent.gameObject.layer;
			gameObject.transform.localPosition = Vector3.zero;
			MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer renderer in componentsInChildren)
			{
				PartScript.PartMaterialScript.AddRenderer(renderer, excludeFromCombine: true);
			}
			return gameObject;
		}
	}
}
