using System;
using System.Linq.Expressions;

namespace VoxelBusters.CoreLibrary
{
	public static class PropertyHelper
	{
		public static string GetValueOrDefault(string value, string defaultValue = null)
		{
			return null;
		}

		public static string GetValueOrDefault<TInstance, TProperty>(TInstance instance, Expression<Func<TInstance, TProperty>> fieldAccess, string value)
		{
			return null;
		}

		public static TValue GetValueOrDefault<TInstance, TProperty, TValue>(TInstance instance, Expression<Func<TInstance, TProperty>> fieldAccess, TValue? value) where TValue : struct
		{
			return default(TValue);
		}

		public static int GetConstrainedValue<TInstance, TProperty>(TInstance instance, Expression<Func<TInstance, TProperty>> fieldAccess, int value)
		{
			return 0;
		}

		public static float GetConstrainedValue<TInstance, TProperty>(TInstance instance, Expression<Func<TInstance, TProperty>> fieldAccess, float value)
		{
			return 0f;
		}
	}
}
