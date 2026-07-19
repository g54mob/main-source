using System;
using UniGLTF;
using UniJSON;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.firstperson.degreemap")]
	public class glTF_VRM_DegreeMap : JsonSerializableBase
	{
		[JsonSchema(Description = "None linear mapping params. time, value, inTangent, outTangent")]
		public float[] curve;

		[JsonSchema(Description = "Look at input clamp range degree.")]
		public float xRange = 90f;

		[JsonSchema(Description = "Look at map range degree from xRange.")]
		public float yRange = 10f;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			if (curve != null)
			{
				f.KeyValue(() => curve);
			}
			f.KeyValue(() => xRange);
			f.KeyValue(() => yRange);
		}
	}
}
