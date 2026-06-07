using System;
using System.Collections.Generic;
using Data.Shapes;
using Events.FactoryFloor;
using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	[CreateAssetMenu(menuName = "Factory/Resources/ResourceFactory", fileName = "ResourceFactory", order = 0)]
	public class ResourceFactory : ScriptableObject
	{
		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[SerializeField]
		private ResourceDataSO _shapeResourceData;

		[SerializeField]
		private List<ResourceDataSO> _colorResourceData;

		[Header("Events")]
		[SerializeField]
		private ResourceCreatedEventSO _resourceCreatedEvent;

		private readonly Dictionary<int, Resource> _cachedResources = new Dictionary<int, Resource>();

		private readonly Dictionary<int, ColorResource> _cachedColourResources = new Dictionary<int, ColorResource>();

		private readonly Dictionary<ShapeHashPair, ShapeResource> _cachedShapeResources = new Dictionary<ShapeHashPair, ShapeResource>();

		public Resource CreateResource(ResourceDataSO resourceDataSO, Color colour = default(Color), ShapeHashPair hash = default(ShapeHashPair))
		{
			Resource resource;
			if (!(resourceDataSO == _shapeResourceData))
			{
				resource = ((!_colorResourceData.Contains(resourceDataSO) && !(resourceDataSO is PaintResourceDataSO)) ? GetOrCreateResource(resourceDataSO) : GetOrCreateColorResource(resourceDataSO, colour));
			}
			else
			{
				if (!TryGetOrCreateShapeResource(hash, out var resource2))
				{
					return null;
				}
				resource = resource2;
			}
			_resourceCreatedEvent.Fire(resource);
			return resource;
		}

		public ShapeResource CreateShapeResource(ShapeData shapeData)
		{
			ShapeResource orCreateShapeResource = GetOrCreateShapeResource(shapeData);
			_resourceCreatedEvent.Fire(orCreateShapeResource);
			return orCreateShapeResource;
		}

		private Resource GetOrCreateResource(ResourceDataSO resourceDataSO)
		{
			if (!_cachedResources.TryGetValue(resourceDataSO.ID, out var value))
			{
				value = new Resource(resourceDataSO);
				_cachedResources.Add(resourceDataSO.ID, value);
			}
			return value;
		}

		private ColorResource GetOrCreateColorResource(ResourceDataSO resourceDataSO, Color colour)
		{
			int key = HashCode.Combine(resourceDataSO, colour);
			if (!_cachedColourResources.TryGetValue(key, out var value))
			{
				value = new ColorResource(resourceDataSO, colour);
				_cachedColourResources.Add(key, value);
			}
			return value;
		}

		private bool TryGetOrCreateShapeResource(ShapeHashPair hash, out ShapeResource resource)
		{
			if (_cachedShapeResources.TryGetValue(hash, out resource))
			{
				return true;
			}
			if (!_shapesDatabase.TryGetShapeData(hash, out var shapeData))
			{
				return false;
			}
			resource = new ShapeResource(_shapeResourceData, shapeData);
			_cachedShapeResources.Add(hash, resource);
			return true;
		}

		private ShapeResource GetOrCreateShapeResource(ShapeData shapeData)
		{
			ShapeHashPair shapeHash = shapeData.GetShapeHash();
			if (!_cachedShapeResources.TryGetValue(shapeHash, out var value))
			{
				value = new ShapeResource(_shapeResourceData, shapeData);
				_cachedShapeResources.Add(shapeHash, value);
			}
			return value;
		}
	}
}
