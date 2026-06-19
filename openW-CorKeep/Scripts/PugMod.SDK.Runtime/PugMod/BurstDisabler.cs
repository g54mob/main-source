using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Unity.Entities;
using UnityEngine;

namespace PugMod
{
	public static class BurstDisabler
	{
		internal static readonly HashSet<Type> SystemTypesToDisableBurstFor = new HashSet<Type>();

		internal static readonly HashSet<SystemHandle> SystemHandlesToDisableBurstFor = new HashSet<SystemHandle>();

		private static readonly Dictionary<Type, List<MethodInfo>> _patchedMethods = new Dictionary<Type, List<MethodInfo>>();

		private static Harmony _harmony;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Init()
		{
			if (_harmony != null)
			{
				_harmony.UnpatchSelf();
				_harmony = null;
			}
			_patchedMethods.Clear();
			SystemTypesToDisableBurstFor.Clear();
			SystemHandlesToDisableBurstFor.Clear();
		}

		public static void DisableBurstForSystem(string systemTypeName, bool burstEnabled = false)
		{
			Type type = AccessTools.TypeByName(systemTypeName);
			if (type == null)
			{
				Debug.LogError("BurstDisabler: Could not find type " + systemTypeName + ". Cannot register for Burst disabling.");
			}
			else
			{
				DisableBurstForSystem(type, burstEnabled);
			}
		}

		public static void DisableBurstForSystemAndJobs(string systemTypeName, bool burstEnabled = false)
		{
			Type type = AccessTools.TypeByName(systemTypeName);
			if (type == null)
			{
				Debug.LogError("BurstDisabler: Could not find type " + systemTypeName + ". Cannot register for Burst disabling.");
			}
			else
			{
				DisableBurstForSystemAndJobs(type, burstEnabled);
			}
		}

		public static void DisableBurstForSystem<T>(bool burstEnabled = false)
		{
			DisableBurstForSystemInternal(typeof(T), burstEnabled, addCompleteDependencyPatch: false);
		}

		public static void DisableBurstForSystemAndJobs<T>(bool burstEnabled = false)
		{
			DisableBurstForSystemInternal(typeof(T), burstEnabled, addCompleteDependencyPatch: true);
		}

		public static void DisableBurstForSystem(Type systemType, bool burstEnabled = false)
		{
			DisableBurstForSystemInternal(systemType, burstEnabled, addCompleteDependencyPatch: false);
		}

		public static void DisableBurstForSystemAndJobs(Type systemType, bool burstEnabled = false)
		{
			DisableBurstForSystemInternal(systemType, burstEnabled, addCompleteDependencyPatch: true);
		}

		internal static void DisableBurstForSystemInternal(Type systemType, bool burstEnabled, bool addCompleteDependencyPatch)
		{
			if (!TypeManager.IsSystemType(systemType))
			{
				Debug.LogError("BurstDisabler: type " + systemType.Name + " is not a system type.");
				return;
			}
			if (_harmony == null)
			{
				_harmony = new Harmony("Pug.BurstDisabler");
				_harmony.PatchAll(typeof(DisableBurstForSystemPatch));
			}
			if (TypeManager.IsSystemManaged(systemType))
			{
				if (burstEnabled)
				{
					UnpatchSystem(systemType, _harmony);
				}
				else
				{
					PatchManagedSystem(systemType, _harmony, addCompleteDependencyPatch);
				}
				return;
			}
			SystemBaseRegistry.SetBurstEnabledForSystem(systemType, burstEnabled);
			if (burstEnabled)
			{
				UnpatchSystem(systemType, _harmony);
				if (!SystemTypesToDisableBurstFor.Remove(systemType))
				{
					Debug.Log(string.Format("{0}: burst already enabled for {1}", "BurstDisabler", systemType));
				}
			}
			else
			{
				if (!SystemTypesToDisableBurstFor.Add(systemType))
				{
					Debug.LogWarning("BurstDisabler: system " + systemType.Name + " is already registered");
				}
				PatchSystem(systemType, _harmony, addCompleteDependencyPatch);
			}
		}

		public static void ResetWorlds()
		{
			SystemHandlesToDisableBurstFor.Clear();
		}

		public static void AddWorld(World world)
		{
			foreach (Type item in SystemTypesToDisableBurstFor)
			{
				if (world.GetExistingSystemManaged(item) == null)
				{
					SystemTypeIndex systemTypeIndex = TypeManager.GetSystemTypeIndex(item);
					SystemHandle existingSystem = world.GetExistingSystem(systemTypeIndex);
					if (existingSystem != SystemHandle.Null)
					{
						SystemHandlesToDisableBurstFor.Add(existingSystem);
					}
				}
			}
		}

		internal static void PatchSystem(Type systemType, Harmony harmony, bool addCompleteDependencyPatch)
		{
			List<MethodInfo> list = new List<MethodInfo>();
			if (addCompleteDependencyPatch)
			{
				CreateCompleteDependencyPatch(systemType, harmony, list, isManaged: false);
			}
			_patchedMethods[systemType] = list;
		}

		internal static void PatchManagedSystem(Type systemType, Harmony harmony, bool addCompleteDependencyPatch)
		{
			List<MethodInfo> patchedMethods;
			if (harmony != null)
			{
				patchedMethods = new List<MethodInfo>();
				PatchMethod("OnCreate", "OnCreatePrefix", "OnCreatePostfix");
				PatchMethod("OnStartRunning", "OnStartRunningPrefix", "OnStartRunningPostfix");
				PatchMethod("OnUpdate", "OnUpdatePrefix", "OnUpdatePostfix");
				PatchMethod("OnStopRunning", "OnStopRunningPrefix", "OnStopRunningPostfix");
				PatchMethod("OnDestroy", "OnDestroyPrefix", "OnDestroyPostfix");
				if (addCompleteDependencyPatch)
				{
					CreateCompleteDependencyPatch(systemType, harmony, patchedMethods, isManaged: true);
				}
				_patchedMethods[systemType] = patchedMethods;
			}
			void PatchMethod(string methodName, string prefixName, string postfixName)
			{
				MethodInfo method = systemType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				if (method != null)
				{
					MethodInfo method2 = typeof(DisableBurstForManagedSystemPatch).GetMethod(prefixName, BindingFlags.Static | BindingFlags.NonPublic);
					MethodInfo method3 = typeof(DisableBurstForManagedSystemPatch).GetMethod(postfixName, BindingFlags.Static | BindingFlags.NonPublic);
					HarmonyMethod prefix = new HarmonyMethod(method2);
					HarmonyMethod postfix = new HarmonyMethod(method3);
					harmony.Patch(method, prefix, postfix);
					patchedMethods.Add(method);
					Debug.Log("BurstDisabler: Patched " + methodName + " on " + systemType.Name);
				}
				else
				{
					Debug.LogWarning("BurstDisabler: Could not find method " + methodName + " on " + systemType.Name);
				}
			}
		}

		internal static void UnpatchSystem(Type systemType, Harmony harmony)
		{
			if (harmony == null || !_patchedMethods.TryGetValue(systemType, out var value))
			{
				Debug.Log($"no method to unpatch for type {systemType}");
				return;
			}
			foreach (MethodInfo item in value)
			{
				harmony.Unpatch(item, HarmonyPatchType.All, harmony.Id);
			}
			_patchedMethods.Remove(systemType);
			Debug.Log("BurstDisabler: Unpatched all methods for " + systemType.Name);
		}

		private static void CreateCompleteDependencyPatch(Type systemType, Harmony harmony, List<MethodInfo> patchedMethods, bool isManaged)
		{
			if (harmony != null)
			{
				MethodInfo methodInfo = AccessTools.Method(systemType, "OnUpdate", isManaged ? null : new Type[1] { typeof(SystemState).MakeByRefType() });
				if (methodInfo != null)
				{
					HarmonyMethod postfix = new HarmonyMethod(isManaged ? typeof(CompleteDependencyAfterUpdateManagedPatch).GetMethod("Postfix") : typeof(CompleteDependencyAfterUpdatePatch).GetMethod("Postfix"));
					harmony.Patch(methodInfo, null, postfix);
					patchedMethods.Add(methodInfo);
					Debug.Log("BurstDisabler: Patched OnUpdate on " + systemType.Name + " for job burst disabling");
				}
				else
				{
					Debug.LogWarning("BurstDisabler: Could not find method OnUpdate on " + systemType.Name);
				}
			}
		}
	}
}
