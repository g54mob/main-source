using System;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.NetworkSupport;
using KitchenData;
using Platforms;

namespace Kitchen
{
	public static class HandleCommandLine
	{
		public const string JOIN_COMMAND_KEY = "-join";

		public static Locale ParseForLocale(string[] args = null)
		{
			if (args == null)
			{
				args = Environment.GetCommandLineArgs();
			}
			for (int i = 0; i < args.Length - 1; i++)
			{
				if (args[i] != "-lang")
				{
					continue;
				}
				string text = args[i + 1];
				foreach (Locale item in Enum.GetValues(typeof(Locale)).Cast<Locale>())
				{
					if (item.ToString().ToLower() == text.ToLower())
					{
						return item;
					}
				}
			}
			if (Enum.TryParse<Locale>(Platform.Current.GetLocale(), out var result))
			{
				return result;
			}
			return Locale.Default;
		}

		public static async Task<INetworkTarget> ParseForConnectionTarget(string[] args = null)
		{
			if (args == null)
			{
				args = Environment.GetCommandLineArgs();
			}
			for (int i = 0; i < args.Length - 1; i++)
			{
				if (!(args[i] != "-join"))
				{
					return await NetworkServices.CreateTargetFromJoinCode(JoinCode.CreateFromRemote(args[i + 1]));
				}
			}
			return null;
		}
	}
}
