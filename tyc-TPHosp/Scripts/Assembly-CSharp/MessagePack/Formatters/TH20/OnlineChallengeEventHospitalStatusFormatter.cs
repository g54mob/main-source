using System;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class OnlineChallengeEventHospitalStatusFormatter : IMessagePackFormatter<OnlineChallengeEventHospitalStatus>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public OnlineChallengeEventHospitalStatusFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "DoctorCount", 0 },
				{ "NurseCount", 1 },
				{ "JanitorCount", 2 },
				{ "AssistantCount", 3 },
				{ "PatientCount", 4 },
				{ "Balance", 5 },
				{ "Reputation", 6 },
				{ "PrestigeLevel", 7 },
				{ "PrestigeProgress", 8 },
				{ "FoundationValue", 9 },
				{ "FoundationShareValue", 10 },
				{ "FoundationStars", 11 },
				{ "FoundationSilver", 12 },
				{ "Day", 13 },
				{ "Type", 14 }
			};
			____stringByteKeys = new byte[15][]
			{
				MessagePackBinary.GetEncodedStringBytes("DoctorCount"),
				MessagePackBinary.GetEncodedStringBytes("NurseCount"),
				MessagePackBinary.GetEncodedStringBytes("JanitorCount"),
				MessagePackBinary.GetEncodedStringBytes("AssistantCount"),
				MessagePackBinary.GetEncodedStringBytes("PatientCount"),
				MessagePackBinary.GetEncodedStringBytes("Balance"),
				MessagePackBinary.GetEncodedStringBytes("Reputation"),
				MessagePackBinary.GetEncodedStringBytes("PrestigeLevel"),
				MessagePackBinary.GetEncodedStringBytes("PrestigeProgress"),
				MessagePackBinary.GetEncodedStringBytes("FoundationValue"),
				MessagePackBinary.GetEncodedStringBytes("FoundationShareValue"),
				MessagePackBinary.GetEncodedStringBytes("FoundationStars"),
				MessagePackBinary.GetEncodedStringBytes("FoundationSilver"),
				MessagePackBinary.GetEncodedStringBytes("Day"),
				MessagePackBinary.GetEncodedStringBytes("Type")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, OnlineChallengeEventHospitalStatus value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 15);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.DoctorCount);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.NurseCount);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[2]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.JanitorCount);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[3]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.AssistantCount);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[4]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.PatientCount);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[5]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.Balance);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[6]);
			offset += MessagePackBinary.WriteSingle(ref bytes, offset, value.Reputation);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[7]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.PrestigeLevel);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[8]);
			offset += MessagePackBinary.WriteSingle(ref bytes, offset, value.PrestigeProgress);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[9]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.FoundationValue);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[10]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.FoundationShareValue);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[11]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.FoundationStars);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[12]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.FoundationSilver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[13]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.Day);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[14]);
			offset += formatterResolver.GetFormatterWithVerify<OnlineChallengeEvent.Event>().Serialize(ref bytes, offset, value.Type, formatterResolver);
			return offset - num;
		}

		public OnlineChallengeEventHospitalStatus Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			int doctorCount = 0;
			int nurseCount = 0;
			int janitorCount = 0;
			int assistantCount = 0;
			int patientCount = 0;
			int balance = 0;
			float reputation = 0f;
			int prestigeLevel = 0;
			float prestigeProgress = 0f;
			int foundationValue = 0;
			int foundationShareValue = 0;
			int foundationStars = 0;
			int foundationSilver = 0;
			int day = 0;
			OnlineChallengeEvent.Event type = OnlineChallengeEvent.Event.Score;
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
						doctorCount = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 1:
						nurseCount = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 2:
						janitorCount = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 3:
						assistantCount = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 4:
						patientCount = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 5:
						balance = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 6:
						reputation = MessagePackBinary.ReadSingle(bytes, offset, out readSize);
						break;
					case 7:
						prestigeLevel = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 8:
						prestigeProgress = MessagePackBinary.ReadSingle(bytes, offset, out readSize);
						break;
					case 9:
						foundationValue = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 10:
						foundationShareValue = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 11:
						foundationStars = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 12:
						foundationSilver = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 13:
						day = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 14:
						type = formatterResolver.GetFormatterWithVerify<OnlineChallengeEvent.Event>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new OnlineChallengeEventHospitalStatus
			{
				DoctorCount = doctorCount,
				NurseCount = nurseCount,
				JanitorCount = janitorCount,
				AssistantCount = assistantCount,
				PatientCount = patientCount,
				Balance = balance,
				Reputation = reputation,
				PrestigeLevel = prestigeLevel,
				PrestigeProgress = prestigeProgress,
				FoundationValue = foundationValue,
				FoundationShareValue = foundationShareValue,
				FoundationStars = foundationStars,
				FoundationSilver = foundationSilver,
				Day = day,
				Type = type
			};
		}
	}
}
