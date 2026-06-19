using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RoslynCSharp.Modding
{
	public static class ModScriptReplacer
	{
		private struct ScriptReplacementInfo
		{
			public string replaceName;

			public Type requireBaseType;

			public Type[] requireInterfaceTypes;
		}

		public static bool ReplaceScriptsForActiveScene(ScriptAssembly scriptAssembly, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			ModScriptReplacerReport report;
			return ReplaceScriptsForActiveScene(scriptAssembly, out report, options);
		}

		public static bool ReplaceScriptsForActiveScene(ScriptAssembly scriptAssembly, out ModScriptReplacerReport report, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			return ReplaceScriptsForScene(SceneManager.GetActiveScene(), scriptAssembly, out report, options);
		}

		public static bool ReplaceScriptsForActiveScene(ScriptType scriptType, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			ModScriptReplacerReport report;
			return ReplaceScriptsForActiveScene(scriptType, out report, options);
		}

		public static bool ReplaceScriptsForActiveScene(ScriptType scriptType, out ModScriptReplacerReport report, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			return ReplaceScriptsForScene(SceneManager.GetActiveScene(), scriptType, out report, options);
		}

		public static bool ReplaceScriptsForScene(Scene targetScene, ScriptAssembly scriptAssembly, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			ModScriptReplacerReport report;
			return ReplaceScriptsForScene(targetScene, scriptAssembly, out report, options);
		}

		public static bool ReplaceScriptsForScene(Scene targetScene, ScriptAssembly scriptAssembly, out ModScriptReplacerReport report, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			bool flag = false;
			report = new ModScriptReplacerReport();
			bool includeInactive = (options & ScriptReplacerOptions.ReplaceDisabledScripts) != 0;
			GameObject[] rootGameObjects = targetScene.GetRootGameObjects();
			for (int i = 0; i < rootGameObjects.Length; i++)
			{
				MonoBehaviour[] componentsInChildren = rootGameObjects[i].GetComponentsInChildren<MonoBehaviour>(includeInactive);
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					if (!ReplaceScriptBehaviourImpl(componentsInChildren[j], scriptAssembly, ref report, options))
					{
						flag = true;
					}
				}
			}
			return !flag;
		}

		public static bool ReplaceScriptsForScene(Scene targetScene, ScriptType scriptType)
		{
			ModScriptReplacerReport report;
			return ReplaceScriptsForScene(targetScene, scriptType, out report);
		}

		public static bool ReplaceScriptsForScene(Scene targetScene, ScriptType scriptType, out ModScriptReplacerReport report, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			bool flag = false;
			report = new ModScriptReplacerReport();
			bool includeInactive = (options & ScriptReplacerOptions.ReplaceDisabledScripts) != 0;
			GameObject[] rootGameObjects = targetScene.GetRootGameObjects();
			for (int i = 0; i < rootGameObjects.Length; i++)
			{
				MonoBehaviour[] componentsInChildren = rootGameObjects[i].GetComponentsInChildren<MonoBehaviour>(includeInactive);
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					if (!ReplaceScriptBehaviourImpl(componentsInChildren[j], scriptType, ref report, options))
					{
						flag = true;
					}
				}
			}
			return !flag;
		}

		public static bool ReplaceScriptsForObject(GameObject gameObject, ScriptAssembly scriptAssembly, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			ModScriptReplacerReport report;
			return ReplaceScriptsForObject(gameObject, scriptAssembly, out report, options);
		}

		public static bool ReplaceScriptsForObject(GameObject gameObject, ScriptAssembly scriptAssembly, out ModScriptReplacerReport report, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			bool flag = false;
			report = new ModScriptReplacerReport();
			bool includeInactive = (options & ScriptReplacerOptions.ReplaceDisabledScripts) != 0;
			MonoBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<MonoBehaviour>(includeInactive);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!ReplaceScriptBehaviourImpl(componentsInChildren[i], scriptAssembly, ref report, options))
				{
					flag = true;
				}
			}
			return !flag;
		}

		public static bool ReplaceScriptsForObject(GameObject gameObject, ScriptType scriptType, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			ModScriptReplacerReport report;
			return ReplaceScriptsForObject(gameObject, scriptType, out report, options);
		}

		public static bool ReplaceScriptsForObject(GameObject gameObject, ScriptType scriptType, out ModScriptReplacerReport report, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			bool flag = false;
			report = new ModScriptReplacerReport();
			bool includeInactive = (options & ScriptReplacerOptions.ReplaceDisabledScripts) != 0;
			MonoBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<MonoBehaviour>(includeInactive);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!ReplaceScriptBehaviourImpl(componentsInChildren[i], scriptType, ref report, options))
				{
					flag = true;
				}
			}
			return !flag;
		}

		public static bool ReplaceScriptBehaviour(MonoBehaviour behaviour, ScriptAssembly scriptAssembly, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			ModScriptReplacerReport report;
			return ReplaceScriptBehaviour(behaviour, scriptAssembly, out report, options);
		}

		public static bool ReplaceScriptBehaviour(MonoBehaviour behaviour, ScriptAssembly scriptAssembly, out ModScriptReplacerReport report, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			report = new ModScriptReplacerReport();
			return ReplaceScriptBehaviourImpl(behaviour, scriptAssembly, ref report, options);
		}

		public static bool ReplaceScriptBehaviour(MonoBehaviour behaviour, ScriptType scriptType, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			ModScriptReplacerReport report;
			return ReplaceScriptBehaviour(behaviour, scriptType, out report, options);
		}

		public static bool ReplaceScriptBehaviour(MonoBehaviour behaviour, ScriptType scriptType, out ModScriptReplacerReport report, ScriptReplacerOptions options = ScriptReplacerOptions.Default)
		{
			report = new ModScriptReplacerReport();
			return ReplaceScriptBehaviourImpl(behaviour, scriptType, ref report, options);
		}

		private static bool ReplaceScriptBehaviourImpl(MonoBehaviour behaviour, ScriptAssembly scriptAssembly, ref ModScriptReplacerReport report, ScriptReplacerOptions options)
		{
			if (behaviour == null)
			{
				report.AddErrorFormat("Target replaceable behaviour '{0}' has been destroyed and will be skipped", behaviour);
			}
			Type type = behaviour.GetType();
			ScriptReplacementInfo replaceInfo = new ScriptReplacementInfo
			{
				replaceName = type.Name
			};
			if ((options & ScriptReplacerOptions.DontRequireAttribute) == 0)
			{
				if (!type.IsDefined(typeof(ModReplaceableBehaviourAttribute), inherit: false))
				{
					return true;
				}
				ModReplaceableBehaviourAttribute modReplaceableBehaviourAttribute = type.GetCustomAttributes(typeof(ModReplaceableBehaviourAttribute), inherit: false)[0] as ModReplaceableBehaviourAttribute;
				replaceInfo.replaceName = (string.IsNullOrEmpty(modReplaceableBehaviourAttribute.ReplaceScriptName) ? type.Name : modReplaceableBehaviourAttribute.ReplaceScriptName);
				replaceInfo.requireBaseType = modReplaceableBehaviourAttribute.RequireBaseType;
				replaceInfo.requireInterfaceTypes = modReplaceableBehaviourAttribute.RequireInterfaceTypes;
			}
			bool flag = false;
			foreach (ScriptType item in scriptAssembly.EnumerateAllMonoBehaviourTypes())
			{
				if (!CheckReplacementScriptMatch(type, behaviour, in replaceInfo, item, ref report))
				{
					flag = true;
				}
				else
				{
					ReplaceScriptBehaviourInstance(type, behaviour, item, ref report, options);
				}
			}
			return !flag;
		}

		private static bool ReplaceScriptBehaviourImpl(MonoBehaviour behaviour, ScriptType scriptType, ref ModScriptReplacerReport report, ScriptReplacerOptions options)
		{
			if (behaviour == null)
			{
				report.AddErrorFormat("Target replaceable behaviour '{0}' has been destroyed and will be skipped", behaviour);
				return false;
			}
			Type type = behaviour.GetType();
			ScriptReplacementInfo replaceInfo = new ScriptReplacementInfo
			{
				replaceName = type.Name
			};
			if ((options & ScriptReplacerOptions.DontRequireAttribute) == 0)
			{
				if (!type.IsDefined(typeof(ModReplaceableBehaviourAttribute), inherit: false))
				{
					return true;
				}
				ModReplaceableBehaviourAttribute modReplaceableBehaviourAttribute = type.GetCustomAttributes(typeof(ModReplaceableBehaviourAttribute), inherit: false)[0] as ModReplaceableBehaviourAttribute;
				replaceInfo.replaceName = (string.IsNullOrEmpty(modReplaceableBehaviourAttribute.ReplaceScriptName) ? type.Name : modReplaceableBehaviourAttribute.ReplaceScriptName);
				replaceInfo.requireBaseType = modReplaceableBehaviourAttribute.RequireBaseType;
				replaceInfo.requireInterfaceTypes = modReplaceableBehaviourAttribute.RequireInterfaceTypes;
			}
			if (!CheckReplacementScriptMatch(type, behaviour, in replaceInfo, scriptType, ref report))
			{
				return false;
			}
			ReplaceScriptBehaviourInstance(type, behaviour, scriptType, ref report, options);
			return true;
		}

		private static bool CheckReplacementScriptMatch(Type behaviourType, MonoBehaviour behaviour, in ScriptReplacementInfo replaceInfo, ScriptType scriptType, ref ModScriptReplacerReport report)
		{
			if (scriptType.Name == replaceInfo.replaceName)
			{
				if (replaceInfo.requireBaseType != null && scriptType.SystemType.BaseType != replaceInfo.requireBaseType)
				{
					report.AddErrorFormat("Script type '{0}' cannot be used as a replacement script because it does not derive from required base type '{1}'", scriptType, replaceInfo.requireBaseType);
					return false;
				}
				if (replaceInfo.requireInterfaceTypes != null && replaceInfo.requireInterfaceTypes.Length != 0)
				{
					bool flag = true;
					Type[] interfaces = scriptType.SystemType.GetInterfaces();
					Type[] requireInterfaceTypes = replaceInfo.requireInterfaceTypes;
					foreach (Type interfaceType in requireInterfaceTypes)
					{
						if (!Array.Exists(interfaces, (Type type) => type == interfaceType))
						{
							report.AddErrorFormat("Script type '{0}' cannot be used as a replacement script beacuse it does not implement the required interface type '{1}'", scriptType, interfaceType);
							flag = false;
						}
					}
					if (!flag)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		private static void ReplaceScriptBehaviourInstance(Type behaviourType, MonoBehaviour behaviour, ScriptType scriptType, ref ModScriptReplacerReport report, ScriptReplacerOptions options)
		{
			ScriptProxy scriptProxy = scriptType.CreateInstance(behaviour.gameObject);
			if (scriptProxy != null)
			{
				report.AddMessageFormat("Created script instance of type '{0}' to replace existing script '{1}'", scriptType, behaviour);
			}
			CopySerializedFields(behaviourType, behaviour, scriptProxy, ref report, options);
			try
			{
				if (behaviour is IModScriptReplacedReceiver)
				{
					((IModScriptReplacedReceiver)behaviour).OnWillReplaceScript(scriptProxy.MonoBehaviourInstance);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			if ((options & ScriptReplacerOptions.DestroyOriginalScript) != 0)
			{
				UnityEngine.Object.Destroy(behaviour);
			}
			else if ((options & ScriptReplacerOptions.DisableOriginalScript) != 0)
			{
				behaviour.enabled = false;
			}
		}

		private static void CopySerializedFields(Type behaviourType, object behaviourInstance, ScriptProxy proxy, ref ModScriptReplacerReport report, ScriptReplacerOptions options)
		{
			FieldInfo[] fields = behaviourType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			foreach (FieldInfo fieldInfo in fields)
			{
				if ((fieldInfo.IsPublic || fieldInfo.IsDefined(typeof(SerializeField), inherit: false) || (options & ScriptReplacerOptions.CopyNonSerializeFields) != 0) && (!fieldInfo.IsDefined(typeof(NonSerializedAttribute), inherit: false) || (options & ScriptReplacerOptions.CopyNonSerializeFields) != 0))
				{
					try
					{
						proxy.Fields[fieldInfo.Name] = fieldInfo.GetValue(behaviourInstance);
						report.AddMessageFormat("\tCopied field '{0}' from replacement source, with value '{1}' of type '{2}'", fieldInfo.Name, fieldInfo.GetValue(behaviourInstance), fieldInfo.FieldType);
					}
					catch (TargetException)
					{
						report.AddWarningFormat("\tThe script type '{0}' does not define a serialized field named '{1}' of type '{2}'", proxy.ScriptType, fieldInfo.Name, fieldInfo.FieldType);
					}
					catch (ArgumentException)
					{
						report.AddWarningFormat("\tThe script type '{0}' defines a serialized field named '{1}', but the field type is not compatible with the corresponding behaviour field. Expected field type '{2}'", proxy.ScriptType, fieldInfo.Name, fieldInfo.FieldType);
					}
				}
			}
		}
	}
}
