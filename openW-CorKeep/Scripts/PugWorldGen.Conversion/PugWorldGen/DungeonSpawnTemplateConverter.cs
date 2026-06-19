using Pug.Conversion;
using Unity.Collections;
using Unity.Entities;

namespace PugWorldGen
{
	public class DungeonSpawnTemplateConverter : SingleAuthoringComponentConverter<DungeonSpawnTemplateAuthoring>
	{
		private BlobAssetComputationContext<int, SpawnTemplateBlob> _context;

		public override void Dispose()
		{
			_context.Dispose();
			base.Dispose();
		}

		protected override void Convert(DungeonSpawnTemplateAuthoring authoring)
		{
			if (!_context.IsCreated)
			{
				_context = new BlobAssetComputationContext<int, SpawnTemplateBlob>(base.BlobAssetStore, 16, Allocator.Persistent);
			}
			EnsureHasBuffer<DungeonNodeTemplateBuffer>();
			foreach (DungeonSpawnTemplateAuthoring.SpawnTemplateConfiguration nodeTemplate in authoring.nodeTemplates)
			{
				Entity entity = CreateAdditionalEntity();
				AddToBuffer(new DungeonNodeTemplateBuffer
				{
					flags = nodeTemplate.flags,
					minimumSizeRequirement = nodeTemplate.minimumSizeRequirement,
					spawnTemplateBufferEntity = entity
				});
				EnsureHasBuffer<DungeonNodeSpawnTemplateBuffer>(entity);
				foreach (SpawnTemplate template in nodeTemplate.templates)
				{
					if (!(template == null))
					{
						AddToBuffer(entity, new DungeonNodeSpawnTemplateBuffer
						{
							Value = DungeonSpawnTemplateHelper.GetBlob(template, _context, authoring.gameObject)
						});
					}
				}
			}
			EnsureHasBuffer<DungeonPathTemplateBuffer>();
			foreach (DungeonSpawnTemplateAuthoring.SpawnTemplateConfiguration pathTemplate in authoring.pathTemplates)
			{
				Entity entity2 = CreateAdditionalEntity();
				AddToBuffer(new DungeonPathTemplateBuffer
				{
					flags = pathTemplate.flags,
					minimumSizeRequirement = pathTemplate.minimumSizeRequirement,
					spawnTemplateBufferEntity = entity2
				});
				EnsureHasBuffer<DungeonPathSpawnTemplateBuffer>(entity2);
				foreach (SpawnTemplate template2 in pathTemplate.templates)
				{
					if (!(template2 == null))
					{
						AddToBuffer(entity2, new DungeonPathSpawnTemplateBuffer
						{
							Value = DungeonSpawnTemplateHelper.GetBlob(template2, _context, authoring.gameObject)
						});
					}
				}
			}
		}
	}
}
