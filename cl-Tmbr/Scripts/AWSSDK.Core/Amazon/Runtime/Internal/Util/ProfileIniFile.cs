using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Amazon.Runtime.Internal.Util
{
	public class ProfileIniFile : IniFile
	{
		private const string ProfileMarker = "profile";

		private const string SsoSessionMarker = "sso-session";

		private const string ServicesMarker = "services";

		public bool ProfileMarkerRequired { get; set; }

		public override HashSet<string> ListSectionNames()
		{
			HashSet<string> hashSet = new HashSet<string>();
			foreach (string item2 in base.ListSectionNames())
			{
				if (!ProfileMarkerRequired || item2.StartsWith("profile", StringComparison.Ordinal))
				{
					string item = Regex.Replace(item2, "profile[ \t]+", "");
					hashSet.Add(item);
				}
			}
			return hashSet;
		}

		public ProfileIniFile(string filePath, bool profileMarkerRequired)
			: base(filePath)
		{
			ProfileMarkerRequired = profileMarkerRequired;
		}

		public bool TryGetSection(string sectionName, bool isSsoSession, bool isServicesSection, out Dictionary<string, string> properties, out Dictionary<string, Dictionary<string, string>> nestedProperties)
		{
			bool flag = false;
			nestedProperties = null;
			properties = null;
			if (!ProfileMarkerRequired && !isSsoSession)
			{
				flag = base.TryGetSection(sectionName, out properties);
			}
			if (!flag)
			{
				string text = ((!isServicesSection) ? (isSsoSession ? "sso-session" : "profile") : "services");
				Regex sectionNameRegex = new Regex("^" + text + "[ \\t]+" + Regex.Escape(sectionName) + "$", RegexOptions.Singleline);
				flag = TryGetSection(sectionNameRegex, out properties, out nestedProperties);
			}
			return flag;
		}

		public override void EditSection(string sectionName, SortedDictionary<string, string> properties)
		{
			EditSection(sectionName, isSsoSession: false, properties);
		}

		public void EditSection(string sectionName, bool isSsoSession, SortedDictionary<string, string> properties)
		{
			if (!ProfileMarkerRequired && !isSsoSession)
			{
				base.EditSection(sectionName, properties);
				return;
			}
			string text = (isSsoSession ? "sso-session" : "profile");
			Regex sectionNameRegex = new Regex("^" + text + "[ \\t]+" + Regex.Escape(sectionName) + "$", RegexOptions.Singleline);
			if (SectionExists(sectionNameRegex, out var sectionName2))
			{
				base.EditSection(sectionName2, properties);
			}
		}
	}
}
