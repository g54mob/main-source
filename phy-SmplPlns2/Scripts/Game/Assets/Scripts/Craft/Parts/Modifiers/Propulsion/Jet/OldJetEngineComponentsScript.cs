using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public class OldJetEngineComponentsScript : MonoBehaviour, IJetEngineComponents
	{
		[SerializeField]
		private OldEngineComponentScript _afterburner;

		[SerializeField]
		private LoopingAudioScript _afterburnerAudio;

		private AttachPointScript _attachPointFront;

		[SerializeField]
		private LoopingAudioScript _audio;

		[SerializeField]
		private Transform _colliderCore;

		private Transform _componentsRoot;

		[SerializeField]
		private OldEngineComponentScript _coreEnd;

		[SerializeField]
		private OldEngineComponentScript _coreMiddle;

		[SerializeField]
		private Transform _coreRoot;

		[SerializeField]
		private OldEngineComponentScript _coreStart;

		[SerializeField]
		private OldEngineComponentScript _fan;

		[SerializeField]
		private Transform _fanCoreFront;

		[SerializeField]
		private Transform _fanCoreRear;

		private string _fanId;

		[SerializeField]
		private Transform _fanMainFront;

		private float _fanSpeed;

		private string _inletConeId;

		[SerializeField]
		private Transform _inletConeParent;

		private JetEngineScript _jet;

		private float _loopingAudioPitch = 1f;

		private bool _materialDirty;

		[SerializeField]
		private OldEngineComponentScript _nozzle;

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
				_fanCoreFront.Rotate(0f, 0f, num * 0.5f);
				_fanCoreRear.Rotate(0f, 0f, num);
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
			float targetVolume = 0f;
			if (throttle > 0f || active)
			{
				_loopingAudioPitch = Mathf.Lerp(0.5f, 1.25f, throttle);
				targetVolume = Mathf.Lerp(0.2f, 1f, throttle);
			}
			_audio.UpdateLoopAudio(targetVolume, _loopingAudioPitch);
			if (_jet.Data.HasAfterburner)
			{
				targetVolume = 0f;
				if (afterburner > 0f)
				{
					targetVolume = Mathf.Lerp(0.5f, 1f, afterburner);
				}
				_afterburnerAudio.UpdateLoopAudio(targetVolume);
			}
		}

		public void Initialize(JetEngineScript jetEngine, AttachPointScript attachPointFront)
		{
			_jet = jetEngine;
			PartScript = jetEngine.PartScript;
			_componentsRoot = _coreRoot.parent;
			_attachPointFront = attachPointFront;
			UpdateComponents();
			UpdateStyles();
			ConfigureAudio();
		}

		public void UpdateComponents()
		{
			JetEngineData data = _jet.Data;
			_fan.Transform.localPosition = Vector3.zero;
			float fanRadius = data.FanRadius;
			_fan.Transform.localScale = new Vector3(fanRadius, fanRadius, fanRadius);
			_coreRoot.localPosition = new Vector3(0f, _fan.EndPosition.y, 0f);
			float coreRadius = data.CoreRadius;
			_coreRoot.localScale = new Vector3(coreRadius, coreRadius, coreRadius);
			Vector3 zero = Vector3.zero;
			zero = _coreStart.SetStartPosition(zero);
			_coreMiddle.transform.localScale = new Vector3(1f, 1f, data.CompressorLength * 0.5f);
			zero = _coreMiddle.SetStartPosition(zero);
			zero = _coreEnd.SetStartPosition(zero);
			if (data.HasAfterburner && _afterburner != null)
			{
				zero = _afterburner.SetStartPosition(zero);
			}
			float y = (0f - _componentsRoot.InverseTransformPoint(_coreRoot.TransformPoint(zero)).y) / 2f;
			_componentsRoot.localPosition = new Vector3(0f, y, 0f);
			_colliderCore.localScale = new Vector3(_colliderCore.localScale.x, 0f - zero.y, _colliderCore.localScale.z);
			_colliderCore.localPosition = new Vector3(0f, (0f - _colliderCore.localScale.y) / 2f, 0f);
			zero = _nozzle.SetStartPosition(zero);
			if (_afterburner != null)
			{
				_afterburner.gameObject.SetActive(data.HasAfterburner);
			}
			if (_attachPointFront != null)
			{
				_attachPointFront.transform.localPosition = _componentsRoot.localPosition;
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

		private void ConfigureAudio()
		{
			float t = 0.5f * (_jet.Data.CoreRadius - 0.25f);
			float basePitch = Mathf.Lerp(2f, 0.5f, t);
			float baseVolume = Mathf.Lerp(0.5f, 1f, t);
			float distanceScale = Mathf.Lerp(0.25f, 1f, t);
			_audio.Configure(basePitch, baseVolume, distanceScale);
			_audio.LerpRate = 1f;
			if (_afterburnerAudio != null)
			{
				_afterburnerAudio.Configure(basePitch, baseVolume, distanceScale);
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
