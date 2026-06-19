using System;
using System.Collections.Generic;
using Pug.ECS.Hybrid;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class TileDependentObjectEnabler : MonoBehaviour, IGraphicalSpawn
{
	[Serializable]
	public class TileAndObject
	{
		public Tileset tileset;

		public GameObject objectToEnable;
	}

	public TileType tileType;

	public List<TileAndObject> variations;

	private int _querySystemTypeIndex;

	private void Awake()
	{
		_querySystemTypeIndex = TypeManager.GetSystemTypeIndex<PugQuerySystem>();
	}

	public void Spawn(Entity entity, EntityManager entityManager)
	{
		PugQuerySystem systemBase = (PugQuerySystem)entityManager.World.GetExistingSystemManaged(_querySystemTypeIndex);
		TileAccessor tileAccessor = new TileAccessor(systemBase);
		int2 worldPosition = entityManager.GetComponentData<LocalTransform>(entity).Position.RoundToInt2();
		bool flag = false;
		if (tileAccessor.GetType(worldPosition, tileType, out var tileCD))
		{
			foreach (TileAndObject variation in variations)
			{
				if (variation.tileset == (Tileset)tileCD.tileset)
				{
					variation.objectToEnable.SetActive(value: true);
					flag = true;
				}
				else
				{
					variation.objectToEnable.SetActive(value: false);
				}
			}
		}
		if (!flag && variations.Count > 0)
		{
			variations[0].objectToEnable.SetActive(value: true);
		}
	}
}
