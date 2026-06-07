using System.Collections.Generic;
using Coherence.Log;
using Coherence.Transport;

namespace Coherence
{
	public static class SimulatorUtility
	{
		public enum Type
		{
			Undefined = 0,
			World = 1,
			Rooms = 2
		}

		private const string ArgumentPrefix = "--coherence";

		private static readonly Logger Logger;

		private static readonly string[] Args;

		public const string LocalRegionParameter = "local";

		public const string SimulatorTypeRoomsParameter = "rooms";

		public const string SimulatorTypeWorldParameter = "world";

		internal const string AuthTokenKeyword = "--coherence-auth-token";

		private static readonly Dictionary<string, string> ArgumentsDict;

		private static bool wantsToBehaveAsSimulator;

		public static Type SimulatorType => default(Type);

		public static string Region => null;

		public static string Ip => null;

		public static int Port => 0;

		public static int RoomId => 0;

		public static ulong UniqueRoomId => 0uL;

		public static ulong WorldId => 0uL;

		public static int HttpServerPort => 0;

		public static string AuthToken => null;

		internal static bool UseSharedCloudCredentials => false;

		public static bool IsCloudSimulator => false;

		public static List<string> RoomTags => null;

		public static Dictionary<string, string> RoomKV => null;

		private static bool HasSimulatorCommandLineParameter => false;

		public static bool IsInvokedAsSimulator => false;

		public static bool IsInvokedInCommandLine => false;

		public static bool IsSimulator
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		static SimulatorUtility()
		{
		}

		public new static string ToString()
		{
			return null;
		}

		internal static TransportType EnsureCorrectCloudSimulatorTransport(Logger logger, TransportType transportType)
		{
			return default(TransportType);
		}

		public static void AddArgument(string arg, string val)
		{
		}

		internal static void SetArgument(string keyword, string value)
		{
		}

		internal static bool RemoveArgument(string keyword)
		{
			return false;
		}

		internal static string GetArgument(string arg)
		{
			return null;
		}
	}
}
