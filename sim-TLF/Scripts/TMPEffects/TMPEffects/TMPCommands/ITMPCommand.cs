using System.Collections.Generic;
using TMPEffects.Databases;
using TMPEffects.Parameters;

namespace TMPEffects.TMPCommands
{
	public interface ITMPCommand : ITMPParameterValidator
	{
		TagType TagType { get; }

		bool ExecuteInstantly { get; }

		bool ExecuteOnSkip { get; }

		bool ExecuteRepeatable { get; }

		void ExecuteCommand(ICommandContext context);

		object GetNewCustomData();

		void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);
	}
}
