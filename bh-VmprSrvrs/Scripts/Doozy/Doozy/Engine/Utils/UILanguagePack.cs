using System;
using UnityEngine;

namespace Doozy.Engine.Utils
{
	[Serializable]
	public class UILanguagePack : LanguagePack
	{
		private static Language s_loadedLanguage;

		private static UILanguagePack s_instance;

		public Language TargetLanguage;

		[Header("Labels")]
		public string Action;

		public string Actions;

		public string ActivateLoadedScenesNodeName;

		public string ActiveNode;

		public string ActiveVariant;

		public string ActiveSceneChange;

		public string AddCategory;

		public string AddItem;

		public string AddSounds;

		public string AddSource;

		public string AddSymbolToAllBuildTargetGroups;

		public string AddToPopupQueue;

		public string After;

		public string AfterDelay;

		public string AllowMultipleClicks;

		public string AllowSceneActivation;

		public string AllSoundsBeforePlaying;

		public string AlternateInput;

		public string AlternateKeyCode;

		public string AlternateVirtualButton;

		public string AnimateAllUIViewsWithSameCategoryAndName;

		public string AnimateValue;

		public string Animation;

		public string AnimationCurve;

		public string AnimationType;

		public string Animator;

		public string AnimatorEvents;

		public string Animators;

		public string AnotherEntryExists;

		public string AnyButton;

		public string AnyGameEvent;

		public string AnyGameEventWillTriggerThisListener;

		public string AnyScene;

		public string AnyUIButton;

		public string AnyUIDrawer;

		public string AnyUIView;

		public string AnyUIButtonWillTriggerThisListener;

		public string AnyUIDrawerWillTriggerThisListener;

		public string AnyUIViewWillTriggerThisListener;

		public string AutoSave;

		public string AutoSaveDisabled;

		public string AutoSaveEnabled;

		public string ApplicationQuit;

		public string AreYouSureConvertToGraph;

		public string AreYouSureConvertToSubGraph;

		public string AreYouSureYouWantToDeleteDatabase;

		public string AreYouSureYouWantToDeleteTheme;

		public string AreYouSureYouWantToDeletePopupReference;

		public string AreYouSureYouWantToRemoveCategory;

		public string AreYouSureYouWantToRemoveTheEntry;

		public string AreYouSureYouWantToResetDatabase;

		public string Arrow;

		public string ArrowComponents;

		public string AtFinish;

		public string AtStart;

		public string AudioClip;

		public string AutoDisableUIInteractionsDescription;

		public string AutoHideAfterShow;

		public string AutoKillIdleControllers;

		public string AutoKillIdleControllersDescription;

		public string AutoRebuild;

		public string AutoResetSequence;

		public string AutoSelectButtonAfterShow;

		public string AutoSelectPreviouslySelectedButtonAfterHide;

		public string AutoSort;

		public string AutoStartLoopAnimation;

		public string BackButton;

		public string BackButtonNodeName;

		public string Behavior;

		public string BehaviorAtStart;

		public string Behaviors;

		public string BlockBackButton;

		public string BorderWidth;

		public string BuildIndex;

		public string ButtonCategory;

		public string ButtonLabel;

		public string ButtonName;

		public string Buttons;

		public string Cancel;

		public string CannotAddEmptyEntry;

		public string Canvas;

		public string CanvasName;

		public string Category;

		public string CategoryIsEmpty;

		public string Center;

		public string CenterSelectedNodes;

		public string Chance;

		public string CheckingForIssues;

		public string ChildHeight;

		public string ChildHeightFactor;

		public string ChildRotation;

		public string ChildWidth;

		public string ChildWidthFactor;

		public string Clear;

		public string ClearRecentOpenedGraphsList;

		public string ClearRecentOpenedGraphsListDescription;

		public string ClearSearch;

		public string ClickAnywhere;

		public string ClickContainer;

		public string ClickMode;

		public string ClickOverlay;

		public string Clockwise;

		public string Close;

		public string Closed;

		public string CloseDirection;

		public string ClosedPosition;

		public string CloseDrawer;

		public string CloseSpeed;

		public string Color;

		public string Compiling;

		public string ComponentDisabled;

		public string Connected;

		public string ConnectionPoint;

		public string Connections;

		public string Container;

		public string ContainerSize;

		public string Continue;

		public string ControlChildHeight;

		public string ControlChildWidth;

		public string ControllerIdleKillDuration;

		public string ControllerIdleKillDurationDescription;

		public string ControllerName;

		public string ConvertToGraph;

		public string ConvertToSubGraph;

		public string Copy;

		public string Create;

		public string CreateAnimation;

		public string CreateGraph;

		public string CreateNewCategory;

		public string CreateNewGraph;

		public string CreateNewGraphAsSubGraph;

		public string CreateNode;

		public string CreateParentAndCenterPivot;

		public string CreateSubGraph;

		public string CurrentTimeScale;

		public string Custom;

		public string CustomName;

		public string CustomPosition;

		public string CustomResetValue;

		public string CustomSortingLayer;

		public string CustomSortingOrder;

		public string CustomStartPosition;

		public string Cut;

		public string Database;

		public string DatabaseAlreadyExists;

		public string ThemeNameAlreadyExists;

		public string DatabaseHasBeenReset;

		public string DatabaseIsEmpty;

		public string DatabaseName;

		public string DatabaseRefreshed;

		public string DatabaseSorted;

		public string Debug;

		public string DebugMode;

		public string DefaultDotAnimationSpeedDescription;

		public string DefaultValues;

		public string DefaultValuesDescription;

		public string DefaultZoom;

		public string DefaultZoomDescription;

		public string Delete;

		public string DeleteDatabase;

		public string DeleteTheme;

		public string DeletedPopupReference;

		public string DeletePopupReference;

		public string DeletePreset;

		public string Description;

		public string Deselect;

		public string DeselectAnyButton;

		public string DeselectButton;

		public string DeselectButtonAfterClick;

		public string DestroyAfterHide;

		public string DetectGestures;

		public string Direction;

		public string Disable;

		public string DisableButtonInterval;

		public string DisableCanvas;

		public string Disabled;

		public string DisableFunctionality;

		public string DisableGameObject;

		public string DisableInterval;

		public string DisablePlugin;

		public string DisableTriggerAfterActivation;

		public string Disconnect;

		public string DispatchButtonClicks;

		public string DispatchGameEvents;

		public string DisplayTarget;

		public string DontDestroyGameObjectOnLoad;

		public string DotAnimationSpeed;

		public string Down;

		public string DragDrawer;

		public string DrawerName;

		public string DropAudioClipsHere;

		public string Duration;

		public string Ease;

		public string EaseType;

		public string EditMode;

		public string Effect;

		public string Elasticity;

		public string Email;

		public string Empty;

		public string Enable;

		public string Enabled;

		public string EnableFunctionality;

		public string EnablePlugin;

		public string EnableSupportForMasterAudio;

		public string EnterCategoryName;

		public string EnterDatabaseName;

		public string EnterThemeName;

		public string EnterGameEventToListenFor;

		public string EnterNodeName;

		public string Error;

		public string Event;

		public string EveryLongTapWillTriggerThisListener;

		public string EverySwipeWillTriggerThisListener;

		public string EveryTapWillTriggerThisListener;

		public string ExitNodeName;

		public string ExposedParameterName;

		public string Fade;

		public string FadeBy;

		public string FadeFrom;

		public string FadeOutContainer;

		public string FadeTo;

		public string Feather;

		public string FeatherExpandsSize;

		public string FillAmount;

		public string FillCenter;

		public string FillMethod;

		public string FillOrigin;

		public string FixedSize;

		public string Font;

		public string FontAsset;

		public string FsmName;

		public string Functionality;

		public string FunctionalityDescription;

		public string GameEvent;

		public string GameEvents;

		public string GameObject;

		public string GeneralSettings;

		public string GestureType;

		public string GetInTouch;

		public string GetPosition;

		public string GetSceneBy;

		public string GlobalListener;

		public string GoToEnterNode;

		public string GoToExitNode;

		public string GoToStartNode;

		public string Graph;

		public string GraphHasNoNodes;

		public string GraphicRaycaster;

		public string GraphId;

		public string GraphModel;

		public string HasBeenAddedToClipboard;

		public string Height;

		public string HeightFromRadius;

		public string HeightRadiusFactor;

		public string Help;

		public string HelpResources;

		public string Hide;

		public string HideAnimationWillNotWork;

		public string HideOnBackButton;

		public string HidePopup;

		public string HideProgressor;

		public string HideUIPopupBy;

		public string HideView;

		public string HideViews;

		public string HowToUse;

		public string IdleCheckInterval;

		public string IdleCheckIntervalDescription;

		public string IgnoreListenerPause;

		public string IgnoreTimescale;

		public string Image;

		public string Images;

		public string ImageType;

		public string IncludeAudioClipNamesInSearch;

		public string Info;

		public string InputConnected;

		public string InputConnections;

		public string InputMode;

		public string InputNotConnected;

		public string Installed;

		public string InstantAction;

		public string InstantAnimation;

		public string Integrations;

		public string IsNotPrefab;

		public string Key;

		public string KeyCode;

		public string Label;

		public string Labels;

		public string Language;

		public string LastModified;

		public string Left;

		public string ListenFor;

		public string ListenForAllGameEvents;

		public string ListenForAllUIButtons;

		public string ListenForAllUIDrawers;

		public string ListenForAllUIViews;

		public string ListeningForGameEvent;

		public string ListIsEmpty;

		public string Load;

		public string LoadBehavior;

		public string LoadedGraph;

		public string LoadPreset;

		public string LoadSceneBy;

		public string LoadSceneMode;

		public string LoadSceneNodeName;

		public string LoadSelectedPresetAtRuntime;

		public string LongTapDuration;

		public string LongTapDurationDescription;

		public string LoopSound;

		public string LoopType;

		public string LoopView;

		public string Manual;

		public string Material;

		public string Max;

		public string MaxAngle;

		public string MaxHeightFactor;

		public string MaxRadius;

		public string MaxValue;

		public string MaxWidthFactor;

		public string Min;

		public string MinAngle;

		public string MinimumNumberOfControllers;

		public string MinimumNumberOfControllersDescription;

		public string MinimumSize;

		public string MinValue;

		public string MissingPrefabReference;

		public string Move;

		public string MoveBy;

		public string MoveDown;

		public string MoveFrom;

		public string MoveTo;

		public string MoveUp;

		public string Multiplier;

		public string MuteAllSounds;

		public string Name;

		public string New;

		public string NewCategory;

		public string NewCategoryNameCannotBeEmpty;

		public string NewColor;

		public string NewDatabase;

		public string NewFont;

		public string NewFontAsset;

		public string NewPopup;

		public string NewPreset;

		public string NewPresetNameCannotBeEmpty;

		public string NewSprite;

		public string NewTexture;

		public string News;

		public string NewSoundDatabase;

		public string NewTheme;

		public string NewThemeName;

		public string NewThemeVariant;

		public string No;

		public string NoAnimationEnabled;

		public string NoAnimatorFound;

		public string Node;

		public string NodeId;

		public string NodeName;

		public string NodeNameTooltip;

		public string Nodes;

		public string NodeState;

		public string NodeWidth;

		public string NodySettings;

		public string NoGraphReferenced;

		public string NoPropertyFound;

		public string NormalLoopAnimation;

		public string NoSound;

		public string NoSoundsHaveBeenAdded;

		public string NotConnected;

		public string Notes;

		public string NoteworthyInformation;

		public string NotInstalled;

		public string NumberOfLoops;

		public string Ok;

		public string OnAnimationFinished;

		public string OnAnimationStart;

		public string OnClick;

		public string OnDeselected;

		public string OnDisable;

		public string OnDoubleClick;

		public string OnEnable;

		public string OnEnter;

		public string OnEnterNode;

		public string OnExit;

		public string OnExitNode;

		public string OnFixedUpdate;

		public string OnLateUpdate;

		public string OnLoadScene;

		public string OnLongClick;

		public string OnNodeFixedUpdate;

		public string OnNodeLateUpdate;

		public string OnNodeUpdate;

		public string OnPointerDown;

		public string OnPointerEnter;

		public string OnPointerExit;

		public string OnPointerUp;

		public string OnRightClick;

		public string OnSceneLoaded;

		public string OnSelected;

		public string OnTrigger;

		public string OnUpdate;

		public string Open;

		public string OpenControlPanel;

		public string OpenDatabase;

		public string OpenDrawer;

		public string Opened;

		public string OpenedPosition;

		public string OpenGraph;

		public string OpenNody;

		public string OpenSpeed;

		public string OpenSubGraph;

		public string OperationCannotBeUndone;

		public string OrientationDetectorDescription;

		public string OtherReferences;

		public string OutputAudioMixerGroup;

		public string OutputConnected;

		public string OutputConnections;

		public string OutputMixerGroup;

		public string OutputNotConnected;

		public string Overlay;

		public string Override;

		public string OverrideAlpha;

		public string OverrideColor;

		public string Overview;

		public string OverviewZoom;

		public string ParameterName;

		public string ParameterType;

		public string ParticleSystem;

		public string Paste;

		public string PauseAllSounds;

		public string PercentageOfScreenZeroToOne;

		public string PitchSemitones;

		public string Play;

		public string PlayAnimationInZeroSeconds;

		public string PlayMode;

		public string PlaySound;

		public string PleaseEnterNewName;

		public string PopupName;

		public string PopupPrefab;

		public string Portal;

		public string PortalNodeName;

		public string Prefab;

		public string Prefix;

		public string PreserveAspect;

		public string PresetCategory;

		public string PresetName;

		public string PreviewAnimation;

		public string Progress;

		public string Progressor;

		public string Progressors;

		public string ProgressTargets;

		public string PunchBy;

		public string Radius;

		public string RadiusControlsHeight;

		public string RadiusControlsWidth;

		public string RadiusHeightFactor;

		public string RadiusWidthFactor;

		public string RandomDuration;

		public string RandomNodeName;

		public string Range;

		public string RawImage;

		public string RaycastTarget;

		public string Recent;

		public string Refresh;

		public string RefreshDatabase;

		public string RegisterInterval;

		public string Remove;

		public string RemoveCategory;

		public string RemovedDuplicateEntries;

		public string RemovedEntriesWithNoName;

		public string RemovedEntriesWithNullPrefabs;

		public string RemovedEntry;

		public string RemovedNullEntries;

		public string RemoveDuplicates;

		public string RemoveEmptyCategories;

		public string RemoveEmptyEntries;

		public string RemoveItem;

		public string RemoveNullEntries;

		public string RemoveSymbolFromAllBuildTargetGroups;

		public string Rename;

		public string RenameCategory;

		public string RenameCategoryDialogMessage;

		public string RenameGameObjectTo;

		public string RenameNodeTo;

		public string RenamePrefix;

		public string RenameSoundDatabase;

		public string RenameTheme;

		public string RenameSoundDatabaseDialogMessage;

		public string RenameSuffix;

		public string RenameTo;

		public string Reset;

		public string ResetAnimationSettings;

		public string ResetClosedPosition;

		public string ResetDatabase;

		public string ResetDelay;

		public string ResetOpenedPosition;

		public string ResetPosition;

		public string ResetRoot;

		public string ResetTrigger;

		public string ResetValue;

		public string Right;

		public string Rotate;

		public string RotateBy;

		public string RotateChildren;

		public string RotateFrom;

		public string RotateMode;

		public string RotateTo;

		public string RuntimeOptions;

		public string RuntimePreset;

		public string Save;

		public string SaveAs;

		public string SavePreset;

		public string Scale;

		public string ScaleBy;

		public string ScaleFrom;

		public string ScaleTo;

		public string Scene;

		public string SceneActivationDelay;

		public string SceneBuildIndex;

		public string SceneLoad;

		public string SceneName;

		public string SceneUnload;

		public string ScriptingDefineSymbol;

		public string Search;

		public string SearchForCategories;

		public string SearchForDatabases;

		public string SearchForUIPopupLinks;

		public string SearchForThemes;

		public string Seconds;

		public string SecondsDelay;

		public string Select;

		public string Selectable;

		public string SelectButton;

		public string SelectedLoopAnimation;

		public string SelectedTheme;

		public string SelectSwipeDirection;

		public string Send;

		public string SendGameEvent;

		public string SendGameEvents;

		public string SetActiveNode;

		public string SetAsSoundName;

		public string SetBoolValueTo;

		public string SetFloatValueTo;

		public string SetIntValueTo;

		public string SetPosition;

		public string SetTargetGameObject;

		public string Settings;

		public string SetUIButtonToListenFor;

		public string SetUIDrawerToListenFor;

		public string SetUIViewToListenFor;

		public string SetValue;

		public string Show;

		public string ShowAnimationWillNotWork;

		public string ShowCurveModifier;

		public string ShowNodeNotes;

		public string ShowNodeNotesDescription;

		public string ShowPopup;

		public string ShowProgressor;

		public string ShowView;

		public string ShowViews;

		public string Simulate;

		public string SocialLinks;

		public string Socket;

		public string Sort;

		public string SortDatabase;

		public string SortingSteps;

		public string Sound;

		public string SoundAction;

		public string SoundDatabases;

		public string SoundName;

		public string SoundNodeName;

		public string Sounds;

		public string SoundSource;

		public string Soundy;

		public string SoundyDatabase;

		public string ThemeName;

		public string SoundySettings;

		public string SourceImage;

		public string SourceName;

		public string Sources;

		public string Spacing;

		public string SpatialBlend;

		public string Speed;

		public string Sprite;

		public string SpriteRenderer;

		public string StartAngle;

		public string StartDelay;

		public string StartNodeName;

		public string StopAllSounds;

		public string StopAnimation;

		public string StopBehavior;

		public string StopSound;

		public string SubGraph;

		public string SubGraphNodeName;

		public string Suffix;

		public string SupportEmail;

		public string SwipeDirection;

		public string SwipeLength;

		public string SwipeLengthDescription;

		public string SwitchBackNodeName;

		public string SwitchBackMode;

		public string Target;

		public string TargetAnimator;

		public string TargetAnimatorDoesNotHaveAnAnimatorController;

		public string TargetAnimatorDoesNotHaveAnyParameters;

		public string TargetCanvas;

		public string TargetFsm;

		public string TargetGameObject;

		public string TargetLabel;

		public string TargetMixer;

		public string TargetOrientation;

		public string TargetProgress;

		public string TargetTheme;

		public string TargetTimeScale;

		public string TargetValue;

		public string TargetVariable;

		public string TargetVariant;

		public string Text;

		public string TextLabel;

		public string TextMeshPro;

		public string TextMeshProLabel;

		public string Texture;

		public string ThemeNode;

		public string Themes;

		public string ThemesAutoSaveEnabled;

		public string ThemesAutoSaveDisabled;

		public string ThemesDisableAutoSave;

		public string ThemesEnableAutoSave;

		public string Time;

		public string TimeScaleNodeName;

		public string ToggleComponentBehaviors;

		public string ToggleOFF;

		public string ToggleON;

		public string ToggleProgressor;

		public string ToggleSupportForThirdPartyPlugins;

		public string Tolerance;

		public string TouchySettings;

		public string TriggerAction;

		public string TriggerEventsAfterAnimation;

		public string TriggerName;

		public string TriggerValue;

		public string UIDrawerNodeName;

		public string UINodeNodeName;

		public string UIPopupDatabase;

		public string UnityEvent;

		public string UnityEvents;

		public string UnloadSceneNodeName;

		public string UnmuteAllSounds;

		public string UnpauseAllSounds;

		public string Up;

		public string UpdateContainer;

		public string UpdateEffect;

		public string TriggerActions;

		public string Is;

		public string And;

		public string To;

		public string UpdateOnHide;

		public string UpdateOnShow;

		public string UpdatePopupName;

		public string UpdatePopupPrefab;

		public string UpdateValue;

		public string UseBackButtonDescription;

		public string UseCustomFromAndTo;

		public string UsefulLinks;

		public string UseLogarithmicConversion;

		public string UseMultiplier;

		public string UseUnscaledTime;

		public string Value;

		public string Version;

		public string Vibrato;

		public string ViewCategory;

		public string ViewName;

		public string VirtualButton;

		public string VolumeDb;

		public string WaitFor;

		public string WaitForAnimationToFinish;

		public string WaitForSceneToUnload;

		public string WaitNodeName;

		public string Warning;

		public string Weight;

		public string When;

		public string WhenUIDrawerIsClosed;

		public string WhenUIPopupIsHiddenDisable;

		public string WhenUIViewIsHiddenDisable;

		public string WholeNumbers;

		public string Width;

		public string X;

		public string Y;

		public string Yes;

		public string YouAreResponsibleToUpdateYourCode;

		public string YouTube;

		[Header("Info Messages")]
		public string MissingTargetFsmMessage;

		public string SelectListenerToActivateMessage;

		public string HasChildViews;

		public string HowToUsePlaymakerEventDispatcherMessage;

		public string MissingDrawerNameTitle;

		public string MissingDrawerNameMessage;

		public string MissingGameEventTitle;

		public string MissingGameEventMessage;

		public string MissingSceneNameTitle;

		public string MissingSceneNameMessage;

		public string WrongSceneBuildIndexTitle;

		public string WrongSceneBuildIndexMessage;

		public string DoubleClickNodeToOpenSubGraphMessage;

		public string DuplicateNodeMessage;

		public string DuplicateNodeTitle;

		public string NoGraphReferencedMessage;

		public string NoGraphReferencedTitle;

		public string NoSourceConnectedMessage;

		public string NoSourceConnectedTitle;

		public string NoSubGraphReferencedMessage;

		public string NoSubGraphReferencedTitle;

		public string NoTargetConnectedMessage;

		public string NoTargetConnectedTitle;

		public string NotConnectedMessage;

		public string NotConnectedTitle;

		public string NotListeningForAnyGameEventMessage;

		public string NotListeningForAnyGameEventTitle;

		public string NotSendingAnyGameEventMessage;

		public string NotSendingAnyGameEventTitle;

		public string ProgressTargetAnimatorParameterInfo;

		public string ReferencedGraphIsNotSubGraphMessage;

		public string ReferencedGraphIsNotSubGraphTitle;

		public string ReferencedGraphIsSubGraphMessage;

		public string ReferencedGraphIsSubGraphTitle;

		public string SomeProgressTargetsGetUpdatedOnlyInPlayMode;

		public string SupportForMasterAudioNotEnabled;

		public string SupportForPlaymakerNotEnabled;

		public string SupportForTextMeshProNotEnabled;

		public string ThisClassShouldBeExtended;

		public string UnnamedNodeMessage;

		public string UnnamedNodeTitle;

		public static UILanguagePack Instance => null;
	}
}
