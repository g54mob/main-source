using System;
using System.Collections.Generic;
using SimulationScripts.BibiteScripts;
using Utility;

namespace ScriptHelpers
{
	public class VersionBrainChange
	{
		public Utility.Version version;

		public bool canBeUpdatedFromOlderVersion = true;

		public NodeChanges[] addedInputs;

		public NodeChanges[] removedInputs;

		public NodeChanges[] addedOutputs;

		public NodeChanges[] removedOutputs;

		public Action<List<NEATBrain.Node>, List<NEATBrain.Synaps>> updateBeforeFunction;

		public Action<List<NEATBrain.Node>, List<NEATBrain.Synaps>> updateAfterFunction;

		public Action<List<NEATBrain.Node>, List<NEATBrain.Synaps>> updateAtEndFunction;

		public Action<BibiteTemplate> updateTemplateFunction;

		public bool anyChanges
		{
			get
			{
				if (addedInputs.Length + addedOutputs.Length + removedInputs.Length + removedOutputs.Length <= 0 && updateAfterFunction == null && updateBeforeFunction == null)
				{
					return updateAtEndFunction != null;
				}
				return true;
			}
		}
	}
}
