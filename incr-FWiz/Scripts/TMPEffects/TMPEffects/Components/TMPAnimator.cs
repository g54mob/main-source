using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Databases;
using TMPEffects.Databases.AnimationDatabase;
using TMPEffects.EffectCategories;
using TMPEffects.Modifiers;
using TMPEffects.SerializedCollections;
using TMPEffects.TMPAnimations.Animations;
using TMPEffects.TMPAnimations.HideAnimations;
using TMPEffects.TMPAnimations.ShowAnimations;
using TMPEffects.Tags.Collections;
using TMPEffects.TextProcessing;
using TMPro;
using UnityEngine;

namespace TMPEffects.Components
{
	[HelpURL("https://tmpeffects.luca3317.dev/manual/tmpanimator.html")]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(TMP_Text))]
	public class TMPAnimator : TMPEffectComponent
	{
		public delegate void OnCharacterAnimatedEventHandler(CharData cData);

		public const char ANIMATION_PREFIX = '\0';

		public const char SHOW_ANIMATION_PREFIX = '+';

		public const char HIDE_ANIMATION_PREFIX = '-';

		[SerializeField]
		private TMPAnimationDatabase database;

		[SerializeField]
		private AnimatorContext context;

		[NonSerialized]
		private ReadOnlyAnimatorContext readonlyContext;

		[SerializeField]
		private UpdateFrom updateFrom;

		[SerializeField]
		private bool animateOnStart;

		[SerializeField]
		private bool animationsOverride;

		[SerializeField]
		private List<string> defaultAnimationsStrings;

		[SerializeField]
		private List<string> defaultShowAnimationsStrings;

		[SerializeField]
		private List<string> defaultHideAnimationsStrings;

		[SerializeField]
		private string excludedCharacters;

		[SerializeField]
		private string excludedCharactersShow;

		[SerializeField]
		private string excludedCharactersHide;

		[SerializeField]
		private bool excludePunctuation;

		[SerializeField]
		private bool excludePunctuationShow;

		[SerializeField]
		private bool excludePunctuationHide;

		[SerializeField]
		private TMPSceneKeywordDatabaseBase sceneKeywordDatabase;

		[SerializeField]
		private TMPKeywordDatabaseBase keywordDatabase;

		[SerializeField]
		private SerializedObservableDictionary<string, TMPSceneAnimation> sceneAnimations;

		[SerializeField]
		private SerializedObservableDictionary<string, TMPSceneShowAnimation> sceneShowAnimations;

		[SerializeField]
		private SerializedObservableDictionary<string, TMPSceneHideAnimation> sceneHideAnimations;

		[NonSerialized]
		private TagProcessorManager processors;

		[NonSerialized]
		private TagCollectionManager<TMPAnimationCategory> tags;

		[NonSerialized]
		private bool isAnimating;

		[NonSerialized]
		private bool ignoreVisibilityChanges;

		[NonSerialized]
		private TMPAnimationCategory basicCategory;

		[NonSerialized]
		private TMPAnimationCategory showCategory;

		[NonSerialized]
		private TMPAnimationCategory hideCategory;

		[NonSerialized]
		private KeywordDatabaseWrapper keywordDatabaseWrapper;

		[NonSerialized]
		private AnimationDatabase<TMPBasicAnimationDatabase, TMPSceneAnimation> basicDatabase;

		[NonSerialized]
		private AnimationDatabase<TMPShowAnimationDatabase, TMPSceneShowAnimation> showDatabase;

		[NonSerialized]
		private AnimationDatabase<TMPHideAnimationDatabase, TMPSceneHideAnimation> hideDatabase;

		[NonSerialized]
		private AnimationDatabase<TMPAnimationDatabase, TMPSceneAnimation> mainDatabaseWrapper;

		[NonSerialized]
		private CachedCollection<CachedAnimation> basic;

		[NonSerialized]
		private CachedCollection<CachedAnimation> show;

		[NonSerialized]
		private CachedCollection<CachedAnimation> hide;

		[NonSerialized]
		private CachedAnimation dummyShow;

		[NonSerialized]
		private CachedAnimation dummyHide;

		[NonSerialized]
		private List<CachedAnimation> defaultAnimations;

		[NonSerialized]
		private List<CachedAnimation> defaultShowAnimations;

		[NonSerialized]
		private List<CachedAnimation> defaultHideAnimations;

		[NonSerialized]
		private List<float> visibleTimes;

		[NonSerialized]
		private List<float> stateTimes;

		[NonSerialized]
		private object timesIdentifier;

		[NonSerialized]
		private CharDataModifiers state;

		private const string FalseUpdateAnimationsCallWarning = "Called UpdateAnimations while TMPAnimator {0} is set to automatically update from {1}; If you want to manually control the animation updates, set its UpdateFrom property to \"Script\", either through the inspector or through a script using the SetUpdateFrom method.";

		private const string FalseStartStopAnimatingCallWarning = "Called {0} while TMPAnimator {1} is set to manually update from script; If you want the TMPAnimator to automatically update and to use the Start / StopAnimating methods, set its UpdateFrom property to \"Update\", \"LateUpdate\" or \"FixedUpdate\", either through the inspector or through a script using the SetUpdateFrom method.";

		private List<OnCharacterAnimatedEventHandler> handlers;

		private Vector3 bl;

		private Vector3 tl;

		private Vector3 tr;

		private Vector3 br;

		private bool characterResetQueued;

		public IAnimatorContext AnimatorContext => null;

		public bool IsAnimating => false;

		public TMPAnimationDatabase Database => null;

		public ITMPKeywordDatabase KeywordDatabase => null;

		public IDictionary<string, TMPSceneAnimation> SceneAnimations => null;

		public IDictionary<string, TMPSceneShowAnimation> SceneShowAnimations => null;

		public IDictionary<string, TMPSceneHideAnimation> SceneHideAnimations => null;

		public UpdateFrom UpdateFrom => default(UpdateFrom);

		public ITagCollection Tags => null;

		public ITagCollection BasicTags => null;

		public ITagCollection ShowTags => null;

		public ITagCollection HideTags => null;

		public bool AnimateOnStart
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AnimationsOverride
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void UpdateAnimations(float deltaTime)
		{
		}

		public void StartAnimating()
		{
		}

		public void StopAnimating()
		{
		}

		public void ResetAnimations()
		{
		}

		public void SetUpdateFrom(UpdateFrom updateFrom)
		{
		}

		public void SetDatabase(TMPAnimationDatabase database)
		{
		}

		public void SetSceneKeywordDatabase(TMPSceneKeywordDatabase database)
		{
		}

		public void SetKeywordDatabase(TMPKeywordDatabase database)
		{
		}

		public void SetExcludedCharacters(TMPAnimationType type, string str, bool? excludePunctuation = null)
		{
		}

		public void SetExcludedBasicCharacters(string str, bool? excludePunctuation = null)
		{
		}

		public void SetExcludedShowCharacters(string str, bool? excludePunctuation = null)
		{
		}

		public void SetExcludedHideCharacters(string str, bool? excludePunctuation = null)
		{
		}

		public bool IsExcluded(char c, TMPAnimationType type)
		{
			return false;
		}

		public bool IsExcludedBasic(char c)
		{
			return false;
		}

		public bool IsExcludedShow(char c)
		{
			return false;
		}

		public bool IsExcludedHide(char c)
		{
			return false;
		}

		public void ResetTime(float time = 0f)
		{
		}

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void SubscribeToMediator()
		{
		}

		private void UnsubscribeFromMediator()
		{
		}

		private void CreateContext()
		{
		}

		private void PrepareForProcessing()
		{
		}

		private void OnTagCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}

		private void SetDefaultAnimations(TMPAnimationType type)
		{
		}

		private void OnDatabaseChanged()
		{
		}

		private void ReprocessOnDatabaseChange(object sender)
		{
		}

		private void SetDummies()
		{
		}

		private void SetDummyShow()
		{
		}

		private void SetDummyHide()
		{
		}

		private void RecalculateSegmentData(TMPAnimationType type)
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void FixedUpdate()
		{
		}

		private void UpdateAnimations_Impl(float deltaTime)
		{
		}

		public void RegisterPostAnimationHook(OnCharacterAnimatedEventHandler handler)
		{
		}

		public bool UnregisterPostAnimationHook(OnCharacterAnimatedEventHandler handler)
		{
			return false;
		}

		public void QueueCharacterReset()
		{
		}

		private void UpdateCharacterAnimation(CharData cData, float deltaTime, int index, bool updateVertices = true, bool forced = false)
		{
		}

		private bool AnimateCharacter(int index, CharData cData)
		{
			return false;
		}

		private void UpdateCharacterAnimation_Impl(int index)
		{
		}

		private void test()
		{
		}

		private void OnTextChanged_Early(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData)
		{
		}

		private void OnTextChanged_Late(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData, ReadOnlyCollection<VisibilityState> oldVisibilities)
		{
		}

		private void PopulateTimes(bool textContentChanged, IList<CharData> oldCharData)
		{
		}

		private void OnVisibilityStateUpdated(int index, VisibilityState prev)
		{
		}

		private void PostProcessTags()
		{
		}

		private void ResetAllVisible()
		{
		}
	}
}
