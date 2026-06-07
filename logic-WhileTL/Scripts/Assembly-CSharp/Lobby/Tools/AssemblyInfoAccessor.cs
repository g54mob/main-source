using System;
using System.Reflection;

namespace Lobby.Tools
{
	public static class AssemblyInfoAccessor
	{
		private const string NOT_SETTED_ATTRIBUTE_VALUE = "not_setted";

		private static string _version;

		private static string _dataVersion;

		private static string _configuration;

		private static string _shortTitle;

		private static string _title;

		private static string _componentName;

		private static string _description;

		private static string _branchVersion;

		private static string _company;

		private static string _copyright;

		private static string _trademark;

		private static int _major;

		private static int _minor;

		private static int _build;

		private static int _revision;

		public static string BranchVersion => _branchVersion;

		public static string Company => _company;

		public static string Copyright => _copyright;

		public static string Trademark => _trademark;

		public static string FullVersion => _version;

		public static string DataVersion => _dataVersion;

		public static string Configuration => _configuration;

		public static int Major => _major;

		public static int Minor => _minor;

		public static int Build => _build;

		public static int Revision => _revision;

		public static string ShortTitle => _shortTitle;

		public static string Title => _title;

		public static string ComponentName => _componentName;

		public static string Description => _description;

		public static bool IsShippingAssembly => _configuration == "shipping";

		private static T GetFirstAttribute<T>(Assembly assembly) where T : Attribute
		{
			object[] customAttributes = assembly.GetCustomAttributes(typeof(T), inherit: true);
			if (customAttributes.Length != 0)
			{
				return (T)customAttributes[0];
			}
			return null;
		}

		public static void FillFromAssembly(Assembly assembly)
		{
			if (!(assembly == null))
			{
				AssemblyFileVersionAttribute firstAttribute = GetFirstAttribute<AssemblyFileVersionAttribute>(assembly);
				AssemblyConfigurationAttribute firstAttribute2 = GetFirstAttribute<AssemblyConfigurationAttribute>(assembly);
				AssemblyTitleAttribute firstAttribute3 = GetFirstAttribute<AssemblyTitleAttribute>(assembly);
				AssemblyDescriptionAttribute firstAttribute4 = GetFirstAttribute<AssemblyDescriptionAttribute>(assembly);
				AssemblyTrademarkAttribute firstAttribute5 = GetFirstAttribute<AssemblyTrademarkAttribute>(assembly);
				AssemblyCopyrightAttribute firstAttribute6 = GetFirstAttribute<AssemblyCopyrightAttribute>(assembly);
				AssemblyCompanyAttribute firstAttribute7 = GetFirstAttribute<AssemblyCompanyAttribute>(assembly);
				AssemblyDataVersion firstAttribute8 = GetFirstAttribute<AssemblyDataVersion>(assembly);
				AssemblyBranchVersion firstAttribute9 = GetFirstAttribute<AssemblyBranchVersion>(assembly);
				AssemblyComponentName firstAttribute10 = GetFirstAttribute<AssemblyComponentName>(assembly);
				AssemblyShortTitle firstAttribute11 = GetFirstAttribute<AssemblyShortTitle>(assembly);
				_company = ((firstAttribute7 != null) ? firstAttribute7.Company : "not_setted");
				_copyright = ((firstAttribute6 != null) ? firstAttribute6.Copyright : "not_setted");
				_trademark = ((firstAttribute5 != null) ? firstAttribute5.Trademark : "not_setted");
				_description = ((firstAttribute4 != null) ? firstAttribute4.Description : "not_setted");
				_version = ((firstAttribute != null) ? firstAttribute.Version : "not_setted");
				_dataVersion = ((firstAttribute8 != null) ? firstAttribute8.Version : "not_setted");
				_configuration = ((firstAttribute2 != null) ? firstAttribute2.Configuration : "not_setted");
				_title = ((firstAttribute3 != null) ? firstAttribute3.Title : "not_setted");
				_branchVersion = ((firstAttribute9 != null) ? firstAttribute9.Branch : "not_setted");
				_componentName = ((firstAttribute10 != null) ? firstAttribute10.Name : "not_setted");
				_shortTitle = ((firstAttribute11 != null) ? firstAttribute11.ShortTitle : "not_setted");
			}
		}

		static AssemblyInfoAccessor()
		{
			FillFromAssembly(Assembly.Load(Assembly.GetCallingAssembly().FullName));
		}
	}
}
