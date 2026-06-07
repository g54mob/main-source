using System;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

namespace DynamicCSharp.Security
{
	[Serializable]
	public sealed class NamespaceRestriction : Restriction
	{
		public static HashSet<string> AlwaysAllowed = new HashSet<string>
		{
			"DebuggableAttribute", "DebuggableAttribute/DebuggingModes", "DebuggerHiddenAttribute", "DebuggerBrowsableState", "DebuggerBrowsableAttribute", "DebuggerDisplayAttribute", "DebuggerNonUserCodeAttribute", "DebuggerStepperBoundaryAttribute", "DebuggerStepThroughAttribute", "DebuggerTypeProxyAttribute",
			"DebuggerVisualizerAttribute", "AssemblyTitleAttribute", "AssemblyDescriptionAttribute", "AssemblyConfigurationAttribute", "AssemblyCompanyAttribute", "AssemblyProductAttribute", "AssemblyCopyrightAttribute", "AssemblyTrademarkAttribute", "AssemblyCultureAttribute", "AssemblyVersionAttribute",
			"AssemblyFileVersionAttribute"
		};

		[SerializeField]
		private string namespaceName = string.Empty;

		[NonSerialized]
		private string _referencedType = "N/A";

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
				return string.Format("The namespace '{0}' is prohibited and cannot be referenced in: '{1}'", namespaceName, _referencedType);
			}
		}

		public override RestrictionMode Mode
		{
			get
			{
				return DynamicCSharp.Settings.namespaceRestrictionMode;
			}
		}

		public NamespaceRestriction(string restrictedName)
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
				string strB = typeReference.Namespace;
				if (!AlwaysAllowed.Contains(typeReference.Name) && string.Compare(namespaceName, strB) == 0)
				{
					_referencedType = typeReference.FullName;
					return false;
				}
			}
			return true;
		}
	}
}
