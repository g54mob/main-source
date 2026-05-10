using System.Reflection;
using UnityEngine;

namespace CTS.BBT
{
	public static class AgentAnimData
	{
		public static readonly string[] VarNames;

		public static readonly AnimKey[] Values;

		public static readonly int[] IntValues;

		public static readonly string[] FullNames;

		static AgentAnimData()
		{
			FieldInfo[] fields = typeof(AgentAnim).GetFields(BindingFlags.Static | BindingFlags.Public);
			VarNames = new string[fields.Length];
			Values = new AnimKey[fields.Length];
			IntValues = new int[fields.Length];
			FullNames = new string[fields.Length];
			for (int i = 0; i < fields.Length; i++)
			{
				FieldInfo fieldInfo = fields[i];
				Values[i] = (AnimKey)fieldInfo.GetValue(null);
				IntValues[i] = Values[i];
				HeaderAttribute customAttribute = fieldInfo.GetCustomAttribute<HeaderAttribute>();
				VarNames[i] = fieldInfo.Name;
				FullNames[i] = ((customAttribute != null) ? (customAttribute.header + "/" + fieldInfo.Name) : fieldInfo.Name);
			}
		}
	}
}
