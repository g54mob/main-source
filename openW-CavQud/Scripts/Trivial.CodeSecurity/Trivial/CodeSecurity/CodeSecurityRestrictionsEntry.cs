using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Trivial.CodeSecurity
{
	[Serializable]
	public class CodeSecurityRestrictionsEntry
	{
		[SerializeField]
		[HideInInspector]
		private CodeSecurityRestrictions.CodeSecurityBehaviour defaultBehaviour;

		[SerializeField]
		[HideInInspector]
		private List<string> allowEntries = new List<string>();

		[SerializeField]
		[HideInInspector]
		private List<string> denyEntries = new List<string>();

		public CodeSecurityRestrictions.CodeSecurityBehaviour DefaultBehaviour
		{
			get
			{
				return defaultBehaviour;
			}
			set
			{
				defaultBehaviour = value;
			}
		}

		public IList<string> AllowEntries => allowEntries;

		public IList<string> DenyEntries => denyEntries;

		public int RestrictionsHash
		{
			get
			{
				int num = 0x3F4D ^ defaultBehaviour.GetHashCode();
				int num2 = num | (num ^ allowEntries.GetHashCode());
				return num2 & (num2 ^ denyEntries.GetHashCode());
			}
		}

		public void AddNestedEntryName(string typeName, string entryName, CodeSecurityRestrictions.CodeSecurityBehaviour behaviour)
		{
			AddEntryName($"{typeName}.{entryName}", behaviour);
		}

		public void AddEntryName(string entryName, CodeSecurityRestrictions.CodeSecurityBehaviour behaviour)
		{
			switch (behaviour)
			{
			case CodeSecurityRestrictions.CodeSecurityBehaviour.Allow:
				if (!allowEntries.Contains(entryName))
				{
					allowEntries.Add(entryName);
				}
				break;
			case CodeSecurityRestrictions.CodeSecurityBehaviour.Deny:
				if (!denyEntries.Contains(entryName))
				{
					denyEntries.Add(entryName);
				}
				break;
			}
		}

		public bool IsAllowable(string entryName, bool ignoreCase, bool allowWildcard = false)
		{
			if (allowWildcard)
			{
				foreach (string allowEntry in allowEntries)
				{
					if (allowEntry.EndsWith(".*"))
					{
						if (string.Compare(allowEntry.Remove(allowEntry.Length - 2, 2), entryName, ignoreCase) == 0)
						{
							return true;
						}
					}
					else if (string.Compare(allowEntry, entryName, ignoreCase) == 0)
					{
						return true;
					}
				}
				foreach (string denyEntry in denyEntries)
				{
					if (denyEntry.EndsWith(".*"))
					{
						if (string.Compare(denyEntry.Remove(denyEntry.Length - 2, 2), entryName, ignoreCase) == 0)
						{
							return false;
						}
					}
					else if (string.Compare(denyEntry, entryName, ignoreCase) == 0)
					{
						return false;
					}
				}
			}
			else
			{
				if (allowEntries.Contains(entryName, StringComparer.OrdinalIgnoreCase))
				{
					return true;
				}
				if (denyEntries.Contains(entryName, StringComparer.OrdinalIgnoreCase))
				{
					return false;
				}
			}
			return defaultBehaviour == CodeSecurityRestrictions.CodeSecurityBehaviour.Allow;
		}
	}
}
