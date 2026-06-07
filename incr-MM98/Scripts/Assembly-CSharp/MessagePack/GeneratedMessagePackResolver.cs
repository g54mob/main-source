using System;
using System.Collections.Generic;
using MessagePack.Formatters;
using UnityEngine;

namespace MessagePack
{
	internal class GeneratedMessagePackResolver : IFormatterResolver
	{
		private static class FormatterCache<T>
		{
			internal static readonly IMessagePackFormatter<T> Formatter;

			static FormatterCache()
			{
				object formatter = GeneratedMessagePackResolverGetFormatterHelper.GetFormatter(typeof(T));
				if (formatter != null)
				{
					Formatter = (IMessagePackFormatter<T>)formatter;
				}
			}
		}

		private static class GeneratedMessagePackResolverGetFormatterHelper
		{
			private static readonly Dictionary<Type, int> closedTypeLookup = new Dictionary<Type, int>(61)
			{
				{
					typeof(Dictionary<Achievement, AchievementDetailsStateDto>),
					0
				},
				{
					typeof(Dictionary<Datacenter, DatacenterDetailsStateDto>),
					1
				},
				{
					typeof(Dictionary<Operation, int>),
					2
				},
				{
					typeof(Dictionary<Operation, List<OperationInstanceStateDto>>),
					3
				},
				{
					typeof(HashSet<ResearchNode>),
					4
				},
				{
					typeof(HashSet<UpgradeNode>),
					5
				},
				{
					typeof(HashSet<int>),
					6
				},
				{
					typeof(List<ComponentUnlockedStateDto>),
					7
				},
				{
					typeof(List<HistoryEntryDto>),
					8
				},
				{
					typeof(List<IRCMessageDto>),
					9
				},
				{
					typeof(List<OperationInstanceStateDto>),
					10
				},
				{
					typeof(List<GnormanAction>),
					11
				},
				{
					typeof(List<global::AuctionStateDto.AuctionLogDto>),
					12
				},
				{
					typeof(Achievement),
					13
				},
				{
					typeof(BackgroundSkin),
					14
				},
				{
					typeof(BoxArt),
					15
				},
				{
					typeof(CursorSkin),
					16
				},
				{
					typeof(Datacenter),
					17
				},
				{
					typeof(DatacenterState),
					18
				},
				{
					typeof(EndingState),
					19
				},
				{
					typeof(GnormanAction),
					20
				},
				{
					typeof(GnormanSkin),
					21
				},
				{
					typeof(Gullibleness),
					22
				},
				{
					typeof(IRCChannel),
					23
				},
				{
					typeof(LoggedSystemLoadType),
					24
				},
				{
					typeof(LootItemCategory),
					25
				},
				{
					typeof(LootItemQuality),
					26
				},
				{
					typeof(Operation),
					27
				},
				{
					typeof(ResearchNode),
					28
				},
				{
					typeof(UpgradeNode),
					29
				},
				{
					typeof(WorldType),
					30
				},
				{
					typeof(global::ComponentUnlockRequirement.RequirementType),
					31
				},
				{
					typeof(AchievementDetailsStateDto),
					32
				},
				{
					typeof(AchievementStateDto),
					33
				},
				{
					typeof(global::AuctionStateDto),
					34
				},
				{
					typeof(ComponentUnlockedStateDto),
					35
				},
				{
					typeof(CustomizationStateDto),
					36
				},
				{
					typeof(DatacenterDetailsStateDto),
					37
				},
				{
					typeof(DatacenterStateDto),
					38
				},
				{
					typeof(DebuggerStateDto),
					39
				},
				{
					typeof(GameStateDto),
					40
				},
				{
					typeof(GlobalFileDto),
					41
				},
				{
					typeof(GnormanStateDto),
					42
				},
				{
					typeof(HistoryEntryDto),
					43
				},
				{
					typeof(HistoryStateDto),
					44
				},
				{
					typeof(IRCMessageDto),
					45
				},
				{
					typeof(IRCStateDto),
					46
				},
				{
					typeof(MetaFileDto),
					47
				},
				{
					typeof(MetricsStateDto),
					48
				},
				{
					typeof(OperationInstanceStateDto),
					49
				},
				{
					typeof(OperationStateDto),
					50
				},
				{
					typeof(PrestigeStateDto),
					51
				},
				{
					typeof(ResearchStateDto),
					52
				},
				{
					typeof(ResourceStateDto),
					53
				},
				{
					typeof(SequelProgressStateDto),
					54
				},
				{
					typeof(SequelStateDto),
					55
				},
				{
					typeof(StateFileDto),
					56
				},
				{
					typeof(StudioStateDto),
					57
				},
				{
					typeof(UpgradeStateDto),
					58
				},
				{
					typeof(global::AuctionStateDto.AuctionLogDto),
					59
				},
				{
					typeof(global::AuctionStateDto.LootItemDto),
					60
				}
			};

			internal static object GetFormatter(Type t)
			{
				if (closedTypeLookup.TryGetValue(t, out var value))
				{
					return value switch
					{
						0 => new DictionaryFormatter<Achievement, AchievementDetailsStateDto>(), 
						1 => new DictionaryFormatter<Datacenter, DatacenterDetailsStateDto>(), 
						2 => new DictionaryFormatter<Operation, int>(), 
						3 => new DictionaryFormatter<Operation, List<OperationInstanceStateDto>>(), 
						4 => new HashSetFormatter<ResearchNode>(), 
						5 => new HashSetFormatter<UpgradeNode>(), 
						6 => new HashSetFormatter<int>(), 
						7 => new ListFormatter<ComponentUnlockedStateDto>(), 
						8 => new ListFormatter<HistoryEntryDto>(), 
						9 => new ListFormatter<IRCMessageDto>(), 
						10 => new ListFormatter<OperationInstanceStateDto>(), 
						11 => new ListFormatter<GnormanAction>(), 
						12 => new ListFormatter<global::AuctionStateDto.AuctionLogDto>(), 
						13 => new AchievementFormatter(), 
						14 => new BackgroundSkinFormatter(), 
						15 => new BoxArtFormatter(), 
						16 => new CursorSkinFormatter(), 
						17 => new DatacenterFormatter(), 
						18 => new DatacenterStateFormatter(), 
						19 => new EndingStateFormatter(), 
						20 => new GnormanActionFormatter(), 
						21 => new GnormanSkinFormatter(), 
						22 => new GulliblenessFormatter(), 
						23 => new IRCChannelFormatter(), 
						24 => new LoggedSystemLoadTypeFormatter(), 
						25 => new LootItemCategoryFormatter(), 
						26 => new LootItemQualityFormatter(), 
						27 => new OperationFormatter(), 
						28 => new ResearchNodeFormatter(), 
						29 => new UpgradeNodeFormatter(), 
						30 => new WorldTypeFormatter(), 
						31 => new ComponentUnlockRequirement.RequirementTypeFormatter(), 
						32 => new AchievementDetailsStateDtoFormatter(), 
						33 => new AchievementStateDtoFormatter(), 
						34 => new AuctionStateDtoFormatter(), 
						35 => new ComponentUnlockedStateDtoFormatter(), 
						36 => new CustomizationStateDtoFormatter(), 
						37 => new DatacenterDetailsStateDtoFormatter(), 
						38 => new DatacenterStateDtoFormatter(), 
						39 => new DebuggerStateDtoFormatter(), 
						40 => new GameStateDtoFormatter(), 
						41 => new GlobalFileDtoFormatter(), 
						42 => new GnormanStateDtoFormatter(), 
						43 => new HistoryEntryDtoFormatter(), 
						44 => new HistoryStateDtoFormatter(), 
						45 => new IRCMessageDtoFormatter(), 
						46 => new IRCStateDtoFormatter(), 
						47 => new MetaFileDtoFormatter(), 
						48 => new MetricsStateDtoFormatter(), 
						49 => new OperationInstanceStateDtoFormatter(), 
						50 => new OperationStateDtoFormatter(), 
						51 => new PrestigeStateDtoFormatter(), 
						52 => new ResearchStateDtoFormatter(), 
						53 => new ResourceStateDtoFormatter(), 
						54 => new SequelProgressStateDtoFormatter(), 
						55 => new SequelStateDtoFormatter(), 
						56 => new StateFileDtoFormatter(), 
						57 => new StudioStateDtoFormatter(), 
						58 => new UpgradeStateDtoFormatter(), 
						59 => new AuctionStateDto.AuctionLogDtoFormatter(), 
						60 => new AuctionStateDto.LootItemDtoFormatter(), 
						_ => null, 
					};
				}
				return null;
			}
		}

		internal sealed class AchievementDetailsStateDtoFormatter : IMessagePackFormatter<AchievementDetailsStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, AchievementDetailsStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				writer.WriteArrayHeader(2);
				writer.Write(value.Unlocked);
				writer.Write(value.Progress);
			}

			public AchievementDetailsStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				int num = reader.ReadArrayHeader();
				AchievementDetailsStateDto achievementDetailsStateDto = new AchievementDetailsStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						achievementDetailsStateDto.Unlocked = reader.ReadBoolean();
						break;
					case 1:
						achievementDetailsStateDto.Progress = reader.ReadDouble();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return achievementDetailsStateDto;
			}
		}

		internal sealed class AchievementStateDtoFormatter : IMessagePackFormatter<AchievementStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, AchievementStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(1);
				resolver.GetFormatterWithVerify<Dictionary<Achievement, AchievementDetailsStateDto>>().Serialize(ref writer, value.AchievementDetails, options);
			}

			public AchievementStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				AchievementStateDto achievementStateDto = new AchievementStateDto();
				for (int i = 0; i < num; i++)
				{
					if (i == 0)
					{
						achievementStateDto.AchievementDetails = resolver.GetFormatterWithVerify<Dictionary<Achievement, AchievementDetailsStateDto>>().Deserialize(ref reader, options);
					}
					else
					{
						reader.Skip();
					}
				}
				reader.Depth--;
				return achievementStateDto;
			}
		}

		internal sealed class AuctionStateDtoFormatter : IMessagePackFormatter<global::AuctionStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, global::AuctionStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(18);
				writer.Write(value.AvailableLootchests);
				writer.Write(value.TimeNextLootchestCurrent);
				writer.Write(value.TimeNextLootchestDuration);
				resolver.GetFormatterWithVerify<global::AuctionStateDto.LootItemDto>().Serialize(ref writer, value.CurrentLootItem, options);
				writer.Write(value.CommonDropchance);
				writer.Write(value.UncommonDropchance);
				writer.Write(value.RareDropchance);
				writer.Write(value.LegendaryDropchance);
				resolver.GetFormatterWithVerify<List<global::AuctionStateDto.AuctionLogDto>>().Serialize(ref writer, value.AuctionLog, options);
				writer.Write(value.EscrowMoney);
				writer.Write(value.EscrowInterestIntervalCurrent);
				writer.Write(value.EscrowInterestIntervalDuration);
				writer.Write(value.HiddenCommonDropchance);
				writer.Write(value.HiddenUncommonDropchance);
				writer.Write(value.HiddenRareDropchance);
				writer.Write(value.HiddenLegendaryDropchance);
				writer.Write(value.HiddenSentiment);
				writer.Write(value.HiddenSentimentTarget);
			}

			public global::AuctionStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				global::AuctionStateDto auctionStateDto = new global::AuctionStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						auctionStateDto.AvailableLootchests = reader.ReadInt32();
						break;
					case 1:
						auctionStateDto.TimeNextLootchestCurrent = reader.ReadSingle();
						break;
					case 2:
						auctionStateDto.TimeNextLootchestDuration = reader.ReadSingle();
						break;
					case 3:
						auctionStateDto.CurrentLootItem = resolver.GetFormatterWithVerify<global::AuctionStateDto.LootItemDto>().Deserialize(ref reader, options);
						break;
					case 4:
						auctionStateDto.CommonDropchance = reader.ReadSingle();
						break;
					case 5:
						auctionStateDto.UncommonDropchance = reader.ReadSingle();
						break;
					case 6:
						auctionStateDto.RareDropchance = reader.ReadSingle();
						break;
					case 7:
						auctionStateDto.LegendaryDropchance = reader.ReadSingle();
						break;
					case 8:
						auctionStateDto.AuctionLog = resolver.GetFormatterWithVerify<List<global::AuctionStateDto.AuctionLogDto>>().Deserialize(ref reader, options);
						break;
					case 9:
						auctionStateDto.EscrowMoney = reader.ReadDouble();
						break;
					case 10:
						auctionStateDto.EscrowInterestIntervalCurrent = reader.ReadSingle();
						break;
					case 11:
						auctionStateDto.EscrowInterestIntervalDuration = reader.ReadSingle();
						break;
					case 12:
						auctionStateDto.HiddenCommonDropchance = reader.ReadSingle();
						break;
					case 13:
						auctionStateDto.HiddenUncommonDropchance = reader.ReadSingle();
						break;
					case 14:
						auctionStateDto.HiddenRareDropchance = reader.ReadSingle();
						break;
					case 15:
						auctionStateDto.HiddenLegendaryDropchance = reader.ReadSingle();
						break;
					case 16:
						auctionStateDto.HiddenSentiment = reader.ReadSingle();
						break;
					case 17:
						auctionStateDto.HiddenSentimentTarget = reader.ReadSingle();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return auctionStateDto;
			}
		}

		internal sealed class ComponentUnlockedStateDtoFormatter : IMessagePackFormatter<ComponentUnlockedStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, ComponentUnlockedStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(2);
				resolver.GetFormatterWithVerify<global::ComponentUnlockRequirement.RequirementType>().Serialize(ref writer, value.Requirement, options);
				writer.Write(value.Value);
			}

			public ComponentUnlockedStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				ComponentUnlockedStateDto componentUnlockedStateDto = new ComponentUnlockedStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						componentUnlockedStateDto.Requirement = resolver.GetFormatterWithVerify<global::ComponentUnlockRequirement.RequirementType>().Deserialize(ref reader, options);
						break;
					case 1:
						componentUnlockedStateDto.Value = reader.ReadDouble();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return componentUnlockedStateDto;
			}
		}

		internal sealed class CustomizationStateDtoFormatter : IMessagePackFormatter<CustomizationStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, CustomizationStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(5);
				resolver.GetFormatterWithVerify<BackgroundSkin>().Serialize(ref writer, value.Background, options);
				writer.Write(value.CustomBackground);
				resolver.GetFormatterWithVerify<CursorSkin>().Serialize(ref writer, value.Cursor, options);
				writer.Write(value.TrailingCursor);
				resolver.GetFormatterWithVerify<GnormanSkin>().Serialize(ref writer, value.Gnorman, options);
			}

			public CustomizationStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				CustomizationStateDto customizationStateDto = new CustomizationStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						customizationStateDto.Background = resolver.GetFormatterWithVerify<BackgroundSkin>().Deserialize(ref reader, options);
						break;
					case 1:
						customizationStateDto.CustomBackground = reader.ReadBoolean();
						break;
					case 2:
						customizationStateDto.Cursor = resolver.GetFormatterWithVerify<CursorSkin>().Deserialize(ref reader, options);
						break;
					case 3:
						customizationStateDto.TrailingCursor = reader.ReadBoolean();
						break;
					case 4:
						customizationStateDto.Gnorman = resolver.GetFormatterWithVerify<GnormanSkin>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return customizationStateDto;
			}
		}

		internal sealed class DatacenterDetailsStateDtoFormatter : IMessagePackFormatter<DatacenterDetailsStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, DatacenterDetailsStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(3);
				resolver.GetFormatterWithVerify<DatacenterState>().Serialize(ref writer, value.State, options);
				writer.Write(value.Engineers);
				writer.Write(value.ReprovisionProgress);
			}

			public DatacenterDetailsStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				DatacenterDetailsStateDto datacenterDetailsStateDto = new DatacenterDetailsStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						datacenterDetailsStateDto.State = resolver.GetFormatterWithVerify<DatacenterState>().Deserialize(ref reader, options);
						break;
					case 1:
						datacenterDetailsStateDto.Engineers = reader.ReadInt32();
						break;
					case 2:
						datacenterDetailsStateDto.ReprovisionProgress = reader.ReadSingle();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return datacenterDetailsStateDto;
			}
		}

		internal sealed class DatacenterStateDtoFormatter : IMessagePackFormatter<DatacenterStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, DatacenterStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(1);
				resolver.GetFormatterWithVerify<Dictionary<Datacenter, DatacenterDetailsStateDto>>().Serialize(ref writer, value.DatacenterDetails, options);
			}

			public DatacenterStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				DatacenterStateDto datacenterStateDto = new DatacenterStateDto();
				for (int i = 0; i < num; i++)
				{
					if (i == 0)
					{
						datacenterStateDto.DatacenterDetails = resolver.GetFormatterWithVerify<Dictionary<Datacenter, DatacenterDetailsStateDto>>().Deserialize(ref reader, options);
					}
					else
					{
						reader.Skip();
					}
				}
				reader.Depth--;
				return datacenterStateDto;
			}
		}

		internal sealed class DebuggerStateDtoFormatter : IMessagePackFormatter<DebuggerStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, DebuggerStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(13);
				resolver.GetFormatterWithVerify<List<int>>().Serialize(ref writer, value.Staged, options);
				resolver.GetFormatterWithVerify<HashSet<int>>().Serialize(ref writer, value.Glitched, options);
				writer.Write(value.Hotfixing);
				writer.Write(value.Compiling);
				writer.Write(value.Progress);
				writer.Write(value.GlitchTimerCurrent);
				writer.Write(value.GlitchTimerDuration);
				writer.Write(value.BonusDecayTimerCurrent);
				writer.Write(value.BonusDecayTimerDuration);
				writer.Write(value.BonusDecayRate);
				writer.Write(value.BonusGrowthTimerCurrent);
				writer.Write(value.BonusGrowthTimerDuration);
				writer.Write(value.BonusGrowthRate);
			}

			public DebuggerStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				DebuggerStateDto debuggerStateDto = new DebuggerStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						debuggerStateDto.Staged = resolver.GetFormatterWithVerify<List<int>>().Deserialize(ref reader, options);
						break;
					case 1:
						debuggerStateDto.Glitched = resolver.GetFormatterWithVerify<HashSet<int>>().Deserialize(ref reader, options);
						break;
					case 2:
						debuggerStateDto.Hotfixing = reader.ReadBoolean();
						break;
					case 3:
						debuggerStateDto.Compiling = reader.ReadBoolean();
						break;
					case 4:
						debuggerStateDto.Progress = reader.ReadSingle();
						break;
					case 5:
						debuggerStateDto.GlitchTimerCurrent = reader.ReadSingle();
						break;
					case 6:
						debuggerStateDto.GlitchTimerDuration = reader.ReadSingle();
						break;
					case 7:
						debuggerStateDto.BonusDecayTimerCurrent = reader.ReadSingle();
						break;
					case 8:
						debuggerStateDto.BonusDecayTimerDuration = reader.ReadSingle();
						break;
					case 9:
						debuggerStateDto.BonusDecayRate = reader.ReadSingle();
						break;
					case 10:
						debuggerStateDto.BonusGrowthTimerCurrent = reader.ReadSingle();
						break;
					case 11:
						debuggerStateDto.BonusGrowthTimerDuration = reader.ReadSingle();
						break;
					case 12:
						debuggerStateDto.BonusGrowthRate = reader.ReadSingle();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return debuggerStateDto;
			}
		}

		internal sealed class GameStateDtoFormatter : IMessagePackFormatter<GameStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, GameStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(5);
				resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Name, options);
				writer.Write(value.Time);
				writer.Write(value.Launched);
				resolver.GetFormatterWithVerify<BoxArt>().Serialize(ref writer, value.BoxArt, options);
				resolver.GetFormatterWithVerify<WorldType>().Serialize(ref writer, value.World, options);
			}

			public GameStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				GameStateDto gameStateDto = new GameStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						gameStateDto.Name = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
						break;
					case 1:
						gameStateDto.Time = reader.ReadDouble();
						break;
					case 2:
						gameStateDto.Launched = reader.ReadBoolean();
						break;
					case 3:
						gameStateDto.BoxArt = resolver.GetFormatterWithVerify<BoxArt>().Deserialize(ref reader, options);
						break;
					case 4:
						gameStateDto.World = resolver.GetFormatterWithVerify<WorldType>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return gameStateDto;
			}
		}

		internal sealed class GlobalFileDtoFormatter : IMessagePackFormatter<GlobalFileDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, GlobalFileDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(1);
				resolver.GetFormatterWithVerify<AchievementStateDto>().Serialize(ref writer, value.Achievements, options);
			}

			public GlobalFileDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				GlobalFileDto globalFileDto = new GlobalFileDto();
				for (int i = 0; i < num; i++)
				{
					if (i == 0)
					{
						globalFileDto.Achievements = resolver.GetFormatterWithVerify<AchievementStateDto>().Deserialize(ref reader, options);
					}
					else
					{
						reader.Skip();
					}
				}
				reader.Depth--;
				return globalFileDto;
			}
		}

		internal sealed class GnormanStateDtoFormatter : IMessagePackFormatter<GnormanStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, GnormanStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(6);
				resolver.GetFormatterWithVerify<GnormanAction>().Serialize(ref writer, value.Action, options);
				writer.Write(value.Index);
				writer.Write(value.MaxIndex);
				resolver.GetFormatterWithVerify<List<GnormanAction>>().Serialize(ref writer, value.TutorialActionsStarted, options);
				resolver.GetFormatterWithVerify<List<GnormanAction>>().Serialize(ref writer, value.TutorialActionsQueue, options);
				resolver.GetFormatterWithVerify<Gullibleness>().Serialize(ref writer, value.Gullibleness, options);
			}

			public GnormanStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				GnormanStateDto gnormanStateDto = new GnormanStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						gnormanStateDto.Action = resolver.GetFormatterWithVerify<GnormanAction>().Deserialize(ref reader, options);
						break;
					case 1:
						gnormanStateDto.Index = reader.ReadInt32();
						break;
					case 2:
						gnormanStateDto.MaxIndex = reader.ReadInt32();
						break;
					case 3:
						gnormanStateDto.TutorialActionsStarted = resolver.GetFormatterWithVerify<List<GnormanAction>>().Deserialize(ref reader, options);
						break;
					case 4:
						gnormanStateDto.TutorialActionsQueue = resolver.GetFormatterWithVerify<List<GnormanAction>>().Deserialize(ref reader, options);
						break;
					case 5:
						gnormanStateDto.Gullibleness = resolver.GetFormatterWithVerify<Gullibleness>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return gnormanStateDto;
			}
		}

		internal sealed class HistoryEntryDtoFormatter : IMessagePackFormatter<HistoryEntryDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, HistoryEntryDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(6);
				writer.Write(value.Release);
				resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Title, options);
				resolver.GetFormatterWithVerify<BoxArt>().Serialize(ref writer, value.BoxArt, options);
				writer.Write(value.Money);
				writer.Write(value.Players);
				writer.Write(value.Time);
			}

			public HistoryEntryDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				HistoryEntryDto historyEntryDto = new HistoryEntryDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						historyEntryDto.Release = reader.ReadInt32();
						break;
					case 1:
						historyEntryDto.Title = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
						break;
					case 2:
						historyEntryDto.BoxArt = resolver.GetFormatterWithVerify<BoxArt>().Deserialize(ref reader, options);
						break;
					case 3:
						historyEntryDto.Money = reader.ReadDouble();
						break;
					case 4:
						historyEntryDto.Players = reader.ReadDouble();
						break;
					case 5:
						historyEntryDto.Time = reader.ReadDouble();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return historyEntryDto;
			}
		}

		internal sealed class HistoryStateDtoFormatter : IMessagePackFormatter<HistoryStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, HistoryStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(1);
				resolver.GetFormatterWithVerify<List<HistoryEntryDto>>().Serialize(ref writer, value.Releases, options);
			}

			public HistoryStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				HistoryStateDto historyStateDto = new HistoryStateDto();
				for (int i = 0; i < num; i++)
				{
					if (i == 0)
					{
						historyStateDto.Releases = resolver.GetFormatterWithVerify<List<HistoryEntryDto>>().Deserialize(ref reader, options);
					}
					else
					{
						reader.Skip();
					}
				}
				reader.Depth--;
				return historyStateDto;
			}
		}

		internal sealed class IRCMessageDtoFormatter : IMessagePackFormatter<IRCMessageDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, IRCMessageDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(6);
				resolver.GetFormatterWithVerify<IRCChannel>().Serialize(ref writer, value.Channel, options);
				resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Username, options);
				resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Message, options);
				writer.WriteNil();
				writer.WriteNil();
				resolver.GetFormatterWithVerify<Color>().Serialize(ref writer, value.Color, options);
			}

			public IRCMessageDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				IRCMessageDto iRCMessageDto = new IRCMessageDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						iRCMessageDto.Channel = resolver.GetFormatterWithVerify<IRCChannel>().Deserialize(ref reader, options);
						break;
					case 1:
						iRCMessageDto.Username = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
						break;
					case 2:
						iRCMessageDto.Message = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
						break;
					case 5:
						iRCMessageDto.Color = resolver.GetFormatterWithVerify<Color>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return iRCMessageDto;
			}
		}

		internal sealed class IRCStateDtoFormatter : IMessagePackFormatter<IRCStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, IRCStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(2);
				resolver.GetFormatterWithVerify<List<IRCMessageDto>>().Serialize(ref writer, value.Messages, options);
				resolver.GetFormatterWithVerify<LoggedSystemLoadType>().Serialize(ref writer, value.SystemLoad, options);
			}

			public IRCStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				IRCStateDto iRCStateDto = new IRCStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						iRCStateDto.Messages = resolver.GetFormatterWithVerify<List<IRCMessageDto>>().Deserialize(ref reader, options);
						break;
					case 1:
						iRCStateDto.SystemLoad = resolver.GetFormatterWithVerify<LoggedSystemLoadType>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return iRCStateDto;
			}
		}

		internal sealed class MetaFileDtoFormatter : IMessagePackFormatter<MetaFileDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, MetaFileDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(5);
				writer.Write(value.Version);
				writer.Write(value.SavedAtUnixSecondsUtc);
				resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.StudioName, options);
				writer.Write(value.PlayTime);
				writer.Write(value.Releases);
			}

			public MetaFileDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				MetaFileDto metaFileDto = new MetaFileDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						metaFileDto.Version = reader.ReadInt32();
						break;
					case 1:
						metaFileDto.SavedAtUnixSecondsUtc = reader.ReadInt64();
						break;
					case 2:
						metaFileDto.StudioName = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
						break;
					case 3:
						metaFileDto.PlayTime = reader.ReadDouble();
						break;
					case 4:
						metaFileDto.Releases = reader.ReadInt32();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return metaFileDto;
			}
		}

		internal sealed class MetricsStateDtoFormatter : IMessagePackFormatter<MetricsStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, MetricsStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(13);
				writer.Write(value.Releases);
				writer.Write(value.BombdusterWins);
				writer.Write(value.MoneyLifetime);
				writer.Write(value.BugsSquashed);
				resolver.GetFormatterWithVerify<List<ComponentUnlockedStateDto>>().Serialize(ref writer, value.ComponentsUnlocked, options);
				writer.Write(value.BombdusterAdvancedWins);
				writer.Write(value.BombdusterExpertWins);
				writer.Write(value.BugsStagedAuto);
				writer.Write(value.DatacenterReprovisionedFromDegraded);
				writer.Write(value.DatacenterReprovisionedFromCritical);
				writer.Write(value.LootchestsOpened);
				writer.Write(value.MoneySpendUpgrades);
				writer.Write(value.MarketingBlastTotalTime);
			}

			public MetricsStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				MetricsStateDto metricsStateDto = new MetricsStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						metricsStateDto.Releases = reader.ReadInt32();
						break;
					case 1:
						metricsStateDto.BombdusterWins = reader.ReadInt32();
						break;
					case 2:
						metricsStateDto.MoneyLifetime = reader.ReadDouble();
						break;
					case 3:
						metricsStateDto.BugsSquashed = reader.ReadDouble();
						break;
					case 4:
						metricsStateDto.ComponentsUnlocked = resolver.GetFormatterWithVerify<List<ComponentUnlockedStateDto>>().Deserialize(ref reader, options);
						break;
					case 5:
						metricsStateDto.BombdusterAdvancedWins = reader.ReadInt32();
						break;
					case 6:
						metricsStateDto.BombdusterExpertWins = reader.ReadInt32();
						break;
					case 7:
						metricsStateDto.BugsStagedAuto = reader.ReadDouble();
						break;
					case 8:
						metricsStateDto.DatacenterReprovisionedFromDegraded = reader.ReadInt32();
						break;
					case 9:
						metricsStateDto.DatacenterReprovisionedFromCritical = reader.ReadInt32();
						break;
					case 10:
						metricsStateDto.LootchestsOpened = reader.ReadInt32();
						break;
					case 11:
						metricsStateDto.MoneySpendUpgrades = reader.ReadDouble();
						break;
					case 12:
						metricsStateDto.MarketingBlastTotalTime = reader.ReadDouble();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return metricsStateDto;
			}
		}

		internal sealed class OperationInstanceStateDtoFormatter : IMessagePackFormatter<OperationInstanceStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, OperationInstanceStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				writer.WriteArrayHeader(2);
				writer.Write(value.Time);
				writer.Write(value.Duration);
			}

			public OperationInstanceStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				int num = reader.ReadArrayHeader();
				OperationInstanceStateDto operationInstanceStateDto = new OperationInstanceStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						operationInstanceStateDto.Time = reader.ReadSingle();
						break;
					case 1:
						operationInstanceStateDto.Duration = reader.ReadSingle();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return operationInstanceStateDto;
			}
		}

		internal sealed class OperationStateDtoFormatter : IMessagePackFormatter<OperationStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, OperationStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(2);
				resolver.GetFormatterWithVerify<Dictionary<Operation, int>>().Serialize(ref writer, value.Activations, options);
				resolver.GetFormatterWithVerify<Dictionary<Operation, List<OperationInstanceStateDto>>>().Serialize(ref writer, value.Instances, options);
			}

			public OperationStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				OperationStateDto operationStateDto = new OperationStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						operationStateDto.Activations = resolver.GetFormatterWithVerify<Dictionary<Operation, int>>().Deserialize(ref reader, options);
						break;
					case 1:
						operationStateDto.Instances = resolver.GetFormatterWithVerify<Dictionary<Operation, List<OperationInstanceStateDto>>>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return operationStateDto;
			}
		}

		internal sealed class PrestigeStateDtoFormatter : IMessagePackFormatter<PrestigeStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, PrestigeStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				writer.WriteArrayHeader(4);
				writer.Write(value.Fans);
				writer.Write(value.LastReleaseFansGain);
				writer.Write(value.Data);
				writer.Write(value.LastReleaseDataGain);
			}

			public PrestigeStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				int num = reader.ReadArrayHeader();
				PrestigeStateDto prestigeStateDto = new PrestigeStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						prestigeStateDto.Fans = reader.ReadDouble();
						break;
					case 1:
						prestigeStateDto.LastReleaseFansGain = reader.ReadDouble();
						break;
					case 2:
						prestigeStateDto.Data = reader.ReadDouble();
						break;
					case 3:
						prestigeStateDto.LastReleaseDataGain = reader.ReadDouble();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return prestigeStateDto;
			}
		}

		internal sealed class ResearchStateDtoFormatter : IMessagePackFormatter<ResearchStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, ResearchStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(2);
				resolver.GetFormatterWithVerify<HashSet<ResearchNode>>().Serialize(ref writer, value.Unlocked, options);
				writer.Write(value.DataNodes);
			}

			public ResearchStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				ResearchStateDto researchStateDto = new ResearchStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						researchStateDto.Unlocked = resolver.GetFormatterWithVerify<HashSet<ResearchNode>>().Deserialize(ref reader, options);
						break;
					case 1:
						researchStateDto.DataNodes = reader.ReadInt32();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return researchStateDto;
			}
		}

		internal sealed class ResourceStateDtoFormatter : IMessagePackFormatter<ResourceStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, ResourceStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				writer.WriteArrayHeader(11);
				writer.Write(value.Players);
				writer.Write(value.Money);
				writer.Write(value.MoneyLifetime);
				writer.Write(value.Nodes);
				writer.Write(value.Load);
				writer.Write(value.Uptime);
				writer.Write(value.Ping);
				writer.Write(value.Bugs);
				writer.Write(value.Hype);
				writer.Write(value.TargetHype);
				writer.Write(value.MoneySpend);
			}

			public ResourceStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				int num = reader.ReadArrayHeader();
				ResourceStateDto resourceStateDto = new ResourceStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						resourceStateDto.Players = reader.ReadDouble();
						break;
					case 1:
						resourceStateDto.Money = reader.ReadDouble();
						break;
					case 2:
						resourceStateDto.MoneyLifetime = reader.ReadDouble();
						break;
					case 3:
						resourceStateDto.Nodes = reader.ReadInt32();
						break;
					case 4:
						resourceStateDto.Load = reader.ReadSingle();
						break;
					case 5:
						resourceStateDto.Uptime = reader.ReadSingle();
						break;
					case 6:
						resourceStateDto.Ping = reader.ReadSingle();
						break;
					case 7:
						resourceStateDto.Bugs = reader.ReadSingle();
						break;
					case 8:
						resourceStateDto.Hype = reader.ReadSingle();
						break;
					case 9:
						resourceStateDto.TargetHype = reader.ReadSingle();
						break;
					case 10:
						resourceStateDto.MoneySpend = reader.ReadDouble();
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return resourceStateDto;
			}
		}

		internal sealed class SequelProgressStateDtoFormatter : IMessagePackFormatter<SequelProgressStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, SequelProgressStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(6);
				writer.Write(value.GameDesign);
				writer.Write(value.Art);
				writer.Write(value.Netcode);
				writer.Write(value.Marketing);
				writer.Write(value.Qa);
				resolver.GetFormatterWithVerify<Vector2>().Serialize(ref writer, value.FactorRange, options);
			}

			public SequelProgressStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				SequelProgressStateDto sequelProgressStateDto = new SequelProgressStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						sequelProgressStateDto.GameDesign = reader.ReadSingle();
						break;
					case 1:
						sequelProgressStateDto.Art = reader.ReadSingle();
						break;
					case 2:
						sequelProgressStateDto.Netcode = reader.ReadSingle();
						break;
					case 3:
						sequelProgressStateDto.Marketing = reader.ReadSingle();
						break;
					case 4:
						sequelProgressStateDto.Qa = reader.ReadSingle();
						break;
					case 5:
						sequelProgressStateDto.FactorRange = resolver.GetFormatterWithVerify<Vector2>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return sequelProgressStateDto;
			}
		}

		internal sealed class SequelStateDtoFormatter : IMessagePackFormatter<SequelStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, SequelStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(9);
				resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Name, options);
				resolver.GetFormatterWithVerify<BoxArt>().Serialize(ref writer, value.BoxArt, options);
				writer.WriteNil();
				writer.Write(value.Developing);
				writer.Write(value.Time);
				writer.Write(value.Duration);
				writer.Write(value.Round);
				writer.Write(value.Cost);
				resolver.GetFormatterWithVerify<SequelProgressStateDto>().Serialize(ref writer, value.Progress, options);
			}

			public SequelStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				SequelStateDto sequelStateDto = new SequelStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						sequelStateDto.Name = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
						break;
					case 1:
						sequelStateDto.BoxArt = resolver.GetFormatterWithVerify<BoxArt>().Deserialize(ref reader, options);
						break;
					case 3:
						sequelStateDto.Developing = reader.ReadBoolean();
						break;
					case 4:
						sequelStateDto.Time = reader.ReadSingle();
						break;
					case 5:
						sequelStateDto.Duration = reader.ReadSingle();
						break;
					case 6:
						sequelStateDto.Round = reader.ReadInt32();
						break;
					case 7:
						sequelStateDto.Cost = reader.ReadDouble();
						break;
					case 8:
						sequelStateDto.Progress = resolver.GetFormatterWithVerify<SequelProgressStateDto>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return sequelStateDto;
			}
		}

		internal sealed class StateFileDtoFormatter : IMessagePackFormatter<StateFileDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, StateFileDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(19);
				writer.Write(value.Version);
				writer.Write(value.SavedAtUnixSecondsUtc);
				resolver.GetFormatterWithVerify<StudioStateDto>().Serialize(ref writer, value.Studio, options);
				resolver.GetFormatterWithVerify<GameStateDto>().Serialize(ref writer, value.Game, options);
				resolver.GetFormatterWithVerify<SequelStateDto>().Serialize(ref writer, value.Sequel, options);
				resolver.GetFormatterWithVerify<HistoryStateDto>().Serialize(ref writer, value.History, options);
				resolver.GetFormatterWithVerify<ResourceStateDto>().Serialize(ref writer, value.Resources, options);
				resolver.GetFormatterWithVerify<PrestigeStateDto>().Serialize(ref writer, value.Prestige, options);
				resolver.GetFormatterWithVerify<GnormanStateDto>().Serialize(ref writer, value.Gnorman, options);
				resolver.GetFormatterWithVerify<UpgradeStateDto>().Serialize(ref writer, value.Upgrades, options);
				resolver.GetFormatterWithVerify<ResearchStateDto>().Serialize(ref writer, value.Research, options);
				resolver.GetFormatterWithVerify<OperationStateDto>().Serialize(ref writer, value.Operations, options);
				resolver.GetFormatterWithVerify<DebuggerStateDto>().Serialize(ref writer, value.Debugger, options);
				resolver.GetFormatterWithVerify<DatacenterStateDto>().Serialize(ref writer, value.Datacenters, options);
				resolver.GetFormatterWithVerify<CustomizationStateDto>().Serialize(ref writer, value.Customization, options);
				resolver.GetFormatterWithVerify<MetricsStateDto>().Serialize(ref writer, value.Metrics, options);
				resolver.GetFormatterWithVerify<AchievementStateDto>().Serialize(ref writer, value.Achievements, options);
				resolver.GetFormatterWithVerify<IRCStateDto>().Serialize(ref writer, value.IRC, options);
				resolver.GetFormatterWithVerify<global::AuctionStateDto>().Serialize(ref writer, value.Auction, options);
			}

			public StateFileDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				StateFileDto stateFileDto = new StateFileDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						stateFileDto.Version = reader.ReadInt32();
						break;
					case 1:
						stateFileDto.SavedAtUnixSecondsUtc = reader.ReadInt64();
						break;
					case 2:
						stateFileDto.Studio = resolver.GetFormatterWithVerify<StudioStateDto>().Deserialize(ref reader, options);
						break;
					case 3:
						stateFileDto.Game = resolver.GetFormatterWithVerify<GameStateDto>().Deserialize(ref reader, options);
						break;
					case 4:
						stateFileDto.Sequel = resolver.GetFormatterWithVerify<SequelStateDto>().Deserialize(ref reader, options);
						break;
					case 5:
						stateFileDto.History = resolver.GetFormatterWithVerify<HistoryStateDto>().Deserialize(ref reader, options);
						break;
					case 6:
						stateFileDto.Resources = resolver.GetFormatterWithVerify<ResourceStateDto>().Deserialize(ref reader, options);
						break;
					case 7:
						stateFileDto.Prestige = resolver.GetFormatterWithVerify<PrestigeStateDto>().Deserialize(ref reader, options);
						break;
					case 8:
						stateFileDto.Gnorman = resolver.GetFormatterWithVerify<GnormanStateDto>().Deserialize(ref reader, options);
						break;
					case 9:
						stateFileDto.Upgrades = resolver.GetFormatterWithVerify<UpgradeStateDto>().Deserialize(ref reader, options);
						break;
					case 10:
						stateFileDto.Research = resolver.GetFormatterWithVerify<ResearchStateDto>().Deserialize(ref reader, options);
						break;
					case 11:
						stateFileDto.Operations = resolver.GetFormatterWithVerify<OperationStateDto>().Deserialize(ref reader, options);
						break;
					case 12:
						stateFileDto.Debugger = resolver.GetFormatterWithVerify<DebuggerStateDto>().Deserialize(ref reader, options);
						break;
					case 13:
						stateFileDto.Datacenters = resolver.GetFormatterWithVerify<DatacenterStateDto>().Deserialize(ref reader, options);
						break;
					case 14:
						stateFileDto.Customization = resolver.GetFormatterWithVerify<CustomizationStateDto>().Deserialize(ref reader, options);
						break;
					case 15:
						stateFileDto.Metrics = resolver.GetFormatterWithVerify<MetricsStateDto>().Deserialize(ref reader, options);
						break;
					case 16:
						stateFileDto.Achievements = resolver.GetFormatterWithVerify<AchievementStateDto>().Deserialize(ref reader, options);
						break;
					case 17:
						stateFileDto.IRC = resolver.GetFormatterWithVerify<IRCStateDto>().Deserialize(ref reader, options);
						break;
					case 18:
						stateFileDto.Auction = resolver.GetFormatterWithVerify<global::AuctionStateDto>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return stateFileDto;
			}
		}

		internal sealed class StudioStateDtoFormatter : IMessagePackFormatter<StudioStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, StudioStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(6);
				resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Name, options);
				writer.Write(value.Time);
				writer.Write(value.Tutorial);
				writer.Write(value.Paused);
				resolver.GetFormatterWithVerify<EndingState>().Serialize(ref writer, value.Ending, options);
				resolver.GetFormatterWithVerify<DateTime>().Serialize(ref writer, value.EndingAchieved, options);
			}

			public StudioStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				StudioStateDto studioStateDto = new StudioStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						studioStateDto.Name = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
						break;
					case 1:
						studioStateDto.Time = reader.ReadDouble();
						break;
					case 2:
						studioStateDto.Tutorial = reader.ReadBoolean();
						break;
					case 3:
						studioStateDto.Paused = reader.ReadBoolean();
						break;
					case 4:
						studioStateDto.Ending = resolver.GetFormatterWithVerify<EndingState>().Deserialize(ref reader, options);
						break;
					case 5:
						studioStateDto.EndingAchieved = resolver.GetFormatterWithVerify<DateTime>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return studioStateDto;
			}
		}

		internal sealed class UpgradeStateDtoFormatter : IMessagePackFormatter<UpgradeStateDto>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, UpgradeStateDto value, MessagePackSerializerOptions options)
			{
				if (value == null)
				{
					writer.WriteNil();
					return;
				}
				IFormatterResolver resolver = options.Resolver;
				writer.WriteArrayHeader(2);
				resolver.GetFormatterWithVerify<HashSet<UpgradeNode>>().Serialize(ref writer, value.Unlocked, options);
				resolver.GetFormatterWithVerify<HashSet<UpgradeNode>>().Serialize(ref writer, value.Visited, options);
			}

			public UpgradeStateDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				if (reader.TryReadNil())
				{
					return null;
				}
				options.Security.DepthStep(ref reader);
				IFormatterResolver resolver = options.Resolver;
				int num = reader.ReadArrayHeader();
				UpgradeStateDto upgradeStateDto = new UpgradeStateDto();
				for (int i = 0; i < num; i++)
				{
					switch (i)
					{
					case 0:
						upgradeStateDto.Unlocked = resolver.GetFormatterWithVerify<HashSet<UpgradeNode>>().Deserialize(ref reader, options);
						break;
					case 1:
						upgradeStateDto.Visited = resolver.GetFormatterWithVerify<HashSet<UpgradeNode>>().Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
					}
				}
				reader.Depth--;
				return upgradeStateDto;
			}
		}

		internal class AuctionStateDto
		{
			internal sealed class AuctionLogDtoFormatter : IMessagePackFormatter<global::AuctionStateDto.AuctionLogDto>, IMessagePackFormatter
			{
				public void Serialize(ref MessagePackWriter writer, global::AuctionStateDto.AuctionLogDto value, MessagePackSerializerOptions options)
				{
					if (value == null)
					{
						writer.WriteNil();
						return;
					}
					IFormatterResolver resolver = options.Resolver;
					writer.WriteArrayHeader(5);
					resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Username, options);
					resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Item, options);
					writer.Write(value.Value);
					writer.Write(value.Cut);
					writer.Write(value.CutPercentage);
				}

				public global::AuctionStateDto.AuctionLogDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
				{
					if (reader.TryReadNil())
					{
						return null;
					}
					options.Security.DepthStep(ref reader);
					IFormatterResolver resolver = options.Resolver;
					int num = reader.ReadArrayHeader();
					global::AuctionStateDto.AuctionLogDto auctionLogDto = new global::AuctionStateDto.AuctionLogDto();
					for (int i = 0; i < num; i++)
					{
						switch (i)
						{
						case 0:
							auctionLogDto.Username = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
							break;
						case 1:
							auctionLogDto.Item = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
							break;
						case 2:
							auctionLogDto.Value = reader.ReadDouble();
							break;
						case 3:
							auctionLogDto.Cut = reader.ReadDouble();
							break;
						case 4:
							auctionLogDto.CutPercentage = reader.ReadSingle();
							break;
						default:
							reader.Skip();
							break;
						}
					}
					reader.Depth--;
					return auctionLogDto;
				}
			}

			internal sealed class LootItemDtoFormatter : IMessagePackFormatter<global::AuctionStateDto.LootItemDto>, IMessagePackFormatter
			{
				public void Serialize(ref MessagePackWriter writer, global::AuctionStateDto.LootItemDto value, MessagePackSerializerOptions options)
				{
					if (value == null)
					{
						writer.WriteNil();
						return;
					}
					IFormatterResolver resolver = options.Resolver;
					writer.WriteArrayHeader(5);
					resolver.GetFormatterWithVerify<LootItemQuality>().Serialize(ref writer, value.Quality, options);
					resolver.GetFormatterWithVerify<LootItemCategory>().Serialize(ref writer, value.Category, options);
					resolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.Name, options);
					writer.Write(value.IconIndex);
					writer.Write(value.Value);
				}

				public global::AuctionStateDto.LootItemDto Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
				{
					if (reader.TryReadNil())
					{
						return null;
					}
					options.Security.DepthStep(ref reader);
					IFormatterResolver resolver = options.Resolver;
					int num = reader.ReadArrayHeader();
					global::AuctionStateDto.LootItemDto lootItemDto = new global::AuctionStateDto.LootItemDto();
					for (int i = 0; i < num; i++)
					{
						switch (i)
						{
						case 0:
							lootItemDto.Quality = resolver.GetFormatterWithVerify<LootItemQuality>().Deserialize(ref reader, options);
							break;
						case 1:
							lootItemDto.Category = resolver.GetFormatterWithVerify<LootItemCategory>().Deserialize(ref reader, options);
							break;
						case 2:
							lootItemDto.Name = resolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
							break;
						case 3:
							lootItemDto.IconIndex = reader.ReadInt32();
							break;
						case 4:
							lootItemDto.Value = reader.ReadDouble();
							break;
						default:
							reader.Skip();
							break;
						}
					}
					reader.Depth--;
					return lootItemDto;
				}
			}
		}

		internal sealed class AchievementFormatter : IMessagePackFormatter<Achievement>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, Achievement value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public Achievement Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (Achievement)reader.ReadInt32();
			}
		}

		internal sealed class BackgroundSkinFormatter : IMessagePackFormatter<BackgroundSkin>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, BackgroundSkin value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public BackgroundSkin Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (BackgroundSkin)reader.ReadInt32();
			}
		}

		internal sealed class BoxArtFormatter : IMessagePackFormatter<BoxArt>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, BoxArt value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public BoxArt Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (BoxArt)reader.ReadInt32();
			}
		}

		internal sealed class CursorSkinFormatter : IMessagePackFormatter<CursorSkin>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, CursorSkin value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public CursorSkin Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (CursorSkin)reader.ReadInt32();
			}
		}

		internal sealed class DatacenterFormatter : IMessagePackFormatter<Datacenter>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, Datacenter value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public Datacenter Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (Datacenter)reader.ReadInt32();
			}
		}

		internal sealed class DatacenterStateFormatter : IMessagePackFormatter<DatacenterState>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, DatacenterState value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public DatacenterState Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (DatacenterState)reader.ReadInt32();
			}
		}

		internal sealed class EndingStateFormatter : IMessagePackFormatter<EndingState>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, EndingState value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public EndingState Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (EndingState)reader.ReadInt32();
			}
		}

		internal sealed class GnormanActionFormatter : IMessagePackFormatter<GnormanAction>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, GnormanAction value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public GnormanAction Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (GnormanAction)reader.ReadInt32();
			}
		}

		internal sealed class GnormanSkinFormatter : IMessagePackFormatter<GnormanSkin>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, GnormanSkin value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public GnormanSkin Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (GnormanSkin)reader.ReadInt32();
			}
		}

		internal sealed class GulliblenessFormatter : IMessagePackFormatter<Gullibleness>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, Gullibleness value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public Gullibleness Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (Gullibleness)reader.ReadInt32();
			}
		}

		internal sealed class IRCChannelFormatter : IMessagePackFormatter<IRCChannel>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, IRCChannel value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public IRCChannel Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (IRCChannel)reader.ReadInt32();
			}
		}

		internal sealed class LoggedSystemLoadTypeFormatter : IMessagePackFormatter<LoggedSystemLoadType>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, LoggedSystemLoadType value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public LoggedSystemLoadType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (LoggedSystemLoadType)reader.ReadInt32();
			}
		}

		internal sealed class LootItemCategoryFormatter : IMessagePackFormatter<LootItemCategory>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, LootItemCategory value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public LootItemCategory Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (LootItemCategory)reader.ReadInt32();
			}
		}

		internal sealed class LootItemQualityFormatter : IMessagePackFormatter<LootItemQuality>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, LootItemQuality value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public LootItemQuality Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (LootItemQuality)reader.ReadInt32();
			}
		}

		internal sealed class OperationFormatter : IMessagePackFormatter<Operation>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, Operation value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public Operation Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (Operation)reader.ReadInt32();
			}
		}

		internal sealed class ResearchNodeFormatter : IMessagePackFormatter<ResearchNode>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, ResearchNode value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public ResearchNode Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (ResearchNode)reader.ReadInt32();
			}
		}

		internal sealed class UpgradeNodeFormatter : IMessagePackFormatter<UpgradeNode>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, UpgradeNode value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public UpgradeNode Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (UpgradeNode)reader.ReadInt32();
			}
		}

		internal sealed class WorldTypeFormatter : IMessagePackFormatter<WorldType>, IMessagePackFormatter
		{
			public void Serialize(ref MessagePackWriter writer, WorldType value, MessagePackSerializerOptions options)
			{
				writer.Write((int)value);
			}

			public WorldType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
			{
				return (WorldType)reader.ReadInt32();
			}
		}

		internal class ComponentUnlockRequirement
		{
			internal sealed class RequirementTypeFormatter : IMessagePackFormatter<global::ComponentUnlockRequirement.RequirementType>, IMessagePackFormatter
			{
				public void Serialize(ref MessagePackWriter writer, global::ComponentUnlockRequirement.RequirementType value, MessagePackSerializerOptions options)
				{
					writer.Write((int)value);
				}

				public global::ComponentUnlockRequirement.RequirementType Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
				{
					return (global::ComponentUnlockRequirement.RequirementType)reader.ReadInt32();
				}
			}
		}

		public static readonly IFormatterResolver Instance = new MessagePack.GeneratedMessagePackResolver();

		private GeneratedMessagePackResolver()
		{
		}

		public IMessagePackFormatter<T> GetFormatter<T>()
		{
			return FormatterCache<T>.Formatter;
		}
	}
}
