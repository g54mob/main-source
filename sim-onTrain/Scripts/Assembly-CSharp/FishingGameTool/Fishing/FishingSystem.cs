using System;
using System.Collections;
using System.Collections.Generic;
using FishingGameTool.CustomAttribute;
using FishingGameTool.Fishing.BaitData;
using FishingGameTool.Fishing.CatchProbability;
using FishingGameTool.Fishing.Float;
using FishingGameTool.Fishing.Line;
using FishingGameTool.Fishing.LootData;
using FishingGameTool.Fishing.Rod;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace FishingGameTool.Fishing
{
	[AddComponentMenu("Fishing Game Tool/Fishing System")]
	public class FishingSystem : MonoBehaviour
	{
		[Serializable]
		public class LootCatchEvent
		{
			[InfoBox("This UnityEvent passes a prefab from LootData as an argument of type GameObject.")]
			[InfoBox("This feature is under development. In version 1.0, it does not work.")]
			public int _invokeCalls = 1;

			public UnityEvent _event;
		}

		[Serializable]
		public class AdvancedSettings
		{
			[ReadOnlyField]
			public FishingLootData _caughtLootData;

			[InfoBox("Custom Catch Probability Data.")]
			public CatchProbabilityData _catchProbabilityData;

			public bool _caughtLoot;

			public float _returnSpeedWithoutLoot = 3f;

			[InfoBox("The time interval in seconds between consecutive checks to determine if the catch has been successfully caught.")]
			public float _catchCheckInterval = 1f;

			[ReadOnlyField]
			public float _lootWeight;
		}

		[BetterHeader("Fishing Settings", 20)]
		[Space]
		public FishingRod _fishingRod;

		[InfoBox("LayerMask used to determine on which layer fishing is allowed.")]
		public LayerMask _fishingLayer;

		public FishingBaitData _bait;

		private FishingBaitData _baitForever;

		[Space]
		[BetterHeader("Loot Settings", 20)]
		[InfoBox("Select the method of handling loot catching:\n\n- \"SpawnItem\": Creates a game object upon successfully catching the loot.\n- \"InvokeEvent\": Triggers a designated event upon successfully catching the loot.")]
		public LootCatchType _lootCatchType;

		[HideInInspector]
		public bool _showCatchEvent;

		[ShowVariable("_showCatchEvent")]
		public LootCatchEvent _lootCatchEvent;

		[Space]
		[BetterHeader("Cast And Attract Settings", 20)]
		public GameObject _fishingFloatPrefab;

		public float _maxCastForce = 20f;

		public float _forceChargeRate = 4f;

		[ReadOnlyField]
		public float _currentCastForce;

		public float _spawnFloatDelay = 0.3f;

		[InfoBox("Minimum distance required for successfully picking up or catching a target (e.g., fish or object).")]
		public float _catchDistance = 3.5f;

		[Space]
		[AddButton("Advanced Settings", "_showAdvancedSettings")]
		public bool _showAdvancedSettings;

		[ShowVariable("_showAdvancedSettings")]
		public AdvancedSettings _advanced;

		[HideInInspector]
		public bool _attractInput;

		[HideInInspector]
		public bool _castInput;

		[HideInInspector]
		public bool _castFloat;

		[SerializeField]
		public InputActionReference _leftAction;

		[SerializeField]
		public InputActionReference _rightAction;

		private float _catchCheckIntervalTimer;

		private float _randomSpeedChangerTimer = 2f;

		private float _randomSpeedChanger = 1f;

		private float _finalSpeed;

		private FishingFloatPathfinder _fishingFloatPathfinder = new FishingFloatPathfinder();

		private static InputAction GetInputAction(InputActionReference actionReference)
		{
			if (!(actionReference != null))
			{
				return null;
			}
			return actionReference.action;
		}

		private void Awake()
		{
			_catchCheckIntervalTimer = _advanced._catchCheckInterval;
			_baitForever = _bait;
			InputAction inputAction = GetInputAction(_leftAction);
			if (inputAction != null)
			{
				inputAction.performed += HandleCastInput;
				inputAction.canceled += StopHandleCastInput;
			}
			InputAction inputAction2 = GetInputAction(_rightAction);
			if (inputAction2 != null)
			{
				inputAction2.performed += HandleAttractInput;
				inputAction2.canceled += StopHandleAttractInput;
			}
		}

		private void Update()
		{
			if (_fishingRod != null)
			{
				AttractFloat();
				CastFloat();
			}
			HandleInput();
		}

		private void AttractFloat()
		{
			if (_fishingRod._fishingFloat == null)
			{
				return;
			}
			SubstrateType substrateType = _fishingRod._fishingFloat.GetComponent<FishingFloat>().CheckSurface(_fishingLayer);
			if (substrateType == SubstrateType.Water)
			{
				_advanced._caughtLoot = CheckingLoot(_advanced._caughtLoot, _bait, _advanced._catchProbabilityData, base.transform.position, _fishingRod._fishingFloat.position);
			}
			LineLengthLimitation(_fishingRod._fishingFloat.gameObject, base.transform.position, _fishingRod._lineStatus, substrateType);
			if (_attractInput && substrateType == SubstrateType.InAir && !_advanced._caughtLoot)
			{
				UnityEngine.Object.Destroy(_fishingRod._fishingFloat.gameObject);
				_fishingRod._fishingFloat = null;
			}
			else if (_attractInput && substrateType == SubstrateType.Land && !_advanced._caughtLoot)
			{
				float num = Vector3.Distance(base.transform.position, _fishingRod._fishingFloat.position);
				float num2 = _advanced._returnSpeedWithoutLoot * 120f * Time.deltaTime;
				Vector3 normalized = (base.transform.position - _fishingRod._fishingFloat.position).normalized;
				_fishingRod._fishingFloat.GetComponent<Rigidbody>().velocity = normalized * num2;
				if (num <= _catchDistance)
				{
					UnityEngine.Object.Destroy(_fishingRod._fishingFloat.gameObject);
					_fishingRod._fishingFloat = null;
				}
			}
			else if (_attractInput && substrateType == SubstrateType.Water && !_advanced._caughtLoot)
			{
				float num3 = Vector3.Distance(base.transform.position, _fishingRod._fishingFloat.position);
				_fishingFloatPathfinder.FloatBehavior(null, _fishingRod._fishingFloat, base.transform.position, _fishingRod._lineStatus._maxLineLength, _advanced._returnSpeedWithoutLoot, _attractInput, _fishingLayer);
				if (num3 <= _catchDistance)
				{
					UnityEngine.Object.Destroy(_fishingRod._fishingFloat.gameObject);
					_fishingRod._fishingFloat = null;
				}
			}
			else
			{
				if (!_advanced._caughtLoot || !(_fishingRod._fishingFloat != null))
				{
					return;
				}
				_fishingRod.LootCaught(_advanced._caughtLoot);
				while (_advanced._caughtLootData == null)
				{
					List<FishingLootData> lootDataFormWaterObject = _fishingRod._fishingFloat.GetComponent<FishingFloat>().GetLootDataFormWaterObject();
					_advanced._caughtLootData = ChooseFishingLoot(_bait, lootDataFormWaterObject);
					if (_advanced._caughtLootData != null)
					{
						float lootWeight = UnityEngine.Random.Range(_advanced._caughtLootData._weightRange._minWeight, _advanced._caughtLootData._weightRange._maxWeight);
						_advanced._lootWeight = lootWeight;
						_bait = _baitForever;
					}
				}
				AttractWithLoot(_advanced._caughtLootData, _fishingRod._fishingFloat, base.transform.position, _fishingLayer, _attractInput, _advanced._lootWeight, _fishingRod);
				if (_attractInput && _fishingRod._fishingFloat != null && Vector3.Distance(base.transform.position, _fishingRod._fishingFloat.position) <= _catchDistance)
				{
					GrabLoot(_advanced._caughtLootData, _fishingRod._fishingFloat.position, base.transform.position);
					UnityEngine.Object.Destroy(_fishingRod._fishingFloat.gameObject);
					_fishingRod._fishingFloat = null;
					_advanced._caughtLoot = false;
					_advanced._caughtLootData = null;
					_fishingRod.FinishFishing();
					_fishingFloatPathfinder.ClearPathData();
				}
			}
		}

		private void LineLengthLimitation(GameObject fishingFloat, Vector3 transformPosition, FishingLineStatus fishingLineStatus, SubstrateType substrateType)
		{
			if (fishingLineStatus._currentLineLength > fishingLineStatus._maxLineLength && substrateType != SubstrateType.Water)
			{
				Vector3 position = fishingFloat.transform.position;
				Vector3 normalized = (transformPosition - position).normalized;
				Rigidbody component = fishingFloat.GetComponent<Rigidbody>();
				float value = (fishingLineStatus._currentLineLength - fishingLineStatus._maxLineLength) / Time.deltaTime;
				float num = 5f;
				float num2 = Mathf.Clamp(value, 0f - num, num);
				component.velocity = normalized * num2;
			}
		}

		private void AttractWithLoot(FishingLootData lootData, Transform fishingFloatTransform, Vector3 transformPosition, LayerMask fishingLayer, bool attractInput, float lootWeight, FishingRod fishingRod)
		{
			float num = CalculateLootSpeed(lootData, lootWeight);
			float attractSpeed = CalculateAttractSpeed(fishingRod, attractInput, lootWeight, (int)lootData._lootTier);
			_finalSpeed = Mathf.Lerp(_finalSpeed, attractInput ? CalculateFinalAttractSpeed(num, attractSpeed, lootData) : num, 3f * Time.deltaTime);
			_fishingFloatPathfinder.FloatBehavior(lootData, fishingFloatTransform, transformPosition, fishingRod._lineStatus._maxLineLength, _finalSpeed, attractInput, fishingLayer);
		}

		private float CalculateLootSpeed(FishingLootData lootData, float lootWeight)
		{
			float[] array = new float[5] { 1f, 1.5f, 2f, 2.5f, 3f };
			int lootTier = (int)lootData._lootTier;
			_randomSpeedChangerTimer -= Time.deltaTime;
			if (_randomSpeedChangerTimer < 0f)
			{
				_randomSpeedChanger = UnityEngine.Random.Range(1f, 3f);
				_randomSpeedChangerTimer = UnityEngine.Random.Range(2f, 4f);
			}
			return (1.4f + lootWeight * 0.1f * array[lootTier]) * _randomSpeedChanger;
		}

		private float CalculateAttractSpeed(FishingRod fishingRod, bool attractInput, float lootWeight, int lootTier)
		{
			return fishingRod.CalculateLineLoad(_attractInput, lootWeight, lootTier)._attractFloatSpeed;
		}

		private float CalculateFinalAttractSpeed(float lootSpeed, float attractSpeed, FishingLootData lootData)
		{
			int lootTier = (int)lootData._lootTier;
			float[] array = new float[5] { 1.2f, 1f, 0.8f, 0.6f, 0.5f };
			float num = (attractSpeed - lootSpeed) * array[lootTier];
			return (num < 2f) ? 2f : num;
		}

		private void GrabLoot(FishingLootData lootData, Vector3 fishingFloatPosition, Vector3 transformPosition)
		{
			switch (_lootCatchType)
			{
			case LootCatchType.SpawnItem:
				if (lootData._lootPrefab == null)
				{
					Debug.LogError("No loot prefab added!");
				}
				else
				{
					SpawnLootItem(lootData._lootPrefab, fishingFloatPosition, transformPosition);
				}
				break;
			case LootCatchType.InvokeEvent:
				Debug.LogWarning("This feature is under development. In version 1.0, it does not work.");
				break;
			}
		}

		private void SpawnLootItem(GameObject lootPrefab, Vector3 fishingFloatPosition, Vector3 transformPosition)
		{
			Vector3 normalized = (transformPosition - fishingFloatPosition + Vector3.up * 3f).normalized;
			Vector3 position = fishingFloatPosition + new Vector3(0f, 1f, 0f);
			GameObject obj = UnityEngine.Object.Instantiate(lootPrefab, position, Quaternion.identity);
			float num = Vector3.Distance(fishingFloatPosition, transformPosition);
			float num2 = 0.8f;
			float num3 = num / num2;
			obj.GetComponent<Rigidbody>().AddForce(normalized * num3, ForceMode.Impulse);
		}

		private bool CheckingLoot(bool caughtLoot, FishingBaitData baitData, CatchProbabilityData catchProbabilityData, Vector3 transformPosition, Vector3 fishingFloatPosition)
		{
			if (caughtLoot)
			{
				return true;
			}
			bool result = false;
			_catchCheckIntervalTimer -= Time.deltaTime;
			if (_catchCheckIntervalTimer <= 0f)
			{
				result = CheckLootIsCatch(baitData, catchProbabilityData, transformPosition, fishingFloatPosition);
				_catchCheckIntervalTimer = _advanced._catchCheckInterval;
			}
			return result;
		}

		private bool CheckLootIsCatch(FishingBaitData baitData, CatchProbabilityData catchProbabilityData, Vector3 transformPosition, Vector3 fishingFloatPosition)
		{
			float distance = Vector3.Distance(transformPosition, fishingFloatPosition);
			float minSafeFishingDistanceFactor = 10f;
			int num = UnityEngine.Random.Range(1, 100);
			int num2 = 5;
			int num3 = 12;
			int num4 = 22;
			int num5 = 35;
			int num6 = 45;
			if (catchProbabilityData != null)
			{
				num2 = catchProbabilityData._commonProbability;
				num3 = catchProbabilityData._uncommonProbability;
				num4 = catchProbabilityData._rareProbability;
				num5 = catchProbabilityData._epicProbability;
				num6 = catchProbabilityData._legendaryProbability;
				minSafeFishingDistanceFactor = catchProbabilityData._minSafeFishingDistanceFactor;
			}
			num2 = CalculateProbabilityValueByCastDistance(num2, distance, minSafeFishingDistanceFactor);
			num3 = CalculateProbabilityValueByCastDistance(num3, distance, minSafeFishingDistanceFactor);
			num4 = CalculateProbabilityValueByCastDistance(num4, distance, minSafeFishingDistanceFactor);
			num5 = CalculateProbabilityValueByCastDistance(num5, distance, minSafeFishingDistanceFactor);
			num6 = CalculateProbabilityValueByCastDistance(num6, distance, minSafeFishingDistanceFactor);
			if (baitData == null)
			{
				if (num <= num2)
				{
					return true;
				}
				return false;
			}
			switch (baitData._baitTier)
			{
			case BaitTier.Uncommon:
				if (num <= num3)
				{
					return true;
				}
				return false;
			case BaitTier.Rare:
				if (num <= num4)
				{
					return true;
				}
				return false;
			case BaitTier.Epic:
				if (num <= num5)
				{
					return true;
				}
				return false;
			case BaitTier.Legendary:
				if (num <= num6)
				{
					return true;
				}
				return false;
			default:
				return false;
			}
		}

		private static int CalculateProbabilityValueByCastDistance(float probability, float distance, float minSafeFishingDistanceFactor)
		{
			float b = 1f;
			float t = Mathf.InverseLerp(0f, minSafeFishingDistanceFactor, distance);
			float num = Mathf.Lerp(0.3f, b, t);
			probability *= num;
			return (int)probability;
		}

		private FishingLootData ChooseFishingLoot(FishingBaitData baitData, List<FishingLootData> lootDataList)
		{
			for (int i = 0; i < lootDataList.Count; i++)
			{
				FishingLootData value = lootDataList[i];
				int index = UnityEngine.Random.Range(i, lootDataList.Count);
				lootDataList[i] = lootDataList[index];
				lootDataList[index] = value;
			}
			float totalRarity = CalculateTotalRarity(lootDataList);
			List<float> list = CalculatePercentageRarity(lootDataList, totalRarity);
			int num = 0;
			if (baitData != null)
			{
				num = (int)(baitData._baitTier + 1);
			}
			float num2 = UnityEngine.Random.Range(1f, 100f);
			float num3 = 0f;
			for (int j = 0; j < list.Count; j++)
			{
				num3 += list[j];
				if (num2 <= num3)
				{
					if (num >= (int)lootDataList[j]._lootTier)
					{
						return lootDataList[j];
					}
					return null;
				}
			}
			return null;
		}

		private float CalculateTotalRarity(List<FishingLootData> lootDataList)
		{
			float num = 0f;
			foreach (FishingLootData lootData in lootDataList)
			{
				num += lootData._lootRarity;
			}
			return num;
		}

		private List<float> CalculatePercentageRarity(List<FishingLootData> lootDataList, float totalRarity)
		{
			List<float> list = new List<float>();
			foreach (FishingLootData lootData in lootDataList)
			{
				float item = lootData._lootRarity / totalRarity * 100f;
				list.Add(item);
			}
			return list;
		}

		private void CastFloat()
		{
			if (!(_fishingRod._fishingFloat != null) && !_castFloat && !_fishingRod._lineStatus._isLineBroken)
			{
				if (_castInput)
				{
					_currentCastForce = CalculateCastForce(_currentCastForce, _maxCastForce, _forceChargeRate);
				}
				else if (!_castInput && _currentCastForce != 0f)
				{
					Vector3 position = _fishingRod._line._lineAttachment.position;
					Vector3 castDirection = base.transform.forward + Vector3.up;
					StartCoroutine(CastingDelay(_spawnFloatDelay, castDirection, position, _currentCastForce, _fishingFloatPrefab));
					_currentCastForce = 0f;
				}
			}
		}

		private IEnumerator CastingDelay(float delay, Vector3 castDirection, Vector3 spawnPoint, float castForce, GameObject fishingFloatPrefab)
		{
			_castFloat = true;
			yield return new WaitForSeconds(delay);
			_fishingRod._fishingFloat = Cast(castDirection, spawnPoint, castForce, fishingFloatPrefab);
			_castFloat = false;
		}

		private Transform Cast(Vector3 castDirection, Vector3 spawnPoint, float castForce, GameObject fishingFloatPrefab)
		{
			GameObject obj = UnityEngine.Object.Instantiate(fishingFloatPrefab, spawnPoint, Quaternion.identity);
			obj.GetComponent<Rigidbody>().AddForce(castDirection * castForce, ForceMode.Impulse);
			return obj.transform;
		}

		private float CalculateCastForce(float currentCastForce, float maxCastForce, float forceChargeRate)
		{
			currentCastForce += forceChargeRate * Time.deltaTime;
			currentCastForce = ((currentCastForce > maxCastForce) ? maxCastForce : currentCastForce);
			return currentCastForce;
		}

		public void ForceStopFishing()
		{
			UnityEngine.Object.Destroy(_fishingRod._fishingFloat.gameObject);
			_fishingRod._fishingFloat = null;
			_advanced._caughtLoot = false;
			_advanced._caughtLootData = null;
			_fishingRod.FinishFishing();
			_fishingFloatPathfinder.ClearPathData();
		}

		public void AddBait(FishingBaitData baitData)
		{
			if (_bait == null)
			{
				_bait = baitData;
				return;
			}
			Vector3 position = base.transform.position + base.transform.forward + Vector3.up;
			UnityEngine.Object.Instantiate(_bait._baitPrefab, position, Quaternion.identity);
			_bait = baitData;
		}

		public void AddCustomCatchProbabilityData(CatchProbabilityData catchProbabilityData)
		{
			_advanced._catchProbabilityData = catchProbabilityData;
		}

		public void FixFishingLine()
		{
			if (_fishingRod._lineStatus._isLineBroken)
			{
				_fishingRod._lineStatus._isLineBroken = false;
			}
		}

		private void HandleInput()
		{
			_attractInput = Input.GetButton("Fire2");
			_castInput = Input.GetButton("Fire1");
		}

		private void HandleCastInput(InputAction.CallbackContext context)
		{
			Debug.Log("HandleCastInput " + context.action.name);
			_castInput = true;
		}

		private void StopHandleCastInput(InputAction.CallbackContext context)
		{
			Debug.Log("stopHandleCastInput " + context.action.name);
			_castInput = false;
		}

		private void HandleAttractInput(InputAction.CallbackContext context)
		{
			Debug.Log("HandleAttractInput " + context.action.name);
			_attractInput = true;
		}

		private void StopHandleAttractInput(InputAction.CallbackContext context)
		{
			Debug.Log("StopHandleAttractInput " + context.action.name);
			_attractInput = false;
		}
	}
}
