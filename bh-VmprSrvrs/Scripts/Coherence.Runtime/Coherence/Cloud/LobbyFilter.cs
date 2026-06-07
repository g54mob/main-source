using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Coherence.Cloud
{
	public struct LobbyFilter
	{
		[JsonProperty("op")]
		private string logicOperator;

		[JsonProperty("key")]
		private string key;

		[JsonProperty("value")]
		private List<object> values;

		private static Dictionary<FilterOperator, string> filterToStringMapping;

		private Stack<LobbyFilter> filterBuilderStack;

		public override string ToString()
		{
			return null;
		}

		private static string GetExpressionString(LobbyFilter filter, StringBuilder stringBuilder, bool useParenthesis)
		{
			return null;
		}

		public LobbyFilter WithAnd()
		{
			return default(LobbyFilter);
		}

		public LobbyFilter WithOr()
		{
			return default(LobbyFilter);
		}

		public LobbyFilter End()
		{
			return default(LobbyFilter);
		}

		public LobbyFilter WithRegion(FilterOperator op, IEnumerable<string> regions)
		{
			return default(LobbyFilter);
		}

		public LobbyFilter WithTag(FilterOperator op, List<string> tags)
		{
			return default(LobbyFilter);
		}

		public LobbyFilter WithMaxPlayers(FilterOperator op, int maxPlayers)
		{
			return default(LobbyFilter);
		}

		public LobbyFilter WithNumPlayers(FilterOperator op, int numPlayers)
		{
			return default(LobbyFilter);
		}

		public LobbyFilter WithAvailableSlots(FilterOperator op, int availableSlots)
		{
			return default(LobbyFilter);
		}

		public LobbyFilter WithSimulatorSlug(FilterOperator op, string simSlug)
		{
			return default(LobbyFilter);
		}

		public LobbyFilter WithIsPrivateLobby(FilterOperator op, bool isPrivate)
		{
			return default(LobbyFilter);
		}

		public LobbyFilter WithIntAttribute(FilterOperator op, IntAttributeIndex index, int value)
		{
			return default(LobbyFilter);
		}

		public LobbyFilter WithStringAttribute(FilterOperator op, StringAttributeIndex index, string value)
		{
			return default(LobbyFilter);
		}

		private LobbyFilter WithFilterGroup(FilterGroupOperator op)
		{
			return default(LobbyFilter);
		}

		private bool IsEmptyFilter()
		{
			return false;
		}

		private bool IsNonFilterGroup()
		{
			return false;
		}

		private bool IsFilterGroup()
		{
			return false;
		}
	}
}
