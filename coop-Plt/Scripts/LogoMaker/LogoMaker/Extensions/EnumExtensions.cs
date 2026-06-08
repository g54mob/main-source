using System;
using UnityEngine;

namespace LogoMaker.Extensions
{
	public static class EnumExtensions
	{
		public static T GetRandom<T>()
		{
			Array values = Enum.GetValues(typeof(T));
			return (T)values.GetValue(UnityEngine.Random.Range(0, values.Length));
		}
	}
}
