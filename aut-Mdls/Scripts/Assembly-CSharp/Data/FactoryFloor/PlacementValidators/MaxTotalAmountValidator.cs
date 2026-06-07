using System.Collections.Generic;
using Data.Operator;
using Data.Variables;
using Logic.Factory.Blueprint;
using NaughtyAttributes;
using UnityEngine;

namespace Data.FactoryFloor.PlacementValidators
{
	[CreateAssetMenu(menuName = "Factory/Validators/MaxTotalAmountValidator", fileName = "MaxTotalAmountValidator")]
	public class MaxTotalAmountValidator : FactoryObjectPlacementValidator
	{
		[SerializeField]
		[InfoBox("The combined amount of these data's needs to be less than the max", EInfoBoxType.Normal)]
		private List<FactoryObjectData> _factoryObjectDatas;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private bool _useScriptableObject;

		[SerializeField]
		[HideIf("_useScriptableObject")]
		private int _maxAmount;

		[SerializeField]
		[ShowIf("_useScriptableObject")]
		private IntVariableSO _maxAmountSO;

		[SerializeField]
		[LocaKey]
		private string _maxPerIslandLimitExceededLocaKey;

		private int MaxAmount
		{
			get
			{
				if (!_useScriptableObject)
				{
					return _maxAmount;
				}
				return _maxAmountSO.Value;
			}
		}

		public override bool IsValidPosition(FactoryObjectData factoryObjectData, Vector3Int blueprintPosition, Vector3Int position, int rotation, FactoryLayer placementLayer, FactoryLayer terrainLayer, int createdId, Blueprint blueprint, bool isBeingMoved = false, BlueprintElement element = null)
		{
			int currentAmountsOnIsland = GetCurrentAmountsOnIsland();
			int amountToBeAdded = GetAmountToBeAdded(blueprint);
			bool num = currentAmountsOnIsland + amountToBeAdded <= MaxAmount;
			if (!num && !string.IsNullOrEmpty(_maxPerIslandLimitExceededLocaKey))
			{
				ThrowFailReasonEvent(this, LocalizationUtility.GetLocalizedText(_maxPerIslandLimitExceededLocaKey));
			}
			return num;
		}

		private int GetCurrentAmountsOnIsland()
		{
			int num = 0;
			foreach (FactoryObjectData factoryObjectData in _factoryObjectDatas)
			{
				if (_factoryLayer.TryGetObjectsFromData(factoryObjectData, out var factoryObjects))
				{
					num += factoryObjects.Count;
				}
			}
			return num;
		}

		private int GetAmountToBeAdded(Blueprint blueprint)
		{
			int num = 0;
			foreach (BlueprintElement element in blueprint.Elements)
			{
				if (_factoryObjectDatas.Contains(element.ObjectData))
				{
					num++;
				}
			}
			return num;
		}

		private void OnValidate()
		{
			if (!_useScriptableObject)
			{
				_maxAmountSO = null;
			}
		}
	}
}
