using System;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

namespace DynamicCSharp.Security
{
	[Serializable]
	public sealed class ReferenceRestriction : Restriction
	{
		[SerializeField]
		private string referenceName = string.Empty;

		public string RestrictedName
		{
			get
			{
				return referenceName;
			}
		}

		public override string Message
		{
			get
			{
				return string.Format("The references assembly '{0}' is prohibited and cannot be referenced", referenceName);
			}
		}

		public override RestrictionMode Mode
		{
			get
			{
				return DynamicCSharp.Settings.assemblyRestrictionMode;
			}
		}

		public ReferenceRestriction(string referenceName)
		{
			this.referenceName = referenceName;
		}

		public override bool Verify(ModuleDefinition module)
		{
			if (string.IsNullOrEmpty(referenceName))
			{
				return true;
			}
			foreach (AssemblyNameReference item in (IEnumerable<AssemblyNameReference>)module.AssemblyReferences)
			{
				if (string.Compare(referenceName, item.Name + ".dll") == 0)
				{
					return false;
				}
			}
			return true;
		}
	}
}
