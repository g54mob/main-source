using System;

namespace RoslynCSharp.Modding
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class ModReplaceableBehaviourAttribute : Attribute
	{
		private string replaceScriptName = "";

		private Type requireBaseType;

		private Type[] requireInterfaceTypes;

		public string ReplaceScriptName => replaceScriptName;

		public Type RequireBaseType => requireBaseType;

		public Type[] RequireInterfaceTypes => requireInterfaceTypes;

		public ModReplaceableBehaviourAttribute(string replaceScriptName = "", Type requireBaseType = null, params Type[] requireInterfaceTypes)
		{
			this.replaceScriptName = replaceScriptName;
			this.requireBaseType = requireBaseType;
			this.requireInterfaceTypes = requireInterfaceTypes;
		}
	}
}
