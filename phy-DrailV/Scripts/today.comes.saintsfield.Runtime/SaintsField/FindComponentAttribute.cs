using System;
using System.Diagnostics;
using System.Linq;
using SaintsField.Utils;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class FindComponentAttribute : GetByXPathAttribute
	{
		public readonly string[] Paths;

		public FindComponentAttribute(EXP config, string path, params string[] paths)
			: base(config, paths.Prepend(path).ToArray())
		{
			Paths = new string[1] { path }.Concat(paths).ToArray();
		}

		public FindComponentAttribute(string path, params string[] paths)
			: this(SaintsFieldConfigUtil.FindComponentExp(EXP.NoAutoResignToNull | EXP.NoPicker), path, paths)
		{
			Paths = new string[1] { path }.Concat(paths).ToArray();
		}
	}
}
