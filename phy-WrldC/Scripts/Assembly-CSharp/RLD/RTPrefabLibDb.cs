using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	[ExecuteInEditMode]
	public class RTPrefabLibDb : MonoSingleton<RTPrefabLibDb>
	{
		[SerializeField]
		private string _newLibName = string.Empty;

		[SerializeField]
		private Vector2 _prefabScrollPos;

		[SerializeField]
		private int _numPrefabsPerRow = 5;

		[NonSerialized]
		private EditorPrefabPreviewGen _editorPrefabPreviewGen = new EditorPrefabPreviewGen();

		[SerializeField]
		private PrefabLibDbSettings _settings = new PrefabLibDbSettings();

		[SerializeField]
		private RTPrefabLibDbUI _runtimeUI;

		[SerializeField]
		private PrefabPreviewLookAndFeel _prefabPreviewLookAndFeel = new PrefabPreviewLookAndFeel();

		[SerializeField]
		private int _activeLibIndex = -1;

		[SerializeField]
		private List<RTPrefabLib> _libs = new List<RTPrefabLib>();

		public int NumLibs => _libs.Count;

		public int ActiveLibIndex => _activeLibIndex;

		public RTPrefabLib ActiveLib
		{
			get
			{
				if (_activeLibIndex < 0)
				{
					return null;
				}
				return _libs[_activeLibIndex];
			}
		}

		public PrefabPreviewLookAndFeel PrefabPreviewLookAndFeel => _prefabPreviewLookAndFeel;

		public RTPrefabLibDbUI RuntimeUI => _runtimeUI;

		public bool HasRuntimeUI
		{
			get
			{
				if (_runtimeUI != null && _runtimeUI.gameObject.activeInHierarchy)
				{
					return _runtimeUI.enabled;
				}
				return false;
			}
		}

		public PrefabLibDbSettings Settings => _settings;

		public EditorPrefabPreviewGen EditorPrefabPreviewGen => _editorPrefabPreviewGen;

		public event PrefabLibDbPrefabSpawnedHander PrefabSpawned;

		public RTPrefabLib CreateLib(string libName)
		{
			if (string.IsNullOrEmpty(libName))
			{
				return null;
			}
			string text = UniqueNameGen.Generate(libName, GetAllLibNames());
			RTPrefabLib rTPrefabLib = new RTPrefabLib();
			rTPrefabLib.Name = text;
			_libs.Add(rTPrefabLib);
			if (HasRuntimeUI && Application.isPlaying)
			{
				_runtimeUI.ActiveLibDropDown.SyncWithLibDb();
			}
			if (_activeLibIndex == -1)
			{
				SetActiveLib(0);
			}
			rTPrefabLib.PrefabCreated += OnPrefabCreatedInLib;
			rTPrefabLib.PrefabRemoved += OnPrefabRemovedFromLib;
			rTPrefabLib.Cleared += OnPrefabLibCleared;
			return rTPrefabLib;
		}

		public void SortLibsByName()
		{
			RTPrefabLib activeLib = ActiveLib;
			_libs.Sort((RTPrefabLib l0, RTPrefabLib l1) => l0.Name.CompareTo(l1.Name));
			if (activeLib != null)
			{
				SetActiveLib(activeLib);
			}
		}

		public bool SetLibName(RTPrefabLib lib, string newLibName)
		{
			if (lib.Name == newLibName || !Contains(lib))
			{
				return false;
			}
			if (string.IsNullOrEmpty(newLibName))
			{
				return false;
			}
			string text = UniqueNameGen.Generate(newLibName, GetAllLibNames());
			lib.Name = text;
			if (HasRuntimeUI && Application.isPlaying)
			{
				_runtimeUI.ActiveLibDropDown.SyncWithLibDb();
			}
			return true;
		}

		public void SetActiveLib(int libIndex)
		{
			if (NumLibs != 0)
			{
				_activeLibIndex = libIndex;
				_activeLibIndex = Mathf.Clamp(_activeLibIndex, 0, NumLibs - 1);
				if (HasRuntimeUI && Application.isPlaying)
				{
					_runtimeUI.ActiveLibDropDown.SetActiveLibIndex(_activeLibIndex);
					_runtimeUI.PrefabScrollView.SyncWithLib(ActiveLib);
				}
			}
		}

		public void SetActiveLib(RTPrefabLib lib)
		{
			int libIndex = GetLibIndex(lib);
			SetActiveLib(libIndex);
		}

		public void SetActiveLib(string libName)
		{
			int libIndex = GetLibIndex(libName);
			SetActiveLib(libIndex);
		}

		public void Clear()
		{
			_libs.Clear();
			_activeLibIndex = -1;
			if (HasRuntimeUI && Application.isPlaying)
			{
				_runtimeUI.ActiveLibDropDown.SyncWithLibDb();
				_runtimeUI.PrefabScrollView.ClearPreviews();
			}
		}

		public void Remove(int libIndex)
		{
			if (libIndex >= 0 && libIndex < NumLibs)
			{
				_ = _libs[libIndex];
				RTPrefabLib activeLib = ActiveLib;
				_libs.RemoveAt(libIndex);
				_activeLibIndex = _libs.IndexOf(activeLib);
				if (_activeLibIndex < 0)
				{
					_activeLibIndex = 0;
				}
				if (HasRuntimeUI && Application.isPlaying)
				{
					_runtimeUI.ActiveLibDropDown.SyncWithLibDb();
				}
			}
		}

		public void Remove(string libName)
		{
			int libIndex = GetLibIndex(libName);
			if (libIndex >= 0)
			{
				Remove(libIndex);
			}
		}

		public void Remove(RTPrefabLib lib)
		{
			int libIndex = GetLibIndex(lib);
			if (libIndex >= 0)
			{
				Remove(libIndex);
			}
		}

		public void Remove(List<RTPrefabLib> libs)
		{
			foreach (RTPrefabLib lib in libs)
			{
				Remove(lib);
			}
		}

		public List<RTPrefabLib> GetEmptyLibs()
		{
			List<RTPrefabLib> list = new List<RTPrefabLib>(10);
			foreach (RTPrefabLib lib in _libs)
			{
				if (lib.NumPrefabs == 0)
				{
					list.Add(lib);
				}
			}
			return list;
		}

		public void RemoveEmptyLibs()
		{
			Remove(GetEmptyLibs());
		}

		public bool Contains(string libName)
		{
			return GetLib(libName) != null;
		}

		public bool Contains(RTPrefabLib lib)
		{
			return _libs.Contains(lib);
		}

		public List<string> GetAllLibNames()
		{
			List<string> list = new List<string>(10);
			foreach (RTPrefabLib lib in _libs)
			{
				list.Add(lib.Name);
			}
			return list;
		}

		public int GetLibIndex(string libName)
		{
			return _libs.FindIndex((RTPrefabLib item) => item.Name == libName);
		}

		public int GetLibIndex(RTPrefabLib lib)
		{
			return _libs.IndexOf(lib);
		}

		public RTPrefabLib GetLib(int libIndex)
		{
			return _libs[libIndex];
		}

		public RTPrefabLib GetLib(string libName)
		{
			List<RTPrefabLib> list = _libs.FindAll((RTPrefabLib item) => item.Name == libName);
			if (list.Count == 0)
			{
				return null;
			}
			return list[0];
		}

		private void Start()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			foreach (RTPrefabLib lib in _libs)
			{
				lib.PrefabCreated += OnPrefabCreatedInLib;
				lib.PrefabRemoved += OnPrefabRemovedFromLib;
				lib.Cleared += OnPrefabLibCleared;
			}
			if (HasRuntimeUI)
			{
				_runtimeUI.ActiveLibDropDown.SyncWithLibDb();
				_runtimeUI.ActiveLibDropDown.AddValueChangedListener(delegate
				{
					OnActiveLibDropDownChanged();
				});
				_runtimeUI.PrefabScrollView.SyncWithLib(ActiveLib);
				_runtimeUI.PrefabScrollView.PrefabPreviewClicked += OnPrefabPreviewButtonClicked;
				GameObject obj = new GameObject("Dummy");
				obj.AddComponent<RectTransform>();
				obj.transform.SetParent(_runtimeUI.PrefabScrollView.transform, worldPositionStays: false);
				UnityEngine.Object.Destroy(obj);
			}
		}

		private void OnActiveLibDropDownChanged()
		{
			if (HasRuntimeUI)
			{
				_activeLibIndex = _runtimeUI.ActiveLibDropDown.ActiveLibIndex;
				_runtimeUI.PrefabScrollView.SyncWithLib(ActiveLib);
			}
		}

		private void OnPrefabCreatedInLib(RTPrefabLib prefabLib, RTPrefab prefab)
		{
			if (HasRuntimeUI && prefabLib == ActiveLib && Application.isPlaying)
			{
				_runtimeUI.PrefabScrollView.AddPrefabPreview(prefab);
			}
		}

		private void OnPrefabRemovedFromLib(RTPrefabLib prefabLib, RTPrefab prefab)
		{
			if (HasRuntimeUI && prefabLib == ActiveLib)
			{
				_runtimeUI.PrefabScrollView.SyncWithLib(prefabLib);
			}
		}

		private void OnPrefabLibCleared(RTPrefabLib prefabLib)
		{
			if (HasRuntimeUI && prefabLib == ActiveLib)
			{
				_runtimeUI.PrefabScrollView.ClearPreviews();
			}
		}

		private void OnPrefabPreviewButtonClicked(RTPrefab prefab)
		{
			if (Settings.SpawnPrefabOnPreviewClick)
			{
				GameObject gameObject = ObjectSpawnUtil.SpawnInFrontOfCamera(prefab.UnityPrefab, MonoSingleton<RTFocusCamera>.Get.TargetCamera, ObjectSpawnUtil.DefaultConfig);
				List<GameObject> list = new List<GameObject>();
				list.Add(gameObject);
				new PostObjectSpawnAction(list).Execute();
				if (this.PrefabSpawned != null)
				{
					this.PrefabSpawned(prefab, gameObject);
				}
			}
		}
	}
}
