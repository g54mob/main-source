using System;
using System.Collections.Generic;
using MessagePack;
using MessagePack.Formatters;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class UnlockSelectPopupView_ViewDataFormatter : IMessagePackFormatter<UnlockSelectPopupView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, UnlockSelectPopupView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(7);
			resolver.GetFormatterWithVerify<List<PlayerInputData>>().Serialize(ref writer, value.Inputs, options);
			resolver.GetFormatterWithVerify<int[]>().Serialize(ref writer, value.Unlocks, options);
			resolver.GetFormatterWithVerify<int[]>().Serialize(ref writer, value.TwitchVotes, options);
			writer.Write(value.VoteComplete);
			writer.Write(value.VoteIsForced);
			writer.Write(value.PollProgress);
			resolver.GetFormatterWithVerify<UnlockRewardType>().Serialize(ref writer, value.Type, options);
		}

		public UnlockSelectPopupView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			UnlockSelectPopupView.ViewData result = default(UnlockSelectPopupView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Inputs = resolver.GetFormatterWithVerify<List<PlayerInputData>>().Deserialize(ref reader, options);
					break;
				case 1:
					result.Unlocks = resolver.GetFormatterWithVerify<int[]>().Deserialize(ref reader, options);
					break;
				case 2:
					result.TwitchVotes = resolver.GetFormatterWithVerify<int[]>().Deserialize(ref reader, options);
					break;
				case 3:
					result.VoteComplete = reader.ReadBoolean();
					break;
				case 4:
					result.VoteIsForced = reader.ReadBoolean();
					break;
				case 5:
					result.PollProgress = reader.ReadSingle();
					break;
				case 6:
					result.Type = resolver.GetFormatterWithVerify<UnlockRewardType>().Deserialize(ref reader, options);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			reader.Depth--;
			return result;
		}
	}
}
