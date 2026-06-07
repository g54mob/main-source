using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class FieldRangeAttribute : PropertyAttribute
	{
		private float LXlCwMWYDjlVXAlcoilAGbEWWQRG;

		private float KaIckCjHzDkQsfxrBKONzpWedTUaA;

		private int pEPruJzJcNBnejdoZBZAsFpYMvOeA;

		private int TaEkXiPagafdyIfymFbudsIzGmwOA;

		public float minFloat => LXlCwMWYDjlVXAlcoilAGbEWWQRG;

		public float maxFloat => KaIckCjHzDkQsfxrBKONzpWedTUaA;

		public int minInt => pEPruJzJcNBnejdoZBZAsFpYMvOeA;

		public int maxInt => TaEkXiPagafdyIfymFbudsIzGmwOA;

		public FieldRangeAttribute(float P_0, float P_1)
		{
			LXlCwMWYDjlVXAlcoilAGbEWWQRG = P_0;
			KaIckCjHzDkQsfxrBKONzpWedTUaA = P_1;
			pEPruJzJcNBnejdoZBZAsFpYMvOeA = (int)P_0;
			TaEkXiPagafdyIfymFbudsIzGmwOA = (int)P_1;
		}

		public FieldRangeAttribute(int P_0, int P_1)
		{
			pEPruJzJcNBnejdoZBZAsFpYMvOeA = P_0;
			TaEkXiPagafdyIfymFbudsIzGmwOA = P_1;
			LXlCwMWYDjlVXAlcoilAGbEWWQRG = P_0;
			KaIckCjHzDkQsfxrBKONzpWedTUaA = P_1;
		}
	}
}
