using System.Collections.Generic;
using System.Text;
using Trivial.Mono.Cecil;

namespace Trivial.CodeSecurity
{
	public class CodeSecurityReport
	{
		private AssemblyDefinition checkAssembly;

		private CodeSecurityRestrictions restrictionsUsed;

		private List<IllegalAssemblyReference> illegalAssemblyReferences = new List<IllegalAssemblyReference>();

		private List<IllegalNamespaceReference> illegalNamespaceReferences = new List<IllegalNamespaceReference>();

		private List<IllegalTypeReference> illegalTypeReferences = new List<IllegalTypeReference>();

		private List<IllegalMemberReference> illegalMemberReferences = new List<IllegalMemberReference>();

		private List<IllegalPInvoke> illegalPInvokes = new List<IllegalPInvoke>();

		public AssemblyDefinition CheckAssembly => checkAssembly;

		public CodeSecurityRestrictions RestrictionsUsed => restrictionsUsed;

		public ICollection<IllegalAssemblyReference> IllegalAssemblyReferences => illegalAssemblyReferences;

		public ICollection<IllegalNamespaceReference> IllegalNamespaceReferences => illegalNamespaceReferences;

		public ICollection<IllegalTypeReference> IllegalTypeReferences => illegalTypeReferences;

		public ICollection<IllegalMemberReference> IllegalMemberReferences => illegalMemberReferences;

		public ICollection<IllegalPInvoke> IllegalPInvokes => illegalPInvokes;

		public bool IsAssemblyReferencesSecurityVerified => illegalAssemblyReferences.Count == 0;

		public bool IsNamespaceReferencesSecurityVerified => illegalNamespaceReferences.Count == 0;

		public bool IsTypeReferencesSecurityVerified => illegalTypeReferences.Count == 0;

		public bool IsMemberReferencesSecurityVerified => illegalMemberReferences.Count == 0;

		public bool IsPInvokeSecurityVerified => illegalPInvokes.Count == 0;

		public bool IsSecurityVerified
		{
			get
			{
				if (illegalAssemblyReferences.Count == 0 && illegalNamespaceReferences.Count == 0 && illegalTypeReferences.Count == 0 && illegalMemberReferences.Count == 0 && illegalPInvokes.Count == 0)
				{
					return true;
				}
				return false;
			}
		}

		internal CodeSecurityReport(AssemblyDefinition definition, CodeSecurityRestrictions restrictions)
		{
			checkAssembly = definition;
			restrictionsUsed = restrictions;
		}

		public IEnumerable<CodeSecurityReportEntry> GetAllEntries(bool reportAllOccurences)
		{
			if (!IsAssemblyReferencesSecurityVerified)
			{
				foreach (IllegalAssemblyReference assemblyReference in illegalAssemblyReferences)
				{
					yield return new CodeSecurityReportEntry(CodeSecurityReportEntry.ReportEntryType.IllegalAssembly, CodeSecurityLocation.defaultLocation, assemblyReference.ToString());
					if (reportAllOccurences)
					{
						yield return new CodeSecurityReportEntry(CodeSecurityReportEntry.ReportEntryType.IllegalOccurence, CodeSecurityLocation.defaultLocation, assemblyReference.IllegalUsage.ToString());
					}
				}
			}
			if (!IsNamespaceReferencesSecurityVerified)
			{
				foreach (IllegalNamespaceReference namespaceReference in illegalNamespaceReferences)
				{
					yield return new CodeSecurityReportEntry(CodeSecurityReportEntry.ReportEntryType.IllegalNamespace, CodeSecurityLocation.defaultLocation, namespaceReference.ToString());
					if (!reportAllOccurences)
					{
						continue;
					}
					foreach (IllegalReferenceUsage referenceUsage in namespaceReference.ReferenceUsages)
					{
						yield return new CodeSecurityReportEntry(CodeSecurityReportEntry.ReportEntryType.IllegalOccurence, referenceUsage.GetUsageLocation(), referenceUsage.ToString());
					}
				}
			}
			if (!IsTypeReferencesSecurityVerified)
			{
				foreach (IllegalTypeReference typeReference in illegalTypeReferences)
				{
					yield return new CodeSecurityReportEntry(CodeSecurityReportEntry.ReportEntryType.IllegalType, CodeSecurityLocation.defaultLocation, typeReference.ToString());
					if (!reportAllOccurences)
					{
						continue;
					}
					foreach (IllegalReferenceUsage referenceUsage2 in typeReference.ReferenceUsages)
					{
						yield return new CodeSecurityReportEntry(CodeSecurityReportEntry.ReportEntryType.IllegalOccurence, referenceUsage2.GetUsageLocation(), referenceUsage2.ToString());
					}
				}
			}
			if (!IsMemberReferencesSecurityVerified)
			{
				foreach (IllegalMemberReference memberReference in illegalMemberReferences)
				{
					yield return new CodeSecurityReportEntry(CodeSecurityReportEntry.ReportEntryType.IllegalMember, CodeSecurityLocation.defaultLocation, memberReference.ToString());
					if (!reportAllOccurences)
					{
						continue;
					}
					foreach (IllegalReferenceUsage referenceUsage3 in memberReference.ReferenceUsages)
					{
						yield return new CodeSecurityReportEntry(CodeSecurityReportEntry.ReportEntryType.IllegalOccurence, referenceUsage3.GetUsageLocation(), referenceUsage3.ToString());
					}
				}
			}
			if (IsPInvokeSecurityVerified)
			{
				yield break;
			}
			foreach (IllegalPInvoke pInvokeReference in illegalPInvokes)
			{
				yield return new CodeSecurityReportEntry(CodeSecurityReportEntry.ReportEntryType.IllegalPInvoke, CodeSecurityLocation.defaultLocation, pInvokeReference.ToString());
				if (!reportAllOccurences)
				{
					continue;
				}
				foreach (IllegalReferenceUsage referenceUsage4 in pInvokeReference.ReferenceUsages)
				{
					yield return new CodeSecurityReportEntry(CodeSecurityReportEntry.ReportEntryType.IllegalOccurence, referenceUsage4.GetUsageLocation(), referenceUsage4.ToString());
				}
			}
		}

		public string[] GetAllLines(bool reportAllOccurences)
		{
			List<string> list = new List<string>();
			foreach (CodeSecurityReportEntry allEntry in GetAllEntries(reportAllOccurences))
			{
				if (allEntry.EntryType == CodeSecurityReportEntry.ReportEntryType.IllegalOccurence && reportAllOccurences)
				{
					list.Add("\t" + allEntry.Message);
				}
				else
				{
					list.Add(allEntry.Message);
				}
			}
			return list.ToArray();
		}

		public string GetAllText(bool reportAllOccurences)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (CodeSecurityReportEntry allEntry in GetAllEntries(reportAllOccurences))
			{
				if (allEntry.EntryType == CodeSecurityReportEntry.ReportEntryType.IllegalOccurence && reportAllOccurences)
				{
					stringBuilder.Append('\t');
					stringBuilder.AppendLine(allEntry.Message);
				}
				else
				{
					stringBuilder.AppendLine(allEntry.Message);
				}
			}
			return stringBuilder.ToString();
		}

		public string GetSummaryText()
		{
			if (!IsSecurityVerified)
			{
				return $"Assembly '{checkAssembly}' has failed code security verification. Illegal Assembly Reference = '{illegalAssemblyReferences.Count}', Illegal Namespace References = '{illegalNamespaceReferences.Count}', Illegal Type References = '{illegalTypeReferences.Count}', Illegal Member References = '{illegalMemberReferences.Count}', Illegal PInvoke References = '{illegalPInvokes.Count}'";
			}
			return $"Assembly '{checkAssembly}' has passed code security verification";
		}

		internal void AddIllegalAssemblyReferenceOccurence(AssemblyNameReference assemblyReference, ModuleDefinition module)
		{
			illegalAssemblyReferences.Add(new IllegalAssemblyReference(assemblyReference, module));
		}

		internal void AddIllegalNamespaceReferenceOccurence(string namespaceReference, TypeReference illegalIndirectType, IllegalReferenceUsage illegalReferenceUsage)
		{
			foreach (IllegalNamespaceReference illegalNamespaceReference in illegalNamespaceReferences)
			{
				if (illegalNamespaceReference.ReferencedNamespace == namespaceReference)
				{
					illegalNamespaceReference.AddIllegalNamespaceUsage(illegalIndirectType, illegalReferenceUsage);
					return;
				}
			}
			illegalNamespaceReferences.Add(new IllegalNamespaceReference(namespaceReference, illegalIndirectType, illegalReferenceUsage));
		}

		internal void AddIllegalTypeReferenceOccurence(TypeReference typeReference, IllegalReferenceUsage illegalReferenceUsage)
		{
			foreach (IllegalTypeReference illegalTypeReference in illegalTypeReferences)
			{
				if (illegalTypeReference.ReferencedType == typeReference)
				{
					illegalTypeReference.AddIllegalReferenceUsage(illegalReferenceUsage);
					return;
				}
			}
			illegalTypeReferences.Add(new IllegalTypeReference(typeReference, illegalReferenceUsage));
		}

		internal void AddIllegalMemberReferenceOccurence(MemberReference memberReference, IllegalReferenceUsage illegalReferenceUsage, bool indirect)
		{
			foreach (IllegalMemberReference illegalMemberReference in illegalMemberReferences)
			{
				if (illegalMemberReference.ReferencedMember == memberReference)
				{
					illegalMemberReference.AddIllegalReferenceUsage(illegalReferenceUsage);
					return;
				}
			}
			illegalMemberReferences.Add(new IllegalMemberReference(memberReference, illegalReferenceUsage, indirect));
		}

		internal void AddIllegalPInvokeReferenceOccurence(string pInvokeMethod, string pInvokeLibrary, IllegalReferenceUsage illegalReferenceUsage)
		{
			foreach (IllegalPInvoke illegalPInvoke in illegalPInvokes)
			{
				if (illegalPInvoke.PInvokeTargetMethod == pInvokeMethod && illegalPInvoke.PInvokeTargetLibrary == pInvokeLibrary)
				{
					illegalPInvoke.AddIllegalReferenceUsage(illegalReferenceUsage);
					return;
				}
			}
			illegalPInvokes.Add(new IllegalPInvoke(pInvokeMethod, pInvokeLibrary, illegalReferenceUsage));
		}
	}
}
