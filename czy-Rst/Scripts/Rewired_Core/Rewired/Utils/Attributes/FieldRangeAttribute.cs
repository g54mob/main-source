using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float GDTPbSERoidTfSrIasclIekpaLHc;

		private float XuzDxdHlMQfcrAyJiUxpzwVtGGk;

		private int gHzSfgrmcIhrkvwfBtZwLLPlGPWV;

		private int EUijgZDqZxtAoWfdadpMyiBAATaC;

		public float minFloat => GDTPbSERoidTfSrIasclIekpaLHc;

		public float maxFloat => XuzDxdHlMQfcrAyJiUxpzwVtGGk;

		public int minInt => gHzSfgrmcIhrkvwfBtZwLLPlGPWV;

		public int maxInt => EUijgZDqZxtAoWfdadpMyiBAATaC;

		public FieldRangeAttribute(float P_0, float P_1)
		{
			GDTPbSERoidTfSrIasclIekpaLHc = P_0;
			XuzDxdHlMQfcrAyJiUxpzwVtGGk = P_1;
			gHzSfgrmcIhrkvwfBtZwLLPlGPWV = (int)P_0;
			EUijgZDqZxtAoWfdadpMyiBAATaC = (int)P_1;
		}

		public FieldRangeAttribute(int P_0, int P_1)
		{
			gHzSfgrmcIhrkvwfBtZwLLPlGPWV = P_0;
			EUijgZDqZxtAoWfdadpMyiBAATaC = P_1;
			GDTPbSERoidTfSrIasclIekpaLHc = P_0;
			XuzDxdHlMQfcrAyJiUxpzwVtGGk = P_1;
		}
	}
}
