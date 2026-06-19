using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.Databases;
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

		[AutoParameter(true, null, new string[] { })]
		private bool skippable;

		public override TagType TagType => default(TagType);

		public override bool ExecuteInstantly => false;

		public override bool ExecuteOnSkip => false;

		public override bool ExecuteRepeatable => false;

		private void ExecuteCommand(AutoParametersData data, ICommandContext context)
		{
		}

		public override void ExecuteCommand(ICommandContext context)
		{
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
		}

		public override object GetNewCustomData()
		{
			return null;
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return false;
		}
	}
}
