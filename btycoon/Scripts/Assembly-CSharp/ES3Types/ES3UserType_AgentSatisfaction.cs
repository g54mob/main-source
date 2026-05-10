using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_AgentSatisfaction : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_AgentSatisfaction()
			: base(typeof(AgentSatisfaction))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			AgentSatisfaction objectContainingField = (AgentSatisfaction)obj;
			writer.WritePrivateField("_currentModifiers", objectContainingField);
			writer.WritePrivateField("_rawSatisfaction", objectContainingField);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			AgentSatisfaction objectContainingField = (AgentSatisfaction)obj;
			foreach (string property in reader.Properties)
			{
				if (!(property == "_currentModifiers"))
				{
					if (property == "_rawSatisfaction")
					{
						objectContainingField = (AgentSatisfaction)reader.SetPrivateField("_rawSatisfaction", reader.Read<int>(), objectContainingField);
					}
					else
					{
						reader.Skip();
					}
				}
				else
				{
					objectContainingField = (AgentSatisfaction)reader.SetPrivateField("_currentModifiers", reader.Read<Dictionary<StringKey, int>>(), objectContainingField);
				}
			}
		}
	}
}
