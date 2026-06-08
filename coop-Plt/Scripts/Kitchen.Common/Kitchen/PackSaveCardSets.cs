using System;
using System.Collections.Generic;
using KitchenData;
using MessagePack;
using MessagePack.Formatters;
using Unity.Entities;

namespace Kitchen
{
	public abstract class PackSaveCardSets
	{
		public class SaveAny : PackSaver<V4>
		{
			protected internal override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
			}
		}

		public class LoadV1 : PackLoader<V1>
		{
			protected internal override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
			}
		}

		public class LoadV2 : PackLoader<V2>
		{
			protected internal override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
			}
		}

		public class LoadV3 : PackLoader<V3>
		{
			protected internal override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
			}
		}

		public class LoadV4 : PackLoader<V4>
		{
			protected internal override void OnCreateForCompiler()
			{
				base.OnCreateForCompiler();
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		[AutoUnionIndex(7)]
		public struct V4 : IPackSaveObject, ISaveObject
		{
			[Key(0)]
			public int Tier;

			[Key(1)]
			public string Name;

			[Key(2)]
			public DataObjectList Cards;

			[Key(3)]
			public Seed MapSeed;

			public bool Save(EntityManager em, Entity e)
			{
				EntityContext entityContext = new EntityContext(em);
				if (!entityContext.Require<CFranchiseItem>(e, out var comp))
				{
					return false;
				}
				if (!entityContext.Require<CFranchiseTier>(e, out var comp2))
				{
					return false;
				}
				if (entityContext.Has<SLayout>(e))
				{
					return false;
				}
				Tier = comp2.Tier;
				Name = comp.Name.Value;
				Cards = comp.Cards;
				MapSeed = comp.MapSeed;
				return true;
			}

			public void Load(EntityManager em)
			{
				EntityContext entityContext = new EntityContext(em);
				Entity entity = entityContext.CreateEntity();
				entityContext.Add<CPersistThroughSceneChanges>(entity);
				entityContext.Set(entity, new CPersistentItem
				{
					Type = PersistentStorageType.FranchiseCardSet,
					ItemID = AssetReference.FranchiseCardSet
				});
				entityContext.Set(entity, new CFranchiseTier
				{
					Tier = Tier
				});
				DataObjectList cards = default(DataObjectList);
				foreach (int card in Cards)
				{
					cards.Add(card);
				}
				entityContext.Set(entity, new CFranchiseItem
				{
					Name = (Name ?? ""),
					Cards = cards,
					MapSeed = MapSeed
				});
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		[AutoUnionIndex(6)]
		[MessagePackFormatter(typeof(PackSaveCardSetsV3Formatter))]
		public struct V3 : IPackSaveObject, ISaveObject
		{
			private class PackSaveCardSetsV3Formatter : IMessagePackFormatter<V3>, IMessagePackFormatter
			{
				public void Serialize(ref MessagePackWriter writer, V3 value, MessagePackSerializerOptions options)
				{
					IFormatterResolver resolver = options.Resolver;
					writer.WriteArrayHeader(4);
					writer.Write(value.Tier);
					resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Name, options);
					resolver.GetFormatterWithVerify<DataObjectList>().Serialize(ref writer, value.Cards, options);
					writer.Write(value.MapSeed);
				}

				public V3 Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
				{
					if (reader.TryReadNil())
					{
						throw new InvalidOperationException("typecode is null, struct not supported");
					}
					options.Security.DepthStep(ref reader);
					IFormatterResolver resolver = options.Resolver;
					int num = reader.ReadArrayHeader();
					V3 result = default(V3);
					for (int i = 0; i < num; i++)
					{
						switch (i)
						{
						case 0:
							result.Tier = reader.ReadInt32();
							break;
						case 1:
							result.Name = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
							break;
						case 2:
							result.Cards = resolver.GetFormatterWithVerify<DataObjectList>().Deserialize(ref reader, options);
							break;
						case 3:
						{
							MessagePackReader messagePackReader = reader.CreatePeekReader();
							try
							{
								result.MapSeed = messagePackReader.ReadInt32();
								reader.ReadInt32();
							}
							catch
							{
								resolver.GetFormatterWithVerify<Seed>().Deserialize(ref reader, options);
							}
							break;
						}
						default:
							reader.Skip();
							break;
						}
					}
					reader.Depth--;
					return result;
				}
			}

			[Key(0)]
			public int Tier;

			[Key(1)]
			public string Name;

			[Key(2)]
			public DataObjectList Cards;

			[Key(3)]
			public int MapSeed;

			public bool Save(EntityManager em, Entity e)
			{
				return false;
			}

			public void Load(EntityManager em)
			{
				EntityContext entityContext = new EntityContext(em);
				Entity entity = entityContext.CreateEntity();
				entityContext.Add<CPersistThroughSceneChanges>(entity);
				entityContext.Set(entity, new CPersistentItem
				{
					Type = PersistentStorageType.FranchiseCardSet,
					ItemID = AssetReference.FranchiseCardSet
				});
				entityContext.Set(entity, new CFranchiseTier
				{
					Tier = Tier
				});
				DataObjectList cards = default(DataObjectList);
				foreach (int card in Cards)
				{
					cards.Add(card);
				}
				entityContext.Set(entity, new CFranchiseItem
				{
					Name = (Name ?? ""),
					Cards = cards,
					MapSeed = Seed.Generate(MapSeed)
				});
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		[AutoUnionIndex(5)]
		public struct V2 : IPackSaveObject, ISaveObject
		{
			[Key(0)]
			public int Tier;

			[Key(1)]
			public string Name;

			[Key(2)]
			public List<int> Cards;

			[Key(3)]
			public int MapSeed;

			public bool Save(EntityManager em, Entity e)
			{
				return false;
			}

			public void Load(EntityManager em)
			{
				EntityContext entityContext = new EntityContext(em);
				Entity entity = entityContext.CreateEntity();
				entityContext.Add<CPersistThroughSceneChanges>(entity);
				entityContext.Set(entity, new CPersistentItem
				{
					Type = PersistentStorageType.FranchiseCardSet,
					ItemID = AssetReference.FranchiseCardSet
				});
				entityContext.Set(entity, new CFranchiseTier
				{
					Tier = Tier
				});
				DataObjectList cards = default(DataObjectList);
				if (Cards != null)
				{
					foreach (int card in Cards)
					{
						cards.Add(card);
					}
				}
				entityContext.Set(entity, new CFranchiseItem
				{
					Name = (Name ?? ""),
					Cards = cards,
					MapSeed = Seed.Generate(MapSeed)
				});
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		[AutoUnionIndex(1)]
		public struct V1 : IPackSaveObject, ISaveObject
		{
			[Key(0)]
			public int Tier;

			[Key(1)]
			public string Name;

			[Key(2)]
			public List<int> Cards;

			public bool Save(EntityManager em, Entity e)
			{
				return false;
			}

			public void Load(EntityManager em)
			{
				EntityContext entityContext = new EntityContext(em);
				Entity entity = entityContext.CreateEntity();
				entityContext.Add<CPersistThroughSceneChanges>(entity);
				entityContext.Set(entity, new CPersistentItem
				{
					Type = PersistentStorageType.FranchiseCardSet,
					ItemID = AssetReference.FranchiseCardSet
				});
				entityContext.Set(entity, new CFranchiseTier
				{
					Tier = Tier
				});
				DataObjectList cards = default(DataObjectList);
				if (Cards != null)
				{
					foreach (int card in Cards)
					{
						cards.Add(card);
					}
				}
				entityContext.Set(entity, new CFranchiseItem
				{
					Name = (Name ?? ""),
					Cards = cards
				});
			}
		}
	}
}
