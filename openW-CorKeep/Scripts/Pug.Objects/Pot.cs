using System.Collections.Generic;
using Pug.UnityExtensions;

public class Pot : Chest
{
	public List<Plant> plants;

	private List<SpriteSkinFromEntityAndSeason> _plantSkins = new List<SpriteSkinFromEntityAndSeason>();

	private List<ObjectID> _currentDisplayedObjectIDs = new List<ObjectID>();

	private List<int> _currentDisplayedObjectVariations = new List<int>();

	private int _numberOfPlants;

	protected override void Awake()
	{
		base.Awake();
		_plantSkins.Resize(null, plants.Count);
		for (int i = 0; i < plants.Count; i++)
		{
			_plantSkins[i] = plants[i].GetComponent<SpriteSkinFromEntityAndSeason>();
		}
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		_currentDisplayedObjectIDs.Clear();
		_currentDisplayedObjectVariations.Clear();
		_numberOfPlants = base.inventoryHandler.size;
		for (int i = 0; i < _numberOfPlants; i++)
		{
			_currentDisplayedObjectIDs.Add(ObjectID.None);
			_currentDisplayedObjectVariations.Add(-1);
		}
		UpdatePlantVisuals();
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdatePlantVisuals();
	}

	private void UpdatePlantVisuals()
	{
		for (int i = 0; i < _numberOfPlants; i++)
		{
			ObjectDataCD objectDataCD = base.inventoryHandler.GetObjectData(i);
			if (objectDataCD.objectID != _currentDisplayedObjectIDs[i] || objectDataCD.variation != _currentDisplayedObjectVariations[i])
			{
				_currentDisplayedObjectIDs[i] = objectDataCD.objectID;
				_currentDisplayedObjectVariations[i] = objectDataCD.variation;
				ObjectInfo objectInfo = null;
				if (objectDataCD.objectID != ObjectID.None)
				{
					objectInfo = PugDatabase.GetObjectInfo(objectDataCD.objectID, objectDataCD.variation);
				}
				if (objectInfo != null && PugDatabase.HasComponent<FlowerCD>(objectDataCD))
				{
					FlowerCD component = PugDatabase.GetComponent<FlowerCD>(objectDataCD);
					ObjectInfo objectInfo2 = PugDatabase.GetObjectInfo(component.plantID, component.plantVariation);
					plants[i].XScaler.gameObject.SetActive(value: true);
					plants[i].UpdateSpriteSheetSkins(objectInfo2, 0);
					_plantSkins[i].UpdateGraphicsFromObjectInfo(objectInfo2);
					plants[i].UpdateVisuals(playChangeStateEffects: false, objectInfo2.additionalSprites.Count - 1, component.plantID, resetCurrentLocalStage: true, component.plantVariation, isInPot: true);
				}
				else
				{
					plants[i].XScaler.gameObject.SetActive(value: false);
				}
			}
		}
	}
}
