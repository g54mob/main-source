using System.Collections.Generic;
using TMPEffects.Databases;
using TMPEffects.ObjectChanged;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPCommands
{
	public abstract class TMPSceneCommand : MonoBehaviour, ITMPCommand, ITMPParameterValidator, INotifyObjectChanged
	{
		public abstract TagType TagType { get; }

		public abstract bool ExecuteInstantly { get; }

		public abstract bool ExecuteOnSkip { get; }

		public abstract bool ExecuteRepeatable { get; }

		public event ObjectChangedEventHandler ObjectChanged;

		public abstract bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);

		public abstract void ExecuteCommand(ICommandContext context);

		public abstract object GetNewCustomData();

		public abstract void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);

		protected virtual void OnValidate()
		{
			RaiseObjectChanged();
		}

		protected virtual void OnDestroy()
		{
			RaiseObjectChanged();
		}

		protected void RaiseObjectChanged()
		{
			this.ObjectChanged?.Invoke(this);
		}
	}
}
