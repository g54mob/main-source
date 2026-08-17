using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Props;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundLaborratory : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<SuperObject, bool> _003C_003E9__35_0;

		public static Predicate<Equipment> _003C_003E9__36_0;

		public static Predicate<Equipment> _003C_003E9__36_1;

		public static Predicate<Equipment> _003C_003E9__36_2;

		public static Predicate<Equipment> _003C_003E9__36_3;

		public static Predicate<Equipment> _003C_003E9__36_4;

		public static Predicate<Equipment> _003C_003E9__36_5;

		public static Predicate<Pickup> _003C_003E9__37_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe bool _003CCreate_003Eb__35_0(SuperObject o)
		{
			//IL_0144: Expected I4, but got O
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected Ref, but got Unknown
			//IL_00fd: Expected I8, but got I4
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D98]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)o != null)
			{
				string tiledName = o.m_TiledName;
				if (o.m_TiledName != null)
				{
					object obj = "TRAINCOORDS";
					if ((object)o.m_TiledName != "TRAINCOORDS")
					{
						if ("TRAINCOORDS" != null)
						{
							int stringLength = tiledName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
							if ((nint)stringLength == 0)
							{
								ref byte second = ref *(byte*)("TRAINCOORDS" + 20);
								ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
								return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
							}
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnPropTriggered_003Eb__36_0(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 209;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnPropTriggered_003Eb__36_1(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 209;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnPropTriggered_003Eb__36_2(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 158;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnPropTriggered_003Eb__36_3(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 158;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnPropTriggered_003Eb__36_4(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 158;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003COnPropTriggered_003Eb__36_5(Equipment x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - 158;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CManageSpawning_003Eb__37_0(Pickup x)
		{
			//IL_0052: Expected I4, but got O
			//IL_0030: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._003CPickupType_003Ek__BackingField - 13;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass37_0
	{
		public WeaponType weaponType;

		public Predicate<Equipment> _003C_003E9__1;

		public Predicate<Equipment> _003C_003E9__2;

		public Predicate<Equipment> _003C_003E9__3;

		public Predicate<Equipment> _003C_003E9__4;

		public Predicate<Equipment> _003C_003E9__5;

		public Predicate<Equipment> _003C_003E9__6;

		public Predicate<Equipment> _003C_003E9__7;

		public Predicate<Equipment> _003C_003E9__8;

		internal bool _003CManageSpawning_003Eb__1(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CManageSpawning_003Eb__2(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CManageSpawning_003Eb__3(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CManageSpawning_003Eb__4(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CManageSpawning_003Eb__5(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CManageSpawning_003Eb__6(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CManageSpawning_003Eb__7(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal bool _003CManageSpawning_003Eb__8(Equipment x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if ((object)x != null)
			{
				object obj = x._equipmentType - weaponType;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private float2 _TrainCoords;

	private List<Vector2> _leverLocations;

	private List<Vector2> _leverLocations2;

	private List<Vector2> _leverLocations3;

	private List<Vector2> _leverLocations4;

	private List<SuperObject> _doorScriptsA;

	private List<SuperObject> _doorScriptsB;

	private List<Vector2> _doorLocationsA;

	private List<Vector2> _doorLocationsB;

	private List<PropLeverTrain> _AllLevers;

	private List<Destructible> _AllDoors;

	private Timer _checkLeversTimer;

	private TilingTileset _tilingTileset;

	private List<Destructible> _spawnedLevers;

	private TrainHazardWeapon _003CTrainWeapon_003Ek__BackingField;

	private Timer _trainLeversTimer;

	private float _trainLeversFrequency;

	private float _leverChance;

	private Timer _itemLeversTimer;

	private float _lever2Chance;

	private float _lever3Chance;

	private float _lever4Chance;

	private float _leverMaxSuccessRate;

	private float _leverDefaultSuccessRate;

	private int _centralLeverPulledTimes;

	private VampireSurvivors.Data.Stage.Event Event_YellowReapers;

	private VampireSurvivors.Data.Stage.Event Event_ExplodingAngels;

	private VampireSurvivors.Data.Stage.Event Event_Trinacrias;

	private VampireSurvivors.Data.Stage.Event Event_EyeSwarm;

	private List<EnemyType> MinorEvent_EnemyTypes;

	private List<VampireSurvivors.Data.Stage.Event> SpecialEvent_Types;

	public TrainHazardWeapon TrainWeapon
	{
		get
		{
			return _003CTrainWeapon_003Ek__BackingField;
		}
		set
		{
			_003CTrainWeapon_003Ek__BackingField = value;
		}
	}

	public override void Awake()
	{
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_0169: Expected O, but got I
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_027a: Expected O, but got I
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Expected O, but got Unknown
		//IL_038b: Expected O, but got I
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Expected O, but got Unknown
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Expected O, but got Unknown
		//IL_049c: Expected O, but got I
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected O, but got Unknown
		//IL_053e: Expected O, but got I
		//IL_0598: Expected O, but got I
		//IL_0781: Expected O, but got I
		//IL_0602: Expected O, but got I
		//IL_07a9: Expected O, but got I
		//IL_066c: Expected O, but got I
		//IL_07d1: Expected O, but got I
		//IL_06d7: Expected O, but got I
		//IL_070b: Expected I4, but got O
		//IL_071a: Expected I4, but got O
		//IL_072e: Expected I4, but got O
		base.Awake();
		List<Vector2> leverLocations = new List<Vector2>();
		_leverLocations = leverLocations;
		List<Vector2> leverLocations2 = new List<Vector2>();
		_leverLocations2 = leverLocations2;
		List<Vector2> leverLocations3 = new List<Vector2>();
		_leverLocations3 = leverLocations3;
		List<Vector2> leverLocations4 = new List<Vector2>();
		_leverLocations4 = leverLocations4;
		List<Destructible> spawnedLevers = new List<Destructible>();
		_spawnedLevers = spawnedLevers;
		List<SuperObject> doorScriptsA = new List<SuperObject>();
		_doorScriptsA = doorScriptsA;
		List<SuperObject> doorScriptsB = new List<SuperObject>();
		_doorScriptsB = doorScriptsB;
		VampireSurvivors.Data.Stage.Event event_YellowReapers = new VampireSurvivors.Data.Stage.Event();
		Event_YellowReapers = event_YellowReapers;
		object obj2 = default(object);
		Enum obj = (Enum)(obj2 - 32);
		VampireSurvivors.Data.Stage.Event event_YellowReapers2 = Event_YellowReapers;
		_ = typeof(StageEventType);
		_ = -1;
		_ = 16;
		string text = obj.ToString();
		event_YellowReapers2._003CeventType_003Ek__BackingField = text;
		VampireSurvivors.Data.Stage.Event event_YellowReapers3 = Event_YellowReapers;
		_ = 0;
		_ = 1189765120;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+20]");
		event_YellowReapers3._003Cduration_003Ek__BackingField = (float?)(object)0;
		VampireSurvivors.Data.Stage.Event event_YellowReapers4 = Event_YellowReapers;
		event_YellowReapers4._003CmoreX_003Ek__BackingField = 50;
		Enum obj3 = (Enum)(obj2 - 32);
		VampireSurvivors.Data.Stage.Event event_YellowReapers5 = Event_YellowReapers;
		_ = typeof(EnemyType);
		_ = -1;
		_ = 823;
		string text2 = obj3.ToString();
		event_YellowReapers5._003CmoreY_003Ek__BackingField = text2;
		VampireSurvivors.Data.Stage.Event event_ExplodingAngels = new VampireSurvivors.Data.Stage.Event();
		Event_ExplodingAngels = event_ExplodingAngels;
		Enum obj4 = (Enum)(obj2 - 32);
		VampireSurvivors.Data.Stage.Event event_ExplodingAngels2 = Event_ExplodingAngels;
		_ = typeof(StageEventType);
		_ = -1;
		_ = 16;
		string text3 = obj4.ToString();
		event_ExplodingAngels2._003CeventType_003Ek__BackingField = text3;
		VampireSurvivors.Data.Stage.Event event_ExplodingAngels3 = Event_ExplodingAngels;
		_ = 0;
		_ = 1189765120;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+20]");
		event_ExplodingAngels3._003Cduration_003Ek__BackingField = (float?)(object)0;
		VampireSurvivors.Data.Stage.Event event_ExplodingAngels4 = Event_ExplodingAngels;
		event_ExplodingAngels4._003CmoreX_003Ek__BackingField = 12;
		Enum obj5 = (Enum)(obj2 - 32);
		VampireSurvivors.Data.Stage.Event event_ExplodingAngels5 = Event_ExplodingAngels;
		_ = typeof(EnemyType);
		_ = -1;
		_ = 824;
		string text4 = obj5.ToString();
		event_ExplodingAngels5._003CmoreY_003Ek__BackingField = text4;
		VampireSurvivors.Data.Stage.Event event_Trinacrias = new VampireSurvivors.Data.Stage.Event();
		Event_Trinacrias = event_Trinacrias;
		Enum obj6 = (Enum)(obj2 - 32);
		VampireSurvivors.Data.Stage.Event event_Trinacrias2 = Event_Trinacrias;
		_ = typeof(StageEventType);
		_ = -1;
		_ = 16;
		string text5 = obj6.ToString();
		event_Trinacrias2._003CeventType_003Ek__BackingField = text5;
		VampireSurvivors.Data.Stage.Event event_Trinacrias3 = Event_Trinacrias;
		_ = 0;
		_ = 1189765120;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+20]");
		event_Trinacrias3._003Cduration_003Ek__BackingField = (float?)(object)0;
		VampireSurvivors.Data.Stage.Event event_Trinacrias4 = Event_Trinacrias;
		event_Trinacrias4._003CmoreX_003Ek__BackingField = 12;
		Enum obj7 = (Enum)(obj2 - 32);
		VampireSurvivors.Data.Stage.Event event_Trinacrias5 = Event_Trinacrias;
		_ = typeof(EnemyType);
		_ = -1;
		_ = 825;
		string text6 = obj7.ToString();
		event_Trinacrias5._003CmoreY_003Ek__BackingField = text6;
		VampireSurvivors.Data.Stage.Event event_EyeSwarm = new VampireSurvivors.Data.Stage.Event();
		Event_EyeSwarm = event_EyeSwarm;
		Enum obj8 = (Enum)(obj2 - 32);
		VampireSurvivors.Data.Stage.Event event_EyeSwarm2 = Event_EyeSwarm;
		_ = typeof(StageEventType);
		_ = -1;
		_ = 16;
		string text7 = obj8.ToString();
		event_EyeSwarm2._003CeventType_003Ek__BackingField = text7;
		VampireSurvivors.Data.Stage.Event event_EyeSwarm3 = Event_EyeSwarm;
		_ = 0;
		_ = 1189765120;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ rsp+20]");
		event_EyeSwarm3._003Cduration_003Ek__BackingField = (float?)(object)0;
		VampireSurvivors.Data.Stage.Event event_EyeSwarm4 = Event_EyeSwarm;
		event_EyeSwarm4._003CmoreX_003Ek__BackingField = 7;
		Enum obj9 = (Enum)(obj2 - 32);
		VampireSurvivors.Data.Stage.Event event_EyeSwarm5 = Event_EyeSwarm;
		_ = typeof(EnemyType);
		_ = -1;
		_ = 826;
		string text8 = obj9.ToString();
		event_EyeSwarm5._003CmoreY_003Ek__BackingField = text8;
		List<EnemyType> list = new List<EnemyType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rdx_v39+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)827);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj11 = (nint)0 + (nint)1;
			_ = 827;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ rdx_v41+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)828);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj13 = (nint)0 + (nint)1;
			_ = 828;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v710 @ rdx_v43+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)829);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj15 = (nint)0 + (nint)1;
			_ = 829;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+10]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ rdx_v45+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)821);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1760 @ rax_v68 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
			object obj17 = (nint)0 + (nint)1;
			_ = 821;
		}
		MinorEvent_EnemyTypes = list;
		List<VampireSurvivors.Data.Stage.Event> list2 = new List<VampireSurvivors.Data.Stage.Event>();
		((List<EnemyType>)(object)list2).Add((EnemyType)Event_YellowReapers);
		((List<EnemyType>)(object)list2).Add((EnemyType)Event_ExplodingAngels);
		((List<EnemyType>)(object)list2).Add((EnemyType)Event_Trinacrias);
		SpecialEvent_Types = list2;
		_centralLeverPulledTimes = 0;
	}

	public unsafe override void Create()
	{
		//IL_06d4: Expected I, but got O
		//IL_06fe: Expected I, but got O
		//IL_070e: Expected O, but got I
		//IL_0746: Expected O, but got I
		//IL_08cc->IL0859: Incompatible stack heights: 1 vs 0
		//IL_077c->IL08cc: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Stage stage = core._stage;
			if ((object)core._stage != null)
			{
				_tilingTileset = stage._tilingTileset;
				TilingTileset tilingTileset = _tilingTileset;
				if ((object)_tilingTileset != null)
				{
					Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__35_0;
					if (_003C_003Ec._003C_003E9__35_0 == null)
					{
						predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__35_0 = delegate(SuperObject o)
						{
							//IL_0144: Expected I4, but got O
							//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
							//IL_00e6: Expected Ref, but got Unknown
							//IL_00fd: Expected I8, but got I4
							//IL_010b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0110: Expected Ref, but got Unknown
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3D98]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							if ((object)o != null)
							{
								string tiledName = o.m_TiledName;
								if (o.m_TiledName != null)
								{
									object obj5 = "TRAINCOORDS";
									if ((object)o.m_TiledName != "TRAINCOORDS")
									{
										if ("TRAINCOORDS" != null)
										{
											int stringLength = tiledName._stringLength;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rdx_v1+10]");
											if ((nint)stringLength == 0)
											{
												ref byte second = ref *(byte*)("TRAINCOORDS" + 20);
												ulong length = (ulong)(tiledName._stringLength + tiledName._stringLength);
												return System.SpanHelpers.SequenceEqual(ref *(byte*)(o.m_TiledName + 20), ref second, length);
											}
										}
										return false;
									}
									return true;
								}
							}
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						});
					}
					object obj = Enumerable.FirstOrDefault(tilingTileset.SavedScripts, predicate);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v667 @ rax_v20 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							Transform transform = ((Component)obj).transform;
							if ((object)transform == null)
							{
								goto IL_07b4;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v100 (UnityEngine.Transform)+10]");
							bool flag = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rax_v100 (UnityEngine.Transform)+10]");
							float2 ret;
							Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
							_TrainCoords = ret;
						}
					}
					List<Vector2> leverLocations = _leverLocations;
					if (_leverLocations != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rcx_v21 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
						_ = (nint)0 + (nint)1;
						_ = 0;
						if ((object)_tilingTileset != null)
						{
							List<Vector2> specialLocations = _tilingTileset.GetSpecialLocations("Lever");
							_leverLocations = specialLocations;
							List<Vector2> leverLocations2 = _leverLocations2;
							if (_leverLocations2 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rcx_v24 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
								_ = (nint)0 + (nint)1;
								_ = 0;
								if ((object)_tilingTileset != null)
								{
									List<Vector2> specialLocations2 = _tilingTileset.GetSpecialLocations("Lever2");
									_leverLocations2 = specialLocations2;
									List<Vector2> leverLocations3 = _leverLocations3;
									if (_leverLocations3 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rcx_v27 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
										_ = (nint)0 + (nint)1;
										_ = 0;
										if ((object)_tilingTileset != null)
										{
											List<Vector2> specialLocations3 = _tilingTileset.GetSpecialLocations("Lever3");
											_leverLocations3 = specialLocations3;
											List<Vector2> leverLocations4 = _leverLocations4;
											if (_leverLocations4 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rcx_v30 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
												_ = (nint)0 + (nint)1;
												_ = 0;
												if ((object)_tilingTileset != null)
												{
													List<Vector2> specialLocations4 = _tilingTileset.GetSpecialLocations("Lever4");
													_leverLocations4 = specialLocations4;
													List<SuperObject> doorScriptsA = _doorScriptsA;
													if (_doorScriptsA != null)
													{
														int version = doorScriptsA._version + 1;
														doorScriptsA._version = version;
														doorScriptsA._size = 0;
														if (doorScriptsA._size > 0)
														{
															Array.Clear(doorScriptsA._items, 0, doorScriptsA._size);
														}
														if ((object)_tilingTileset != null)
														{
															List<SuperObject> scriptsFromName = _tilingTileset.GetScriptsFromName("DoorA");
															_doorScriptsA = scriptsFromName;
															List<SuperObject> doorScriptsB = _doorScriptsB;
															if (_doorScriptsB != null)
															{
																int version2 = doorScriptsB._version + 1;
																doorScriptsB._version = version2;
																doorScriptsB._size = 0;
																if (doorScriptsB._size > 0)
																{
																	Array.Clear(doorScriptsB._items, 0, doorScriptsB._size);
																}
																if ((object)_tilingTileset != null)
																{
																	List<SuperObject> scriptsFromName2 = _tilingTileset.GetScriptsFromName("DoorB");
																	_doorScriptsB = scriptsFromName2;
																	List<Vector2> doorLocationsA = _doorLocationsA;
																	if (_doorLocationsA != null)
																	{
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rcx_v41 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
																		_ = (nint)0 + (nint)1;
																		_ = 0;
																		if ((object)_tilingTileset != null)
																		{
																			List<Vector2> specialLocations5 = _tilingTileset.GetSpecialLocations("DoorA");
																			_doorLocationsA = specialLocations5;
																			List<Vector2> doorLocationsB = _doorLocationsB;
																			if (_doorLocationsB != null)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rcx_v44 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+1C]");
																				_ = (nint)0 + (nint)1;
																				_ = 0;
																				if ((object)_tilingTileset != null)
																				{
																					List<Vector2> specialLocations6 = _tilingTileset.GetSpecialLocations("DoorB");
																					_doorLocationsB = specialLocations6;
																					base.Create();
																					GameManager core2 = GM.Core;
																					if ((object)GM.Core != null)
																					{
																						Stage stage2 = core2._stage;
																						if ((object)core2._stage != null)
																						{
																							_tilingTileset = stage2._tilingTileset;
																							GameManager core3 = GM.Core;
																							if ((object)GM.Core != null)
																							{
																								GameSessionData gameSessionData = core3._gameSessionData;
																								if (core3._gameSessionData != null && core3._weaponsFacade != null)
																								{
																									bool allowDuplicates = default(bool);
																									Weapon weapon = core3._weaponsFacade.AddHiddenWeapon(WeaponType.TRAINHAZARD, gameSessionData._activeCharacter, removeFromStore: true, allowDuplicates);
																									nint num = (nint)typeof(TrainHazardWeapon);
																									bool flag2 = (object)weapon == null;
																									object obj2 = null;
																									if (!flag2)
																									{
																										nint num2 = (nint)weapon;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rdx_v33 (Il2CppClass<VampireSurvivors.Objects.Weapons.TrainHazardWeapon>)+130]");
																										object obj3 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v762 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+130]");
																										nint num3 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v766 @ rdx_v33 (Il2CppClass<VampireSurvivors.Objects.Weapons.TrainHazardWeapon>)+130]");
																										bool flag3 = num3 < 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v762 @ r9_v12 (Il2CppClass<VampireSurvivors.Objects.Weapons.Weapon>)+C8]");
																										object obj4 = 0;
																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v774 @ rax_v60+FFFFFFF8+v773 @ rax_v59*8]");
																										bool flag4 = 0 != (nint)typeof(TrainHazardWeapon);
																										obj2 = weapon;
																									}
																									_003CTrainWeapon_003Ek__BackingField = (TrainHazardWeapon)obj2;
																									TrainHazardWeapon trainHazardWeapon = _003CTrainWeapon_003Ek__BackingField;
																									if ((object)_003CTrainWeapon_003Ek__BackingField != null)
																									{
																										((Equipment)trainHazardWeapon)._003CShowInRecap_003Ek__BackingField = false;
																										return;
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_07b4;
		IL_07b4:
		throw new NullReferenceException();
	}

	public unsafe override void OnPropTriggered(PropType propType, PizzaCircle pizzaCircle, VampireSurvivors.Objects.Characters.CharacterController player)
	{
		//IL_0a6c: Expected I, but got O
		//IL_0a9d: Expected O, but got I
		//IL_0ac7: Expected O, but got I
		//IL_0d19: Expected I, but got O
		//IL_0d4a: Expected O, but got I
		//IL_0d81: Expected O, but got I
		//IL_0ba1: Expected I, but got O
		//IL_0bd2: Expected O, but got I
		//IL_0dde: Expected I, but got O
		//IL_0e0f: Expected O, but got I
		//IL_0c09: Expected O, but got I
		//IL_0e46: Expected O, but got I
		//IL_0e71: Expected O, but got I
		//IL_0263: Expected O, but got I
		//IL_0c66: Expected I, but got O
		//IL_0c97: Expected O, but got I
		//IL_0282: Expected O, but got I
		//IL_02a5: Expected O, but got I
		//IL_0e9d: Expected I, but got O
		//IL_0cce: Expected O, but got I
		//IL_0cf9: Expected O, but got I
		//IL_033a: Expected O, but got I
		//IL_0359: Expected O, but got I
		//IL_037c: Expected O, but got I
		//IL_03ee: Expected O, but got I4
		//IL_03f7: Expected O, but got I4
		//IL_042c: Expected O, but got I4
		//IL_0434: Expected O, but got Ref
		//IL_0900: Expected O, but got I4
		//IL_093c: Expected O, but got I4
		ref List<ItemType> itemChoice;
		ref List<EnemyType> enemyChoice;
		ref List<WeaponType> weaponChoice;
		List<WeaponType> list10;
		float2 trainCoords;
		List<WeaponType> list7;
		if (propType != PropType.TRAINLEVER)
		{
			if (propType != PropType.LABORATORYLEVER2)
			{
				if (propType != PropType.LABORATORYLEVER3)
				{
					if (propType != PropType.LABORATORYLEVER4)
					{
						return;
					}
					List<WeaponType> list = new List<WeaponType>();
					if (list != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						List<ItemType> list2 = new List<ItemType>();
						if (list2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
							List<ItemType> list3 = default(List<ItemType>);
							itemChoice = ref list3;
							List<EnemyType> list4 = default(List<EnemyType>);
							enemyChoice = ref list4;
							List<WeaponType> list5 = default(List<WeaponType>);
							weaponChoice = ref list5;
							goto IL_1301;
						}
					}
				}
				else
				{
					List<WeaponType> list6 = new List<WeaponType>();
					bool flag = list6 == null;
					list7 = list6;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
						List<ItemType> list8 = new List<ItemType>();
						bool flag2 = list8 == null;
						list7 = (List<WeaponType>)(object)list8;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
							List<EnemyType> list9 = new List<EnemyType>();
							list7 = (List<WeaponType>)(object)GM.Core;
							if ((object)GM.Core != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+90]");
								bool flag3 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+90]");
								list7 = (List<WeaponType>)0;
								if (!flag3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+90]");
									PlayerOptionsData config = ((PlayerOptions)0).Config;
									bool flag4 = config == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+90]");
									list7 = (List<WeaponType>)0;
									if (!flag4)
									{
										list7 = config._003CUnlockedWeapons_003Ek__BackingField;
										if (config._003CUnlockedWeapons_003Ek__BackingField != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
											list7 = (List<WeaponType>)(object)GM.Core;
											if ((object)GM.Core != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+90]");
												bool flag5 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+90]");
												list7 = (List<WeaponType>)0;
												if (!flag5)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+90]");
													PlayerOptionsData config2 = ((PlayerOptions)0).Config;
													bool flag6 = config2 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v902 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+90]");
													list7 = (List<WeaponType>)0;
													if (!flag6 && config2._003CUnlockedWeapons_003Ek__BackingField != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
														bool flag7 = _centralLeverPulledTimes > 2;
														object obj2 = default(object);
														object obj = obj2;
														object obj4 = default(object);
														object obj3 = obj4;
														if (!flag7)
														{
															obj = 0;
															obj3 = 0;
														}
														GameManager core = GM.Core;
														if ((object)GM.Core != null && core._characters != null)
														{
															List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
															if (enumerator.MoveNext())
															{
																object obj5 = 0;
																list7 = (List<WeaponType>)(&enumerator);
																throw new NullReferenceException();
															}
															bool flag8 = obj == null;
															object obj6 = obj;
															object obj7 = obj;
															object obj8 = obj3;
															if (!flag8)
															{
																bool flag9 = obj3 != null;
																obj7 = obj6;
																obj8 = obj3;
																list10 = list6;
																if (flag9)
																{
																	goto IL_094d;
																}
															}
															List<WeaponType> list11 = new List<WeaponType>();
															bool flag10 = obj7 != null;
															List<WeaponType> list12 = list11;
															if (!flag10)
															{
																if (list11 == null)
																{
																	goto IL_0eac;
																}
																Equipment equipment = ((List<Equipment>)(object)list11).Find((Predicate<Equipment>)209);
																list12 = list11;
															}
															bool flag11 = obj8 != null;
															list10 = list11;
															if (!flag11)
															{
																if (list12 == null)
																{
																	goto IL_0eac;
																}
																Equipment equipment2 = ((List<Equipment>)(object)list12).Find((Predicate<Equipment>)158);
																list10 = list11;
															}
															goto IL_094d;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				List<WeaponType> list13 = new List<WeaponType>();
				if (list13 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96950");
					List<ItemType> list14 = new List<ItemType>();
					if (list14 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A972C0");
						List<ItemType> list15 = default(List<ItemType>);
						itemChoice = ref list15;
						List<EnemyType> list16 = default(List<EnemyType>);
						enemyChoice = ref list16;
						List<WeaponType> list17 = default(List<WeaponType>);
						weaponChoice = ref list17;
						goto IL_1301;
					}
				}
			}
		}
		else
		{
			nint num = (nint)typeof(GM);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v33 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
			nint num2 = 0;
			GameManager core2 = GM.Core;
			bool flag12 = (object)GM.Core == null;
			list7 = (List<WeaponType>)num2;
			if (!flag12)
			{
				bool flag13 = core2._playerOptions == null;
				list7 = (List<WeaponType>)num2;
				if (!flag13)
				{
					PlayerOptionsData config3 = core2._playerOptions.Config;
					bool flag14 = config3 == null;
					list7 = (List<WeaponType>)(object)core2._playerOptions;
					if (!flag14)
					{
						if (!config3._003CSelectedInverse_003Ek__BackingField)
						{
							goto IL_0d0b;
						}
						PlayerOptionsData config4 = core2._playerOptions.Config;
						bool flag15 = config4 == null;
						list7 = (List<WeaponType>)(object)core2._playerOptions;
						if (!flag15)
						{
							if (!config4._003CVisuallyInvertStages_003Ek__BackingField)
							{
								goto IL_0d0b;
							}
							nint num3 = (nint)typeof(GM);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1238 @ rax_v47 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
							nint num4 = 0;
							GameManager core3 = GM.Core;
							bool flag16 = (object)GM.Core == null;
							list7 = (List<WeaponType>)num4;
							if (!flag16)
							{
								GameSessionData gameSessionData = core3._gameSessionData;
								bool flag17 = core3._gameSessionData == null;
								list7 = (List<WeaponType>)num4;
								if (!flag17)
								{
									bool flag18 = (object)gameSessionData._activeCharacter == null;
									list7 = (List<WeaponType>)(object)gameSessionData._activeCharacter;
									if (!flag18)
									{
										float2 position = gameSessionData._activeCharacter.position;
										nint num5 = (nint)typeof(GM);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1504 @ rax_v51 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
										nint num6 = 0;
										GameManager core4 = GM.Core;
										bool flag19 = (object)GM.Core == null;
										list7 = (List<WeaponType>)num6;
										if (!flag19)
										{
											Stage stage = core4._stage;
											bool flag20 = (object)core4._stage == null;
											list7 = (List<WeaponType>)num6;
											if (!flag20)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v53 (VampireSurvivors.Objects.Stage)+138]");
												nint num7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rax_v53 (VampireSurvivors.Objects.Stage)+138]");
												object obj9 = num7 + 0;
												trainCoords = (float2)(obj9 + (object)position);
												goto IL_1320;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0eac;
		IL_0d0b:
		nint num8 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1028 @ rax_v39 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num9 = 0;
		GameManager core5 = GM.Core;
		bool flag21 = (object)GM.Core == null;
		list7 = (List<WeaponType>)num9;
		if (!flag21)
		{
			GameSessionData gameSessionData2 = core5._gameSessionData;
			bool flag22 = core5._gameSessionData == null;
			list7 = (List<WeaponType>)num9;
			if (!flag22)
			{
				bool flag23 = (object)gameSessionData2._activeCharacter == null;
				list7 = (List<WeaponType>)(object)gameSessionData2._activeCharacter;
				if (!flag23)
				{
					float2 position2 = gameSessionData2._activeCharacter.position;
					nint num10 = (nint)typeof(GM);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ rax_v43 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
					nint num11 = 0;
					GameManager core6 = GM.Core;
					bool flag24 = (object)GM.Core == null;
					list7 = (List<WeaponType>)num11;
					if (!flag24)
					{
						Stage stage2 = core6._stage;
						bool flag25 = (object)core6._stage == null;
						list7 = (List<WeaponType>)num11;
						if (!flag25)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v45 (VampireSurvivors.Objects.Stage)+138]");
							nint num12 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ rax_v45 (VampireSurvivors.Objects.Stage)+138]");
							object obj10 = num12 + 0;
							trainCoords = (object)position2 - obj10;
							goto IL_1320;
						}
					}
				}
			}
		}
		goto IL_0eac;
		IL_0eac:
		throw new NullReferenceException();
		IL_094d:
		int centralLeverPulledTimes = _centralLeverPulledTimes + 1;
		_centralLeverPulledTimes = centralLeverPulledTimes;
		List<ItemType> list18 = default(List<ItemType>);
		itemChoice = ref list18;
		List<EnemyType> list19 = default(List<EnemyType>);
		enemyChoice = ref list19;
		weaponChoice = ref list10;
		goto IL_1301;
		IL_1301:
		ref PizzaCircle pizzaCircle2 = default(ref PizzaCircle);
		bool specialEvents = default(bool);
		ManageSpawning(ref weaponChoice, ref itemChoice, ref enemyChoice, ref pizzaCircle2, specialEvents);
		return;
		IL_1320:
		_TrainCoords = trainCoords;
		list7 = (List<WeaponType>)(object)_003CTrainWeapon_003Ek__BackingField;
		if ((object)_003CTrainWeapon_003Ek__BackingField != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundLaborratory)+84]");
			_ = 0;
			nint num13 = (nint)list7;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1581 @ rax_v36 (Il2CppClass<System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>>)+4C8] (should have been resolved before IL gen)");
			return;
		}
		goto IL_0eac;
	}

	public unsafe void ManageSpawning(ref List<WeaponType> weaponChoice, ref List<ItemType> itemChoice, ref List<EnemyType> enemyChoice, ref PizzaCircle pizzaCircle, bool specialEvents = false)
	{
		//IL_152f: Expected O, but got F4
		//IL_155f: Invalid comparison between F4 and I4
		//IL_156e: Invalid comparison between F4 and I4
		//IL_1597: Expected O, but got I4
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_188b: Expected O, but got I8
		//IL_1895: Expected O, but got I4
		//IL_18a7: Expected O, but got I4
		//IL_135b: Invalid comparison between F4 and I4
		//IL_1384: Expected O, but got I4
		//IL_09d7: Expected O, but got I4
		//IL_1202: Expected O, but got Ref
		//IL_0192: Expected O, but got I
		//IL_13b5: Expected O, but got I
		//IL_024f: Expected O, but got I
		//IL_125f: Expected O, but got I4
		//IL_09c0: Expected O, but got I4
		//IL_14ea: Expected O, but got I
		//IL_0c64: Expected O, but got I
		//IL_0284: Expected O, but got I
		//IL_100a: Expected O, but got I
		//IL_0341: Expected O, but got I
		//IL_0cb8: Expected O, but got I
		//IL_0bce: Expected O, but got I8
		//IL_0bd8: Expected O, but got I4
		//IL_09a9: Expected O, but got I4
		//IL_105e: Expected O, but got I
		//IL_0a65: Expected F4, but got I4
		//IL_0375: Expected O, but got I
		//IL_0da6: Expected I, but got O
		//IL_0db4: Expected I, but got O
		//IL_0dc4: Expected O, but got I
		//IL_0e44: Expected O, but got I4
		//IL_0e00: Expected O, but got I
		//IL_0b38: Expected O, but got Ref
		//IL_0432: Expected O, but got I
		//IL_0e36: Expected O, but got I4
		//IL_0992: Expected O, but got I4
		//IL_0466: Expected O, but got I
		//IL_0bbb: Expected O, but got I4
		//IL_0523: Expected O, but got I
		//IL_097b: Expected O, but got I4
		//IL_0557: Expected O, but got I
		//IL_0614: Expected O, but got I
		//IL_0f14: Expected O, but got I4
		//IL_0964: Expected O, but got I4
		//IL_0f50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f55: Expected O, but got Unknown
		//IL_0648: Expected O, but got I
		//IL_0705: Expected O, but got I
		//IL_094d: Expected O, but got I4
		//IL_0739: Expected O, but got I
		//IL_07f6: Expected O, but got I
		//IL_0936: Expected O, but got I4
		//IL_082a: Expected O, but got I
		//IL_08e7: Expected O, but got Ref
		//IL_08e7: Expected O, but got I
		//IL_091f: Expected O, but got I4
		//IL_1718->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_1832->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_0c4e->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_09ce->IL15da: Incompatible stack heights: 2 vs 0
		//IL_0ff4->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_0c80->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_1026->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_1745->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_0cd4->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_09b7->IL15da: Incompatible stack heights: 4 vs 0
		//IL_107a->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_111c->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_10ca->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_115c->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_0b94->IL167d: Incompatible stack heights: 1 vs 0
		//IL_09a0->IL15da: Incompatible stack heights: 6 vs 0
		//IL_117e->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_17a0->IL17a5: Incompatible stack heights: 1 vs 0
		//IL_0bc0->IL0f76: Incompatible stack heights: 1 vs 0
		//IL_11b3->IL11b3: Incompatible stack heights: 1 vs 0
		//IL_0e97->IL17a5: Incompatible stack heights: 1 vs 0
		//IL_0989->IL15da: Incompatible stack heights: 8 vs 0
		//IL_0ebe->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_0ee0->IL14f9: Incompatible stack heights: 1 vs 0
		//IL_0f3b->IL17a5: Incompatible stack heights: 1 vs 0
		//IL_0972->IL15da: Incompatible stack heights: 10 vs 0
		//IL_0f5f->IL0f5f: Incompatible stack heights: 1 vs 0
		//IL_095b->IL15da: Incompatible stack heights: 12 vs 0
		//IL_0944->IL15da: Incompatible stack heights: 14 vs 0
		//IL_0911->IL15b4: Incompatible stack heights: 16 vs 0
		//IL_092d->IL15da: Incompatible stack heights: 16 vs 0
		_003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals39 = new _003C_003Ec__DisplayClass37_0();
		float num2;
		if (CS_0024_003C_003E8__locals39 != null)
		{
			CS_0024_003C_003E8__locals39.weaponType = WeaponType.VOID;
			object obj = UnityEngine.Random.value;
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				GameSessionData gameSessionData = core._gameSessionData;
				if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
				{
					float num = gameSessionData._activeCharacter.PLuck();
					num2 = 0f * _leverDefaultSuccessRate;
					if (!(num2 > _leverMaxSuccessRate))
					{
						object obj2 = _leverMaxSuccessRate & -2147483649L;
						if ((nint)obj2 <= 2139095040)
						{
							goto IL_1556;
						}
					}
					num2 = _leverMaxSuccessRate;
					goto IL_1556;
				}
			}
		}
		goto IL_14f9;
		IL_177e:
		ref List<WeaponType> reference;
		bool flag = System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference) == null;
		Pickup pickup;
		ref List<ItemType> reference2 = ref *(List<ItemType>*)pickup;
		float ret;
		float y;
		ref List<EnemyType> reference3 = default(ref List<EnemyType>);
		object obj5;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v775 @ rbx_v32 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+10]");
			bool flag2 = (nint)0 == 0;
			reference2 = ref *(List<ItemType>*)pickup;
			if (!flag2)
			{
				GameManager core2 = GM.Core;
				if ((object)GM.Core == null || core2._gizmoManager == null)
				{
					goto IL_14f9;
				}
				core2._gizmoManager.ShowHighlightAt(ret, y);
				_ = 1;
				object obj3 = CS_0024_003C_003E8__locals39.weaponType + -67;
				bool flag3 = (nint)obj3 > 5;
				reference2 = ref *(List<ItemType>*)pickup;
				reference3 = ref *(List<EnemyType>*)null;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ r15_v27+6F7F284+v1679 @ rax_v95*4]");
					object obj4 = 0 + obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2262 @ rdx_v42 (should have been resolved before IL gen)");
					goto IL_0f5f;
				}
			}
		}
		goto IL_17a5;
		IL_1863:
		StageEventManager stageEventManager;
		VampireSurvivors.Data.Stage.Event stageDataEvent;
		bool fromTrisection;
		bool flag4 = stageEventManager.TriggerEvent(stageDataEvent, fromTrisection);
		return;
		IL_171d:
		float num3;
		object obj6 = default(object);
		y = num3 + (float)obj6;
		if ((object)GM.Core == null)
		{
			goto IL_14f9;
		}
		Vector2 pos = default(Vector2);
		float value = default(float);
		ItemType relicType = default(ItemType);
		bool validatePickups = default(bool);
		pickup = GM.Core.MakeStagePickup(pos, ItemType.WEAPON, CS_0024_003C_003E8__locals39.weaponType, value, relicType, validatePickups);
		if ((object)pickup == null)
		{
			reference3 = ref *(List<EnemyType>*)(int)CS_0024_003C_003E8__locals39.weaponType;
			reference = ref *(List<WeaponType>*)null;
			goto IL_177e;
		}
		nint num4 = (nint)pickup;
		nint num5 = (nint)typeof(PickupWeapon);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3743 @ rdx_v43 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3742 @ r9_v31 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3743 @ rdx_v43 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
		object obj9;
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3742 @ r9_v31 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3846 @ rax_v106+FFFFFFF8+v3744 @ rax_v102*8]");
			if (0 == (nint)typeof(PickupWeapon))
			{
				obj9 = 1;
				goto IL_174f;
			}
		}
		obj9 = 0;
		goto IL_174f;
		IL_174f:
		bool flag5 = obj9 == null;
		reference3 = ref *(List<EnemyType>*)num4;
		reference = ref *(List<WeaponType>*)null;
		if (!flag5)
		{
			reference3 = ref *(List<EnemyType>*)num4;
			reference = ref *(List<WeaponType>*)pickup;
		}
		goto IL_177e;
		IL_113a:
		GameManager core3 = GM.Core;
		float y2;
		object obj10;
		object obj11;
		ref List<ItemType> reference4;
		ref List<EnemyType> reference5;
		if ((object)GM.Core != null && core3._gizmoManager != null)
		{
			core3._gizmoManager.ShowHighlightAt(ret, y2);
			reference4 = ref reference2;
			reference5 = ref *(List<EnemyType>*)null;
			obj10 = obj11;
			goto IL_11b3;
		}
		goto IL_14f9;
		IL_17a5:
		WeaponType weaponType;
		bool flag6 = weaponType == WeaponType.VOID;
		reference4 = ref reference2;
		reference5 = ref reference3;
		obj10 = obj11;
		if (!flag6)
		{
			goto IL_0f76;
		}
		goto IL_11b3;
		IL_1556:
		bool flag7 = num2 < 0f;
		bool flag8 = num2 == 0f;
		bool flag9 = !flag7;
		bool flag10 = !flag8;
		object obj12 = flag10 & flag9;
		object obj21;
		if (obj12 != null)
		{
			WeaponType weaponType2 = Extensions.PickRnd(weaponChoice);
			CS_0024_003C_003E8__locals39.weaponType = weaponType2;
			GameManager core4 = GM.Core;
			if ((object)GM.Core != null && core4._characters != null)
			{
				List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
				while (true)
				{
					if (enumerator.MoveNext())
					{
						ref List<WeaponType> reference6 = ref *(List<WeaponType>*)null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C0]");
						object obj13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C0]");
						bool flag11 = (nint)0 == 0;
						Predicate<Equipment> match = CS_0024_003C_003E8__locals39._003C_003E9__1;
						if (CS_0024_003C_003E8__locals39._003C_003E9__1 == null)
						{
							match = (CS_0024_003C_003E8__locals39._003C_003E9__1 = delegate(Equipment x)
							{
								//IL_0053: Expected I4, but got O
								//IL_0031: Expected O, but got I4
								if ((object)x == null)
								{
									NullReferenceException ex = new NullReferenceException();
									return (byte)(int)ex != 0;
								}
								object obj29 = x._equipmentType - CS_0024_003C_003E8__locals39.weaponType;
								return obj29 == null;
							});
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2615 @ rax_v201+28]");
						bool flag12 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2615 @ rax_v201+28]");
						Equipment equipment = ((List<Equipment>)0).Find(match);
						if (!equipment)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C0]");
							object obj14 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C0]");
							bool flag13 = (nint)0 == 0;
							Predicate<Equipment> match2 = CS_0024_003C_003E8__locals39._003C_003E9__2;
							if (CS_0024_003C_003E8__locals39._003C_003E9__2 == null)
							{
								match2 = (CS_0024_003C_003E8__locals39._003C_003E9__2 = delegate(Equipment x)
								{
									//IL_0053: Expected I4, but got O
									//IL_0031: Expected O, but got I4
									if ((object)x == null)
									{
										NullReferenceException ex = new NullReferenceException();
										return (byte)(int)ex != 0;
									}
									object obj29 = x._equipmentType - CS_0024_003C_003E8__locals39.weaponType;
									return obj29 == null;
								});
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3205 @ rax_v206+30]");
							bool flag14 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3205 @ rax_v206+30]");
							Equipment equipment2 = ((List<Equipment>)0).Find(match2);
							if (!equipment2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C0]");
								object obj15 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C0]");
								bool flag15 = (nint)0 == 0;
								Predicate<Equipment> match3 = CS_0024_003C_003E8__locals39._003C_003E9__3;
								if (CS_0024_003C_003E8__locals39._003C_003E9__3 == null)
								{
									match3 = (CS_0024_003C_003E8__locals39._003C_003E9__3 = delegate(Equipment x)
									{
										//IL_0053: Expected I4, but got O
										//IL_0031: Expected O, but got I4
										if ((object)x == null)
										{
											NullReferenceException ex = new NullReferenceException();
											return (byte)(int)ex != 0;
										}
										object obj29 = x._equipmentType - CS_0024_003C_003E8__locals39.weaponType;
										return obj29 == null;
									});
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2610 @ rax_v211+40]");
								bool flag16 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2610 @ rax_v211+40]");
								Equipment equipment3 = ((List<Equipment>)0).Find(match3);
								if (!equipment3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C0]");
									object obj16 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C0]");
									bool flag17 = (nint)0 == 0;
									Predicate<Equipment> match4 = CS_0024_003C_003E8__locals39._003C_003E9__4;
									if (CS_0024_003C_003E8__locals39._003C_003E9__4 == null)
									{
										match4 = (CS_0024_003C_003E8__locals39._003C_003E9__4 = delegate(Equipment x)
										{
											//IL_0053: Expected I4, but got O
											//IL_0031: Expected O, but got I4
											if ((object)x == null)
											{
												NullReferenceException ex = new NullReferenceException();
												return (byte)(int)ex != 0;
											}
											object obj29 = x._equipmentType - CS_0024_003C_003E8__locals39.weaponType;
											return obj29 == null;
										});
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2162 @ rax_v216+38]");
									bool flag18 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2162 @ rax_v216+38]");
									Equipment equipment4 = ((List<Equipment>)0).Find(match4);
									if (!equipment4)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C8]");
										object obj17 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C8]");
										bool flag19 = (nint)0 == 0;
										Predicate<Equipment> match5 = CS_0024_003C_003E8__locals39._003C_003E9__5;
										if (CS_0024_003C_003E8__locals39._003C_003E9__5 == null)
										{
											match5 = (CS_0024_003C_003E8__locals39._003C_003E9__5 = delegate(Equipment x)
											{
												//IL_0053: Expected I4, but got O
												//IL_0031: Expected O, but got I4
												if ((object)x == null)
												{
													NullReferenceException ex = new NullReferenceException();
													return (byte)(int)ex != 0;
												}
												object obj29 = x._equipmentType - CS_0024_003C_003E8__locals39.weaponType;
												return obj29 == null;
											});
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1762 @ rax_v221+28]");
										bool flag20 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1762 @ rax_v221+28]");
										Equipment equipment5 = ((List<Equipment>)0).Find(match5);
										if (!equipment5)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C8]");
											object obj18 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C8]");
											bool flag21 = (nint)0 == 0;
											Predicate<Equipment> match6 = CS_0024_003C_003E8__locals39._003C_003E9__6;
											if (CS_0024_003C_003E8__locals39._003C_003E9__6 == null)
											{
												match6 = (CS_0024_003C_003E8__locals39._003C_003E9__6 = delegate(Equipment x)
												{
													//IL_0053: Expected I4, but got O
													//IL_0031: Expected O, but got I4
													if ((object)x == null)
													{
														NullReferenceException ex = new NullReferenceException();
														return (byte)(int)ex != 0;
													}
													object obj29 = x._equipmentType - CS_0024_003C_003E8__locals39.weaponType;
													return obj29 == null;
												});
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1509 @ rax_v226+30]");
											bool flag22 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1509 @ rax_v226+30]");
											Equipment equipment6 = ((List<Equipment>)0).Find(match6);
											if (!equipment6)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C8]");
												object obj19 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C8]");
												bool flag23 = (nint)0 == 0;
												Predicate<Equipment> match7 = CS_0024_003C_003E8__locals39._003C_003E9__7;
												if (CS_0024_003C_003E8__locals39._003C_003E9__7 == null)
												{
													match7 = (CS_0024_003C_003E8__locals39._003C_003E9__7 = delegate(Equipment x)
													{
														//IL_0053: Expected I4, but got O
														//IL_0031: Expected O, but got I4
														if ((object)x == null)
														{
															NullReferenceException ex = new NullReferenceException();
															return (byte)(int)ex != 0;
														}
														object obj29 = x._equipmentType - CS_0024_003C_003E8__locals39.weaponType;
														return obj29 == null;
													});
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1306 @ rax_v231+40]");
												bool flag24 = (nint)0 == 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1306 @ rax_v231+40]");
												Equipment equipment7 = ((List<Equipment>)0).Find(match7);
												if (!equipment7)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C8]");
													object obj20 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ rbx_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+C8]");
													bool flag25 = (nint)0 == 0;
													ref List<WeaponType> reference7 = ref *(List<WeaponType>*)CS_0024_003C_003E8__locals39._003C_003E9__8;
													if (CS_0024_003C_003E8__locals39._003C_003E9__8 == null)
													{
														reference7 = ref *(List<WeaponType>*)(CS_0024_003C_003E8__locals39._003C_003E9__8 = delegate(Equipment x)
														{
															//IL_0053: Expected I4, but got O
															//IL_0031: Expected O, but got I4
															if ((object)x == null)
															{
																NullReferenceException ex = new NullReferenceException();
																return (byte)(int)ex != 0;
															}
															object obj29 = x._equipmentType - CS_0024_003C_003E8__locals39.weaponType;
															return obj29 == null;
														});
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1089 @ rax_v236+38]");
													bool flag26 = (nint)0 == 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1089 @ rax_v236+38]");
													Equipment equipment8 = ((List<Equipment>)0).Find((Predicate<Equipment>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference7));
													if ((bool)equipment8)
													{
														obj21 = 0;
														weaponType = WeaponType.MAGIC_MISSILE;
														break;
													}
													continue;
												}
												obj21 = 0;
												weaponType = WeaponType.MAGIC_MISSILE;
												break;
											}
											obj21 = 0;
											weaponType = WeaponType.MAGIC_MISSILE;
											break;
										}
										obj21 = 0;
										weaponType = WeaponType.MAGIC_MISSILE;
										break;
									}
									obj21 = 0;
									weaponType = WeaponType.MAGIC_MISSILE;
									break;
								}
								obj21 = 0;
								weaponType = WeaponType.MAGIC_MISSILE;
								break;
							}
							obj21 = 0;
							weaponType = WeaponType.MAGIC_MISSILE;
							break;
						}
						obj21 = 0;
						weaponType = WeaponType.MAGIC_MISSILE;
						break;
					}
					obj21 = 1;
					weaponType = WeaponType.VOID;
					break;
				}
				GameManager core5 = GM.Core;
				if ((object)GM.Core != null)
				{
					Predicate<object> match8 = (Predicate<object>)_003C_003Ec._003C_003E9__37_0;
					if (_003C_003Ec._003C_003E9__37_0 == null)
					{
						match8 = (Predicate<object>)(_003C_003Ec._003C_003E9__37_0 = delegate(Pickup x)
						{
							//IL_0052: Expected I4, but got O
							//IL_0030: Expected O, but got I4
							if ((object)x == null)
							{
								NullReferenceException ex = new NullReferenceException();
								return (byte)(int)ex != 0;
							}
							object obj29 = x._003CPickupType_003Ek__BackingField - 13;
							return obj29 == null;
						});
					}
					if (core5._stagePickups != null)
					{
						List<object> list = ((List<object>)(object)core5._stagePickups).FindAll(match8);
						if (list != null)
						{
							reference2 = ref *(List<ItemType>*)null;
							reference3 = ref *(List<EnemyType>*)list;
							List<Pickup>.Enumerator enumerator2 = default(List<Pickup>.Enumerator);
							while (enumerator2.MoveNext())
							{
								float num7 = 0f;
								ref List<WeaponType> reference8 = ref *(List<WeaponType>*)null;
								bool flag27 = (UnityEngine.Object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference8) != null;
								reference2 = ref *(List<ItemType>*)null;
								if (!flag27)
								{
									continue;
								}
								bool flag28 = System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference8) == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1838 @ rbx_v49 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+1F0]");
								bool flag29 = (nint)0 != (nint)CS_0024_003C_003E8__locals39.weaponType;
								reference2 = ref *(List<ItemType>*)null;
								if (flag29)
								{
									continue;
								}
								goto IL_0b99;
							}
							obj5 = 6442450944L;
							obj11 = 0;
							goto IL_16a3;
						}
					}
				}
			}
			goto IL_14f9;
		}
		obj5 = 6442450944L;
		obj21 = 0;
		weaponType = WeaponType.VOID;
		obj11 = 1;
		goto IL_16a3;
		IL_11b3:
		if (obj10 == null)
		{
			return;
		}
		object obj22 = default(object);
		if (obj22 == null)
		{
			VampireSurvivors.Data.Stage.Event obj23 = new VampireSurvivors.Data.Stage.Event();
			IntPtr intPtr = default(IntPtr);
			string text = ((Enum)(&intPtr)).ToString();
			if (obj23 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA8A50");
				_ = 1;
				float value2 = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
				object obj24 = 25 - 1;
				object list2 = default(object);
				EnemyType enemyType = Extensions.PickRnd((IList<EnemyType>)list2);
				EnemyType enemyType2 = default(EnemyType);
				object obj25 = enemyType2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181BA4360");
				GameManager core6 = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage = core6._stage;
					if ((object)core6._stage != null)
					{
						stageEventManager = stage._stageEventManager;
						if (stage._stageEventManager != null)
						{
							fromTrisection = false;
							stageDataEvent = obj23;
							goto IL_1863;
						}
					}
				}
			}
		}
		else
		{
			float value3 = UnityEngine.Random.value;
			bool flag30 = 0.0015f < value3;
			float num8 = 0.0015f - value3;
			bool flag31 = num8 == 0f;
			bool flag32 = !flag30;
			bool flag33 = !flag31;
			object obj26 = flag33 & flag32;
			if (obj26 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [specialEvents @ stack_8 (VampireSurvivors.Objects.PizzaCircle&)+150]");
				VampireSurvivors.Data.Stage.Event obj27 = Extensions.PickRnd((IList<VampireSurvivors.Data.Stage.Event>)0);
				GameManager core7 = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage2 = core7._stage;
					if ((object)core7._stage != null)
					{
						stageEventManager = stage2._stageEventManager;
						if (stage2._stageEventManager != null)
						{
							fromTrisection = false;
							stageDataEvent = obj27;
							goto IL_1863;
						}
					}
				}
			}
			else
			{
				GameManager core8 = GM.Core;
				if ((object)GM.Core != null)
				{
					Stage stage3 = core8._stage;
					if ((object)core8._stage != null)
					{
						stageEventManager = stage3._stageEventManager;
						if (stage3._stageEventManager != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [specialEvents @ stack_8 (VampireSurvivors.Objects.PizzaCircle&)+140]");
							stageDataEvent = (VampireSurvivors.Data.Stage.Event)0;
							fromTrisection = false;
							goto IL_1863;
						}
					}
				}
			}
		}
		goto IL_14f9;
		IL_0f5f:
		float num9 = -0.96f;
		float num10 = 0.96f;
		goto IL_17a5;
		IL_1837:
		y2 = (float)obj6 + num9;
		ItemType itemType;
		if (itemType != ItemType.COINBAG1)
		{
			if ((object)GM.Core != null)
			{
				Pickup pickup2 = GM.Core.MakeStagePickup(pos, itemType, WeaponType.VOID, value, relicType, validatePickups);
				reference2 = ref *(List<ItemType>*)(int)itemType;
				goto IL_113a;
			}
		}
		else if ((object)GM.Core != null)
		{
			GM.Core.MakeRedCoinBag(pos);
			goto IL_113a;
		}
		goto IL_14f9;
		IL_0b99:
		num9 = -0.96f;
		reference2 = ref *(List<ItemType>*)null;
		num10 = 0.96f;
		obj11 = 0;
		goto IL_0f76;
		IL_0f76:
		object list3 = default(object);
		itemType = Extensions.PickRnd((IList<ItemType>)list3);
		object obj28 = default(object);
		if (obj28 != null)
		{
			Transform transform = ((Component)obj28).transform;
			if ((object)transform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rax_v136 (UnityEngine.Transform)+10]");
				bool flag34 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rax_v136 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
				ref List<WeaponType> reference9 = ref *(List<WeaponType>*)GM.Core;
				if ((object)GM.Core != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ rbx_v43 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+90]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ rbx_v43 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+90]");
						PlayerOptionsData config = ((PlayerOptions)0).Config;
						if (config != null)
						{
							if (config._003CSelectedInverse_003Ek__BackingField)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v783 @ rbx_v43 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+90]");
								PlayerOptionsData config2 = ((PlayerOptions)0).Config;
								if (config2 == null)
								{
									goto IL_14f9;
								}
								if (config2._003CVisuallyInvertStages_003Ek__BackingField)
								{
									goto IL_1837;
								}
							}
							num9 = num10;
							goto IL_1837;
						}
					}
				}
			}
		}
		goto IL_14f9;
		IL_14f9:
		throw new NullReferenceException();
		IL_16a3:
		if (obj21 == null)
		{
			goto IL_0f5f;
		}
		if (obj28 != null)
		{
			Transform transform2 = ((Component)obj28).transform;
			if ((object)transform2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v790 @ rax_v74 (UnityEngine.Transform)+10]");
				bool flag35 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v790 @ rax_v74 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
				ref List<WeaponType> reference10 = ref *(List<WeaponType>*)GM.Core;
				if ((object)GM.Core != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rbx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+90]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rbx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+90]");
						PlayerOptionsData config3 = ((PlayerOptions)0).Config;
						if (config3 != null)
						{
							if (config3._003CSelectedInverse_003Ek__BackingField)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v782 @ rbx_v30 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>&)+90]");
								PlayerOptionsData config4 = ((PlayerOptions)0).Config;
								if (config4 == null)
								{
									goto IL_14f9;
								}
								if (config4._003CVisuallyInvertStages_003Ek__BackingField)
								{
									num9 = -0.96f;
									num3 = -0.96f;
									num10 = 0.96f;
									goto IL_171d;
								}
							}
							num9 = -0.96f;
							num3 = 0.96f;
							num10 = 0.96f;
							goto IL_171d;
						}
					}
				}
			}
		}
		goto IL_14f9;
	}

	public void ManageGuardians(PickupGuarded pickupGuard, WeaponType wType)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 15 Invalid \"Jump target not found in method: 0x186F7F318\"");
	}

	public unsafe override void OnInitCompleted()
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected Ref, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected Ref, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Ref, but got Unknown
		base.OnInitCompleted();
		if (_trainLeversTimer != null)
		{
			_trainLeversTimer.Cancel();
		}
		Action onComplete = TryToSpawnTrainLevers;
		float duration = _trainLeversFrequency * 0.001f;
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer trainLeversTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
		_trainLeversTimer = trainLeversTimer;
		TryToSpawnDoors();
		GameManager core = GM.Core;
		Destructible destructible = core._stage.SpawnPropInRandomLocation(100f, PropType.LABORATORYLEVER2, ref *(List<Vector2>*)(this + 144));
		GameManager core2 = GM.Core;
		Destructible destructible2 = core2._stage.SpawnPropInRandomLocation(100f, PropType.LABORATORYLEVER3, ref *(List<Vector2>*)(this + 152));
		GameManager core3 = GM.Core;
		Destructible destructible3 = core3._stage.SpawnPropInRandomLocation(100f, PropType.LABORATORYLEVER4, ref *(List<Vector2>*)(this + 160));
	}

	private unsafe void TryToSpawnTrainLevers()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected Ref, but got Unknown
		GameManager core = GM.Core;
		Destructible destructible = core._stage.SpawnPropInRandomLocation(_leverChance, PropType.TRAINLEVER, ref *(List<Vector2>*)(this + 136));
	}

	private unsafe void TryToSpawnLabLevers()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected Ref, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Ref, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Ref, but got Unknown
		//IL_00f8: Expected I, but got O
		//IL_0100: Expected I, but got O
		//IL_0110: Expected O, but got I
		//IL_0190: Expected O, but got I4
		//IL_014c: Expected O, but got I
		//IL_0182: Expected O, but got I4
		//IL_0259: Expected I, but got O
		//IL_0261: Expected I, but got O
		//IL_0271: Expected O, but got I
		//IL_02f1: Expected O, but got I4
		//IL_02ad: Expected O, but got I
		//IL_02e3: Expected O, but got I4
		//IL_03ba: Expected I, but got O
		//IL_03c2: Expected I, but got O
		//IL_03d2: Expected O, but got I
		//IL_0452: Expected O, but got I4
		//IL_040e: Expected O, but got I
		//IL_0444: Expected O, but got I4
		GameManager core = GM.Core;
		Destructible destructible = core._stage.SpawnPropInRandomLocation(_lever2Chance, PropType.LABORATORYLEVER2, ref *(List<Vector2>*)(this + 144));
		GameManager core2 = GM.Core;
		Destructible destructible2 = core2._stage.SpawnPropInRandomLocation(_lever3Chance, PropType.LABORATORYLEVER3, ref *(List<Vector2>*)(this + 152));
		GameManager core3 = GM.Core;
		Destructible destructible3 = core3._stage.SpawnPropInRandomLocation(_lever4Chance, PropType.LABORATORYLEVER4, ref *(List<Vector2>*)(this + 160));
		List<object> allLevers;
		object obj3;
		if ((object)destructible != null && ((UnityEngine.Object)destructible).m_CachedPtr != (IntPtr)0)
		{
			allLevers = (List<object>)(object)_AllLevers;
			nint num = (nint)typeof(PropLeverTrain);
			nint num2 = (nint)destructible;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Props.PropLeverTrain>)+130]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rdx_v14 (Il2CppClass<VampireSurvivors.Objects.Props.PropLeverTrain>)+130]");
			if (num3 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r8_v16 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v499 @ rax_v65+FFFFFFF8+v472 @ rax_v57*8]");
				if (0 == (nint)typeof(PropLeverTrain))
				{
					obj3 = 1;
					goto IL_050e;
				}
			}
			obj3 = 0;
			goto IL_050e;
		}
		goto IL_0542;
		IL_055f:
		List<object> allLevers2;
		object[] items = allLevers2._items;
		object obj4;
		bool flag = obj4 == null;
		Destructible item = null;
		if (!flag)
		{
			item = destructible2;
		}
		int version = allLevers2._version + 1;
		allLevers2._version = version;
		if (allLevers2._size >= items.Length)
		{
			allLevers2.AddWithResize((object)item);
		}
		else
		{
			int size = allLevers2._size + 1;
			allLevers2._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		goto IL_0593;
		IL_04c8:
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 728 Invalid \"Jump target not found in method: 0x186F7FB20\"");
		throw new NullReferenceException();
		IL_05b0:
		List<object> allLevers3;
		object[] items2 = allLevers3._items;
		object obj5;
		bool flag2 = obj5 == null;
		Destructible item2 = null;
		if (!flag2)
		{
			item2 = destructible3;
		}
		int version2 = allLevers3._version + 1;
		allLevers3._version = version2;
		if (allLevers3._size >= items2.Length)
		{
			allLevers3.AddWithResize((object)item2);
		}
		else
		{
			int size2 = allLevers3._size + 1;
			allLevers3._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		goto IL_04c8;
		IL_0593:
		if ((object)destructible3 == null || ((UnityEngine.Object)destructible3).m_CachedPtr == (IntPtr)0)
		{
			goto IL_04c8;
		}
		allLevers3 = (List<object>)(object)_AllLevers;
		nint num4 = (nint)typeof(PropLeverTrain);
		nint num5 = (nint)destructible3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Props.PropLeverTrain>)+130]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rdx_v8 (Il2CppClass<VampireSurvivors.Objects.Props.PropLeverTrain>)+130]");
		if (num6 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ r8_v8 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ rax_v33+FFFFFFF8+v804 @ rax_v25*8]");
			if (0 == (nint)typeof(PropLeverTrain))
			{
				obj5 = 1;
				goto IL_05b0;
			}
		}
		obj5 = 0;
		goto IL_05b0;
		IL_0542:
		if ((object)destructible2 != null && ((UnityEngine.Object)destructible2).m_CachedPtr != (IntPtr)0)
		{
			allLevers2 = (List<object>)(object)_AllLevers;
			nint num7 = (nint)typeof(PropLeverTrain);
			nint num8 = (nint)destructible2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Props.PropLeverTrain>)+130]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+130]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rdx_v11 (Il2CppClass<VampireSurvivors.Objects.Props.PropLeverTrain>)+130]");
			if (num9 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ r8_v12 (Il2CppClass<VampireSurvivors.Objects.Destructible>)+C8]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v692 @ rax_v49+FFFFFFF8+v665 @ rax_v41*8]");
				if (0 == (nint)typeof(PropLeverTrain))
				{
					obj4 = 1;
					goto IL_055f;
				}
			}
			obj4 = 0;
			goto IL_055f;
		}
		goto IL_0593;
		IL_050e:
		object[] items3 = allLevers._items;
		bool flag3 = obj3 == null;
		Destructible item3 = null;
		if (!flag3)
		{
			item3 = destructible;
		}
		int version3 = allLevers._version + 1;
		allLevers._version = version3;
		if (allLevers._size >= items3.Length)
		{
			allLevers.AddWithResize((object)item3);
		}
		else
		{
			int size3 = allLevers._size + 1;
			allLevers._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		goto IL_0542;
	}

	private unsafe void SeparateLevers()
	{
		//IL_0146: Expected O, but got I4
		//IL_014e: Expected O, but got I4
		//IL_009d: Expected O, but got I
		//IL_0661: Unknown result type (might be due to invalid IL or missing references)
		//IL_0666: Expected O, but got Unknown
		//IL_066e: Expected O, but got Ref
		//IL_05f6: Expected O, but got I4
		List<PropLeverTrain> allLevers = _AllLevers;
		bool flag = (nint)_AllLevers < 0;
		int num = allLevers._size - 1;
		BackgroundLaborratory backgroundLaborratory = this;
		int num2 = num;
		if (flag)
		{
			goto IL_0124;
		}
		while (true)
		{
			List<PropLeverTrain> allLevers2 = _AllLevers;
			if (num2 >= allLevers2._size)
			{
				break;
			}
			backgroundLaborratory = (BackgroundLaborratory)(object)allLevers2._items;
			if (num2 < (nint)((MonoBehaviour)backgroundLaborratory).m_CancellationTokenSource)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rcx_v7 (VampireSurvivors.Objects.Stages.BackgroundLaborratory)+20+v167 @ rbx_v6 (System.Int32)*8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v13+D3]");
				if ((nint)0 != 0)
				{
					_AllLevers.RemoveAt(num2);
					backgroundLaborratory = (BackgroundLaborratory)(object)_AllLevers;
				}
				num = num2 - 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rax_v13+D3]");
				bool flag2 = (nint)0 >= (nint)0;
				num2 = num;
				if (flag2)
				{
					continue;
				}
				goto IL_0124;
			}
			goto IL_051b;
		}
		goto IL_05a5;
		IL_0124:
		List<PropLeverTrain> allLevers3 = _AllLevers;
		object obj2 = allLevers3._size - 1;
		ArcadeSprite arcadeSprite = (ArcadeSprite)num;
		List<PropLeverTrain>.Enumerator enumerator = default(List<PropLeverTrain>.Enumerator);
		while (true)
		{
			if ((nint)obj2 < 1)
			{
				return;
			}
			List<PropLeverTrain> allLevers4 = _AllLevers;
			if ((nint)obj2 >= allLevers4._size)
			{
				break;
			}
			PropLeverTrain[] items = allLevers4._items;
			if ((nint)obj2 < items.Length)
			{
				ArcadeSprite arcadeSprite2 = items[obj2];
				while (enumerator.MoveNext())
				{
					ArcadeSprite arcadeSprite3 = null;
					bool flag3 = (object)items[obj2] == null;
					bool flag4 = !flag3;
					object obj3 = !flag4;
					arcadeSprite = null;
					if (obj3 == null)
					{
						ArcadeSprite typeFromHandle;
						if ((object)items[obj2] == null)
						{
							typeFromHandle = (ArcadeSprite)(object)typeof(UnityEngine.Object);
							throw new NullReferenceException();
						}
						bool flag5 = ((UnityEngine.Object)arcadeSprite2).m_CachedPtr == (IntPtr)0;
						typeFromHandle = (ArcadeSprite)(object)typeof(UnityEngine.Object);
						arcadeSprite = null;
						if (!flag5)
						{
							throw new NullReferenceException();
						}
					}
				}
				obj2--;
				backgroundLaborratory = (BackgroundLaborratory)(&enumerator);
				continue;
			}
			goto IL_051b;
		}
		goto IL_05a5;
		IL_05a5:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
		IL_051b:
		throw new IndexOutOfRangeException();
	}

	private unsafe void TryToSpawnDoors()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected Ref, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected Ref, but got Unknown
		GameManager core = GM.Core;
		List<Destructible> collection = core._stage.SpawnPropInAllLocations(PropType.LAB_DOOR_A, ref *(List<Vector2>*)(this + 184));
		GameManager core2 = GM.Core;
		List<Destructible> collection2 = core2._stage.SpawnPropInAllLocations(PropType.LAB_DOOR_B, ref *(List<Vector2>*)(this + 192));
		List<object> allDoors = (List<object>)(object)_AllDoors;
		((List<object>)(object)_AllDoors).InsertRange(allDoors._size, (IEnumerable<object>)collection);
		List<object> allDoors2 = (List<object>)(object)_AllDoors;
		((List<object>)(object)_AllDoors).InsertRange(allDoors2._size, (IEnumerable<object>)collection2);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 132 Invalid \"Jump target not found in method: 0x186F801E0\"");
		throw new NullReferenceException();
	}

	private void SeparateDoors()
	{
		//IL_0098: Expected O, but got I
		//IL_0207: Expected O, but got I
		//IL_0253: Expected I, but got O
		//IL_0263: Expected O, but got I
		//IL_02e3: Expected O, but got I4
		//IL_0238: Expected O, but got I4
		//IL_059e: Expected O, but got I4
		//IL_029f: Expected O, but got I
		//IL_0151: Expected O, but got I4
		//IL_02f8: Expected O, but got I
		//IL_02d5: Expected O, but got I4
		//IL_05da: Expected O, but got I4
		//IL_03fe: Expected O, but got I
		List<Destructible> allDoors = _AllDoors;
		bool flag = (nint)_AllDoors < 0;
		int num = allDoors._size - 1;
		int num2 = num;
		if (flag)
		{
			goto IL_0167;
		}
		while (true)
		{
			List<Destructible> allDoors2 = _AllDoors;
			if (num2 >= allDoors2._size)
			{
				break;
			}
			List<Destructible> items = (List<Destructible>)(object)allDoors2._items;
			bool flag2;
			if (num2 < items._size)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Destructible>)+20+v162 @ rbx_v6 (System.Int32)*8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Destructible>)+20+v162 @ rbx_v6 (System.Int32)*8]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdi_v6+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdi_v6+D3]");
						flag2 = (nint)0 < (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdi_v6+D3]");
						if ((nint)0 == 0)
						{
							goto IL_0138;
						}
					}
				}
				flag2 = (nint)_AllDoors < 0;
				_AllDoors.RemoveAt(num2);
				goto IL_0138;
			}
			goto IL_04d3;
			IL_0138:
			num = num2 - 1;
			object obj2 = !flag2;
			num2 = num;
			if (obj2 != null)
			{
				continue;
			}
			goto IL_0167;
		}
		goto IL_053c;
		IL_0167:
		List<Destructible> allDoors3 = _AllDoors;
		int num3 = allDoors3._size - 1;
		List<Destructible>.Enumerator enumerator = default(List<Destructible>.Enumerator);
		while (true)
		{
			if (num3 < 1)
			{
				return;
			}
			List<Destructible> allDoors4 = _AllDoors;
			if (num3 >= allDoors4._size)
			{
				break;
			}
			List<Destructible> items = (List<Destructible>)(object)allDoors4._items;
			if (num3 >= items._size)
			{
				goto IL_04d3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Destructible>)+20+v140 @ r14_v12 (System.Int32)*8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Destructible>)+20+v140 @ r14_v12 (System.Int32)*8]");
			object obj4;
			if ((nint)0 == 0)
			{
				obj4 = 0;
				goto IL_0603;
			}
			object obj5 = obj3;
			nint num4 = (nint)typeof(PropDoubleDoor);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Props.PropDoubleDoor>)+130]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ r9_v13+130]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v820 @ rdx_v24 (Il2CppClass<VampireSurvivors.Objects.Props.PropDoubleDoor>)+130]");
			object obj8;
			if (num5 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ r9_v13+C8]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v930 @ rax_v76+FFFFFFF8+v821 @ rax_v72*8]");
				if (0 == (nint)typeof(PropDoubleDoor))
				{
					obj8 = 1;
					goto IL_0586;
				}
			}
			obj8 = 0;
			goto IL_0586;
			IL_0603:
			while (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite = null;
				bool flag3 = obj4 == null;
				bool flag4 = !flag3;
				object obj9 = !flag4;
				if (obj9 != null)
				{
					continue;
				}
				Circle typeFromHandle;
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdi_v16+10]");
					bool flag5 = (nint)0 == 0;
					typeFromHandle = (Circle)(object)typeof(UnityEngine.Object);
					if (!flag5)
					{
						if (obj4 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdi_v16+110]");
							object obj10 = 0;
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					continue;
				}
				typeFromHandle = (Circle)(object)typeof(UnityEngine.Object);
				throw new NullReferenceException();
			}
			num3--;
			continue;
			IL_0586:
			bool flag6 = obj8 == null;
			obj4 = 0;
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v640 @ rcx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Destructible>)+20+v140 @ r14_v12 (System.Int32)*8]");
				obj4 = 0;
			}
			goto IL_0603;
		}
		goto IL_053c;
		IL_053c:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
		IL_04d3:
		throw new IndexOutOfRangeException();
	}

	public override void OnPlayerEnteringDifferentTilemap()
	{
		TryToSpawnLabLevers();
		TryToSpawnDoors();
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
	}

	public override void Cleanup()
	{
		base._003CIsBackgroundActive_003Ek__BackingField = false;
		if (_trainLeversTimer != null)
		{
			_trainLeversTimer.Cancel();
		}
		if (_itemLeversTimer != null)
		{
			_itemLeversTimer.Cancel();
		}
	}

	public BackgroundLaborratory()
	{
		//IL_01cc: Expected O, but got I4
		_TrainCoords = (float2)1157693440;
		_ = 1155727360;
		List<Vector2> leverLocations = new List<Vector2>();
		_leverLocations = leverLocations;
		_leverLocations2 = new List<Vector2>();
		_leverLocations3 = new List<Vector2>();
		_leverLocations4 = new List<Vector2>();
		_doorScriptsA = new List<SuperObject>();
		_doorScriptsB = new List<SuperObject>();
		_doorLocationsA = new List<Vector2>();
		_doorLocationsB = new List<Vector2>();
		_AllLevers = new List<PropLeverTrain>();
		_AllDoors = new List<Destructible>();
		_spawnedLevers = new List<Destructible>();
		_trainLeversFrequency = 5000f;
		_leverChance = 60f;
		_lever2Chance = 100f;
		_lever3Chance = 100f;
		_lever4Chance = 100f;
		_leverMaxSuccessRate = 0.95f;
		_leverDefaultSuccessRate = 0.55f;
		MinorEvent_EnemyTypes = new List<EnemyType>();
		SpecialEvent_Types = new List<VampireSurvivors.Data.Stage.Event>();
		base._002Ector();
	}
}
