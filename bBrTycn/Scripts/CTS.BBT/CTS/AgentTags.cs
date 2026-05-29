using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS
{
	public struct AgentTags
	{
		private HashSet<EAgentTag> _tags;

		public static AgentTags Default => new AgentTags
		{
			_tags = new HashSet<EAgentTag>()
		};

		public bool HasTag(EAgentTag p_tag)
		{
			return _tags.Contains(p_tag);
		}

		public bool HasOneOfTags(EAgentTag[] tags)
		{
			foreach (EAgentTag p_tag in tags)
			{
				if (HasTag(p_tag))
				{
					return true;
				}
			}
			return false;
		}

		public void AddTag(EAgentTag p_tag)
		{
			_tags.Add(p_tag);
		}

		public void RemoveTag(EAgentTag p_tag)
		{
			_tags.Remove(p_tag);
		}

		public void Clear()
		{
			_tags.Clear();
		}
	}
}
