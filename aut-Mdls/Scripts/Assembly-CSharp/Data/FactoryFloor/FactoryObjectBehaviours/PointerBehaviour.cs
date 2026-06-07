using System;
using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Logic.Threading.Events;
using SaveData.FactoryFloor;
using SaveData.FactoryFloor.Configurations;
using UnityEngine;

namespace Data.FactoryFloor.FactoryObjectBehaviours
{
	[CreateAssetMenu(menuName = "Factory/FactoryBehaviour/PointerBehaviour", fileName = "PointerBehaviour", order = 0)]
	public class PointerBehaviour : FactoryObjectBehaviour
	{
		[Serializable]
		public struct MaterialPack
		{
			public Color UIButtonColour;

			public Material[] MaterialsPerMesh;
		}

		public MainThreadEvent<MaterialPack> OnPointerColorChanged = new MainThreadEvent<MaterialPack>();

		[SerializeField]
		private MaterialPack[] _colours;

		[SerializeField]
		private bool _shouldUpdateAdjacentBehaviours;

		[SerializeField]
		private FactoryLayer _factoryLayer;

		private int _currentColourIndex;

		private static int LastSelectedColourIndex;

		public MaterialPack CurrentMaterials => _colours[_currentColourIndex];

		public IReadOnlyList<MaterialPack> AllMaterials => _colours;

		public override void Init(FactoryObject factoryObject)
		{
			base.Init(factoryObject);
			PointerBehaviourConfigurationDto behaviourConfigurationDto = factoryObject.GetBehaviourConfigurationDto<PointerBehaviourConfigurationDto>();
			if (behaviourConfigurationDto != null)
			{
				SelectColor(behaviourConfigurationDto.Color, updateAdjacentBehaviours: false);
			}
			else
			{
				SelectColor((_colours.Length > LastSelectedColourIndex) ? LastSelectedColourIndex : 0, updateAdjacentBehaviours: false);
			}
		}

		public override void Update()
		{
		}

		public void SelectColor(int colourIndex, bool updateAdjacentBehaviours = true)
		{
			_currentColourIndex = colourIndex;
			LastSelectedColourIndex = _currentColourIndex;
			OnPointerColorChanged.Fire(CurrentMaterials);
			if (_shouldUpdateAdjacentBehaviours && updateAdjacentBehaviours)
			{
				List<FactoryObject> alreadyUpdatedObjects = new List<FactoryObject>();
				UpdateAdjacentBehaviours(colourIndex, ref alreadyUpdatedObjects);
			}
		}

		private void SelectColor(int colourIndex, ref List<FactoryObject> alreadyUpdatedObjects)
		{
			_currentColourIndex = colourIndex;
			LastSelectedColourIndex = _currentColourIndex;
			OnPointerColorChanged.Fire(CurrentMaterials);
			UpdateAdjacentBehaviours(colourIndex, ref alreadyUpdatedObjects);
		}

		private void UpdateAdjacentBehaviours(int colourIndex, ref List<FactoryObject> alreadyUpdatedObjects)
		{
			if (!alreadyUpdatedObjects.Contains(_factoryObject))
			{
				alreadyUpdatedObjects.Add(_factoryObject);
				UpdateColorOfAdjacentAtPosition(_factoryObject.Position + new Vector3Int(0, 0, 1), ref alreadyUpdatedObjects);
				UpdateColorOfAdjacentAtPosition(_factoryObject.Position + new Vector3Int(1, 0, 0), ref alreadyUpdatedObjects);
				UpdateColorOfAdjacentAtPosition(_factoryObject.Position + new Vector3Int(0, 0, -1), ref alreadyUpdatedObjects);
				UpdateColorOfAdjacentAtPosition(_factoryObject.Position + new Vector3Int(-1, 0, 0), ref alreadyUpdatedObjects);
			}
			void UpdateColorOfAdjacentAtPosition(Vector3Int pos, ref List<FactoryObject> alreadyUpdatedObjects2)
			{
				if (_factoryLayer.TryGetObjectAt(pos, out var factoryObject) && factoryObject.FactoryObjectData.ID == _factoryObject.FactoryObjectData.ID && factoryObject.TryGetFactoryObjectBehaviour<PointerBehaviour>(out var behaviour))
				{
					behaviour.SelectColor(colourIndex, ref alreadyUpdatedObjects2);
				}
			}
		}

		public override BehaviourConfigurationDto GetConfiguration()
		{
			return new PointerBehaviourConfigurationDto(_currentColourIndex);
		}
	}
}
