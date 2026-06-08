using System;
using Controllers;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Controllers
{
	public sealed class InputStateFormatter : IMessagePackFormatter<InputState>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, InputState value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(15);
			writer.WriteNil();
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.InteractAction, options);
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.GrabAction, options);
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.SecondaryAction1, options);
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.SecondaryAction2, options);
			resolver.GetFormatterWithVerify<Vector2>().Serialize(ref writer, value.Movement, options);
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.StopMoving, options);
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.MenuTrigger, options);
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.MenuUp, options);
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.MenuDown, options);
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.MenuLeft, options);
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.MenuRight, options);
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.MenuSelect, options);
			resolver.GetFormatterWithVerify<ButtonState>().Serialize(ref writer, value.MenuCancel, options);
			resolver.GetFormatterWithVerify<GameStateRequest>().Serialize(ref writer, value.Request, options);
		}

		public InputState Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			InputState result = default(InputState);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 1:
					result.InteractAction = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 2:
					result.GrabAction = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 3:
					result.SecondaryAction1 = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 4:
					result.SecondaryAction2 = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 5:
					result.Movement = resolver.GetFormatterWithVerify<Vector2>().Deserialize(ref reader, options);
					break;
				case 6:
					result.StopMoving = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 7:
					result.MenuTrigger = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 8:
					result.MenuUp = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 9:
					result.MenuDown = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 10:
					result.MenuLeft = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 11:
					result.MenuRight = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 12:
					result.MenuSelect = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 13:
					result.MenuCancel = resolver.GetFormatterWithVerify<ButtonState>().Deserialize(ref reader, options);
					break;
				case 14:
					result.Request = resolver.GetFormatterWithVerify<GameStateRequest>().Deserialize(ref reader, options);
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
