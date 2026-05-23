using System;
using System.Diagnostics;

namespace LBG
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class SubclassPathAttribute : Attribute
	{
		private string _subClassPath = string.Empty;

		private string _subClassName = string.Empty;

		public string SubClassPath
		{
			get
			{
				return _subClassPath;
			}
			set
			{
				HasSubClassPath = !string.IsNullOrEmpty(value);
				_subClassPath = value;
			}
		}

		public string SubClassName
		{
			get
			{
				return _subClassName;
			}
			set
			{
				HasSubClassName = !string.IsNullOrEmpty(value);
				_subClassName = value;
			}
		}

		public bool HasSubClassPath { get; private set; }

		public bool HasSubClassName { get; private set; }

		public SubclassPathAttribute()
		{
		}

		public SubclassPathAttribute(string path)
		{
			SubClassPath = path;
		}

		public SubclassPathAttribute(string path, string subclassName)
		{
			SubClassPath = path;
			SubClassName = subclassName;
		}
	}
}
