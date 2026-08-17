using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Items;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI;

public class HealerPage : GameWindowedUIPage
{
	private sealed class _003C_003Ec__DisplayClass18_0
	{
		public HealerPage _003C_003E4__this;

		public ShopItemUI item;

		public TweenCallback _003C_003E9__0;

		internal void _003CPurchase_003Eb__0()
		{
			//IL_00c6: Expected I, but got O
			//IL_00e0->IL008f: Incompatible stack heights: 1 vs 0
			if ((object)_003C_003E4__this != null)
			{
				_003C_003E4__this.UpdateEggsTotal();
				if ((object)item != null)
				{
					Transform transform = item.transform;
					if ((object)transform != null)
					{
						bool flag = (object)((_003C_003Ec__DisplayClass18_0)(object)transform)._003C_003E4__this == null;
						Transform.get_localPosition_Injected((IntPtr)((_003C_003Ec__DisplayClass18_0)(object)transform)._003C_003E4__this, out Vector3 _);
						if ((object)_003C_003E4__this != null)
						{
							Vector2 pos = default(Vector2);
							_003C_003E4__this.PlayRemovalAnimation(pos);
							return;
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass31_0
	{
		public HealerPage _003C_003E4__this;

		public Vector2 pos;

		public TweenCallback _003C_003E9__0;

		internal void _003CRemoveEggs_003Eb__0()
		{
			_003C_003E4__this.UpdateEggsTotal();
			Vector2 vector = default(Vector2);
			_003C_003E4__this.PlayRemovalAnimation(vector);
		}
	}

	private sealed class _003CWaitAndTween_003Ed__22(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public HealerPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0159: Expected I4, but got I8
			//IL_01be: Expected O, but got I4
			//IL_01c7: Expected O, but got I4
			//IL_0516: Expected F4, but got I
			//IL_051f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0524: Expected O, but got Unknown
			//IL_02b9: Expected O, but got I
			//IL_0331: Expected O, but got I
			//IL_0351: Expected O, but got I
			//IL_0361: Unknown result type (might be due to invalid IL or missing references)
			//IL_0366: Expected O, but got Unknown
			//IL_0313: Expected O, but got Ref
			//IL_0689: Expected O, but got I4
			//IL_061c: Expected F4, but got I
			//IL_0625: Unknown result type (might be due to invalid IL or missing references)
			//IL_062a: Expected O, but got Unknown
			//IL_0128->IL0531: Incompatible stack heights: 2 vs 0
			//IL_01eb->IL04ae: Incompatible stack heights: 3 vs 0
			//IL_0531->IL0637: Incompatible stack heights: 7 vs 1
			//IL_0637->IL068e: Incompatible stack heights: 20 vs 2
			HealerPage healerPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				bool flag = (object)_003C_003E4__this == null;
				object obj = null;
				object obj2 = null;
				while (true)
				{
					List<GameObject> spawned = healerPage._spawned;
					bool flag2 = healerPage._spawned == null;
					if ((nint)obj2 >= spawned._size)
					{
						break;
					}
					bool flag3 = (nint)obj >= spawned._size;
					GameObject[] items = spawned._items;
					bool flag4 = spawned._items == null;
					bool flag5 = (object)items[obj] == null;
					CanvasGroup component = items[obj].GetComponent<CanvasGroup>();
					bool flag6 = (object)component == null;
					bool flag7 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
					CanvasGroup.set_alpha_Injected(((UnityEngine.Object)component).m_CachedPtr, 0f);
					obj++;
					obj2 = obj;
				}
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				bool flag8 = (object)_003C_003E4__this == null;
				bool flag9 = (object)healerPage._Grid == null;
				healerPage._Grid.enabled = false;
				List<Vector3> list = new List<Vector3>();
				object obj3 = 0;
				object obj4 = 0;
				Vector2 vector2 = default(Vector2);
				Vector2 value = default(Vector2);
				Vector2 endValue = default(Vector2);
				while (true)
				{
					List<GameObject> spawned2 = healerPage._spawned;
					bool flag10 = healerPage._spawned == null;
					if ((nint)obj4 >= spawned2._size)
					{
						break;
					}
					bool flag11 = (nint)obj3 >= spawned2._size;
					GameObject[] items2 = spawned2._items;
					bool flag12 = spawned2._items == null;
					bool flag13 = (object)items2[obj3] == null;
					RectTransform component2 = items2[obj3].GetComponent<RectTransform>();
					bool flag14 = (object)component2 == null;
					bool flag15 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
					RectTransform.get_anchoredPosition_Injected(((UnityEngine.Object)component2).m_CachedPtr, out Vector2 _);
					bool flag16 = list == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					Vector3 vector = (Vector3)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					bool flag17 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdx_v29 (UnityEngine.Vector3)+18]");
					if (num >= 0)
					{
						list.AddWithResize((Vector3)(&vector2));
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						object obj5 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						object obj6 = (nint)0 * (nint)2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						object obj7 = 0 + obj6;
						_ = 0;
					}
					bool flag18 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
					RectTransform.get_anchoredPosition_Injected(((UnityEngine.Object)component2).m_CachedPtr, out Vector2 _);
					object obj8 = Screen.width;
					bool flag19 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
					RectTransform.set_anchoredPosition_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref value);
					object obj9 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
					bool flag20 = (nint)obj9 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ rax_v36 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
					bool flag21 = (nint)0 == 0;
					float num2 = (float)obj3 * 0.03f;
					float duration = num2 + 0.15f;
					TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(component2, endValue, duration);
					List<GameObject> spawned3 = healerPage._spawned;
					bool flag22 = healerPage._spawned == null;
					bool flag23 = (nint)obj3 >= spawned3._size;
					GameObject[] items3 = spawned3._items;
					bool flag24 = spawned3._items == null;
					bool flag25 = (object)items3[obj3] == null;
					CanvasGroup component3 = items3[obj3].GetComponent<CanvasGroup>();
					bool flag26 = (object)component3 == null;
					bool flag27 = ((UnityEngine.Object)component3).m_CachedPtr == (IntPtr)0;
					CanvasGroup.set_alpha_Injected(((UnityEngine.Object)component3).m_CachedPtr, 0f);
					obj3++;
					obj4 = obj3;
				}
			}
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

	private GameObject _EggPrefab;

	private RectTransform _EggContainer;

	private GameObject _ItemPrefab;

	private TextMeshProUGUI _EggCountText;

	private RectTransform _EggPanel;

	private UISpriteAnimation _BurstVFX;

	private VerticalLayoutGroup _Grid;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private EggManager _egg;

	private BgmType _currentTrack;

	private BgmModType _currentMod;

	private List<Image> _spawnedEggs;

	private int _spriteIndex;

	private ParticleSystem _happyPfx1;

	private ParticleSystem _happyPfx2;

	private bool _happyParticlesCreated;

	private void Constructor(DataManager data, PlayerOptions player, EggManager egg)
	{
		_data = data;
		_playerOptions = player;
		_egg = egg;
	}

	public unsafe override void Purchase(ItemType t, ItemData d, ShopItemUI item, float price, RectTransform sender)
	{
		//IL_021e: Expected O, but got Ref
		//IL_0402->IL02cf: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass18_0 CS_0024_003C_003E8__locals18 = new _003C_003Ec__DisplayClass18_0();
		if (CS_0024_003C_003E8__locals18 != null)
		{
			CS_0024_003C_003E8__locals18._003C_003E4__this = this;
			CS_0024_003C_003E8__locals18.item = item;
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (config != null && _playerOptions != null)
				{
					PlayerOptionsData config2 = _playerOptions.Config;
					if (config2 != null && config._003CCharacterEggCount_003Ek__BackingField != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96AE0");
						object obj = default(object);
						bool flag = obj == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186CDF6E4h\"");
						if (flag)
						{
							return;
						}
						float time = default(float);
						Vector3 ret = default(Vector3);
						switch (t)
						{
						case ItemType.PURIFY2:
						{
							ShopItemUI item2 = CS_0024_003C_003E8__locals18.item;
							if ((object)CS_0024_003C_003E8__locals18.item == null)
							{
								break;
							}
							if (!item2._isSoldOut)
							{
								CS_0024_003C_003E8__locals18.item.SoldOut();
							}
							PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
							GameManager core = GM.Core;
							if ((object)GM.Core == null || core._eggManager == null)
							{
								break;
							}
							KeyValuePair<string, float> keyValuePair = ((EggManager)(&ret)).RemoveAllSpecificEggs((string)(object)core._eggManager);
							UpdateEggsTotal();
							Sequence s = DOTween.Sequence();
							do
							{
								bool flag3 = CS_0024_003C_003E8__locals18._003C_003E9__0 != null;
								TweenCallback callback = CS_0024_003C_003E8__locals18._003C_003E9__0;
								if (!flag3)
								{
									callback = (CS_0024_003C_003E8__locals18._003C_003E9__0 = delegate
									{
										//IL_00c6: Expected I, but got O
										//IL_00e0->IL008f: Incompatible stack heights: 1 vs 0
										if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null)
										{
											CS_0024_003C_003E8__locals18._003C_003E4__this.UpdateEggsTotal();
											if ((object)CS_0024_003C_003E8__locals18.item != null)
											{
												Transform transform2 = CS_0024_003C_003E8__locals18.item.transform;
												if ((object)transform2 != null)
												{
													bool flag4 = (object)((_003C_003Ec__DisplayClass18_0)(object)transform2)._003C_003E4__this == null;
													Transform.get_localPosition_Injected((IntPtr)((_003C_003Ec__DisplayClass18_0)(object)transform2)._003C_003E4__this, out Vector3 _);
													if ((object)CS_0024_003C_003E8__locals18._003C_003E4__this != null)
													{
														Vector2 pos2 = default(Vector2);
														CS_0024_003C_003E8__locals18._003C_003E4__this.PlayRemovalAnimation(pos2);
														return;
													}
												}
											}
										}
										throw new NullReferenceException();
									});
								}
								Sequence sequence = TweenSettingsExtensions.AppendCallback(s, callback);
								Sequence sequence2 = TweenSettingsExtensions.AppendInterval(s, 0.01f);
							}
							while (CS_0024_003C_003E8__locals18._003C_003E9__0 != null);
							UpdateEggsTotal();
							return;
						}
						default:
							return;
						case ItemType.PURIFY:
						{
							PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
							if ((object)CS_0024_003C_003E8__locals18.item != null)
							{
								Transform transform = CS_0024_003C_003E8__locals18.item.transform;
								if ((object)transform != null)
								{
									bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
									Transform.get_localPosition_Injected(((UnityEngine.Object)transform).m_CachedPtr, out ret);
									Vector2 pos = default(Vector2);
									RemoveEggs(100, pos);
									return;
								}
							}
							break;
						}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public void Back()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		SignalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_008e: Expected O, but got I4
		//IL_00cf: Expected O, but got I4
		//IL_0169: Expected O, but got Ref
		//IL_01e4->IL023f: Incompatible stack heights: 1 vs 0
		//IL_020e->IL023f: Incompatible stack heights: 1 vs 0
		base.OnShowStart(g);
		if (!_happyParticlesCreated)
		{
			CreateHappyParticles();
		}
		if ((object)GM.Core != null)
		{
			VampireSurvivors.Objects.Characters.CharacterController interactingPlayer = GM.Core.InteractingPlayer;
			EnterMultiplayerControl(interactingPlayer);
			SetMusic();
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Detune = -1200f;
			soundConfig.Volume = (float?)(object)1;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, soundConfig, 0f, 10, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Rate = 1f;
			soundConfig2.Detune = -1500f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig2, 0f, 10, time);
			if ((object)_BackButton != null)
			{
				Transform transform = _BackButton.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform transform2 = _BackButton.transform;
				object obj = default(object);
				transform2.localEulerAngles = (Vector3)(&obj);
				List<Image> spawnedEggs = _spawnedEggs;
				if (spawnedEggs._size == 0)
				{
					SpawnEggs();
				}
				Populate();
				IntroAnimation();
				ShuffleText();
				UpdateEggsTotal();
				if ((object)_happyPfx1 != null)
				{
					_happyPfx1.Stop();
					if ((object)_happyPfx2 != null)
					{
						_happyPfx2.Stop();
						RenderingExtensions.Start(_pfx1);
						RenderingExtensions.Start(_pfx2);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void IntroAnimation()
	{
		//IL_0008: Expected O, but got Ref
		//IL_02e4: Expected I, but got O
		//IL_0325: Expected O, but got Ref
		//IL_0066: Expected O, but got Ref
		//IL_00de: Expected O, but got Ref
		//IL_0368: Expected O, but got Ref
		//IL_01ba: Expected O, but got Ref
		//IL_03a3: Expected I, but got O
		//IL_03b1: Expected O, but got Ref
		//IL_022b: Expected O, but got Ref
		//IL_0438: Expected O, but got Ref
		//IL_047f: Expected I, but got O
		//IL_048d: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform = _BackButton.transform;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v22 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		_ = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)obj3);
		Transform transform2 = _BackButton.transform;
		_ = -90f;
		Vector3 localEulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		transform2.localEulerAngles = localEulerAngles;
		Image componentInParent = _BurstVFX.GetComponentInParent<Image>();
		PlayerOptionsData config = _playerOptions.Config;
		bool flag2 = (object)componentInParent == null;
		Color color = componentInParent.color;
		Color color2 = (Color)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		componentInParent.color = color2;
		bool flag3 = (object)_BurstVFX == null;
		_BurstVFX.Play();
		bool flag4 = (object)_TitlePanel == null;
		Transform transform3 = _TitlePanel.transform;
		bool flag5 = (object)transform3 == null;
		_ = 0;
		bool flag6 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref *(Vector3*)obj4);
		bool flag7 = (object)_TitlePanel == null;
		Transform transform4 = _TitlePanel.transform;
		bool flag8 = (object)transform4 == null;
		_ = 180f;
		Vector3 localEulerAngles2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		transform4.localEulerAngles = localEulerAngles2;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(_TitlePanel, 1f, 0.15f);
		nint num3 = (nint)typeof(Vector3);
		Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1014 @ rax_v51 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num4 = 0;
		_ = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1016 @ rax_v52 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(_TitlePanel, endValue, 0.15f);
		bool flag9 = (object)_EggPanel == null;
		Transform transform5 = _EggPanel.transform;
		bool flag10 = (object)transform5 == null;
		_ = -45f;
		Vector3 localEulerAngles3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		transform5.localEulerAngles = localEulerAngles3;
		bool flag11 = (object)_EggPanel == null;
		Transform transform6 = _EggPanel.transform;
		bool flag12 = (object)transform6 == null;
		_ = 0;
		bool flag13 = ((UnityEngine.Object)transform6).m_CachedPtr == (IntPtr)0;
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 23));
		Transform.set_localScale_Injected(((UnityEngine.Object)transform6).m_CachedPtr, ref *(Vector3*)obj5);
		nint num5 = (nint)typeof(Vector3);
		Vector3 endValue2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 7));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ rax_v63 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num6 = 0;
		_ = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1085 @ rax_v64 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(_EggPanel, endValue2, 0.5f);
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(_EggPanel, 1f, 0.5f);
		TweenCallback tweenCallback = delegate
		{
			//IL_0056: Expected O, but got Ref
			Transform target = _BackButton.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5 = ShortcutExtensions.DOScale(target, 1f, 0.15f);
			Transform target2 = _BackButton.transform;
			object obj7 = default(object);
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore6 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj7), 0.15f);
		};
		tweenCallback._002Ector(this, (nint)__ldftn(HealerPage._003CIntroAnimation_003Eb__21_0));
		Tween tween = UITimerHelper.RegisterMillis(500f, tweenCallback);
		_003CWaitAndTween_003Ed__22 obj6 = null;
		obj6._003C_003E1__state = 0;
		obj6._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj6);
	}

	private IEnumerator WaitAndTween()
	{
		_003CWaitAndTween_003Ed__22 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected override void OnHideStart(GameObject g)
	{
		base.OnHideStart(g);
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedBGMMod_003Ek__BackingField = _currentMod;
		PlayerOptionsData config2 = _playerOptions.Config;
		config2._003CSelectedBGM_003Ek__BackingField = _currentTrack;
		PlayerOptionsData config3 = _playerOptions.Config;
		SoundManager.PlayMusic(config3._003CSelectedBGM_003Ek__BackingField);
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		SoundManager.FadeMusic(_currentTrack, mainGameConfig._003CMusicVolume_003Ek__BackingField, 0.5f);
	}

	private void UnsetMusic()
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedBGMMod_003Ek__BackingField = _currentMod;
		PlayerOptionsData config2 = _playerOptions.Config;
		config2._003CSelectedBGM_003Ek__BackingField = _currentTrack;
		PlayerOptionsData config3 = _playerOptions.Config;
		SoundManager.PlayMusic(config3._003CSelectedBGM_003Ek__BackingField);
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
		SoundManager.FadeMusic(_currentTrack, mainGameConfig._003CMusicVolume_003Ek__BackingField, 0.5f);
	}

	private void SetMusic()
	{
		PlayerOptionsData config = _playerOptions.Config;
		_currentMod = config._003CSelectedBGMMod_003Ek__BackingField;
		PlayerOptionsData config2 = _playerOptions.Config;
		_currentTrack = config2._003CSelectedBGM_003Ek__BackingField;
		SoundManager.FadeMusic(config2._003CSelectedBGM_003Ek__BackingField, 0f, 1000f);
		Sequence sequence = DOTween.Sequence();
		Sequence sequence2 = TweenSettingsExtensions.AppendInterval(sequence, 0.1f);
		TweenCallback tweenCallback = delegate
		{
			PlayerOptionsData config3 = _playerOptions.Config;
			config3._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
			SoundManager.PlayMusic(BgmType.BGM_Machine);
			SoundManager.FadeMusic(BgmType.BGM_Machine, 1f, 100f);
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

	private unsafe void CreateHappyParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_01ad: Expected O, but got I4
		//IL_01c6: Expected O, but got Ref
		//IL_01e0: Expected native int or pointer, but got O
		//IL_01fa: Expected O, but got I
		//IL_0228: Expected O, but got I4
		//IL_0241: Expected O, but got Ref
		//IL_025b: Expected native int or pointer, but got O
		//IL_06a1: Expected O, but got I4
		//IL_0280: Expected O, but got Ref
		//IL_029a: Expected native int or pointer, but got O
		//IL_06db: Expected O, but got I
		//IL_02d2: Expected O, but got Ref
		//IL_02ec: Expected native int or pointer, but got O
		//IL_0715: Expected O, but got I
		//IL_033d: Expected O, but got I
		//IL_035e: Expected O, but got I
		//IL_039f: Expected O, but got I4
		//IL_03b8: Expected O, but got Ref
		//IL_03d2: Expected native int or pointer, but got O
		//IL_03ec: Expected O, but got I
		//IL_041a: Expected O, but got I4
		//IL_0433: Expected O, but got Ref
		//IL_044d: Expected native int or pointer, but got O
		//IL_0475: Expected O, but got I
		//IL_074f: Expected O, but got I
		//IL_0488: Expected O, but got Ref
		//IL_04a2: Expected native int or pointer, but got O
		//IL_0789: Expected O, but got I
		//IL_04da: Expected O, but got Ref
		//IL_04f4: Expected native int or pointer, but got O
		//IL_07c3: Expected O, but got I
		//IL_054b: Expected O, but got I
		//IL_0572: Expected O, but got I
		//IL_0593: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		float num = UIPositionHelper.ScreenHeight();
		float screenPosY = num + 672f;
		float yPositionFromScreenPosition = UIPositionHelper.GetYPositionFromScreenPosition(screenPosY);
		float num2 = UIPositionHelper.ScreenWidth();
		float screenPosX = num2 * 0.25f;
		float xPositionFromScreenPosition = UIPositionHelper.GetXPositionFromScreenPosition(screenPosX);
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"colours3");
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
			((List<object>)(object)list).AddWithResize((object)"colours4");
		}
		else
		{
			int size2 = list._size + 1;
			list._size = size2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("shop");
		particleSystemConfig._frame = list;
		ParticleSystem.MinMaxCurve minMaxCurve = new ParticleSystem.MinMaxCurve(yPositionFromScreenPosition);
		particleSystemConfig._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 4f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
		particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(10000f);
		particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve3 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve3, new ParticleSystem.MinMaxCurve(-100f, -300f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
		_ = 0;
		particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-80]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-70]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(0.8f, 0.9f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-68]");
		particleSystemConfig._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-48]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
		particleSystemConfig._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-30]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-20]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
		particleSystemConfig._quantity = (int?)(object)0;
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
		particleSystemConfig._blendMode = (BlendMode?)(object)0;
		ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("shop");
		particleSystemConfig2._frame = list;
		minMaxCurve = new ParticleSystem.MinMaxCurve(yPositionFromScreenPosition);
		particleSystemConfig2._y = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, 4f));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
		particleSystemConfig2._x = (ParticleSystem.MinMaxCurve)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
		_ = 0;
		minMaxCurve = new ParticleSystem.MinMaxCurve(10000f);
		particleSystemConfig2._lifespan = (ParticleSystem.MinMaxCurve)0;
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(-100f, -300f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
		obj = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
		particleSystemConfig2._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+8]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(1f, 0f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
		particleSystemConfig2._alpha = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+20]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+30]");
		_ = 0;
		ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 320));
		_ = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(2f, 1f));
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+140]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+150]");
		_ = 0;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
		particleSystemConfig2._scaleY = (ParticleSystem.MinMaxCurve?)(object)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+58]");
		_ = 0;
		_ = 0;
		_ = 1;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
		particleSystemConfig2._quantity = (int?)(object)0;
		_ = 1133903872;
		_ = 1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
		particleSystemConfig2._frequency = (float?)(object)0;
		_ = 1;
		_ = 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1B0]");
		particleSystemConfig2._blendMode = (BlendMode?)(object)0;
		Transform transform = _PfxEmitter.transform;
		Transform parent = default(Transform);
		string psName = default(string);
		bool isAdditive = default(bool);
		bool requiresMasking = default(bool);
		ParticleSystem happyPfx = _PfxEmitter.CreateUIEmitter(particleSystemConfig, "UI", 3, parent, psName, isAdditive, requiresMasking);
		_happyPfx1 = happyPfx;
		Transform transform2 = _PfxEmitter.transform;
		ParticleSystem happyPfx2 = _PfxEmitter.CreateUIEmitter(particleSystemConfig2, "UI", 3, parent, psName, isAdditive, requiresMasking);
		_happyPfx2 = happyPfx2;
		_happyPfx1.Stop();
		_happyPfx2.Stop();
		_happyParticlesCreated = true;
	}

	private void Populate()
	{
		//IL_042c: Invalid comparison between O and F4
		_Grid.enabled = true;
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		while (enumerator.MoveNext())
		{
			UnityEngine.Object.Destroy(null, 0f);
		}
		List<GameObject> spawned = _spawned;
		int version = spawned._version + 1;
		spawned._version = version;
		spawned._size = 0;
		if (spawned._size > 0)
		{
			Array.Clear(spawned._items, 0, spawned._size);
		}
		SpawnItem(ItemType.PURIFY, 0);
		PlayerOptions playerOptions = _playerOptions;
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
						goto IL_04b5;
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
		goto IL_04b5;
		IL_024d:
		PlayerOptionsData playerOptionsData2;
		int num = playerOptionsData._003CCharacterEggCount_003Ek__BackingField.FindEntry(playerOptionsData2._selectedChar);
		if (num < 0)
		{
			return;
		}
		PlayerOptions playerOptions2 = _playerOptions;
		PlayerOptionsData playerOptionsData3;
		if (playerOptions2._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions2._hostGameConfig == null)
			{
				if (playerOptions2._currentAdventureSaveData != null)
				{
					playerOptionsData3 = playerOptions2._currentAdventureSaveData;
					if ((object)playerOptionsData3._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_050e;
					}
				}
				playerOptionsData3 = playerOptions2._mainGameConfig;
			}
			else
			{
				playerOptionsData3 = playerOptions2._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData3 = playerOptions2._onlineClientWithRunDataConfig;
		}
		goto IL_050e;
		IL_0406:
		PlayerOptionsData playerOptionsData4;
		int num2 = playerOptionsData3._003CCharacterEggCount_003Ek__BackingField.FindEntry(playerOptionsData4._selectedChar);
		if (System.Runtime.CompilerServices.Unsafe.As<List<GameObject>, UIntPtr>(ref _spawned) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)25000f))
		{
			SpawnItem(ItemType.PURIFY2, 1);
		}
		return;
		IL_04b5:
		PlayerOptions playerOptions3 = _playerOptions;
		if (playerOptions3._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions3._hostGameConfig == null)
			{
				if (playerOptions3._currentAdventureSaveData != null)
				{
					PlayerOptionsData currentAdventureSaveData = playerOptions3._currentAdventureSaveData;
					if ((object)currentAdventureSaveData._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						playerOptionsData2 = currentAdventureSaveData;
						goto IL_024d;
					}
				}
				playerOptionsData2 = playerOptions3._mainGameConfig;
			}
			else
			{
				playerOptionsData2 = playerOptions3._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData2 = playerOptions3._onlineClientWithRunDataConfig;
		}
		goto IL_024d;
		IL_050e:
		PlayerOptions playerOptions4 = _playerOptions;
		if (playerOptions4._onlineClientWithRunDataConfig == null)
		{
			if (playerOptions4._hostGameConfig == null)
			{
				if (playerOptions4._currentAdventureSaveData != null)
				{
					playerOptionsData4 = playerOptions4._currentAdventureSaveData;
					if ((object)playerOptionsData4._003CSelectedAdventureType_003Ek__BackingField != null)
					{
						goto IL_0406;
					}
				}
				playerOptionsData4 = playerOptions4._mainGameConfig;
			}
			else
			{
				playerOptionsData4 = playerOptions4._hostGameConfig;
			}
		}
		else
		{
			playerOptionsData4 = playerOptions4._onlineClientWithRunDataConfig;
		}
		goto IL_0406;
	}

	private void SpawnItem(ItemType t, int index)
	{
		DataManager data = _data;
		object d = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)t);
		GameObject gameObject = UnityEngine.Object.Instantiate(_ItemPrefab, _Content);
		ShopItemUI component = gameObject.GetComponent<ShopItemUI>();
		float price = default(float);
		int index2 = default(int);
		int quantity = default(int);
		float priceMarkupMultiplier = default(float);
		component.SetItemData((ItemData)d, t, this, price, index2, quantity, priceMarkupMultiplier);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
	}

	private void SpawnEggs()
	{
		//IL_0169: Expected O, but got I4
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01c5->IL01ca: Incompatible stack heights: 1 vs 0
		object obj = 0;
		while (true)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(_EggPrefab, _EggContainer);
			List<object> spawnedEggs = (List<object>)(object)_spawnedEggs;
			if ((object)gameObject == null)
			{
				break;
			}
			Image component = gameObject.GetComponent<Image>();
			if (_spawnedEggs == null)
			{
				break;
			}
			int version = spawnedEggs._version + 1;
			spawnedEggs._version = version;
			object[] items = spawnedEggs._items;
			if (spawnedEggs._items == null)
			{
				break;
			}
			if (spawnedEggs._size >= items.Length)
			{
				((List<object>)(object)_spawnedEggs).AddWithResize((object)component);
			}
			else
			{
				int size = spawnedEggs._size + 1;
				spawnedEggs._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			Image component2 = gameObject.GetComponent<Image>();
			if ((object)component2 == null)
			{
				break;
			}
			bool flag = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
			Behaviour.set_enabled_Injected(((UnityEngine.Object)component2).m_CachedPtr, false);
			obj++;
			if ((nint)obj >= 100)
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void ShuffleText()
	{
		//IL_027f: Expected I, but got O
		//IL_0295: Expected O, but got I
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_030c: Expected I, but got O
		//IL_0691: Expected O, but got I4
		//IL_06a8: Expected I, but got I8
		//IL_02f5: Expected I, but got I8
		//IL_06fe: Expected I, but got O
		//IL_0714: Expected O, but got I
		//IL_071d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0722: Expected O, but got Unknown
		//IL_05b8: Expected I, but got O
		//IL_0756: Expected I, but got I8
		//IL_058b: Expected I, but got I8
		//IL_0659->IL0773: Incompatible stack heights: 5 vs 0
		Sequence sequence;
		Sequence sequence2;
		if (_spawned != null)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			List<GameObject>.Enumerator value = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				ShopItemUI component = ((GameObject)null).GetComponent<ShopItemUI>();
				bool flag = (object)component == null;
				component.ShuffleText();
				bool flag2 = (object)_Title == null;
				string text = _Title.text;
				string text2 = VampireSurvivors.App.Tools.Extensions.Shuffle(text);
				_Title.text = text2;
				bool flag3 = (object)_Title == null;
				Transform transform = _Title.transform;
				bool flag4 = (object)transform == null;
				bool flag5 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
			}
			sequence = DOTween.Sequence();
			sequence2 = DOTween.Sequence();
			object message;
			if (sequence != null)
			{
				if (((Tween)sequence)._003Cactive_003Ek__BackingField)
				{
					if (!((Tween)sequence).creationLocked)
					{
						sequence.lastTweenInsertTime = ((Tween)sequence).duration;
						float duration = ((Tween)sequence).duration + 0.4f;
						((Tween)sequence).duration = duration;
						goto IL_0234;
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
			goto IL_0234;
		}
		goto IL_05ff;
		IL_0234:
		TweenCallback tweenCallback = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v9 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback).method = (nint)__ldftn(HealerPage._003CShuffleText_003Eb__30_0);
		((Delegate)tweenCallback).m_target = this;
		((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v9 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		nint num2;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ r10_v9 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num2 = unchecked((nint)6447293664L);
				goto IL_0688;
			}
		}
		((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
		num2 = ((Delegate)tweenCallback).method_ptr;
		goto IL_0688;
		IL_03ea:
		if (((Tween)sequence)._003Cactive_003Ek__BackingField && !((Tween)sequence).creationLocked)
		{
			((Tween)sequence).loops = 7;
			if (((ABSSequentiable)sequence).tweenType == TweenType.Tweener)
			{
				float fullDuration = ((Tween)sequence).duration * 7f;
				((Tween)sequence).fullDuration = fullDuration;
			}
		}
		goto IL_04be;
		IL_05ff:
		throw new NullReferenceException();
		IL_04be:
		if (TweenSettingsExtensions.ValidateAddToSequence(sequence2, (Tween)sequence, false))
		{
			if (sequence2 == null)
			{
				goto IL_05ff;
			}
			Sequence sequence3 = Sequence.DoInsert(sequence2, (Tween)sequence, ((Tween)sequence2).duration);
		}
		TweenCallback tweenCallback2 = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ r10_v10 (Il2CppMethodInfo)+8]");
		((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
		((Delegate)tweenCallback2).method = (nint)__ldftn(HealerPage._003CShuffleText_003Eb__30_1);
		((Delegate)tweenCallback2).m_target = this;
		((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ r10_v10 (Il2CppMethodInfo)+4C]");
		object obj3 = (nint)0 >> 4;
		object obj4 = obj3 & 1;
		nint num4;
		if (obj4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v734 @ r10_v10 (Il2CppMethodInfo)+52]");
			bool flag6 = (nint)0 == 0;
			num4 = unchecked((nint)6447293664L);
			if (flag6)
			{
				goto IL_073f;
			}
		}
		num4 = ((Delegate)tweenCallback2).method_ptr;
		((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
		goto IL_073f;
		IL_0688:
		object obj5 = 24;
		((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
		if (sequence != null)
		{
			object message2;
			if (((Tween)sequence)._003Cactive_003Ek__BackingField)
			{
				if (!((Tween)sequence).creationLocked)
				{
					Sequence sequence4 = Sequence.DoInsertCallback(sequence, tweenCallback, ((Tween)sequence).duration);
					goto IL_03ea;
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
			Debugger.LogWarning(message2);
			goto IL_03ea;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Debugger.LogWarning("You can't add elements to a NULL Sequence");
		goto IL_04be;
		IL_073f:
		((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
		if (sequence2 != null && ((Tween)sequence2)._003Cactive_003Ek__BackingField)
		{
			sequence2.onComplete = tweenCallback2;
		}
		Sequence sequence5 = TweenExtensions.Play(sequence2);
	}

	private unsafe void RemoveEggs(int value, Vector2 pos)
	{
		//IL_0094: Expected O, but got I4
		//IL_00ab: Expected O, but got I4
		//IL_00b4: Expected O, but got I4
		//IL_024c: Expected O, but got I4
		//IL_00c2: Expected O, but got Ref
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f8: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_0284: Expected I, but got O
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected Ref, but got Unknown
		//IL_01a2: Expected I8, but got I
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected Ref, but got Unknown
		//IL_01ca: Expected I, but got O
		//IL_01cf: Expected I, but got O
		_003C_003Ec__DisplayClass31_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass31_0();
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		Vector2 vector = default(Vector2);
		CS_0024_003C_003E8__locals7.pos = vector;
		PlayerOptionsData config = _playerOptions.Config;
		PlayerOptionsData config2 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96AE0");
		Vector2 vector2;
		if (value <= (nint)vector)
		{
			bool flag = value <= 0;
			vector2 = (Vector2)0;
			if (!flag)
			{
				vector2 = (Vector2)0;
				object obj = 0;
				object obj2 = default(object);
				nint num2 = default(nint);
				do
				{
					KeyValuePair<string, float> keyValuePair = ((EggManager)(&obj2)).RemoveRandomEgg();
					object obj3 = "undefined";
					object obj4 = keyValuePair;
					if ((object)keyValuePair != "undefined")
					{
						bool flag2 = (object)keyValuePair == null;
						nint num = num2;
						if (!flag2)
						{
							bool flag3 = "undefined" == null;
							num = num2;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rcx_v22+10]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ rdx_v15+10]");
								bool flag4 = num3 != 0;
								num = num2;
								if (!flag4)
								{
									ref byte second = ref *(byte*)("undefined" + 20);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rcx_v22+10]");
									nint num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v430 @ rcx_v22+10]");
									ulong length = (ulong)(num4 + 0);
									bool flag5 = System.SpanHelpers.SequenceEqual(ref *(byte*)(keyValuePair + 20), ref second, length);
									num = unchecked((nint)null);
									num2 = unchecked((nint)null);
									if (flag5)
									{
										goto IL_02ea;
									}
								}
							}
						}
						vector2++;
						num2 = num;
					}
					goto IL_02ea;
					IL_02ea:
					obj++;
				}
				while ((nint)obj < value);
			}
		}
		else
		{
			_egg.RemoveAllEggs();
			vector2 = vector;
		}
		Sequence s = DOTween.Sequence();
		if ((nint)vector2 <= 0)
		{
			return;
		}
		object obj5 = 0;
		do
		{
			TweenCallback callback = CS_0024_003C_003E8__locals7._003C_003E9__0;
			if (CS_0024_003C_003E8__locals7._003C_003E9__0 == null)
			{
				callback = (CS_0024_003C_003E8__locals7._003C_003E9__0 = delegate
				{
					CS_0024_003C_003E8__locals7._003C_003E4__this.UpdateEggsTotal();
					Vector2 pos2 = default(Vector2);
					CS_0024_003C_003E8__locals7._003C_003E4__this.PlayRemovalAnimation(pos2);
				});
				nint num2 = unchecked((nint)null);
			}
			Sequence sequence = TweenSettingsExtensions.AppendCallback(s, callback);
			Sequence sequence2 = TweenSettingsExtensions.AppendInterval(s, 0.01f);
			obj5++;
		}
		while (System.Runtime.CompilerServices.Unsafe.As<Vector2, UIntPtr>(ref vector2) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5));
	}

	private void PlayRemovalAnimation(Vector2 pos)
	{
		//IL_010b: Expected O, but got I
		//IL_022c: Expected O, but got I
		//IL_0174: Expected O, but got I8
		//IL_01b2: Expected O, but got I8
		List<Image> spawnedEggs = _spawnedEggs;
		int spriteIndex = _spriteIndex;
		if (_spriteIndex < spawnedEggs._size)
		{
			Image[] items = spawnedEggs._items;
			int num = _spriteIndex + 1;
			List<Image> spawnedEggs2 = _spawnedEggs;
			_spriteIndex = num;
			if (num >= spawnedEggs2._size)
			{
				_spriteIndex = 0;
			}
			GameObject gameObject = items[spriteIndex].gameObject;
			gameObject.SetActive(value: true);
			GameObject gameObject2 = items[spriteIndex].gameObject;
			Image component = gameObject2.GetComponent<Image>();
			component.enabled = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189999090]");
			bool flag = (nint)0 != 0;
			Behaviour behaviour = component;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"InternalCalls_Resolve\"");
				if (obj == null)
				{
					MissingMethodException ex = new MissingMethodException();
					throw ex;
				}
				behaviour = (Behaviour)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v426 @ rax_v22 (should have been resolved before IL gen)");
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
				behaviour = (Behaviour)6573110936L;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v451 @ rax_v25 (should have been resolved before IL gen)");
			RectTransform rectTransform = items[spriteIndex].rectTransform;
			Vector2 anchoredPosition = default(Vector2);
			rectTransform.anchoredPosition = anchoredPosition;
			UISpriteAnimation component2 = items[spriteIndex].GetComponent<UISpriteAnimation>();
			component2.Play(hideWhenDone: true);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void UpdateEggsTotal()
	{
		//IL_00e5: Expected I, but got O
		//IL_0132: Invalid comparison between I4 and F4
		//IL_016b: Expected O, but got I4
		//IL_01c8: Expected O, but got I4
		PlayerOptionsData config = _playerOptions.Config;
		PlayerOptionsData config2 = _playerOptions.Config;
		bool flag = config._003CCharacterEggCount_003Ek__BackingField == null;
		int num = config._003CCharacterEggCount_003Ek__BackingField.FindEntry(config2._selectedChar);
		if (flag)
		{
			return;
		}
		TextMeshProUGUI eggCountText = _EggCountText;
		PlayerOptionsData config3 = _playerOptions.Config;
		PlayerOptionsData config4 = _playerOptions.Config;
		int num2 = config3._003CCharacterEggCount_003Ek__BackingField.FindEntry(config4._selectedChar);
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		float num3 = default(float);
		string text = System.Number.FormatSingle(num3, null, currentInfo);
		nint num4 = (nint)eggCountText;
		eggCountText.text = text;
		PlayerOptionsData config5 = _playerOptions.Config;
		PlayerOptionsData config6 = _playerOptions.Config;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A96AE0");
		if (!(0f < num3))
		{
			SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
			soundConfig.Rate = 1f;
			soundConfig.Volume = (float?)(object)1;
			soundConfig.Detune = -200f;
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, soundConfig, 0f, 10, time);
			SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
			soundConfig2.Rate = 1f;
			soundConfig2.Volume = (float?)(object)1;
			soundConfig2.Detune = -1500f;
			PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig2, 0f, 10, time);
			_happyPfx1.Play(withChildren: true);
			_happyPfx2.Play(withChildren: true);
			_pfx1.Stop();
			_pfx2.Stop();
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			if (enumerator.MoveNext())
			{
				throw new NullReferenceException();
			}
		}
	}

	public HealerPage()
	{
		List<Image> spawnedEggs = new List<Image>();
		_spawnedEggs = spawnedEggs;
		base._002Ector();
	}

	private unsafe void _003CIntroAnimation_003Eb__21_0()
	{
		//IL_0056: Expected O, but got Ref
		Transform target = _BackButton.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.15f);
		Transform target2 = _BackButton.transform;
		object obj = default(object);
		TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj), 0.15f);
	}

	private void _003CSetMusic_003Eb__25_0()
	{
		PlayerOptionsData config = _playerOptions.Config;
		config._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		SoundManager.PlayMusic(BgmType.BGM_Machine);
		SoundManager.FadeMusic(BgmType.BGM_Machine, 1f, 100f);
	}

	private void _003CShuffleText_003Eb__30_0()
	{
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		if (enumerator.MoveNext())
		{
			GameObject gameObject = null;
			throw new NullReferenceException();
		}
		Transform transform = _Title.transform;
		bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
		string text = _Title.text;
		string text2 = VampireSurvivors.App.Tools.Extensions.Shuffle(text);
		_Title.text = text2;
	}

	private void _003CShuffleText_003Eb__30_1()
	{
		//IL_0257: Expected F4, but got I4
		//IL_0257: Expected I4, but got O
		//IL_0257: Expected I4, but got O
		//IL_0257: Expected F4, but got I4
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		TextMeshProUGUI title = _Title;
		bool flag = default(bool);
		GameObject gameObject = default(GameObject);
		string text = default(string);
		bool flag2 = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/healer_header", FixForRTL: true, 0, ignoreRTLnumbers: true, flag, gameObject, text, flag2);
		if ((object)_Title != null)
		{
			GameWindowedUIPage gameWindowedUIPage = (GameWindowedUIPage)(object)title;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v153 @ r9_v8 (VampireSurvivors.UI.GameWindowedUIPage)+558] (should have been resolved before IL gen)");
			List<GameObject> spawned = _spawned;
			if (_spawned != null)
			{
				Transform transform = null;
				Transform transform2 = null;
				Vector3 value = default(Vector3);
				while (true)
				{
					if ((nint)transform2 < spawned._size)
					{
						List<GameObject> spawned2 = _spawned;
						if (_spawned == null)
						{
							break;
						}
						if ((nint)transform < spawned2._size)
						{
							GameObject[] items = spawned2._items;
							if (spawned2._items == null)
							{
								break;
							}
							if ((nint)transform < items.Length)
							{
								if ((object)items[(object)transform] == null)
								{
									break;
								}
								ShopItemUI component = items[(object)transform].GetComponent<ShopItemUI>();
								if ((object)component == null)
								{
									break;
								}
								DataManager data = _data;
								if (_data == null || data._003CAllItems_003Ek__BackingField == null)
								{
									break;
								}
								object d = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllItems_003Ek__BackingField).get_Item((System.Int32Enum)component._itemType);
								ShopItemUI component2 = items[(object)transform].GetComponent<ShopItemUI>();
								if ((object)component2 == null)
								{
									break;
								}
								component2.SetItemData((ItemData)d, component._itemType, this, flag ? 1 : 0, (int)gameObject, (int)text, flag2 ? 1 : 0);
								spawned = _spawned;
								transform = (Transform)(transform + 1);
								if (_spawned == null)
								{
									break;
								}
								gameWindowedUIPage = this;
								transform2 = transform;
								continue;
							}
						}
						else
						{
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						}
						throw new IndexOutOfRangeException();
					}
					if ((object)_Title != null)
					{
						Transform transform3 = _Title.transform;
						if ((object)transform3 != null)
						{
							bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
							Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value);
							return;
						}
					}
					throw new NullReferenceException();
				}
			}
		}
		throw new NullReferenceException();
	}
}
