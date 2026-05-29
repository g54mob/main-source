using System;
using UnityEngine;

namespace Rewired.Utils.Attributes
{
	public class BitmaskAttribute : PropertyAttribute
	{
		public Type propType;

		public BitmaskAttribute(Type aType)
		{
			while (true)
			{
				int num = 661390598;
				while (true)
				{
					switch (num ^ 0x276C0507)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 2:
						return;
					}
					break;
					IL_0024:
					propType = aType;
					num = 661390597;
				}
			}
		}
	}
}
