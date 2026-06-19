using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using RoslynCSharp.Compiler;
using Trivial.CodeSecurity;
using UnityEngine;

namespace RoslynCSharp
{
	public abstract class ScriptAssembly : IMetadataReferenceProvider
	{
		private static List<ScriptType> matchedTypes = new List<ScriptType>();

		private Dictionary<string, ScriptType> scriptTypes;

		private ScriptType mainType;

		private bool isSecurityValidated;

		private int securityValidatedHash = -1;

		private CodeSecurityReport securityReport;

		protected string assemblyPath;

		protected string assemblySymbolsPath;

		protected byte[] assemblyImage;

		protected byte[] assemblySymbolsImage;

		public abstract ScriptDomain Domain { get; }

		public abstract Assembly SystemAssembly { get; }

		public virtual ScriptType MainType
		{
			get
			{
				if (mainType == null)
				{
					LoadScriptAssemblyTypes();
					ScriptType scriptType = null;
					using (Dictionary<string, ScriptType>.ValueCollection.Enumerator enumerator = scriptTypes.Values.GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							scriptType = enumerator.Current;
						}
					}
					ScriptType scriptType2 = scriptTypes.Values.Where((ScriptType t) => t.SystemType.IsClass && t.Name != "<Module>").FirstOrDefault();
					mainType = ((scriptType2 != null) ? scriptType2 : scriptType);
				}
				return mainType;
			}
		}

		public virtual string Name => SystemAssembly.GetName().Name;

		public virtual string FullName => SystemAssembly.FullName;

		public virtual Version Version => SystemAssembly.GetName().Version;

		public virtual string AssemblyPath => assemblyPath;

		public virtual string AssemblySymbolsPath => assemblySymbolsPath;

		public virtual byte[] AssemblyImage => assemblyImage;

		public virtual byte[] AssemblySymbolsImage => assemblySymbolsImage;

		public virtual MetadataReference CompilerReference
		{
			get
			{
				if (AssemblyImage != null)
				{
					return AssemblyReference.FromImage(AssemblyImage).CompilerReference;
				}
				return AssemblyReference.FromNameOrFile(AssemblyPath).CompilerReference;
			}
		}

		public abstract bool IsRuntimeCompiled { get; }

		public abstract DateTime RuntimeCompiledTime { get; }

		public abstract CompilationResult CompileResult { get; }

		public virtual bool IsSecurityValidated => isSecurityValidated;

		public virtual CodeSecurityReport SecurityReport => securityReport;

		protected abstract void ConstructInstance(ScriptDomain domain, Assembly systemAssembly);

		public override string ToString()
		{
			return string.Format("{0}({1})", "ScriptAssembly", SystemAssembly);
		}

		public bool SecurityCheckAssembly(CodeSecurityRestrictions restrictions)
		{
			CodeSecurityReport report;
			return SecurityCheckAssembly(restrictions, out report);
		}

		public virtual bool SecurityCheckAssembly(CodeSecurityRestrictions restrictions, out CodeSecurityReport report)
		{
			if (isSecurityValidated && restrictions.RestrictionsHash == securityValidatedHash)
			{
				report = securityReport;
				return true;
			}
			CodeSecurityEngine codeSecurityEngine = CreateSecurityEngine();
			if (codeSecurityEngine == null)
			{
				report = securityReport;
				return isSecurityValidated;
			}
			using (codeSecurityEngine)
			{
				isSecurityValidated = codeSecurityEngine.SecurityCheckAssembly(restrictions, out securityReport);
				if (isSecurityValidated)
				{
					securityValidatedHash = restrictions.RestrictionsHash;
				}
				else
				{
					securityValidatedHash = -1;
				}
				report = securityReport;
				return isSecurityValidated;
			}
		}

		protected virtual CodeSecurityEngine CreateSecurityEngine()
		{
			if (AssemblyImage != null)
			{
				return new CodeSecurityEngine(AssemblyImage, AssemblySymbolsImage);
			}
			if (AssemblyPath == null)
			{
				throw new NotSupportedException("Cannot create code security engine for script assembly with no valid source load location");
			}
			return new CodeSecurityEngine(AssemblyPath);
		}

		public virtual bool HasType(string name)
		{
			return FindType(name) != null;
		}

		public virtual bool HasSubTypeOf(Type subType)
		{
			return FindSubTypeOf(subType) != null;
		}

		public bool HasSubTypeOf<T>()
		{
			return HasSubTypeOf(typeof(T));
		}

		public virtual bool HasSubTypeOf(Type subType, string name)
		{
			return FindSubTypeOf(subType, name) != null;
		}

		public bool HasSubTypeOf<T>(string name)
		{
			return HasSubTypeOf(typeof(T), name);
		}

		public virtual ScriptType FindType(string name)
		{
			LoadScriptAssemblyTypes();
			Type type = SystemAssembly.GetType(name, throwOnError: false, ignoreCase: false);
			if (type == null)
			{
				return null;
			}
			return scriptTypes[type.FullName];
		}

		public virtual ScriptType FindType(Type type)
		{
			LoadScriptAssemblyTypes();
			if (type == null)
			{
				return null;
			}
			return scriptTypes[type.FullName];
		}

		public virtual ScriptType FindSubTypeOf(Type subType, bool includeNonPublic = true, bool findNestedTypes = true)
		{
			LoadScriptAssemblyTypes();
			foreach (ScriptType value in scriptTypes.Values)
			{
				if ((includeNonPublic || value.IsPublic) && (!value.IsNestedType || findNestedTypes) && value.IsSubTypeOf(subType))
				{
					return value;
				}
			}
			return null;
		}

		public ScriptType FindSubTypeOf<T>(bool includeNonPublic = true, bool findNestedTypes = true)
		{
			return FindSubTypeOf(typeof(T), includeNonPublic, findNestedTypes);
		}

		public virtual ScriptType FindSubTypeOf(Type subType, string name)
		{
			LoadScriptAssemblyTypes();
			ScriptType scriptType = FindType(name);
			if (scriptType == null)
			{
				return null;
			}
			if (scriptType.IsSubTypeOf(subType))
			{
				return scriptType;
			}
			return null;
		}

		public ScriptType FindSubTypeOf<T>(string name)
		{
			return FindSubTypeOf(typeof(T), name);
		}

		public virtual ScriptType[] FindAllSubTypesOf(Type subType, bool includeNonPublic = true, bool findNestedTypes = true)
		{
			LoadScriptAssemblyTypes();
			matchedTypes.Clear();
			foreach (ScriptType value in scriptTypes.Values)
			{
				if ((includeNonPublic || value.IsPublic) && (!value.IsNestedType || findNestedTypes) && value.IsSubTypeOf(subType))
				{
					matchedTypes.Add(value);
				}
			}
			return matchedTypes.ToArray();
		}

		public ScriptType[] FindAllSubTypesOf<T>(bool includeNonPublic = true, bool findNestedTypes = true)
		{
			return FindAllSubTypesOf(typeof(T), includeNonPublic, findNestedTypes);
		}

		public virtual ScriptType[] FindAllTypes(bool includeNonPublic = true, bool findNestedTypes = true)
		{
			LoadScriptAssemblyTypes();
			matchedTypes.Clear();
			matchedTypes.AddRange(scriptTypes.Values);
			if (!findNestedTypes)
			{
				matchedTypes.RemoveAll((ScriptType t) => t.IsNestedType);
			}
			return matchedTypes.ToArray();
		}

		public ScriptType[] FindAllUnityTypes(bool includeNonPublic = true, bool findNestedTypes = true)
		{
			return FindAllSubTypesOf<UnityEngine.Object>(includeNonPublic, findNestedTypes);
		}

		public ScriptType[] FindAllMonoBehaviourTypes(bool includeNonPublic = true, bool findNestedTypes = true)
		{
			return FindAllSubTypesOf<MonoBehaviour>(includeNonPublic, findNestedTypes);
		}

		public ScriptType[] FindAllScriptableObjectTypes(bool includeNonPublic = true, bool findNestedTypes = true)
		{
			return FindAllSubTypesOf<ScriptableObject>(includeNonPublic, findNestedTypes);
		}

		public virtual IEnumerable<ScriptType> EnumerateAllSubTypesOf(Type subType, bool includeNonPublic = true, bool enumerateNestedTypes = true)
		{
			LoadScriptAssemblyTypes();
			foreach (ScriptType value in scriptTypes.Values)
			{
				if ((includeNonPublic || value.IsPublic) && (!value.IsNestedType || enumerateNestedTypes) && value.IsSubTypeOf(subType))
				{
					yield return value;
				}
			}
		}

		public IEnumerable<ScriptType> EnumerateAllSubTypesOf<T>(bool includeNonPublic = true, bool enumerateNestedTypes = true)
		{
			return EnumerateAllSubTypesOf(typeof(T), includeNonPublic, enumerateNestedTypes);
		}

		public virtual IEnumerable<ScriptType> EnumerateAllTypes(bool includeNonPublic = true, bool enumerateNestedTypes = true)
		{
			LoadScriptAssemblyTypes();
			foreach (ScriptType value in scriptTypes.Values)
			{
				if ((includeNonPublic || value.IsPublic) && (!value.IsNestedType || enumerateNestedTypes))
				{
					yield return value;
				}
			}
		}

		public IEnumerable<ScriptType> EnumerateAllUnityTypes(bool includeNonPublic = true, bool enumerateNestedTypes = true)
		{
			return EnumerateAllSubTypesOf<UnityEngine.Object>(includeNonPublic, enumerateNestedTypes);
		}

		public IEnumerable<ScriptType> EnumerateAllMonoBehaviourTypes(bool includeNonPublic = true, bool enumerateNestedTypes = true)
		{
			return EnumerateAllSubTypesOf<MonoBehaviour>(includeNonPublic, enumerateNestedTypes);
		}

		public IEnumerable<ScriptType> EnumerateAllScriptableObjectTypes(bool includeNonPublic = true, bool enumerateNestedTypes = true)
		{
			return EnumerateAllSubTypesOf<ScriptableObject>(includeNonPublic, enumerateNestedTypes);
		}

		protected abstract ScriptType CreateRootScriptType(Type systemType);

		private void LoadScriptAssemblyTypes()
		{
			if (scriptTypes != null)
			{
				return;
			}
			scriptTypes = new Dictionary<string, ScriptType>();
			Type[] types = SystemAssembly.GetTypes();
			foreach (Type type in types)
			{
				if (!type.IsNested)
				{
					scriptTypes.Add(type.FullName, CreateRootScriptType(type));
				}
			}
		}

		public static T CreateScriptAssembly<T>(ScriptDomain domain, Assembly systemAssembly, string assemblyPath = null, string assemblySymbolsPath = null, byte[] assemblyImage = null, byte[] assemblySymbolsImage = null, CompilationResult compileResult = null) where T : ScriptAssembly, new()
		{
			T val = new T();
			val.ConstructInstance(domain, systemAssembly);
			val.assemblyPath = assemblyPath;
			val.assemblySymbolsPath = assemblySymbolsPath;
			val.assemblyImage = assemblyImage;
			val.assemblySymbolsImage = assemblySymbolsImage;
			if (val is IScriptCompiledAssembly)
			{
				(val as IScriptCompiledAssembly).MarkAsRuntimeCompiled(compileResult);
			}
			return val;
		}
	}
}
