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
				return default(TMPSceneCommandType);
			}
			set
			{
			}
		}

		public TMPGenericSceneCommand Generic
		{
			get
			{
				return default(TMPGenericSceneCommand);
			}
			set
			{
			}
		}

		public TMPSceneCommand Custom
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private ITMPCommand BackingCommand => null;

		public TagType TagType => default(TagType);

		public bool ExecuteInstantly => false;

		public bool ExecuteOnSkip => false;

		public bool ExecuteRepeatable => false;

		public bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return false;
		}

		public void ExecuteCommand(ICommandContext context)
		{
		}

		public object GetNewCustomData()
		{
			return null;
		}

		public void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
		}
	}
}
