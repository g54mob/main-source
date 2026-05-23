using UnityEngine;

namespace ES3Types
{
	public class ES3UserType_SkinnedMeshRendererArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SkinnedMeshRendererArray()
			: base(typeof(SkinnedMeshRenderer[]), ES3UserType_SkinnedMeshRenderer.Instance)
		{
			Instance = this;
		}
	}
}
