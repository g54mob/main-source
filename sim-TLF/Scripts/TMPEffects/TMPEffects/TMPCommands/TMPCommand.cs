using System.Collections.Generic;
using TMPEffects.Databases;
using TMPEffects.ObjectChanged;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPCommands
{
	public abstract class TMPCommand : ScriptableObject, ITMPCommand, ITMPParameterValidator, INotifyObjectChanged
	{
		public abstract TagType TagType { get; }

		public abstract bool ExecuteInstantly { get; }

		public abstract bool ExecuteOnSkip { get; }

		public virtual bool ExecuteRepeatable => false;

		public event ObjectChangedEventHandler ObjectChanged;

		public abstract void ExecuteCommand(ICommandContext context);

		public abstract bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);

		public abstract void SetParameters(object obj, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase);

		public abstract object GetNewCustomData();

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
