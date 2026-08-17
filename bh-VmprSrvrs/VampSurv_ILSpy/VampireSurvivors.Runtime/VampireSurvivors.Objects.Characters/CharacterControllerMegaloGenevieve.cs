using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters;

public class CharacterControllerMegaloGenevieve : CharacterController
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__18_0;

		public static TweenCallback _003C_003E9__27_0;

		public static TweenCallback _003C_003E9__27_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003COnLevelUpCompleted_003Eb__18_0()
		{
			//IL_004d: Expected O, but got I4
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Vacuum, soundConfig, 1000f, 1, time);
			GM.Core.TurnOnVacuum();
		}

		internal void _003CScreenShake_003Eb__27_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -3f;
		}

		internal void _003CScreenShake_003Eb__27_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public CharacterControllerMegaloGenevieve _003C_003E4__this;

		public List<int2> posList;

		internal void _003CStartEatingTile_003Eb__0()
		{
			//IL_0272: Expected O, but got I4
			//IL_0081: Expected O, but got I
			//IL_0096: Expected O, but got I
			//IL_00ac: Expected O, but got I
			//IL_00e3: Expected O, but got I
			//IL_00fe: Expected O, but got I
			//IL_0119: Expected O, but got I
			//IL_0136: Expected O, but got I
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Expected O, but got Unknown
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Expected O, but got Unknown
			//IL_0187: Expected O, but got I4
			//IL_0190: Expected O, but got I4
			//IL_02fb: Expected O, but got I4
			//IL_030a: Expected O, but got I4
			_003C_003E4__this.EatTile(posList);
			List<int2> list = posList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
			if ((nint)0 > (nint)100)
			{
				if ((object)_003C_003E4__this == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rbx_v7+20]");
					int2 int5 = (int2)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
					object obj2 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
					if ((nint)obj2 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+10]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
						object obj4 = -1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
						object obj5 = (nint)0 >> 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rbx_v7+20]");
						object obj6 = num - 0;
						object obj7 = obj6 + 1;
						object obj9 = default(object);
						object obj8 = obj5 - obj9;
						object obj10 = obj8 + 1;
						List<int2> list2 = (List<int2>)(obj10 * obj7);
						bool flag = (nint)list2 <= 100;
						object obj11 = 1;
						object obj12 = 100;
						if (!flag)
						{
							do
							{
								obj11 = 1 + 1;
								obj12 = 100 * 4;
							}
							while (System.Runtime.CompilerServices.Unsafe.As<List<int2>, UIntPtr>(ref list2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12));
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+1C]");
						_ = (nint)0 + (nint)1;
						_ = 0;
						int2 obj13 = int5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
						if ((nint)obj13 <= 0)
						{
							object obj14 = default(object);
							int2 obj16;
							do
							{
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14))
								{
									object obj15;
									do
									{
										list.Add(int5);
										obj15 = obj9 + obj11;
									}
									while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14));
								}
								int5 = (int2)((object)int5 + obj11);
								obj16 = int5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
							}
							while ((nint)obj16 <= 0);
						}
						goto IL_0216;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			goto IL_0216;
			IL_0216:
			_003C_003E4__this.BlackExplosionAt(posList);
			_003C_003E4__this.RecoverHp(1f, showRecovery: true, mulByRegen: true);
			_003C_003E4__this.ScreenShake();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack2, soundConfig, 1000f, 1, time);
		}
	}

	private List<int2> _tilesToEat;

	private List<int2> _currentTilesBeingEaten;

	private float _eatTimer = 1100f;

	private float _eatDelay = 1100f;

	private ParticleEmitterManager _particlesManager;

	private ParticleSystem _pfxEmitter;

	private ParticleSystem _pfxEmitter2;

	private GravityWell _well;

	public WorldEaterVFX _wolrdEater;

	public Action _worldEaterCallback;

	public override bool NeedsCart => false;

	public override void AfterFullInitialization()
	{
		WorldEaterVFX wolrdEater = new WorldEaterVFX(this);
		_wolrdEater = wolrdEater;
		base._isLastBreathEnabled = true;
		Action worldEaterCallback = TryEatingWorld;
		_worldEaterCallback = worldEaterCallback;
		Action onLastBreath = LastBreath;
		base._onLastBreath = onLastBreath;
		base.AfterFullInitialization();
	}

	public override void OnQuit()
	{
		base.OnQuit();
	}

	public void LastBreath()
	{
		base.IsInvul = true;
		if (2f > base._invincibilityTimer)
		{
			base._invincibilityTimer = 2f;
		}
		_wolrdEater.CastSoulSteal(_worldEaterCallback);
	}

	public void TryEatingWorld()
	{
		if (_eatTimer > _eatDelay)
		{
			List<int2> tilesToEat = _tilesToEat;
			_eatTimer = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rcx_v2 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			CheckTiles();
		}
	}

	protected override void MakeLevelOne(bool dontGetCharacterDataForCurrentLevel = false)
	{
		base.MakeLevelOne();
		List<int2> tilesToEat = new List<int2>();
		_tilesToEat = tilesToEat;
		List<int2> currentTilesBeingEaten = new List<int2>();
		_currentTilesBeingEaten = currentTilesBeingEaten;
		CreateBlackEmitter();
	}

	public override void OnLevelUpSkipped()
	{
		//IL_0018: Expected O, but got I
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul r8d\"");
		nint num = default(nint);
		object obj = num >> 31;
		object obj2 = num + obj;
		object obj3 = obj2 * 2;
		object obj4 = obj2 + obj3;
		object obj5 = obj4 + obj4;
		if (base._level == (nint)obj5)
		{
			_wolrdEater.CastSoulSteal(_worldEaterCallback);
		}
	}

	public override void OnLevelUpCompleted()
	{
		//IL_04bf: Expected O, but got I4
		//IL_04d9: Expected O, but got I4
		//IL_04fa: Expected O, but got I
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Expected O, but got Unknown
		//IL_02d0: Expected F4, but got I4
		//IL_058d: Expected I4, but got O
		//IL_0250: Expected F4, but got I4
		//IL_02dd: Expected I, but got O
		//IL_02eb: Expected I, but got O
		//IL_02fb: Expected O, but got I
		//IL_037b: Expected O, but got I4
		//IL_0337: Expected O, but got I
		//IL_01d0: Expected F4, but got I4
		//IL_0388: Expected I4, but got O
		//IL_036d: Expected O, but got I4
		//IL_03f0: Expected F4, but got O
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		CharacterController activeCharacter = gameSessionData._activeCharacter;
		bool flag = (object)gameSessionData._activeCharacter == null;
		bool flag2 = (object)this == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		Action action;
		if (obj2 == null)
		{
			bool flag4;
			if ((object)this != null)
			{
				if ((object)gameSessionData._activeCharacter != null)
				{
					object obj3 = (object)gameSessionData._activeCharacter - (object)this;
					flag4 = obj3 == null;
				}
				else
				{
					flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
				}
			}
			else
			{
				flag4 = ((UnityEngine.Object)activeCharacter).m_CachedPtr == (IntPtr)0;
			}
			bool flag5 = !flag4;
			IntPtr intPtr = default(IntPtr);
			action = (Action)(nint)intPtr;
			if (flag5)
			{
				goto IL_0640;
			}
		}
		Action action2 = _003C_003Ec._003C_003E9__18_0;
		if (_003C_003Ec._003C_003E9__18_0 == null)
		{
			action2 = (_003C_003Ec._003C_003E9__18_0 = delegate
			{
				//IL_004d: Expected O, but got I4
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Volume = (float?)(object)1;
				soundConfig.Rate = 1f;
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Vacuum, soundConfig, 1000f, 1, time);
				GM.Core.TurnOnVacuum();
			});
		}
		bool flag6 = default(bool);
		MonoBehaviour monoBehaviour = default(MonoBehaviour);
		int num = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.1f, action2, null, isLooped: false, flag6, monoBehaviour, num, type, isOnlineTimer: false, canPause: false);
		action = action2;
		goto IL_0640;
		IL_0640:
		float y;
		object obj4 = default(object);
		GameManager core2;
		float2 float7;
		WeaponType weaponType;
		float value;
		if (base._level != 10)
		{
			if (base._level != 20)
			{
				if (base._level != 30)
				{
					goto IL_03f5;
				}
				float2 float5 = base.position;
				float2 float6 = base.position;
				PhaserScene s_scene = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer = s_scene._renderer;
				float num2 = renderer.height * 0.45f;
				y = (float)obj4 - num2;
				core2 = GM.Core;
				float7 = float5;
				weaponType = WeaponType.SPELL_STRIKE;
				value = (flag6 ? 1 : 0);
			}
			else
			{
				float2 float8 = base.position;
				float2 float9 = base.position;
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.Renderer renderer2 = s_scene2._renderer;
				float num3 = renderer2.height * 0.45f;
				y = (float)obj4 - num3;
				core2 = GM.Core;
				float7 = float8;
				weaponType = WeaponType.SPELL_STREAM;
				value = (flag6 ? 1 : 0);
			}
		}
		else
		{
			float2 float10 = base.position;
			float2 float11 = base.position;
			PhaserScene s_scene3 = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer3 = s_scene3._renderer;
			float num4 = renderer3.height * 0.45f;
			y = (float)obj4 - num4;
			core2 = GM.Core;
			float7 = float10;
			weaponType = WeaponType.SPELL_STRING;
			value = (flag6 ? 1 : 0);
		}
		Vector2 vector = default(Vector2);
		Pickup pickup = core2.MakeStagePickup(vector, ItemType.WEAPON, weaponType, value, (ItemType)monoBehaviour, (byte)num != 0);
		bool flag7 = (object)pickup == null;
		bool flag8 = false;
		action = (Action)vector;
		object obj7;
		if (!flag7)
		{
			nint num5 = (nint)pickup;
			nint num6 = (nint)typeof(PickupWeapon);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+130]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ rdx_v5 (Il2CppClass<VampireSurvivors.Objects.Items.PickupWeapon>)+130]");
			if (num7 >= 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v960 @ r8_v5 (Il2CppClass<VampireSurvivors.Objects.Pickups.Pickup>)+C8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1015 @ rax_v33+FFFFFFF8+v962 @ rax_v29*8]");
				if (0 == (nint)typeof(PickupWeapon))
				{
					obj7 = 1;
					goto IL_05e0;
				}
			}
			obj7 = 0;
			goto IL_05e0;
		}
		goto IL_0619;
		IL_05e0:
		bool flag9 = obj7 == null;
		flag8 = false;
		action = (Action)(object)typeof(PickupWeapon);
		if (!flag9)
		{
			flag8 = (byte)(int)pickup != 0;
			action = (Action)(object)typeof(PickupWeapon);
		}
		goto IL_0619;
		IL_03f5:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul ecx\"");
		object obj8 = (object)action >> 31;
		object obj9 = (object)action + obj8;
		object obj10 = obj9 * 2;
		object obj11 = obj9 + obj10;
		object obj12 = obj11 + obj11;
		if (base._level == (nint)obj12)
		{
			_wolrdEater.CastSoulSteal(_worldEaterCallback);
		}
		return;
		IL_0619:
		if (flag8)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ rdi_v3 (System.Boolean)+10]");
			if ((nint)0 != 0)
			{
				_ = 1;
			}
		}
		GameManager core3 = GM.Core;
		core3._gizmoManager.ShowHighlightAt((float)float7, y);
		goto IL_03f5;
	}

	protected override void OnUpdate()
	{
		//IL_03c8: Invalid comparison between F4 and O
		//IL_03e3->IL00f1: Incompatible stack heights: 1 vs 0
		//IL_00f1->IL00f1: Incompatible stack heights: 1 vs 0
		//IL_04ba->IL0337: Incompatible stack heights: 1 vs 0
		//IL_0328->IL0337: Incompatible stack heights: 1 vs 0
		//IL_04fa->IL0455: Incompatible stack heights: 2 vs 0
		base.OnUpdate();
		if (base._level > 1)
		{
			float deltaTime = PauseSystem.DeltaTime;
			float num = deltaTime * 1000f;
			float eatTimer = num + _eatTimer;
			_eatTimer = eatTimer;
		}
		List<int2> tilesToEat = _tilesToEat;
		Vector3 ret;
		if (_tilesToEat != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v3 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
			bool useRealTime = default(bool);
			MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
			int repeat = default(int);
			TimerType type = default(TimerType);
			if ((nint)0 > (nint)0)
			{
				Action cachedTransform = (Action)(object)base._cachedTransform;
				if ((object)base._cachedTransform == null)
				{
					goto IL_0337;
				}
				bool flag = ((Delegate)cachedTransform).method_ptr == (IntPtr)0;
				Transform.get_localScale_Injected(((Delegate)cachedTransform).method_ptr, out ret);
				bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)2f) <= System.Runtime.CompilerServices.Unsafe.As<Vector3, UIntPtr>(ref ret);
				float eatTimer = 2f;
				if (!flag2)
				{
					Action onComplete = delegate
					{
						//IL_0068: Expected O, but got I4
						Transform cachedTransform2 = base._cachedTransform;
						bool flag5 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
						Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out Vector3 ret2);
						float xScale = (float)ret2 + 0.1f;
						ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
					};
					Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
					eatTimer = 0.5f;
				}
			}
			List<int2> tilesToEat2 = _tilesToEat;
			if (_tilesToEat != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v22 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
				if ((nint)0 <= (nint)0)
				{
					goto IL_03e8;
				}
				List<int2> currentTilesBeingEaten = _currentTilesBeingEaten;
				if (_currentTilesBeingEaten != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rcx_v44 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+1C]");
					_ = (nint)0 + (nint)1;
					_ = 0;
					List<int2> currentTilesBeingEaten2 = _currentTilesBeingEaten;
					if (_currentTilesBeingEaten != null)
					{
						List<int2> currentTilesBeingEaten3 = _currentTilesBeingEaten;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rcx_v45 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
						currentTilesBeingEaten3.InsertRange(0, _tilesToEat);
						_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass21_0();
						if (CS_0024_003C_003E8__locals11 != null)
						{
							CS_0024_003C_003E8__locals11._003C_003E4__this = this;
							CS_0024_003C_003E8__locals11.posList = _currentTilesBeingEaten;
							Action onComplete2 = delegate
							{
								//IL_0272: Expected O, but got I4
								//IL_0081: Expected O, but got I
								//IL_0096: Expected O, but got I
								//IL_00ac: Expected O, but got I
								//IL_00e3: Expected O, but got I
								//IL_00fe: Expected O, but got I
								//IL_0119: Expected O, but got I
								//IL_0136: Expected O, but got I
								//IL_013f: Unknown result type (might be due to invalid IL or missing references)
								//IL_0144: Expected O, but got Unknown
								//IL_015a: Unknown result type (might be due to invalid IL or missing references)
								//IL_015f: Expected O, but got Unknown
								//IL_0187: Expected O, but got I4
								//IL_0190: Expected O, but got I4
								//IL_02fb: Expected O, but got I4
								//IL_030a: Expected O, but got I4
								CS_0024_003C_003E8__locals11._003C_003E4__this.EatTile(CS_0024_003C_003E8__locals11.posList);
								List<int2> posList = CS_0024_003C_003E8__locals11.posList;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
								if ((nint)0 > (nint)100)
								{
									if ((object)CS_0024_003C_003E8__locals11._003C_003E4__this == null)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
									if ((nint)0 > (nint)0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+10]");
										object obj = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rbx_v7+20]");
										int2 int5 = (int2)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
										object obj2 = -1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
										if ((nint)obj2 < 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+10]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
											object obj4 = -1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
											object obj5 = (nint)0 >> 32;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
											nint num2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rbx_v7+20]");
											object obj6 = num2 - 0;
											object obj7 = obj6 + 1;
											object obj9 = default(object);
											object obj8 = obj5 - obj9;
											object obj10 = obj8 + 1;
											List<int2> list = (List<int2>)(obj10 * obj7);
											bool flag5 = (nint)list <= 100;
											object obj11 = 1;
											object obj12 = 100;
											if (!flag5)
											{
												do
												{
													obj11 = 1 + 1;
													obj12 = 100 * 4;
												}
												while (System.Runtime.CompilerServices.Unsafe.As<List<int2>, UIntPtr>(ref list) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12));
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+1C]");
											_ = (nint)0 + (nint)1;
											_ = 0;
											int2 obj13 = int5;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
											if ((nint)obj13 <= 0)
											{
												object obj14 = default(object);
												int2 obj16;
												do
												{
													if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14))
													{
														object obj15;
														do
														{
															posList.Add(int5);
															obj15 = obj9 + obj11;
														}
														while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14));
													}
													int5 = (int2)((object)int5 + obj11);
													obj16 = int5;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
												}
												while ((nint)obj16 <= 0);
											}
											goto IL_0216;
										}
									}
									System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
									return;
								}
								goto IL_0216;
								IL_0216:
								CS_0024_003C_003E8__locals11._003C_003E4__this.BlackExplosionAt(CS_0024_003C_003E8__locals11.posList);
								CS_0024_003C_003E8__locals11._003C_003E4__this.RecoverHp(1f, showRecovery: true, mulByRegen: true);
								CS_0024_003C_003E8__locals11._003C_003E4__this.ScreenShake();
								SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
								soundConfig.Volume = (float?)(object)1;
								soundConfig.Rate = 1f;
								float time = default(float);
								PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack2, soundConfig, 1000f, 1, time);
							};
							Timer timer2 = Timers.Register(0.5f, onComplete2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
							List<int2> tilesToEat3 = _tilesToEat;
							if (_tilesToEat != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ rcx_v53 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+1C]");
								_ = (nint)0 + (nint)1;
								_ = 0;
								float eatTimer = 0.5f;
								goto IL_03e8;
							}
						}
					}
				}
			}
		}
		goto IL_0337;
		IL_0337:
		throw new NullReferenceException();
		IL_03e8:
		Action well = (Action)(object)_well;
		if ((object)_well == null || ((Delegate)well).method_ptr == (IntPtr)0)
		{
			return;
		}
		if ((object)_well != null)
		{
			Transform transform = _well.transform;
			if ((object)transform != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v30 (UnityEngine.Transform)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v188 @ rax_v30 (UnityEngine.Transform)+10]");
				Transform.get_position_Injected((IntPtr)0, out ret);
				float2 float5 = base.position;
				float2 float6 = base.position;
				if ((object)_well != null)
				{
					Transform transform2 = _well.transform;
					if ((object)transform2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v38 (UnityEngine.Transform)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rax_v38 (UnityEngine.Transform)+10]");
						Transform.get_position_Injected((IntPtr)0, out ret);
						return;
					}
				}
			}
		}
		goto IL_0337;
	}

	private void CheckTiles()
	{
		//IL_0117: Expected O, but got I4
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		GameManager core = GM.Core;
		Stage stage = core._stage;
		if (!stage._hasTileSet)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		TilingTileset tilingTileset = stage2._tilingTileset;
		List<PhaserTilemap> phaserTilemaps = tilingTileset._phaserTilemaps;
		if (tilingTileset._phaserTilemaps == null)
		{
			return;
		}
		int num = phaserTilemaps._size ^ phaserTilemaps._size;
		int num2 = phaserTilemaps._size & num;
		bool flag = num2 < 0;
		bool flag2 = phaserTilemaps._size < 0;
		bool flag3 = phaserTilemaps._size == 0;
		if (flag3)
		{
			return;
		}
		bool flag4 = flag2 == flag;
		object obj = !flag4;
		object obj2 = obj | flag3;
		if (obj2 == null)
		{
			PhaserTilemap[] items = phaserTilemaps._items;
			float2 center = base._magnet.getCenter();
			List<int2> list = (List<int2>)(items[0] + 192);
			int2 item = default(int2);
			list.Add(item);
			List<int2> list2 = (List<int2>)(items[0] + 192);
			list2.Add(item);
			object obj4 = default(object);
			int2 int5 = default(int2);
			object obj3 = obj4 - (object)int5;
			object obj5 = obj4 >> 32;
			object obj7 = default(object);
			object obj6 = obj5 - obj7;
			int2 int6 = (int2)((object)int5 + obj3);
			bool flag5 = (byte)(int5 <= int6) != 0;
			int2 int7 = int5;
			if (!flag5)
			{
				int7 = int6;
			}
			int2 int8 = (int2)((object)int5 + obj3);
			bool flag6 = (byte)(int5 >= int8) != 0;
			int2 int9 = int5;
			if (!flag6)
			{
				int9 = int8;
			}
			while (int7 <= int9 != 0)
			{
				object obj8 = obj7 + obj6;
				bool flag7 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj8);
				object obj9 = obj7;
				if (!flag7)
				{
					obj9 = obj8;
				}
				object obj10 = obj7 + obj6;
				bool flag8 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10);
				object obj11 = obj7;
				if (!flag8)
				{
					obj11 = obj10;
				}
				while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11))
				{
					_tilesToEat.Add(int7);
					object obj12 = obj9 + 1;
					obj9 = obj12;
				}
				int7++;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private void StartEatingTile(List<int2> posList)
	{
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals10._003C_003E4__this = this;
		CS_0024_003C_003E8__locals10.posList = posList;
		Action onComplete = delegate
		{
			//IL_0272: Expected O, but got I4
			//IL_0081: Expected O, but got I
			//IL_0096: Expected O, but got I
			//IL_00ac: Expected O, but got I
			//IL_00e3: Expected O, but got I
			//IL_00fe: Expected O, but got I
			//IL_0119: Expected O, but got I
			//IL_0136: Expected O, but got I
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Expected O, but got Unknown
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Expected O, but got Unknown
			//IL_0187: Expected O, but got I4
			//IL_0190: Expected O, but got I4
			//IL_02fb: Expected O, but got I4
			//IL_030a: Expected O, but got I4
			CS_0024_003C_003E8__locals10._003C_003E4__this.EatTile(CS_0024_003C_003E8__locals10.posList);
			List<int2> posList2 = CS_0024_003C_003E8__locals10.posList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
			if ((nint)0 > (nint)100)
			{
				if ((object)CS_0024_003C_003E8__locals10._003C_003E4__this == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+10]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rbx_v7+20]");
					int2 int5 = (int2)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
					object obj2 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
					if ((nint)obj2 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+10]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
						object obj4 = -1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
						object obj5 = (nint)0 >> 32;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rbx_v7+20]");
						object obj6 = num - 0;
						object obj7 = obj6 + 1;
						object obj9 = default(object);
						object obj8 = obj5 - obj9;
						object obj10 = obj8 + 1;
						List<int2> list = (List<int2>)(obj10 * obj7);
						bool flag = (nint)list <= 100;
						object obj11 = 1;
						object obj12 = 100;
						if (!flag)
						{
							do
							{
								obj11 = 1 + 1;
								obj12 = 100 * 4;
							}
							while (System.Runtime.CompilerServices.Unsafe.As<List<int2>, UIntPtr>(ref list) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12));
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9 (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+1C]");
						_ = (nint)0 + (nint)1;
						_ = 0;
						int2 obj13 = int5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
						if ((nint)obj13 <= 0)
						{
							object obj14 = default(object);
							int2 obj16;
							do
							{
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14))
								{
									object obj15;
									do
									{
										posList2.Add(int5);
										obj15 = obj9 + obj11;
									}
									while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14));
								}
								int5 = (int2)((object)int5 + obj11);
								obj16 = int5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ rax_v21+20+v246 @ rdi_v6*8]");
							}
							while ((nint)obj16 <= 0);
						}
						goto IL_0216;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			goto IL_0216;
			IL_0216:
			CS_0024_003C_003E8__locals10._003C_003E4__this.BlackExplosionAt(CS_0024_003C_003E8__locals10.posList);
			CS_0024_003C_003E8__locals10._003C_003E4__this.RecoverHp(1f, showRecovery: true, mulByRegen: true);
			CS_0024_003C_003E8__locals10._003C_003E4__this.ScreenShake();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Rate = 1f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Attack2, soundConfig, 1000f, 1, time);
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(0.5f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private void BuildPositionListToBeSpacedApart(List<int2> posList)
	{
		//IL_003d: Expected O, but got I
		//IL_0052: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_009f: Expected O, but got I
		//IL_00ba: Expected O, but got I
		//IL_00d5: Expected O, but got I
		//IL_00f2: Expected O, but got I
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0143: Expected O, but got I4
		//IL_014c: Expected O, but got I4
		//IL_01e7: Expected O, but got I4
		//IL_01f6: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rbx_v4+20]");
			int2 int5 = (int2)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
			object obj2 = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
			if ((nint)obj2 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
				object obj4 = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v9+20+v168 @ rdi_v3*8]");
				object obj5 = (nint)0 >> 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v9+20+v168 @ rdi_v3*8]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rbx_v4+20]");
				object obj6 = num - 0;
				object obj7 = obj6 + 1;
				object obj9 = default(object);
				object obj8 = obj5 - obj9;
				object obj10 = obj8 + 1;
				List<int2> list = (List<int2>)(obj10 * obj7);
				bool flag = (nint)list <= 100;
				object obj11 = 1;
				object obj12 = 100;
				if (!flag)
				{
					do
					{
						obj11 = 1 + 1;
						obj12 = 100 * 4;
					}
					while (System.Runtime.CompilerServices.Unsafe.As<List<int2>, UIntPtr>(ref list) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj12));
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+1C]");
				_ = (nint)0 + (nint)1;
				_ = 0;
				int2 obj13 = int5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v9+20+v168 @ rdi_v3*8]");
				if ((nint)obj13 > 0)
				{
					return;
				}
				object obj14 = default(object);
				int2 obj16;
				do
				{
					if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj9) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14))
					{
						object obj15;
						do
						{
							posList.Add(int5);
							obj15 = obj9 + obj11;
						}
						while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj15) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj14));
					}
					int5 = (int2)((object)int5 + obj11);
					obj16 = int5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v9+20+v168 @ rdi_v3*8]");
				}
				while ((nint)obj16 <= 0);
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void EatTile(List<int2> posList)
	{
		//IL_00a2: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		GameManager core = GM.Core;
		Stage stage = core._stage;
		TilingTileset tilingTileset = stage._tilingTileset;
		if ((object)stage._tilingTileset == null || ((UnityEngine.Object)tilingTileset).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		GameManager core2 = GM.Core;
		Stage stage2 = core2._stage;
		TilingTileset tilingTileset2 = stage2._tilingTileset;
		List<SuperMap> maps = tilingTileset2._maps;
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			if ((nint)obj2 < maps._size)
			{
				if ((nint)obj >= maps._size)
				{
					break;
				}
				SuperMap[] items = maps._items;
				bool flag = TilemapUtils.BatchRemoveTileAt(items[obj], posList, "Walls");
				bool flag2 = TilemapUtils.BatchRemoveTileAt(items[obj], posList, "PlayerWall");
				bool flag3 = TilemapUtils.BatchRemoveTileAt(items[obj], posList, "Obstacle");
				bool flag4 = TilemapUtils.BatchRemoveTileAt(items[obj], posList, "FakeWalls");
				bool flag5 = TilemapUtils.BatchRemoveTileAt(items[obj], posList, "Decals");
				bool flag6 = TilemapUtils.BatchRemoveTileAt(items[obj], posList, "Overlay1");
				obj++;
				obj2 = obj;
				continue;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private unsafe void BlackExplosionAt(List<int2> posList)
	{
		//IL_01b5->IL01b5: Incompatible stack heights: 1 vs 0
		int num = 0;
		int num2 = 0;
		Tilemap cellPosition = default(Tilemap);
		Vector2 pos = default(Vector2);
		while (true)
		{
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [posList @ rdx (System.Collections.Generic.List`1<Unity.Mathematics.int2>)+18]");
			if ((nint)num3 >= (nint)0)
			{
				break;
			}
			GameManager core = GM.Core;
			Stage stage = core._stage;
			TilingTileset tilingTileset = stage._tilingTileset;
			List<Tilemap> allLayers = stage._tilingTileset.GetAllLayers();
			if (allLayers._size > 0)
			{
				SuperMap defaultMap = stage._tilingTileset.DefaultMap;
				if ((object)defaultMap != null && ((UnityEngine.Object)defaultMap).m_CachedPtr != (IntPtr)0)
				{
					Tilemap tilemap = allLayers.get_Item(0);
					Tilemap tilemap2 = ((List<Tilemap>)(object)posList).get_Item(num);
					Tilemap tilemap3 = ((List<Tilemap>)(object)posList).get_Item(num);
					bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
					GridLayout.CellToWorld_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref *(Vector3Int*)(&cellPosition), out Vector3 _);
					if (tilingTileset._inverted)
					{
						GameManager core2 = GM.Core;
						PlayerOptionsData config = core2._playerOptions.Config;
						if (!config._003CVisuallyInvertStages_003Ek__BackingField)
						{
						}
					}
					SuperMap defaultMap2 = stage._tilingTileset.DefaultMap;
					SuperMap defaultMap3 = stage._tilingTileset.DefaultMap;
					_particlesManager.EmitParticleAt(pos, 10);
					cellPosition = tilemap2;
				}
			}
			num++;
			num2 = num;
		}
	}

	private unsafe void CreateBlackEmitter()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0060: Expected O, but got I
		//IL_026a: Expected F4, but got I
		//IL_027d: Expected O, but got I4
		//IL_02ac: Expected F4, but got I
		//IL_02bf: Expected O, but got I4
		//IL_02e6: Expected O, but got I4
		//IL_02ff: Expected O, but got Ref
		//IL_0319: Expected native int or pointer, but got O
		//IL_0333: Expected O, but got I
		//IL_0353: Expected O, but got Ref
		//IL_036d: Expected native int or pointer, but got O
		//IL_0387: Expected O, but got I
		//IL_03a7: Expected O, but got Ref
		//IL_03cf: Expected native int or pointer, but got O
		//IL_09ca: Expected O, but got I4
		//IL_03e7: Expected O, but got Ref
		//IL_040e: Expected O, but got I
		//IL_0428: Expected native int or pointer, but got O
		//IL_09e7: Expected O, but got I4
		//IL_045a: Expected O, but got Ref
		//IL_0481: Expected O, but got I
		//IL_049b: Expected native int or pointer, but got O
		//IL_0a21: Expected O, but got I
		//IL_05ee: Expected F4, but got I
		//IL_0601: Expected O, but got I4
		//IL_0630: Expected F4, but got I
		//IL_0643: Expected O, but got I4
		//IL_066a: Expected O, but got I4
		//IL_0683: Expected O, but got Ref
		//IL_069d: Expected native int or pointer, but got O
		//IL_06b7: Expected O, but got I
		//IL_06d7: Expected O, but got Ref
		//IL_06f1: Expected native int or pointer, but got O
		//IL_0a5b: Expected O, but got I
		//IL_0729: Expected O, but got Ref
		//IL_0743: Expected native int or pointer, but got O
		//IL_075d: Expected O, but got I
		//IL_077d: Expected O, but got Ref
		//IL_07a5: Expected native int or pointer, but got O
		//IL_0a95: Expected O, but got I
		//IL_07dd: Expected O, but got Ref
		//IL_0804: Expected O, but got I
		//IL_081e: Expected native int or pointer, but got O
		//IL_0ac7: Expected O, but got I
		//IL_086f: Expected O, but got I
		//IL_08f7: Expected O, but got I
		//IL_096e: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject = base.gameObject;
		_ = 0;
		ParticleEmitterManager particlesManager;
		if (gameObject.TryGetComponent<ParticleEmitterManager>(out System.Runtime.CompilerServices.Unsafe.As<object, ParticleEmitterManager>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 448))))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			particlesManager = (ParticleEmitterManager)0;
		}
		else
		{
			particlesManager = gameObject.AddComponent<ParticleEmitterManager>();
		}
		_particlesManager = particlesManager;
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.Renderer renderer = s_scene._renderer;
			int num = -renderer.pixelHeight;
			ParticleEmitterManager particleEmitterManager = _particlesManager.SetDepth(num);
			ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("vfx");
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"Smoke1");
			}
			else
			{
				int num2 = list._size + 1;
				list._size = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			int version2 = list._version + 1;
			list._version = version2;
			string[] items2 = list._items;
			if (list._size >= items2.Length)
			{
				((List<object>)(object)list).AddWithResize((object)"Smoke2");
			}
			else
			{
				int num3 = list._size + 1;
				list._size = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig._frame = list;
			float2 float5 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			float2 float6 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C4]");
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+40]");
			particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+50]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(0f, 180f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+60]");
			particleSystemConfig._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+70]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
			particleSystemConfig._angleSteps = 16;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(100f, 200f));
			particleSystemConfig._speed = (ParticleSystem.MinMaxCurve?)(object)1;
			ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
			_ = 0;
			_ = 4;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			particleSystemConfig._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(1f, 0f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+A0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+B0]");
			_ = 0;
			particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-68]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
			_ = 0;
			_ = 1082130432;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			particleSystemConfig._frequency = (float?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0.65f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+C0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+D0]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-60]");
			particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-40]");
			_ = 0;
			particleSystemConfig._on = false;
			ParticleSystem pfxEmitter = _particlesManager.CreateEmitter(particleSystemConfig);
			_pfxEmitter2 = pfxEmitter;
			ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("vfx");
			List<string> list2 = new List<string>();
			int version3 = list2._version + 1;
			list2._version = version3;
			string[] items3 = list2._items;
			if (list2._size >= items3.Length)
			{
				((List<object>)(object)list2).AddWithResize((object)"blackDot");
			}
			else
			{
				int num4 = list2._size + 1;
				list2._size = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			particleSystemConfig2._frame = list2;
			float2 float7 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			float2 float8 = base.position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C4]");
			minMaxCurve = new ParticleSystem.MinMaxCurve(0f);
			particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			minMaxCurve = new ParticleSystem.MinMaxCurve(1000f);
			particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+E0]");
			particleSystemConfig2._rotate = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+F0]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(0.65f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+100]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+110]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-38]");
			particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-18]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(0f, 360f));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+120]");
			particleSystemConfig2._angle = (ParticleSystem.MinMaxCurve)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+130]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve10 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
			particleSystemConfig2._angleSteps = 16;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve10, new ParticleSystem.MinMaxCurve(50f, 80f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+140]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+150]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1-10]");
			particleSystemConfig2._speed = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+10]");
			_ = 0;
			ParticleSystem.MinMaxCurve minMaxCurve11 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 352));
			_ = 0;
			_ = 4;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			particleSystemConfig2._quantity = (int?)(object)0;
			_ = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve11, new ParticleSystem.MinMaxCurve(32f, 0f));
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+160]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+170]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+18]");
			particleSystemConfig2._scale = (ParticleSystem.MinMaxCurve?)(object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+38]");
			_ = 0;
			_ = 0;
			_ = 1073741824;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			particleSystemConfig2._frequency = (float?)(object)0;
			particleSystemConfig2._on = false;
			ParticleSystem pfxEmitter2 = _particlesManager.CreateEmitter(particleSystemConfig2);
			_pfxEmitter = pfxEmitter2;
			GravityWellConfig gravityWellConfig = new GravityWellConfig();
			float2 float9 = base.position;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C8]");
			_ = 0;
			_ = 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			gravityWellConfig._x = (float?)(object)0;
			float2 float10 = base.position;
			_ = 0;
			_ = 1;
			gravityWellConfig._power = 1f;
			gravityWellConfig._epsilon = 100f;
			gravityWellConfig._gravity = 40f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1CC]");
			float num5 = 0f + 0.19999999f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rbp_v1+1C0]");
			gravityWellConfig._y = (float?)(object)0;
			GravityWell well = _particlesManager.CreateGravityWell(gravityWellConfig);
			_well = well;
			return;
		}
		throw new NullReferenceException();
	}

	protected override void OnStop()
	{
		_wiggleTween.Kill();
		base.angle = 0f;
	}

	protected void ScreenShake()
	{
		//IL_00b3: Expected I, but got O
		//IL_0133: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		PhaserScene s_scene = ArcadePhysics.s_scene;
		PhaserScene.CameraSet cameras = s_scene.cameras;
		PhaserCamera main = cameras.main;
		if (main.followOffset != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 24f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = 12;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__27_0;
		if (_003C_003Ec._003C_003E9__27_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__27_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -3f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__27_1;
		if (_003C_003Ec._003C_003E9__27_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__27_1 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = 0f;
				followOffset.y = 0f;
			});
		}
		tweenConfig.onComplete = onComplete;
		MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
	}

	private void _003COnUpdate_003Eb__19_0()
	{
		//IL_0068: Expected O, but got I4
		Transform cachedTransform = base._cachedTransform;
		bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 ret);
		float xScale = (float)ret + 0.1f;
		ArcadeSprite arcadeSprite = setScale(xScale, (float?)(object)0);
	}
}
