using System;
using Cpp2ILInjected;
using Doozy.Engine.Progress;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
	private static SceneDirector s_instance;

	private static bool _003CApplicationIsQuitting_003Ek__BackingField;

	public bool DebugMode;

	public ActiveSceneChangedEvent OnActiveSceneChanged;

	public SceneLoadedEvent OnSceneLoaded;

	public SceneUnloadedEvent OnSceneUnloaded;

	public static SceneDirector Instance
	{
		get
		{
			SceneDirector sceneDirector = s_instance;
			if ((object)s_instance == null || ((UnityEngine.Object)sceneDirector).m_CachedPtr == (IntPtr)0)
			{
				if (_003CApplicationIsQuitting_003Ek__BackingField)
				{
					return null;
				}
				SceneDirector sceneDirector2 = UnityEngine.Object.FindObjectOfType<SceneDirector>();
				s_instance = sceneDirector2;
				SceneDirector sceneDirector3 = s_instance;
				if ((object)s_instance == null || ((UnityEngine.Object)sceneDirector3).m_CachedPtr == (IntPtr)0)
				{
					SceneDirector sceneDirector4 = DoozyUtils.AddToScene<SceneDirector>("Scene Director", isSingleton: true);
					if ((object)sceneDirector4 == null)
					{
						return (SceneDirector)(object)new NullReferenceException();
					}
					GameObject target = sceneDirector4.gameObject;
					UnityEngine.Object.DontDestroyOnLoad(target);
				}
			}
			return s_instance;
		}
	}

	private static bool ApplicationIsQuitting
	{
		get
		{
			return _003CApplicationIsQuitting_003Ek__BackingField;
		}
		set
		{
			_003CApplicationIsQuitting_003Ek__BackingField = value;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_0063: Expected I4, but got O
			if (DebugMode)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugSceneDirector;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	protected SceneDirector()
	{
		ActiveSceneChangedEvent activeSceneChangedEvent = (ActiveSceneChangedEvent)new UnityEventBase();
		_ = 0;
		((UnityEventBase)activeSceneChangedEvent)._002Ector();
		OnActiveSceneChanged = activeSceneChangedEvent;
		SceneLoadedEvent onSceneLoaded = (SceneLoadedEvent)new UnityEventBase();
		_ = 0;
		OnSceneLoaded = onSceneLoaded;
		SceneUnloadedEvent onSceneUnloaded = (SceneUnloadedEvent)new UnityEventBase();
		_ = 0;
		OnSceneUnloaded = onSceneUnloaded;
	}

	private static void RunOnStart()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = false;
	}

	private void Awake()
	{
		//IL_01fb: Expected O, but got I4
		//IL_0215: Expected O, but got I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		SceneDirector sceneDirector = s_instance;
		if ((object)s_instance != null && ((UnityEngine.Object)sceneDirector).m_CachedPtr != (IntPtr)0)
		{
			SceneDirector sceneDirector2 = s_instance;
			bool flag = (object)s_instance == null;
			bool flag2 = (object)this == null;
			object obj = flag2 & flag;
			bool flag3 = obj == null;
			object obj2 = !flag3;
			if (obj2 == null)
			{
				bool flag4;
				if ((object)this != null)
				{
					if ((object)s_instance != null)
					{
						object obj3 = (object)s_instance - (object)this;
						flag4 = obj3 == null;
					}
					else
					{
						flag4 = ((UnityEngine.Object)this).m_CachedPtr == (IntPtr)0;
					}
				}
				else
				{
					flag4 = ((UnityEngine.Object)sceneDirector2).m_CachedPtr == (IntPtr)0;
				}
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
					object obj5 = default(object);
					object obj4 = obj5 + 32;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
					object obj6 = default(object);
					string text;
					string text2 = default(string);
					if (obj6 != null)
					{
						object obj7 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v600 @ rdx_v12+168] (should have been resolved before IL gen)");
						text = "There cannot be two ";
					}
					else
					{
						text = "There cannot be two ";
						text2 = null;
					}
					string message = text + text2 + "' active at the same time. Destroying this one!";
					DDebug.Log(message);
					GameObject obj8 = base.gameObject;
					UnityEngine.Object.Destroy(obj8, 0f);
					return;
				}
			}
		}
		s_instance = this;
		GameObject target = base.gameObject;
		UnityEngine.Object.DontDestroyOnLoad(target);
	}

	private void OnEnable()
	{
		// ILSpy could not decompile this. Please report the exception below,
		// along with the assembly it came from, at https://github.com/icsharpcode/ILSpy/issues/new
		// System.BadImageFormatException: Read out of bounds.
		//    at System.Reflection.Throw.OutOfBounds()
		//    at ICSharpCode.Decompiler.SRMExtensions.HasBody(MethodDefinition methodDefinition) in /_/ICSharpCode.Decompiler/SRMExtensions.cs:line 135
		//    at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileBodyForAnalysis(IMethod method, IDecompilerTypeSystem typeSystem, CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/CSharp/CSharpDecompiler.cs:line 196
		//    at ICSharpCode.Decompiler.CSharp.AutoEventDecompiler.IsAutomaticAccessor(IDecompilerTypeSystem typeSystem, IMethod accessor, IField field, Boolean isAddAccessor, CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/CSharp/AutoEventDecompiler.cs:line 123
		//    at ICSharpCode.Decompiler.CSharp.AutoEventDecompiler.IsAutomaticEvent(IDecompilerTypeSystem typeSystem, IEvent ev, CancellationToken cancellationToken, IField& backingField) in /_/ICSharpCode.Decompiler/CSharp/AutoEventDecompiler.cs:line 70
		//    at ICSharpCode.Decompiler.CSharp.AutoEventDecompiler.IsAutomaticEvent(IDecompilerTypeSystem typeSystem, IEvent ev, DecompileRun decompileRun, CancellationToken cancellationToken, IField& backingField) in /_/ICSharpCode.Decompiler/CSharp/AutoEventDecompiler.cs:line 51
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.ConvertField(IField field, ILInstruction targetInstruction) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 304
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.VisitLdsFlda(LdsFlda inst, TranslationContext context) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 3198
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.LdObj(ILInstruction address, IType loadType) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 2896
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.VisitLdObj(LdObj inst, TranslationContext context) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 2888
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.VisitStLoc(StLoc inst, TranslationContext context) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 811
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitStLoc(StLoc inst) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 118
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.ConvertBlockContainer(BlockStatement blockStatement, BlockContainer container, IEnumerable`1 blocks, Boolean isLoop) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1547
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.ConvertBlockContainer(BlockContainer container, Boolean isLoop) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1434
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitBlockContainer(BlockContainer container) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1320
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.ConvertAsBlock(ILInstruction inst) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 87
		//    at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileBody(IMethod method, EntityDeclaration entityDecl, DecompileRun decompileRun, ITypeResolveContext decompilationContext, ExtensionInfo extensionInfo) in /_/ICSharpCode.Decompiler/CSharp/CSharpDecompiler.cs:line 2325
	}

	private void OnDisable()
	{
		// ILSpy could not decompile this. Please report the exception below,
		// along with the assembly it came from, at https://github.com/icsharpcode/ILSpy/issues/new
		// System.BadImageFormatException: Read out of bounds.
		//    at System.Reflection.Throw.OutOfBounds()
		//    at ICSharpCode.Decompiler.SRMExtensions.HasBody(MethodDefinition methodDefinition) in /_/ICSharpCode.Decompiler/SRMExtensions.cs:line 135
		//    at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileBodyForAnalysis(IMethod method, IDecompilerTypeSystem typeSystem, CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/CSharp/CSharpDecompiler.cs:line 196
		//    at ICSharpCode.Decompiler.CSharp.AutoEventDecompiler.IsAutomaticAccessor(IDecompilerTypeSystem typeSystem, IMethod accessor, IField field, Boolean isAddAccessor, CancellationToken cancellationToken) in /_/ICSharpCode.Decompiler/CSharp/AutoEventDecompiler.cs:line 123
		//    at ICSharpCode.Decompiler.CSharp.AutoEventDecompiler.IsAutomaticEvent(IDecompilerTypeSystem typeSystem, IEvent ev, CancellationToken cancellationToken, IField& backingField) in /_/ICSharpCode.Decompiler/CSharp/AutoEventDecompiler.cs:line 70
		//    at ICSharpCode.Decompiler.CSharp.AutoEventDecompiler.IsAutomaticEvent(IDecompilerTypeSystem typeSystem, IEvent ev, DecompileRun decompileRun, CancellationToken cancellationToken, IField& backingField) in /_/ICSharpCode.Decompiler/CSharp/AutoEventDecompiler.cs:line 51
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.ConvertField(IField field, ILInstruction targetInstruction) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 304
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.VisitLdsFlda(LdsFlda inst, TranslationContext context) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 3198
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.LdObj(ILInstruction address, IType loadType) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 2896
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.VisitLdObj(LdObj inst, TranslationContext context) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 2888
		//    at ICSharpCode.Decompiler.CSharp.ExpressionBuilder.VisitStLoc(StLoc inst, TranslationContext context) in /_/ICSharpCode.Decompiler/CSharp/ExpressionBuilder.cs:line 811
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitStLoc(StLoc inst) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 118
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.ConvertBlockContainer(BlockStatement blockStatement, BlockContainer container, IEnumerable`1 blocks, Boolean isLoop) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1547
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.ConvertBlockContainer(BlockContainer container, Boolean isLoop) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1434
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.VisitBlockContainer(BlockContainer container) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 1320
		//    at ICSharpCode.Decompiler.CSharp.StatementBuilder.ConvertAsBlock(ILInstruction inst) in /_/ICSharpCode.Decompiler/CSharp/StatementBuilder.cs:line 87
		//    at ICSharpCode.Decompiler.CSharp.CSharpDecompiler.DecompileBody(IMethod method, EntityDeclaration entityDecl, DecompileRun decompileRun, ITypeResolveContext decompilationContext, ExtensionInfo extensionInfo) in /_/ICSharpCode.Decompiler/CSharp/CSharpDecompiler.cs:line 2325
	}

	private void OnApplicationQuit()
	{
		_003CApplicationIsQuitting_003Ek__BackingField = true;
	}

	private void ActiveSceneChanged(Scene current, Scene next)
	{
		//IL_0073: Expected I4, but got O
		//IL_0080: Expected I4, but got O
		if (OnActiveSceneChanged == null)
		{
			return;
		}
		OnActiveSceneChanged.Invoke(current, next);
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugSceneDirector)
			{
				return;
			}
		}
		string nameInternal = Scene.GetNameInternal((int)current);
		string nameInternal2 = Scene.GetNameInternal((int)next);
		string message = "Active Scene Changed - Replaced Scene: " + nameInternal + " / Next Scene: " + nameInternal2;
		DDebug.Log(message, this);
	}

	private unsafe void SceneLoaded(Scene scene, LoadSceneMode mode)
	{
		//IL_0073: Expected I4, but got O
		//IL_0080: Expected O, but got Ref
		if (OnSceneLoaded == null)
		{
			return;
		}
		((UnityEvent<Scene, System.Int32Enum>)(object)OnSceneLoaded).Invoke(scene, (System.Int32Enum)mode);
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugSceneDirector)
			{
				return;
			}
		}
		string nameInternal = Scene.GetNameInternal((int)scene);
		IntPtr intPtr = default(IntPtr);
		string text = ((Enum)(&intPtr)).ToString();
		string message = "Scene Loaded - Scene: " + nameInternal + " / LoadSceneMode: " + text;
		DDebug.Log(message, this);
	}

	private void SceneUnloaded(Scene unloadedScene)
	{
		//IL_006f: Expected I4, but got O
		if (OnSceneUnloaded == null)
		{
			return;
		}
		OnSceneUnloaded.Invoke(unloadedScene);
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugSceneDirector)
			{
				return;
			}
		}
		string nameInternal = Scene.GetNameInternal((int)unloadedScene);
		string message = "Scene Unloaded - Scene: " + nameInternal;
		DDebug.Log(message, this);
	}

	public unsafe static SceneLoader LoadSceneAsync(int sceneBuildIndex, LoadSceneMode loadSceneMode, Progressor progressor = null)
	{
		//IL_00db: Expected O, but got Ref
		SceneDirector instance = Instance;
		string[] array;
		if ((object)instance != null)
		{
			if (!instance.DebugMode)
			{
				DoozySettings instance2 = DoozySettings.Instance;
				if ((object)instance2 == null)
				{
					goto IL_024d;
				}
				if (!instance2.DebugSceneDirector)
				{
					goto IL_015f;
				}
			}
			array = new string[6];
			if (array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				int num = default(int);
				string text = num.ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				object obj = default(object);
				string text2 = ((Enum)(&obj)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				object obj2;
				if ((object)progressor != null)
				{
					bool flag = ((UnityEngine.Object)progressor).m_CachedPtr != (IntPtr)0;
					obj2 = "Yes";
					if (flag)
					{
						goto IL_02a3;
					}
				}
				obj2 = "No";
				goto IL_02a3;
			}
		}
		goto IL_024d;
		IL_02a3:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string message = string.Concat(array);
		SceneDirector instance3 = Instance;
		DDebug.Log(message, instance3);
		goto IL_015f;
		IL_024d:
		return (SceneLoader)(object)new NullReferenceException();
		IL_015f:
		SceneLoader loader = SceneLoader.GetLoader();
		if ((object)loader != null)
		{
			loader.SceneBuildIndex = sceneBuildIndex;
			loader.GetSceneBy = GetSceneBy.BuildIndex;
			loader.Progressor = progressor;
			loader.LoadSceneMode = loadSceneMode;
			if (loader.GetSceneBy == GetSceneBy.Name)
			{
				Progressor progressor2 = loader.LoadSceneAsync(loader.SceneName, loadSceneMode);
			}
			else if (loader.GetSceneBy == GetSceneBy.BuildIndex)
			{
				Progressor progressor3 = loader.LoadSceneAsync(loader.SceneBuildIndex, loadSceneMode);
			}
			return loader;
		}
		goto IL_024d;
	}

	public unsafe static SceneLoader LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode, Progressor progressor = null)
	{
		//IL_00c9: Expected O, but got Ref
		SceneDirector instance = Instance;
		string[] array;
		if ((object)instance != null)
		{
			if (!instance.DebugMode)
			{
				DoozySettings instance2 = DoozySettings.Instance;
				if ((object)instance2 == null)
				{
					goto IL_0225;
				}
				if (!instance2.DebugSceneDirector)
				{
					goto IL_0152;
				}
			}
			array = new string[6];
			if (array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				object obj = default(object);
				string text = ((Enum)(&obj)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				object obj2;
				if ((object)progressor != null)
				{
					bool flag = ((UnityEngine.Object)progressor).m_CachedPtr != (IntPtr)0;
					obj2 = "Yes";
					if (flag)
					{
						goto IL_027b;
					}
				}
				obj2 = "No";
				goto IL_027b;
			}
		}
		goto IL_0225;
		IL_027b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string message = string.Concat(array);
		SceneDirector instance3 = Instance;
		DDebug.Log(message, instance3);
		goto IL_0152;
		IL_0225:
		return (SceneLoader)(object)new NullReferenceException();
		IL_0152:
		SceneLoader loader = SceneLoader.GetLoader();
		if ((object)loader != null)
		{
			loader.SceneName = sceneName;
			loader.GetSceneBy = GetSceneBy.Name;
			loader.Progressor = progressor;
			loader.LoadSceneMode = loadSceneMode;
			if (loader.GetSceneBy == GetSceneBy.Name)
			{
				Progressor progressor2 = loader.LoadSceneAsync(loader.SceneName, loadSceneMode);
			}
			else if (loader.GetSceneBy == GetSceneBy.BuildIndex)
			{
				Progressor progressor3 = loader.LoadSceneAsync(loader.SceneBuildIndex, loadSceneMode);
			}
			return loader;
		}
		goto IL_0225;
	}

	public static AsyncOperation UnloadSceneAsync(Scene scene)
	{
		//IL_007b: Expected I4, but got O
		SceneDirector instance = Instance;
		if ((object)instance != null)
		{
			if (!instance.DebugMode)
			{
				DoozySettings instance2 = DoozySettings.Instance;
				if ((object)instance2 == null)
				{
					goto IL_00cd;
				}
				if (!instance2.DebugSceneDirector)
				{
					goto IL_00b6;
				}
			}
			string nameInternal = Scene.GetNameInternal((int)scene);
			string message = "UnloadSceneAsync - scene: " + nameInternal;
			SceneDirector instance3 = Instance;
			DDebug.Log(message, instance3);
			goto IL_00b6;
		}
		goto IL_00cd;
		IL_00cd:
		return (AsyncOperation)(object)new NullReferenceException();
		IL_00b6:
		return SceneManager.UnloadSceneAsyncInternal(scene, UnloadSceneOptions.None);
	}

	public static AsyncOperation UnloadSceneAsync(int sceneBuildIndex)
	{
		SceneDirector instance = Instance;
		if ((object)instance != null)
		{
			if (!instance.DebugMode)
			{
				DoozySettings instance2 = DoozySettings.Instance;
				if ((object)instance2 == null)
				{
					goto IL_00db;
				}
				if (!instance2.DebugSceneDirector)
				{
					goto IL_00b6;
				}
			}
			int num = default(int);
			string text = num.ToString();
			string message = "UnloadSceneAsync - sceneBuildIndex: " + text;
			SceneDirector instance3 = Instance;
			DDebug.Log(message, instance3);
			goto IL_00b6;
		}
		goto IL_00db;
		IL_00db:
		return (AsyncOperation)(object)new NullReferenceException();
		IL_00b6:
		ref bool outSuccess = default(ref bool);
		return SceneManager.UnloadSceneNameIndexInternal("", sceneBuildIndex, false, UnloadSceneOptions.None, out outSuccess);
	}

	public static AsyncOperation UnloadSceneAsync(string sceneName)
	{
		SceneDirector instance = Instance;
		if ((object)instance != null)
		{
			if (!instance.DebugMode)
			{
				DoozySettings instance2 = DoozySettings.Instance;
				if ((object)instance2 == null)
				{
					goto IL_00b6;
				}
				if (!instance2.DebugSceneDirector)
				{
					goto IL_00a4;
				}
			}
			string message = "UnloadSceneAsync - sceneName: " + sceneName;
			SceneDirector instance3 = Instance;
			DDebug.Log(message, instance3);
			goto IL_00a4;
		}
		goto IL_00b6;
		IL_00b6:
		return (AsyncOperation)(object)new NullReferenceException();
		IL_00a4:
		return SceneManager.UnloadSceneAsync(sceneName);
	}

	public static SceneDirector AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<SceneDirector>("Scene Director", isSingleton: true, selectGameObjectAfterCreation);
	}
}
