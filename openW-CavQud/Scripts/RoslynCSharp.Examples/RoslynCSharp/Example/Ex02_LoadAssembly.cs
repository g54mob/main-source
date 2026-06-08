using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex02_LoadAssembly : MonoBehaviour
	{
		private ScriptDomain domain;

		public void Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings;
			domain.LoadAssembly("path/to/assembly.dll", securityMode);
		}
	}
}
