using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Unity.Collections;
using UnityEngine;
using UnityEngine.LowLevel;

namespace Aggro.Core
{
	public static class EntityWorldUtil
	{
		private class CreationEntry
		{
			public List<Transform> transforms = new List<Transform>();

			public Queue<EntityBehaviour> entitiesQueue = new Queue<EntityBehaviour>();

			public List<EntityBehaviour> entitiesList = new List<EntityBehaviour>();
		}

		private class SystemDelegateWrapper
		{
			private readonly EntitySystemBase _system;

			public EntitySystemBase System => _system;

			public SystemDelegateWrapper(EntitySystemBase system)
			{
				_system = system;
			}

			public void Update()
			{
				if (_system != null)
				{
					_system.Update();
				}
			}
		}

		private static Type[] _systemTypes;

		private static MethodInfo[] _behaviourSimMethods;

		private static MethodInfo[] _behaviourSimEarlyMethods;

		private static MethodInfo[] _behaviourSimLateMethods;

		private static MethodInfo[] _behaviourPresMethods;

		private static MethodInfo[] _behaviourPresEarlyMethods;

		private static MethodInfo[] _behaviourPresLateMethods;

		private static Type[] _bufferTypes;

		private static Type[] _externalDataTypes;

		private static List<CreationEntry> _creationStack = new List<CreationEntry>();

		private static int _nextStackIndex;

		public static void CreateSystemsForWorld(EntityWorld world)
		{
			for (int i = 0; i < _systemTypes.Length; i++)
			{
				Type type = _systemTypes[i];
				if (!world.HasSystem(type))
				{
					world.CreateSystem(type);
				}
			}
			Type typeFromHandle = typeof(EntityBehaviourSimulationSystem);
			Type typeFromHandle2 = typeof(SimulationSystemGroup);
			Type typeFromHandle3 = typeof(SimulationSystemGroup);
			for (int j = 0; j < _behaviourSimMethods.Length; j++)
			{
				world.CreateBehaviourSystem(typeFromHandle, _behaviourSimMethods[j], typeFromHandle2, typeFromHandle3);
			}
			typeFromHandle = typeof(EntityBehaviourSimulationEarlySystem);
			typeFromHandle2 = typeof(SimulationEarlySystemGroup);
			typeFromHandle3 = typeof(SimulationEarlySystemGroup);
			for (int k = 0; k < _behaviourSimEarlyMethods.Length; k++)
			{
				world.CreateBehaviourSystem(typeFromHandle, _behaviourSimEarlyMethods[k], typeFromHandle2, typeFromHandle3);
			}
			typeFromHandle = typeof(EntityBehaviourSimulationLateSystem);
			typeFromHandle2 = typeof(SimulationLateSystemGroup);
			typeFromHandle3 = typeof(SimulationLateSystemGroup);
			for (int l = 0; l < _behaviourSimLateMethods.Length; l++)
			{
				world.CreateBehaviourSystem(typeFromHandle, _behaviourSimLateMethods[l], typeFromHandle2, typeFromHandle3);
			}
			Type typeFromHandle4 = typeof(EntityBehaviourPresentationSystem);
			Type typeFromHandle5 = typeof(PresentationSystemGroup);
			Type typeFromHandle6 = typeof(PresentationSystemGroup);
			for (int m = 0; m < _behaviourPresMethods.Length; m++)
			{
				world.CreateBehaviourSystem(typeFromHandle4, _behaviourPresMethods[m], typeFromHandle5, typeFromHandle6);
			}
			typeFromHandle4 = typeof(EntityBehaviourPresentationEarlySystem);
			typeFromHandle5 = typeof(PresentationEarlySystemGroup);
			typeFromHandle6 = typeof(PresentationEarlySystemGroup);
			for (int n = 0; n < _behaviourPresEarlyMethods.Length; n++)
			{
				world.CreateBehaviourSystem(typeFromHandle4, _behaviourPresEarlyMethods[n], typeFromHandle5, typeFromHandle6);
			}
			typeFromHandle4 = typeof(EntityBehaviourPresentationLateSystem);
			typeFromHandle5 = typeof(PresentationLateSystemGroup);
			typeFromHandle6 = typeof(PresentationLateSystemGroup);
			for (int num = 0; num < _behaviourPresLateMethods.Length; num++)
			{
				world.CreateBehaviourSystem(typeFromHandle4, _behaviourPresLateMethods[num], typeFromHandle5, typeFromHandle6);
			}
			for (int num2 = 0; num2 < _bufferTypes.Length; num2++)
			{
				world.CreateBuffer(_bufferTypes[num2]);
			}
			for (int num3 = 0; num3 < _externalDataTypes.Length; num3++)
			{
				world.CreateBuffer(_externalDataTypes[num3]);
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void Initialize()
		{
			Type typeFromHandle = typeof(EntitySystemBase);
			List<Type> list = new List<Type>();
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Assembly[] array = assemblies;
			for (int i = 0; i < array.Length; i++)
			{
				Type[] types = array[i].GetTypes();
				foreach (Type type in types)
				{
					if (!type.IsInterface && !type.IsGenericTypeDefinition && !type.IsAbstract && type.GetCustomAttribute<NoAutoCreationAttribute>() == null && typeFromHandle.IsAssignableFrom(type))
					{
						list.Add(type);
					}
				}
			}
			list.Sort((Type x, Type y) => string.Compare(x.AssemblyQualifiedName, y.AssemblyQualifiedName, StringComparison.Ordinal));
			_systemTypes = list.ToArray();
			typeFromHandle = typeof(IEntityBehaviourBase);
			List<Type> list2 = new List<Type>();
			array = assemblies;
			for (int i = 0; i < array.Length; i++)
			{
				Type[] types = array[i].GetTypes();
				foreach (Type type2 in types)
				{
					if (!type2.IsInterface && !type2.IsGenericTypeDefinition && !type2.IsAbstract && type2.GetCustomAttribute<NoAutoCreationAttribute>() == null && typeFromHandle.IsAssignableFrom(type2))
					{
						list2.Add(type2);
					}
				}
			}
			Type[] types2 = list2.ToArray();
			_behaviourSimMethods = GetDefinedMethods(types2, "OnUpdateSimulation");
			_behaviourSimEarlyMethods = GetDefinedMethods(types2, "OnUpdateSimulationEarly");
			_behaviourSimLateMethods = GetDefinedMethods(types2, "OnUpdateSimulationLate");
			_behaviourPresMethods = GetDefinedMethods(types2, "OnUpdatePresentation");
			_behaviourPresEarlyMethods = GetDefinedMethods(types2, "OnUpdatePresentationEarly");
			_behaviourPresLateMethods = GetDefinedMethods(types2, "OnUpdatePresentationLate");
			typeFromHandle = typeof(IBufferItem);
			List<Type> list3 = new List<Type>();
			array = assemblies;
			for (int i = 0; i < array.Length; i++)
			{
				Type[] types = array[i].GetTypes();
				foreach (Type type3 in types)
				{
					if (!type3.IsInterface && !type3.IsGenericTypeDefinition && !type3.IsAbstract && type3.IsValueType && type3.GetCustomAttribute<NoAutoCreationAttribute>() == null && typeFromHandle.IsAssignableFrom(type3))
					{
						list3.Add(type3);
					}
				}
			}
			list3.Sort((Type x, Type y) => string.Compare(x.AssemblyQualifiedName, y.AssemblyQualifiedName, StringComparison.Ordinal));
			_bufferTypes = list3.ToArray();
			typeFromHandle = typeof(IExternalData);
			List<Type> list4 = new List<Type>();
			array = assemblies;
			for (int i = 0; i < array.Length; i++)
			{
				Type[] types = array[i].GetTypes();
				foreach (Type type4 in types)
				{
					if (!type4.IsInterface && !type4.IsGenericTypeDefinition && !type4.IsAbstract && type4.IsClass && type4.GetCustomAttribute<NoAutoCreationAttribute>() == null && typeFromHandle.IsAssignableFrom(type4))
					{
						list4.Add(type4);
					}
				}
			}
			list4.Sort((Type x, Type y) => string.Compare(x.AssemblyQualifiedName, y.AssemblyQualifiedName, StringComparison.Ordinal));
			_externalDataTypes = list4.ToArray();
		}

		public static void AppendSystemToPlayerLoopList(EntitySystemBase system, Type playerLoopSystemType)
		{
			PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();
			if (!AppendSystemToPlayerLoopListHelper(system, ref playerLoop, playerLoopSystemType))
			{
				throw new InvalidOperationException("Could not append system to player loop! System: " + system.GetType().FullName + " Append Target: " + playerLoopSystemType.FullName);
			}
			PlayerLoop.SetPlayerLoop(playerLoop);
		}

		private static bool AppendSystemToPlayerLoopListHelper(EntitySystemBase system, ref PlayerLoopSystem playerLoop, Type playerLoopSystemType)
		{
			SystemDelegateWrapper systemDelegateWrapper = new SystemDelegateWrapper(system);
			if (playerLoop.type == playerLoopSystemType)
			{
				int num = ((playerLoop.subSystemList != null) ? playerLoop.subSystemList.Length : 0);
				PlayerLoopSystem[] array = new PlayerLoopSystem[num + 1];
				for (int i = 0; i < num; i++)
				{
					array[i] = playerLoop.subSystemList[i];
				}
				array[num].type = system.GetType();
				array[num].updateDelegate = systemDelegateWrapper.Update;
				playerLoop.subSystemList = array;
				return true;
			}
			if (playerLoop.subSystemList != null)
			{
				for (int j = 0; j < playerLoop.subSystemList.Length; j++)
				{
					if (AppendSystemToPlayerLoopListHelper(system, ref playerLoop.subSystemList[j], playerLoopSystemType))
					{
						return true;
					}
				}
			}
			return false;
		}

		public static void RemoveSystemFromPlayerLoopList(EntitySystemBase system)
		{
			PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();
			if (!RemoveSystemFromPlayerLoopListHelper(system, ref playerLoop))
			{
				throw new InvalidOperationException("Could not remove system from player loop! System: " + system.GetType().FullName);
			}
			PlayerLoop.SetPlayerLoop(playerLoop);
		}

		private static bool RemoveSystemFromPlayerLoopListHelper(EntitySystemBase system, ref PlayerLoopSystem playerLoop)
		{
			if (playerLoop.subSystemList == null || playerLoop.subSystemList.Length == 0)
			{
				return false;
			}
			for (int i = 0; i < playerLoop.subSystemList.Length; i++)
			{
				if (IsDelegateForSystem(system, playerLoop.subSystemList[i]))
				{
					List<PlayerLoopSystem> list = new List<PlayerLoopSystem>(playerLoop.subSystemList);
					list.RemoveAt(i);
					playerLoop.subSystemList = list.ToArray();
					return true;
				}
				if (RemoveSystemFromPlayerLoopListHelper(system, ref playerLoop.subSystemList[i]))
				{
					return true;
				}
			}
			return false;
		}

		public static void RemoveWorldFromPlayerLoopList(EntityWorld world)
		{
			PlayerLoopSystem playerLoop = PlayerLoop.GetCurrentPlayerLoop();
			RemoveWorldFromPlayerLoopListHelper(world, ref playerLoop);
			PlayerLoop.SetPlayerLoop(playerLoop);
		}

		private static void RemoveWorldFromPlayerLoopListHelper(EntityWorld world, ref PlayerLoopSystem playerLoop)
		{
			if (playerLoop.subSystemList == null || playerLoop.subSystemList.Length == 0)
			{
				return;
			}
			List<PlayerLoopSystem> list = new List<PlayerLoopSystem>(playerLoop.subSystemList.Length);
			for (int i = 0; i < playerLoop.subSystemList.Length; i++)
			{
				RemoveWorldFromPlayerLoopListHelper(world, ref playerLoop.subSystemList[i]);
				if (!IsDelegateForWorld(world, playerLoop.subSystemList[i]))
				{
					list.Add(playerLoop.subSystemList[i]);
				}
			}
			playerLoop.subSystemList = list.ToArray();
		}

		private static bool IsDelegateForSystem(EntitySystemBase system, PlayerLoopSystem pls)
		{
			if (typeof(EntitySystemBase).IsAssignableFrom(pls.type) && pls.updateDelegate.Target is SystemDelegateWrapper systemDelegateWrapper && systemDelegateWrapper.System == system)
			{
				return true;
			}
			return false;
		}

		private static bool IsDelegateForWorld(EntityWorld world, PlayerLoopSystem pls)
		{
			if (typeof(EntitySystemBase).IsAssignableFrom(pls.type) && pls.updateDelegate.Target is SystemDelegateWrapper { System: not null } systemDelegateWrapper && systemDelegateWrapper.System.world == world)
			{
				return true;
			}
			return false;
		}

		public static void GetGroupAndPriority(MemberInfo info, out Type group, out int priority)
		{
			UpdateInGroupAttribute customAttribute = info.GetCustomAttribute<UpdateInGroupAttribute>();
			if (customAttribute != null)
			{
				group = customAttribute.groupType;
				priority = customAttribute.priority;
			}
			else
			{
				group = null;
				priority = 0;
			}
		}

		public static MethodInfo[] GetDefinedMethods(Type[] types, string methodName)
		{
			List<MethodInfo> list = new List<MethodInfo>();
			foreach (Type type in types)
			{
				MethodInfo method = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
				if (method != null && method.DeclaringType == type)
				{
					list.Add(method);
				}
			}
			list.Sort((MethodInfo x, MethodInfo y) => string.Compare(x.DeclaringType.AssemblyQualifiedName, y.DeclaringType.AssemblyQualifiedName, StringComparison.Ordinal));
			return list.ToArray();
		}

		public static void CreateEntities(EntityWorld world, Transform transform, bool runStartRunning, bool checkForPool = true)
		{
			if (_nextStackIndex == _creationStack.Count)
			{
				CreationEntry item = new CreationEntry();
				_creationStack.Add(item);
			}
			CreationEntry creationEntry = _creationStack[_nextStackIndex++];
			creationEntry.transforms.Add(transform);
			CreateEntities(world, creationEntry, runStartRunning, checkForPool);
			_nextStackIndex--;
		}

		public static void CreateEntities(EntityWorld world, List<Transform> rootTransforms, bool runStartRunning, bool checkForPool = true)
		{
			if (_nextStackIndex == _creationStack.Count)
			{
				CreationEntry item = new CreationEntry();
				_creationStack.Add(item);
			}
			CreationEntry creationEntry = _creationStack[_nextStackIndex++];
			int count = rootTransforms.Count;
			for (int i = 0; i < count; i++)
			{
				creationEntry.transforms.Add(rootTransforms[i]);
			}
			CreateEntities(world, creationEntry, runStartRunning, checkForPool);
			_nextStackIndex--;
		}

		private static void CreateEntities(EntityWorld world, CreationEntry entry, bool runStartRunning, bool checkForPool)
		{
			int count = entry.transforms.Count;
			for (int i = 0; i < count; i++)
			{
				GatherEntities(entry.transforms[i], entry.entitiesQueue, checkForPool);
			}
			while (entry.entitiesQueue.Count > 0)
			{
				EntityBehaviour entityBehaviour = entry.entitiesQueue.Dequeue();
				entry.entitiesList.Add(entityBehaviour);
				Transform transform = entityBehaviour.transform;
				int childCount = transform.childCount;
				for (int j = 0; j < childCount; j++)
				{
					GatherEntities(transform.GetChild(j), entry.entitiesQueue, checkForPool);
				}
			}
			int num = entry.entitiesList.Count;
			for (int k = 0; k < num; k++)
			{
				EntityBehaviour entityBehaviour2 = entry.entitiesList[k];
				if (entityBehaviour2 == null)
				{
					UnityEngine.Debug.LogWarning("[ENTITY] Entity now null in CreateEntities, ignoring!");
					entry.entitiesList.RemoveAtSwapBack(k);
					num--;
					k--;
				}
				else if (entityBehaviour2.entity.Exists(allowIsDying: true))
				{
					UnityEngine.Debug.LogWarning("[ENTITY] Entity was created out of turn in CreateEntities, ignoring! (" + entityBehaviour2.name + ")", entityBehaviour2);
					entry.entitiesList.RemoveAtSwapBack(k);
					num--;
					k--;
				}
			}
			for (int l = 0; l < num; l++)
			{
				entry.entitiesList[l].CreateEntity(world);
			}
			for (int m = 0; m < num; m++)
			{
				entry.entitiesList[m].CreateCallInitialize();
			}
			for (int n = 0; n < num; n++)
			{
				entry.entitiesList[n].CreateCallInitializeLate();
			}
			for (int num2 = 0; num2 < num; num2++)
			{
				entry.entitiesList[num2].CreateCallCreate();
			}
			if (runStartRunning)
			{
				for (int num3 = 0; num3 < num; num3++)
				{
					entry.entitiesList[num3].CreateCallStartRunning();
				}
			}
			entry.transforms.Clear();
			entry.entitiesQueue.Clear();
			entry.entitiesList.Clear();
		}

		private static void GatherEntities(Transform transform, Queue<EntityBehaviour> entities, bool checkForPool)
		{
			if (checkForPool && transform.GetComponent<TemplatePool>() != null)
			{
				return;
			}
			if (transform.TryGetComponent<EntityBehaviour>(out var component) && component.isActiveAndEnabled && !component.entity.Exists())
			{
				entities.Enqueue(component);
				return;
			}
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				if (child.gameObject.activeInHierarchy)
				{
					GatherEntities(child, entities, checkForPool);
				}
			}
		}

		[Conditional("UNITY_EDITOR")]
		[Conditional("DEVELOPMENT_BUILD")]
		public static void VerifyRootGroup(Type group, Type rootGroup, Type check)
		{
			Type group2 = group;
			while (group2 != null && group2 != rootGroup)
			{
				GetGroupAndPriority(group2, out group2, out var _);
			}
			if (group2 == null)
			{
				throw new InvalidOperationException($"Method is not in the appropriate System Group! Type: ({check}) Expected Root Group: {rootGroup.FullName}");
			}
		}
	}
}
