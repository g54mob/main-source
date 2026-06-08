using System.Collections.Generic;

namespace KitchenData
{
	public class StringSubstitutor
	{
		public Dictionary<string, string> PrioritySubstitutions = new Dictionary<string, string>();

		public Dictionary<string, string> Substitutions = new Dictionary<string, string>();

		public void Add(StringSubstitution sub)
		{
			foreach (KeyValuePair<string, string> item in sub.Active)
			{
				if (sub.IsPriority)
				{
					PrioritySubstitutions.Add(item.Key, item.Value);
				}
				else
				{
					Substitutions.Add(item.Key, item.Value);
				}
			}
		}

		public string Parse(string input)
		{
			if (input == null)
			{
				return "";
			}
			foreach (KeyValuePair<string, string> prioritySubstitution in PrioritySubstitutions)
			{
				input = input.Replace(prioritySubstitution.Key, prioritySubstitution.Value);
			}
			foreach (KeyValuePair<string, string> substitution in Substitutions)
			{
				input = input.Replace(substitution.Key, substitution.Value);
			}
			return input;
		}
	}
}
