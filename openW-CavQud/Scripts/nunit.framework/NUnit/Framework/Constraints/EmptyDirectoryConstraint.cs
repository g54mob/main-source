using System;
using System.IO;

namespace NUnit.Framework.Constraints
{
	public class EmptyDirectoryConstraint : Constraint
	{
		private int files;

		private int subdirs;

		public override string Description => "an empty directory";

		public override ConstraintResult ApplyTo(object actual)
		{
			if (!(actual is DirectoryInfo directoryInfo))
			{
				throw new ArgumentException("The actual value must be a DirectoryInfo", "actual");
			}
			files = directoryInfo.GetFiles().Length;
			subdirs = directoryInfo.GetDirectories().Length;
			bool isSuccess = files == 0 && subdirs == 0;
			return new ConstraintResult(this, actual, isSuccess);
		}
	}
}
