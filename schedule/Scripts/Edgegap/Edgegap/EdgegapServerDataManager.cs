using System.Collections.Generic;
using IO.Swagger.Model;
using UnityEngine.UIElements;

namespace Edgegap
{
	public static class EdgegapServerDataManager
	{
		internal static Status _serverData;

		private static ApiEnvironment _apiEnvironment;

		private static readonly StyleSheet _serverDataStylesheet;

		private static readonly List<VisualElement> _serverDataContainers;

		public static Status GetServerStatus()
		{
			return null;
		}

		static EdgegapServerDataManager()
		{
		}

		public static void RegisterServerDataContainer(VisualElement serverDataContainer)
		{
		}

		public static void DeregisterServerDataContainer(VisualElement serverDataContainer)
		{
		}

		public static void SetServerData(Status serverData, ApiEnvironment apiEnvironment)
		{
		}

		private static VisualElement GetStatusSection()
		{
			return null;
		}

		private static VisualElement GetDnsSection()
		{
			return null;
		}

		private static VisualElement GetPortsSection()
		{
			return null;
		}

		public static VisualElement GetServerDataVisualTree()
		{
			return null;
		}

		private static void RefreshServerDataContainers()
		{
		}
	}
}
