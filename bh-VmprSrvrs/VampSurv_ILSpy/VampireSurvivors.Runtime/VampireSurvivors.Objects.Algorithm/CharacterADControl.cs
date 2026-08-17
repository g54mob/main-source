using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Algorithm;

public class CharacterADControl
{
	private AIType _currentType;

	private VampireSurvivors.Objects.Characters.CharacterController _controlledPlayer;

	private VampireSurvivors.Objects.Characters.CharacterController _followedCharacter;

	private LevelupType _003CLevelupType_003Ek__BackingField = LevelupType.LevelupPresets;

	private int _levelupLoadoutIndex;

	private List<WeaponType> _loadout;

	private WeaponType _lasLevelledUpWeaponType;

	private float2 _angleDistance;

	private float _congaMaxDistance = 0.5f;

	private float _congaMinDistance = 0.1f;

	private float _congaYOffset;

	private bool _initialPositionReached;

	public bool ShouldOverrideFollowDelay;

	private Queue<Vector2> _followedCharacterHistory;

	private Vector2 _followedCharacterLastPosition;

	private Unity.Mathematics.Random _loadoutShuffler;

	public LevelupType LevelupType
	{
		get
		{
			return _003CLevelupType_003Ek__BackingField;
		}
		set
		{
			_003CLevelupType_003Ek__BackingField = value;
		}
	}

	public VampireSurvivors.Objects.Characters.CharacterController FollowedCharacter
	{
		get
		{
			return _followedCharacter;
		}
		set
		{
			_followedCharacter = value;
		}
	}

	public void SetAIType(AIType type, VampireSurvivors.Objects.Characters.CharacterController controlledPlayer, VampireSurvivors.Objects.Characters.CharacterController followedCharacter = null)
	{
		_currentType = type;
		_controlledPlayer = controlledPlayer;
		_followedCharacter = followedCharacter;
	}

	public void InitLoadoutShuffler(uint seed)
	{
		//IL_005b: Expected O, but got I4
		int num = (int)(seed << 13);
		int num2 = num ^ (int)seed;
		int num3 = num2 >> 17;
		int num4 = num2 ^ num3;
		int num5 = num4 << 5;
		int num6 = num5 ^ num4;
		_loadoutShuffler = (Unity.Mathematics.Random)num6;
	}

	public void SetAIToAngleDistance(float angleDegrees, float distance, bool mirrorInput = false)
	{
		//IL_001e: Expected O, but got I4
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected I4, but got Unknown
		//IL_0040: Expected O, but got F4
		float num = angleDegrees * ((float)Math.PI / 180f);
		object obj = (mirrorInput ? 1 : 0) * 2;
		AIType currentType = (AIType)(obj + 11);
		_currentType = currentType;
		_angleDistance = (float2)num;
	}

	public void SetAIToConga(float maxDistance, float minDistance, float yOffset = 0f)
	{
		_congaMaxDistance = maxDistance;
		_congaMinDistance = minDistance;
		_congaYOffset = yOffset;
		_currentType = AIType.Conga;
	}

	public Vector2 CalculateMovement()
	{
		//IL_0041: Expected O, but got I8
		//IL_005b: Expected O, but got I8
		AIType currentType = _currentType;
		if (_currentType <= AIType.Conga)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ r10_v1+737D7E0+v48 @ rax_v4 (VampireSurvivors.Objects.Algorithm.AIType)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v67 @ rax_v10 (should have been resolved before IL gen)");
		}
		Vector2 result = default(Vector2);
		return result;
	}

	private Vector2 GetDelayedInputCopyVector()
	{
		if (_followedCharacterHistory == null)
		{
			Queue<Vector2> followedCharacterHistory = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADB00");
			_followedCharacterHistory = followedCharacterHistory;
		}
		VampireSurvivors.Objects.Characters.CharacterController followedCharacter = _followedCharacter;
		if ((object)_followedCharacter != null && _followedCharacterHistory != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADC20");
			Queue<Vector2> followedCharacterHistory2 = _followedCharacterHistory;
			if (_followedCharacterHistory != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v7 (System.Collections.Generic.Queue`1<UnityEngine.Vector2>)+20]");
				Vector2 result = default(Vector2);
				if ((nint)0 <= (nint)60)
				{
					return result;
				}
				if (_followedCharacterHistory != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AADCE0");
					Vector2 result2 = default(Vector2);
					return result2;
				}
			}
		}
		return (Vector2)new NullReferenceException();
	}

	public void Update()
	{
		if (_currentType == AIType.AngleDistanceMirrorInput && _initialPositionReached)
		{
			VampireSurvivors.Objects.Characters.CharacterController controlledPlayer = _controlledPlayer;
			if (!controlledPlayer._isDead && !controlledPlayer.IsDisconnectedFromOnlinePlay)
			{
				VampireSurvivors.Objects.Characters.CharacterController followedCharacter = _followedCharacter;
				VampireSurvivors.Objects.Characters.CharacterController controlledPlayer2 = _controlledPlayer;
				BaseBody body = followedCharacter.body;
				BaseBody body2 = controlledPlayer2.body;
				body2._velocity = body._velocity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v6 (BaseBody)+74]");
				_ = 0;
				VampireSurvivors.Objects.Characters.CharacterController controlledPlayer3 = _controlledPlayer;
				BaseBody body3 = controlledPlayer3.body;
				controlledPlayer3._currentDirection = body3._velocity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v8 (BaseBody)+74]");
				_ = 0;
			}
		}
	}

	private float2 CombineWithStandardRepulsionAndDeadZone(float2 input, float repulsionScale = 0.001f)
	{
		float2 float5 = CalculateStandardRepulsionVector();
		object obj = default(object);
		float num = (float)obj * repulsionScale;
		float num2 = (float)float5 * repulsionScale;
		object obj2 = default(object);
		float num3 = (float)obj2 + num;
		float num4 = num2 + (float)input;
		float num5 = num3 * num3;
		float num6 = num4 * num4;
		float num7 = num6 + num5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
		float2 result = default(float2);
		if (0.1f > num7)
		{
			return result;
		}
		return result;
	}

	private float2 CalculateStandardRepulsionVector()
	{
		//IL_0049: Expected F4, but got I4
		//IL_0310: Expected O, but got I4
		//IL_00e5: Expected I, but got O
		//IL_0372: Expected O, but got I4
		//IL_0197: Expected I, but got O
		GameManager core = GM.Core;
		float2 zero = float2.zero;
		float num = 0f;
		List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator enumerator = default(List<VampireSurvivors.Objects.Characters.CharacterController>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				ArcadeSprite arcadeSprite = null;
				VampireSurvivors.Objects.Characters.CharacterController controlledPlayer = _controlledPlayer;
				bool flag = (object)_controlledPlayer == null;
				bool flag2 = !flag;
				object obj = !flag2;
				if (obj != null)
				{
					continue;
				}
				if ((object)_controlledPlayer == null)
				{
					nint num2 = (nint)typeof(UnityEngine.Object);
					throw new NullReferenceException();
				}
				if (((UnityEngine.Object)controlledPlayer).m_CachedPtr == (IntPtr)0)
				{
					continue;
				}
				VampireSurvivors.Objects.Characters.CharacterController followedCharacter = _followedCharacter;
				bool flag3 = (object)_followedCharacter == null;
				bool flag4 = !flag3;
				object obj2 = !flag4;
				if (obj2 == null)
				{
					if ((object)_followedCharacter == null)
					{
						nint num2 = (nint)typeof(UnityEngine.Object);
						throw new NullReferenceException();
					}
					if (((UnityEngine.Object)followedCharacter).m_CachedPtr != (IntPtr)0)
					{
						break;
					}
				}
				continue;
			}
			return zero;
		}
		throw new NullReferenceException();
	}

	public void HandleWeaponLevelling()
	{
		//IL_002f: Expected O, but got I4
		bool flag = _003CLevelupType_003Ek__BackingField == LevelupType.NoWeapons;
		if (flag)
		{
			return;
		}
		object obj = _003CLevelupType_003Ek__BackingField - 1;
		if (!flag)
		{
			if ((nint)obj == 1)
			{
				GiveNextLevelupPresetWeapon(0);
			}
		}
		else
		{
			GiveNextShowcaseWeapon();
		}
	}

	public unsafe void HandleOnLevelUpCompleted()
	{
		//IL_01c3: Expected O, but got I4
		//IL_01dd: Expected O, but got I4
		//IL_016e: Expected O, but got Ref
		VampireSurvivors.Objects.Characters.CharacterController followedCharacter = _followedCharacter;
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
		bool flag = (object)gameSessionData._activeCharacter == null;
		bool flag2 = (object)_followedCharacter == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)gameSessionData._activeCharacter != null)
			{
				if ((object)_followedCharacter != null)
				{
					object obj3 = (object)_followedCharacter - (object)gameSessionData._activeCharacter;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)activeCharacter).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)followedCharacter).m_CachedPtr == (IntPtr)0;
			}
			if (!flag4)
			{
				return;
			}
		}
		if (_lasLevelledUpWeaponType != WeaponType.VOID)
		{
			GameManager core2 = GM.Core;
			core2._gizmoManager.DisplayWeaponLevelup(_controlledPlayer);
			GameManager core3 = GM.Core;
			Color coopColour = _controlledPlayer.GetCoopColour();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,0Ch\"");
			object obj4 = default(object);
			VampireSurvivors.Objects.Characters.CharacterController character = default(VampireSurvivors.Objects.Characters.CharacterController);
			float displayTimeMultiplier = default(float);
			Vector2 vOffset = default(Vector2);
			core3._gizmoManager.DisplayWeaponIconOverhead(_lasLevelledUpWeaponType, "1", (Color?)(object)(&obj4), character, displayTimeMultiplier, vOffset);
		}
	}

	private void GiveNextLoadoutWeapon()
	{
		//IL_0089: Expected O, but got I
		List<WeaponType> loadout = _loadout;
		int levelupLoadoutIndex = _levelupLoadoutIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)levelupLoadoutIndex >= (nint)0)
		{
			_lasLevelledUpWeaponType = WeaponType.VOID;
			return;
		}
		List<WeaponType> loadout2 = _loadout;
		int levelupLoadoutIndex2 = _levelupLoadoutIndex;
		int levelupLoadoutIndex3 = _levelupLoadoutIndex;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
		if ((nint)levelupLoadoutIndex3 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v10 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+10]");
			object obj = 0;
			int levelupLoadoutIndex4 = _levelupLoadoutIndex + 1;
			_levelupLoadoutIndex = levelupLoadoutIndex4;
			GameManager core = GM.Core;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+20+v69 @ rcx_v6 (System.Int32)*4]");
			core.LevelWeaponUp(WeaponType.VOID, removeFromStore: false, _controlledPlayer);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4+20+v69 @ rcx_v6 (System.Int32)*4]");
			_lasLevelledUpWeaponType = WeaponType.VOID;
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void GiveNextShowcaseWeapon()
	{
		//IL_006f: Expected O, but got I
		//IL_0084: Expected O, but got I
		//IL_00de: Expected O, but got I
		VampireSurvivors.Objects.Characters.CharacterController controlledPlayer = _controlledPlayer;
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)controlledPlayer._characterType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v11 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v11 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v9+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rcx_v9+20]");
			if ((nint)0 == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v10+E8]");
			if ((nint)0 == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ rcx_v10+E8]");
			List<WeaponType> loadout = (List<WeaponType>)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 > (nint)0)
			{
				if (_loadout == null)
				{
					_loadout = loadout;
				}
				GiveNextLoadoutWeapon();
			}
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void GiveNextLevelupPresetWeapon(int presetIndex)
	{
		//IL_006f: Expected O, but got I
		//IL_0084: Expected O, but got I
		//IL_00de: Expected O, but got I
		//IL_0174: Expected O, but got I4
		//IL_018e: Expected O, but got I
		VampireSurvivors.Objects.Characters.CharacterController controlledPlayer = _controlledPlayer;
		GameManager core = GM.Core;
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = core._dataManager.GetConvertedCharacterData();
		object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)controlledPlayer._characterType);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v11 (System.Object)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rax_v11 (System.Object)+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v5+20]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rbx_v5+20]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rbx_v6+F0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rbx_v6+F0]");
					Dictionary<CharacterType, List<CharacterData>> dictionary = (Dictionary<CharacterType, List<CharacterData>>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rax_v14 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>>)+18]");
					if ((nint)0 > (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rax_v14 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, System.Collections.Generic.List`1<VampireSurvivors.Data.Characters.CharacterData>>)+18]");
						if ((nint)presetIndex < (nint)0)
						{
							if (_loadout == null)
							{
								List<CharacterData> list = dictionary.get_Item((CharacterType)presetIndex);
								_loadout = (List<WeaponType>)list._size;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rbx_v6+F0]");
								List<CharacterData> list2 = ((Dictionary<CharacterType, List<CharacterData>>)0).get_Item((CharacterType)presetIndex);
								if (list2._syncRoot != null)
								{
									Debug.Log("<color=green> SHUFFLING LOADOUT</color>");
									List<WeaponType> loadout = (List<WeaponType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_loadout);
									_loadout = loadout;
									Extensions.Shuffle(_loadout, _loadoutShuffler);
								}
							}
							GiveNextLoadoutWeapon();
							return;
						}
					}
				}
			}
			GiveNextShowcaseWeapon();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}
}
