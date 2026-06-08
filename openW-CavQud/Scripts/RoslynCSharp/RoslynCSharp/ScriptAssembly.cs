using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.CodeAnalysis;
using RoslynCSharp.Compiler;
using Trivial.CodeSecurity;
using UnityEngine;

namespace RoslynCSharp
{
	public sealed class ScriptAssembly : IMetadataReferenceProvider
	{
		private static List<ScriptType> matchedTypes = new List<ScriptType>();

		private ScriptDomain domain;

		private string assemblyPath;

		private byte[] rawAssemblyImage;

		private Assembly rawAssembly;

		private CodeSecurityReport securityReport;

		private CompilationResult compileResult;

		private Dictionary<string, ScriptType> scriptTypes = new Dictionary<string, ScriptType>();

		private DateTime runtimeCompiledTime = DateTime.MinValue;

		private bool isRuntimeCompiled;

		private bool isSecurityValidated;

		private int securityValidatedHash = -1;

		public string Name => rawAssembly.GetName().Name;

		public string AssemblyPath
		{
			get
			{
				return assemblyPath;
			}
			internal set
			{
				assemblyPath = value;
			}
		}

		public byte[] AssemblyImage
		{
			get
			{
				return rawAssemblyImage;
			}
			internal set
			{
				rawAssemblyImage = value;
			}
		}

		public Version Version => rawAssembly.GetName().Version;

		public string FullName => rawAssembly.FullName;

		public MetadataReference Reference
		{
			get
			{
				if (compileResult != null)
				{
					return compileResult.Reference;
				}
				return null;
			}
		}

		public DateTime RuntimeCompiledTime => runtimeCompiledTime;

		public bool IsRuntimeCompiled => isRuntimeCompiled;

		public CompilationResult CompileResult => compileResult;

		public bool IsSecurityValidated => isSecurityValidated;

		public ScriptDomain Domain => domain;

		public ScriptType MainType
		{
			get
			{
				if (scriptTypes.Count == 0)
				{
					return null;
				}
				ScriptType result = null;
				using (Dictionary<string, ScriptType>.ValueCollection.Enumerator enumerator = scriptTypes.Values.GetEnumerator())
				{
					if (enumerator.MoveNext())
					{
						result = enumerator.Current;
					}
				}
				return result;
			}
		}

		public Assembly RawAssembly => rawAssembly;

		internal ScriptAssembly(ScriptDomain domain, Assembly rawAssembly, CompilationResult compileResult = null)
		{
			this.domain = domain;
			this.rawAssembly = rawAssembly;
			this.compileResult = compileResult;
			Type[] types = rawAssembly.GetTypes();
			foreach (Type type in types)
			{
				if (!type.IsNested)
				{
					ScriptType value = new ScriptType(this, null, type);
					scriptTypes.Add(type.FullName, value);
				}
			}
			matchedTypes.AddRange(scriptTypes.Values);
			foreach (ScriptType matchedType in matchedTypes)
			{
				CreateNestedTypes(matchedType);
			}
			matchedTypes.Clear();
		}

		public bool SecurityCheckAssembly(CodeSecurityRestrictions restrictions)
		{
			if (isSecurityValidated && restrictions.RestrictionsHash == securityValidatedHash)
			{
				return true;
			}
			CodeSecurityEngine codeSecurityEngine = CreateSecurityEngine();
			if (codeSecurityEngine == null)
			{
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
				return isSecurityValidated;
			}
		}

		public bool SecurityCheckAssembly(CodeSecurityRestrictions restrictions, out CodeSecurityReport report)
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

		private CodeSecurityEngine CreateSecurityEngine()
		{
			if (!isRuntimeCompiled)
			{
				if (assemblyPath != null)
				{
					return new CodeSecurityEngine(assemblyPath);
				}
				if (rawAssemblyImage != null)
				{
					return new CodeSecurityEngine(rawAssemblyImage);
				}
				return null;
			}
			return CreateSecurityEngine(compileResult);
		}

		private CodeSecurityEngine CreateSecurityEngine(CompilationResult result)
		{
			if (!result.Success)
			{
				return null;
			}
			if (result.OutputAssemblyImage != null)
			{
				return new CodeSecurityEngine(result.OutputAssemblyImage);
			}
			if (result.OutputFile != null)
			{
				return new CodeSecurityEngine(result.OutputFile);
			}
			if (result.OutputAssembly != null)
			{
				return new CodeSecurityEngine(result.OutputAssembly.Location);
			}
			return null;
		}

		public bool HasType(string name)
		{
			return FindType(name) != null;
		}

		public bool HasSubTypeOf(Type subType)
		{
			return FindSubTypeOf(subType) != null;
		}

		public bool HasSubTypeOf(Type subType, string name)
		{
			return FindSubTypeOf(subType, name) != null;
		}

		public bool HasSubTypeOf<T>()
		{
			return FindSubTypeOf<T>() != null;
		}

		public bool HasSubTypeOf<T>(string name)
		{
			return FindSubTypeOf<T>(name) != null;
		}

		public ScriptType FindType(string name)
		{
			Type type = rawAssembly.GetType(name, throwOnError: false, ignoreCase: false);
			if (type == null)
			{
				return null;
			}
			return scriptTypes[type.FullName];
		}

		public ScriptType FindSubTypeOf(Type subType, bool includeNonPublic = true, bool findNestedTypes = true)
		{
			foreach (ScriptType value in scriptTypes.Values)
			{
				if ((includeNonPublic || value.IsPublic) && (!value.IsNestedType || findNestedTypes) && value.IsSubTypeOf(subType))
				{
					return value;
				}
			}
			return null;
		}

		public ScriptType FindSubTypeOf(Type subType, string name)
		{
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

		public ScriptType FindSubTypeOf<T>(bool includeNonPublic = true, bool findNestedTypes = true)
		{
			return FindSubTypeOf(typeof(T), includeNonPublic, findNestedTypes);
		}

		public ScriptType FindSubTypeOf<T>(string name, bool findNestedTypes = true)
		{
			return FindSubTypeOf(typeof(T), name);
		}

		public ScriptType[] FindAllSubTypesOf(Type subType, bool includeNonPublic = true, bool findNestedTypes = true)
		{
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

		public ScriptType[] FindAllTypes(bool includeNonPublic = true, bool findNestedTypes = true)
		{
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

		public IEnumerable<ScriptType> EnumerateAllSubTypesOf(Type subType, bool includeNonPublic = true, bool enumerateNestedTypes = true)
		{
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

		public IEnumerable<ScriptType> EnumerateAllTypes(bool includeNonPublic = true, bool enumerateNestedTypes = true)
		{
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

		internal void MarkAsRuntimeCompiled()
		{
			isRuntimeCompiled = true;
			runtimeCompiledTime = DateTime.Now;
		}

		private void CreateNestedTypes(ScriptType type)
		{
			Type[] nestedTypes = type.RawType.GetNestedTypes(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (Type type2 in nestedTypes)
			{
				ScriptType scriptType = new ScriptType(this, type, type2);
				scriptTypes.Add(scriptType.FullName, scriptType);
				CreateNestedTypes(scriptType);
			}
		}
	}
}
