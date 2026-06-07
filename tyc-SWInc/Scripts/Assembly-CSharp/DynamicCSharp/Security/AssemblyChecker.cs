using System;
using System.ComponentModel;
using System.IO;
using Mono.Cecil;

namespace DynamicCSharp.Security
{
	internal sealed class AssemblyChecker
	{
		private AssemblySecurityError[] errors = new AssemblySecurityError[0];

		public AssemblySecurityError[] Errors
		{
			get
			{
				return errors;
			}
		}

		public bool HasErrors
		{
			get
			{
				return errors.Length != 0;
			}
		}

		public int ErrorCount
		{
			get
			{
				return errors.Length;
			}
		}

		public void SecurityCheckAssembly(byte[] assemblyData, ScriptDomain.HackLevel allowHack)
		{
			ClearErrors();
			AssemblyDefinition assemblyDefinition = null;
			using (MemoryStream stream = new MemoryStream(assemblyData))
			{
				assemblyDefinition = AssemblyDefinition.ReadAssembly(stream);
			}
			bool flag = false;
			foreach (ModuleDefinition module in assemblyDefinition.Modules)
			{
				if (allowHack > ScriptDomain.HackLevel.DENY && !flag)
				{
					foreach (TypeDefinition type in module.Types)
					{
						if (type.IsClass && type.BaseType != null && type.BaseType.Name.Equals("ModMeta") && type.HasFields && type.Fields.Any((FieldDefinition x) => x.IsPublic && x.IsStatic && x.Name.Equals("GiveMeFreedom")))
						{
							flag = true;
							if (allowHack == ScriptDomain.HackLevel.ALLOW)
							{
								ClearErrors();
								return;
							}
						}
					}
				}
				SecurityCheckModule(assemblyDefinition.Name, module);
			}
			if (flag && allowHack == ScriptDomain.HackLevel.WARN)
			{
				throw new WarningException();
			}
		}

		private void SecurityCheckModule(AssemblyNameDefinition assemblyName, ModuleDefinition module)
		{
			foreach (Restriction restriction in DynamicCSharp.Settings.Restrictions)
			{
				if (restriction.Mode == RestrictionMode.Exclusive && !restriction.Verify(module))
				{
					CreateError(assemblyName.Name, module.Name, restriction.Message, restriction.GetType().Name);
				}
			}
		}

		private void ClearErrors()
		{
			errors = new AssemblySecurityError[0];
		}

		private void CreateError(string assemblyName, string moduleName, string message, string type)
		{
			AssemblySecurityError assemblySecurityError = new AssemblySecurityError
			{
				assemblyName = assemblyName,
				moduleName = moduleName,
				securityMessage = message,
				securityType = type
			};
			Array.Resize(ref errors, errors.Length + 1);
			errors[errors.Length - 1] = assemblySecurityError;
		}
	}
}
