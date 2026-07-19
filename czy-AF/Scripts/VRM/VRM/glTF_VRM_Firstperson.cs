using System;
using System.Collections.Generic;
using UniGLTF;
using UniJSON;
using UnityEngine;

namespace VRM
{
	[Serializable]
	[JsonSchema(Title = "vrm.firstperson")]
	public class glTF_VRM_Firstperson : JsonSerializableBase
	{
		[JsonSchema(Description = "The bone whose rendering should be turned off in first-person view. Usually Head is specified.", Minimum = 0.0, ExplicitIgnorableValue = -1)]
		public int firstPersonBone = -1;

		[JsonSchema(Description = "The target position of the VR headset in first-person view. It is assumed that an offset from the head bone to the VR headset is added.")]
		public Vector3 firstPersonBoneOffset;

		[JsonSchema(Description = "Switch display / undisplay for each mesh in first-person view or the others.")]
		public List<glTF_VRM_MeshAnnotation> meshAnnotations = new List<glTF_VRM_MeshAnnotation>();

		[JsonSchema(Description = "Eye controller mode.", EnumValues = new object[] { "Bone", "BlendShape" }, EnumSerializationType = EnumSerializationType.AsString)]
		public string lookAtTypeName = "Bone";

		[JsonSchema(Description = "Eye controller setting.")]
		public glTF_VRM_DegreeMap lookAtHorizontalInner = new glTF_VRM_DegreeMap();

		[JsonSchema(Description = "Eye controller setting.")]
		public glTF_VRM_DegreeMap lookAtHorizontalOuter = new glTF_VRM_DegreeMap();

		[JsonSchema(Description = "Eye controller setting.")]
		public glTF_VRM_DegreeMap lookAtVerticalDown = new glTF_VRM_DegreeMap();

		[JsonSchema(Description = "Eye controller setting.")]
		public glTF_VRM_DegreeMap lookAtVerticalUp = new glTF_VRM_DegreeMap();

		public LookAtType lookAtType
		{
			get
			{
				return CacheEnum.TryParseOrDefault(lookAtTypeName, ignoreCase: true, LookAtType.None);
			}
			set
			{
				lookAtTypeName = value.ToString();
			}
		}

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => firstPersonBone);
			f.KeyValue(() => firstPersonBoneOffset);
			f.Key("meshAnnotations");
			f.GLTFValue(meshAnnotations);
			f.KeyValue(() => lookAtTypeName);
			f.Key("lookAtHorizontalInner");
			f.GLTFValue(lookAtHorizontalInner);
			f.Key("lookAtHorizontalOuter");
			f.GLTFValue(lookAtHorizontalOuter);
			f.Key("lookAtVerticalDown");
			f.GLTFValue(lookAtVerticalDown);
			f.Key("lookAtVerticalUp");
			f.GLTFValue(lookAtVerticalUp);
		}
	}
}
