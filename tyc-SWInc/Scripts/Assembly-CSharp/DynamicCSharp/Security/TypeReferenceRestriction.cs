using System;
using Mono.Cecil;
using UnityEngine;

namespace DynamicCSharp.Security
{
	[Serializable]
	public sealed class TypeReferenceRestriction : Restriction
	{
		[SerializeField]
		private string namespaceName = string.Empty;

		private RestrictionMode _mode;

		public string RestrictedNamespace
		{
			get
			{
				return namespaceName;
			}
		}

		public override string Message
		{
			get
			{
				return string.Format("The type '{0}' is prohibited and cannot be referenced", namespaceName);
			}
		}

		public override RestrictionMode Mode
		{
			get
			{
				return DynamicCSharp.Settings.typeReferenceRestrictionMode;
			}
		}

		public TypeReferenceRestriction(string restrictedName)
		{
			namespaceName = restrictedName;
		}

		public override bool Verify(ModuleDefinition module)
		{
			if (string.IsNullOrEmpty(namespaceName))
			{
				return true;
			}
			foreach (TypeReference typeReference in module.GetTypeReferences())
			{
				if (typeReference.FullName.StartsWith(namespaceName))
				{
					return false;
				}
			}
			return true;
		}
	}
}
