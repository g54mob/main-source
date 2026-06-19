using System;

namespace TMPEffects.Parameters.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = false)]
	public class TMPParameterTypeAttribute : Attribute
	{
		private bool generateKeywordDatabase;

		private string displayName;

		private Type sceneType;

		private Type diskType;

		public TMPParameterTypeAttribute(string displayName)
		{
		}

		public TMPParameterTypeAttribute(string displayName, Type diskType, Type sceneType)
		{
		}

		internal TMPParameterTypeAttribute(string displayName, bool generateKeywordDatabase)
		{
		}

		internal TMPParameterTypeAttribute(string displayName, Type diskType, Type sceneType, bool generateKeywordDatabase)
		{
		}
	}
}
