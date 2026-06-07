using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.App.Framework;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class BestiaryPage : BaseUIPage
	{
		private class EnemyAnimDisplayData
		{
			public int IdleFrameCount;

			public string TextureName;

			public float? Scale;

			public uint? Tint;

			public float Alpha;

			public EnemyType Type;

			public string FrameName;

			public EnemyAnimDisplayData(EnemyData data, EnemyType type, string frameName)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWaitAndGenerateSliderNavigation_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BestiaryPage _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitAndGenerateSliderNavigation_003Ed__60(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		private TextMeshProUGUI _Title;

		[FormerlySerializedAs("_Name")]
		[SerializeField]
		private TextMeshProUGUI _KillCount;

		[SerializeField]
		private TextMeshProUGUI _QuestionMarks;

		[SerializeField]
		private TextMeshProUGUI _Resistances;

		[SerializeField]
		private TextMeshProUGUI _Skills;

		[SerializeField]
		private TextMeshProUGUI _FoundIn;

		[SerializeField]
		private TextMeshProUGUI _HP;

		[SerializeField]
		private TextMeshProUGUI _Power;

		[SerializeField]
		private TextMeshProUGUI _Speed;

		[SerializeField]
		private Image _EnvironmentBackground;

		[SerializeField]
		private Image _EnemyNotFoundImage;

		[SerializeField]
		private GameObject _EnemyIconPrefab;

		[SerializeField]
		private GameObject _EnemyItemPrefab;

		[SerializeField]
		private RectTransform _EnemyListContainer;

		[SerializeField]
		private PositionInsideRectUI _EnemyContainer;

		[SerializeField]
		private RectTransform _InfoContent;

		[SerializeField]
		private FakeSliderHandleController _InfoSlider;

		[SerializeField]
		private ScrollEnhancer _InfoScrollEnhancer;

		[SerializeField]
		private Image _Frame;

		[SerializeField]
		private Mask _InfoMask;

		[SerializeField]
		private GameObject _UndeadStars1Prefab;

		[SerializeField]
		private GameObject _UndeadStars2Prefab;

		[SerializeField]
		private GameObject _UndeadStars3Prefab;

		[SerializeField]
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

		[Inject]
		private void Construct(DataManager data, SignalBus signal, PlayerOptions playerOptions, BestiaryFactory bestiaryFactory, AdventureManager adventureManager)
		{
		}

		protected override void Awake()
		{
		}

		public void SetInfoPanel(EnemyType t, EnemyData dat, EnemyItemUI item)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitAndGenerateSliderNavigation_003Ed__60))]
		private IEnumerator WaitAndGenerateSliderNavigation()
		{
			return null;
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		protected override void OnHideStart(GameObject g)
		{
		}

		private void NavigationWrap()
		{
		}

		private bool GetMusicData(BgmType bgmType, out MusicData musicData)
		{
			musicData = null;
			return false;
		}

		private void PlaySoundTrack()
		{
		}

		private void Populate()
		{
		}

		private void SetDescription(EnemyData dat, EnemyType type)
		{
		}

		private void SetFoundIn(EnemyData dat)
		{
		}

		private void SetStats(EnemyData ed, EnemyType type)
		{
		}

		private void SetResistances(EnemyData dat, EnemyType type)
		{
		}

		private void SetSkills(EnemyData dat, EnemyType type)
		{
		}

		private void SetBackground(EnemyData dat, EnemyType type)
		{
		}

		private static List<Sprite> GetAnimationForEnemy(EnemyData d, int index)
		{
			return null;
		}

		private void InitPositions()
		{
		}

		private void ClearExistingEnemyAnims()
		{
		}

		private void SpawnEnemyAnimations(EnemyData enemyData, EnemyType enemyType)
		{
		}

		private List<EnemyAnimDisplayData> BuildEnemyDisplayList(EnemyData enemyData, EnemyType enemyType)
		{
			return null;
		}

		private void CreateEnemyAnimation(EnemyAnimDisplayData cData, Vector2 randomPosition, string prefixOverride = "_i", bool flipX = false)
		{
		}

		private static void UpdateEnemyDisplay(EnemyAnimDisplayData cData, Image enemyImage, GameObject enemyObject)
		{
		}

		private void ApplyAnimationToEnemy(GameObject enemyObject, List<Sprite> sprites, EnemyData enemyData)
		{
		}

		private void AddEnemyObjectToHierarchy(GameObject enemyObject, List<Vector2> variants, int positionIndex, EnemyType enemyType, bool ignoreAngle = false)
		{
		}

		private GameObject CreateFactoryPrefab(List<Vector2> variants, int positionIndex, EnemyType enemyType, bool ignoreAngle = false)
		{
			return null;
		}

		private void CreateDirecter(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
		{
		}

		private void CreateTrinacria(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
		{
		}

		private void CreateSketamari(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
		{
		}

		private void CreateCrabbino(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
		{
		}

		private void CreateMask(EnemyType enemyType, EnemyType maskType, EnemyData data, List<Vector2> variants, int positionIndex)
		{
		}

		private void CreateAlias(EnemyType enemyType, EnemyData enemyData)
		{
		}

		private void CreateGASHADOKURO(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
		{
		}

		private void CreateOROCHIMARIO(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
		{
		}

		private void CreateCosmicEgg(List<Vector2> variants, int positionIndex, EnemyType enemyType)
		{
		}

		private void CreateRedBlue(EnemyData enemyData, EnemyType enemyType)
		{
		}

		private void CreateUndeadStars(EnemyData enemyData, EnemyType enemyType)
		{
		}

		private void CreateBigFuzz(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
		{
		}

		private void CreateTPDeath(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
		{
		}

		private void CreateDoppelganger(List<Vector2> variants, int positionIndex, EnemyType enemyType, EnemyData enemyData)
		{
		}
	}
}
