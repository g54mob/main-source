using System.Reflection;

namespace RoslynCSharp
{
	public sealed class AsyncLoadOperation : AsyncOperation
	{
		private enum AssemblyLoadType
		{
			LoadByName = 0,
			LoadByPath = 1,
			LoadFromBytes = 2
		}

		private object assemblyAccessLock = new object();

		private ScriptDomain loadDomain;

		private ScriptAssembly loadResult;

		private ScriptSecurityMode securityMode;

		private bool isSecurityVerified;

		private AssemblyLoadType loadType;

		private AssemblyName asmName;

		private string asmPath;

		private byte[] asmBytes;

		public ScriptDomain LoadDomain
		{
			get
			{
				lock (loadDomain)
				{
					return loadDomain;
				}
			}
		}

		public ScriptAssembly LoadedAssembly
		{
			get
			{
				lock (assemblyAccessLock)
				{
					return loadResult;
				}
			}
		}

		public bool IsSecurityVerified => isSecurityVerified;

		internal AsyncLoadOperation(ScriptDomain domain, AssemblyName assemblyName, ScriptSecurityMode securityMode)
		{
			loadDomain = domain;
			asmName = assemblyName;
			loadType = AssemblyLoadType.LoadByName;
			this.securityMode = securityMode;
		}

		internal AsyncLoadOperation(ScriptDomain domain, string assemblyPath, ScriptSecurityMode securityMode)
		{
			loadDomain = domain;
			asmPath = assemblyPath;
			loadType = AssemblyLoadType.LoadByPath;
			this.securityMode = securityMode;
		}

		internal AsyncLoadOperation(ScriptDomain domain, byte[] assemblyBytes, ScriptSecurityMode securityMode)
		{
			loadDomain = domain;
			asmBytes = assemblyBytes;
			loadType = AssemblyLoadType.LoadFromBytes;
			this.securityMode = securityMode;
		}

		protected override void RunAsyncOperation()
		{
			ScriptAssembly scriptAssembly = null;
			lock (loadDomain)
			{
				switch (loadType)
				{
				case AssemblyLoadType.LoadByName:
					scriptAssembly = loadDomain.LoadAssembly(asmName, securityMode);
					break;
				case AssemblyLoadType.LoadByPath:
					scriptAssembly = loadDomain.LoadAssembly(asmPath, securityMode);
					break;
				case AssemblyLoadType.LoadFromBytes:
					scriptAssembly = loadDomain.LoadAssembly(asmBytes, securityMode);
					break;
				}
				lock (assemblyAccessLock)
				{
					loadResult = scriptAssembly;
				}
			}
			isSuccessful = scriptAssembly != null;
			isSecurityVerified = loadDomain.SecurityResult != null && loadDomain.SecurityResult.IsSecurityVerified;
		}
	}
}
