using Timberborn.BlockSystem;
using Timberborn.Coordinates;
using Timberborn.Demolishing;
using Timberborn.SingletonSystem;
using Timberborn.TemplateSystem;
using UnityEngine;

namespace Timberborn.NaturalResources
{
	public class NaturalResourceFactory
	{
		private readonly TemplateNameMapper _templateNameMapper;

		private readonly SpawnValidationService _spawnValidationService;

		private readonly BlockObjectFactory _blockObjectFactory;

		private readonly EventBus _eventBus;

		public NaturalResourceFactory(TemplateNameMapper templateNameMapper, SpawnValidationService spawnValidationService, BlockObjectFactory blockObjectFactory, EventBus eventBus)
		{
			_templateNameMapper = templateNameMapper;
			_spawnValidationService = spawnValidationService;
			_blockObjectFactory = blockObjectFactory;
			_eventBus = eventBus;
		}

		public NaturalResource SpawnIgnoringConstraintsAndRandomizePosition(string resourceId, Vector3Int coordinates)
		{
			return SpawnIgnoringConstraints(resourceId, coordinates, randomPosition: true);
		}

		public NaturalResource SpawnIgnoringConstraints(string resourceId, Vector3Int coordinates)
		{
			return SpawnIgnoringConstraints(resourceId, coordinates, randomPosition: false);
		}

		public void SpawnNew(string resourceId, Vector3Int coordinates, bool spawnMarkedForDemolish)
		{
			BlockObjectSpec spec = _templateNameMapper.GetTemplate(resourceId).GetSpec<BlockObjectSpec>();
			if (_spawnValidationService.CanSpawn(coordinates, spec, resourceId))
			{
				Create(coordinates, spec, randomPosition: true, spawnMarkedForDemolish);
			}
		}

		public void PlantNew(string resourceId, Vector3Int coordinates)
		{
			BlockObjectSpec spec = _templateNameMapper.GetTemplate(resourceId).GetSpec<BlockObjectSpec>();
			Create(coordinates, spec, randomPosition: false);
			_eventBus.Post(new NaturalResourcePlantedEvent(spec));
		}

		private NaturalResource SpawnIgnoringConstraints(string resourceId, Vector3Int coordinates, bool randomPosition)
		{
			BlockObjectSpec spec = _templateNameMapper.GetTemplate(resourceId).GetSpec<BlockObjectSpec>();
			if (!_spawnValidationService.CanSpawnIgnoringConstraints(coordinates, spec))
			{
				return null;
			}
			return Create(coordinates, spec, randomPosition);
		}

		private NaturalResource Create(Vector3Int coordinates, BlockObjectSpec template, bool randomPosition, bool spawnMarkedForDemolish = false)
		{
			BlockObject blockObject = _blockObjectFactory.CreateFinished(template, new Placement(coordinates));
			if (randomPosition)
			{
				blockObject.GetComponent<CoordinatesOffsetter>().SetRandomOffset();
			}
			if (spawnMarkedForDemolish)
			{
				blockObject.GetComponent<Demolishable>().Mark();
			}
			return blockObject.GetComponent<NaturalResource>();
		}
	}
}
