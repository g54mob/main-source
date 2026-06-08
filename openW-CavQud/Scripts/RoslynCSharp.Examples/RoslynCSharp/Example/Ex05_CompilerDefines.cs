using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex05_CompilerDefines : MonoBehaviour
	{
		private ScriptDomain domain;

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			domain.RoslynCompilerService.DefineSymbols.Add("DEBUG");
			domain.RoslynCompilerService.DefineSymbols.Add("UNITY_EDITOR");
		}
	}
}
