using System.Collections.Generic;

namespace Photon.Pun.Demo.Shared
{
	public static class DocLinks
	{
		public enum DocTypes
		{
			Doc = 0,
			Api = 1
		}

		public enum Products
		{
			OnPremise = 0,
			Realtime = 1,
			Pun = 2,
			Chat = 3,
			Voice = 4,
			Bolt = 5,
			Quantum = 6
		}

		public enum Versions
		{
			Current = 0,
			V1 = 1,
			V2 = 2
		}

		public enum Languages
		{
			English = 0,
			Japanese = 1,
			Korean = 2,
			Chinese = 3
		}

		public static Versions Version;

		public static Languages Language;

		public static Products Product;

		public static string ApiUrlRoot;

		public static string DocUrlFormat;

		private static Dictionary<Products, string> ProductsFolders;

		private static Dictionary<Languages, string> ApiLanguagesFolder;

		private static Dictionary<Languages, string> DocLanguagesFolder;

		private static Dictionary<Versions, string> VersionsFolder;

		public static string GetLink(DocTypes type, string reference)
		{
			return null;
		}

		public static string GetApiLink(string reference)
		{
			return null;
		}

		public static string GetDocLink(string reference)
		{
			return null;
		}
	}
}
