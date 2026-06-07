using System;
using Data.Shapes;
using Newtonsoft.Json;
using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	[Serializable]
	public class ResourceDto
	{
		public int ResourceID;

		public string Hash;

		public Color Color;

		private readonly ShapeDto _shapeDto;

		public bool TryGetShapeDto(out ShapeDto shapeDto)
		{
			shapeDto = _shapeDto;
			return shapeDto != null;
		}

		[JsonConstructor]
		public ResourceDto()
		{
		}

		public ResourceDto(Resource resource)
		{
			if (resource == null)
			{
				ResourceID = -1;
				return;
			}
			ResourceID = resource.Data.ID;
			if (resource is ShapeResource shapeResource)
			{
				Hash = shapeResource.ShapeData.GetShapeHash().ToString();
				_shapeDto = new ShapeDto(shapeResource.ShapeData);
			}
			if (resource is IColorResource colorResource)
			{
				Color = colorResource.GetColor();
			}
		}

		public Resource ToResource(ResourceFactory resourceFactory, ResourceDatabaseSO resourceDatabase)
		{
			if (ResourceID == -1)
			{
				return null;
			}
			ShapeHashPair hash = (string.IsNullOrEmpty(Hash) ? default(ShapeHashPair) : ShapeHashPair.Parse(Hash));
			return resourceFactory.CreateResource(resourceDatabase.GetResourceDataFromID(ResourceID), Color, hash);
		}

		public static Resource ToResource(ResourceDto resourceDto, ResourceFactory resourceFactory, ResourceDatabaseSO resourceDatabase)
		{
			if (resourceDto == null || resourceDto.ResourceID == -1)
			{
				return null;
			}
			ShapeHashPair hash = (string.IsNullOrEmpty(resourceDto.Hash) ? default(ShapeHashPair) : ShapeHashPair.Parse(resourceDto.Hash));
			return resourceFactory.CreateResource(resourceDatabase.GetResourceDataFromID(resourceDto.ResourceID), resourceDto.Color, hash);
		}
	}
}
