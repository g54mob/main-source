using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.App.Framework;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Items;
using Zenject;

namespace VampireSurvivors.Objects.Pickups;

public class PickupManager : IInitializable, IDisposable
{
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public ItemType itemType;

		internal bool _003CIsPickupItemInWorld_003Eb__0(Pickup item)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)item != null)
			{
				object obj = item._003CPickupType_003Ek__BackingField - itemType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public ItemType itemType;

		internal bool _003CGetPickupItemFromWorld_003Eb__0(Pickup pickupItem)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)pickupItem != null)
			{
				object obj = pickupItem._003CPickupType_003Ek__BackingField - itemType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public ItemType relicType;

		internal bool _003CGetRelicItemFromWorld_003Eb__0(PickupRelic relic)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)relic != null)
			{
				object obj = relic._itemType - relicType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public ItemType[] types;

		internal bool _003CGetAllPickupsOfTypes_003Eb__0(Pickup pickupItem)
		{
			//IL_0030: Expected I4, but got O
			if ((object)pickupItem != null)
			{
				return Enumerable.Contains((IEnumerable<System.Int32Enum>)(object)types, (System.Int32Enum)pickupItem._003CPickupType_003Ek__BackingField);
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public WeaponType weaponType;

		internal bool _003CIsWeaponPickupItemInWorld_003Eb__0(PickupWeapon item)
		{
			//IL_007b: Expected I4, but got O
			//IL_0059: Expected O, but got I4
			if ((object)item != null)
			{
				if (((Pickup)item)._003CPickupType_003Ek__BackingField != ItemType.WEAPON)
				{
					return false;
				}
				object obj = item._weaponType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public WeaponType weaponType;

		internal bool _003CGetPickupWeaponFromWorld_003Eb__0(PickupWeapon item)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)item != null)
			{
				object obj = item._weaponType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private static PickupFactory _pickupFactory;

	private static readonly List<Pickup> PickupItems;

	public static List<Pickup> Pickups => PickupItems;

	public static PickupFactory PickupFactory => _pickupFactory;

	private void Construct(PickupFactory pickupFactory)
	{
		_pickupFactory = pickupFactory;
	}

	public void Initialize()
	{
		Cleanup();
		_pickupFactory.GeneratePools();
	}

	public void Dispose()
	{
		Cleanup();
	}

	public unsafe static Pickup CreatePickup(Vector2 pos, ItemType itemType, bool onlineSynchronization = true)
	{
		//IL_0059: Expected O, but got Ref
		//IL_00ba: Expected I, but got O
		ObjectPool pool = GetPool(itemType);
		if ((object)pool != null && ((UnityEngine.Object)pool).m_CachedPtr != (IntPtr)0)
		{
			object obj = default(object);
			Pickup objectComponent = pool.GetObjectComponent<Pickup>((Vector3)(&obj), onlineSynchronization);
			if ((object)objectComponent != null)
			{
				GameObject gameObject = objectComponent.gameObject;
				if ((object)gameObject != null)
				{
					gameObject.SetActive(value: true);
					nint num = (nint)objectComponent;
					objectComponent.SetData(itemType);
					if (PickupItems != null)
					{
						List<Pickup> pickupItems = PickupItems;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v16 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+330]");
						Pickup objectComponent2 = ((ObjectPool)(object)pickupItems).GetObjectComponent<Pickup>((Vector3)objectComponent, false);
						return objectComponent;
					}
				}
			}
			return (Pickup)(object)new NullReferenceException();
		}
		return null;
	}

	public static void ReturnPickup(Pickup pickup)
	{
		GameObject gameObject = pickup.gameObject;
		((BasePoolableSpriteBehaviour)pickup)._ParentPool.Release(gameObject);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA52F0");
		object obj = default(object);
		if (obj != null)
		{
			bool flag = ((List<object>)(object)PickupItems).Remove((object)pickup);
		}
	}

	public static void RemovePickup(Pickup pickup)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA52F0");
		object obj = default(object);
		if (obj != null)
		{
			bool flag = ((List<object>)(object)PickupItems).Remove((object)pickup);
		}
	}

	public static void AddPickup(Pickup pickup)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA3FE0");
	}

	public static void Cleanup()
	{
		_pickupFactory.PurgePools();
		List<Pickup> pickupItems = PickupItems;
		int version = pickupItems._version + 1;
		pickupItems._version = version;
		pickupItems._size = 0;
		if (pickupItems._size > 0)
		{
			Array.Clear(pickupItems._items, 0, pickupItems._size);
		}
	}

	public static bool IsPickupItemInWorld(ItemType itemType)
	{
		//IL_00a2: Expected I4, but got O
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass14_0();
		if (CS_0024_003C_003E8__locals3 != null)
		{
			CS_0024_003C_003E8__locals3.itemType = itemType;
			if (PickupItems == null)
			{
				return false;
			}
			Func<Pickup, bool> predicate = delegate(Pickup item)
			{
				//IL_0053: Expected I4, but got O
				//IL_0031: Expected O, but got I4
				if ((object)item == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				object obj = item._003CPickupType_003Ek__BackingField - CS_0024_003C_003E8__locals3.itemType;
				return obj == null;
			};
			int num = Enumerable.Count(PickupItems, (Func<object, bool>)predicate);
			int num2 = num ^ num;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = num < 0;
			bool flag3 = num == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static Pickup GetPickupItemFromWorld(ItemType itemType)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass15_0();
		if (CS_0024_003C_003E8__locals3 != null)
		{
			CS_0024_003C_003E8__locals3.itemType = itemType;
			if (PickupItems != null)
			{
				List<Pickup> pickupItems = PickupItems;
				if (PickupItems == null)
				{
					goto IL_004d;
				}
				if (pickupItems._size > 0)
				{
					Func<Pickup, bool> predicate = delegate(Pickup pickupItem)
					{
						//IL_0053: Expected I4, but got O
						//IL_0031: Expected O, but got I4
						if ((object)pickupItem == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj = pickupItem._003CPickupType_003Ek__BackingField - CS_0024_003C_003E8__locals3.itemType;
						return obj == null;
					};
					return (Pickup)Enumerable.FirstOrDefault(PickupItems, (Func<object, bool>)predicate);
				}
			}
			return null;
		}
		goto IL_004d;
		IL_004d:
		return (Pickup)(object)new NullReferenceException();
	}

	public static PickupRelic GetRelicItemFromWorld(ItemType relicType)
	{
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass16_0();
		if (CS_0024_003C_003E8__locals3 != null)
		{
			CS_0024_003C_003E8__locals3.relicType = relicType;
			if (PickupItems != null)
			{
				List<Pickup> pickupItems = PickupItems;
				if (PickupItems == null)
				{
					goto IL_005e;
				}
				if (pickupItems._size > 0)
				{
					IEnumerable<PickupRelic> source = Enumerable.OfType<PickupRelic>(PickupItems);
					Func<PickupRelic, bool> predicate = delegate(PickupRelic relic)
					{
						//IL_0053: Expected I4, but got O
						//IL_0031: Expected O, but got I4
						if ((object)relic == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj = relic._itemType - CS_0024_003C_003E8__locals3.relicType;
						return obj == null;
					};
					return (PickupRelic)Enumerable.FirstOrDefault(source, (Func<object, bool>)predicate);
				}
			}
			return null;
		}
		goto IL_005e;
		IL_005e:
		return (PickupRelic)(object)new NullReferenceException();
	}

	public static List<Pickup> GetAllPickupsOfTypes(ItemType[] types)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals2.types = types;
		Func<Pickup, bool> predicate = delegate(Pickup pickupItem)
		{
			//IL_0030: Expected I4, but got O
			if ((object)pickupItem == null)
			{
				NullReferenceException ex2 = new NullReferenceException();
				return (byte)(int)ex2 != 0;
			}
			return Enumerable.Contains((IEnumerable<System.Int32Enum>)(object)CS_0024_003C_003E8__locals2.types, (System.Int32Enum)pickupItem._003CPickupType_003Ek__BackingField);
		};
		IEnumerable<Pickup> enumerable = Enumerable.Where(PickupItems, predicate);
		if (enumerable != null)
		{
			return (List<Pickup>)(object)new List<object>(enumerable);
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public static bool IsWeaponPickupItemInWorld(WeaponType weaponType)
	{
		//IL_00b3: Expected I4, but got O
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass18_0();
		if (CS_0024_003C_003E8__locals3 != null)
		{
			CS_0024_003C_003E8__locals3.weaponType = weaponType;
			if (PickupItems == null)
			{
				return false;
			}
			IEnumerable<PickupWeapon> source = Enumerable.OfType<PickupWeapon>(PickupItems);
			Func<PickupWeapon, bool> predicate = delegate(PickupWeapon item)
			{
				//IL_007b: Expected I4, but got O
				//IL_0059: Expected O, but got I4
				if ((object)item == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				if (((Pickup)item)._003CPickupType_003Ek__BackingField != ItemType.WEAPON)
				{
					return false;
				}
				object obj = item._weaponType - CS_0024_003C_003E8__locals3.weaponType;
				return obj == null;
			};
			int num = Enumerable.Count(source, (Func<object, bool>)predicate);
			int num2 = num ^ num;
			int num3 = num & num2;
			bool flag = num3 < 0;
			bool flag2 = num < 0;
			bool flag3 = num == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			return flag5 & flag4;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static PickupWeapon GetPickupWeaponFromWorld(WeaponType weaponType)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass19_0();
		if (CS_0024_003C_003E8__locals3 != null)
		{
			CS_0024_003C_003E8__locals3.weaponType = weaponType;
			if (PickupItems != null)
			{
				List<Pickup> pickupItems = PickupItems;
				if (PickupItems == null)
				{
					goto IL_005e;
				}
				if (pickupItems._size > 0)
				{
					IEnumerable<PickupWeapon> source = Enumerable.OfType<PickupWeapon>(PickupItems);
					Func<PickupWeapon, bool> predicate = delegate(PickupWeapon item)
					{
						//IL_0053: Expected I4, but got O
						//IL_0031: Expected O, but got I4
						if ((object)item == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						object obj = item._weaponType - CS_0024_003C_003E8__locals3.weaponType;
						return obj == null;
					};
					return (PickupWeapon)Enumerable.FirstOrDefault(source, (Func<object, bool>)predicate);
				}
			}
			return null;
		}
		goto IL_005e;
		IL_005e:
		return (PickupWeapon)(object)new NullReferenceException();
	}

	private void GeneratePools()
	{
		Cleanup();
		_pickupFactory.GeneratePools();
	}

	public static ObjectPool GetPool(ItemType itemType)
	{
		if ((object)_pickupFactory != null)
		{
			return _pickupFactory.GetPool(itemType);
		}
		return (ObjectPool)(object)new NullReferenceException();
	}

	static PickupManager()
	{
		List<Pickup> pickupItems = new List<Pickup>();
		PickupItems = pickupItems;
	}
}
