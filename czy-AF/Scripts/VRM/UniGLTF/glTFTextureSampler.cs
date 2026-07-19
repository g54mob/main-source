using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFTextureSampler : JsonSerializableBase
	{
		[JsonSchema(EnumSerializationType = EnumSerializationType.AsInt, EnumExcludes = new object[]
		{
			glFilter.NONE,
			glFilter.NEAREST_MIPMAP_NEAREST,
			glFilter.LINEAR_MIPMAP_NEAREST,
			glFilter.NEAREST_MIPMAP_LINEAR,
			glFilter.LINEAR_MIPMAP_LINEAR
		})]
		public glFilter magFilter = glFilter.NEAREST;

		[JsonSchema(EnumSerializationType = EnumSerializationType.AsInt, EnumExcludes = new object[] { glFilter.NONE })]
		public glFilter minFilter = glFilter.NEAREST;

		[JsonSchema(EnumSerializationType = EnumSerializationType.AsInt, EnumExcludes = new object[] { glWrap.NONE })]
		public glWrap wrapS = glWrap.REPEAT;

		[JsonSchema(EnumSerializationType = EnumSerializationType.AsInt, EnumExcludes = new object[] { glWrap.NONE })]
		public glWrap wrapT = glWrap.REPEAT;

		public object extensions;

		public object extras;

		public string name;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.Key("magFilter");
			f.Value((int)magFilter);
			f.Key("minFilter");
			f.Value((int)minFilter);
			f.Key("wrapS");
			f.Value((int)wrapS);
			f.Key("wrapT");
			f.Value((int)wrapT);
		}
	}
}
