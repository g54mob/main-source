using System.Collections.Generic;

namespace Trivial.CodeSecurity
{
	public class IllegalPInvoke
	{
		private string pInvokeTargetMethod = "";

		private string pInvokeTargetLibrary = "";

		private List<IllegalReferenceUsage> referenceUsages = new List<IllegalReferenceUsage>();

		public string PInvokeTargetMethod => pInvokeTargetMethod;

		public string PInvokeTargetLibrary => pInvokeTargetLibrary;

		public ICollection<IllegalReferenceUsage> ReferenceUsages => referenceUsages;

		public int ReferenceUsageCount => referenceUsages.Count;

		public IllegalPInvoke(string pInvokeTargetMethod, string pInvokeTargetLibrary, IllegalReferenceUsage illegalUsage)
		{
			this.pInvokeTargetMethod = pInvokeTargetMethod;
			this.pInvokeTargetLibrary = pInvokeTargetLibrary;
			referenceUsages.Add(illegalUsage);
		}

		public void AddIllegalReferenceUsage(IllegalReferenceUsage illegalUsage)
		{
			referenceUsages.Add(illegalUsage);
		}

		public override string ToString()
		{
			return $"Illegal usage of disallowed convention PInvoke targeting call site: {pInvokeTargetMethod}:{pInvokeTargetLibrary}";
		}
	}
}
