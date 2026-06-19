using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPCommands.Commands
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new SkippableCommand", menuName = "TMPEffects/Commands/Built-in/Skippable")]
	public class SkippableCommand : TMPCommand
	{
		private class AutoParametersData
		{
			public bool skippable;
		}

		[AutoParameter(true, "", new string[] { })]
		private bool skippable;

		public override TagType TagType => TagType.Index;

		public override bool ExecuteInstantly => false;

		public override bool ExecuteOnSkip => true;

		public override bool ExecuteRepeatable => true;

		private void ExecuteCommand(AutoParametersData data, ICommandContext context)
		{
			context.Writer.SetSkippable(data.skippable);
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
				if (TMPParameterUtility.TryGetBoolParameter(out var value, parameters, keywordDatabase, ""))
				{
					autoParametersData.skippable = value;
				}
			}
		}

		public override object GetNewCustomData()
		{
			return new AutoParametersData
			{
				skippable = skippable
			};
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return false;
			}
			if (!TMPParameterUtility.HasBoolParameter(parameters, keywordDatabase, ""))
			{
				return false;
			}
			return true;
		}
	}
}
