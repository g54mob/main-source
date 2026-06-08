using System;
using UnityEngine;

namespace RoslynCSharp.Example
{
	public class Ex01_CreateScriptDomain : MonoBehaviour
	{
		private ScriptDomain domain;

		public void Start()
		{
			bool initCompiler = true;
			bool makeActiveDomain = true;
			AppDomain currentDomain = AppDomain.CurrentDomain;
			domain = ScriptDomain.CreateDomain("Example Domain", initCompiler, makeActiveDomain, currentDomain);
		}
	}
}
