using System;
using DynamicCSharp.Compiler;

namespace DynamicCSharp
{
	public class AsyncCompileLoadOperation : AsyncCompileOperation
	{
		private ScriptDomain domain;

		private ScriptAssembly loadedAssembly;

		public ScriptType MainType
		{
			get
			{
				return loadedAssembly.MainType;
			}
		}

		public ScriptAssembly LoadedAssembly
		{
			get
			{
				return loadedAssembly;
			}
		}

		internal AsyncCompileLoadOperation(ScriptDomain domain, Func<bool> asyncCallback)
			: base(domain.CompilerService, asyncCallback)
		{
			this.domain = domain;
		}

		protected override void DoSyncFinalize()
		{
			base.DoSyncFinalize();
			if (base.IsSuccessful)
			{
				loadedAssembly = domain.LoadAssembly(assemblyData);
			}
		}
	}
}
