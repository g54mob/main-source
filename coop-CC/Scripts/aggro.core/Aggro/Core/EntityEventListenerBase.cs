using System;
using System.Collections.Generic;
using System.Reflection;
using Mirror;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Aggro.Core
{
	public abstract class EntityEventListenerBase : EntityBehaviourBase
	{
		public enum EventType
		{
			Local = 0,
			Global = 1
		}

		public EventType eventType;

		public string eventName = "";

		[Tooltip("Includes local player!")]
		public bool ownerOnly;

		public bool serverOnly;

		public bool clientOnly;

		private Type _eventType;

		private int _eventTypeIndex;

		private EventType _registeredEventType;

		private string _lastWarnedString;

		private static Type[] LOCAL_EVENT_TYPES;

		private static Type[] GLOBAL_EVENT_TYPES;

		private bool showLocalNetworkFields => eventType == EventType.Local;

		private bool showNetworkFields => GetComponentInParent<NetworkIdentity>() != null;

		protected sealed override void OnInitializeBehaviour()
		{
			Initialize();
			OnInitializeListener();
		}

		protected virtual void OnInitializeListener()
		{
		}

		private void Initialize()
		{
			if (string.IsNullOrEmpty(eventName))
			{
				_eventType = null;
				return;
			}
			_eventType = Type.GetType(eventName);
			if (_eventType != null)
			{
				_eventTypeIndex = EntityTypeManager.GetIndex(_eventType);
			}
			else if (_lastWarnedString != eventName)
			{
				_lastWarnedString = eventName;
				Debug.LogWarning("Invalid string type for event listener! (" + eventName + ")", this);
			}
		}

		protected sealed override void OnEntityCreated()
		{
			if (_eventType != null)
			{
				Register();
			}
		}

		protected sealed override void OnEntityDestroyed()
		{
			if (_eventType == null)
			{
				Unregister();
			}
		}

		private void Register()
		{
			switch (eventType)
			{
			case EventType.Local:
				base.entity.AddGenericEventListener(OnLocalEvent, _eventTypeIndex);
				break;
			case EventType.Global:
				base.eventManager.AddGlobalGenericListener(OnGlobalEvent, _eventTypeIndex);
				break;
			default:
				throw new InvalidEnumException();
			}
			_registeredEventType = eventType;
		}

		private void Unregister()
		{
			switch (_registeredEventType)
			{
			case EventType.Local:
				base.entity.RemoveGenericEventListener(OnLocalEvent, _eventTypeIndex);
				break;
			case EventType.Global:
				base.eventManager.RemoveGlobalGenericListener(OnGlobalEvent, _eventTypeIndex);
				break;
			default:
				throw new InvalidEnumException();
			}
		}

		private void OnLocalEvent(Entity e)
		{
			if ((!ownerOnly || e.isOwned) && (!serverOnly || NetworkServer.active) && (!clientOnly || (!NetworkServer.active && NetworkClient.active)))
			{
				OnEvent();
			}
		}

		private void OnGlobalEvent()
		{
			if ((!serverOnly || NetworkServer.active) && (!clientOnly || (!NetworkServer.active && NetworkClient.active)))
			{
				OnEvent();
			}
		}

		protected abstract void OnEvent();

		private ValueDropdownList<string> ValueDropDownGetTypes()
		{
			if (LOCAL_EVENT_TYPES == null || GLOBAL_EVENT_TYPES == null)
			{
				Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
				Type typeFromHandle = typeof(IEntityEvent);
				List<Type> list = new List<Type>();
				List<Type> list2 = new List<Type>();
				Assembly[] array = assemblies;
				for (int i = 0; i < array.Length; i++)
				{
					Type[] types = array[i].GetTypes();
					foreach (Type type in types)
					{
						if (!type.IsInterface && !type.IsGenericTypeDefinition && !type.IsAbstract && type.IsValueType && typeFromHandle.IsAssignableFrom(type) && type.GetCustomAttribute<HideInInspector>() == null)
						{
							if (type.GetCustomAttribute<LocalOnlyEventAttribute>() != null)
							{
								list.Add(type);
								continue;
							}
							if (type.GetCustomAttribute<GlobalOnlyEventAttribute>() != null)
							{
								list2.Add(type);
								continue;
							}
							list.Add(type);
							list2.Add(type);
						}
					}
				}
				list.Sort((Type x, Type y) => string.CompareOrdinal(x.FullName, y.FullName));
				list2.Sort((Type x, Type y) => string.CompareOrdinal(x.FullName, y.FullName));
				LOCAL_EVENT_TYPES = list.ToArray();
				GLOBAL_EVENT_TYPES = list2.ToArray();
			}
			ValueDropdownList<string> valueDropdownList = new ValueDropdownList<string>();
			valueDropdownList.Add("None", "");
			Type[] array2 = eventType switch
			{
				EventType.Local => LOCAL_EVENT_TYPES, 
				EventType.Global => GLOBAL_EVENT_TYPES, 
				_ => throw new InvalidEnumException(), 
			};
			foreach (Type type2 in array2)
			{
				valueDropdownList.Add(type2.FullName, type2.AssemblyQualifiedName);
			}
			return valueDropdownList;
		}

		private bool ValidateType(string typeName, ref string errorMessage)
		{
			if (string.IsNullOrEmpty(typeName))
			{
				return true;
			}
			Type type = Type.GetType(typeName);
			if (type == null)
			{
				errorMessage = "Invalid type name! (" + typeName + ")";
				return false;
			}
			if (!type.IsValueType)
			{
				errorMessage = "Type is not a struct! (" + TypeUtil.GetFriendlyName(type) + ")";
				return false;
			}
			if (!typeof(IEntityEvent).IsAssignableFrom(type))
			{
				errorMessage = "Type does not implement IEntityEvent! (" + TypeUtil.GetFriendlyName(type) + ")";
				return false;
			}
			if (type.GetCustomAttribute<HideInInspector>() != null)
			{
				errorMessage = "Type is marked with HideInInspector! (" + TypeUtil.GetFriendlyName(type) + ")";
				return false;
			}
			switch (eventType)
			{
			case EventType.Local:
				if (type.GetCustomAttribute<GlobalOnlyEventAttribute>() != null)
				{
					errorMessage = "Type is marked with GlobalOnlyEvent! (" + TypeUtil.GetFriendlyName(type) + ")";
					return false;
				}
				break;
			case EventType.Global:
				if (type.GetCustomAttribute<LocalOnlyEventAttribute>() != null)
				{
					errorMessage = "Type is marked with LocalOnlyEvent! (" + TypeUtil.GetFriendlyName(type) + ")";
					return false;
				}
				break;
			default:
				throw new InvalidEnumException();
			}
			return true;
		}
	}
}
