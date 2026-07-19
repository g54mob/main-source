using System;
using System.Linq;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFAccessor : JsonSerializableBase
	{
		[JsonSchema(Minimum = 0.0)]
		public int bufferView = -1;

		[JsonSchema(Minimum = 0.0, Dependencies = new string[] { "bufferView" })]
		public int byteOffset;

		[JsonSchema(Required = true, EnumValues = new object[] { "SCALAR", "VEC2", "VEC3", "VEC4", "MAT2", "MAT3", "MAT4" }, EnumSerializationType = EnumSerializationType.AsString)]
		public string type;

		[JsonSchema(Required = true, EnumSerializationType = EnumSerializationType.AsInt)]
		public glComponentType componentType;

		[JsonSchema(Required = true, Minimum = 1.0)]
		public int count;

		[JsonSchema(MinItems = 1, MaxItems = 16)]
		public float[] max;

		[JsonSchema(MinItems = 1, MaxItems = 16)]
		public float[] min;

		public bool normalized;

		public glTFSparse sparse;

		public string name;

		public object extensions;

		public object extras;

		public int TypeCount
		{
			get
			{
				switch (type)
				{
				case "SCALAR":
					return 1;
				case "VEC2":
					return 2;
				case "VEC3":
					return 3;
				case "VEC4":
				case "MAT2":
					return 4;
				case "MAT3":
					return 9;
				case "MAT4":
					return 16;
				default:
					throw new NotImplementedException();
				}
			}
		}

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => bufferView);
			f.KeyValue(() => byteOffset);
			f.KeyValue(() => type);
			f.Key("componentType");
			f.Value((int)componentType);
			f.KeyValue(() => count);
			if (max != null && max.Any())
			{
				f.KeyValue(() => max);
			}
			if (min != null && min.Any())
			{
				f.KeyValue(() => min);
			}
			if (sparse != null && sparse.count > 0)
			{
				f.Key("sparse");
				f.GLTFValue(sparse);
			}
			f.KeyValue(() => normalized);
			f.KeyValue(() => name);
		}
	}
}
