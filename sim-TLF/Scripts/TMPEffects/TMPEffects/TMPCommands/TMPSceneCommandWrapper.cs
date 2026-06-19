using System;
using System.Collections.Generic;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPCommands
{
	[Serializable]
	public struct TMPSceneCommandWrapper : ITMPCommand, ITMPParameterValidator
	{
		[Serializable]
		public enum TMPSceneCommandType
		{
			Custom = 0,
			Generic = 1
		}

		[SerializeField]
		private TMPSceneCommandType type;

		[SerializeField]
		private TMPGenericSceneCommand generic;

		[SerializeField]
		private TMPSceneCommand custom;

		public TMPSceneCommandType Type
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
			}
		}

		public TMPGenericSceneCommand Generic
		{
			get
			{
				return generic;
			}
			set
			{
				generic = value;
			}
		}

		public TMPSceneCommand Custom
		{
			get
			{
				return custom;
			}
			set
			{
				custom = value;
			}
		}

		private ITMPCommand BackingCommand
		{
			get
			{
				if (type != TMPSceneCommandType.Custom)
				{
					return generic;
				}
				return custom;
			}
		}

		public TagType TagType => BackingCommand.TagType;

		public bool ExecuteInstantly => BackingCommand.ExecuteInstantly;

		public bool ExecuteOnSkip => BackingCommand.ExecuteOnSkip;

		public bool ExecuteRepeatable => BackingCommand.ExecuteRepeatable;

		public bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return BackingCommand.ValidateParameters(parameters, keywordDatabase);
		}

		public void ExecuteCommand(ICommandContext context)
		{
			BackingCommand.ExecuteCommand(context);
		}

		public object GetNewCustomData()
		{
			return BackingCommand.GetNewCustomData();
		}

		public void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			BackingCommand.SetParameters(customData, parameters, keywordDatabase);
		}
	}
}
