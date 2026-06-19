using System.Collections.Generic;
using TMPEffects.Components;
using TMPEffects.Databases;
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

		public override TagType TagType => default(TagType);

		public override bool ExecuteInstantly => false;

		public override bool ExecuteOnSkip => false;

		public override bool ExecuteRepeatable => false;

		public override void ExecuteCommand(ICommandContext context)
		{
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return false;
		}

		public override object GetNewCustomData()
		{
			return null;
		}

		public override void SetParameters(object obj, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
		}
	}
}
