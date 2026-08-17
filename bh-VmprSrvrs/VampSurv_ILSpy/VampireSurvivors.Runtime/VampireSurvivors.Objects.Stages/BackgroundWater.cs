using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering.Universal;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Graphics.RenderPass;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Characters.Enemies;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.Objects.Stages;

public class BackgroundWater : BackgroundManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Predicate<ScriptableRendererFeature> _003C_003E9__18_0;

		public static TweenCallback _003C_003E9__26_6;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal unsafe bool _003CInitFishEye_003Eb__18_0(ScriptableRendererFeature f)
		{
			//IL_0135: Expected I4, but got O
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected Ref, but got Unknown
			//IL_00f2: Expected I8, but got I4
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected Ref, but got Unknown
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3E0F]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			if ((object)f != null)
			{
				string name = ((UnityEngine.Object)f).GetName();
				object obj = "FishEye";
				if ((object)name != "FishEye")
				{
					if (name != null && "FishEye" != null)
					{
						int stringLength = name._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2+10]");
						if ((nint)stringLength == 0)
						{
							ref byte first = ref *(byte*)(name + 20);
							ulong length = (ulong)(name._stringLength + name._stringLength);
							return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("FishEye" + 20), length);
						}
					}
					return false;
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal void _003CSendToHiddenGround_003Eb__26_6()
		{
			GameManager core = GM.Core;
			PlayerOptions playerOptions = core._playerOptions;
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
			object obj = default(object);
			if (obj == null)
			{
				GameManager core2 = GM.Core;
				PlayerOptions playerOptions2 = core2._playerOptions;
				PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
			}
			GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public float intensity;

		public BackgroundWater _003C_003E4__this;

		public float minute;

		public float moonTime;

		internal float _003CStartEclipse_003Eb__0()
		{
			return intensity;
		}

		internal void _003CStartEclipse_003Eb__1(float x)
		{
			intensity = x;
		}

		internal void _003CStartEclipse_003Eb__2()
		{
			BackgroundWater backgroundWater = _003C_003E4__this;
			FishEyeRenderFeature fishEyeRenderFeature = backgroundWater._fishEyeRenderFeature;
			fishEyeRenderFeature.passMaterial.SetFloatImpl(Intensity, intensity);
		}

		internal void _003CStartEclipse_003Eb__3()
		{
			if (Stage.HasValidStageXCharacters())
			{
				_003C_003E4__this.Cry();
			}
		}

		internal void _003CStartEclipse_003Eb__4()
		{
			//IL_018e: Expected O, but got I4
			//IL_01c9: Expected O, but got I4
			//IL_01d2: Expected F4, but got I4
			if (SoundManager._003CCurrentBgm_003Ek__BackingField != BgmType.BGM_Water)
			{
				return;
			}
			GameManager core = GM.Core;
			PlayerOptionsData config = core._playerOptions.Config;
			if (config._003CSelectedBGMMod_003Ek__BackingField == BgmModType.Normal)
			{
				_003C_003Ec__DisplayClass24_1 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass24_1();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D20");
				SoundManager.SoundConfig soundConfig = default(SoundManager.SoundConfig);
				CS_0024_003C_003E8__locals2.soundConfig = soundConfig;
				float num = moonTime * minute;
				BackgroundWater backgroundWater = _003C_003E4__this;
				float num2 = num * 13f;
				float duration = num2 * 0.001f;
				Sequence waterBgmTween = DOTween.Sequence();
				backgroundWater._waterBgmTween = waterBgmTween;
				BackgroundWater backgroundWater2 = _003C_003E4__this;
				DOGetter<float> getter = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter = null;
				float x = default(float);
				((_003C_003Ec__DisplayClass24_1)(object)dOSetter)._003CStartEclipse_003Eb__6(x);
				TweenerCore<float, float, FloatOptions> t = DOTween.To(getter, dOSetter, 1.125f, duration);
				bool flag = TweenSettingsExtensions.ValidateAddToSequence(backgroundWater2._waterBgmTween, (Tween)t, false);
				bool flag2 = !flag;
				object obj = 0;
				float num3 = 1.125f;
				if (!flag2)
				{
					Sequence sequence = Sequence.DoInsert(backgroundWater2._waterBgmTween, (Tween)t, 0f);
					obj = 0;
					num3 = 0f;
				}
				BackgroundWater backgroundWater3 = _003C_003E4__this;
				DOGetter<float> getter2 = null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
				DOSetter<float> dOSetter2 = null;
				((_003C_003Ec__DisplayClass24_1)(object)dOSetter2)._003CStartEclipse_003Eb__8(x);
				TweenerCore<float, float, FloatOptions> t2 = DOTween.To(getter2, dOSetter2, -1000f, duration);
				if (TweenSettingsExtensions.ValidateAddToSequence(backgroundWater3._waterBgmTween, (Tween)t2, false))
				{
					Sequence sequence2 = Sequence.DoInsert(backgroundWater3._waterBgmTween, (Tween)t2, 0f);
				}
				BackgroundWater backgroundWater4 = _003C_003E4__this;
				Sequence waterBgmTween2 = backgroundWater4._waterBgmTween;
				TweenCallback onUpdate = delegate
				{
					SoundManager.UpdateCurrentMusicWithConfig(CS_0024_003C_003E8__locals2.soundConfig);
				};
				if (backgroundWater4._waterBgmTween != null && ((Tween)waterBgmTween2)._003Cactive_003Ek__BackingField)
				{
					waterBgmTween2.onUpdate = onUpdate;
				}
				BackgroundWater backgroundWater5 = _003C_003E4__this;
				Sequence sequence3 = VampireSurvivors.Tools.TweenExtensions.SetGameId(backgroundWater5._waterBgmTween);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass24_1
	{
		public SoundManager.SoundConfig soundConfig;

		internal float _003CStartEclipse_003Eb__5()
		{
			SoundManager.SoundConfig soundConfig = this.soundConfig;
			return soundConfig.Rate;
		}

		internal void _003CStartEclipse_003Eb__6(float x)
		{
			SoundManager.SoundConfig soundConfig = this.soundConfig;
			soundConfig.Rate = x;
		}

		internal float _003CStartEclipse_003Eb__7()
		{
			SoundManager.SoundConfig soundConfig = this.soundConfig;
			return soundConfig.Detune;
		}

		internal void _003CStartEclipse_003Eb__8(float x)
		{
			SoundManager.SoundConfig soundConfig = this.soundConfig;
			soundConfig.Detune = x;
		}

		internal void _003CStartEclipse_003Eb__9()
		{
			SoundManager.UpdateCurrentMusicWithConfig(soundConfig);
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public float intensity;

		public BackgroundWater _003C_003E4__this;

		public float radius;

		internal float _003CSendToHiddenGround_003Eb__0()
		{
			return intensity;
		}

		internal void _003CSendToHiddenGround_003Eb__1(float x)
		{
			intensity = x;
		}

		internal void _003CSendToHiddenGround_003Eb__2()
		{
			BackgroundWater backgroundWater = _003C_003E4__this;
			FishEyeRenderFeature fishEyeRenderFeature = backgroundWater._fishEyeRenderFeature;
			fishEyeRenderFeature.passMaterial.SetFloatImpl(Intensity, intensity);
		}

		internal float _003CSendToHiddenGround_003Eb__3()
		{
			return radius;
		}

		internal void _003CSendToHiddenGround_003Eb__4(float x)
		{
			radius = x;
		}

		internal void _003CSendToHiddenGround_003Eb__5()
		{
			BackgroundWater backgroundWater = _003C_003E4__this;
			FishEyeRenderFeature fishEyeRenderFeature = backgroundWater._fishEyeRenderFeature;
			fishEyeRenderFeature.passMaterial.SetFloatImpl(Radius, radius);
		}

		internal void _003CSendToHiddenGround_003Eb__7()
		{
			//IL_00dc: Expected I8, but got O
			//IL_00f1: Expected O, but got I
			//IL_0099: Expected O, but got I8
			//IL_00c0: Expected O, but got I
			GameManager core = GM.Core;
			if (!core._multiplayer.IsOnlineMultiplayer)
			{
				_003C_003E4__this.TransitionToHolyForbidden();
			}
			else if (GM.Core.IsStageHost)
			{
				long num = (long)OnlineStageManager._instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v3 (System.Int64)+88]");
				object obj = 0;
				(string, object)[] array = Array.Empty<(string, object)>();
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v64 @ r10_v2+1E8] (should have been resolved before IL gen)");
				Action<long> action = null;
				((OnlineStageManager)(object)action).TransitionToHolyForbidden(num);
				long startingOnlineClientFrame = ((OnlineStageManager)num).GetStartingOnlineClientFrame();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v3 (System.Int64)+78]");
				bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
			}
		}
	}

	private sealed class _003CInitFishEye_003Ed__18(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BackgroundWater _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_02e3: Expected I4, but got I8
			//IL_0539: Expected I4, but got O
			//IL_034d: Expected O, but got Ref
			//IL_03b6: Expected O, but got Ref
			//IL_00f8: Expected I, but got O
			//IL_0106: Expected I, but got O
			//IL_0116: Expected O, but got I
			//IL_0196: Expected O, but got I4
			//IL_0152: Expected O, but got I
			//IL_0188: Expected O, but got I4
			BackgroundWater backgroundWater = _003C_003E4__this;
			ScriptableRendererFeature scriptableRendererFeature;
			ScriptableRendererFeature fishEyeRenderFeature;
			object obj3;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				GameManager core = GM.Core;
				if ((object)GM.Core != null)
				{
					Renderer2DData renderer2DData = core._Renderer2DData;
					if ((object)core._Renderer2DData != null)
					{
						Predicate<ScriptableRendererFeature> match = _003C_003Ec._003C_003E9__18_0;
						if (_003C_003Ec._003C_003E9__18_0 == null)
						{
							match = (_003C_003Ec._003C_003E9__18_0 = delegate(ScriptableRendererFeature f)
							{
								//IL_0135: Expected I4, but got O
								//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
								//IL_00db: Expected Ref, but got Unknown
								//IL_00f2: Expected I8, but got I4
								//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
								//IL_0101: Expected Ref, but got Unknown
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3E0F]");
								if ((nint)0 == 0)
								{
									_ = 1;
								}
								if ((object)f == null)
								{
									NullReferenceException ex2 = new NullReferenceException();
									return (byte)(int)ex2 != 0;
								}
								string name = ((UnityEngine.Object)f).GetName();
								object obj5 = "FishEye";
								if ((object)name != "FishEye")
								{
									if (name != null && "FishEye" != null)
									{
										int stringLength = name._stringLength;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rdx_v2+10]");
										if ((nint)stringLength == 0)
										{
											ref byte first = ref *(byte*)(name + 20);
											ulong length = (ulong)(name._stringLength + name._stringLength);
											return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("FishEye" + 20), length);
										}
									}
									return false;
								}
								return true;
							});
						}
						if (((ScriptableRendererData)renderer2DData).m_RendererFeatures != null)
						{
							scriptableRendererFeature = ((ScriptableRendererData)renderer2DData).m_RendererFeatures.Find(match);
							if ((object)_003C_003E4__this != null)
							{
								bool flag = (object)scriptableRendererFeature == null;
								fishEyeRenderFeature = scriptableRendererFeature;
								if (flag)
								{
									goto IL_05ba;
								}
								nint num = (nint)scriptableRendererFeature;
								nint num2 = (nint)typeof(FishEyeRenderFeature);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v680 @ rdx_v30 (Il2CppClass<VampireSurvivors.Graphics.RenderPass.FishEyeRenderFeature>)+130]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ r9_v11 (Il2CppClass<UnityEngine.Rendering.Universal.ScriptableRendererFeature>)+130]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v680 @ rdx_v30 (Il2CppClass<VampireSurvivors.Graphics.RenderPass.FishEyeRenderFeature>)+130]");
								if (num3 >= 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ r9_v11 (Il2CppClass<UnityEngine.Rendering.Universal.ScriptableRendererFeature>)+C8]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v754 @ rax_v66+FFFFFFF8+v681 @ rax_v61*8]");
									if (0 == (nint)typeof(FishEyeRenderFeature))
									{
										obj3 = 1;
										goto IL_05cc;
									}
								}
								obj3 = 0;
								goto IL_05cc;
							}
						}
					}
				}
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_051d;
				}
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					FishEyeRenderFeature fishEyeRenderFeature2 = backgroundWater._fishEyeRenderFeature;
					if ((object)backgroundWater._fishEyeRenderFeature != null && (object)fishEyeRenderFeature2.passMaterial != null)
					{
						object obj4 = default(object);
						fishEyeRenderFeature2.passMaterial.SetVector(TexSize, (Vector4)(&obj4));
						FishEyeRenderFeature fishEyeRenderFeature3 = backgroundWater._fishEyeRenderFeature;
						if ((object)backgroundWater._fishEyeRenderFeature != null && (object)fishEyeRenderFeature3.passMaterial != null)
						{
							fishEyeRenderFeature3.passMaterial.SetVector(Center, (Vector4)(&obj4));
							FishEyeRenderFeature fishEyeRenderFeature4 = backgroundWater._fishEyeRenderFeature;
							if ((object)backgroundWater._fishEyeRenderFeature != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rsi_v1 (VampireSurvivors.Objects.Stages.BackgroundWater)+40]");
								float num4 = 0f * 2f;
								if ((object)fishEyeRenderFeature4.passMaterial != null)
								{
									float value = num4 * 0.25f;
									fishEyeRenderFeature4.passMaterial.SetFloatImpl(Radius, value);
									FishEyeRenderFeature fishEyeRenderFeature5 = backgroundWater._fishEyeRenderFeature;
									if ((object)backgroundWater._fishEyeRenderFeature != null && (object)fishEyeRenderFeature5.passMaterial != null)
									{
										fishEyeRenderFeature5.passMaterial.SetFloatImpl(Intensity, 0f);
										FishEyeRenderFeature fishEyeRenderFeature6 = backgroundWater._fishEyeRenderFeature;
										if ((object)backgroundWater._fishEyeRenderFeature != null && (object)fishEyeRenderFeature6.passMaterial != null)
										{
											fishEyeRenderFeature6.passMaterial.SetFloatImpl(Mode, 1f);
											goto IL_051d;
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_052b;
			IL_052b:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_05ba:
			backgroundWater._fishEyeRenderFeature = (FishEyeRenderFeature)fishEyeRenderFeature;
			FishEyeRenderFeature fishEyeRenderFeature7 = backgroundWater._fishEyeRenderFeature;
			if ((object)backgroundWater._fishEyeRenderFeature == null || ((UnityEngine.Object)fishEyeRenderFeature7).m_CachedPtr == (IntPtr)0)
			{
				goto IL_051d;
			}
			FishEyeRenderFeature fishEyeRenderFeature8 = backgroundWater._fishEyeRenderFeature;
			if ((object)backgroundWater._fishEyeRenderFeature != null)
			{
				Material passMaterial = new Material(fishEyeRenderFeature8._FishEyeMaterial);
				fishEyeRenderFeature8.passMaterial = passMaterial;
				FishEyeRenderFeature fishEyeRenderFeature9 = backgroundWater._fishEyeRenderFeature;
				if ((object)backgroundWater._fishEyeRenderFeature != null)
				{
					((ScriptableRendererFeature)fishEyeRenderFeature9).m_Active = true;
					WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
					_003C_003E2__current = waitForEndOfFrame;
					_003C_003E1__state = 1;
					return true;
				}
			}
			goto IL_052b;
			IL_05cc:
			bool flag2 = obj3 == null;
			fishEyeRenderFeature = null;
			if (!flag2)
			{
				fishEyeRenderFeature = scriptableRendererFeature;
			}
			goto IL_05ba;
			IL_051d:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private bool _canTriggerEclipse;

	private SpriteRenderer _water;

	private TileSprite _bgTile;

	private SpriteRenderer _moonPresence;

	private SpriteRenderer _fader;

	private SpriteRenderer _sDarkness;

	private FishEyeRenderFeature _fishEyeRenderFeature;

	private Timer _destructibleTimer;

	private Sequence _waterBgmTween;

	private static readonly int Intensity;

	private static readonly int Radius;

	private static readonly int Mode;

	private static readonly int TexSize;

	private static readonly int Center;

	protected override void OnUpdate()
	{
		//IL_011f: Expected F4, but got O
		//IL_0158: Expected F4, but got O
		//IL_0196: Expected F4, but got I
		//IL_01d2: Expected F4, but got I
		base.OnUpdate();
		if ((object)GM.Core != null)
		{
			PhaserScene s_scene = ArcadePhysics.s_scene;
			if (ArcadePhysics.s_scene != null)
			{
				PhaserScene.Renderer renderer = s_scene._renderer;
				if (s_scene._renderer != null)
				{
					GameManager core = GM.Core;
					if ((object)GM.Core != null && core._playerOptions != null)
					{
						PlayerOptionsData config = core._playerOptions.Config;
						if (config != null && (object)_bgTile != null)
						{
							_bgTile.enabled = config._003CFlashingVFXEnabled_003Ek__BackingField;
							TileSprite bgTile = _bgTile;
							if ((object)_bgTile != null)
							{
								bgTile._xScrollOffset = (float)renderer.screenCenter;
								if ((object)bgTile._spriteScroller != null)
								{
									bgTile._spriteScroller.SetScrollOffsetX((float)renderer.screenCenter);
									TileSprite bgTile2 = _bgTile;
									if ((object)_bgTile != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v14 (PhaserScene+Renderer)+38]");
										bgTile2._yScrollOffset = 0f;
										if ((object)bgTile2._spriteScroller != null)
										{
											SpriteScroller spriteScroller = bgTile2._spriteScroller;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ rax_v14 (PhaserScene+Renderer)+38]");
											spriteScroller.SetScrollOffsetY(0f);
											if ((object)_bgTile != null)
											{
												Transform transform = _bgTile.transform;
												if ((object)transform != null)
												{
													bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
													Vector3 value = default(Vector3);
													Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
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
		throw new NullReferenceException();
	}

	protected override void OnDestroy()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		GameManager core = GM.Core;
		Action token = CharacterDied;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		core._signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		FishEyeRenderFeature fishEyeRenderFeature = _fishEyeRenderFeature;
		if ((object)_fishEyeRenderFeature != null && ((UnityEngine.Object)fishEyeRenderFeature).m_CachedPtr != (IntPtr)0)
		{
			FishEyeRenderFeature fishEyeRenderFeature2 = _fishEyeRenderFeature;
			((ScriptableRendererFeature)fishEyeRenderFeature2).m_Active = false;
		}
		Action<EnemyController> value = OnRemoteEnemySpawned;
		Delegate obj3 = Delegate.Remove(EnemyInstantiator.OnRemoteEnemySpawned, value);
		if ((object)obj3 == null)
		{
			EnemyInstantiator.OnRemoteEnemySpawned = (Action<EnemyController>)obj3;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			Action<EnemyController> action = default(Action<EnemyController>);
			if (action == null)
			{
				throw new InvalidCastException();
			}
			EnemyInstantiator.OnRemoteEnemySpawned = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj4 = default(object);
			if (obj4 == null)
			{
				throw new InvalidCastException();
			}
		}
		base.OnDestroy();
		if (_waterBgmTween != null)
		{
			DG.Tweening.TweenExtensions.Kill(_waterBgmTween);
		}
	}

	public unsafe override void Create()
	{
		//IL_00d5: Expected O, but got I4
		//IL_00d5: Expected O, but got I
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_0ec8: Expected O, but got I
		//IL_0f0b: Expected O, but got I
		//IL_11e3: Expected F4, but got I4
		//IL_11f4: Expected F4, but got I
		//IL_1043: Expected I4, but got I8
		//IL_121e: Expected F4, but got I4
		//IL_122f: Expected F4, but got I
		//IL_10b7: Expected I4, but got I8
		//IL_0563: Expected O, but got I4
		//IL_1174: Expected I4, but got O
		//IL_0b04: Expected I4, but got O
		//IL_037b->IL0e99: Incompatible stack heights: 1 vs 0
		//IL_03bc->IL0e99: Incompatible stack heights: 1 vs 0
		//IL_124b->IL0e99: Incompatible stack heights: 1 vs 0
		//IL_10e1->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_046b->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_1117->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_049f->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_04bd->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_113e->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_04f1->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_050e->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_0550->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_0644->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_068e->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_06bc->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_06e8->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_0719->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_0747->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_0773->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_07a4->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_07d2->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_07fe->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_082f->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_085d->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_0889->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_08e6->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_09d4->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_09a9->IL09a9: Incompatible stack heights: 4 vs 2
		//IL_1268->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_0b2e->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_1285->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_0c8a->IL0e99: Incompatible stack heights: 2 vs 0
		//IL_12a2->IL0e99: Incompatible stack heights: 2 vs 0
		base.Create();
		base._003CHasMovingBg_003Ek__BackingField = true;
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			Action action = CharacterDied;
			if (core._signalBus != null)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rbx_v14 (Il2CppMethodInfo)+38]");
				if ((nint)0 == 0)
				{
				}
				object obj = null;
				if (obj != null)
				{
					Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.CharacterDiedSignal>)obj)._003CSubscribeId_003Eb__0;
					((SignalBus._003C_003Ec__DisplayClass35_0<GameplaySignals.CharacterDiedSignal>)0)._003CSubscribeId_003Eb__0((object)1);
					object obj3 = default(object);
					object obj2 = obj3 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					SignalBus signalBus = core._signalBus;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rax_v44 (System.Object)+10]");
					Type signalType = default(Type);
					Action<object> action3 = default(Action<object>);
					signalBus.SubscribeInternal(signalType, (object)null, (object)0, action3);
					SpawnHealer();
					SpawnEggman();
					_003CInitFishEye_003Ed__18 obj4 = null;
					obj4._003C_003E1__state = 0;
					obj4._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(obj4);
					_canTriggerEclipse = true;
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null && core2._playerOptions != null)
					{
						PlayerOptionsData config = core2._playerOptions.Config;
						if (config != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v58 (VampireSurvivors.Data.PlayerOptionsData)+188]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v306 @ rax_v58 (VampireSurvivors.Data.PlayerOptionsData)+188]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ rcx_v57+18]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
									object obj6 = default(object);
									if ((nint)obj6 != -1)
									{
										_canTriggerEclipse = false;
									}
								}
								if (!Stage.HasValidStageXCharacters())
								{
									_canTriggerEclipse = false;
								}
								GameManager core3 = GM.Core;
								if ((object)GM.Core != null && core3._playerOptions != null)
								{
									PlayerOptionsData config2 = core3._playerOptions.Config;
									if (config2 != null)
									{
										float num2 = ((!config2._003CSelectedHurry_003Ek__BackingField) ? 1f : 0.5f);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Objects.Stages.BackgroundWater)+3C]");
										float num3 = 0f * 2f;
										float num4 = num3 / 5.12f;
										if ((object)_mainCamera != null)
										{
											Transform transform = _mainCamera.transform;
											if ((object)transform != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v67 (UnityEngine.Transform)+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v309 @ rax_v67 (UnityEngine.Transform)+10]");
													float ret;
													Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
													Camera main = Camera.main;
													Bounds bounds = VampireSurvivors.Tools.CameraExtensions.OrthographicBoundsIgnoringBorders(main);
													object obj7 = default(object);
													float num5 = (float)obj7 * 2f;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2163 @ rax_v76 (UnityEngine.Bounds)+10]");
													float num6 = 0f * 2f;
													GameObject gameObject = base.gameObject;
													float y = default(float);
													SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, ret, y, "backgroundW", (string)(object)action3);
													nint num7 = Screen.width;
													float yScale = Screen.height;
													SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, num7, yScale);
													if ((object)spriteRenderer != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v88 (UnityEngine.SpriteRenderer)+10]");
														bool flag = (nint)0 == 0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v88 (UnityEngine.SpriteRenderer)+10]");
														Renderer.set_sortingOrder_Injected((IntPtr)0, -1970);
														SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(spriteRenderer, 0f);
														Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
														if ((object)spriteRenderer2 != null)
														{
															((Renderer)spriteRenderer2).SetMaterial(material);
															SpriteRenderer spriteRenderer3 = RenderingExtensions.SetTint(spriteRenderer2, 16711680u);
															if ((object)spriteRenderer3 != null)
															{
																((UnityEngine.Object)spriteRenderer3).SetName("MoonPresence");
																_moonPresence = spriteRenderer3;
																GameObject gameObject2 = base.gameObject;
																SpriteRenderer component2 = RenderingExtensions.AddSprite(gameObject2, ret, y, "backgroundW", (string)(object)action3);
																nint num8 = Screen.width;
																float yScale2 = Screen.height;
																SpriteRenderer spriteRenderer4 = RenderingExtensions.SetScale(component2, num8, yScale2);
																if ((object)spriteRenderer4 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v111 (UnityEngine.SpriteRenderer)+10]");
																	bool flag2 = (nint)0 == 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rax_v111 (UnityEngine.SpriteRenderer)+10]");
																	Renderer.set_sortingOrder_Injected((IntPtr)0, -1980);
																	SpriteRenderer spriteRenderer5 = RenderingExtensions.SetAlpha(spriteRenderer4, 0f);
																	if ((object)spriteRenderer5 != null)
																	{
																		((UnityEngine.Object)spriteRenderer5).SetName("Fader");
																		_fader = spriteRenderer5;
																		GameObject go = base.gameObject;
																		TileSpriteBuilder tileSpriteBuilder = RenderingExtensions.AddTileSprite(go, 0f, 0f, "backgroundW", (string)(object)action3);
																		if ((object)GM.Core != null)
																		{
																			PhaserScene s_scene = ArcadePhysics.s_scene;
																			if (ArcadePhysics.s_scene != null)
																			{
																				PhaserScene.Renderer renderer = s_scene._renderer;
																				if (s_scene._renderer != null && (object)GM.Core != null)
																				{
																					PhaserScene s_scene2 = ArcadePhysics.s_scene;
																					if (ArcadePhysics.s_scene != null)
																					{
																						PhaserScene.Renderer renderer2 = s_scene2._renderer;
																						if (s_scene2._renderer != null && tileSpriteBuilder != null)
																						{
																							_ = renderer.width;
																							_ = renderer2.height;
																							TileSpriteBuilder tileSpriteBuilder2 = tileSpriteBuilder.SetScale(num4);
																							if (tileSpriteBuilder2 != null)
																							{
																								tileSpriteBuilder2._spritePivot = (Vector2?)(object)1;
																								_ = 0.5f;
																								tileSpriteBuilder2._depth = -1990f;
																								tileSpriteBuilder2._depthMul = 1f;
																								tileSpriteBuilder2._blendMode = BlendMode.Add;
																								tileSpriteBuilder2._alpha = 0.25f;
																								TileSprite bgTile = tileSpriteBuilder2.Build();
																								_bgTile = bgTile;
																								GameObject gameObject3 = base.gameObject;
																								SpriteRenderer spriteRenderer6 = RenderingExtensions.AddSprite(gameObject3, ret, y, "vfx", (string)(object)action3);
																								SpriteRenderer component3 = RenderingExtensions.SetAlpha(spriteRenderer6, 0f);
																								float yScale3 = num6 * 100f;
																								float xScale = num5 * 100f;
																								SpriteRenderer spriteRenderer7 = RenderingExtensions.SetScale(component3, xScale, yScale3);
																								if ((object)spriteRenderer7 != null)
																								{
																									spriteRenderer7.sortingOrder = 10000;
																									((UnityEngine.Object)spriteRenderer7).SetName("sDarkness");
																									_sDarkness = spriteRenderer7;
																									if ((object)_moonPresence != null)
																									{
																										Transform transform2 = _moonPresence.transform;
																										if ((object)_mainCamera != null)
																										{
																											Transform parent = _mainCamera.transform;
																											if ((object)transform2 != null)
																											{
																												transform2.SetParent(parent, worldPositionStays: true);
																												if ((object)_fader != null)
																												{
																													Transform transform3 = _fader.transform;
																													if ((object)_mainCamera != null)
																													{
																														Transform parent2 = _mainCamera.transform;
																														if ((object)transform3 != null)
																														{
																															transform3.SetParent(parent2, worldPositionStays: true);
																															if ((object)_bgTile != null)
																															{
																																Transform transform4 = _bgTile.transform;
																																if ((object)_mainCamera != null)
																																{
																																	Transform parent3 = _mainCamera.transform;
																																	if ((object)transform4 != null)
																																	{
																																		transform4.SetParent(parent3, worldPositionStays: true);
																																		if ((object)_sDarkness != null)
																																		{
																																			Transform transform5 = _sDarkness.transform;
																																			if ((object)_mainCamera != null)
																																			{
																																				Transform parent4 = _mainCamera.transform;
																																				if ((object)transform5 != null)
																																				{
																																					transform5.SetParent(parent4, worldPositionStays: true);
																																					if (!_canTriggerEclipse)
																																					{
																																						RemoveEclipse();
																																					}
																																					else
																																					{
																																						if ((object)GM.Core == null)
																																						{
																																							goto IL_0e99;
																																						}
																																						if (!GM.Core.IsStageHost)
																																						{
																																							Delegate obj8 = Delegate.Combine(b: new Action<EnemyController>(OnRemoteEnemySpawned), a: EnemyInstantiator.OnRemoteEnemySpawned);
																																							if ((object)obj8 == null)
																																							{
																																								EnemyInstantiator.OnRemoteEnemySpawned = null;
																																							}
																																							else
																																							{
																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																								Action<EnemyController> action4 = default(Action<EnemyController>);
																																								bool flag3 = action4 == null;
																																								EnemyInstantiator.OnRemoteEnemySpawned = action4;
																																								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
																																								object obj9 = default(object);
																																								bool flag4 = obj9 == null;
																																							}
																																						}
																																						RestoreEclipse();
																																						StartEclipse();
																																					}
																																					if ((object)_bgTile != null)
																																					{
																																						Transform target = _bgTile.transform;
																																						float endValue = num4 * 1.25f;
																																						TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(target, endValue, 5f);
																																						if (tweenerCore != null)
																																						{
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2868 @ rax_v157 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																																							if ((nint)0 != 0)
																																							{
																																								_ = 2;
																																								_ = 0;
																																							}
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2868 @ rax_v157 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																																							if ((nint)0 != 0)
																																							{
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2868 @ rax_v157 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
																																								if ((nint)0 == 0)
																																								{
																																									_ = 4294967295L;
																																									_ = 1;
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2868 @ rax_v157 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
																																									if ((nint)0 == 0)
																																									{
																																										_ = 2139095040;
																																									}
																																								}
																																							}
																																						}
																																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																																						bool flag5 = (nint)0 != 0;
																																						int num9 = (int)action3;
																																						if (!flag5)
																																						{
																																							_ = 1;
																																							num9 = (int)action3;
																																						}
																																						if (tweenerCore != null && (object)_bgTile != null)
																																						{
																																							Transform target2 = _bgTile.transform;
																																							float endValue2 = num4 * 1.25f;
																																							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScaleY(target2, endValue2, 6.0000005f);
																																							if (tweenerCore2 != null)
																																							{
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3099 @ rax_v163 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																																								if ((nint)0 != 0)
																																								{
																																									_ = 3;
																																									_ = 0;
																																								}
																																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3099 @ rax_v163 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																																								if ((nint)0 != 0)
																																								{
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3099 @ rax_v163 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
																																									if ((nint)0 == 0)
																																									{
																																										_ = 4294967295L;
																																										_ = 1;
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3099 @ rax_v163 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
																																										if ((nint)0 == 0)
																																										{
																																											_ = 2139095040;
																																										}
																																									}
																																								}
																																							}
																																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																																							if ((nint)0 == 0)
																																							{
																																								_ = 1;
																																							}
																																							if (tweenerCore2 != null)
																																							{
																																								TileSprite bgTile2 = _bgTile;
																																								if ((object)_bgTile != null)
																																								{
																																									TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleSprite.DOFade(bgTile2._spriteRenderer, 0.15f, 7.0000005f);
																																									if (tweenerCore3 != null)
																																									{
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3303 @ rax_v168 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
																																										if ((nint)0 != 0)
																																										{
																																											_ = 4;
																																											_ = 0;
																																										}
																																										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3303 @ rax_v168 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
																																										if ((nint)0 != 0)
																																										{
																																											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3303 @ rax_v168 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+100]");
																																											if ((nint)0 == 0)
																																											{
																																												_ = 4294967295L;
																																												_ = 1;
																																												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3303 @ rax_v168 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+10]");
																																												if ((nint)0 == 0)
																																												{
																																													_ = 2139095040;
																																												}
																																											}
																																										}
																																									}
																																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
																																									bool flag6 = (nint)0 != 0;
																																									bool useRealTime = (byte)num9 != 0;
																																									if (!flag6)
																																									{
																																										_ = 1;
																																										useRealTime = (byte)num9 != 0;
																																									}
																																									if (tweenerCore3 != null)
																																									{
																																										if (_destructibleTimer != null)
																																										{
																																											_destructibleTimer.Cancel();
																																										}
																																										Action onComplete = SpawnAnforaCluster;
																																										float num10 = num2 * 10000f;
																																										float duration = num10 * 0.001f;
																																										MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
																																										int repeat = default(int);
																																										TimerType type = default(TimerType);
																																										Timer destructibleTimer = Timers.Register(duration, onComplete, null, isLooped: true, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
																																										_destructibleTimer = destructibleTimer;
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
																	}
																}
															}
														}
													}
												}
												else
												{
													UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
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
		goto IL_0e99;
		IL_0e99:
		throw new NullReferenceException();
	}

	private void OnRemoteEnemySpawned(EnemyController enemy)
	{
		if (enemy._enemyType == EnemyType.MOON_TRINACRIA)
		{
			EnemyTrinaMoon component = enemy.GetComponent<EnemyTrinaMoon>();
			if ((object)component != null && ((UnityEngine.Object)component).m_CachedPtr != (IntPtr)0)
			{
				Action onDefeat = SendToHiddenGround;
				component.OnDefeat = onDefeat;
			}
		}
	}

	private IEnumerator InitFishEye()
	{
		_003CInitFishEye_003Ed__18 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void CharacterDied()
	{
		FishEyeRenderFeature fishEyeRenderFeature = _fishEyeRenderFeature;
		((ScriptableRendererFeature)fishEyeRenderFeature).m_Active = false;
	}

	private void RestoreEclipse()
	{
		//IL_02be: Expected I8, but got I4
		//IL_031c: Expected I8, but got I4
		//IL_007e: Expected I4, but got O
		//IL_0359: Expected I8, but got I4
		//IL_012c: Expected I4, but got O
		//IL_01f6: Expected I4, but got O
		//IL_014d: Expected I4, but got O
		//IL_00be: Expected I4, but got O
		//IL_0188: Expected I4, but got O
		//IL_00df: Expected I4, but got O
		//IL_010b: Expected O, but got I4
		//IL_01a9: Expected I4, but got O
		//IL_01d5: Expected O, but got I4
		GameManager core = GM.Core;
		DataManager dataManager = core._dataManager;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllStages_003Ek__BackingField).get_Item((System.Int32Enum)1);
		JToken minuteDataFromStageDataList = DataHelper.GetMinuteDataFromStageDataList(12, (JArray)obj);
		object obj2 = default(object);
		if (minuteDataFromStageDataList != null)
		{
			JValue value = new JValue(200L);
			minuteDataFromStageDataList.set_Item((object)"minimum", (JToken)value);
			JArray jArray = new JArray();
			jArray._002Ector();
			object content = (EnemyType)obj2;
			jArray.Add(content);
			minuteDataFromStageDataList.set_Item((object)"enemies", (JToken)jArray);
			JArray jArray2 = new JArray();
			object content2 = (EnemyType)obj2;
			jArray2.Add(content2);
			object content3 = (EnemyType)obj2;
			jArray2.Add(content3);
			minuteDataFromStageDataList.set_Item((object)"bosses", (JToken)jArray2);
			obj2 = 183;
		}
		JToken minuteDataFromStageDataList2 = DataHelper.GetMinuteDataFromStageDataList(13, (JArray)obj);
		if (minuteDataFromStageDataList2 != null)
		{
			JValue value2 = new JValue(120L);
			minuteDataFromStageDataList2.set_Item((object)"minimum", (JToken)value2);
			JArray jArray3 = new JArray();
			jArray3._002Ector();
			object content4 = (EnemyType)obj2;
			jArray3.Add(content4);
			object content5 = (EnemyType)obj2;
			jArray3.Add(content5);
			minuteDataFromStageDataList2.set_Item((object)"enemies", (JToken)jArray3);
			JArray jArray4 = new JArray();
			object content6 = (EnemyType)obj2;
			jArray4.Add(content6);
			object content7 = (EnemyType)obj2;
			jArray4.Add(content7);
			minuteDataFromStageDataList2.set_Item((object)"bosses", (JToken)jArray4);
			obj2 = 184;
		}
		JToken minuteDataFromStageDataList3 = DataHelper.GetMinuteDataFromStageDataList(14, (JArray)obj);
		if (minuteDataFromStageDataList3 != null)
		{
			JValue value3 = new JValue(200L);
			minuteDataFromStageDataList3.set_Item((object)"minimum", (JToken)value3);
			JArray jArray5 = new JArray();
			jArray5._002Ector();
			object content8 = (EnemyType)obj2;
			jArray5.Add(content8);
			minuteDataFromStageDataList3.set_Item((object)"enemies", (JToken)jArray5);
			JArray value4 = new JArray();
			minuteDataFromStageDataList3.set_Item((object)"bosses", (JToken)value4);
		}
		GameManager core2 = GM.Core;
		DataManager dataManager2 = core2._dataManager;
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllStages_003Ek__BackingField).TryInsert((System.Int32Enum)1, obj, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
	}

	private void RemoveEclipse()
	{
		//IL_02de: Expected I8, but got I4
		//IL_01ba: Expected I4, but got O
		//IL_033c: Expected I8, but got I4
		//IL_007e: Expected I4, but got O
		//IL_0110: Expected I4, but got O
		//IL_01fa: Expected I4, but got O
		//IL_0131: Expected I4, but got O
		//IL_00be: Expected I4, but got O
		//IL_021b: Expected I4, but got O
		//IL_0237: Expected I4, but got O
		//IL_016c: Expected I4, but got O
		//IL_00ef: Expected O, but got I4
		//IL_019d: Expected O, but got I4
		GameManager core = GM.Core;
		DataManager dataManager = core._dataManager;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)dataManager._003CAllStages_003Ek__BackingField).get_Item((System.Int32Enum)1);
		JToken minuteDataFromStageDataList = DataHelper.GetMinuteDataFromStageDataList(12, (JArray)obj);
		object obj2 = default(object);
		if (minuteDataFromStageDataList != null)
		{
			JValue value = new JValue(200L);
			minuteDataFromStageDataList.set_Item((object)"minimum", (JToken)value);
			JArray jArray = new JArray();
			jArray._002Ector();
			object content = (EnemyType)obj2;
			jArray.Add(content);
			minuteDataFromStageDataList.set_Item((object)"enemies", (JToken)jArray);
			JArray jArray2 = new JArray();
			object content2 = (EnemyType)obj2;
			jArray2.Add(content2);
			minuteDataFromStageDataList.set_Item((object)"bosses", (JToken)jArray2);
			obj2 = 181;
		}
		JToken minuteDataFromStageDataList2 = DataHelper.GetMinuteDataFromStageDataList(13, (JArray)obj);
		if (minuteDataFromStageDataList2 != null)
		{
			JValue value2 = new JValue(200L);
			minuteDataFromStageDataList2.set_Item((object)"minimum", (JToken)value2);
			JArray jArray3 = new JArray();
			jArray3._002Ector();
			object content3 = (EnemyType)obj2;
			jArray3.Add(content3);
			object content4 = (EnemyType)obj2;
			jArray3.Add(content4);
			minuteDataFromStageDataList2.set_Item((object)"enemies", (JToken)jArray3);
			JArray jArray4 = new JArray();
			object content5 = (EnemyType)obj2;
			jArray4.Add(content5);
			minuteDataFromStageDataList2.set_Item((object)"bosses", (JToken)jArray4);
			obj2 = 181;
		}
		JToken minuteDataFromStageDataList3 = DataHelper.GetMinuteDataFromStageDataList(14, (JArray)obj);
		if (minuteDataFromStageDataList3 != null)
		{
			JArray jArray5 = new JArray();
			object content6 = (EnemyType)obj2;
			jArray5.Add(content6);
			minuteDataFromStageDataList3.set_Item((object)"enemies", (JToken)jArray5);
			JArray jArray6 = new JArray();
			object content7 = (EnemyType)obj2;
			jArray6.Add(content7);
			object content8 = (EnemyType)obj2;
			jArray6.Add(content8);
			object content9 = (EnemyType)obj2;
			jArray6.Add(content9);
			minuteDataFromStageDataList3.set_Item((object)"bosses", (JToken)jArray6);
		}
		GameManager core2 = GM.Core;
		DataManager dataManager2 = core2._dataManager;
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)dataManager2._003CAllStages_003Ek__BackingField).TryInsert((System.Int32Enum)1, obj, System.Collections.Generic.InsertionBehavior.OverwriteExisting);
	}

	private void SpawnHealer()
	{
		//IL_01ba: Invalid comparison between O and F4
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rcx_v6 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj == -1)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		int num = config2._003CCharacterEggCount_003Ek__BackingField.FindEntry(config3._selectedChar);
		if (num < 0)
		{
			return;
		}
		GameManager core4 = GM.Core;
		int playerCount = core4._multiplayer.GetPlayerCount();
		if (playerCount <= 1 && !core4._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core5 = GM.Core;
			PlayerOptionsData config4 = core5._playerOptions.Config;
			GameManager core6 = GM.Core;
			PlayerOptionsData config5 = core6._playerOptions.Config;
			int num2 = config4._003CCharacterEggCount_003Ek__BackingField.FindEntry(config5._selectedChar);
			object obj2 = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)5000f))
			{
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool validatePickups = default(bool);
				Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.HEALER, WeaponType.VOID, value, relicType, validatePickups);
			}
		}
	}

	private void SpawnEggman()
	{
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		if (config._selectedChar == CharacterType.SIGMA)
		{
			return;
		}
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		List<ItemType> list = config2._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rcx_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 == 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj = default(object);
		if ((nint)obj == -1)
		{
			return;
		}
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		if (1000000f > config3._003CCoins_003Ek__BackingField)
		{
			return;
		}
		GameManager core4 = GM.Core;
		int playerCount = core4._multiplayer.GetPlayerCount();
		if (playerCount <= 1 && !core4._multiplayer.IsOnlineMultiplayer)
		{
			GameManager core5 = GM.Core;
			PlayerOptionsData config4 = core5._playerOptions.Config;
			if (!(config4._003CTotalEggCount_003Ek__BackingField < 5000f))
			{
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool validatePickups = default(bool);
				Pickup pickup = GM.Core.MakeStagePickup(pos, ItemType.EGGMAN, WeaponType.VOID, value, relicType, validatePickups);
				ArcadeSprite arcadeSprite = pickup.setFlipX(flipX: true);
			}
		}
	}

	private void StartEclipse()
	{
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals22 = new _003C_003Ec__DisplayClass24_0();
		CS_0024_003C_003E8__locals22._003C_003E4__this = this;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		float moonTime = ((!config._003CSelectedHurry_003Ek__BackingField) ? 1f : 0.5f);
		CS_0024_003C_003E8__locals22.moonTime = moonTime;
		CS_0024_003C_003E8__locals22.minute = 60000f;
		Sequence sequence = DOTween.Sequence();
		float num = CS_0024_003C_003E8__locals22.moonTime * CS_0024_003C_003E8__locals22.minute;
		float num2 = num * 14f;
		float duration = num2 * 0.001f;
		TweenerCore<Color, Color, ColorOptions> t = DOTweenModuleSprite.DOFade(_moonPresence, 0.6f, duration);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, 0f);
		}
		float num3 = CS_0024_003C_003E8__locals22.moonTime * CS_0024_003C_003E8__locals22.minute;
		float num4 = num3 * 14f;
		float duration2 = num4 * 0.001f;
		TweenerCore<Color, Color, ColorOptions> t2 = DOTweenModuleSprite.DOFade(_fader, 0.6f, duration2);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, 0f);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C3]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		sequence.stringId = "DefaultGameTweenId";
		FishEyeRenderFeature fishEyeRenderFeature = _fishEyeRenderFeature;
		fishEyeRenderFeature.passMaterial.SetFloatImpl(Intensity, 0f);
		CS_0024_003C_003E8__locals22.intensity = 0f;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((_003C_003Ec__DisplayClass24_0)(object)dOSetter)._003CStartEclipse_003Eb__1(0.6f);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.2f, 10f);
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 1;
				_ = 0;
			}
		}
		float num5 = CS_0024_003C_003E8__locals22.moonTime * CS_0024_003C_003E8__locals22.minute;
		float num6 = num5 * 14f;
		float delay = num6 * 0.001f;
		TweenerCore<float, float, FloatOptions> tweenerCore2 = TweenSettingsExtensions.SetDelay(tweenerCore, delay);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenCallback tweenCallback = delegate
		{
			BackgroundWater backgroundWater = CS_0024_003C_003E8__locals22._003C_003E4__this;
			FishEyeRenderFeature fishEyeRenderFeature2 = backgroundWater._fishEyeRenderFeature;
			fishEyeRenderFeature2.passMaterial.SetFloatImpl(Intensity, CS_0024_003C_003E8__locals22.intensity);
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
		}
		TweenCallback tweenCallback2 = delegate
		{
			if (Stage.HasValidStageXCharacters())
			{
				CS_0024_003C_003E8__locals22._003C_003E4__this.Cry();
			}
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v634 @ rax_v29 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
		}
		Action onComplete = delegate
		{
			//IL_018e: Expected O, but got I4
			//IL_01c9: Expected O, but got I4
			//IL_01d2: Expected F4, but got I4
			if (SoundManager._003CCurrentBgm_003Ek__BackingField == BgmType.BGM_Water)
			{
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				if (config2._003CSelectedBGMMod_003Ek__BackingField == BgmModType.Normal)
				{
					_003C_003Ec__DisplayClass24_1 CS_0024_003C_003E8__locals23 = new _003C_003Ec__DisplayClass24_1();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186CD2D20");
					SoundManager.SoundConfig soundConfig = default(SoundManager.SoundConfig);
					CS_0024_003C_003E8__locals23.soundConfig = soundConfig;
					float num7 = CS_0024_003C_003E8__locals22.moonTime * CS_0024_003C_003E8__locals22.minute;
					BackgroundWater backgroundWater = CS_0024_003C_003E8__locals22._003C_003E4__this;
					float num8 = num7 * 13f;
					float duration3 = num8 * 0.001f;
					Sequence waterBgmTween = DOTween.Sequence();
					backgroundWater._waterBgmTween = waterBgmTween;
					BackgroundWater backgroundWater2 = CS_0024_003C_003E8__locals22._003C_003E4__this;
					DOGetter<float> getter2 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
					DOSetter<float> dOSetter2 = null;
					float x = default(float);
					((_003C_003Ec__DisplayClass24_1)(object)dOSetter2)._003CStartEclipse_003Eb__6(x);
					TweenerCore<float, float, FloatOptions> t3 = DOTween.To(getter2, dOSetter2, 1.125f, duration3);
					bool flag = TweenSettingsExtensions.ValidateAddToSequence(backgroundWater2._waterBgmTween, (Tween)t3, false);
					bool flag2 = !flag;
					object obj = 0;
					float num9 = 1.125f;
					if (!flag2)
					{
						Sequence sequence4 = Sequence.DoInsert(backgroundWater2._waterBgmTween, (Tween)t3, 0f);
						obj = 0;
						num9 = 0f;
					}
					BackgroundWater backgroundWater3 = CS_0024_003C_003E8__locals22._003C_003E4__this;
					DOGetter<float> getter3 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
					DOSetter<float> dOSetter3 = null;
					((_003C_003Ec__DisplayClass24_1)(object)dOSetter3)._003CStartEclipse_003Eb__8(x);
					TweenerCore<float, float, FloatOptions> t4 = DOTween.To(getter3, dOSetter3, -1000f, duration3);
					if (TweenSettingsExtensions.ValidateAddToSequence(backgroundWater3._waterBgmTween, (Tween)t4, false))
					{
						Sequence sequence5 = Sequence.DoInsert(backgroundWater3._waterBgmTween, (Tween)t4, 0f);
					}
					BackgroundWater backgroundWater4 = CS_0024_003C_003E8__locals22._003C_003E4__this;
					Sequence waterBgmTween2 = backgroundWater4._waterBgmTween;
					TweenCallback onUpdate = delegate
					{
						SoundManager.UpdateCurrentMusicWithConfig(CS_0024_003C_003E8__locals23.soundConfig);
					};
					if (backgroundWater4._waterBgmTween != null && ((Tween)waterBgmTween2)._003Cactive_003Ek__BackingField)
					{
						waterBgmTween2.onUpdate = onUpdate;
					}
					BackgroundWater backgroundWater5 = CS_0024_003C_003E8__locals22._003C_003E4__this;
					Sequence sequence6 = VampireSurvivors.Tools.TweenExtensions.SetGameId(backgroundWater5._waterBgmTween);
				}
			}
		};
		bool useRealTime = default(bool);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		TimerType type = default(TimerType);
		Timer timer = Timers.Register(1f, onComplete, null, isLooped: false, useRealTime, autoDestroyOwner, repeat, type, isOnlineTimer: false, canPause: false);
	}

	private unsafe void Cry()
	{
		//IL_042f: Expected O, but got I4
		//IL_0442: Expected I, but got O
		//IL_0462: Expected O, but got I
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_007b: Expected O, but got I4
		//IL_04b9: Expected I, but got O
		//IL_04d9: Expected O, but got I
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_010f: Expected O, but got I4
		//IL_0530: Expected I, but got O
		//IL_0550: Expected O, but got I
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_024a: Expected O, but got I4
		//IL_0286: Expected O, but got I4
		//IL_035d: Expected O, but got I
		//IL_05ea: Expected I, but got O
		//IL_0600: Expected O, but got I
		//IL_0609: Unknown result type (might be due to invalid IL or missing references)
		//IL_060e: Expected O, but got Unknown
		//IL_0414: Expected I, but got O
		//IL_0634: Expected O, but got I4
		//IL_064b: Expected I, but got I8
		//IL_03ce: Expected I, but got I8
		object obj = 0;
		Vector2 vector = default(Vector2);
		bool forceSpawn = default(bool);
		object obj7 = default(object);
		while (true)
		{
			GameManager core = GM.Core;
			if ((object)GM.Core == null)
			{
				break;
			}
			nint num = (nint)typeof(Vector2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rax_v11 (Il2CppClass<UnityEngine.Vector2>)+B8]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
			object obj2 = 0;
			if ((object)core._stage == null)
			{
				break;
			}
			GameObject gameObject = core._stage.SpawnEnemy(EnemyType.MOON_EYE1S, vector, asRemote: false, forceSpawn);
			obj++;
			bool flag = (nint)obj < 60;
			Vector2 vector2 = vector;
			bool flag2 = false;
			Vector2 vector3 = vector;
			if (flag)
			{
				continue;
			}
			object obj3 = 0;
			vector2 = vector;
			flag2 = false;
			vector3 = vector;
			while (true)
			{
				GameManager core2 = GM.Core;
				if ((object)GM.Core == null)
				{
					break;
				}
				nint num3 = (nint)typeof(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v17 (Il2CppClass<UnityEngine.Vector2>)+B8]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v9 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
				obj2 = 0;
				if ((object)core2._stage == null)
				{
					break;
				}
				GameObject gameObject2 = core2._stage.SpawnEnemy(EnemyType.MOON_EYE2S, vector, asRemote: false, forceSpawn);
				obj3++;
				bool flag3 = (nint)obj3 < 40;
				vector2 = vector;
				flag2 = false;
				vector3 = vector;
				if (flag3)
				{
					continue;
				}
				object obj4 = 0;
				vector2 = vector;
				flag2 = false;
				vector3 = vector;
				while (true)
				{
					GameManager core3 = GM.Core;
					if ((object)GM.Core == null)
					{
						break;
					}
					nint num5 = (nint)typeof(Vector2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rax_v23 (Il2CppClass<UnityEngine.Vector2>)+B8]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v12 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
					obj2 = 0;
					if ((object)core3._stage == null)
					{
						break;
					}
					GameObject gameObject3 = core3._stage.SpawnEnemy(EnemyType.MOON_EYE3S, vector, asRemote: false, forceSpawn);
					obj4++;
					bool flag4 = (nint)obj4 < 20;
					vector2 = vector;
					flag2 = false;
					vector3 = vector;
					if (flag4)
					{
						continue;
					}
					GameManager core4 = GM.Core;
					bool flag5 = (object)GM.Core == null;
					vector2 = vector;
					flag2 = false;
					vector3 = vector;
					if (flag5)
					{
						break;
					}
					bool flag6 = (object)core4._stage == null;
					vector2 = vector;
					flag2 = false;
					vector3 = vector;
					if (flag6)
					{
						break;
					}
					Vector2 bossyPosition = core4._stage.GetBossyPosition();
					GameManager core5 = GM.Core;
					bool flag7 = (object)GM.Core == null;
					vector2 = (Vector2)0;
					flag2 = false;
					vector3 = bossyPosition;
					if (flag7)
					{
						break;
					}
					bool flag8 = (object)core5._stage == null;
					vector2 = (Vector2)0;
					flag2 = false;
					vector3 = bossyPosition;
					if (flag8)
					{
						break;
					}
					GameObject gameObject4 = core5._stage.SpawnEnemy(EnemyType.MOON_TRINACRIA, bossyPosition, asRemote: false, forceSpawn);
					if ((object)gameObject4 == null || ((UnityEngine.Object)gameObject4).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					EnemyTrinaMoon component = gameObject4.GetComponent<EnemyTrinaMoon>();
					if ((object)component == null || ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0)
					{
						return;
					}
					Action action = null;
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
					vector2 = (Vector2)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r10_v3 (Il2CppMethodInfo)+8]");
					((Delegate)action).method_ptr = (IntPtr)0;
					((Delegate)action).method = (nint)__ldftn(BackgroundWater.SendToHiddenGround);
					((Delegate)action).m_target = this;
					flag2 = false;
					((Delegate)action).method_code = (IntPtr)action;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r10_v3 (Il2CppMethodInfo)+4C]");
					object obj5 = (nint)0 >> 4;
					object obj6 = obj5 & 1;
					nint num8;
					if (obj6 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v341 @ r10_v3 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num8 = unchecked((nint)6447293664L);
							goto IL_062b;
						}
					}
					else
					{
						bool flag9 = (object)this == null;
						vector3 = bossyPosition;
						if (flag9)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7570");
							throw obj7;
						}
					}
					num8 = ((Delegate)action).method_ptr;
					((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
					goto IL_062b;
					IL_062b:
					object obj8 = 24;
					((Delegate)action).extra_arg = unchecked((nint)6447293568L);
					component.OnDefeat = action;
					return;
				}
				break;
			}
			break;
		}
		throw new NullReferenceException();
	}

	private void SendToHiddenGround()
	{
		//IL_0012: Expected O, but got I8
		//IL_0115: Expected O, but got I4
		//IL_0305: Expected O, but got I4
		//IL_030e: Expected O, but got I4
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected O, but got Unknown
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_063d: Expected O, but got I4
		//IL_064d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0652: Expected O, but got Unknown
		//IL_02c7: Expected O, but got I4
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals10 = new _003C_003Ec__DisplayClass26_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals10._003C_003E4__this = this;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rcx_v8 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
			object obj2 = default(object);
			if ((nint)obj2 != -1)
			{
				_canTriggerEclipse = false;
			}
		}
		bool flag = Stage.HasValidStageXCharacters();
		if (!flag)
		{
			_canTriggerEclipse = flag;
		}
		GameManager core2 = GM.Core;
		core2._003CCanInterrupt_003Ek__BackingField = false;
		SoundManager.FadeMusic(SoundManager._003CCurrentBgm_003Ek__BackingField, 0f, 5000f);
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Rate = 1f;
		soundConfig.Detune = -1900f;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.BGM_Intro, soundConfig, 0f, 10, time);
		FishEyeRenderFeature fishEyeRenderFeature = _fishEyeRenderFeature;
		float floatImpl = fishEyeRenderFeature.passMaterial.GetFloatImpl(Intensity);
		CS_0024_003C_003E8__locals10.intensity = floatImpl;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((_003C_003Ec__DisplayClass26_0)(object)dOSetter)._003CSendToHiddenGround_003Eb__1(0f);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.2f, 10f);
		object obj10;
		TweenCallback tweenCallback2;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag2 = (nint)0 == 0;
				_ = 0;
				if (!flag2)
				{
					object obj3 = tweenerCore + 184;
					object obj4 = obj3 >> 12;
					object obj5 = obj4 & 0x1FFFFF;
					object obj6 = obj5 >> 6;
					object obj7 = obj5 & 0x3F;
					nint num2;
					do
					{
						object obj8 = 1 << (int)obj7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r14_v2+462E0+v700 @ rdx_v47*8]");
						object obj9 = 0 | obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r14_v2+462E0+v700 @ rdx_v47*8]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r14_v2+462E0+v700 @ rdx_v47*8]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r14_v2+462E0+v700 @ rdx_v47*8]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ r14_v2+462E0+v700 @ rdx_v47*8]");
					}
					while (num2 != 0);
					TweenCallback tweenCallback = delegate
					{
						BackgroundWater backgroundWater = CS_0024_003C_003E8__locals10._003C_003E4__this;
						FishEyeRenderFeature fishEyeRenderFeature3 = backgroundWater._fishEyeRenderFeature;
						fishEyeRenderFeature3.passMaterial.SetFloatImpl(Intensity, CS_0024_003C_003E8__locals10.intensity);
					};
					tweenCallback2 = tweenCallback;
					obj10 = 0;
					goto IL_031c;
				}
			}
		}
		TweenCallback tweenCallback3 = delegate
		{
			BackgroundWater backgroundWater = CS_0024_003C_003E8__locals10._003C_003E4__this;
			FishEyeRenderFeature fishEyeRenderFeature3 = backgroundWater._fishEyeRenderFeature;
			fishEyeRenderFeature3.passMaterial.SetFloatImpl(Intensity, CS_0024_003C_003E8__locals10.intensity);
		};
		bool flag3 = tweenerCore == null;
		tweenCallback2 = tweenCallback3;
		obj10 = 0;
		object obj11 = 0;
		if (!flag3)
		{
			goto IL_031c;
		}
		goto IL_035b;
		IL_031c:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ rax_v30 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		bool flag4 = (nint)0 == 0;
		obj11 = obj10;
		if (!flag4)
		{
			obj11 = obj10;
		}
		goto IL_035b;
		IL_035b:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		FishEyeRenderFeature fishEyeRenderFeature2 = _fishEyeRenderFeature;
		float floatImpl2 = fishEyeRenderFeature2.passMaterial.GetFloatImpl(Radius);
		CS_0024_003C_003E8__locals10.radius = floatImpl2;
		DOGetter<float> getter2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter2 = null;
		((_003C_003Ec__DisplayClass26_0)(object)dOSetter2)._003CSendToHiddenGround_003Eb__4(0f);
		TweenerCore<float, float, FloatOptions> tweenerCore2 = DOTween.To(getter2, dOSetter2, 1f, 10f);
		if (tweenerCore2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				_ = 2;
				_ = 0;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		TweenCallback tweenCallback4 = delegate
		{
			BackgroundWater backgroundWater = CS_0024_003C_003E8__locals10._003C_003E4__this;
			FishEyeRenderFeature fishEyeRenderFeature3 = backgroundWater._fishEyeRenderFeature;
			fishEyeRenderFeature3.passMaterial.SetFloatImpl(Radius, CS_0024_003C_003E8__locals10.radius);
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
		}
		TweenCallback tweenCallback5 = _003C_003Ec._003C_003E9__26_6;
		if (_003C_003Ec._003C_003E9__26_6 == null)
		{
			tweenCallback5 = (_003C_003Ec._003C_003E9__26_6 = delegate
			{
				GameManager core3 = GM.Core;
				PlayerOptions playerOptions = core3._playerOptions;
				PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002E30");
				object obj12 = default(object);
				if (obj12 == null)
				{
					GameManager core4 = GM.Core;
					PlayerOptions playerOptions2 = core4._playerOptions;
					PlayerOptionsData mainGameConfig2 = playerOptions2._mainGameConfig;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
				}
				GM.Core.SetPlayersInvulForMillisecondsAndRestoreTints(30000f);
			});
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 != 0)
		{
		}
		TweenCallback tweenCallback6 = delegate
		{
			//IL_00dc: Expected I8, but got O
			//IL_00f1: Expected O, but got I
			//IL_0099: Expected O, but got I8
			//IL_00c0: Expected O, but got I
			GameManager core3 = GM.Core;
			if (!core3._multiplayer.IsOnlineMultiplayer)
			{
				CS_0024_003C_003E8__locals10._003C_003E4__this.TransitionToHolyForbidden();
			}
			else if (GM.Core.IsStageHost)
			{
				long num3 = (long)OnlineStageManager._instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v3 (System.Int64)+88]");
				object obj12 = 0;
				(string, object)[] array = Array.Empty<(string, object)>();
				object obj13 = obj12;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v64 @ r10_v2+1E8] (should have been resolved before IL gen)");
				Action<long> action = null;
				((OnlineStageManager)(object)action).TransitionToHolyForbidden(num3);
				long startingOnlineClientFrame = ((OnlineStageManager)num3).GetStartingOnlineClientFrame();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v3 (System.Int64)+78]");
				bool flag5 = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
			}
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ rax_v41 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
	}

	public void TransitionToHolyForbidden()
	{
		Debug.Log("<color=green>Starting Transition To Holy Forbidden</color>");
		GameManager core = GM.Core;
		PlayerOptions playerOptions = core._playerOptions;
		playerOptions._onlineClientWithRunDataConfig = null;
		_sDarkness.enabled = true;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_sDarkness, 1f);
		GameManager core2 = GM.Core;
		PlayerOptionsData config = core2._playerOptions.Config;
		config._003CSelectedStage_003Ek__BackingField = StageType.STAGEX;
		GameManager core3 = GM.Core;
		PlayerOptionsData config2 = core3._playerOptions.Config;
		config2._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Chapet;
		GameManager core4 = GM.Core;
		PlayerOptionsData config3 = core4._playerOptions.Config;
		config3._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		GameManager core5 = GM.Core;
		PlayerOptionsData config4 = core5._playerOptions.Config;
		config4._003CSelectedHurry_003Ek__BackingField = false;
		GameManager core6 = GM.Core;
		PlayerOptionsData config5 = core6._playerOptions.Config;
		config5._003CSelectedMazzo_003Ek__BackingField = false;
		GM.Core.RestartGameScene(shouldShowTransition: true);
	}

	private void SpawnAnforaCluster()
	{
		//IL_00e7: Invalid comparison between F4 and I4
		//IL_00f9: Expected O, but got I4
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_00ac: Invalid comparison between F4 and O
		GameManager core = GM.Core;
		GameSessionData gameSessionData = core._gameSessionData;
		float num = gameSessionData._activeCharacter.PLuck();
		object obj = default(object);
		float num2 = (float)obj * 6f;
		if (!(18f > num2))
		{
			num2 = 18f;
		}
		Vector2 positionOutOfSight = GetPositionOutOfSight(15f);
		bool flag = !(num2 > 0f);
		object obj2 = 0;
		if (!flag)
		{
			bool forceSpawn = default(bool);
			do
			{
				GameManager core2 = GM.Core;
				GameObject gameObject = core2._stage.SpawnEnemy(EnemyType.MOON_ANFORA, positionOutOfSight, asRemote: false, forceSpawn);
				obj2++;
			}
			while (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2));
		}
	}

	private Vector2 GetPositionOutOfSight(float inPlayerDirectionAngle)
	{
		//IL_01b8: Expected O, but got F4
		//IL_0191: Expected O, but got F4
		//IL_01aa: Expected O, but got I4
		GameManager core = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData = core._gameSessionData;
			if (core._gameSessionData != null && (object)gameSessionData._activeCharacter != null)
			{
				Vector2 velocity = gameSessionData._activeCharacter.Velocity;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186F9E44Dh\"");
				object obj = default(object);
				float num;
				Vector2 vector;
				if ((object)velocity == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186F9E44Dh\"");
					if (obj == null)
					{
						object obj2 = UnityEngine.Random.value;
						num = (float)obj * ((float)Math.PI * 2f);
						vector = (Vector2)0;
						goto IL_024c;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6DAF8");
				object obj3 = UnityEngine.Random.value;
				float num2 = (float)obj - 0.5f;
				float num3 = num2 * ((float)Math.PI / 180f);
				float num4 = num3 * inPlayerDirectionAngle;
				num = num4 + (float)obj;
				vector = velocity;
				goto IL_024c;
			}
		}
		goto IL_015a;
		IL_015a:
		throw new NullReferenceException();
		IL_024c:
		GameManager core2 = GM.Core;
		if ((object)GM.Core != null)
		{
			GameSessionData gameSessionData2 = core2._gameSessionData;
			if (core2._gameSessionData != null && (object)gameSessionData2._activeCharacter != null)
			{
				Transform transform = gameSessionData2._activeCharacter.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6E6F0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B73150");
					Vector2 result = default(Vector2);
					return result;
				}
			}
		}
		goto IL_015a;
	}

	public override void DisableMovingBackground()
	{
		FishEyeRenderFeature fishEyeRenderFeature = _fishEyeRenderFeature;
		if ((object)_fishEyeRenderFeature != null && ((UnityEngine.Object)fishEyeRenderFeature).m_CachedPtr != (IntPtr)0)
		{
			FishEyeRenderFeature fishEyeRenderFeature2 = _fishEyeRenderFeature;
			((ScriptableRendererFeature)fishEyeRenderFeature2).m_Active = false;
		}
	}

	public override void EnableMovingBackground()
	{
		FishEyeRenderFeature fishEyeRenderFeature = _fishEyeRenderFeature;
		if ((object)_fishEyeRenderFeature != null && ((UnityEngine.Object)fishEyeRenderFeature).m_CachedPtr != (IntPtr)0)
		{
			FishEyeRenderFeature fishEyeRenderFeature2 = _fishEyeRenderFeature;
			((ScriptableRendererFeature)fishEyeRenderFeature2).m_Active = true;
		}
	}

	static BackgroundWater()
	{
		int intensity = Shader.PropertyToID("_Intensity");
		Intensity = intensity;
		int radius = Shader.PropertyToID("_Radius");
		Radius = radius;
		int mode = Shader.PropertyToID("_Mode");
		Mode = mode;
		int texSize = Shader.PropertyToID("_TexSize");
		TexSize = texSize;
		int center = Shader.PropertyToID("_Center");
		Center = center;
	}
}
