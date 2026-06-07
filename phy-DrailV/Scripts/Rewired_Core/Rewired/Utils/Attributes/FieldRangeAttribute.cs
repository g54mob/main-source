using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float ZNVGBUeZkHuaLkMYEtIvgdKLqUmk;

		private float MvmfbYFrFrpiSfdafVJRudQrntUV;

		private int EADkDnuLuXnnnibmSFFOrTkiSmSP;

		private int TnBUTdRqIlYNieoEQefbaGtUXOBi;

		public float minFloat => ZNVGBUeZkHuaLkMYEtIvgdKLqUmk;

		public float maxFloat => MvmfbYFrFrpiSfdafVJRudQrntUV;

		public int minInt => EADkDnuLuXnnnibmSFFOrTkiSmSP;

		public int maxInt => TnBUTdRqIlYNieoEQefbaGtUXOBi;

		public FieldRangeAttribute(float P_0, float P_1)
		{
			ZNVGBUeZkHuaLkMYEtIvgdKLqUmk = P_0;
			MvmfbYFrFrpiSfdafVJRudQrntUV = P_1;
			EADkDnuLuXnnnibmSFFOrTkiSmSP = (int)P_0;
			TnBUTdRqIlYNieoEQefbaGtUXOBi = (int)P_1;
		}

		public FieldRangeAttribute(int P_0, int P_1)
		{
			EADkDnuLuXnnnibmSFFOrTkiSmSP = P_0;
			TnBUTdRqIlYNieoEQefbaGtUXOBi = P_1;
			ZNVGBUeZkHuaLkMYEtIvgdKLqUmk = P_0;
			MvmfbYFrFrpiSfdafVJRudQrntUV = P_1;
		}
	}
}
