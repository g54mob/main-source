using System.Collections.Generic;
using System.Text.Json;

namespace Amazon.Auth.AccessControlPolicy.Internal
{
	internal static class JsonPolicyReader
	{
		public static Policy ReadJsonStringToPolicy(string jsonString)
		{
			Policy policy = new Policy();
			using JsonDocument jsonDocument = JsonDocument.Parse(jsonString);
			JsonElement rootElement = jsonDocument.RootElement;
			if (rootElement.TryGetProperty("Id", out var value) && value.ValueKind == JsonValueKind.String)
			{
				policy.Id = value.GetString();
			}
			if (rootElement.TryGetProperty("Statement", out var value2) && value2.ValueKind == JsonValueKind.Array)
			{
				foreach (JsonElement item in value2.EnumerateArray())
				{
					Statement statement = convertStatement(item);
					if (statement != null)
					{
						policy.Statements.Add(statement);
					}
				}
			}
			return policy;
		}

		private static Statement convertStatement(JsonElement jStatement)
		{
			if (jStatement.TryGetProperty("Effect", out var value) && value.ValueKind == JsonValueKind.String)
			{
				string value2 = value.GetString();
				Statement.StatementEffect effect = ((!"Allow".Equals(value2)) ? Statement.StatementEffect.Deny : Statement.StatementEffect.Allow);
				Statement statement = new Statement(effect);
				if (jStatement.TryGetProperty("Sid", out var value3) && value3.ValueKind == JsonValueKind.String)
				{
					statement.Id = value3.GetString();
				}
				convertActions(statement, jStatement);
				convertResources(statement, jStatement);
				convertCondition(statement, jStatement);
				convertPrincipals(statement, jStatement);
				return statement;
			}
			return null;
		}

		private static void convertPrincipals(Statement statement, JsonElement jStatement)
		{
			if (!jStatement.TryGetProperty("Principal", out var value))
			{
				return;
			}
			if (value.ValueKind == JsonValueKind.String && value.GetString().Equals("*"))
			{
				statement.Principals.Add(Principal.Anonymous);
				return;
			}
			foreach (JsonProperty item3 in value.EnumerateObject())
			{
				if (item3.Value.ValueKind == JsonValueKind.String)
				{
					Principal item = new Principal(item3.Name, item3.Value.GetString());
					statement.Principals.Add(item);
				}
				else
				{
					if (item3.Value.ValueKind != JsonValueKind.Array)
					{
						continue;
					}
					foreach (JsonElement item4 in item3.Value.EnumerateArray())
					{
						if (item4.ValueKind == JsonValueKind.String)
						{
							Principal item2 = new Principal(item3.Name, item4.GetString(), stripHyphen: false);
							statement.Principals.Add(item2);
						}
					}
				}
			}
		}

		private static void convertActions(Statement statement, JsonElement jStatement)
		{
			if (!jStatement.TryGetProperty("Action", out var value))
			{
				return;
			}
			if (value.ValueKind == JsonValueKind.String)
			{
				statement.Actions.Add(new ActionIdentifier(value.GetString()));
			}
			else
			{
				if (value.ValueKind != JsonValueKind.Array)
				{
					return;
				}
				foreach (JsonElement item in value.EnumerateArray())
				{
					if (item.ValueKind == JsonValueKind.String)
					{
						statement.Actions.Add(new ActionIdentifier(item.GetString()));
					}
				}
			}
		}

		private static void convertResources(Statement statement, JsonElement jStatement)
		{
			if (!jStatement.TryGetProperty("Resource", out var value))
			{
				return;
			}
			if (value.ValueKind == JsonValueKind.String)
			{
				statement.Resources.Add(new Resource(value.GetString()));
			}
			else
			{
				if (value.ValueKind != JsonValueKind.Array)
				{
					return;
				}
				foreach (JsonElement item in value.EnumerateArray())
				{
					if (item.ValueKind == JsonValueKind.String)
					{
						statement.Resources.Add(new Resource(item.GetString()));
					}
				}
			}
		}

		private static void convertCondition(Statement statement, JsonElement jStatement)
		{
			if (!jStatement.TryGetProperty("Condition", out var value))
			{
				return;
			}
			foreach (JsonProperty item2 in value.EnumerateObject())
			{
				string name = item2.Name;
				foreach (JsonProperty item3 in item2.Value.EnumerateObject())
				{
					string name2 = item3.Name;
					List<string> list = new List<string>();
					if (item3.Value.ValueKind == JsonValueKind.String)
					{
						list.Add(item3.Value.GetString());
					}
					else if (item3.Value.ValueKind == JsonValueKind.Array)
					{
						foreach (JsonElement item4 in item3.Value.EnumerateArray())
						{
							if (item4.ValueKind == JsonValueKind.String)
							{
								list.Add(item4.GetString());
							}
						}
					}
					Condition item = new Condition(name, name2, list.ToArray());
					statement.Conditions.Add(item);
				}
			}
		}
	}
}
