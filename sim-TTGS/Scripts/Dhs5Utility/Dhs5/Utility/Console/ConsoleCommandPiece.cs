using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dhs5.Utility.Console
{
	[Serializable]
	public class ConsoleCommandPiece
	{
		private enum Type
		{
			SINGLE = 0,
			MULTI = 1,
			PARAMETER = 2
		}

		[SerializeField]
		private Type m_type;

		[SerializeField]
		private string m_singleInput;

		[SerializeField]
		private string[] m_multiInputs;

		[SerializeField]
		private ParamType m_paramType;

		[SerializeField]
		private bool m_optional;

		public ConsoleCommandPiece(bool optional, string singleInput)
		{
			m_type = Type.SINGLE;
			m_singleInput = singleInput;
			m_multiInputs = null;
			m_paramType = ParamType.BOOL;
			m_optional = optional;
		}

		public ConsoleCommandPiece(bool optional, params string[] multiInputs)
		{
			m_type = Type.MULTI;
			m_singleInput = null;
			m_multiInputs = multiInputs;
			m_paramType = ParamType.BOOL;
			m_optional = optional;
		}

		public ConsoleCommandPiece(ParamType paramType)
		{
			m_type = Type.PARAMETER;
			m_singleInput = null;
			m_multiInputs = null;
			m_paramType = paramType;
			m_optional = false;
		}

		public IEnumerable<string> GetOptions()
		{
			switch (m_type)
			{
			case Type.SINGLE:
				yield return m_singleInput;
				if (m_optional)
				{
					yield return string.Empty;
				}
				break;
			case Type.MULTI:
			{
				for (int i = 0; i < m_multiInputs.Length; i++)
				{
					yield return m_multiInputs[i];
				}
				if (m_optional)
				{
					yield return string.Empty;
				}
				break;
			}
			case Type.PARAMETER:
				yield return ConsoleCommandUtility.GetParameterString(m_paramType);
				break;
			}
		}

		public bool IsCommandValid(string rawCommandPiece, out object parameter, out string rawCommandLeft)
		{
			parameter = null;
			rawCommandLeft = null;
			if (string.IsNullOrWhiteSpace(rawCommandPiece))
			{
				return m_optional;
			}
			switch (m_type)
			{
			case Type.SINGLE:
				if (rawCommandPiece.StartsWith(m_singleInput, StringComparison.OrdinalIgnoreCase) && (rawCommandPiece.Length == m_singleInput.Length || rawCommandPiece[m_singleInput.Length] == ' '))
				{
					parameter = null;
					rawCommandLeft = rawCommandPiece.Substring(m_singleInput.Length).Trim();
					return true;
				}
				break;
			case Type.MULTI:
			{
				for (int i = 0; i < m_multiInputs.Length; i++)
				{
					if (rawCommandPiece.StartsWith(m_multiInputs[i], StringComparison.OrdinalIgnoreCase) && (rawCommandPiece.Length == m_multiInputs[i].Length || rawCommandPiece[m_multiInputs[i].Length] == ' '))
					{
						parameter = i;
						rawCommandLeft = rawCommandPiece.Substring(m_multiInputs[i].Length).Trim();
						return true;
					}
				}
				break;
			}
			case Type.PARAMETER:
			{
				int num = rawCommandPiece.IndexOf(' ');
				string paramStr;
				if (num != -1)
				{
					paramStr = rawCommandPiece.Substring(0, num).Trim();
					rawCommandLeft = rawCommandPiece.Substring(num).Trim();
				}
				else
				{
					paramStr = rawCommandPiece;
					rawCommandLeft = string.Empty;
				}
				return ConsoleCommandUtility.IsParameterValid(paramStr, m_paramType, out parameter);
			}
			}
			if (m_optional)
			{
				parameter = null;
				rawCommandLeft = rawCommandPiece;
				return true;
			}
			return false;
		}
	}
}
