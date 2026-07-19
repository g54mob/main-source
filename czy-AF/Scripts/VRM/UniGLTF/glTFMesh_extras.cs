using System;
using System.Collections.Generic;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFMesh_extras : ExtraBase<glTFMesh_extras>
	{
		[JsonSchema(Required = true, MinItems = 1)]
		public List<string> targetNames = new List<string>();

		[JsonSerializeMembers]
		private void PrimitiveMembers(GLTFJsonFormatter f)
		{
			if (targetNames.Count <= 0)
			{
				return;
			}
			f.Key("targetNames");
			f.BeginList();
			foreach (string targetName in targetNames)
			{
				f.Value(targetName);
			}
			f.EndList();
		}
	}
}
