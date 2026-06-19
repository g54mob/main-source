using System;
using System.Collections.Generic;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class UserProfileDataFormatter : IMessagePackFormatter<UserProfileData>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public UserProfileDataFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "IsSandboxUnlocked", 0 },
				{ "HasSeenSandboxCutscene", 1 },
				{ "IsCollaborativeProjectsUnlocked", 2 },
				{ "HasSeenCollaborativeProjectCutscene", 3 },
				{ "SuperBugRewardRecord", 4 },
				{ "PrimeGamingEntitlements", 5 },
				{ "PrimeGamingRefreshToken", 6 },
				{ "PrimeGamingKudoshIDsClaimed", 7 },
				{ "FGWPUserID", 8 }
			};
			____stringByteKeys = new byte[9][]
			{
				MessagePackBinary.GetEncodedStringBytes("IsSandboxUnlocked"),
				MessagePackBinary.GetEncodedStringBytes("HasSeenSandboxCutscene"),
				MessagePackBinary.GetEncodedStringBytes("IsCollaborativeProjectsUnlocked"),
				MessagePackBinary.GetEncodedStringBytes("HasSeenCollaborativeProjectCutscene"),
				MessagePackBinary.GetEncodedStringBytes("SuperBugRewardRecord"),
				MessagePackBinary.GetEncodedStringBytes("PrimeGamingEntitlements"),
				MessagePackBinary.GetEncodedStringBytes("PrimeGamingRefreshToken"),
				MessagePackBinary.GetEncodedStringBytes("PrimeGamingKudoshIDsClaimed"),
				MessagePackBinary.GetEncodedStringBytes("FGWPUserID")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, UserProfileData value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 9);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.IsSandboxUnlocked);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.HasSeenSandboxCutscene);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[2]);
			offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.IsCollaborativeProjectsUnlocked);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[3]);
			offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.HasSeenCollaborativeProjectCutscene);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[4]);
			offset += formatterResolver.GetFormatterWithVerify<SuperBugRewardRecord>().Serialize(ref bytes, offset, value.SuperBugRewardRecord, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[5]);
			offset += formatterResolver.GetFormatterWithVerify<List<string>>().Serialize(ref bytes, offset, value.PrimeGamingEntitlements, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[6]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.PrimeGamingRefreshToken, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[7]);
			offset += formatterResolver.GetFormatterWithVerify<List<string>[]>().Serialize(ref bytes, offset, value.PrimeGamingKudoshIDsClaimed, formatterResolver);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[8]);
			offset += MessagePackBinary.WriteUInt64(ref bytes, offset, value.FGWPUserID);
			return offset - num;
		}

		public UserProfileData Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			bool isSandboxUnlocked = false;
			bool hasSeenSandboxCutscene = false;
			bool isCollaborativeProjectsUnlocked = false;
			bool hasSeenCollaborativeProjectCutscene = false;
			SuperBugRewardRecord superBugRewardRecord = null;
			List<string> primeGamingEntitlements = null;
			string primeGamingRefreshToken = null;
			List<string>[] primeGamingKudoshIDsClaimed = null;
			ulong fGWPUserID = 0uL;
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
						isSandboxUnlocked = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
						break;
					case 1:
						hasSeenSandboxCutscene = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
						break;
					case 2:
						isCollaborativeProjectsUnlocked = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
						break;
					case 3:
						hasSeenCollaborativeProjectCutscene = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
						break;
					case 4:
						superBugRewardRecord = formatterResolver.GetFormatterWithVerify<SuperBugRewardRecord>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 5:
						primeGamingEntitlements = formatterResolver.GetFormatterWithVerify<List<string>>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 6:
						primeGamingRefreshToken = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 7:
						primeGamingKudoshIDsClaimed = formatterResolver.GetFormatterWithVerify<List<string>[]>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					case 8:
						fGWPUserID = MessagePackBinary.ReadUInt64(bytes, offset, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new UserProfileData
			{
				IsSandboxUnlocked = isSandboxUnlocked,
				HasSeenSandboxCutscene = hasSeenSandboxCutscene,
				IsCollaborativeProjectsUnlocked = isCollaborativeProjectsUnlocked,
				HasSeenCollaborativeProjectCutscene = hasSeenCollaborativeProjectCutscene,
				SuperBugRewardRecord = superBugRewardRecord,
				PrimeGamingEntitlements = primeGamingEntitlements,
				PrimeGamingRefreshToken = primeGamingRefreshToken,
				PrimeGamingKudoshIDsClaimed = primeGamingKudoshIDsClaimed,
				FGWPUserID = fGWPUserID
			};
		}
	}
}
