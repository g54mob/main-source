using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Dhs5.Utility.Console
{
	internal struct CommandArray
	{
		private List<string> m_list;

		public bool IsValid => m_list.IsValid();

		public int Count => m_list.Count;

		public CommandArray(string str)
		{
			m_list = new List<string>();
			Push(str);
		}

		public CommandArray(CommandArray other)
		{
			if (other.IsValid)
			{
				m_list = new List<string>(other.m_list);
			}
			else
			{
				m_list = new List<string>();
			}
		}

		public void Push(string input)
		{
			if (!string.IsNullOrWhiteSpace(input))
			{
				if (m_list == null)
				{
					m_list = new List<string>();
				}
				string[] array = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					m_list.Add(array[i]);
				}
			}
		}

		public string GetAtIndex(int index)
		{
			if (m_list.IsIndexValid(index))
			{
				return m_list[index];
			}
			return null;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < m_list.Count; i++)
			{
				stringBuilder.Append(m_list[i]);
				if (i < Count - 1)
				{
					stringBuilder.Append(' ');
				}
			}
			return stringBuilder.ToString();
		}

		public string ToStringWithoutParams()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < m_list.Count; i++)
			{
				if (ConsoleCommandUtility.IsParameterString(m_list[i], out var paramType))
				{
					stringBuilder.Append(ConsoleCommandUtility.ParamDefaultValueAsString(paramType));
				}
				else
				{
					stringBuilder.Append(m_list[i]);
				}
				if (i < Count - 1)
				{
					stringBuilder.Append(' ');
				}
			}
			return stringBuilder.ToString();
		}

		public bool StartsTheSameAs(CommandArray other)
		{
			if (IsValid && other.IsValid)
			{
				int num = Mathf.Min(Count, other.Count);
				string atIndex;
				string atIndex2;
				for (int i = 0; i < num - 1; i++)
				{
					atIndex = GetAtIndex(i);
					atIndex2 = other.GetAtIndex(i);
					if (string.Compare(atIndex, atIndex2, ignoreCase: true) != 0 && !IsFirstStrStartingLikeParameterOfTypeSecondStr(atIndex, atIndex2))
					{
						return false;
					}
				}
				atIndex = GetAtIndex(num - 1);
				atIndex2 = other.GetAtIndex(num - 1);
				if (!IsFirstStrStartingLikeParameterOfTypeSecondStr(atIndex, atIndex2) && !atIndex2.StartsWith(atIndex, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
			}
			return true;
		}

		private static bool IsFirstStrStartingLikeParameterOfTypeSecondStr(string firstStr, string secondStr)
		{
			if (!ConsoleCommandUtility.IsParameterString(secondStr, out var paramType))
			{
				return false;
			}
			object param;
			return ConsoleCommandUtility.IsParameterValid(firstStr, paramType, out param);
		}

		public static bool StartTheSame(CommandArray a, CommandArray b)
		{
			if (a.IsValid && b.IsValid)
			{
				int num = Mathf.Min(a.Count, b.Count);
				for (int i = 0; i < num; i++)
				{
					if (string.Compare(a.GetAtIndex(i), b.GetAtIndex(i), ignoreCase: true) != 0)
					{
						return false;
					}
				}
			}
			return true;
		}
	}
}
