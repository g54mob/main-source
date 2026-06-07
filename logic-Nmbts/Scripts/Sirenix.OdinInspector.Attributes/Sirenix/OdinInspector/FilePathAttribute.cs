using System;

namespace Sirenix.OdinInspector
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
	public sealed class FilePathAttribute : Attribute
	{
		public bool AbsolutePath;

		public string Extensions;

		public string ParentFolder;

		[Obsolete("Use RequireExistingPath instead.")]
		public bool RequireValidPath;

		public bool RequireExistingPath;

		public bool UseBackslashes;

		[Obsolete("Add a ReadOnly attribute to the property instead.")]
		public bool ReadOnly { get; set; }
	}
}
