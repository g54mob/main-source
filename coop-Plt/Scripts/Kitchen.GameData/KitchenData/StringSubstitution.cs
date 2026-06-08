using System.Collections.Generic;
using UnityEngine;

namespace KitchenData
{
	[CreateAssetMenu(menuName = "Kitchen/Strings/Substitution", fileName = "StringSubstitution", order = 0)]
	public class StringSubstitution : KitchenObject
	{
		public Dictionary<string, string> Substitutions = new Dictionary<string, string>();

		public virtual bool IsPriority => false;

		public virtual Dictionary<string, string> Active => Substitutions;

		public void AddEscape()
		{
			Substitutions.Add("\\n", "\n");
		}
	}
}
