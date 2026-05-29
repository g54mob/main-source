using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TinyGiantStudio.Modules;
using UnityEngine;

namespace TinyGiantStudio.Text
{
	[SelectionBase]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(TextUpdater))]
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/3D Text", 200)]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/text/modular-3d-text")]
	public class Modular3DText : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CUpdateRoutine_003Ed__86 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Modular3DText _003C_003E4__this;

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
			public _003CUpdateRoutine_003Ed__86(int _003C_003E1__state)
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
		private string _text;

		public string oldText;

		private string processedText;

		public string[] wordArray;

		public List<GameObject> characterObjectList;

		private List<GameObject> objectsPendingModulesApply;

		public List<Mesh> generatedMeshes;

		public bool autoSaveMesh;

		[SerializeField]
		private Font _font;

		[SerializeField]
		private Material _material;

		[SerializeField]
		private Vector3 _fontSize;

		[SerializeField]
		private bool _capitalize;

		[SerializeField]
		private bool _lowercase;

		[SerializeField]
		private bool _autoLetterSize;

		[SerializeField]
		private float _wordSpacing;

		public bool useModules;

		public bool startAddingModuleFromChar;

		public List<ModuleContainer> addingModules;

		public bool startDeletingModuleFromChar;

		public List<ModuleContainer> deletingModules;

		public bool customDeleteAfterDuration;

		public float deleteAfter;

		public bool applyModuleOnNewCharacter;

		[Tooltip("If turned on, adding modules will be automatically called when a prefab with existing text is instantiated on Start() instead of only when a new character is added.")]
		public bool applyModulesOnStart;

		[Tooltip("If turned on, adding modules will be automatically called when a prefab with existing text is enabled instead of only when a new character is added")]
		public bool applyModulesOnEnable;

		private bool applyModuleFromStartOrEnable;

		[Tooltip("When text is updated, old characters are moved to their correct position if their position is moved by something like a module.")]
		public bool destroyChildObjectsWithGameObject;

		public bool repositionOldCharacters;

		public bool reApplyModulesToOldCharacters;

		public bool singleInPrefab;

		public bool combineMeshInEditor;

		public bool combineMeshDuringRuntime;

		[Tooltip("Don't let letters show up in hierarchy in play mode. They are still there but not visible.")]
		public bool hideLettersInHierarchyInPlayMode;

		[Tooltip("If combine mesh is turned off")]
		public bool hideLettersInHierarchyInEditMode;

		[Tooltip("Breaks prefab connection while saving prefab location, can replace prefab at that location with a click")]
		public bool canBreakOutermostPrefab;

		public string assetPath;

		public List<string> meshPaths;

		private bool createChilds;

		public bool updateTextOncePerFrame;

		private bool runningRoutine;

		[SerializeField]
		private List<GameObject> extraLinesCreatedBecauseOfTooManyVerticies;

		public MeshPostProcess meshPostProcess;

		public bool useIncreasedVertexCountForCombinedMesh;

		private DebugLogger _logger;

		public bool debugLogs;

		public bool runTimeLogging;

		public bool editorTimeLogging;

		public bool logTextUpdates;

		public bool logFontUpdates;

		public bool logMaterialUpdates;

		public bool logDeletedCharacters;

		public bool logSingleMeshStatus;

		private CharacterCleanUp _characterCleanUp;

		public string Text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Font Font
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Material Material
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 FontSize
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public bool Capitalize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool LowerCase
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AutoLetterSize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float WordSpacing
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		internal DebugLogger Logger => null;

		internal CharacterCleanUp CharacterCleanUp => null;

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void SetTextDirty()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateRoutine_003Ed__86))]
		private IEnumerator UpdateRoutine()
		{
			return null;
		}

		[ContextMenu("CleanUpdateText")]
		public void CleanUpdateText()
		{
		}

		public void UpdateText(string newText)
		{
		}

		public void UpdateText(float number)
		{
		}

		public void UpdateText(int number)
		{
		}

		public void UpdateText()
		{
		}

		private void CreateSingleMesh()
		{
		}

		private void ApplyCombinedMesh(List<Mesh> combinedMeshes)
		{
		}

		private void CreateNewChacracters(int newCharStartsFrom, int startapplyingModulesFromIndex)
		{
		}

		private bool ApplyModuleToThisCharacterNow(int currentCharacterIndex, int startApplyingModulesFromIndex)
		{
			return false;
		}

		private string ProcessText()
		{
			return null;
		}

		private void DestroyMeshRenderAndMeshFilter()
		{
		}

		public bool ShouldItCreateChild()
		{
			return false;
		}

		private int NewCharacterStartsFrom()
		{
			return 0;
		}

		private void DestroyObject(GameObject obj)
		{
		}

		private void DestroyObjectRuntime(GameObject obj)
		{
		}

		public float GetDeleteDurationFromEffects()
		{
			return 0f;
		}

		private void RunTimeDestroyObjectOnDisabledText(GameObject obj)
		{
		}

		private void CreateThisChar(char previousChar, char currentChar, bool applyModule)
		{
		}

		private void CreateThisChar(char currentChar, bool applyModule)
		{
		}

		private void AddCharacterToList(GameObject obj)
		{
		}

		private void ApplyAllPendingModules()
		{
		}

		private void ApplyEffects(GameObject obj)
		{
		}

		private void ApplyStyle(GameObject obj)
		{
		}

		private Vector3 GetChildSize()
		{
			return default(Vector3);
		}

		private void SetLayer(GameObject obj)
		{
		}

		public void EmptyEffect(List<ModuleContainer> moduleList)
		{
		}

		public void NewEffect(List<ModuleContainer> moduleList, Module newModule = null)
		{
		}

		public void DestroyMesh(Mesh mesh)
		{
		}

		public bool DoesStyleInheritFromAParent()
		{
			return false;
		}
	}
}
