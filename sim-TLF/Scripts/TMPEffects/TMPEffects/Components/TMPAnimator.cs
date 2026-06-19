using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Databases;
using TMPEffects.Databases.AnimationDatabase;
using TMPEffects.EffectCategories;
using TMPEffects.Modifiers;
using TMPEffects.SerializedCollections;
using TMPEffects.TMPAnimations;
using TMPEffects.TMPAnimations.Animations;
using TMPEffects.TMPAnimations.HideAnimations;
using TMPEffects.TMPAnimations.ShowAnimations;
using TMPEffects.Tags;
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
		private AnimatorContext context = new AnimatorContext();

		[NonSerialized]
		private ReadOnlyAnimatorContext readonlyContext;

		[SerializeField]
		private UpdateFrom updateFrom;

		[SerializeField]
		private bool animateOnStart = true;

		[SerializeField]
		private bool animationsOverride;

		[SerializeField]
		private List<string> defaultAnimationsStrings = new List<string>();

		[SerializeField]
		private List<string> defaultShowAnimationsStrings = new List<string>();

		[SerializeField]
		private List<string> defaultHideAnimationsStrings = new List<string>();

		[SerializeField]
		private string excludedCharacters = "";

		[SerializeField]
		private string excludedCharactersShow = "";

		[SerializeField]
		private string excludedCharactersHide = "";

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
		private SerializedObservableDictionary<string, TMPSceneAnimation> sceneAnimations = new SerializedObservableDictionary<string, TMPSceneAnimation>();

		[SerializeField]
		private SerializedObservableDictionary<string, TMPSceneShowAnimation> sceneShowAnimations = new SerializedObservableDictionary<string, TMPSceneShowAnimation>();

		[SerializeField]
		private SerializedObservableDictionary<string, TMPSceneHideAnimation> sceneHideAnimations = new SerializedObservableDictionary<string, TMPSceneHideAnimation>();

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
		private List<CachedAnimation> defaultAnimations = new List<CachedAnimation>();

		[NonSerialized]
		private List<CachedAnimation> defaultShowAnimations = new List<CachedAnimation>();

		[NonSerialized]
		private List<CachedAnimation> defaultHideAnimations = new List<CachedAnimation>();

		[NonSerialized]
		private List<float> visibleTimes = new List<float>();

		[NonSerialized]
		private List<float> stateTimes = new List<float>();

		[NonSerialized]
		private object timesIdentifier;

		[NonSerialized]
		private CharDataModifiers state = new CharDataModifiers();

		private const string FalseUpdateAnimationsCallWarning = "Called UpdateAnimations while TMPAnimator {0} is set to automatically update from {1}; If you want to manually control the animation updates, set its UpdateFrom property to \"Script\", either through the inspector or through a script using the SetUpdateFrom method.";

		private const string FalseStartStopAnimatingCallWarning = "Called {0} while TMPAnimator {1} is set to manually update from script; If you want the TMPAnimator to automatically update and to use the Start / StopAnimating methods, set its UpdateFrom property to \"Update\", \"LateUpdate\" or \"FixedUpdate\", either through the inspector or through a script using the SetUpdateFrom method.";

		private List<OnCharacterAnimatedEventHandler> handlers = new List<OnCharacterAnimatedEventHandler>();

		private Vector3 bl;

		private Vector3 tl;

		private Vector3 tr;

		private Vector3 br;

		private bool characterResetQueued;

		public IAnimatorContext AnimatorContext => readonlyContext;

		public bool IsAnimating
		{
			get
			{
				if (base.isActiveAndEnabled)
				{
					if (updateFrom != UpdateFrom.Script)
					{
						return isAnimating;
					}
					return true;
				}
				return false;
			}
		}

		public TMPAnimationDatabase Database => database;

		public ITMPKeywordDatabase KeywordDatabase => keywordDatabaseWrapper?.Database;

		public IDictionary<string, TMPSceneAnimation> SceneAnimations => sceneAnimations;

		public IDictionary<string, TMPSceneShowAnimation> SceneShowAnimations => sceneShowAnimations;

		public IDictionary<string, TMPSceneHideAnimation> SceneHideAnimations => sceneHideAnimations;

		public UpdateFrom UpdateFrom => updateFrom;

		public ITagCollection Tags => tags;

		public ITagCollection BasicTags => tags?[basicCategory];

		public ITagCollection ShowTags => tags?[showCategory];

		public ITagCollection HideTags => tags?[hideCategory];

		public bool AnimateOnStart
		{
			get
			{
				return animateOnStart;
			}
			set
			{
				animateOnStart = value;
			}
		}

		public bool AnimationsOverride
		{
			get
			{
				return animationsOverride;
			}
			set
			{
				animationsOverride = value;
			}
		}

		public void UpdateAnimations(float deltaTime)
		{
			if (!base.isActiveAndEnabled || base.Mediator == null)
			{
				throw new InvalidOperationException("Animator is not enabled!");
			}
			if (updateFrom != UpdateFrom.Script)
			{
				throw new InvalidOperationException($"Called UpdateAnimations while TMPAnimator {base.name} is set to automatically update from {updateFrom.ToString()}; If you want to manually control the animation updates, set its UpdateFrom property to \"Script\", either through the inspector or through a script using the SetUpdateFrom method.");
			}
			UpdateAnimations_Impl(deltaTime);
		}

		public void StartAnimating()
		{
			if (!base.isActiveAndEnabled || base.Mediator == null)
			{
				throw new InvalidOperationException("Animator is not enabled!");
			}
			if (updateFrom == UpdateFrom.Script)
			{
				throw new InvalidOperationException($"Called {base.name} while TMPAnimator {updateFrom.ToString()} is set to manually update from script; If you want the TMPAnimator to automatically update and to use the Start / StopAnimating methods, set its UpdateFrom property to \"Update\", \"LateUpdate\" or \"FixedUpdate\", either through the inspector or through a script using the SetUpdateFrom method.");
			}
			isAnimating = true;
		}

		public void StopAnimating()
		{
			if (!base.isActiveAndEnabled || base.Mediator == null)
			{
				throw new InvalidOperationException("Animator is not enabled!");
			}
			if (updateFrom == UpdateFrom.Script)
			{
				throw new InvalidOperationException($"Called {base.name} while TMPAnimator {updateFrom.ToString()} is set to manually update from script; If you want the TMPAnimator to automatically update and to use the Start / StopAnimating methods, set its UpdateFrom property to \"Update\", \"LateUpdate\" or \"FixedUpdate\", either through the inspector or through a script using the SetUpdateFrom method.");
			}
			isAnimating = false;
			for (int i = 0; i < base.Mediator?.CharData.Count; i++)
			{
				switch (base.Mediator.VisibilityStates[i])
				{
				case VisibilityState.Showing:
					base.Mediator.SetVisibilityState(i, VisibilityState.Shown);
					break;
				case VisibilityState.Hiding:
					base.Mediator.SetVisibilityState(i, VisibilityState.Hidden);
					break;
				}
			}
			ResetAllVisible();
		}

		public void ResetAnimations()
		{
			ResetAllVisible();
		}

		public void SetUpdateFrom(UpdateFrom updateFrom)
		{
			if (isAnimating)
			{
				StopAnimating();
			}
			this.updateFrom = updateFrom;
		}

		public void SetDatabase(TMPAnimationDatabase database)
		{
			this.database = database;
			OnDatabaseChanged();
		}

		public void SetSceneKeywordDatabase(TMPSceneKeywordDatabase database)
		{
			sceneKeywordDatabase = database;
			OnDatabaseChanged();
		}

		public void SetKeywordDatabase(TMPKeywordDatabase database)
		{
			keywordDatabase = database;
			OnDatabaseChanged();
		}

		public void SetExcludedCharacters(TMPAnimationType type, string str, bool? excludePunctuation = null)
		{
			switch (type)
			{
			case TMPAnimationType.Basic:
				SetExcludedBasicCharacters(str, excludePunctuation);
				break;
			case TMPAnimationType.Show:
				SetExcludedShowCharacters(str, excludePunctuation);
				break;
			case TMPAnimationType.Hide:
				SetExcludedHideCharacters(str, excludePunctuation);
				break;
			default:
				throw new ArgumentException();
			}
		}

		public void SetExcludedBasicCharacters(string str, bool? excludePunctuation = null)
		{
			excludedCharacters = str;
			if (excludePunctuation.HasValue)
			{
				this.excludePunctuation = excludePunctuation.Value;
			}
			if (base.Mediator != null)
			{
				RecalculateSegmentData(TMPAnimationType.Basic);
				QueueCharacterReset();
			}
		}

		public void SetExcludedShowCharacters(string str, bool? excludePunctuation = null)
		{
			excludedCharactersShow = str;
			if (excludePunctuation.HasValue)
			{
				excludePunctuationShow = excludePunctuation.Value;
			}
			if (base.Mediator != null)
			{
				RecalculateSegmentData(TMPAnimationType.Show);
				QueueCharacterReset();
			}
		}

		public void SetExcludedHideCharacters(string str, bool? excludePunctuation = null)
		{
			excludedCharactersHide = str;
			if (excludePunctuation.HasValue)
			{
				excludePunctuationHide = excludePunctuation.Value;
			}
			if (base.Mediator != null)
			{
				RecalculateSegmentData(TMPAnimationType.Hide);
				QueueCharacterReset();
			}
		}

		public bool IsExcluded(char c, TMPAnimationType type)
		{
			return type switch
			{
				TMPAnimationType.Basic => IsExcludedBasic(c), 
				TMPAnimationType.Show => IsExcludedShow(c), 
				TMPAnimationType.Hide => IsExcludedHide(c), 
				_ => throw new ArgumentException(), 
			};
		}

		public bool IsExcludedBasic(char c)
		{
			if (!excludePunctuation || !char.IsPunctuation(c))
			{
				return excludedCharacters.Contains(c);
			}
			return true;
		}

		public bool IsExcludedShow(char c)
		{
			if (!excludePunctuationShow || !char.IsPunctuation(c))
			{
				return excludedCharactersShow.Contains(c);
			}
			return true;
		}

		public bool IsExcludedHide(char c)
		{
			if (!excludePunctuationHide || !char.IsPunctuation(c))
			{
				return excludedCharactersHide.Contains(c);
			}
			return true;
		}

		public void ResetTime(float time = 0f)
		{
			if (time < 0f)
			{
				throw new ArgumentOutOfRangeException("time");
			}
			if (base.Mediator != null)
			{
				context.passed = time;
				for (int i = 0; i < stateTimes.Count; i++)
				{
					stateTimes[i] = time;
				}
				for (int j = 0; j < visibleTimes.Count; j++)
				{
					visibleTimes[j] = time;
				}
			}
		}

		private void OnEnable()
		{
			UpdateMediator();
			CreateContext();
			PrepareForProcessing();
			SetDummies();
			SubscribeToMediator();
			base.Mediator.ForceReprocess();
		}

		private void Start()
		{
			if (animateOnStart && updateFrom != UpdateFrom.Script)
			{
				StartAnimating();
			}
		}

		private void OnDisable()
		{
			if (base.Mediator != null)
			{
				processors.UnregisterFrom(base.Mediator.Processor);
				basicDatabase?.Dispose();
				showDatabase?.Dispose();
				hideDatabase?.Dispose();
				mainDatabaseWrapper?.Dispose();
				keywordDatabaseWrapper?.Dispose();
				UnsubscribeFromMediator();
			}
		}

		private void SubscribeToMediator()
		{
			timesIdentifier = new object();
			if (!base.Mediator.RegisterVisibilityProcessor(timesIdentifier))
			{
				UnityEngine.Debug.LogError("Could not register as visibility processor!");
			}
			base.Mediator.TextChanged_Late += OnTextChanged_Late;
			base.Mediator.TextChanged_Early += OnTextChanged_Early;
			base.Mediator.VisibilityStateUpdated += OnVisibilityStateUpdated;
			OnSubscribeToMediator();
		}

		private void UnsubscribeFromMediator()
		{
			base.Mediator.TextChanged_Late -= OnTextChanged_Late;
			base.Mediator.TextChanged_Early -= OnTextChanged_Early;
			base.Mediator.VisibilityStateUpdated -= OnVisibilityStateUpdated;
			if (!base.Mediator.UnregisterVisibilityProcessor(timesIdentifier))
			{
				UnityEngine.Debug.LogError("Could not unregister as visibility processor!");
			}
			OnUnsubscribeFromMediator();
			TMP_Text tMP_Text = base.Mediator.Text;
			FreeMediator();
			if (tMP_Text != null)
			{
				tMP_Text.ForceMeshUpdate(ignoreActiveState: false, forceTextReparsing: true);
			}
		}

		private void CreateContext()
		{
			context._VisibleTime = (int i) => visibleTimes[i];
			context._StateTime = (int i) => stateTimes[i];
			context.Animator = this;
			ResetTime();
			readonlyContext = new ReadOnlyAnimatorContext(context);
		}

		private void PrepareForProcessing()
		{
			basicDatabase?.Dispose();
			showDatabase?.Dispose();
			hideDatabase?.Dispose();
			mainDatabaseWrapper?.Dispose();
			keywordDatabaseWrapper?.Dispose();
			basicDatabase = new AnimationDatabase<TMPBasicAnimationDatabase, TMPSceneAnimation>((database == null) ? null : ((database.BasicAnimationDatabase == null) ? null : database.BasicAnimationDatabase), sceneAnimations);
			showDatabase = new AnimationDatabase<TMPShowAnimationDatabase, TMPSceneShowAnimation>((database == null) ? null : ((database.ShowAnimationDatabase == null) ? null : database.ShowAnimationDatabase), sceneShowAnimations);
			hideDatabase = new AnimationDatabase<TMPHideAnimationDatabase, TMPSceneHideAnimation>((database == null) ? null : ((database.HideAnimationDatabase == null) ? null : database.HideAnimationDatabase), sceneHideAnimations);
			mainDatabaseWrapper = new AnimationDatabase<TMPAnimationDatabase, TMPSceneAnimation>((database == null) ? null : database, null);
			keywordDatabaseWrapper = new KeywordDatabaseWrapper(sceneKeywordDatabase, keywordDatabase, TMPEffectsSettings.GlobalKeywordDatabase);
			basicDatabase.AddAnimation("sprite", new SpriteAnimation());
			basicDatabase.ObjectChanged += ReprocessOnDatabaseChange;
			showDatabase.ObjectChanged += ReprocessOnDatabaseChange;
			hideDatabase.ObjectChanged += ReprocessOnDatabaseChange;
			mainDatabaseWrapper.ObjectChanged += ReprocessOnDatabaseChange;
			keywordDatabaseWrapper.ObjectChanged += ReprocessOnDatabaseChange;
			basicCategory = new TMPAnimationCategory('\0', basicDatabase, keywordDatabaseWrapper.Database);
			showCategory = new TMPAnimationCategory('+', showDatabase, keywordDatabaseWrapper.Database);
			hideCategory = new TMPAnimationCategory('-', hideDatabase, keywordDatabaseWrapper.Database);
			if (processors == null)
			{
				processors = new TagProcessorManager();
			}
			processors.UnregisterFrom(base.Mediator.Processor);
			processors.Clear();
			processors.AddProcessor(basicCategory.Prefix, new TagProcessor(basicCategory));
			processors.AddProcessor(showCategory.Prefix, new TagProcessor(showCategory));
			processors.AddProcessor(hideCategory.Prefix, new TagProcessor(hideCategory));
			processors.RegisterTo(base.Mediator.Processor);
		}

		private void OnTagCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			ResetAllVisible();
		}

		private void SetDefaultAnimations(TMPAnimationType type)
		{
			ITMPEffectDatabase<ITMPAnimation> iTMPEffectDatabase;
			List<CachedAnimation> list;
			AnimationCacher animationCacher;
			List<string> list2;
			switch (type)
			{
			case TMPAnimationType.Basic:
				iTMPEffectDatabase = basicDatabase;
				list = defaultAnimations;
				animationCacher = new AnimationCacher(iTMPEffectDatabase, state, readonlyContext, base.Mediator.CharData, (char x) => !IsExcludedBasic(x), keywordDatabaseWrapper.Database);
				list2 = defaultAnimationsStrings;
				QueueCharacterReset();
				break;
			case TMPAnimationType.Show:
				iTMPEffectDatabase = showDatabase;
				list = defaultShowAnimations;
				animationCacher = new AnimationCacher(iTMPEffectDatabase, state, readonlyContext, base.Mediator.CharData, (char x) => !IsExcludedShow(x), keywordDatabaseWrapper.Database);
				list2 = defaultShowAnimationsStrings;
				break;
			case TMPAnimationType.Hide:
				iTMPEffectDatabase = hideDatabase;
				list = defaultHideAnimations;
				animationCacher = new AnimationCacher(iTMPEffectDatabase, state, readonlyContext, base.Mediator.CharData, (char x) => !IsExcludedHide(x), keywordDatabaseWrapper.Database);
				list2 = defaultHideAnimationsStrings;
				break;
			default:
				throw new ArgumentException("type");
			}
			list.Clear();
			ParsingUtility.TagInfo tagInfo = new ParsingUtility.TagInfo();
			for (int num = 0; num < list2.Count; num++)
			{
				string text = list2[num];
				if (string.IsNullOrWhiteSpace(text))
				{
					continue;
				}
				text = ((text.Trim()[0] == '<') ? text : ("<" + text + ">"));
				ITMPAnimation effect;
				if (ParsingUtility.TryParseTag(text, 0, text.Length - 1, ref tagInfo, ParsingUtility.TagType.Open) && iTMPEffectDatabase.ContainsEffect(tagInfo.name) && (effect = iTMPEffectDatabase.GetEffect(tagInfo.name)) != null)
				{
					Dictionary<string, string> tagParametersDict = ParsingUtility.GetTagParametersDict(text);
					if (effect.ValidateParameters(tagParametersDict, keywordDatabaseWrapper?.Database))
					{
						list.Add(animationCacher.CacheTag(new TMPEffectTag(tagInfo.name, tagInfo.prefix, tagParametersDict), new TMPEffectTagIndices(0, -1, 0)));
					}
				}
			}
		}

		private void OnDatabaseChanged()
		{
			if (base.Mediator != null)
			{
				PrepareForProcessing();
				base.Mediator.ForceReprocess();
			}
		}

		private void ReprocessOnDatabaseChange(object sender)
		{
			OnDatabaseChanged();
		}

		private void SetDummies()
		{
			SetDummyShow();
			SetDummyHide();
		}

		private void SetDummyShow()
		{
			TMPEffectTag tMPEffectTag = new TMPEffectTag("Dummy Show Animation", ' ', null);
			AnimationCacher animationCacher = new AnimationCacher(new DummyDatabase("Dummy Show Animation", ScriptableObject.CreateInstance<DummyShowAnimation>()), state, readonlyContext, base.Mediator.CharData, (char x) => !IsExcludedShow(x), keywordDatabaseWrapper.Database);
			dummyShow = animationCacher.CacheTag(tMPEffectTag, new TMPEffectTagIndices(0, -1, 0));
		}

		private void SetDummyHide()
		{
			TMPEffectTag tMPEffectTag = new TMPEffectTag("Dummy Hide Animation", ' ', null);
			AnimationCacher animationCacher = new AnimationCacher(new DummyDatabase("Dummy Hide Animation", ScriptableObject.CreateInstance<DummyHideAnimation>()), state, readonlyContext, base.Mediator.CharData, (char x) => !IsExcludedHide(x), keywordDatabaseWrapper.Database);
			dummyHide = animationCacher.CacheTag(tMPEffectTag, new TMPEffectTagIndices(0, -1, 0));
		}

		private void RecalculateSegmentData(TMPAnimationType type)
		{
			if (base.Mediator == null)
			{
				return;
			}
			switch (type)
			{
			case TMPAnimationType.Basic:
			{
				foreach (CachedAnimation item in basic)
				{
					item.context.SegmentData = new SegmentData(item.Indices, base.Mediator.CharData, (char c) => !IsExcludedBasic(c));
				}
				break;
			}
			case TMPAnimationType.Show:
			{
				foreach (CachedAnimation item2 in show)
				{
					item2.context.SegmentData = new SegmentData(item2.Indices, base.Mediator.CharData, (char c) => !IsExcludedShow(c));
				}
				break;
			}
			case TMPAnimationType.Hide:
			{
				foreach (CachedAnimation item3 in hide)
				{
					item3.context.SegmentData = new SegmentData(item3.Indices, base.Mediator.CharData, (char c) => !IsExcludedHide(c));
				}
				break;
			}
			default:
				throw new ArgumentException();
			}
		}

		private void Update()
		{
			if (updateFrom == UpdateFrom.Update && isAnimating)
			{
				UpdateAnimations_Impl(context.UseScaledTime ? Time.deltaTime : Time.unscaledDeltaTime);
			}
		}

		private void LateUpdate()
		{
			if (updateFrom == UpdateFrom.LateUpdate && isAnimating)
			{
				UpdateAnimations_Impl(context.UseScaledTime ? Time.deltaTime : Time.unscaledDeltaTime);
			}
		}

		private void FixedUpdate()
		{
			if (updateFrom == UpdateFrom.FixedUpdate && isAnimating)
			{
				UpdateAnimations_Impl(context.UseScaledTime ? Time.fixedDeltaTime : Time.fixedUnscaledDeltaTime);
			}
		}

		private void UpdateAnimations_Impl(float deltaTime)
		{
			context.passed += deltaTime;
			if (characterResetQueued)
			{
				ResetAllVisible();
				characterResetQueued = false;
			}
			for (int i = 0; i < base.Mediator.CharData.Count; i++)
			{
				CharData cData = base.Mediator.CharData[i];
				UpdateCharacterAnimation(cData, deltaTime, i, updateVertices: false);
			}
			if (base.Mediator.Text.mesh != null)
			{
				base.Mediator.Text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
			}
		}

		public void RegisterPostAnimationHook(OnCharacterAnimatedEventHandler handler)
		{
			handlers.Add(handler);
		}

		public bool UnregisterPostAnimationHook(OnCharacterAnimatedEventHandler handler)
		{
			return handlers.Remove(handler);
		}

		public void QueueCharacterReset()
		{
			characterResetQueued = true;
		}

		private void UpdateCharacterAnimation(CharData cData, float deltaTime, int index, bool updateVertices = true, bool forced = false)
		{
			if (!cData.info.isVisible)
			{
				return;
			}
			VisibilityState visibilityState = base.Mediator.VisibilityStates[index];
			if (visibilityState == VisibilityState.Hidden)
			{
				return;
			}
			context.deltaTime = deltaTime;
			context.Modifiers = state;
			if (defaultAnimations.Count != 0 || basic.HasAnyContaining(index) || visibilityState != VisibilityState.Shown)
			{
				state.Reset();
				UpdateCharacterAnimation_Impl(index);
				if (base.Mediator.VisibilityStates[index] != VisibilityState.Hidden && handlers.Count != 0)
				{
					for (int i = 0; i < handlers.Count; i++)
					{
						cData.Reset();
						handlers[i](cData);
						state.MeshModifiers.Combine(cData.MeshModifiers);
						state.CharacterModifiers.Combine(cData.CharacterModifiers);
					}
				}
			}
			else
			{
				if (handlers.Count == 0)
				{
					return;
				}
				state.Reset();
				for (int j = 0; j < handlers.Count; j++)
				{
					cData.Reset();
					handlers[j](cData);
					state.MeshModifiers.Combine(cData.MeshModifiers);
					state.CharacterModifiers.Combine(cData.CharacterModifiers);
				}
			}
			ApplyVertices();
			base.Mediator.ApplyMesh(cData);
			if (updateVertices && base.Mediator.Text.mesh != null)
			{
				base.Mediator.Text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
			}
			void ApplyVertices()
			{
				if (state.CharacterModifiers.Modifier != 0 || state.MeshModifiers.Modifier.HasFlag(TMPMeshModifiers.ModifierFlags.Deltas))
				{
					state.CalculateVertexPositions(cData, context);
					cData.mesh.SetPosition(0, state.BL_Position);
					cData.mesh.SetPosition(1, state.TL_Position);
					cData.mesh.SetPosition(2, state.TR_Position);
					cData.mesh.SetPosition(3, state.BR_Position);
				}
				if (state.MeshModifiers.Modifier.HasFlag(TMPMeshModifiers.ModifierFlags.Colors))
				{
					cData.mesh.SetColor(0, state.MeshModifiers.BL_Color.GetValue(cData.InitialMesh.GetColor(0)));
					cData.mesh.SetColor(1, state.MeshModifiers.TL_Color.GetValue(cData.InitialMesh.GetColor(1)));
					cData.mesh.SetColor(2, state.MeshModifiers.TR_Color.GetValue(cData.InitialMesh.GetColor(2)));
					cData.mesh.SetColor(3, state.MeshModifiers.BR_Color.GetValue(cData.InitialMesh.GetColor(3)));
				}
				if (state.MeshModifiers.Modifier.HasFlag(TMPMeshModifiers.ModifierFlags.UVs))
				{
					cData.mesh.SetUV0(0, state.MeshModifiers.BL_UV0.GetValue(cData.InitialMesh.GetUV0(0)));
					cData.mesh.SetUV0(1, state.MeshModifiers.TL_UV0.GetValue(cData.InitialMesh.GetUV0(1)));
					cData.mesh.SetUV0(2, state.MeshModifiers.TR_UV0.GetValue(cData.InitialMesh.GetUV0(2)));
					cData.mesh.SetUV0(3, state.MeshModifiers.BR_UV0.GetValue(cData.InitialMesh.GetUV0(3)));
					cData.mesh.SetUV2(0, state.MeshModifiers.BL_UV2.GetValue(cData.InitialMesh.GetUV2(0)));
					cData.mesh.SetUV2(1, state.MeshModifiers.TL_UV2.GetValue(cData.InitialMesh.GetUV2(1)));
					cData.mesh.SetUV2(2, state.MeshModifiers.TR_UV2.GetValue(cData.InitialMesh.GetUV2(2)));
					cData.mesh.SetUV2(3, state.MeshModifiers.BR_UV2.GetValue(cData.InitialMesh.GetUV2(3)));
				}
			}
		}

		private bool AnimateCharacter(int index, CharData cData)
		{
			VisibilityState visibilityState = base.Mediator.VisibilityStates[index];
			if (cData.info.isVisible && visibilityState != VisibilityState.Hidden)
			{
				if (defaultAnimations.Count == 0 && !basic.HasAnyContaining(index))
				{
					return visibilityState != VisibilityState.Shown;
				}
				return true;
			}
			return false;
		}

		private void UpdateCharacterAnimation_Impl(int index)
		{
			CharData cData = base.Mediator.CharData[index];
			VisibilityState visibilityState = base.Mediator.VisibilityStates[index];
			if (!cData.info.isVisible)
			{
				return;
			}
			switch (visibilityState)
			{
			case VisibilityState.Hidden:
				return;
			case VisibilityState.Showing:
			{
				bool flag4 = ignoreVisibilityChanges;
				ignoreVisibilityChanges = true;
				bool flag5 = true;
				bool flag6 = IsExcludedBasic(cData.info.character);
				if (IsExcludedShow(cData.info.character))
				{
					Animate(dummyShow, late: false);
					if (!flag6)
					{
						AnimateBasic(late: false);
						AnimateBasic(late: true);
					}
				}
				else
				{
					flag5 = AnimateShowList(late: false);
					if (!flag6)
					{
						AnimateBasic(late: false);
					}
					flag5 &= AnimateShowList(late: true);
					if (!flag6)
					{
						AnimateBasic(late: true);
					}
				}
				if (flag5)
				{
					if (!basic.HasAnyContaining(index) || IsExcludedBasic(cData.info.character))
					{
						ignoreVisibilityChanges = false;
						base.Mediator.SetVisibilityState(cData, VisibilityState.Shown);
						ignoreVisibilityChanges = flag4;
						return;
					}
					base.Mediator.SetVisibilityState(cData, VisibilityState.Shown);
				}
				ignoreVisibilityChanges = flag4;
				return;
			}
			case VisibilityState.Hiding:
			{
				bool flag = ignoreVisibilityChanges;
				ignoreVisibilityChanges = true;
				bool flag2 = true;
				bool flag3 = IsExcludedBasic(cData.info.character);
				if (IsExcludedHide(cData.info.character))
				{
					Animate(dummyShow, late: false);
					if (!flag3)
					{
						AnimateBasic(late: false);
						AnimateBasic(late: true);
					}
				}
				else
				{
					flag2 = AnimateHideList(late: false);
					if (!flag2)
					{
						if (!flag3)
						{
							AnimateBasic(late: false);
						}
						flag2 = AnimateHideList(late: true);
						if (!flag2 && !flag3)
						{
							AnimateBasic(late: true);
						}
					}
				}
				if (flag2)
				{
					state.Reset();
					ignoreVisibilityChanges = false;
					base.Mediator.SetVisibilityState(cData, VisibilityState.Hidden);
					ignoreVisibilityChanges = flag;
				}
				else
				{
					ignoreVisibilityChanges = flag;
				}
				return;
			}
			default:
				TMPEffectsBugReport.BugReportPrompt("This should be unreachable:\n" + new StackTrace());
				break;
			case VisibilityState.Shown:
				break;
			}
			if (!IsExcludedBasic(cData.info.character))
			{
				AnimateBasic(late: false);
				AnimateBasic(late: true);
			}
			void Animate(CachedAnimation ca, bool late)
			{
				if (ca.late == late && !ca.Finished(index))
				{
					cData.Reset();
					ca.animation.Animate(cData, ca.roContext);
					state.MeshModifiers.Combine(cData.mesh.Modifiers);
					state.CharacterModifiers.Combine(cData.CharacterModifiers);
				}
			}
			void AnimateBasic(bool late)
			{
				for (int i = 0; i < defaultAnimations.Count; i++)
				{
					CachedAnimation ca = defaultAnimations[i];
					Animate(ca, late);
				}
				CachedCollection<CachedAnimation>.MinMax minMax = basic.MinMaxAt(index);
				if (minMax != null)
				{
					if (animationsOverride)
					{
						int num = minMax.MinIndex;
						for (int num2 = minMax.MaxIndex; num2 >= minMax.MinIndex; num2--)
						{
							CachedAnimation cachedAnimation = basic[num2];
							if (cachedAnimation.Indices.Contains(index) && (!cachedAnimation.overrides.HasValue || cachedAnimation.overrides.Value))
							{
								num = num2;
								break;
							}
						}
						for (int j = num; j <= minMax.MaxIndex; j++)
						{
							CachedAnimation cachedAnimation2 = basic[j];
							if (cachedAnimation2.Indices.Contains(index))
							{
								Animate(cachedAnimation2, late);
							}
						}
					}
					else
					{
						int num3 = minMax.MinIndex;
						for (int num4 = minMax.MaxIndex; num4 >= minMax.MinIndex; num4--)
						{
							CachedAnimation cachedAnimation3 = basic[num4];
							if (cachedAnimation3.Indices.Contains(index) && cachedAnimation3.overrides.HasValue && cachedAnimation3.overrides.Value)
							{
								num3 = num4;
								break;
							}
						}
						for (int k = num3; k <= minMax.MaxIndex; k++)
						{
							CachedAnimation cachedAnimation4 = basic[k];
							if (cachedAnimation4.Indices.Contains(index))
							{
								Animate(cachedAnimation4, late);
							}
						}
					}
				}
			}
			bool AnimateHideList(bool late)
			{
				for (int i = 0; i < defaultHideAnimations.Count; i++)
				{
					CachedAnimation cachedAnimation = defaultHideAnimations[i];
					Animate(cachedAnimation, late);
					if (cachedAnimation.context.Finished(index))
					{
						return true;
					}
				}
				CachedCollection<CachedAnimation>.MinMax minMax = hide.MinMaxAt(index);
				if (minMax == null)
				{
					return defaultHideAnimations.Count == 0;
				}
				bool result = false;
				if (animationsOverride)
				{
					int num = minMax.MinIndex;
					for (int num2 = minMax.MaxIndex; num2 >= minMax.MinIndex; num2--)
					{
						CachedAnimation cachedAnimation2 = hide[num2];
						if (cachedAnimation2.Indices.Contains(index) && (!cachedAnimation2.overrides.HasValue || cachedAnimation2.overrides.Value))
						{
							num = num2;
							break;
						}
					}
					for (int j = num; j <= minMax.MaxIndex; j++)
					{
						CachedAnimation cachedAnimation3 = hide[j];
						if (cachedAnimation3.Indices.Contains(index))
						{
							Animate(cachedAnimation3, late);
							if (cachedAnimation3.Finished(index))
							{
								return true;
							}
							if (!cachedAnimation3.overrides.HasValue || cachedAnimation3.overrides.Value)
							{
								break;
							}
						}
					}
				}
				else
				{
					int num3 = minMax.MinIndex;
					for (int num4 = minMax.MaxIndex; num4 >= minMax.MinIndex; num4--)
					{
						CachedAnimation cachedAnimation4 = hide[num4];
						if (cachedAnimation4.Indices.Contains(index) && cachedAnimation4.overrides.HasValue && cachedAnimation4.overrides.Value)
						{
							num3 = num4;
							break;
						}
					}
					for (int k = num3; k <= minMax.MaxIndex; k++)
					{
						CachedAnimation cachedAnimation5 = hide[k];
						if (cachedAnimation5.Indices.Contains(index))
						{
							Animate(cachedAnimation5, late);
							if (cachedAnimation5.Finished(index))
							{
								return true;
							}
							if (cachedAnimation5.overrides.HasValue && cachedAnimation5.overrides.Value)
							{
								break;
							}
						}
					}
				}
				return result;
			}
			bool AnimateShowList(bool late)
			{
				bool result = true;
				for (int i = 0; i < defaultShowAnimations.Count; i++)
				{
					CachedAnimation cachedAnimation = defaultShowAnimations[i];
					Animate(cachedAnimation, late);
					if (!cachedAnimation.context.Finished(index))
					{
						result = false;
					}
				}
				CachedCollection<CachedAnimation>.MinMax minMax = show.MinMaxAt(index);
				if (minMax == null)
				{
					return result;
				}
				if (animationsOverride)
				{
					int num = minMax.MinIndex;
					for (int num2 = minMax.MaxIndex; num2 >= minMax.MinIndex; num2--)
					{
						CachedAnimation cachedAnimation2 = show[num2];
						if (cachedAnimation2.Indices.Contains(index) && (!cachedAnimation2.overrides.HasValue || cachedAnimation2.overrides.Value))
						{
							num = num2;
							break;
						}
					}
					for (int j = num; j <= minMax.MaxIndex; j++)
					{
						CachedAnimation cachedAnimation3 = show[j];
						if (cachedAnimation3.Indices.Contains(index))
						{
							Animate(cachedAnimation3, late);
							if (!cachedAnimation3.Finished(index))
							{
								result = false;
							}
							if (!cachedAnimation3.overrides.HasValue || cachedAnimation3.overrides.Value)
							{
								break;
							}
						}
					}
				}
				else
				{
					int num3 = minMax.MinIndex;
					for (int num4 = minMax.MaxIndex; num4 >= minMax.MinIndex; num4--)
					{
						CachedAnimation cachedAnimation4 = show[num4];
						if (cachedAnimation4.Indices.Contains(index) && cachedAnimation4.overrides.HasValue && cachedAnimation4.overrides.Value)
						{
							num3 = num4;
							break;
						}
					}
					for (int k = num3; k <= minMax.MaxIndex; k++)
					{
						CachedAnimation cachedAnimation5 = show[k];
						if (cachedAnimation5.Indices.Contains(index))
						{
							Animate(cachedAnimation5, late);
							if (!cachedAnimation5.Finished(index))
							{
								result = false;
							}
							if (cachedAnimation5.overrides.HasValue && cachedAnimation5.overrides.Value)
							{
								break;
							}
						}
					}
				}
				return result;
			}
		}

		private void test()
		{
		}

		private void OnTextChanged_Early(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData)
		{
			PopulateTimes(textContentChanged, oldCharData);
			SetDummies();
			PostProcessTags();
			SetDefaultAnimations(TMPAnimationType.Basic);
			SetDefaultAnimations(TMPAnimationType.Show);
			SetDefaultAnimations(TMPAnimationType.Hide);
		}

		private void OnTextChanged_Late(bool textContentChanged, ReadOnlyCollection<CharData> oldCharData, ReadOnlyCollection<VisibilityState> oldVisibilities)
		{
			QueueCharacterReset();
			if (IsAnimating)
			{
				UpdateAnimations_Impl(0f);
			}
		}

		private void PopulateTimes(bool textContentChanged, IList<CharData> oldCharData)
		{
			if (textContentChanged || base.Mediator.CharData.Count != visibleTimes?.Count)
			{
				visibleTimes = new List<float>();
				stateTimes = new List<float>();
				for (int i = 0; i < base.Mediator.CharData.Count; i++)
				{
					visibleTimes.Add(0f);
					stateTimes.Add(0f);
				}
			}
		}

		private void OnVisibilityStateUpdated(int index, VisibilityState prev)
		{
			if (ignoreVisibilityChanges)
			{
				return;
			}
			CharData cData = base.Mediator.CharData[index];
			if (!cData.info.isVisible)
			{
				return;
			}
			VisibilityState visibilityState = base.Mediator.VisibilityStates[index];
			if (!IsAnimating)
			{
				switch (visibilityState)
				{
				case VisibilityState.Showing:
					base.Mediator.SetVisibilityState(index, VisibilityState.Shown);
					return;
				case VisibilityState.Hiding:
					base.Mediator.SetVisibilityState(index, VisibilityState.Hidden);
					return;
				}
			}
			if (prev == visibilityState)
			{
				return;
			}
			stateTimes[index] = context.passed;
			if (visibilityState == VisibilityState.Hidden || prev == VisibilityState.Hidden)
			{
				visibleTimes[index] = context.passed;
			}
			switch (visibilityState)
			{
			case VisibilityState.Hidden:
				UpdateVisibility(show: false);
				break;
			case VisibilityState.Shown:
				cData.Reset();
				UpdateVisibility(show: true);
				break;
			}
			switch (visibilityState)
			{
			case VisibilityState.Showing:
			{
				for (int k = 0; k < defaultShowAnimations.Count; k++)
				{
					defaultShowAnimations[k].context.ResetFinishAnimation(index);
				}
				dummyShow.context.ResetFinishAnimation(index);
				CachedCollection<CachedAnimation>.MinMax minMax2 = show.MinMaxAt(index);
				if (minMax2 == null)
				{
					break;
				}
				for (int l = minMax2.MinIndex; l <= minMax2.MaxIndex; l++)
				{
					CachedAnimation cachedAnimation2 = show[l];
					if (cachedAnimation2.Indices.Contains(index))
					{
						cachedAnimation2.context.ResetFinishAnimation(index);
					}
				}
				break;
			}
			case VisibilityState.Hiding:
			{
				for (int i = 0; i < defaultHideAnimations.Count; i++)
				{
					defaultHideAnimations[i].context.ResetFinishAnimation(index);
				}
				dummyHide.context.ResetFinishAnimation(index);
				CachedCollection<CachedAnimation>.MinMax minMax = hide.MinMaxAt(index);
				if (minMax == null)
				{
					break;
				}
				for (int j = minMax.MinIndex; j <= minMax.MaxIndex; j++)
				{
					CachedAnimation cachedAnimation = hide[j];
					if (cachedAnimation.Indices.Contains(index))
					{
						cachedAnimation.context.ResetFinishAnimation(index);
					}
				}
				break;
			}
			}
			if (IsAnimating)
			{
				ignoreVisibilityChanges = true;
				UpdateCharacterAnimation(base.Mediator.CharData[index], 0f, index, updateVertices: false);
				ignoreVisibilityChanges = false;
				if (visibilityState != base.Mediator.VisibilityStates[index])
				{
					OnVisibilityStateUpdated(index, visibilityState);
					return;
				}
			}
			if (base.Mediator.Text.mesh != null)
			{
				base.Mediator.Text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
			}
			void SetVerticesToDefault()
			{
				for (int m = 0; m < 4; m++)
				{
					cData.mesh.SetPosition(m, cData.mesh.initial.GetPosition(m));
				}
			}
			void SetVerticesToZero()
			{
				for (int m = 0; m < 4; m++)
				{
					cData.mesh.SetPosition(m, cData.InitialPosition);
				}
			}
			void UpdateVisibility(bool show)
			{
				if (show)
				{
					SetVerticesToDefault();
				}
				else
				{
					SetVerticesToZero();
				}
				base.Mediator.ApplyMesh(cData);
			}
		}

		private void PostProcessTags()
		{
			ReadOnlyCollection<CharData> charData = new ReadOnlyCollection<CharData>(base.Mediator.CharData);
			CharDataModifiers modifiers = state;
			KeyValuePair<TMPAnimationCategory, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>> keyValuePair = new KeyValuePair<TMPAnimationCategory, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>>(basicCategory, processors.TagProcessors[basicCategory.Prefix][0].ProcessedTags);
			KeyValuePair<TMPAnimationCategory, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>> keyValuePair2 = new KeyValuePair<TMPAnimationCategory, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>>(showCategory, processors.TagProcessors[showCategory.Prefix][0].ProcessedTags);
			KeyValuePair<TMPAnimationCategory, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>> keyValuePair3 = new KeyValuePair<TMPAnimationCategory, IEnumerable<KeyValuePair<TMPEffectTagIndices, TMPEffectTag>>>(hideCategory, processors.TagProcessors[hideCategory.Prefix][0].ProcessedTags);
			if (tags != null)
			{
				tags.CollectionChanged -= OnTagCollectionChanged;
			}
			tags = new TagCollectionManager<TMPAnimationCategory>(keyValuePair, keyValuePair2, keyValuePair3);
			tags.CollectionChanged += OnTagCollectionChanged;
			AnimationCacher cacher = new AnimationCacher(basicCategory, modifiers, readonlyContext, charData, (char x) => !IsExcludedBasic(x), keywordDatabaseWrapper.Database);
			AnimationCacher cacher2 = new AnimationCacher(showCategory, modifiers, readonlyContext, charData, (char x) => !IsExcludedShow(x), keywordDatabaseWrapper.Database);
			AnimationCacher cacher3 = new AnimationCacher(hideCategory, modifiers, readonlyContext, charData, (char x) => !IsExcludedHide(x), keywordDatabaseWrapper.Database);
			basic = new CachedCollection<CachedAnimation>(cacher, tags[basicCategory]);
			show = new CachedCollection<CachedAnimation>(cacher2, tags[showCategory]);
			hide = new CachedCollection<CachedAnimation>(cacher3, tags[hideCategory]);
		}

		private void ResetAllVisible()
		{
			if (base.Mediator == null)
			{
				return;
			}
			TMP_TextInfo textInfo = base.Mediator.Text.textInfo;
			for (int i = 0; i < base.Mediator.CharData.Count; i++)
			{
				if (textInfo.characterInfo[i].isVisible && base.Mediator.VisibilityStates[i] != VisibilityState.Hidden)
				{
					CharData charData = base.Mediator.CharData[i];
					charData.Reset();
					base.Mediator.ApplyMesh(charData);
				}
			}
			if (base.Mediator.Text.mesh != null)
			{
				base.Mediator.Text.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
			}
		}
	}
}
