using System;
using System.Collections.Generic;
using System.Linq;
using UniGLTF;
using UniJSON;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.material")]
	public class glTF_VRM_Material : JsonSerializableBase
	{
		public string name;

		public string shader;

		public int renderQueue = -1;

		public Dictionary<string, float> floatProperties = new Dictionary<string, float>();

		public Dictionary<string, float[]> vectorProperties = new Dictionary<string, float[]>();

		public Dictionary<string, int> textureProperties = new Dictionary<string, int>();

		public Dictionary<string, bool> keywordMap = new Dictionary<string, bool>();

		public Dictionary<string, string> tagMap = new Dictionary<string, string>();

		public static readonly string VRM_USE_GLTFSHADER = "VRM_USE_GLTFSHADER";

		private static Utf8String s_floatProperties = Utf8String.From("floatProperties");

		private static Utf8String s_vectorProperties = Utf8String.From("vectorProperties");

		private static Utf8String s_keywordMap = Utf8String.From("keywordMap");

		private static Utf8String s_tagMap = Utf8String.From("tagMap");

		private static Utf8String s_textureProperties = Utf8String.From("textureProperties");

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => name);
			f.KeyValue(() => renderQueue);
			f.KeyValue(() => shader);
			f.Key("floatProperties");
			f.BeginMap();
			foreach (KeyValuePair<string, float> floatProperty in floatProperties)
			{
				f.Key(floatProperty.Key);
				f.Value(floatProperty.Value);
			}
			f.EndMap();
			f.Key("vectorProperties");
			f.BeginMap();
			foreach (KeyValuePair<string, float[]> vectorProperty in vectorProperties)
			{
				f.Key(vectorProperty.Key);
				f.Serialize(vectorProperty.Value.ToArray());
			}
			f.EndMap();
			f.Key("textureProperties");
			f.BeginMap();
			foreach (KeyValuePair<string, int> textureProperty in textureProperties)
			{
				f.Key(textureProperty.Key);
				f.Value(textureProperty.Value);
			}
			f.EndMap();
			f.Key("keywordMap");
			f.BeginMap();
			foreach (KeyValuePair<string, bool> item in keywordMap)
			{
				f.Key(item.Key);
				f.Value(item.Value);
			}
			f.EndMap();
			f.Key("tagMap");
			f.BeginMap();
			foreach (KeyValuePair<string, string> item2 in tagMap)
			{
				f.Key(item2.Key);
				f.Value(item2.Value);
			}
			f.EndMap();
		}

		public static List<glTF_VRM_Material> Parse(string src)
		{
			return Parse(JsonParser.Parse(src)["extensions"]["VRM"]["materialProperties"]);
		}

		public static List<glTF_VRM_Material> Parse(ListTreeNode<JsonValue> json)
		{
			List<glTF_VRM_Material> list = json.DeserializeList<glTF_VRM_Material>();
			ListTreeNode<JsonValue>[] array = json.ArrayItems().ToArray();
			for (int i = 0; i < list.Count; i++)
			{
				list[i].floatProperties = array[i][s_floatProperties].ObjectItems().ToDictionary((KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> x) => x.Key.GetString(), (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> x) => x.Value.GetSingle());
				list[i].vectorProperties = array[i][s_vectorProperties].ObjectItems().ToDictionary((KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> x) => x.Key.GetString(), (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> x) => (from y in x.Value.ArrayItems()
					select y.GetSingle()).ToArray());
				list[i].keywordMap = array[i][s_keywordMap].ObjectItems().ToDictionary((KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> x) => x.Key.GetString(), (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> x) => x.Value.GetBoolean());
				list[i].tagMap = array[i][s_tagMap].ObjectItems().ToDictionary((KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> x) => x.Key.GetString(), (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> x) => x.Value.GetString());
				list[i].textureProperties = array[i][s_textureProperties].ObjectItems().ToDictionary((KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> x) => x.Key.GetString(), (KeyValuePair<ListTreeNode<JsonValue>, ListTreeNode<JsonValue>> x) => x.Value.GetInt32());
			}
			return list;
		}
	}
}
