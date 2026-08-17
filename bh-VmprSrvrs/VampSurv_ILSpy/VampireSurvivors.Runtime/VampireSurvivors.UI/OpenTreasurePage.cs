using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using VampireSurvivors.Utility;
using Zenject;

namespace VampireSurvivors.UI;

public class OpenTreasurePage : BaseUIPage
{
	private sealed class _003C_003Ec__DisplayClass113_0
	{
		public float coins;

		public OpenTreasurePage _003C_003E4__this;

		public TweenCallback _003C_003E9__4;

		internal float _003CTweenCoins_003Eb__0()
		{
			return coins;
		}

		internal void _003CTweenCoins_003Eb__1(float x)
		{
			coins = x;
		}

		internal unsafe void _003CTweenCoins_003Eb__2()
		{
			//IL_004e: Expected Ref, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A33C2]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			OpenTreasurePage openTreasurePage = _003C_003E4__this;
			float num = (float)this + 16f;
			string text = ((float*)num)->ToString("00.00");
			openTreasurePage.CoinsCount.text = text;
		}

		internal unsafe void _003CTweenCoins_003Eb__3()
		{
			//IL_0017: Expected O, but got Ref
			OpenTreasurePage openTreasurePage = _003C_003E4__this;
			object obj = default(object);
			openTreasurePage.CoinsCount.color = (Color)(&obj);
			OpenTreasurePage openTreasurePage2 = _003C_003E4__this;
			if (openTreasurePage2._coinSinTimer != null)
			{
				TweenExtensions.Kill(openTreasurePage2._coinSinTimer);
			}
			TweenCallback callback = _003C_003E9__4;
			OpenTreasurePage openTreasurePage3 = _003C_003E4__this;
			if (_003C_003E9__4 == null)
			{
				callback = (_003C_003E9__4 = delegate
				{
					//IL_00a7: Expected O, but got F4
					OpenTreasurePage openTreasurePage4 = _003C_003E4__this;
					Transform transform = openTreasurePage4.CoinsCount.transform;
					Transform parent = transform.parent;
					SinScaler component = parent.GetComponent<SinScaler>();
					object obj2 = Time.timeSinceLevelLoad;
					OpenTreasurePage openTreasurePage5 = _003C_003E4__this;
					float restartTime = default(float);
					component._restartTime = restartTime;
					Transform transform2 = openTreasurePage5.CoinsCount.transform;
					Transform parent2 = transform2.parent;
					SinScaler component2 = parent2.GetComponent<SinScaler>();
					component2.enabled = true;
				});
			}
			Tween coinSinTimer = DOVirtual.DelayedCall(0.1f, callback);
			openTreasurePage3._coinSinTimer = coinSinTimer;
		}

		internal void _003CTweenCoins_003Eb__4()
		{
			//IL_00a7: Expected O, but got F4
			OpenTreasurePage openTreasurePage = _003C_003E4__this;
			Transform transform = openTreasurePage.CoinsCount.transform;
			Transform parent = transform.parent;
			SinScaler component = parent.GetComponent<SinScaler>();
			object obj = Time.timeSinceLevelLoad;
			OpenTreasurePage openTreasurePage2 = _003C_003E4__this;
			float restartTime = default(float);
			component._restartTime = restartTime;
			Transform transform2 = openTreasurePage2.CoinsCount.transform;
			Transform parent2 = transform2.parent;
			SinScaler component2 = parent2.GetComponent<SinScaler>();
			component2.enabled = true;
		}
	}

	private sealed class _003C_003Ec__DisplayClass114_0
	{
		public float coins;

		public OpenTreasurePage _003C_003E4__this;

		internal float _003CSkipCoins_003Eb__0()
		{
			return coins;
		}

		internal void _003CSkipCoins_003Eb__1(float x)
		{
			coins = x;
		}

		internal unsafe void _003CSkipCoins_003Eb__2()
		{
			//IL_004e: Expected Ref, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A33C5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			OpenTreasurePage openTreasurePage = _003C_003E4__this;
			float num = (float)this + 16f;
			string text = ((float*)num)->ToString("00.00");
			openTreasurePage.CoinsCount.text = text;
		}

		internal unsafe void _003CSkipCoins_003Eb__3()
		{
			//IL_0021: Expected O, but got Ref
			OpenTreasurePage openTreasurePage = _003C_003E4__this;
			object obj = default(object);
			openTreasurePage.CoinsCount.color = (Color)(&obj);
		}
	}

	private sealed class _003C_003Ec__DisplayClass83_0
	{
		public int count;

		public string[] frames;

		public OpenTreasurePage _003C_003E4__this;

		public TweenCallback _003C_003E9__1;

		public TweenCallback _003C_003E9__0;

		internal void _003CPlayFireworks_003Eb__0()
		{
			if (frames != null)
			{
				List<object> list = new List<object>(frames);
				OpenTreasurePage openTreasurePage = _003C_003E4__this;
				ParticleSystem particleSystem = FireworksManager.CreateRandomFirework(count, (List<string>)(object)list, openTreasurePage._Panel);
				OpenTreasurePage openTreasurePage2 = _003C_003E4__this;
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(openTreasurePage2._BGOverlay, 1f, 0.03f);
				TweenCallback tweenCallback = _003C_003E9__1;
				if (_003C_003E9__1 == null)
				{
					tweenCallback = (_003C_003E9__1 = delegate
					{
						OpenTreasurePage openTreasurePage3 = _003C_003E4__this;
						TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(openTreasurePage3._BGOverlay, 0f, 0.03f);
					});
				}
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
				openTreasurePage2._bgTween = tweenerCore;
				int num = count + 1;
				count = num;
				return;
			}
			Exception ex = System.Linq.Error.ArgumentNull("source");
			throw ex;
		}

		internal void _003CPlayFireworks_003Eb__1()
		{
			OpenTreasurePage openTreasurePage = _003C_003E4__this;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(openTreasurePage._BGOverlay, 0f, 0.03f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass91_0
	{
		public float alphaValue;

		public OpenTreasurePage _003C_003E4__this;

		internal float _003CStartPlayingCoins_003Eb__0()
		{
			return alphaValue;
		}

		internal void _003CStartPlayingCoins_003Eb__1(float x)
		{
			alphaValue = x;
		}

		internal unsafe void _003CStartPlayingCoins_003Eb__2()
		{
			//IL_004a: Expected O, but got Ref
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A33C7]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			OpenTreasurePage openTreasurePage = _003C_003E4__this;
			object obj = default(object);
			openTreasurePage._powerParticlesMaterial.SetColor("_BaseColor", (Color)(&obj));
		}
	}

	private sealed class _003CPlayMultiplayerRandomisation_003Ed__111(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public OpenTreasurePage _003C_003E4__this;

		private List<VampireSurvivors.Objects.Characters.CharacterController> _003Cplayers_003E5__2;

		private int _003Cindex_003E5__3;

		private int _003Cscrolls_003E5__4;

		private float _003Ctime_003E5__5;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_09bf: Expected I4, but got I8
			//IL_09eb: Expected O, but got I
			//IL_0a1e: Invalid comparison between I and F4
			//IL_009d: Expected O, but got I
			//IL_0e31: Expected O, but got F4
			//IL_0e64: Expected O, but got I
			//IL_0a5a: Invalid comparison between I4 and F4
			//IL_0aa5: Expected F4, but got I4
			//IL_1000: Expected O, but got I
			//IL_019a: Expected O, but got I
			//IL_01d6: Expected O, but got I4
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Expected O, but got Unknown
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Expected O, but got Unknown
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Expected I4, but got Unknown
			//IL_0ebd: Expected F4, but got O
			//IL_0ec1: Expected O, but got F4
			//IL_0eeb: Expected O, but got I
			//IL_0b30: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b35: Expected O, but got Unknown
			//IL_0b42: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b47: Expected I4, but got Unknown
			//IL_039b: Expected O, but got I
			//IL_03db: Expected O, but got I
			//IL_03ef: Expected O, but got I
			//IL_0cc5: Expected O, but got I
			//IL_052a: Expected O, but got I
			//IL_053e: Expected O, but got I
			//IL_0d1a: Expected O, but got I
			//IL_0d52: Expected O, but got I
			//IL_0a30->IL0d95: Incompatible stack heights: 2 vs 0
			//IL_1021->IL014d: Incompatible stack heights: 8 vs 7
			//IL_04f8->IL04f8: Incompatible stack heights: 19 vs 18
			//IL_0677->IL06b7: Incompatible stack heights: 21 vs 20
			//IL_0d95->IL0fca: Incompatible stack heights: 21 vs 0
			//IL_098e->IL09db: Incompatible stack heights: 20 vs 1
			object obj = _003C_003E4__this;
			Sequence sequence2;
			object message;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				GameManager core = GM.Core;
				bool flag = (object)GM.Core == null;
				_003Cplayers_003E5__2 = core._mainCharacters;
				bool flag2 = (object)_003C_003E4__this == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				((Behaviour)0).enabled = true;
				List<VampireSurvivors.Objects.Characters.CharacterController> list = _003Cplayers_003E5__2;
				bool flag4 = _003Cplayers_003E5__2 == null;
				GameManager core2 = GM.Core;
				bool flag5 = (object)GM.Core == null;
				bool flag6 = (object)core2.CoopConfig == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+210]");
				bool flag7 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edi,xmm0\"");
				Sequence sequence = default(Sequence);
				if ((nint)sequence >= 1)
				{
					int num = UnityEngine.Random.RandomRangeInt(0, list._size);
					_003Cindex_003E5__3 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+208]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+208]");
					bool flag8 = (nint)0 == 0;
				}
				List<VampireSurvivors.Objects.Characters.CharacterController> list2 = _003Cplayers_003E5__2;
				bool flag9 = _003Cplayers_003E5__2 == null;
				VampireSurvivors.Objects.Characters.CharacterController[] items = list2._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdx_v37+40]");
				int num2 = Array.IndexOf((object[])items, (object)0, 0, list2._size);
				List<VampireSurvivors.Objects.Characters.CharacterController> list3 = _003Cplayers_003E5__2;
				bool flag10 = _003Cplayers_003E5__2 == null;
				object obj3 = 1 * list3._size;
				object obj4 = obj3 - _003Cindex_003E5__3;
				object obj5 = obj4 + list3._size;
				int num3 = obj5 + num2;
				int num4 = _003Cindex_003E5__3;
				_003Cscrolls_003E5__4 = num3;
				bool flag11 = _003Cplayers_003E5__2 == null;
				bool flag12 = _003Cindex_003E5__3 >= list3._size;
				VampireSurvivors.Objects.Characters.CharacterController[] items2 = list3._items;
				bool flag13 = list3._items == null;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items2[num4];
				bool flag14 = (object)items2[num4] == null;
				CharacterData currentSkinData = characterController._currentSkinData;
				bool flag15 = characterController._currentSkinData == null;
				List<VampireSurvivors.Objects.Characters.CharacterController> list4 = _003Cplayers_003E5__2;
				int num5 = _003Cindex_003E5__3;
				VampireSurvivors.Objects.Characters.CharacterController[] items3 = list4._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController2 = items3[num5];
				CharacterData currentSkinData2 = characterController2._currentSkinData;
				bool flag16 = characterController2._currentSkinData == null;
				Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData2._003CtextureName_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				bool flag17 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				((Image)0).sprite = sprite;
				sequence2 = DOTween.Sequence();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				bool flag18 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				Transform transform = ((Component)0).transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+210]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+210]");
				bool flag19 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rcx_v76+34]");
				float duration = 0f * 0.5f;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScaleX(transform, 0.6f, duration);
				if (tweenerCore != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1669 @ rax_v103 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 2;
						_ = 0;
					}
				}
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweenerCore, false))
				{
					bool flag20 = sequence2 == null;
					Sequence sequence3 = Sequence.DoInsert(sequence2, (Tween)tweenerCore, ((Tween)sequence2).duration);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				bool flag21 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				Transform transform2 = ((Component)0).transform;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+210]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+210]");
				bool flag22 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rcx_v82+34]");
				float duration2 = 0f * 0.5f;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScaleX(transform2, 1f, duration2);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1839 @ rax_v108 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						_ = 3;
						_ = 0;
					}
				}
				TweenCallback tweenCallback2;
				if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)tweenerCore2, false))
				{
					bool flag23 = sequence2 == null;
					duration2 = ((Tween)sequence2).duration;
					Sequence sequence4 = Sequence.DoInsert(sequence2, (Tween)tweenerCore2, ((Tween)sequence2).duration);
					TweenCallback tweenCallback = delegate
					{
						_003C_003E4__this._CoopCharacterParticles.Play(withChildren: true);
					};
					tweenCallback2 = tweenCallback;
				}
				else
				{
					TweenCallback tweenCallback3 = delegate
					{
						_003C_003E4__this._CoopCharacterParticles.Play(withChildren: true);
					};
					bool flag24 = sequence2 == null;
					tweenCallback2 = tweenCallback3;
					if (flag24)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						message = "You can't add elements to a NULL Sequence";
						goto IL_1021;
					}
				}
				if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
				{
					if (!((Tween)sequence2).creationLocked)
					{
						if (tweenCallback2 != null)
						{
							duration2 = ((Tween)sequence2).duration;
							Sequence sequence5 = Sequence.DoInsertCallback(sequence2, tweenCallback2, ((Tween)sequence2).duration);
						}
						goto IL_07dd;
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
				goto IL_1021;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				bool flag25 = (object)_003C_003E4__this == null;
				goto IL_09db;
			}
			goto IL_0d95;
			IL_097e:
			_003Ctime_003E5__5 = 0f;
			goto IL_09db;
			IL_0d95:
			return false;
			IL_1021:
			Debugger.LogWarning(message);
			goto IL_07dd;
			IL_07dd:
			Sequence sequence6 = TweenSettingsExtensions.AppendInterval(sequence2, 0.1f);
			TweenCallback tweenCallback4 = delegate
			{
				if ((object)_003C_003E4__this._CoopCharacterParticles != null)
				{
					_003C_003E4__this._CoopCharacterParticles.Stop();
					return;
				}
				throw new NullReferenceException();
			};
			Tween tween = default(Tween);
			object obj8;
			if (sequence2 != null)
			{
				if (((Tween)sequence2)._003Cactive_003Ek__BackingField)
				{
					if (!((Tween)sequence2).creationLocked)
					{
						bool flag26 = tweenCallback4 == null;
						tween = (Tween)(object)_003C_003E4__this;
						obj8 = tweenCallback4;
						if (!flag26)
						{
							float duration2 = ((Tween)sequence2).duration;
							Sequence sequence7 = Sequence.DoInsertCallback(sequence2, tweenCallback4, ((Tween)sequence2).duration);
							tween = (Tween)(object)tweenCallback4;
							obj8 = sequence2;
						}
						goto IL_097e;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					obj8 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					obj8 = "You can't add elements to an inactive/killed Sequence";
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				obj8 = "You can't add elements to a NULL Sequence";
			}
			Debugger.LogWarning(obj8);
			tween = null;
			goto IL_097e;
			IL_09db:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+210]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+210]");
			bool flag27 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v33+34]");
			if (0f > _003Ctime_003E5__5)
			{
				object obj10 = Time.deltaTime;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v33+34]");
				float num6 = (_003Ctime_003E5__5 = 0f + _003Ctime_003E5__5);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+210]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+210]");
				bool flag28 = (nint)0 == 0;
				float num7 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v268 @ rax_v37+34]");
				float num8 = num7 / 0f;
				if (!(0f > num8))
				{
					if (num8 > 1f)
					{
						num8 = 1f;
					}
				}
				else
				{
					num8 = 0f;
				}
				GameManager core3 = GM.Core;
				bool flag29 = (object)GM.Core == null;
				CoopConfig coopConfig = core3.CoopConfig;
				bool flag30 = (object)core3.CoopConfig == null;
				object chestRandomisationSpinPositionCurve = coopConfig._chestRandomisationSpinPositionCurve;
				bool flag31 = coopConfig._chestRandomisationSpinPositionCurve == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rcx_v31 (System.Object)+10]");
				bool flag32 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rcx_v31 (System.Object)+10]");
				object obj12 = AnimationCurve.Evaluate_Injected((IntPtr)0, (float)tween);
				float num9 = _003Cscrolls_003E5__4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rax_v33+34]");
				float num10 = num9 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rcx_v31 (System.Object)+10]");
				((OpenTreasurePage)0)._003CPlayMultiplayerRandomisation_003Eb__111_1();
				List<VampireSurvivors.Objects.Characters.CharacterController> list5 = _003Cplayers_003E5__2;
				bool flag33 = _003Cplayers_003E5__2 == null;
				object obj14 = default(object);
				object obj13 = obj14 + _003Cindex_003E5__3;
				int num11 = obj13 % list5._size;
				bool flag34 = num11 >= list5._size;
				VampireSurvivors.Objects.Characters.CharacterController[] items4 = list5._items;
				bool flag35 = list5._items == null;
				VampireSurvivors.Objects.Characters.CharacterController characterController3 = items4[num11];
				bool flag36 = (object)items4[num11] == null;
				CharacterData currentSkinData3 = characterController3._currentSkinData;
				bool flag37 = characterController3._currentSkinData == null;
				List<VampireSurvivors.Objects.Characters.CharacterController> list6 = _003Cplayers_003E5__2;
				VampireSurvivors.Objects.Characters.CharacterController[] items5 = list6._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController4 = items5[num11];
				bool flag38 = (object)items5[num11] == null;
				CharacterData currentSkinData4 = characterController4._currentSkinData;
				bool flag39 = characterController4._currentSkinData == null;
				Sprite sprite2 = SpriteManager.GetSprite(currentSkinData3._003CspriteName_003Ek__BackingField, currentSkinData4._003CtextureName_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				bool flag40 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				((Image)0).sprite = sprite2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B6FB44");
				if (num10 > 0.5f)
				{
					num10--;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				bool flag41 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				RectTransform rectTransform = ((Graphic)0).rectTransform;
				bool flag42 = (object)rectTransform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v55 (UnityEngine.RectTransform)+10]");
				bool flag43 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ rax_v55 (UnityEngine.RectTransform)+10]");
				RectTransform.get_rect_Injected((IntPtr)0, out Rect _);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				bool flag44 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rbp_v1 (System.Object)+1D0]");
				RectTransform rectTransform2 = ((Graphic)0).rectTransform;
				bool flag45 = (object)rectTransform2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v60 (UnityEngine.RectTransform)+10]");
				bool flag46 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1556 @ rax_v60 (UnityEngine.RectTransform)+10]");
				Vector3 value = default(Vector3);
				Transform.set_localPosition_Injected((IntPtr)0, ref value);
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_0d95;
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

	private bool _PauseOnAnimIntro;

	private List<TreasurePlaybackSettings> PlaybackLevels;

	private UISpriteAnimation _IdleTreasureChest;

	private UISpriteAnimation _OpenTreasureChest;

	private UISpriteAnimation _OpenTreasureChestFront;

	private Image _TreasureImage;

	private Image _OpenTreasureFrontImage;

	private Animator Animator;

	private TreasureRibbonTrailGenerator _Ribbons;

	private GameObject OpenButton;

	private GameObject DoneButton;

	private GameObject OpenButtonLeftArrow;

	private GameObject OpenButtonRightArrow;

	private GameObject DoneButtonLeftArrow;

	private GameObject DoneButtonRightArrow;

	private TextMeshProUGUI CoinsCount;

	private TextMeshProUGUI FinalCoins;

	private ParticleSystem PowerParticles;

	private TreasureInfoPanel InfoPanel;

	private TreasureFireworksManager Fireworks;

	private UISpriteAnimation VFXAnimation;

	private RectTransform Panel;

	private GameObject _Title;

	private Image _YellowBackground;

	private Image _HeatBackground;

	private RectTransform _Panel;

	private Image _BGOverlay;

	private RectTransform _FireworkContainer;

	private RectTransform _GravityWellPosition;

	private GameObject _CoopRandomPanel;

	private Image _CoopRandomCharacter;

	private ParticleSystem _CoopCharacterParticles;

	private SignalBus _signalBus;

	private TreasureFactory _treasureFactory;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private GameSessionData _session;

	private Treasure _currentTreasure;

	private TreasurePlaybackSettings _currentPlayback;

	private List<TreasurePrizeTypePair> _prizes;

	private List<string> _weaponFrameNames;

	private Dictionary<WeaponType, List<WeaponData>> _weaponData;

	private static readonly int Play1;

	private static readonly int Play2;

	private static readonly int Play3;

	private static readonly int NormalizedAnimationTimeParameter;

	private static readonly int BaseColorProperty;

	private int _currentTreasureLevel;

	private bool _openButtonPressed;

	private bool _doneButtonPressed;

	private bool _animationFinished;

	private bool _receivedClaimRequest;

	private float _outAnimationSpeed;

	private float _inAnimationSpeed;

	private float _animationTime;

	private float _normalizedAnimationTime;

	private float _audioClipLength;

	private bool _canSkip;

	private bool _isPlaying;

	private bool _animCanBeSkippedPastThisPoint;

	private bool _isSkipped;

	private Tween _heatTween;

	private Tween _yellowTween;

	private Tween _coinTween;

	private Tween _bgTween;

	private Tween _idleTimer;

	private Tween _animFinishedTimer;

	private Tween _coinSinTimer;

	private SfxType _treasure1SfxType;

	private SfxType _treasure2SfxType;

	private SfxType _treasure3SfxType;

	private Sequence _randomCharacterSequence;

	private Coroutine _winningPlayerRoutine;

	private int _fireworksSortingOrder;

	private Material _powerParticlesMaterial;

	private string _treasureCacheGroupName;

	private void Construct(SignalBus signalBus, TreasureFactory treasureFactory, DataManager data, PlayerOptions playerOptions, GameSessionData session)
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_0219: Expected O, but got I
		//IL_0145: Expected O, but got I4
		//IL_0145: Expected O, but got I
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0254: Expected O, but got I
		_signalBus = signalBus;
		TreasureFactory treasureFactory2 = default(TreasureFactory);
		_treasureFactory = treasureFactory2;
		_data = data;
		PlayerOptions playerOptions2 = default(PlayerOptions);
		_playerOptions = playerOptions2;
		GameSessionData session2 = default(GameSessionData);
		_session = session2;
		Action<GameplaySignals.OpenTreasureSignal> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0540");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.OpenTreasureSignal>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<GameplaySignals.OpenTreasureSignal>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rax_v19 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus2.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = PerformSkip;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.OnlineSkipTreasureAnim>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.OnlineSkipTreasureAnim>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ rax_v34 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus3.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Renderer component = PowerParticles.GetComponent<Renderer>();
		Material material = component.GetMaterial();
		_powerParticlesMaterial = material;
		Animator.keepAnimatorStateOnDisable = false;
		Animator.writeDefaultValuesOnDisable = true;
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		Action<GameplaySignals.OpenTreasureSignal> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0540");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action token2 = PerformSkip;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
	}

	protected override void Awake()
	{
		base.Awake();
		GameManager core = GM.Core;
		core._003COpenTreasurePage_003Ek__BackingField = this;
	}

	protected override void Update()
	{
		//IL_0570: Expected O, but got F4
		//IL_0460->IL03e0: Incompatible stack heights: 1 vs 0
		//IL_00a0->IL03e0: Incompatible stack heights: 1 vs 0
		//IL_04b4->IL03e0: Incompatible stack heights: 2 vs 0
		//IL_00d6->IL03e0: Incompatible stack heights: 2 vs 0
		//IL_010e->IL03e0: Incompatible stack heights: 2 vs 0
		//IL_013d->IL03e0: Incompatible stack heights: 2 vs 0
		//IL_0513->IL03e0: Incompatible stack heights: 3 vs 0
		//IL_0176->IL03e0: Incompatible stack heights: 3 vs 0
		//IL_0561->IL03e0: Incompatible stack heights: 4 vs 0
		//IL_05af->IL03e0: Incompatible stack heights: 4 vs 0
		//IL_05ce->IL03e0: Incompatible stack heights: 4 vs 0
		//IL_0247->IL03e0: Incompatible stack heights: 4 vs 0
		//IL_0288->IL03e0: Incompatible stack heights: 4 vs 0
		//IL_02d3->IL03e0: Incompatible stack heights: 4 vs 0
		//IL_02f5->IL03e0: Incompatible stack heights: 4 vs 0
		//IL_0349->IL03e0: Incompatible stack heights: 4 vs 0
		//IL_036b->IL03e0: Incompatible stack heights: 4 vs 0
		//IL_039a->IL03e0: Incompatible stack heights: 4 vs 0
		base.Update();
		if ((object)_TreasureImage != null)
		{
			RectTransform rectTransform = _TreasureImage.rectTransform;
			Image treasureImage = _TreasureImage;
			if ((object)_TreasureImage != null)
			{
				Image sprite = (Image)(object)treasureImage.m_Sprite;
				if ((object)treasureImage.m_Sprite != null)
				{
					bool flag = ((UnityEngine.Object)sprite).m_CachedPtr == (IntPtr)0;
					Sprite.get_rect_Injected(((UnityEngine.Object)sprite).m_CachedPtr, out Rect ret);
					Image treasureImage2 = _TreasureImage;
					if ((object)_TreasureImage != null)
					{
						object sprite2 = treasureImage2.m_Sprite;
						if ((object)treasureImage2.m_Sprite != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdi_v14 (System.Object)+10]");
							bool flag2 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ rdi_v14 (System.Object)+10]");
							Sprite.get_rect_Injected((IntPtr)0, out Rect ret2);
							if ((object)rectTransform != null)
							{
								Vector2 vector = default(Vector2);
								rectTransform.sizeDelta = vector;
								if ((object)_OpenTreasureFrontImage != null)
								{
									RectTransform rectTransform2 = _OpenTreasureFrontImage.rectTransform;
									Image openTreasureFrontImage = _OpenTreasureFrontImage;
									if ((object)_OpenTreasureFrontImage != null)
									{
										object sprite3 = openTreasureFrontImage.m_Sprite;
										if ((object)openTreasureFrontImage.m_Sprite != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdi_v16 (System.Object)+10]");
											bool flag3 = (nint)0 == 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdi_v16 (System.Object)+10]");
											Sprite.get_rect_Injected((IntPtr)0, out ret2);
											Image openTreasureFrontImage2 = _OpenTreasureFrontImage;
											if ((object)_OpenTreasureFrontImage != null)
											{
												Image sprite4 = (Image)(object)openTreasureFrontImage2.m_Sprite;
												if ((object)openTreasureFrontImage2.m_Sprite != null)
												{
													bool flag4 = ((UnityEngine.Object)sprite4).m_CachedPtr == (IntPtr)0;
													Sprite.get_rect_Injected(((UnityEngine.Object)sprite4).m_CachedPtr, out ret);
													if ((object)rectTransform2 != null)
													{
														rectTransform2.sizeDelta = vector;
														if (!_isPlaying)
														{
															return;
														}
														object obj = Time.deltaTime;
														TreasurePlaybackSettings currentPlayback = _currentPlayback;
														float num = (_animationTime = (float)vector + _animationTime);
														if (_currentPlayback != null)
														{
															float normalizedAnimationTime = num / currentPlayback.AnimationLength;
															_normalizedAnimationTime = normalizedAnimationTime;
															if ((object)Animator != null)
															{
																Animator.SetFloat(NormalizedAnimationTimeParameter, _normalizedAnimationTime);
																if (!_canSkip || !_animCanBeSkippedPastThisPoint)
																{
																	return;
																}
																if (Player != null)
																{
																	if (Player.GetButtonDown(6))
																	{
																		goto IL_03ca;
																	}
																	if (Player != null)
																	{
																		if (Player.GetButtonDown(10))
																		{
																			goto IL_03ca;
																		}
																		Rewired.Player player = Player;
																		if (Player != null && player.controllers != null)
																		{
																			if (!player.controllers.hasMouse)
																			{
																				return;
																			}
																			Rewired.Player player2 = Player;
																			if (Player != null && player2.controllers != null)
																			{
																				Mouse mouse = player2.controllers.Mouse;
																				if (mouse != null)
																				{
																					if (mouse.GetButtonDown(1))
																					{
																						goto IL_03ca;
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
		IL_03ca:
		Skip();
		_canSkip = false;
	}

	public void DoReelTrailAnimation()
	{
		_Ribbons.PlayReelTrails(1f, 0f, 1);
	}

	public void OpenTreasure()
	{
		//IL_0170: Expected I8, but got O
		if (_openButtonPressed)
		{
			return;
		}
		_openButtonPressed = true;
		if (_idleTimer != null)
		{
			TweenExtensions.Kill(_idleTimer);
		}
		if (_isPlaying)
		{
			return;
		}
		GameManager core = GM.Core;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C080");
			OnlineStageManager onlineStageManager = default(OnlineStageManager);
			long startingOnlineClientFrame = onlineStageManager.GetStartingOnlineClientFrame();
			Action<long> action = null;
			((OnlineStageManager)(object)action).OpenTreasure((long)onlineStageManager);
			bool flag = onlineStageManager._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		}
		else
		{
			if (_idleTimer != null)
			{
				TweenExtensions.Kill(_idleTimer);
			}
			Treasure currentTreasure = _currentTreasure;
			Play(currentTreasure._003Clevel_003Ek__BackingField);
		}
	}

	public void StartPlaying()
	{
		if (_idleTimer != null)
		{
			TweenExtensions.Kill(_idleTimer);
		}
		Treasure currentTreasure = _currentTreasure;
		Play(currentTreasure._003Clevel_003Ek__BackingField);
	}

	public void PlayFireworks()
	{
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_0222->IL02aa: Incompatible stack heights: 2 vs 1
		//IL_01c2->IL0267: Incompatible stack heights: 3 vs 2
		_003C_003Ec__DisplayClass83_0 CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass83_0();
		CS_0024_003C_003E8__locals17._003C_003E4__this = this;
		TreasureFireworksManager fireworks = Fireworks;
		Canvas component = fireworks._FireworksRenderTextureView.GetComponent<Canvas>();
		bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Canvas.set_sortingOrder_Injected(((UnityEngine.Object)component).m_CachedPtr, 7);
		RectTransform component2 = _GravityWellPosition.GetComponent<RectTransform>();
		Vector2 viewportPosition = FireworksManager.GetViewportPosition(component2);
		GravityWell gravityWell = FireworksManager.Instance.SpawnGravityWell(viewportPosition, (GravityWellConfig)null);
		float[] array = new float[5] { 0.1f, 0.4f, 0.7f, 1f, 1.3f };
		string[] frames = new string[4];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		CS_0024_003C_003E8__locals17.frames = frames;
		Sequence s = DOTween.Sequence();
		CS_0024_003C_003E8__locals17.count = 0;
		Canvas canvas = null;
		Canvas canvas2 = null;
		while ((nint)canvas2 < array.Length)
		{
			bool flag2 = (nint)canvas >= array.Length;
			float interval = array[(object)canvas];
			if ((object)canvas != null)
			{
				object obj = canvas - 1;
				bool flag3 = (nint)obj >= array.Length;
				interval = array[(object)canvas] - array[obj];
			}
			Sequence sequence = TweenSettingsExtensions.AppendInterval(s, interval);
			TweenCallback callback = CS_0024_003C_003E8__locals17._003C_003E9__0;
			if (CS_0024_003C_003E8__locals17._003C_003E9__0 == null)
			{
				callback = (CS_0024_003C_003E8__locals17._003C_003E9__0 = delegate
				{
					if (CS_0024_003C_003E8__locals17.frames != null)
					{
						List<object> frames2 = new List<object>(CS_0024_003C_003E8__locals17.frames);
						OpenTreasurePage openTreasurePage = CS_0024_003C_003E8__locals17._003C_003E4__this;
						ParticleSystem particleSystem = FireworksManager.CreateRandomFirework(CS_0024_003C_003E8__locals17.count, (List<string>)(object)frames2, openTreasurePage._Panel);
						OpenTreasurePage openTreasurePage2 = CS_0024_003C_003E8__locals17._003C_003E4__this;
						TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleUI.DOFade(openTreasurePage2._BGOverlay, 1f, 0.03f);
						TweenCallback tweenCallback = CS_0024_003C_003E8__locals17._003C_003E9__1;
						if (CS_0024_003C_003E8__locals17._003C_003E9__1 == null)
						{
							tweenCallback = (CS_0024_003C_003E8__locals17._003C_003E9__1 = delegate
							{
								OpenTreasurePage openTreasurePage3 = CS_0024_003C_003E8__locals17._003C_003E4__this;
								TweenerCore<Color, Color, ColorOptions> tweenerCore2 = DOTweenModuleUI.DOFade(openTreasurePage3._BGOverlay, 0f, 0.03f);
							});
						}
						if (tweenerCore != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rax_v14 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>)+E8]");
							if ((nint)0 == 0)
							{
							}
						}
						openTreasurePage2._bgTween = tweenerCore;
						int count = CS_0024_003C_003E8__locals17.count + 1;
						CS_0024_003C_003E8__locals17.count = count;
						return;
					}
					Exception ex = System.Linq.Error.ArgumentNull("source");
					throw ex;
				});
			}
			Sequence sequence2 = TweenSettingsExtensions.AppendCallback(s, callback);
			canvas = (Canvas)(canvas + 1);
			canvas2 = canvas;
		}
	}

	public void ClaimTreasure()
	{
		//IL_006d: Expected O, but got I
		if (!_doneButtonPressed)
		{
			_doneButtonPressed = true;
			GameManager core = GM.Core;
			if (core._multiplayer.IsOnlineMultiplayer)
			{
				object instance = OnlineStageManager._instance;
				Action action = OnlineStageManager._instance.ClaimTreasureRequest;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rbx_v6 (System.Object)+78]");
				bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.AuthorityOnly);
			}
			else
			{
				AnimateOut();
				Treasure currentTreasure = _currentTreasure;
				_currentTreasure.ClaimPrizes(currentTreasure.winningPlayer);
			}
		}
	}

	public void ReceiveClaimTreasureRequest()
	{
		//IL_008b: Expected I8, but got O
		if (!_receivedClaimRequest)
		{
			_receivedClaimRequest = true;
			OnlineStageManager instance = OnlineStageManager._instance;
			long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
			Action<long> action = null;
			((OnlineStageManager)(object)action).ClaimTreasure((long)OnlineStageManager._instance);
			bool flag = instance._sync.SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
		}
	}

	public void TreasureCompleted()
	{
		AnimateOut();
		Treasure currentTreasure = _currentTreasure;
		_currentTreasure.ClaimPrizes(currentTreasure.winningPlayer);
	}

	public void DoExtraFireworks()
	{
		//IL_01e0: Expected O, but got I
		//IL_0245: Expected O, but got I8
		//IL_0281: Expected O, but got I
		//IL_02e6: Expected O, but got I8
		//IL_0322: Expected O, but got I
		//IL_0387: Expected O, but got I8
		//IL_03c3: Expected O, but got I
		//IL_0428: Expected O, but got I8
		//IL_049d->IL042d: Incompatible stack heights: 1 vs 0
		//IL_0064->IL042d: Incompatible stack heights: 1 vs 0
		//IL_0090->IL042d: Incompatible stack heights: 1 vs 0
		//IL_04ec->IL042d: Incompatible stack heights: 2 vs 0
		//IL_0126->IL042d: Incompatible stack heights: 2 vs 0
		//IL_053b->IL042d: Incompatible stack heights: 3 vs 0
		//IL_017c->IL042d: Incompatible stack heights: 3 vs 0
		//IL_024a->IL0540: Incompatible stack heights: 4 vs 3
		//IL_02eb->IL05b3: Incompatible stack heights: 4 vs 3
		//IL_038c->IL0626: Incompatible stack heights: 4 vs 3
		//IL_042d->IL0699: Incompatible stack heights: 4 vs 3
		if ((object)_Panel != null)
		{
			Transform transform = _Panel.transform;
			if ((object)transform != null)
			{
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 ret);
				if ((object)_Panel != null)
				{
					Vector2 sizeDelta = _Panel.sizeDelta;
					if ((object)_Panel != null)
					{
						Transform transform2 = _Panel.transform;
						if ((object)transform2 != null)
						{
							bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 ret2);
							if ((object)_Panel != null)
							{
								Vector2 sizeDelta2 = _Panel.sizeDelta;
								float num = (float)sizeDelta / 1000f;
								float num2 = (float)sizeDelta2 / 1000f;
								float maxInclusive = num2 + (float)ret2;
								float minInclusive = (float)ret - num;
								float num3 = UnityEngine.Random.Range(minInclusive, maxInclusive);
								Transform gravityWellPosition = _GravityWellPosition;
								if ((object)_GravityWellPosition != null)
								{
									bool flag3 = ((UnityEngine.Object)gravityWellPosition).m_CachedPtr == (IntPtr)0;
									Transform.get_position_Injected(((UnityEngine.Object)gravityWellPosition).m_CachedPtr, out ret);
									if ((object)_OpenTreasureChest != null)
									{
										RectTransform component = _OpenTreasureChest.GetComponent<RectTransform>();
										Vector2 viewportPosition = FireworksManager.GetViewportPosition(component);
										string[] array = new string[4];
										if (array != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											List<object> list = new List<object>(array);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
											object obj = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
											bool flag4 = (nint)0 != 0;
											List<object> list2 = list;
											if (!flag4)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												bool flag5 = obj == null;
												list2 = (List<object>)6573110936L;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1157 @ rax_v64 (should have been resolved before IL gen)");
											object obj2 = default(object);
											float num4 = (float)obj2 + 0.2f;
											float num5 = -0.1f + num4;
											Vector2 viewportPos = default(Vector2);
											ParticleSystem particleSystem = FireworksManager.CreateFireworkAtPosition(0, (List<string>)(object)list, viewportPos);
											nint num6 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ rdi_v16 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											List<object> list3 = new List<object>(array);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
											object obj3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
											bool flag6 = (nint)0 != 0;
											List<object> list4 = list3;
											if (!flag6)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												bool flag7 = obj3 == null;
												list4 = (List<object>)6573110936L;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1230 @ rax_v74 (should have been resolved before IL gen)");
											float num7 = (float)obj2 + 0.2f;
											float num8 = -0.1f + num7;
											ParticleSystem particleSystem2 = FireworksManager.CreateFireworkAtPosition(1, (List<string>)(object)list3, viewportPos);
											nint num9 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v932 @ rdi_v17 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											List<object> list5 = new List<object>(array);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
											object obj4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
											bool flag8 = (nint)0 != 0;
											List<object> list6 = list5;
											if (!flag8)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												bool flag9 = obj4 == null;
												list6 = (List<object>)6573110936L;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1297 @ rax_v84 (should have been resolved before IL gen)");
											float num10 = (float)obj2 + 0.2f;
											float num11 = -0.1f + num10;
											ParticleSystem particleSystem3 = FireworksManager.CreateFireworkAtPosition(2, (List<string>)(object)list5, viewportPos);
											nint num12 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1072 @ rdi_v18 (Il2CppMethodInfo)+38]");
											if ((nint)0 == 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
											}
											List<object> list7 = new List<object>(array);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
											object obj5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
											bool flag10 = (nint)0 != 0;
											List<object> list8 = list7;
											if (!flag10)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
												bool flag11 = obj5 == null;
												list8 = (List<object>)6573110936L;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v1364 @ rax_v94 (should have been resolved before IL gen)");
											ParticleSystem particleSystem4 = FireworksManager.CreateFireworkAtPosition(3, (List<string>)(object)list7, viewportPos);
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
	}

	public void FinishHeat()
	{
		if (_heatTween != null)
		{
			TweenExtensions.Kill(_heatTween);
		}
		if (_yellowTween != null)
		{
			TweenExtensions.Kill(_yellowTween);
		}
		if (_bgTween != null)
		{
			TweenExtensions.Kill(_bgTween);
		}
		TweenerCore<Color, Color, ColorOptions> yellowTween = DOTweenModuleUI.DOFade(_YellowBackground, 0f, 1f);
		_yellowTween = yellowTween;
		TweenerCore<Color, Color, ColorOptions> heatTween = DOTweenModuleUI.DOFade(_HeatBackground, 0f, 1f);
		_heatTween = heatTween;
		TweenerCore<Color, Color, ColorOptions> bgTween = DOTweenModuleUI.DOFade(_BGOverlay, 0f, 1f);
		_bgTween = bgTween;
		PowerParticles.Stop();
		Debug.Log("Killing heat");
		string text = ((_bgTween == null) ? null : _bgTween.ToString());
		string message = "BG : " + text;
		Debug.Log(message);
	}

	public unsafe void AnimationFinished()
	{
		//IL_010f: Expected O, but got I4
		//IL_0118: Expected F4, but got I4
		//IL_0015: Expected O, but got I4
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_005a: Expected F4, but got I4
		bool flag = !_isSkipped;
		object obj = !flag;
		float num = 0f;
		if (obj == null)
		{
			object obj2 = _currentTreasureLevel - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					bool flag2 = (nint)obj3 != 1;
					num = 0f;
					if (!flag2)
					{
						num = 3500f;
					}
				}
				else
				{
					num = 4500f;
				}
			}
			else
			{
				num = 4000f;
			}
		}
		if (_animFinishedTimer != null)
		{
			TweenExtensions.Kill(_animFinishedTimer);
		}
		TweenCallback callback = delegate
		{
			//IL_0241: Expected O, but got Ref
			//IL_0310: Expected O, but got Ref
			//IL_04fb->IL05bc: Incompatible stack heights: 1 vs 0
			//IL_052a->IL05bc: Incompatible stack heights: 1 vs 0
			//IL_065d->IL05bc: Incompatible stack heights: 1 vs 0
			//IL_0580->IL05bc: Incompatible stack heights: 1 vs 0
			//IL_059e->IL05bc: Incompatible stack heights: 1 vs 0
			if ((object)DoneButtonLeftArrow != null)
			{
				Transform target = DoneButtonLeftArrow.transform;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMoveX(target, -5f, 0f);
				if ((object)DoneButtonRightArrow != null)
				{
					Transform target2 = DoneButtonRightArrow.transform;
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOLocalMoveX(target2, 5f, 0f);
					if ((object)DoneButtonLeftArrow != null)
					{
						Transform transform = DoneButtonLeftArrow.transform;
						if ((object)transform != null)
						{
							Transform parent = transform.parent;
							if ((object)parent != null)
							{
								GameObject gameObject = parent.gameObject;
								if ((object)gameObject != null)
								{
									gameObject.SetActive(value: true);
									if ((object)DoneButtonLeftArrow != null)
									{
										DoneButtonLeftArrow.SetActive(value: true);
										if ((object)DoneButtonRightArrow != null)
										{
											DoneButtonRightArrow.SetActive(value: true);
											if ((object)DoneButton != null)
											{
												SelectableUI component = DoneButton.GetComponent<SelectableUI>();
												if ((object)component != null)
												{
													component.UpdateAlternateSelectionIconColour();
													if ((object)DoneButton != null)
													{
														Transform transform2 = DoneButton.transform;
														bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
														Vector3 value = default(Vector3);
														Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
														Transform transform3 = DoneButton.transform;
														object obj4 = default(object);
														transform3.localEulerAngles = (Vector3)(&obj4);
														DoneButton.SetActive(value: true);
														Transform target3 = DoneButton.transform;
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target3, 1f, _inAnimationSpeed);
														TweenCallback tweenCallback = delegate
														{
															Selectable component3 = DoneButton.GetComponent<Selectable>();
															component3.Select();
														};
														if (tweenerCore3 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v853 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 == 0)
															{
															}
														}
														Transform target4 = DoneButton.transform;
														TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DOLocalRotate(target4, (Vector3)(&obj4), _inAnimationSpeed);
														Transform target5 = DoneButtonLeftArrow.transform;
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOLocalMoveX(target5, -168f, _inAnimationSpeed);
														Transform target6 = DoneButtonRightArrow.transform;
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore6 = ShortcutExtensions.DOLocalMoveX(target6, 168f, _inAnimationSpeed);
														HideBeams();
														Transform transform4 = CoinsCount.transform;
														Transform parent2 = transform4.parent;
														SinScaler component2 = parent2.GetComponent<SinScaler>();
														component2.enabled = false;
														Transform transform5 = CoinsCount.transform;
														Transform parent3 = transform5.parent;
														TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore7 = ShortcutExtensions.DOScale(parent3, 0f, _inAnimationSpeed);
														TweenCallback tweenCallback2 = delegate
														{
															Transform transform6 = FinalCoins.transform;
															Transform parent4 = transform6.parent;
															GameObject gameObject2 = parent4.gameObject;
															gameObject2.SetActive(value: true);
															Transform transform7 = CoinsCount.transform;
															Transform parent5 = transform7.parent;
															GameObject gameObject3 = parent5.gameObject;
															gameObject3.SetActive(value: false);
														};
														if (tweenerCore7 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
															if ((nint)0 == 0)
															{
															}
														}
														InfoPanel.Initialize(_prizes);
														_Ribbons.ClearExisting();
														GameManager core = GM.Core;
														if (core._mainCharacters == null)
														{
															return;
														}
														List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
														if (mainCharacters._size <= 1)
														{
															return;
														}
														Treasure currentTreasure = _currentTreasure;
														if (_currentTreasure != null)
														{
															VampireSurvivors.Objects.Characters.CharacterController winningPlayer = currentTreasure.winningPlayer;
															if ((object)currentTreasure.winningPlayer != null)
															{
																if (winningPlayer._player == null)
																{
																	return;
																}
																Treasure currentTreasure2 = _currentTreasure;
																if (_currentTreasure != null)
																{
																	VampireSurvivors.Objects.Characters.CharacterController winningPlayer2 = currentTreasure2.winningPlayer;
																	if ((object)currentTreasure2.winningPlayer != null && MultiplayerManager.s_instance != null)
																	{
																		MultiplayerManager.s_instance.AddPlayerToUIControl(winningPlayer2._player);
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
			throw new NullReferenceException();
		};
		float delay = num * 0.001f;
		Tween animFinishedTimer = DOVirtual.DelayedCall(delay, callback, ignoreTimeScale: false);
		_animFinishedTimer = animFinishedTimer;
	}

	public unsafe void OpenChest()
	{
		//IL_00b2: Expected O, but got Ref
		Transform target = _Title.transform;
		object obj = default(object);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, (Vector3)(&obj), 0.3f);
		TweenCallback tweenCallback = delegate
		{
			_Title.SetActive(value: false);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ rax_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		_OpenTreasureChest.Play();
		_OpenTreasureChestFront.Play();
		_isPlaying = true;
	}

	public unsafe void StartPlayingCoins()
	{
		_003C_003Ec__DisplayClass91_0 CS_0024_003C_003E8__locals3 = new _003C_003Ec__DisplayClass91_0();
		CS_0024_003C_003E8__locals3._003C_003E4__this = this;
		_currentPlayback.StartCoins();
		CS_0024_003C_003E8__locals3.alphaValue = 0f;
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		float x = default(float);
		((_003C_003Ec__DisplayClass91_0)(object)dOSetter)._003CStartPlayingCoins_003Eb__1(x);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, 0.75f, 1f);
		TweenCallback tweenCallback = delegate
		{
			//IL_004a: Expected O, but got Ref
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A33C7]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			OpenTreasurePage openTreasurePage = CS_0024_003C_003E8__locals3._003C_003E4__this;
			object obj = default(object);
			openTreasurePage._powerParticlesMaterial.SetColor("_BaseColor", (Color)(&obj));
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v252 @ rax_v12 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		TweenCoins();
	}

	public void StopCoins()
	{
		_currentPlayback.StopCoins();
		PowerParticles.Stop();
	}

	public void StopScrollingReels()
	{
		//IL_0019: Expected O, but got I4
		List<TreasureReelUI>.Enumerator enumerator = default(List<TreasureReelUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public void StartScrollingReels()
	{
		//IL_0019: Expected O, but got I4
		List<TreasureReelUI>.Enumerator enumerator = default(List<TreasureReelUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public unsafe void HideBeams()
	{
		//IL_0019: Expected O, but got I4
		//IL_0021: Expected O, but got Ref
		List<TreasureReelUI>.Enumerator enumerator = default(List<TreasureReelUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<TreasureReelUI>.Enumerator enumerator2 = (List<TreasureReelUI>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public void StopReels()
	{
		//IL_0019: Expected O, but got I4
		List<TreasureReelUI>.Enumerator enumerator = default(List<TreasureReelUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	public void RevealReel1()
	{
		TreasurePlaybackSettings currentPlayback = _currentPlayback;
		List<TreasureReelUI> reels = currentPlayback.Reels;
		if (reels._size > 0)
		{
			TreasureReelUI[] items = reels._items;
			items[0].Reveal();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void RevealReel2()
	{
		TreasurePlaybackSettings currentPlayback = _currentPlayback;
		List<TreasureReelUI> reels = currentPlayback.Reels;
		if (reels._size > 1)
		{
			TreasureReelUI[] items = reels._items;
			items[1].Reveal();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void RevealReel3()
	{
		TreasurePlaybackSettings currentPlayback = _currentPlayback;
		List<TreasureReelUI> reels = currentPlayback.Reels;
		if (reels._size > 2)
		{
			TreasureReelUI[] items = reels._items;
			items[2].Reveal();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void RevealReel4()
	{
		TreasurePlaybackSettings currentPlayback = _currentPlayback;
		List<TreasureReelUI> reels = currentPlayback.Reels;
		if (reels._size > 3)
		{
			TreasureReelUI[] items = reels._items;
			items[3].Reveal();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void RevealReel5()
	{
		TreasurePlaybackSettings currentPlayback = _currentPlayback;
		List<TreasureReelUI> reels = currentPlayback.Reels;
		if (reels._size > 4)
		{
			TreasureReelUI[] items = reels._items;
			items[4].Reveal();
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void CacheTreasure(GameplaySignals.OpenTreasureSignal sig)
	{
		//IL_0213: Expected O, but got I4
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_01b9: Expected O, but got I4
		_currentTreasure = (Treasure)sig;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [sig @ rdx (VampireSurvivors.Signals.GameplaySignals+OpenTreasureSignal)+18]");
		_currentTreasureLevel = 0;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool flag = config._003CClassicMusic_003Ek__BackingField;
		SfxType treasure1SfxType = SfxType.Treasure1;
		if (!flag)
		{
			treasure1SfxType = SfxType.Treasure1B;
		}
		_treasure1SfxType = treasure1SfxType;
		GameManager core2 = GM.Core;
		PlayerOptionsData config2 = core2._playerOptions.Config;
		bool flag2 = config2._003CClassicMusic_003Ek__BackingField;
		SfxType treasure2SfxType = SfxType.Treasure2;
		if (!flag2)
		{
			treasure2SfxType = SfxType.Treasure2B;
		}
		_treasure2SfxType = treasure2SfxType;
		GameManager core3 = GM.Core;
		PlayerOptionsData config3 = core3._playerOptions.Config;
		bool flag3 = !config3._003CClassicMusic_003Ek__BackingField;
		bool flag4 = config3._003CClassicMusic_003Ek__BackingField;
		SfxType treasure3SfxType = SfxType.Treasure3;
		if (!flag4)
		{
			treasure3SfxType = SfxType.Treasure3B;
		}
		_treasure3SfxType = treasure3SfxType;
		object obj = _currentTreasureLevel - 1;
		SfxType sfxType;
		if (!flag3)
		{
			object obj2 = obj - 1;
			if (!flag3)
			{
				bool flag5 = (nint)obj2 != 1;
				sfxType = SfxType.None;
				if (!flag5)
				{
					sfxType = _treasure3SfxType;
				}
			}
			else
			{
				sfxType = _treasure2SfxType;
			}
		}
		else
		{
			sfxType = _treasure1SfxType;
		}
		AudioLoader.LoadSFX(sfxType, _treasureCacheGroupName, (DlcType?)(object)0);
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_00b1: Expected O, but got I
		//IL_00c7: Expected O, but got I
		//IL_00dd: Expected O, but got I
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		//IL_01e1: Expected O, but got I
		//IL_0288: Expected O, but got I4
		//IL_1202: Expected O, but got I4
		//IL_02bf: Expected I4, but got O
		//IL_029f: Expected O, but got I4
		//IL_0336: Expected O, but got I
		//IL_0355: Expected O, but got I4
		//IL_03b0: Expected O, but got I4
		//IL_048d: Expected O, but got I4
		//IL_0495: Expected O, but got F4
		//IL_1250: Expected I4, but got O
		//IL_04f1: Expected O, but got Ref
		//IL_057b: Expected O, but got Ref
		//IL_100a: Unknown result type (might be due to invalid IL or missing references)
		//IL_100f: Expected O, but got Unknown
		//IL_0e8c: Expected I4, but got O
		//IL_0605: Expected O, but got Ref
		//IL_0ed2: Expected O, but got I
		//IL_0ee2: Expected O, but got I
		//IL_0664: Expected O, but got F4
		//IL_0690: Expected O, but got Ref
		//IL_0690: Expected I4, but got O
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_078d: Expected O, but got Unknown
		//IL_0cea: Expected I4, but got O
		//IL_0d30: Expected O, but got I
		//IL_0d40: Expected O, but got I
		//IL_108f->IL1318: Incompatible stack heights: 21 vs 9
		//IL_1078->IL1078: Incompatible stack heights: 22 vs 21
		//IL_0929->IL0d4d: Incompatible stack heights: 27 vs 26
		//IL_1026->IL12f3: Incompatible stack heights: 28 vs 21
		//IL_102b->IL102b: Incompatible stack heights: 28 vs 21
		//IL_098c->IL0d4d: Incompatible stack heights: 29 vs 26
		//IL_09ef->IL0d4d: Incompatible stack heights: 31 vs 26
		//IL_0a52->IL0d4d: Incompatible stack heights: 33 vs 26
		//IL_0829->IL122c: Incompatible stack heights: 29 vs 21
		//IL_0ab5->IL0d4d: Incompatible stack heights: 35 vs 26
		//IL_0fed->IL1001: Incompatible stack heights: 41 vs 28
		//IL_07c7->IL1297: Incompatible stack heights: 32 vs 27
		//IL_0b8f->IL12bb: Incompatible stack heights: 39 vs 37
		//IL_0bfd->IL0ee7: Incompatible stack heights: 41 vs 35
		//IL_0d4d->IL12d4: Incompatible stack heights: 45 vs 35
		//IL_0c11->IL12bb: Incompatible stack heights: 41 vs 37
		base.OnShowStart(g);
		Treasure currentTreasure = _currentTreasure;
		_openButtonPressed = false;
		_receivedClaimRequest = false;
		bool flag = _currentTreasure == null;
		GameManager core = GM.Core;
		bool flag2 = (object)GM.Core == null;
		CoopConfig coopConfig = core.CoopConfig;
		bool flag3 = (object)core.CoopConfig == null;
		EnterMultiplayerControl(currentTreasure.openingPlayer, coopConfig._levelupVibrationMilliseconds);
		GameObject core2 = (GameObject)(object)GM.Core;
		bool flag4 = (object)GM.Core == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rdi_v7 (UnityEngine.GameObject)+2A0]");
		bool active;
		if ((nint)0 == 0)
		{
			active = false;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ rdi_v7 (UnityEngine.GameObject)+2A0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1279 @ rax_v182+18]");
			object obj2 = -1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1279 @ rax_v182+18]");
			object obj3 = (nint)0 ^ (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1279 @ rax_v182+18]");
			object obj4 = 0 ^ obj2;
			object obj5 = obj3 & obj4;
			bool flag5 = (nint)obj5 < 0;
			bool flag6 = (nint)obj2 < 0;
			bool flag7 = obj2 == null;
			bool flag8 = flag6 == flag5;
			bool flag9 = !flag7;
			active = flag9 & flag8;
		}
		bool flag10 = (object)_CoopRandomPanel == null;
		_CoopRandomPanel.SetActive(active);
		bool flag11 = (object)_CoopRandomCharacter == null;
		_CoopRandomCharacter.enabled = false;
		_animCanBeSkippedPastThisPoint = false;
		FireworksManager.Clear();
		GameObject fireworks = (GameObject)(object)Fireworks;
		bool flag12 = (object)Fireworks == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rdi_v8 (UnityEngine.GameObject)+50]");
		bool flag13 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rdi_v8 (UnityEngine.GameObject)+50]");
		Canvas component = ((GameObject)0).GetComponent<Canvas>();
		bool flag14 = (object)component == null;
		bool flag15 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		GameObject obj6 = (GameObject)(object)component;
		if (!flag15)
		{
			int fireworksSortingOrder = Canvas.get_sortingOrder_Injected(((UnityEngine.Object)component).m_CachedPtr);
			_fireworksSortingOrder = fireworksSortingOrder;
			Reset();
			bool flag16 = (object)_Title == null;
			_Title.SetActive(value: true);
			bool flag17 = (object)_Title == null;
			Transform transform = _Title.transform;
			bool flag18 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Vector3 value = default(Vector3);
			Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			GameManager core3 = GM.Core;
			PlayerOptionsData config = core3._playerOptions.Config;
			bool flag19 = config._003CClassicMusic_003Ek__BackingField;
			GameObject gameObject = (GameObject)4;
			if (!flag19)
			{
				gameObject = (GameObject)86;
			}
			float num = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound((SfxType)gameObject, new SoundManager.SoundConfig
			{
				Rate = 1f,
				Volume = (float?)(object)1
			}, 0f, 10, num);
			Treasure currentTreasure2 = _currentTreasure;
			bool flag20 = _currentTreasure == null;
			_prizes = currentTreasure2.prizes;
			bool flag21 = _data == null;
			Dictionary<WeaponType, List<WeaponData>> convertedWeapons = _data.GetConvertedWeapons();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			string text = (string)0;
			_weaponData = convertedWeapons;
			List<TreasurePlaybackSettings> playbackLevels = PlaybackLevels;
			bool flag22 = PlaybackLevels == null;
			object obj7 = _currentTreasureLevel - 1;
			bool flag23 = (nint)obj7 >= playbackLevels._size;
			TreasurePlaybackSettings[] items = playbackLevels._items;
			bool flag24 = playbackLevels._items == null;
			object obj8 = _currentTreasureLevel - 1;
			bool flag25 = (nint)obj8 >= items.Length;
			_currentPlayback = items[obj8];
			List<TreasurePrizeTypePair> prizes = _prizes;
			bool flag26 = _prizes == null;
			int size = prizes._size;
			TreasurePlaybackSettings currentPlayback = _currentPlayback;
			bool flag27 = _currentPlayback == null;
			List<TreasureReelUI> reels = currentPlayback.Reels;
			bool flag28 = currentPlayback.Reels == null;
			bool flag29 = prizes._size <= reels._size;
			string text2 = (string)_currentTreasureLevel;
			VampireSurvivors.Objects.Characters.CharacterController character = (VampireSurvivors.Objects.Characters.CharacterController)num;
			if (!flag29)
			{
				string[] array = new string[6];
				bool flag30 = array == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string text3 = System.Number.FormatInt32(prizes._size, (ReadOnlySpan<char>)(&value), null);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				TreasurePlaybackSettings currentPlayback2 = _currentPlayback;
				bool flag31 = _currentPlayback == null;
				List<TreasureReelUI> reels2 = currentPlayback2.Reels;
				bool flag32 = currentPlayback2.Reels == null;
				string text4 = System.Number.FormatInt32(reels2._size, (ReadOnlySpan<char>)(&value), null);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				TreasurePlaybackSettings currentPlayback3 = _currentPlayback;
				bool flag33 = _currentPlayback == null;
				List<TreasureReelUI> reels3 = currentPlayback3.Reels;
				bool flag34 = currentPlayback3.Reels == null;
				string text5 = System.Number.FormatInt32(reels3._size, (ReadOnlySpan<char>)(&value), null);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string message = string.Concat(array);
				Debug.LogError(message);
				List<TreasurePrizeTypePair> prizes2 = _prizes;
				bool flag35 = _prizes == null;
				text = text5;
				text2 = null;
				character = (VampireSurvivors.Objects.Characters.CharacterController)num;
				GameObject gameObject2 = null;
				GameObject gameObject3 = null;
				while ((nint)gameObject2 < prizes2._size)
				{
					string text6 = System.Number.FormatInt32((int)gameObject3, (ReadOnlySpan<char>)(&value), null);
					List<TreasurePrizeTypePair> prizes3 = _prizes;
					bool flag36 = _prizes == null;
					bool flag37 = (nint)gameObject3 >= prizes3._size;
					TreasurePrizeTypePair[] items2 = prizes3._items;
					bool flag38 = prizes3._items == null;
					bool flag39 = (nint)gameObject3 >= items2.Length;
					GameObject gameObject4 = (GameObject)(object)((items2[(object)gameObject3] == null) ? null : items2[(object)gameObject3].ToString());
					string message2 = "Prize " + text6 + " = " + (string)(object)gameObject4;
					Debug.LogError(message2);
					prizes2 = _prizes;
					gameObject3 = (GameObject)(gameObject3 + 1);
					bool flag40 = _prizes == null;
					text = " = ";
					text2 = (string)(object)gameObject4;
					gameObject2 = gameObject3;
				}
				TreasurePlaybackSettings currentPlayback4 = _currentPlayback;
				bool flag41 = _currentPlayback == null;
				List<TreasureReelUI> reels4 = currentPlayback4.Reels;
				bool flag42 = currentPlayback4.Reels == null;
				size = reels4._size;
			}
			bool flag43 = size <= 0;
			Dictionary<WeaponType, List<WeaponData>> dictionary = (Dictionary<WeaponType, List<WeaponData>>)(object)text;
			PrizeType prizeType = (PrizeType)text2;
			GameObject gameObject5 = null;
			if (!flag43)
			{
				object obj9 = default(object);
				object obj10 = default(object);
				object obj11 = default(object);
				object obj12 = default(object);
				object obj13 = default(object);
				object obj14 = default(object);
				object obj15 = default(object);
				object obj16 = default(object);
				object obj17 = default(object);
				object obj19 = default(object);
				object obj21 = default(object);
				TreasureReelUI treasureReelUI = default(TreasureReelUI);
				do
				{
					List<TreasurePrizeTypePair> prizes4 = _prizes;
					bool flag44 = _prizes == null;
					bool flag45 = (nint)gameObject5 >= prizes4._size;
					TreasurePrizeTypePair[] items3 = prizes4._items;
					bool flag46 = prizes4._items == null;
					bool flag47 = (nint)gameObject5 >= items3.Length;
					TreasurePrizeTypePair treasurePrizeTypePair = items3[(object)gameObject5];
					bool flag48 = items3[(object)gameObject5] == null;
					string text7;
					string spriteName;
					List<WeaponData> list;
					if (treasurePrizeTypePair.prizeType != PrizeType.POWERUP)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						bool flag49 = obj9 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ rax_v84+10]");
						if ((nint)0 != 1)
						{
							bool flag50 = _prizes == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							bool flag51 = obj10 == null;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rax_v85+10]");
							if ((nint)0 != 2)
							{
								bool flag52 = _prizes == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								bool flag53 = obj11 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v86+10]");
								if ((nint)0 != 5)
								{
									bool flag54 = _prizes == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									bool flag55 = obj12 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v87+10]");
									if ((nint)0 != 8)
									{
										bool flag56 = _prizes == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
										bool flag57 = obj13 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v283 @ rax_v88+10]");
										if ((nint)0 != 6)
										{
											bool flag58 = _prizes == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
											bool flag59 = obj14 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rax_v89+10]");
											bool flag60 = (nint)0 == 3;
											List<TreasurePrizeTypePair> prizes5 = _prizes;
											if (!flag60)
											{
												bool flag61 = _prizes == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
												bool flag62 = obj15 == null;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v94+10]");
												bool flag63 = (nint)0 == 7;
												prizes5 = _prizes;
												if (!flag63)
												{
													bool flag64 = _prizes == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
													bool flag65 = obj16 == null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ rax_v95+10]");
													bool flag66 = (nint)0 != 9;
													text7 = (string)(object)dictionary;
													if (flag66)
													{
														goto IL_0ee7;
													}
													prizes5 = _prizes;
												}
											}
											bool flag67 = prizes5 == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
											bool flag68 = obj17 == null;
											DataManager data = _data;
											bool flag69 = _data == null;
											bool flag70 = data._003CAllItems_003Ek__BackingField == null;
											Dictionary<ItemType, ItemData> dictionary2 = data._003CAllItems_003Ek__BackingField;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ rax_v91+14]");
											object obj18 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)0);
											TreasurePlaybackSettings currentPlayback5 = _currentPlayback;
											bool flag71 = _currentPlayback == null;
											bool flag72 = currentPlayback5.Reels == null;
											ItemData itemData = ((Dictionary<ItemType, ItemData>)(object)currentPlayback5.Reels).get_Item((ItemType)gameObject5);
											bool flag73 = obj18 == null;
											bool flag74 = itemData == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rax_v92 (System.Object)+30]");
											text7 = (string)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rax_v92 (System.Object)+38]");
											spriteName = (string)0;
											list = (List<WeaponData>)(object)itemData;
											goto IL_12d4;
										}
									}
								}
							}
						}
					}
					bool flag75 = _prizes == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag76 = obj19 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v76+18]");
					if ((nint)0 != 0)
					{
						bool flag77 = _data == null;
						Dictionary<WeaponType, List<WeaponData>> convertedWeapons2 = _data.GetConvertedWeapons();
						bool flag78 = convertedWeapons2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v76+18]");
						object obj20 = ((Dictionary<System.Int32Enum, object>)(object)convertedWeapons2).get_Item((System.Int32Enum)0);
						bool flag79 = obj20 == null;
						List<WeaponData> list2 = ((Dictionary<WeaponType, List<WeaponData>>)obj20).get_Item(WeaponType.VOID);
						TreasurePlaybackSettings currentPlayback6 = _currentPlayback;
						bool flag80 = _currentPlayback == null;
						bool flag81 = currentPlayback6.Reels == null;
						list = ((Dictionary<WeaponType, List<WeaponData>>)(object)currentPlayback6.Reels).get_Item((WeaponType)gameObject5);
						bool flag82 = list2 == null;
						bool flag83 = list == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v82 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+38]");
						text7 = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ rax_v82 (System.Collections.Generic.List`1<VampireSurvivors.Data.Weapons.WeaponData>)+40]");
						spriteName = (string)0;
						goto IL_12d4;
					}
					Debug.LogError("Getting void weapon returned in prizes");
					goto IL_1001;
					IL_0ee7:
					TreasurePlaybackSettings currentPlayback7 = _currentPlayback;
					bool flag84 = _currentPlayback == null;
					bool flag85 = currentPlayback7.Reels == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag86 = _prizes == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					bool flag87 = obj21 == null;
					bool flag88 = _currentTreasure == null;
					bool flag89 = (object)treasureReelUI == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rax_v73+10]");
					prizeType = PrizeType.POWERUP;
					GameSessionData session = _session;
					Dictionary<WeaponType, List<WeaponData>> weaponData = _weaponData;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rax_v73+10]");
					treasureReelUI.GenerateWeapons(session, weaponData, PrizeType.POWERUP, character);
					dictionary = _weaponData;
					goto IL_1001;
					IL_12d4:
					((TreasureReelUI)(object)list).SetRewardIcon(spriteName, text7);
					prizeType = PrizeType.POWERUP;
					goto IL_0ee7;
					IL_1001:
					gameObject5 = (GameObject)(gameObject5 + 1);
				}
				while ((nint)gameObject5 < size);
			}
			if (_currentTreasureLevel == 3)
			{
				bool flag90 = (object)_Ribbons == null;
				_Ribbons.MakeRibbons3();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 2054 Invalid \"Jump target not found in method: 0x186D40E80\"");
			GameObject gameObject6 = default(GameObject);
			obj6 = gameObject6;
		}
		UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(obj6);
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-78), the output could be wrong!");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 117 ConditionalJump @-1, v77 @ ZF_v8 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 129 ConditionalJump @-1, v535 @ ZF_v9 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 149 ConditionalJump @-1, v536 @ ZF_v10 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 219 ConditionalJump @-1, v537 @ ZF_v15 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 237 ConditionalJump @-1, v538 @ ZF_v16 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 279 ConditionalJump @-1, v539 @ ZF_v19 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 367 ConditionalJump @-1, v541 @ ZF_v28 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 559 ConditionalJump @-1, v542 @ ZF_v40 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 617 ConditionalJump @-1, v543 @ ZF_v43 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 691 ConditionalJump @-1, v359 @ TEMP_v23 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 703 ConditionalJump @-1, v544 @ ZF_v48 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 716 ConditionalJump @-1, v1131 @ TEMP_v24 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 773 ConditionalJump @-1, v545 @ ZF_v52 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 786 ConditionalJump @-1, v546 @ ZF_v53 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 798 ConditionalJump @-1, v547 @ ZF_v54 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 827 ConditionalJump @-1, v548 @ ZF_v123 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 904 ConditionalJump @-1, v549 @ ZF_v127 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 916 ConditionalJump @-1, v550 @ ZF_v128 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 989 ConditionalJump @-1, v551 @ ZF_v132 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1001 ConditionalJump @-1, v552 @ ZF_v133 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1093 ConditionalJump @-1, v553 @ ZF_v138 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1171 ConditionalJump @-1, v554 @ ZF_v146 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1183 ConditionalJump @-1, v366 @ TEMP_v65 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1195 ConditionalJump @-1, v555 @ ZF_v148 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1207 ConditionalJump @-1, v1132 @ TEMP_v66 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1266 ConditionalJump @-1, v556 @ ZF_v152 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1279 ConditionalJump @-1, v557 @ ZF_v141 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1291 ConditionalJump @-1, v558 @ ZF_v142 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1333 ConditionalJump @-1, v370 @ TEMP_v34 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1345 ConditionalJump @-1, v560 @ ZF_v61 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1357 ConditionalJump @-1, v371 @ TEMP_v35 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1370 ConditionalJump @-1, v561 @ ZF_v63 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1395 ConditionalJump @-1, v562 @ ZF_v87 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1418 ConditionalJump @-1, v563 @ ZF_v89 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1431 ConditionalJump @-1, v564 @ ZF_v90 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1454 ConditionalJump @-1, v565 @ ZF_v92 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1467 ConditionalJump @-1, v566 @ ZF_v93 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1490 ConditionalJump @-1, v567 @ ZF_v95 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1503 ConditionalJump @-1, v568 @ ZF_v96 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1526 ConditionalJump @-1, v569 @ ZF_v98 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1539 ConditionalJump @-1, v570 @ ZF_v99 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1562 ConditionalJump @-1, v571 @ ZF_v101 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1575 ConditionalJump @-1, v572 @ ZF_v102 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1598 ConditionalJump @-1, v573 @ ZF_v113 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1611 ConditionalJump @-1, v574 @ ZF_v114 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1634 ConditionalJump @-1, v575 @ ZF_v116 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1647 ConditionalJump @-1, v576 @ ZF_v117 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1684 ConditionalJump @-1, v577 @ ZF_v106 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1696 ConditionalJump @-1, v578 @ ZF_v107 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1708 ConditionalJump @-1, v579 @ ZF_v108 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1724 ConditionalJump @-1, v580 @ ZF_v109 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1736 ConditionalJump @-1, v581 @ ZF_v110 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1749 ConditionalJump @-1, v582 @ ZF_v111 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1760 ConditionalJump @-1, v583 @ ZF_v112 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1775 ConditionalJump @-1, v584 @ ZF_v76 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1788 ConditionalJump @-1, v585 @ ZF_v77 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1812 ConditionalJump @-1, v586 @ ZF_v80 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1825 ConditionalJump @-1, v587 @ ZF_v81 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1840 ConditionalJump @-1, v588 @ ZF_v82 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1856 ConditionalJump @-1, v589 @ ZF_v83 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1868 ConditionalJump @-1, v590 @ ZF_v84 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1881 ConditionalJump @-1, v591 @ ZF_v85 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1892 ConditionalJump @-1, v592 @ ZF_v86 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1909 ConditionalJump @-1, v593 @ ZF_v69 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1921 ConditionalJump @-1, v594 @ ZF_v70 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1938 ConditionalJump @-1, v595 @ ZF_v71 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1951 ConditionalJump @-1, v596 @ ZF_v72 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1963 ConditionalJump @-1, v597 @ ZF_v73 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1974 ConditionalJump @-1, v598 @ ZF_v74 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 2038 ConditionalJump @-1, v599 @ ZF_v122 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 103 ConditionalJump @-1, v61 @ ZF_v2 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 204 ConditionalJump @-1, v600 @ ZF_v14 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 265 ConditionalJump @-1, v601 @ ZF_v18 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 352 ConditionalJump @-1, v540 @ ZF_v27 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 431 ConditionalJump @-1, v1328 @ ZF_v32 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 677 ConditionalJump @-1, v602 @ ZF_v46 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1671 ConditionalJump @-1, v603 @ ZF_v105 (System.Boolean) --- -1 Nop");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Branch target not in ISIL to IL map: 1321 ConditionalJump @-1, v559 @ ZF_v59 (System.Boolean) --- -1 Nop");
		/*Error: End of method reached without returning.*/;
	}

	public unsafe void AnimateIn()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0806: Expected O, but got Ref
		//IL_00e5: Expected O, but got Ref
		//IL_0875: Expected O, but got Ref
		//IL_01cf: Expected O, but got Ref
		//IL_08b3: Expected I, but got O
		//IL_090b: Expected O, but got Ref
		//IL_02b5: Expected O, but got Ref
		//IL_0318: Expected O, but got Ref
		//IL_03f5: Expected O, but got Ref
		//IL_0515: Expected O, but got Ref
		//IL_0532: Expected O, but got Ref
		//IL_0546: Expected native int or pointer, but got O
		//IL_055e: Expected O, but got Ref
		//IL_099c->IL0795: Incompatible stack heights: 1 vs 0
		//IL_007b->IL0795: Incompatible stack heights: 1 vs 0
		//IL_00a7->IL0795: Incompatible stack heights: 1 vs 0
		//IL_03e7->IL03e7: Incompatible stack heights: 19 vs 18
		//IL_04e6->IL04e6: Incompatible stack heights: 19 vs 18
		//IL_05d0->IL0795: Incompatible stack heights: 18 vs 0
		//IL_05ff->IL0795: Incompatible stack heights: 18 vs 0
		//IL_062e->IL0795: Incompatible stack heights: 18 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		if ((object)PowerParticles != null)
		{
			PowerParticles.Play(withChildren: true);
			Material powerParticlesMaterial = _powerParticlesMaterial;
			if ((object)_powerParticlesMaterial != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11C30]");
				_ = 0;
				bool flag = ((UnityEngine.Object)powerParticlesMaterial).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Material.SetColorImpl_Injected(((UnityEngine.Object)powerParticlesMaterial).m_CachedPtr, BaseColorProperty, ref *(Color*)obj3);
				if (_PauseOnAnimIntro)
				{
					Debug.Break();
				}
				_isPlaying = false;
				if ((object)VFXAnimation != null)
				{
					Image componentInParent = VFXAnimation.GetComponentInParent<Image>();
					if (_playerOptions != null)
					{
						PlayerOptionsData config = _playerOptions.Config;
						if (config != null)
						{
							bool flag2 = (object)componentInParent == null;
							Color color = componentInParent.color;
							Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							componentInParent.color = color2;
							bool flag3 = (object)VFXAnimation == null;
							VFXAnimation.Play();
							Sequence sequence = DOTween.Sequence();
							bool flag4 = (object)Panel == null;
							Transform transform = Panel.transform;
							bool flag5 = (object)transform == null;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ rax_v46 (UnityEngine.Transform)+10]");
							bool flag6 = (nint)0 == 0;
							object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ rax_v46 (UnityEngine.Transform)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj4);
							bool flag7 = (object)Panel == null;
							Transform transform2 = Panel.transform;
							bool flag8 = (object)transform2 == null;
							_ = 180f;
							Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
							transform2.localEulerAngles = localEulerAngles;
							bool flag9 = (object)OpenButton == null;
							SelectableUI component = OpenButton.GetComponent<SelectableUI>();
							bool flag10 = (object)component == null;
							component.UpdateAlternateSelectionIconColour();
							bool flag11 = (object)OpenButton == null;
							Transform transform3 = OpenButton.transform;
							nint num = (nint)typeof(Vector3);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ rdx_v32 (Il2CppClass<UnityEngine.Vector3>)+B8]");
							nint num2 = 0;
							bool flag12 = (object)transform3 == null;
							_ = Vector3.zeroVector;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1049 @ rax_v57 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1230 @ rax_v55 (UnityEngine.Transform)+10]");
							bool flag13 = (nint)0 == 0;
							object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1230 @ rax_v55 (UnityEngine.Transform)+10]");
							Transform.set_localScale_Injected((IntPtr)0, ref *(Vector3*)obj5);
							bool flag14 = (object)OpenButton == null;
							Transform transform4 = OpenButton.transform;
							bool flag15 = (object)transform4 == null;
							_ = 180f;
							Vector3 localEulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							transform4.localEulerAngles = localEulerAngles2;
							bool flag16 = (object)_Panel == null;
							Image component2 = _Panel.GetComponent<Image>();
							bool flag17 = (object)component2 == null;
							Color color3 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
							_ = 0;
							component2.color = color3;
							bool flag18 = (object)_IdleTreasureChest == null;
							_IdleTreasureChest.Play(hideWhenDone: false, 0.95f);
							TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(Panel, 1f, 0.13f);
							if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
							{
								bool flag19 = sequence == null;
								Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, sequence.lastTweenInsertTime);
							}
							Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							_ = 0;
							TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(Panel, endValue, 0.13f);
							TweenCallback tweenCallback = delegate
							{
								//IL_00bd: Expected I4, but got I8
								if (_idleTimer != null)
								{
									TweenExtensions.Kill(_idleTimer);
								}
								TweenCallback callback = delegate
								{
									_IdleTreasureChest.Play();
								};
								Tween tween = DOVirtual.DelayedCall(3.0000002f, callback, ignoreTimeScale: false);
								if (tween != null && tween._003Cactive_003Ek__BackingField && !tween.creationLocked)
								{
									tween.loops = -1;
									if (((ABSSequentiable)tween).tweenType == TweenType.Tweener)
									{
										tween.fullDuration = 1f / 0f;
									}
								}
								_idleTimer = tween;
							};
							if (tweenerCore != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1326 @ rax_v71 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
								if ((nint)0 == 0)
								{
								}
							}
							if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)tweenerCore, false))
							{
								bool flag20 = sequence == null;
								Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)tweenerCore, sequence.lastTweenInsertTime);
							}
							Sequence sequence4 = TweenSettingsExtensions.AppendInterval(sequence, 0.1f);
							bool flag21 = IsLocalPlayerControllingUi();
							object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 103));
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
							System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
							_ = 0;
							_ = 0;
							object arg = default(object);
							System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
							System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-19]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ rbp_v1-9]");
							_ = 0;
							string message = string.FormatHelper((IFormatProvider)null, "Am I Controlling OpenTreasurePage UI? {0}", args);
							Debug.Log(message);
							if (IsLocalPlayerControllingUi())
							{
								TweenCallback tweenCallback2 = delegate
								{
									//IL_0206: Expected O, but got Ref
									Transform target = OpenButtonLeftArrow.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOLocalMoveX(target, -5f, 0f);
									Transform target2 = OpenButtonRightArrow.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOLocalMoveX(target2, 5f, 0f);
									Transform transform5 = OpenButtonLeftArrow.transform;
									Transform parent = transform5.parent;
									GameObject gameObject = parent.gameObject;
									gameObject.SetActive(value: true);
									OpenButtonLeftArrow.SetActive(value: true);
									OpenButtonRightArrow.SetActive(value: true);
									OpenButton.SetActive(value: true);
									Transform target3 = OpenButtonLeftArrow.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOLocalMoveX(target3, -168f, _inAnimationSpeed);
									Transform target4 = OpenButtonRightArrow.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOLocalMoveX(target4, 168f, _inAnimationSpeed);
									Transform target5 = OpenButton.transform;
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore6 = ShortcutExtensions.DOScale(target5, 1f, _inAnimationSpeed);
									TweenCallback tweenCallback3 = delegate
									{
										Selectable component3 = OpenButton.GetComponent<Selectable>();
										component3.Select();
									};
									if (tweenerCore6 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
										if ((nint)0 == 0)
										{
										}
									}
									Transform target6 = OpenButton.transform;
									object obj7 = default(object);
									TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore7 = ShortcutExtensions.DOLocalRotate(target6, (Vector3)(&obj7), _inAnimationSpeed);
									TweenCallback tweenCallback4 = delegate
									{
										Button component3 = OpenButton.GetComponent<Button>();
										UnityAction call = OpenTreasure;
										component3.m_OnClick.AddListener(call);
									};
									if (tweenerCore7 != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rax_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
										if ((nint)0 == 0)
										{
										}
									}
								};
								Tween t2;
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
											return;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										t2 = null;
										message2 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
									}
									else
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
										if ((nint)0 == 0)
										{
											_ = 1;
										}
										t2 = null;
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
									t2 = null;
									message2 = "You can't add elements to a NULL Sequence";
								}
								Debugger.LogWarning(message2, t2);
								return;
							}
							if ((object)OpenButtonLeftArrow != null)
							{
								OpenButtonLeftArrow.SetActive(value: false);
								if ((object)OpenButtonRightArrow != null)
								{
									OpenButtonRightArrow.SetActive(value: false);
									if ((object)OpenButton != null)
									{
										OpenButton.SetActive(value: false);
										return;
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

	public unsafe void AnimateOut()
	{
		//IL_00e6: Expected O, but got Ref
		//IL_0164: Expected O, but got Ref
		//IL_048c: Expected O, but got Ref
		DoneButtonLeftArrow.SetActive(value: false);
		DoneButtonRightArrow.SetActive(value: false);
		Button component = OpenButton.GetComponent<Button>();
		component.m_OnClick.RemoveAllListeners();
		Sequence sequence = DOTween.Sequence();
		TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(Panel, 0f, _outAnimationSpeed);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t, false))
		{
			Sequence sequence2 = Sequence.DoInsert(sequence, (Tween)t, ((Tween)sequence).duration);
		}
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> t2 = ShortcutExtensions.DOLocalRotate(Panel, (Vector3)(&obj), _outAnimationSpeed, RotateMode.LocalAxisAdd);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t2, false))
		{
			Sequence sequence3 = Sequence.DoInsert(sequence, (Tween)t2, sequence.lastTweenInsertTime);
		}
		Transform target = DoneButton.transform;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> t3 = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj), _outAnimationSpeed, RotateMode.LocalAxisAdd);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t3, false))
		{
			Sequence sequence4 = Sequence.DoInsert(sequence, (Tween)t3, sequence.lastTweenInsertTime);
		}
		Transform target2 = DoneButton.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t4 = ShortcutExtensions.DOScale(target2, (Vector3)(&obj), _outAnimationSpeed);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t4, false))
		{
			Sequence sequence5 = Sequence.DoInsert(sequence, (Tween)t4, sequence.lastTweenInsertTime);
		}
		GameObject gameObject = _OpenTreasureChest.gameObject;
		Transform target3 = gameObject.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t5 = ShortcutExtensions.DOScale(target3, 0f, _outAnimationSpeed);
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t5, false))
		{
			Sequence sequence6 = Sequence.DoInsert(sequence, (Tween)t5, sequence.lastTweenInsertTime);
		}
		GameObject gameObject2 = _OpenTreasureChestFront.gameObject;
		Transform target4 = gameObject2.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> t6 = ShortcutExtensions.DOScale(target4, 0f, _outAnimationSpeed);
		TweenCallback tweenCallback2;
		Tween t7;
		object message;
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence, (Tween)t6, false))
		{
			Sequence sequence7 = Sequence.DoInsert(sequence, (Tween)t6, sequence.lastTweenInsertTime);
			TweenCallback tweenCallback = delegate
			{
				View.Hide();
				Fireworks.OrderInLayer(_fireworksSortingOrder);
			};
			tweenCallback2 = tweenCallback;
		}
		else
		{
			TweenCallback tweenCallback3 = delegate
			{
				View.Hide();
				Fireworks.OrderInLayer(_fireworksSortingOrder);
			};
			bool flag = sequence == null;
			tweenCallback2 = tweenCallback3;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				t7 = null;
				message = "You can't add elements to a NULL Sequence";
				goto IL_04fb;
			}
		}
		if (((Tween)sequence)._003Cactive_003Ek__BackingField)
		{
			if (!((Tween)sequence).creationLocked)
			{
				if (tweenCallback2 != null)
				{
					Sequence sequence8 = Sequence.DoInsertCallback(sequence, tweenCallback2, ((Tween)sequence).duration);
				}
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t7 = null;
			message = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			t7 = null;
			message = "You can't add elements to an inactive/killed Sequence";
		}
		goto IL_04fb;
		IL_04fb:
		Debugger.LogWarning(message, t7);
	}

	public void MakeRibbons()
	{
		if (!_isSkipped)
		{
			_Ribbons.MakeRibbons();
			TreasurePlaybackSettings currentPlayback = _currentPlayback;
			int howMany = default(int);
			_Ribbons.Play(1.3f, 0.1f, currentPlayback.RibbonLoopAmount, howMany);
		}
	}

	protected override void OnHideStart(GameObject g)
	{
		base.OnHideStart(g);
		InfoPanel.Reset();
		AddressableCache.ReleaseCustomOperationHandleGroup(_treasureCacheGroupName);
	}

	protected override void OnHideFinish(GameObject g)
	{
		base.OnHideFinish(g);
		ExitMultiplayerControl();
		FireTreasureFinishedEvents();
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		Treasure currentTreasure = _currentTreasure;
		if (_currentTreasure != null)
		{
			return currentTreasure.openingPlayer;
		}
		return (VampireSurvivors.Objects.Characters.CharacterController)(object)new NullReferenceException();
	}

	private unsafe void FireTreasureFinishedEvents()
	{
		//IL_0023: Expected O, but got I4
		//IL_002b: Expected O, but got Ref
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_019d: Expected I, but got O
		//IL_01b9: Expected O, but got I
		if (_prizes != null)
		{
			List<TreasurePrizeTypePair> prizes = _prizes;
			List<TreasurePrizeTypePair>.Enumerator enumerator = default(List<TreasurePrizeTypePair>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<TreasurePrizeTypePair>.Enumerator enumerator2 = (List<TreasurePrizeTypePair>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			if (_signalBus != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0620");
				Debug.Log("Firing treasure completed signal");
				if (_currentTreasure != null && _signalBus != null)
				{
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj3 = default(object);
					object obj2 = obj3 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					IntPtr intPtr = default(IntPtr);
					num = intPtr;
					object signal = (IntPtr)prizes;
					bool requireDeclaration = default(bool);
					_signalBus.InternalFire((Type)num, signal, (object)null, requireDeclaration);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private IEnumerator PlayMultiplayerRandomisation()
	{
		_003CPlayMultiplayerRandomisation_003Ed__111 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void Play(int level)
	{
		//IL_00f1: Expected O, but got Ref
		//IL_0164: Expected O, but got I
		//IL_04c3: Expected I, but got O
		//IL_04f4: Expected O, but got I
		//IL_0251: Expected O, but got I4
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Expected O, but got Unknown
		//IL_03ed: Expected O, but got I4
		//IL_0373: Expected O, but got I4
		//IL_02ee: Expected O, but got I4
		GameObject openButtonLeftArrow = OpenButtonLeftArrow;
		if ((object)OpenButtonLeftArrow != null)
		{
			OpenButtonLeftArrow.SetActive(value: false);
			openButtonLeftArrow = OpenButtonRightArrow;
			if ((object)OpenButtonRightArrow != null)
			{
				OpenButtonRightArrow.SetActive(value: false);
				openButtonLeftArrow = OpenButton;
				if ((object)OpenButton != null)
				{
					Transform target = OpenButton.transform;
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 0f, 0.15f);
					openButtonLeftArrow = OpenButton;
					if ((object)OpenButton != null)
					{
						Transform target2 = OpenButton.transform;
						List<TreasureReelUI>.Enumerator enumerator = default(List<TreasureReelUI>.Enumerator);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&enumerator), 0.15f, RotateMode.LocalAxisAdd);
						openButtonLeftArrow = OpenButton;
						if ((object)OpenButton != null)
						{
							SelectableUI component = OpenButton.GetComponent<SelectableUI>();
							if ((object)component != null)
							{
								openButtonLeftArrow = (GameObject)(object)SelectableUI.SetSelectorVisibility;
								if (SelectableUI.SetSelectorVisibility != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rcx_v4 (UnityEngine.GameObject)+40]");
									openButtonLeftArrow = (GameObject)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v151 @ rcx_v4 (UnityEngine.GameObject)+18] (should have been resolved before IL gen)");
								}
								TreasurePlaybackSettings currentPlayback = _currentPlayback;
								if (_currentPlayback != null && currentPlayback.Reels != null)
								{
									List<TreasureReelUI>.Enumerator enumerator2 = default(List<TreasureReelUI>.Enumerator);
									if (enumerator2.MoveNext())
									{
										TreasureReelUI treasureReelUI = null;
										throw new NullReferenceException();
									}
									nint num = (nint)typeof(GM);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rax_v24 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
									nint num2 = 0;
									GameManager core = GM.Core;
									bool flag = (object)GM.Core == null;
									openButtonLeftArrow = (GameObject)num2;
									if (!flag)
									{
										if (core._mainCharacters != null)
										{
											List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
											if (mainCharacters._size > 1)
											{
												_003CPlayMultiplayerRandomisation_003Ed__111 obj = null;
												obj._003C_003E1__state = 0;
												obj._003C_003E4__this = this;
												Coroutine winningPlayerRoutine = StartCoroutine(obj);
												_winningPlayerRoutine = winningPlayerRoutine;
											}
										}
										_animationTime = 0f;
										SoundManager.StopSound(_treasure1SfxType);
										SoundManager.StopSound(_treasure2SfxType);
										SoundManager.StopSound(_treasure3SfxType);
										openButtonLeftArrow = (GameObject)(level - 1);
										bool flag2 = level == 1;
										float time = default(float);
										if (!flag2)
										{
											openButtonLeftArrow = (GameObject)(openButtonLeftArrow - 1);
											if (!flag2)
											{
												if ((nint)openButtonLeftArrow == 1)
												{
													if ((object)Animator == null)
													{
														goto IL_0423;
													}
													Animator.SetBool(Play3, value: true);
													SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
													soundConfig.Rate = 1f;
													soundConfig.Volume = (float?)(object)1;
													PlaySoundResult playSoundResult = SoundManager.PlaySound(_treasure3SfxType, soundConfig, 0f, 10, time);
													_audioClipLength = 19.077f;
													PlayFireworks();
												}
											}
											else
											{
												if ((object)Animator == null)
												{
													goto IL_0423;
												}
												Animator.SetBool(Play2, value: true);
												SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
												soundConfig2.Rate = 1f;
												soundConfig2.Volume = (float?)(object)1;
												PlaySoundResult playSoundResult2 = SoundManager.PlaySound(_treasure2SfxType, soundConfig2, 0f, 10, time);
												_audioClipLength = 14.588f;
											}
										}
										else
										{
											if ((object)Animator == null)
											{
												goto IL_0423;
											}
											Animator.SetBool(Play1, value: true);
											SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
											soundConfig3.Rate = 1f;
											soundConfig3.Volume = (float?)(object)1;
											PlaySoundResult playSoundResult3 = SoundManager.PlaySound(_treasure1SfxType, soundConfig3, 0f, 10, time);
											_audioClipLength = 9.573f;
										}
										_isPlaying = true;
										SetSkip(level);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0423;
		IL_0423:
		throw new NullReferenceException();
	}

	private unsafe void TweenCoins()
	{
		//IL_0008: Expected O, but got Ref
		//IL_001a: Expected O, but got I8
		//IL_082a: Expected I, but got O
		//IL_086b: Expected O, but got Ref
		//IL_0148: Expected O, but got Ref
		//IL_016a: Expected O, but got Ref
		//IL_017e: Expected native int or pointer, but got O
		//IL_0191: Expected O, but got Ref
		//IL_023c: Expected O, but got I4
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_022e: Expected O, but got I
		//IL_0254: Expected O, but got Ref
		//IL_02b7: Expected O, but got I4
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected O, but got Unknown
		//IL_0339: Expected O, but got Ref
		//IL_03b7: Expected F4, but got I
		//IL_03d6: Expected F4, but got I4
		//IL_0655: Expected O, but got Ref
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a3: Expected O, but got Unknown
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Expected O, but got Unknown
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04db: Expected O, but got Unknown
		//IL_0906: Expected O, but got I4
		//IL_0916: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Expected O, but got Unknown
		//IL_06d4: Expected O, but got I4
		//IL_06eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Expected O, but got Unknown
		//IL_08a6->IL07ef: Incompatible stack heights: 1 vs 0
		//IL_0642->IL07ef: Incompatible stack heights: 1 vs 0
		//IL_06bc->IL07ef: Incompatible stack heights: 1 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass113_0 CS_0024_003C_003E8__locals21 = new _003C_003Ec__DisplayClass113_0();
		float duration;
		TweenerCore<float, float, FloatOptions> tweenerCore3;
		if (CS_0024_003C_003E8__locals21 != null)
		{
			object obj3 = 6603577472L;
			CS_0024_003C_003E8__locals21._003C_003E4__this = this;
			if ((object)CoinsCount != null)
			{
				Transform transform = CoinsCount.transform;
				if ((object)transform != null)
				{
					Transform parent = transform.parent;
					nint num = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v390 @ rcx_v14 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num2 = 0;
					_ = Vector3.zeroVector;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rax_v16 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
					_ = 0;
					bool flag = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
					object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 57));
					Transform.set_localScale_Injected(((UnityEngine.Object)parent).m_CachedPtr, ref *(Vector3*)obj4);
					Transform transform2 = CoinsCount.transform;
					Transform parent2 = transform2.parent;
					GameObject gameObject = parent2.gameObject;
					gameObject.SetActive(value: true);
					Transform transform3 = CoinsCount.transform;
					Transform parent3 = transform3.parent;
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(parent3, 1.3f, 0.3f);
					int coinPrize = _currentTreasure.GetCoinPrize();
					object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119));
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					System.ParamsArray paramsArray = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					_ = 0;
					_ = 0;
					object arg = default(object);
					System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)paramsArray, new System.ParamsArray(arg));
					System.ParamsArray args = (System.ParamsArray)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
					_ = 0;
					string message = string.FormatHelper((IFormatProvider)null, "Tweening coin prize: {0}", args);
					Debug.Log(message);
					CS_0024_003C_003E8__locals21.coins = 0f;
					TextMeshProUGUI finalCoins = FinalCoins;
					TweenerCore<float, float, FloatOptions> tweenerCore2 = (TweenerCore<float, float, FloatOptions>)(object)"00.00";
					if ("00.00" != null)
					{
						object obj6 = "00.00" + 20;
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v8 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+10]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-29]");
						object obj7 = 0;
					}
					else
					{
						object obj7 = 0;
					}
					ReadOnlySpan<char> format = (ReadOnlySpan<char>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
					string text = System.Number.FormatInt32(coinPrize, format, null);
					FinalCoins.text = text;
					TreasurePlaybackSettings currentPlayback = _currentPlayback;
					bool flag2 = _currentPlayback == null;
					duration = currentPlayback.CoinTweenDuration;
					object obj8 = _currentTreasureLevel - 1;
					if (!flag2)
					{
						object obj9 = obj8 - 1;
						if (!flag2)
						{
							if ((nint)obj9 == 1)
							{
								duration = 14f;
							}
						}
						else
						{
							duration = 11f;
						}
					}
					else
					{
						duration = 7.5f;
					}
					if ((object)CoinsCount != null)
					{
						Color color = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
						_ = 0;
						CoinsCount.color = color;
						if (_coinTween != null)
						{
							TweenExtensions.Kill(_coinTween);
						}
						DOGetter<float> getter = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
						DOSetter<float> dOSetter = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-19]");
						((_003C_003Ec__DisplayClass113_0)(object)dOSetter)._003CTweenCoins_003Eb__1(0f);
						tweenerCore3 = DOTween.To(getter, dOSetter, coinPrize, duration);
						TweenCallback tweenCallback = delegate
						{
							//IL_004e: Expected Ref, but got F4
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A33C2]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							OpenTreasurePage openTreasurePage = CS_0024_003C_003E8__locals21._003C_003E4__this;
							float num5 = (float)CS_0024_003C_003E8__locals21 + 16f;
							string text2 = ((float*)num5)->ToString("00.00");
							openTreasurePage.CoinsCount.text = text2;
						};
						TweenCallback tweenCallback3;
						if (tweenerCore3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rax_v50 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rax_v50 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
								if ((nint)0 != 0)
								{
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
									bool flag3 = (nint)0 == 0;
									_ = 0;
									if (!flag3)
									{
										object obj10 = tweenerCore3 + 184;
										object obj11 = obj10 >> 12;
										object obj12 = obj11 & 0x1FFFFF;
										object obj13 = obj12 >> 6;
										object obj14 = obj12 & 0x3F;
										nint num4;
										do
										{
											object obj15 = 1 << (int)obj14;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r12_v5+462E0+v1091 @ rdx_v64*8]");
											object obj16 = 0 | obj15;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r12_v5+462E0+v1091 @ rdx_v64*8]");
											nint num3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r12_v5+462E0+v1091 @ rdx_v64*8]");
											if (num3 == 0)
											{
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r12_v5+462E0+v1091 @ rdx_v64*8]");
											num4 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r12_v5+462E0+v1091 @ rdx_v64*8]");
										}
										while (num4 != 0);
										TweenCallback tweenCallback2 = delegate
										{
											//IL_0017: Expected O, but got Ref
											OpenTreasurePage openTreasurePage = CS_0024_003C_003E8__locals21._003C_003E4__this;
											object obj19 = default(object);
											openTreasurePage.CoinsCount.color = (Color)(&obj19);
											OpenTreasurePage openTreasurePage2 = CS_0024_003C_003E8__locals21._003C_003E4__this;
											if (openTreasurePage2._coinSinTimer != null)
											{
												TweenExtensions.Kill(openTreasurePage2._coinSinTimer);
											}
											TweenCallback callback = CS_0024_003C_003E8__locals21._003C_003E9__4;
											OpenTreasurePage openTreasurePage3 = CS_0024_003C_003E8__locals21._003C_003E4__this;
											if (CS_0024_003C_003E8__locals21._003C_003E9__4 == null)
											{
												callback = (CS_0024_003C_003E8__locals21._003C_003E9__4 = delegate
												{
													//IL_00a7: Expected O, but got F4
													OpenTreasurePage openTreasurePage4 = CS_0024_003C_003E8__locals21._003C_003E4__this;
													Transform transform4 = openTreasurePage4.CoinsCount.transform;
													Transform parent4 = transform4.parent;
													SinScaler component = parent4.GetComponent<SinScaler>();
													object obj20 = Time.timeSinceLevelLoad;
													OpenTreasurePage openTreasurePage5 = CS_0024_003C_003E8__locals21._003C_003E4__this;
													float restartTime = default(float);
													component._restartTime = restartTime;
													Transform transform5 = openTreasurePage5.CoinsCount.transform;
													Transform parent5 = transform5.parent;
													SinScaler component2 = parent5.GetComponent<SinScaler>();
													component2.enabled = true;
												});
											}
											Tween coinSinTimer = DOVirtual.DelayedCall(0.1f, callback);
											openTreasurePage3._coinSinTimer = coinSinTimer;
										};
										tweenCallback3 = tweenCallback2;
										goto IL_054e;
									}
								}
							}
						}
						TweenCallback tweenCallback4 = delegate
						{
							//IL_0017: Expected O, but got Ref
							OpenTreasurePage openTreasurePage = CS_0024_003C_003E8__locals21._003C_003E4__this;
							object obj19 = default(object);
							openTreasurePage.CoinsCount.color = (Color)(&obj19);
							OpenTreasurePage openTreasurePage2 = CS_0024_003C_003E8__locals21._003C_003E4__this;
							if (openTreasurePage2._coinSinTimer != null)
							{
								TweenExtensions.Kill(openTreasurePage2._coinSinTimer);
							}
							TweenCallback callback = CS_0024_003C_003E8__locals21._003C_003E9__4;
							OpenTreasurePage openTreasurePage3 = CS_0024_003C_003E8__locals21._003C_003E4__this;
							if (CS_0024_003C_003E8__locals21._003C_003E9__4 == null)
							{
								callback = (CS_0024_003C_003E8__locals21._003C_003E9__4 = delegate
								{
									//IL_00a7: Expected O, but got F4
									OpenTreasurePage openTreasurePage4 = CS_0024_003C_003E8__locals21._003C_003E4__this;
									Transform transform4 = openTreasurePage4.CoinsCount.transform;
									Transform parent4 = transform4.parent;
									SinScaler component = parent4.GetComponent<SinScaler>();
									object obj20 = Time.timeSinceLevelLoad;
									OpenTreasurePage openTreasurePage5 = CS_0024_003C_003E8__locals21._003C_003E4__this;
									float restartTime = default(float);
									component._restartTime = restartTime;
									Transform transform5 = openTreasurePage5.CoinsCount.transform;
									Transform parent5 = transform5.parent;
									SinScaler component2 = parent5.GetComponent<SinScaler>();
									component2.enabled = true;
								});
							}
							Tween coinSinTimer = DOVirtual.DelayedCall(0.1f, callback);
							openTreasurePage3._coinSinTimer = coinSinTimer;
						};
						bool flag4 = tweenerCore3 == null;
						tweenCallback3 = tweenCallback4;
						if (!flag4)
						{
							goto IL_054e;
						}
						goto IL_057d;
					}
				}
			}
		}
		goto IL_07ef;
		IL_07ef:
		throw new NullReferenceException();
		IL_054e:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v847 @ rax_v50 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_057d;
		IL_057d:
		_coinTween = tweenerCore3;
		if (_heatTween != null)
		{
			TweenExtensions.Kill(_heatTween);
		}
		if (_yellowTween != null)
		{
			TweenExtensions.Kill(_yellowTween);
		}
		if (_bgTween != null)
		{
			TweenExtensions.Kill(_bgTween);
		}
		if ((object)_BGOverlay != null)
		{
			Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11C30]");
			_ = 0;
			_BGOverlay.color = color2;
			TweenerCore<Color, Color, ColorOptions> heatTween = DOTweenModuleUI.DOFade(_HeatBackground, 1f, duration);
			_heatTween = heatTween;
			Treasure currentTreasure = _currentTreasure;
			bool flag5 = _currentTreasure == null;
			if (!flag5)
			{
				object obj17 = currentTreasure._003Clevel_003Ek__BackingField - 1;
				if (!flag5)
				{
					object obj18 = obj17 - 1;
					if (!flag5)
					{
						if ((nint)obj18 == 1)
						{
							TweenerCore<Color, Color, ColorOptions> bgTween = DOTweenModuleUI.DOFade(_BGOverlay, 1f, 5f);
							_bgTween = bgTween;
							TweenerCore<Color, Color, ColorOptions> yellowTween = DOTweenModuleUI.DOFade(_YellowBackground, 1f, 3.5f);
							_yellowTween = yellowTween;
						}
					}
					else
					{
						TweenerCore<Color, Color, ColorOptions> bgTween2 = DOTweenModuleUI.DOFade(_BGOverlay, 0.75f, duration);
						_bgTween = bgTween2;
						TweenerCore<Color, Color, ColorOptions> yellowTween2 = DOTweenModuleUI.DOFade(_YellowBackground, 1f, duration);
						_yellowTween = yellowTween2;
					}
				}
				else
				{
					TweenerCore<Color, Color, ColorOptions> yellowTween3 = DOTweenModuleUI.DOFade(_YellowBackground, 0.8f, duration);
					_yellowTween = yellowTween3;
				}
				_animCanBeSkippedPastThisPoint = true;
				return;
			}
		}
		goto IL_07ef;
	}

	private unsafe void SkipCoins(float skipTime, float animationLength)
	{
		//IL_0012: Expected O, but got I8
		//IL_0067: Expected O, but got Ref
		//IL_00a6: Invalid comparison between I4 and F4
		//IL_0103: Expected F4, but got I4
		//IL_0162: Expected F4, but got I4
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected O, but got Unknown
		//IL_03c7: Expected O, but got I4
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Expected O, but got Unknown
		_003C_003Ec__DisplayClass114_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass114_0();
		object obj = 6603577472L;
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		int coinPrize = _currentTreasure.GetCoinPrize();
		CS_0024_003C_003E8__locals7.coins = 0f;
		TextMeshProUGUI finalCoins = FinalCoins;
		if ("00.00" != null)
		{
		}
		object obj2 = default(object);
		string text = System.Number.FormatInt32(coinPrize, (ReadOnlySpan<char>)(&obj2), null);
		FinalCoins.text = text;
		float num = default(float);
		float duration = animationLength - num;
		float num2 = num / animationLength;
		if (!(0f > num2))
		{
			bool flag = !(num2 > 1f);
			num = 1f;
			if (!flag)
			{
				num = 1f;
				num2 = 1f;
			}
		}
		else
		{
			num2 = 0f;
		}
		float coins = (float)coinPrize * num2;
		CS_0024_003C_003E8__locals7.coins = coins;
		if (_coinTween != null)
		{
			TweenExtensions.Kill(_coinTween);
		}
		DOGetter<float> getter = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049ADA0");
		DOSetter<float> dOSetter = null;
		((_003C_003Ec__DisplayClass114_0)(object)dOSetter)._003CSkipCoins_003Eb__1(num);
		TweenerCore<float, float, FloatOptions> tweenerCore = DOTween.To(getter, dOSetter, coinPrize, duration);
		TweenCallback tweenCallback = delegate
		{
			//IL_004e: Expected Ref, but got F4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A33C5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			OpenTreasurePage openTreasurePage = CS_0024_003C_003E8__locals7._003C_003E4__this;
			float num5 = (float)CS_0024_003C_003E8__locals7 + 16f;
			string text2 = ((float*)num5)->ToString("00.00");
			openTreasurePage.CoinsCount.text = text2;
		};
		TweenCallback tweenCallback3;
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
				if ((nint)0 != 0)
				{
					_ = 1;
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
						nint num4;
						do
						{
							object obj8 = 1 << (int)obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r15_v2+462E0+v713 @ rdx_v22*8]");
							object obj9 = 0 | obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r15_v2+462E0+v713 @ rdx_v22*8]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r15_v2+462E0+v713 @ rdx_v22*8]");
							if (num3 == 0)
							{
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r15_v2+462E0+v713 @ rdx_v22*8]");
							num4 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ r15_v2+462E0+v713 @ rdx_v22*8]");
						}
						while (num4 != 0);
						TweenCallback tweenCallback2 = delegate
						{
							//IL_0021: Expected O, but got Ref
							OpenTreasurePage openTreasurePage = CS_0024_003C_003E8__locals7._003C_003E4__this;
							object obj10 = default(object);
							openTreasurePage.CoinsCount.color = (Color)(&obj10);
						};
						tweenCallback3 = tweenCallback2;
						goto IL_02da;
					}
				}
			}
		}
		TweenCallback tweenCallback4 = delegate
		{
			//IL_0021: Expected O, but got Ref
			OpenTreasurePage openTreasurePage = CS_0024_003C_003E8__locals7._003C_003E4__this;
			object obj10 = default(object);
			openTreasurePage.CoinsCount.color = (Color)(&obj10);
		};
		bool flag3 = tweenerCore == null;
		tweenCallback3 = tweenCallback4;
		if (!flag3)
		{
			goto IL_02da;
		}
		goto IL_0309;
		IL_02da:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v467 @ rax_v19 (DG.Tweening.Core.TweenerCore`3<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>)+E8]");
		if ((nint)0 == 0)
		{
		}
		goto IL_0309;
		IL_0309:
		_coinTween = tweenerCore;
	}

	private void SetSkip(int level)
	{
		bool flag;
		bool canSkip;
		if (level == 1)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (CheckLevel1Skip(config))
			{
				goto IL_0040;
			}
			PlayerOptions playerOptions = _playerOptions;
			flag = CheckLevel1Skip(playerOptions._mainGameConfig);
		}
		else
		{
			if (level != 2)
			{
				bool flag2 = level != 3;
				canSkip = false;
				if (!flag2)
				{
					GameManager core = GM.Core;
					PlayerOptionsData config2 = core._playerOptions.Config;
					PlayerOptionsData config3 = _playerOptions.Config;
					bool flag3 = CheckLevel3Skip(config3);
					bool flag4 = !flag3;
					if (!flag4)
					{
						canSkip = false;
						if (!flag4)
						{
							canSkip = true;
						}
					}
					else
					{
						PlayerOptions playerOptions2 = _playerOptions;
						bool flag5 = _playerOptions == null;
						bool flag6 = CheckLevel3Skip(playerOptions2._mainGameConfig);
						canSkip = false;
						if (!flag5)
						{
							canSkip = true;
						}
					}
				}
				goto IL_021f;
			}
			PlayerOptionsData config4 = _playerOptions.Config;
			if (CheckLevel2Skip(config4))
			{
				goto IL_0040;
			}
			PlayerOptions playerOptions3 = _playerOptions;
			flag = CheckLevel2Skip(playerOptions3._mainGameConfig);
		}
		canSkip = flag;
		goto IL_021f;
		IL_021f:
		_canSkip = canSkip;
		_isSkipped = false;
		return;
		IL_0040:
		canSkip = true;
		goto IL_021f;
	}

	private bool CheckLevel1Skip(PlayerOptionsData config)
	{
		//IL_0270: Expected I4, but got O
		//IL_0209: Expected O, but got I4
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected I4, but got Unknown
		if (config != null && config._003CPickupCount_003Ek__BackingField != null)
		{
			int num = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.TREASURE);
			if (num >= 0)
			{
				if (config._003CPickupCount_003Ek__BackingField == null)
				{
					goto IL_0262;
				}
				int num2 = config._003CPickupCount_003Ek__BackingField.get_Item(ItemType.TREASURE);
				if (num2 > 50)
				{
					goto IL_015d;
				}
			}
			if (config._003CPickupCount_003Ek__BackingField != null)
			{
				int num3 = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.STATS_TREASURE_3);
				if (num3 >= 0)
				{
					if (config._003CPickupCount_003Ek__BackingField == null)
					{
						goto IL_0262;
					}
					int num4 = config._003CPickupCount_003Ek__BackingField.get_Item(ItemType.STATS_TREASURE_3);
					if (num4 >= 1)
					{
						goto IL_015d;
					}
				}
				if (config._003CPickupCount_003Ek__BackingField != null)
				{
					int num5 = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.STATS_TREASURE_1);
					if (num5 < 0)
					{
						return false;
					}
					if (config._003CPickupCount_003Ek__BackingField != null)
					{
						int num6 = config._003CPickupCount_003Ek__BackingField.get_Item(ItemType.STATS_TREASURE_1);
						object obj = num6 - 5;
						int num7 = num6 ^ 5;
						int num8 = num6 ^ obj;
						int num9 = num7 & num8;
						bool flag = num9 < 0;
						bool flag2 = (nint)obj < 0;
						return flag2 == flag;
					}
				}
			}
		}
		goto IL_0262;
		IL_015d:
		return true;
		IL_0262:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool CheckLevel2Skip(PlayerOptionsData config)
	{
		//IL_0270: Expected I4, but got O
		//IL_0209: Expected O, but got I4
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected I4, but got Unknown
		if (config != null && config._003CPickupCount_003Ek__BackingField != null)
		{
			int num = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.TREASURE);
			if (num >= 0)
			{
				if (config._003CPickupCount_003Ek__BackingField == null)
				{
					goto IL_0262;
				}
				int num2 = config._003CPickupCount_003Ek__BackingField.get_Item(ItemType.TREASURE);
				if (num2 > 50)
				{
					goto IL_015d;
				}
			}
			if (config._003CPickupCount_003Ek__BackingField != null)
			{
				int num3 = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.STATS_TREASURE_3);
				if (num3 >= 0)
				{
					if (config._003CPickupCount_003Ek__BackingField == null)
					{
						goto IL_0262;
					}
					int num4 = config._003CPickupCount_003Ek__BackingField.get_Item(ItemType.STATS_TREASURE_3);
					if (num4 >= 1)
					{
						goto IL_015d;
					}
				}
				if (config._003CPickupCount_003Ek__BackingField != null)
				{
					int num5 = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.STATS_TREASURE_1);
					if (num5 < 0)
					{
						return false;
					}
					if (config._003CPickupCount_003Ek__BackingField != null)
					{
						int num6 = config._003CPickupCount_003Ek__BackingField.get_Item(ItemType.STATS_TREASURE_1);
						object obj = num6 - 3;
						int num7 = num6 ^ 3;
						int num8 = num6 ^ obj;
						int num9 = num7 & num8;
						bool flag = num9 < 0;
						bool flag2 = (nint)obj < 0;
						return flag2 == flag;
					}
				}
			}
		}
		goto IL_0262;
		IL_015d:
		return true;
		IL_0262:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private bool CheckLevel3Skip(PlayerOptionsData config)
	{
		//IL_01eb: Expected I4, but got O
		//IL_015d: Expected O, but got I4
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected I4, but got Unknown
		if (config != null && config._003CPickupCount_003Ek__BackingField != null)
		{
			int num = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.STATS_TREASURE_3);
			if (num >= 0)
			{
				if (config._003CPickupCount_003Ek__BackingField == null)
				{
					goto IL_01dd;
				}
				int num2 = config._003CPickupCount_003Ek__BackingField.get_Item(ItemType.STATS_TREASURE_3);
				if (num2 >= 50)
				{
					return true;
				}
			}
			if (config._003CPickupCount_003Ek__BackingField != null)
			{
				int num3 = config._003CPickupCount_003Ek__BackingField.FindEntry(ItemType.TREASURE);
				if (num3 < 0)
				{
					return false;
				}
				if (config._003CPickupCount_003Ek__BackingField != null)
				{
					int num4 = config._003CPickupCount_003Ek__BackingField.get_Item(ItemType.TREASURE);
					object obj = num4 - 200;
					int num5 = num4 ^ 0xC8;
					int num6 = num4 ^ obj;
					int num7 = num5 & num6;
					bool flag = num7 < 0;
					bool flag2 = (nint)obj < 0;
					bool flag3 = obj == null;
					bool flag4 = flag2 == flag;
					bool flag5 = !flag3;
					return flag5 & flag4;
				}
			}
		}
		goto IL_01dd;
		IL_01dd:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void Reset()
	{
		//IL_001e: Expected O, but got Ref
		if (PlaybackLevels != null)
		{
			List<TreasurePlaybackSettings>.Enumerator enumerator = default(List<TreasurePlaybackSettings>.Enumerator);
			if (enumerator.MoveNext())
			{
				TreasureReelUI treasureReelUI = null;
				TreasureReelUI treasureReelUI2 = (TreasureReelUI)(&enumerator);
				throw new NullReferenceException();
			}
			if ((object)VFXAnimation != null)
			{
				Transform transform = VFXAnimation.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform target = DoneButtonLeftArrow.transform;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMoveX(target, -5f, 0f);
				Transform target2 = DoneButtonRightArrow.transform;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOLocalMoveX(target2, 5f, 0f);
				DoneButtonLeftArrow.SetActive(value: false);
				DoneButtonRightArrow.SetActive(value: false);
				Transform target3 = OpenButtonLeftArrow.transform;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOLocalMoveX(target3, -5f, 0f);
				Transform target4 = OpenButtonRightArrow.transform;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOLocalMoveX(target4, 5f, 0f);
				OpenButtonLeftArrow.SetActive(value: false);
				OpenButtonRightArrow.SetActive(value: false);
				OpenButton.SetActive(value: true);
				DoneButton.SetActive(value: false);
				Transform transform2 = DoneButton.transform;
				bool flag2 = (object)transform2 == null;
				bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
				Vector3 value2 = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value2);
				bool flag4 = (object)OpenButton == null;
				Transform transform3 = OpenButton.transform;
				bool flag5 = (object)transform3 == null;
				bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
				bool flag7 = (object)FinalCoins == null;
				Transform transform4 = FinalCoins.transform;
				bool flag8 = (object)transform4 == null;
				Transform parent = transform4.parent;
				bool flag9 = (object)parent == null;
				GameObject gameObject = parent.gameObject;
				bool flag10 = (object)gameObject == null;
				gameObject.SetActive(value: false);
				bool flag11 = (object)_OpenTreasureChest == null;
				Transform transform5 = _OpenTreasureChest.transform;
				bool flag12 = (object)transform5 == null;
				bool flag13 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref value2);
				bool flag14 = (object)_OpenTreasureChestFront == null;
				Transform transform6 = _OpenTreasureChestFront.transform;
				bool flag15 = (object)transform6 == null;
				bool flag16 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref value);
				bool flag17 = (object)_OpenTreasureChest == null;
				_OpenTreasureChest.Reset();
				bool flag18 = (object)_OpenTreasureChestFront == null;
				_OpenTreasureChestFront.Reset();
				bool flag19 = (object)_IdleTreasureChest == null;
				_IdleTreasureChest.Reset();
				bool flag20 = (object)InfoPanel == null;
				InfoPanel.Reset();
				bool flag21 = (object)CoinsCount == null;
				Transform transform7 = CoinsCount.transform;
				bool flag22 = (object)transform7 == null;
				Transform parent2 = transform7.parent;
				bool flag23 = (object)parent2 == null;
				SinScaler component = parent2.GetComponent<SinScaler>();
				bool flag24 = (object)component == null;
				component.enabled = false;
				bool flag25 = (object)CoinsCount == null;
				Transform transform8 = CoinsCount.transform;
				bool flag26 = (object)transform8 == null;
				Transform parent3 = transform8.parent;
				bool flag27 = (object)parent3 == null;
				SinScaler component2 = parent3.GetComponent<SinScaler>();
				bool flag28 = (object)component2 == null;
				component2._restartTime = 0f;
				bool flag29 = (object)CoinsCount == null;
				Transform transform9 = CoinsCount.transform;
				bool flag30 = (object)transform9 == null;
				Transform parent4 = transform9.parent;
				bool flag31 = (object)parent4 == null;
				bool flag32 = ((UnityEngine.Object)parent4).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)parent4).m_CachedPtr, ref value2);
				bool flag33 = (object)CoinsCount == null;
				Transform transform10 = CoinsCount.transform;
				bool flag34 = (object)transform10 == null;
				Transform parent5 = transform10.parent;
				bool flag35 = (object)parent5 == null;
				GameObject gameObject2 = parent5.gameObject;
				bool flag36 = (object)gameObject2 == null;
				gameObject2.SetActive(value: false);
				FireworksManager.Clear();
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void Skip()
	{
		//IL_009e: Expected I8, but got O
		//IL_0082: Expected I8, but got O
		//IL_0057: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x186D44E60\"");
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).SkipTreasureAnimation((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rbx_v4 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	private void PerformSkip()
	{
		//IL_009b: Expected O, but got I4
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_045d: Expected O, but got I4
		//IL_0505->IL0389: Incompatible stack heights: 1 vs 0
		//IL_0389->IL0389: Incompatible stack heights: 1 vs 0
		if (_isSkipped)
		{
			return;
		}
		TreasurePlaybackSettings currentPlayback = _currentPlayback;
		_isSkipped = true;
		if (_currentPlayback != null)
		{
			if (currentPlayback.SkipTime > _animationTime)
			{
				Treasure currentTreasure = _currentTreasure;
				bool flag = _currentTreasure == null;
				if (flag)
				{
					goto IL_040f;
				}
				object obj = currentTreasure._003Clevel_003Ek__BackingField - 1;
				float t;
				SfxType sfxType;
				if (!flag)
				{
					object obj2 = obj - 1;
					if (!flag)
					{
						if ((nint)obj2 != 1)
						{
							goto IL_01f5;
						}
						_animationTime = currentPlayback.SkipTime;
						t = currentPlayback.SkipTime / _audioClipLength;
						SoundManager.StopSound(_treasure3SfxType);
						sfxType = _treasure3SfxType;
					}
					else
					{
						if (_currentPlayback == null)
						{
							goto IL_040f;
						}
						_animationTime = currentPlayback.SkipTime;
						t = currentPlayback.SkipTime / _audioClipLength;
						SoundManager.StopSound(_treasure2SfxType);
						sfxType = _treasure2SfxType;
					}
				}
				else
				{
					if (_currentPlayback == null)
					{
						goto IL_040f;
					}
					_animationTime = currentPlayback.SkipTime;
					t = currentPlayback.SkipTime / _audioClipLength;
					FinishHeat();
					SoundManager.StopSound(_treasure1SfxType);
					sfxType = _treasure1SfxType;
				}
				SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
				soundConfig.Rate = 1f;
				soundConfig.Volume = (float?)(object)1;
				float num = Mathf.Lerp(0f, _audioClipLength, t);
				float time = default(float);
				PlaySoundResult playSoundResult = SoundManager.PlaySound(sfxType, soundConfig, 0f, 10, time);
			}
			goto IL_01f5;
		}
		goto IL_040f;
		IL_01f5:
		TreasurePlaybackSettings currentPlayback2 = _currentPlayback;
		if (_currentPlayback != null)
		{
			SkipCoins(_animationTime, currentPlayback2.CoinTweenDuration);
			GameManager core = GM.Core;
			if ((object)GM.Core != null)
			{
				if (core._mainCharacters != null)
				{
					List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
					if (mainCharacters._size > 1)
					{
						if (_winningPlayerRoutine != null)
						{
							StopCoroutine(_winningPlayerRoutine);
						}
						Treasure currentTreasure2 = _currentTreasure;
						VampireSurvivors.Objects.Characters.CharacterController winningPlayer = currentTreasure2.winningPlayer;
						CharacterData currentSkinData = winningPlayer._currentSkinData;
						Treasure currentTreasure3 = _currentTreasure;
						VampireSurvivors.Objects.Characters.CharacterController winningPlayer2 = currentTreasure3.winningPlayer;
						CharacterData currentSkinData2 = winningPlayer2._currentSkinData;
						Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField, currentSkinData2._003CtextureName_003Ek__BackingField);
						_CoopRandomCharacter.sprite = sprite;
						RectTransform rectTransform = _CoopRandomCharacter.rectTransform;
						bool flag2 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
						Vector3 value = default(Vector3);
						Transform.set_localPosition_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref value);
						if (_randomCharacterSequence != null)
						{
							TweenExtensions.Complete(_randomCharacterSequence, withCallbacks: false);
						}
					}
				}
				if ((object)_Ribbons != null)
				{
					_Ribbons.ClearExisting();
					if (_animFinishedTimer != null && TweenExtensions.IsPlaying(_animFinishedTimer))
					{
						TweenExtensions.Complete(_animFinishedTimer, withCallbacks: true);
					}
					return;
				}
			}
		}
		goto IL_040f;
		IL_040f:
		throw new NullReferenceException();
	}

	public OpenTreasurePage()
	{
		List<TreasurePlaybackSettings> playbackLevels = new List<TreasurePlaybackSettings>();
		PlaybackLevels = playbackLevels;
		_prizes = new List<TreasurePrizeTypePair>();
		_weaponFrameNames = new List<string>();
		_weaponData = new Dictionary<WeaponType, List<WeaponData>>();
		_outAnimationSpeed = 0.2f;
		_inAnimationSpeed = 0.17f;
		_treasureCacheGroupName = "TreasureCache";
		base._002Ector();
	}

	static OpenTreasurePage()
	{
		int play = Animator.StringToHash("Play1");
		Play1 = play;
		int play2 = Animator.StringToHash("Play2");
		Play2 = play2;
		int play3 = Animator.StringToHash("Play3");
		Play3 = play3;
		int normalizedAnimationTimeParameter = Animator.StringToHash("Time");
		NormalizedAnimationTimeParameter = normalizedAnimationTimeParameter;
		int baseColorProperty = Shader.PropertyToID("_BaseColor");
		BaseColorProperty = baseColorProperty;
	}

	private unsafe void _003CAnimationFinished_003Eb__89_0()
	{
		//IL_0241: Expected O, but got Ref
		//IL_0310: Expected O, but got Ref
		//IL_04fb->IL05bc: Incompatible stack heights: 1 vs 0
		//IL_052a->IL05bc: Incompatible stack heights: 1 vs 0
		//IL_065d->IL05bc: Incompatible stack heights: 1 vs 0
		//IL_0580->IL05bc: Incompatible stack heights: 1 vs 0
		//IL_059e->IL05bc: Incompatible stack heights: 1 vs 0
		if ((object)DoneButtonLeftArrow != null)
		{
			Transform target = DoneButtonLeftArrow.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMoveX(target, -5f, 0f);
			if ((object)DoneButtonRightArrow != null)
			{
				Transform target2 = DoneButtonRightArrow.transform;
				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOLocalMoveX(target2, 5f, 0f);
				if ((object)DoneButtonLeftArrow != null)
				{
					Transform transform = DoneButtonLeftArrow.transform;
					if ((object)transform != null)
					{
						Transform parent = transform.parent;
						if ((object)parent != null)
						{
							GameObject gameObject = parent.gameObject;
							if ((object)gameObject != null)
							{
								gameObject.SetActive(value: true);
								if ((object)DoneButtonLeftArrow != null)
								{
									DoneButtonLeftArrow.SetActive(value: true);
									if ((object)DoneButtonRightArrow != null)
									{
										DoneButtonRightArrow.SetActive(value: true);
										if ((object)DoneButton != null)
										{
											SelectableUI component = DoneButton.GetComponent<SelectableUI>();
											if ((object)component != null)
											{
												component.UpdateAlternateSelectionIconColour();
												if ((object)DoneButton != null)
												{
													Transform transform2 = DoneButton.transform;
													bool flag = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
													Vector3 value = default(Vector3);
													Transform.set_localScale_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
													Transform transform3 = DoneButton.transform;
													object obj = default(object);
													transform3.localEulerAngles = (Vector3)(&obj);
													DoneButton.SetActive(value: true);
													Transform target3 = DoneButton.transform;
													TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOScale(target3, 1f, _inAnimationSpeed);
													TweenCallback tweenCallback = delegate
													{
														Selectable component3 = DoneButton.GetComponent<Selectable>();
														component3.Select();
													};
													if (tweenerCore3 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v853 @ rax_v35 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
														if ((nint)0 == 0)
														{
														}
													}
													Transform target4 = DoneButton.transform;
													TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore4 = ShortcutExtensions.DOLocalRotate(target4, (Vector3)(&obj), _inAnimationSpeed);
													Transform target5 = DoneButtonLeftArrow.transform;
													TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOLocalMoveX(target5, -168f, _inAnimationSpeed);
													Transform target6 = DoneButtonRightArrow.transform;
													TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore6 = ShortcutExtensions.DOLocalMoveX(target6, 168f, _inAnimationSpeed);
													HideBeams();
													Transform transform4 = CoinsCount.transform;
													Transform parent2 = transform4.parent;
													SinScaler component2 = parent2.GetComponent<SinScaler>();
													component2.enabled = false;
													Transform transform5 = CoinsCount.transform;
													Transform parent3 = transform5.parent;
													TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore7 = ShortcutExtensions.DOScale(parent3, 0f, _inAnimationSpeed);
													TweenCallback tweenCallback2 = delegate
													{
														Transform transform6 = FinalCoins.transform;
														Transform parent4 = transform6.parent;
														GameObject gameObject2 = parent4.gameObject;
														gameObject2.SetActive(value: true);
														Transform transform7 = CoinsCount.transform;
														Transform parent5 = transform7.parent;
														GameObject gameObject3 = parent5.gameObject;
														gameObject3.SetActive(value: false);
													};
													if (tweenerCore7 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v957 @ rax_v52 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
														if ((nint)0 == 0)
														{
														}
													}
													InfoPanel.Initialize(_prizes);
													_Ribbons.ClearExisting();
													GameManager core = GM.Core;
													if (core._mainCharacters == null)
													{
														return;
													}
													List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
													if (mainCharacters._size <= 1)
													{
														return;
													}
													Treasure currentTreasure = _currentTreasure;
													if (_currentTreasure != null)
													{
														VampireSurvivors.Objects.Characters.CharacterController winningPlayer = currentTreasure.winningPlayer;
														if ((object)currentTreasure.winningPlayer != null)
														{
															if (winningPlayer._player == null)
															{
																return;
															}
															Treasure currentTreasure2 = _currentTreasure;
															if (_currentTreasure != null)
															{
																VampireSurvivors.Objects.Characters.CharacterController winningPlayer2 = currentTreasure2.winningPlayer;
																if ((object)currentTreasure2.winningPlayer != null && MultiplayerManager.s_instance != null)
																{
																	MultiplayerManager.s_instance.AddPlayerToUIControl(winningPlayer2._player);
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
		throw new NullReferenceException();
	}

	private void _003CAnimationFinished_003Eb__89_1()
	{
		Selectable component = DoneButton.GetComponent<Selectable>();
		component.Select();
	}

	private void _003CAnimationFinished_003Eb__89_2()
	{
		Transform transform = FinalCoins.transform;
		Transform parent = transform.parent;
		GameObject gameObject = parent.gameObject;
		gameObject.SetActive(value: true);
		Transform transform2 = CoinsCount.transform;
		Transform parent2 = transform2.parent;
		GameObject gameObject2 = parent2.gameObject;
		gameObject2.SetActive(value: false);
	}

	private void _003COpenChest_003Eb__90_0()
	{
		_Title.SetActive(value: false);
	}

	private void _003CAnimateIn_003Eb__104_0()
	{
		//IL_00bd: Expected I4, but got I8
		if (_idleTimer != null)
		{
			TweenExtensions.Kill(_idleTimer);
		}
		TweenCallback callback = delegate
		{
			_IdleTreasureChest.Play();
		};
		Tween tween = DOVirtual.DelayedCall(3.0000002f, callback, ignoreTimeScale: false);
		if (tween != null && tween._003Cactive_003Ek__BackingField && !tween.creationLocked)
		{
			tween.loops = -1;
			if (((ABSSequentiable)tween).tweenType == TweenType.Tweener)
			{
				tween.fullDuration = 1f / 0f;
			}
		}
		_idleTimer = tween;
	}

	private void _003CAnimateIn_003Eb__104_2()
	{
		_IdleTreasureChest.Play();
	}

	private unsafe void _003CAnimateIn_003Eb__104_1()
	{
		//IL_0206: Expected O, but got Ref
		Transform target = OpenButtonLeftArrow.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOLocalMoveX(target, -5f, 0f);
		Transform target2 = OpenButtonRightArrow.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOLocalMoveX(target2, 5f, 0f);
		Transform transform = OpenButtonLeftArrow.transform;
		Transform parent = transform.parent;
		GameObject gameObject = parent.gameObject;
		gameObject.SetActive(value: true);
		OpenButtonLeftArrow.SetActive(value: true);
		OpenButtonRightArrow.SetActive(value: true);
		OpenButton.SetActive(value: true);
		Transform target3 = OpenButtonLeftArrow.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOLocalMoveX(target3, -168f, _inAnimationSpeed);
		Transform target4 = OpenButtonRightArrow.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOLocalMoveX(target4, 168f, _inAnimationSpeed);
		Transform target5 = OpenButton.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOScale(target5, 1f, _inAnimationSpeed);
		TweenCallback tweenCallback = delegate
		{
			Selectable component = OpenButton.GetComponent<Selectable>();
			component.Select();
		};
		if (tweenerCore5 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ rax_v20 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
		Transform target6 = OpenButton.transform;
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore6 = ShortcutExtensions.DOLocalRotate(target6, (Vector3)(&obj), _inAnimationSpeed);
		TweenCallback tweenCallback2 = delegate
		{
			Button component = OpenButton.GetComponent<Button>();
			UnityAction call = OpenTreasure;
			component.m_OnClick.AddListener(call);
		};
		if (tweenerCore6 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ rax_v25 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private void _003CAnimateIn_003Eb__104_3()
	{
		Selectable component = OpenButton.GetComponent<Selectable>();
		component.Select();
	}

	private void _003CAnimateIn_003Eb__104_4()
	{
		Button component = OpenButton.GetComponent<Button>();
		UnityAction call = OpenTreasure;
		component.m_OnClick.AddListener(call);
	}

	private void _003CAnimateOut_003Eb__105_0()
	{
		View.Hide();
		Fireworks.OrderInLayer(_fireworksSortingOrder);
	}

	private void _003CPlayMultiplayerRandomisation_003Eb__111_0()
	{
		_CoopCharacterParticles.Play(withChildren: true);
	}

	private void _003CPlayMultiplayerRandomisation_003Eb__111_1()
	{
		if ((object)_CoopCharacterParticles != null)
		{
			_CoopCharacterParticles.Stop();
			return;
		}
		throw new NullReferenceException();
	}
}
