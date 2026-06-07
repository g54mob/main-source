namespace Doozy.Engine.Utils
{
	public static class MenuUtils
	{
		private const string GENERIC_VIDEO_LINK = "https://www.youtube.com/user/doozyplay/videos";

		private const int INPUT_MENU_ORDER = 13;

		private const int LAYOUTS_MENU_ORDER = 13;

		private const int LISTENERS_MENU_ORDER = 13;

		private const int MANAGERS_MENU_ORDER = 13;

		private const int NODY_MENU_ORDER = 13;

		private const int ORIENTATION_MENU_ORDER = 13;

		private const int PLAYMAKER_MENU_ORDER = 13;

		private const int PROGRESS_MENU_ORDER = 13;

		private const int SCENE_MANAGEMENT_MENU_ORDER = 13;

		private const int SOUNDY_MENU_ORDER = 13;

		private const int THEMES_MENU_ORDER = 13;

		private const int TOUCHY_MENU_ORDER = 13;

		private const int UI_MENU_ORDER = 2;

		private const string UI_INPUT_AddComponentMenu_Path = "Doozy/Input/";

		private const string UI_INPUT_MenuItem_Path = "GameObject/Doozy/Input/";

		public const string BackButton_GameObject_Name = "Back Button";

		public const string BackButton_AddComponentMenu_MenuName = "Doozy/Input/Back Button";

		public const int BackButton_AddComponentMenu_Order = 13;

		public const string BackButton_MenuItem_ItemName = "GameObject/Doozy/Input/Back Button";

		public const int BackButton_MenuItem_Priority = 13;

		public const string BackButton_Manual = "http://doozyui.com/back-button/";

		public const string BackButton_YouTube = "https://www.youtube.com/watch?v=IvFbtBYAZL4";

		public const string KeyToAction_GameObject_Name = "Key To Action";

		public const string KeyToAction_AddComponentMenu_MenuName = "Doozy/Input/Key To Action";

		public const int KeyToAction_AddComponentMenu_Order = 13;

		public const string KeyToAction_MenuItem_ItemName = "GameObject/Doozy/Input/Key To Action";

		public const int KeyToAction_MenuItem_Priority = 13;

		public const string KeyToAction_Manual = "http://doozyui.com/key-to-action/";

		public const string KeyToAction_YouTube = "https://youtu.be/ZOid_LaM6sM";

		public const string KeyToGameEvent_GameObject_Name = "Key To Game Event";

		public const string KeyToGameEvent_AddComponentMenu_MenuName = "Doozy/Input/Key To Game Event";

		public const int KeyToGameEvent_AddComponentMenu_Order = 13;

		public const string KeyToGameEvent_MenuItem_ItemName = "GameObject/Doozy/Input/Key To Game Event";

		public const int KeyToGameEvent_MenuItem_Priority = 13;

		public const string KeyToGameEvent_Manual = "http://doozyui.com/key-to-game-event/";

		public const string KeyToGameEvent_YouTube = "https://youtu.be/4xYR-p1gl3Q";

		private const string Layouts_AddComponentMenu_Path = "Doozy/Layouts/";

		private const string Layouts_MenuItem_Path = "GameObject/Doozy/Layouts/";

		public const string RadialLayout_GameObject_Name = "Radial Layout";

		public const string RadialLayout_AddComponentMenu_MenuName = "Doozy/Layouts/Radial Layout";

		public const int RadialLayout_AddComponentMenu_Order = 13;

		public const string RadialLayout_MenuItem_ItemName = "GameObject/Doozy/Layouts/Radial Layout";

		public const int RadialLayout_MenuItem_Priority = 13;

		public const string RadialLayout_Manual = "http://doozyui.com/radial-layout/";

		public const string RadialLayout_YouTube = "https://youtu.be/nrrdPa86tFY";

		private const string Listeners_AddComponentMenu_Path = "Doozy/Listeners/";

		private const string Listeners_MenuItem_Path = "GameObject/Doozy/Listeners/";

		public const string GameEventListener_GameObject_Name = "Game Event Listener";

		public const string GameEventListener_AddComponentMenu_MenuName = "Doozy/Listeners/Game Event Listener";

		public const int GameEventListener_AddComponentMenu_Order = 13;

		public const string GameEventListener_MenuItem_ItemName = "GameObject/Doozy/Listeners/Game Event Listener";

		public const int GameEventListener_MenuItem_Priority = 13;

		public const string GameEventListener_Manual = "http://doozyui.com/game-event-listener/";

		public const string GameEventListener_YouTube = "https://www.youtube.com/watch?v=7qLjgLKOH5w";

		public const string UIButtonListener_GameObject_Name = "UIButton Listener";

		public const string UIButtonListener_AddComponentMenu_MenuName = "Doozy/Listeners/UIButton Listener";

		public const int UIButtonListener_AddComponentMenu_Order = 13;

		public const string UIButtonListener_MenuItem_ItemName = "GameObject/Doozy/Listeners/UIButton Listener";

		public const int UIButtonListener_MenuItem_Priority = 13;

		public const string UIButtonListener_Manual = "http://doozyui.com/uibutton-listener/";

		public const string UIButtonListener_YouTube = "https://www.youtube.com/watch?v=BUpZMDX4IEs";

		public const string UIDrawerListener_GameObject_Name = "UIDrawer Listener";

		public const string UIDrawerListener_AddComponentMenu_MenuName = "Doozy/Listeners/UIDrawer Listener";

		public const int UIDrawerListener_AddComponentMenu_Order = 13;

		public const string UIDrawerListener_MenuItem_ItemName = "GameObject/Doozy/Listeners/UIDrawer Listener";

		public const int UIDrawerListener_MenuItem_Priority = 13;

		public const string UIDrawerListener_Manual = "http://doozyui.com/uidrawer-listener/";

		public const string UIDrawerListener_YouTube = "https://www.youtube.com/watch?v=gHwsfzXcvE4";

		public const string UIViewListener_GameObject_Name = "UIView Listener";

		public const string UIViewListener_AddComponentMenu_MenuName = "Doozy/Listeners/UIView Listener";

		public const int UIViewListener_AddComponentMenu_Order = 13;

		public const string UIViewListener_MenuItem_ItemName = "GameObject/Doozy/Listeners/UIView Listener";

		public const int UIViewListener_MenuItem_Priority = 13;

		public const string UIViewListener_Manual = "http://doozyui.com/uiview-listener/";

		public const string UIViewListener_YouTube = "https://www.youtube.com/watch?v=05xuFExYVZc";

		private const string Managers_AddComponentMenu_Path = "Doozy/Managers/";

		private const string Managers_MenuItem_Path = "GameObject/Doozy/Managers/";

		public const string GameEventManager_GameObject_Name = "Game Event Manager";

		public const string GameEventManager_AddComponentMenu_MenuName = "Doozy/Managers/Game Event Manager";

		public const int GameEventManager_AddComponentMenu_Order = 13;

		public const string GameEventManager_MenuItem_ItemName = "GameObject/Doozy/Managers/Game Event Manager";

		public const int GameEventManager_MenuItem_Priority = 13;

		public const string GameEventManager_Manual = "http://doozyui.com/game-event-manager/";

		public const string GameEventManager_YouTube = "https://www.youtube.com/watch?v=5hVP_El0tVA";

		public const string UIPopupManager_GameObject_Name = "UIPopup Manager";

		public const string UIPopupManager_AddComponentMenu_MenuName = "Doozy/Managers/UIPopup Manager";

		public const int UIPopupManager_AddComponentMenu_Order = 13;

		public const string UIPopupManager_MenuItem_ItemName = "GameObject/Doozy/Managers/UIPopup Manager";

		public const int UIPopupManager_MenuItem_Priority = 13;

		public const string UIPopupManager_Manual = "http://doozyui.com/uipopup-manager/";

		public const string UIPopupManager_YouTube = "https://www.youtube.com/watch?v=MH8a1G93mW8";

		private const string Nody_AddComponentMenu_Path = "Doozy/Nody/";

		private const string Nody_MenuItem_Path = "GameObject/Doozy/Nody/";

		public const string GraphController_GameObject_Name = "Graph Controller";

		public const string GraphController_AddComponentMenu_MenuName = "Doozy/Nody/Graph Controller";

		public const int GraphController_AddComponentMenu_Order = 13;

		public const string GraphController_MenuItem_ItemName = "GameObject/Doozy/Nody/Graph Controller";

		public const int GraphController_MenuItem_Priority = 13;

		public const string GraphController_Manual = "http://doozyui.com/graph-controller/";

		public const string GraphController_YouTube = "https://www.youtube.com/watch?v=UuAkXDvXS1A";

		public const string Graph_Manual = "http://doozyui.com";

		public const string Graph_YouTube = "https://www.youtube.com/user/doozyplay/videos";

		public const string HiddenNode = "";

		public const int BaseNodeOrder = 0;

		public const int DefaultNodeOrder = 50;

		public const string ActivateLoadedScenesNode_CreateNodeMenu_Name = "Scene Management/Activate Loaded Scenes";

		public const int ActivateLoadedScenesNode_CreateNodeMenu_Order = 50;

		public const string ActivateLoadedScenesNode_Manual = "http://doozyui.com/nodes/#ActivateLoadedScenesNode";

		public const string ActivateLoadedScenesNode_YouTube = "https://www.youtube.com/watch?v=rpGb6vKGqfU";

		public const string ApplicationQuitNode_CreateNodeMenu_Name = "System/Application Quit";

		public const int ApplicationQuitNode_CreateNodeMenu_Order = 50;

		public const string ApplicationQuitNode_Manual = "http://doozyui.com/nodes/#ApplicationQuitNode";

		public const string ApplicationQuitNode_YouTube = "https://www.youtube.com/watch?v=G4E_OSisXXM";

		public const string BackButtonNode_CreateNodeMenu_Name = "Navigation/Back Button";

		public const int BackButtonNode_CreateNodeMenu_Order = 50;

		public const string BackButtonNode_Manual = "http://doozyui.com/nodes/#BackButtonNode";

		public const string BackButtonNode_YouTube = "https://www.youtube.com/watch?v=PpZ27a517v0";

		public const string EnterNode_Manual = "http://doozyui.com/nodes/#EnterNode";

		public const string EnterNode_YouTube = "https://www.youtube.com/watch?v=LSLxgpsuJMs";

		public const string ExitNode_Manual = "http://doozyui.com/nodes/#ExitNode";

		public const string ExitNode_YouTube = "https://www.youtube.com/watch?v=LSLxgpsuJMs";

		public const string GameEventNode_CreateNodeMenu_Name = "Game Event";

		public const int GameEventNode_CreateNodeMenu_Order = 1;

		public const string GameEventNode_Manual = "http://doozyui.com/nodes/#GameEventNode";

		public const string GameEventNode_YouTube = "https://www.youtube.com/watch?v=is1C67fWy54";

		public const string LoadSceneNode_CreateNodeMenu_Name = "Scene Management/Load Scene";

		public const int LoadSceneNode_CreateNodeMenu_Order = 50;

		public const string LoadSceneNode_Manual = "http://doozyui.com/nodes/#LoadSceneNode";

		public const string LoadSceneNode_YouTube = "https://www.youtube.com/watch?v=rpGb6vKGqfU";

		public const string PortalNode_CreateNodeMenu_Name = "Navigation/Portal";

		public const int PortalNode_CreateNodeMenu_Order = 50;

		public const string PortalNode_Manual = "http://doozyui.com/nodes/#PortalNode";

		public const string PortalNode_YouTube = "https://www.youtube.com/watch?v=3CMbLmzVZ5o";

		public const string RandomNode_CreateNodeMenu_Name = "System/Random";

		public const int RandomNode_CreateNodeMenu_Order = 50;

		public const string RandomNode_Manual = "http://doozyui.com/nodes/#RandomNode";

		public const string RandomNode_YouTube = "https://www.youtube.com/watch?v=02Rqr4BF0rw";

		public const string SoundNode_CreateNodeMenu_Name = "Sound";

		public const int SoundNode_CreateNodeMenu_Order = 1;

		public const string SoundNode_Manual = "http://doozyui.com/nodes/#SoundNode";

		public const string SoundNode_YouTube = "https://www.youtube.com/watch?v=67QTFzPPFCA";

		public const string StartNode_Manual = "http://doozyui.com/nodes/#StartNode";

		public const string StartNode_YouTube = "https://www.youtube.com/watch?v=LSLxgpsuJMs";

		public const string SubGraphNode_CreateNodeMenu_Name = "SubGraph";

		public const int SubGraphNode_CreateNodeMenu_Order = 1;

		public const string SubGraphNode_Manual = "http://doozyui.com/nodes/#SubGraphNode";

		public const string SubGraphNode_YouTube = "https://www.youtube.com/watch?v=8ETnjKJNJfE";

		public const string SwitchBackNode_CreateNodeMenu_Name = "Navigation/Switch Back";

		public const int SwitchBackNode_CreateNodeMenu_Order = 50;

		public const string SwitchBackNode_Manual = "http://doozyui.com/nodes/#SwitchBackNode";

		public const string SwitchBackNode_YouTube = "https://www.youtube.com/watch?v=oKg1Im0_P54";

		public const string ThemeNode_CreateNodeMenu_Name = "Theme";

		public const int ThemeNode_CreateNodeMenu_Order = 50;

		public const string ThemeNode_Manual = "http://doozyui.com/nodes/#ThemeNode";

		public const string ThemeNode_YouTube = "https://youtu.be/kG6Oe6SXKdo";

		public const string TimeScaleNode_CreateNodeMenu_Name = "System/TimeScale";

		public const int TimeScaleNode_CreateNodeMenu_Order = 50;

		public const string TimeScaleNode_Manual = "http://doozyui.com/nodes/#TimeScaleNode";

		public const string TimeScaleNode_YouTube = "https://www.youtube.com/watch?v=A_9tuCsfB_0";

		public const string UIDrawerNode_CreateNodeMenu_Name = "Navigation/UIDrawer";

		public const int UIDrawerNode_CreateNodeMenu_Order = 50;

		public const string UIDrawerNode_Manual = "http://doozyui.com/nodes/#UIDrawerNode";

		public const string UIDrawerNode_YouTube = "https://www.youtube.com/watch?v=BTZRxxSTOcA";

		public const string UINode_CreateNodeMenu_Name = "UINode";

		public const int UINode_CreateNodeMenu_Order = 0;

		public const string UINode_Manual = "http://doozyui.com/nodes/#UINode";

		public const string UINode_YouTube = "https://www.youtube.com/watch?v=i-kvNakvtvA";

		public const string UnloadSceneNode_CreateNodeMenu_Name = "Scene Management/Unload Scene";

		public const int UnloadSceneNode_CreateNodeMenu_Order = 50;

		public const string UnloadSceneNode_Manual = "http://doozyui.com/nodes/#UnloadSceneNode";

		public const string UnloadSceneNode_YouTube = "https://www.youtube.com/watch?v=rpGb6vKGqfU";

		public const string WaitNode_CreateNodeMenu_Name = "System/Wait";

		public const int WaitNode_CreateNodeMenu_Order = 50;

		public const string WaitNode_Manual = "http://doozyui.com/nodes/#WaitNode";

		public const string WaitNode_YouTube = "https://www.youtube.com/watch?v=9vfO1N6fkiI";

		private const string Orientation_AddComponentMenu_Path = "Doozy/Orientation/";

		private const string Orientation_MenuItem_Path = "GameObject/Doozy/Orientation/";

		public const string OrientationDetector_GameObject_Name = "Orientation Detector";

		public const string OrientationDetector_AddComponentMenu_MenuName = "Doozy/Orientation/Orientation Detector";

		public const int OrientationDetector_AddComponentMenu_Order = 13;

		public const string OrientationDetector_MenuItem_ItemName = "GameObject/Doozy/Orientation/Orientation Detector";

		public const int OrientationDetector_MenuItem_Priority = 13;

		public const string OrientationDetector_Manual = "http://doozyui.com/orientation-detector/";

		public const string OrientationDetector_YouTube = "https://www.youtube.com/watch?v=wT27M7O53g0";

		private const string Playmaker_AddComponentMenu_Path = "Doozy/Playmaker/";

		private const string Playmaker_MenuItem_Path = "GameObject/Doozy/Playmaker/";

		public const string PlaymakerEventDispatcher_GameObject_Name = "Event Dispatcher";

		public const string PlaymakerEventDispatcher_AddComponentMenu_MenuName = "Doozy/Playmaker/Event Dispatcher";

		public const int PlaymakerEventDispatcher_AddComponentMenu_Order = 13;

		public const string PlaymakerEventDispatcher_MenuItem_ItemName = "GameObject/Doozy/Playmaker/Event Dispatcher";

		public const int PlaymakerEventDispatcher_MenuItem_Priority = 13;

		public const string PlaymakerEventDispatcher_Manual = "http://doozyui.com/playmaker-event-dispatcher/";

		public const string PlaymakerEventDispatcher_YouTube = "https://www.youtube.com/user/doozyplay/videos";

		private const string Progress_AddComponentMenu_Path = "Doozy/Progress/";

		private const string Progress_MenuItem_Path = "GameObject/Doozy/Progress/";

		public const string Progressor_GameObject_Name = "Progressor";

		public const string Progressor_AddComponentMenu_MenuName = "Doozy/Progress/Progressor";

		public const int Progressor_AddComponentMenu_Order = 13;

		public const string Progressor_MenuItem_ItemName = "GameObject/Doozy/Progress/Progressor";

		public const int Progressor_MenuItem_Priority = 13;

		public const string Progressor_Manual = "http://doozyui.com/progressor/";

		public const string Progressor_YouTube = "https://www.youtube.com/watch?v=kp84R8n7VLY";

		public const string ProgressorGroup_GameObject_Name = "Progressor Group";

		public const string ProgressorGroup_AddComponentMenu_MenuName = "Doozy/Progress/Progressor Group";

		public const int ProgressorGroup_AddComponentMenu_Order = 13;

		public const string ProgressorGroup_MenuItem_ItemName = "GameObject/Doozy/Progress/Progressor Group";

		public const int ProgressorGroup_MenuItem_Priority = 13;

		public const string ProgressorGroup_Manual = "http://doozyui.com/progressor-group/";

		public const string ProgressorGroup_YouTube = "https://www.youtube.com/watch?v=y9-pit5yMsg";

		private const string Progress_Targets_AddComponentMenu_Path = "Doozy/Progress/Targets/";

		private const string Progress_Targets_MenuItem_Path = "GameObject/Doozy/Progress/Targets/";

		public const string ProgressTargetAction_GameObject_Name = "Progress Target Action";

		public const string ProgressTargetAction_AddComponentMenu_MenuName = "Doozy/Progress/Targets/Progress Target Action";

		public const int ProgressTargetAction_AddComponentMenu_Order = 13;

		public const string ProgressTargetAction_MenuItem_ItemName = "GameObject/Doozy/Progress/Targets/Progress Target Action";

		public const int ProgressTargetAction_MenuItem_Priority = 13;

		public const string ProgressTargetAction_Manual = "http://doozyui.com/progress-target-action/";

		public const string ProgressTargetAction_YouTube = "https://youtu.be/3sbfZOJJzzE";

		public const string ProgressTargetAnimator_GameObject_Name = "Progress Target Animator";

		public const string ProgressTargetAnimator_AddComponentMenu_MenuName = "Doozy/Progress/Targets/Progress Target Animator";

		public const int ProgressTargetAnimator_AddComponentMenu_Order = 13;

		public const string ProgressTargetAnimator_MenuItem_ItemName = "GameObject/Doozy/Progress/Targets/Progress Target Animator";

		public const int ProgressTargetAnimator_MenuItem_Priority = 13;

		public const string ProgressTargetAnimator_Manual = "http://doozyui.com/progress-target-animator/";

		public const string ProgressTargetAnimator_YouTube = "https://www.youtube.com/watch?v=c2T3M--Ty50";

		public const string ProgressTargetAudioMixer_GameObject_Name = "Progress Target AudioMixer";

		public const string ProgressTargetAudioMixer_AddComponentMenu_MenuName = "Doozy/Progress/Targets/Progress Target AudioMixer";

		public const int ProgressTargetAudioMixer_AddComponentMenu_Order = 13;

		public const string ProgressTargetAudioMixer_MenuItem_ItemName = "GameObject/Doozy/Progress/Targets/Progress Target AudioMixer";

		public const int ProgressTargetAudioMixer_MenuItem_Priority = 13;

		public const string ProgressTargetAudioMixer_Manual = "http://doozyui.com/progress-target-audiomixer/";

		public const string ProgressTargetAudioMixer_YouTube = "https://youtu.be/rkfs7EHHKzY";

		public const string ProgressTargetImage_GameObject_Name = "Progress Target Image";

		public const string ProgressTargetImage_AddComponentMenu_MenuName = "Doozy/Progress/Targets/Progress Target Image";

		public const int ProgressTargetImage_AddComponentMenu_Order = 13;

		public const string ProgressTargetImage_MenuItem_ItemName = "GameObject/Doozy/Progress/Targets/Progress Target Image";

		public const int ProgressTargetImage_MenuItem_Priority = 13;

		public const string ProgressTargetImage_Manual = "http://doozyui.com/progress-target-image/";

		public const string ProgressTargetImage_YouTube = "https://www.youtube.com/watch?v=XUH85WaPg_0";

		public const string ProgressTargetText_GameObject_Name = "Progress Target Text";

		public const string ProgressTargetText_AddComponentMenu_MenuName = "Doozy/Progress/Targets/Progress Target Text";

		public const int ProgressTargetText_AddComponentMenu_Order = 13;

		public const string ProgressTargetText_MenuItem_ItemName = "GameObject/Doozy/Progress/Targets/Progress Target Text";

		public const int ProgressTargetText_MenuItem_Priority = 13;

		public const string ProgressTargetText_Manual = "http://doozyui.com/progress-target-text/";

		public const string ProgressTargetText_YouTube = "https://www.youtube.com/watch?v=yVIs0oq7S3w";

		public const string ProgressTargetTextMeshPro_GameObject_Name = "Progress Target TextMeshPro";

		public const string ProgressTargetTextMeshPro_AddComponentMenu_MenuName = "Doozy/Progress/Targets/Progress Target TextMeshPro";

		public const int ProgressTargetTextMeshPro_AddComponentMenu_Order = 13;

		public const string ProgressTargetTextMeshPro_MenuItem_ItemName = "GameObject/Doozy/Progress/Targets/Progress Target TextMeshPro";

		public const int ProgressTargetTextMeshPro_MenuItem_Priority = 13;

		public const string ProgressTargetTextMeshPro_Manual = "http://doozyui.com/progress-target-textmeshpro/";

		public const string ProgressTargetTextMeshPro_YouTube = "https://www.youtube.com/watch?v=iwhcj4XdBzM";

		private const string SceneManagement_AddComponentMenu_Path = "Doozy/SceneManagement/";

		private const string SceneManagement_MenuItem_Path = "GameObject/Doozy/SceneManagement/";

		public const string SceneLoader_GameObject_Name = "Scene Loader";

		public const string SceneLoader_AddComponentMenu_MenuName = "Doozy/SceneManagement/Scene Loader";

		public const int SceneLoader_AddComponentMenu_Order = 13;

		public const string SceneLoader_MenuItem_ItemName = "GameObject/Doozy/SceneManagement/Scene Loader";

		public const int SceneLoader_MenuItem_Priority = 13;

		public const string SceneLoader_Manual = "http://doozyui.com/scene-loader/";

		public const string SceneLoader_YouTube = "https://www.youtube.com/watch?v=mViQaOf3aO8";

		public const string SceneDirector_GameObject_Name = "Scene Director";

		public const string SceneDirector_AddComponentMenu_MenuName = "Doozy/SceneManagement/Scene Director";

		public const int SceneDirector_AddComponentMenu_Order = 13;

		public const string SceneDirector_MenuItem_ItemName = "GameObject/Doozy/SceneManagement/Scene Director";

		public const int SceneDirector_MenuItem_Priority = 13;

		public const string SceneDirector_Manual = "http://doozyui.com/scene-director/";

		public const string SceneDirector_YouTube = "https://www.youtube.com/watch?v=jhiAnlcRjug";

		private const string Soundy_AddComponentMenu_Path = "Doozy/Soundy/";

		private const string Soundy_MenuItem_Path = "GameObject/Doozy/Soundy/";

		public const string SoundyManager_GameObject_Name = "Soundy Manager";

		public const string SoundyManager_AddComponentMenu_MenuName = "Doozy/Soundy/Soundy Manager";

		public const int SoundyManager_AddComponentMenu_Order = 13;

		public const string SoundyManager_MenuItem_ItemName = "GameObject/Doozy/Soundy/Soundy Manager";

		public const int SoundyManager_MenuItem_Priority = 13;

		public const string SoundyManager_Manual = "http://doozyui.com/soundy-manager/";

		public const string SoundyManager_YouTube = "https://www.youtube.com/watch?v=oe86Q0Bljtc";

		private const string Themes_AddComponentMenu_Path = "Doozy/Themes/";

		private const string Themes_MenuItem_Path = "GameObject/Doozy/Themes/";

		public const string ThemeManager_GameObject_Name = "Theme Manager";

		public const string ThemeManager_AddComponentMenu_MenuName = "Doozy/Themes/Theme Manager";

		public const int ThemeManager_AddComponentMenu_Order = 13;

		public const string ThemeManager_MenuItem_ItemName = "GameObject/Doozy/Themes/Theme Manager";

		public const int ThemeManager_MenuItem_Priority = 13;

		public const string ThemeManager_Manual = "http://doozyui.com/theme-manager/";

		public const string ThemeManager_YouTube = "https://youtu.be/h3Q8AvugeWc";

		private const string Themes_Targets_AddComponentMenu_Path = "Doozy/Themes/Targets/";

		private const string Themes_Targets_MenuItem_Path = "GameObject/Doozy/Themes/Targets/";

		public const string ColorTargetImage_GameObject_Name = "Color Target Image";

		public const string ColorTargetImage_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Color Target Image";

		public const int ColorTargetImage_AddComponentMenu_Order = 13;

		public const string ColorTargetImage_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Color Target Image";

		public const int ColorTargetImage_MenuItem_Priority = 13;

		public const string ColorTargetImage_Manual = "http://doozyui.com/color-target-image/";

		public const string ColorTargetImage_YouTube = "https://youtu.be/RCo_mh15vDw";

		public const string ColorTargetParticleSystem_GameObject_Name = "Color Target ParticleSystem";

		public const string ColorTargetParticleSystem_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Color Target ParticleSystem";

		public const int ColorTargetParticleSystem_AddComponentMenu_Order = 13;

		public const string ColorTargetParticleSystem_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Color Target ParticleSystem";

		public const int ColorTargetParticleSystem_MenuItem_Priority = 13;

		public const string ColorTargetParticleSystem_Manual = "http://doozyui.com/color-target-particlesystem/";

		public const string ColorTargetParticleSystem_YouTube = "https://youtu.be/eePa65aT_4Q";

		public const string ColorTargetRawImage_GameObject_Name = "Color Target RawImage";

		public const string ColorTargetRawImage_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Color Target RawImage";

		public const int ColorTargetRawImage_AddComponentMenu_Order = 13;

		public const string ColorTargetRawImage_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Color Target RawImage";

		public const int ColorTargetRawImage_MenuItem_Priority = 13;

		public const string ColorTargetRawImage_Manual = "http://doozyui.com/color-target-rawimage/";

		public const string ColorTargetRawImage_YouTube = "https://youtu.be/5wgYhIY5hVQ";

		public const string ColorTargetSpriteRenderer_GameObject_Name = "Color Target SpriteRenderer";

		public const string ColorTargetSpriteRenderer_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Color Target SpriteRenderer";

		public const int ColorTargetSpriteRenderer_AddComponentMenu_Order = 13;

		public const string ColorTargetSpriteRenderer_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Color Target SpriteRenderer";

		public const int ColorTargetSpriteRenderer_MenuItem_Priority = 13;

		public const string ColorTargetSpriteRenderer_Manual = "http://doozyui.com/color-target-spriterenderer/";

		public const string ColorTargetSpriteRenderer_YouTube = "https://youtu.be/OJCM7nbIoQc";

		public const string ColorTargetText_GameObject_Name = "Color Target Text";

		public const string ColorTargetText_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Color Target Text";

		public const int ColorTargetText_AddComponentMenu_Order = 13;

		public const string ColorTargetText_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Color Target Text";

		public const int ColorTargetText_MenuItem_Priority = 13;

		public const string ColorTargetText_Manual = "http://doozyui.com/color-target-text/";

		public const string ColorTargetText_YouTube = "https://youtu.be/5HLQnq013ls";

		public const string ColorTargetTextMeshPro_GameObject_Name = "Color Target TextMeshPro";

		public const string ColorTargetTextMeshPro_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Color Target TextMeshPro";

		public const int ColorTargetTextMeshPro_AddComponentMenu_Order = 13;

		public const string ColorTargetTextMeshPro_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Color Target TextMeshPro";

		public const int ColorTargetTextMeshPro_MenuItem_Priority = 13;

		public const string ColorTargetTextMeshPro_Manual = "http://doozyui.com/color-target-textmeshpro/";

		public const string ColorTargetTextMeshPro_YouTube = "https://youtu.be/WEisFz1q0Uw";

		public const string ColorTargetSelectable_GameObject_Name = "Color Target Selectable";

		public const string ColorTargetSelectable_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Color Target Selectable";

		public const int ColorTargetSelectable_AddComponentMenu_Order = 13;

		public const string ColorTargetSelectable_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Color Target Selectable";

		public const int ColorTargetSelectable_MenuItem_Priority = 13;

		public const string ColorTargetSelectable_Manual = "http://doozyui.com/color-target-selectable/";

		public const string ColorTargetSelectable_YouTube = "https://youtu.be/y04XQORK6Kk";

		public const string ColorTargetUnityEvent_GameObject_Name = "Color Target UnityEvent";

		public const string ColorTargetUnityEvent_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Color Target UnityEvent";

		public const int ColorTargetUnityEvent_AddComponentMenu_Order = 13;

		public const string ColorTargetUnityEvent_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Color Target UnityEvent";

		public const int ColorTargetUnityEvent_MenuItem_Priority = 13;

		public const string ColorTargetUnityEvent_Manual = "http://doozyui.com/color-target-unityevent/";

		public const string ColorTargetUnityEvent_YouTube = "https://youtu.be/ChkOH_-zbHU";

		public const string FontTargetText_GameObject_Name = "Font Target Text";

		public const string FontTargetText_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Font Target Text";

		public const int FontTargetText_AddComponentMenu_Order = 13;

		public const string FontTargetText_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Font Target Text";

		public const int FontTargetText_MenuItem_Priority = 13;

		public const string FontTargetText_Manual = "http://doozyui.com/font-target-text/";

		public const string FontTargetText_YouTube = "https://youtu.be/Nwfj83VrMuM";

		public const string FontTargetTextMeshPro_GameObject_Name = "Font Target TextMeshPro";

		public const string FontTargetTextMeshPro_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Font Target TextMeshPro";

		public const int FontTargetTextMeshPro_AddComponentMenu_Order = 13;

		public const string FontTargetTextMeshPro_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Font Target TextMeshPro";

		public const int FontTargetTextMeshPro_MenuItem_Priority = 13;

		public const string FontTargetTextMeshPro_Manual = "http://doozyui.com/font-target-textmeshpro/";

		public const string FontTargetTextMeshPro_YouTube = "https://youtu.be/3YUXhF_eY8w";

		public const string SpriteTargetImage_GameObject_Name = "Sprite Target Image";

		public const string SpriteTargetImage_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Sprite Target Image";

		public const int SpriteTargetImage_AddComponentMenu_Order = 13;

		public const string SpriteTargetImage_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Sprite Target Image";

		public const int SpriteTargetImage_MenuItem_Priority = 13;

		public const string SpriteTargetImage_Manual = "http://doozyui.com/sprite-target-image/";

		public const string SpriteTargetImage_YouTube = "https://youtu.be/dZlHNHfR0po";

		public const string SpriteTargetSelectable_GameObject_Name = "Sprite Target Selectable";

		public const string SpriteTargetSelectable_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Sprite Target Selectable";

		public const int SpriteTargetSelectable_AddComponentMenu_Order = 13;

		public const string SpriteTargetSelectable_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Sprite Target Selectable";

		public const int SpriteTargetSelectable_MenuItem_Priority = 13;

		public const string SpriteTargetSelectable_Manual = "http://doozyui.com/sprite-target-selectable/";

		public const string SpriteTargetSelectable_YouTube = "https://youtu.be/jkIlc-6xv04";

		public const string SpriteTargetSpriteRenderer_GameObject_Name = "Sprite Target SpriteRenderer";

		public const string SpriteTargetSpriteRenderer_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Sprite Target SpriteRenderer";

		public const int SpriteTargetSpriteRenderer_AddComponentMenu_Order = 13;

		public const string SpriteTargetSpriteRenderer_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Sprite Target SpriteRenderer";

		public const int SpriteTargetSpriteRenderer_MenuItem_Priority = 13;

		public const string SpriteTargetSpriteRenderer_Manual = "http://doozyui.com/sprite-target-spriterenderer/";

		public const string SpriteTargetSpriteRenderer_YouTube = "https://youtu.be/umoIvXb57Ys";

		public const string SpriteTargetUnityEvent_GameObject_Name = "Sprite Target UnityEvent";

		public const string SpriteTargetUnityEvent_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Sprite Target UnityEvent";

		public const int SpriteTargetUnityEvent_AddComponentMenu_Order = 13;

		public const string SpriteTargetUnityEvent_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Sprite Target UnityEvent";

		public const int SpriteTargetUnityEvent_MenuItem_Priority = 13;

		public const string SpriteTargetUnityEvent_Manual = "http://doozyui.com/sprite-target-unityevent/";

		public const string SpriteTargetUnityEvent_YouTube = "https://youtu.be/Wbw_eHJRQcM";

		public const string TextureTargetRawImage_GameObject_Name = "Texture Target RawImage";

		public const string TextureTargetRawImage_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Texture Target RawImage";

		public const int TextureTargetRawImage_AddComponentMenu_Order = 13;

		public const string TextureTargetRawImage_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Texture Target RawImage";

		public const int TextureTargetRawImage_MenuItem_Priority = 13;

		public const string TextureTargetRawImage_Manual = "http://doozyui.com/texture-target-rawimage/";

		public const string TextureTargetRawImage_YouTube = "https://youtu.be/ZJkcAoiCV4Q";

		public const string TextureTargetUnityEvent_GameObject_Name = "Texture Target UnityEvent";

		public const string TextureTargetUnityEvent_AddComponentMenu_MenuName = "Doozy/Themes/Targets/Texture Target UnityEvent";

		public const int TextureTargetUnityEvent_AddComponentMenu_Order = 13;

		public const string TextureTargetUnityEvent_MenuItem_ItemName = "GameObject/Doozy/Themes/Targets/Texture Target UnityEvent";

		public const int TextureTargetUnityEvent_MenuItem_Priority = 13;

		public const string TextureTargetUnityEvent_Manual = "http://doozyui.com/texture-target-unityevent/";

		public const string TextureTargetUnityEvent_YouTube = "https://youtu.be/_-KnTuoBIhw";

		private const string Touchy_AddComponentMenu_Path = "Doozy/Touchy/";

		private const string Touchy_MenuItem_Path = "GameObject/Doozy/Touchy/";

		public const string GestureListener_GameObject_Name = "Gesture Listener";

		public const string GestureListener_AddComponentMenu_MenuName = "Doozy/Touchy/Gesture Listener";

		public const int GestureListener_AddComponentMenu_Order = 13;

		public const string GestureListener_MenuItem_ItemName = "GameObject/Doozy/Touchy/Gesture Listener";

		public const int GestureListener_MenuItem_Priority = 13;

		public const string GestureListener_Manual = "http://doozyui.com/gesture-listener/";

		public const string GestureListener_YouTube = "https://www.youtube.com/watch?v=x697qCs12QU";

		public const string TouchDetector_GameObject_Name = "Touch Detector";

		public const string TouchDetector_AddComponentMenu_MenuName = "Doozy/Touchy/Touch Detector";

		public const int TouchDetector_AddComponentMenu_Order = 13;

		public const string TouchDetector_MenuItem_ItemName = "GameObject/Doozy/Touchy/Touch Detector";

		public const int TouchDetector_MenuItem_Priority = 13;

		public const string TouchDetector_Manual = "http://doozyui.com/touch-detector/";

		public const string TouchDetector_YouTube = "https://www.youtube.com/watch?v=ZTz3V8Lv-jQ";

		private const string UI_AddComponentMenu_Path = "Doozy/UI/";

		private const string UI_MenuItem_Path = "GameObject/Doozy/UI/";

		public const string UIButton_GameObject_Name = "UIButton";

		public const string UIButton_AddComponentMenu_MenuName = "Doozy/UI/UIButton";

		public const int UIButton_AddComponentMenu_Order = 2;

		public const string UIButton_MenuItem_ItemName = "GameObject/Doozy/UI/UIButton";

		public const int UIButton_MenuItem_Priority = 2;

		public const string UIButton_Manual = "http://doozyui.com/uibutton/";

		public const string UIButton_YouTube = "https://www.youtube.com/watch?v=Cf73pHkkkAo";

		public const string UICanvas_GameObject_Name = "UICanvas";

		public const string UICanvas_AddComponentMenu_MenuName = "Doozy/UI/UICanvas";

		public const int UICanvas_AddComponentMenu_Order = 2;

		public const string UICanvas_MenuItem_ItemName = "GameObject/Doozy/UI/UICanvas";

		public const int UICanvas_MenuItem_Priority = 2;

		public const string UICanvas_Manual = "http://doozyui.com/uicanvas/";

		public const string UICanvas_YouTube = "https://www.youtube.com/watch?v=6CCdgP-fdr4";

		public const string UIDrawer_GameObject_Name = "UIDrawer";

		public const string UIDrawer_AddComponentMenu_MenuName = "Doozy/UI/UIDrawer";

		public const int UIDrawer_AddComponentMenu_Order = 2;

		public const string UIDrawer_MenuItem_ItemName = "GameObject/Doozy/UI/UIDrawer";

		public const int UIDrawer_MenuItem_Priority = 2;

		public const string UIDrawer_Manual = "http://doozyui.com/uidrawer/";

		public const string UIDrawer_YouTube = "https://www.youtube.com/watch?v=rhHSvTZckAk";

		public const string UIImage_GameObject_Name = "UIImage";

		public const string UIImage_AddComponentMenu_MenuName = "Doozy/UI/UIImage";

		public const int UIImage_AddComponentMenu_Order = 2;

		public const string UIImage_MenuItem_ItemName = "GameObject/Doozy/UI/UIImage";

		public const int UIImage_MenuItem_Priority = 2;

		public const string UIImage_Manual = "http://doozyui.com/uiimage/";

		public const string UIImage_YouTube = "https://youtu.be/rpeNiPES4e0";

		public const string UIPopup_GameObject_Name = "UIPopup";

		public const string UIPopup_AddComponentMenu_MenuName = "Doozy/UI/UIPopup";

		public const int UIPopup_AddComponentMenu_Order = 2;

		public const string UIPopup_MenuItem_ItemName = "GameObject/Doozy/UI/UIPopup";

		public const int UIPopup_MenuItem_Priority = 2;

		public const string UIPopup_Manual = "http://doozyui.com/uipopup/";

		public const string UIPopup_YouTube = "https://www.youtube.com/watch?v=TQXgouPw5rY";

		public const string UIView_GameObject_Name = "UIView";

		public const string UIView_AddComponentMenu_MenuName = "Doozy/UI/UIView";

		public const int UIView_AddComponentMenu_Order = 2;

		public const string UIView_MenuItem_ItemName = "GameObject/Doozy/UI/UIView";

		public const int UIView_MenuItem_Priority = 2;

		public const string UIView_Manual = "http://doozyui.com/uiview/";

		public const string UIView_YouTube = "https://www.youtube.com/watch?v=fzetthl5dSA";

		public const string UIToggle_GameObject_Name = "UIToggle";

		public const string UIToggle_AddComponentMenu_MenuName = "Doozy/UI/UIToggle";

		public const int UIToggle_AddComponentMenu_Order = 2;

		public const string UIToggle_MenuItem_ItemName = "GameObject/Doozy/UI/UIToggle";

		public const int UIToggle_MenuItem_Priority = 2;

		public const string UIToggle_Manual = "http://doozyui.com/uitoggle/";

		public const string UIToggle_YouTube = "https://www.youtube.com/watch?v=aTzuxGstbbY";

		public const string DoozyWindow_MenuItem_ItemName = "Tools/Doozy/Control Panel &d";

		public const string DoozyWindow_OpenShortcut = " &d";

		public const int DoozyWindow_MenuItem_Order = 0;

		public const string Refresh_MenuItem_ItemName = "Tools/Doozy/Refresh";

		public const string Refresh_OpenShortcut = "";

		public const int Refresh_MenuItem_Order = 1;

		public const string NodyWindow_MenuItem_ItemName = "Tools/Doozy/Nody";

		public const string NodyWindow_OpenShortcut = "";

		public const int NodyWindow_MenuItem_Order = 900;
	}
}
