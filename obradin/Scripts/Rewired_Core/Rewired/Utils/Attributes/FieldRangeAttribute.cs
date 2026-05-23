using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float UGUwEceMcOraAFKUDWmWOhchPpd;

		private float XWdWeuNtlctxPOsowwacAwEJGbN;

		private int ZTGmZRyYYMaAyXsaFoabDdWQhZH;

		private int UUUQvLVMUgTHnLjgFMTMUDPehqYD;

		public float minFloat
		{
			get
			{
				return UGUwEceMcOraAFKUDWmWOhchPpd;
			}
		}

		public float maxFloat
		{
			get
			{
				return XWdWeuNtlctxPOsowwacAwEJGbN;
			}
		}

		public int minInt
		{
			get
			{
				return ZTGmZRyYYMaAyXsaFoabDdWQhZH;
			}
		}

		public int maxInt
		{
			get
			{
				return UUUQvLVMUgTHnLjgFMTMUDPehqYD;
			}
		}

		public FieldRangeAttribute(float min, float max)
		{
			while (true)
			{
				int num = -2001262864;
				while (true)
				{
					switch (num ^ -2001262861)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						UGUwEceMcOraAFKUDWmWOhchPpd = min;
						num = -2001262861;
						continue;
					case 0:
						XWdWeuNtlctxPOsowwacAwEJGbN = max;
						ZTGmZRyYYMaAyXsaFoabDdWQhZH = (int)min;
						UUUQvLVMUgTHnLjgFMTMUDPehqYD = (int)max;
						num = -2001262862;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		public FieldRangeAttribute(int min, int max)
		{
			ZTGmZRyYYMaAyXsaFoabDdWQhZH = min;
			UUUQvLVMUgTHnLjgFMTMUDPehqYD = max;
			UGUwEceMcOraAFKUDWmWOhchPpd = min;
			XWdWeuNtlctxPOsowwacAwEJGbN = max;
		}
	}
}
