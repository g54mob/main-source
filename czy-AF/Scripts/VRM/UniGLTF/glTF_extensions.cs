using System;
using UniJSON;
using VRM;

namespace UniGLTF
{
	[Serializable]
	public class glTF_extensions : ExtensionsBase<glTF_extensions>
	{
		public glTF_VRM_extensions VRM;

		[JsonSerializeMembers]
		private void VRMSerializeMembers(GLTFJsonFormatter f)
		{
			if (VRM != null)
			{
				f.Key("VRM");
				f.GLTFValue(VRM);
			}
		}
	}
}
