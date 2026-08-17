using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Coherence;
using Coherence.Toolkit;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Tools;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.UI;

public class SurvarotsSelectionPage : BaseUIPage, ISetArcanaInfo
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static TweenCallback _003C_003E9__74_4;

		public static TweenCallback _003C_003E9__76_4;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CPerformBooster_003Eb__74_4()
		{
		}

		internal void _003CPerformReRoll_003Eb__76_4()
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass74_0
	{
		public GameObject v;

		internal void _003CPerformBooster_003Eb__1()
		{
			UnityEngine.Object.Destroy(v, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass74_1
	{
		public ArcanaCardUI c;

		internal void _003CPerformBooster_003Eb__2()
		{
			Tween tween = c.Reveal();
		}

		internal void _003CPerformBooster_003Eb__3()
		{
			Selectable component = c.GetComponent<Selectable>();
			component.Select();
		}
	}

	private sealed class _003C_003Ec__DisplayClass76_0
	{
		public GameObject v;

		internal void _003CPerformReRoll_003Eb__1()
		{
			UnityEngine.Object.Destroy(v, 0f);
		}
	}

	private sealed class _003C_003Ec__DisplayClass76_1
	{
		public ArcanaCardUI c;

		internal void _003CPerformReRoll_003Eb__2()
		{
			Tween tween = c.Reveal();
		}

		internal void _003CPerformReRoll_003Eb__3()
		{
			Selectable component = c.GetComponent<Selectable>();
			component.Select();
		}
	}

	private sealed class _003C_003Ec__DisplayClass79_0
	{
		public GameObject v;

		public SurvarotsSelectionPage _003C_003E4__this;

		internal void _003CPopulateMenu_003Eb__0()
		{
			//IL_01c4->IL0154: Incompatible stack heights: 1 vs 0
			//IL_0098->IL0154: Incompatible stack heights: 1 vs 0
			//IL_00b5->IL0154: Incompatible stack heights: 1 vs 0
			//IL_00eb->IL0154: Incompatible stack heights: 1 vs 0
			//IL_0117->IL0154: Incompatible stack heights: 1 vs 0
			if ((object)v != null)
			{
				Transform transform = v.transform;
				if ((object)transform != null)
				{
					Transform parent = transform.parent;
					if ((object)parent != null)
					{
						bool flag = ((UnityEngine.Object)parent).m_CachedPtr == (IntPtr)0;
						int siblingIndex_Injected = Transform.GetSiblingIndex_Injected(((UnityEngine.Object)parent).m_CachedPtr);
						if ((object)v != null)
						{
							Transform transform2 = v.transform;
							SurvarotsSelectionPage survarotsSelectionPage = _003C_003E4__this;
							if ((object)_003C_003E4__this != null && (object)transform2 != null)
							{
								transform2.SetParent(survarotsSelectionPage._cardContainer, worldPositionStays: true);
								if ((object)v != null)
								{
									Transform transform3 = v.transform;
									if ((object)transform3 != null)
									{
										transform3.SetSiblingIndex(siblingIndex_Injected);
										GameObject gameObject = parent.gameObject;
										UnityEngine.Object.Destroy(gameObject, 0f);
										return;
									}
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass79_1
	{
		public ArcanaCardUI card;

		internal void _003CPopulateMenu_003Eb__1()
		{
			Tween tween = card.Reveal();
		}
	}

	private sealed class _003C_003Ec__DisplayClass86_0
	{
		public GameObject g;

		internal void _003CAddStrips_003Eb__0()
		{
			g.SetActive(value: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass86_1
	{
		public GameObject g;

		internal void _003CAddStrips_003Eb__1()
		{
			g.SetActive(value: false);
		}
	}

	private sealed class _003C_003Ec__DisplayClass96_0
	{
		public SurvarotsSelectionPage _003C_003E4__this;

		public List<GameObject> cards;

		public Sequence s;

		public Transform t;

		public ArcanaCardUI arcanaCardUI;

		internal void _003CRandom_003Eb__0()
		{
			SurvarotsSelectionPage survarotsSelectionPage = _003C_003E4__this;
			Button component = survarotsSelectionPage._collectRandomButton.GetComponent<Button>();
			component.Select();
		}

		internal unsafe void _003CRandom_003Eb__1()
		{
			//IL_0042: Expected O, but got I4
			//IL_004c: Expected O, but got I4
			//IL_0241: Expected O, but got Ref
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Expected O, but got Unknown
			//IL_00cf->IL01c1: Incompatible stack heights: 1 vs 0
			//IL_0106->IL01c1: Incompatible stack heights: 1 vs 0
			//IL_01a6->IL01c1: Incompatible stack heights: 2 vs 0
			//IL_014b->IL01c1: Incompatible stack heights: 2 vs 0
			//IL_01c0->IL0262: Incompatible stack heights: 2 vs 0
			if (cards != null)
			{
				((List<object>)(object)cards).Reverse();
				List<GameObject> list = cards;
				if (cards != null)
				{
					object obj = 0;
					object obj2 = 0;
					object obj3 = default(object);
					object obj4 = default(object);
					while (true)
					{
						if ((nint)obj2 >= list._size)
						{
							return;
						}
						List<GameObject> list2 = cards;
						if (cards == null)
						{
							break;
						}
						Sequence sequence = s;
						bool flag = (nint)obj >= list2._size;
						GameObject[] items = list2._items;
						if (list2._items == null)
						{
							break;
						}
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = (TweenerCore<Quaternion, Vector3, QuaternionOptions>)(object)items[obj];
						if ((object)items[obj] == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbp_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rbp_v8 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
						IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
						Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&obj3), 0.2f);
						if (TweenSettingsExtensions.ValidateAddToSequence(s, (Tween)tweenerCore2, false))
						{
							if (s == null)
							{
								break;
							}
							Sequence sequence2 = Sequence.DoInsert(s, (Tween)tweenerCore2, sequence.lastTweenInsertTime);
						}
						list = cards;
						obj++;
						if (cards == null)
						{
							break;
						}
						obj3 = obj4;
						obj2 = obj;
					}
				}
			}
			throw new NullReferenceException();
		}

		internal unsafe void _003CRandom_003Eb__2()
		{
			//IL_0156: Expected O, but got Ref
			//IL_00cb: Expected O, but got I
			//IL_01a9: Expected I, but got O
			//IL_01c2: Expected O, but got Ref
			if ((object)t != null)
			{
				RectTransform component = t.GetComponent<RectTransform>();
				if ((object)component != null)
				{
					Vector2 pivot = default(Vector2);
					component.pivot = pivot;
					Vector3 ret = default(Vector3);
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(t, (Vector3)(&ret), 0.2f);
					if ((object)arcanaCardUI != null)
					{
						Tween tween = arcanaCardUI.Reveal();
						if ((object)arcanaCardUI != null)
						{
							string name = ((UnityEngine.Object)arcanaCardUI).GetName();
							string message = name + " -> Opening";
							Debug.Log(message);
							_003C_003Ec__DisplayClass96_0 obj = (_003C_003Ec__DisplayClass96_0)(object)_003C_003E4__this;
							if ((object)_003C_003E4__this != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v5 (VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0)+140]");
								_003C_003Ec__DisplayClass96_0 obj2 = (_003C_003Ec__DisplayClass96_0)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rbx_v5 (VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0)+140]");
								if ((nint)0 != 0)
								{
									bool flag = (object)obj2._003C_003E4__this == null;
									Transform.get_position_Injected((IntPtr)obj2._003C_003E4__this, out ret);
									object obj3 = default(object);
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOMove(t, (Vector3)(&obj3), 0.2f);
									return;
								}
							}
						}
					}
				}
			}
			throw new NullReferenceException();
		}

		internal void _003CRandom_003Eb__3()
		{
			ArcanaCardUI arcanaCardUI = this.arcanaCardUI;
			_003C_003E4__this.SetInfo(arcanaCardUI._data, arcanaCardUI._type, this.arcanaCardUI);
		}

		internal void _003CRandom_003Eb__4()
		{
			SurvarotsSelectionPage survarotsSelectionPage = _003C_003E4__this;
			Button component = survarotsSelectionPage._collectRandomButton.GetComponent<Button>();
			component.enabled = true;
		}
	}

	private sealed class _003C_003Ec__DisplayClass96_1
	{
		public int cardIndex;

		public _003C_003Ec__DisplayClass96_0 CS_0024_003C_003E8__locals1;

		internal void _003CRandom_003Eb__5(float value)
		{
			_003C_003Ec__DisplayClass96_0 obj = CS_0024_003C_003E8__locals1;
			List<GameObject> cards = obj.cards;
			int num = cardIndex;
			if (cardIndex < cards._size)
			{
				GameObject[] items = cards._items;
				RectTransform component = items[num].GetComponent<RectTransform>();
				Vector2 pivot = default(Vector2);
				component.pivot = pivot;
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
	}

	private sealed class _003CSpawnContent_003Ed__60(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SurvarotsSelectionPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00cd: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.InitializeNormalArcanaParticles();
				_003C_003E4__this.InitializeRingsOfCards();
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

	private sealed class _003CWaitAndConfigureRandomButton_003Ed__82(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SurvarotsSelectionPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0031: Expected I4, but got I8
			//IL_007f: Expected I4, but got I8
			//IL_00c2: Expected I4, but got O
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				_003C_003E4__this.SetBoosterButton();
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

	private sealed class _003CWaitAndSelect_003Ed__83(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public SurvarotsSelectionPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0078: Expected I4, but got I8
			//IL_0305: Expected I4, but got O
			SurvarotsSelectionPage survarotsSelectionPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				WaitForSeconds waitForSeconds = null;
				waitForSeconds.m_Seconds = 0.5f;
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					List<GameObject> allSpawnedInOrder = survarotsSelectionPage._allSpawnedInOrder;
					if (survarotsSelectionPage._allSpawnedInOrder != null)
					{
						if (allSpawnedInOrder._size > 0)
						{
							GameObject[] items = allSpawnedInOrder._items;
							if (allSpawnedInOrder._items != null && (object)items[0] != null)
							{
								ArcanaCardUI component = items[0].GetComponent<ArcanaCardUI>();
								if ((object)component != null)
								{
									component.OnClick();
									Selectable component2 = items[0].GetComponent<Selectable>();
									if ((object)component2 != null)
									{
										component2.Select();
										ArcanaCardUI component3 = items[0].GetComponent<ArcanaCardUI>();
										if ((object)component3 != null)
										{
											ArcanaCardUI component4 = items[0].GetComponent<ArcanaCardUI>();
											if ((object)component4 != null)
											{
												ArcanaCardUI component5 = items[0].GetComponent<ArcanaCardUI>();
												_003C_003E4__this.SetInfo(component3._data, component4._type, component5);
												if ((object)survarotsSelectionPage._getButton != null)
												{
													Selectable component6 = survarotsSelectionPage._getButton.GetComponent<Selectable>();
													if ((object)component6 != null)
													{
														component6.Select();
														return false;
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
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
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

	private Transform _cardInfoPanelsRoot;

	private RectTransform _titleGroup;

	private RectTransform _cardContainer;

	private RectTransform _minorCardContainer;

	private GameObject _arcanaCardPrefab;

	private GameObject _boosterButton;

	private TextMeshProUGUI _boosterPriceText;

	private RectTransform _CurrencyPanel;

	private GameObject _getButton;

	private ParticleEmitterManager _topParticles;

	private ParticleEmitterManager _bottomParticles;

	private RectTransform _cardOrigin;

	private RectTransform _selectedCardOrigin;

	private Image _blackFader;

	private Image _collectRandomButton;

	private GameObject _majorSelectionGroup;

	private GameObject _minorSelectionGroup;

	private GameObject _bigArcanaCard;

	private RectTransform _stripContainer;

	private RectTransform _minorGetButton;

	private RectTransform _skipButton;

	private RectTransform _rerollButton;

	private TextMeshProUGUI _rerollCountText;

	private TextMeshProUGUI _skipCountText;

	private PauseEquipmentPanel _equipmentPanel;

	private GameObject _characterStatsPanel;

	private bool _debugpage2;

	private RectTransform _rerollAnimContainer;

	private RectTransform _infoGroup;

	private RectTransform _minorBackground;

	private RectTransform _majorBackground;

	private RectTransform _majorForeground;

	private RectTransform _titleBackground;

	private RectTransform _characterPanelBackground;

	private GameObject _characterPanel;

	private Image _characterImage;

	private List<SpinningRingOfCards> _cardRings;

	private int _maxWeaponsBeforeCarousel;

	private CardInfoUI _cardInfoUI;

	private CardRiskInfoUI _survarotInfoRisk;

	private CardEditionInfoUI _survarotInfoEdition;

	private List<GameObject> _spawned;

	private List<GameObject> _allSpawnedInOrder;

	private DataManager _data;

	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private CharacterSkillCard_Base _currentSelected;

	private string _arcanaCacheGroupName;

	private Selectable _previouslyHighlightedDraftCard;

	private int _lastSelected;

	private ArcanaCardUI _selected;

	private bool _hasPickedRandom;

	private bool _hasFreeReroll;

	private VampireSurvivors.Objects.Characters.CharacterController _controllingCharacter;

	private bool _hasFinishedPopulationAnimation;

	private bool _rngInit;

	private Unity.Mathematics.Random _random;

	private int _boostersBought;

	private void Construct(DataManager data, PlayerOptions player, SignalBus signalBus)
	{
		//IL_0099: Expected O, but got I4
		//IL_0099: Expected O, but got I
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_0260: Expected O, but got I
		//IL_0145: Expected O, but got I4
		//IL_0145: Expected O, but got I
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_029b: Expected O, but got I
		//IL_01f1: Expected O, but got I4
		//IL_01f1: Expected O, but got I
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_02d6: Expected O, but got I
		_data = data;
		PlayerOptions playerOptions = default(PlayerOptions);
		_playerOptions = playerOptions;
		_signalBus = signalBus;
		Action<OnlineSignals.OnlineSelectedCharacterCard> action = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA18F0");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v338 @ rbx_v4 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj = null;
		Action<object> action2 = ((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineSelectedCharacterCard>)obj)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass37_0<OnlineSignals.OnlineSelectedCharacterCard>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj3 = default(object);
		object obj2 = obj3 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus2 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v16 (System.Object)+10]");
		Type signalType = default(Type);
		Action<object> callback = default(Action<object>);
		signalBus2.SubscribeInternal(signalType, (object)null, (object)0, callback);
		Action action3 = OnReRolledCharacterCardsRemotely;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rbx_v8 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj4 = null;
		Action<object> action4 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.OnlineReRolledCharacterCards>)obj4)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.OnlineReRolledCharacterCards>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus3 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v31 (System.Object)+10]");
		Type signalType2 = default(Type);
		signalBus3.SubscribeInternal(signalType2, (object)null, (object)0, callback);
		Action action5 = OnBoosterSurvarotsRemotely;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ rbx_v12 (Il2CppMethodInfo)+38]");
		if ((nint)0 == 0)
		{
		}
		object obj7 = null;
		Action<object> action6 = ((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.OnlineBoosterSurvarots>)obj7)._003CSubscribeId_003Eb__0;
		((SignalBus._003C_003Ec__DisplayClass35_0<OnlineSignals.OnlineBoosterSurvarots>)0)._003CSubscribeId_003Eb__0((object)1);
		object obj9 = default(object);
		object obj8 = obj9 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		SignalBus signalBus4 = _signalBus;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v46 (System.Object)+10]");
		Type signalType3 = default(Type);
		signalBus4.SubscribeInternal(signalType3, (object)null, (object)0, callback);
	}

	protected override void Awake()
	{
		base.Awake();
		_AutoSizeAfterParse = true;
		_003CSpawnContent_003Ed__60 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = CoroutineRunner.Instance.StartCoroutine(obj);
	}

	public IEnumerator SpawnContent()
	{
		_003CSpawnContent_003Ed__60 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void OnDestroy()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		Action<OnlineSignals.OnlineSelectedCharacterCard> token = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA18F0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool throwIfMissing = default(bool);
		_signalBus.UnsubscribeInternal(signalType, (object)null, (object)token, throwIfMissing);
		Action token2 = OnReRolledCharacterCardsRemotely;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType2 = default(Type);
		_signalBus.UnsubscribeInternal(signalType2, (object)null, (object)token2, throwIfMissing);
		Action token3 = OnBoosterSurvarotsRemotely;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj6 = default(object);
		object obj5 = obj6 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType3 = default(Type);
		_signalBus.UnsubscribeInternal(signalType3, (object)null, (object)token3, throwIfMissing);
	}

	protected unsafe override void OnShowStart(GameObject g)
	{
		//IL_038e: Expected O, but got I4
		//IL_011f: Expected O, but got Ref
		//IL_04c6: Expected O, but got Ref
		//IL_01bd: Expected O, but got Ref
		//IL_059b: Expected O, but got Ref
		//IL_04e4->IL0313: Incompatible stack heights: 1 vs 0
		//IL_05d2->IL0313: Incompatible stack heights: 9 vs 0
		//IL_0231->IL0313: Incompatible stack heights: 9 vs 0
		//IL_02a9->IL0313: Incompatible stack heights: 9 vs 0
		//IL_02d5->IL0313: Incompatible stack heights: 9 vs 0
		//IL_0302->IL0313: Incompatible stack heights: 9 vs 0
		base.OnShowStart(g);
		if (!_rngInit)
		{
			object obj = UnityEngine.Random.RandomRangeInt(0, 9999999);
			object obj2 = obj << 13;
			object obj3 = obj ^ obj2;
			object obj4 = obj3 >> 17;
			object obj5 = obj3 ^ obj4;
			object obj6 = obj5 << 5;
			Unity.Mathematics.Random random = (Unity.Mathematics.Random)(obj6 ^ obj5);
			_random = random;
			GameManager core = GM.Core;
			if ((object)GM.Core == null || core._multiplayer == null)
			{
				goto IL_0313;
			}
			if (core._multiplayer.IsOnlineMultiplayer)
			{
				GameObject instance = (GameObject)(object)OnlineStageManager._instance;
				if ((object)OnlineStageManager._instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
				{
					OnlineStageManager instance2 = OnlineStageManager._instance;
					if ((object)OnlineStageManager._instance == null)
					{
						goto IL_0313;
					}
					_random = instance2._survarotsRng;
				}
			}
			_rngInit = true;
		}
		GetControllingCharacter();
		EnterMultiplayerControl(_controllingCharacter, 1000f);
		if ((object)GM.Core != null)
		{
			_ = _controllingCharacter;
			Vector2 pivot = default(Vector2);
			VampireSurvivors.App.Tools.Extensions.SetPivot(_infoGroup, pivot);
			if ((object)_infoGroup != null)
			{
				Transform transform = _infoGroup.transform;
				bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				Transform transform2 = _titleBackground.transform;
				Vector2 vector = default(Vector2);
				transform2.localEulerAngles = (Vector3)(&vector);
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_titleBackground, (Vector3)(&vector), 0.2f);
				if ((object)_titleBackground != null)
				{
					Transform transform3 = _titleBackground.transform;
					bool flag2 = (object)transform3 == null;
					bool flag3 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
					Vector3 value2 = default(Vector3);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, ref value2);
					bool flag4 = (object)_titleBackground == null;
					Transform target = _titleBackground.transform;
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, 1f, 0.2f);
					bool flag5 = (object)_CurrencyPanel == null;
					Transform transform4 = _CurrencyPanel.transform;
					bool flag6 = (object)transform4 == null;
					transform4.localEulerAngles = (Vector3)(&value);
					bool flag7 = (object)_CurrencyPanel == null;
					Transform transform5 = _CurrencyPanel.transform;
					bool flag8 = (object)transform5 == null;
					bool flag9 = ((UnityEngine.Object)transform5).m_CachedPtr == (IntPtr)0;
					Vector2 value3 = default(Vector2);
					Transform.set_localScale_Injected(((UnityEngine.Object)transform5).m_CachedPtr, ref *(Vector3*)(&value3));
					Vector2 vector2 = default(Vector2);
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(_CurrencyPanel, (Vector3)(&vector2), 0.35f);
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(_CurrencyPanel, 1f, 0.35f);
					if ((object)_collectRandomButton != null)
					{
						GameObject gameObject = _collectRandomButton.gameObject;
						if ((object)gameObject != null)
						{
							gameObject.SetActive(value: false);
							ClearSpawned();
							TweenerCore<Color, Color, ColorOptions> tweenerCore5 = DOTweenModuleUI.DOFade(_blackFader, 0.5f, 1f);
							_boostersBought = 0;
							PopulateMenu();
							SetReRollButton();
							SetBoosterButton();
							if ((object)_survarotInfoEdition != null)
							{
								GameObject gameObject2 = _survarotInfoEdition.gameObject;
								if ((object)gameObject2 != null)
								{
									gameObject2.SetActive(value: false);
									if ((object)_survarotInfoRisk != null)
									{
										_survarotInfoRisk.UpdateText();
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0313;
		IL_0313:
		throw new NullReferenceException();
	}

	private unsafe void GetControllingCharacter()
	{
		//IL_060f: Expected O, but got Ref
		//IL_087a: Expected O, but got Ref
		//IL_04a3: Expected O, but got I
		//IL_04e2: Expected O, but got I
		//IL_07d9: Expected I, but got O
		//IL_0556: Expected O, but got I4
		//IL_0898->IL06d3: Incompatible stack heights: 4 vs 0
		//IL_07a4->IL06d3: Incompatible stack heights: 1 vs 0
		//IL_0502->IL06d3: Incompatible stack heights: 1 vs 0
		//IL_07f2->IL06d3: Incompatible stack heights: 2 vs 0
		//IL_0538->IL06d3: Incompatible stack heights: 2 vs 0
		//IL_055b->IL055b: Incompatible stack heights: 2 vs 0
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController controllingCharacter;
		if ((object)GM.Core != null && core._multiplayer != null)
		{
			int playerCount = core._multiplayer.GetPlayerCount();
			if (playerCount <= 1 && !core._multiplayer.IsOnlineMultiplayer)
			{
				if ((object)_characterPanel != null)
				{
					_characterPanel.SetActive(value: false);
					GameManager core2 = GM.Core;
					if ((object)GM.Core != null)
					{
						GameSessionData gameSessionData = core2._gameSessionData;
						if (core2._gameSessionData != null)
						{
							_controllingCharacter = gameSessionData._activeCharacter;
							goto IL_055b;
						}
					}
				}
			}
			else if ((object)GM.Core != null)
			{
				VampireSurvivors.Objects.Characters.CharacterController characterControllerFromType = GM.Core.GetCharacterControllerFromType(CharacterType.SIGMA);
				if ((object)characterControllerFromType != null && ((UnityEngine.Object)characterControllerFromType).m_CachedPtr != (IntPtr)0)
				{
					_controllingCharacter = characterControllerFromType;
					goto IL_02b0;
				}
				GameManager core3 = GM.Core;
				if ((object)GM.Core != null)
				{
					VampireSurvivors.Objects.Characters.CharacterController characterController = core3._003CChestWinnerPlayer_003Ek__BackingField;
					if ((object)core3._003CChestWinnerPlayer_003Ek__BackingField != null && ((UnityEngine.Object)characterController).m_CachedPtr != (IntPtr)0)
					{
						GameManager core4 = GM.Core;
						if ((object)GM.Core != null)
						{
							controllingCharacter = core4._003CChestWinnerPlayer_003Ek__BackingField;
							goto IL_0259;
						}
					}
					else if ((object)GM.Core != null)
					{
						controllingCharacter = GM.Core.PlayerOne;
						goto IL_0259;
					}
				}
			}
		}
		goto IL_06d3;
		IL_06d3:
		throw new NullReferenceException();
		IL_02b0:
		GameManager core5 = GM.Core;
		Vector2 ret = default(Vector2);
		Vector3 ret2 = default(Vector3);
		Vector2 vector = default(Vector2);
		if ((object)GM.Core != null && core5._multiplayer != null)
		{
			int localPlayerCount = core5._multiplayer.GetLocalPlayerCount();
			if (localPlayerCount > 1)
			{
				VampireSurvivors.Objects.Characters.CharacterController controllingCharacter2 = _controllingCharacter;
				if ((object)_controllingCharacter == null || Multiplayer == null)
				{
					goto IL_06d3;
				}
				float vibrationMS = default(float);
				Multiplayer.SelectPlayerToControlUI(controllingCharacter2._player, exclusiveUIControl: true, vibrate: true, vibrationMS);
			}
			VampireSurvivors.Objects.Characters.CharacterController controllingCharacter3 = _controllingCharacter;
			if ((object)_controllingCharacter != null)
			{
				CharacterData currentSkinData = controllingCharacter3._currentSkinData;
				if (controllingCharacter3._currentSkinData != null)
				{
					Sprite sprite = SpriteManager.GetSprite(currentSkinData._003CspriteName_003Ek__BackingField);
					if ((object)_characterImage != null)
					{
						_characterImage.sprite = sprite;
						if ((object)_characterImage != null)
						{
							RectTransform rectTransform = _characterImage.rectTransform;
							MultiplayerManager characterImage = (MultiplayerManager)(object)_characterImage;
							if ((object)_characterImage != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v22 (VampireSurvivors.Framework.MultiplayerManager)+E0]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v22 (VampireSurvivors.Framework.MultiplayerManager)+E0]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdi_v23 (System.Object)+10]");
									bool flag = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rdi_v23 (System.Object)+10]");
									Sprite.get_rect_Injected((IntPtr)0, out *(Rect*)(&ret));
									MultiplayerManager characterImage2 = (MultiplayerManager)(object)_characterImage;
									if ((object)_characterImage != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdi_v24 (VampireSurvivors.Framework.MultiplayerManager)+E0]");
										MultiplayerManager multiplayerManager = (MultiplayerManager)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ rdi_v24 (VampireSurvivors.Framework.MultiplayerManager)+E0]");
										if ((nint)0 != 0)
										{
											bool flag2 = multiplayerManager._playerOptions == null;
											Sprite.get_rect_Injected((IntPtr)multiplayerManager._playerOptions, out *(Rect*)(&ret2));
											if ((object)rectTransform != null)
											{
												rectTransform.sizeDelta = vector;
												if ((object)_characterPanel != null)
												{
													_characterPanel.SetActive(value: true);
													ret = (Vector2)0;
													goto IL_055b;
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
		goto IL_06d3;
		IL_055b:
		GameManager core6 = GM.Core;
		if ((object)GM.Core != null)
		{
			_ = _controllingCharacter;
			VampireSurvivors.App.Tools.Extensions.SetPivot(_infoGroup, vector);
			if ((object)_infoGroup != null)
			{
				Transform transform = _infoGroup.transform;
				bool flag3 = (object)transform == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ rax_v35 (UnityEngine.Transform)+10]");
				bool flag4 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1137 @ rax_v35 (UnityEngine.Transform)+10]");
				Transform.set_localScale_Injected((IntPtr)0, ref ret2);
				bool flag5 = (object)_titleBackground == null;
				Transform transform2 = _titleBackground.transform;
				bool flag6 = (object)transform2 == null;
				transform2.localEulerAngles = (Vector3)(&ret);
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_titleBackground, (Vector3)(&ret), 0.2f);
				if ((object)_titleBackground != null)
				{
					Transform transform3 = _titleBackground.transform;
					bool flag7 = (object)transform3 == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1853 @ rax_v50 (UnityEngine.Transform)+10]");
					bool flag8 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1853 @ rax_v50 (UnityEngine.Transform)+10]");
					Vector3 value = default(Vector3);
					Transform.set_localScale_Injected((IntPtr)0, ref value);
					bool flag9 = (object)_titleBackground == null;
					Transform target = _titleBackground.transform;
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, 1f, 0.2f);
					bool flag10 = (object)_collectRandomButton == null;
					GameObject gameObject = _collectRandomButton.gameObject;
					bool flag11 = (object)gameObject == null;
					gameObject.SetActive(value: false);
					ClearSpawned();
					TweenerCore<Color, Color, ColorOptions> tweenerCore3 = DOTweenModuleUI.DOFade(_blackFader, 0.5f, 1f);
					return;
				}
			}
		}
		goto IL_06d3;
		IL_0259:
		if ((object)this != null)
		{
			_controllingCharacter = controllingCharacter;
			if ((object)GM.Core != null)
			{
				GM.Core.ChestWinnerPlayer = null;
				goto IL_02b0;
			}
		}
		goto IL_06d3;
	}

	protected override void OnShowFinish(GameObject g)
	{
		base.OnShowFinish(g);
		GridLayoutGroup component = _minorCardContainer.GetComponent<GridLayoutGroup>();
		component.enabled = true;
	}

	private void InitializeRingsOfCards()
	{
		List<SpinningRingOfCards>.Enumerator enumerator = default(List<SpinningRingOfCards>.Enumerator);
		if (enumerator.MoveNext())
		{
			SpinningRingOfCards spinningRingOfCards = null;
			throw new NullReferenceException();
		}
	}

	protected override VampireSurvivors.Objects.Characters.CharacterController GetCharacterControllingUi()
	{
		return _controllingCharacter;
	}

	private unsafe void UpdateButtonNavigation()
	{
		//IL_0026: Expected O, but got Ref
		Selectable component = _boosterButton.GetComponent<Selectable>();
		object obj = default(object);
		component.navigation = (Navigation)(&obj);
		Selectable component2 = _boosterButton.GetComponent<Selectable>();
		Selectable component3 = _skipButton.GetComponent<Selectable>();
		SetNavigationDown(component2, component3);
		Selectable component4 = _boosterButton.GetComponent<Selectable>();
		List<GameObject> spawned = _spawned;
		if (spawned._size > 0)
		{
			GameObject[] items = spawned._items;
			Selectable component5 = items[0].GetComponent<Selectable>();
			SetNavigationUp(component4, component5);
			Selectable component6 = _boosterButton.GetComponent<Selectable>();
			Selectable component7 = _getButton.GetComponent<Selectable>();
			SetNavigationRight(component6, component7);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	public void Skip()
	{
		//IL_00a0: Expected I8, but got O
		//IL_00b8: Expected I8, but got O
		//IL_007f: Expected O, but got I
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			float time = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA19D0");
			return;
		}
		long num = (long)OnlineStageManager._instance;
		Action<long> action = null;
		((OnlineStageManager)(object)action).SkipSurvarots((long)OnlineStageManager._instance);
		long startingOnlineClientFrame = OnlineStageManager._instance.GetStartingOnlineClientFrame();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ rbx_v3 (System.Int64)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All, startingOnlineClientFrame);
	}

	private void PerformSkip()
	{
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickOut, null, 0f, 10, time);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA19D0");
	}

	private void SetReRollButton()
	{
		//IL_03b6: Expected I4, but got F4
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_03df: Invalid comparison between F4 and I4
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_0212: Expected I4, but got F4
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		GameObject gameObject = _minorGetButton.gameObject;
		bool active = IsLocalPlayerControllingUi();
		gameObject.SetActive(active);
		GameObject gameObject2 = _skipButton.gameObject;
		bool active2 = IsLocalPlayerControllingUi();
		gameObject2.SetActive(active2);
		float num = default(float);
		float num2;
		if (!_hasFreeReroll)
		{
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, num);
			VampireSurvivors.Objects.Characters.CharacterController controllingCharacter = _controllingCharacter;
			PlayerModifierStats playerStats = controllingCharacter._playerStats;
			EggFloat eggFloat = playerStats._003CReRolls_003Ek__BackingField;
			num2 = eggFloat._eggVal + eggFloat._val;
			object obj = num2 & -2147483649L;
			if ((nint)obj != 2139095040)
			{
				object obj2 = num2 & -2147483649L;
				if ((nint)obj2 <= 2139095040)
				{
					bool flag = num2 == -1f / 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186DD287Dh\"");
					if (flag)
					{
						goto IL_0188;
					}
					goto IL_03d6;
				}
			}
			num2 = 3.4028235E+38f;
			goto IL_03d6;
		}
		GameObject gameObject3 = _rerollButton.gameObject;
		bool active3 = IsLocalPlayerControllingUi();
		gameObject3.SetActive(active3);
		TextMeshProUGUI rerollCountText = _rerollCountText;
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("lang/free_reroll", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		string text = translation;
		TextMeshProUGUI textMeshProUGUI = rerollCountText;
		goto IL_0411;
		IL_03d6:
		TextMeshProUGUI rerollCountText2;
		string translation2;
		float num3;
		if (num2 > 0f)
		{
			GameObject gameObject4 = _rerollButton.gameObject;
			bool active4 = IsLocalPlayerControllingUi();
			gameObject4.SetActive(active4);
			rerollCountText2 = _rerollCountText;
			translation2 = LocalizationManager.GetTranslation("lang/levelup_Xleft", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)num != 0, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			VampireSurvivors.Objects.Characters.CharacterController controllingCharacter2 = _controllingCharacter;
			PlayerModifierStats playerStats2 = controllingCharacter2._playerStats;
			EggFloat eggFloat2 = playerStats2._003CReRolls_003Ek__BackingField;
			num3 = eggFloat2._eggVal + eggFloat2._val;
			object obj3 = num3 & -2147483649L;
			if ((nint)obj3 != 2139095040)
			{
				object obj4 = num3 & -2147483649L;
				if ((nint)obj4 <= 2139095040)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186DD29AEh\"");
					if (num3 == -1f / 0f)
					{
						num3 = -3.4028235E+38f;
					}
					goto IL_03f4;
				}
			}
			num3 = 3.4028235E+38f;
			goto IL_03f4;
		}
		goto IL_0188;
		IL_0188:
		GameObject gameObject5 = _rerollButton.gameObject;
		gameObject5.SetActive(value: false);
		return;
		IL_03f4:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string newValue = System.Number.FormatSingle(num3, "F0", currentInfo);
		string text2 = translation2.Replace("%0", newValue);
		text = text2;
		textMeshProUGUI = rerollCountText2;
		goto IL_0411;
		IL_0411:
		textMeshProUGUI.text = text;
	}

	private void SetBoosterButton()
	{
		float num = CurrentBoosterCost();
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		string text = System.Number.FormatSingle(num, "F0", currentInfo);
		_boosterPriceText.text = text;
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		bool active;
		if (!(num > config._003CCoins_003Ek__BackingField))
		{
			bool flag = IsLocalPlayerControllingUi();
			active = flag;
		}
		else
		{
			active = false;
		}
		_boosterButton.SetActive(active);
	}

	private float CurrentBoosterCost()
	{
		//IL_00e3: Expected O, but got I4
		//IL_00ec: Expected O, but got I4
		//IL_00c3: Expected O, but got I4
		//IL_00cc: Expected O, but got I4
		//IL_010a: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_00ac: Expected O, but got I4
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		//IL_02d1: Expected F4, but got I
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_01c9: Expected F4, but got I
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null)
			{
				object obj2;
				if (!(1000000f > config._003CCoins_003Ek__BackingField))
				{
					if (!(100000000f > config._003CCoins_003Ek__BackingField))
					{
						object obj = 40;
						obj2 = 2;
						float num = 100000000f;
					}
					else
					{
						object obj = 36;
						obj2 = 1;
						float num = 100000000f;
					}
				}
				else
				{
					object obj = 32;
					obj2 = 0;
					float num = 1000000f;
				}
				bool flag = _boostersBought == 0;
				if (!flag)
				{
					object obj3 = _boostersBought - 1;
					float[] array;
					Array array2;
					RuntimeFieldHandle fldHandle;
					if (!flag)
					{
						object obj4 = obj3 - 1;
						if (!flag)
						{
							object obj5 = obj4 - 1;
							if (!flag)
							{
								if ((nint)obj5 != 1)
								{
									array = new float[3];
									array2 = array;
									fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
								}
								else
								{
									array = new float[3];
									array2 = array;
									fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
								}
							}
							else
							{
								array = new float[3];
								array2 = array;
								fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
							}
						}
						else
						{
							array = new float[3];
							array2 = array;
							fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
						}
					}
					else
					{
						array = new float[3];
						array2 = array;
						fldHandle = (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/;
					}
					RuntimeHelpers.InitializeArray(array, fldHandle);
					if (array2 == null)
					{
						goto IL_02d6;
					}
					object obj6 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdi_v6 (System.Array)+18]");
					if ((nint)obj6 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdi_v6 (System.Array)+20+v74 @ rbx_v3*4]");
						return 0f;
					}
				}
				else
				{
					float[] array3 = new float[3] { 2999f, 9999f, 99999f };
					if (array3 == null)
					{
						goto IL_02d6;
					}
					if ((nint)obj2 < array3.Length)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdi_v3+v292 @ rax_v10 (System.Single[])]");
						return 0f;
					}
				}
				throw new IndexOutOfRangeException();
			}
		}
		goto IL_02d6;
		IL_02d6:
		throw new NullReferenceException();
	}

	public void Booster()
	{
		//IL_00a5: Expected O, but got I
		Button component = _boosterButton.GetComponent<Button>();
		component.interactable = false;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 125 Invalid \"Jump target not found in method: 0x186DD30A0\"");
		}
		object instance = OnlineStageManager._instance;
		Action action = OnlineStageManager._instance.BoosterSurvarots;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ rbx_v4 (System.Object)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All);
	}

	private unsafe void PerformBooster()
	{
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8f: Expected O, but got Unknown
		//IL_04ed: Expected O, but got I
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_058e: Expected Ref, but got Unknown
		//IL_12be: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c3: Expected Ref, but got Unknown
		//IL_130e: Expected O, but got I
		//IL_131e: Expected O, but got I
		//IL_0298: Expected O, but got I
		//IL_0318: Expected O, but got I
		//IL_056a: Expected O, but got I
		//IL_035e: Expected O, but got I
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		//IL_02f2: Expected O, but got Ref
		//IL_0f6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f74: Expected O, but got Unknown
		//IL_0611: Expected O, but got I
		//IL_08e1: Expected O, but got I4
		//IL_0e54: Expected O, but got Ref
		//IL_0e6f: Expected I, but got O
		//IL_0e85: Expected O, but got I
		//IL_0e8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e93: Expected O, but got Unknown
		//IL_0418: Expected I, but got O
		//IL_0eb9: Expected O, but got I4
		//IL_0ed0: Expected I, but got I8
		//IL_0401: Expected I, but got I8
		//IL_0756: Expected O, but got I4
		//IL_0893: Expected I4, but got F4
		//IL_0893: Expected O, but got Ref
		//IL_1175: Expected O, but got Ref
		//IL_11dc: Expected I, but got O
		//IL_0c50: Expected I, but got O
		//IL_0c66: Expected O, but got I
		//IL_0c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c74: Expected O, but got Unknown
		//IL_0cea: Expected I, but got O
		//IL_1271: Expected I, but got I8
		//IL_0cc6: Expected I, but got I8
		//IL_0302->IL0ded: Incompatible stack heights: 6 vs 7
		//IL_0631->IL0d5c: Incompatible stack heights: 1 vs 0
		//IL_065a->IL0d5c: Incompatible stack heights: 1 vs 0
		//IL_067c->IL0d5c: Incompatible stack heights: 1 vs 0
		//IL_0931->IL0d5c: Incompatible stack heights: 1 vs 0
		//IL_0fd1->IL0d5c: Incompatible stack heights: 1 vs 0
		//IL_0eeb->IL0ef0: Incompatible stack heights: 9 vs 0
		//IL_0958->IL0d5c: Incompatible stack heights: 1 vs 0
		//IL_071c->IL0d5c: Incompatible stack heights: 1 vs 0
		//IL_044d->IL0ef0: Incompatible stack heights: 9 vs 0
		//IL_098c->IL0d5c: Incompatible stack heights: 1 vs 0
		//IL_045f->IL0ef0: Incompatible stack heights: 9 vs 0
		//IL_09be->IL0d5c: Incompatible stack heights: 1 vs 0
		//IL_080f->IL0fd6: Incompatible stack heights: 1 vs 0
		//IL_0a0e->IL0d5c: Incompatible stack heights: 2 vs 0
		//IL_0a35->IL0d5c: Incompatible stack heights: 2 vs 0
		//IL_0a69->IL0d5c: Incompatible stack heights: 2 vs 0
		//IL_0a92->IL0d5c: Incompatible stack heights: 2 vs 0
		//IL_0ab4->IL0d5c: Incompatible stack heights: 2 vs 0
		//IL_0af8->IL0d5c: Incompatible stack heights: 2 vs 0
		//IL_08d8->IL120b: Incompatible stack heights: 9 vs 0
		//IL_0b48->IL0d5c: Incompatible stack heights: 3 vs 0
		//IL_0b6f->IL0d5c: Incompatible stack heights: 3 vs 0
		//IL_0bc1->IL0d5c: Incompatible stack heights: 3 vs 0
		//IL_0bed->IL0d5c: Incompatible stack heights: 3 vs 0
		float num = default(float);
		List<GameObject>.Enumerator ret;
		List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
		List<GameObject>.Enumerator value = default(List<GameObject>.Enumerator);
		List<SkillCardEdition> list2;
		float num6 = default(float);
		if ((object)_minorCardContainer != null)
		{
			GridLayoutGroup component = _minorCardContainer.GetComponent<GridLayoutGroup>();
			if ((object)component != null)
			{
				component.enabled = true;
				if ((object)_minorCardContainer != null)
				{
					GridLayoutGroup component2 = _minorCardContainer.GetComponent<GridLayoutGroup>();
					if ((object)component2 != null)
					{
						object obj = component2 + 104;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A903E0");
						PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, num);
						SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
						soundConfig.Rate = 1f;
						soundConfig.Detune = 400f;
						PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.ClickIn, soundConfig, 0f, 10, num);
						SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
						soundConfig2.Rate = 1f;
						soundConfig2.Detune = -800f;
						PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.ClickIn, soundConfig2, 0f, 10, num);
						if ((object)_minorCardContainer != null)
						{
							CanvasGroup component3 = _minorCardContainer.GetComponent<CanvasGroup>();
							if ((object)component3 != null)
							{
								component3.interactable = false;
								List<Vector3> list = new List<Vector3>();
								if (_spawned != null)
								{
									List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
									List<GameObject>.Enumerator endValue = default(List<GameObject>.Enumerator);
									List<GameObject>.Enumerator enumerator3 = default(List<GameObject>.Enumerator);
									while (enumerator.MoveNext())
									{
										_003C_003Ec__DisplayClass74_0 obj2 = new _003C_003Ec__DisplayClass74_0();
										bool flag = obj2 == null;
										obj2.v = null;
										bool flag2 = (object)obj2.v == null;
										RectTransform component4 = obj2.v.GetComponent<RectTransform>();
										bool flag3 = (object)component4 == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1513 @ rax_v248 (UnityEngine.RectTransform)+10]");
										bool flag4 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1513 @ rax_v248 (UnityEngine.RectTransform)+10]");
										Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
										bool flag5 = list == null;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1746 @ rax_v88 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
										_ = (nint)0 + (nint)1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1746 @ rax_v88 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
										Vector3 vector = (Vector3)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1746 @ rax_v88 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
										bool flag6 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1746 @ rax_v88 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
										nint num2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ rdx_v122 (UnityEngine.Vector3)+18]");
										if (num2 >= 0)
										{
											list.AddWithResize((Vector3)(&enumerator2));
											enumerator2 = ret;
										}
										else
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1746 @ rax_v88 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
											object obj3 = (nint)0 + (nint)1;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1746 @ rax_v88 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
											nint num3 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v814 @ rdx_v122 (UnityEngine.Vector3)+18]");
											bool flag7 = num3 >= 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1746 @ rax_v88 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
											object obj4 = (nint)0 * (nint)2;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1746 @ rax_v88 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
											object obj5 = 0 + obj4;
											_ = 0;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1513 @ rax_v248 (UnityEngine.RectTransform)+10]");
										bool flag8 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1513 @ rax_v248 (UnityEngine.RectTransform)+10]");
										RectTransform.get_sizeDelta_Injected((IntPtr)0, out Vector2 _);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1513 @ rax_v248 (UnityEngine.RectTransform)+10]");
										bool flag9 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1513 @ rax_v248 (UnityEngine.RectTransform)+10]");
										RectTransform.get_sizeDelta_Injected((IntPtr)0, out *(Vector2*)(&value));
										TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(component4, (Vector2)endValue, 0.24f);
										TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(component4, (Vector3)(&enumerator3), 0.24f);
										TweenCallback tweenCallback = null;
										nint num4 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1998 @ r10_v33 (Il2CppMethodInfo)+8]");
										((Delegate)tweenCallback).method_ptr = (IntPtr)0;
										((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass74_0._003CPerformBooster_003Eb__1);
										((Delegate)tweenCallback).m_target = obj2;
										((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1998 @ r10_v33 (Il2CppMethodInfo)+4C]");
										object obj6 = (nint)0 >> 4;
										object obj7 = obj6 & 1;
										nint num5;
										if (obj7 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1998 @ r10_v33 (Il2CppMethodInfo)+52]");
											if ((nint)0 == 0)
											{
												num5 = unchecked((nint)6447293664L);
												goto IL_0eb0;
											}
										}
										((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
										num5 = ((Delegate)tweenCallback).method_ptr;
										goto IL_0eb0;
										IL_0eb0:
										object obj8 = 24;
										((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
										if (tweenerCore2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3971 @ rax_v266 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
											if ((nint)0 == 0)
											{
											}
										}
									}
									List<GameObject> spawned = _spawned;
									if (_spawned != null)
									{
										int version = spawned._version + 1;
										spawned._version = version;
										spawned._size = 0;
										if (spawned._size > 0)
										{
											Array.Clear(spawned._items, 0, spawned._size);
										}
										list2 = new List<SkillCardEdition>();
										if (list2 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2514 @ rax_v98 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
											GridLayoutGroup gridLayoutGroup = (GridLayoutGroup)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2514 @ rax_v98 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
											if ((nint)0 >= (nint)7)
											{
												goto IL_0583;
											}
											float wInve = default(float);
											while (true)
											{
												SkillCardEdition weightedEdition = CharacterSkillCardsManager.GetWeightedEdition(ref *(Unity.Mathematics.Random*)(this + 652), 0f, 4f, 4f, num, num6, wInve);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2514 @ rax_v98 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+1C]");
												_ = (nint)0 + (nint)1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2514 @ rax_v98 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+10]");
												object obj9 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2514 @ rax_v98 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
												object obj10 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2514 @ rax_v98 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+10]");
												if ((nint)0 == 0)
												{
													break;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2514 @ rax_v98 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
												nint num7 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ rdx_v115+18]");
												if (num7 >= 0)
												{
													((List<System.Int32Enum>)(object)list2).AddWithResize((System.Int32Enum)weightedEdition);
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2514 @ rax_v98 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
													object obj11 = (nint)0 + (nint)1;
												}
												gridLayoutGroup = (GridLayoutGroup)(gridLayoutGroup + 1);
												bool flag10 = (nint)gridLayoutGroup < 7;
												float num8 = 4f;
												if (flag10)
												{
													continue;
												}
												goto IL_0583;
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
		goto IL_0d5c;
		IL_0583:
		List<ArcanaType> weightedSurvarots = CharacterSkillCard_RandomGenerator.GetWeightedSurvarots(7, ref *(Unity.Mathematics.Random*)(this + 652));
		if (weightedSurvarots != null)
		{
			ArcanaType arcanaType = ArcanaType.T00_KILLER;
			ArcanaType arcanaType2 = ArcanaType.T00_KILLER;
			List<GameObject>.Enumerator enumerator4 = default(List<GameObject>.Enumerator);
			Vector3 vector2 = default(Vector3);
			while (true)
			{
				ArcanaType num9 = arcanaType2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rax_v102 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
				if ((nint)num9 < (nint)0)
				{
					_003C_003Ec__DisplayClass74_1 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass74_1();
					ArcanaType num10 = arcanaType;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rax_v102 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
					bool flag11 = (nint)num10 >= (nint)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rax_v102 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
					object obj12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v661 @ rax_v102 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					DataManager data = _data;
					if (_data == null || data._003CAllArcanas_003Ek__BackingField == null)
					{
						break;
					}
					Dictionary<ArcanaType, ArcanaData> dictionary = data._003CAllArcanas_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v662 @ rax_v215+20+v103 @ rsi_v34 (VampireSurvivors.Data.ArcanaType)*4]");
					bool flag12 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryGetValue((System.Int32Enum)0, out object value2);
					ArcanaType num11 = arcanaType;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2514 @ rax_v98 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
					bool edition = (nint)num11 < (nint)0 && ((Dictionary<ArcanaType, ArcanaData>)(object)list2).TryGetValue(arcanaType, out *(ArcanaData*)(&value2));
					object data2 = value2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v662 @ rax_v215+20+v103 @ rsi_v34 (VampireSurvivors.Data.ArcanaType)*4]");
					ArcanaCardUI c = SpawnCharacterCard((ArcanaData)data2, ArcanaType.T00_KILLER, edition ? SkillCardEdition.Foil : SkillCardEdition.Base);
					if (CS_0024_003C_003E8__locals6 == null)
					{
						break;
					}
					CS_0024_003C_003E8__locals6.c = c;
					if ((object)CS_0024_003C_003E8__locals6.c == null)
					{
						break;
					}
					CS_0024_003C_003E8__locals6.c.SetClosed();
					TweenCallback onComplete = delegate
					{
						Tween tween4 = CS_0024_003C_003E8__locals6.c.Reveal();
					};
					object obj13 = arcanaType + 6;
					float duration = (float)obj13 * 50f;
					Tween gameId = UITimerHelper.RegisterMillis(duration, onComplete);
					Tween tween = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId);
					if (arcanaType == ArcanaType.T00_KILLER)
					{
						TweenCallback onComplete2 = delegate
						{
							Selectable component9 = CS_0024_003C_003E8__locals6.c.GetComponent<Selectable>();
							component9.Select();
						};
						Tween gameId2 = UITimerHelper.RegisterMillis(50f, onComplete2);
						Tween tween2 = VampireSurvivors.Tools.TweenExtensions.SetGameId(gameId2);
					}
					arcanaType++;
					arcanaType2 = arcanaType;
					continue;
				}
				if (_spawned == null)
				{
					break;
				}
				while (enumerator4.MoveNext())
				{
					object obj14 = null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1688 @ r14_v37 (System.Object)+10]");
					bool flag13 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1688 @ r14_v37 (System.Object)+10]");
					IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
					Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
					bool flag14 = (object)transform == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3083 @ rax_v151 (UnityEngine.Transform)+10]");
					bool flag15 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3083 @ rax_v151 (UnityEngine.Transform)+10]");
					Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
					TweenToLayoutGroup tweenToLayoutGroup = ((GameObject)null).AddComponent<TweenToLayoutGroup>();
					bool flag16 = (object)this == null;
					bool flag17 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)this).m_CachedPtr);
					Transform sender = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
					bool flag18 = (object)tweenToLayoutGroup == null;
					tweenToLayoutGroup.TweenFromLocationToLayoutSpot(sender, (Vector3)(&vector2), 0.24f, num, (byte)(int)num6 != 0);
					RectTransform component5 = ((GameObject)null).GetComponent<RectTransform>();
					bool flag19 = (object)component5 == null;
					bool flag20 = ((UnityEngine.Object)component5).m_CachedPtr == (IntPtr)0;
					RectTransform.set_anchoredPosition_Injected(((UnityEngine.Object)component5).m_CachedPtr, ref *(Vector2*)(&value));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1688 @ r14_v37 (System.Object)+10]");
					bool flag21 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1688 @ r14_v37 (System.Object)+10]");
					IntPtr gcHandlePtr3 = GameObject.get_transform_Injected((IntPtr)0);
					Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
					TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOMove(target, (Vector3)(&enumerator2), 0.24f);
					GridLayoutGroup gridLayoutGroup2 = (GridLayoutGroup)(object)_003C_003Ec._003C_003E9__74_4;
					bool flag22 = _003C_003Ec._003C_003E9__74_4 != null;
					bool flag23 = false;
					nint num12 = (nint)(&vector2);
					if (!flag22)
					{
						TweenCallback tweenCallback2 = delegate
						{
						};
						nint num13 = (nint)typeof(_003C_003Ec);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4595 @ rax_v190 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c>)+B8]");
						num12 = 0;
						_003C_003Ec._003C_003E9__74_4 = tweenCallback2;
						flag23 = false;
						gridLayoutGroup2 = (GridLayoutGroup)(object)tweenCallback2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B5D0");
					float num8 = 0.24f;
				}
				_003C_003Ec__DisplayClass74_1 obj15 = (_003C_003Ec__DisplayClass74_1)24;
				List<GameObject> spawned2 = _spawned;
				if (_spawned == null)
				{
					break;
				}
				bool flag24 = spawned2._size <= 0;
				GameObject[] items = spawned2._items;
				if (spawned2._items == null || (object)items[0] == null)
				{
					break;
				}
				Selectable component6 = items[0].GetComponent<Selectable>();
				if ((object)component6 == null)
				{
					break;
				}
				component6.Select();
				List<GameObject> spawned3 = _spawned;
				if (_spawned == null)
				{
					break;
				}
				bool flag25 = spawned3._size <= 0;
				GameObject[] items2 = spawned3._items;
				if (spawned3._items == null || (object)items2[0] == null)
				{
					break;
				}
				ArcanaCardUI component7 = items2[0].GetComponent<ArcanaCardUI>();
				if ((object)component7 == null)
				{
					break;
				}
				DataManager data3 = _data;
				if (_data == null || data3._003CAllArcanas_003Ek__BackingField == null)
				{
					break;
				}
				object data4 = ((Dictionary<System.Int32Enum, object>)(object)data3._003CAllArcanas_003Ek__BackingField).get_Item((System.Int32Enum)component7._type);
				List<GameObject> spawned4 = _spawned;
				if (_spawned == null)
				{
					break;
				}
				bool flag26 = spawned4._size <= 0;
				GameObject[] items3 = spawned4._items;
				if (spawned4._items == null || (object)items3[0] == null)
				{
					break;
				}
				SetInfo(ui: items3[0].GetComponent<ArcanaCardUI>(), data: (ArcanaData)data4, type: component7._type);
				if ((object)_boosterButton == null)
				{
					break;
				}
				Button component8 = _boosterButton.GetComponent<Button>();
				if ((object)component8 == null)
				{
					break;
				}
				component8.interactable = false;
				TweenCallback tweenCallback3 = null;
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4439 @ r9_v43 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback3).method = (nint)__ldftn(SurvarotsSelectionPage._003CPerformBooster_003Eb__74_0);
				((Delegate)tweenCallback3).m_target = this;
				((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4439 @ r9_v43 (Il2CppMethodInfo)+4C]");
				object obj16 = (nint)0 >> 4;
				object obj17 = obj16 & 1;
				nint num15;
				if (obj17 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4439 @ r9_v43 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num15 = unchecked((nint)6447293664L);
						goto IL_125a;
					}
				}
				num15 = ((Delegate)tweenCallback3).method_ptr;
				((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
				goto IL_125a;
				IL_125a:
				((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
				Tween tween3 = DOVirtual.DelayedCall(0.65000004f, tweenCallback3);
				tween3.stringId = "UI_CUSTOM_TIMER";
				float num16 = CurrentBoosterCost();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
				_playerOptions.RemoveCoins(0, removeFromLifetime: true);
				int boostersBought = _boostersBought + 1;
				_boostersBought = boostersBought;
				SetBoosterButton();
				UpdateButtonNavigation();
				return;
			}
		}
		goto IL_0d5c;
		IL_0d5c:
		throw new NullReferenceException();
	}

	private void PurchaseBooster()
	{
		float num = CurrentBoosterCost();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si edx,xmm0\"");
		_playerOptions.RemoveCoins(0, removeFromLifetime: true);
		int boostersBought = _boostersBought + 1;
		_boostersBought = boostersBought;
	}

	private unsafe void PerformReRoll()
	{
		//IL_027d: Expected O, but got I
		//IL_031d: Expected O, but got I4
		//IL_0382: Expected O, but got I
		//IL_10a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a9: Expected Ref, but got Unknown
		//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f7: Expected Ref, but got Unknown
		//IL_03cc: Expected O, but got I
		//IL_044c: Expected O, but got I
		//IL_0779: Expected O, but got I
		//IL_0492: Expected O, but got I
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Expected O, but got Unknown
		//IL_0426: Expected O, but got Ref
		//IL_0a4f: Expected O, but got I4
		//IL_0fb2: Expected O, but got Ref
		//IL_0fcd: Expected I, but got O
		//IL_0fe3: Expected O, but got I
		//IL_0fec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff1: Expected O, but got Unknown
		//IL_054b: Expected I, but got O
		//IL_1025: Expected I, but got I8
		//IL_088a: Expected I, but got O
		//IL_0534: Expected I, but got I8
		//IL_08ba: Expected O, but got I
		//IL_08e1: Expected O, but got I4
		//IL_0a0a: Expected O, but got Ref
		//IL_129f: Expected O, but got Ref
		//IL_1306: Expected I, but got O
		//IL_0ddc: Expected I, but got O
		//IL_0df2: Expected O, but got I
		//IL_0dfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e00: Expected O, but got Unknown
		//IL_0e76: Expected I, but got O
		//IL_13a1: Expected I, but got I8
		//IL_13af: Expected O, but got I4
		//IL_13b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13bd: Expected O, but got Unknown
		//IL_0e52: Expected I, but got I8
		//IL_0799->IL0ea6: Incompatible stack heights: 1 vs 0
		//IL_0436->IL0f4b: Incompatible stack heights: 6 vs 7
		//IL_07c8->IL0ea6: Incompatible stack heights: 1 vs 0
		//IL_07ea->IL0ea6: Incompatible stack heights: 1 vs 0
		//IL_0829->IL0ea6: Incompatible stack heights: 1 vs 0
		//IL_0a9f->IL0ea6: Incompatible stack heights: 1 vs 0
		//IL_0ac6->IL0ea6: Incompatible stack heights: 1 vs 0
		//IL_10f8->IL0ea6: Incompatible stack heights: 1 vs 0
		//IL_0afa->IL0ea6: Incompatible stack heights: 1 vs 0
		//IL_1041->IL1046: Incompatible stack heights: 9 vs 0
		//IL_08a7->IL0ea6: Incompatible stack heights: 1 vs 0
		//IL_0b32->IL0ea6: Incompatible stack heights: 1 vs 0
		//IL_0581->IL1046: Incompatible stack heights: 9 vs 0
		//IL_0594->IL1046: Incompatible stack heights: 9 vs 0
		//IL_0b82->IL0ea6: Incompatible stack heights: 2 vs 0
		//IL_0980->IL10fd: Incompatible stack heights: 1 vs 0
		//IL_0ba9->IL0ea6: Incompatible stack heights: 2 vs 0
		//IL_0bdd->IL0ea6: Incompatible stack heights: 2 vs 0
		//IL_0c0c->IL0ea6: Incompatible stack heights: 2 vs 0
		//IL_0c2e->IL0ea6: Incompatible stack heights: 2 vs 0
		//IL_0c78->IL0ea6: Incompatible stack heights: 2 vs 0
		//IL_0a46->IL1335: Incompatible stack heights: 9 vs 0
		//IL_0cc8->IL0ea6: Incompatible stack heights: 3 vs 0
		//IL_0cef->IL0ea6: Incompatible stack heights: 3 vs 0
		//IL_0d47->IL0ea6: Incompatible stack heights: 3 vs 0
		//IL_0d76->IL0ea6: Incompatible stack heights: 3 vs 0
		//IL_1460->IL0ea6: Incompatible stack heights: 3 vs 0
		GridLayoutGroup component2;
		if ((object)_minorCardContainer != null)
		{
			GridLayoutGroup component = _minorCardContainer.GetComponent<GridLayoutGroup>();
			if ((object)component != null)
			{
				component.enabled = true;
				if (_playerOptions != null)
				{
					PlayerOptionsData config = _playerOptions.Config;
					if (config != null)
					{
						List<ArcanaType> list = config._003CUnlockedArcanas_003Ek__BackingField;
						if (config._003CUnlockedArcanas_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v724 @ rax_v76 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
							if ((nint)0 <= (nint)22)
							{
								if ((object)_minorCardContainer != null)
								{
									component2 = _minorCardContainer.GetComponent<GridLayoutGroup>();
									if ((object)component2 != null)
									{
										goto IL_0ecb;
									}
								}
							}
							else if ((object)_minorCardContainer != null)
							{
								component2 = _minorCardContainer.GetComponent<GridLayoutGroup>();
								if ((object)component2 != null)
								{
									goto IL_0ecb;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0ea6;
		IL_0ea6:
		throw new NullReferenceException();
		IL_0edd:
		List<GameObject>.Enumerator enumerator3 = default(List<GameObject>.Enumerator);
		float num9 = default(float);
		if ((object)_minorCardContainer != null)
		{
			CanvasGroup component3 = _minorCardContainer.GetComponent<CanvasGroup>();
			if ((object)component3 != null)
			{
				component3.interactable = false;
				List<Vector3> list2 = new List<Vector3>();
				if (_spawned != null)
				{
					List<GameObject> list3 = (List<GameObject>)24;
					List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
					List<GameObject>.Enumerator ret;
					List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
					List<GameObject>.Enumerator enumerator4 = default(List<GameObject>.Enumerator);
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass76_0 obj = new _003C_003Ec__DisplayClass76_0();
						bool flag = obj == null;
						obj.v = null;
						bool flag2 = ((UnityEngine.Object)(object)obj).m_CachedPtr == (IntPtr)0;
						RectTransform component4 = ((GameObject)(nint)((UnityEngine.Object)(object)obj).m_CachedPtr).GetComponent<RectTransform>();
						bool flag3 = (object)component4 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1585 @ rax_v240 (UnityEngine.RectTransform)+10]");
						bool flag4 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1585 @ rax_v240 (UnityEngine.RectTransform)+10]");
						Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
						bool flag5 = list2 == null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1961 @ rax_v84 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+1C]");
						_ = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1961 @ rax_v84 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
						Vector3 vector = (Vector3)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1961 @ rax_v84 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+10]");
						bool flag6 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1961 @ rax_v84 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ rdx_v116 (UnityEngine.Vector3)+18]");
						if (num >= 0)
						{
							list2.AddWithResize((Vector3)(&enumerator2));
							enumerator2 = ret;
						}
						else
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1961 @ rax_v84 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj2 = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1961 @ rax_v84 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v888 @ rdx_v116 (UnityEngine.Vector3)+18]");
							bool flag7 = num2 >= 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1961 @ rax_v84 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj3 = (nint)0 * (nint)2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1961 @ rax_v84 (System.Collections.Generic.List`1<UnityEngine.Vector3>)+18]");
							object obj4 = 0 + obj3;
							_ = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1585 @ rax_v240 (UnityEngine.RectTransform)+10]");
						bool flag8 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1585 @ rax_v240 (UnityEngine.RectTransform)+10]");
						RectTransform.get_sizeDelta_Injected((IntPtr)0, out Vector2 _);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1585 @ rax_v240 (UnityEngine.RectTransform)+10]");
						bool flag9 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1585 @ rax_v240 (UnityEngine.RectTransform)+10]");
						RectTransform.get_sizeDelta_Injected((IntPtr)0, out Vector2 _);
						TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTweenModuleUI.DOAnchorPos(component4, (Vector2)enumerator3, 0.24f);
						TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore2 = ShortcutExtensions.DOLocalRotate(component4, (Vector3)(&enumerator4), 0.24f);
						TweenCallback tweenCallback = null;
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2300 @ r10_v32 (Il2CppMethodInfo)+8]");
						((Delegate)tweenCallback).method_ptr = (IntPtr)0;
						((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass76_0._003CPerformReRoll_003Eb__1);
						((Delegate)tweenCallback).m_target = obj;
						((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2300 @ r10_v32 (Il2CppMethodInfo)+4C]");
						object obj5 = (nint)0 >> 4;
						object obj6 = obj5 & 1;
						nint num4;
						if (obj6 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2300 @ r10_v32 (Il2CppMethodInfo)+52]");
							if ((nint)0 == 0)
							{
								num4 = unchecked((nint)6447293664L);
								goto IL_100e;
							}
						}
						((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
						num4 = ((Delegate)tweenCallback).method_ptr;
						goto IL_100e;
						IL_100e:
						((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
						if (tweenerCore2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3951 @ rax_v258 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
							if ((nint)0 == 0)
							{
							}
						}
					}
					SurvarotsSelectionPage survarotsSelectionPage = default(SurvarotsSelectionPage);
					List<GameObject> spawned = survarotsSelectionPage._spawned;
					if (survarotsSelectionPage._spawned != null)
					{
						int version = spawned._version + 1;
						spawned._version = version;
						spawned._size = 0;
						bool flag10 = spawned._size < 0;
						if (spawned._size > 0)
						{
							Array.Clear(spawned._items, 0, spawned._size);
						}
						object obj7 = (object)survarotsSelectionPage._random << 13;
						object obj8 = obj7 ^ (object)survarotsSelectionPage._random;
						object obj9 = obj8 >> 17;
						object obj10 = obj9 ^ obj8;
						object obj11 = obj10 << 5;
						Unity.Mathematics.Random random = (Unity.Mathematics.Random)(obj11 ^ obj10);
						survarotsSelectionPage._random = random;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
						bool flag11 = !flag10;
						int num5 = (flag11 ? 1 : 0) + 4;
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm1\"");
						if (spawned._size >= 0)
						{
							num5 = 6;
						}
						List<SkillCardEdition> randomEditions = CharacterSkillCardsManager.GetRandomEditions(num5, ref *(Unity.Mathematics.Random*)(survarotsSelectionPage + 652));
						List<ArcanaType> weightedSurvarots = CharacterSkillCard_RandomGenerator.GetWeightedSurvarots(num5, ref *(Unity.Mathematics.Random*)(survarotsSelectionPage + 652));
						if (weightedSurvarots != null)
						{
							ArcanaType arcanaType = ArcanaType.T00_KILLER;
							bool flag12 = false;
							List<GameObject>.Enumerator enumerator5 = default(List<GameObject>.Enumerator);
							Vector3 vector2 = default(Vector3);
							bool isWorldPos = default(bool);
							List<GameObject>.Enumerator value2 = default(List<GameObject>.Enumerator);
							while (true)
							{
								bool num6 = flag12;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3055 @ rax_v102 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
								if ((nint)(num6 ? 1 : 0) < (nint)0)
								{
									_003C_003Ec__DisplayClass76_1 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass76_1();
									ArcanaType num7 = arcanaType;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3055 @ rax_v102 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
									bool flag13 = (nint)num7 >= (nint)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3055 @ rax_v102 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
									object obj12 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3055 @ rax_v102 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
									if ((nint)0 == 0)
									{
										break;
									}
									DataManager data = survarotsSelectionPage._data;
									if (survarotsSelectionPage._data == null || data._003CAllArcanas_003Ek__BackingField == null)
									{
										break;
									}
									Dictionary<ArcanaType, ArcanaData> dictionary = data._003CAllArcanas_003Ek__BackingField;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rax_v218+20+v101 @ rsi_v37 (VampireSurvivors.Data.ArcanaType)*4]");
									bool flag14 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryGetValue((System.Int32Enum)0, out object value);
									if (randomEditions == null)
									{
										break;
									}
									ArcanaType num8 = arcanaType;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2888 @ rax_v100 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
									bool edition = (nint)num8 < (nint)0 && ((Dictionary<ArcanaType, ArcanaData>)(object)randomEditions).TryGetValue(arcanaType, out *(ArcanaData*)(&value));
									object data2 = value;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v732 @ rax_v218+20+v101 @ rsi_v37 (VampireSurvivors.Data.ArcanaType)*4]");
									ArcanaCardUI arcanaCardUI = survarotsSelectionPage.SpawnCharacterCard((ArcanaData)data2, ArcanaType.T00_KILLER, edition ? SkillCardEdition.Foil : SkillCardEdition.Base);
									if (CS_0024_003C_003E8__locals6 == null)
									{
										break;
									}
									((UnityEngine.Object)(object)CS_0024_003C_003E8__locals6).m_CachedPtr = (IntPtr)arcanaCardUI;
									if (((UnityEngine.Object)(object)CS_0024_003C_003E8__locals6).m_CachedPtr == (IntPtr)0)
									{
										break;
									}
									((ArcanaCardUI)(nint)((UnityEngine.Object)(object)CS_0024_003C_003E8__locals6).m_CachedPtr).SetClosed();
									TweenCallback onComplete = delegate
									{
										Tween tween4 = CS_0024_003C_003E8__locals6.c.Reveal();
									};
									object obj13 = arcanaType + 6;
									float duration = (float)obj13 * 50f;
									Tween tween = UITimerHelper.RegisterMillis(duration, onComplete);
									if (arcanaType == ArcanaType.T00_KILLER)
									{
										TweenCallback onComplete2 = delegate
										{
											Selectable component9 = CS_0024_003C_003E8__locals6.c.GetComponent<Selectable>();
											component9.Select();
										};
										Tween tween2 = UITimerHelper.RegisterMillis(50f, onComplete2);
									}
									arcanaType++;
									flag12 = (byte)arcanaType != 0;
									continue;
								}
								if (survarotsSelectionPage._spawned == null)
								{
									break;
								}
								while (enumerator5.MoveNext())
								{
									SurvarotsSelectionPage survarotsSelectionPage2 = null;
									bool flag15 = ((UnityEngine.Object)survarotsSelectionPage2).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)survarotsSelectionPage2).m_CachedPtr);
									Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
									bool flag16 = (object)transform == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3125 @ rax_v153 (UnityEngine.Transform)+10]");
									bool flag17 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3125 @ rax_v153 (UnityEngine.Transform)+10]");
									Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
									TweenToLayoutGroup tweenToLayoutGroup = ((GameObject)null).AddComponent<TweenToLayoutGroup>();
									bool flag18 = (object)survarotsSelectionPage == null;
									bool flag19 = ((UnityEngine.Object)survarotsSelectionPage).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr2 = Component.get_transform_Injected(((UnityEngine.Object)survarotsSelectionPage).m_CachedPtr);
									Transform sender = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
									bool flag20 = (object)tweenToLayoutGroup == null;
									tweenToLayoutGroup.TweenFromLocationToLayoutSpot(sender, (Vector3)(&vector2), 0.24f, num9, isWorldPos);
									RectTransform component5 = ((GameObject)null).GetComponent<RectTransform>();
									bool flag21 = (object)component5 == null;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4234 @ rax_v170 (UnityEngine.RectTransform)+10]");
									bool flag22 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4234 @ rax_v170 (UnityEngine.RectTransform)+10]");
									RectTransform.set_anchoredPosition_Injected((IntPtr)0, ref *(Vector2*)(&value2));
									bool flag23 = ((UnityEngine.Object)survarotsSelectionPage2).m_CachedPtr == (IntPtr)0;
									IntPtr gcHandlePtr3 = GameObject.get_transform_Injected(((UnityEngine.Object)survarotsSelectionPage2).m_CachedPtr);
									Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = ShortcutExtensions.DOMove(target, (Vector3)(&enumerator2), 0.24f);
									object obj14 = _003C_003Ec._003C_003E9__76_4;
									bool flag24 = _003C_003Ec._003C_003E9__76_4 != null;
									bool flag25 = false;
									nint num10 = (nint)(&vector2);
									if (!flag24)
									{
										TweenCallback tweenCallback2 = delegate
										{
										};
										nint num11 = (nint)typeof(_003C_003Ec);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4541 @ rax_v193 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c>)+B8]");
										num10 = 0;
										_003C_003Ec._003C_003E9__76_4 = tweenCallback2;
										obj14 = tweenCallback2;
										flag25 = false;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B5D0");
								}
								object obj15 = 24;
								List<GameObject> spawned2 = survarotsSelectionPage._spawned;
								if (survarotsSelectionPage._spawned == null)
								{
									break;
								}
								bool flag26 = spawned2._size <= 0;
								GameObject[] items = spawned2._items;
								if (spawned2._items == null || (object)items[0] == null)
								{
									break;
								}
								Selectable component6 = items[0].GetComponent<Selectable>();
								if ((object)component6 == null)
								{
									break;
								}
								component6.Select();
								List<GameObject> spawned3 = survarotsSelectionPage._spawned;
								if (survarotsSelectionPage._spawned == null)
								{
									break;
								}
								bool flag27 = spawned3._size <= 0;
								GameObject[] items2 = spawned3._items;
								if (spawned3._items == null || (object)items2[0] == null)
								{
									break;
								}
								ArcanaCardUI component7 = items2[0].GetComponent<ArcanaCardUI>();
								if ((object)component7 == null)
								{
									break;
								}
								DataManager data3 = survarotsSelectionPage._data;
								if (survarotsSelectionPage._data == null || data3._003CAllArcanas_003Ek__BackingField == null)
								{
									break;
								}
								object data4 = ((Dictionary<System.Int32Enum, object>)(object)data3._003CAllArcanas_003Ek__BackingField).get_Item((System.Int32Enum)component7._type);
								List<GameObject> spawned4 = survarotsSelectionPage._spawned;
								if (survarotsSelectionPage._spawned == null)
								{
									break;
								}
								bool flag28 = spawned4._size <= 0;
								GameObject[] items3 = spawned4._items;
								if (spawned4._items == null || (object)items3[0] == null)
								{
									break;
								}
								survarotsSelectionPage.SetInfo(ui: items3[0].GetComponent<ArcanaCardUI>(), data: (ArcanaData)data4, type: component7._type);
								if ((object)survarotsSelectionPage._rerollButton == null)
								{
									break;
								}
								Button component8 = survarotsSelectionPage._rerollButton.GetComponent<Button>();
								if ((object)component8 == null)
								{
									break;
								}
								component8.interactable = false;
								TweenCallback tweenCallback3 = null;
								nint num12 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4380 @ r9_v39 (Il2CppMethodInfo)+8]");
								((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
								((Delegate)tweenCallback3).method = (nint)__ldftn(SurvarotsSelectionPage._003CPerformReRoll_003Eb__76_0);
								((Delegate)tweenCallback3).m_target = survarotsSelectionPage;
								((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4380 @ r9_v39 (Il2CppMethodInfo)+4C]");
								object obj16 = (nint)0 >> 4;
								object obj17 = obj16 & 1;
								nint num13;
								if (obj17 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4380 @ r9_v39 (Il2CppMethodInfo)+52]");
									if ((nint)0 == 0)
									{
										num13 = unchecked((nint)6447293664L);
										goto IL_138a;
									}
								}
								num13 = ((Delegate)tweenCallback3).method_ptr;
								((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
								goto IL_138a;
								IL_138a:
								((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
								object obj18 = num5 + 6;
								object obj19 = obj18 * 50;
								float delay = (float)obj19 * 0.001f;
								Tween tween3 = DOVirtual.DelayedCall(delay, tweenCallback3);
								if (tween3 == null)
								{
									break;
								}
								tween3.stringId = "UI_CUSTOM_TIMER";
								survarotsSelectionPage.SetReRollButton();
								survarotsSelectionPage.UpdateButtonNavigation();
								return;
							}
						}
					}
				}
			}
		}
		goto IL_0ea6;
		IL_0ecb:
		component2.cellSize = (Vector2)enumerator3;
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, num9);
		if (!_hasFreeReroll)
		{
			float value3 = UnityEngine.Random.value;
			VampireSurvivors.Objects.Characters.CharacterController controllingCharacter = _controllingCharacter;
			if ((object)_controllingCharacter != null)
			{
				PlayerModifierStats playerStats = controllingCharacter._playerStats;
				if (controllingCharacter._playerStats != null)
				{
					if (!(value3 < playerStats._003CRecycle_003Ek__BackingField))
					{
						VampireSurvivors.Objects.Characters.CharacterController controllingCharacter2 = _controllingCharacter;
						object playerStats2 = controllingCharacter2._playerStats;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1756 @ rbx_v53 (System.Object)+70]");
						EggFloat eggFloat = (EggFloat)0;
						--eggFloat;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A8E780");
					}
					goto IL_0edd;
				}
			}
			goto IL_0ea6;
		}
		_hasFreeReroll = false;
		goto IL_0edd;
	}

	public void Reroll()
	{
		//IL_00a2: Expected O, but got I
		Button component = _rerollButton.GetComponent<Button>();
		component.interactable = false;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, time);
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			PerformReRoll();
			return;
		}
		object instance = OnlineStageManager._instance;
		Action action = OnlineStageManager._instance.ReRollCharacterCards;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ rbx_v3 (System.Object)+78]");
		bool flag = ((CoherenceSync)0).SendCommand(action, MessageTarget.All);
	}

	protected override void OnHideFinish(GameObject g)
	{
		base.OnHideFinish(g);
		AddressableCache.ReleaseCustomOperationHandleGroup(_arcanaCacheGroupName);
	}

	private unsafe void PopulateMenu()
	{
		//IL_153b: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_00af: Expected O, but got I4
		//IL_02ca: Expected I4, but got I8
		//IL_02ca: Expected O, but got I
		//IL_057a: Expected O, but got Ref
		//IL_1027: Expected O, but got Ref
		//IL_05a0: Expected O, but got Ref
		//IL_05f1: Expected O, but got Ref
		//IL_1063: Expected O, but got Ref
		//IL_0617: Expected O, but got Ref
		//IL_06fb: Expected O, but got Ref
		//IL_0740: Expected O, but got Ref
		//IL_07af: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b4: Expected Ref, but got Unknown
		//IL_07d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07da: Expected Ref, but got Unknown
		//IL_0879: Expected O, but got I
		//IL_0bb4: Expected O, but got I4
		//IL_0c0a: Expected O, but got I4
		//IL_0c40: Expected O, but got Ref
		//IL_12b8: Expected O, but got I4
		//IL_0c6c: Expected O, but got I4
		//IL_110b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1110: Expected O, but got Unknown
		//IL_1118: Expected I4, but got O
		//IL_0aa6: Expected I4, but got O
		//IL_0c8f: Expected O, but got I4
		//IL_12fc: Expected O, but got I4
		//IL_1315: Expected O, but got I
		//IL_0e04: Expected O, but got I4
		//IL_11a9: Expected O, but got Ref
		//IL_0d01: Expected I, but got O
		//IL_0d17: Expected O, but got I
		//IL_0d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d25: Expected O, but got Unknown
		//IL_0d8e: Expected I, but got O
		//IL_0e80: Expected F4, but got O
		//IL_11c0: Expected O, but got I4
		//IL_11d7: Expected I, but got I8
		//IL_11ef: Expected O, but got I
		//IL_0ea0: Expected O, but got I
		//IL_0ea9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eae: Expected O, but got Unknown
		//IL_0d77: Expected I, but got I8
		//IL_1323: Expected O, but got I4
		//IL_0f00: Expected I4, but got I8
		//IL_0f3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f42: Expected O, but got Unknown
		//IL_129e->IL0ffd: Incompatible stack heights: 1 vs 0
		//IL_12e2->IL0ffd: Incompatible stack heights: 2 vs 0
		//IL_0f70->IL0ffd: Incompatible stack heights: 3 vs 0
		//IL_11f5->IL11f5: Incompatible stack heights: 9 vs 0
		//IL_13d4->IL0ffd: Incompatible stack heights: 4 vs 0
		//IL_0f47->IL1354: Incompatible stack heights: 5 vs 3
		//IL_1429->IL0ffd: Incompatible stack heights: 5 vs 0
		//IL_1483->IL0ffd: Incompatible stack heights: 6 vs 0
		//IL_0fb7->IL0ffd: Incompatible stack heights: 7 vs 0
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Detune = -400f;
		float num = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, soundConfig, 0f, 10, num);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Rate = 1f;
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Detune = -800f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig2, 0f, 10, num);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 1.7f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig3, 0f, 10, num);
		_hasFinishedPopulationAnimation = false;
		if ((object)_boosterButton != null)
		{
			Button component = _boosterButton.GetComponent<Button>();
			if ((object)component != null)
			{
				component.interactable = false;
				if ((object)_getButton != null)
				{
					Button component2 = _getButton.GetComponent<Button>();
					if ((object)component2 != null)
					{
						component2.interactable = false;
						_hasPickedRandom = false;
						if ((object)_equipmentPanel != null)
						{
							GameObject gameObject = _equipmentPanel.gameObject;
							if ((object)gameObject != null)
							{
								gameObject.SetActive(value: false);
								if ((object)_characterStatsPanel != null)
								{
									_characterStatsPanel.SetActive(value: true);
									if ((object)_characterStatsPanel != null)
									{
										StatsPanelUI component3 = _characterStatsPanel.GetComponent<StatsPanelUI>();
										if ((object)component3 != null)
										{
											if (!component3._hasLoaded)
											{
												component3.Populate();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rax_v104 (VampireSurvivors.UI.StatsPanelUI)+98]");
											TextAutoSizeHelper.UpdateTextSizes((List<TextMeshProUGUI>)0, -1);
											if ((object)_characterStatsPanel != null)
											{
												StatsPanelUI component4 = _characterStatsPanel.GetComponent<StatsPanelUI>();
												if (_data != null)
												{
													Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
													VampireSurvivors.Objects.Characters.CharacterController controllingCharacter = _controllingCharacter;
													if ((object)_controllingCharacter != null && convertedCharacterData != null)
													{
														object obj = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)controllingCharacter._characterType);
														if (obj != null)
														{
															List<CharacterData> character = ((Dictionary<CharacterType, List<CharacterData>>)obj).get_Item(controllingCharacter._characterType);
															VampireSurvivors.Objects.Characters.CharacterController controllingCharacter2 = _controllingCharacter;
															if ((object)_controllingCharacter != null && (object)component4 != null)
															{
																component4.SetCharacter((CharacterData)(object)character, controllingCharacter2._characterType, _controllingCharacter);
																if ((object)_boosterButton != null)
																{
																	Button component5 = _boosterButton.GetComponent<Button>();
																	if ((object)component5 != null)
																	{
																		component5.enabled = true;
																		if ((object)_getButton != null)
																		{
																			Button component6 = _getButton.GetComponent<Button>();
																			if ((object)component6 != null)
																			{
																				component6.enabled = true;
																				if ((object)_collectRandomButton != null)
																				{
																					Button component7 = _collectRandomButton.GetComponent<Button>();
																					if ((object)component7 != null)
																					{
																						component7.enabled = true;
																						if ((object)_majorBackground != null)
																						{
																							Transform transform = _majorBackground.transform;
																							if ((object)transform != null)
																							{
																								Vector2 vector = default(Vector2);
																								transform.localEulerAngles = (Vector3)(&vector);
																								Vector3 vector2 = default(Vector3);
																								TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(_majorBackground, (Vector3)(&vector2), 0.2f);
																								if ((object)_majorBackground != null)
																								{
																									Transform transform2 = _majorBackground.transform;
																									Vector3 vector3 = default(Vector3);
																									transform2.localScale = (Vector3)(&vector3);
																									Transform target = _majorBackground.transform;
																									TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target, 1f, 0.2f);
																									Transform transform3 = _majorForeground.transform;
																									Vector2 vector4 = default(Vector2);
																									transform3.localEulerAngles = (Vector3)(&vector4);
																									Vector3 vector5 = default(Vector3);
																									TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(_majorForeground, (Vector3)(&vector5), 0.2f);
																									if ((object)_majorForeground != null)
																									{
																										Transform transform4 = _majorForeground.transform;
																										Vector3 vector6 = default(Vector3);
																										transform4.localScale = (Vector3)(&vector6);
																										Transform target2 = _majorForeground.transform;
																										TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOScale(target2, 1f, 0.2f);
																										_majorSelectionGroup.SetActive(value: true);
																										_minorSelectionGroup.SetActive(value: false);
																										GridLayoutGroup component8 = _cardContainer.GetComponent<GridLayoutGroup>();
																										component8.enabled = true;
																										bool active = IsLocalPlayerControllingUi();
																										_getButton.SetActive(active);
																										if ((object)_getButton != null)
																										{
																											Transform transform5 = _getButton.transform;
																											Vector3 vector7 = default(Vector3);
																											transform5.localScale = (Vector3)(&vector7);
																											if ((object)_boosterButton != null)
																											{
																												Transform transform6 = _boosterButton.transform;
																												Vector3 vector8 = default(Vector3);
																												transform6.localScale = (Vector3)(&vector8);
																												if ((object)_boosterButton != null)
																												{
																													bool active2 = IsLocalPlayerControllingUi();
																													_boosterButton.SetActive(active2);
																													_003CWaitAndConfigureRandomButton_003Ed__82 obj2 = null;
																													obj2._003C_003E1__state = 0;
																													obj2._003C_003E4__this = this;
																													Coroutine coroutine = StartCoroutine(obj2);
																													GameManager core = GM.Core;
																													if ((object)GM.Core != null)
																													{
																														List<SkillCardEdition> randomEditions = CharacterSkillCardsManager.GetRandomEditions(core._003CSurvarotsCardsToShow_003Ek__BackingField, ref *(Unity.Mathematics.Random*)(this + 652));
																														List<ArcanaType> weightedSurvarots = CharacterSkillCard_RandomGenerator.GetWeightedSurvarots(core._003CSurvarotsCardsToShow_003Ek__BackingField, ref *(Unity.Mathematics.Random*)(this + 652));
																														bool flag = weightedSurvarots == null;
																														SoundManager.SoundConfig soundConfig4 = null;
																														int num2 = 0;
																														if (!flag)
																														{
																															List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
																															Vector3 vector9 = default(Vector3);
																															bool isWorldPos = default(bool);
																															Vector2 anchoredPosition = default(Vector2);
																															float num4 = default(float);
																															List<GameObject>.Enumerator enumerator2 = default(List<GameObject>.Enumerator);
																															object obj16 = default(object);
																															Vector2 value2 = default(Vector2);
																															while (true)
																															{
																																int num3 = num2;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4252 @ rax_v174 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
																																object value;
																																object obj4;
																																if ((nint)num3 < (nint)0)
																																{
																																	SoundManager.SoundConfig soundConfig5 = soundConfig4;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4252 @ rax_v174 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+18]");
																																	if ((nint)soundConfig5 < 0)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4252 @ rax_v174 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
																																		object obj3 = 0;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4252 @ rax_v174 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
																																		if ((nint)0 == 0)
																																		{
																																			break;
																																		}
																																		SoundManager.SoundConfig soundConfig6 = soundConfig4;
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v266+18]");
																																		if ((nint)soundConfig6 < 0)
																																		{
																																			DataManager data = _data;
																																			if (_data == null || data._003CAllArcanas_003Ek__BackingField == null)
																																			{
																																				break;
																																			}
																																			Dictionary<ArcanaType, ArcanaData> dictionary = data._003CAllArcanas_003Ek__BackingField;
																																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v266+20+v424 @ rbx_v51 (VampireSurvivors.Framework.SoundManager+SoundConfig)*4]");
																																			bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryGetValue((System.Int32Enum)0, out value);
																																			bool flag3 = value == null;
																																			obj4 = value;
																																			if (!flag3)
																																			{
																																				if (_playerOptions == null)
																																				{
																																					break;
																																				}
																																				PlayerOptionsData config = _playerOptions.Config;
																																				if (config == null || config._003CUnlockedArcanas_003Ek__BackingField == null)
																																				{
																																					break;
																																				}
																																				List<ArcanaType> list = config._003CUnlockedArcanas_003Ek__BackingField;
																																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v266+20+v424 @ rbx_v51 (VampireSurvivors.Framework.SoundManager+SoundConfig)*4]");
																																				if (!((Dictionary<ArcanaType, ArcanaData>)(object)list).TryGetValue(ArcanaType.T00_KILLER, out *(ArcanaData*)(&value)))
																																				{
																																					if (value == null)
																																					{
																																						break;
																																					}
																																					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ stack_18_v41 (System.Object)+49]");
																																					bool flag4 = (nint)0 == 0;
																																					obj4 = value;
																																					if (flag4)
																																					{
																																						goto IL_10c7;
																																					}
																																				}
																																				if (value == null)
																																				{
																																					break;
																																				}
																																				_ = 1;
																																				obj4 = value;
																																			}
																																			goto IL_10c7;
																																		}
																																	}
																																	else
																																	{
																																		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
																																	}
																																	throw new IndexOutOfRangeException();
																																}
																																List<object> allSpawnedInOrder = (List<object>)(object)_allSpawnedInOrder;
																																if (_allSpawnedInOrder == null)
																																{
																																	break;
																																}
																																((List<object>)(object)_allSpawnedInOrder).InsertRange(allSpawnedInOrder._size, (IEnumerable<object>)_spawned);
																																if (_spawned == null)
																																{
																																	break;
																																}
																																IEnumerable<object> collection;
																																object obj8;
																																TweenCallback tweenCallback;
																																TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore5;
																																TweenerCore<Vector3, Vector3, VectorOptions> t;
																																for (collection = _spawned; enumerator.MoveNext(); obj8 = 24, ((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L), tweenerCore5 = TweenSettingsExtensions.OnComplete(t, tweenCallback), collection = (IEnumerable<object>)0)
																																{
																																	_003C_003Ec__DisplayClass79_0 obj5 = new _003C_003Ec__DisplayClass79_0();
																																	bool flag5 = obj5 == null;
																																	obj5._003C_003E4__this = this;
																																	((SoundManager.SoundConfig)(object)obj5).Mute = false;
																																	bool flag6 = !((SoundManager.SoundConfig)(object)obj5).Mute;
																																	Transform transform7 = ((GameObject)((SoundManager.SoundConfig)(object)obj5).Mute).transform;
																																	bool flag7 = (object)transform7 == null;
																																	Vector3 position = transform7.position;
																																	bool flag8 = !((SoundManager.SoundConfig)(object)obj5).Mute;
																																	TweenToLayoutGroup tweenToLayoutGroup = ((GameObject)((SoundManager.SoundConfig)(object)obj5).Mute).AddComponent<TweenToLayoutGroup>();
																																	Transform sender = base.transform;
																																	bool flag9 = (object)tweenToLayoutGroup == null;
																																	tweenToLayoutGroup.TweenFromLocationToLayoutSpot(sender, (Vector3)(&vector9), 0.24f, num, isWorldPos);
																																	bool flag10 = !((SoundManager.SoundConfig)(object)obj5).Mute;
																																	RectTransform component9 = ((GameObject)((SoundManager.SoundConfig)(object)obj5).Mute).GetComponent<RectTransform>();
																																	bool flag11 = (object)component9 == null;
																																	component9.anchoredPosition = anchoredPosition;
																																	List<ArcanaType> list2 = (List<ArcanaType>)((SoundManager.SoundConfig)(object)obj5).Mute;
																																	bool flag12 = !((SoundManager.SoundConfig)(object)obj5).Mute;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1228 @ rsi_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
																																	bool flag13 = (nint)0 == 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1228 @ rsi_v54 (System.Collections.Generic.List`1<VampireSurvivors.Data.ArcanaType>)+10]");
																																	IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
																																	Transform target3 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
																																	t = ShortcutExtensions.DOMove(target3, (Vector3)(&num4), 0.24f);
																																	tweenCallback = null;
																																	nint num5 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4310 @ r10_v39 (Il2CppMethodInfo)+8]");
																																	((Delegate)tweenCallback).method_ptr = (IntPtr)0;
																																	((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass79_0._003CPopulateMenu_003Eb__0);
																																	((Delegate)tweenCallback).m_target = obj5;
																																	((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4310 @ r10_v39 (Il2CppMethodInfo)+4C]");
																																	object obj6 = (nint)0 >> 4;
																																	object obj7 = obj6 & 1;
																																	nint num6;
																																	if (obj7 != null)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4310 @ r10_v39 (Il2CppMethodInfo)+52]");
																																		if ((nint)0 == 0)
																																		{
																																			num6 = unchecked((nint)6447293664L);
																																			continue;
																																		}
																																	}
																																	((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
																																	num6 = ((Delegate)tweenCallback).method_ptr;
																																}
																																SoundManager.SoundConfig cardContainer = (SoundManager.SoundConfig)(object)_cardContainer;
																																if ((object)_cardContainer == null)
																																{
																																	break;
																																}
																																bool flag14 = !cardContainer.Mute;
																																RectTransform.get_rect_Injected((IntPtr)(cardContainer.Mute ? 1 : 0), out Rect ret);
																																object padding = ((LayoutGroup)component8).m_Padding;
																																if (((LayoutGroup)component8).m_Padding == null)
																																{
																																	break;
																																}
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rcx_v152 (System.Object)+10]");
																																bool flag15 = (nint)0 == 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rcx_v152 (System.Object)+10]");
																																List<ArcanaType> list3 = (List<ArcanaType>)RectOffset.get_left_Injected((IntPtr)0);
																																object padding2 = ((LayoutGroup)component8).m_Padding;
																																if (((LayoutGroup)component8).m_Padding == null)
																																{
																																	break;
																																}
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rcx_v155 (System.Object)+10]");
																																bool flag16 = (nint)0 == 0;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rcx_v155 (System.Object)+10]");
																																object obj9 = RectOffset.get_right_Injected((IntPtr)0);
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ rcx_v155 (System.Object)+10]");
																																((List<GameObject>)0).InsertRange((int)(&ret), (IEnumerable<GameObject>)collection);
																																object obj10 = 0;
																																while (enumerator2.MoveNext())
																																{
																																	_003C_003Ec__DisplayClass79_1 obj11 = new _003C_003Ec__DisplayClass79_1();
																																	ArcanaCardUI component10 = ((GameObject)null).GetComponent<ArcanaCardUI>();
																																	bool flag17 = obj11 == null;
																																	obj11.card = component10;
																																	TweenCallback tweenCallback2 = null;
																																	nint num7 = 0;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4794 @ r9_v57 (Il2CppMethodInfo)+8]");
																																	((SoundManager.SoundConfig)(object)tweenCallback2).Mute = false;
																																	((SoundManager.SoundConfig)(object)tweenCallback2).Loop = false;
																																	((SoundManager.SoundConfig)(object)tweenCallback2).Detune = (float)obj11;
																																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4794 @ r9_v57 (Il2CppMethodInfo)+4C]");
																																	object obj12 = (nint)0 >> 4;
																																	object obj13 = obj12 & 1;
																																	bool flag18;
																																	if (obj13 != null)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4794 @ r9_v57 (Il2CppMethodInfo)+52]");
																																		if ((nint)0 == 0)
																																		{
																																			flag18 = true;
																																			goto IL_131a;
																																		}
																																	}
																																	_ = ((SoundManager.SoundConfig)(object)tweenCallback2).Detune;
																																	flag18 = ((SoundManager.SoundConfig)(object)tweenCallback2).Mute;
																																	goto IL_131a;
																																	IL_131a:
																																	object obj14 = 24;
																																	_ = 6447293568L;
																																	object obj15 = obj10 % obj16;
																																	float num8 = (float)obj15 * 30f;
																																	float delay = num8 * 0.001f;
																																	Tween tween = DOVirtual.DelayedCall(delay, tweenCallback2);
																																	bool flag19 = tween == null;
																																	tween.stringId = "UI_CUSTOM_TIMER";
																																	obj10++;
																																}
																																TweenCallback onComplete = delegate
																																{
																																	Button component12 = _boosterButton.GetComponent<Button>();
																																	component12.interactable = true;
																																	Button component13 = _getButton.GetComponent<Button>();
																																	component13.interactable = true;
																																	_hasFinishedPopulationAnimation = true;
																																	Transform target4 = _infoGroup.transform;
																																	TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore6 = ShortcutExtensions.DOScale(target4, 1f, 0.2f);
																																	TweenCallback tweenCallback3 = delegate
																																	{
																																		Vector2 pivot = default(Vector2);
																																		VampireSurvivors.App.Tools.Extensions.SetPivot(_infoGroup, pivot);
																																	};
																																	if (tweenerCore6 != null)
																																	{
																																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																																		if ((nint)0 == 0)
																																		{
																																		}
																																	}
																																};
																																Tween tween2 = UITimerHelper.RegisterMillis(500f, onComplete);
																																SoundManager.SoundConfig boosterButton = (SoundManager.SoundConfig)(object)_boosterButton;
																																if ((object)_boosterButton == null)
																																{
																																	break;
																																}
																																bool flag20 = !boosterButton.Mute;
																																IntPtr gcHandlePtr2 = GameObject.get_transform_Injected((IntPtr)(boosterButton.Mute ? 1 : 0));
																																Transform transform8 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
																																if ((object)transform8 == null)
																																{
																																	break;
																																}
																																bool flag21 = !((SoundManager.SoundConfig)(object)transform8).Mute;
																																Transform.SetAsLastSibling_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform8).Mute ? 1 : 0));
																																SoundManager.SoundConfig getButton = (SoundManager.SoundConfig)(object)_getButton;
																																if ((object)_getButton == null)
																																{
																																	break;
																																}
																																bool flag22 = !getButton.Mute;
																																IntPtr gcHandlePtr3 = GameObject.get_transform_Injected((IntPtr)(getButton.Mute ? 1 : 0));
																																Transform transform9 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr3);
																																if ((object)transform9 == null)
																																{
																																	break;
																																}
																																bool flag23 = !((SoundManager.SoundConfig)(object)transform9).Mute;
																																Transform.SetAsLastSibling_Injected((IntPtr)(((SoundManager.SoundConfig)(object)transform9).Mute ? 1 : 0));
																																if ((object)_collectRandomButton == null)
																																{
																																	break;
																																}
																																RectTransform component11 = _collectRandomButton.GetComponent<RectTransform>();
																																bool flag24 = (object)component11 == null;
																																bool flag25 = (byte)(~(((SoundManager.SoundConfig)(object)component11).Mute ? 1u : 0u)) != 0;
																																RectTransform.set_anchoredPosition_Injected((IntPtr)(((SoundManager.SoundConfig)(object)component11).Mute ? 1 : 0), ref value2);
																																AddStrips();
																																UpdateButtonNavigation();
																																_003CWaitAndSelect_003Ed__83 obj17 = null;
																																obj17._003C_003E1__state = 0;
																																obj17._003C_003E4__this = this;
																																Coroutine coroutine2 = StartCoroutine(obj17);
																																return;
																																IL_10c7:
																																if (randomEditions == null)
																																{
																																	break;
																																}
																																SoundManager.SoundConfig soundConfig7 = soundConfig4;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4238 @ rax_v172 (System.Collections.Generic.List`1<VampireSurvivors.Objects.Characters.SkillCardEdition>)+18]");
																																ArcanaData arcanaData;
																																int edition;
																																if ((nint)soundConfig7 < 0)
																																{
																																	bool flag26 = ((Dictionary<ArcanaType, ArcanaData>)(object)randomEditions).TryGetValue((ArcanaType)soundConfig4, out *(ArcanaData*)(&value));
																																	arcanaData = (ArcanaData)value;
																																	edition = (flag26 ? 1 : 0);
																																}
																																else
																																{
																																	arcanaData = (ArcanaData)obj4;
																																	edition = 0;
																																}
																																ArcanaData data2 = arcanaData;
																																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ rcx_v266+20+v424 @ rbx_v51 (VampireSurvivors.Framework.SoundManager+SoundConfig)*4]");
																																ArcanaCardUI arcanaCardUI = SpawnCharacterCard(data2, ArcanaType.T00_KILLER, (SkillCardEdition)edition);
																																soundConfig4 = (SoundManager.SoundConfig)(soundConfig4 + 1);
																																num2 = (int)soundConfig4;
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
		throw new NullReferenceException();
	}

	private void EnableInputFirstMenu()
	{
		TweenCallback onComplete = delegate
		{
			Button component = _boosterButton.GetComponent<Button>();
			component.interactable = true;
			Button component2 = _getButton.GetComponent<Button>();
			component2.interactable = true;
			_hasFinishedPopulationAnimation = true;
			Transform target = _infoGroup.transform;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.2f);
			TweenCallback tweenCallback = delegate
			{
				Vector2 pivot = default(Vector2);
				VampireSurvivors.App.Tools.Extensions.SetPivot(_infoGroup, pivot);
			};
			if (tweenerCore != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
				if ((nint)0 == 0)
				{
				}
			}
		};
		Tween tween = UITimerHelper.RegisterMillis(500f, onComplete);
	}

	private void SetRandomButton()
	{
		_003CWaitAndConfigureRandomButton_003Ed__82 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator WaitAndConfigureRandomButton()
	{
		_003CWaitAndConfigureRandomButton_003Ed__82 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private IEnumerator WaitAndSelect(GameObject forcedSelect = null)
	{
		_003CWaitAndSelect_003Ed__83 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void InitializeNormalArcanaParticles()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0968: Expected O, but got Ref
		//IL_018c: Expected O, but got I
		//IL_0208: Expected O, but got Ref
		//IL_0221: Expected native int or pointer, but got O
		//IL_0240: Expected O, but got I
		//IL_0260: Expected O, but got Ref
		//IL_027a: Expected native int or pointer, but got O
		//IL_0294: Expected O, but got I
		//IL_02c2: Expected O, but got I4
		//IL_02db: Expected O, but got Ref
		//IL_0313: Expected native int or pointer, but got O
		//IL_0a01: Expected O, but got I
		//IL_034b: Expected O, but got Ref
		//IL_0365: Expected native int or pointer, but got O
		//IL_0a3b: Expected O, but got I
		//IL_03bc: Expected O, but got I
		//IL_03dd: Expected O, but got I
		//IL_0531: Expected O, but got Ref
		//IL_054a: Expected native int or pointer, but got O
		//IL_0584: Expected O, but got Ref
		//IL_059e: Expected native int or pointer, but got O
		//IL_05ef: Expected O, but got Ref
		//IL_0627: Expected native int or pointer, but got O
		//IL_065f: Expected O, but got Ref
		//IL_0679: Expected native int or pointer, but got O
		//IL_0ae2: Expected O, but got Ref
		//IL_0994->IL08d1: Incompatible stack heights: 1 vs 0
		//IL_00c0->IL08d1: Incompatible stack heights: 1 vs 0
		//IL_00f0->IL08d1: Incompatible stack heights: 2 vs 0
		//IL_0132->IL08d1: Incompatible stack heights: 2 vs 0
		//IL_01b8->IL08d1: Incompatible stack heights: 2 vs 0
		//IL_0418->IL08d1: Incompatible stack heights: 2 vs 0
		//IL_0467->IL08d1: Incompatible stack heights: 2 vs 0
		//IL_04e9->IL08d1: Incompatible stack heights: 2 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Camera main = Camera.main;
		bool flag = (object)main == null;
		float num = 1f;
		if (!flag)
		{
			bool flag2 = ((UnityEngine.Object)main).m_CachedPtr == (IntPtr)0;
			num = 1f;
			if (!flag2)
			{
				Camera main2 = Camera.main;
				num = 0.666875f;
			}
		}
		if ((object)_bottomParticles != null)
		{
			Transform transform = _bottomParticles.transform;
			if ((object)transform != null)
			{
				_ = 0;
				_ = 0;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 128));
				Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out *(Vector3*)obj3);
				if ((object)_topParticles != null)
				{
					Transform transform2 = _topParticles.transform;
					if ((object)transform2 != null)
					{
						bool flag4 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
						Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
						ParticleSystemConfig particleSystemConfig = new ParticleSystemConfig("randomazzo");
						List<string> list = new List<string>();
						list._002Ector();
						if (list != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v51 (System.Collections.Generic.List`1<System.String>)+1C]");
							_ = (nint)0 + (nint)1;
							IntPtr cachedPtr = ((UnityEngine.Object)(object)list).m_CachedPtr;
							if (((UnityEngine.Object)(object)list).m_CachedPtr != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v51 (System.Collections.Generic.List`1<System.String>)+18]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rcx_v47 (System.IntPtr)+18]");
								if (num2 >= 0)
								{
									((List<object>)(object)list).AddWithResize((object)"sv_back");
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v51 (System.Collections.Generic.List`1<System.String>)+18]");
									object obj4 = (nint)0 + (nint)1;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								}
								if (particleSystemConfig != null)
								{
									particleSystemConfig._frame = list;
									Camera main3 = Camera.main;
									Bounds bounds = CameraExtensions.OrthographicBoundsIgnoringBorders(main3);
									object obj5 = default(object);
									float max = (float)obj5 * 2f;
									ParticleSystem.MinMaxCurve minMaxCurve = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve, new ParticleSystem.MinMaxCurve(0f, max));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
									particleSystemConfig._x = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve2 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 96));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve2, new ParticleSystem.MinMaxCurve(0f, 360f));
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+60]");
									particleSystemConfig._rotate = (ParticleSystem.MinMaxCurve)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+70]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve3 = new ParticleSystem.MinMaxCurve(4000f);
									particleSystemConfig._lifespan = (ParticleSystem.MinMaxCurve)0;
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve4 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
									float max2 = num * 200f;
									float min = num * 100f;
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve4, new ParticleSystem.MinMaxCurve(min, max2));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+80]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+90]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-60]");
									particleSystemConfig._speedY = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-50]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-40]");
									_ = 0;
									ParticleSystem.MinMaxCurve minMaxCurve5 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 160));
									_ = 0;
									_ = 0;
									System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve5, new ParticleSystem.MinMaxCurve(2f, 0f));
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+A0]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+B0]");
									_ = 0;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-38]");
									particleSystemConfig._scale = (ParticleSystem.MinMaxCurve?)(object)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-28]");
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-18]");
									_ = 0;
									_ = 0;
									_ = 1;
									_ = 1;
									_ = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
									particleSystemConfig._quantity = (int?)(object)0;
									_ = 4473924;
									_ = 1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
									particleSystemConfig._tint = (uint?)(object)0;
									ParticleSystemConfig particleSystemConfig2 = new ParticleSystemConfig("randomazzo");
									List<string> list2 = new List<string>();
									if (list2 != null)
									{
										int version = list2._version + 1;
										list2._version = version;
										string[] items = list2._items;
										if (list2._items != null)
										{
											if (list2._size >= items.Length)
											{
												((List<object>)(object)list2).AddWithResize((object)"sv_back");
											}
											else
											{
												int size = list2._size + 1;
												list2._size = size;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											}
											if (particleSystemConfig2 != null)
											{
												Camera main4 = Camera.main;
												Bounds bounds2 = CameraExtensions.OrthographicBoundsIgnoringBorders(main4);
												float max3 = (float)obj5 * 2f;
												ParticleSystem.MinMaxCurve minMaxCurve6 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve6, new ParticleSystem.MinMaxCurve(0f, max3));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+C0]");
												((UnityEngine.Object)(object)particleSystemConfig2).m_CachedPtr = (IntPtr)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+D0]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve7 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 224));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve7, new ParticleSystem.MinMaxCurve(0f, 360f));
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+E0]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+F0]");
												_ = 0;
												minMaxCurve3 = new ParticleSystem.MinMaxCurve(4000f);
												_ = 0;
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve8 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 256));
												float min2 = num * -100f;
												float max4 = num * -200f;
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve8, new ParticleSystem.MinMaxCurve(min2, max4));
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+100]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+110]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1-10]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+10]");
												_ = 0;
												ParticleSystem.MinMaxCurve minMaxCurve9 = (ParticleSystem.MinMaxCurve)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 288));
												_ = 0;
												_ = 0;
												System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)minMaxCurve9, new ParticleSystem.MinMaxCurve(2f, 0f));
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+120]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+130]");
												_ = 0;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+18]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+28]");
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+38]");
												_ = 0;
												_ = 0;
												_ = 1;
												_ = 1;
												_ = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
												_ = 0;
												_ = 4473924;
												_ = 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+1A0]");
												_ = 0;
												bool flag5 = (object)_topParticles == null;
												Transform transform3 = _topParticles.transform;
												Transform parent = default(Transform);
												string psName = default(string);
												bool isAdditive = default(bool);
												bool requiresMasking = default(bool);
												ParticleSystem particleSystem = _topParticles.CreateUIEmitter(particleSystemConfig, "UI", 6, parent, psName, isAdditive, requiresMasking);
												bool flag6 = (object)particleSystem == null;
												particleSystem.Play(withChildren: true);
												bool flag7 = (object)_topParticles == null;
												Transform transform4 = _topParticles.transform;
												bool flag8 = (object)transform4 == null;
												Transform child = transform4.GetChild(0);
												bool flag9 = (object)child == null;
												_ = 0;
												bool flag10 = ((UnityEngine.Object)child).m_CachedPtr == (IntPtr)0;
												object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
												Transform.set_position_Injected(((UnityEngine.Object)child).m_CachedPtr, ref *(Vector3*)obj6);
												bool flag11 = (object)_bottomParticles == null;
												Transform transform5 = _bottomParticles.transform;
												ParticleSystem particleSystem2 = _bottomParticles.CreateUIEmitter(particleSystemConfig2, "UI", 6, parent, psName, isAdditive, requiresMasking);
												bool flag12 = (object)particleSystem2 == null;
												particleSystem2.Play(withChildren: true);
												bool flag13 = (object)_bottomParticles == null;
												Transform transform6 = _bottomParticles.transform;
												bool flag14 = (object)transform6 == null;
												Transform child2 = transform6.GetChild(0);
												bool flag15 = (object)child2 == null;
												bool flag16 = ((UnityEngine.Object)child2).m_CachedPtr == (IntPtr)0;
												Transform.set_position_Injected(((UnityEngine.Object)child2).m_CachedPtr, ref *(Vector3*)(&minMaxCurve3));
												Renderer component = particleSystem2.GetComponent<Renderer>();
												bool flag17 = (object)component == null;
												bool flag18 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
												Renderer.set_sortingOrder_Injected(((UnityEngine.Object)component).m_CachedPtr, 8);
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
		throw new NullReferenceException();
	}

	private unsafe ArcanaCardUI SpawnCharacterCard(ArcanaData data, ArcanaType type, SkillCardEdition edition)
	{
		//IL_005c: Expected O, but got Ref
		//IL_0069: Expected O, but got Ref
		//IL_014a: Expected O, but got I4
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		GameObject gameObject = UnityEngine.Object.Instantiate(_arcanaCardPrefab, _cardContainer);
		if ((object)gameObject != null)
		{
			ArcanaCardUI component = gameObject.GetComponent<ArcanaCardUI>();
			IntPtr intPtr = default(IntPtr);
			string text = System.Number.FormatInt32((int)type, (ReadOnlySpan<char>)(&intPtr), null);
			string text2 = ((Enum)(&intPtr)).ToString();
			string text3 = text + ": " + text2;
			((UnityEngine.Object)gameObject).SetName(text3);
			string text4 = ((UnityEngine.Object)gameObject).GetName();
			string message = "Spawned : " + text4;
			Debug.Log(message);
			if ((object)component != null)
			{
				component.OverrideBackFrameName("sv_back");
				bool isShowing = default(bool);
				component.SetData(data, type, (ISetArcanaInfo)this, isShowing);
				CharacterSkillCard_Base cardForArcanaType = CharacterSkillCardsManager.GetCardForArcanaType(type);
				if (cardForArcanaType != null)
				{
					object obj = edition - 1;
					cardForArcanaType.Edition = edition;
					bool flag = edition == SkillCardEdition.Foil;
					if (!flag)
					{
						object obj2 = obj - 1;
						if (!flag)
						{
							object obj3 = obj2 - 1;
							if (!flag)
							{
								object obj4 = obj3 - 1;
								if (!flag)
								{
									if ((nint)obj4 == 1)
									{
										cardForArcanaType.OnActivate_Gala();
									}
								}
								else
								{
									cardForArcanaType.MultiplyAllStats(-0.5f);
									float num = -0.5f;
								}
							}
							else
							{
								cardForArcanaType.MultiplyAllStats(2f);
								float num = 2f;
							}
						}
					}
					else
					{
						cardForArcanaType.OnActivate_Foil();
					}
					component.SetCharacterCard(cardForArcanaType);
					if (_spawned != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
						Button component2 = gameObject.GetComponent<Button>();
						if ((object)component2 != null)
						{
							component2.enabled = true;
							component2.interactable = true;
							return component;
						}
					}
				}
			}
		}
		return (ArcanaCardUI)(object)new NullReferenceException();
	}

	private unsafe void AddStrips()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0084: Expected O, but got I4
		//IL_0991: Expected O, but got Ref
		//IL_09d4: Expected O, but got Ref
		//IL_09fe: Expected O, but got Ref
		//IL_0a47: Expected O, but got I4
		//IL_018f: Expected O, but got I
		//IL_0241: Expected I, but got O
		//IL_0ae3: Expected O, but got Ref
		//IL_0bb2: Expected I, but got O
		//IL_0bc8: Expected O, but got I
		//IL_0bd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd6: Expected O, but got Unknown
		//IL_0415: Expected I, but got O
		//IL_0bfc: Expected O, but got I4
		//IL_0c13: Expected I, but got I8
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Expected O, but got Unknown
		//IL_04cd: Expected O, but got I4
		//IL_04d6: Expected O, but got I4
		//IL_03fe: Expected I, but got I8
		//IL_0f85: Expected O, but got I
		//IL_0f92: Expected I, but got O
		//IL_04b6: Expected O, but got I
		//IL_031d: Expected O, but got I
		//IL_03bf: Expected O, but got I
		//IL_0c73: Expected O, but got Ref
		//IL_0c95: Expected I, but got O
		//IL_0cec: Expected O, but got Ref
		//IL_101d: Expected O, but got I4
		//IL_05cb: Expected O, but got I
		//IL_067d: Expected I, but got O
		//IL_0e1f: Expected O, but got Ref
		//IL_0eee: Expected I, but got O
		//IL_0f04: Expected O, but got I
		//IL_0f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f12: Expected O, but got Unknown
		//IL_0851: Expected I, but got O
		//IL_0f38: Expected O, but got I4
		//IL_0f4f: Expected I, but got I8
		//IL_08bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c2: Expected O, but got Unknown
		//IL_08cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d0: Expected O, but got Unknown
		//IL_083a: Expected I, but got I8
		//IL_0759: Expected O, but got I
		//IL_07fb: Expected O, but got I
		//IL_0a28->IL093f: Incompatible stack heights: 3 vs 0
		//IL_01af->IL093f: Incompatible stack heights: 4 vs 0
		//IL_020d->IL093f: Incompatible stack heights: 5 vs 0
		//IL_025e->IL093f: Incompatible stack heights: 5 vs 0
		//IL_0faf->IL093f: Incompatible stack heights: 6 vs 0
		//IL_04c3->IL0c30: Incompatible stack heights: 6 vs 0
		//IL_0cb2->IL093f: Incompatible stack heights: 7 vs 0
		//IL_0523->IL093f: Incompatible stack heights: 8 vs 0
		//IL_0557->IL093f: Incompatible stack heights: 8 vs 0
		//IL_058b->IL093f: Incompatible stack heights: 8 vs 0
		//IL_0d20->IL093f: Incompatible stack heights: 8 vs 0
		//IL_05eb->IL093f: Incompatible stack heights: 12 vs 0
		//IL_0649->IL093f: Incompatible stack heights: 13 vs 0
		//IL_069a->IL093f: Incompatible stack heights: 13 vs 0
		//IL_08f2->IL0f6c: Incompatible stack heights: 14 vs 6
		object obj2 = default(object);
		object obj = (object)(&obj2);
		DataManager data = _data;
		if (_data != null && data._003CAllArcanas_003Ek__BackingField != null)
		{
			Dictionary<ArcanaType, ArcanaData>.KeyCollection keys = data._003CAllArcanas_003Ek__BackingField.Keys;
			if (keys == null)
			{
				Exception ex = System.Linq.Error.ArgumentNull("source");
				throw ex;
			}
			List<System.Int32Enum> list = new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)(object)keys);
			object obj3 = 0;
			SurvarotsSelectionPage survarotsSelectionPage = this;
			bool isInteractable = default(bool);
			Vector2 value = default(Vector2);
			object obj11 = default(object);
			Vector2 value2 = default(Vector2);
			object obj22 = default(object);
			while (true)
			{
				_003C_003Ec__DisplayClass86_0 obj4 = new _003C_003Ec__DisplayClass86_0();
				float screenWidth = UIHelper.ScreenWidth;
				float screenHeight = UIHelper.ScreenHeight;
				GameObject g = UnityEngine.Object.Instantiate(survarotsSelectionPage._arcanaCardPrefab, survarotsSelectionPage._stripContainer);
				if (obj4 == null)
				{
					break;
				}
				obj4.g = g;
				if ((object)obj4.g == null)
				{
					break;
				}
				ArcanaCardUI component = obj4.g.GetComponent<ArcanaCardUI>();
				if ((object)obj4.g == null)
				{
					break;
				}
				RectTransform component2 = obj4.g.GetComponent<RectTransform>();
				if ((object)component2 == null)
				{
					break;
				}
				bool flag = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
				object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
				RectTransform.set_anchorMin_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref *(Vector2*)obj5);
				bool flag2 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
				RectTransform.set_anchorMax_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref *(Vector2*)obj6);
				bool flag3 = ((UnityEngine.Object)component2).m_CachedPtr == (IntPtr)0;
				object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
				RectTransform.set_anchoredPosition_Injected(((UnityEngine.Object)component2).m_CachedPtr, ref *(Vector2*)obj7);
				if (list == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v73 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				object obj8 = UnityEngine.Random.RandomRangeInt(0, 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v73 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
				bool flag4 = (nint)obj8 >= 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v73 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v73 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v96+18]");
				bool flag5 = (nint)obj8 >= 0;
				Dictionary<ArcanaType, ArcanaData> dictionary = data._003CAllArcanas_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v96+20+v278 @ rax_v100*4]");
				object data2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).get_Item((System.Int32Enum)0);
				if ((object)component == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ rcx_v96+20+v278 @ rax_v100*4]");
				component.SetData((ArcanaData)data2, ArcanaType.T00_KILLER, isOpen: false, isInteractable);
				nint num = (nint)obj4.g;
				if ((object)obj4.g == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rbx_v34 (Il2CppMethodInfo)+10]");
				bool flag6 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ rbx_v34 (Il2CppMethodInfo)+10]");
				IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
				Transform target = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
				float num2 = (float)obj3 * 0.05f;
				float duration = num2 + 0.5f;
				TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DOLocalRotate(target, (Vector3)(&value), duration, RotateMode.LocalAxisAdd);
				bool flag7 = tweenerCore == null;
				object obj10 = obj11;
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2672 @ rax_v109 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
					bool flag8 = (nint)0 == 0;
					obj10 = obj11;
					if (!flag8)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2672 @ rax_v109 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
						bool flag9 = (nint)0 != 0;
						obj10 = obj11;
						if (!flag9)
						{
							_ = 2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2672 @ rax_v109 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
							bool flag10 = (nint)0 != 0;
							obj10 = obj11;
							if (!flag10)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2672 @ rax_v109 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+A0]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2672 @ rax_v109 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+A0]");
								obj10 = num3 + 0;
							}
						}
					}
				}
				float num4 = (float)obj3 * 0.05f;
				float duration2 = num4 + 0.5f;
				TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore2 = DOTweenModuleUI.DOAnchorPosY(component2, -100f, duration2);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2800 @ rax_v110 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2800 @ rax_v110 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
						if ((nint)0 == 0)
						{
							_ = 2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2800 @ rax_v110 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2800 @ rax_v110 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
								nint num5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2800 @ rax_v110 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
								obj10 = num5 + 0;
							}
						}
					}
				}
				TweenCallback tweenCallback = null;
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ r10_v27 (Il2CppMethodInfo)+8]");
				((Delegate)tweenCallback).method_ptr = (IntPtr)0;
				((Delegate)tweenCallback).method = (nint)__ldftn(_003C_003Ec__DisplayClass86_0._003CAddStrips_003Eb__0);
				((Delegate)tweenCallback).m_target = obj4;
				((Delegate)tweenCallback).method_code = (IntPtr)tweenCallback;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ r10_v27 (Il2CppMethodInfo)+4C]");
				object obj12 = (nint)0 >> 4;
				object obj13 = obj12 & 1;
				nint num7;
				if (obj13 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ r10_v27 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num7 = unchecked((nint)6447293664L);
						goto IL_0bf3;
					}
				}
				((Delegate)tweenCallback).method_code = (IntPtr)((Delegate)tweenCallback).m_target;
				num7 = ((Delegate)tweenCallback).method_ptr;
				goto IL_0bf3;
				IL_0bf3:
				object obj14 = 24;
				((Delegate)tweenCallback).extra_arg = unchecked((nint)6447293568L);
				if (tweenerCore2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2800 @ rax_v110 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
					if ((nint)0 == 0)
					{
					}
				}
				float delay = (float)obj3 * 0.05f;
				component.SpinDelay(delay, 12);
				obj3++;
				if ((nint)obj3 < 6)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
					survarotsSelectionPage = (SurvarotsSelectionPage)0;
					value = (Vector2)obj11;
					continue;
				}
				object obj15 = 0;
				object obj16 = 6;
				while (true)
				{
					_003C_003Ec__DisplayClass86_1 obj17 = new _003C_003Ec__DisplayClass86_1();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
					SurvarotsSelectionPage survarotsSelectionPage2 = (SurvarotsSelectionPage)0;
					nint num8 = (nint)survarotsSelectionPage2._stripContainer;
					if ((object)survarotsSelectionPage2._stripContainer == null)
					{
						break;
					}
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rbx_v38 (Il2CppMethodInfo)+10]");
					bool flag11 = (nint)0 == 0;
					object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rbx_v38 (Il2CppMethodInfo)+10]");
					RectTransform.get_sizeDelta_Injected((IntPtr)0, out *(Vector2*)obj18);
					nint num9 = (nint)survarotsSelectionPage2._stripContainer;
					if ((object)survarotsSelectionPage2._stripContainer == null)
					{
						break;
					}
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rbx_v39 (Il2CppMethodInfo)+10]");
					bool flag12 = (nint)0 == 0;
					object obj19 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 88));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rbx_v39 (Il2CppMethodInfo)+10]");
					RectTransform.get_sizeDelta_Injected((IntPtr)0, out *(Vector2*)obj19);
					GameObject g2 = UnityEngine.Object.Instantiate(survarotsSelectionPage2._arcanaCardPrefab, survarotsSelectionPage2._stripContainer);
					if (obj17 == null)
					{
						break;
					}
					obj17.g = g2;
					if ((object)obj17.g == null)
					{
						break;
					}
					ArcanaCardUI component3 = obj17.g.GetComponent<ArcanaCardUI>();
					if ((object)obj17.g == null)
					{
						break;
					}
					RectTransform component4 = obj17.g.GetComponent<RectTransform>();
					if ((object)component4 == null)
					{
						break;
					}
					bool flag13 = ((UnityEngine.Object)component4).m_CachedPtr == (IntPtr)0;
					RectTransform.set_anchorMin_Injected(((UnityEngine.Object)component4).m_CachedPtr, ref value2);
					bool flag14 = ((UnityEngine.Object)component4).m_CachedPtr == (IntPtr)0;
					RectTransform.set_anchorMax_Injected(((UnityEngine.Object)component4).m_CachedPtr, ref value);
					bool flag15 = ((UnityEngine.Object)component4).m_CachedPtr == (IntPtr)0;
					RectTransform.set_anchoredPosition_Injected(((UnityEngine.Object)component4).m_CachedPtr, ref value2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v73 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					object obj20 = UnityEngine.Random.RandomRangeInt(0, 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v73 (System.Collections.Generic.List`1<System.Int32Enum>)+18]");
					bool flag16 = (nint)obj20 >= 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v73 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
					object obj21 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v647 @ rax_v73 (System.Collections.Generic.List`1<System.Int32Enum>)+10]");
					if ((nint)0 == 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v140+18]");
					bool flag17 = (nint)obj20 >= 0;
					Dictionary<ArcanaType, ArcanaData> dictionary2 = data._003CAllArcanas_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v140+20+v285 @ rax_v153*4]");
					object data3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)0);
					if ((object)component3 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ rcx_v140+20+v285 @ rax_v153*4]");
					component3.SetData((ArcanaData)data3, ArcanaType.T00_KILLER, isOpen: false, isInteractable);
					nint num10 = (nint)obj17.g;
					if ((object)obj17.g == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rbx_v46 (Il2CppMethodInfo)+10]");
					bool flag18 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ rbx_v46 (Il2CppMethodInfo)+10]");
					IntPtr gcHandlePtr2 = GameObject.get_transform_Injected((IntPtr)0);
					Transform target2 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr2);
					float num11 = (float)obj15 * 0.05f;
					float duration3 = num11 + 0.5f;
					TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore3 = ShortcutExtensions.DOLocalRotate(target2, (Vector3)(&obj22), duration3, RotateMode.LocalAxisAdd);
					bool flag19 = tweenerCore3 == null;
					obj10 = obj11;
					if (!flag19)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3487 @ rax_v162 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
						bool flag20 = (nint)0 == 0;
						obj10 = obj11;
						if (!flag20)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3487 @ rax_v162 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
							bool flag21 = (nint)0 != 0;
							obj10 = obj11;
							if (!flag21)
							{
								_ = 2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3487 @ rax_v162 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
								bool flag22 = (nint)0 != 0;
								obj10 = obj11;
								if (!flag22)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3487 @ rax_v162 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+A0]");
									nint num12 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3487 @ rax_v162 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+A0]");
									obj10 = num12 + 0;
								}
							}
						}
					}
					float num13 = (float)obj15 * 0.05f;
					duration2 = num13 + 0.5f;
					TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore4 = DOTweenModuleUI.DOAnchorPosY(component4, -100f, duration2);
					if (tweenerCore4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3549 @ rax_v163 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3549 @ rax_v163 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+100]");
							if ((nint)0 == 0)
							{
								_ = 2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3549 @ rax_v163 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+10]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3549 @ rax_v163 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
									nint num14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3549 @ rax_v163 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+A0]");
									obj10 = num14 + 0;
								}
							}
						}
					}
					TweenCallback tweenCallback2 = null;
					nint num15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1543 @ r10_v29 (Il2CppMethodInfo)+8]");
					((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
					((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass86_1._003CAddStrips_003Eb__1);
					((Delegate)tweenCallback2).m_target = obj17;
					((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1543 @ r10_v29 (Il2CppMethodInfo)+4C]");
					object obj23 = (nint)0 >> 4;
					object obj24 = obj23 & 1;
					nint num16;
					if (obj24 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1543 @ r10_v29 (Il2CppMethodInfo)+52]");
						if ((nint)0 == 0)
						{
							num16 = unchecked((nint)6447293664L);
							goto IL_0f2f;
						}
					}
					((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
					num16 = ((Delegate)tweenCallback2).method_ptr;
					goto IL_0f2f;
					IL_0f2f:
					object obj25 = 24;
					((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
					if (tweenerCore4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3549 @ rax_v163 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector2, UnityEngine.Vector2, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
						if ((nint)0 == 0)
						{
						}
					}
					delay = (float)obj15 * 0.05f;
					component3.SpinDelay(delay, 12);
					obj15++;
					obj16--;
					bool flag23 = (nint)obj16 > 0;
					obj22 = obj11;
					if (!flag23)
					{
						return;
					}
				}
				break;
			}
		}
		throw new NullReferenceException();
	}

	private void ClearSpawned()
	{
		//IL_0087: Expected I4, but got O
		//IL_0087: Expected O, but got I
		//IL_0113: Expected I4, but got O
		//IL_0113: Expected O, but got I
		bool flag = _spawned == null;
		SurvarotsSelectionPage survarotsSelectionPage = this;
		if (!flag)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, 0f);
			}
			survarotsSelectionPage = (SurvarotsSelectionPage)(object)_allSpawnedInOrder;
			if (_allSpawnedInOrder != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v2 (VampireSurvivors.UI.SurvarotsSelectionPage)+1C]");
				_ = (nint)0 + (nint)1;
				((MonoBehaviour)survarotsSelectionPage).m_CancellationTokenSource = null;
				if ((nint)((MonoBehaviour)survarotsSelectionPage).m_CancellationTokenSource > 0)
				{
					Array.Clear((Array)(nint)((UnityEngine.Object)survarotsSelectionPage).m_CachedPtr, 0, (int)((MonoBehaviour)survarotsSelectionPage).m_CancellationTokenSource);
				}
				survarotsSelectionPage = (SurvarotsSelectionPage)(object)_spawned;
				if (_spawned != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rcx_v2 (VampireSurvivors.UI.SurvarotsSelectionPage)+1C]");
					_ = (nint)0 + (nint)1;
					((MonoBehaviour)survarotsSelectionPage).m_CancellationTokenSource = null;
					if ((nint)((MonoBehaviour)survarotsSelectionPage).m_CancellationTokenSource > 0)
					{
						Array.Clear((Array)(nint)((UnityEngine.Object)survarotsSelectionPage).m_CachedPtr, 0, (int)((MonoBehaviour)survarotsSelectionPage).m_CancellationTokenSource);
					}
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SelectArcana()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0084: Expected I, but got O
		//IL_00a0: Expected O, but got I
		//IL_0066: Expected F4, but got I4
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		object obj3 = default(object);
		object signal = (IntPtr)obj3;
		bool flag = default(bool);
		SignalBus.InternalFire((Type)num, signal, (object)null, flag);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, flag ? 1 : 0);
	}

	private void OnSelectedCharacterCardRemotely(OnlineSignals.OnlineSelectedCharacterCard cardInfo)
	{
		CharacterSkillCard_Base cardForArcanaType = CharacterSkillCardsManager.GetCardForArcanaType((ArcanaType)cardInfo.Arcana);
		cardForArcanaType.Edition = (SkillCardEdition)cardInfo.Edition;
		if (cardInfo.SubCardType > -1)
		{
			CharacterSkillCard_Base cardForArcanaType2 = CharacterSkillCardsManager.GetCardForArcanaType((ArcanaType)cardInfo.SubCardType);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1A80");
		}
		_currentSelected = cardForArcanaType;
		SelectArcana();
	}

	private void OnReRolledCharacterCardsRemotely()
	{
		PerformReRoll();
	}

	private void OnBoosterSurvarotsRemotely()
	{
		PerformBooster();
	}

	private void PlayJingle()
	{
		//IL_00fb: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_0099: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = -400f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, soundConfig, 0f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = -800f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig2, 0f, 10, time);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 1.7f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig3, 0f, 10, time);
	}

	private void PlayLightSound()
	{
		//IL_00fb: Expected O, but got I4
		//IL_0041: Expected O, but got I4
		//IL_0099: Expected O, but got I4
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		soundConfig.Detune = -400f;
		soundConfig.Volume = (float?)(object)1;
		float time = default(float);
		PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.LevelUp, soundConfig, 0f, 10, time);
		SoundManager.SoundConfig soundConfig2 = new SoundManager.SoundConfig();
		soundConfig2.Volume = (float?)(object)1;
		soundConfig2.Rate = 1f;
		soundConfig2.Detune = -800f;
		PlaySoundResult playSoundResult2 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig2, 0f, 10, time);
		SoundManager.SoundConfig soundConfig3 = new SoundManager.SoundConfig();
		soundConfig3.Volume = (float?)(object)1;
		soundConfig3.Rate = 1.7f;
		PlaySoundResult playSoundResult3 = SoundManager.PlaySound(SfxType.LevelUp, soundConfig3, 0f, 10, time);
	}

	public unsafe void SetInfo(ArcanaData data, ArcanaType type, ArcanaCardUI ui)
	{
		//IL_02ef: Expected O, but got I4
		//IL_0309: Expected O, but got I4
		//IL_00d3: Expected O, but got Ref
		ArcanaCardUI selected = _selected;
		bool flag = (object)_selected == null;
		bool flag2 = (object)ui == null;
		object obj = flag2 & flag;
		bool flag3 = obj == null;
		object obj2 = !flag3;
		if (obj2 != null)
		{
			return;
		}
		bool flag4;
		if ((object)ui != null)
		{
			if ((object)_selected != null)
			{
				object obj3 = (object)_selected - (object)ui;
				flag4 = obj3 == null;
			}
			else
			{
				flag4 = ((UnityEngine.Object)ui).m_CachedPtr == (IntPtr)0;
			}
		}
		else
		{
			flag4 = ((UnityEngine.Object)selected).m_CachedPtr == (IntPtr)0;
		}
		if (!flag4)
		{
			if (data == null)
			{
				object obj4 = default(object);
				string text = ((Enum)(&obj4)).ToString();
				string message = "Missing data for : " + text;
				Debug.Log(message);
				GameObject gameObject = ui.gameObject;
				string text2 = ((UnityEngine.Object)gameObject).GetName();
				string message2 = "Missing data for : " + text2;
				Debug.Log(message2);
			}
			ArcanaCardUI selected2 = _selected;
			if ((object)_selected != null && ((UnityEngine.Object)selected2).m_CachedPtr != (IntPtr)0)
			{
				ArcanaCardUI selected3 = _selected;
				selected3._Selected.SetActive(value: false);
			}
			_selected = ui;
			ArcanaCardUI selected4 = _selected;
			selected4._Selected.SetActive(value: true);
			_currentSelected = ui._003CCharacterCard_003Ek__BackingField;
			_cardInfoUI.SetData(_currentSelected, data);
			CharacterSkillCard_Base currentSelected = _currentSelected;
			if (currentSelected.Edition != SkillCardEdition.Base)
			{
				GameObject gameObject2 = _survarotInfoEdition.gameObject;
				gameObject2.SetActive(value: true);
				CharacterSkillCard_Base currentSelected2 = _currentSelected;
				_survarotInfoEdition.SetData(currentSelected2.Edition);
			}
			else
			{
				GameObject gameObject3 = _survarotInfoEdition.gameObject;
				gameObject3.SetActive(value: false);
			}
		}
	}

	public void Select()
	{
		//IL_00bc: Expected O, but got I4
		//IL_00ae: Expected O, but got I4
		Debug.Log("Selecting survarrochi card");
		GameManager core = GM.Core;
		if (!core._multiplayer.IsOnlineMultiplayer)
		{
			SelectArcana();
			return;
		}
		CharacterSkillCard_Base currentSelected = _currentSelected;
		List<CharacterSkillCard_Base> subCards = currentSelected.SubCards;
		ArcanaType? subCardType;
		if (subCards._size > 0)
		{
			if (subCards._size <= 0)
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			subCardType = (ArcanaType?)(object)1;
		}
		else
		{
			subCardType = (ArcanaType?)(object)0;
		}
		OnlineStageManager._instance.SendSelectCharacterCard(currentSelected.Type, currentSelected.Edition, subCardType);
	}

	public unsafe void Random()
	{
		//IL_1aa0: Expected I, but got O
		//IL_012a: Expected I, but got O
		//IL_00c5: Expected I, but got O
		//IL_0160: Expected I, but got O
		//IL_0197: Expected I, but got O
		//IL_01cd: Expected I, but got O
		//IL_0204: Expected I, but got O
		//IL_023a: Expected I, but got O
		//IL_0271: Expected I, but got O
		//IL_02aa: Expected I, but got O
		//IL_02e3: Expected I, but got O
		//IL_0319: Expected I, but got O
		//IL_0350: Expected I, but got O
		//IL_0386: Expected I, but got O
		//IL_03bd: Expected I, but got O
		//IL_0411: Expected I, but got O
		//IL_0465: Expected I, but got O
		//IL_049b: Expected I, but got O
		//IL_04d2: Expected I, but got O
		//IL_055c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Expected I, but got Unknown
		//IL_05b4: Expected O, but got Ref
		//IL_06e0: Expected I, but got O
		//IL_06ef: Expected I, but got O
		//IL_05d3: Expected O, but got I
		//IL_0673: Expected O, but got I
		//IL_073e: Expected I, but got O
		//IL_0767: Expected I, but got O
		//IL_0bf1: Expected I, but got O
		//IL_0c3f: Expected I, but got O
		//IL_0c55: Expected O, but got I
		//IL_0c5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c63: Expected O, but got Unknown
		//IL_0ccc: Expected I, but got O
		//IL_07b5: Expected I, but got O
		//IL_1c29: Expected O, but got I4
		//IL_1c40: Expected I, but got I8
		//IL_0cb5: Expected I, but got I8
		//IL_0df7: Expected I, but got O
		//IL_0d7a: Expected F4, but got I
		//IL_0875: Expected O, but got I
		//IL_0883: Expected I, but got O
		//IL_1ea0: Expected I, but got O
		//IL_0fc9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fce: Expected O, but got Unknown
		//IL_0fdc: Expected I, but got O
		//IL_0fe9: Expected I, but got O
		//IL_1b3c: Expected O, but got Ref
		//IL_0925: Expected I, but got O
		//IL_095b: Expected I, but got O
		//IL_09cf: Expected O, but got I
		//IL_09d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dd: Expected O, but got Unknown
		//IL_10a9: Expected O, but got I
		//IL_0a51: Expected O, but got I
		//IL_1b66: Expected O, but got I4
		//IL_0a2f: Expected O, but got I8
		//IL_112b: Expected I, but got O
		//IL_1204: Unknown result type (might be due to invalid IL or missing references)
		//IL_1209: Expected O, but got Unknown
		//IL_128c: Expected I, but got O
		//IL_12e9: Expected O, but got I
		//IL_132a: Expected I4, but got F4
		//IL_138a: Expected I, but got O
		//IL_13a0: Expected O, but got I
		//IL_13a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ae: Expected O, but got Unknown
		//IL_1417: Expected I, but got O
		//IL_1d22: Expected I, but got I8
		//IL_1400: Expected I, but got I8
		//IL_16ca: Expected I, but got O
		//IL_16e0: Expected O, but got I
		//IL_16e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ee: Expected O, but got Unknown
		//IL_1757: Expected I, but got O
		//IL_1daf: Expected I, but got I8
		//IL_1740: Expected I, but got I8
		//IL_18c5: Expected I, but got O
		//IL_18db: Expected O, but got I
		//IL_18e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e9: Expected O, but got Unknown
		//IL_1957: Expected I, but got O
		//IL_1e12: Expected I, but got I8
		//IL_192a: Expected I, but got I8
		//IL_082a->IL1a5e: Incompatible stack heights: 1 vs 0
		//IL_085f->IL1a5e: Incompatible stack heights: 1 vs 0
		//IL_08ad->IL1a5e: Incompatible stack heights: 1 vs 0
		//IL_105e->IL1a5e: Incompatible stack heights: 1 vs 0
		//IL_098a->IL1a5e: Incompatible stack heights: 2 vs 0
		//IL_1093->IL1a5e: Incompatible stack heights: 1 vs 0
		//IL_10f9->IL1a5e: Incompatible stack heights: 1 vs 0
		//IL_0a9e->IL1bc7: Incompatible stack heights: 2 vs 0
		//IL_1148->IL1a5e: Incompatible stack heights: 2 vs 0
		//IL_117d->IL1a5e: Incompatible stack heights: 2 vs 0
		//IL_12a6->IL1a5e: Incompatible stack heights: 3 vs 0
		//IL_12cb->IL1a5e: Incompatible stack heights: 3 vs 0
		//IL_130a->IL1a5e: Incompatible stack heights: 3 vs 0
		//IL_1ee4->IL19d3: Incompatible stack heights: 3 vs 0
		//IL_19f8->IL19d3: Incompatible stack heights: 3 vs 0
		_003C_003Ec__DisplayClass96_0 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass96_0();
		bool flag = CS_0024_003C_003E8__locals11 == null;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass96_0);
		if (!flag)
		{
			CS_0024_003C_003E8__locals11._003C_003E4__this = this;
			if (!_hasFinishedPopulationAnimation || _hasPickedRandom)
			{
				return;
			}
			_hasPickedRandom = true;
			ArcanaCardUI selected = _selected;
			if ((object)_selected != null)
			{
				bool flag2 = (object)selected._Selected == null;
				num = (nint)selected._Selected;
				if (flag2)
				{
					goto IL_1a5e;
				}
				selected._Selected.SetActive(value: false);
			}
			float num2 = default(float);
			PlaySoundResult playSoundResult = SoundManager.PlaySound(SfxType.ClickIn, null, 0f, 10, num2);
			bool flag3 = (object)_boosterButton == null;
			num = (nint)_boosterButton;
			if (!flag3)
			{
				Button component = _boosterButton.GetComponent<Button>();
				bool flag4 = (object)component == null;
				num = (nint)_boosterButton;
				if (!flag4)
				{
					component.enabled = false;
					bool flag5 = (object)_getButton == null;
					num = (nint)_getButton;
					if (!flag5)
					{
						Button component2 = _getButton.GetComponent<Button>();
						bool flag6 = (object)component2 == null;
						num = (nint)_getButton;
						if (!flag6)
						{
							component2.enabled = false;
							bool flag7 = (object)_collectRandomButton == null;
							num = (nint)_collectRandomButton;
							if (!flag7)
							{
								Button component3 = _collectRandomButton.GetComponent<Button>();
								bool flag8 = (object)component3 == null;
								num = (nint)_collectRandomButton;
								if (!flag8)
								{
									component3.enabled = false;
									bool flag9 = (object)_boosterButton == null;
									num = (nint)_boosterButton;
									if (!flag9)
									{
										_boosterButton.SetActive(value: false);
										bool flag10 = (object)_getButton == null;
										num = (nint)_getButton;
										if (!flag10)
										{
											_getButton.SetActive(value: false);
											bool flag11 = (object)_rerollButton == null;
											num = (nint)_rerollButton;
											if (!flag11)
											{
												GameObject gameObject = _rerollButton.gameObject;
												bool flag12 = (object)gameObject == null;
												num = (nint)_rerollButton;
												if (!flag12)
												{
													gameObject.SetActive(value: false);
													bool flag13 = (object)_cardContainer == null;
													num = (nint)_cardContainer;
													if (!flag13)
													{
														GridLayoutGroup component4 = _cardContainer.GetComponent<GridLayoutGroup>();
														bool flag14 = (object)component4 == null;
														num = (nint)_cardContainer;
														if (!flag14)
														{
															component4.enabled = false;
															bool flag15 = (object)_boosterButton == null;
															num = (nint)_boosterButton;
															if (!flag15)
															{
																Transform target = _boosterButton.transform;
																TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 0f, 0.2f);
																bool flag16 = (object)_getButton == null;
																num = (nint)_getButton;
																if (!flag16)
																{
																	Transform target2 = _getButton.transform;
																	TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore2 = ShortcutExtensions.DOScale(target2, 0f, 0.2f);
																	bool flag17 = (object)_collectRandomButton == null;
																	num = (nint)_collectRandomButton;
																	if (!flag17)
																	{
																		GameObject gameObject2 = _collectRandomButton.gameObject;
																		bool flag18 = (object)gameObject2 == null;
																		num = (nint)_collectRandomButton;
																		if (!flag18)
																		{
																			gameObject2.SetActive(value: true);
																			bool flag19 = (object)_collectRandomButton == null;
																			num = (nint)_collectRandomButton;
																			if (!flag19)
																			{
																				Transform target3 = _collectRandomButton.transform;
																				TweenerCore<Vector3, Vector3, VectorOptions> t = ShortcutExtensions.DOScale(target3, 1f, 0.2f);
																				TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore3 = TweenSettingsExtensions.SetDelay(t, 0.2f);
																				TweenCallback tweenCallback = delegate
																				{
																					SurvarotsSelectionPage survarotsSelectionPage = CS_0024_003C_003E8__locals11._003C_003E4__this;
																					Button component9 = survarotsSelectionPage._collectRandomButton.GetComponent<Button>();
																					component9.Select();
																				};
																				((_003C_003Ec__DisplayClass96_0)(object)tweenerCore3)._003CRandom_003Eb__0();
																				CS_0024_003C_003E8__locals11.cards = _spawned;
																				num = (nint)(CS_0024_003C_003E8__locals11 + 24);
																				if (CS_0024_003C_003E8__locals11.cards != null)
																				{
																					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804799C0");
																					List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
																					while (enumerator.MoveNext())
																					{
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1625 @ rax_v59+10]");
																						bool flag20 = (nint)0 == 0;
																						GameObject gameObject3 = (GameObject)(&enumerator);
																						if (!flag20)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1625 @ rax_v59+10]");
																							ArcanaCardUI component5 = ((GameObject)0).GetComponent<ArcanaCardUI>();
																							if ((object)component5 != null)
																							{
																								if (component5._IsOpen)
																								{
																									string text = ((UnityEngine.Object)component5).GetName();
																									string message = text + " -> Closing";
																									Debug.Log(message);
																									Tween tween = component5.Reveal();
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1625 @ rax_v59+10]");
																								Button component6 = ((GameObject)0).GetComponent<Button>();
																								if ((object)component6 != null)
																								{
																									component6.enabled = true;
																									component6.interactable = false;
																									continue;
																								}
																								throw new NullReferenceException();
																							}
																							throw new NullReferenceException();
																						}
																						throw new NullReferenceException();
																					}
																					Sequence s = DOTween.Sequence();
																					CS_0024_003C_003E8__locals11.s = s;
																					nint num3 = unchecked((nint)null);
																					_003C_003Ec__DisplayClass96_0 obj = CS_0024_003C_003E8__locals11;
																					num = unchecked((nint)null);
																					object obj4 = default(object);
																					int num17 = default(int);
																					while (true)
																					{
																						List<GameObject> cards = CS_0024_003C_003E8__locals11.cards;
																						if (CS_0024_003C_003E8__locals11.cards == null)
																						{
																							break;
																						}
																						_003C_003Ec__DisplayClass96_0 obj5;
																						TweenCallback<float> onVirtualUpdate;
																						if (num < cards._size)
																						{
																							_003C_003Ec__DisplayClass96_1 obj2 = new _003C_003Ec__DisplayClass96_1();
																							bool flag21 = obj2 == null;
																							num = (nint)typeof(_003C_003Ec__DisplayClass96_1);
																							if (flag21)
																							{
																								break;
																							}
																							obj2.CS_0024_003C_003E8__locals1 = obj;
																							num = (nint)typeof(_003C_003Ec__DisplayClass96_1);
																							obj2.cardIndex = (int)num3;
																							_003C_003Ec__DisplayClass96_0 obj3 = obj2.CS_0024_003C_003E8__locals1;
																							if (obj2.CS_0024_003C_003E8__locals1 == null)
																							{
																								break;
																							}
																							num = (nint)obj3.cards;
																							if (obj3.cards == null)
																							{
																								break;
																							}
																							nint intPtr = num3;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+18]");
																							bool flag22 = intPtr >= 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+10]");
																							num = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+10]");
																							if ((nint)0 == 0)
																							{
																								break;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+20+v107 @ r14_v14 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)*8]");
																							bool flag23 = (nint)0 == 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+20+v107 @ r14_v14 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)*8]");
																							num = 0;
																							if (flag23)
																							{
																								break;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+20+v107 @ r14_v14 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)*8]");
																							RectTransform component7 = ((GameObject)0).GetComponent<RectTransform>();
																							nint num4 = (nint)_cardOrigin;
																							bool flag24 = (object)_cardOrigin == null;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+20+v107 @ r14_v14 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)*8]");
																							num = 0;
																							if (flag24)
																							{
																								break;
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rbx_v26 (Il2CppMethodInfo)+10]");
																							bool flag25 = (nint)0 == 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ rbx_v26 (Il2CppMethodInfo)+10]");
																							Transform.get_position_Injected((IntPtr)0, out Vector3 _);
																							TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore4 = ShortcutExtensions.DOMove(component7, (Vector3)(&obj4), 0.1f);
																							if (tweenerCore4 != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2279 @ rax_v246 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
																								if ((nint)0 != 0)
																								{
																									_ = 9;
																									_ = 0;
																								}
																							}
																							bool flag26 = TweenSettingsExtensions.ValidateAddToSequence(obj3.s, (Tween)tweenerCore4, false);
																							bool flag27 = !flag26;
																							num = (nint)obj3.s;
																							if (!flag27)
																							{
																								Sequence sequence = Sequence.DoInsert(obj3.s, (Tween)tweenerCore4, 0.04f);
																								num = (nint)obj3.s;
																							}
																							obj5 = obj2.CS_0024_003C_003E8__locals1;
																							if (obj2.CS_0024_003C_003E8__locals1 == null)
																							{
																								break;
																							}
																							onVirtualUpdate = null;
																							nint num5 = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2481 @ r9_v57 (Il2CppMethodInfo)+8]");
																							_ = 0;
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2481 @ r9_v57 (Il2CppMethodInfo)+4C]");
																							object obj6 = (nint)0 >> 4;
																							object obj7 = obj6 & 1;
																							object obj8;
																							if (obj7 != null)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2481 @ r9_v57 (Il2CppMethodInfo)+52]");
																								if ((nint)0 == 1)
																								{
																									obj8 = 6447299152L;
																									goto IL_1b5d;
																								}
																							}
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2479 @ rax_v251 (DG.Tweening.TweenCallback`1<System.Single>)+20]");
																							_ = 0;
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2479 @ rax_v251 (DG.Tweening.TweenCallback`1<System.Single>)+10]");
																							obj8 = 0;
																							goto IL_1b5d;
																						}
																						Sequence s2 = obj.s;
																						object message2;
																						if (obj.s != null)
																						{
																							if (((Tween)s2)._003Cactive_003Ek__BackingField)
																							{
																								if (!((Tween)s2).creationLocked)
																								{
																									s2.lastTweenInsertTime = ((Tween)s2).duration;
																									float duration = ((Tween)s2).duration + 0.32f;
																									((Tween)s2).duration = duration;
																									goto IL_0be4;
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
																						goto IL_0be4;
																						IL_152a:
																						Sequence s3 = obj.s;
																						object message3;
																						if (obj.s != null)
																						{
																							if (((Tween)s3)._003Cactive_003Ek__BackingField)
																							{
																								if (!((Tween)s3).creationLocked)
																								{
																									s3.lastTweenInsertTime = ((Tween)s3).duration;
																									float duration2 = ((Tween)s3).duration + 0.2f;
																									((Tween)s3).duration = duration2;
																									goto IL_166f;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
																								if ((nint)0 == 0)
																								{
																									_ = 1;
																								}
																								message3 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
																							}
																							else
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
																								if ((nint)0 == 0)
																								{
																									_ = 1;
																								}
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
																							message3 = "You can't add elements to a NULL Sequence";
																						}
																						Debugger.LogWarning(message3);
																						goto IL_166f;
																						IL_186a:
																						Sequence s4 = obj.s;
																						TweenCallback tweenCallback2 = null;
																						nint num6 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ r10_v17 (Il2CppMethodInfo)+8]");
																						((Delegate)tweenCallback2).method_ptr = (IntPtr)0;
																						((Delegate)tweenCallback2).method = (nint)__ldftn(_003C_003Ec__DisplayClass96_0._003CRandom_003Eb__4);
																						((Delegate)tweenCallback2).m_target = obj;
																						((Delegate)tweenCallback2).method_code = (IntPtr)tweenCallback2;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ r10_v17 (Il2CppMethodInfo)+4C]");
																						object obj9 = (nint)0 >> 4;
																						object obj10 = obj9 & 1;
																						nint num7;
																						if (obj10 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v817 @ r10_v17 (Il2CppMethodInfo)+52]");
																							bool flag28 = (nint)0 == 0;
																							num7 = unchecked((nint)6447293664L);
																							if (flag28)
																							{
																								goto IL_1dfb;
																							}
																						}
																						num7 = ((Delegate)tweenCallback2).method_ptr;
																						((Delegate)tweenCallback2).method_code = (IntPtr)((Delegate)tweenCallback2).m_target;
																						goto IL_1dfb;
																						IL_1d0b:
																						TweenCallback tweenCallback3;
																						((Delegate)tweenCallback3).extra_arg = unchecked((nint)6447293568L);
																						Sequence s5;
																						object message4;
																						if (obj.s != null)
																						{
																							if (((Tween)s5)._003Cactive_003Ek__BackingField)
																							{
																								if (!((Tween)s5).creationLocked)
																								{
																									Sequence sequence2 = Sequence.DoInsertCallback(obj.s, tweenCallback3, ((Tween)s5).duration);
																									goto IL_152a;
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
																						goto IL_152a;
																						IL_0dea:
																						num = (nint)obj.s;
																						object obj11;
																						if (obj.s != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+E8]");
																							if ((nint)0 != 0)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+100]");
																								if ((nint)0 == 0)
																								{
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+A0]");
																									_ = 0;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+A0]");
																									float num8 = 0f + 0.25f;
																									goto IL_0f2c;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
																								if ((nint)0 == 0)
																								{
																									_ = 1;
																								}
																								obj11 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
																							}
																							else
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
																								if ((nint)0 == 0)
																								{
																									_ = 1;
																								}
																								obj11 = "You can't add elements to an inactive/killed Sequence";
																							}
																						}
																						else
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBB]");
																							if ((nint)0 == 0)
																							{
																								_ = 1;
																							}
																							obj11 = "You can't add elements to a NULL Sequence";
																						}
																						Debugger.LogWarning(obj11);
																						num = (nint)obj11;
																						goto IL_0f2c;
																						IL_1dfb:
																						((Delegate)tweenCallback2).extra_arg = unchecked((nint)6447293568L);
																						Tween t2;
																						object message5;
																						if (obj.s != null)
																						{
																							if (((Tween)s4)._003Cactive_003Ek__BackingField)
																							{
																								if (!((Tween)s4).creationLocked)
																								{
																									Sequence sequence3 = Sequence.DoInsertCallback(obj.s, tweenCallback2, ((Tween)s4).duration);
																									return;
																								}
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBD]");
																								if ((nint)0 == 0)
																								{
																									_ = 1;
																								}
																								t2 = null;
																								message5 = "The Sequence has started and is now locked, you can only elements to a Sequence before it starts";
																							}
																							else
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980DBC]");
																								if ((nint)0 == 0)
																								{
																									_ = 1;
																								}
																								t2 = null;
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
																							t2 = null;
																							message5 = "You can't add elements to a NULL Sequence";
																						}
																						Debugger.LogWarning(message5, t2);
																						return;
																						IL_1b5d:
																						object obj12 = 24;
																						_ = 6449796912L;
																						Tweener t3 = DOVirtual.Float(0.5f, 0f, 0.1f, onVirtualUpdate);
																						if (TweenSettingsExtensions.ValidateAddToSequence(obj5.s, (Tween)t3, false))
																						{
																							Sequence sequence4 = Sequence.DoInsert(obj5.s, (Tween)t3, 0.04f);
																						}
																						num3++;
																						obj = CS_0024_003C_003E8__locals11;
																						num = num3;
																						continue;
																						IL_166f:
																						Sequence s6 = obj.s;
																						TweenCallback tweenCallback4 = null;
																						nint num9 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3169 @ r10_v16 (Il2CppMethodInfo)+8]");
																						((Delegate)tweenCallback4).method_ptr = (IntPtr)0;
																						((Delegate)tweenCallback4).method = (nint)__ldftn(_003C_003Ec__DisplayClass96_0._003CRandom_003Eb__3);
																						((Delegate)tweenCallback4).m_target = obj;
																						((Delegate)tweenCallback4).method_code = (IntPtr)tweenCallback4;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3169 @ r10_v16 (Il2CppMethodInfo)+4C]");
																						object obj13 = (nint)0 >> 4;
																						object obj14 = obj13 & 1;
																						nint num10;
																						if (obj14 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3169 @ r10_v16 (Il2CppMethodInfo)+52]");
																							if ((nint)0 == 0)
																							{
																								num10 = unchecked((nint)6447293664L);
																								goto IL_1d98;
																							}
																						}
																						((Delegate)tweenCallback4).method_code = (IntPtr)((Delegate)tweenCallback4).m_target;
																						num10 = ((Delegate)tweenCallback4).method_ptr;
																						goto IL_1d98;
																						IL_0f2c:
																						List<GameObject> cards2 = obj.cards;
																						if (obj.cards == null)
																						{
																							break;
																						}
																						object obj15 = (object)_random << 13;
																						object obj16 = obj15 ^ (object)_random;
																						object obj17 = obj16 >> 17;
																						object obj18 = obj16 ^ obj17;
																						object obj19 = obj18 << 5;
																						Unity.Mathematics.Random random = (Unity.Mathematics.Random)(obj19 ^ obj18);
																						_random = random;
																						object obj20 = _random * cards2._size;
																						nint num11 = obj20 >> 32;
																						num = (nint)obj.cards;
																						if (obj.cards == null)
																						{
																							break;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+18]");
																						bool flag29 = num11 >= 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+10]");
																						num = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+10]");
																						if ((nint)0 == 0)
																						{
																							break;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+20+v137 @ rbx_v19 (Il2CppMethodInfo)*8]");
																						bool flag30 = (nint)0 == 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+20+v137 @ rbx_v19 (Il2CppMethodInfo)*8]");
																						num = 0;
																						if (flag30)
																						{
																							break;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+20+v137 @ rbx_v19 (Il2CppMethodInfo)*8]");
																						ArcanaCardUI component8 = ((GameObject)0).GetComponent<ArcanaCardUI>();
																						obj.arcanaCardUI = component8;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+20+v137 @ rbx_v19 (Il2CppMethodInfo)*8]");
																						num = 0;
																						List<GameObject> cards3 = obj.cards;
																						if (obj.cards == null)
																						{
																							break;
																						}
																						bool flag31 = num11 >= cards3._size;
																						num = (nint)cards3._items;
																						if (cards3._items == null)
																						{
																							break;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+20+v137 @ rbx_v19 (Il2CppMethodInfo)*8]");
																						nint num12 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+20+v137 @ rbx_v19 (Il2CppMethodInfo)*8]");
																						if ((nint)0 == 0)
																						{
																							break;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rbx_v20 (Il2CppMethodInfo)+10]");
																						bool flag32 = (nint)0 == 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ rbx_v20 (Il2CppMethodInfo)+10]");
																						IntPtr gcHandlePtr = GameObject.get_transform_Injected((IntPtr)0);
																						Transform t4 = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
																						obj.t = t4;
																						object obj21 = (object)_random << 13;
																						object obj22 = obj21 ^ (object)_random;
																						object obj23 = obj22 >> 17;
																						object obj24 = obj22 ^ obj23;
																						object obj25 = obj24 << 5;
																						Unity.Mathematics.Random random2 = (Unity.Mathematics.Random)(obj25 ^ obj24);
																						_random = random2;
																						object obj26 = (object)_random >> 9;
																						object obj27 = obj26 | 0x3F800000;
																						float num13 = (float)obj27 - 1f;
																						float num14 = num13 * 23f;
																						float num15 = num14 + 101f;
																						double num16 = Math.Round(num15);
																						string value = num17.ToString();
																						IntPtr result;
																						bool flag33 = Enum.TryParse<ArcanaType>(value, ignoreCase: false, out *(ArcanaType*)(&result));
																						num = (nint)_data;
																						if (_data == null)
																						{
																							break;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+188]");
																						if ((nint)0 == 0)
																						{
																							break;
																						}
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ rcx_v19 (Il2CppClass<VampireSurvivors.UI.SurvarotsSelectionPage+<>c__DisplayClass96_0>)+188]");
																						bool flag34 = ((Dictionary<System.Int32Enum, object>)0).TryGetValue((System.Int32Enum)(nint)result, out var value2);
																						if ((object)obj.arcanaCardUI == null)
																						{
																							break;
																						}
																						obj.arcanaCardUI.SetData((ArcanaData)value2, (ArcanaType)(nint)result, (ISetArcanaInfo)this, (byte)(int)num2 != 0);
																						s5 = obj.s;
																						tweenCallback3 = null;
																						nint num18 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2805 @ r10_v15 (Il2CppMethodInfo)+8]");
																						((Delegate)tweenCallback3).method_ptr = (IntPtr)0;
																						((Delegate)tweenCallback3).method = (nint)__ldftn(_003C_003Ec__DisplayClass96_0._003CRandom_003Eb__2);
																						((Delegate)tweenCallback3).m_target = obj;
																						((Delegate)tweenCallback3).method_code = (IntPtr)tweenCallback3;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2805 @ r10_v15 (Il2CppMethodInfo)+4C]");
																						object obj28 = (nint)0 >> 4;
																						object obj29 = obj28 & 1;
																						nint num19;
																						if (obj29 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2805 @ r10_v15 (Il2CppMethodInfo)+52]");
																							if ((nint)0 == 0)
																							{
																								num19 = unchecked((nint)6447293664L);
																								goto IL_1d0b;
																							}
																						}
																						((Delegate)tweenCallback3).method_code = (IntPtr)((Delegate)tweenCallback3).m_target;
																						num19 = ((Delegate)tweenCallback3).method_ptr;
																						goto IL_1d0b;
																						IL_1d98:
																						((Delegate)tweenCallback4).extra_arg = unchecked((nint)6447293568L);
																						object message6;
																						if (obj.s != null)
																						{
																							if (((Tween)s6)._003Cactive_003Ek__BackingField)
																							{
																								if (!((Tween)s6).creationLocked)
																								{
																									Sequence sequence5 = Sequence.DoInsertCallback(obj.s, tweenCallback4, ((Tween)s6).duration);
																									goto IL_186a;
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
																						goto IL_186a;
																						IL_0be4:
																						nint num20 = (nint)obj.s;
																						TweenCallback tweenCallback5 = null;
																						nint num21 = 0;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r10_v14 (Il2CppMethodInfo)+8]");
																						((Delegate)tweenCallback5).method_ptr = (IntPtr)0;
																						((Delegate)tweenCallback5).method = (nint)__ldftn(_003C_003Ec__DisplayClass96_0._003CRandom_003Eb__1);
																						((Delegate)tweenCallback5).m_target = obj;
																						((Delegate)tweenCallback5).method_code = (IntPtr)tweenCallback5;
																						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r10_v14 (Il2CppMethodInfo)+4C]");
																						object obj30 = (nint)0 >> 4;
																						object obj31 = obj30 & 1;
																						nint num22;
																						if (obj31 != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ r10_v14 (Il2CppMethodInfo)+52]");
																							if ((nint)0 == 0)
																							{
																								num22 = unchecked((nint)6447293664L);
																								goto IL_1c20;
																							}
																						}
																						((Delegate)tweenCallback5).method_code = (IntPtr)((Delegate)tweenCallback5).m_target;
																						num22 = ((Delegate)tweenCallback5).method_ptr;
																						goto IL_1c20;
																						IL_1c20:
																						object obj32 = 24;
																						((Delegate)tweenCallback5).extra_arg = unchecked((nint)6447293568L);
																						object message7;
																						if (obj.s != null)
																						{
																							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rbx_v16 (Il2CppMethodInfo)+E8]");
																							if ((nint)0 != 0)
																							{
																								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rbx_v16 (Il2CppMethodInfo)+100]");
																								if ((nint)0 == 0)
																								{
																									Sequence s7 = obj.s;
																									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rbx_v16 (Il2CppMethodInfo)+A0]");
																									Sequence sequence6 = Sequence.DoInsertCallback(s7, tweenCallback5, 0f);
																									goto IL_0dea;
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
																						goto IL_0dea;
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
		goto IL_1a5e;
		IL_1a5e:
		throw new NullReferenceException();
	}

	private void OpenMenu()
	{
		GameManager core = GM.Core;
		VampireSurvivors.Objects.Characters.CharacterController chestWinner;
		if (core._multiplayer.IsOnlineMultiplayer)
		{
			chestWinner = GM.Core.MyOnlinePlayer;
		}
		else
		{
			GameManager core2 = GM.Core;
			GameSessionData gameSessionData = core2._gameSessionData;
			chestWinner = gameSessionData._activeCharacter;
		}
		core.QueueOpenSurvarots(4, chestWinner);
	}

	public SurvarotsSelectionPage()
	{
		List<SpinningRingOfCards> cardRings = new List<SpinningRingOfCards>();
		_cardRings = cardRings;
		_spawned = new List<GameObject>();
		_allSpawnedInOrder = new List<GameObject>();
		_arcanaCacheGroupName = "ArcanaAudio";
		base._002Ector();
	}

	private void _003CPerformBooster_003Eb__74_0()
	{
		CanvasGroup component = _minorCardContainer.GetComponent<CanvasGroup>();
		component.interactable = true;
		Button component2 = _boosterButton.GetComponent<Button>();
		component2.interactable = true;
	}

	private void _003CPerformReRoll_003Eb__76_0()
	{
		CanvasGroup component = _minorCardContainer.GetComponent<CanvasGroup>();
		component.interactable = true;
		Button component2 = _rerollButton.GetComponent<Button>();
		component2.interactable = true;
	}

	private void _003CEnableInputFirstMenu_003Eb__80_0()
	{
		Button component = _boosterButton.GetComponent<Button>();
		component.interactable = true;
		Button component2 = _getButton.GetComponent<Button>();
		component2.interactable = true;
		_hasFinishedPopulationAnimation = true;
		Transform target = _infoGroup.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 1f, 0.2f);
		TweenCallback tweenCallback = delegate
		{
			Vector2 pivot = default(Vector2);
			VampireSurvivors.App.Tools.Extensions.SetPivot(_infoGroup, pivot);
		};
		if (tweenerCore != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rax_v9 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
		}
	}

	private void _003CEnableInputFirstMenu_003Eb__80_1()
	{
		Vector2 pivot = default(Vector2);
		VampireSurvivors.App.Tools.Extensions.SetPivot(_infoGroup, pivot);
	}
}
