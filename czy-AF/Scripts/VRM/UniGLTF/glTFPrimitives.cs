using System;
using System.Collections.Generic;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFPrimitives : JsonSerializableBase
	{
		[JsonSchema(EnumValues = new object[] { 0, 1, 2, 3, 4, 5, 6 })]
		public int mode;

		[JsonSchema(Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int indices = -1;

		[JsonSchema(Required = true, SkipSchemaComparison = true)]
		public glTFAttributes attributes;

		[JsonSchema(Minimum = 0.0)]
		public int material;

		[JsonSchema(MinItems = 1, ExplicitIgnorableItemLength = 0)]
		[ItemJsonSchema(SkipSchemaComparison = true)]
		public List<gltfMorphTarget> targets = new List<gltfMorphTarget>();

		public glTFPrimitives_extras extras = new glTFPrimitives_extras();

		[JsonSchema(SkipSchemaComparison = true)]
		public glTFPrimitives_extensions extensions;

		public bool HasVertexColor => attributes.COLOR_0 != -1;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => mode);
			f.KeyValue(() => indices);
			f.Key("attributes");
			f.GLTFValue(attributes);
			f.KeyValue(() => material);
			if (targets != null && targets.Count > 0)
			{
				f.Key("targets");
				f.GLTFValue(targets);
			}
			if (extras.targetNames.Count > 0)
			{
				f.Key("extras");
				f.GLTFValue(extras);
			}
		}
	}
}
