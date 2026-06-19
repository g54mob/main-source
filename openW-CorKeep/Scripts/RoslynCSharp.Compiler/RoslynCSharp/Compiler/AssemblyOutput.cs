using System.Reflection;

namespace RoslynCSharp.Compiler
{
	public sealed class AssemblyOutput
	{
		private Assembly outputAssembly;

		private string assemblyFilePath;

		private string assemblyPDBFilePath;

		private byte[] assemblyImage;

		private byte[] assemblyPDBImage;

		private bool isPatched;

		public Assembly OutputAssembly
		{
			get
			{
				return outputAssembly;
			}
			internal set
			{
				outputAssembly = value;
			}
		}

		public bool HasFilePath => assemblyFilePath != null;

		public string AssemblyFilePath
		{
			get
			{
				return assemblyFilePath;
			}
			internal set
			{
				assemblyFilePath = value;
			}
		}

		public string AssemblyPDBFilePath
		{
			get
			{
				return assemblyPDBFilePath;
			}
			internal set
			{
				assemblyPDBFilePath = value;
			}
		}

		public byte[] AssemblyImage
		{
			get
			{
				return assemblyImage;
			}
			internal set
			{
				assemblyImage = value;
			}
		}

		public byte[] AssemblyPDBImage
		{
			get
			{
				return assemblyPDBImage;
			}
			internal set
			{
				assemblyPDBImage = value;
			}
		}

		public bool IsPatched => isPatched;

		internal AssemblyOutput()
		{
		}

		public void PatchAssemblyFilePath(string newAssemblyFilePath)
		{
			assemblyFilePath = newAssemblyFilePath;
			isPatched = true;
		}

		public void PatchAssemblyPDBFilePath(string newAssemblyPDBFilePath)
		{
			assemblyPDBFilePath = newAssemblyPDBFilePath;
			isPatched = true;
		}

		public void PatchAssemblyImage(byte[] newAssemblyImage)
		{
			assemblyImage = newAssemblyImage;
			isPatched = true;
		}

		public void PatchAssemblyPDBImage(byte[] newAssemblyPDBImage)
		{
			assemblyPDBImage = newAssemblyPDBImage;
			isPatched = true;
		}
	}
}
