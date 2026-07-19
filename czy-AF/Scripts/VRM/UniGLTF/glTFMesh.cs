using System;
using System.Collections.Generic;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFMesh : JsonSerializableBase
	{
		public string name;

		[JsonSchema(Required = true, MinItems = 1)]
		public List<glTFPrimitives> primitives = new List<glTFPrimitives>();

		[JsonSchema(MinItems = 1)]
		public float[] weights;

		[JsonSchema(SkipSchemaComparison = true)]
		public glTFMesh_extras extras;

		public object extensions;

		public glTFMesh()
		{
		}

		public glTFMesh(string _name)
		{
			name = _name;
		}

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => name);
			f.Key("primitives");
			f.GLTFValue(primitives);
			if (weights != null && weights.Length != 0)
			{
				f.KeyValue(() => weights);
			}
		}
	}
}
