using System;
using System.Collections.Generic;
using Gh.Tk.Story.Config;
using LitJson;

namespace Gh.Tk
{
	[GhTypeHintingAlias("Gh.Tk.SpawnPatron+PatronNeedData")]
	public class PatronNeedData : IPersistable, ICloneable
	{
		[JsonIgnore]
		private PatronNeedConfigNode _sourceNode;

		public string Need { get; private set; }

		public List<PatronSecondaryNeed> SecondaryNeeds { get; private set; }

		public bool IsOptional { get; set; }

		public string SourceId { get; private set; }

		public int TargetReputation { get; internal set; }

		protected PatronNeedData()
		{
		}

		public PatronNeedData(PatronNeedConfigNode source)
		{
		}

		public PatronNeedConfigNode GetSourceNode()
		{
			return null;
		}

		public object Clone()
		{
			return null;
		}
	}
}
