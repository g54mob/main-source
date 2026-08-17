using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class ReportWeapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public ReportWeapon _003C_003E4__this;

		public VampireSurvivors.Objects.Characters.CharacterController character;

		internal void _003CPerformReport_003Eb__0()
		{
			ReportWeapon reportWeapon = _003C_003E4__this;
			Transform transform = reportWeapon._reportImage.transform;
			Vector3 euler = default(Vector3);
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		}

		internal void _003CPerformReport_003Eb__1()
		{
			ReportWeapon reportWeapon = _003C_003E4__this;
			Transform transform = reportWeapon._reportImage.transform;
			Vector3 euler = default(Vector3);
			Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			ReportWeapon reportWeapon2 = _003C_003E4__this;
			Transform transform2 = reportWeapon2._reportImage.transform;
			bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
			Vector3 value2 = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
			ReportWeapon reportWeapon3 = _003C_003E4__this;
			VampireSurvivors.Objects.Characters.CharacterController characterController = character;
			CharacterData currentSkinData = characterController._currentSkinData;
			Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData._003CtextureName_003Ek__BackingField);
			reportWeapon3._deadCharacterSprite.sprite = sprite;
			ReportWeapon reportWeapon4 = _003C_003E4__this;
			Sprite sprite2 = reportWeapon4._deadCharacterSprite.sprite;
			reportWeapon4._deadCharacterShadowSprite.sprite = sprite2;
			ReportWeapon reportWeapon5 = _003C_003E4__this;
			reportWeapon5._deadBodyDisplay.SetActive(value: true);
		}
	}

	private SpriteRenderer _reportImage;

	private GameObject _deadBodyDisplay;

	private SpriteRenderer _deadCharacterSprite;

	private SpriteRenderer _deadCharacterShadowSprite;

	private List<VampireSurvivors.Objects.Characters.CharacterController> _reportedPlayers;

	private bool _isSendingBodyReport;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		GameObject gameObject = _reportImage.gameObject;
		gameObject.SetActive(value: false);
		_deadBodyDisplay.SetActive(value: false);
	}

	public override void InternalUpdate()
	{
		//IL_01e5: Expected O, but got I4
		//IL_06ca: Expected O, but got I4
		//IL_06e4: Expected O, but got I4
		//IL_0646: Unknown result type (might be due to invalid IL or missing references)
		//IL_064b: Expected O, but got Unknown
		//IL_0344: Expected I4, but got O
		//IL_03a2: Expected I4, but got O
		//IL_047b: Expected I4, but got O
		//IL_04d7: Invalid comparison between F4 and O
		//IL_03d0: Expected I, but got O
		//IL_03de: Expected I, but got O
		//IL_03ee: Expected O, but got I
		//IL_0503: Expected I4, but got O
		//IL_042b: Expected O, but got I
		//IL_0517: Expected I4, but got O
		//IL_054c: Expected I4, but got O
		//IL_059b: Expected I4, but got O
		//IL_05b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b8: Expected O, but got Unknown
		//IL_05bd: Expected I, but got O
		base.InternalUpdate();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (characterController._isDead || characterController.IsDisconnectedFromOnlinePlay)
		{
			return;
		}
		VampireSurvivors.Objects.Characters.CharacterController characterController2 = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (!characterController2._coherenceSync.HasStateAuthority || _isSendingBodyReport)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> reportedPlayers = _reportedPlayers;
		bool flag = (nint)_reportedPlayers < 0;
		int num = reportedPlayers._size - 1;
		nint num3 = default(nint);
		nint num2 = num3;
		if (flag)
		{
			goto IL_01fb;
		}
		while (true)
		{
			List<VampireSurvivors.Objects.Characters.CharacterController> reportedPlayers2 = _reportedPlayers;
			if (num >= reportedPlayers2._size)
			{
				break;
			}
			VampireSurvivors.Objects.Characters.CharacterController[] items = reportedPlayers2._items;
			VampireSurvivors.Objects.Characters.CharacterController characterController3 = items[num];
			bool flag2 = (characterController3._isDead ? 1 : 0) < (false ? 1 : 0);
			if (!characterController3._isDead)
			{
				bool isDisconnectedFromOnlinePlay = characterController3.IsDisconnectedFromOnlinePlay;
				flag2 = (isDisconnectedFromOnlinePlay ? 1 : 0) < (false ? 1 : 0);
				if (!isDisconnectedFromOnlinePlay)
				{
					flag2 = (nint)_reportedPlayers < 0;
					_reportedPlayers.RemoveAt(num);
					num2 = 0;
				}
			}
			num--;
			object obj = !flag2;
			num3 = num2;
			if (obj != null)
			{
				continue;
			}
			goto IL_01fb;
		}
		goto IL_0675;
		IL_01fb:
		GameManager core = GM.Core;
		List<VampireSurvivors.Objects.Characters.CharacterController> characters = core._characters;
		VampireSurvivors.Objects.Characters.CharacterController characterController4 = null;
		VampireSurvivors.Objects.Characters.CharacterController characterController5 = null;
		VampireSurvivors.Objects.Characters.CharacterController characterController8 = default(VampireSurvivors.Objects.Characters.CharacterController);
		object obj5 = default(object);
		ArcadeSprite arcadeSprite = default(ArcadeSprite);
		object obj10 = default(object);
		object obj11 = default(object);
		VampireSurvivors.Objects.Characters.CharacterController characterController9 = default(VampireSurvivors.Objects.Characters.CharacterController);
		object obj15 = default(object);
		int index = default(int);
		VampireSurvivors.Objects.Characters.CharacterController character = default(VampireSurvivors.Objects.Characters.CharacterController);
		OnlineStageManager onlineStageManager = default(OnlineStageManager);
		while (true)
		{
			if ((nint)characterController5 >= characters._size)
			{
				return;
			}
			if ((nint)characterController4 >= characters._size)
			{
				break;
			}
			VampireSurvivors.Objects.Characters.CharacterController[] items2 = characters._items;
			VampireSurvivors.Objects.Characters.CharacterController characterController6 = ((Equipment)this)._003COwner_003Ek__BackingField;
			VampireSurvivors.Objects.Characters.CharacterController characterController7 = items2[(object)characterController4];
			bool flag3 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
			bool flag4 = (object)items2[(object)characterController4] == null;
			object obj2 = flag4 & flag3;
			bool flag5 = obj2 == null;
			object obj3 = !flag5;
			if (obj3 == null)
			{
				bool flag6;
				if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
				{
					if ((object)items2[(object)characterController4] != null)
					{
						object obj4 = (object)items2[(object)characterController4] - (object)((Equipment)this)._003COwner_003Ek__BackingField;
						flag6 = obj4 == null;
					}
					else
					{
						flag6 = ((UnityEngine.Object)characterController6).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag6 = ((UnityEngine.Object)characterController7).m_CachedPtr == (IntPtr)0;
				}
				if (!flag6)
				{
					characters.RemoveAt((int)characterController4);
					if (characterController8._isDead || characterController8.IsDisconnectedFromOnlinePlay)
					{
						characters.RemoveAt((int)characterController4);
						bool flag7 = obj5 == null;
						nint num4 = num3;
						if (!flag7)
						{
							num4 = (nint)obj5;
							nint num5 = (nint)typeof(FollowerEnemy_CharacterController);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v891 @ rdx_v33 (Il2CppClass<VampireSurvivors.Objects.Characters.FollowerEnemy_CharacterController>)+130]");
							object obj6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r8_v11 (Il2CppMethodInfo)+130]");
							nint num6 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v891 @ rdx_v33 (Il2CppClass<VampireSurvivors.Objects.Characters.FollowerEnemy_CharacterController>)+130]");
							if (num6 >= 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ r8_v11 (Il2CppMethodInfo)+C8]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v896 @ rax_v57+FFFFFFF8+v1071 @ rax_v56*8]");
								bool flag8 = 0 == (nint)typeof(FollowerEnemy_CharacterController);
								num3 = num4;
								if (flag8)
								{
									goto IL_063d;
								}
							}
						}
						float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
						characters.RemoveAt((int)characterController4);
						float2 position2 = arcadeSprite.position;
						object obj8 = position2 - position;
						object obj9 = obj10 - obj11;
						object obj12 = obj8 * obj8;
						object obj13 = obj9 * obj9;
						object obj14 = obj12 + obj13;
						bool flag9 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)0.25f) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14);
						num3 = num4;
						if (!flag9)
						{
							characters.RemoveAt((int)characterController4);
							_reportedPlayers.RemoveAt((int)characterController9);
							bool flag10 = obj15 != null;
							num3 = num4;
							if (!flag10)
							{
								characters.RemoveAt((int)characterController4);
								_reportedPlayers.RemoveAt(index);
								GameManager core2 = GM.Core;
								if (!core2._multiplayer.IsOnlineMultiplayer)
								{
									characters.RemoveAt((int)characterController4);
									ReportBody(character);
									characterController4 = (VampireSurvivors.Objects.Characters.CharacterController)(characterController4 + 1);
									num3 = unchecked((nint)null);
									characterController5 = characterController4;
									continue;
								}
								VampireSurvivors.Objects.Characters.CharacterController characterController10 = ((Equipment)this)._003COwner_003Ek__BackingField;
								_isSendingBodyReport = true;
								Action<long, CoherenceSync> action = null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA56D0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
								long startingOnlineClientFrame = onlineStageManager.GetStartingOnlineClientFrame();
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F6D7F0");
								num3 = 1;
							}
						}
					}
				}
			}
			goto IL_063d;
			IL_063d:
			characterController4 = (VampireSurvivors.Objects.Characters.CharacterController)(characterController4 + 1);
			characterController5 = characterController4;
		}
		goto IL_0675;
		IL_0675:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	public void ReportBody(VampireSurvivors.Objects.Characters.CharacterController character = null)
	{
		while ((object)character != null && ((UnityEngine.Object)character).m_CachedPtr == (IntPtr)0)
		{
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 127 Invalid \"Jump target not found in method: 0x1873CFCF0\"");
	}

	private void PerformReport(VampireSurvivors.Objects.Characters.CharacterController character)
	{
		//IL_01fe: Expected F4, but got I4
		//IL_01fe: Expected F4, but got I4
		//IL_01fe: Expected F4, but got O
		//IL_01fe: Expected O, but got I4
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass9_0();
		if (CS_0024_003C_003E8__locals10 != null)
		{
			CS_0024_003C_003E8__locals10._003C_003E4__this = this;
			CS_0024_003C_003E8__locals10.character = character;
			_isSendingBodyReport = false;
			Transform transform = base.transform;
			Camera main = Camera.main;
			if ((object)main != null)
			{
				Transform transform2 = main.transform;
				if ((object)transform2 != null)
				{
					bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret);
					bool flag2 = (object)transform == null;
					bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
					bool flag4 = (object)_reportImage == null;
					GameObject gameObject = _reportImage.gameObject;
					bool flag5 = (object)gameObject == null;
					gameObject.SetActive(value: true);
					bool flag6 = (object)_reportImage == null;
					Transform transform3 = _reportImage.transform;
					bool flag7 = (object)transform3 == null;
					bool flag8 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
					bool flag9 = (object)_reportImage == null;
					Transform transform4 = _reportImage.transform;
					Quaternion.Internal_FromEulerRad_Injected(ref ret, out Quaternion _);
					bool flag10 = (object)transform4 == null;
					bool flag11 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
					Quaternion value3 = default(Quaternion);
					Transform.set_localRotation_Injected(((UnityEngine.Object)transform4).m_CachedPtr, ref value3);
					Action onComplete = delegate
					{
						ReportWeapon reportWeapon = CS_0024_003C_003E8__locals10._003C_003E4__this;
						Transform transform5 = reportWeapon._reportImage.transform;
						Vector3 euler = default(Vector3);
						Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
						bool flag16 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
						Quaternion value4 = default(Quaternion);
						Transform.set_localRotation_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value4);
					};
					bool flag12 = default(bool);
					MonoBehaviour monoBehaviour = default(MonoBehaviour);
					int num = default(int);
					Timer timer = TimerHelper.RegisterMillisUI(100f, onComplete, null, isLooped: false, flag12, monoBehaviour, num);
					Action onComplete2 = delegate
					{
						ReportWeapon reportWeapon = CS_0024_003C_003E8__locals10._003C_003E4__this;
						Transform transform5 = reportWeapon._reportImage.transform;
						Vector3 euler = default(Vector3);
						Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
						bool flag16 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
						Quaternion value4 = default(Quaternion);
						Transform.set_localRotation_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value4);
						ReportWeapon reportWeapon2 = CS_0024_003C_003E8__locals10._003C_003E4__this;
						Transform transform6 = reportWeapon2._reportImage.transform;
						bool flag17 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
						Vector3 value5 = default(Vector3);
						Transform.set_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref value5);
						ReportWeapon reportWeapon3 = CS_0024_003C_003E8__locals10._003C_003E4__this;
						VampireSurvivors.Objects.Characters.CharacterController character2 = CS_0024_003C_003E8__locals10.character;
						CharacterData currentSkinData = character2._currentSkinData;
						Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData._003CtextureName_003Ek__BackingField);
						reportWeapon3._deadCharacterSprite.sprite = sprite;
						ReportWeapon reportWeapon4 = CS_0024_003C_003E8__locals10._003C_003E4__this;
						Sprite sprite2 = reportWeapon4._deadCharacterSprite.sprite;
						reportWeapon4._deadCharacterShadowSprite.sprite = sprite2;
						ReportWeapon reportWeapon5 = CS_0024_003C_003E8__locals10._003C_003E4__this;
						reportWeapon5._deadBodyDisplay.SetActive(value: true);
					};
					Timer timer2 = TimerHelper.RegisterMillisUI(200f, onComplete2, null, isLooped: false, flag12, monoBehaviour, num);
					bool flag13 = _playerOptions == null;
					PlayerOptionsData config = _playerOptions.Config;
					bool flag14 = config == null;
					SoundManager.FadeMusic(config._003CSelectedBGM_003Ek__BackingField, 0f, 0f);
					bool loop = default(bool);
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.DLC3_BodyReported, 1000f, 10, 0f, (float?)(object)flag12, (float)monoBehaviour, num, loop, 1f);
					Action onComplete3 = Unfreeze;
					bool flag15 = (object)GM.Core == null;
					GM.Core.FrameFreeze(onComplete3, 2800f, pauseTweens: true);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void Unfreeze()
	{
		PlayerOptionsData config = _playerOptions.Config;
		PlayerOptionsData config2 = _playerOptions.Config;
		SoundManager.FadeMusic(config._003CSelectedBGM_003Ek__BackingField, config2._003CMusicVolume_003Ek__BackingField, 2000f);
		_deadBodyDisplay.SetActive(value: false);
		GameObject gameObject = _reportImage.gameObject;
		gameObject.SetActive(value: false);
		GM.Core.EraseEnemies();
	}

	public ReportWeapon()
	{
		List<VampireSurvivors.Objects.Characters.CharacterController> reportedPlayers = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		_reportedPlayers = reportedPlayers;
		base._002Ector();
	}
}
