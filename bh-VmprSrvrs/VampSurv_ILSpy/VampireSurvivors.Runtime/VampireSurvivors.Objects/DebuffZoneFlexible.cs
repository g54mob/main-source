using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using QFSW.MOP2;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Objects;

public class DebuffZoneFlexible : DamageZoneFlexible
{
	public enum DebuffType
	{
		SLOW,
		MONEY_DRAIN
	}

	private DebuffType _debuffZoneType;

	private float _slowAmount;

	private float _moneyDrainAmount;

	private List<VampireSurvivors.Objects.Characters.CharacterController> _currentlyDebuffedPlayers;

	public unsafe static DebuffZoneFlexible CreateDebuffZone(Camera targetCamera)
	{
		//IL_006c: Expected O, but got Ref
		//IL_006c: Expected O, but got Ref
		//IL_019f->IL0110: Incompatible stack heights: 1 vs 0
		//IL_0181->IL0110: Incompatible stack heights: 1 vs 0
		//IL_00a8->IL0110: Incompatible stack heights: 1 vs 0
		//IL_00c5->IL0110: Incompatible stack heights: 1 vs 0
		//IL_00f4->IL0110: Incompatible stack heights: 1 vs 0
		if ((object)targetCamera != null)
		{
			Transform transform = targetCamera.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)HeroVfxManager._factory != null)
				{
					ObjectPool pool = HeroVfxManager._factory.GetPool(HeroVfxType.DebuffZonesFlexible);
					if ((object)pool != null)
					{
						object obj2 = default(object);
						GameObject obj = pool.GetObject((Vector3)(&obj2), (Quaternion)(&ret));
						Transform objectComponent = (Transform)(object)pool.GetObjectComponent<DebuffZoneFlexible>(obj);
						GameManager core = GM.Core;
						if ((object)GM.Core != null && (object)objectComponent != null)
						{
							GameObject gameObject = objectComponent.gameObject;
							if (core._diContainer != null)
							{
								core._diContainer.InjectGameObject(gameObject);
								return (DebuffZoneFlexible)(object)objectComponent;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void InitDebuffZoneBehaviour(DebuffType debuffType, float debuffValue)
	{
		_debuffZoneType = debuffType;
		switch (debuffType)
		{
		case DebuffType.SLOW:
			_slowAmount = debuffValue;
			break;
		case DebuffType.MONEY_DRAIN:
			_moneyDrainAmount = debuffValue;
			break;
		default:
		{
			DebuffType debuffType2 = default(DebuffType);
			object actualValue = debuffType2;
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("debuffType", actualValue, null);
			throw ex;
		}
		}
	}

	protected override void UpdatePlayerEffects()
	{
		GameManager core = GM.Core;
		bool flag = !_activateDamage;
		List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
		if (flag || core._mainCharacters == null || mainCharacters._size == 0)
		{
			return;
		}
		if (_debuffZoneType == DebuffType.SLOW)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 89 Invalid \"Jump target not found in method: 0x186E1A7B0\"");
			return;
		}
		if (_debuffZoneType == DebuffType.MONEY_DRAIN)
		{
			HandleMoneyDrain(core._mainCharacters);
			return;
		}
		ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
		throw ex;
	}

	private unsafe void HandleSlowDebuff(List<VampireSurvivors.Objects.Characters.CharacterController> players)
	{
		//IL_0039: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_0193: Expected I, but got O
		//IL_02d9: Expected O, but got I4
		//IL_030b: Expected I, but got O
		//IL_01ee: Expected I, but got O
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_00ca: Expected I, but got O
		if (players._size <= 0)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController = null;
		Vector3 _unity_self = (Vector3)0;
		Vector2 vector = (Vector2)0;
		ArcadeSprite arcadeSprite = default(ArcadeSprite);
		Vector2 point = default(Vector2);
		object obj3 = default(object);
		Vector2 vector2 = default(Vector2);
		object obj4 = default(object);
		object item = default(object);
		ArcadeSprite arcadeSprite2 = default(ArcadeSprite);
		object obj5 = default(object);
		object item2 = default(object);
		object obj6 = default(object);
		do
		{
			if (!_isCircle)
			{
				Bounds bounds = _groundFx.Bounds;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				float2 float5 = arcadeSprite.position;
				object obj = Bounds.Contains_Injected(ref *(Bounds*)(&_unity_self), ref *(Vector3*)(&point));
				List<VampireSurvivors.Objects.Characters.CharacterController> currentlyDebuffedPlayers = _currentlyDebuffedPlayers;
				bool flag = obj != null;
				object obj2 = obj3;
				vector = vector2;
				nint num = unchecked((nint)null);
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = characterController;
				List<VampireSurvivors.Objects.Characters.CharacterController> list = players;
				if (flag)
				{
					goto IL_0255;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA24C0");
				bool flag2 = obj4 == null;
				point = vector2;
				obj2 = obj3;
				_unity_self = bounds.m_Center;
				vector = vector2;
				num = unchecked((nint)null);
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					_ = 1065353216;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag3 = ((List<object>)(object)_currentlyDebuffedPlayers).Remove(item);
					point = vector2;
					obj2 = obj3;
					_unity_self = bounds.m_Center;
					vector = vector2;
					num = 0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				float2 float6 = arcadeSprite2.position;
				List<VampireSurvivors.Objects.Characters.CharacterController> currentlyDebuffedPlayers = _currentlyDebuffedPlayers;
				bool flag4 = _circleCollider.Contains(vector2);
				object obj2 = obj3;
				vector = vector2;
				nint num = unchecked((nint)null);
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = characterController;
				List<VampireSurvivors.Objects.Characters.CharacterController> list = players;
				if (flag4)
				{
					goto IL_0255;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA24C0");
				bool flag5 = obj5 == null;
				obj2 = obj3;
				vector = vector2;
				num = unchecked((nint)null);
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag6 = ((List<object>)(object)_currentlyDebuffedPlayers).Remove(item2);
					bool flag7 = players.Remove(characterController);
					_ = 1065353216;
					obj2 = obj3;
					vector = vector2;
					num = 0;
				}
			}
			goto IL_0329;
			IL_0329:
			characterController = (VampireSurvivors.Objects.Characters.CharacterController)(characterController + 1);
			continue;
			IL_0255:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA24C0");
			if (obj6 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
			_ = _slowAmount;
			goto IL_0329;
		}
		while ((nint)characterController < players._size);
	}

	private unsafe void HandleMoneyDrain(List<VampireSurvivors.Objects.Characters.CharacterController> players)
	{
		//IL_0033: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_028c: Expected O, but got F4
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		if (players._size <= 0)
		{
			return;
		}
		object obj = 0;
		Vector3 _unity_self = (Vector3)0;
		Vector2 point = default(Vector2);
		Vector2 vector = default(Vector2);
		while ((nint)obj < players._size)
		{
			VampireSurvivors.Objects.Characters.CharacterController[] items = players._items;
			object obj2 = Time.deltaTime;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
			double num = Math.Floor(0.0);
			GameManager core = GM.Core;
			PlayerOptions playerOptions = core._playerOptions;
			PlayerOptionsData playerOptionsData;
			if (playerOptions._onlineClientWithRunDataConfig == null)
			{
				if (playerOptions._hostGameConfig == null)
				{
					if (playerOptions._currentAdventureSaveData != null)
					{
						playerOptionsData = playerOptions._currentAdventureSaveData;
						if ((object)playerOptionsData._003CSelectedAdventureType_003Ek__BackingField != null)
						{
							goto IL_014f;
						}
					}
					playerOptionsData = playerOptions._mainGameConfig;
				}
				else
				{
					playerOptionsData = playerOptions._hostGameConfig;
				}
			}
			else
			{
				playerOptionsData = playerOptions._onlineClientWithRunDataConfig;
			}
			goto IL_014f;
			IL_014f:
			double num2 = Math.Floor(playerOptionsData._003CRunCoins_003Ek__BackingField);
			bool flag = !(num > num2);
			double num3 = num;
			if (!flag)
			{
				num3 = num2;
			}
			bool flag2;
			if (!_isCircle)
			{
				Bounds bounds = _groundFx.Bounds;
				float2 float5 = items[obj].position;
				flag2 = Bounds.Contains_Injected(ref *(Bounds*)(&_unity_self), ref *(Vector3*)(&point));
				point = vector;
			}
			else
			{
				float2 float6 = items[obj].position;
				flag2 = _circleCollider.Contains(vector);
			}
			if (flag2)
			{
				GameManager core2 = GM.Core;
				float num4 = core2._playerOptions.RemoveCoinsFlat((float)num3);
			}
			obj++;
			if ((nint)obj >= players._size)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	protected override void Despawn()
	{
		//IL_0025: Expected O, but got I4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		base.Despawn();
		List<VampireSurvivors.Objects.Characters.CharacterController> currentlyDebuffedPlayers = _currentlyDebuffedPlayers;
		bool flag = currentlyDebuffedPlayers._size <= 0;
		object obj = 0;
		if (!flag)
		{
			do
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> currentlyDebuffedPlayers2 = _currentlyDebuffedPlayers;
				if ((nint)obj < currentlyDebuffedPlayers2._size)
				{
					VampireSurvivors.Objects.Characters.CharacterController[] items = currentlyDebuffedPlayers2._items;
					VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj];
					obj++;
					characterController._debuffSlow = 1f;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			while ((nint)obj < currentlyDebuffedPlayers._size);
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> currentlyDebuffedPlayers3 = _currentlyDebuffedPlayers;
		int version = currentlyDebuffedPlayers3._version + 1;
		currentlyDebuffedPlayers3._version = version;
		currentlyDebuffedPlayers3._size = 0;
		if (currentlyDebuffedPlayers3._size > 0)
		{
			Array.Clear(currentlyDebuffedPlayers3._items, 0, currentlyDebuffedPlayers3._size);
		}
	}

	public DebuffZoneFlexible()
	{
		List<VampireSurvivors.Objects.Characters.CharacterController> currentlyDebuffedPlayers = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		_currentlyDebuffedPlayers = currentlyDebuffedPlayers;
		base._damage = 1f;
		base._activatonDelay = 500f;
		base._durationMillis = 250f;
		base._hitDelayMillis = 500f;
		base._visibleWarningZone = true;
		((GameMonoBehaviour)this)._onResumeSent = true;
	}
}
