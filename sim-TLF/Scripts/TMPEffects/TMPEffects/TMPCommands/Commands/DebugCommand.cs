using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPCommands.Commands
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new DebugCommand", menuName = "TMPEffects/Commands/Built-in/Debug")]
	public class DebugCommand : TMPCommand
	{
		private class AutoParametersData
		{
			public string type;

			public string message;
		}

		[AutoParameter("type", new string[] { })]
		private string type;

		[AutoParameter(true, "", new string[] { })]
		private string message;

		public override TagType TagType => TagType.Index;

		public override bool ExecuteInstantly => false;

		public override bool ExecuteOnSkip => true;

		public override bool ExecuteRepeatable => true;

		private void ExecuteCommand(AutoParametersData data, ICommandContext context)
		{
			if (data.type == "")
			{
				Debug.Log(data.message);
				return;
			}
			switch (data.type)
			{
			case "w":
			case "warning":
				Debug.LogWarning(message);
				break;
			case "e":
			case "error":
				Debug.LogError(message);
				break;
			default:
				Debug.Log(message);
				break;
			}
		}

		public override void ExecuteCommand(ICommandContext context)
		{
			AutoParametersData data = (AutoParametersData)context.CustomData;
			ExecuteCommand(data, context);
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData autoParametersData = (AutoParametersData)customData;
				if (TMPParameterUtility.TryGetDefinedParameter(out var value, parameters, "type"))
				{
					autoParametersData.type = value;
				}
				if (TMPParameterUtility.TryGetDefinedParameter(out var value2, parameters, ""))
				{
					autoParametersData.message = value2;
				}
			}
		}

		public override object GetNewCustomData()
		{
			return new AutoParametersData
			{
				type = type,
				message = message
			};
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return false;
			}
			if (TMPParameterUtility.ParameterDefined(parameters, ""))
			{
				return false;
			}
			return true;
		}
	}
}
