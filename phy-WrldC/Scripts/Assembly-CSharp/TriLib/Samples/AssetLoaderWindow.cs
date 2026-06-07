using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace TriLib.Samples
{
	[RequireComponent(typeof(AssetDownloader))]
	public class AssetLoaderWindow : MonoBehaviour
	{
		public bool Async;

		[SerializeField]
		private Button _loadLocalAssetButton;

		[SerializeField]
		private Button _loadRemoteAssetButton;

		[SerializeField]
		private Text _spinningText;

		[SerializeField]
		private Dropdown _transparencyModeDropdown;

		[SerializeField]
		private Dropdown _shadingDropdown;

		[SerializeField]
		private Toggle _spinXToggle;

		[SerializeField]
		private Toggle _spinYToggle;

		[SerializeField]
		private Button _resetRotationButton;

		[SerializeField]
		private Button _stopAnimationButton;

		[SerializeField]
		private Text _animationsText;

		[SerializeField]
		private Text _blendShapesText;

		[SerializeField]
		private ScrollRect _animationsScrollRect;

		[SerializeField]
		private ScrollRect _blendShapesScrollRect;

		[SerializeField]
		private Transform _containerTransform;

		[SerializeField]
		private Transform _blendShapesContainerTransform;

		[SerializeField]
		private AnimationText _animationTextPrefab;

		[SerializeField]
		private BlendShapeControl _blendShapeControlPrefab;

		[SerializeField]
		private Canvas _backgroundCanvas;

		private GameObject _rootGameObject;

		[SerializeField]
		private Text _loadingTimeText;

		[SerializeField]
		private Text _dragAndDropText;

		private Stopwatch _loadingTimer = new Stopwatch();

		public static AssetLoaderWindow Instance { get; private set; }

		public void HandleEvent(string animationName)
		{
			_rootGameObject.GetComponent<Animation>().Play(animationName);
			_stopAnimationButton.interactable = true;
		}

		public void HandleBlendEvent(SkinnedMeshRenderer skinnedMeshRenderer, int index, float value)
		{
			skinnedMeshRenderer.SetBlendShapeWeight(index, value);
		}

		public void DestroyItems()
		{
			foreach (Transform item in _containerTransform)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			foreach (Transform item2 in _blendShapesContainerTransform)
			{
				UnityEngine.Object.Destroy(item2.gameObject);
			}
		}

		protected void Awake()
		{
			_loadLocalAssetButton.onClick.AddListener(LoadLocalAssetButtonClick);
			_loadRemoteAssetButton.onClick.AddListener(LoadRemoteAssetButtonClick);
			_stopAnimationButton.onClick.AddListener(StopAnimationButtonClick);
			_resetRotationButton.onClick.AddListener(ResetRotationButtonClick);
			HideControls();
			Instance = this;
		}

		protected void Update()
		{
			if (_rootGameObject != null)
			{
				_rootGameObject.transform.Rotate(_spinXToggle.isOn ? (20f * Time.deltaTime) : 0f, _spinYToggle.isOn ? (-20f * Time.deltaTime) : 0f, 0f, Space.World);
			}
		}

		private void HideControls()
		{
			_loadLocalAssetButton.interactable = true;
			_loadRemoteAssetButton.interactable = true;
			_spinningText.gameObject.SetActive(value: false);
			_spinXToggle.gameObject.SetActive(value: false);
			_spinYToggle.gameObject.SetActive(value: false);
			_resetRotationButton.gameObject.SetActive(value: false);
			_stopAnimationButton.gameObject.SetActive(value: false);
			_animationsText.gameObject.SetActive(value: false);
			_animationsScrollRect.gameObject.SetActive(value: false);
			_blendShapesText.gameObject.SetActive(value: false);
			_blendShapesScrollRect.gameObject.SetActive(value: false);
		}

		private void LoadLocalAssetButtonClick()
		{
			FileOpenDialog instance = FileOpenDialog.Instance;
			instance.Title = "Please select a File";
			instance.Filter = AssetLoaderBase.GetSupportedFileExtensions() + ";*.zip;";
			instance.ShowFileOpenDialog(delegate(string filename)
			{
				LoadInternal(filename);
			});
		}

		public void LoadFromBrowserFiles(int filesCount)
		{
			LoadInternal(null, null, filesCount);
		}

		private void FullPostLoadSetup()
		{
			if (_rootGameObject != null)
			{
				PostLoadSetup();
				ShowLoadingTime();
			}
			else
			{
				HideLoadingTime();
			}
		}

		private void HandleException(Exception exception)
		{
			if (_rootGameObject != null)
			{
				UnityEngine.Object.Destroy(_rootGameObject);
			}
			_rootGameObject = null;
			HideLoadingTime();
			ErrorDialog.Instance.ShowDialog(exception.ToString());
		}

		private void CheckForValidModel(AssetLoaderBase assetLoader)
		{
			if (assetLoader.MeshData == null || assetLoader.MeshData.Length == 0)
			{
				throw new Exception("File contains no meshes");
			}
		}

		private void LoadInternal(string filename, byte[] fileBytes = null, int browserFilesCount = -1)
		{
			PreLoadSetup();
			AssetLoaderOptions assetLoaderOptions = GetAssetLoaderOptions();
			if (!Async)
			{
				using (AssetLoader assetLoader = new AssetLoader())
				{
					assetLoader.OnMetadataProcessed += AssetLoader_OnMetadataProcessed;
					try
					{
						if (fileBytes != null && fileBytes.Length != 0)
						{
							_rootGameObject = assetLoader.LoadFromMemoryWithTextures(fileBytes, FileUtils.GetFileExtension(filename), assetLoaderOptions, _rootGameObject);
						}
						else
						{
							if (string.IsNullOrEmpty(filename))
							{
								throw new Exception("File not selected");
							}
							_rootGameObject = assetLoader.LoadFromFileWithTextures(filename, assetLoaderOptions);
						}
						CheckForValidModel(assetLoader);
					}
					catch (Exception exception)
					{
						HandleException(exception);
					}
				}
				FullPostLoadSetup();
				return;
			}
			AssetLoaderAsync assetLoader2 = new AssetLoaderAsync();
			try
			{
				assetLoader2.OnMetadataProcessed += AssetLoader_OnMetadataProcessed;
				try
				{
					if (fileBytes != null && fileBytes.Length != 0)
					{
						assetLoader2.LoadFromMemoryWithTextures(fileBytes, FileUtils.GetFileExtension(filename), assetLoaderOptions, null, delegate(GameObject loadedGameObject)
						{
							CheckForValidModel(assetLoader2);
							_rootGameObject = loadedGameObject;
							FullPostLoadSetup();
						});
						return;
					}
					if (!string.IsNullOrEmpty(filename))
					{
						assetLoader2.LoadFromFileWithTextures(filename, assetLoaderOptions, null, delegate(GameObject loadedGameObject)
						{
							CheckForValidModel(assetLoader2);
							_rootGameObject = loadedGameObject;
							FullPostLoadSetup();
						});
						return;
					}
					throw new Exception("File not selected");
				}
				catch (Exception exception2)
				{
					HandleException(exception2);
				}
			}
			finally
			{
				if (assetLoader2 != null)
				{
					((IDisposable)assetLoader2).Dispose();
				}
			}
		}

		private void ShowLoadingTime()
		{
			_loadingTimeText.text = $"Loading time: {_loadingTimer.Elapsed.Minutes:00}:{_loadingTimer.Elapsed.Seconds:00}.{_loadingTimer.Elapsed.Milliseconds / 10:00}";
			_loadingTimer.Stop();
		}

		private void HideLoadingTime()
		{
			_loadingTimeText.text = null;
		}

		private void AssetLoader_OnMetadataProcessed(AssimpMetadataType metadataType, uint metadataIndex, string metadataKey, object metadataValue)
		{
			UnityEngine.Debug.Log(string.Concat("Found metadata of type [", metadataType, "] at index [", metadataIndex, "] and key [", metadataKey, "] with value [", metadataValue, "]"));
		}

		private AssetLoaderOptions GetAssetLoaderOptions()
		{
			AssetLoaderOptions assetLoaderOptions = AssetLoaderOptions.CreateInstance();
			assetLoaderOptions.DontLoadCameras = false;
			assetLoaderOptions.DontLoadLights = false;
			assetLoaderOptions.UseOriginalPositionRotationAndScale = true;
			switch (_transparencyModeDropdown.value)
			{
			case 0:
				assetLoaderOptions.DisableAlphaMaterials = true;
				break;
			case 1:
				assetLoaderOptions.MaterialTransparencyMode = MaterialTransparencyMode.Alpha;
				break;
			case 2:
				assetLoaderOptions.MaterialTransparencyMode = MaterialTransparencyMode.Cutout;
				break;
			case 3:
				assetLoaderOptions.MaterialTransparencyMode = MaterialTransparencyMode.Fade;
				break;
			}
			switch (_shadingDropdown.value)
			{
			case 1:
				assetLoaderOptions.MaterialShadingMode = MaterialShadingMode.Roughness;
				break;
			case 2:
				assetLoaderOptions.MaterialShadingMode = MaterialShadingMode.Specular;
				break;
			}
			assetLoaderOptions.AddAssetUnloader = true;
			assetLoaderOptions.AdvancedConfigs.Add(AssetAdvancedConfig.CreateConfig(AssetAdvancedPropertyClassNames.FBXImportDisableDiffuseFactor, value: true));
			return assetLoaderOptions;
		}

		private void PreLoadSetup()
		{
			_loadingTimer.Reset();
			_loadingTimer.Start();
			HideControls();
			if (_rootGameObject != null)
			{
				UnityEngine.Object.Destroy(_rootGameObject);
				_rootGameObject = null;
			}
		}

		private void PostLoadSetup()
		{
			Camera main = Camera.main;
			main.FitToBounds(_rootGameObject.transform, 3f);
			_backgroundCanvas.planeDistance = main.farClipPlane * 0.99f;
			_spinningText.gameObject.SetActive(value: true);
			_spinXToggle.isOn = false;
			_spinXToggle.gameObject.SetActive(value: true);
			_spinYToggle.isOn = false;
			_spinYToggle.gameObject.SetActive(value: true);
			_resetRotationButton.gameObject.SetActive(value: true);
			DestroyItems();
			Animation component = _rootGameObject.GetComponent<Animation>();
			if (component != null)
			{
				_animationsText.gameObject.SetActive(value: true);
				_animationsScrollRect.gameObject.SetActive(value: true);
				_stopAnimationButton.gameObject.SetActive(value: true);
				_stopAnimationButton.interactable = true;
				foreach (AnimationState item in component)
				{
					CreateItem(item.name);
				}
			}
			SkinnedMeshRenderer[] componentsInChildren = _rootGameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			if (componentsInChildren == null)
			{
				return;
			}
			bool flag = false;
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				if (!flag && skinnedMeshRenderer.sharedMesh.blendShapeCount > 0)
				{
					_blendShapesText.gameObject.SetActive(value: true);
					_blendShapesScrollRect.gameObject.SetActive(value: true);
					flag = true;
				}
				for (int j = 0; j < skinnedMeshRenderer.sharedMesh.blendShapeCount; j++)
				{
					CreateBlendShapeItem(skinnedMeshRenderer, skinnedMeshRenderer.sharedMesh.GetBlendShapeName(j), j);
				}
			}
		}

		private void LoadRemoteAssetButtonClick()
		{
			URIDialog.Instance.ShowDialog(delegate(string assetUri, string assetExtension)
			{
				GetComponent<AssetDownloader>().DownloadAsset(assetUri, assetExtension, LoadDownloadedAsset, null, GetAssetLoaderOptions());
				_loadLocalAssetButton.interactable = false;
				_loadRemoteAssetButton.interactable = false;
			});
		}

		private void LoadDownloadedAsset(GameObject loadedGameObject)
		{
			PreLoadSetup();
			if (loadedGameObject != null)
			{
				_rootGameObject = loadedGameObject;
				PostLoadSetup();
			}
			else
			{
				AssetDownloader component = GetComponent<AssetDownloader>();
				ErrorDialog.Instance.ShowDialog(component.Error);
			}
		}

		private void CreateItem(string text)
		{
			UnityEngine.Object.Instantiate(_animationTextPrefab, _containerTransform).Text = text;
		}

		private void CreateBlendShapeItem(SkinnedMeshRenderer skinnedMeshRenderer, string name, int index)
		{
			BlendShapeControl blendShapeControl = UnityEngine.Object.Instantiate(_blendShapeControlPrefab, _blendShapesContainerTransform);
			blendShapeControl.SkinnedMeshRenderer = skinnedMeshRenderer;
			blendShapeControl.Text = name;
			blendShapeControl.BlendShapeIndex = index;
		}

		private void ResetRotationButtonClick()
		{
			_spinXToggle.isOn = false;
			_spinYToggle.isOn = false;
			_rootGameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		}

		private void StopAnimationButtonClick()
		{
			_rootGameObject.GetComponent<Animation>().Stop();
			_stopAnimationButton.interactable = false;
		}
	}
}
