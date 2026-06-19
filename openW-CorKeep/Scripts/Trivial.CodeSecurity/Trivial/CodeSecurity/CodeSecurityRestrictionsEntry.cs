using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
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

		[SerializeField]
		[HideInInspector]
		private bool useRegexMatch;

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

		public bool UseRegexMatch
		{
			get
			{
				return useRegexMatch;
			}
			set
			{
				useRegexMatch = value;
			}
		}

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
			bool isEntryListed;
			return IsAllowable(entryName, ignoreCase, out isEntryListed, allowWildcard);
		}

		public bool IsAllowable(string entryName, bool ignoreCase, out bool isEntryListed, bool allowWildcard = false)
		{
			if (allowWildcard || useRegexMatch)
			{
				foreach (string allowEntry in allowEntries)
				{
					if (useRegexMatch)
					{
						Match match = Regex.Match(entryName, allowEntry);
						if (match.Success && match.Value == entryName)
						{
							isEntryListed = true;
							return true;
						}
					}
					else if (allowEntry.EndsWith(".*"))
					{
						string text = allowEntry.Remove(allowEntry.Length - 2, 2);
						if (string.Compare(text, entryName, ignoreCase) == 0 || entryName.StartsWith(text, ignoreCase, CultureInfo.CurrentCulture))
						{
							isEntryListed = true;
							return true;
						}
					}
					else if (string.Compare(allowEntry, entryName, ignoreCase) == 0)
					{
						isEntryListed = true;
						return true;
					}
				}
				foreach (string denyEntry in denyEntries)
				{
					if (useRegexMatch)
					{
						Match match2 = Regex.Match(entryName, denyEntry);
						if (match2.Success && match2.Value == entryName)
						{
							isEntryListed = true;
							return false;
						}
					}
					else if (denyEntry.EndsWith(".*"))
					{
						string text2 = denyEntry.Remove(denyEntry.Length - 2, 2);
						if (string.Compare(text2, entryName, ignoreCase) == 0 || entryName.StartsWith(text2, ignoreCase, CultureInfo.CurrentCulture))
						{
							isEntryListed = true;
							return false;
						}
					}
					else if (string.Compare(denyEntry, entryName, ignoreCase) == 0)
					{
						isEntryListed = true;
						return false;
					}
				}
			}
			else
			{
				if (allowEntries.Contains(entryName, StringComparer.OrdinalIgnoreCase))
				{
					isEntryListed = true;
					return true;
				}
				if (denyEntries.Contains(entryName, StringComparer.OrdinalIgnoreCase))
				{
					isEntryListed = true;
					return false;
				}
			}
			isEntryListed = false;
			return defaultBehaviour == CodeSecurityRestrictions.CodeSecurityBehaviour.Allow;
		}
	}
}
