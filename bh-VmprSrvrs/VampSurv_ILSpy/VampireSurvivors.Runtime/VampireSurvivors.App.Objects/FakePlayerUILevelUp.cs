using System;
using Cpp2ILInjected;
using DG.Tweening;
using I2.Loc;
using TMPro;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Tools;

namespace VampireSurvivors.App.Objects;

public class FakePlayerUILevelUp : GameMonoBehaviour
{
	private SpriteRenderer _ProgressBox;

	private PhaserSprite _ProgressBar;

	private TextMeshPro _PlayerLevelText;

	private int _level;

	private float _value;

	private readonly LocalizedString _playerLevelString;

	private Color _defaultBarColor;

	private void Awake()
	{
		//IL_0012: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12380]");
		_defaultBarColor = (Color)0;
	}

	private unsafe void Update()
	{
		//IL_01ea->IL01ae: Incompatible stack heights: 3 vs 0
		PhaserSprite progressBar = _ProgressBar;
		if ((object)_ProgressBar != null && ((UnityEngine.Object)progressBar).m_CachedPtr != (IntPtr)0)
		{
			float value = _value + 0.1f;
			_value = value;
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
			{
				PhaserSprite progressBar2 = _ProgressBar;
				bool flag = (object)_ProgressBar == null;
				object spriteRenderer = progressBar2._spriteRenderer;
				bool flag2 = (object)progressBar2._spriteRenderer == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdi_v13 (System.Object)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ rdi_v13 (System.Object)+10]");
				Color value2 = default(Color);
				SpriteRenderer.set_color_Injected((IntPtr)0, ref value2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
				float num = _value * 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm6\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ecx,xmm0\"");
				PhaserSprite progressBar3 = _ProgressBar;
				FakePlayerUILevelUp spriteRenderer2 = (FakePlayerUILevelUp)(object)progressBar3._spriteRenderer;
				bool flag4 = ((UnityEngine.Object)spriteRenderer2).m_CachedPtr == (IntPtr)0;
				float value3 = default(float);
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)spriteRenderer2).m_CachedPtr, ref *(Color*)(&value3));
			}
		}
	}

	public unsafe void Init(float xPos, float yPos)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_01e1: Expected O, but got I4
		//IL_0244: Expected O, but got I4
		//IL_034a: Expected I, but got O
		//IL_0421: Expected O, but got I4
		//IL_05e4: Expected O, but got F4
		//IL_0606: Expected I4, but got I8
		//IL_036d->IL036d: Incompatible stack heights: 16 vs 15
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter = gameSessionData._activeCharacter;
				if ((object)gameSessionData._activeCharacter != null)
				{
					_level = activeCharacter._level;
					Camera main = Camera.main;
					Bounds bounds = CameraExtensions.OrthographicBounds(main);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v43 (UnityEngine.Bounds)+10]");
					Vector2 vector = default(Vector2);
					object obj = vector + 0;
					if ((object)GM.Core != null)
					{
						PhaserScene s_scene = ArcadePhysics.s_scene;
						if (ArcadePhysics.s_scene != null && s_scene._renderer != null)
						{
							float num = yPos * 0.01f;
							if ((object)_ProgressBox != null)
							{
								Transform transform = _ProgressBox.transform;
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Vector2 value = default(Vector2);
								Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
								SpriteRenderer spriteRenderer = RenderingExtensions.SetTileMode(_ProgressBox);
								_ProgressBox.size = vector;
								Transform progressBox = (Transform)(object)_ProgressBox;
								bool flag2 = ((UnityEngine.Object)progressBox).m_CachedPtr == (IntPtr)0;
								Renderer.set_sortingOrder_Injected(((UnityEngine.Object)progressBox).m_CachedPtr, 32765);
								Transform transform2 = _ProgressBar.transform;
								float num2 = (float)obj + num;
								float num3 = num2 - 0.049999997f;
								bool flag3 = (object)transform2 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1382 @ rax_v64 (UnityEngine.Transform)+10]");
								bool flag4 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1382 @ rax_v64 (UnityEngine.Transform)+10]");
								Vector2 value2 = default(Vector2);
								Transform.set_position_Injected((IntPtr)0, ref *(Vector3*)(&value2));
								bool flag5 = (object)_ProgressBar == null;
								PhaserSprite phaserSprite = _ProgressBar.setOrigin(0f, (float?)(object)1);
								bool flag6 = (object)_ProgressBar == null;
								PhaserSprite phaserSprite2 = _ProgressBar.setDepth(32766);
								bool flag7 = (object)_ProgressBar == null;
								PhaserSprite phaserSprite3 = _ProgressBar.setScale(0f, (float?)(object)1);
								bool flag8 = (object)_PlayerLevelText == null;
								Transform transform3 = _PlayerLevelText.transform;
								bool flag9 = (object)GM.Core == null;
								PhaserScene s_scene2 = ArcadePhysics.s_scene;
								bool flag10 = ArcadePhysics.s_scene == null;
								bool flag11 = s_scene2._renderer == null;
								bool flag12 = (object)transform3 == null;
								bool flag13 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
								Vector2 value3 = default(Vector2);
								Transform.set_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)(&value3));
								bool flag14 = (object)_PlayerLevelText == null;
								_PlayerLevelText.sortingOrder = 32767;
								UpdateLevelDisplay();
								TweenConfig tweenConfig = new TweenConfig();
								object[] array = new object[1];
								bool flag15 = array == null;
								if ((object)_ProgressBar != null)
								{
									nint num4 = (nint)array;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									object obj2 = default(object);
									bool flag16 = obj2 == null;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								bool flag17 = tweenConfig == null;
								tweenConfig.targets = array;
								bool flag18 = (object)GM.Core == null;
								PhaserScene s_scene3 = ArcadePhysics.s_scene;
								bool flag19 = ArcadePhysics.s_scene == null;
								PhaserScene.Renderer renderer = s_scene3._renderer;
								bool flag20 = s_scene3._renderer == null;
								float num5 = renderer.width * 100f;
								float num6 = num5 - 10f;
								tweenConfig.scaleX = (float?)(object)1;
								object obj3 = UnityEngine.Random.value;
								float num7 = num6 * 1000f;
								tweenConfig.repeat = -1;
								float duration = num7 + 1000f;
								tweenConfig.duration = duration;
								TweenCallback onRepeat = delegate
								{
									int level = _level + 1;
									_level = level;
									UpdateLevelDisplay();
								};
								tweenConfig.onRepeat = onRepeat;
								MultiTargetTween multiTargetTween = Tweens.Add(tweenConfig);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateLevelDisplay()
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected I4, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2DDD]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		LocalizedString localizedString = default(LocalizedString);
		string text = localizedString.ToString();
		int num = this + 64;
		string newValue = ((int*)num)->ToString();
		string text2 = text.Replace("%0", newValue);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
	}

	public FakePlayerUILevelUp()
	{
		//IL_0058: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2DDE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_playerLevelString = "lang/ingame_level";
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v5 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CInit_003Eb__9_0()
	{
		int level = _level + 1;
		_level = level;
		UpdateLevelDisplay();
	}
}
