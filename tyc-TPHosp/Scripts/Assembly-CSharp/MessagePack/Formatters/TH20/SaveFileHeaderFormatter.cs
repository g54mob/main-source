using System;
using System.Collections.Generic;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class SaveFileHeaderFormatter : IMessagePackFormatter<SaveFileHeader>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public SaveFileHeaderFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "Date", 0 },
				{ "Name", 1 },
				{ "Version", 2 },
				{ "LevelID", 3 },
				{ "ThumbnailPNG", 4 },
				{ "Balance", 5 },
				{ "Reputation", 6 },
				{ "HospitalLevel", 7 },
				{ "HospitalLevelProgress", 8 },
				{ "HospitalValue", 9 },
				{ "UsedDLCAppIDs", 10 },
				{ "UsedWorkshopItemPublishedFileIds", 11 },
				{ "UsedWorkshopItemNames", 12 },
				{ "UsedLocalUGCItemIDs", 13 },
				{ "UsedLocalUGCItemNames", 14 }
			};
			____stringByteKeys = new byte[15][]
			{
				MessagePackBinary.GetEncodedStringBytes("Date"),
				MessagePackBinary.GetEncodedStringBytes("Name"),
				MessagePackBinary.GetEncodedStringBytes("Version"),
				MessagePackBinary.GetEncodedStringBytes("LevelID"),
				MessagePackBinary.GetEncodedStringBytes("ThumbnailPNG"),
				MessagePackBinary.GetEncodedStringBytes("Balance"),
				MessagePackBinary.GetEncodedStringBytes("Reputation"),
				MessagePackBinary.GetEncodedStringBytes("HospitalLevel"),
				MessagePackBinary.GetEncodedStringBytes("HospitalLevelProgress"),
				MessagePackBinary.GetEncodedStringBytes("HospitalValue"),
				MessagePackBinary.GetEncodedStringBytes("UsedDLCAppIDs"),
				MessagePackBinary.GetEncodedStringBytes("UsedWorkshopItemPublishedFileIds"),
				MessagePackBinary.GetEncodedStringBytes("UsedWorkshopItemNames"),
				MessagePackBinary.GetEncodedStringBytes("UsedLocalUGCItemIDs"),
				MessagePackBinary.GetEncodedStringBytes("UsedLocalUGCItemNames")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, SaveFileHeader value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 15);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += formatterResolver.GetFormatterWithVerify<DateTime>().Serialize(ref bytes, offset, value.Date, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.Name, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[2]);
			offset += formatterResolver.GetFormatterWithVerify<VersionNumber>().Serialize(ref bytes, offset, value.Version, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[3]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.LevelID, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[4]);
			offset += formatterResolver.GetFormatterWithVerify<byte[]>().Serialize(ref bytes, offset, value.ThumbnailPNG, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[5]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.Balance);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[6]);
			offset += MessagePackBinary.WriteSingle(ref bytes, offset, value.Reputation);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[7]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.HospitalLevel);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[8]);
			offset += MessagePackBinary.WriteSingle(ref bytes, offset, value.HospitalLevelProgress);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[9]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.HospitalValue);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[10]);
			offset += formatterResolver.GetFormatterWithVerify<List<uint>>().Serialize(ref bytes, offset, value.UsedDLCAppIDs, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[11]);
			offset += formatterResolver.GetFormatterWithVerify<List<string>>().Serialize(ref bytes, offset, value.UsedWorkshopItemPublishedFileIds, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[12]);
			offset += formatterResolver.GetFormatterWithVerify<List<string>>().Serialize(ref bytes, offset, value.UsedWorkshopItemNames, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[13]);
			offset += formatterResolver.GetFormatterWithVerify<List<string>>().Serialize(ref bytes, offset, value.UsedLocalUGCItemIDs, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[14]);
			offset += formatterResolver.GetFormatterWithVerify<List<string>>().Serialize(ref bytes, offset, value.UsedLocalUGCItemNames, formatterResolver);
			return offset - num;
		}

		public SaveFileHeader Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			DateTime date = default(DateTime);
			string name = null;
			VersionNumber version = null;
			string levelID = null;
			byte[] thumbnailPNG = null;
			int balance = 0;
			float reputation = 0f;
			int hospitalLevel = 0;
			float hospitalLevelProgress = 0f;
			int hospitalValue = 0;
			List<uint> usedDLCAppIDs = null;
			List<string> usedWorkshopItemPublishedFileIds = null;
			List<string> usedWorkshopItemNames = null;
			List<string> usedLocalUGCItemIDs = null;
			List<string> usedLocalUGCItemNames = null;
			for (int i = 0; i < num2; i++)
			{
				ArraySegment<byte> key = MessagePackBinary.ReadStringSegment(bytes, offset, out readSize);
				offset += readSize;
				if (!____keyMapping.TryGetValueSafe(key, out var value))
				{
					readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
				}
				else
				{
					switch (value)
					{
					case 0:
						date = formatterResolver.GetFormatterWithVerify<DateTime>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 1:
						name = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 2:
						version = formatterResolver.GetFormatterWithVerify<VersionNumber>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 3:
						levelID = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 4:
						thumbnailPNG = formatterResolver.GetFormatterWithVerify<byte[]>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 5:
						balance = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 6:
						reputation = MessagePackBinary.ReadSingle(bytes, offset, out readSize);
						break;
					case 7:
						hospitalLevel = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 8:
						hospitalLevelProgress = MessagePackBinary.ReadSingle(bytes, offset, out readSize);
						break;
					case 9:
						hospitalValue = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 10:
						usedDLCAppIDs = formatterResolver.GetFormatterWithVerify<List<uint>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 11:
						usedWorkshopItemPublishedFileIds = formatterResolver.GetFormatterWithVerify<List<string>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 12:
						usedWorkshopItemNames = formatterResolver.GetFormatterWithVerify<List<string>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 13:
						usedLocalUGCItemIDs = formatterResolver.GetFormatterWithVerify<List<string>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 14:
						usedLocalUGCItemNames = formatterResolver.GetFormatterWithVerify<List<string>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new SaveFileHeader
			{
				Date = date,
				Name = name,
				Version = version,
				LevelID = levelID,
				ThumbnailPNG = thumbnailPNG,
				Balance = balance,
				Reputation = reputation,
				HospitalLevel = hospitalLevel,
				HospitalLevelProgress = hospitalLevelProgress,
				HospitalValue = hospitalValue,
				UsedDLCAppIDs = usedDLCAppIDs,
				UsedWorkshopItemPublishedFileIds = usedWorkshopItemPublishedFileIds,
				UsedWorkshopItemNames = usedWorkshopItemNames,
				UsedLocalUGCItemIDs = usedLocalUGCItemIDs,
				UsedLocalUGCItemNames = usedLocalUGCItemNames
			};
		}
	}
}
