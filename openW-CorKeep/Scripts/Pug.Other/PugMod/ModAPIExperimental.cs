using System;
using System.Linq;
using System.Reflection;
using System.Text;
using HarmonyLib;
using UnityEngine;

namespace PugMod
{
	public class ModAPIExperimental : IExperimental
	{
		private string GetSignature(MethodInfo member)
		{
			if (member == null)
			{
				return "null";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(member.ReturnType.Name);
			stringBuilder.Append(' ');
			string text = "";
			text = member.GetParameters().Join((ParameterInfo p) => p.ParameterType.Name + " " + p.Name);
			stringBuilder.Append('(');
			stringBuilder.Append(text);
			stringBuilder.Append(')');
			return stringBuilder.ToString();
		}

		public int RegisterAttributeFunction<TAttr, TDel>(Type type, Func<TDel, TAttr, bool> handler) where TAttr : Attribute where TDel : Delegate
		{
			int num = 0;
			foreach (MethodInfo item in from x in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
				where x.GetCustomAttribute<TAttr>() != null
				select x)
			{
				TDel val = (TDel)Delegate.CreateDelegate(typeof(TDel), item, throwOnBindFailure: false);
				if (val == null)
				{
					MethodInfo method = typeof(TDel).GetMethod("Invoke");
					Debug.LogError("Failed to add modify method '" + item.Name + "', because method signature is incorrect. Should be " + GetSignature(method) + "!");
					continue;
				}
				foreach (TAttr customAttribute in item.GetCustomAttributes<TAttr>())
				{
					if (handler(val, customAttribute))
					{
						num++;
					}
				}
			}
			return num;
		}
	}
}
