using System.Collections;
using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex03_LoadAssemblyAsync : MonoBehaviour
	{
		private ScriptDomain domain;

		public IEnumerator Start()
		{
			domain = ScriptDomain.CreateDomain("Example Domain");
			ScriptSecurityMode securityMode = ScriptSecurityMode.UseSettings;
			AsyncLoadOperation assemblyLoad = domain.LoadAssemblyAsync("path/to/assembly.dll", securityMode);
			yield return assemblyLoad;
			_ = assemblyLoad.LoadedAssembly;
		}
	}
}
