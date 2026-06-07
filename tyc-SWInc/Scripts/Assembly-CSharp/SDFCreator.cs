using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using ReedSolomon;
using Tyd;
using UnityEngine;

public class SDFCreator : ScriptableObject
{
	public interface ISDFRandomInput
	{
	}

	public class SDFParameterExport
	{
		public ISDFNode Target;

		public string Field;

		public bool Smooth;

		public float[] Ranges;

		public int Index;

		public SDFParameterExport(ISDFNode target, string field)
		{
			Target = target;
			Field = field;
		}

		public SDFParameterExport(ISDFNode target, TydTable t)
		{
			Target = target;
			Field = t.GetChildValue("Field");
			if (Field.Contains('['))
			{
				int num = Field.IndexOf('[');
				Index = Field.Substring(num + 1, Field.Length - num - 2).ConvertToIntDef(0);
				Field = Field.Substring(0, num);
			}
			Smooth = t.GetChildValue("Smooth", false, false);
			TydList child = t.GetChild<TydList>("Ranges");
			if (child != null)
			{
				Ranges = child.GetChildValues<float>().ToArray();
			}
		}

		public void Execute(float val)
		{
			FieldInfo field = Target.GetType().GetField(Field, BindingFlags.Instance | BindingFlags.Public);
			float num = ((!Smooth) ? Ranges[Mathf.FloorToInt(val * (float)Ranges.Length).Clamp(0, Ranges.Length - 1)] : val.MapRange(0f, 1f, Ranges[0], Ranges[1], true));
			if (field.FieldType == typeof(int))
			{
				field.SetValue(Target, (int)num);
			}
			else if (field.FieldType == typeof(float))
			{
				field.SetValue(Target, num);
			}
			else if (field.FieldType == typeof(Vector2))
			{
				Vector2 vector = (Vector2)field.GetValue(Target);
				vector[Index] = num;
				field.SetValue(Target, vector);
			}
			else if (field.FieldType == typeof(Vector4))
			{
				Vector4 vector2 = (Vector4)field.GetValue(Target);
				vector2[Index] = num;
				field.SetValue(Target, vector2);
			}
		}

		public void Execute(Color c)
		{
			Target.GetType().GetField(Field, BindingFlags.Instance | BindingFlags.Public).SetValue(Target, c);
		}

		public Color GetColor()
		{
			return (Color)Target.GetType().GetField(Field, BindingFlags.Instance | BindingFlags.Public).GetValue(Target);
		}

		public float GetFloat()
		{
			FieldInfo field = Target.GetType().GetField(Field, BindingFlags.Instance | BindingFlags.Public);
			float num = 0f;
			if (field.FieldType == typeof(int))
			{
				num = (int)field.GetValue(Target);
			}
			else if (field.FieldType == typeof(float))
			{
				num = (float)field.GetValue(Target);
			}
			else if (field.FieldType == typeof(Vector2))
			{
				num = ((Vector2)field.GetValue(Target))[Index];
			}
			else if (field.FieldType == typeof(Vector4))
			{
				num = ((Vector4)field.GetValue(Target))[Index];
			}
			if (Smooth)
			{
				return num.MapRange(Ranges[0], Ranges[1], 0f, 1f, true);
			}
			float num2 = float.MaxValue;
			int num3 = 0;
			for (int i = 0; i < Ranges.Length; i++)
			{
				float num4 = Mathf.Abs(Ranges[i] - num);
				if (num4 < num2)
				{
					num2 = num4;
					num3 = i;
				}
			}
			return (float)num3 / ((float)Ranges.Length - 1f);
		}
	}

	public class SDFRandomCategory : ISDFRandomInput
	{
		public string Name;

		public string ID;

		public List<SDFRandomNode> Pick;

		public SDFRandomCategory(string name, string id)
		{
			Name = name;
			ID = id;
		}

		public SDFRandomCategory(string id, List<SDFRandomNode> pick)
		{
			Pick = pick;
			ID = id;
		}
	}

	public class SDFRandomNode : ISDFRandomInput
	{
		public NodeType Type;

		public Dictionary<string, string[]> Variables = new Dictionary<string, string[]>();

		public Dictionary<string, Dictionary<string, string[]>> Tags;

		public List<ISDFRandomInput> Inputs = new List<ISDFRandomInput>();

		public TydTable[] Exports;

		public float Weight = 1f;

		public string Name;

		public string SetTag;

		public bool HasValue(string key)
		{
			return Variables.ContainsKey(key);
		}

		public T GetValue<T>(string key, T def, Dictionary<string, string> tagged)
		{
			string[] value;
			if (Variables.TryGetValue(key, out value))
			{
				if (value[0].StartsWith("Tag:"))
				{
					string key2 = value[0].Substring(4);
					string value2;
					if (!tagged.TryGetValue(key2, out value2))
					{
						value2 = (tagged[key2] = value[Utilities.RandomRange(1, value.Length)]);
					}
					return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value2);
				}
				if (value[0].StartsWith("TagIndex:"))
				{
					string key3 = value[0].Substring(9);
					string value3;
					if (!tagged.TryGetValue(key3, out value3))
					{
						value3 = (tagged[key3] = Utilities.RandomRange(1, value.Length).ToString());
					}
					return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value[value3.ConvertToIntDef(1)]);
				}
				return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value.GetRandom());
			}
			return def;
		}

		public SDFRandomNode(TydTable node)
		{
			Type = node.Name.ToEnum<NodeType>();
			foreach (TydNode node2 in node.Nodes)
			{
				if (node2.Name.Equals("CheckTag"))
				{
					TydTable tydTable;
					if ((tydTable = node2 as TydTable) == null)
					{
						continue;
					}
					if (Tags == null)
					{
						Tags = new Dictionary<string, Dictionary<string, string[]>>();
					}
					Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
					Tags[tydTable.GetChildValue("Tag")] = dictionary;
					foreach (TydNode node3 in tydTable.Nodes)
					{
						if (!node3.Name.Equals("Tag"))
						{
							dictionary[node3.Name] = node3.GetNodeValues().ToArray();
						}
					}
				}
				else if (!node2.Name.Equals("ID") && !node2.Name.Equals("Exports") && !node2.Name.Equals("SetTag"))
				{
					Variables[node2.Name] = node2.GetNodeValues().ToArray();
				}
			}
			TydTable child = node.GetChild<TydTable>("Exports");
			if (child != null)
			{
				Exports = child.Nodes.OfType<TydTable>().ToArray();
			}
			SetTag = node.GetChildValue("SetTag", false);
		}

		public ISDFNode Generate(Dictionary<string, List<SDFParameterExport>> exports = null)
		{
			HashSet<string> tags = null;
			return Generate(new Dictionary<ISDFRandomInput, ISDFNode>(), new Dictionary<string, ISDFNode>(), new Dictionary<string, string>(), PickRandomColors(), exports, ref tags);
		}

		public ISDFNode Generate(Dictionary<ISDFRandomInput, ISDFNode> existing, Dictionary<string, ISDFNode> existingCat, Dictionary<string, string> tagged, Dictionary<string, Color> colors, Dictionary<string, List<SDFParameterExport>> exports, ref HashSet<string> tags)
		{
			ISDFNode value;
			if (!existing.TryGetValue(this, out value))
			{
				switch (Type)
				{
				case NodeType.Shape:
					value = new SDFShape(this, tagged);
					break;
				case NodeType.Effect:
					value = new SDFEffect(this, tagged);
					break;
				case NodeType.Combine:
					value = new SDFCombine(this, tagged);
					break;
				case NodeType.Color:
					value = new SDFExport(this, colors, tagged);
					break;
				case NodeType.Mix:
					value = new SDFMix(this, tagged);
					break;
				case NodeType.Transform:
					value = new SDFTransform(this, tagged);
					break;
				case NodeType.Mirror:
					value = new SDFMirror(this, tagged);
					break;
				case NodeType.Reflect:
					value = new SDFReflect(this, tagged);
					break;
				case NodeType.Texture:
					value = new SDFTexture(this, tagged);
					break;
				case NodeType.Array:
					value = new SDFArray(this, tagged);
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
				existing[this] = value;
				if (exports != null && Exports != null)
				{
					TydTable[] exports2 = Exports;
					foreach (TydTable tydTable in exports2)
					{
						exports.Append(tydTable.Name, new SDFParameterExport(value, tydTable));
					}
				}
				if (SetTag != null)
				{
					if (tags == null)
					{
						tags = new HashSet<string>();
					}
					tags.Add(SetTag);
				}
			}
			for (int j = 0; j < Inputs.Count; j++)
			{
				ISDFRandomInput iSDFRandomInput = Inputs[j];
				if (iSDFRandomInput == null)
				{
					continue;
				}
				SDFRandomNode sDFRandomNode;
				if ((sDFRandomNode = iSDFRandomInput as SDFRandomNode) == null)
				{
					SDFRandomCategory sDFRandomCategory;
					if ((sDFRandomCategory = iSDFRandomInput as SDFRandomCategory) == null)
					{
						continue;
					}
					SDFRandomCategory sDFRandomCategory2 = sDFRandomCategory;
					ISDFNode value2;
					if (sDFRandomCategory2.ID == null || !existingCat.TryGetValue(sDFRandomCategory2.ID, out value2))
					{
						if (sDFRandomCategory2.Pick != null)
						{
							value2 = sDFRandomCategory2.Pick.GetRandom().Generate(existing, existingCat, tagged, colors, exports, ref tags);
						}
						else
						{
							HashSet<string> tags2 = null;
							value2 = Instance.GetRandomTree(sDFRandomCategory2.Name).Generate(new Dictionary<ISDFRandomInput, ISDFNode>(), new Dictionary<string, ISDFNode>(), new Dictionary<string, string>(), colors, exports, ref tags2);
						}
						if (sDFRandomCategory2.ID != null)
						{
							existingCat[sDFRandomCategory2.ID] = value2;
						}
					}
					value.SetInput(value2, j);
				}
				else
				{
					SDFRandomNode sDFRandomNode2 = sDFRandomNode;
					value.SetInput(sDFRandomNode2.Generate(existing, existingCat, tagged, colors, exports, ref tags), j);
				}
			}
			if (tags != null && Tags != null)
			{
				foreach (string tag in tags)
				{
					Dictionary<string, string[]> value3;
					if (!Tags.TryGetValue(tag, out value3))
					{
						continue;
					}
					foreach (KeyValuePair<string, string[]> item in value3)
					{
						FieldInfo field = value.GetType().GetField(item.Key, BindingFlags.Instance | BindingFlags.Public);
						field.SetValue(value, TypeDescriptor.GetConverter(field.FieldType).ConvertFrom(item.Value.GetRandom()));
					}
				}
			}
			return value;
		}

		public void SetInput(ISDFRandomInput n, int i)
		{
			for (int j = Inputs.Count; j <= i; j++)
			{
				Inputs.Add(null);
			}
			Inputs[i] = n;
		}

		public override string ToString()
		{
			return Name ?? base.ToString();
		}
	}

	public interface ISDFNode
	{
		void SetInput(ISDFNode node, int i);

		bool IsValid();

		void Execute(int size, RenderTexture result, Matrix4x4 m);

		void Serialize(Dictionary<ISDFNode, int> ids, TydTable nodes, TydList connections);

		void Serialize(Dictionary<ISDFNode, int> ids, Stream stream);

		void SerializeConnections(Dictionary<ISDFNode, int> ids, HashSet<ISDFNode> done, Stream stream);

		void Compare(ISDFNode other, StringBuilder sb);

		int CountNodes();

		ISDFNode Duplicate();

		IEnumerable<ISDFNode> GetChildren();
	}

	public interface ISDFInput : ISDFNode
	{
	}

	public interface ISDFOutput : ISDFNode
	{
	}

	[Serializable]
	public class SDFTexture : ISDFInput, ISDFNode
	{
		public string SDFResource;

		[NonSerialized]
		private Texture2D _SDFTexture;

		[NonSerialized]
		private bool _loaded;

		public Vector2 Pos = Vector2.zero;

		public Vector2 Scale = Vector2.one;

		public float Rotation;

		public Texture2D SDFTex
		{
			get
			{
				if (!_loaded)
				{
					_SDFTexture = Instance.LoadSDF(SDFResource);
					_loaded = true;
				}
				return _SDFTexture;
			}
		}

		public SDFTexture(string resource)
		{
			SDFResource = resource.Trim();
		}

		public SDFTexture(TydTable t)
		{
			SDFResource = t.GetChildValue("SDFResource").Trim();
			Pos = SVector3.Deserialize(t.GetChildValue("Pos"));
			Scale = SVector3.Deserialize(t.GetChildValue("Scale"));
			Rotation = t.GetChildValue("Rotation").ConvertToFloatDef(0f);
		}

		public SDFTexture(SDFRandomNode node, Dictionary<string, string> tagged)
		{
			SDFResource = node.GetValue("SDFResource", "TestSDF", tagged).Trim();
			Pos = SVector3.Deserialize(node.GetValue("Pos", "0,0", tagged));
			Scale = SVector3.Deserialize(node.GetValue("Scale", "0,0", tagged));
			Rotation = node.GetValue("Rotation", 0f, tagged);
		}

		public void Execute(int size, RenderTexture result, Matrix4x4 m)
		{
			Vector3 vector = m.MultiplyPoint(Pos.ToVector3(0f));
			Vector3 vector2 = Vector3.Scale(m.lossyScale, Scale.ToVector3(1f));
			float num = 0f - Quaternion.LookRotation(m.MultiplyVector(Quaternion.Euler(0f, Rotation, 0f) * Vector3.forward)).eulerAngles.y;
			Material texture = Instance._texture;
			texture.SetVector("_SDFTranslationScale", new Vector4(vector.x, vector.z, vector2.x, vector2.z));
			texture.SetFloat("_SDFRotation", num * ((float)Math.PI / 180f));
			Graphics.Blit(SDFTex, result, texture);
		}

		public void Reset()
		{
			_SDFTexture = null;
			_loaded = false;
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, TydTable nodes, TydList connections)
		{
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				nodes.AddChild(new TydTable(NodeType.Texture.ToString(), new TydString("ID", value.ToString()), new TydString("SDFResource", SDFResource), new TydString("Pos", ((SVector3)Pos).Serialize(2)), new TydString("Scale", ((SVector3)Scale).Serialize(2)), new TydString("Rotation", Rotation.ToString())));
			}
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, Stream stream)
		{
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				bool flag = Pos != Vector2.zero;
				bool flag2 = Scale != Vector2.one;
				bool flag3 = Rotation != 0f;
				stream.WriteByte(7);
				stream.WriteByte((byte)value);
				stream.WriteString(SDFResource);
				stream.WriteBools(flag, flag2, flag3);
				if (flag)
				{
					stream.WriteFloat(Pos.x, -1f, 1f);
					stream.WriteFloat(Pos.y, -1f, 1f);
				}
				if (flag2)
				{
					stream.WriteFloat(Scale.x, 0f, 2f);
				}
				if (flag3)
				{
					stream.WriteFloat(Rotation.FixAngleDegrees(), 0f, 360f);
				}
			}
		}

		public void SerializeConnections(Dictionary<ISDFNode, int> ids, HashSet<ISDFNode> done, Stream stream)
		{
		}

		public void Compare(ISDFNode other, StringBuilder sb)
		{
			if (other.GetType() != GetType())
			{
				sb.AppendLine("Difference in " + GetType().ToString() + " other is: " + other.GetType().ToString());
				return;
			}
			CompareValues(this, other, "Pos", sb);
			CompareValues(this, other, "Scale", sb);
			CompareValues(this, other, "Rotation", sb);
			CompareValues(this, other, "SDFResource", sb);
		}

		public int CountNodes()
		{
			return 1;
		}

		public SDFTexture(string sdfResource, Vector2 pos, Vector2 scale, float rotation)
		{
			SDFResource = sdfResource.Trim();
			Pos = pos;
			Scale = scale;
			Rotation = rotation;
		}

		public ISDFNode Duplicate()
		{
			return new SDFTexture(SDFResource, Pos, Scale, Rotation);
		}

		public SDFTexture(Stream stream, byte version)
		{
			SDFResource = stream.ReadString().Trim();
			bool b = true;
			bool b2 = true;
			bool b3 = true;
			if (version > 2)
			{
				stream.ReadBools(out b, out b2, out b3);
			}
			if (b)
			{
				Pos = new Vector2(stream.ReadFloat(-1f, 1f), stream.ReadFloat(-1f, 1f));
			}
			if (b2)
			{
				float num = stream.ReadFloat(0f, 2f);
				Scale = Vector2.one * num;
			}
			if (b3)
			{
				Rotation = stream.ReadFloat(0f, 360f);
			}
		}

		public IEnumerable<ISDFNode> GetChildren()
		{
			yield break;
		}

		public void SetInput(ISDFNode node, int i)
		{
		}

		public bool IsValid()
		{
			return SDFTex != null;
		}
	}

	[Serializable]
	public class SDFShape : ISDFInput, ISDFNode
	{
		public SDFFunction Function;

		public Vector2 Pos = Vector2.zero;

		public Vector2 Scale = Vector2.one * 0.5f;

		public float Rotation;

		public float Rounding;

		public Vector4 SDFParams;

		public SDFShape(SDFFunction function, Vector2 pos, Vector2 scale, float rotation, float rounding, Vector4 sdfParams)
		{
			Function = function;
			Pos = pos;
			Scale = scale;
			Rotation = rotation;
			Rounding = rounding;
			SDFParams = sdfParams;
		}

		public SDFShape(SDFFunction function, Vector4 p)
		{
			Function = function;
			SDFParams = p;
		}

		public SDFShape(TydTable t)
		{
			Function = t.GetChildValue("Function").ToEnum<SDFFunction>();
			Pos = SVector3.Deserialize(t.GetChildValue("Pos"));
			Scale = SVector3.Deserialize(t.GetChildValue("Scale"));
			Rotation = t.GetChildValue("Rotation").ConvertToFloatDef(0f);
			Rounding = t.GetChildValue("Rounding").ConvertToFloatDef(0f);
			SDFParams = SVector3.Deserialize(t.GetChildValue("SDFParams"));
		}

		public SDFShape(SDFRandomNode node, Dictionary<string, string> tagged)
		{
			Function = node.GetValue("Function", SDFFunction.Circle, tagged);
			Pos = SVector3.Deserialize(node.GetValue("Pos", "0,0", tagged));
			Scale = SVector3.Deserialize(node.GetValue("Scale", "0.5,0.5", tagged));
			Rotation = node.GetValue("Rotation", 0f, tagged);
			Rounding = node.GetValue("Rounding", 0f, tagged);
			if (node.HasValue("SDFParams"))
			{
				SDFParams = SVector3.Deserialize(node.GetValue("SDFParams", "0,0,0,0", tagged));
				return;
			}
			float x = node.GetValue("SDFParam1", "0", tagged).ConvertToFloatDef(0f);
			float y = node.GetValue("SDFParam2", "0", tagged).ConvertToFloatDef(0f);
			float z = node.GetValue("SDFParam3", "0", tagged).ConvertToFloatDef(0f);
			float w = node.GetValue("SDFParam4", "0", tagged).ConvertToFloatDef(0f);
			SDFParams = new Vector4(x, y, z, w);
		}

		public void Execute(int size, RenderTexture result, Matrix4x4 m)
		{
			Vector3 vector = m.MultiplyPoint(Pos.ToVector3(0f));
			Vector3 vector2 = Vector3.Scale(m.lossyScale, Scale.ToVector3(1f));
			Vector3 vector3 = m.MultiplyVector(Quaternion.Euler(0f, Rotation, 0f) * Vector3.forward);
			float num = ((vector3 == Vector3.zero) ? 0f : (0f - Quaternion.LookRotation(vector3).eulerAngles.y));
			Material sdfMat = Instance._sdfMat;
			sdfMat.SetInt("_SDFFunction", (int)Function);
			sdfMat.SetVector("_SDFParams", SDFParams);
			sdfMat.SetVector("_SDFTranslationScale", new Vector4(vector.x, vector.z, vector2.x, vector2.z));
			sdfMat.SetFloat("_SDFRotation", num * ((float)Math.PI / 180f));
			sdfMat.SetFloat("_SDFRounding", Rounding);
			Graphics.Blit(null, result, sdfMat);
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, TydTable nodes, TydList connections)
		{
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				nodes.AddChild(new TydTable(NodeType.Shape.ToString(), new TydString("ID", value.ToString()), new TydString("Function", Function.ToString()), new TydString("Pos", ((SVector3)Pos).Serialize(2)), new TydString("Scale", ((SVector3)Scale).Serialize(2)), new TydString("Rotation", Rotation.ToString()), new TydString("Rounding", Rounding.ToString()), new TydString("SDFParams", ((SVector3)SDFParams).Serialize())));
			}
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, Stream stream)
		{
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				stream.WriteByte(0);
				stream.WriteByte((byte)value);
				stream.WriteByte((byte)Function);
				bool flag = Pos != Vector2.zero;
				bool flag2 = Scale != Vector2.one * 0.5f;
				bool flag3 = Rotation != 0f;
				bool flag4 = Rounding != 0f;
				stream.WriteBools(flag, flag2, flag3, flag4);
				if (flag)
				{
					stream.WriteFloat(Pos.x, -1f, 1f);
					stream.WriteFloat(Pos.y, -1f, 1f);
				}
				if (flag2)
				{
					stream.WriteFloat(Scale.x, 0f, 2f);
				}
				if (flag3)
				{
					stream.WriteFloat(Rotation.FixAngleDegrees(), 0f, 360f);
				}
				if (flag4)
				{
					stream.WriteFloat(Rounding, 0f, 1f);
				}
				ParameterInfo[] parameters = GetParameters(Function);
				for (int num2 = 0; num2 < parameters.Length; num2++)
				{
					stream.WriteFloat(SDFParams[num2], parameters[num2].Min, parameters[num2].Max);
				}
			}
		}

		public SDFShape(Stream stream, byte version)
		{
			Function = (SDFFunction)stream.ReadByte();
			bool b = true;
			bool b2 = true;
			bool b3 = true;
			bool b4 = true;
			if (version > 2)
			{
				stream.ReadBools(out b, out b2, out b3, out b4);
			}
			if (b)
			{
				Pos = new Vector2(stream.ReadFloat(-1f, 1f), stream.ReadFloat(-1f, 1f));
			}
			if (b2)
			{
				float num = stream.ReadFloat(0f, 2f);
				Scale = Vector2.one * num;
			}
			if (b3)
			{
				Rotation = stream.ReadFloat(0f, 360f);
			}
			if (b4)
			{
				Rounding = stream.ReadFloat(0f, 1f);
			}
			ParameterInfo[] parameters = GetParameters(Function);
			SDFParams = Vector4.zero;
			for (int i = 0; i < parameters.Length; i++)
			{
				if (version < 6 && Function == SDFFunction.Circle && i == 1)
				{
					SDFParams[i] = 1f;
				}
				else
				{
					SDFParams[i] = stream.ReadFloat(parameters[i].Min, parameters[i].Max);
				}
			}
		}

		public void SerializeConnections(Dictionary<ISDFNode, int> ids, HashSet<ISDFNode> done, Stream stream)
		{
		}

		public void Compare(ISDFNode other, StringBuilder sb)
		{
			if (other.GetType() != GetType())
			{
				sb.AppendLine("Difference in " + GetType().ToString() + " other is: " + other.GetType().ToString());
				return;
			}
			CompareValues(this, other, "Pos", sb);
			CompareValues(this, other, "Scale", sb);
			CompareValues(this, other, "Rotation", sb);
			CompareValues(this, other, "Rounding", sb);
			CompareValues(this, other, "Function", sb);
			CompareValues(this, other, "SDFParams", sb);
		}

		public int CountNodes()
		{
			return 1;
		}

		public ISDFNode Duplicate()
		{
			return new SDFShape(Function, Pos, Scale, Rotation, Rounding, SDFParams);
		}

		public IEnumerable<ISDFNode> GetChildren()
		{
			yield break;
		}

		public void SetInput(ISDFNode node, int i)
		{
		}

		public bool IsValid()
		{
			return true;
		}
	}

	[Serializable]
	public class SDFTransform : ISDFInput, ISDFNode
	{
		public ISDFNode Input;

		public Vector2 Pos = Vector2.zero;

		public Vector2 Scale = Vector2.one;

		public float Rotation;

		public SDFTransform(ISDFNode input, Vector2 pos, Vector2 scale, float rotation)
		{
			Input = input;
			Pos = pos;
			Scale = scale;
			Rotation = rotation;
		}

		public SDFTransform(ISDFNode input)
		{
			Input = input;
		}

		public SDFTransform(SDFRandomNode node, Dictionary<string, string> tagged)
		{
			Pos = SVector3.Deserialize(node.GetValue("Pos", "0,0", tagged));
			Scale = SVector3.Deserialize(node.GetValue("Scale", "1,1", tagged));
			Rotation = node.GetValue("Rotation", 0f, tagged);
		}

		public SDFTransform(TydTable t)
		{
			Pos = SVector3.Deserialize(t.GetChildValue("Pos"));
			Scale = SVector3.Deserialize(t.GetChildValue("Scale"));
			Rotation = t.GetChildValue("Rotation").ConvertToFloatDef(0f);
		}

		public void SetInput(ISDFNode node, int i)
		{
			Input = node;
		}

		public bool IsValid()
		{
			ISDFNode input = Input;
			if (input == null)
			{
				return false;
			}
			return input.IsValid();
		}

		public void Execute(int size, RenderTexture result, Matrix4x4 m)
		{
			Matrix4x4 matrix4x = Matrix4x4.TRS(Pos.ToVector3(0f), Quaternion.Euler(0f, Rotation, 0f), Scale.ToVector3(1f));
			Input.Execute(size, result, m * matrix4x);
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, TydTable nodes, TydList connections)
		{
			Input.Serialize(ids, nodes, connections);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				connections.AddChild(new TydList(null, value.ToString(), ids[Input].ToString()));
				nodes.AddChild(new TydTable(NodeType.Transform.ToString(), new TydString("ID", value.ToString()), new TydString("Pos", ((SVector3)Pos).Serialize(2)), new TydString("Scale", ((SVector3)Scale).Serialize(2)), new TydString("Rotation", Rotation.ToString())));
			}
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, Stream stream)
		{
			Input.Serialize(ids, stream);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				stream.WriteByte(5);
				stream.WriteByte((byte)value);
				bool flag = Pos != Vector2.zero;
				bool flag2 = Scale != Vector2.one;
				bool flag3 = Rotation != 0f;
				stream.WriteBools(flag, flag2, flag3);
				if (flag)
				{
					stream.WriteFloat(Pos.x, -1f, 1f);
					stream.WriteFloat(Pos.y, -1f, 1f);
				}
				if (flag2)
				{
					stream.WriteFloat(Scale.x, 0f, 2f);
				}
				if (flag3)
				{
					stream.WriteFloat(Rotation.FixAngleDegrees(), 0f, 360f);
				}
			}
		}

		public void Compare(ISDFNode other, StringBuilder sb)
		{
			if (other.GetType() != GetType())
			{
				sb.AppendLine("Difference in " + GetType().ToString() + " other is: " + other.GetType().ToString());
				return;
			}
			CompareValues(this, other, "Pos", sb);
			CompareValues(this, other, "Scale", sb);
			CompareValues(this, other, "Rotation", sb);
			CompareChildren(Input, (other as SDFTransform).Input, sb);
		}

		public void SerializeConnections(Dictionary<ISDFNode, int> ids, HashSet<ISDFNode> done, Stream stream)
		{
			Input.SerializeConnections(ids, done, stream);
			if (done.Add(this))
			{
				stream.WriteByte(2);
				stream.WriteByte((byte)ids[this]);
				stream.WriteByte((byte)ids[Input]);
			}
		}

		public int CountNodes()
		{
			ISDFNode input = Input;
			return 1 + ((input != null) ? input.CountNodes() : 0);
		}

		public SDFTransform(Vector2 pos, Vector2 scale, float rotation)
		{
			Pos = pos;
			Scale = scale;
			Rotation = rotation;
		}

		public ISDFNode Duplicate()
		{
			return new SDFTransform(Pos, Scale, Rotation);
		}

		public SDFTransform(Stream stream, byte version)
		{
			bool b = true;
			bool b2 = true;
			bool b3 = true;
			if (version > 2)
			{
				stream.ReadBools(out b, out b2, out b3);
			}
			if (b)
			{
				Pos = new Vector2(stream.ReadFloat(-1f, 1f), stream.ReadFloat(-1f, 1f));
			}
			if (b2)
			{
				float num = stream.ReadFloat(0f, 2f);
				Scale = Vector2.one * num;
			}
			if (b3)
			{
				Rotation = stream.ReadFloat(0f, 360f);
			}
		}

		public IEnumerable<ISDFNode> GetChildren()
		{
			yield return Input;
		}
	}

	public class SDFEffect : ISDFInput, ISDFNode
	{
		public ISDFInput Input;

		public float Rounding;

		public float Subtraction;

		public float Distortion;

		public float Threshold;

		public float Blur;

		public Vector2 WaveAmount = Vector2.zero;

		public Vector2 WaveFrequency = Vector2.one;

		public Vector2 Skew = Vector2.zero;

		public SDFEffect(ISDFInput input, float rounding, float subtraction)
		{
			Input = input;
			Rounding = rounding;
			Subtraction = subtraction;
		}

		public SDFEffect(TydTable t)
		{
			Subtraction = t.GetChildValue("Subtraction").ConvertToFloatDef(0f);
			Distortion = t.GetChildValue("Distortion", false, "0").ConvertToFloatDef(0f);
			Threshold = t.GetChildValue("Threshold", false, "0").ConvertToFloatDef(0f);
			Blur = t.GetChildValue("Blur", false, "0").ConvertToFloatDef(0f);
			WaveAmount = SVector3.Deserialize(t.GetChildValue("WaveAmount", false, "0,0"));
			WaveFrequency = SVector3.Deserialize(t.GetChildValue("WaveFrequency", false, "1,1"));
			Skew = SVector3.Deserialize(t.GetChildValue("Skew", false, "0,0"));
		}

		public SDFEffect(SDFRandomNode node, Dictionary<string, string> tagged)
		{
			Subtraction = node.GetValue("Subtraction", 0f, tagged);
			Rounding = node.GetValue("Rounding", 0f, tagged);
			Distortion = node.GetValue("Distortion", 0f, tagged);
			Threshold = node.GetValue("Threshold", 0f, tagged);
			Blur = node.GetValue("Blur", 0f, tagged);
			WaveAmount = SVector3.Deserialize(node.GetValue("WaveAmount", "0,0", tagged));
			WaveFrequency = SVector3.Deserialize(node.GetValue("WaveFrequency", "1,1", tagged));
			Skew = SVector3.Deserialize(node.GetValue("Skew", "0,0", tagged));
		}

		public void Execute(int size, RenderTexture result, Matrix4x4 m)
		{
			if (Rounding == 0f && Subtraction == 0f && Distortion == 0f && Threshold == 0f && Blur == 0f && WaveAmount == Vector2.zero && Skew == Vector2.zero)
			{
				Input.Execute(size, result, m);
				return;
			}
			RenderTexture temporary = RenderTexture.GetTemporary(size, size, 0, RenderTextureFormat.RFloat);
			Input.Execute(size, temporary, m);
			Material effect = Instance._effect;
			effect.SetFloat("_SDFRounding", Rounding);
			effect.SetFloat("_SDFSubtraction", Subtraction);
			effect.SetFloat("_SDFDistortion", Distortion);
			effect.SetFloat("_SDFThreshold", Threshold);
			effect.SetFloat("_SDFBlur", Blur);
			effect.SetVector("_SDFWave", new Vector4(WaveFrequency.x, WaveAmount.x, WaveFrequency.y, WaveAmount.y));
			effect.SetVector("_SDFSkew", Skew);
			Graphics.Blit(temporary, result, effect);
			RenderTexture.ReleaseTemporary(temporary);
		}

		public void SetInput(ISDFNode node, int i)
		{
			Input = node as ISDFInput;
		}

		public bool IsValid()
		{
			ISDFInput input = Input;
			if (input == null)
			{
				return false;
			}
			return input.IsValid();
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, TydTable nodes, TydList connections)
		{
			Input.Serialize(ids, nodes, connections);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				connections.AddChild(new TydList(null, value.ToString(), ids[Input].ToString()));
				nodes.AddChild(new TydTable(NodeType.Effect.ToString(), new TydString("ID", value.ToString()), new TydString("Subtraction", Subtraction.ToString()), new TydString("Distortion", Distortion.ToString()), new TydString("Threshold", Threshold.ToString()), new TydString("Blur", Blur.ToString()), new TydString("WaveAmount", ((SVector3)WaveAmount).Serialize(2)), new TydString("WaveFrequency", ((SVector3)WaveFrequency).Serialize(2)), new TydString("Skew", ((SVector3)Skew).Serialize(2))));
			}
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, Stream stream)
		{
			Input.Serialize(ids, stream);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				stream.WriteByte(1);
				stream.WriteByte((byte)value);
				bool flag = Subtraction != 0f;
				bool flag2 = Distortion != 0f;
				bool flag3 = Threshold != 0f;
				bool flag4 = WaveAmount != Vector2.zero;
				bool flag5 = WaveFrequency != Vector2.one;
				bool flag6 = Skew != Vector2.zero;
				stream.WriteBools(flag, flag2, flag3, flag4, flag5, flag6);
				if (flag)
				{
					stream.WriteFloat(Subtraction, 0f, 1f);
				}
				if (flag2)
				{
					stream.WriteFloat(Distortion, -1f, 1f);
				}
				if (flag3)
				{
					stream.WriteFloat(Threshold, -1f, 1f);
				}
				if (flag4)
				{
					stream.WriteFloat(WaveAmount.x, -1f, 1f);
					stream.WriteFloat(WaveAmount.y, -1f, 1f);
				}
				if (flag5)
				{
					stream.WriteFloat(WaveFrequency.x, 0f, 10f);
					stream.WriteFloat(WaveFrequency.y, 0f, 10f);
				}
				if (flag6)
				{
					stream.WriteFloat(Skew.x, -1f, 1f);
					stream.WriteFloat(Skew.y, -1f, 1f);
				}
			}
		}

		public void Compare(ISDFNode other, StringBuilder sb)
		{
			if (other.GetType() != GetType())
			{
				sb.AppendLine("Difference in " + GetType().ToString() + " other is: " + other.GetType().ToString());
				return;
			}
			CompareValues(this, other, "Subtraction", sb);
			CompareValues(this, other, "Distortion", sb);
			CompareValues(this, other, "Threshold", sb);
			CompareValues(this, other, "WaveAmount", sb);
			CompareValues(this, other, "WaveFrequency", sb);
			CompareValues(this, other, "Skew", sb);
			CompareChildren(Input, (other as SDFEffect).Input, sb);
		}

		public void SerializeConnections(Dictionary<ISDFNode, int> ids, HashSet<ISDFNode> done, Stream stream)
		{
			Input.SerializeConnections(ids, done, stream);
			if (done.Add(this))
			{
				stream.WriteByte(2);
				stream.WriteByte((byte)ids[this]);
				stream.WriteByte((byte)ids[Input]);
			}
		}

		public int CountNodes()
		{
			ISDFInput input = Input;
			return 1 + ((input != null) ? input.CountNodes() : 0);
		}

		public SDFEffect(float rounding, float subtraction, float distortion, float threshold, float blur, Vector2 waveAmount, Vector2 waveFrequency, Vector2 skew)
		{
			Rounding = rounding;
			Subtraction = subtraction;
			Distortion = distortion;
			Threshold = threshold;
			Blur = blur;
			WaveAmount = waveAmount;
			WaveFrequency = waveFrequency;
			Skew = skew;
		}

		public ISDFNode Duplicate()
		{
			return new SDFEffect(Rounding, Subtraction, Distortion, Threshold, Blur, WaveAmount, WaveFrequency, Skew);
		}

		public SDFEffect(Stream stream, byte version)
		{
			bool b = true;
			bool b2 = true;
			bool b3 = true;
			bool b4 = true;
			bool b5 = true;
			bool b6 = true;
			if (version > 2)
			{
				stream.ReadBools(out b, out b2, out b3, out b4, out b5, out b6);
			}
			if (b)
			{
				Subtraction = stream.ReadFloat(0f, 1f);
			}
			if (b2)
			{
				Distortion = stream.ReadFloat(-1f, 1f);
			}
			if (b3)
			{
				Threshold = stream.ReadFloat(-1f, 1f);
			}
			if (b4)
			{
				WaveAmount = new Vector2(stream.ReadFloat(-1f, 1f), stream.ReadFloat(-1f, 1f));
			}
			if (b5)
			{
				WaveFrequency = new Vector2(stream.ReadFloat(0f, 10f), stream.ReadFloat(0f, 10f));
			}
			if (b6 && version > 1)
			{
				Skew = new Vector2(stream.ReadFloat(-1f, 1f), stream.ReadFloat(-1f, 1f));
			}
		}

		public IEnumerable<ISDFNode> GetChildren()
		{
			yield return Input;
		}
	}

	public class SDFArray : ISDFInput, ISDFNode
	{
		public ISDFInput Input;

		public Vector2 Pos = Vector2.zero;

		public Vector2 Scale = Vector2.one;

		public float Rotation;

		public bool WrapX;

		public bool WrapY;

		public SDFArray(ISDFInput input, bool wrapX, bool wrapY)
		{
			Input = input;
			WrapX = wrapX;
			WrapY = wrapY;
		}

		public SDFArray(TydTable t)
		{
			Pos = SVector3.Deserialize(t.GetChildValue("Pos"));
			Scale = SVector3.Deserialize(t.GetChildValue("Scale"));
			Rotation = t.GetChildValue("Rotation").ConvertToFloatDef(0f);
			WrapX = t.GetChildValue("WrapX", false, "true").ConvertToBoolDef(true);
			WrapY = t.GetChildValue("WrapY", false, "true").ConvertToBoolDef(true);
		}

		public SDFArray(SDFRandomNode node, Dictionary<string, string> tagged)
		{
			Pos = SVector3.Deserialize(node.GetValue("Pos", "0,0", tagged));
			Scale = SVector3.Deserialize(node.GetValue("Scale", "1,1", tagged));
			Rotation = node.GetValue("Rotation", 0f, tagged);
			WrapX = node.GetValue("WrapX", true, tagged);
			WrapY = node.GetValue("WrapY", true, tagged);
		}

		public void Execute(int size, RenderTexture result, Matrix4x4 m)
		{
			if (Rotation == 0f && Scale == Vector2.one && Pos == Vector2.zero)
			{
				Input.Execute(size, result, m);
				return;
			}
			Vector3 vector = m.MultiplyPoint(Pos.ToVector3(0f));
			Vector3 vector2 = Vector3.Scale(m.lossyScale, Scale.ToVector3(1f));
			float num = 0f - Quaternion.LookRotation(m.MultiplyVector(Quaternion.Euler(0f, Rotation, 0f) * Vector3.forward)).eulerAngles.y;
			RenderTexture temporary = RenderTexture.GetTemporary(size, size, 0, RenderTextureFormat.RFloat);
			Input.Execute(size, temporary, Matrix4x4.identity);
			Material array = Instance._array;
			array.SetVector("_SDFTranslationScale", new Vector4(vector.x, vector.z, vector2.x, vector2.z));
			array.SetFloat("_SDFRotation", num * ((float)Math.PI / 180f));
			array.SetVector("_SDFWrap", Vector4.one);
			Graphics.Blit(temporary, result, array);
			RenderTexture.ReleaseTemporary(temporary);
		}

		public void SetInput(ISDFNode node, int i)
		{
			Input = node as ISDFInput;
		}

		public bool IsValid()
		{
			ISDFInput input = Input;
			if (input == null)
			{
				return false;
			}
			return input.IsValid();
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, TydTable nodes, TydList connections)
		{
			Input.Serialize(ids, nodes, connections);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				connections.AddChild(new TydList(null, value.ToString(), ids[Input].ToString()));
				nodes.AddChild(new TydTable(NodeType.Array.ToString(), new TydString("ID", value.ToString()), new TydString("Pos", ((SVector3)Pos).Serialize(2)), new TydString("Scale", ((SVector3)Scale).Serialize(2)), new TydString("Rotation", Rotation.ToString()), new TydString("WrapX", WrapX.ToString()), new TydString("WrapY", WrapY.ToString())));
			}
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, Stream stream)
		{
			Input.Serialize(ids, stream);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				stream.WriteByte(8);
				stream.WriteByte((byte)value);
				bool flag = Pos != Vector2.zero;
				bool flag2 = Scale != Vector2.one;
				bool flag3 = Rotation != 0f;
				stream.WriteBools(flag, flag2, flag3);
				if (flag)
				{
					stream.WriteFloat(Pos.x, -1f, 1f);
					stream.WriteFloat(Pos.y, -1f, 1f);
				}
				if (flag2)
				{
					stream.WriteFloat(Scale.x, 0f, 1f);
				}
				if (flag3)
				{
					stream.WriteFloat(Rotation.FixAngleDegrees(), 0f, 360f);
				}
			}
		}

		public void Compare(ISDFNode other, StringBuilder sb)
		{
			if (other.GetType() != GetType())
			{
				sb.AppendLine("Difference in " + GetType().ToString() + " other is: " + other.GetType().ToString());
				return;
			}
			CompareValues(this, other, "Pos", sb);
			CompareValues(this, other, "Scale", sb);
			CompareValues(this, other, "Rotation", sb);
			CompareChildren(Input, (other as SDFArray).Input, sb);
		}

		public void SerializeConnections(Dictionary<ISDFNode, int> ids, HashSet<ISDFNode> done, Stream stream)
		{
			Input.SerializeConnections(ids, done, stream);
			if (done.Add(this))
			{
				stream.WriteByte(2);
				stream.WriteByte((byte)ids[this]);
				stream.WriteByte((byte)ids[Input]);
			}
		}

		public int CountNodes()
		{
			ISDFInput input = Input;
			return 1 + ((input != null) ? input.CountNodes() : 0);
		}

		public SDFArray(Vector2 pos, Vector2 scale, float rotation, bool wrapX, bool wrapY)
		{
			Pos = pos;
			Scale = scale;
			Rotation = rotation;
			WrapX = wrapX;
			WrapY = wrapY;
		}

		public ISDFNode Duplicate()
		{
			return new SDFArray(Pos, Scale, Rotation, WrapX, WrapY);
		}

		public SDFArray(Stream stream, byte version)
		{
			bool b = true;
			bool b2 = true;
			bool b3 = true;
			if (version > 2)
			{
				stream.ReadBools(out b, out b2, out b3);
			}
			if (b)
			{
				Pos = new Vector2(stream.ReadFloat(-1f, 1f), stream.ReadFloat(-1f, 1f));
			}
			if (b2)
			{
				float num = stream.ReadFloat(0f, 1f);
				Scale = Vector2.one * num;
			}
			if (b3)
			{
				Rotation = stream.ReadFloat(0f, 360f);
			}
		}

		public IEnumerable<ISDFNode> GetChildren()
		{
			yield return Input;
		}
	}

	public class SDFMirror : ISDFInput, ISDFNode
	{
		public ISDFInput Input;

		public Vector2 Pos;

		public int Times;

		public float Angle;

		public float Offset;

		public bool FlipX;

		public bool FlipY;

		public SDFMirror(ISDFInput input, Vector2 pos, int times, float angle, float offset)
		{
			Input = input;
			Pos = pos;
			Times = times;
			Angle = angle;
			Offset = offset;
			FlipX = false;
			FlipY = false;
		}

		public SDFMirror(ISDFInput input, int times)
		{
			Input = input;
			Pos = Vector2.one * 0.5f;
			Times = times;
			Angle = 0f;
			Offset = 0f;
			FlipX = false;
			FlipY = false;
		}

		public SDFMirror(TydTable t)
		{
			Pos = SVector3.Deserialize(t.GetChildValue("Pos"));
			Times = t.GetChildValue("Times").ConvertToIntDef(0);
			Angle = t.GetChildValue("Angle", false, "0").ConvertToFloatDef(0f);
			Offset = t.GetChildValue("Offset", false, "0").ConvertToFloatDef(0f);
			FlipX = t.GetChildValue("FlipX", false, "false").ConvertToBoolDef(false);
			FlipY = t.GetChildValue("FlipY", false, "false").ConvertToBoolDef(false);
		}

		public SDFMirror(SDFRandomNode node, Dictionary<string, string> tagged)
		{
			Pos = SVector3.Deserialize(node.GetValue("Pos", "0.5,0.5", tagged));
			Times = node.GetValue("Times", 2, tagged);
			Angle = node.GetValue("Angle", 0f, tagged);
			Offset = node.GetValue("Offset", 0f, tagged);
			FlipX = node.GetValue("FlipX", false, tagged);
			FlipY = node.GetValue("FlipY", false, tagged);
		}

		public void Execute(int size, RenderTexture result, Matrix4x4 m)
		{
			if (Times == 0 && !FlipX && !FlipY)
			{
				Input.Execute(size, result, m);
				return;
			}
			Vector3 position;
			Quaternion rotation;
			Vector3 scale;
			m.ExtractTRS(out position, out rotation, out scale);
			float y = rotation.eulerAngles.y;
			m = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
			RenderTexture temporary = RenderTexture.GetTemporary(size, size, 0, RenderTextureFormat.RFloat);
			Input.Execute(size, temporary, m);
			Material mirror = Instance._mirror;
			mirror.SetVector("_SDFCenter", Pos);
			mirror.SetInt("_SDFTimes", Times);
			mirror.SetFloat("_SDFAngle", Angle * ((float)Math.PI / 180f));
			mirror.SetFloat("_SDFOffset", Offset * ((float)Math.PI / 180f));
			mirror.SetVector("_SDFFlip", new Vector4(FlipX ? 1 : 0, FlipY ? 1 : 0, position.x, position.z));
			mirror.SetFloat("_SDFSubRot", y * ((float)Math.PI / 180f));
			Graphics.Blit(temporary, result, mirror);
			RenderTexture.ReleaseTemporary(temporary);
		}

		public void SetInput(ISDFNode node, int i)
		{
			Input = node as ISDFInput;
		}

		public bool IsValid()
		{
			ISDFInput input = Input;
			if (input == null)
			{
				return false;
			}
			return input.IsValid();
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, TydTable nodes, TydList connections)
		{
			Input.Serialize(ids, nodes, connections);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				connections.AddChild(new TydList(null, value.ToString(), ids[Input].ToString()));
				nodes.AddChild(new TydTable(NodeType.Mirror.ToString(), new TydString("ID", value.ToString()), new TydString("Pos", ((SVector3)Pos).Serialize(2)), new TydString("Times", Times.ToString()), new TydString("Angle", Angle.ToString()), new TydString("Offset", Offset.ToString()), new TydString("FlipX", FlipX.ToString()), new TydString("FlipY", FlipY.ToString())));
			}
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, Stream stream)
		{
			Input.Serialize(ids, stream);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				stream.WriteByte(6);
				stream.WriteByte((byte)value);
				stream.WriteFloat(Pos.x, 0f, 1f);
				stream.WriteFloat(Pos.y, 0f, 1f);
				stream.WriteByte((byte)Times);
				stream.WriteFloat(Angle.FixAngleDegrees(), 0f, 360f);
				stream.WriteFloat(Offset.FixAngleDegrees(), 0f, 360f);
				stream.WriteBools(FlipX, FlipY);
			}
		}

		public void Compare(ISDFNode other, StringBuilder sb)
		{
			if (other.GetType() != GetType())
			{
				sb.AppendLine("Difference in " + GetType().ToString() + " other is: " + other.GetType().ToString());
				return;
			}
			CompareValues(this, other, "Pos", sb);
			CompareValues(this, other, "Times", sb);
			CompareValues(this, other, "Angle", sb);
			CompareValues(this, other, "Offset", sb);
			CompareValues(this, other, "FlipX", sb);
			CompareValues(this, other, "FlipY", sb);
			CompareChildren(Input, (other as SDFMirror).Input, sb);
		}

		public void SerializeConnections(Dictionary<ISDFNode, int> ids, HashSet<ISDFNode> done, Stream stream)
		{
			Input.SerializeConnections(ids, done, stream);
			if (done.Add(this))
			{
				stream.WriteByte(2);
				stream.WriteByte((byte)ids[this]);
				stream.WriteByte((byte)ids[Input]);
			}
		}

		public int CountNodes()
		{
			ISDFInput input = Input;
			return 1 + ((input != null) ? input.CountNodes() : 0);
		}

		public SDFMirror(Vector2 pos, int times, float angle, float offset, bool flipX, bool flipY)
		{
			Pos = pos;
			Times = times;
			Angle = angle;
			Offset = offset;
			FlipX = flipX;
			FlipY = flipY;
		}

		public ISDFNode Duplicate()
		{
			return new SDFMirror(Pos, Times, Angle, Offset, FlipX, FlipY);
		}

		public SDFMirror(Stream stream, byte version)
		{
			Pos = new Vector2(stream.ReadFloat(0f, 1f), stream.ReadFloat(0f, 1f));
			Times = stream.ReadByte();
			Angle = stream.ReadFloat(0f, 360f);
			Offset = stream.ReadFloat(0f, 360f);
			if (version > 2)
			{
				stream.ReadBools(out FlipX, out FlipY);
				return;
			}
			FlipX = stream.ReadBool();
			FlipY = stream.ReadBool();
		}

		public IEnumerable<ISDFNode> GetChildren()
		{
			yield return Input;
		}
	}

	public class SDFReflect : ISDFInput, ISDFNode
	{
		public ISDFInput Input;

		public Vector2 Pos;

		public float Angle;

		public SDFReflect(ISDFInput input, Vector2 pos, float angle)
		{
			Input = input;
			Pos = pos;
			Angle = angle;
		}

		public SDFReflect(ISDFInput input)
		{
			Input = input;
			Pos = Vector2.one * 0.5f;
			Angle = 0f;
		}

		public SDFReflect(TydTable t)
		{
			Pos = SVector3.Deserialize(t.GetChildValue("Pos"));
			Angle = t.GetChildValue("Angle", false, "0").ConvertToFloatDef(0f);
		}

		public SDFReflect(SDFRandomNode node, Dictionary<string, string> tagged)
		{
			Pos = SVector3.Deserialize(node.GetValue("Pos", "0.5,0.5", tagged));
			Angle = node.GetValue("Angle", 0f, tagged);
		}

		public void Execute(int size, RenderTexture result, Matrix4x4 m)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(size, size, 0, RenderTextureFormat.RFloat);
			Input.Execute(size, temporary, m);
			Material reflect = Instance._reflect;
			reflect.SetVector("_SDFCenter", Pos);
			reflect.SetFloat("_SDFAngle", Angle * ((float)Math.PI / 180f));
			Graphics.Blit(temporary, result, reflect);
			RenderTexture.ReleaseTemporary(temporary);
		}

		public void SetInput(ISDFNode node, int i)
		{
			Input = node as ISDFInput;
		}

		public bool IsValid()
		{
			ISDFInput input = Input;
			if (input == null)
			{
				return false;
			}
			return input.IsValid();
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, TydTable nodes, TydList connections)
		{
			Input.Serialize(ids, nodes, connections);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				connections.AddChild(new TydList(null, value.ToString(), ids[Input].ToString()));
				nodes.AddChild(new TydTable(NodeType.Reflect.ToString(), new TydString("ID", value.ToString()), new TydString("Pos", ((SVector3)Pos).Serialize(2)), new TydString("Angle", Angle.ToString())));
			}
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, Stream stream)
		{
			Input.Serialize(ids, stream);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				stream.WriteByte(10);
				stream.WriteByte((byte)value);
				stream.WriteFloat(Pos.x, 0f, 1f);
				stream.WriteFloat(Pos.y, 0f, 1f);
				stream.WriteFloat(Angle.FixAngleDegrees(), 0f, 360f);
			}
		}

		public void Compare(ISDFNode other, StringBuilder sb)
		{
			if (other.GetType() != GetType())
			{
				sb.AppendLine("Difference in " + GetType().ToString() + " other is: " + other.GetType().ToString());
				return;
			}
			CompareValues(this, other, "Pos", sb);
			CompareValues(this, other, "Angle", sb);
			CompareChildren(Input, (other as SDFReflect).Input, sb);
		}

		public void SerializeConnections(Dictionary<ISDFNode, int> ids, HashSet<ISDFNode> done, Stream stream)
		{
			Input.SerializeConnections(ids, done, stream);
			if (done.Add(this))
			{
				stream.WriteByte(2);
				stream.WriteByte((byte)ids[this]);
				stream.WriteByte((byte)ids[Input]);
			}
		}

		public int CountNodes()
		{
			ISDFInput input = Input;
			return 1 + ((input != null) ? input.CountNodes() : 0);
		}

		public SDFReflect(Vector2 pos, float angle)
		{
			Pos = pos;
			Angle = angle;
		}

		public ISDFNode Duplicate()
		{
			return new SDFReflect(Pos, Angle);
		}

		public SDFReflect(Stream stream, byte version)
		{
			Pos = new Vector2(stream.ReadFloat(0f, 1f), stream.ReadFloat(0f, 1f));
			Angle = stream.ReadFloat(0f, 360f);
		}

		public IEnumerable<ISDFNode> GetChildren()
		{
			yield return Input;
		}
	}

	[Serializable]
	public class SDFCombine : ISDFInput, ISDFNode
	{
		public ISDFInput Input1;

		public ISDFInput Input2;

		public CombineFunction Function;

		public float Param;

		public CombineFunction SimpleFunction()
		{
			switch (Function)
			{
			case CombineFunction.Union:
			case CombineFunction.RoundUnion:
				return CombineFunction.Union;
			case CombineFunction.Intersection:
			case CombineFunction.RoundIntersection:
				return CombineFunction.Intersection;
			case CombineFunction.Subtraction:
			case CombineFunction.RoundSubtraction:
				return CombineFunction.Subtraction;
			case CombineFunction.Lerp:
				return CombineFunction.Lerp;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		public SDFCombine(ISDFInput input1, ISDFInput input2, CombineFunction function, float param)
		{
			Input1 = input1;
			Input2 = input2;
			Function = function;
			Param = param;
		}

		public SDFCombine(ISDFInput input1, ISDFInput input2, CombineFunction function)
		{
			Input1 = input1;
			Input2 = input2;
			Function = function;
			Param = 0f;
		}

		public SDFCombine(TydTable t)
		{
			Function = t.GetChildValue("Function").ToEnum<CombineFunction>();
			Param = t.GetChildValue("Param").ConvertToFloatDef(0f);
		}

		public SDFCombine(SDFRandomNode node, Dictionary<string, string> tagged)
		{
			Function = node.GetValue("Function", CombineFunction.Union, tagged);
			Param = node.GetValue("Param", 0f, tagged);
		}

		public void Execute(int size, RenderTexture result, Matrix4x4 m)
		{
			if (Function == CombineFunction.Lerp)
			{
				if (Param == 0f)
				{
					Input1.Execute(size, result, m);
					return;
				}
				if (Param == 1f)
				{
					Input2.Execute(size, result, m);
					return;
				}
			}
			RenderTexture temporary = RenderTexture.GetTemporary(size, size, 0, RenderTextureFormat.RFloat);
			Input1.Execute(size, temporary, m);
			RenderTexture temporary2 = RenderTexture.GetTemporary(size, size, 0, RenderTextureFormat.RFloat);
			Input2.Execute(size, temporary2, m);
			Material combine = Instance._combine;
			combine.SetInt("_SDFFunction", (int)Function);
			combine.SetFloat("_SDFParam", Param);
			combine.SetTexture("_MainTex2", temporary2);
			Graphics.Blit(temporary, result, combine);
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(temporary2);
		}

		public void SetInput(ISDFNode node, int i)
		{
			if (i == 0)
			{
				Input1 = node as ISDFInput;
			}
			else
			{
				Input2 = node as ISDFInput;
			}
		}

		public bool IsValid()
		{
			ISDFInput input = Input1;
			if (input != null && input.IsValid())
			{
				ISDFInput input2 = Input2;
				if (input2 == null)
				{
					return false;
				}
				return input2.IsValid();
			}
			return false;
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, TydTable nodes, TydList connections)
		{
			Input1.Serialize(ids, nodes, connections);
			Input2.Serialize(ids, nodes, connections);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				connections.AddChild(new TydList(null, value.ToString(), ids[Input1].ToString(), ids[Input2].ToString()));
				nodes.AddChild(new TydTable(NodeType.Combine.ToString(), new TydString("ID", value.ToString()), new TydString("Function", Function.ToString()), new TydString("Param", Param.ToString())));
			}
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, Stream stream)
		{
			Input1.Serialize(ids, stream);
			Input2.Serialize(ids, stream);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				stream.WriteByte(2);
				stream.WriteByte((byte)value);
				stream.WriteByte((byte)Function);
				stream.WriteFloat(Param, 0f, 1f);
			}
		}

		public void Compare(ISDFNode other, StringBuilder sb)
		{
			if (other.GetType() != GetType())
			{
				sb.AppendLine("Difference in " + GetType().ToString() + " other is: " + other.GetType().ToString());
				return;
			}
			CompareValues(this, other, "Function", sb);
			CompareValues(this, other, "Param", sb);
			CompareChildren(Input1, (other as SDFCombine).Input1, sb);
			CompareChildren(Input2, (other as SDFCombine).Input2, sb);
		}

		public void SerializeConnections(Dictionary<ISDFNode, int> ids, HashSet<ISDFNode> done, Stream stream)
		{
			Input1.SerializeConnections(ids, done, stream);
			Input2.SerializeConnections(ids, done, stream);
			if (done.Add(this))
			{
				stream.WriteByte(3);
				stream.WriteByte((byte)ids[this]);
				stream.WriteByte((byte)ids[Input1]);
				stream.WriteByte((byte)ids[Input2]);
			}
		}

		public int CountNodes()
		{
			ISDFInput input = Input1;
			int num = 1 + ((input != null) ? input.CountNodes() : 0);
			ISDFInput input2 = Input2;
			return num + ((input2 != null) ? input2.CountNodes() : 0);
		}

		public SDFCombine(CombineFunction function, float param)
		{
			Function = function;
			Param = param;
		}

		public ISDFNode Duplicate()
		{
			return new SDFCombine(Function, Param);
		}

		public SDFCombine(Stream stream, byte version)
		{
			Function = (CombineFunction)stream.ReadByte();
			Param = stream.ReadFloat(0f, 1f);
		}

		public IEnumerable<ISDFNode> GetChildren()
		{
			yield return Input1;
			yield return Input2;
		}
	}

	[Serializable]
	public class SDFExport : ISDFOutput, ISDFNode
	{
		public ISDFInput Input;

		public ISDFInput ColorSDF;

		public Color MainColor;

		public Color GradientColor;

		public Color OutlineColor;

		public float Threshold;

		public float Outline;

		public Vector2 Pos = Vector2.zero;

		public Vector2 Scale = Vector2.one;

		public float Rotation;

		public float GradientRotation;

		public bool GradientLinear = true;

		public SDFExport(ISDFInput input, Color mainColor, Color outlineColor, float threshold, float outline)
		{
			Input = input;
			MainColor = (GradientColor = mainColor);
			OutlineColor = outlineColor;
			Threshold = threshold;
			Outline = outline;
			Pos = Vector2.zero;
			Scale = Vector2.one;
			GradientRotation = (Rotation = 0f);
		}

		public SDFExport(ISDFInput input, Color mainColor)
		{
			Input = input;
			MainColor = (GradientColor = mainColor);
			OutlineColor = mainColor;
		}

		public SDFExport(TydTable t)
		{
			Color color;
			MainColor = (ColorUtility.TryParseHtmlString("#" + t.GetChildValue("MainColor"), out color) ? color : Color.white);
			Color color2;
			GradientColor = (ColorUtility.TryParseHtmlString("#" + t.GetChildValue("GradientColor"), out color2) ? color2 : Color.white);
			Color color3;
			OutlineColor = (ColorUtility.TryParseHtmlString("#" + t.GetChildValue("OutlineColor"), out color3) ? color3 : Color.white);
			Threshold = t.GetChildValue("Threshold").ConvertToFloatDef(0f);
			Outline = t.GetChildValue("Outline").ConvertToFloatDef(0f);
			Pos = SVector3.Deserialize(t.GetChildValue("Pos"));
			Scale = SVector3.Deserialize(t.GetChildValue("Scale"));
			Rotation = t.GetChildValue("Rotation").ConvertToFloatDef(0f);
			GradientRotation = t.GetChildValue("GradientRotation").ConvertToFloatDef(0f);
			GradientLinear = t.GetChildValue("GradientLinear", false, "true").ConvertToBoolDef(true);
		}

		public SDFExport(SDFRandomNode node, Dictionary<string, Color> colors, Dictionary<string, string> tagged)
		{
			MainColor = colors[node.GetValue("MainColor", "Primary", tagged)];
			GradientColor = colors[node.GetValue("GradientColor", "Secondary", tagged)];
			OutlineColor = colors[node.GetValue("OutlineColor", "Tertiary", tagged)];
			Pos = SVector3.Deserialize(node.GetValue("Pos", "0,0", tagged));
			Scale = SVector3.Deserialize(node.GetValue("Scale", "1,1", tagged));
			Rotation = node.GetValue("Rotation", 0f, tagged);
			Threshold = node.GetValue("Threshold", 0f, tagged);
			Outline = node.GetValue("Outline", 0f, tagged);
			GradientRotation = node.GetValue("GradientRotation", 0f, tagged);
			GradientLinear = node.GetValue("GradientLinear", true, tagged);
		}

		public void Execute(int size, RenderTexture result, Matrix4x4 m)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(size, size, 0, RenderTextureFormat.RFloat);
			Input.Execute(size, temporary, m);
			Material finalMat = Instance._finalMat;
			RenderTexture renderTexture = null;
			if (ColorSDF != null && ColorSDF.IsValid())
			{
				renderTexture = RenderTexture.GetTemporary(size, size, 0, RenderTextureFormat.RFloat);
				ColorSDF.Execute(size, renderTexture, m);
				finalMat.SetTexture("_ColorSDF", renderTexture);
				finalMat.SetInt("_UseSDFColor", 1);
			}
			else
			{
				finalMat.SetInt("_UseSDFColor", 0);
			}
			finalMat.SetColor("_Color", MainColor);
			finalMat.SetColor("_Color2", GradientColor);
			finalMat.SetColor("_OutlineColor", OutlineColor);
			finalMat.SetFloat("_SDFThreshold", Threshold);
			finalMat.SetFloat("_SDFOutline", Outline);
			finalMat.SetVector("_TranslationScale", new Vector4(Pos.x, Pos.y, Scale.x, Scale.y));
			finalMat.SetFloat("_Rotation", Rotation * ((float)Math.PI / 180f));
			finalMat.SetFloat("_GradRotation", GradientRotation * ((float)Math.PI / 180f));
			finalMat.SetInt("_GradLinear", GradientLinear ? 1 : 0);
			Graphics.Blit(temporary, result, finalMat);
			RenderTexture.ReleaseTemporary(temporary);
			if (renderTexture != null)
			{
				RenderTexture.ReleaseTemporary(renderTexture);
			}
		}

		public void SetInput(ISDFNode node, int i)
		{
			if (i == 0)
			{
				Input = node as ISDFInput;
			}
			else
			{
				ColorSDF = node as ISDFInput;
			}
		}

		public bool IsValid()
		{
			ISDFInput input = Input;
			if (input == null)
			{
				return false;
			}
			return input.IsValid();
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, TydTable nodes, TydList connections)
		{
			Input.Serialize(ids, nodes, connections);
			bool flag = ColorSDF != null && ColorSDF.IsValid();
			if (flag)
			{
				ColorSDF.Serialize(ids, nodes, connections);
			}
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				if (flag)
				{
					connections.AddChild(new TydList(null, value.ToString(), ids[Input].ToString(), ids[ColorSDF].ToString()));
				}
				else
				{
					connections.AddChild(new TydList(null, value.ToString(), ids[Input].ToString()));
				}
				nodes.AddChild(new TydTable(NodeType.Color.ToString(), new TydString("ID", value.ToString()), new TydString("MainColor", ColorUtility.ToHtmlStringRGB(MainColor)), new TydString("GradientColor", ColorUtility.ToHtmlStringRGB(GradientColor)), new TydString("OutlineColor", ColorUtility.ToHtmlStringRGB(OutlineColor)), new TydString("Threshold", Threshold.ToString()), new TydString("Outline", Outline.ToString()), new TydString("Pos", ((SVector3)Pos).Serialize(2)), new TydString("Scale", ((SVector3)Scale).Serialize(2)), new TydString("Rotation", Rotation.ToString()), new TydString("GradientRotation", GradientRotation.ToString()), new TydString("GradientLinear", GradientLinear.ToString())));
			}
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, Stream stream)
		{
			Input.Serialize(ids, stream);
			if (ColorSDF != null && ColorSDF.IsValid())
			{
				ColorSDF.Serialize(ids, stream);
			}
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				stream.WriteByte(3);
				stream.WriteByte((byte)value);
				bool flag = Pos != Vector2.zero;
				bool flag2 = Scale != Vector2.zero;
				bool flag3 = Rotation != 0f;
				bool flag4 = Threshold != 0f;
				bool flag5 = Outline != 0f;
				bool flag6 = GradientRotation != 0f;
				bool flag7 = MainColor != GradientColor;
				stream.WriteBools(flag, flag2, flag3, flag4, flag5, flag6, GradientLinear, flag7);
				stream.WriteColor(MainColor, false);
				if (flag7)
				{
					stream.WriteColor(GradientColor, false);
				}
				if (flag5)
				{
					stream.WriteFloat(Outline, 0f, 1f);
				}
				if (Outline > 0f)
				{
					stream.WriteColor(OutlineColor, false);
				}
				if (flag4)
				{
					stream.WriteFloat(Threshold, -1f, 1f);
				}
				if (flag)
				{
					stream.WriteFloat(Pos.x, -1f, 1f);
					stream.WriteFloat(Pos.y, -1f, 1f);
				}
				if (flag2)
				{
					stream.WriteFloat(Scale.x, 0f, 2f);
				}
				if (flag3)
				{
					stream.WriteFloat(Rotation.FixAngleDegrees(), 0f, 360f);
				}
				if (flag6)
				{
					stream.WriteFloat(GradientRotation);
				}
			}
		}

		public void Compare(ISDFNode other, StringBuilder sb)
		{
			if (other.GetType() != GetType())
			{
				sb.AppendLine("Difference in " + GetType().ToString() + " other is: " + other.GetType().ToString());
				return;
			}
			CompareValues(this, other, "Pos", sb);
			CompareValues(this, other, "Scale", sb);
			CompareValues(this, other, "Rotation", sb);
			CompareValues(this, other, "Threshold", sb);
			CompareValues(this, other, "Outline", sb);
			CompareValues(this, other, "GradientRotation", sb);
			CompareValues(this, other, "MainColor", sb);
			CompareValues(this, other, "GradientColor", sb);
			CompareValues(this, other, "OutlineColor", sb);
			CompareChildren(Input, (other as SDFExport).Input, sb);
			CompareChildren(ColorSDF, (other as SDFExport).ColorSDF, sb);
		}

		public void SerializeConnections(Dictionary<ISDFNode, int> ids, HashSet<ISDFNode> done, Stream stream)
		{
			Input.SerializeConnections(ids, done, stream);
			bool flag = ColorSDF != null && ColorSDF.IsValid();
			if (flag)
			{
				ColorSDF.SerializeConnections(ids, done, stream);
			}
			if (done.Add(this))
			{
				if (flag)
				{
					stream.WriteByte(3);
					stream.WriteByte((byte)ids[this]);
					stream.WriteByte((byte)ids[Input]);
					stream.WriteByte((byte)ids[ColorSDF]);
				}
				else
				{
					stream.WriteByte(2);
					stream.WriteByte((byte)ids[this]);
					stream.WriteByte((byte)ids[Input]);
				}
			}
		}

		public int CountNodes()
		{
			ISDFInput input = Input;
			int num = 1 + ((input != null) ? input.CountNodes() : 0);
			ISDFInput colorSDF = ColorSDF;
			return num + ((colorSDF != null) ? colorSDF.CountNodes() : 0);
		}

		public SDFExport(Color mainColor, Color gradientColor, Color outlineColor, float threshold, float outline, Vector2 pos, Vector2 scale, float rotation, float gradientRotation, bool gradientLinear)
		{
			MainColor = mainColor;
			GradientColor = gradientColor;
			OutlineColor = outlineColor;
			Threshold = threshold;
			Outline = outline;
			Pos = pos;
			Scale = scale;
			Rotation = rotation;
			GradientRotation = gradientRotation;
			GradientLinear = gradientLinear;
		}

		public ISDFNode Duplicate()
		{
			return new SDFExport(MainColor, GradientColor, OutlineColor, Threshold, Outline, Pos, Scale, Rotation, GradientRotation, GradientLinear);
		}

		public SDFExport(Stream stream, byte version)
		{
			bool b = true;
			bool b2 = true;
			bool b3 = true;
			bool b4 = true;
			bool b5 = true;
			bool b6 = true;
			bool b7 = true;
			bool b8 = true;
			if (version > 2)
			{
				stream.ReadBools(out b, out b2, out b3, out b4, out b5, out b6, out b7, out b8);
				b8 = b8 || version < 4;
				GradientLinear = b7;
				b7 = false;
			}
			if (version == 0)
			{
				MainColor = stream.ReadColor();
				GradientColor = stream.ReadColor();
				OutlineColor = stream.ReadColor();
				Threshold = stream.ReadFloat(-1f, 1f);
				Outline = stream.ReadFloat(0f, 1f);
			}
			else
			{
				MainColor = stream.ReadColor(false);
				if (b8)
				{
					GradientColor = stream.ReadColor(false);
				}
				else
				{
					GradientColor = MainColor;
				}
				if (b5)
				{
					Outline = stream.ReadFloat(0f, 1f);
				}
				OutlineColor = ((Outline > 0f) ? ((Color)stream.ReadColor(false)) : Color.black);
				if (b4)
				{
					Threshold = stream.ReadFloat(-1f, 1f);
				}
			}
			if (b)
			{
				Pos = new Vector2(stream.ReadFloat(-1f, 1f), stream.ReadFloat(-1f, 1f));
			}
			if (b2)
			{
				float num = stream.ReadFloat(0f, 2f);
				Scale = Vector2.one * num;
			}
			if (b3)
			{
				Rotation = stream.ReadFloat(0f, 360f);
			}
			if (b6)
			{
				GradientRotation = ((version > 4) ? stream.ReadFloat() : stream.ReadFloat(0f, 360f));
			}
			if (b7)
			{
				GradientLinear = stream.ReadBool();
			}
		}

		public IEnumerable<ISDFNode> GetChildren()
		{
			yield return Input;
			yield return ColorSDF;
		}
	}

	[Serializable]
	public class SDFMix : ISDFOutput, ISDFNode
	{
		public ISDFOutput Input1;

		public ISDFOutput Input2;

		public Vector2 Pos = Vector2.zero;

		public Vector2 Scale = Vector2.one;

		public float Rotation;

		public SDFMix(ISDFOutput input1, ISDFOutput input2, Vector2 pos, Vector2 scale, float rotation)
		{
			Input1 = input1;
			Input2 = input2;
			Pos = pos;
			Scale = scale;
			Rotation = rotation;
		}

		public SDFMix(ISDFOutput input1, ISDFOutput input2, Vector2 pos)
		{
			Input1 = input1;
			Input2 = input2;
			Pos = pos;
		}

		public SDFMix(TydTable t)
		{
			Pos = SVector3.Deserialize(t.GetChildValue("Pos"));
			Scale = SVector3.Deserialize(t.GetChildValue("Scale"));
			Rotation = t.GetChildValue("Rotation").ConvertToFloatDef(0f);
		}

		public SDFMix(SDFRandomNode node, Dictionary<string, string> tagged)
		{
			Pos = SVector3.Deserialize(node.GetValue("Pos", "0,0", tagged));
			Scale = SVector3.Deserialize(node.GetValue("Scale", "1,1", tagged));
			Rotation = node.GetValue("Rotation", 0f, tagged);
		}

		public void Execute(int size, RenderTexture result, Matrix4x4 m)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(size, size, 0, RenderTextureFormat.ARGB32);
			Input1.Execute(size, temporary, m);
			RenderTexture temporary2 = RenderTexture.GetTemporary(size, size, 0, RenderTextureFormat.ARGB32);
			Input2.Execute(size, temporary2, m);
			Material mix = Instance._mix;
			mix.SetVector("_TranslationScale", new Vector4(Pos.x, Pos.y, Scale.x, Scale.y));
			mix.SetFloat("_Rotation", Rotation * ((float)Math.PI / 180f));
			mix.SetTexture("_BackTex", temporary);
			Graphics.Blit(temporary2, result, mix);
			RenderTexture.ReleaseTemporary(temporary2);
			RenderTexture.ReleaseTemporary(temporary);
		}

		public void SetInput(ISDFNode node, int i)
		{
			if (i == 0)
			{
				Input1 = node as ISDFOutput;
			}
			else
			{
				Input2 = node as ISDFOutput;
			}
		}

		public bool IsValid()
		{
			ISDFOutput input = Input1;
			if (input != null && input.IsValid())
			{
				ISDFOutput input2 = Input2;
				if (input2 == null)
				{
					return false;
				}
				return input2.IsValid();
			}
			return false;
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, TydTable nodes, TydList connections)
		{
			Input1.Serialize(ids, nodes, connections);
			Input2.Serialize(ids, nodes, connections);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				connections.AddChild(new TydList(null, value.ToString(), ids[Input1].ToString(), ids[Input2].ToString()));
				nodes.AddChild(new TydTable(NodeType.Mix.ToString(), new TydString("ID", value.ToString()), new TydString("Pos", ((SVector3)Pos).Serialize(2)), new TydString("Scale", ((SVector3)Scale).Serialize(2)), new TydString("Rotation", Rotation.ToString())));
			}
		}

		public void Serialize(Dictionary<ISDFNode, int> ids, Stream stream)
		{
			Input1.Serialize(ids, stream);
			Input2.Serialize(ids, stream);
			int value;
			if (!ids.TryGetValue(this, out value))
			{
				value = (ids[this] = ids.MaxSafeInt((KeyValuePair<ISDFNode, int> x) => x.Value, 0) + 1);
				stream.WriteByte(4);
				stream.WriteByte((byte)value);
				bool flag = Pos != Vector2.zero;
				bool flag2 = Scale != Vector2.one;
				bool flag3 = Rotation != 0f;
				stream.WriteBools(flag, flag2, flag3);
				if (flag)
				{
					stream.WriteFloat(Pos.x, -1f, 1f);
					stream.WriteFloat(Pos.y, -1f, 1f);
				}
				if (flag2)
				{
					stream.WriteFloat(Scale.x, 0f, 2f);
				}
				if (flag3)
				{
					stream.WriteFloat(Rotation.FixAngleDegrees(), 0f, 360f);
				}
			}
		}

		public void Compare(ISDFNode other, StringBuilder sb)
		{
			if (other.GetType() != GetType())
			{
				sb.AppendLine("Difference in " + GetType().ToString() + " other is: " + other.GetType().ToString());
				return;
			}
			CompareValues(this, other, "Pos", sb);
			CompareValues(this, other, "Scale", sb);
			CompareValues(this, other, "Rotation", sb);
			CompareChildren(Input1, (other as SDFMix).Input1, sb);
			CompareChildren(Input2, (other as SDFMix).Input2, sb);
		}

		public void SerializeConnections(Dictionary<ISDFNode, int> ids, HashSet<ISDFNode> done, Stream stream)
		{
			Input1.SerializeConnections(ids, done, stream);
			Input2.SerializeConnections(ids, done, stream);
			if (done.Add(this))
			{
				stream.WriteByte(3);
				stream.WriteByte((byte)ids[this]);
				stream.WriteByte((byte)ids[Input1]);
				stream.WriteByte((byte)ids[Input2]);
			}
		}

		public int CountNodes()
		{
			ISDFOutput input = Input1;
			int num = 1 + ((input != null) ? input.CountNodes() : 0);
			ISDFOutput input2 = Input2;
			return num + ((input2 != null) ? input2.CountNodes() : 0);
		}

		public SDFMix(Vector2 pos, Vector2 scale, float rotation)
		{
			Pos = pos;
			Scale = scale;
			Rotation = rotation;
		}

		public ISDFNode Duplicate()
		{
			return new SDFMix(Pos, Scale, Rotation);
		}

		public SDFMix(Stream stream, byte version)
		{
			bool b = true;
			bool b2 = true;
			bool b3 = true;
			if (version > 2)
			{
				stream.ReadBools(out b, out b2, out b3);
			}
			if (b)
			{
				Pos = new Vector2(stream.ReadFloat(-1f, 1f), stream.ReadFloat(-1f, 1f));
			}
			if (b2)
			{
				float num = stream.ReadFloat(0f, 2f);
				Scale = Vector2.one * num;
			}
			if (b3)
			{
				Rotation = stream.ReadFloat(0f, 360f);
			}
		}

		public IEnumerable<ISDFNode> GetChildren()
		{
			yield return Input1;
			yield return Input2;
		}
	}

	public enum NodeType
	{
		Shape = 0,
		Effect = 1,
		Combine = 2,
		Color = 3,
		Mix = 4,
		Transform = 5,
		Mirror = 6,
		Texture = 7,
		Array = 8,
		Stop = 9,
		Reflect = 10
	}

	public enum CombineFunction
	{
		Union = 0,
		Intersection = 1,
		Subtraction = 2,
		Lerp = 3,
		RoundUnion = 4,
		RoundIntersection = 5,
		RoundSubtraction = 6
	}

	public enum SDFFunction
	{
		Circle = 0,
		Capsule = 1,
		Box = 2,
		RoundedBox = 3,
		Rhombus = 4,
		Trapez = 5,
		Triangle = 6,
		Pentagon = 7,
		Hexagon = 8,
		Octagon = 9,
		Star = 10,
		Pie = 11,
		CutDisk = 12,
		RoundedX = 14,
		Cross = 15,
		QuadCircle = 16,
		Vesica = 17,
		Grid = 18
	}

	public struct ParameterInfo
	{
		public string Name;

		public float Min;

		public float Max;

		public float Default;

		public bool UseSlider;

		public Vector2 Start;

		public Vector2 End;

		public ParameterInfo(string name, float min = 0f, float max = 1f, float def = 1f)
		{
			Name = name;
			Min = min;
			Max = max;
			Default = def;
			UseSlider = false;
			Start = Vector2.zero;
			End = Vector2.zero;
		}

		public ParameterInfo(string name, float min, float max, float def, Vector2 start, Vector2 end)
		{
			Name = name;
			Min = min;
			Max = max;
			Default = def;
			UseSlider = true;
			Start = start;
			End = end;
		}

		public ParameterInfo(string name, float min, float max, Vector2 start, Vector2 end)
		{
			Name = name;
			Min = min;
			Max = max;
			Default = 1f;
			UseSlider = true;
			Start = start;
			End = end;
		}

		public ParameterInfo(string name, float def)
		{
			Name = name;
			Min = 0f;
			Max = 1f;
			Default = def;
			UseSlider = false;
			Start = Vector2.zero;
			End = Vector2.zero;
		}

		public ParameterInfo(string name, Vector2 start, Vector2 end)
		{
			Name = name;
			Min = 0f;
			Max = 1f;
			Default = 1f;
			UseSlider = true;
			Start = start;
			End = end;
		}

		public ParameterInfo(string name, float def, Vector2 start, Vector2 end)
		{
			Name = name;
			Min = 0f;
			Max = 1f;
			Default = def;
			UseSlider = true;
			Start = start;
			End = end;
		}

		public static implicit operator ParameterInfo(string c)
		{
			return new ParameterInfo(c);
		}
	}

	public const byte Version = 6;

	private static bool _bound;

	private static SDFCreator _instance;

	public const int SmallTextureSize = 128;

	public const int TextureSize = 256;

	[NonSerialized]
	private Material _sdfMat;

	[NonSerialized]
	private Material _combine;

	[NonSerialized]
	private Material _effect;

	[NonSerialized]
	private Material _mix;

	[NonSerialized]
	private Material _mirror;

	[NonSerialized]
	private Material _reflect;

	[NonSerialized]
	private Material _texture;

	[NonSerialized]
	private Material _array;

	[NonSerialized]
	private Material _finalMat;

	[NonSerialized]
	private Dictionary<string, Texture2D> _textureCache = new Dictionary<string, Texture2D>();

	[NonSerialized]
	private Dictionary<string, List<SDFRandomNode>> _randomTrees = new Dictionary<string, List<SDFRandomNode>>();

	public const int MaxLogoSize = 512;

	public const int ECC = 32;

	public static SDFCreator Instance
	{
		get
		{
			Bind();
			return _instance;
		}
	}

	public static void CompareChildren(ISDFNode a, ISDFNode b, StringBuilder sb)
	{
		if (a == null)
		{
			if (b != null)
			{
				sb.AppendLine("Difference in " + b.GetType().Name + ": a is null");
			}
		}
		else if (b == null)
		{
			sb.AppendLine("Difference in " + a.GetType().Name + ": b is null");
		}
		else
		{
			a.Compare(b, sb);
		}
	}

	public static void CompareValues(ISDFNode node, ISDFNode node2, string field, StringBuilder sb)
	{
		FieldInfo field2 = node.GetType().GetField(field, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
		object value = field2.GetValue(node);
		object value2 = field2.GetValue(node2);
		if (!value.Equals(value2))
		{
			sb.AppendLine("Difference in " + node.GetType().Name + ": " + field + " = " + value.ToString() + " vs. " + value2.ToString());
		}
	}

	public static string GetCombineLoc(CombineFunction c)
	{
		switch (c)
		{
		case CombineFunction.Union:
		case CombineFunction.RoundUnion:
			return "SDFUnion";
		case CombineFunction.Intersection:
		case CombineFunction.RoundIntersection:
			return "SDFIntersection";
		case CombineFunction.Subtraction:
		case CombineFunction.RoundSubtraction:
			return "SDFSubtract";
		case CombineFunction.Lerp:
			return "SDFInterpolate";
		default:
			throw new ArgumentOutOfRangeException("c", c, null);
		}
	}

	public static Vector4 GetDefaultParameters(SDFFunction f)
	{
		ParameterInfo[] parameters = GetParameters(f);
		return new Vector4((parameters.Length != 0) ? parameters[0].Default : 1f, (parameters.Length > 1) ? parameters[1].Default : 1f, (parameters.Length > 2) ? parameters[2].Default : 1f, (parameters.Length > 3) ? parameters[3].Default : 1f);
	}

	public static ParameterInfo[] GetParameters(SDFFunction f)
	{
		switch (f)
		{
		case SDFFunction.Circle:
			return new ParameterInfo[2]
			{
				new ParameterInfo("Radius", Vector2.zero, Vector2.right),
				new ParameterInfo("Height", Vector2.zero, Vector2.up)
			};
		case SDFFunction.Capsule:
			return new ParameterInfo[3]
			{
				new ParameterInfo("Radius", 0.5f, -Vector2.one * 0.5f, -Vector2.one),
				new ParameterInfo("Radius", 0.5f, Vector2.one * 0.5f, Vector2.one),
				new ParameterInfo("Length", 0.5f, Vector2.zero, Vector2.up)
			};
		case SDFFunction.Box:
			return new ParameterInfo[2]
			{
				new ParameterInfo("Width", Vector2.zero, Vector2.right),
				new ParameterInfo("Height", Vector2.zero, Vector2.up)
			};
		case SDFFunction.RoundedBox:
			return new ParameterInfo[4]
			{
				new ParameterInfo("Width", Vector2.zero, Vector2.right),
				new ParameterInfo("Height", Vector2.zero, Vector2.up),
				new ParameterInfo("Radius", 0.5f, Vector2.one, Vector2.one * 0.71f),
				new ParameterInfo("Radius", 0.5f, -Vector2.one, -Vector2.one * 0.71f)
			};
		case SDFFunction.Rhombus:
			return new ParameterInfo[2]
			{
				new ParameterInfo("Width", Vector2.zero, Vector2.right),
				new ParameterInfo("Height", Vector2.zero, Vector2.up)
			};
		case SDFFunction.Trapez:
			return new ParameterInfo[3]
			{
				new ParameterInfo("Width", Vector2.down, -Vector2.one),
				new ParameterInfo("Width", 0.5f, Vector2.up, Vector2.one),
				new ParameterInfo("Height", Vector2.zero, Vector2.up)
			};
		case SDFFunction.Triangle:
			return new ParameterInfo[2]
			{
				new ParameterInfo("Width", Vector2.down, -Vector2.one),
				new ParameterInfo("Height", Vector2.up * 0.5f, Vector2.up)
			};
		case SDFFunction.Pentagon:
			return new ParameterInfo[1]
			{
				new ParameterInfo("Radius", Vector2.zero, Vector2.right)
			};
		case SDFFunction.Hexagon:
			return new ParameterInfo[1]
			{
				new ParameterInfo("Radius", Vector2.zero, Vector2.right)
			};
		case SDFFunction.Octagon:
			return new ParameterInfo[1]
			{
				new ParameterInfo("Radius", Vector2.zero, Vector2.right)
			};
		case SDFFunction.Star:
			return new ParameterInfo[2]
			{
				new ParameterInfo("Radius", Vector2.zero, Vector2.up),
				new ParameterInfo("Radius", 0.5f, Vector2.zero, Vector2.one * 0.71f)
			};
		case SDFFunction.Pie:
			return new ParameterInfo[2]
			{
				new ParameterInfo("Angle", 0f, (float)Math.PI, Vector2.up, Vector2.down),
				new ParameterInfo("Radius", Vector2.zero, Vector2.right)
			};
		case SDFFunction.CutDisk:
			return new ParameterInfo[2]
			{
				new ParameterInfo("Radius", Vector2.zero, Vector2.right),
				new ParameterInfo("Height", -1f, 1f, 0.5f, Vector2.down, Vector2.up)
			};
		case SDFFunction.RoundedX:
			return new ParameterInfo[2]
			{
				new ParameterInfo("Length", Vector2.zero, Vector2.one),
				new ParameterInfo("Radius", 0.25f, Vector2.zero, Vector2.right * 0.9f)
			};
		case SDFFunction.Cross:
			return new ParameterInfo[3]
			{
				new ParameterInfo("Length", Vector2.zero, Vector2.right),
				new ParameterInfo("Width", 0.5f, Vector2.zero, Vector2.one),
				new ParameterInfo("Radius", 0.25f, -Vector2.one, Vector2.zero)
			};
		case SDFFunction.QuadCircle:
			return Array.Empty<ParameterInfo>();
		case SDFFunction.Vesica:
			return new ParameterInfo[2]
			{
				new ParameterInfo("Radius", Vector2.zero, Vector2.up),
				new ParameterInfo("Width", 0.5f, Vector2.right, Vector2.zero)
			};
		case SDFFunction.Grid:
			return new ParameterInfo[3]
			{
				new ParameterInfo("Width", 0f, 10f, 2f, Vector2.zero, Vector2.right),
				new ParameterInfo("Height", 0f, 10f, 2f, Vector2.zero, Vector2.up),
				new ParameterInfo("Thickness", 0.1f, -Vector2.one * 0.25f, Vector2.one * 0.25f)
			};
		default:
			return Array.Empty<ParameterInfo>();
		}
	}

	public static void Bind()
	{
		if (!_bound)
		{
			_instance = UnityEngine.Object.Instantiate(Resources.Load<SDFCreator>("SDFCreator"));
			_bound = true;
		}
	}

	public SDFRandomNode GetSpecificTree(string name, string cat)
	{
		return _randomTrees[cat].FirstOrDefault((SDFRandomNode x) => x.Name.Equals(name));
	}

	public SDFRandomNode FindSpecificTree(string name)
	{
		foreach (List<SDFRandomNode> value in _randomTrees.Values)
		{
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i].Name.Equals(name))
				{
					return value[i];
				}
			}
		}
		return null;
	}

	public SDFRandomNode GetRandomTree(string key)
	{
		List<SDFRandomNode> list = _randomTrees[key];
		float num = Utilities.RandomRange(0f, list.SumSafe((SDFRandomNode x) => x.Weight));
		SDFRandomNode sDFRandomNode = null;
		float num2 = 0f;
		for (int num3 = 0; num3 < list.Count; num3++)
		{
			sDFRandomNode = list[num3];
			num2 += sDFRandomNode.Weight;
			if (num2 > num)
			{
				break;
			}
		}
		return sDFRandomNode;
	}

	private void OnEnable()
	{
		_sdfMat = new Material(Shader.Find("Hidden/2DSDFShader"));
		_combine = new Material(Shader.Find("Hidden/SDFCombine"));
		_effect = new Material(Shader.Find("Hidden/2DSDFEffectShader"));
		_array = new Material(Shader.Find("Hidden/SDFArray"));
		_mirror = new Material(Shader.Find("Hidden/2DSDFMirror"));
		_reflect = new Material(Shader.Find("Hidden/2DSDFReflect"));
		_texture = new Material(Shader.Find("Hidden/SDFTexture"));
		_finalMat = new Material(Shader.Find("Hidden/2DSDFRGB"));
		_mix = new Material(Shader.Find("Hidden/2DSDFRGBMix"));
		TextAsset[] array = Resources.LoadAll<TextAsset>("SDF/Trees");
		foreach (TextAsset textAsset in array)
		{
			TydTable tydTable = TydFile.FromContent(textAsset.text, textAsset.name).DocumentNode.Nodes[0] as TydTable;
			List<string> extraTags;
			SDFRandomNode element = LoadRandomTree(textAsset.name, tydTable, out extraTags);
			_randomTrees.Append(tydTable.Name, element);
			if (extraTags != null)
			{
				for (int j = 0; j < extraTags.Count; j++)
				{
					_randomTrees.Append(extraTags[j], element);
				}
			}
		}
	}

	public void Render(ISDFOutput sdf, RenderTexture tex)
	{
		sdf.Execute(tex.width, tex, Matrix4x4.identity);
	}

	public RenderTexture Render(ISDFOutput sdf, int size)
	{
		RenderTexture renderTexture = new RenderTexture(size, size, 0);
		Render(sdf, renderTexture);
		return renderTexture;
	}

	public Texture2D LoadSDF(string resource)
	{
		Texture2D value;
		if (_textureCache.TryGetValue(resource, out value))
		{
			return value;
		}
		TextAsset textAsset = Resources.Load<TextAsset>("SDF/" + resource);
		if (textAsset != null)
		{
			Texture2D texture2D = DeserializeSDF(textAsset.bytes);
			_textureCache[resource] = texture2D;
			return texture2D;
		}
		return null;
	}

	public static SDFRandomNode LoadRandomTree(string name, TydTable root, out List<string> extraTags)
	{
		extraTags = null;
		TydTable child = root.GetChild<TydTable>("Nodes");
		SDFRandomNode sDFRandomNode = null;
		Dictionary<int, SDFRandomNode> dictionary = new Dictionary<int, SDFRandomNode>();
		foreach (TydTable item in child.Nodes.OfType<TydTable>())
		{
			sDFRandomNode = new SDFRandomNode(item);
			dictionary[item.GetChildValue("ID", true, 0)] = sDFRandomNode;
		}
		foreach (TydList item2 in root.GetChild<TydList>("Connections").Nodes.OfType<TydList>())
		{
			List<TydNode> nodes = item2.Nodes;
			SDFRandomNode sDFRandomNode2 = dictionary[((TydString)nodes[0]).Value.ConvertToInt("First node")];
			for (int i = 1; i < nodes.Count; i++)
			{
				TydNode tydNode = nodes[i];
				TydString tydString;
				if ((tydString = tydNode as TydString) != null)
				{
					sDFRandomNode2.SetInput(dictionary[tydString.Value.ConvertToIntDef(0)], i - 1);
					continue;
				}
				TydList tydList = (TydList)tydNode;
				if (tydList.GetChildValue(0).Equals("Pick"))
				{
					List<SDFRandomNode> list = new List<SDFRandomNode>();
					List<string> list2 = tydList.GetChildValues().ToList();
					for (int j = 1; j < list2.Count - 1; j++)
					{
						list.Add(dictionary[list2[j].ConvertToInt("Random pick")]);
					}
					sDFRandomNode2.SetInput(new SDFRandomCategory(list2.Last(), list), i - 1);
				}
				else
				{
					sDFRandomNode2.SetInput(new SDFRandomCategory(tydList.GetChildValue(0), tydList.GetChildValue(1)), i - 1);
				}
			}
		}
		sDFRandomNode.Name = name;
		sDFRandomNode.Weight = root.GetChildValue("Weight", false, 1f);
		TydList child2 = root.GetChild<TydList>("Tags");
		if (child2 != null)
		{
			extraTags = child2.GetChildValues().ToList();
		}
		return sDFRandomNode;
	}

	public static ISDFNode LoadSDFTree(byte[] data)
	{
		MemoryStream memoryStream = new MemoryStream(data);
		byte version = (byte)memoryStream.ReadByte();
		ISDFNode iSDFNode = null;
		Dictionary<int, ISDFNode> dictionary = new Dictionary<int, ISDFNode>();
		while (true)
		{
			NodeType nodeType = (NodeType)memoryStream.ReadByte();
			if (nodeType == NodeType.Stop)
			{
				break;
			}
			int key = memoryStream.ReadByte();
			switch (nodeType)
			{
			case NodeType.Shape:
				iSDFNode = new SDFShape(memoryStream, version);
				break;
			case NodeType.Effect:
				iSDFNode = new SDFEffect(memoryStream, version);
				break;
			case NodeType.Combine:
				iSDFNode = new SDFCombine(memoryStream, version);
				break;
			case NodeType.Color:
				iSDFNode = new SDFExport(memoryStream, version);
				break;
			case NodeType.Mix:
				iSDFNode = new SDFMix(memoryStream, version);
				break;
			case NodeType.Transform:
				iSDFNode = new SDFTransform(memoryStream, version);
				break;
			case NodeType.Mirror:
				iSDFNode = new SDFMirror(memoryStream, version);
				break;
			case NodeType.Reflect:
				iSDFNode = new SDFReflect(memoryStream, version);
				break;
			case NodeType.Texture:
				iSDFNode = new SDFTexture(memoryStream, version);
				break;
			case NodeType.Array:
				iSDFNode = new SDFArray(memoryStream, version);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			dictionary[key] = iSDFNode;
		}
		while (memoryStream.Position < memoryStream.Length)
		{
			int num = memoryStream.ReadByte();
			ISDFNode iSDFNode2 = dictionary[memoryStream.ReadByte()];
			for (int i = 1; i < num; i++)
			{
				iSDFNode2.SetInput(dictionary[memoryStream.ReadByte()], i - 1);
			}
		}
		return iSDFNode;
	}

	public static ISDFNode LoadSDFTree(TydTable root)
	{
		TydTable child = root.GetChild<TydTable>("Nodes");
		Dictionary<int, ISDFNode> dictionary = new Dictionary<int, ISDFNode>();
		ISDFNode iSDFNode = null;
		foreach (TydTable item in child.Nodes.OfType<TydTable>())
		{
			switch (item.Name.ToEnum<NodeType>())
			{
			case NodeType.Shape:
				iSDFNode = new SDFShape(item);
				break;
			case NodeType.Transform:
				iSDFNode = new SDFTransform(item);
				break;
			case NodeType.Effect:
				iSDFNode = new SDFEffect(item);
				break;
			case NodeType.Array:
				iSDFNode = new SDFArray(item);
				break;
			case NodeType.Combine:
				iSDFNode = new SDFCombine(item);
				break;
			case NodeType.Color:
				iSDFNode = new SDFExport(item);
				break;
			case NodeType.Mix:
				iSDFNode = new SDFMix(item);
				break;
			case NodeType.Mirror:
				iSDFNode = new SDFMirror(item);
				break;
			case NodeType.Texture:
				iSDFNode = new SDFTexture(item);
				break;
			default:
				throw new Exception("Could not find node type: " + item.Name);
			}
			dictionary[item.GetChildValue("ID", true, 0)] = iSDFNode;
		}
		foreach (TydList item2 in root.GetChild<TydList>("Connections").Nodes.OfType<TydList>())
		{
			int[] array = item2.GetChildValues<int>().ToArray();
			ISDFNode iSDFNode2 = dictionary[array[0]];
			for (int i = 1; i < array.Length; i++)
			{
				iSDFNode2.SetInput(dictionary[array[i]], i - 1);
			}
		}
		return iSDFNode;
	}

	public static byte[] SerializeSDF(Texture2D tex)
	{
		byte[] rawTextureData = tex.GetRawTextureData();
		byte[] array = new byte[rawTextureData.Length + 8];
		byte[] bytes = BitConverter.GetBytes(tex.width);
		byte[] bytes2 = BitConverter.GetBytes(tex.height);
		int i;
		for (i = 0; i < bytes.Length; i++)
		{
			array[i] = bytes[i];
		}
		int num = i + bytes2.Length;
		int num2 = i;
		for (; i < num; i++)
		{
			array[i] = bytes2[i - num2];
		}
		num2 = i;
		for (; i < array.Length; i++)
		{
			array[i] = rawTextureData[i - num2];
		}
		using (MemoryStream memoryStream = new MemoryStream())
		{
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, false))
			{
				gZipStream.Write(array, 0, array.Length);
			}
			return memoryStream.ToArray();
		}
	}

	private static float ShiftHue(float hue, float amount)
	{
		float num = hue + amount;
		if (num > 1f)
		{
			num -= 1f;
		}
		else if (num < 0f)
		{
			num = 1f + num;
		}
		return num;
	}

	public static Dictionary<string, Color> PickRandomColors()
	{
		Dictionary<string, Color> dictionary = new Dictionary<string, Color>();
		float num = Utilities.RandomRange(0f, 1f);
		float num2 = Utilities.RandomRange(0.6f, 0.8f);
		float num3 = 0f;
		float num4 = 0f;
		switch (Utilities.RandomRange(0, 4))
		{
		case 0:
			num3 = ShiftHue(num, 0.5f);
			num4 = ShiftHue(num, (Utilities.RandomValue > 0.5f) ? 0.25f : 0.75f);
			break;
		case 1:
			num3 = ShiftHue(num, 0.25f);
			num4 = ShiftHue(num, 0.75f);
			break;
		case 2:
			num3 = ShiftHue(num, 0.33333f);
			num4 = ShiftHue(num, 0.666666f);
			break;
		case 3:
			num3 = ShiftHue(num, 1f / 12f);
			num4 = ShiftHue(num, -1f / 12f);
			break;
		}
		dictionary["Primary"] = Utilities.HSVToRGBA(num, num2, 1f);
		dictionary["Primary2"] = Utilities.HSVToRGBA(ShiftHue(num, Utilities.RandomRange(-0.01f, 0.01f)), num2 + Utilities.RandomRange(-0.1f, 0.1f), 0.7f);
		dictionary["Secondary"] = Utilities.HSVToRGBA(num3, num2, 1f);
		dictionary["Secondary2"] = Utilities.HSVToRGBA(ShiftHue(num3, Utilities.RandomRange(-0.01f, 0.01f)), num2 + Utilities.RandomRange(-0.1f, 0.1f), 0.7f);
		dictionary["Tertiary"] = Utilities.HSVToRGBA(num4, num2, 1f);
		dictionary["Tertiary2"] = Utilities.HSVToRGBA(ShiftHue(num4, Utilities.RandomRange(-0.01f, 0.01f)), num2 + Utilities.RandomRange(-0.1f, 0.1f), 0.7f);
		dictionary["White"] = Color.white;
		dictionary["Black"] = new Color32(50, 50, 50, byte.MaxValue);
		Color value = dictionary["Primary2"];
		Color value2 = dictionary["Primary"];
		Color value3 = dictionary["Primary"];
		Color value4 = dictionary["Primary2"];
		Color color = dictionary["Secondary"];
		Color color2 = dictionary["Secondary2"];
		if (color.grayscale > value.grayscale)
		{
			value = color;
			value2 = color2;
		}
		else if (color.grayscale < value3.grayscale)
		{
			value3 = color;
			value4 = color2;
		}
		color = dictionary["Tertiary"];
		color2 = dictionary["Tertiary2"];
		if (color.grayscale > value.grayscale)
		{
			value = color;
			value2 = color2;
		}
		else if (color.grayscale < value3.grayscale)
		{
			value3 = color;
			value4 = color2;
		}
		dictionary["Bright"] = value;
		dictionary["Bright2"] = value2;
		dictionary["Dark"] = value3;
		dictionary["Dark2"] = value4;
		return dictionary;
	}

	public static byte[] SerializeTree(ISDFNode start)
	{
		MemoryStream memoryStream = new MemoryStream();
		memoryStream.WriteByte(6);
		Dictionary<ISDFNode, int> ids = new Dictionary<ISDFNode, int>();
		start.Serialize(ids, memoryStream);
		memoryStream.WriteByte(9);
		start.SerializeConnections(ids, new HashSet<ISDFNode>(), memoryStream);
		return memoryStream.ToArray();
	}

	private static byte[] Compress(byte[] bytes)
	{
		MemoryStream memoryStream = new MemoryStream();
		using (DeflateStream deflateStream = new DeflateStream(memoryStream, System.IO.Compression.CompressionLevel.Optimal))
		{
			deflateStream.Write(bytes, 0, bytes.Length);
		}
		return memoryStream.ToArray();
	}

	public static string GetTreeString(byte[] bytes)
	{
		return ByteToString2(Compress(bytes));
	}

	private static byte[] Decompress(byte[] bytes)
	{
		MemoryStream stream = new MemoryStream(bytes);
		MemoryStream memoryStream = new MemoryStream();
		using (DeflateStream deflateStream = new DeflateStream(stream, CompressionMode.Decompress))
		{
			deflateStream.CopyTo(memoryStream);
		}
		return memoryStream.ToArray();
	}

	public static byte[] GetTreeFromString(string s)
	{
		return Decompress(ByteFromString2(s.Trim()));
	}

	private static byte[] ByteFromString(string c)
	{
		byte[] array = new byte[c.Length / 2];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)(c[i * 2] - 65);
			array[i] |= (byte)(c[i * 2 + 1] - 65 << 4);
		}
		return array;
	}

	private static string ByteToString(byte[] bytes)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < bytes.Length; i++)
		{
			stringBuilder.Append((char)((bytes[i] & 0xF) + 65));
			stringBuilder.Append((char)(((bytes[i] >> 4) & 0xF) + 65));
		}
		return stringBuilder.ToString();
	}

	private static string ByteToString2(byte[] bytes)
	{
		return Convert.ToBase64String(bytes);
	}

	private static byte[] ByteFromString2(string str)
	{
		return Convert.FromBase64String(str);
	}

	public static Texture2D DeserializeSDF(byte[] data)
	{
		using (MemoryStream stream = new MemoryStream(data))
		{
			using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress, false))
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					gZipStream.CopyTo(memoryStream, 16384);
					data = memoryStream.ToArray();
				}
			}
		}
		int width = BitConverter.ToInt32(data, 0);
		int height = BitConverter.ToInt32(data, 4);
		Texture2D texture2D = new Texture2D(width, height, TextureFormat.RFloat, false)
		{
			wrapMode = TextureWrapMode.Clamp
		};
		byte[] array = new byte[data.Length - 8];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = data[i + 8];
		}
		texture2D.LoadRawTextureData(array);
		texture2D.Apply(false);
		return texture2D;
	}

	public static void GetColorParameters(ISDFNode n, HashSet<ISDFNode> visited, Dictionary<Color, List<SDFParameterExport>> parameters)
	{
		if (n == null || !visited.Add(n))
		{
			return;
		}
		SDFExport sDFExport;
		if ((sDFExport = n as SDFExport) != null)
		{
			parameters.Append(sDFExport.MainColor, new SDFParameterExport(n, "MainColor"));
			parameters.Append(sDFExport.GradientColor, new SDFParameterExport(n, "GradientColor"));
			if (sDFExport.Outline > 0f)
			{
				parameters.Append(sDFExport.OutlineColor, new SDFParameterExport(n, "OutlineColor"));
			}
		}
		foreach (ISDFNode child in n.GetChildren())
		{
			GetColorParameters(child, visited, parameters);
		}
	}

	public static Texture2D EncodeInTexture(ISDFNode node)
	{
		RenderTexture temporary = RenderTexture.GetTemporary(256, 256, 0, RenderTextureFormat.ARGB32);
		node.Execute(256, temporary, Matrix4x4.identity);
		Texture2D texture2D = new Texture2D(256, 256, TextureFormat.ARGB32, false, true);
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = temporary;
		texture2D.ReadPixels(new Rect(0f, 0f, 256f, 256f), 0, 0, false);
		texture2D.Apply(false);
		RenderTexture.active = active;
		RenderTexture.ReleaseTemporary(temporary);
		byte[] data = Compress(SerializeTree(node));
		Debug.Log(Compress(texture2D.GetRawTextureData()).Length);
		texture2D.SetPixels32(EncodeDataInTexture(texture2D.GetPixels32(), data));
		texture2D.Apply(false);
		return texture2D;
	}

	public static ISDFNode DecodeFromTexture(Texture2D tex)
	{
		return LoadSDFTree(Decompress(ExtractDataFromImage(tex.GetPixels32())));
	}

	public static byte[] ExtractDataFromImage(Color32[] imagePixels)
	{
		int num = 4384;
		BitArray bitArray = new BitArray(num);
		int num2 = 0;
		for (int i = 0; i < imagePixels.Length; i++)
		{
			Color32 color = imagePixels[i];
			if (color.a == byte.MaxValue)
			{
				if (num2 < num)
				{
					bitArray[num2++] = (color.r & 1) == 1;
				}
				if (num2 < num)
				{
					bitArray[num2++] = (color.g & 1) == 1;
				}
				if (num2 < num)
				{
					bitArray[num2++] = (color.b & 1) == 1;
				}
				if (num2 >= num)
				{
					break;
				}
			}
		}
		byte[] array = new byte[548];
		bitArray.CopyTo(array, 0);
		byte[] array2 = new byte[32];
		Buffer.BlockCopy(array, 0, array2, 0, 32);
		byte[] array3 = new byte[516];
		Buffer.BlockCopy(array, 32, array3, 0, 516);
		array = ReedSolomonAlgorithm.Decode(array3, array2);
		int num3 = BitConverter.ToInt32(array, 0);
		byte[] array4 = new byte[num3];
		Buffer.BlockCopy(array, 4, array4, 0, num3);
		return array4;
	}

	public static Color32[] EncodeDataInTexture(Color32[] imagePixels, byte[] data)
	{
		int value = data.Length;
		if (data.Length < 512)
		{
			byte[] array = new byte[512];
			Buffer.BlockCopy(data, 0, array, 0, data.Length);
			data = array;
		}
		else if (data.Length > 512)
		{
			throw new Exception("Logo to big to embed");
		}
		byte[] array2 = ReedSolomonAlgorithm.Encode(data, 32);
		byte[] bytes = BitConverter.GetBytes(value);
		byte[] array3 = new byte[bytes.Length + data.Length + array2.Length];
		Buffer.BlockCopy(array2, 0, array3, 0, array2.Length);
		Buffer.BlockCopy(bytes, 0, array3, array2.Length, bytes.Length);
		Buffer.BlockCopy(data, 0, array3, array2.Length + bytes.Length, data.Length);
		BitArray bitArray = new BitArray(array3);
		int num = 0;
		for (int i = 0; i < imagePixels.Length; i++)
		{
			if (imagePixels[i].a == byte.MaxValue)
			{
				if (num < bitArray.Length)
				{
					imagePixels[i].r = (byte)((imagePixels[i].r & 0xFE) | (bitArray[num] ? 1 : 0));
					num++;
				}
				if (num < bitArray.Length)
				{
					imagePixels[i].g = (byte)((imagePixels[i].g & 0xFE) | (bitArray[num] ? 1 : 0));
					num++;
				}
				if (num < bitArray.Length)
				{
					imagePixels[i].b = (byte)((imagePixels[i].b & 0xFE) | (bitArray[num] ? 1 : 0));
					num++;
				}
				if (num >= bitArray.Length)
				{
					break;
				}
			}
		}
		if (num < bitArray.Length)
		{
			throw new Exception("Not enough space in the image to embed the data.");
		}
		return imagePixels;
	}
}
