using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPCommands.Commands
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new WaitCommand", menuName = "TMPEffects/Commands/Built-in/Wait")]
	public class WaitCommand : TMPCommand
	{
		private class AutoParametersData
		{
			public float waitTime;
		}

		[AutoParameter(true, "", new string[] { })]
		private float waitTime;

		public override TagType TagType => TagType.Index;

		public override bool ExecuteInstantly => false;

		public override bool ExecuteOnSkip => false;

		public override bool ExecuteRepeatable => true;

		private void ExecuteCommand(AutoParametersData data, ICommandContext context)
		{
			context.Writer.Wait(data.waitTime);
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
				if (TMPParameterUtility.TryGetFloatParameter(out var value, parameters, keywordDatabase, ""))
				{
					autoParametersData.waitTime = value;
				}
			}
		}

		public override object GetNewCustomData()
		{
			return new AutoParametersData
			{
				waitTime = waitTime
			};
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return false;
			}
			if (!TMPParameterUtility.HasFloatParameter(parameters, keywordDatabase, ""))
			{
				return false;
			}
			return true;
		}
	}
}
