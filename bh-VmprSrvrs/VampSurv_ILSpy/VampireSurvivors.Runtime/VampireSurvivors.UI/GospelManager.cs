using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class GospelManager : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__15_7;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CBuildFireworks_003Eb__15_7()
		{
			FireworksManager.Clear();
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public int i;

		public GospelManager _003C_003E4__this;

		internal void _003CPlayFirework_003Eb__0()
		{
			GospelManager gospelManager = _003C_003E4__this;
			RectTransform component = _003C_003E4__this.GetComponent<RectTransform>();
			ParticleSystem particleSystem = FireworksManager.CreateRandomFirework(i, gospelManager._frames, component, 0.6f);
		}
	}

	private Image _Clap;

	private UISpriteAnimation _ClapInAnim;

	private UISpriteAnimation _ClapOutAnim;

	private ParticleEmitterManager _ParticleEmitter;

	private Image _Panel;

	private int _claps;

	private int _maxClaps;

	private Action _callback;

	private List<ParticleSystem> _particles;

	private GravityWell _gravityWell;

	private PlayerOptions _playerOptions;

	private List<string> _frames;

	private void Construct(PlayerOptions player)
	{
		_playerOptions = player;
	}

	public void PlayEffect(Action cb = null)
	{
		//IL_0048: Expected O, but got I4
		//IL_0092: Expected O, but got I4
		_maxClaps = 7;
		_claps = 0;
		Clap();
		_callback = cb;
		PlayerOptionsData config = _playerOptions.Config;
		SoundManager.StopMusic(config._003CSelectedBGM_003Ek__BackingField);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Piano, soundConfig, 0f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.CFFX, soundConfig2, 0f, 10, time);
	}

	private void Clap()
	{
		//IL_010e: Expected O, but got I4
		//IL_012c: Expected O, but got I
		//IL_014f: Expected O, but got I4
		//IL_01b7: Expected F4, but got I4
		//IL_0196: Expected O, but got I8
		int num = default(int);
		List<Sprite> animationFrames = SpriteManager.GetAnimationFrames("clap", 1, 6, "backgroundX", num);
		UISpriteAnimation clapInAnim = _ClapInAnim;
		clapInAnim.sprites = animationFrames;
		List<Sprite> animationFrames2 = SpriteManager.GetAnimationFrames("clap", 6, 11, "backgroundX", num);
		UISpriteAnimation clapOutAnim = _ClapOutAnim;
		clapOutAnim.sprites = animationFrames2;
		if (_particles == null)
		{
			BuildFireworks();
		}
		GameObject gameObject = _Clap.gameObject;
		gameObject.SetActive(value: true);
		_ClapInAnim.Play();
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		float? num2 = (float?)(object)1;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			num2 = (float?)(object)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v463 @ rax_v18 (should have been resolved before IL gen)");
		float detune = -1f * 100f;
		soundConfig.Detune = detune;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.Clap, soundConfig, 0f, 10, num);
		UISpriteAnimation clapInAnim2 = _ClapInAnim;
		Action onComplete = delegate
		{
			//IL_00c6: Expected O, but got I
			//IL_0274: Expected O, but got I
			//IL_012f: Expected O, but got I8
			//IL_016d: Expected O, but got I8
			List<ParticleSystem> particles = _particles;
			if (_claps < particles._size)
			{
				List<ParticleSystem> particles2 = _particles;
				int claps = _claps;
				if (_claps < particles2._size)
				{
					ParticleSystem[] items = particles2._items;
					Transform transform = items[claps].transform;
					Transform parent = transform.parent;
					RectTransform component = parent.GetComponent<RectTransform>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					bool flag2 = (nint)0 != 0;
					Component component2 = parent;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj2 == null)
						{
							MissingMethodException ex2 = new MissingMethodException();
							throw ex2;
						}
						component2 = (Component)6573110936L;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v589 @ rax_v31 (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
						if (obj3 == null)
						{
							MissingMethodException ex3 = new MissingMethodException();
							throw ex3;
						}
						component2 = (Component)6573110936L;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v613 @ rax_v34 (should have been resolved before IL gen)");
					Vector2 anchoredPosition = default(Vector2);
					component.anchoredPosition = anchoredPosition;
					List<ParticleSystem> particles3 = _particles;
					int claps2 = _claps;
					if (_claps < particles3._size)
					{
						ParticleSystem[] items2 = particles3._items;
						items2[claps2].Emit(100);
						goto IL_01ec;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			goto IL_01ec;
			IL_01ec:
			_ClapOutAnim.Play();
			UISpriteAnimation clapOutAnim2 = _ClapOutAnim;
			Action onComplete2 = delegate
			{
				if (++_claps >= _maxClaps)
				{
					GameObject gameObject2 = _Clap.gameObject;
					gameObject2.SetActive(value: false);
					Sequence sequence = DOTween.Sequence();
					Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 3f);
					TweenCallback tweenCallback = delegate
					{
						if (_callback != null)
						{
							Action callback = _callback;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
						}
					};
					Tween t;
					object message;
					if (sequence != null)
					{
						if (((Tween)sequence)._003Cactive_003Ek__BackingField)
						{
							if (!((Tween)sequence).creationLocked)
							{
								if (tweenCallback != null)
								{
									Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
								}
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							t = null;
							message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							t = null;
							message = "You can't add elements to an inactive/killed Sequence";
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						t = null;
						message = "You can't add elements to a NULL Sequence";
					}
					Debugger.LogWarning(message, t);
				}
				else
				{
					Clap();
				}
			};
			clapOutAnim2._onComplete = onComplete2;
		};
		clapInAnim2._onComplete = onComplete;
	}

	private void BuildFireworks()
	{
		ParticleEmitterManager particleEmitter = _ParticleEmitter;
		particleEmitter._GlobalClockKey = "Root";
		List<ParticleSystem> particles = new List<ParticleSystem>();
		_particles = particles;
		GravityWellConfig gravityWellConfig = new GravityWellConfig();
		gravityWellConfig._power = 0.6f;
		gravityWellConfig._epsilon = 15.000001f;
		gravityWellConfig._gravity = 90f;
		gravityWellConfig._usePauseSystem = false;
		RectTransform component = GetComponent<RectTransform>();
		Vector2 viewportPosition = FireworksManager.GetViewportPosition(component);
		GravityWell gravityWell = FireworksManager.CreateGravityWell(viewportPosition, gravityWellConfig);
		float[] array = new float[7] { 0.1f, 0.3f, 0.5f, 0.7f, 0.9f, 1.2f, 1.4f };
		Sequence sequence = DOTween.Sequence();
		Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, array[0]);
		TweenCallback tweenCallback = delegate
		{
			PlayFirework(0);
		};
		object message;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback != null)
					{
						Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
					}
					goto IL_0245;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message);
		goto IL_0245;
		IL_0545:
		float interval = array[3] - array[2];
		Sequence sequence4 = TweenSettingsExtensions.AppendInterval(sequence, interval);
		TweenCallback tweenCallback2 = delegate
		{
			PlayFirework(3);
		};
		object message2;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback2 != null)
					{
						Sequence sequence5 = Sequence.DoInsertCallback(sequence, tweenCallback2, ((Tween)sequence).duration);
					}
					goto IL_06c5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message2 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message2 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message2);
		goto IL_06c5;
		IL_0b45:
		Sequence sequence6 = TweenSettingsExtensions.AppendInterval(sequence, 3f);
		TweenCallback tweenCallback3 = _003C_003Ec._003C_003E9__15_7;
		if (_003C_003Ec._003C_003E9__15_7 == null)
		{
			tweenCallback3 = (_003C_003Ec._003C_003E9__15_7 = delegate
			{
				FireworksManager.Clear();
			});
		}
		Tween t;
		object message3;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback3 != null)
					{
						Sequence sequence7 = Sequence.DoInsertCallback(sequence, tweenCallback3, ((Tween)sequence).duration);
					}
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t = null;
				message3 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t = null;
				message3 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t = null;
			message3 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message3, t);
		return;
		IL_03c5:
		float interval2 = array[2] - array[1];
		Sequence sequence8 = TweenSettingsExtensions.AppendInterval(sequence, interval2);
		TweenCallback tweenCallback4 = delegate
		{
			PlayFirework(2);
		};
		object message4;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback4 != null)
					{
						Sequence sequence9 = Sequence.DoInsertCallback(sequence, tweenCallback4, ((Tween)sequence).duration);
					}
					goto IL_0545;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message4 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message4 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message4 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message4);
		goto IL_0545;
		IL_0245:
		float interval3 = array[1] - array[0];
		Sequence sequence10 = TweenSettingsExtensions.AppendInterval(sequence, interval3);
		TweenCallback tweenCallback5 = delegate
		{
			PlayFirework(1);
		};
		object message5;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback5 != null)
					{
						Sequence sequence11 = Sequence.DoInsertCallback(sequence, tweenCallback5, ((Tween)sequence).duration);
					}
					goto IL_03c5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message5 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message5 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message5 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message5);
		goto IL_03c5;
		IL_0845:
		float interval4 = array[5] - array[4];
		Sequence sequence12 = TweenSettingsExtensions.AppendInterval(sequence, interval4);
		TweenCallback tweenCallback6 = delegate
		{
			PlayFirework(5);
		};
		object message6;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback6 != null)
					{
						Sequence sequence13 = Sequence.DoInsertCallback(sequence, tweenCallback6, ((Tween)sequence).duration);
					}
					goto IL_09c5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message6 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message6 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message6 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message6);
		goto IL_09c5;
		IL_09c5:
		float interval5 = array[6] - array[5];
		Sequence sequence14 = TweenSettingsExtensions.AppendInterval(sequence, interval5);
		TweenCallback tweenCallback7 = delegate
		{
			PlayFirework(6);
		};
		object message7;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback7 != null)
					{
						Sequence sequence15 = Sequence.DoInsertCallback(sequence, tweenCallback7, ((Tween)sequence).duration);
					}
					goto IL_0b45;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message7 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message7 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message7 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message7);
		goto IL_0b45;
		IL_06c5:
		float interval6 = array[4] - array[3];
		Sequence sequence16 = TweenSettingsExtensions.AppendInterval(sequence, interval6);
		TweenCallback tweenCallback8 = delegate
		{
			PlayFirework(4);
		};
		object message8;
		if (sequence != null)
		{
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					if (tweenCallback8 != null)
					{
						Sequence sequence17 = Sequence.DoInsertCallback(sequence, tweenCallback8, ((Tween)sequence).duration);
					}
					goto IL_0845;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message8 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				message8 = "You can't add elements to an inactive/killed Sequence";
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			message8 = "You can't add elements to a NULL Sequence";
		}
		Debugger.LogWarning(message8);
		goto IL_0845;
	}

	private void SetRandomPosition(ParticleSystem ps)
	{
		//IL_0046: Expected O, but got I
		//IL_011a: Expected O, but got I
		//IL_00af: Expected O, but got I8
		//IL_00ed: Expected O, but got I8
		Transform transform = ps.transform;
		Transform parent = transform.parent;
		RectTransform component = parent.GetComponent<RectTransform>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		bool flag = (nint)0 != 0;
		Component component2 = parent;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj == null)
			{
				MissingMethodException ex = new MissingMethodException();
				throw ex;
			}
			component2 = (Component)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v188 @ rax_v14 (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
			if (obj2 == null)
			{
				MissingMethodException ex2 = new MissingMethodException();
				throw ex2;
			}
			component2 = (Component)6573110936L;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v215 @ rax_v17 (should have been resolved before IL gen)");
		Vector2 anchoredPosition = default(Vector2);
		component.anchoredPosition = anchoredPosition;
	}

	private void PlayFirework(int i)
	{
		_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass17_0();
		CS_0024_003C_003E8__locals8.i = i;
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(_Panel, 0.4f, 0.03f);
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
				if ((nint)0 == 0)
				{
					_ = 1;
					_ = 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
					if ((nint)0 == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+A0]");
						_ = 0;
					}
					TweenCallback tweenCallback = delegate
					{
						GospelManager gospelManager = CS_0024_003C_003E8__locals8._003C_003E4__this;
						RectTransform component = CS_0024_003C_003E8__locals8._003C_003E4__this.GetComponent<RectTransform>();
						ParticleSystem particleSystem = FireworksManager.CreateRandomFirework(CS_0024_003C_003E8__locals8.i, gospelManager._frames, component, 0.6f);
					};
					tweenCallback2 = tweenCallback;
					goto IL_0128;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			GospelManager gospelManager = CS_0024_003C_003E8__locals8._003C_003E4__this;
			RectTransform component = CS_0024_003C_003E8__locals8._003C_003E4__this.GetComponent<RectTransform>();
			ParticleSystem particleSystem = FireworksManager.CreateRandomFirework(CS_0024_003C_003E8__locals8.i, gospelManager._frames, component, 0.6f);
		};
		bool flag = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		if (!flag)
		{
			goto IL_0128;
		}
		return;
		IL_0128:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rax_v5 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
	}

	public GospelManager()
	{
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxYellow");
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxPink");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxRed");
		}
		else
		{
			int size3 = list._size + 1;
			list._size = size3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"PfxGreen");
		}
		else
		{
			int size4 = list._size + 1;
			list._size = size4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		_frames = list;
	}

	private void _003CClap_003Eb__14_0()
	{
		//IL_00c6: Expected O, but got I
		//IL_0274: Expected O, but got I
		//IL_012f: Expected O, but got I8
		//IL_016d: Expected O, but got I8
		List<ParticleSystem> particles = _particles;
		if (_claps < particles._size)
		{
			List<ParticleSystem> particles2 = _particles;
			int claps = _claps;
			if (_claps < particles2._size)
			{
				ParticleSystem[] items = particles2._items;
				Transform transform = items[claps].transform;
				Transform parent = transform.parent;
				RectTransform component = parent.GetComponent<RectTransform>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				bool flag = (nint)0 != 0;
				Component component2 = parent;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj == null)
					{
						MissingMethodException ex = new MissingMethodException();
						throw ex;
					}
					component2 = (Component)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v589 @ rax_v31 (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
				if ((nint)0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
					if (obj2 == null)
					{
						MissingMethodException ex2 = new MissingMethodException();
						throw ex2;
					}
					component2 = (Component)6573110936L;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v613 @ rax_v34 (should have been resolved before IL gen)");
				Vector2 anchoredPosition = default(Vector2);
				component.anchoredPosition = anchoredPosition;
				List<ParticleSystem> particles3 = _particles;
				int claps2 = _claps;
				if (_claps < particles3._size)
				{
					ParticleSystem[] items2 = particles3._items;
					items2[claps2].Emit(100);
					goto IL_01ec;
				}
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			return;
		}
		goto IL_01ec;
		IL_01ec:
		_ClapOutAnim.Play();
		UISpriteAnimation clapOutAnim = _ClapOutAnim;
		Action onComplete = delegate
		{
			if (++_claps >= _maxClaps)
			{
				GameObject gameObject = _Clap.gameObject;
				gameObject.SetActive(value: false);
				Sequence sequence = DOTween.Sequence();
				Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 3f);
				TweenCallback tweenCallback = delegate
				{
					if (_callback != null)
					{
						Action callback = _callback;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
				};
				Tween t;
				object message;
				if (sequence != null)
				{
					if (((Tween)sequence)._003Cactive_003Ek__BackingField)
					{
						if (!((Tween)sequence).creationLocked)
						{
							if (tweenCallback != null)
							{
								Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
							}
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						t = null;
						message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						t = null;
						message = "You can't add elements to an inactive/killed Sequence";
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					t = null;
					message = "You can't add elements to a NULL Sequence";
				}
				Debugger.LogWarning(message, t);
			}
			else
			{
				Clap();
			}
		};
		clapOutAnim._onComplete = onComplete;
	}

	private void _003CClap_003Eb__14_1()
	{
		if (++_claps >= _maxClaps)
		{
			GameObject gameObject = _Clap.gameObject;
			gameObject.SetActive(value: false);
			Sequence sequence = DOTween.Sequence();
			Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 3f);
			TweenCallback tweenCallback = delegate
			{
				if (_callback != null)
				{
					Action callback = _callback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			Tween t;
			object message;
			if (sequence != null)
			{
				if (((Tween)sequence)._003Cactive_003Ek__BackingField)
				{
					if (!((Tween)sequence).creationLocked)
					{
						if (tweenCallback != null)
						{
							Sequence sequence3 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
						}
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					t = null;
					message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					t = null;
					message = "You can't add elements to an inactive/killed Sequence";
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t = null;
				message = "You can't add elements to a NULL Sequence";
			}
			Debugger.LogWarning(message, t);
		}
		else
		{
			Clap();
		}
	}

	private void _003CClap_003Eb__14_2()
	{
		if (_callback != null)
		{
			Action callback = _callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v11.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private void _003CBuildFireworks_003Eb__15_0()
	{
		PlayFirework(0);
	}

	private void _003CBuildFireworks_003Eb__15_1()
	{
		PlayFirework(1);
	}

	private void _003CBuildFireworks_003Eb__15_2()
	{
		PlayFirework(2);
	}

	private void _003CBuildFireworks_003Eb__15_3()
	{
		PlayFirework(3);
	}

	private void _003CBuildFireworks_003Eb__15_4()
	{
		PlayFirework(4);
	}

	private void _003CBuildFireworks_003Eb__15_5()
	{
		PlayFirework(5);
	}

	private void _003CBuildFireworks_003Eb__15_6()
	{
		PlayFirework(6);
	}
}
