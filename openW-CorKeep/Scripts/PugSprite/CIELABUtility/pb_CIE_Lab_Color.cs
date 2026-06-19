using UnityEngine;

namespace CIELABUtility
{
	public class pb_CIE_Lab_Color
	{
		public float L;

		public float a;

		public float b;

		public pb_CIE_Lab_Color(float L, float a, float b)
		{
			this.L = L;
			this.a = a;
			this.b = b;
		}

		public static pb_CIE_Lab_Color FromXYZ(pb_XYZ_Color xyz)
		{
			return pb_ColorUtil.XYZToCIE_Lab(xyz);
		}

		public static pb_CIE_Lab_Color FromRGB(Color col)
		{
			return pb_ColorUtil.XYZToCIE_Lab(pb_XYZ_Color.FromRGB(col));
		}

		public override string ToString()
		{
			return $"( {L}, {a}, {b} )";
		}
	}
}
