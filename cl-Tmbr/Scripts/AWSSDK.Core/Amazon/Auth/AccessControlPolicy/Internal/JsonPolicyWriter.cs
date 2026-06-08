using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Amazon.Auth.AccessControlPolicy.Internal
{
	internal static class JsonPolicyWriter
	{
		public static string WritePolicyToString(bool prettyPrint, Policy policy)
		{
			if (policy == null)
			{
				throw new ArgumentNullException("policy");
			}
			new StringWriter(CultureInfo.InvariantCulture);
			try
			{
				JsonWriterOptions options = new JsonWriterOptions
				{
					Indented = prettyPrint
				};
				using MemoryStream memoryStream = new MemoryStream();
				using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream, options);
				writePolicy(policy, utf8JsonWriter);
				utf8JsonWriter.Flush();
				return Encoding.UTF8.GetString(memoryStream.ToArray()).Trim();
			}
			catch (Exception ex)
			{
				throw new ArgumentException("Unable to serialize policy to JSON string: " + ex.Message, ex);
			}
		}

		private static void writePolicy(Policy policy, Utf8JsonWriter generator)
		{
			generator.WriteStartObject();
			writePropertyValue(generator, "Version", policy.Version);
			if (policy.Id != null)
			{
				writePropertyValue(generator, "Id", policy.Id);
			}
			generator.WritePropertyName("Statement");
			generator.WriteStartArray();
			foreach (Statement statement in policy.Statements)
			{
				generator.WriteStartObject();
				if (statement.Id != null)
				{
					writePropertyValue(generator, "Sid", statement.Id);
				}
				writePropertyValue(generator, "Effect", statement.Effect.ToString());
				writePrincipals(statement, generator);
				writeActions(statement, generator);
				writeResources(statement, generator);
				writeConditions(statement, generator);
				generator.WriteEndObject();
			}
			generator.WriteEndArray();
			generator.WriteEndObject();
		}

		private static void writePrincipals(Statement statement, Utf8JsonWriter generator)
		{
			IList<Principal> principals = statement.Principals;
			if (principals == null || principals.Count == 0)
			{
				return;
			}
			generator.WritePropertyName("Principal");
			if (principals.Count == 1 && principals[0] != null && principals[0].Provider.Equals("__ANONYMOUS__", StringComparison.Ordinal))
			{
				generator.WriteStringValue("*");
				return;
			}
			generator.WriteStartObject();
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			foreach (Principal item in principals)
			{
				if (!dictionary.TryGetValue(item.Provider, out var value))
				{
					value = new List<string>();
					dictionary[item.Provider] = value;
				}
				value.Add(item.Id);
			}
			foreach (string key in dictionary.Keys)
			{
				generator.WritePropertyName(key);
				if (dictionary[key].Count > 1)
				{
					generator.WriteStartArray();
				}
				foreach (string item2 in dictionary[key])
				{
					generator.WriteStringValue(item2);
				}
				if (dictionary[key].Count > 1)
				{
					generator.WriteEndArray();
				}
			}
			generator.WriteEndObject();
		}

		private static void writeActions(Statement statement, Utf8JsonWriter generator)
		{
			IList<ActionIdentifier> actions = statement.Actions;
			if (actions == null || actions.Count == 0)
			{
				return;
			}
			generator.WritePropertyName("Action");
			if (actions.Count > 1)
			{
				generator.WriteStartArray();
			}
			foreach (ActionIdentifier item in actions)
			{
				generator.WriteStringValue(item.ActionName);
			}
			if (actions.Count > 1)
			{
				generator.WriteEndArray();
			}
		}

		private static void writeResources(Statement statement, Utf8JsonWriter generator)
		{
			IList<Resource> resources = statement.Resources;
			if (resources == null || resources.Count == 0)
			{
				return;
			}
			generator.WritePropertyName("Resource");
			if (resources.Count > 1)
			{
				generator.WriteStartArray();
			}
			foreach (Resource item in resources)
			{
				generator.WriteStringValue(item.Id);
			}
			if (resources.Count > 1)
			{
				generator.WriteEndArray();
			}
		}

		private static void writeConditions(Statement statement, Utf8JsonWriter generator)
		{
			IList<Condition> conditions = statement.Conditions;
			if (conditions == null || conditions.Count == 0)
			{
				return;
			}
			Dictionary<string, Dictionary<string, List<string>>> dictionary = sortConditionsByTypeAndKey(conditions);
			generator.WritePropertyName("Condition");
			generator.WriteStartObject();
			foreach (KeyValuePair<string, Dictionary<string, List<string>>> item in dictionary)
			{
				generator.WritePropertyName(item.Key);
				generator.WriteStartObject();
				foreach (KeyValuePair<string, List<string>> item2 in item.Value)
				{
					IList<string> value = item2.Value;
					if (value.Count == 0)
					{
						continue;
					}
					generator.WritePropertyName(item2.Key);
					if (value.Count > 1)
					{
						generator.WriteStartArray();
					}
					if (value != null && value.Count != 0)
					{
						foreach (string item3 in value)
						{
							generator.WriteStringValue(item3);
						}
					}
					if (value.Count > 1)
					{
						generator.WriteEndArray();
					}
				}
				generator.WriteEndObject();
			}
			generator.WriteEndObject();
		}

		private static Dictionary<string, Dictionary<string, List<string>>> sortConditionsByTypeAndKey(IList<Condition> conditions)
		{
			Dictionary<string, Dictionary<string, List<string>>> dictionary = new Dictionary<string, Dictionary<string, List<string>>>();
			foreach (Condition condition in conditions)
			{
				string type = condition.Type;
				string conditionKey = condition.ConditionKey;
				if (!dictionary.TryGetValue(type, out var value))
				{
					value = (dictionary[type] = new Dictionary<string, List<string>>());
				}
				if (!value.TryGetValue(conditionKey, out var value2))
				{
					value2 = (value[conditionKey] = new List<string>());
				}
				if (condition.Values != null)
				{
					string[] values = condition.Values;
					foreach (string item in values)
					{
						value2.Add(item);
					}
				}
			}
			return dictionary;
		}

		private static void writePropertyValue(Utf8JsonWriter generator, string propertyName, string value)
		{
			generator.WritePropertyName(propertyName);
			generator.WriteStringValue(value);
		}
	}
}
