using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.TMPCommands.Commands
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new ShowCommand", menuName = "TMPEffects/Commands/Built-in/Show")]
	public class ShowCommand : TMPCommand
	{
		private class AutoParametersData
		{
		}

		public override TagType TagType => TagType.Block;

		public override bool ExecuteInstantly => true;

		public override bool ExecuteOnSkip => false;

		public override bool ExecuteRepeatable => true;

		private void ExecuteCommand(AutoParametersData data, ICommandContext context)
		{
			context.Writer.Show(context.Indices.StartIndex, context.Indices.Length, skipShowProcess: true);
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
				_ = (AutoParametersData)customData;
			}
		}

		public override object GetNewCustomData()
		{
			return new AutoParametersData();
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return true;
		}
	}
}
