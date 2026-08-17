using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;
using DG.Tweening.Plugins.Options;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UI;
using VampireSurvivors.App.Data.Adventures;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Scripts.Data;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Tools;
using VampireSurvivors.App.UI.Bestiary;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Loading;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;
using VampireSurvivors.Tools;
using Zenject;

namespace VampireSurvivors.UI;

public class BestiaryPage : BaseUIPage
{
	private class EnemyAnimDisplayData(EnemyData data, EnemyType type, string frameName)
	{
		public int IdleFrameCount = data._003CidleFrameCount_003Ek__BackingField;

		public string TextureName = data._003CtextureName_003Ek__BackingField;

		public float? Scale = data._003Cscale_003Ek__BackingField;

		public uint? Tint = data._003Ctint_003Ek__BackingField;

		public float Alpha = data._003Calpha_003Ek__BackingField;

		public EnemyType Type = type;

		public string FrameName = frameName;
	}

	private sealed class _003C_003Ec__DisplayClass77_0
	{
		public string frameName;

		internal unsafe bool _003CBuildEnemyDisplayList_003Eb__0(EnemyAnimDisplayData data)
		{
			//IL_012f: Expected I4, but got O
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected Ref, but got Unknown
			//IL_00e8: Expected I8, but got I4
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected Ref, but got Unknown
			if (data != null)
			{
				string text = data.FrameName;
				if (data.FrameName != null)
				{
					string text2 = frameName;
					if ((object)data.FrameName != frameName)
					{
						if (frameName != null && text._stringLength == text2._stringLength)
						{
							ref byte second = ref *(byte*)(frameName + 20);
							ulong length = (ulong)(text._stringLength + text._stringLength);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(data.FrameName + 20), ref second, length);
						}
						return false;
					}
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003C_003Ec__DisplayClass92_0
	{
		public BestiaryPage _003C_003E4__this;

		public bool isBlue;

		internal unsafe void _003CCreateRedBlue_003Eb__0()
		{
			//IL_0066: Expected O, but got Ref
			BestiaryPage bestiaryPage = _003C_003E4__this;
			if (bestiaryPage._spawnedEnemies == null)
			{
				return;
			}
			List<GameObject> spawnedEnemies = bestiaryPage._spawnedEnemies;
			if (spawnedEnemies._size > 0)
			{
				List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
				if (enumerator.MoveNext())
				{
					List<GameObject>.Enumerator enumerator2 = (List<GameObject>.Enumerator)(&enumerator);
					throw new NullReferenceException();
				}
				bool flag = !isBlue;
				isBlue = flag;
			}
		}
	}

	private sealed class _003CWaitAndGenerateSliderNavigation_003Ed__60(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public BestiaryPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_006a: Expected I4, but got I8
			//IL_007f: Expected O, but got I
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_0106: Expected O, but got I
			//IL_0292: Expected O, but got I
			//IL_02af: Expected O, but got I
			//IL_02c5: Expected O, but got I
			//IL_02e2: Expected O, but got I
			//IL_013b: Expected O, but got I
			//IL_02f7: Expected O, but got I
			//IL_0326: Expected O, but got I
			//IL_0178: Expected O, but got I
			//IL_0344: Expected O, but got I
			//IL_019a: Expected O, but got I
			//IL_0359: Expected O, but got I
			//IL_036f: Expected O, but got I
			//IL_01b9: Expected O, but got I
			//IL_01d7: Expected O, but got I
			//IL_03a6: Expected O, but got I
			//IL_01ec: Expected O, but got I
			//IL_0202: Expected O, but got I
			//IL_03c1: Expected O, but got I
			//IL_03d7: Expected O, but got I
			//IL_03e9: Expected O, but got I4
			//IL_0239: Expected O, but got I
			//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fc: Expected O, but got Unknown
			//IL_0254: Expected O, but got I
			//IL_026a: Expected O, but got I
			//IL_027c: Expected O, but got I4
			BaseUIPage baseUIPage = _003C_003E4__this;
			_ = 0;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			object obj = default(object);
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+160]");
				Selectable selectable = (Selectable)0;
				Navigation navigation = (Navigation)(obj - 48);
				_ = selectable.m_Navigation;
				_ = 4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rcx_v8 (UnityEngine.UI.Selectable)+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ rcx_v8 (UnityEngine.UI.Selectable)+48]");
				_ = 0;
				selectable.navigation = navigation;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+1D0]");
				Selectable component = ((Component)0).GetComponent<Selectable>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+160]");
				GameObject gameObject = ((Component)0).gameObject;
				if (!gameObject.activeInHierarchy)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+1D0]");
					Selectable component2 = ((Component)0).GetComponent<Selectable>();
					Selectable component3 = BackButtonController.Instance.GetComponent<Selectable>();
					baseUIPage.SetNavigationRight(component2, component3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+1A8]");
					object obj2 = 0;
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+1D0]");
					Selectable component4 = ((Component)0).GetComponent<Selectable>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+1D0]");
					Selectable component5 = ((Component)0).GetComponent<Selectable>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+1F0]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v38+18]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v38+18]");
					object obj5 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v38+18]");
					if ((nint)obj5 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v38+10]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rcx_v38+18]");
						object obj7 = -1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ rdx_v33+20+v282 @ rax_v56*8]");
						Selectable component6 = ((GameObject)0).GetComponent<Selectable>();
						object obj8 = 0;
						goto IL_03ee;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+1D0]");
					Selectable component7 = ((Component)0).GetComponent<Selectable>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+160]");
					baseUIPage.SetNavigationRight(component7, (Selectable)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+1D0]");
					Selectable component8 = ((Component)0).GetComponent<Selectable>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+160]");
					baseUIPage.SetNavigationLeft((Selectable)0, component8);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+1A8]");
					object obj2 = 0;
					_ = 0;
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+160]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+1D0]");
					Selectable component9 = ((Component)0).GetComponent<Selectable>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rbx_v1 (VampireSurvivors.UI.BaseUIPage)+1F0]");
					object obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v21+18]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v21+18]");
					object obj10 = -1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v21+18]");
					if ((nint)obj10 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v21+10]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rcx_v21+18]");
						object obj12 = -1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rdx_v19+20+v287 @ rax_v27*8]");
						Selectable component10 = ((GameObject)0).GetComponent<Selectable>();
						object obj8 = 0;
						goto IL_03ee;
					}
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				bool result = default(bool);
				return result;
			}
			goto IL_0425;
			IL_03ee:
			object obj13 = obj - 48;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ rsp-40]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A320");
			goto IL_0425;
			IL_0425:
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

	private TextMeshProUGUI _Title;

	private TextMeshProUGUI _KillCount;

	private TextMeshProUGUI _QuestionMarks;

	private TextMeshProUGUI _Resistances;

	private TextMeshProUGUI _Skills;

	private TextMeshProUGUI _FoundIn;

	private TextMeshProUGUI _HP;

	private TextMeshProUGUI _Power;

	private TextMeshProUGUI _Speed;

	private Image _EnvironmentBackground;

	private Image _EnemyNotFoundImage;

	private GameObject _EnemyIconPrefab;

	private GameObject _EnemyItemPrefab;

	private RectTransform _EnemyListContainer;

	private PositionInsideRectUI _EnemyContainer;

	private RectTransform _InfoContent;

	private FakeSliderHandleController _InfoSlider;

	private ScrollEnhancer _InfoScrollEnhancer;

	private Image _Frame;

	private Mask _InfoMask;

	private GameObject _UndeadStars1Prefab;

	private GameObject _UndeadStars2Prefab;

	private GameObject _UndeadStars3Prefab;

	private bool _Debug;

	private DataManager _data;

	private SignalBus _signalBus;

	private PlayerOptions _playerOptions;

	private BestiaryFactory _bestiaryFactory;

	private AdventureManager _adventureManager;

	private EnemyData _currentData;

	private EnemyItemUI _currentItem;

	private EnemyType _currentType;

	private Dictionary<StageType, List<StageData>> _stages;

	private Dictionary<EnemyType, List<EnemyData>> _enemies;

	private List<GameObject> _spawnedList;

	private List<GameObject> _spawnedEnemies;

	private List<List<Vector2>> _positions1;

	private List<List<Vector2>> _positions2;

	private List<List<Vector2>> _positions3;

	private List<List<Vector2>> _positions4;

	private List<List<Vector2>> _positions5;

	private List<List<Vector2>> _positions6;

	private List<List<Vector2>> _positions7;

	private List<List<Vector2>> _positions8;

	private List<List<Vector2>> _positions9;

	private List<List<Vector2>> _positions10;

	private List<List<Vector2>> _positions11;

	private List<List<Vector2>> _positions12;

	private List<List<Vector2>> _positions13;

	private List<List<Vector2>> _positions14;

	private List<List<Vector2>> _positions15;

	private List<List<Vector2>> _positions16;

	private List<List<List<Vector2>>> _allPositions;

	private const string BestiaryTweenId = "BESTIARY_TWEENS";

	private BgmType _previousBGM;

	private BgmModType _previousBGMMod;

	private Timer _redBlueTimer;

	private void Construct(DataManager data, SignalBus signal, PlayerOptions playerOptions, BestiaryFactory bestiaryFactory, AdventureManager adventureManager)
	{
		_data = data;
		_signalBus = signal;
		_playerOptions = playerOptions;
		BestiaryFactory bestiaryFactory2 = default(BestiaryFactory);
		_bestiaryFactory = bestiaryFactory2;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
	}

	protected override void Awake()
	{
		base.Awake();
		InitPositions();
		base._maxInputActionsPerSecond = 100f;
		base._scrollAccelerationSpeed = 5f;
	}

	public unsafe void SetInfoPanel(EnemyType t, EnemyData dat, EnemyItemUI item)
	{
		//IL_0c87: Expected O, but got I
		//IL_01ff: Expected O, but got I
		//IL_0539: Expected O, but got Ref
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_0346: Expected O, but got I
		//IL_0331: Expected O, but got I
		//IL_031c: Expected O, but got I
		//IL_038d: Expected O, but got I
		//IL_02e4: Expected O, but got I
		//IL_06b0: Expected I4, but got O
		//IL_06b0: Expected O, but got I4
		//IL_06f2: Expected I, but got O
		//IL_06e5->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_0733->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_0761->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_09e0->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_0790->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_0a0c->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_07bf->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_0a36->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_07ef->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_0a70->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_0a9c->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_0ac6->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_0b1f->IL0b47: Incompatible stack heights: 1 vs 0
		//IL_0e3b->IL0b47: Incompatible stack heights: 2 vs 0
		_currentData = dat;
		_currentItem = item;
		_currentType = t;
		int num2;
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				bool flag = config._003CKillCount_003Ek__BackingField == null;
				if (!flag)
				{
					int num = config._003CKillCount_003Ek__BackingField.FindEntry(_currentType);
					Dictionary<EnemyType, int> dictionary = config._003CKillCount_003Ek__BackingField;
					num2 = 0;
					if (flag)
					{
						goto IL_0bce;
					}
					if (_playerOptions != null)
					{
						PlayerOptionsData config2 = _playerOptions.Config;
						if (config2 != null)
						{
							dictionary = config2._003CKillCount_003Ek__BackingField;
							if (config2._003CKillCount_003Ek__BackingField != null)
							{
								int num3 = config2._003CKillCount_003Ek__BackingField.get_Item(_currentType);
								num2 = num3;
								goto IL_0bce;
							}
						}
					}
				}
			}
		}
		goto IL_0b47;
		IL_0d07:
		Canvas.ForceUpdateCanvases();
		LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
		int num4;
		if ((object)_HP != null)
		{
			Transform transform = _HP.transform;
			if ((object)transform != null)
			{
				Transform parent = transform.parent;
				if ((object)parent != null)
				{
					RectTransform component = parent.GetComponent<RectTransform>();
					LayoutRebuilder.ForceRebuildLayoutImmediate(component);
					if ((object)_Resistances != null)
					{
						Transform transform2 = _Resistances.transform;
						if ((object)transform2 != null)
						{
							Transform parent2 = transform2.parent;
							if ((object)parent2 != null)
							{
								RectTransform component2 = parent2.GetComponent<RectTransform>();
								LayoutRebuilder.ForceRebuildLayoutImmediate(component2);
								LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
								Canvas.ForceUpdateCanvases();
								object infoMask = _InfoMask;
								if ((object)_InfoMask != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ rbx_v28 (System.Object)+10]");
									bool flag2 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v716 @ rbx_v28 (System.Object)+10]");
									Behaviour.set_enabled_Injected((IntPtr)0, false);
									object infoMask2 = _InfoMask;
									if ((object)_InfoMask != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ rbx_v29 (System.Object)+10]");
										bool flag3 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v717 @ rbx_v29 (System.Object)+10]");
										Behaviour.set_enabled_Injected((IntPtr)0, true);
										_003CWaitAndGenerateSliderNavigation_003Ed__60 obj = null;
										obj._003C_003E1__state = num4;
										obj._003C_003E4__this = this;
										Coroutine coroutine = StartCoroutine(obj);
										return;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0b47;
		IL_0bce:
		if (dat == null)
		{
			goto IL_0b47;
		}
		bool flag4 = dat._003CbVariants_003Ek__BackingField == null;
		List<EnemyType> list = null;
		List<EnemyType> list2 = default(List<EnemyType>);
		if (!flag4)
		{
			list2 = dat._003CbVariants_003Ek__BackingField;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj5 = default(object);
			Dictionary<EnemyType, int> dictionary;
			while (true)
			{
				object obj8;
				object obj9;
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ stack_-68_v24+1C]");
					if (obj3 != null)
					{
						break;
					}
					object obj4 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ stack_-68_v24+18]");
					if ((nint)obj4 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ stack_-68_v24+10]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ stack_-68_v24+10]");
					if ((nint)0 != 0)
					{
						object obj7 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ rdx_v91+18]");
						if ((nint)obj7 < 0)
						{
							obj8 = obj5 + 1;
							string playerOptions = (string)(object)_playerOptions;
							if (_playerOptions == null)
							{
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rbx_v41 (System.String)+68]");
							if ((nint)0 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rbx_v41 (System.String)+58]");
								if ((nint)0 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rbx_v41 (System.String)+78]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rbx_v41 (System.String)+78]");
										obj9 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1072 @ rax_v193+2CC]");
										if ((nint)0 != 0)
										{
											goto IL_0c2d;
										}
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rbx_v41 (System.String)+50]");
									obj9 = 0;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rbx_v41 (System.String)+58]");
									obj9 = 0;
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v883 @ rbx_v41 (System.String)+68]");
								obj9 = 0;
							}
							goto IL_0c2d;
						}
						throw new IndexOutOfRangeException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_0c2d:
				if (obj9 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1072 @ rax_v193+1C8]");
					bool flag5 = (nint)0 == 0;
					if (!flag5)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1072 @ rax_v193+1C8]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ rdx_v91+20+v763 @ stack_-60_v22*4]");
						int num6 = ((Dictionary<EnemyType, int>)num5).FindEntry(EnemyType.BAT1);
						obj5 = obj8;
						if (!flag5)
						{
							if (_playerOptions == null)
							{
								throw new NullReferenceException();
							}
							PlayerOptionsData config3 = _playerOptions.Config;
							if (config3 == null)
							{
								throw new NullReferenceException();
							}
							if (config3._003CKillCount_003Ek__BackingField == null)
							{
								throw new NullReferenceException();
							}
							Dictionary<EnemyType, int> dictionary2 = config3._003CKillCount_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v787 @ rdx_v91+20+v1232 @ rcx_v143*4]");
							int num7 = dictionary2.get_Item(EnemyType.BAT1);
							num2 += num7;
							obj5 = obj8;
							dictionary = config3._003CKillCount_003Ek__BackingField;
						}
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			bool flag6 = obj2 == null;
			dictionary = (Dictionary<EnemyType, int>)0;
			if (!flag6)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ stack_-68_v24+1C]");
				if (obj3 == null)
				{
					list = dat._003CbVariants_003Ek__BackingField;
					goto IL_0beb;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				dictionary = null;
			}
			throw new NullReferenceException();
		}
		goto IL_0beb;
		IL_0b47:
		throw new NullReferenceException();
		IL_0ca4:
		if ("N0" != null)
		{
		}
		string text = System.Number.FormatInt32(num2, (ReadOnlySpan<char>)(&list2), LocalizationManager.mCurrentCulture);
		string text3;
		string text2 = text3 + " " + text;
		bool num8;
		bool flag8 = default(bool);
		bool flag9 = default(bool);
		GameObject gameObject2 = default(GameObject);
		string text4 = default(string);
		EnemyType enemyType2;
		if ((object)_KillCount != null)
		{
			_KillCount.text = text2;
			if (num2 <= 0)
			{
				if ((object)_FoundIn != null)
				{
					_FoundIn.text = "?";
					if ((object)_Resistances != null)
					{
						_Resistances.text = "?";
						if ((object)_Skills != null)
						{
							_Skills.text = "?";
							if ((object)_EnemyNotFoundImage != null)
							{
								GameObject gameObject = _EnemyNotFoundImage.gameObject;
								if ((object)gameObject != null)
								{
									bool flag7 = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
									num8 = flag7;
									GameObject.SetActive_Injected(((UnityEngine.Object)gameObject).m_CachedPtr, true);
									string killCount = (string)(object)_KillCount;
									string translation = LocalizationManager.GetTranslation("lang/bestiary_defeated", FixForRTL: true, 0, ignoreRTLnumbers: true, flag8, (GameObject)flag9, (string)(object)gameObject2, (byte)(int)text4 != 0);
									string text5 = translation + " 0";
									if ((object)_KillCount != null)
									{
										nint num9 = (nint)killCount;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2609 @ r9_v34 (Il2CppClass<System.String>)+558] (should have been resolved before IL gen)");
										Sprite sprite = SpriteManager.GetSprite("background_forest", "UI_Bestiary");
										if ((object)_EnvironmentBackground != null)
										{
											_EnvironmentBackground.sprite = sprite;
											if ((object)_HP != null)
											{
												_HP.text = "?";
												if ((object)_Power != null)
												{
													_Power.text = "?";
													if ((object)_Speed != null)
													{
														_Speed.text = "?";
														if ((object)_QuestionMarks != null)
														{
															_QuestionMarks.text = "???";
															ClearExistingEnemyAnims();
															num4 = 0;
															goto IL_0d07;
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
				string text6 = dat._003CbDesc_003Ek__BackingField;
				EnemyType enemyType = default(EnemyType);
				if (dat._003CbDesc_003Ek__BackingField == null || text6._stringLength <= 0)
				{
					string localizedBestiaryDescription = dat.GetLocalizedBestiaryDescription(enemyType);
					bool flag10 = localizedBestiaryDescription != null;
					enemyType2 = enemyType;
					if (!flag10)
					{
						if ((object)_QuestionMarks == null)
						{
							goto IL_0b47;
						}
						string text7 = "???";
						string questionMarks = (string)(object)_QuestionMarks;
						enemyType2 = enemyType;
						goto IL_0d70;
					}
				}
				else
				{
					enemyType2 = enemyType;
				}
				string localizedBestiaryDescription2 = dat.GetLocalizedBestiaryDescription(enemyType2);
				if ((object)_QuestionMarks != null)
				{
					string text7 = localizedBestiaryDescription2;
					string questionMarks = (string)(object)_QuestionMarks;
					goto IL_0d70;
				}
			}
		}
		goto IL_0b47;
		IL_0beb:
		TextMeshProUGUI killCount2 = _KillCount;
		bool flag11 = LocalizationManager.TryGetTranslation("lang/bestiary_defeated", out var Translation, FixForRTL: true, 0, flag8, flag9, gameObject2, text4);
		if (Translation != null)
		{
			bool flag12 = Translation._stringLength > 0;
			text3 = Translation;
			if (flag12)
			{
				goto IL_0ca4;
			}
		}
		text3 = "lang/bestiary_defeated";
		goto IL_0ca4;
		IL_0d70:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		if ((object)_QuestionMarks != null)
		{
			RectTransform rectTransform = _QuestionMarks.rectTransform;
			LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
			Canvas.ForceUpdateCanvases();
			SetFoundIn(dat);
			SetResistances(dat, enemyType2);
			SetSkills(dat, enemyType2);
			SetBackground(dat, enemyType2);
			SpawnEnemyAnimations(dat, enemyType2);
			SetStats(_currentData, enemyType2);
			if ((object)_EnemyNotFoundImage != null)
			{
				GameObject gameObject3 = _EnemyNotFoundImage.gameObject;
				if ((object)gameObject3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ rax_v125 (UnityEngine.GameObject)+10]");
					bool flag13 = (nint)0 == 0;
					num8 = flag13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ rax_v125 (UnityEngine.GameObject)+10]");
					GameObject.SetActive_Injected((IntPtr)0, false);
					num4 = 0;
					goto IL_0d07;
				}
			}
		}
		goto IL_0b47;
	}

	private IEnumerator WaitAndGenerateSliderNavigation()
	{
		_003CWaitAndGenerateSliderNavigation_003Ed__60 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected override void OnShowStart(GameObject g)
	{
		//IL_001e: Expected O, but got I4
		//IL_0148: Expected O, but got I4
		//IL_0151: Expected O, but got I4
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		base.OnShowStart(g);
		BestiaryFactory bestiaryFactory = _bestiaryFactory;
		bool flag = SpriteLoader.LoadTexture("UI_Bestiary", bestiaryFactory.CACHE_GROUP_UI, (DlcType?)(object)0);
		PlayerOptionsData config = _playerOptions.Config;
		_previousBGM = config._003CSelectedBGM_003Ek__BackingField;
		PlayerOptionsData config2 = _playerOptions.Config;
		_previousBGMMod = config2._003CSelectedBGMMod_003Ek__BackingField;
		PlayerOptionsData config3 = _playerOptions.Config;
		config3._003CSelectedBGM_003Ek__BackingField = BgmType.BGM_Bestiary;
		PlayerOptionsData config4 = _playerOptions.Config;
		config4._003CSelectedBGMMod_003Ek__BackingField = BgmModType.Normal;
		PlaySoundTrack();
		PlayerOptionsData config5 = _playerOptions.Config;
		config5._003CSelectedBGM_003Ek__BackingField = _previousBGM;
		PlayerOptionsData config6 = _playerOptions.Config;
		config6._003CSelectedBGMMod_003Ek__BackingField = _previousBGMMod;
		Populate();
		Vector2 anchoredPosition = default(Vector2);
		_InfoContent.anchoredPosition = anchoredPosition;
		ScrollEnhancer[] componentsInChildren = GetComponentsInChildren<ScrollEnhancer>();
		DlcType? dlcType = (DlcType?)(object)0;
		DlcType? dlcType2 = (DlcType?)(object)0;
		while ((nint)dlcType < componentsInChildren.Length)
		{
			ScrollEnhancer scrollEnhancer = componentsInChildren[(object)dlcType2];
			dlcType2 = (DlcType?)(object)((_003F?)dlcType2 + 1);
			scrollEnhancer.RequiresMouseOverForScroll = true;
			dlcType = dlcType2;
		}
		NavigationWrap();
		Image frame = _Frame;
		frame.m_PixelsPerUnitMultiplier = 0.6f;
		frame.SetVerticesDirty();
		Canvas.ForceUpdateCanvases();
		_InfoScrollEnhancer.ForceScrollAlignment();
	}

	protected override void OnHideStart(GameObject g)
	{
		PlayerOptionsData config = _playerOptions.Config;
		SoundManager.StopMusic(config._003CSelectedBGM_003Ek__BackingField);
		ResetBackButtonNavigation();
		BestiaryFactory bestiaryFactory = _bestiaryFactory;
		AddressableCache.RemoveTexturesFromCacheAndSpriteManager(bestiaryFactory.CACHE_GROUP_UI);
		BestiaryFactory bestiaryFactory2 = _bestiaryFactory;
		AddressableCache.ReleaseCustomOperationHandleGroup(bestiaryFactory2.CACHE_GROUP_UI);
		BestiaryFactory bestiaryFactory3 = _bestiaryFactory;
		AddressableCache.RemoveTexturesFromCacheAndSpriteManager(bestiaryFactory3.CACHE_GROUP);
		BestiaryFactory bestiaryFactory4 = _bestiaryFactory;
		AddressableCache.ReleaseCustomOperationHandleGroup(bestiaryFactory4.CACHE_GROUP);
	}

	private unsafe void NavigationWrap()
	{
		//IL_0035: Expected O, but got I4
		//IL_007e: Expected O, but got I4
		//IL_0108: Expected O, but got Ref
		//IL_0198: Expected O, but got Ref
		Selectable component = BackButtonController.Instance.GetComponent<Selectable>();
		List<GameObject> spawnedList = _spawnedList;
		object obj = spawnedList._size - 1;
		if ((nint)obj < spawnedList._size)
		{
			GameObject[] items = spawnedList._items;
			object obj2 = spawnedList._size - 1;
			Selectable component2 = items[obj2].GetComponent<Selectable>();
			List<GameObject> spawnedList2 = _spawnedList;
			if (spawnedList2._size > 0)
			{
				GameObject[] items2 = spawnedList2._items;
				Selectable component3 = items2[0].GetComponent<Selectable>();
				object obj3 = default(object);
				component3.navigation = (Navigation)(&obj3);
				List<GameObject> spawnedList3 = _spawnedList;
				if (spawnedList3._size > 1)
				{
					GameObject[] items3 = spawnedList3._items;
					Selectable component4 = items3[1].GetComponent<Selectable>();
					SetNavigationDown(component3, component4);
					SetNavigationUp(component3, component);
					component2.navigation = (Navigation)(&obj3);
					SetNavigationDown(component2, component3);
					SetNavigationUp(component2);
					Selectable right = default(Selectable);
					ForceBackButtonNavigation(component2, component3, null, right);
					return;
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe bool GetMusicData(BgmType bgmType, out MusicData musicData)
	{
		//IL_011b: Expected I4, but got O
		ref MusicData reference = ref *(MusicData*)null;
		DataManager data = _data;
		if (_data != null && data._003CAllMusicData_003Ek__BackingField != null)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllMusicData_003Ek__BackingField).FindEntry((System.Int32Enum)bgmType);
			if (num < 0)
			{
				return false;
			}
			DataManager data2 = _data;
			if (_data != null && data2._003CAllMusicData_003Ek__BackingField != null)
			{
				object obj = ((Dictionary<System.Int32Enum, object>)(object)data2._003CAllMusicData_003Ek__BackingField).get_Item((System.Int32Enum)bgmType);
				reference = ref *(MusicData*)obj;
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void PlaySoundTrack()
	{
		//IL_027a: Expected O, but got I4
		//IL_01c7: Expected O, but got I
		//IL_01dc: Expected F4, but got I
		//IL_01f1: Expected O, but got I
		//IL_020b: Expected F4, but got I
		//IL_0146: Expected O, but got I
		//IL_015b: Expected F4, but got I
		//IL_0170: Expected O, but got I
		SoundManager.SoundConfig soundConfig = new SoundManager.SoundConfig();
		soundConfig.Rate = 1f;
		object obj = null;
		DataManager data = _data;
		int num = ((Dictionary<System.Int32Enum, object>)(object)data._003CAllMusicData_003Ek__BackingField).FindEntry((System.Int32Enum)SoundManager._003CCurrentBgm_003Ek__BackingField);
		if (num >= 0)
		{
			DataManager data2 = _data;
			object obj2 = ((Dictionary<System.Int32Enum, object>)(object)data2._003CAllMusicData_003Ek__BackingField).get_Item((System.Int32Enum)SoundManager._003CCurrentBgm_003Ek__BackingField);
			obj = obj2;
		}
		PlayerOptionsData config = _playerOptions.Config;
		if (config._003CSelectedBGMMod_003Ek__BackingField != BgmModType.Hyper)
		{
			PlayerOptionsData config2 = _playerOptions.Config;
			if (config2._003CSelectedBGMMod_003Ek__BackingField != BgmModType.Forsaken)
			{
				goto IL_026c;
			}
			if (obj == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+58]");
			if ((nint)0 == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+58]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v599 @ rax_v31+10]");
			soundConfig.Rate = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+58]");
			object obj4 = 0;
		}
		else
		{
			if (obj == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+50]");
			if ((nint)0 == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+50]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v26+10]");
			soundConfig.Rate = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ stack_18_v4 (System.Object)+50]");
			object obj4 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v17+14]");
		soundConfig.Detune = 0f;
		goto IL_026c;
		IL_026c:
		soundConfig.Volume = (float?)(object)1;
		soundConfig.Loop = true;
		PlayerOptionsData config3 = _playerOptions.Config;
		SoundManager.PlayMusic(config3._003CSelectedBGM_003Ek__BackingField, soundConfig);
	}

	private unsafe void Populate()
	{
		//IL_0143: Expected O, but got I4
		//IL_0180: Expected O, but got Ref
		//IL_0912: Expected I4, but got O
		//IL_07c5: Expected O, but got Ref
		//IL_0853: Expected O, but got I4
		//IL_07f5: Expected O, but got I4
		//IL_087d: Expected O, but got I4
		//IL_0a31: Expected O, but got Ref
		//IL_09c5: Expected I4, but got O
		//IL_0a68: Expected O, but got Ref
		List<GameObject> spawnedList = _spawnedList;
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		while (enumerator.MoveNext())
		{
			UnityEngine.Object.Destroy(null, 0f);
		}
		List<GameObject> spawnedList2 = _spawnedList;
		int version = spawnedList2._version + 1;
		spawnedList2._version = version;
		spawnedList2._size = 0;
		if (spawnedList2._size > 0)
		{
			Array.Clear(spawnedList2._items, 0, spawnedList2._size);
		}
		DataManager data = _data;
		if (!AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			Dictionary<EnemyType, List<EnemyData>> convertedEnemyData = data.GetConvertedEnemyData();
			_enemies = convertedEnemyData;
		}
		else
		{
			_enemies = data._adventureBestiaryData;
		}
		Dictionary<StageType, List<StageData>> convertedStages = _data.GetConvertedStages();
		_stages = convertedStages;
		EnemyData enemies = (EnemyData)(object)_enemies;
		int num = 0;
		List<EnemyType>.Enumerator enumerator2 = (List<EnemyType>.Enumerator)0;
		int value = 0;
		EnemyType enemyType = EnemyType.BAT1;
		int value2 = 0;
		Dictionary<EnemyType, List<EnemyData>>.Enumerator enumerator3 = default(Dictionary<EnemyType, List<EnemyData>>.Enumerator);
		if (enumerator3.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			EnemyType enemyType2 = EnemyType.BAT1;
			Dictionary<EnemyType, List<EnemyData>>.Enumerator enumerator4 = (Dictionary<EnemyType, List<EnemyData>>.Enumerator)(&enumerator3);
			throw new NullReferenceException();
		}
		List<GameObject> spawnedList3 = _spawnedList;
		if (spawnedList3._size > 0)
		{
			GameObject[] items = spawnedList3._items;
			Selectable component = items[0].GetComponent<Selectable>();
			component.Select();
			List<GameObject> spawnedList4 = _spawnedList;
			int num2 = 0;
			int num3 = 0;
			EnemyType enemyType3 = default(EnemyType);
			GameObject gameObject = default(GameObject);
			GameObject gameObject2 = default(GameObject);
			BestiaryPage bestiaryPage = default(BestiaryPage);
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			while (true)
			{
				if (num3 < spawnedList4._size)
				{
					List<GameObject> spawnedList5 = _spawnedList;
					if (num2 >= spawnedList5._size)
					{
						break;
					}
					GameObject[] items2 = spawnedList5._items;
					Selectable component2 = items2[num2].GetComponent<Selectable>();
					component2.navigation = (Navigation)(&enemyType3);
					bool flag = num2 == 0;
					Selectable selectable = null;
					if (!flag)
					{
						object obj = num2 - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Selectable component3 = gameObject.GetComponent<Selectable>();
						SetNavigationUp(component2, component3);
						enemies = null;
						selectable = component3;
					}
					List<GameObject> spawnedList6 = _spawnedList;
					object obj2 = spawnedList6._size - 1;
					if (num2 != (nint)obj2)
					{
						object obj3 = num2 + 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Selectable component4 = gameObject2.GetComponent<Selectable>();
						SetNavigationDown(component2, component4);
						enemies = null;
					}
					num2++;
					spawnedList4 = _spawnedList;
					num3 = num2;
					continue;
				}
				bool flag2 = LocalizationManager.TryGetTranslation("lang/bestiary_header", out var Translation, FixForRTL: true, 0, (byte)(int)bestiaryPage != 0, applyParameters, localParametersRoot, overrideLanguage);
				string text;
				if (Translation != null)
				{
					bool flag3 = Translation._stringLength > 0;
					text = Translation;
					if (flag3)
					{
						goto IL_0970;
					}
				}
				text = "lang/bestiary_header";
				goto IL_0970;
				IL_0a23:
				string newValue = System.Number.FormatInt32(value2, (ReadOnlySpan<char>)(&spawnedList), null);
				string text2 = text.Replace("%0", newValue);
				string newValue2 = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&spawnedList), null);
				string text3 = text2.Replace("%1", newValue2);
				_Title.text = text3;
				LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
				Canvas.ForceUpdateCanvases();
				return;
				IL_0970:
				if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
				{
					bool flag4 = LocalizationManager.TryGetTranslation("adventureLang/adv_adventureBeastiary_header", out var Translation2, FixForRTL: true, 0, (byte)(int)bestiaryPage != 0, applyParameters, localParametersRoot, overrideLanguage);
					if (Translation2 != null)
					{
						bool flag5 = Translation2._stringLength > 0;
						text = Translation2;
						if (flag5)
						{
							goto IL_0a23;
						}
					}
					text = "adventureLang/adv_adventureBeastiary_header";
				}
				goto IL_0a23;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw null;
	}

	private void SetDescription(EnemyData dat, EnemyType type)
	{
		string text = dat._003CbDesc_003Ek__BackingField;
		string text2;
		TextMeshProUGUI questionMarks;
		if (dat._003CbDesc_003Ek__BackingField == null || text._stringLength <= 0)
		{
			string localizedBestiaryDescription = dat.GetLocalizedBestiaryDescription(type);
			if (localizedBestiaryDescription == null)
			{
				questionMarks = _QuestionMarks;
				text2 = "???";
				goto IL_00f9;
			}
		}
		string localizedBestiaryDescription2 = dat.GetLocalizedBestiaryDescription(type);
		text2 = localizedBestiaryDescription2;
		questionMarks = _QuestionMarks;
		goto IL_00f9;
		IL_00f9:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		RectTransform rectTransform = _QuestionMarks.rectTransform;
		LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
		Canvas.ForceUpdateCanvases();
	}

	private unsafe void SetFoundIn(EnemyData dat)
	{
		//IL_001c: Expected O, but got I4
		//IL_0438: Expected O, but got I
		//IL_007f: Expected O, but got I
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0350: Expected I8, but got I4
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected Ref, but got Unknown
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected Ref, but got Unknown
		string text = "";
		object obj = 0;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj5 = default(object);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		while (true)
		{
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ stack_-40_v13+1C]");
				if (obj3 != null)
				{
					break;
				}
				object obj4 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ stack_-40_v13+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ stack_-40_v13+10]");
				object obj6 = 0;
				object obj7 = obj5 + 1;
				bool flag = _stages == null;
				Dictionary<StageType, List<StageData>> stages = _stages;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdx_v27+20+v202 @ stack_-38_v12*4]");
				int num = ((Dictionary<System.Int32Enum, object>)(object)stages).FindEntry((System.Int32Enum)0);
				obj5 = obj7;
				if (flag)
				{
					continue;
				}
				obj++;
				bool flag2 = (nint)obj > 3;
				obj5 = obj7;
				if (flag2)
				{
					continue;
				}
				Dictionary<StageType, List<StageData>> stages2 = _stages;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdx_v27+20+v939 @ rcx_v30*4]");
				object obj8 = ((Dictionary<System.Int32Enum, object>)(object)stages2).get_Item((System.Int32Enum)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdx_v27+20+v939 @ rcx_v30*4]");
				List<StageData> list = ((Dictionary<StageType, List<StageData>>)obj8).get_Item(StageType.FOREST);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ rdx_v27+20+v939 @ rcx_v30*4]");
				string localizedName = ((StageData)(object)list).GetLocalizedName(StageType.FOREST);
				string translation = LocalizationManager.GetTranslation(localizedName, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
				string text2 = text + translation;
				List<StageType> list2 = dat._003CbPlaces_003Ek__BackingField;
				object obj9 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ rax_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
				bool flag3 = (nint)obj9 >= 0;
				text = text2;
				obj5 = obj7;
				if (!flag3)
				{
					bool flag4 = (nint)obj > 2;
					text = text2;
					obj5 = obj7;
					if (!flag4)
					{
						string text3 = text2 + ", ";
						text = text3;
						obj5 = obj7;
					}
				}
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag5 = obj2 == null;
		BestiaryPage bestiaryPage = (BestiaryPage)0;
		if (!flag5)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ stack_-40_v13+1C]");
			if (obj3 == null)
			{
				if ((nint)obj > 2)
				{
					string translation2 = LocalizationManager.GetTranslation("lang/bestiary_others", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					string text4 = text + ", " + translation2;
					text = text4;
				}
				object obj10 = "";
				if ((object)text == "")
				{
					goto IL_039b;
				}
				if (text != null && "" != null)
				{
					int stringLength = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1009 @ rdx_v17+10]");
					if ((nint)stringLength == 0)
					{
						ulong length = (ulong)(text._stringLength + text._stringLength);
						if (System.SpanHelpers.SequenceEqual(ref *(byte*)(text + 20), ref *(byte*)("" + 20), length))
						{
							goto IL_039b;
						}
					}
				}
				goto IL_03a9;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			bestiaryPage = null;
		}
		throw new NullReferenceException();
		IL_039b:
		text = "-";
		goto IL_03a9;
		IL_03a9:
		_FoundIn.text = text;
		RectTransform rectTransform = _FoundIn.rectTransform;
		LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
	}

	private void SetStats(EnemyData ed, EnemyType type)
	{
		//IL_0078: Expected O, but got I
		//IL_0088: Expected O, but got I
		//IL_00e6: Expected O, but got I
		//IL_0122: Expected O, but got I
		//IL_0132: Expected O, but got I
		//IL_0190: Expected O, but got I
		//IL_01cc: Expected O, but got I
		//IL_01dc: Expected O, but got I
		//IL_023a: Expected O, but got I
		//IL_0261: Expected F4, but got I4
		//IL_07f9: Expected O, but got I
		//IL_02c9: Expected O, but got I
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Expected O, but got Unknown
		//IL_036f: Expected F4, but got I
		//IL_04c8: Invalid comparison between F4 and I4
		//IL_04f6: Expected O, but got I4
		//IL_03bd: Expected F4, but got O
		//IL_05d2: Invalid comparison between F4 and O
		//IL_0406: Expected F4, but got I4
		//IL_0418: Expected F4, but got I4
		//IL_0540: Expected O, but got I4
		//IL_05bb: Expected O, but got I4
		//IL_06b2: Invalid comparison between F4 and O
		List<float> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		List<float> list2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		List<float> list3 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ rcx_v26+18]");
		if (num >= 0)
		{
			list.AddWithResize(ed._003CmaxHp_003Ek__BackingField);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v3 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj3 = (nint)0 + (nint)1;
			_ = ed._003CmaxHp_003Ek__BackingField;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ rcx_v28+18]");
		if (num2 >= 0)
		{
			list2.AddWithResize(ed._003Cpower_003Ek__BackingField);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rax_v5 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = ed._003Cpower_003Ek__BackingField;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
		object obj8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v227 @ rcx_v30+18]");
		if (num3 >= 0)
		{
			list3.AddWithResize(ed._003Cspeed_003Ek__BackingField);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ rax_v7 (System.Collections.Generic.List`1<System.Single>)+18]");
			object obj9 = (nint)0 + (nint)1;
			_ = ed._003Cspeed_003Ek__BackingField;
		}
		float num4 = 0f;
		Dictionary<System.Int32Enum, object> dictionary = null;
		object obj10 = default(object);
		object obj11 = default(object);
		object obj13 = default(object);
		while (true)
		{
			if (obj10 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ stack_-D0_v19+1C]");
				if (obj11 == null)
				{
					object obj12 = obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ stack_-D0_v19+18]");
					if ((nint)obj12 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ stack_-D0_v19+10]");
						object obj14 = 0;
						object obj15 = obj13 + 1;
						bool flag = _enemies == null;
						Dictionary<EnemyType, List<EnemyData>> enemies = _enemies;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rbx_v24+20+v419 @ stack_-C8_v18*4]");
						int num5 = ((Dictionary<System.Int32Enum, object>)(object)enemies).FindEntry((System.Int32Enum)0);
						obj13 = obj15;
						if (!flag)
						{
							Dictionary<EnemyType, List<EnemyData>> enemies2 = _enemies;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rbx_v24+20+v1600 @ rcx_v136*4]");
							object obj16 = ((Dictionary<System.Int32Enum, object>)(object)enemies2).get_Item((System.Int32Enum)0);
							List<EnemyData> list4 = ((Dictionary<EnemyType, List<EnemyData>>)obj16).get_Item(EnemyType.BAT1);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1090 @ rax_v199 (System.Collections.Generic.List`1<VampireSurvivors.Data.Enemies.EnemyData>)+14]");
							list.Add(0f);
							Dictionary<EnemyType, List<EnemyData>> enemies3 = _enemies;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rbx_v24+20+v1600 @ rcx_v136*4]");
							object obj17 = ((Dictionary<System.Int32Enum, object>)(object)enemies3).get_Item((System.Int32Enum)0);
							List<EnemyData> list5 = ((Dictionary<EnemyType, List<EnemyData>>)obj17).get_Item(EnemyType.BAT1);
							list2.Add((float)list5._syncRoot);
							Dictionary<EnemyType, List<EnemyData>> enemies4 = _enemies;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v464 @ rbx_v24+20+v1600 @ rcx_v136*4]");
							object obj18 = ((Dictionary<System.Int32Enum, object>)(object)enemies4).get_Item((System.Int32Enum)0);
							List<EnemyData> list6 = ((Dictionary<EnemyType, List<EnemyData>>)obj18).get_Item(EnemyType.BAT1);
							num4 = list6._size;
							list3.Add(list6._size);
							obj13 = obj15;
						}
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag2 = obj10 == null;
		dictionary = (Dictionary<System.Int32Enum, object>)0;
		float num12;
		float num13;
		object obj19;
		if (!flag2)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ stack_-D0_v19+1C]");
			if (obj11 == null)
			{
				float num6 = Enumerable.Min(list);
				float num7 = num6 * 10f;
				float num8 = Enumerable.Max(list);
				float num9 = num8 * 10f;
				float num10 = Enumerable.Min(list2);
				float num11 = Enumerable.Max(list2);
				num12 = Enumerable.Min(list3);
				num13 = Enumerable.Max(list3);
				TextMeshProUGUI hP = _HP;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000186B8E3E8h\"");
				if (num7 == num9)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B8E30Bh\"");
					if (num7 == 0f)
					{
						hP.text = "?";
						obj19 = 0;
					}
					else
					{
						NumberFormatInfo instance = NumberFormatInfo.GetInstance(LocalizationManager.mCurrentCulture);
						string text = System.Number.FormatSingle(num7, "N0", instance);
						List<EnemyType> list7 = (List<EnemyType>)(object)hP;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1721 @ r9_v39 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+558] (should have been resolved before IL gen)");
						obj19 = 0;
					}
				}
				else
				{
					NumberFormatInfo instance2 = NumberFormatInfo.GetInstance(LocalizationManager.mCurrentCulture);
					string text2 = System.Number.FormatSingle(num7, "N0", instance2);
					NumberFormatInfo instance3 = NumberFormatInfo.GetInstance(LocalizationManager.mCurrentCulture);
					string text3 = System.Number.FormatSingle(num9, "N0", instance3);
					string text4 = text2 + " - " + text3;
					List<EnemyType> list8 = (List<EnemyType>)(object)hP;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1720 @ r9_v37 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+558] (should have been resolved before IL gen)");
					obj19 = 0;
				}
				TextMeshProUGUI power = _Power;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000186B8E687h\"");
				if (num10 == num11)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B8E5C9h\"");
					if ((object)num10 == obj19)
					{
						power.text = "?";
						goto IL_08ce;
					}
					NumberFormatInfo instance4 = NumberFormatInfo.GetInstance(LocalizationManager.mCurrentCulture);
					string text5 = System.Number.FormatSingle(num10, "N0", instance4);
				}
				else
				{
					NumberFormatInfo instance5 = NumberFormatInfo.GetInstance(LocalizationManager.mCurrentCulture);
					string text6 = System.Number.FormatSingle(num10, "N0", instance5);
					NumberFormatInfo instance6 = NumberFormatInfo.GetInstance(LocalizationManager.mCurrentCulture);
					string text7 = System.Number.FormatSingle(num11, "N0", instance6);
					string text5 = text6 + " - " + text7;
					num10 = num11;
				}
				List<EnemyType> list9 = (List<EnemyType>)(object)power;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1935 @ r9_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+558] (should have been resolved before IL gen)");
				goto IL_08ce;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			dictionary = null;
		}
		throw new NullReferenceException();
		IL_08ce:
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000186B8E95Bh\"");
		string text8;
		if (num12 == num13)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186B8E89Dh\"");
			if ((object)num12 == obj19)
			{
				_Speed.text = "?";
				return;
			}
			NumberFormatInfo instance7 = NumberFormatInfo.GetInstance(LocalizationManager.mCurrentCulture);
			text8 = System.Number.FormatSingle(num12, "N0", instance7);
		}
		else
		{
			NumberFormatInfo instance8 = NumberFormatInfo.GetInstance(LocalizationManager.mCurrentCulture);
			string text9 = System.Number.FormatSingle(num12, "N0", instance8);
			NumberFormatInfo instance9 = NumberFormatInfo.GetInstance(LocalizationManager.mCurrentCulture);
			string text10 = System.Number.FormatSingle(num13, "N0", instance9);
			text8 = text9 + " - " + text10;
		}
		_Speed.text = text8;
	}

	private unsafe void SetResistances(EnemyData dat, EnemyType type)
	{
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected I, but got Unknown
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0322: Expected Ref, but got Unknown
		//IL_0339: Expected I8, but got I4
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected Ref, but got Unknown
		bool flag = (object)dat._003Cres_Freeze_003Ek__BackingField == null;
		string text = "";
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		if (!flag)
		{
			string translation = LocalizationManager.GetTranslation("lang/res_Freeze", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			string text2 = "" + translation;
			string text3 = text2 + ", ";
			text = text3;
		}
		if ((object)dat._003Cres_Rosary_003Ek__BackingField != null)
		{
			string translation2 = LocalizationManager.GetTranslation("lang/res_Rosary", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			string text4 = text + translation2;
			string text5 = text4 + ", ";
			text = text5;
		}
		if ((object)dat._003Cres_Debuffs_003Ek__BackingField != null)
		{
			string translation3 = LocalizationManager.GetTranslation("lang/res_Debuffs", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			string text6 = text + translation3;
			string text7 = text6 + ", ";
			text = text7;
		}
		if ((object)dat._003Cres_Knockback_003Ek__BackingField != null)
		{
			string translation4 = LocalizationManager.GetTranslation("lang/res_Knockback", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			string text8 = text + translation4;
			string text9 = text8 + ", ";
			text = text9;
		}
		char[] array = new char[2] { ',', ' ' };
		string text10;
		if (array.Length != 0)
		{
			char* trimChars = (char*)(nint)(array + 32);
			text10 = text.TrimHelper(trimChars, array.Length, string.TrimType.Tail);
		}
		else
		{
			text10 = text.TrimWhiteSpaceHelper(string.TrimType.Tail);
		}
		object obj = "";
		if ((object)text10 == "")
		{
			goto IL_037e;
		}
		bool flag2 = text10 == null;
		string text11 = text10;
		if (!flag2)
		{
			bool flag3 = "" == null;
			text11 = text10;
			if (!flag3)
			{
				int stringLength = text10._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ rdx_v9+10]");
				bool flag4 = (nint)stringLength != 0;
				text11 = text10;
				if (!flag4)
				{
					ref byte first = ref *(byte*)(text10 + 20);
					ulong length = (ulong)(text10._stringLength + text10._stringLength);
					bool flag5 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), length);
					bool flag6 = !flag5;
					text11 = text10;
					if (!flag6)
					{
						goto IL_037e;
					}
				}
			}
		}
		goto IL_038c;
		IL_038c:
		_Resistances.text = text11;
		RectTransform rectTransform = _Resistances.rectTransform;
		LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
		return;
		IL_037e:
		text11 = "-";
		goto IL_038c;
	}

	private unsafe void SetSkills(EnemyData dat, EnemyType type)
	{
		//IL_0022: Expected O, but got I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_009a: Expected O, but got Ref
		//IL_00ae: Expected O, but got I
		//IL_00be: Expected O, but got I
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected I, but got Unknown
		//IL_0361: Expected I8, but got I4
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected Ref, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected Ref, but got Unknown
		string text = "";
		object obj = 0;
		object obj2 = default(object);
		BestiaryPage bestiaryPage = default(BestiaryPage);
		object obj4 = default(object);
		IntPtr intPtr = default(IntPtr);
		bool ignoreRTLnumbers = default(bool);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		while (true)
		{
			object obj5;
			string text5;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ stack_-60_v11+1C]");
				if ((object)bestiaryPage != null)
				{
					break;
				}
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ stack_-60_v11+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				obj5 = obj4 + 1;
				obj++;
				string text2 = ((Enum)(&intPtr)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rax_v49+B8]");
				object newValue = 0;
				string text3 = text2.Replace("_", (string)newValue);
				string text4 = "lang/" + text3;
				bool flag = LocalizationManager.TryGetTranslation(text4, out var Translation, FixForRTL: true, 0, ignoreRTLnumbers, applyParameters, localParametersRoot, overrideLanguage);
				if (Translation != null)
				{
					bool flag2 = Translation._stringLength > 0;
					text5 = Translation;
					if (flag2)
					{
						goto IL_0429;
					}
				}
				text5 = text4;
				goto IL_0429;
			}
			throw new NullReferenceException();
			IL_0429:
			string text6 = text + text5;
			List<StageType> list = dat._003CbPlaces_003Ek__BackingField;
			object obj7 = obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rax_v57 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
			bool flag3 = (nint)obj7 > 0;
			text = text6;
			obj4 = obj5;
			if (!flag3)
			{
				string text7 = text6 + ", ";
				text = text7;
				obj4 = obj5;
			}
		}
		string text9;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ stack_-60_v11+1C]");
			if ((object)bestiaryPage == null)
			{
				char[] array = new char[2] { ',', ' ' };
				string text8;
				if (array.Length != 0)
				{
					char* trimChars = (char*)(nint)(array + 32);
					text8 = text.TrimHelper(trimChars, array.Length, string.TrimType.Tail);
				}
				else
				{
					text8 = text.TrimWhiteSpaceHelper(string.TrimType.Tail);
				}
				object obj8 = "";
				if ((object)text8 == "")
				{
					goto IL_03b4;
				}
				bool flag4 = text8 == null;
				text9 = text8;
				if (!flag4)
				{
					bool flag5 = "" == null;
					text9 = text8;
					if (!flag5)
					{
						int stringLength = text8._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1060 @ rdx_v16+10]");
						bool flag6 = (nint)stringLength != 0;
						text9 = text8;
						if (!flag6)
						{
							ulong length = (ulong)(text8._stringLength + text8._stringLength);
							bool flag7 = System.SpanHelpers.SequenceEqual(ref *(byte*)(text8 + 20), ref *(byte*)("" + 20), length);
							bool flag8 = !flag7;
							text9 = text8;
							if (!flag8)
							{
								goto IL_03b4;
							}
						}
					}
				}
				goto IL_03c2;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			BestiaryPage bestiaryPage2 = null;
		}
		throw new NullReferenceException();
		IL_03b4:
		text9 = "-";
		goto IL_03c2;
		IL_03c2:
		_Skills.text = text9;
		RectTransform rectTransform = _Skills.rectTransform;
		LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
	}

	private void SetBackground(EnemyData dat, EnemyType type)
	{
		//IL_03a5: Expected O, but got I
		//IL_00d8: Expected O, but got I
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_03cd: Expected O, but got I4
		//IL_0234: Expected O, but got I
		//IL_028d: Expected O, but got I
		//IL_02a2: Expected O, but got I
		//IL_02ec: Expected O, but got I
		//IL_02c7->IL030d: Incompatible stack heights: 2 vs 0
		//IL_030d->IL03f0: Incompatible stack heights: 2 vs 0
		Sprite sprite2;
		Image environmentBackground;
		if (dat._003CbPlaces_003Ek__BackingField != null)
		{
			List<StageType> list = dat._003CbPlaces_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ rax_v33 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
			if ((nint)0 > (nint)0)
			{
				List<StageType> list2 = new List<StageType>();
				Dictionary<System.Int32Enum, object> dictionary = null;
				object obj = default(object);
				StageType stageType = default(StageType);
				object obj3 = default(object);
				while (true)
				{
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ stack_-38_v15+1C]");
						if ((nint)stageType == (nint)0)
						{
							object obj2 = obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ stack_-38_v15+18]");
							if ((nint)obj2 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ stack_-38_v15+10]");
								object obj4 = 0;
								object obj5 = obj3 + 1;
								bool flag = _stages == null;
								Dictionary<StageType, List<StageData>> stages = _stages;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rdx_v31+20+v319 @ stack_-30_v14*4]");
								int num = ((Dictionary<System.Int32Enum, object>)(object)stages).FindEntry((System.Int32Enum)0);
								obj3 = obj5;
								if (!flag)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ rdx_v31+20+v982 @ rcx_v42*4]");
									int num2 = ((Dictionary<StageType, List<StageData>>)(object)list2).FindEntry(StageType.FOREST);
									obj3 = obj5;
								}
								continue;
							}
							break;
						}
						break;
					}
					throw new NullReferenceException();
				}
				bool flag2 = obj == null;
				dictionary = (Dictionary<System.Int32Enum, object>)0;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ stack_-38_v15+1C]");
					if ((nint)stageType == (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
							object obj6 = default(object);
							if (obj6 == null)
							{
								return;
							}
							AdventureManager adventureManager = _adventureManager;
							AdventureData adventureData = adventureManager._003CAdventureData_003Ek__BackingField;
							CoreAdventureData coreAdventureData = adventureData._003CCoreAdventureData_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A97AB0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
						object obj7 = UnityEngine.Random.RandomRangeInt(0, 0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+18]");
						bool flag3 = (nint)obj7 >= 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v367 @ rax_v34 (System.Collections.Generic.List`1<VampireSurvivors.Data.StageType>)+10]");
						object obj8 = 0;
						Dictionary<StageType, List<StageData>> stages2 = _stages;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rdx_v24+20+v117 @ rax_v49*4]");
						object obj9 = ((Dictionary<System.Int32Enum, object>)(object)stages2).get_Item((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v51 (System.Object)+18]");
						bool flag4 = (nint)0 <= (nint)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v51 (System.Object)+10]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ rax_v52+20]");
						object obj11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v33+48]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ rcx_v33+48]");
							Sprite sprite = SpriteManager.GetSprite((string)0, "UI_Bestiary");
							sprite2 = sprite;
							environmentBackground = _EnvironmentBackground;
							goto IL_03f0;
						}
						return;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					dictionary = null;
				}
				throw new NullReferenceException();
			}
		}
		Sprite sprite3 = SpriteManager.GetSprite("background_forest", "UI_Bestiary");
		sprite2 = sprite3;
		environmentBackground = _EnvironmentBackground;
		goto IL_03f0;
		IL_03f0:
		environmentBackground.sprite = sprite2;
	}

	private static List<Sprite> GetAnimationForEnemy(EnemyData d, int index)
	{
		List<List<string>> internal_IdleAnimFrameNames = d.Internal_IdleAnimFrameNames;
		if (index < internal_IdleAnimFrameNames._size)
		{
			List<string>[] items = internal_IdleAnimFrameNames._items;
			List<Sprite> animationFramesFast = SpriteManager.GetAnimationFramesFast(items[index], d._003CtextureName_003Ek__BackingField);
			if (animationFramesFast != null)
			{
				return (List<Sprite>)(object)new List<object>(animationFramesFast);
			}
			return animationFramesFast;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		List<Sprite> result = default(List<Sprite>);
		return result;
	}

	private void InitPositions()
	{
		//IL_020c: Expected O, but got I
		//IL_0254: Expected O, but got I
		//IL_029c: Expected O, but got I
		//IL_02e4: Expected O, but got I
		//IL_033e: Expected O, but got I
		//IL_0398: Expected O, but got I
		//IL_03f2: Expected O, but got I
		//IL_0459: Expected O, but got I
		//IL_04c0: Expected O, but got I
		//IL_0539: Expected O, but got I
		//IL_05b2: Expected O, but got I
		//IL_0638: Expected O, but got I
		//IL_06be: Expected O, but got I
		//IL_0756: Expected O, but got I
		//IL_07ee: Expected O, but got I
		//IL_0893: Expected O, but got I
		List<List<Vector2>> positions = new List<List<Vector2>>();
		_positions1 = positions;
		List<List<Vector2>> positions2 = new List<List<Vector2>>();
		_positions2 = positions2;
		List<List<Vector2>> positions3 = new List<List<Vector2>>();
		_positions3 = positions3;
		List<List<Vector2>> positions4 = new List<List<Vector2>>();
		_positions4 = positions4;
		List<List<Vector2>> positions5 = new List<List<Vector2>>();
		_positions5 = positions5;
		List<List<Vector2>> positions6 = new List<List<Vector2>>();
		_positions6 = positions6;
		List<List<Vector2>> positions7 = new List<List<Vector2>>();
		_positions7 = positions7;
		List<List<Vector2>> positions8 = new List<List<Vector2>>();
		_positions8 = positions8;
		List<List<Vector2>> positions9 = new List<List<Vector2>>();
		_positions9 = positions9;
		List<List<Vector2>> positions10 = new List<List<Vector2>>();
		_positions10 = positions10;
		List<List<Vector2>> positions11 = new List<List<Vector2>>();
		_positions11 = positions11;
		List<List<Vector2>> positions12 = new List<List<Vector2>>();
		_positions12 = positions12;
		List<List<Vector2>> positions13 = new List<List<Vector2>>();
		_positions13 = positions13;
		List<List<Vector2>> positions14 = new List<List<Vector2>>();
		_positions14 = positions14;
		List<List<Vector2>> positions15 = new List<List<Vector2>>();
		_positions15 = positions15;
		List<List<Vector2>> positions16 = new List<List<Vector2>>();
		_positions16 = positions16;
		List<Vector2> list = new List<Vector2>();
		Vector2 item = default(Vector2);
		list.Add(item);
		((List<Vector2>)(object)_positions1).Add((Vector2)list);
		List<Vector2> list2 = null;
		list2.Add((Vector2)0);
		list2.Add(item);
		list2.Add(item);
		((List<Vector2>)(object)_positions2).Add((Vector2)list2);
		List<Vector2> list3 = null;
		list3.Add((Vector2)0);
		list3.Add(item);
		list3.Add(item);
		((List<Vector2>)(object)_positions2).Add((Vector2)list3);
		List<Vector2> list4 = null;
		list4.Add((Vector2)0);
		list4.Add(item);
		list4.Add(item);
		((List<Vector2>)(object)_positions2).Add((Vector2)list4);
		List<Vector2> list5 = null;
		list5.Add((Vector2)0);
		list5.Add(item);
		list5.Add(item);
		list5.Add(item);
		((List<Vector2>)(object)_positions3).Add((Vector2)list5);
		List<Vector2> list6 = null;
		list6.Add((Vector2)0);
		list6.Add(item);
		list6.Add(item);
		list6.Add(item);
		((List<Vector2>)(object)_positions3).Add((Vector2)list6);
		List<Vector2> list7 = null;
		list7.Add((Vector2)0);
		list7.Add(item);
		list7.Add(item);
		list7.Add(item);
		((List<Vector2>)(object)_positions3).Add((Vector2)list7);
		List<Vector2> list8 = null;
		list8.Add((Vector2)0);
		list8.Add(item);
		list8.Add(item);
		list8.Add(item);
		list8.Add(item);
		((List<Vector2>)(object)_positions4).Add((Vector2)list8);
		List<Vector2> list9 = null;
		list9.Add((Vector2)0);
		list9.Add(item);
		list9.Add(item);
		list9.Add(item);
		list9.Add(item);
		((List<Vector2>)(object)_positions4).Add((Vector2)list9);
		List<Vector2> list10 = null;
		list10.Add((Vector2)0);
		list10.Add(item);
		list10.Add(item);
		list10.Add(item);
		list10.Add(item);
		list10.Add(item);
		((List<Vector2>)(object)_positions5).Add((Vector2)list10);
		List<Vector2> list11 = null;
		list11.Add((Vector2)0);
		list11.Add(item);
		list11.Add(item);
		list11.Add(item);
		list11.Add(item);
		list11.Add(item);
		((List<Vector2>)(object)_positions5).Add((Vector2)list11);
		List<Vector2> list12 = null;
		list12.Add((Vector2)0);
		list12.Add(item);
		list12.Add(item);
		list12.Add(item);
		list12.Add(item);
		list12.Add(item);
		list12.Add(item);
		((List<Vector2>)(object)_positions6).Add((Vector2)list12);
		List<Vector2> list13 = null;
		list13.Add((Vector2)0);
		list13.Add(item);
		list13.Add(item);
		list13.Add(item);
		list13.Add(item);
		list13.Add(item);
		list13.Add(item);
		((List<Vector2>)(object)_positions6).Add((Vector2)list13);
		List<Vector2> list14 = null;
		list14.Add((Vector2)0);
		list14.Add(item);
		list14.Add(item);
		list14.Add(item);
		list14.Add(item);
		list14.Add(item);
		list14.Add(item);
		list14.Add(item);
		((List<Vector2>)(object)_positions7).Add((Vector2)list14);
		List<Vector2> list15 = null;
		list15.Add((Vector2)0);
		list15.Add(item);
		list15.Add(item);
		list15.Add(item);
		list15.Add(item);
		list15.Add(item);
		list15.Add(item);
		list15.Add(item);
		((List<Vector2>)(object)_positions7).Add((Vector2)list15);
		List<Vector2> list16 = null;
		list16.Add((Vector2)0);
		list16.Add(item);
		list16.Add(item);
		list16.Add(item);
		list16.Add(item);
		list16.Add(item);
		list16.Add(item);
		list16.Add(item);
		list16.Add(item);
		((List<Vector2>)(object)_positions8).Add((Vector2)list16);
		List<Vector2> list17 = null;
		list17.Add((Vector2)0);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		list17.Add(item);
		((List<Vector2>)(object)_positions16).Add((Vector2)list17);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions1);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions2);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions3);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions4);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions5);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions6);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions7);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions8);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions9);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions10);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions11);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions12);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions13);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions14);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions15);
		((List<Vector2>)(object)_allPositions).Add((Vector2)_positions16);
	}

	private void ClearExistingEnemyAnims()
	{
		//IL_0024: Expected I, but got O
		//IL_0080: Expected F4, but got I4
		//IL_0089: Expected O, but got I4
		//IL_0060: Expected F4, but got I4
		//IL_0069: Expected O, but got I4
		//IL_0222: Expected I, but got O
		//IL_0113: Expected O, but got I
		//IL_016e: Expected I, but got O
		//IL_019e: Expected O, but got I
		nint num = (nint)typeof(DOTween);
		float t;
		if ("BESTIARY_TWEENS" != null)
		{
			float optionalFloat = default(float);
			object optionalObj = default(object);
			object[] optionalArray = default(object[]);
			int num2 = DG.Tweening.Core.TweenManager.FilteredOperation(DG.Tweening.Core.Enums.OperationType.Despawn, DG.Tweening.Core.Enums.FilterType.TargetOrId, (object)"BESTIARY_TWEENS", false, optionalFloat, optionalObj, optionalArray);
			t = 0f;
			object obj = 0;
			num = 1;
		}
		else
		{
			t = 0f;
			object obj = 0;
		}
		if (_spawnedEnemies != null)
		{
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null, t);
			}
			num = (nint)_spawnedEnemies;
			if (_spawnedEnemies != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v10 (Il2CppClass<DG.Tweening.DOTween>)+1C]");
				_ = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v10 (Il2CppClass<DG.Tweening.DOTween>)+18]");
				if ((nint)0 > (nint)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v10 (Il2CppClass<DG.Tweening.DOTween>)+10]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v10 (Il2CppClass<DG.Tweening.DOTween>)+18]");
					Array.Clear((Array)num3, 0, 0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v10 (Il2CppClass<DG.Tweening.DOTween>)+10]");
					num = 0;
				}
				BestiaryFactory bestiaryFactory = _bestiaryFactory;
				if ((object)_bestiaryFactory != null)
				{
					AddressableCache.RemoveTexturesFromCacheAndSpriteManager(bestiaryFactory.CACHE_GROUP);
					num = (nint)_bestiaryFactory;
					if ((object)_bestiaryFactory != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rcx_v10 (Il2CppClass<DG.Tweening.DOTween>)+70]");
						AddressableCache.ReleaseCustomOperationHandleGroup((string)0);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SpawnEnemyAnimations(EnemyData enemyData, EnemyType enemyType)
	{
		//IL_0ac4: Expected O, but got I4
		//IL_0019: Expected O, but got I4
		//IL_092c: Expected I4, but got O
		//IL_0172: Expected O, but got I4
		//IL_01da: Expected O, but got I4
		//IL_0249: Expected O, but got I4
		//IL_0277: Expected O, but got I4
		//IL_062e: Expected I4, but got O
		//IL_0467: Expected O, but got I4
		//IL_049e: Expected O, but got I4
		//IL_03db: Expected I4, but got O
		//IL_0505: Expected I4, but got O
		//IL_050e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Expected O, but got Unknown
		ClearExistingEnemyAnims();
		bool flag = _redBlueTimer == null;
		object obj = 0;
		if (!flag)
		{
			_redBlueTimer.Cancel();
			obj = 0;
		}
		if (enemyData == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B7F160");
		DlcUtils dlcUtils = default(DlcUtils);
		DlcType? enemyDlcType = dlcUtils.GetEnemyDlcType(enemyType, _data);
		bool flag2 = (object)enemyDlcType == null;
		Action<bool> action = null;
		DlcType? data = (DlcType?)_data;
		if (!flag2)
		{
			BestiaryFactory bestiaryFactory = _bestiaryFactory;
			bool flag3 = SpriteLoader.LoadTexture(enemyData._003CtextureName_003Ek__BackingField, bestiaryFactory.CACHE_GROUP, enemyDlcType);
			action = null;
			data = enemyDlcType;
		}
		EnemyData enemyData2 = default(EnemyData);
		EnemyType enemyType2;
		GameObject enemyObject;
		int positionIndex;
		List<Vector2> variants5;
		int num = default(int);
		if (enemyType != EnemyType.SKETAMARI)
		{
			if (enemyType != EnemyType.DIRECTER)
			{
				if (enemyType != EnemyType.TRINACRIA)
				{
					if (enemyType != EnemyType.MS_GOSHADOKURO)
					{
						if (enemyType != EnemyType.MS_OROCHIMARIO)
						{
							object obj2 = enemyType - 167;
							if ((nint)obj2 > 1 && enemyType != EnemyType.BOSS_XLCRAB)
							{
								if (enemyType != EnemyType.MOON_MASK3)
								{
									object obj3 = enemyType - 190;
									if ((nint)obj3 <= 12)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"bt ecx,eax\"");
										if ((nint)obj3 < 12)
										{
											goto IL_06a3;
										}
									}
									if (enemyType != EnemyType.MOON_MASK5)
									{
										object obj4 = enemyType - 195;
										if ((nint)obj4 > 2)
										{
											object obj5 = enemyType - 207;
											if ((nint)obj5 > 2 && enemyType != EnemyType.TRAINEE_Y)
											{
												if (enemyType != EnemyType.COSMIC_EGG)
												{
													switch (enemyType)
													{
													case EnemyType.TP_BOSS_DOPPLEGANGER:
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
														List<Vector2> variants3 = default(List<Vector2>);
														CreateDoppelganger(variants3, 0, EnemyType.TP_BOSS_DOPPLEGANGER, enemyData2);
														return;
													}
													case EnemyType.TP_BOSS_DEATH:
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
														List<Vector2> variants2 = default(List<Vector2>);
														CreateTPDeath(variants2, 0, EnemyType.TP_BOSS_DEATH, enemyData2);
														return;
													}
													case EnemyType.BOSS_FB_BIGFUZZ:
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
														List<Vector2> variants = default(List<Vector2>);
														CreateBigFuzz(variants, 0, EnemyType.BOSS_FB_BIGFUZZ, enemyData2);
														return;
													}
													case EnemyType.STARDUST_MUD:
														CreateUndeadStars(enemyData, EnemyType.STARDUST_MUD);
														return;
													case EnemyType.STARDUST_ELEMENTAL:
														CreateRedBlue(enemyData, EnemyType.STARDUST_ELEMENTAL);
														return;
													}
													GameObject bestiaryEnemyPrefab = _bestiaryFactory.GetBestiaryEnemyPrefab(enemyType);
													if ((object)bestiaryEnemyPrefab != null && ((UnityEngine.Object)bestiaryEnemyPrefab).m_CachedPtr != (IntPtr)0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
														List<Vector2> variants4 = default(List<Vector2>);
														GameObject gameObject = CreateFactoryPrefab(variants4, 0, enemyType, (byte)(int)enemyData2 != 0);
														return;
													}
													List<EnemyAnimDisplayData> list = BuildEnemyDisplayList(enemyData, enemyType);
													List<List<List<Vector2>>> allPositions = _allPositions;
													int size = allPositions._size;
													if (list._size <= allPositions._size)
													{
														size = list._size;
													}
													object obj6 = size - 1;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
													IList<List<Vector2>> list3 = default(IList<List<Vector2>>);
													List<Vector2> list2 = VampireSurvivors.App.Tools.Extensions.PickRnd(list3);
													bool flag4 = size <= 0;
													object obj7 = 0;
													if (flag4)
													{
														return;
													}
													Vector2 randomPosition = default(Vector2);
													while ((nint)obj7 < list._size)
													{
														EnemyAnimDisplayData[] items = list._items;
														object obj8 = obj7;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1466 @ rax_v106 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
														if ((nint)obj8 >= 0)
														{
															break;
														}
														CreateEnemyAnimation(items[obj7], randomPosition, "_i", (byte)(int)enemyData2 != 0);
														obj7++;
														if ((nint)obj7 >= size)
														{
															return;
														}
													}
													goto IL_0af5;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
												enemyType2 = (EnemyType)enemyData2;
												GameObject bestiaryEnemyPrefab2 = _bestiaryFactory.GetBestiaryEnemyPrefab(EnemyType.COSMIC_EGG);
												Transform parent = _EnvironmentBackground.transform;
												enemyObject = UnityEngine.Object.Instantiate(bestiaryEnemyPrefab2, parent);
												positionIndex = 0;
												List<Vector2> list4 = default(List<Vector2>);
												variants5 = list4;
												goto IL_0b4e;
											}
										}
										EnemyData enemyData3 = enemyData._003Calias_003Ek__BackingField;
										if (enemyData._003Calias_003Ek__BackingField != null)
										{
											string text = VampireSurvivors.App.Tools.Extensions.PickRnd(enemyData3._003CframeNames_003Ek__BackingField);
										}
										return;
									}
									goto IL_06a3;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								CreateMask(EnemyType.MOON_MASK3, EnemyType.MOON_MASK2, enemyData, (List<Vector2>)(object)enemyData2, num);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								CreateMask(EnemyType.MOON_MASK3, EnemyType.MOON_MASK3, enemyData, (List<Vector2>)(object)enemyData2, num);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								CreateMask(EnemyType.MOON_MASK3, EnemyType.MOON_MASK4, enemyData, (List<Vector2>)(object)enemyData2, num);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								CreateMask(EnemyType.MOON_MASK3, EnemyType.MOON_MASK5, enemyData, (List<Vector2>)(object)enemyData2, num);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
								CreateMask(EnemyType.MOON_MASK3, EnemyType.MOON_MASK1, enemyData, (List<Vector2>)(object)enemyData2, num);
								return;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							List<Vector2> variants6 = default(List<Vector2>);
							CreateCrabbino(variants6, 0, enemyType, enemyData2);
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						List<Vector2> variants7 = default(List<Vector2>);
						CreateOROCHIMARIO(variants7, 0, EnemyType.MS_OROCHIMARIO, enemyData2);
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					List<Vector2> variants8 = default(List<Vector2>);
					CreateGASHADOKURO(variants8, 0, EnemyType.MS_GOSHADOKURO, enemyData2);
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
				GameObject bestiaryEnemyPrefab3 = _bestiaryFactory.GetBestiaryEnemyPrefab(EnemyType.TRINACRIA);
				Transform parent2 = _EnvironmentBackground.transform;
				enemyObject = UnityEngine.Object.Instantiate(bestiaryEnemyPrefab3, parent2);
				positionIndex = 0;
				List<Vector2> list5 = default(List<Vector2>);
				variants5 = list5;
				enemyType2 = (EnemyType)enemyData2;
				goto IL_0b4e;
			}
			List<List<List<Vector2>>> allPositions2 = _allPositions;
			if (allPositions2._size > 0)
			{
				List<List<Vector2>>[] items2 = allPositions2._items;
				List<List<Vector2>> list6 = items2[0];
				if (list6._size > 0)
				{
					Sprite sprite = SpriteManager.GetSprite("blackDot", "vfx");
					_EnvironmentBackground.sprite = sprite;
					return;
				}
			}
		}
		else
		{
			List<List<List<Vector2>>> allPositions3 = _allPositions;
			if (allPositions3._size > 0)
			{
				List<List<Vector2>>[] items3 = allPositions3._items;
				List<List<Vector2>> list7 = items3[0];
				if (list7._size > 0)
				{
					List<Vector2>[] items4 = list7._items;
					CreateSketamari(items4[0], 0, EnemyType.SKETAMARI, enemyData2);
					return;
				}
			}
		}
		goto IL_0af5;
		IL_0b4e:
		AddEnemyObjectToHierarchy(enemyObject, variants5, positionIndex, enemyType2, (byte)num != 0);
		return;
		IL_0af5:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_06a3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
		CreateMask(enemyType, enemyType, enemyData, (List<Vector2>)(object)enemyData2, num);
	}

	private unsafe List<EnemyAnimDisplayData> BuildEnemyDisplayList(EnemyData enemyData, EnemyType enemyType)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0225: Expected O, but got I
		//IL_04fb: Expected O, but got I4
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_02d4: Expected O, but got I
		//IL_02e9: Expected O, but got I
		//IL_035e: Expected O, but got I4
		List<EnemyAnimDisplayData> list = new List<EnemyAnimDisplayData>();
		object obj = 0;
		object obj2 = 0;
		object obj4 = default(object);
		object obj5 = default(object);
		object obj6 = default(object);
		while (true)
		{
			List<string> list2 = enemyData._003CframeNames_003Ek__BackingField;
			if ((nint)obj2 < list2._size)
			{
				if ((nint)obj >= list2._size)
				{
					break;
				}
				string[] items = list2._items;
				EnemyAnimDisplayData item = new EnemyAnimDisplayData(enemyData, enemyType, items[obj]);
				int version = list._version + 1;
				list._version = version;
				EnemyAnimDisplayData[] items2 = list._items;
				if (list._size >= items2.Length)
				{
					((List<object>)(object)list).AddWithResize((object)item);
					obj++;
					obj2 = obj;
				}
				else
				{
					int size = list._size + 1;
					list._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					obj++;
					obj2 = obj;
				}
				continue;
			}
			if (enemyData._003CbVariants_003Ek__BackingField != null)
			{
				List<EnemyType> list3 = enemyData._003CbVariants_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ rax_v46 (System.Collections.Generic.List`1<VampireSurvivors.Data.EnemyType>)+18]");
				if ((nint)0 > (nint)0)
				{
					EnemyType enemyType2 = enemyType;
					while (true)
					{
						object obj3 = obj4;
						while (true)
						{
							if (obj5 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ stack_-68_v19+1C]");
								if (obj6 == null)
								{
									object obj7 = obj3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ stack_-68_v19+18]");
									if ((nint)obj7 < 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ stack_-68_v19+10]");
										object obj8 = 0;
										obj3++;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v62+20+v356 @ rdx_v26*4]");
										if ((nint)0 == (nint)enemyType2)
										{
											continue;
										}
										goto IL_025c;
									}
									break;
								}
								break;
							}
							throw new NullReferenceException();
						}
						break;
						IL_025c:
						Dictionary<EnemyType, List<EnemyData>> enemies = _enemies;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v62+20+v356 @ rdx_v26*4]");
						bool flag = ((Dictionary<System.Int32Enum, object>)(object)enemies).TryGetValue((System.Int32Enum)0, out object value);
						bool flag2 = !flag;
						obj4 = obj3;
						if (flag2)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ stack_10_v20 (System.Object)+18]");
						if ((nint)0 > (nint)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ stack_10_v20 (System.Object)+10]");
							object obj9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ r15_v20+20]");
							EnemyData enemyData2 = (EnemyData)0;
							ref List<EnemyData> value2 = ref *(List<EnemyData>*)(&value);
							EnemyType enemyType3 = EnemyType.BAT1;
							while (true)
							{
								List<string> list4 = enemyData2._003CframeNames_003Ek__BackingField;
								if ((int)enemyType3 >= list4._size)
								{
									break;
								}
								_003C_003Ec__DisplayClass77_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass77_0();
								bool flag3 = ((Dictionary<EnemyType, List<EnemyData>>)(object)enemyData2._003CframeNames_003Ek__BackingField).TryGetValue(enemyType3, out value2);
								CS_0024_003C_003E8__locals6.frameName = (string)flag3;
								Func<EnemyAnimDisplayData, bool> predicate = delegate(EnemyAnimDisplayData data)
								{
									//IL_012f: Expected I4, but got O
									//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
									//IL_00d1: Expected Ref, but got Unknown
									//IL_00e8: Expected I8, but got I4
									//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
									//IL_00fb: Expected Ref, but got Unknown
									if (data != null)
									{
										string frameName = data.FrameName;
										if (data.FrameName != null)
										{
											string frameName2 = CS_0024_003C_003E8__locals6.frameName;
											if ((object)data.FrameName != CS_0024_003C_003E8__locals6.frameName)
											{
												if (CS_0024_003C_003E8__locals6.frameName != null && frameName._stringLength == frameName2._stringLength)
												{
													ref byte second = ref *(byte*)(CS_0024_003C_003E8__locals6.frameName + 20);
													ulong length = (ulong)(frameName._stringLength + frameName._stringLength);
													return System.SpanHelpers.SequenceEqual(ref *(byte*)(data.FrameName + 20), ref second, length);
												}
												return false;
											}
											return true;
										}
									}
									NullReferenceException ex = new NullReferenceException();
									return (byte)(int)ex != 0;
								};
								int num = Enumerable.Count(list, (Func<object, bool>)predicate);
								EnemyType enemyType4;
								if (num > 0)
								{
									bool flag4 = !enemyData._003CbIncludeColorVariants_003Ek__BackingField;
									enemyType4 = EnemyType.BAT1;
									if (flag4)
									{
										goto IL_041f;
									}
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v62+20+v356 @ rdx_v26*4]");
								EnemyAnimDisplayData enemyAnimDisplayData = new EnemyAnimDisplayData(enemyData2, EnemyType.BAT1, CS_0024_003C_003E8__locals6.frameName);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9A510");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ rax_v62+20+v356 @ rdx_v26*4]");
								enemyType4 = EnemyType.BAT1;
								goto IL_041f;
								IL_041f:
								enemyType3++;
								value2 = ref *(List<EnemyData>*)(int)enemyType4;
							}
							obj4 = obj3;
							enemyType2 = enemyType;
							continue;
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						throw new NullReferenceException();
					}
					if (obj5 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ stack_-68_v19+1C]");
						if (obj6 == null)
						{
							goto IL_054b;
						}
						System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
						object obj10 = 0;
					}
					throw new NullReferenceException();
				}
			}
			goto IL_054b;
			IL_054b:
			return list;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
	}

	private unsafe void CreateEnemyAnimation(EnemyAnimDisplayData cData, Vector2 randomPosition, string prefixOverride = "_i", bool flipX = false)
	{
		//IL_0008: Expected O, but got Ref
		//IL_07e6: Expected O, but got I4
		//IL_0826: Expected O, but got I
		//IL_0163: Expected O, but got I
		//IL_03a0: Expected O, but got I
		//IL_01c9: Expected O, but got I
		//IL_01d9: Expected O, but got I
		//IL_03f2: Expected O, but got Ref
		//IL_043c: Expected O, but got I
		//IL_021c: Expected O, but got I
		//IL_022c: Expected O, but got I
		//IL_0274: Expected O, but got I
		//IL_04a0: Expected F4, but got I
		//IL_04a0: Expected F4, but got I
		//IL_04a0: Expected O, but got I
		//IL_092f: Expected O, but got Ref
		//IL_09a0: Expected O, but got Ref
		//IL_0a17: Expected O, but got Ref
		//IL_0a52: Expected O, but got Ref
		//IL_059d: Expected O, but got Ref
		//IL_05cf: Expected O, but got Ref
		//IL_0ae9: Expected O, but got Ref
		//IL_0b11: Expected O, but got I
		//IL_0b1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1f: Expected O, but got Unknown
		//IL_0b28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2d: Expected O, but got Unknown
		//IL_0b8f: Expected O, but got Ref
		//IL_072f: Expected F4, but got I
		//IL_0966->IL080a: Incompatible stack heights: 1 vs 0
		//IL_09da->IL080a: Incompatible stack heights: 2 vs 0
		//IL_0b52->IL080a: Incompatible stack heights: 7 vs 0
		object obj2 = default(object);
		object obj = (object)(&obj2);
		GameObject gameObject;
		UISpriteAnimation componentInChildren;
		Image component;
		if (cData != null)
		{
			string textureName = cData.TextureName;
			if (cData.TextureName == null || textureName._stringLength <= 0)
			{
				textureName = "enemies";
			}
			int num = cData.IdleFrameCount ^ cData.IdleFrameCount;
			int num2 = cData.IdleFrameCount & num;
			bool flag = num2 < 0;
			bool flag2 = cData.IdleFrameCount < 0;
			bool flag3 = cData.IdleFrameCount == 0;
			bool flag4 = flag2 == flag;
			bool flag5 = !flag3;
			List<Sprite> list = (List<Sprite>)(flag5 & flag4);
			if ((object)_EnvironmentBackground != null)
			{
				Transform parent = _EnvironmentBackground.transform;
				gameObject = UnityEngine.Object.Instantiate(_EnemyIconPrefab, parent);
				if ((object)gameObject != null)
				{
					componentInChildren = gameObject.GetComponentInChildren<UISpriteAnimation>(includeInactive: false);
					component = gameObject.GetComponent<Image>();
					if ((object)componentInChildren != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rax_v49 (VampireSurvivors.UI.UISpriteAnimation)+60]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v699 @ rax_v49 (VampireSurvivors.UI.UISpriteAnimation)+60]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v49+1C]");
							_ = (nint)0 + (nint)1;
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v49+18]");
							if ((nint)0 > (nint)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v49+10]");
								nint num3 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v202 @ rcx_v49+18]");
								Array.Clear((Array)num3, 0, 0);
							}
							if (list != null)
							{
								if (cData.FrameName != null)
								{
									string text = cData.FrameName.ToLowerInvariant();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rcx_v117+B8]");
									object newValue = 0;
									if (text != null)
									{
										string text2 = text.Replace(".png", (string)newValue);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
										object obj5 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ rcx_v119+B8]");
										object newValue2 = 0;
										if (text2 != null)
										{
											string text3 = text2.Replace("_0", (string)newValue2);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+6F]");
											string animName = text3 + (string)0;
											_ = cData.TextureName;
											int zeroPad = default(int);
											List<Sprite> animationFrames = SpriteManager.GetAnimationFrames(animName, 1, cData.IdleFrameCount, cData.TextureName, zeroPad);
											if (animationFrames == null || animationFrames._size <= 0)
											{
												goto IL_036b;
											}
											if (animationFrames._size <= 0)
											{
												System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
												goto IL_0896;
											}
											Sprite[] items = animationFrames._items;
											if (animationFrames._items != null)
											{
												if (items.Length <= 0)
												{
													goto IL_0896;
												}
												if ((object)component != null)
												{
													component.sprite = items[0];
													_ = 8;
													goto IL_036b;
												}
											}
										}
									}
								}
							}
							else
							{
								_ = 1;
								string frameName = cData.FrameName;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+5F]");
								Sprite sprite = SpriteManager.GetSprite(frameName, (string)0);
								if ((object)component != null)
								{
									component.sprite = sprite;
									goto IL_03d3;
								}
							}
						}
					}
				}
			}
		}
		goto IL_080a;
		IL_0896:
		throw new IndexOutOfRangeException();
		IL_080a:
		throw new NullReferenceException();
		IL_036b:
		_ = 1;
		goto IL_03d3;
		IL_03d3:
		UpdateEnemyDisplay(cData, component, gameObject);
		Enum obj6 = (Enum)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = typeof(EnemyType);
		_ = cData.Type;
		_ = -1;
		string text4 = obj6.ToString();
		((UnityEngine.Object)gameObject).SetName(text4);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+57]");
		List<Sprite> list2 = (List<Sprite>)0;
		RectTransform component2 = gameObject.GetComponent<RectTransform>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r14_v22 (System.Collections.Generic.List`1<UnityEngine.Sprite>)+150]");
		if ((nint)0 != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r14_v22 (System.Collections.Generic.List`1<UnityEngine.Sprite>)+150]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-49]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-45]");
			((PositionInsideRectUI)num4).PlaceInside(component2, num5, 0f);
			Transform transform = gameObject.transform;
			if ((object)transform != null)
			{
				if (((EnemyAnimDisplayData)(object)transform).IdleFrameCount == 0)
				{
					UnityEngine.Bindings.ThrowHelper.ThrowNullReferenceException(transform);
				}
				else
				{
					Transform.SetAsFirstSibling_Injected((IntPtr)((EnemyAnimDisplayData)(object)transform).IdleFrameCount);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ r14_v22 (System.Collections.Generic.List`1<UnityEngine.Sprite>)+1F8]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
						if ((object)component != null)
						{
							RectTransform rectTransform = component.rectTransform;
							if ((object)rectTransform != null)
							{
								Vector2 pivot = default(Vector2);
								rectTransform.pivot = pivot;
								RectTransform rectTransform2 = component.rectTransform;
								if ((object)rectTransform2 != null)
								{
									_ = 0;
									_ = 0;
									bool flag6 = ((EnemyAnimDisplayData)(object)rectTransform2).IdleFrameCount == 0;
									object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
									Transform.get_localPosition_Injected((IntPtr)((EnemyAnimDisplayData)(object)rectTransform2).IdleFrameCount, out *(Vector3*)obj7);
									RectTransform rectTransform3 = component.rectTransform;
									if ((object)rectTransform3 != null)
									{
										_ = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v76 (UnityEngine.RectTransform)+10]");
										bool flag7 = (nint)0 == 0;
										object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v76 (UnityEngine.RectTransform)+10]");
										RectTransform.get_rect_Injected((IntPtr)0, out *(Rect*)obj8);
										RectTransform rectTransform4 = component.rectTransform;
										if ((object)rectTransform4 != null)
										{
											_ = 0;
											_ = 0;
											bool flag8 = ((UnityEngine.Object)rectTransform4).m_CachedPtr == (IntPtr)0;
											object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
											Transform.get_localScale_Injected(((UnityEngine.Object)rectTransform4).m_CachedPtr, out *(Vector3*)obj9);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-39]");
											_ = 0;
											bool flag9 = ((EnemyAnimDisplayData)(object)rectTransform2).IdleFrameCount == 0;
											object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
											Transform.set_localPosition_Injected((IntPtr)((EnemyAnimDisplayData)(object)rectTransform2).IdleFrameCount, ref *(Vector3*)obj10);
											Transform transform2 = component.transform;
											bool flag10 = (object)transform2 == null;
											_ = -5f;
											Vector3 eulerAngles = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
											transform2.eulerAngles = eulerAngles;
											Transform target = component.transform;
											Vector3 endValue = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
											_ = 5f;
											TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, endValue, 1f);
											if (tweenerCore != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1853 @ rax_v94 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1853 @ rax_v94 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
													if ((nint)0 == 0)
													{
														_ = 4294967295L;
														_ = 1;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1853 @ rax_v94 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
														if ((nint)0 == 0)
														{
															_ = 2139095040;
														}
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1853 @ rax_v94 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
													if ((nint)0 == 0)
													{
													}
												}
											}
											Transform component3 = componentInChildren.transform;
											Transform transform3 = componentInChildren.transform;
											bool flag11 = (object)transform3 == null;
											_ = 0;
											_ = 0;
											bool flag12 = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
											object obj11 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41));
											Transform.get_localScale_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out *(Vector3*)obj11);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
											object obj12 = (nint)0 ^ (nint)1;
											object obj13 = obj12 * 2;
											List<Sprite> list3 = (List<Sprite>)(obj13 - 1);
											Transform transform4 = componentInChildren.transform;
											if ((object)transform4 != null)
											{
												_ = 0;
												_ = 0;
												bool flag13 = ((UnityEngine.Object)transform4).m_CachedPtr == (IntPtr)0;
												object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 65));
												Transform.get_localScale_Injected(((UnityEngine.Object)transform4).m_CachedPtr, out *(Vector3*)obj14);
												float num6 = (float)list3;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
												float xScale = num6 * 0f;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-3D]");
												Transform transform5 = RenderingExtensions.SetScale(component3, xScale, 0f);
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
		goto IL_080a;
	}

	private unsafe static void UpdateEnemyDisplay(EnemyAnimDisplayData cData, Image enemyImage, GameObject enemyObject)
	{
		//IL_000e: Invalid comparison between F4 and I4
		//IL_001d: Invalid comparison between F4 and I4
		//IL_0046: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_0174: Invalid comparison between F4 and I4
		//IL_00ce: Expected O, but got Ref
		//IL_00f5: Expected O, but got Ref
		float num = default(float);
		bool flag = num < 0f;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj = flag4 & flag3;
		object obj2 = (object?)cData.Scale & obj;
		float? num2 = (float?)((obj2 == null) ? ((object)1) : cData.Scale);
		enemyImage.SetNativeSize();
		RectTransform rectTransform = enemyImage.rectTransform;
		bool flag5 = (object)num2 == null;
		bool flag6 = ((UnityEngine.Object)rectTransform).m_CachedPtr == (IntPtr)0;
		float value = default(float);
		Transform.set_localScale_Injected(((UnityEngine.Object)rectTransform).m_CachedPtr, ref *(Vector3*)(&value));
		if ((object)cData.Tint != null)
		{
			enemyImage.color = (Color)(&value);
			float num3 = default(float);
			value = num3;
		}
		if (cData.Alpha > 0f)
		{
			Color color = enemyImage.color;
			enemyImage.color = (Color)(&value);
		}
	}

	private void ApplyAnimationToEnemy(GameObject enemyObject, List<Sprite> sprites, EnemyData enemyData)
	{
		UISpriteAnimation component = enemyObject.GetComponent<UISpriteAnimation>();
		component.sprites = sprites;
		Image component2 = enemyObject.GetComponent<Image>();
		List<Sprite> sprites2 = component.sprites;
		bool flag = sprites2._size <= 0;
		Sprite[] items = sprites2._items;
		component2.sprite = items[0];
		EnemyData enemyData2 = default(EnemyData);
		if ((object)enemyData2._003Cscale_003Ek__BackingField != null)
		{
		}
		Transform transform = enemyObject.transform;
		bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
	}

	private unsafe void AddEnemyObjectToHierarchy(GameObject enemyObject, List<Vector2> variants, int positionIndex, EnemyType enemyType, bool ignoreAngle = false)
	{
		//IL_003f: Expected O, but got Ref
		//IL_009e: Expected O, but got I
		//IL_00ca: Expected F4, but got I
		//IL_00ca: Expected F4, but got I
		//IL_0133: Expected O, but got Ref
		//IL_015c: Expected O, but got Ref
		if ((object)enemyObject == null || ((UnityEngine.Object)enemyObject).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		((UnityEngine.Object)enemyObject).SetName(text);
		RectTransform component = enemyObject.GetComponent<RectTransform>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [variants @ r8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
		if ((nint)positionIndex < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [variants @ r8 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
			object obj = 0;
			PositionInsideRectUI enemyContainer = _EnemyContainer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ r8_v5+20+positionIndex @ r9 (System.Int32)*8]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v342 @ r8_v5+24+positionIndex @ r9 (System.Int32)*8]");
			enemyContainer.PlaceInside(component, num, 0f);
			Transform transform = enemyObject.transform;
			transform.SetAsFirstSibling();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180497F80");
			object obj2 = default(object);
			if (obj2 != null)
			{
				return;
			}
			Transform transform2 = enemyObject.transform;
			transform2.eulerAngles = (Vector3)(&intPtr);
			Transform target = enemyObject.transform;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = ShortcutExtensions.DORotate(target, (Vector3)(&intPtr), 0.5f);
			if (tweenerCore == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 == 0)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+100]");
			if ((nint)0 == 0)
			{
				_ = 4294967295L;
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+10]");
				if ((nint)0 == 0)
				{
					_ = 2139095040;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v469 @ rax_v27 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+E8]");
			if ((nint)0 == 0)
			{
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new NullReferenceException();
	}

	private GameObject CreateFactoryPrefab(List<Vector2> variants, int positionIndex, EnemyType enemyType, bool ignoreAngle = false)
	{
		if ((object)_bestiaryFactory != null)
		{
			GameObject bestiaryEnemyPrefab = _bestiaryFactory.GetBestiaryEnemyPrefab(enemyType);
			if ((object)_EnvironmentBackground != null)
			{
				Transform parent = _EnvironmentBackground.transform;
				GameObject gameObject = UnityEngine.Object.Instantiate(bestiaryEnemyPrefab, parent);
				EnemyType enemyType2 = default(EnemyType);
				bool ignoreAngle2 = default(bool);
				AddEnemyObjectToHierarchy(gameObject, variants, positionIndex, enemyType2, ignoreAngle2);
				return gameObject;
			}
		}
		return (GameObject)(object)new NullReferenceException();
	}

	private void CreateDirecter(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
	{
		Sprite sprite = SpriteManager.GetSprite("blackDot", "vfx");
		_EnvironmentBackground.sprite = sprite;
	}

	private void CreateTrinacria(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
	{
		GameObject bestiaryEnemyPrefab = _bestiaryFactory.GetBestiaryEnemyPrefab(enemyType);
		Transform parent = _EnvironmentBackground.transform;
		GameObject enemyObject = UnityEngine.Object.Instantiate(bestiaryEnemyPrefab, parent);
		EnemyType enemyType2 = default(EnemyType);
		bool ignoreAngle = default(bool);
		AddEnemyObjectToHierarchy(enemyObject, variants, positionIndex, enemyType2, ignoreAngle);
	}

	private void CreateSketamari(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
	{
		//IL_00af: Expected F4, but got I4
		//IL_00af: Expected F4, but got I4
		//IL_00d7: Expected F4, but got I4
		//IL_00d7: Expected F4, but got I4
		//IL_0104: Expected F4, but got I4
		//IL_0104: Expected F4, but got I4
		GameObject bestiaryEnemyPrefab = _bestiaryFactory.GetBestiaryEnemyPrefab(enemyType);
		Transform parent = _EnvironmentBackground.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(bestiaryEnemyPrefab, parent);
		EnemyType enemyType2 = default(EnemyType);
		bool flag = default(bool);
		AddEnemyObjectToHierarchy(gameObject, variants, positionIndex, enemyType2, flag);
		UISketamari component = gameObject.GetComponent<UISketamari>();
		component._dataManager = _data;
		bool flipY = default(bool);
		component.AddBones(component._BonesParent, 60, 0.75f, (float)enemyType2, (float)(flag ? 1 : 0), flipY);
		component.AddBones(component._BonesParent, 35, 0.5f, (float)enemyType2, (float)(flag ? 1 : 0), flipY);
		component.AddBones(component._BonesParent, 25, 0f, (float)enemyType2, (float)(flag ? 1 : 0), flipY);
		Transform target = component._BonesParent.transform;
		TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = ShortcutExtensions.DOScale(target, 400f, 60.000004f);
	}

	private unsafe void CreateCrabbino(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
	{
		//IL_00d9: Expected O, but got I4
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_0129: Expected O, but got I4
		//IL_011b: Expected O, but got I
		if ((object)_bestiaryFactory != null)
		{
			GameObject bestiaryEnemyPrefab = _bestiaryFactory.GetBestiaryEnemyPrefab(enemyType);
			if ((object)_EnvironmentBackground != null)
			{
				Transform parent = _EnvironmentBackground.transform;
				GameObject gameObject = UnityEngine.Object.Instantiate(bestiaryEnemyPrefab, parent);
				EnemyType enemyType2 = default(EnemyType);
				bool ignoreAngle = default(bool);
				AddEnemyObjectToHierarchy(gameObject, variants, positionIndex, enemyType2, ignoreAngle);
				object obj = default(object);
				if (obj != null)
				{
					object obj2 = default(object);
					bool flag = (nint)obj2 < 0;
					bool flag2 = obj2 == null;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					object obj3 = flag4 & flag3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ stack_28+68]");
					object obj4 = 0 & obj3;
					object obj5;
					if (obj4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ stack_28+68]");
						obj5 = 0;
					}
					else
					{
						obj5 = 1;
					}
					if ((object)gameObject != null)
					{
						RectTransform component = gameObject.GetComponent<RectTransform>();
						bool flag5 = obj5 == null;
						bool flag6 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						Vector2 value = default(Vector2);
						Transform.set_localScale_Injected(((UnityEngine.Object)component).m_CachedPtr, ref *(Vector3*)(&value));
						Vector2 pivot = default(Vector2);
						component.pivot = pivot;
						bool flag7 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						Vector2 ret;
						Transform.get_localPosition_Injected(((UnityEngine.Object)component).m_CachedPtr, out *(Vector3*)(&ret));
						bool flag8 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						RectTransform.get_rect_Injected(((UnityEngine.Object)component).m_CachedPtr, out Rect _);
						bool flag9 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						Transform.get_localScale_Injected(((UnityEngine.Object)component).m_CachedPtr, out *(Vector3*)(&value));
						bool flag10 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
						Transform.set_localPosition_Injected(((UnityEngine.Object)component).m_CachedPtr, ref *(Vector3*)(&ret));
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void CreateMask(EnemyType enemyType, EnemyType maskType, EnemyData data, List<Vector2> variants, int positionIndex)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 65 Invalid \"Jump target not found in method: 0x186B94EBF\"");
		GameObject bestiaryEnemyPrefab = _bestiaryFactory.GetBestiaryEnemyPrefab(enemyType);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 81 Invalid \"Jump target not found in method: 0x186B94EBF\"");
		Transform parent = _EnvironmentBackground.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(bestiaryEnemyPrefab, parent);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 136 Invalid \"Jump target not found in method: 0x186B94EBF\"");
		List<List<string>> internal_IdleAnimFrameNames = data.Internal_IdleAnimFrameNames;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 148 Invalid \"Jump target not found in method: 0x186B94EBF\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 162 Invalid \"Jump target not found in method: 0x186B94F83\"");
		List<string>[] items = internal_IdleAnimFrameNames._items;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 174 Invalid \"Jump target not found in method: 0x186B94EBF\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 188 Invalid \"Jump target not found in method: 0x186B94EC5\"");
		List<Sprite> animationFramesFast = SpriteManager.GetAnimationFramesFast(items[0], data._003CtextureName_003Ek__BackingField);
		List<Sprite> sprites;
		if (animationFramesFast != null)
		{
			List<object> list = new List<object>(animationFramesFast);
			sprites = (List<Sprite>)(object)list;
		}
		else
		{
			sprites = null;
		}
		ApplyAnimationToEnemy(gameObject, sprites, data);
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 279 Invalid \"Jump target not found in method: 0x186B94EBF\"");
		UIMaskedEnemy component = gameObject.GetComponent<UIMaskedEnemy>();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 294 Invalid \"Jump target not found in method: 0x186B94EBF\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 347 Invalid \"Jump target not found in method: 0x186B94AC0\"");
	}

	private void CreateAlias(EnemyType enemyType, EnemyData enemyData)
	{
		EnemyData enemyData2 = enemyData._003Calias_003Ek__BackingField;
		if (enemyData._003Calias_003Ek__BackingField != null)
		{
			string text = VampireSurvivors.App.Tools.Extensions.PickRnd(enemyData2._003CframeNames_003Ek__BackingField);
		}
	}

	private void CreateGASHADOKURO(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
	{
		List<List<List<Vector2>>> allPositions = _allPositions;
		bool flag = allPositions._size <= 0;
		List<List<Vector2>>[] items = allPositions._items;
		List<List<Vector2>> list = items[0];
		bool flag2 = list._size <= 0;
		List<Vector2>[] items2 = list._items;
		bool ignoreAngle = default(bool);
		GameObject gameObject = CreateFactoryPrefab(items2[0], 0, enemyType, ignoreAngle);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		bool flag3 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)component).m_CachedPtr, ref value);
		bool flag4 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Transform.get_localPosition_Injected(((UnityEngine.Object)component).m_CachedPtr, out Vector3 ret);
		bool flag5 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)component).m_CachedPtr, out Rect _);
		bool flag6 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)component).m_CachedPtr, out value);
		bool flag7 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Transform.set_localPosition_Injected(((UnityEngine.Object)component).m_CachedPtr, ref ret);
	}

	private void CreateOROCHIMARIO(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
	{
		List<List<List<Vector2>>> allPositions = _allPositions;
		bool flag = allPositions._size <= 0;
		List<List<Vector2>>[] items = allPositions._items;
		List<List<Vector2>> list = items[0];
		bool flag2 = list._size <= 0;
		List<Vector2>[] items2 = list._items;
		bool ignoreAngle = default(bool);
		GameObject gameObject = CreateFactoryPrefab(items2[0], 0, enemyType, ignoreAngle);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		bool flag3 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)component).m_CachedPtr, ref value);
		bool flag4 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Transform.get_localPosition_Injected(((UnityEngine.Object)component).m_CachedPtr, out Vector3 ret);
		bool flag5 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		RectTransform.get_rect_Injected(((UnityEngine.Object)component).m_CachedPtr, out Rect _);
		bool flag6 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Transform.get_localScale_Injected(((UnityEngine.Object)component).m_CachedPtr, out value);
		bool flag7 = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Transform.set_localPosition_Injected(((UnityEngine.Object)component).m_CachedPtr, ref ret);
	}

	private void CreateCosmicEgg(List<Vector2> variants, int positionIndex, EnemyType enemyType)
	{
		GameObject bestiaryEnemyPrefab = _bestiaryFactory.GetBestiaryEnemyPrefab(enemyType);
		Transform parent = _EnvironmentBackground.transform;
		GameObject enemyObject = UnityEngine.Object.Instantiate(bestiaryEnemyPrefab, parent);
		EnemyType enemyType2 = default(EnemyType);
		bool ignoreAngle = default(bool);
		AddEnemyObjectToHierarchy(enemyObject, variants, positionIndex, enemyType2, ignoreAngle);
	}

	private unsafe void CreateRedBlue(EnemyData enemyData, EnemyType enemyType)
	{
		//IL_0447: Expected I, but got O
		//IL_003a: Expected I, but got O
		//IL_0075: Expected I, but got O
		//IL_045f: Expected I, but got O
		//IL_00d1: Expected O, but got I4
		//IL_0108: Expected O, but got I
		//IL_013b: Expected O, but got I4
		//IL_0151: Expected O, but got I
		//IL_016c: Expected I, but got O
		//IL_02da: Expected O, but got I4
		//IL_02e8: Expected O, but got I4
		//IL_02fa: Expected O, but got Ref
		//IL_0370: Expected I, but got O
		//IL_0386: Expected O, but got I
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Expected O, but got Unknown
		//IL_040a: Expected I, but got O
		//IL_0551: Expected O, but got I4
		//IL_0568: Expected I, but got I8
		//IL_03e6: Expected I, but got I8
		_003C_003Ec__DisplayClass92_0 obj = new _003C_003Ec__DisplayClass92_0();
		bool flag = obj == null;
		nint num = (nint)typeof(_003C_003Ec__DisplayClass92_0);
		bool flag5 = default(bool);
		if (!flag)
		{
			obj._003C_003E4__this = this;
			List<EnemyAnimDisplayData> list = BuildEnemyDisplayList(enemyData, enemyType);
			bool flag2 = list == null;
			num = (nint)this;
			if (!flag2)
			{
				int size = list._size;
				List<List<List<Vector2>>> allPositions = _allPositions;
				bool flag3 = _allPositions == null;
				num = (nint)this;
				if (!flag3)
				{
					if (list._size > allPositions._size)
					{
						size = allPositions._size;
					}
					num = (nint)_allPositions;
					if (_allPositions != null)
					{
						object obj2 = size - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.BestiaryPage+<>c__DisplayClass92_0>)+18]");
						if ((nint)obj2 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.BestiaryPage+<>c__DisplayClass92_0>)+10]");
							object obj3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rcx_v7 (Il2CppClass<VampireSurvivors.UI.BestiaryPage+<>c__DisplayClass92_0>)+10]");
							if ((nint)0 == 0)
							{
								goto IL_0410;
							}
							object obj4 = size - 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rax_v18+20+v436 @ rcx_v13*8]");
							List<Vector2> list2 = VampireSurvivors.App.Tools.Extensions.PickRnd((IList<List<Vector2>>)0);
							bool flag4 = size <= 0;
							nint num2 = unchecked((nint)null);
							if (flag4)
							{
								goto IL_0281;
							}
							Vector2 randomPosition = default(Vector2);
							while (num2 < list._size)
							{
								EnemyAnimDisplayData[] items = list._items;
								if (list._items != null && list2 != null)
								{
									nint intPtr = num2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rax_v19 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
									if (intPtr >= 0)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v674 @ rax_v19 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+10]");
									if ((nint)0 != 0)
									{
										CreateEnemyAnimation(items[num2], randomPosition, "_i", flag5);
										num2++;
										if (num2 < size)
										{
											continue;
										}
										goto IL_0281;
									}
								}
								goto IL_0410;
							}
						}
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
						return;
					}
				}
			}
		}
		goto IL_0410;
		IL_0410:
		throw new NullReferenceException();
		IL_0548:
		object obj5 = 24;
		Action action;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
		int repeat = default(int);
		Timer redBlueTimer = TimerHelper.RegisterMillisUI(2000f, action, null, isLooped: true, flag5, autoDestroyOwner, repeat);
		_redBlueTimer = redBlueTimer;
		return;
		IL_0281:
		obj.isBlue = true;
		Timer redBlueTimer2 = _redBlueTimer;
		if (_redBlueTimer != null && !_redBlueTimer.IsDone)
		{
			float timeElapsed = _redBlueTimer.GetTimeElapsed();
			redBlueTimer2._timeElapsedBeforeCancel = (float?)(object)1;
			redBlueTimer2._timeElapsedBeforePause = (float?)(object)0;
		}
		if (_spawnedEnemies == null)
		{
			goto IL_0410;
		}
		List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<GameObject>.Enumerator enumerator2 = (List<GameObject>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		action = null;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ r10_v1 (Il2CppMethodInfo)+8]");
		((Delegate)action).method_ptr = (IntPtr)0;
		((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass92_0._003CCreateRedBlue_003Eb__0);
		((Delegate)action).m_target = obj;
		((Delegate)action).method_code = (IntPtr)action;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ r10_v1 (Il2CppMethodInfo)+4C]");
		object obj6 = (nint)0 >> 4;
		object obj7 = obj6 & 1;
		nint num4;
		if (obj7 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ r10_v1 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 0)
			{
				num4 = unchecked((nint)6447293664L);
				goto IL_0548;
			}
		}
		num4 = ((Delegate)action).method_ptr;
		((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
		goto IL_0548;
	}

	private void CreateUndeadStars(EnemyData enemyData, EnemyType enemyType)
	{
		//IL_03ae: Expected O, but got I4
		//IL_006f: Expected O, but got I4
		//IL_0196: Expected O, but got I
		//IL_01f0: Expected O, but got I
		//IL_03f5: Expected O, but got I
		//IL_025a: Expected O, but got I
		//IL_02c4: Expected O, but got I
		List<List<List<Vector2>>> allPositions = _allPositions;
		int num = allPositions._size;
		List<List<List<Vector2>>> allPositions2 = _allPositions;
		if (allPositions._size > 3)
		{
			num = 3;
		}
		object obj = num - 1;
		if ((nint)obj < allPositions2._size)
		{
			List<List<Vector2>>[] items = allPositions2._items;
			object obj2 = num - 1;
			List<Vector2> variants = VampireSurvivors.App.Tools.Extensions.PickRnd(items[obj2]);
			Transform parent = _EnvironmentBackground.transform;
			GameObject gameObject = UnityEngine.Object.Instantiate(_UndeadStars1Prefab, parent);
			Transform parent2 = _EnvironmentBackground.transform;
			GameObject gameObject2 = UnityEngine.Object.Instantiate(_UndeadStars2Prefab, parent2);
			Transform parent3 = _EnvironmentBackground.transform;
			GameObject gameObject3 = UnityEngine.Object.Instantiate(_UndeadStars3Prefab, parent3);
			EnemyType enemyType2 = default(EnemyType);
			bool ignoreAngle = default(bool);
			AddEnemyObjectToHierarchy(gameObject, variants, 0, enemyType2, ignoreAngle);
			AddEnemyObjectToHierarchy(gameObject2, variants, 1, enemyType2, ignoreAngle);
			AddEnemyObjectToHierarchy(gameObject3, variants, 2, enemyType2, ignoreAngle);
			List<uint> list = new List<uint>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ rdx_v16+18]");
			if (num2 >= 0)
			{
				list.AddWithResize(8947814u);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+18]");
				object obj4 = (nint)0 + (nint)1;
				_ = 8947814;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rdx_v18+18]");
			if (num3 >= 0)
			{
				list.AddWithResize(8939110u);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+18]");
				object obj6 = (nint)0 + (nint)1;
				_ = 8939110;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+10]");
			uint num4 = 0u;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+18]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rdx_v20 (System.UInt32)+18]");
			if (num5 >= 0)
			{
				list.AddWithResize(8947780u);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v509 @ rax_v21 (System.Collections.Generic.List`1<System.UInt32>)+18]");
				object obj7 = (nint)0 + (nint)1;
				_ = 8947780;
			}
			Image componentInChildren = gameObject.GetComponentInChildren<Image>(includeInactive: false);
			Image componentInChildren2 = ((GameObject)(object)list).GetComponentInChildren<Image>(false);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
			Image componentInChildren3 = gameObject2.GetComponentInChildren<Image>(includeInactive: false);
			Image componentInChildren4 = ((GameObject)(object)list).GetComponentInChildren<Image>(false);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
			Image componentInChildren5 = gameObject3.GetComponentInChildren<Image>(includeInactive: false);
			Image componentInChildren6 = ((GameObject)(object)list).GetComponentInChildren<Image>(false);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C0B200");
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	private void CreateBigFuzz(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
	{
		GameObject bestiaryEnemyPrefab = _bestiaryFactory.GetBestiaryEnemyPrefab(enemyType);
		Transform parent = _EnvironmentBackground.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(bestiaryEnemyPrefab, parent);
		EnemyType enemyType2 = default(EnemyType);
		bool ignoreAngle = default(bool);
		AddEnemyObjectToHierarchy(gameObject, variants, positionIndex, enemyType2, ignoreAngle);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		bool flag = ((UnityEngine.Object)component).m_CachedPtr == (IntPtr)0;
		Vector3 value = default(Vector3);
		Transform.set_localScale_Injected(((UnityEngine.Object)component).m_CachedPtr, ref value);
	}

	private void CreateTPDeath(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
	{
		GameObject bestiaryEnemyPrefab = _bestiaryFactory.GetBestiaryEnemyPrefab(enemyType);
		Transform parent = _EnvironmentBackground.transform;
		GameObject enemyObject = UnityEngine.Object.Instantiate(bestiaryEnemyPrefab, parent);
		EnemyType enemyType2 = default(EnemyType);
		bool ignoreAngle = default(bool);
		AddEnemyObjectToHierarchy(enemyObject, variants, positionIndex, enemyType2, ignoreAngle);
	}

	private void CreateDoppelganger(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
	{
		//IL_0028: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_1226: Expected O, but got I
		//IL_00ec: Expected O, but got I
		//IL_1255: Expected O, but got I
		//IL_0156: Expected O, but got I
		//IL_127d: Expected O, but got I
		//IL_01c0: Expected O, but got I
		//IL_12a5: Expected O, but got I
		//IL_022a: Expected O, but got I
		//IL_12cd: Expected O, but got I
		//IL_0294: Expected O, but got I
		//IL_12f5: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_131d: Expected O, but got I
		//IL_0368: Expected O, but got I
		//IL_1345: Expected O, but got I
		//IL_03d2: Expected O, but got I
		//IL_136d: Expected O, but got I
		//IL_043c: Expected O, but got I
		//IL_1395: Expected O, but got I
		//IL_04a6: Expected O, but got I
		//IL_13bd: Expected O, but got I
		//IL_0510: Expected O, but got I
		//IL_13e5: Expected O, but got I
		//IL_057a: Expected O, but got I
		//IL_140d: Expected O, but got I
		//IL_05e4: Expected O, but got I
		//IL_1435: Expected O, but got I
		//IL_064e: Expected O, but got I
		//IL_145d: Expected O, but got I
		//IL_06b8: Expected O, but got I
		//IL_1485: Expected O, but got I
		//IL_0722: Expected O, but got I
		//IL_14ad: Expected O, but got I
		//IL_078c: Expected O, but got I
		//IL_14d5: Expected O, but got I
		//IL_07f6: Expected O, but got I
		//IL_14fd: Expected O, but got I
		//IL_0860: Expected O, but got I
		//IL_1525: Expected O, but got I
		//IL_08ca: Expected O, but got I
		//IL_154d: Expected O, but got I
		//IL_0934: Expected O, but got I
		//IL_1575: Expected O, but got I
		//IL_099e: Expected O, but got I
		//IL_159d: Expected O, but got I
		//IL_0a08: Expected O, but got I
		//IL_15c5: Expected O, but got I
		//IL_0a72: Expected O, but got I
		//IL_15ed: Expected O, but got I
		//IL_0adc: Expected O, but got I
		//IL_1615: Expected O, but got I
		//IL_0b46: Expected O, but got I
		//IL_163d: Expected O, but got I
		//IL_0bb0: Expected O, but got I
		//IL_1665: Expected O, but got I
		//IL_0c1a: Expected O, but got I
		//IL_168d: Expected O, but got I
		//IL_0c84: Expected O, but got I
		//IL_16b5: Expected O, but got I
		//IL_0cee: Expected O, but got I
		//IL_16dd: Expected O, but got I
		//IL_0d58: Expected O, but got I
		//IL_1705: Expected O, but got I
		//IL_0dc2: Expected O, but got I
		//IL_172d: Expected O, but got I
		//IL_0e2c: Expected O, but got I
		//IL_1755: Expected O, but got I
		//IL_0e96: Expected O, but got I
		//IL_177d: Expected O, but got I
		//IL_0f00: Expected O, but got I
		//IL_17a5: Expected O, but got I
		//IL_0f6b: Expected O, but got I
		//IL_0fe6: Expected O, but got I
		//IL_1041: Expected O, but got I
		//IL_1056: Expected O, but got I
		//IL_1071: Expected O, but got I
		//IL_17d8: Expected O, but got I
		//IL_17e8: Expected O, but got I
		//IL_1802: Expected O, but got I
		//IL_1816: Expected O, but got I
		//IL_1826: Expected O, but got I
		//IL_1105: Expected O, but got I
		//IL_11f3: Expected I4, but got O
		List<CharacterType> list = new List<CharacterType>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rdx_v5+18]");
		if (num >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)222);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj2 = (nint)0 + (nint)1;
			_ = 222;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ rdx_v7+18]");
		if (num2 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)234);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj4 = (nint)0 + (nint)1;
			_ = 234;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ rdx_v9+18]");
		if (num3 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)239);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj6 = (nint)0 + (nint)1;
			_ = 239;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v11+18]");
		if (num4 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)241);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj8 = (nint)0 + (nint)1;
			_ = 241;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ rdx_v13+18]");
		if (num5 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)232);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj10 = (nint)0 + (nint)1;
			_ = 232;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rdx_v15+18]");
		if (num6 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)221);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj12 = (nint)0 + (nint)1;
			_ = 221;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rdx_v17+18]");
		if (num7 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)229);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj14 = (nint)0 + (nint)1;
			_ = 229;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ rdx_v19+18]");
		if (num8 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)219);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj16 = (nint)0 + (nint)1;
			_ = 219;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num9 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rdx_v21+18]");
		if (num9 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)213);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj18 = (nint)0 + (nint)1;
			_ = 213;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ rdx_v23+18]");
		if (num10 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)218);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj20 = (nint)0 + (nint)1;
			_ = 218;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num11 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rdx_v25+18]");
		if (num11 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)217);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj22 = (nint)0 + (nint)1;
			_ = 217;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num12 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rdx_v27+18]");
		if (num12 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)211);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj24 = (nint)0 + (nint)1;
			_ = 211;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num13 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ rdx_v29+18]");
		if (num13 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)214);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj26 = (nint)0 + (nint)1;
			_ = 214;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num14 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ rdx_v31+18]");
		if (num14 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)202);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj28 = (nint)0 + (nint)1;
			_ = 202;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rdx_v33+18]");
		if (num15 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)224);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj30 = (nint)0 + (nint)1;
			_ = 224;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rdx_v35+18]");
		if (num16 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)238);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj32 = (nint)0 + (nint)1;
			_ = 238;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num17 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rdx_v37+18]");
		if (num17 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)240);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj34 = (nint)0 + (nint)1;
			_ = 240;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num18 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ rdx_v39+18]");
		if (num18 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)247);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj36 = (nint)0 + (nint)1;
			_ = 247;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rdx_v41+18]");
		if (num19 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)231);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj38 = (nint)0 + (nint)1;
			_ = 231;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj39 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num20 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v43+18]");
		if (num20 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)248);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj40 = (nint)0 + (nint)1;
			_ = 248;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num21 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ rdx_v45+18]");
		if (num21 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)249);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj42 = (nint)0 + (nint)1;
			_ = 249;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj43 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num22 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rdx_v47+18]");
		if (num22 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)215);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj44 = (nint)0 + (nint)1;
			_ = 215;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj45 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num23 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v49+18]");
		if (num23 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)209);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj46 = (nint)0 + (nint)1;
			_ = 209;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj47 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num24 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ rdx_v51+18]");
		if (num24 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)220);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj48 = (nint)0 + (nint)1;
			_ = 220;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj49 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num25 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ rdx_v53+18]");
		if (num25 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)205);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj50 = (nint)0 + (nint)1;
			_ = 205;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj51 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num26 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ rdx_v55+18]");
		if (num26 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)246);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj52 = (nint)0 + (nint)1;
			_ = 246;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj53 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num27 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ rdx_v57+18]");
		if (num27 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)210);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj54 = (nint)0 + (nint)1;
			_ = 210;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj55 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num28 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ rdx_v59+18]");
		if (num28 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)228);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj56 = (nint)0 + (nint)1;
			_ = 228;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj57 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num29 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rdx_v61+18]");
		if (num29 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)216);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj58 = (nint)0 + (nint)1;
			_ = 216;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj59 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num30 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdx_v63+18]");
		if (num30 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)242);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj60 = (nint)0 + (nint)1;
			_ = 242;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj61 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num31 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ rdx_v65+18]");
		if (num31 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)251);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj62 = (nint)0 + (nint)1;
			_ = 251;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj63 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num32 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rdx_v67+18]");
		if (num32 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)201);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj64 = (nint)0 + (nint)1;
			_ = 201;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj65 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num33 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rdx_v69+18]");
		if (num33 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)250);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj66 = (nint)0 + (nint)1;
			_ = 250;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj67 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num34 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rdx_v71+18]");
		if (num34 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)230);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj68 = (nint)0 + (nint)1;
			_ = 230;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj69 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num35 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ rdx_v73+18]");
		if (num35 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)236);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj70 = (nint)0 + (nint)1;
			_ = 236;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj71 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num36 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rdx_v75+18]");
		if (num36 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)226);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj72 = (nint)0 + (nint)1;
			_ = 226;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
		_ = (nint)0 + (nint)1;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
		object obj73 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		nint num37 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ rdx_v77+18]");
		if (num37 >= 0)
		{
			((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)207);
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			object obj74 = (nint)0 + (nint)1;
			_ = 207;
		}
		list.Add(CharacterType.TP_BARLOWE);
		Dictionary<CharacterType, List<CharacterData>> convertedCharacterData = _data.GetConvertedCharacterData();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		int num38 = UnityEngine.Random.Range(0, 0);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
		if ((nint)num38 < (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rax_v2 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj75 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rdx_v82+20+v186 @ rax_v49 (System.Int32)*4]");
			object obj76 = ((Dictionary<System.Int32Enum, object>)(object)convertedCharacterData).get_Item((System.Int32Enum)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v51 (System.Object)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v51 (System.Object)+10]");
				object obj77 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rdi_v5+20]");
				object obj78 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v6+48]");
				bool flag = ((string)0).Contains("w01");
				bool flag2 = !flag;
				string prefixOverride = "_i";
				if (!flag2)
				{
					prefixOverride = "_w";
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				object obj79 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2696 @ rax_v53+B8]");
				object newValue = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v6+48]");
				string text = ((string)0).Replace("_w01.png", (string)newValue);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
				object obj80 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v234 @ rcx_v88+B8]");
				object newValue2 = 0;
				string frameName = text.Replace("_i01.png", (string)newValue2);
				EnemyData data = default(EnemyData);
				EnemyAnimDisplayData enemyAnimDisplayData = new EnemyAnimDisplayData(data, enemyType, frameName);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v6+68]");
				enemyAnimDisplayData.IdleFrameCount = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rdi_v6+40]");
				enemyAnimDisplayData.TextureName = (string)0;
				List<List<List<Vector2>>> allPositions = _allPositions;
				if (allPositions._size > 0)
				{
					List<List<Vector2>>[] items = allPositions._items;
					List<List<Vector2>> list2 = items[0];
					if (list2._size > 0)
					{
						List<Vector2>[] items2 = list2._items;
						List<Vector2> list3 = items2[0];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v61 (System.Collections.Generic.List`1<UnityEngine.Vector2>)+18]");
						if ((nint)0 > (nint)0)
						{
							Vector2 randomPosition = default(Vector2);
							CreateEnemyAnimation(enemyAnimDisplayData, randomPosition, prefixOverride, (byte)(int)enemyData != 0);
							return;
						}
					}
				}
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		throw new IndexOutOfRangeException();
	}

	public BestiaryPage()
	{
		List<GameObject> spawnedList = new List<GameObject>();
		_spawnedList = spawnedList;
		_spawnedEnemies = new List<GameObject>();
		_allPositions = new List<List<List<Vector2>>>();
		base._002Ector();
	}
}
