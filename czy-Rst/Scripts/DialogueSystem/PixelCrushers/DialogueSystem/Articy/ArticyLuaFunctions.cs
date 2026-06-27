using UnityEngine;

namespace PixelCrushers.DialogueSystem.Articy
{
	[AddComponentMenu("")]
	public class ArticyLuaFunctions : MonoBehaviour
	{
		private static bool s_registered;

		private void OnEnable()
		{
			if (!s_registered)
			{
				s_registered = true;
				Lua.RegisterFunction("getObj", this, SymbolExtensions.GetMethodInfo(() => getObj(string.Empty)));
				Lua.RegisterFunction("getObject", this, SymbolExtensions.GetMethodInfo(() => getObj(string.Empty)));
				Lua.RegisterFunction("getProp", this, SymbolExtensions.GetMethodInfo(() => getProp(string.Empty, string.Empty)));
				Lua.RegisterFunction("setProp", this, SymbolExtensions.GetMethodInfo(() => setProp(string.Empty, string.Empty, null)));
			}
		}

		private void OnConversationLine(Subtitle subtitle)
		{
			string text = "\"Actor[\\\"" + DialogueLua.StringToTableIndex(subtitle.speakerInfo.nameInDatabase) + "\\\"]\"";
			string text2 = "\"Dialog[" + subtitle.dialogueEntry.id + "]\"";
			Lua.Run("speaker = " + text + "; self = " + text2, DialogueDebug.logInfo);
		}

		public static string getObj(string objectName)
		{
			DialogueDatabase masterDatabase = DialogueManager.MasterDatabase;
			Actor actor = masterDatabase.actors.Find((Actor x) => string.Equals(objectName, x.Name) || string.Equals(objectName, x.LookupValue("Technical Name")) || string.Equals(objectName, x.LookupValue("Articy Id")));
			if (actor != null)
			{
				return "Actor[\"" + DialogueLua.StringToTableIndex(actor.Name) + "\"]";
			}
			Item item = masterDatabase.items.Find((Item x) => string.Equals(objectName, x.Name) || string.Equals(objectName, x.LookupValue("Technical Name")) || string.Equals(objectName, x.LookupValue("Articy Id")));
			if (item != null)
			{
				return "Item[\"" + DialogueLua.StringToTableIndex(item.Name) + "\"]";
			}
			Location location = masterDatabase.locations.Find((Location x) => string.Equals(objectName, x.Name) || string.Equals(objectName, x.LookupValue("Technical Name")) || string.Equals(objectName, x.LookupValue("Articy Id")));
			if (location != null)
			{
				return "Location[\"" + DialogueLua.StringToTableIndex(location.Name) + "\"]";
			}
			Conversation conversation = masterDatabase.conversations.Find((Conversation x) => string.Equals(objectName, x.Title) || string.Equals(objectName, x.LookupValue("Technical Name")) || string.Equals(objectName, x.LookupValue("Articy Id")));
			if (conversation != null)
			{
				return "Conversation[\"" + conversation.id + "\"]";
			}
			if (objectName.StartsWith("Dialog["))
			{
				return objectName;
			}
			return null;
		}

		public static object getProp(string objectIdentifier, string propertyName)
		{
			if (string.IsNullOrEmpty(objectIdentifier) || string.IsNullOrEmpty(propertyName))
			{
				return string.Empty;
			}
			if (objectIdentifier.StartsWith("Dialog[") && DialogueManager.isConversationActive)
			{
				int num = Tools.StringToInt(objectIdentifier.Substring(7, objectIdentifier.Length - 8));
				int conversationID = DialogueManager.currentConversationState.subtitle.dialogueEntry.conversationID;
				if (string.Equals("SimStatus", propertyName))
				{
					return DialogueLua.GetSimStatus(conversationID, num);
				}
				DialogueEntry dialogueEntry = DialogueManager.masterDatabase.GetDialogueEntry(conversationID, num);
				if (dialogueEntry == null)
				{
					return string.Empty;
				}
				Field field = Field.Lookup(dialogueEntry.fields, propertyName);
				if (field == null)
				{
					return string.Empty;
				}
				if (field.type == FieldType.Number)
				{
					return Tools.StringToFloat(field.value);
				}
				if (field.type == FieldType.Boolean)
				{
					return Tools.StringToBool(field.value);
				}
				return field.value;
			}
			Lua.Result result = Lua.Run("return " + objectIdentifier + "." + DialogueLua.StringToTableIndex(GetShortPropertyName(propertyName)), DialogueDebug.logInfo);
			if (result.isBool)
			{
				return result.asBool;
			}
			if (result.isNumber)
			{
				return result.asInt;
			}
			return result.asString;
		}

		public static void setProp(string objectIdentifier, string propertyName, object value)
		{
			string text = ((value == null) ? "nil" : ((value.GetType() == typeof(string)) ? ("\"" + value.ToString() + "\"") : ((!(value.GetType() == typeof(bool))) ? value.ToString() : value.ToString().ToLower())));
			Lua.Run(objectIdentifier + "." + GetShortPropertyName(propertyName) + " = " + text, DialogueDebug.logInfo);
		}

		private static string GetShortPropertyName(string propertyName)
		{
			if (propertyName.Contains("."))
			{
				int num = propertyName.LastIndexOf('.');
				return propertyName.Substring(num + 1);
			}
			return propertyName;
		}
	}
}
