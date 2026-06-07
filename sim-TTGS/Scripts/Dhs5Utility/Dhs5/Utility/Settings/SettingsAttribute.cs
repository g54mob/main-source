using System;

namespace Dhs5.Utility.Settings
{
	public class SettingsAttribute : Attribute
	{
		public readonly string path;

		public readonly Scope scope;

		public SettingsAttribute(string path, Scope scope)
		{
			this.path = ((scope == Scope.User) ? "Preferences/" : "Project/") + path;
			this.scope = scope;
		}
	}
}
