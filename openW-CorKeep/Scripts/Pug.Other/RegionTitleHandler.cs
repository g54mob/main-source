using System;
using System.Collections.Generic;
using I2.Loc;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using UnityEngine;

public class RegionTitleHandler : MonoBehaviour
{
	[Serializable]
	public class RegionTitle
	{
		public Biome biome;

		public List<Tileset> requiredTilesets;

		public LocalizedString title;

		public Color color;

		public Sprite icon;
	}

	public PugText title;

	public PugText titleOutline;

	public PugTextEffectFade titleFader;

	public PugTextEffectFade titleOutlineFader;

	public SpriteRenderer leftIcon;

	public SpriteRenderer rightIcon;

	[SerializeField]
	[Tooltip("Used as a fallback color for gamepad light when there is no valid region title available (for example for the Slime biome).")]
	private Color fallbackGamepadLightColor;

	private TimerSimple fadeDelayTimer;

	private TimerSimple musicFadeTimer;

	private RegionTitle currentRegionTitle;

	private Biome biomeLastShown;

	[ArrayElementTitle("biome")]
	public List<RegionTitle> regionTitles;

	public GameObject container;

	public PugText mapTitle;

	public PugText mapTitleOutline;

	public GameObject mapTitleContainer;

	private Color currentTitleColor = Color.white;

	private void Awake()
	{
		container.SetActive(value: false);
	}

	private void LateUpdate()
	{
		if (Manager.sceneHandler == null || !Manager.sceneHandler.isInGame)
		{
			currentRegionTitle = null;
			container.SetActive(value: false);
			mapTitleContainer.SetActive(value: false);
			musicFadeTimer.Stop();
			return;
		}
		Manager.audio.ambientSoundsHandler.GetNearbyTileData(out var tileCount).Complete();
		currentRegionTitle = GetRegionTitle(tileCount, out var regionTitle);
		if (currentRegionTitle == null || regionTitle == null)
		{
			if (biomeLastShown != Biome.None)
			{
				Manager.input.singleplayerInputModule.SetGamepadLight(fallbackGamepadLightColor);
				biomeLastShown = Biome.None;
			}
		}
		else if (biomeLastShown != currentRegionTitle.biome)
		{
			biomeLastShown = currentRegionTitle.biome;
			if (!Manager.saves.IsCreativeModeWorld() && !Manager.saves.HasDiscoveredBiome(currentRegionTitle.biome))
			{
				musicFadeTimer.Start(1f);
				Manager.music.FadeOutVolume(2f);
			}
			Manager.input.singleplayerInputModule.SetGamepadLight(currentRegionTitle.color);
		}
		if (musicFadeTimer.isRunning && musicFadeTimer.isTimerElapsed && currentRegionTitle != null)
		{
			musicFadeTimer.Stop();
			container.SetActive(value: true);
			fadeDelayTimer.Start(6f);
			string mTerm = currentRegionTitle.title.mTerm;
			title.Render(mTerm, rewindEffectAnims: true);
			Color color = new Color(currentRegionTitle.color.r, currentRegionTitle.color.g, currentRegionTitle.color.b, 0f);
			title.SetTempColor(color);
			currentTitleColor = color;
			titleOutline.Render(mTerm, rewindEffectAnims: true);
			leftIcon.color = color;
			rightIcon.color = color;
			leftIcon.sprite = currentRegionTitle.icon;
			rightIcon.sprite = currentRegionTitle.icon;
			Manager.saves.DiscoverBiome(currentRegionTitle.biome);
			AudioManager.SfxMono(SfxID.biomeTitle, 0.4f, 0.7f);
		}
		float currentCurveValue = titleFader.GetCurrentCurveValue();
		float num = title.dimensions.width / 2f;
		num = num + num % 0.0625f + 0.5f;
		leftIcon.SetAlpha(currentCurveValue);
		rightIcon.SetAlpha(currentCurveValue);
		leftIcon.transform.localPosition = new Vector3(0f - num, leftIcon.transform.localPosition.y, leftIcon.transform.localPosition.z);
		rightIcon.transform.localPosition = new Vector3(num, rightIcon.transform.localPosition.y, rightIcon.transform.localPosition.z);
		if (fadeDelayTimer.isRunning && fadeDelayTimer.isTimerElapsed)
		{
			fadeDelayTimer.Stop();
			titleFader.FadeOut();
			titleOutlineFader.FadeOut();
			Manager.music.FadeInVolume(2f);
		}
		if (!titleFader.isFading && (!fadeDelayTimer.isRunning || fadeDelayTimer.isTimerElapsed))
		{
			container.SetActive(value: false);
		}
		else if (currentRegionTitle != null)
		{
			title.SetTempColor(new Color(currentTitleColor.r, currentTitleColor.g, currentTitleColor.b, title.tmpColor.a));
		}
		if (Manager.ui.isShowingMap && !Manager.saves.IsCreativeModeWorld())
		{
			if (regionTitle != null)
			{
				mapTitleContainer.SetActive(value: true);
				mapTitle.Render(regionTitle.title.mTerm);
				mapTitle.SetTempColor(regionTitle.color);
				mapTitleOutline.Render(regionTitle.title.mTerm);
			}
			else
			{
				mapTitleContainer.SetActive(value: false);
			}
		}
		else
		{
			mapTitleContainer.SetActive(value: false);
		}
		container.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
		mapTitleContainer.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
	}

	private RegionTitle GetRegionTitle(NativeHashMap<TileTypeAndTileset, int> nearbyTileCount, out RegionTitle mapTitle)
	{
		mapTitle = null;
		PlayerController player = Manager.main.player;
		if (player == null)
		{
			return currentRegionTitle;
		}
		Biome currentBiome = player.currentBiome;
		if ((currentRegionTitle != null && currentBiome == currentRegionTitle.biome) || currentBiome == Biome.None)
		{
			mapTitle = ((currentBiome == Biome.None) ? null : currentRegionTitle);
			return currentRegionTitle;
		}
		if (!TryGetRegionTitle(currentBiome, out var result))
		{
			return currentRegionTitle;
		}
		if (!Manager.saves.HasDiscoveredBiome(currentBiome) && !HasSufficientMatchingTilesets(result, nearbyTileCount))
		{
			return currentRegionTitle;
		}
		mapTitle = result;
		return result;
	}

	private bool TryGetRegionTitle(Biome biome, out RegionTitle result)
	{
		foreach (RegionTitle regionTitle in regionTitles)
		{
			if (regionTitle.biome == biome)
			{
				result = regionTitle;
				return true;
			}
		}
		result = null;
		return false;
	}

	private bool HasSufficientMatchingTilesets(RegionTitle regionTitle, NativeHashMap<TileTypeAndTileset, int> nearbyTileCount)
	{
		foreach (Tileset requiredTileset in regionTitle.requiredTilesets)
		{
			if (CountNearbyTiles(TileType.wall, requiredTileset, nearbyTileCount) + CountNearbyTiles(TileType.ground, requiredTileset, nearbyTileCount) + CountNearbyTiles(TileType.water, requiredTileset, nearbyTileCount) > 100)
			{
				return true;
			}
		}
		return false;
	}

	private int CountNearbyTiles(TileType tileType, Tileset tileset, NativeHashMap<TileTypeAndTileset, int> nearbyTileCount)
	{
		TileTypeAndTileset key = new TileTypeAndTileset
		{
			TileType = tileType,
			Tileset = tileset
		};
		if (!nearbyTileCount.TryGetValue(key, out var item))
		{
			return 0;
		}
		return item;
	}
}
