using System;
using System.Collections.Generic;
using TMPEffects.Components;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPCommands.Commands
{
	[CreateAssetMenu(fileName = "new DelayCommand", menuName = "TMPEffects/Commands/Built-in/Delay")]
	public class DelayCommand : TMPCommand
	{
		private class Data
		{
			public float delay;

			public TMPWriter.DelayType delayType;

			public string methodIdentifier;
		}

		public override TagType TagType => TagType.Index;

		public override bool ExecuteInstantly => false;

		public override bool ExecuteOnSkip => true;

		public override bool ExecuteRepeatable => true;

		public override void ExecuteCommand(ICommandContext context)
		{
			TMPWriter writer = context.Writer;
			Data data = (Data)context.CustomData;
			if (string.IsNullOrWhiteSpace(data.methodIdentifier))
			{
				if (data.delay == -1f)
				{
					writer.CurrentDelays.SetDelay(writer.DefaultDelays.delay);
				}
				else
				{
					writer.CurrentDelays.SetDelay(data.delay);
				}
				return;
			}
			switch (data.methodIdentifier)
			{
			case "whitespace":
			case "ws":
				if (data.delay == -1f)
				{
					writer.CurrentDelays.SetWhitespaceDelay(writer.DefaultDelays.whitespaceDelay, writer.DefaultDelays.whitespaceDelayType);
				}
				else
				{
					writer.CurrentDelays.SetWhitespaceDelay(data.delay, data.delayType);
				}
				break;
			case "linebreak":
			case "linebr":
			case "br":
				if (data.delay == -1f)
				{
					writer.CurrentDelays.SetLinebreakDelay(writer.DefaultDelays.linebreakDelay, writer.DefaultDelays.linebreakDelayType);
				}
				else
				{
					writer.CurrentDelays.SetLinebreakDelay(data.delay, data.delayType);
				}
				break;
			case "punctuation":
			case "punct":
				if (data.delay == -1f)
				{
					writer.CurrentDelays.SetPunctuationDelay(writer.DefaultDelays.punctuationDelay, writer.DefaultDelays.punctuationDelayType);
				}
				else
				{
					writer.CurrentDelays.SetPunctuationDelay(data.delay, data.delayType);
				}
				break;
			case "visible":
			case "vis":
				if (data.delay == -1f)
				{
					writer.CurrentDelays.SetVisibleDelay(writer.DefaultDelays.visibleDelay, writer.DefaultDelays.visibleDelayType);
				}
				else
				{
					writer.CurrentDelays.SetVisibleDelay(data.delay, data.delayType);
				}
				break;
			default:
				throw new InvalidOperationException();
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return false;
			}
			if (!parameters.ContainsKey(""))
			{
				return false;
			}
			if (TMPParameterUtility.TryGetDefinedParameter(out var value, parameters, "for"))
			{
				switch (parameters[value])
				{
				default:
					return false;
				case "whitespace":
				case "ws":
				case "linebreak":
				case "linebr":
				case "br":
				case "punctuation":
				case "punct":
				case "visible":
				case "vis":
					break;
				}
				if (TMPParameterUtility.TryGetDefinedParameter(out value, parameters, "type"))
				{
					switch (parameters[value])
					{
					default:
						return false;
					case "raw":
					case "percentage":
					case "pct":
					case "%":
						break;
					}
				}
			}
			if (!TMPParameterUtility.HasFloatParameter(parameters, keywordDatabase, "") && !(parameters[""] == ""))
			{
				return parameters[""] == "default";
			}
			return true;
		}

		public override object GetNewCustomData()
		{
			return new Data();
		}

		public override void SetParameters(object obj, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			Data data = (Data)obj;
			float value = -1f;
			TMPWriter.DelayType delayType = TMPWriter.DelayType.Raw;
			if (!TMPParameterUtility.TryGetFloatParameter(out value, parameters, keywordDatabase, ""))
			{
				if (!(parameters[""] == "") && !(parameters[""] == "default"))
				{
					throw new InvalidOperationException();
				}
				value = -1f;
			}
			if (TMPParameterUtility.TryGetDefinedParameter(out var value2, parameters, "for"))
			{
				if (!TMPParameterUtility.TryGetDefinedParameter(out var value3, parameters, "type"))
				{
					delayType = TMPWriter.DelayType.Raw;
				}
				else
				{
					switch (parameters[value3])
					{
					case "raw":
						delayType = TMPWriter.DelayType.Raw;
						break;
					case "percentage":
					case "pct":
					case "%":
						delayType = TMPWriter.DelayType.Percentage;
						break;
					default:
						delayType = TMPWriter.DelayType.Raw;
						break;
					}
				}
				data.methodIdentifier = parameters[value2];
			}
			data.delay = value;
			data.delayType = delayType;
		}
	}
}
