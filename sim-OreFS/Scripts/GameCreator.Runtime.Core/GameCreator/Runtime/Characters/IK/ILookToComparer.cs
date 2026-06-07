using System.Collections.Generic;

namespace GameCreator.Runtime.Characters.IK
{
	internal class ILookToComparer : IComparer<ILookTo>
	{
		public int Compare(ILookTo x, ILookTo y)
		{
			return (x?.Layer ?? 0).CompareTo(y?.Layer ?? 0);
		}
	}
}
