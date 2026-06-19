using System;
using System.Collections.Generic;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;
using UnityEngine.Events;

namespace TMPEffects.TMPCommands
{
	[Serializable]
	public struct TMPGenericSceneCommand : ITMPCommand, ITMPParameterValidator
	{
		private class ParameterContainer
		{
			public IDictionary<string, string> parameters;
		}

		[Tooltip("Whether tags of this command operate on a range (and therefore need to be closed) or on an index.")]
		[SerializeField]
		private TagType commandType;

		[Tooltip("Whether the command is executed instantly when the writer begins writing the text, regardless of its position within it.")]
		[SerializeField]
		private bool executeInstantly;

		[Tooltip("Whether the command should be executed when the tag's position is skipped by the writer. Check for essential commands, e.g. triggering a quest.")]
		[SerializeField]
		private bool executeOnSkip;

		[Tooltip("Whether the command should be allowed to be executed multiple times. Relevant for when the writer is reset while writing.")]
		[SerializeField]
		private bool executeRepeatable;

		[Tooltip("The methods to trigger.")]
		[SerializeField]
		private UnityEvent<IDictionary<string, string>, ICommandContext> command;

		public TagType TagType => commandType;

		public bool ExecuteInstantly => executeInstantly;

		public bool ExecuteOnSkip => executeOnSkip;

		public bool ExecuteRepeatable => executeRepeatable;

		public void ExecuteCommand(ICommandContext context)
		{
			IDictionary<string, string> parameters = ((ParameterContainer)context.CustomData).parameters;
			command?.Invoke(parameters, context);
		}

		public bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return true;
		}

		public object GetNewCustomData()
		{
			return new ParameterContainer();
		}

		public void SetParameters(object obj, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			((ParameterContainer)obj).parameters = parameters;
		}
	}
}
