using System.Collections.Generic;
using Pug.Conversion;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace PugWorldGen
{
	public class DungeonShapeConverter : SingleAuthoringComponentConverter<DungeonShapeAuthoring>
	{
		private BlobAssetComputationContext<int, SpawnTemplateBlob> _context;

		public override void Dispose()
		{
			_context.Dispose();
			base.Dispose();
		}

		protected override void Convert(DungeonShapeAuthoring authoring)
		{
			if (!_context.IsCreated)
			{
				_context = new BlobAssetComputationContext<int, SpawnTemplateBlob>(base.BlobAssetStore, 16, Allocator.Persistent);
			}
			if (authoring.roomShapeSpawnTemplate != null)
			{
				Entity entity = CreateAdditionalEntity();
				EnsureHasBuffer<DungeonNodeTemplateBuffer>();
				AddToBuffer(new DungeonNodeTemplateBuffer
				{
					spawnTemplateBufferEntity = entity,
					flags = RoomFlags.Fill
				});
				EnsureHasBuffer<DungeonNodeSpawnTemplateBuffer>(entity);
				BlobAssetReference<SpawnTemplateBlob> blob = DungeonSpawnTemplateHelper.GetBlob(authoring.roomShapeSpawnTemplate, _context, authoring.gameObject);
				AddToBuffer(entity, new DungeonNodeSpawnTemplateBuffer
				{
					Value = blob
				});
			}
			if (authoring.pathShapeSpawnTemplate != null)
			{
				Entity entity2 = CreateAdditionalEntity();
				EnsureHasBuffer<DungeonPathTemplateBuffer>();
				AddToBuffer(new DungeonPathTemplateBuffer
				{
					spawnTemplateBufferEntity = entity2,
					flags = RoomFlags.Fill
				});
				EnsureHasBuffer<DungeonPathSpawnTemplateBuffer>(entity2);
				BlobAssetReference<SpawnTemplateBlob> blob2 = DungeonSpawnTemplateHelper.GetBlob(authoring.pathShapeSpawnTemplate, _context, authoring.gameObject);
				AddToBuffer(entity2, new DungeonPathSpawnTemplateBuffer
				{
					Value = blob2
				});
			}
			if (authoring.roomShapeSpawnTemplate == null || (authoring.pathShapeSpawnTemplate == null && authoring.tiles.Count > 0))
			{
				SpawnTemplate spawnTemplate = ScriptableObject.CreateInstance<SpawnTemplate>();
				spawnTemplate.shapeAmplitude = 0.5f;
				spawnTemplate.shapeFrequency = 2f;
				spawnTemplate.spawnEntries = new List<SpawnTemplate.SpawnEntry>();
				for (int i = 0; i < authoring.tiles.Count; i++)
				{
					ObjectID objectID = authoring.tiles[i];
					spawnTemplate.spawnEntries.Add(new SpawnTemplate.SpawnEntry
					{
						algorithm = ((!authoring.rectShaped) ? SpawnAlgorithm.Circle : SpawnAlgorithm.Rect),
						amount = new Pug.UnityExtensions.RangeInt
						{
							min = 1,
							max = 1
						},
						chanceToAppearAtAll = 1f,
						objectID = objectID,
						randomChance = 1f,
						shapeSize = (authoring.rectShaped ? new Range
						{
							min = 0.65710676f,
							max = 0.65710676f
						} : new Range
						{
							min = 1f,
							max = 1f
						})
					});
				}
				spawnTemplate.UpdateGuid();
				BlobAssetReference<SpawnTemplateBlob> blob3 = DungeonSpawnTemplateHelper.GetBlob(spawnTemplate, _context, authoring.gameObject);
				if (authoring.roomShapeSpawnTemplate == null)
				{
					Entity entity3 = CreateAdditionalEntity();
					EnsureHasBuffer<DungeonNodeTemplateBuffer>();
					AddToBuffer(new DungeonNodeTemplateBuffer
					{
						spawnTemplateBufferEntity = entity3,
						flags = RoomFlags.Fill
					});
					EnsureHasBuffer<DungeonNodeSpawnTemplateBuffer>(entity3);
					AddToBuffer(entity3, new DungeonNodeSpawnTemplateBuffer
					{
						Value = blob3
					});
				}
				spawnTemplate.shapeAmplitude = 0f;
				spawnTemplate.shapeFrequency = 1f;
				for (int j = 0; j < spawnTemplate.spawnEntries.Count; j++)
				{
					spawnTemplate.spawnEntries[j].canSpawnOn = ((j == 0) ? new List<ObjectID> { ObjectID.None } : new List<ObjectID> { authoring.tiles[j - 1] });
					spawnTemplate.spawnEntries[j].algorithm = SpawnAlgorithm.Rect;
					spawnTemplate.spawnEntries[j].shapeSize = new Range
					{
						min = 1f,
						max = 1f
					};
					spawnTemplate.spawnEntries[j].rotateTowardsCenter = true;
				}
				spawnTemplate.UpdateGuid();
				blob3 = DungeonSpawnTemplateHelper.GetBlob(spawnTemplate, _context, authoring.gameObject);
				if (authoring.pathShapeSpawnTemplate == null)
				{
					Entity entity4 = CreateAdditionalEntity();
					EnsureHasBuffer<DungeonPathTemplateBuffer>();
					AddToBuffer(new DungeonPathTemplateBuffer
					{
						spawnTemplateBufferEntity = entity4,
						flags = RoomFlags.Fill
					});
					EnsureHasBuffer<DungeonPathSpawnTemplateBuffer>(entity4);
					AddToBuffer(entity4, new DungeonPathSpawnTemplateBuffer
					{
						Value = blob3
					});
				}
			}
		}
	}
}
