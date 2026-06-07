using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Jundroo.ModTools;
using ModApi;
using ModApi.Common.ResourceUtils;
using ModApi.Craft.Parts;
using ModApi.Exceptions;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class RocketEngineComponentsScript : MonoBehaviour
	{
		private static float[] _cornerRadiuses = new float[8] { 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f };

		private static Dictionary<(string Path, ILoadedMod Mod), ResourceData> _gameObjectResourceDataLookup = new Dictionary<(string, ILoadedMod), ResourceData>();

		private EngineActuatorScript[] _actuators;

		[SerializeField]
		private Transform _chamberCollider;

		[SerializeField]
		private Transform _depthMask;

		private Vector3 _endOffset;

		private ExhaustSystemScript _exhaustSystem;

		[SerializeField]
		private Transform _internals;

		[SerializeField]
		private FuselageColliderScript _nozzleCollider;

		private AdaptiveMesh _nozzleMesh;

		private RocketEngineScript _rocket;

		[SerializeField]
		private SmokeTrailScript _smokeTrail;

		private GameObject _subPartAudio;

		private EngineComponentScript _subPartChamber;

		private EngineComponentScript _subPartCycle;

		private EngineComponentScript _subPartExtension;

		private GameObject _subPartGimbals;

		private EngineComponentScript _subPartNozzle;

		public ExhaustSystemScript ExhaustSystem => _exhaustSystem;

		public IPartScript PartScript { get; private set; }

		public SmokeTrailScript SmokeTrail => _smokeTrail;

		public void FlightStart()
		{
			EngineActuatorScript[] actuators = _actuators;
			for (int i = 0; i < actuators.Length; i++)
			{
				actuators[i].transform.SetParent(base.transform, worldPositionStays: true);
			}
		}

		public void Initialize(RocketEngineScript rocketEngine)
		{
			_rocket = rocketEngine;
			PartScript = rocketEngine.PartScript;
			_nozzleCollider.OnFuselageInitialized();
			UpdateComponents();
			UpdateStyles();
		}

		public void UpdateActuators()
		{
			EngineActuatorScript[] actuators = _actuators;
			for (int i = 0; i < actuators.Length; i++)
			{
				actuators[i].UpdateRotations();
			}
		}

		public void UpdateComponents()
		{
			RocketEngineData data = _rocket.Data;
			float size = data.Size;
			_subPartChamber = LoadEngineComponent(_subPartChamber, "Chamber", data.EngineType.PrefabId, data.EngineType.Mod);
			_subPartCycle = LoadEngineComponent(_subPartCycle, "Cycle", data.EngineType.SubPrefabId, data.EngineType.Mod);
			_subPartNozzle = LoadEngineComponent(_subPartNozzle, "Nozzle", data.NozzleType?.PrefabId, data.NozzleType.Mod);
			_subPartExtension = LoadEngineComponent(_subPartExtension, "Extension", data.NozzleType?.ExtensionPrefabId, data.NozzleType.Mod);
			_subPartAudio = LoadSubPart(_subPartAudio, "Audio", (data.EngineSound == "None") ? data.EngineType.AudioId : data.EngineSound, data.EngineType.Mod);
			string text = data.EngineType.GimbalId;
			if (data.GimbalRange * data.EngineType.GimbalRange == 0f)
			{
				text = null;
			}
			if (_subPartGimbals?.name != text)
			{
				_subPartGimbals = LoadSubPart(_subPartGimbals, "Gimbal", text, data.EngineType.Mod);
				_actuators = GetComponentsInChildren<EngineActuatorScript>();
				UpdateActuators();
			}
			else
			{
				_actuators = GetComponentsInChildren<EngineActuatorScript>();
			}
			foreach (AttachPointScript attachPointScript in PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 2f * size;
			}
			_internals.localPosition = Vector3.zero;
			_internals.localScale = new Vector3(size, size, size);
			_endOffset = Vector3.zero;
			_endOffset = _subPartChamber.SetStartPosition(_endOffset);
			_chamberCollider.localScale = new Vector3(2f, _subPartChamber.Length / 2f, 2f);
			_chamberCollider.localPosition = new Vector3(0f, 0f - _chamberCollider.localScale.y, 0f);
			Vector3? vector = null;
			if (_subPartNozzle != null)
			{
				vector = _endOffset;
				_endOffset = _subPartNozzle.SetStartPosition(_endOffset);
			}
			if (_subPartCycle != null)
			{
				_subPartCycle.transform.localPosition = _subPartChamber.transform.localPosition;
			}
			float exitRadius = data.NozzleType.GetExitRadius(data.ExtensionSize);
			float num = data.NozzleType.GetExtensionLength(data.ExtensionSize) / 2f;
			if (_subPartExtension != null)
			{
				if (_subPartExtension.TryGetComponent<MeshDefinitionScript>(out var component))
				{
					MeshFilter component2 = _subPartExtension.GetComponent<MeshFilter>();
					if (_nozzleMesh == null || _nozzleMesh.MeshFilter != component2)
					{
						_nozzleMesh = new AdaptiveMesh(component2, anchorsEnabled: false, tileableTexture: false, useSimpleRadialScaling: true, null);
					}
					float nozzleRadius = data.NozzleType.NozzleRadius;
					_nozzleMesh.Update(component, new Vector2(nozzleRadius, nozzleRadius), new Vector2(exitRadius, exitRadius), _cornerRadiuses, new Vector3(0f, num, 0f), 60f);
					component.transform.localPosition = _endOffset - new Vector3(0f, num - data.NozzleType.ExtensionOverlap, 0f);
					_endOffset -= new Vector3(0f, num * 2f, 0f);
				}
				else
				{
					_subPartExtension.transform.localScale = new Vector3(1f, num, 1f);
					_subPartExtension.transform.localPosition = _endOffset + new Vector3(0f, data.NozzleType.ExtensionOverlap, 0f);
					_endOffset -= new Vector3(0f, num * 2f, 0f);
				}
			}
			else
			{
				_nozzleMesh = null;
			}
			if (vector.HasValue)
			{
				float num2 = exitRadius;
				Vector3 vector2 = new Vector3(0f, num + _subPartNozzle.Length / 2f, 0f);
				_nozzleCollider.AdaptiveMesh.Update(null, Vector3.one, new Vector2(num2, num2), _cornerRadiuses, vector2, 60f);
				_nozzleCollider.transform.localPosition = vector.Value - vector2;
				_nozzleCollider.gameObject.SetActive(value: true);
			}
			else
			{
				_nozzleCollider.gameObject.SetActive(value: false);
			}
			if (data.NozzleType == null)
			{
				return;
			}
			_exhaustSystem = GetComponentInChildren<ExhaustSystemScript>(includeInactive: true);
			if (_exhaustSystem != null)
			{
				ExhaustInfoScript componentInChildren = _subPartNozzle.GetComponentInChildren<ExhaustInfoScript>();
				if (componentInChildren == null)
				{
					_exhaustSystem.transform.localPosition = _endOffset;
					_exhaustSystem.NozzleRadius = data.NozzleType.GetExitRadius(data.ExtensionSize) * data.NozzleType.ExhaustRadiusScale;
				}
				else
				{
					_exhaustSystem.transform.position = componentInChildren.transform.position;
					_exhaustSystem.NozzleRadius = componentInChildren.ThroatRadius;
				}
			}
			_depthMask.localPosition = _exhaustSystem.transform.localPosition + new Vector3(0f, 0.01f, 0f);
			_depthMask.localScale = new Vector3(ExhaustSystem.NozzleRadius * 103f, ExhaustSystem.NozzleRadius * 103f, 1f);
		}

		public void UpdateSmokePosition()
		{
			_smokeTrail.transform.localPosition = _endOffset - new Vector3(0f, _exhaustSystem.ExhaustLength * _exhaustSystem.Intensity * _rocket.Data.SmokeOffset + _rocket.Data.ExhaustOffset, 0f);
		}

		public void UpdateStyles()
		{
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
				UnityEngine.Object.Destroy(subPart);
				subPart.SetActive(value: false);
			}
		}

		private EngineComponentScript LoadEngineComponent(EngineComponentScript engineComponent, string prefabPathPrefix, string id, ILoadedMod mod)
		{
			EngineComponentScript component = null;
			GameObject gameObject = LoadSubPart(engineComponent?.gameObject, prefabPathPrefix, id, mod);
			if (gameObject != null && !gameObject.TryGetComponent<EngineComponentScript>(out component))
			{
				Debug.LogError("Could not get the " + typeof(EngineComponentScript).FullName + " for " + prefabPathPrefix + " component with ID '" + id + "'" + ((mod == null) ? string.Empty : (" from mod '" + mod.ModInfo.Name + "'")) + ".");
				component = gameObject.AddComponent<EngineComponentScript>();
			}
			return component;
		}

		private GameObject LoadGameObject(string path, Transform parent, ILoadedMod mod)
		{
			try
			{
				GameObject gameObject = null;
				if (mod != null)
				{
					gameObject = mod.ResourceLoader.LoadAsset<GameObject>("Assets/Content/Craft/Parts/RocketEngines/" + path + ".prefab");
				}
				if (!_gameObjectResourceDataLookup.TryGetValue((path, mod), out var value))
				{
					value = new ResourceData(path, (gameObject == null) ? null : mod);
					_gameObjectResourceDataLookup[(path, mod)] = value;
				}
				if (gameObject == null)
				{
					gameObject = Game.Instance.ResourceLoader.LoadPrefab("Craft/Parts/Prefabs/RocketEngine/" + path);
				}
				GameObject gameObject2 = UnityEngine.Object.Instantiate(gameObject);
				gameObject2.transform.SetParent(parent, worldPositionStays: false);
				gameObject2.layer = parent.gameObject.layer;
				gameObject2.transform.localPosition = Vector3.zero;
				ResourceDataScript.Add(gameObject2, value);
				Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(gameObject2, 31);
				MeshRenderer[] componentsInChildren = gameObject2.GetComponentsInChildren<MeshRenderer>();
				foreach (MeshRenderer renderer in componentsInChildren)
				{
					PartScript.PartMaterialScript.AddRenderer(renderer, true);
				}
				return gameObject2;
			}
			catch (Exception inner)
			{
				throw new GameException("Failed to load rocket sub part " + path, inner);
			}
		}

		private GameObject LoadSubPart(GameObject existingGameObject, string prefabPathPrefix, string id, ILoadedMod mod)
		{
			if (string.IsNullOrWhiteSpace(id))
			{
				DestroySubPart(existingGameObject);
				return null;
			}
			string text = prefabPathPrefix + "_" + id.Replace(" ", string.Empty);
			if (existingGameObject?.name == text && _gameObjectResourceDataLookup.TryGetValue((text, mod), out var value))
			{
				ResourceDataScript component = existingGameObject.GetComponent<ResourceDataScript>();
				if (component != null && component.Data == value)
				{
					return existingGameObject;
				}
			}
			DestroySubPart(existingGameObject);
			GameObject obj = LoadGameObject(text, _internals, mod);
			obj.name = text;
			return obj;
		}
	}
}
