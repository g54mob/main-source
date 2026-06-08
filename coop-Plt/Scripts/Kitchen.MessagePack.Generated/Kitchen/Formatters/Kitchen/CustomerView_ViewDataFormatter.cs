using System;
using MessagePack;
using MessagePack.Formatters;
using UnityEngine;

namespace Kitchen.Formatters.Kitchen
{
	public sealed class CustomerView_ViewDataFormatter : IMessagePackFormatter<CustomerView.ViewData>, IMessagePackFormatter
	{
		public void Serialize(ref MessagePackWriter writer, CustomerView.ViewData value, MessagePackSerializerOptions options)
		{
			IFormatterResolver resolver = options.Resolver;
			writer.WriteArrayHeader(11);
			writer.Write(value.Scale);
			resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.SerializableMoveTarget, options);
			resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.SerializableDesiredFacing, options);
			writer.Write(value.IsMoving);
			writer.Write(value.StoppingDistance);
			writer.Write(value.IsPaused);
			resolver.GetFormatterWithVerify<CCustomerState.State>().Serialize(ref writer, value.State, options);
			writer.Write(value.Speed);
			resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.MoveTarget, options);
			resolver.GetFormatterWithVerify<Vector3>().Serialize(ref writer, value.DesiredFacing, options);
			writer.Write(value.HasLeftoversBag);
		}

		public CustomerView.ViewData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				throw new InvalidOperationException("typecode is null, struct not supported");
			}
			options.Security.DepthStep(ref reader);
			IFormatterResolver resolver = options.Resolver;
			int num = reader.ReadArrayHeader();
			CustomerView.ViewData result = default(CustomerView.ViewData);
			for (int i = 0; i < num; i++)
			{
				switch (i)
				{
				case 0:
					result.Scale = reader.ReadSingle();
					break;
				case 1:
					result.SerializableMoveTarget = resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
					break;
				case 2:
					result.SerializableDesiredFacing = resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
					break;
				case 3:
					result.IsMoving = reader.ReadBoolean();
					break;
				case 4:
					result.StoppingDistance = reader.ReadSingle();
					break;
				case 5:
					result.IsPaused = reader.ReadBoolean();
					break;
				case 6:
					result.State = resolver.GetFormatterWithVerify<CCustomerState.State>().Deserialize(ref reader, options);
					break;
				case 7:
					result.Speed = reader.ReadSingle();
					break;
				case 8:
					result.MoveTarget = resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
					break;
				case 9:
					result.DesiredFacing = resolver.GetFormatterWithVerify<Vector3>().Deserialize(ref reader, options);
					break;
				case 10:
					result.HasLeftoversBag = reader.ReadBoolean();
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
