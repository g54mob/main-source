using System;
using MessagePack.Internal;
using TH20;

namespace MessagePack.Formatters.TH20
{
	public sealed class CloudDataFormatter : IMessagePackFormatter<CloudData>, IMessagePackFormatter
	{
		private readonly AutomataDictionary ____keyMapping;

		private readonly byte[][] ____stringByteKeys;

		public CloudDataFormatter()
		{
			____keyMapping = new AutomataDictionary
			{
				{ "ShowCampusPromotion", 0 },
				{ "PrimePromotionAvailableForSignUp", 1 },
				{ "SteamCampusPreorderID", 2 },
				{ "MSStoreCampusPreorderID", 3 }
			};
			____stringByteKeys = new byte[4][]
			{
				MessagePackBinary.GetEncodedStringBytes("ShowCampusPromotion"),
				MessagePackBinary.GetEncodedStringBytes("PrimePromotionAvailableForSignUp"),
				MessagePackBinary.GetEncodedStringBytes("SteamCampusPreorderID"),
				MessagePackBinary.GetEncodedStringBytes("MSStoreCampusPreorderID")
			};
		}

		public int Serialize(ref byte[] bytes, int offset, CloudData value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = offset;
			offset += MessagePackBinary.WriteFixedMapHeaderUnsafe(ref bytes, offset, 4);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[0]);
			offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.ShowCampusPromotion);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[1]);
			offset += MessagePackBinary.WriteBoolean(ref bytes, offset, value.PrimePromotionAvailableForSignUp);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[2]);
			offset += MessagePackBinary.WriteInt32(ref bytes, offset, value.SteamCampusPreorderID);
			offset += MessagePackBinary.WriteRaw(ref bytes, offset, ____stringByteKeys[3]);
			offset += formatterResolver.GetFormatterWithVerify<string>().Serialize(ref bytes, offset, value.MSStoreCampusPreorderID, formatterResolver);
			return offset - num;
		}

		public CloudData Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			if (MessagePackBinary.IsNil(bytes, offset))
			{
				readSize = 1;
				return null;
			}
			int num = offset;
			int num2 = MessagePackBinary.ReadMapHeader(bytes, offset, out readSize);
			offset += readSize;
			bool showCampusPromotion = false;
			bool primePromotionAvailableForSignUp = false;
			int steamCampusPreorderID = 0;
			string mSStoreCampusPreorderID = null;
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
						showCampusPromotion = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
						break;
					case 1:
						primePromotionAvailableForSignUp = MessagePackBinary.ReadBoolean(bytes, offset, out readSize);
						break;
					case 2:
						steamCampusPreorderID = MessagePackBinary.ReadInt32(bytes, offset, out readSize);
						break;
					case 3:
						mSStoreCampusPreorderID = formatterResolver.GetFormatterWithVerify<string>().Deserialize(bytes, offset, formatterResolver, out readSize);
						break;
					default:
						readSize = MessagePackBinary.ReadNextBlock(bytes, offset);
						break;
					}
				}
				offset += readSize;
			}
			readSize = offset - num;
			return new CloudData
			{
				ShowCampusPromotion = showCampusPromotion,
				PrimePromotionAvailableForSignUp = primePromotionAvailableForSignUp,
				SteamCampusPreorderID = steamCampusPreorderID,
				MSStoreCampusPreorderID = mSStoreCampusPreorderID
			};
		}
	}
}
