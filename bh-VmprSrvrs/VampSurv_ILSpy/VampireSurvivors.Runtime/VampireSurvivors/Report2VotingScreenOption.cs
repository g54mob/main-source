using System;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;

namespace VampireSurvivors;

public class Report2VotingScreenOption : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__10_0;

		public static TweenCallback _003C_003E9__10_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CScreenShake_003Eb__10_0()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = -2f;
		}

		internal void _003CScreenShake_003Eb__10_1()
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			PhaserScene.CameraSet cameras = s_scene.cameras;
			PhaserCamera main = cameras.main;
			PhaserScene.BoxedVector2 followOffset = main.followOffset;
			followOffset.x = 0f;
			followOffset.y = 0f;
		}
	}

	private SpriteRenderer _nineSliceSprite;

	private SpriteRenderer _maskSprite;

	private SpriteMask _spriteMask;

	private SpriteRenderer _enemySprite;

	private SpriteRenderer _voteSprite;

	private MultiTargetTween _voteTween;

	private MultiTargetTween _screenShakeTween;

	private void Awake()
	{
		Sprite sprite = SpriteManager.GetSprite("PlayerBanner_9slice", "vfx");
		_nineSliceSprite.sprite = sprite;
		Vector2 size = default(Vector2);
		_nineSliceSprite.size = size;
		Sprite sprite2 = SpriteManager.GetSprite("WhiteDot", "vfx");
		_maskSprite.sprite = sprite2;
		Sprite sprite3 = SpriteManager.GetSprite("WhiteDot", "vfx");
		_spriteMask.sprite = sprite3;
		Sprite sprite4 = SpriteManager.GetSprite("VoteX", "vfx");
		_voteSprite.sprite = sprite4;
	}

	public unsafe void SetVoteTargetSprite(Sprite sprite, Color tint)
	{
		if ((object)_enemySprite != null)
		{
			_enemySprite.sprite = sprite;
			SpriteRenderer enemySprite = _enemySprite;
			if ((object)_enemySprite != null)
			{
				bool flag = ((UnityEngine.Object)enemySprite).m_CachedPtr == (IntPtr)0;
				float value = default(float);
				SpriteRenderer.set_color_Injected(((UnityEngine.Object)enemySprite).m_CachedPtr, ref *(Color*)(&value));
				SpriteRenderer component = GetComponent<SpriteRenderer>();
				bool flag2 = (object)component == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v21 (UnityEngine.SpriteRenderer)+10]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rax_v21 (UnityEngine.SpriteRenderer)+10]");
				Color value2 = default(Color);
				SpriteRenderer.set_color_Injected((IntPtr)0, ref value2);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void AddVote()
	{
		//IL_00ba: Expected I, but got O
		//IL_0124: Expected I, but got O
		//IL_0188: Expected O, but got I4
		//IL_01a4: Expected O, but got I4
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_voteSprite, 0f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetScale(_voteSprite, 75f);
		_voteSprite.enabled = true;
		if (_voteTween != null)
		{
			_voteTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[2];
		if ((object)_voteSprite != null)
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
		Transform transform = _voteSprite.transform;
		if ((object)transform != null)
		{
			nint num2 = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj2 = default(object);
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
				throw ex2;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.ease = Ease.InExpo;
		tweenConfig.alpha = (float?)(object)1;
		tweenConfig.duration = 500f;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onComplete = delegate
		{
			ScreenShake(12);
			SpriteRenderer component = GetComponent<SpriteRenderer>();
			bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
			Color value = default(Color);
			SpriteRenderer.set_color_Injected(((UnityEngine.Object)component).m_CachedPtr, ref value);
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween voteTween = Tweens.Add(tweenConfig);
		_voteTween = voteTween;
	}

	public void ScreenShake(int repeats = 6)
	{
		//IL_00e2: Expected I, but got O
		//IL_0161: Expected O, but got I4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (!config._003CScreenShakeEnabled_003Ek__BackingField)
		{
			return;
		}
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
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
		tweenConfig.duration = 16f;
		tweenConfig.yoyo = true;
		tweenConfig.repeat = repeats;
		tweenConfig.x = (float?)(object)1;
		TweenCallback onStart = _003C_003Ec._003C_003E9__10_0;
		if (_003C_003Ec._003C_003E9__10_0 == null)
		{
			onStart = (_003C_003Ec._003C_003E9__10_0 = delegate
			{
				PhaserScene s_scene2 = ArcadePhysics.s_scene;
				PhaserScene.CameraSet cameras2 = s_scene2.cameras;
				PhaserCamera main2 = cameras2.main;
				PhaserScene.BoxedVector2 followOffset = main2.followOffset;
				followOffset.x = -2f;
			});
		}
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = _003C_003Ec._003C_003E9__10_1;
		if (_003C_003Ec._003C_003E9__10_1 == null)
		{
			onComplete = (_003C_003Ec._003C_003E9__10_1 = delegate
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
		MultiTargetTween screenShakeTween = Tweens.Add(tweenConfig);
		_screenShakeTween = screenShakeTween;
	}

	public void ClearVotes()
	{
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)component).m_CachedPtr, ref value);
	}

	public void Cleanup()
	{
		if (_voteTween != null)
		{
			_voteTween.Kill();
		}
		_voteTween = null;
		if (_screenShakeTween != null)
		{
			_screenShakeTween.Kill();
		}
		_screenShakeTween = null;
	}

	public Report2VotingScreenOption()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private void _003CAddVote_003Eb__9_0()
	{
		ScreenShake(12);
		SpriteRenderer component = GetComponent<SpriteRenderer>();
		bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Color value = default(Color);
		SpriteRenderer.set_color_Injected(((UnityEngine.Object)component).m_CachedPtr, ref value);
	}
}
