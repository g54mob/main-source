using System;
using System.Collections.Generic;

namespace VampireSurvivors.Data;

public static class NetworkItems
{
	private static HashSet<ItemType> _networkItems;

	public static bool IsNetworkItem(ItemType type)
	{
		//IL_002a: Expected I4, but got O
		if (_networkItems != null)
		{
			return _networkItems.Contains(type);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	static NetworkItems()
	{
		HashSet<ItemType> hashSet = (HashSet<ItemType>)(object)new HashSet<System.Int32Enum>();
		bool flag = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)8);
		bool flag2 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)48);
		bool flag3 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)27);
		bool flag4 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)19);
		bool flag5 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)29);
		bool flag6 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)40);
		bool flag7 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)17);
		bool flag8 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)12);
		bool flag9 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)60);
		bool flag10 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)65);
		bool flag11 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)13);
		bool flag12 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)11);
		bool flag13 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)25);
		bool flag14 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)61);
		bool flag15 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)9);
		bool flag16 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)30);
		bool flag17 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)10);
		bool flag18 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)45);
		bool flag19 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)77);
		bool flag20 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)76);
		bool flag21 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)21);
		bool flag22 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)46);
		bool flag23 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)47);
		bool flag24 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)202);
		bool flag25 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)201);
		bool flag26 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)200);
		bool flag27 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)70);
		bool flag28 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)204);
		bool flag29 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)229);
		bool flag30 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)208);
		bool flag31 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)207);
		bool flag32 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)206);
		bool flag33 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)205);
		bool flag34 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)209);
		bool flag35 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)80);
		bool flag36 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)107);
		bool flag37 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)101);
		_networkItems = hashSet;
	}
}
