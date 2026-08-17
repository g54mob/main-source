using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects;

public abstract class Equipment : GameMonoBehaviour
{
	protected DataManager _dataManager;

	protected JObject _currentJsonDataObject;

	protected SignalBus _signalBus;

	protected LevelUpFactory _levelUpFactory;

	private WeaponType _equipmentType;

	private int _003CLevel_003Ek__BackingField;

	private int _003CLevelsNumber_003Ek__BackingField;

	private VampireSurvivors.Objects.Characters.CharacterController _003COwner_003Ek__BackingField;

	private bool _003CShowInRecap_003Ek__BackingField;

	public int Level
	{
		get
		{
			return _003CLevel_003Ek__BackingField;
		}
		set
		{
			_003CLevel_003Ek__BackingField = value;
		}
	}

	public int LevelsNumber
	{
		get
		{
			return _003CLevelsNumber_003Ek__BackingField;
		}
		set
		{
			_003CLevelsNumber_003Ek__BackingField = value;
		}
	}

	public WeaponType Type
	{
		get
		{
			return _equipmentType;
		}
		protected set
		{
			_equipmentType = value;
		}
	}

	public VampireSurvivors.Objects.Characters.CharacterController Owner
	{
		get
		{
			return _003COwner_003Ek__BackingField;
		}
		set
		{
			_003COwner_003Ek__BackingField = value;
		}
	}

	public bool ShowInRecap
	{
		get
		{
			return _003CShowInRecap_003Ek__BackingField;
		}
		set
		{
			_003CShowInRecap_003Ek__BackingField = value;
		}
	}

	protected virtual void FakeConstruct()
	{
		GameManager core = GM.Core;
		_dataManager = core._dataManager;
		GameManager core2 = GM.Core;
		_signalBus = core2._signalBus;
		GameManager core3 = GM.Core;
		_levelUpFactory = core3._levelUpFactory;
	}

	public virtual bool IsPowerup()
	{
		return true;
	}

	public virtual void Cleanup()
	{
	}

	public abstract bool LevelUp(bool skipFire = false);

	public abstract void CheckArcanas();

	public abstract void InternalUpdate();

	protected abstract Dictionary<WeaponType, JArray> GetDataDictionary();

	protected abstract void MakeLevelOne();

	protected unsafe virtual bool GetDataForLevel(WeaponType type, int level, out JObject newLevelData, bool upgradeExistingData = true)
	{
		//IL_0213: Expected I4, but got O
		//IL_00e3: Expected I, but got O
		//IL_017d: Expected I, but got O
		ref JObject reference = ref *(JObject*)null;
		Dictionary<System.Int32Enum, object> dataDictionary = (Dictionary<System.Int32Enum, object>)(object)GetDataDictionary();
		if (dataDictionary != null)
		{
			int num = dataDictionary.FindEntry((System.Int32Enum)type);
			if (num < 0)
			{
				goto IL_01ff;
			}
			Dictionary<System.Int32Enum, object> dataDictionary2 = (Dictionary<System.Int32Enum, object>)(object)GetDataDictionary();
			if (dataDictionary2 != null)
			{
				object obj = dataDictionary2.get_Item((System.Int32Enum)type);
				if (obj != null)
				{
					int count = ((JContainer)obj).Count;
					if (level < count)
					{
						nint num2 = (nint)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v327 @ r8_v6 (Il2CppClass<System.Object>)+678] (should have been resolved before IL gen)");
						object obj2 = default(object);
						if (obj2 == null)
						{
							goto IL_0205;
						}
						object obj3 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v329 @ rdx_v13+238] (should have been resolved before IL gen)");
						object obj4 = default(object);
						if (obj4 != null)
						{
							object obj5 = obj2;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v330 @ r8_v9+208] (should have been resolved before IL gen)");
							IEnumerable<JToken> value = default(IEnumerable<JToken>);
							object obj6 = Extensions.Value<object>(value);
							if (obj6 != null)
							{
								nint num3 = (nint)obj6;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v335 @ rdx_v17 (Il2CppClass<System.Object>)+238] (should have been resolved before IL gen)");
								object obj7 = default(object);
								if (obj7 != null)
								{
									reference = ref *(JObject*)obj6;
									object obj8 = default(object);
									JObject currentJsonDataObject = ((obj8 == null) ? newLevelData : DataHelper.UpgradeJsonData(_currentJsonDataObject, (JObject)obj6));
									_currentJsonDataObject = currentJsonDataObject;
									return true;
								}
							}
						}
					}
					goto IL_01ff;
				}
			}
		}
		goto IL_0205;
		IL_01ff:
		return false;
		IL_0205:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsMaxLevel()
	{
		//IL_00bd: Expected I4, but got O
		//IL_00ec: Expected I, but got O
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected I4, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected I4, but got Unknown
		Dictionary<System.Int32Enum, object> dataDictionary = (Dictionary<System.Int32Enum, object>)(object)GetDataDictionary();
		if (dataDictionary != null)
		{
			object obj = dataDictionary.get_Item((System.Int32Enum)_equipmentType);
			if (obj != null)
			{
				nint num = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v146 @ rdx_v5 (Il2CppClass<System.Object>)+5E8] (should have been resolved before IL gen)");
				object obj2 = default(object);
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj4 = default(object);
					object obj3 = _003CLevel_003Ek__BackingField - obj4;
					int num2 = _003CLevel_003Ek__BackingField ^ obj4;
					int num3 = _003CLevel_003Ek__BackingField ^ obj3;
					int num4 = num2 & num3;
					bool flag = num4 < 0;
					bool flag2 = (nint)obj3 < 0;
					return flag2 == flag;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool IsEvolution()
	{
		//IL_004d: Expected I4, but got O
		//IL_0014: Expected I4, but got O
		if (_currentJsonDataObject != null)
		{
			bool flag = (byte)(int)_currentJsonDataObject.ToObject<object>() != 0;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal3 @ rax_v3 (System.Boolean)+60]");
				return false;
			}
			return flag;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public int GetLevelsNumber()
	{
		//IL_008d: Expected I4, but got O
		if (_003CLevelsNumber_003Ek__BackingField <= 0)
		{
			Dictionary<System.Int32Enum, object> dataDictionary = (Dictionary<System.Int32Enum, object>)(object)GetDataDictionary();
			if (dataDictionary != null)
			{
				object obj = dataDictionary.get_Item((System.Int32Enum)_equipmentType);
				if (obj != null)
				{
					return _003CLevelsNumber_003Ek__BackingField = ((JContainer)obj).Count;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
		return _003CLevelsNumber_003Ek__BackingField;
	}

	private void EditorPrintDataAsJson()
	{
		object message = _currentJsonDataObject.ToString();
		Debug.Log(message);
	}

	protected Equipment()
	{
		//IL_002b: Expected I, but got O
		_003CShowInRecap_003Ek__BackingField = true;
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
