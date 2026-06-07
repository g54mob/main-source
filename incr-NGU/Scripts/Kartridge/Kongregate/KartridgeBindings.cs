using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Kongregate
{
	public class KartridgeBindings
	{
		public class Item
		{
			public readonly ulong Id;

			public readonly decimal Price;

			public readonly string Identifier;

			public readonly string Name;

			public readonly string Description;

			internal Item(ItemType item)
			{
				Id = item.Id;
				Price = (decimal)item.Price / 100m;
				Identifier = UTF8Encoder.GetString(item.Identifier).TrimEnd(default(char));
				Name = UTF8Encoder.GetString(item.Name).TrimEnd(default(char));
				Description = UTF8Encoder.GetString(item.Description).TrimEnd(default(char));
			}
		}

		public class ItemInstance
		{
			public readonly uint UserId;

			public readonly ulong Id;

			public readonly string Identifier;

			public readonly bool Consumable;

			internal ItemInstance(ItemInstanceType item)
			{
				UserId = item.UserId;
				Id = item.Id;
				Identifier = UTF8Encoder.GetString(item.Identifier).TrimEnd(default(char));
				Consumable = item.Consumable;
			}
		}

		public delegate void EventDelegate(string eventName, string eventPayload);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void EventDelegate_Internal(IntPtr context, string eventName, string eventPayload);

		public delegate void KongregateEventListener(string eventName, string eventPayload);

		public delegate void ItemInstanceDelegate(bool success, ItemInstance instance);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void ItemInstanceCallback(IntPtr context, uint id, byte success, ref ItemInstanceType instance);

		private static readonly UTF8Encoding UTF8Encoder = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

		private static readonly IntPtr NullPtr = new IntPtr(0);

		private static Dictionary<uint, Delegate> Callbacks = new Dictionary<uint, Delegate>();

		private static EventDelegate eventListener = null;

		[MonoPInvokeCallback(typeof(ItemInstanceCallback))]
		private static void InternalItemInstanceCallback(IntPtr context, uint id, byte success, ref ItemInstanceType instance)
		{
			try
			{
				if (Callbacks.TryGetValue(id, out var value) && value is ItemInstanceDelegate)
				{
					((ItemInstanceDelegate)value)(success != 0, new ItemInstance(instance));
				}
			}
			finally
			{
				Callbacks.Remove(id);
			}
		}

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool KongregateAPI_RestartWithKartridgeIfNeeded(uint gameId);

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool KongregateAPI_Initialize(string settingsJson);

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		public static extern void KongregateAPI_Shutdown();

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		public static extern void KongregateAPI_Update();

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool KongregateAPI_IsReady();

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool KongregateAPI_IsConnected();

		public static void KongregateAPI_SetEventCallback(EventDelegate listener)
		{
			eventListener = listener;
			KongregateAPI_SetEventCallback_Internal(InternalEventCallback, NullPtr);
		}

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "KongregateAPI_SetEventCallback")]
		private static extern void KongregateAPI_SetEventCallback_Internal(EventDelegate_Internal listener, IntPtr context);

		[MonoPInvokeCallback(typeof(EventDelegate_Internal))]
		private static void InternalEventCallback(IntPtr context, string eventName, string eventPayload)
		{
			if (eventListener != null)
			{
				eventListener(eventName, eventPayload);
			}
		}

		[Obsolete("Use KongregateAPI_SetEventCallback instead")]
		public static void KongregateAPI_SetEventListener(KongregateEventListener listener)
		{
			KongregateAPI_SetEventCallback(delegate(string name, string payload)
			{
				listener(name, payload);
			});
		}

		public static string KongregateServices_GetUsername()
		{
			return Marshal.PtrToStringAnsi(KongregateServices_Internal_GetUsername());
		}

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "KongregateServices_GetUsername")]
		private static extern IntPtr KongregateServices_Internal_GetUsername();

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		public static extern uint KongregateServices_GetUserId();

		public static string KongregateServices_GetGameAuthToken()
		{
			return Marshal.PtrToStringAnsi(KongregateServices_GetGameAuthTokenPtr());
		}

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "KongregateServices_GetGameAuthToken")]
		private static extern IntPtr KongregateServices_GetGameAuthTokenPtr();

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		public static extern void KongregateStats_Submit(string statisticName, long value);

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool KongregateLibrary_IsGameOwned(uint gameId);

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool KongregateLibrary_IsGameInstalled(uint gameId);

		public static Item[] KongregateIAP_GetItems()
		{
			uint num = 0u;
			List<Item> list = new List<Item>();
			ItemType item = KongregateIAP_GetItem(num);
			while (item.Id != 0)
			{
				list.Add(new Item(item));
				item = KongregateIAP_GetItem(++num);
			}
			return list.ToArray();
		}

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		private static extern ItemType KongregateIAP_GetItem(uint index);

		public static ItemInstance[] KongregateIAP_GetItemInstances()
		{
			uint num = 0u;
			List<ItemInstance> list = new List<ItemInstance>();
			ItemInstanceType item = KongregateIAP_GetItemInstance(num);
			while (item.Id != 0)
			{
				list.Add(new ItemInstance(item));
				item = KongregateIAP_GetItemInstance(++num);
			}
			return list.ToArray();
		}

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		private static extern ItemInstanceType KongregateIAP_GetItemInstance(uint index);

		public static bool KongregateIAP_ConsumeItemInstance(ulong instanceId, ItemInstanceDelegate callback)
		{
			uint num = KongregateIAP_ConsumeItemInstance_Internal(instanceId, InternalItemInstanceCallback, NullPtr);
			Callbacks.Add(num, (num != 0) ? callback : null);
			return num != 0;
		}

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "KongregateIAP_ConsumeItemInstance")]
		private static extern uint KongregateIAP_ConsumeItemInstance_Internal(ulong id, ItemInstanceCallback callback, IntPtr context);

		public static bool KongregateIAP_PurchaseItem(string identifier, bool consume, ItemInstanceDelegate callback)
		{
			uint num = KongregateIAP_PurchaseItem_Internal(identifier, consume, InternalItemInstanceCallback, NullPtr);
			Callbacks.Add(num, (num != 0) ? callback : null);
			return num != 0;
		}

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "KongregateIAP_PurchaseItem")]
		private static extern uint KongregateIAP_PurchaseItem_Internal(string identifier, [MarshalAs(UnmanagedType.I1)] bool consume, ItemInstanceCallback callback, IntPtr context);

		public static bool KongregateIAP_PurchaseDynamicItem(string orderInfo, ItemInstanceDelegate callback)
		{
			uint num = KongregateIAP_PurchaseDynamicItem_Internal(orderInfo, InternalItemInstanceCallback, NullPtr);
			Callbacks.Add(num, (num != 0) ? callback : null);
			return num != 0;
		}

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl, EntryPoint = "KongregateIAP_PurchaseDynamicItem")]
		private static extern uint KongregateIAP_PurchaseDynamicItem_Internal(string orderInfo, ItemInstanceCallback callback, IntPtr context);

		[DllImport("kartridge-sdk", CallingConvention = CallingConvention.Cdecl)]
		public static extern void KongregateIAP_RequestItemInstances();
	}
}
