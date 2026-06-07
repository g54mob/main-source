using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using ModApi;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class JetEngineComponentsScript : MonoBehaviour
	{
		[SerializeField]
		private EngineComponentScript _afterburner;

		[SerializeField]
		private LoopingAudioScript _afterburnerAudio;

		[SerializeField]
		private Transform _colliderCore;

		private Transform _componentsRoot;

		[SerializeField]
		private EngineComponentScript _coreEnd;

		[SerializeField]
		private EngineComponentScript _coreMiddle;

		[SerializeField]
		private Transform _coreRoot;

		[SerializeField]
		private EngineComponentScript _coreStart;

		[SerializeField]
		private EngineComponentScript _fan;

		[SerializeField]
		private Transform _fanCoreFront;

		[SerializeField]
		private Transform _fanCoreRear;

		[SerializeField]
		private Transform _fanMainFront;

		private float _fanSpeed;

		private FuselageScript _fuselage;

		[SerializeField]
		private Transform _inletConeParent;

		private JetEngineScript _jet;

		[SerializeField]
		private EngineComponentScript _nozzle;

		private GameObject _subPartFan;

		private GameObject _subPartInletCone;

		private GameObject _subPartNozzle;

		private VariableNozzleAnimationScript _variableNozzleScript;

		public LoopingAudioScript AfterburnerAudio => _afterburnerAudio;

		public IPartScript PartScript { get; private set; }

		public void AnimateComponents(bool active, float throttle)
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
				_variableNozzleScript.SetExpansion(throttle);
			}
		}

		public void Initialize(JetEngineScript jetEngine, FuselageScript fuselage)
		{
			_jet = jetEngine;
			PartScript = jetEngine.PartScript;
			_fuselage = fuselage;
			_componentsRoot = _coreRoot.parent;
			UpdateComponents();
			UpdateStyles();
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
			if (data.HasAfterburner)
			{
				zero = _afterburner.SetStartPosition(zero);
			}
			float num = (0f - _componentsRoot.InverseTransformPoint(_coreRoot.TransformPoint(zero)).y) / 2f;
			_componentsRoot.localPosition = new Vector3(0f, num * data.ShroudLength, 0f);
			_fuselage.Data.Offset = new Vector3(0f, num * data.ShroudLength, 0f);
			_fuselage.Data.TopScale = new Vector2(data.FanRadius, data.FanRadius);
			_colliderCore.localScale = new Vector3(_colliderCore.localScale.x, 0f - zero.y, _colliderCore.localScale.z);
			_colliderCore.localPosition = new Vector3(0f, (0f - _colliderCore.localScale.y) / 2f, 0f);
			float num2 = Mathf.LerpUnclamped(data.FanRadius, data.CoreRadius, data.ShroudCurvature);
			_fuselage.Data.BottomScale = new Vector2(num2, num2);
			zero = _nozzle.SetStartPosition(zero);
			if (!Game.InFlightScene)
			{
				_fuselage.UpdateMeshes(updateNormalSmoothing: true);
				if (_fuselage.AttachPointRotate != null)
				{
					Vector3 vector = new Vector3(0f, 0f, 0f);
					vector.z = data.FanRadius;
					vector.y = _fan.EndPosition.y + _componentsRoot.transform.localPosition.y;
					_fuselage.AttachPointRotate.Position = vector;
					if (Game.InDesignerScene)
					{
						_fuselage.AttachPointRotate.AttachPointScript.transform.localPosition = vector;
					}
				}
			}
			_afterburner.gameObject.SetActive(data.HasAfterburner);
		}

		public void UpdateStyles()
		{
			LoadFan(PartScript.Data.Styles[2].Style.Id);
			LoadNozzle(PartScript.Data.Styles[3].Style.Id);
			LoadInletCone(PartScript.Data.Styles[4].Style.Id);
			_variableNozzleScript = base.gameObject.GetComponentInChildren<VariableNozzleAnimationScript>();
		}

		private void DestroySubPart(GameObject subPart)
		{
			if (subPart != null)
			{
				MeshRenderer[] componentsInChildren = subPart.GetComponentsInChildren<MeshRenderer>();
				foreach (MeshRenderer renderer in componentsInChildren)
				{
					PartScript.PartMaterialScript.RemoveRenderer(renderer);
				}
				Object.Destroy(subPart);
				subPart.gameObject.SetActive(value: false);
			}
		}

		private void LoadFan(string fanId)
		{
			DestroySubPart(_subPartFan);
			_subPartFan = LoadSubPart("Craft/Parts/Prefabs/JetEngine/Fan_" + fanId, _fanMainFront);
			_subPartFan.name = fanId;
		}

		private void LoadInletCone(string inletConeId)
		{
			DestroySubPart(_subPartInletCone);
			_subPartInletCone = LoadSubPart("Craft/Parts/Prefabs/JetEngine/InletCone_" + inletConeId, _inletConeParent);
			_subPartInletCone.name = inletConeId;
		}

		private void LoadNozzle(string nozzleId)
		{
			DestroySubPart(_subPartNozzle);
			_subPartNozzle = LoadSubPart("Craft/Parts/Prefabs/JetEngine/Nozzle_" + nozzleId, _nozzle.transform);
			_subPartNozzle.name = nozzleId;
		}

		private GameObject LoadSubPart(string path, Transform parent)
		{
			GameObject gameObject = Object.Instantiate(Resources.Load(path)) as GameObject;
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			gameObject.layer = parent.gameObject.layer;
			gameObject.transform.localPosition = Vector3.zero;
			Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(gameObject, 31);
			MeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer renderer in componentsInChildren)
			{
				PartScript.PartMaterialScript.AddRenderer(renderer, true);
			}
			return gameObject;
		}
	}
}
