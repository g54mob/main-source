using System;

namespace FluffyUnderware.DevTools
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class DTAttribute : Attribute, IComparable
	{
		public int Sort;

		public bool ShowBelowProperty;

		public int Space;

		public int TypeSort { get; protected set; }

		public virtual int CompareTo(object obj)
		{
			return 0;
		}

		public DTAttribute(int sortOrder, bool showBelow = false)
		{
		}
	}
}
