using System.Collections.Generic;
using CTS;
using CTS.BBT.AI;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "_tags" })]
	public class ES3UserType_AgentTags : ES3Type
	{
		public static ES3Type Instance;

		public ES3UserType_AgentTags()
			: base(typeof(AgentTags))
		{
			Instance = this;
			priority = 1;
		}

		public override void Write(object obj, ES3Writer writer)
		{
			AgentTags agentTags = (AgentTags)obj;
			writer.WritePrivateField("_tags", agentTags);
		}

		public override object Read<T>(ES3Reader reader)
		{
			AgentTags agentTags = default(AgentTags);
			string text;
			while ((text = reader.ReadPropertyName()) != null)
			{
				if (text == "_tags")
				{
					agentTags = (AgentTags)reader.SetPrivateField("_tags", reader.Read<HashSet<EAgentTag>>(), agentTags);
				}
				else
				{
					reader.Skip();
				}
			}
			return agentTags;
		}
	}
}
