using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Algorithm;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects;

public class Accessory : Equipment
{
	private ModifierStats _modifierStats;

	private WeaponData _003CCurrentAccessoryData_003Ek__BackingField;

	public WeaponData CurrentAccessoryData
	{
		get
		{
			return _003CCurrentAccessoryData_003Ek__BackingField;
		}
		private set
		{
			_003CCurrentAccessoryData_003Ek__BackingField = value;
		}
	}

	public unsafe void Init(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType accessoryType)
	{
		//IL_0022: Expected O, but got Ref
		base.FakeConstruct();
		base._003COwner_003Ek__BackingField = characterController;
		base._equipmentType = accessoryType;
		GameObject gameObject = base.gameObject;
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		((UnityEngine.Object)gameObject).SetName(text);
		MakeLevelOne();
	}

	public virtual void OnAccessoryAddedToEquipment()
	{
	}

	public virtual void OnAccessoryRemovedFromEquipment()
	{
	}

	public void Apply()
	{
		//IL_0015: Expected O, but got I
		//IL_004b: Expected O, but got I
		//IL_013c: Expected O, but got I4
		//IL_01d7: Expected O, but got I
		//IL_0237: Expected O, but got I
		PlayerOptions core = (PlayerOptions)(object)GM.Core;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v4 (VampireSurvivors.Objects.PlayerOptions)+90]");
			core = (PlayerOptions)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v4 (VampireSurvivors.Objects.PlayerOptions)+90]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v4 (VampireSurvivors.Objects.PlayerOptions)+90]");
				PlayerOptionsData config = ((PlayerOptions)0).Config;
				if (config != null)
				{
					if (!config._003CSelectedSharePassives_003Ek__BackingField)
					{
						goto IL_038a;
					}
					VampireSurvivors.Objects.Characters.CharacterController characterController = base._003COwner_003Ek__BackingField;
					if ((object)base._003COwner_003Ek__BackingField != null)
					{
						VampireSurvivors.Objects.Characters.CharacterController characterController3;
						if (characterController._PlayerIndex >> 31 != 0)
						{
							VampireSurvivors.Objects.Characters.CharacterController characterController2 = base._003COwner_003Ek__BackingField;
							bool flag = characterController2._deficiencyControl == null;
							bool flag2 = false;
							if (!flag)
							{
								CharacterADControl deficiencyControl = characterController2._deficiencyControl;
								object obj = deficiencyControl._003CLevelupType_003Ek__BackingField - 3;
								bool flag3 = obj == null;
								flag2 = flag3;
							}
							int num = characterController2._PlayerIndex >> 31;
							if (((flag2 ? 1u : 0u) & (uint)num) == 0)
							{
								goto IL_038a;
							}
							characterController3 = characterController2;
						}
						else
						{
							characterController3 = base._003COwner_003Ek__BackingField;
						}
						if (characterController3._PlayerIndex >> 31 != 0)
						{
							VampireSurvivors.Objects.Characters.CharacterController characterController4 = base._003COwner_003Ek__BackingField;
							if (!characterController4.IsFollowerSharingPassives)
							{
								goto IL_038a;
							}
						}
						core = (PlayerOptions)(object)GM.Core;
						if ((object)GM.Core != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v4 (VampireSurvivors.Objects.PlayerOptions)+3B8]");
							core = (PlayerOptions)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v4 (VampireSurvivors.Objects.PlayerOptions)+3B8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v4 (VampireSurvivors.Objects.PlayerOptions)+AC]");
								bool flag4 = (nint)0 == 0;
								if (flag4)
								{
									goto IL_038a;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v4 (VampireSurvivors.Objects.PlayerOptions)+AC]");
								core = (PlayerOptions)(-1);
								if (!flag4)
								{
									if ((nint)core != 1)
									{
										return;
									}
									core = (PlayerOptions)(object)GM.Core;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v4 (VampireSurvivors.Objects.PlayerOptions)+2A0]");
									if ((nint)0 != 0)
									{
										List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
										while (enumerator.MoveNext())
										{
											ApplyToCharacter(null);
										}
										return;
									}
								}
								else
								{
									WeaponData weaponData = _003CCurrentAccessoryData_003Ek__BackingField;
									if (_003CCurrentAccessoryData_003Ek__BackingField != null)
									{
										if (weaponData._003CappliesOnlyToOwner_003Ek__BackingField)
										{
											goto IL_038a;
										}
										GameManager core2 = GM.Core;
										if ((object)GM.Core != null && core2._mainCharacters != null)
										{
											List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator2 = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
											while (enumerator2.MoveNext())
											{
												ApplyToCharacter(null);
											}
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
		throw new NullReferenceException();
		IL_038a:
		ApplyToCharacter(base._003COwner_003Ek__BackingField);
	}

	private void ApplyToCharacter(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		if ((object)character != null && ((UnityEngine.Object)character).m_CachedPtr != (IntPtr)0)
		{
			character.PlayerStatsUpgrade(_modifierStats, multiplicativeMaxHp: true);
		}
	}

	public override bool LevelUp(bool skipFire = false)
	{
		//IL_00fe: Expected I4, but got O
		CleanJsonModifierStats();
		if (base.GetDataForLevel(base._equipmentType, base._003CLevel_003Ek__BackingField, out var _, upgradeExistingData: false))
		{
			if (_currentJsonDataObject != null)
			{
				object modifierStats = _currentJsonDataObject.ToObject<object>();
				_modifierStats = (ModifierStats)modifierStats;
				if (_currentJsonDataObject != null)
				{
					object obj = _currentJsonDataObject.ToObject<object>();
					_003CCurrentAccessoryData_003Ek__BackingField = (WeaponData)obj;
					int num = base._003CLevel_003Ek__BackingField + 1;
					base._003CLevel_003Ek__BackingField = num;
					VampireSurvivors.Objects.Characters.CharacterController characterController = base._003COwner_003Ek__BackingField;
					if ((object)base._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
					{
						Apply();
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public override void Cleanup()
	{
	}

	public override void InternalUpdate()
	{
	}

	public override void CheckArcanas()
	{
	}

	protected unsafe override void MakeLevelOne()
	{
		ModifierStats modifierStats = _modifierStats;
		modifierStats._003CPower_003Ek__BackingField = 0f;
		modifierStats._003CSpeed_003Ek__BackingField = 0f;
		modifierStats._003CGrowth_003Ek__BackingField = 0f;
		modifierStats._003CDuration_003Ek__BackingField = 0f;
		modifierStats._003CAmount_003Ek__BackingField = 0f;
		modifierStats._003CArmor_003Ek__BackingField = 0f;
		modifierStats._003CRegen_003Ek__BackingField = 0f;
		modifierStats._003CRevivals_003Ek__BackingField = 0.0;
		modifierStats._003CReRolls_003Ek__BackingField = 0f;
		modifierStats._003CMaxHp_003Ek__BackingField = 0f;
		modifierStats._003CCurse_003Ek__BackingField = 0f;
		modifierStats._003CShroud_003Ek__BackingField = 0f;
		modifierStats._003CDefang_003Ek__BackingField = 0f;
		modifierStats._003CInvulTimeBonus_003Ek__BackingField = 0f;
		modifierStats._003CRecycle_003Ek__BackingField = 0f;
		base._003CLevel_003Ek__BackingField = 0;
		JToken newLevelData;
		if (base.GetDataForLevel(base._equipmentType, 0, out *(JObject*)(&newLevelData), upgradeExistingData: false))
		{
			object modifierStats2 = newLevelData.ToObject<object>();
			_modifierStats = (ModifierStats)modifierStats2;
			object obj = newLevelData.ToObject<object>();
			_003CCurrentAccessoryData_003Ek__BackingField = (WeaponData)obj;
			WeaponData weaponData = _003CCurrentAccessoryData_003Ek__BackingField;
			VampireSurvivors.Objects.Characters.CharacterController characterController = base._003COwner_003Ek__BackingField;
			base._003CLevel_003Ek__BackingField = weaponData._003Clevel_003Ek__BackingField;
			if ((object)base._003COwner_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
			{
				Apply();
			}
			WeaponData weaponData2 = _003CCurrentAccessoryData_003Ek__BackingField;
			if (weaponData2._003CunexcludeSelf_003Ek__BackingField)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA2130");
			}
		}
	}

	protected override Dictionary<WeaponType, JArray> GetDataDictionary()
	{
		DataManager dataManager = _dataManager;
		if (_dataManager != null)
		{
			return dataManager._003CAllWeaponData_003Ek__BackingField;
		}
		return (Dictionary<WeaponType, JArray>)(object)new NullReferenceException();
	}

	private unsafe void CleanJsonModifierStats()
	{
		//IL_0106: Expected O, but got Ref
		//IL_01ee: Expected O, but got I4
		//IL_0199: Expected O, but got I
		//IL_01a2: Expected F4, but got I4
		//IL_02cd: Expected O, but got I
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_01c7: Invalid comparison between F4 and I
		//IL_0231: Expected O, but got I
		//IL_024e: Expected I, but got O
		//IL_026c: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_0299: Expected I, but got O
		ModifierStats modifierStats = _modifierStats;
		modifierStats._003CPower_003Ek__BackingField = 0f;
		modifierStats._003CSpeed_003Ek__BackingField = 0f;
		modifierStats._003CGrowth_003Ek__BackingField = 0f;
		modifierStats._003CDuration_003Ek__BackingField = 0f;
		modifierStats._003CAmount_003Ek__BackingField = 0f;
		modifierStats._003CArmor_003Ek__BackingField = 0f;
		modifierStats._003CRegen_003Ek__BackingField = 0f;
		modifierStats._003CRevivals_003Ek__BackingField = 0.0;
		modifierStats._003CReRolls_003Ek__BackingField = 0f;
		modifierStats._003CMaxHp_003Ek__BackingField = 0f;
		modifierStats._003CCurse_003Ek__BackingField = 0f;
		modifierStats._003CShroud_003Ek__BackingField = 0f;
		modifierStats._003CDefang_003Ek__BackingField = 0f;
		modifierStats._003CInvulTimeBonus_003Ek__BackingField = 0f;
		modifierStats._003CRecycle_003Ek__BackingField = 0f;
		JObject jObject = JObject.FromObject(_modifierStats);
		IEnumerable<object> enumerable = Enumerable.Cast<object>(jObject._properties);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		JObject jObject2 = null;
		object obj3 = default(object);
		object obj9 = default(object);
		object obj10 = default(object);
		while (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj5;
			object obj8;
			if (obj3 != null)
			{
				bool flag = obj2 == null;
				jObject2 = null;
				if (!flag)
				{
					object obj4 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r10_v5+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_01db;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r10_v5+B0]");
					obj5 = 0;
					float num = 0f;
					while (true)
					{
						float num2 = num + num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ r8_v9+v341 @ rax_v35 (System.Single)*8]");
						if (0 == (nint)typeof(IEnumerator<JProperty>))
						{
							break;
						}
						num++;
						float num3 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ r10_v5+12E]");
						if (num3 < 0f)
						{
							continue;
						}
						goto IL_01db;
					}
					float num4 = num + num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ r8_v9+8+v397 @ rcx_v24 (System.Single)*8]");
					object obj6 = (nint)0 << 4;
					object obj7 = obj6 + 312;
					obj8 = obj7 + obj4;
					goto IL_03d9;
				}
				throw new NullReferenceException();
			}
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
			}
			return;
			IL_01db:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj5 = 0;
			obj8 = obj9;
			goto IL_03d9;
			IL_03d9:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v403 @ rdx_v12] (should have been resolved before IL gen)");
			if (obj10 != null)
			{
				if (_currentJsonDataObject != null)
				{
					JObject currentJsonDataObject = _currentJsonDataObject;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v20+60]");
					bool flag2 = currentJsonDataObject.ContainsKey((string)0);
					bool flag3 = !flag2;
					nint num5 = (nint)typeof(IEnumerator<JProperty>);
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v20+58]");
						object obj11 = 0;
						JObject currentJsonDataObject2 = _currentJsonDataObject;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ rax_v20+60]");
						nint num6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rax_v26+10]");
						currentJsonDataObject2.set_Item((string)num6, (JToken)0);
						num5 = unchecked((nint)null);
						jObject2 = _currentJsonDataObject;
					}
					continue;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public Accessory()
	{
		//IL_0048: Expected I, but got O
		ModifierStats modifierStats = new ModifierStats();
		_modifierStats = modifierStats;
		base._003CShowInRecap_003Ek__BackingField = true;
		((GameMonoBehaviour)this)._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rcx_v5 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
