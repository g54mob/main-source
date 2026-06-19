using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Sentry.Extensibility;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public class SentryStackTrace : ISentryJsonSerializable
	{
		internal IList<SentryStackFrame>? InternalFrames { get; private set; }

		public IList<SentryStackFrame> Frames
		{
			get
			{
				return InternalFrames ?? (InternalFrames = new List<SentryStackFrame>());
			}
			set
			{
				InternalFrames = value;
			}
		}

		public InstructionAddressAdjustment? AddressAdjustment { get; set; }

		public void WriteTo(Utf8JsonWriter writer, IDiagnosticLogger? logger)
		{
			writer.WriteStartObject();
			writer.WriteArrayIfNotEmpty("frames", InternalFrames, logger);
			string text;
			string value;
			switch (AddressAdjustment)
			{
			case InstructionAddressAdjustment.Auto:
				text = "auto";
				goto IL_006e;
			case InstructionAddressAdjustment.All:
				text = "all";
				goto IL_006e;
			case InstructionAddressAdjustment.AllButFirst:
				text = "all_but_first";
				goto IL_006e;
			case InstructionAddressAdjustment.None:
				text = "none";
				goto IL_006e;
			default:
				text = "auto";
				goto IL_006e;
			case null:
				break;
				IL_006e:
				value = text;
				writer.WriteString("instruction_addr_adjustment", value);
				break;
			}
			writer.WriteEndObject();
		}

		public static SentryStackTrace FromJson(JsonElement json)
		{
			JsonElement? propertyOrNull = json.GetPropertyOrNull("frames");
			SentryStackFrame[] internalFrames = (propertyOrNull.HasValue ? propertyOrNull.GetValueOrDefault().EnumerateArray().Select(SentryStackFrame.FromJson)
				.ToArray() : null);
			InstructionAddressAdjustment? addressAdjustment = json.GetPropertyOrNull("instruction_addr_adjustment")?.ToString()?.ParseEnum<InstructionAddressAdjustment>();
			return new SentryStackTrace
			{
				InternalFrames = internalFrames,
				AddressAdjustment = addressAdjustment
			};
		}
	}
}
