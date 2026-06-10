using System;
using System.Collections.Generic;
using System.Text;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Map;
using NSMedieval.RoomDetection;
using NSMedieval.State.Timers;
using NSMedieval.UI;
using NSMedieval.WorldMap;
using UnityEngine;
using UnityEngine.Rendering;

namespace NSMedieval.Village.Map
{
	public class VisualHeatmapManager : MonoSingleton<VisualHeatmapManager>
	{
		private const string InfoCursorTag = "vheatmap";

		private Vec3Int resolution;

		[NonSerialized]
		private ComputeShader computeShader;

		private int kernelIndex;

		private uint threadGroupX;

		private uint threadGroupY;

		private uint threadGroupZ;

		[NonSerialized]
		private VillageMap map;

		private bool isInfoCursorActive;

		private bool isInfoCursorActiveForHeatmap;

		private readonly List<string> infoCursorLines = new List<string>();

		private readonly StringBuilder infoCursorStringBuilder = new StringBuilder(2048);

		private BaseTimer updateTimer;

		public HeatmapType HeatmapShowing { get; private set; }

		private RenderTexture OutputTexture3D { get; set; }

		public event Action<HeatmapType> OnShowHeatmap;

		private void Initialize(Vec3Int mapSize)
		{
			map = VillageManager.ActiveVillage.Map;
			computeShader = UnityEngine.Resources.Load<ComputeShader>("Shaders/Compute/HeatmapToTexture");
			kernelIndex = computeShader.FindKernel("CSMain");
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(21, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\VisualHeatmapManager.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("'");
				messageBuilder.AppendFormatted(computeShader.name);
				messageBuilder.AppendLiteral("' shader supported: ");
				messageBuilder.AppendFormatted(computeShader.IsSupported(kernelIndex));
			}
			Log.Info(messageBuilder);
			computeShader.GetKernelThreadGroupSizes(kernelIndex, out threadGroupX, out threadGroupY, out threadGroupZ);
			resolution = mapSize;
			computeShader.SetInts("resolution", resolution.x, resolution.y, resolution.z);
			CreateOutputTexture();
			Shader.SetGlobalTexture("_heatmapTexture3d", OutputTexture3D);
			SetHeatmapShowing((HeatmapType)GlobalSaveController.CurrentVillageData.HeatmapVisible);
			MonoSingleton<UIController>.Instance.InfoCursorToggleEvent += OnInfoCursorToggle;
			PlayerVoxelInfo playerVoxelInfo = MonoSingleton<PlayerVoxelInfo>.Instance;
			playerVoxelInfo.OnHoverChange = (Action<Vec3Int>)Delegate.Combine(playerVoxelInfo.OnHoverChange, new Action<Vec3Int>(OnVoxelHoverChange));
			updateTimer = new UnscaledTimer(0.6f, restartOnEnd: true);
			updateTimer.AddCallback(OnUpdateTimer);
		}

		public void ToggleHeatmapShowing(HeatmapType heatmapType)
		{
			if (HeatmapShowing == heatmapType)
			{
				SetHeatmapShowing(HeatmapType.None);
			}
			else
			{
				SetHeatmapShowing(heatmapType);
			}
			MonoSingleton<RoomViewManager>.Instance.IsShowingRooms = HeatmapShowing == HeatmapType.RoomOverlay;
		}

		public void DisplayHeatmap(HeatmapType heatmapType, ComputeBuffer bufferToDisplay, bool isInputBuffer3D, float heatmapValueMin, float heatmapValueMax, Texture2D gradientTexture)
		{
			if (HeatmapShowing == heatmapType && HeatmapShowing != HeatmapType.None)
			{
				Shader.SetGlobalTexture("_heatmapGradient", gradientTexture);
				int threadGroupsX = Mathf.CeilToInt((float)resolution.x / (float)threadGroupX);
				int threadGroupsY = Mathf.CeilToInt((float)resolution.y / (float)threadGroupY);
				int threadGroupsZ = Mathf.CeilToInt((float)resolution.z / (float)threadGroupZ);
				if (isInputBuffer3D)
				{
					computeShader.EnableKeyword("_USING_3D_BUFFER");
				}
				else
				{
					computeShader.DisableKeyword("_USING_3D_BUFFER");
				}
				computeShader.SetFloat("heatmapValueMin", heatmapValueMin);
				computeShader.SetFloat("heatmapValueMax", heatmapValueMax);
				computeShader.SetBuffer(kernelIndex, "inputBuffer", bufferToDisplay);
				computeShader.SetTexture(kernelIndex, "outputTexture3D", OutputTexture3D);
				computeShader.Dispatch(kernelIndex, threadGroupsX, threadGroupsY, threadGroupsZ);
			}
		}

		private void SetHeatmapShowing(HeatmapType heatmapType)
		{
			if (HeatmapShowing != heatmapType)
			{
				if (heatmapType == HeatmapType.Temperature)
				{
					Shader.SetGlobalInt("_GlobalGradient", 0);
				}
				if (heatmapType == HeatmapType.Beauty)
				{
					Shader.SetGlobalInt("_GlobalGradient", 1);
				}
				if (isInfoCursorActive && isInfoCursorActiveForHeatmap)
				{
					isInfoCursorActiveForHeatmap = false;
					MonoSingleton<UIController>.Instance.ToggleInfoCursor(active: false, "vheatmap");
				}
			}
			HeatmapShowing = heatmapType;
			GlobalSaveController.CurrentVillageData.HeatmapVisible = (int)HeatmapShowing;
			this.OnShowHeatmap?.Invoke(HeatmapShowing);
			if (HeatmapShowing != HeatmapType.None && HeatmapShowing != HeatmapType.RoomOverlay)
			{
				Shader.EnableKeyword("_HEATMAP");
			}
			else
			{
				Shader.DisableKeyword("_HEATMAP");
			}
		}

		private void Start()
		{
			MonoSingleton<TaskController>.Instance.WaitUntil((float time) => VillageManager.ActiveVillage.MapSize != Vec3Int.zero).Then(delegate
			{
				Initialize(VillageManager.ActiveVillage.MapSize);
			});
		}

		protected override void OnDestroy()
		{
			OutputTexture3D.Release();
			UnityEngine.Object.Destroy(OutputTexture3D);
			OutputTexture3D = null;
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.InfoCursorToggleEvent -= OnInfoCursorToggle;
			}
			if (MonoSingleton<PlayerVoxelInfo>.IsInstantiated())
			{
				PlayerVoxelInfo playerVoxelInfo = MonoSingleton<PlayerVoxelInfo>.Instance;
				playerVoxelInfo.OnHoverChange = (Action<Vec3Int>)Delegate.Remove(playerVoxelInfo.OnHoverChange, new Action<Vec3Int>(OnVoxelHoverChange));
			}
			map = null;
			this.OnShowHeatmap = null;
			base.OnDestroy();
			updateTimer?.Dispose();
			updateTimer = null;
		}

		private void CreateOutputTexture()
		{
			if (OutputTexture3D == null)
			{
				OutputTexture3D = new RenderTexture(resolution.x, resolution.y, 0, RenderTextureFormat.R16, RenderTextureReadWrite.Linear);
				OutputTexture3D.dimension = TextureDimension.Tex3D;
				OutputTexture3D.volumeDepth = resolution.z;
				OutputTexture3D.useMipMap = false;
				OutputTexture3D.filterMode = FilterMode.Point;
				OutputTexture3D.enableRandomWrite = true;
				OutputTexture3D.Create();
				OutputTexture3D.name = "VisualHeatmapManager.OutputTexture3D";
				Log.Info("Created output 3d texture.", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\VisualHeatmapManager.cs");
			}
			else if (OutputTexture3D.width != resolution.x || OutputTexture3D.height != resolution.y || OutputTexture3D.volumeDepth != resolution.z)
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(58, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\VisualHeatmapManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Deleting output 3d texture - size (");
					messageBuilder.AppendFormatted(OutputTexture3D.width);
					messageBuilder.AppendLiteral(", ");
					messageBuilder.AppendFormatted(OutputTexture3D.height);
					messageBuilder.AppendLiteral(", ");
					messageBuilder.AppendFormatted(OutputTexture3D.volumeDepth);
					messageBuilder.AppendLiteral(") did not match (");
					messageBuilder.AppendFormatted(resolution);
					messageBuilder.AppendLiteral(").");
				}
				Log.Info(messageBuilder);
				OutputTexture3D.Release();
				UnityEngine.Object.DestroyImmediate(OutputTexture3D);
				OutputTexture3D = null;
				CreateOutputTexture();
			}
		}

		private void OnInfoCursorToggle(bool isActive, string tag)
		{
			if (!(tag != "vheatmap"))
			{
				isInfoCursorActive = isActive;
				if (!isActive)
				{
					isInfoCursorActiveForHeatmap = false;
					MonoSingleton<UIController>.Instance.SetInfoCursorBackground(isActive: false);
				}
			}
		}

		private void RefreshInfoCursorContent()
		{
			if (!MonoSingleton<World>.IsInstantiated() || !MonoSingleton<World>.Instance.IsLoaded || HeatmapShowing == HeatmapType.None || map?.BeautyManager == null || map?.TemperatureManager == null)
			{
				return;
			}
			infoCursorStringBuilder.Clear();
			infoCursorLines.Clear();
			Vec3Int hoverGridPosition = MonoSingleton<PlayerVoxelInfo>.Instance.HoverGridPosition;
			if (HeatmapShowing == HeatmapType.Beauty && isInfoCursorActiveForHeatmap)
			{
				float beauty = map.BeautyManager.GetBeauty(hoverGridPosition);
				infoCursorStringBuilder.AppendFormat("{0}: {1:N1}", MonoSingleton<LocalizationController>.Instance.GetText("menu_beauty_points"), beauty);
			}
			if (HeatmapShowing == HeatmapType.Temperature && isInfoCursorActiveForHeatmap)
			{
				float temperature = map.TemperatureManager.GetTemperature(hoverGridPosition);
				float lightIntensity = map.TemperatureManager.GetLightIntensity(hoverGridPosition);
				MapNode node = map.GetNode(hoverGridPosition);
				string localizedTemperature = WorldDate.GetLocalizedTemperature(temperature);
				string key = ((node == null) ? "outside" : node.Coverage.ToString().ToLower());
				infoCursorStringBuilder.AppendFormat("{0}: {1}\n", MonoSingleton<LocalizationController>.Instance.GetText("general_temperature"), localizedTemperature);
				infoCursorStringBuilder.AppendFormat("{0}: {1}%\n", MonoSingleton<LocalizationController>.Instance.GetText("node_sunlight"), (int)(Mathf.Clamp01(lightIntensity) * 100f));
				infoCursorStringBuilder.AppendFormat("{0}", MonoSingleton<LocalizationController>.Instance.GetText(key));
			}
			if (HeatmapShowing == HeatmapType.RoomOverlay && isInfoCursorActiveForHeatmap)
			{
				MapNode node2 = map.GetNode(hoverGridPosition);
				Room room = map.RoomDetection.GetRoom(node2);
				if (room != null)
				{
					if (room.RoomType != null)
					{
						string arg = ColorUtility.ToHtmlStringRGB(room.RoomType.Color);
						infoCursorStringBuilder.AppendFormat("<color=#{0}>{1}</color>\n", arg, room.GetRoomTypeLocalized());
					}
					infoCursorStringBuilder.AppendFormat("{0}: {1}\n", MonoSingleton<LocalizationController>.Instance.GetText("room_imp"), room.Impressiveness?.NameLocalized);
					infoCursorStringBuilder.AppendFormat("{0}: {1}\n", MonoSingleton<LocalizationController>.Instance.GetText("room_imp_free_space"), room.FreeSpace);
					infoCursorStringBuilder.AppendFormat("{0}: {1:F1}\n", MonoSingleton<LocalizationController>.Instance.GetText("room_imp_wealth"), room.TotalWealth);
					infoCursorStringBuilder.AppendFormat("{0}: {1:F1}", MonoSingleton<LocalizationController>.Instance.GetText("room_imp_average_beauty"), room.AverageBeauty);
				}
				else if (node2 != null && node2.Coverage.ToString().ToLower() != "outside")
				{
					infoCursorStringBuilder.AppendFormat("{0}", MonoSingleton<LocalizationController>.Instance.GetText(node2.Coverage.ToString().ToLower()));
				}
			}
			infoCursorLines.Add(infoCursorStringBuilder.ToString());
			if (!isInfoCursorActive)
			{
				MonoSingleton<UIController>.Instance.ToggleInfoCursor(active: true, "vheatmap");
			}
			MonoSingleton<UIController>.Instance.UpdateInfoCursorContent(infoCursorLines, "vheatmap", 1);
		}

		private void OnVoxelHoverChange(Vec3Int obj)
		{
			if (isInfoCursorActive && isInfoCursorActiveForHeatmap)
			{
				RefreshInfoCursorContent();
			}
		}

		private void OnUpdateTimer()
		{
			if (!MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible && HeatmapShowing != HeatmapType.None)
			{
				if (!isInfoCursorActive)
				{
					MonoSingleton<UIController>.Instance.ToggleInfoCursor(active: true, "vheatmap");
					isInfoCursorActiveForHeatmap = true;
					RefreshInfoCursorContent();
				}
				if (isInfoCursorActiveForHeatmap)
				{
					RefreshInfoCursorContent();
				}
			}
		}
	}
}
