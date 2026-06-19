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

		private string symbolPath;

		private byte[] asmBytes;

		private byte[] symbolBytes;

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

		internal AsyncLoadOperation(ScriptDomain domain, string assemblyPath, ScriptSecurityMode securityMode, string symbolPath = null)
		{
			loadDomain = domain;
			asmPath = assemblyPath;
			loadType = AssemblyLoadType.LoadByPath;
			this.securityMode = securityMode;
			this.symbolPath = symbolPath;
		}

		internal AsyncLoadOperation(ScriptDomain domain, byte[] assemblyBytes, ScriptSecurityMode securityMode, byte[] symbolBytes = null)
		{
			loadDomain = domain;
			asmBytes = assemblyBytes;
			loadType = AssemblyLoadType.LoadFromBytes;
			this.securityMode = securityMode;
			this.symbolBytes = symbolBytes;
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
					scriptAssembly = ((symbolPath == null) ? loadDomain.LoadAssembly(asmPath, securityMode) : loadDomain.LoadAssemblyWithSymbols(asmPath, symbolPath, securityMode));
					break;
				case AssemblyLoadType.LoadFromBytes:
					scriptAssembly = ((symbolBytes == null) ? loadDomain.LoadAssembly(asmBytes, securityMode) : loadDomain.LoadAssemblyWithSymbols(asmBytes, symbolBytes, securityMode));
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
