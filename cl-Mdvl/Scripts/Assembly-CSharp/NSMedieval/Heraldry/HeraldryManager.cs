using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.UI;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

namespace NSMedieval.Heraldry
{
	public class HeraldryManager : MonoSingleton<HeraldryManager>
	{
		public const string CrestSamplerName = "_heraldry_crest";

		public const string BackgroundSamplerName = "_heraldry_background";

		[SerializeField]
		private Image crest;

		[SerializeField]
		private Image pattern;

		[SerializeField]
		private Canvas[] layers;

		[SerializeField]
		private Image crestLive;

		[SerializeField]
		private Image patternLive;

		[SerializeField]
		private RectTransform referenceSize;

		[SerializeField]
		private HeraldryCamera patternCam;

		[SerializeField]
		private HeraldryCamera crestCam;

		[SerializeField]
		private GameObject heraldryCaptureCam;

		[NonSerialized]
		private TextureCreationFlags flags;

		private string presetsPath = "HeraldryPresets/Presets.json";

		private AllHeraldryPresets allPresets;

		[NonSerialized]
		public TextureWrapMode HeraldryPatternWrapMode = TextureWrapMode.Clamp;

		public AllHeraldryPresets AllPresets => allPresets ?? (allPresets = LoadAllPresets());

		public Image Crest => crest;

		public Image Pattern => pattern;

		public Canvas[] Layers
		{
			get
			{
				return layers;
			}
			set
			{
				layers = value;
			}
		}

		public Image CrestLive
		{
			get
			{
				return crestLive;
			}
			set
			{
				crest = value;
			}
		}

		public Image PatternLive
		{
			get
			{
				return patternLive;
			}
			set
			{
				patternLive = value;
			}
		}

		public RectTransform ReferenceSize
		{
			get
			{
				return referenceSize;
			}
			set
			{
				referenceSize = value;
			}
		}

		public HeraldryCamera PatternCam
		{
			get
			{
				return patternCam;
			}
			set
			{
				patternCam = value;
			}
		}

		public HeraldryCamera CrestCam
		{
			get
			{
				return crestCam;
			}
			set
			{
				crestCam = value;
			}
		}

		public bool CaptureCameraEnabled
		{
			get
			{
				if (heraldryCaptureCam != null)
				{
					return heraldryCaptureCam.activeInHierarchy;
				}
				return false;
			}
			set
			{
				if (heraldryCaptureCam != null)
				{
					heraldryCaptureCam.SetActive(value);
				}
			}
		}

		public event Action HeraldryChangedEvent;

		public void UpdateShaders(bool setWrapModeFromHeraldryEditor)
		{
			Texture mainTexture = Crest.mainTexture;
			Texture mainTexture2 = Pattern.mainTexture;
			mainTexture.wrapMode = TextureWrapMode.Clamp;
			if (setWrapModeFromHeraldryEditor)
			{
				mainTexture2.wrapMode = patternLive.mainTexture.wrapMode;
				HeraldryPatternWrapMode = mainTexture2.wrapMode;
			}
			else
			{
				mainTexture2.wrapMode = HeraldryPatternWrapMode;
			}
			Shader.SetGlobalTexture("_HeraldryCrest", mainTexture);
			Shader.SetGlobalTexture("_HeraldryBackground", mainTexture2);
		}

		public void UpdateHeraldry(bool setWrapModeFromHeraldryEditor = false)
		{
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "UpdateHeraldry", delegate
			{
				MonoSingleton<HeraldryManager>.Instance.Crest.sprite = MonoSingleton<HeraldryManager>.Instance.GetHeraldrySprite("HeraldryCrest.png");
				MonoSingleton<HeraldryManager>.Instance.Pattern.sprite = MonoSingleton<HeraldryManager>.Instance.GetHeraldrySprite("HeraldryPattern.png");
				UpdateShaders(setWrapModeFromHeraldryEditor);
				this.HeraldryChangedEvent?.Invoke();
			});
		}

		public void SetHeraldryOnBlock(MaterialPropertyBlock block, FactionInstance factionInstance)
		{
			Texture crestTexture = ((factionInstance != null) ? factionInstance.Blueprint.HeraldryCrestTexture : MonoSingleton<HeraldryManager>.Instance.Crest.mainTexture);
			Texture backgroundTexture = ((factionInstance != null) ? factionInstance.Blueprint.HeraldryBackgroundTexture : MonoSingleton<HeraldryManager>.Instance.pattern.mainTexture);
			SetHeraldryOnBlock(block, crestTexture, backgroundTexture);
		}

		public void SetHeraldryOnBlock(MaterialPropertyBlock block, Texture crestTexture, Texture backgroundTexture)
		{
			block.SetTexture("_heraldry_crest", crestTexture);
			block.SetTexture("_heraldry_background", backgroundTexture);
		}

		public static void WriteHeraldryFileToDisk(ref byte[] byteArrayCrest, string filename)
		{
			FilePathUtils.CheckAndCreatePath(filename);
			try
			{
				FileUtils.SafeWriteAllBytes(filename, byteArrayCrest);
			}
			catch (UnauthorizedAccessException ex)
			{
				bool isEnabled;
				try
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(58, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\HeraldryManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Could not write ");
						messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(filename));
						messageBuilder.AppendLiteral(". Exception: ");
						messageBuilder.AppendFormatted(ex.GetType().ToString());
						messageBuilder.AppendLiteral(". Deleting file and retrying.");
					}
					Log.Info(messageBuilder);
					File.Delete(filename);
					FileUtils.SafeWriteAllBytes(filename, byteArrayCrest);
				}
				catch (Exception)
				{
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(30, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\HeraldryManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Could not delete. Exception: ");
						messageBuilder.AppendFormatted(ex.Message);
						messageBuilder.AppendLiteral(".");
					}
					Log.Info(messageBuilder);
					string fileName = Path.GetFileName(filename);
					string path = Path.Combine(Application.temporaryCachePath, fileName).Replace("\\", "/");
					try
					{
						messageBuilder = new FVLogInfoInterpolationHandler(9, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\HeraldryManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Writing ");
							messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
							messageBuilder.AppendLiteral(".");
						}
						Log.Info(messageBuilder);
						FileUtils.SafeWriteAllBytes(path, byteArrayCrest);
					}
					catch (UnauthorizedAccessException ex3)
					{
						messageBuilder = new FVLogInfoInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\HeraldryManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Could not write ");
							messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
							messageBuilder.AppendLiteral(". Error: ");
							messageBuilder.AppendFormatted(ex3.Message);
							messageBuilder.AppendLiteral(".");
						}
						Log.Info(messageBuilder);
					}
				}
			}
		}

		public static byte[] ReadHeraldryFileFromDisk(string filePath)
		{
			byte[] result = null;
			bool flag = false;
			bool isEnabled;
			if (File.Exists(filePath))
			{
				try
				{
					result = FileUtils.SafeReadAllBytes(filePath);
				}
				catch (UnauthorizedAccessException ex)
				{
					flag = true;
					FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\HeraldryManager.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Could not read ");
						messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(filePath));
						messageBuilder.AppendLiteral(". Error: ");
						messageBuilder.AppendFormatted(ex.Message);
						messageBuilder.AppendLiteral(".");
					}
					Log.Info(messageBuilder);
				}
			}
			if (flag)
			{
				string path = Path.Combine(Application.temporaryCachePath, Path.GetFileName(filePath)).Replace("\\", "/");
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(8, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\HeraldryManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Reading ");
					messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
				}
				Log.Info(messageBuilder);
				if (File.Exists(path))
				{
					try
					{
						result = FileUtils.SafeReadAllBytes(path);
					}
					catch (UnauthorizedAccessException ex2)
					{
						messageBuilder = new FVLogInfoInterpolationHandler(25, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\HeraldryManager.cs");
						if (isEnabled)
						{
							messageBuilder.AppendLiteral("Could not read ");
							messageBuilder.AppendFormatted(FilePathUtils.RemoveUserFromPath(path));
							messageBuilder.AppendLiteral(". Error: ");
							messageBuilder.AppendFormatted(ex2.Message);
							messageBuilder.AppendLiteral(".");
						}
						Log.Info(messageBuilder);
					}
				}
			}
			return result;
		}

		public string MergeWithPersistentDataPath(string filename)
		{
			return Path.Combine(FileReaders.Get.GetPersistentDataPath(), filename).Replace("\\", "/");
		}

		public void SaveHeraldryImage(Texture2D heraldryImage, string heraldryPath)
		{
			Rect source = new Rect(0f, 0f, heraldryImage.width, heraldryImage.height);
			heraldryImage.ReadPixels(source, 0, 0);
			byte[] byteArrayCrest = heraldryImage.EncodeToPNG();
			string text = MergeWithPersistentDataPath(heraldryPath);
			FilePathUtils.CheckAndCreatePath(text);
			WriteHeraldryFileToDisk(ref byteArrayCrest, text);
		}

		public Sprite GetHeraldrySprite(string val)
		{
			string text = MergeWithPersistentDataPath(Path.Combine(VillageSaveData.TempHeraldryDirectory, val)).Replace("\\", "/");
			FilePathUtils.CheckAndCreatePath(text);
			byte[] array = ReadHeraldryFileFromDisk(text);
			Texture2D texture2D = new Texture2D(512, 512, GraphicsFormat.R32G32B32A32_SFloat, flags);
			if (array != null)
			{
				texture2D.LoadImage(array);
			}
			return Sprite.Create(texture2D, new Rect(0f, 0f, 512f, 512f), new Vector2(0f, 0f));
		}

		public string GetTempHeraldryFilename()
		{
			string text = MergeWithPersistentDataPath(VillageSaveData.HeraldryJsonTemp);
			FilePathUtils.CheckAndCreatePath(text);
			return text;
		}

		public void SaveTempHeraldry(HeraldryPresets preset)
		{
			string data = JsonUtility.ToJson(preset);
			FileUtils.SafeWriteAllText(GetTempHeraldryFilename(), data);
		}

		private AllHeraldryPresets LoadAllPresets()
		{
			return JsonUtility.FromJson<AllHeraldryPresets>(FileUtils.SafeReadAllText(Path.Combine(Application.streamingAssetsPath, presetsPath).Replace("\\", "/")));
		}

		public HeraldryPresets GetLastHeraldry()
		{
			HeraldryPresets heraldryPresets = null;
			try
			{
				heraldryPresets = JsonUtility.FromJson<HeraldryPresets>(FileUtils.SafeReadAllText(MonoSingleton<HeraldryManager>.Instance.GetTempHeraldryFilename()));
			}
			catch (Exception t)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\HeraldryManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Failed to load last heraldry, exception: ");
					messageBuilder.AppendFormatted(t);
				}
				Log.Error(messageBuilder);
				heraldryPresets = null;
			}
			if (heraldryPresets == null)
			{
				Log.Info("Heraldry not found, picking a random preset", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\HeraldryManager.cs");
				heraldryPresets = MonoSingleton<HeraldryManager>.Instance.AllPresets.Presets.PickRandom();
				if (heraldryPresets != null)
				{
					SaveTempHeraldry(heraldryPresets);
				}
			}
			return heraldryPresets;
		}

		public void TrySetPlayerHeraldry(IEnumerable<MeshRenderer> meshRenderers)
		{
			Texture mainTexture = Crest.mainTexture;
			Texture mainTexture2 = Pattern.mainTexture;
			TrySetHeraldry(meshRenderers, mainTexture, mainTexture2);
		}

		public void TrySetHeraldry(IEnumerable<MeshRenderer> meshRenderers, FactionInstance factionInstance)
		{
			Texture crestTexture = ((factionInstance != null) ? factionInstance.Blueprint.HeraldryCrestTexture : MonoSingleton<HeraldryManager>.Instance.Crest.mainTexture);
			Texture backgroundTexture = ((factionInstance != null) ? factionInstance.Blueprint.HeraldryBackgroundTexture : MonoSingleton<HeraldryManager>.Instance.pattern.mainTexture);
			TrySetHeraldry(meshRenderers, crestTexture, backgroundTexture);
		}

		public void TrySetHeraldry(IEnumerable<MeshRenderer> meshRenderers, Texture crestTexture, Texture backgroundTexture)
		{
			foreach (MeshRenderer meshRenderer in meshRenderers)
			{
				if (meshRenderer.sharedMaterials.Any((Material material) => material.HasProperty("_heraldry_crest") || material.HasProperty("_heraldry_background")))
				{
					MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(meshRenderer);
					MonoSingleton<HeraldryManager>.Instance.SetHeraldryOnBlock(materialPropertyBlock, crestTexture, backgroundTexture);
					meshRenderer.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}

		public void HeraldryJsonLoaded(string heraldryJsonFromZip)
		{
			try
			{
				HeraldryPresets heraldryPresets = JsonUtility.FromJson<HeraldryPresets>(heraldryJsonFromZip);
				HeraldryPatternWrapMode = heraldryPresets.PatternWrapMode;
			}
			catch (Exception t)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(75, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\HeraldryManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error in HeraldryJsonLoaded. HeraldryPatternWrapMode Not set. \nException: ");
					messageBuilder.AppendFormatted(t);
					messageBuilder.AppendLiteral("\n");
				}
				Log.Error(messageBuilder);
			}
		}

		public void SavingHeraldryToJson(ref string heraldryJsonFromZip)
		{
			try
			{
				HeraldryPresets heraldryPresets = JsonUtility.FromJson<HeraldryPresets>(heraldryJsonFromZip);
				heraldryPresets.PatternWrapMode = HeraldryPatternWrapMode;
				string text = JsonUtility.ToJson(heraldryPresets);
				if (!string.IsNullOrEmpty(text))
				{
					heraldryJsonFromZip = text;
				}
			}
			catch (Exception t)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(40, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\HeraldryManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Error happened in SavingHeraldryToJson: ");
					messageBuilder.AppendFormatted(t);
				}
				Log.Error(messageBuilder);
			}
		}
	}
}
