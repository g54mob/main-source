using System;
using System.Globalization;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnit.Framework
{
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class CultureAttribute : IncludeExcludeAttribute, IApplyToTest
	{
		private CultureDetector cultureDetector = new CultureDetector();

		private CultureInfo currentCulture = CultureInfo.CurrentCulture;

		public CultureAttribute()
		{
		}

		public CultureAttribute(string cultures)
			: base(cultures)
		{
		}

		public void ApplyToTest(Test test)
		{
			if (test.RunState != RunState.NotRunnable && !IsCultureSupported())
			{
				test.RunState = RunState.Skipped;
				test.Properties.Set("_SKIPREASON", base.Reason);
			}
		}

		private bool IsCultureSupported()
		{
			if (base.Include != null && !cultureDetector.IsCultureSupported(base.Include))
			{
				base.Reason = $"Only supported under culture {base.Include}";
				return false;
			}
			if (base.Exclude != null && cultureDetector.IsCultureSupported(base.Exclude))
			{
				base.Reason = $"Not supported under culture {base.Exclude}";
				return false;
			}
			return true;
		}

		public bool IsCultureSupported(string culture)
		{
			culture = culture.Trim();
			if (culture.IndexOf(',') >= 0)
			{
				if (IsCultureSupported(culture.Split(new char[1] { ',' })))
				{
					return true;
				}
			}
			else if (currentCulture.Name == culture || currentCulture.TwoLetterISOLanguageName == culture)
			{
				return true;
			}
			return false;
		}

		public bool IsCultureSupported(string[] cultures)
		{
			foreach (string culture in cultures)
			{
				if (IsCultureSupported(culture))
				{
					return true;
				}
			}
			return false;
		}
	}
}
