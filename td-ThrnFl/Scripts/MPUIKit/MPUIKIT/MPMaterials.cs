using UnityEngine;

namespace MPUIKIT
{
	public static class MPMaterials
	{
		private const string MpBasicProceduralShaderName = "MPUI/Basic Procedural Image";

		private static string[] MpShapeKeywords = new string[4] { "CIRCLE", "TRIANGLE", "RECTANGLE", "NSTAR_POLYGON" };

		private const string MpStrokeKeyword = "STROKE";

		private const string MpOutlineKeyword = "OUTLINED";

		private const string MpOutlinedStrokeKeyword = "OUTLINED_STROKE";

		private static Shader _proceduralShader;

		private static Material[] _materialDB = new Material[16];

		internal static Shader MPBasicProceduralShader
		{
			get
			{
				if (_proceduralShader == null)
				{
					_proceduralShader = Shader.Find("MPUI/Basic Procedural Image");
				}
				return _proceduralShader;
			}
		}

		internal static ref Material GetMaterial(int shapeIndex, bool stroked, bool outlined)
		{
			int num = shapeIndex * 4;
			if (stroked && outlined)
			{
				num += 3;
			}
			else if (outlined)
			{
				num += 2;
			}
			else if (stroked)
			{
				num++;
			}
			ref Material reference = ref _materialDB[num];
			if (reference != null)
			{
				return ref reference;
			}
			reference = new Material(MPBasicProceduralShader);
			string text = MpShapeKeywords[shapeIndex];
			reference.name = "Basic Procedural Sprite - " + text + " " + (stroked ? "STROKE" : string.Empty) + " " + (outlined ? "OUTLINED" : string.Empty);
			reference.EnableKeyword(text);
			if (stroked && outlined)
			{
				reference.EnableKeyword("OUTLINED_STROKE");
			}
			else if (stroked)
			{
				reference.EnableKeyword("STROKE");
			}
			else if (outlined)
			{
				reference.EnableKeyword("OUTLINED");
			}
			return ref reference;
		}
	}
}
