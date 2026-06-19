using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace TH20
{
	[Serializable]
	public class LogCallStackFrame
	{
		[SerializeField]
		private string _formattedMethodName;

		[SerializeField]
		private string _declaringType;

		[SerializeField]
		private string _fileName;

		[SerializeField]
		private int _lineNumber;

		[SerializeField]
		private string _methodName;

		[SerializeField]
		private string _parameterSig;

		private static readonly Regex UnityStackLineRegex = new Regex("(.*)\\.(.*)\\s*\\(.*\\(at (.*):(\\d+)");

		private static readonly Regex UnityMessageRegex = new Regex("(.*)\\((\\d+).*\\)");

		public string ParameterSig => _parameterSig;

		public string MethodName => _methodName;

		public int LineNumber => _lineNumber;

		public string FileName => _fileName;

		public string DeclaringType => _declaringType;

		public string FormattedMethodName => _formattedMethodName;

		public LogCallStackFrame(StackFrame frame)
		{
			MethodBase method = frame.GetMethod();
			MethodInfoCache.CachedMethodInfo cachedMethodInfo = MethodInfoCache.Instance.Get(method);
			_methodName = cachedMethodInfo.Name;
			_declaringType = cachedMethodInfo.DeclaringTypeName;
			_parameterSig = cachedMethodInfo.ParameterSignature;
			_fileName = frame.GetFileName();
			_lineNumber = frame.GetFileLineNumber();
			_formattedMethodName = MakeFormattedMethodName();
		}

		public LogCallStackFrame(string unityStackFrame)
		{
			if (ExtractInfoFromUnityStackInfo(unityStackFrame, ref _declaringType, ref _methodName, ref _fileName, ref _lineNumber))
			{
				_formattedMethodName = MakeFormattedMethodName();
			}
			else
			{
				_formattedMethodName = unityStackFrame;
			}
		}

		public LogCallStackFrame(string message, string filename, int lineNumber)
		{
			_fileName = filename;
			_lineNumber = lineNumber;
			_formattedMethodName = message;
		}

		private string MakeFormattedMethodName()
		{
			StringBuilder builder = StringBuilderPool.GlobalStringBuilderPool.GetBuilder(200);
			builder.Append(_declaringType);
			builder.Append(".");
			builder.Append(_methodName);
			builder.Append("(");
			builder.Append(_parameterSig);
			builder.Append(") (at ");
			if (!string.IsNullOrEmpty(_fileName))
			{
				int num = _fileName.IndexOf("Assets", StringComparison.OrdinalIgnoreCase);
				if (num >= 0)
				{
					builder.Append(_fileName, num, _fileName.Length - num);
				}
				else
				{
					builder.Append(_fileName);
				}
			}
			builder.Append(":");
			builder.Append(_lineNumber);
			builder.Append(")");
			string result = builder.ToString();
			StringBuilderPool.GlobalStringBuilderPool.ReturnBuilder(builder);
			return result;
		}

		private static bool ExtractInfoFromUnityStackInfo(string log, ref string declaringType, ref string methodName, ref string filename, ref int lineNumber)
		{
			MatchCollection matchCollection = UnityStackLineRegex.Matches(log);
			if (matchCollection.Count > 0)
			{
				declaringType = matchCollection[0].Groups[1].Value;
				methodName = matchCollection[0].Groups[2].Value;
				filename = matchCollection[0].Groups[3].Value;
				lineNumber = Convert.ToInt32(matchCollection[0].Groups[4].Value);
				return true;
			}
			return false;
		}

		public static bool ExtractFileAndLineInfoFromUnityMessage(string log, ref string filename, ref int lineNumber)
		{
			MatchCollection matchCollection = UnityMessageRegex.Matches(log);
			if (matchCollection.Count > 0)
			{
				filename = matchCollection[0].Groups[1].Value;
				lineNumber = Convert.ToInt32(matchCollection[0].Groups[2].Value);
				return true;
			}
			return false;
		}
	}
}
