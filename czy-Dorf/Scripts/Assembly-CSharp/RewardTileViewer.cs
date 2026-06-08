using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class RewardTileViewer : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<MeshRenderer, bool> _003C_003E9__16_0;

		internal bool _003CSetupLevelRewards_003Eb__16_0(MeshRenderer x)
		{
			return x.sharedMaterial.name.Contains("MAT_Water_");
		}
	}

	private sealed class _003CDisableCameraInNextFrame_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RewardTileViewer _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CDisableCameraInNextFrame_003Ed__19(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			RewardTileViewer rewardTileViewer = _003C_003E4__this;
			if (num != 0)
			{
				return false;
			}
			_003C_003E1__state = -1;
			rewardTileViewer.light.enabled = true;
			rewardTileViewer.renderCamera.Render();
			rewardTileViewer.renderCamera.enabled = false;
			rewardTileViewer.light.enabled = false;
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
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private MeshRenderer backgroundQuad;

	[SerializeField]
	private RenderTexture renderTextureReference;

	private List<Tile> rewardTiles = new List<Tile>();

	private List<Tile> previewTiles = new List<Tile>();

	[SerializeField]
	private TileFactory tileFactory;

	private SessionQuest sessionQuest;

	private Camera renderCamera;

	private Light light;

	private Texture[] completedRenderTextures;

	private Texture[] previewRenderTextures;

	private int currentlyActiveIndex = -1;

	public object Level => currentlyActiveIndex;

	public void Setup(SessionQuest sessionQuest, List<Texture2D> preRenderedImages)
	{
		this.sessionQuest = sessionQuest;
		base.name = "SessionQuestTileViewer_" + sessionQuest.name;
		renderCamera = GetComponentInChildren<Camera>();
		light = GetComponentInChildren<Light>();
		completedRenderTextures = new Texture[sessionQuest.LevelCount];
		previewRenderTextures = new Texture[sessionQuest.LevelCount];
		if (preRenderedImages != null)
		{
			for (int i = 0; i < preRenderedImages.Count; i++)
			{
				if (i % 2 == 0)
				{
					completedRenderTextures[Mathf.FloorToInt((float)i / 2f)] = preRenderedImages[i];
				}
				else
				{
					previewRenderTextures[Mathf.FloorToInt((float)i / 2f)] = preRenderedImages[i];
				}
			}
		}
		for (int j = 0; j < sessionQuest.LevelCount; j++)
		{
			SetupLevelRewards(j);
		}
		base.gameObject.SetActive(value: false);
	}

	public Texture GetRenderTexture(int levelIndex = -1, RewardState overwriteRewardState = RewardState.Undefined)
	{
		int value = ((levelIndex == -1) ? sessionQuest.CurrentLevelIndex : levelIndex);
		RewardState rewardState = ((overwriteRewardState == RewardState.Undefined) ? sessionQuest.GetLevelState(levelIndex) : overwriteRewardState);
		if (rewardState == RewardState.Hidden)
		{
			return null;
		}
		value = Mathf.Clamp(value, 0, sessionQuest.LevelCount - 1);
		Texture[] array = ((rewardState == RewardState.Completed) ? completedRenderTextures : previewRenderTextures);
		if (array[value] != null)
		{
			return array[value];
		}
		RenderTexture renderTexture = new RenderTexture(renderTextureReference)
		{
			name = $"RenderTexture_{sessionQuest.name}_{value}_{rewardState}"
		};
		renderCamera.targetTexture = renderTexture;
		DisplayLevel(value, rewardState);
		array[value] = renderTexture;
		return renderTexture;
	}

	private void DisplayLevel(int levelIndex, RewardState displayState)
	{
		if (currentlyActiveIndex != -1)
		{
			previewTiles[currentlyActiveIndex].gameObject.SetActive(value: false);
			rewardTiles[currentlyActiveIndex].gameObject.SetActive(value: false);
		}
		currentlyActiveIndex = levelIndex;
		Color secondaryColor;
		Color uiColor = sessionQuest.GetLevel(currentlyActiveIndex).reward.displayBiome.GetUiColor(out secondaryColor);
		backgroundQuad.material.SetColor("_bottomCol", uiColor);
		backgroundQuad.material.SetColor("_topCol", secondaryColor);
		previewTiles[currentlyActiveIndex].gameObject.SetActive(displayState == RewardState.InProgress);
		rewardTiles[currentlyActiveIndex].gameObject.SetActive(displayState == RewardState.Completed);
		RenderOnce();
	}

	private void SetupLevelRewards(int levelIndex)
	{
		SessionQuestLevel level = sessionQuest.GetLevel(levelIndex);
		if (completedRenderTextures[levelIndex] == null)
		{
			Tile tile = UnityEngine.Object.Instantiate(level.reward.displayTile, base.transform);
			tile.transform.localPosition = Vector3.zero;
			tile.transform.localRotation = Quaternion.AngleAxis(level.reward.displayRotation, Vector3.up);
			tile.InitializeSeed(level.reward.seed);
			tileFactory.InitializePrebuiltTile(tile);
			BiomeManager.ApplyBiomeToTile(tile, level.reward.displayBiome, level.reward);
			foreach (MeshRenderer item in Enumerable.ToList(Enumerable.Where(tile.GetComponentsInChildren<MeshRenderer>(), (MeshRenderer x) => x.sharedMaterial.name.Contains("MAT_Water_"))))
			{
				item.sharedMaterial = level.reward.displayBiome.GetBiomeWaterMaterial();
			}
			tile.ChangeTileState(TileState.stackPreview);
			tile.SetLayer(12);
			rewardTiles.Add(tile);
			tile.gameObject.SetActive(value: false);
		}
		if (previewRenderTextures[levelIndex] == null)
		{
			Tile tile2 = UnityEngine.Object.Instantiate(level.reward.displayTile, base.transform);
			tile2.transform.localPosition = Vector3.zero;
			tile2.transform.localRotation = Quaternion.AngleAxis(level.reward.displayRotation, Vector3.up);
			tile2.InitializeSeed(level.reward.seed);
			tileFactory.InitializePrebuiltTile(tile2);
			BiomeManager.ApplyBiomeToTile(tile2, level.reward.displayBiome, level.reward);
			tile2.ChangeTileState(TileState.stackPreview);
			tile2.SetLayer(12);
			tile2.SetMaterials(level.reward.displayBiome.GetBiomeTileSlotMaterial());
			previewTiles.Add(tile2);
			tile2.gameObject.SetActive(value: false);
		}
	}

	public void ClearRenderTextures()
	{
		for (int i = 0; i < completedRenderTextures.Length; i++)
		{
			completedRenderTextures[i] = null;
		}
		for (int j = 0; j < previewRenderTextures.Length; j++)
		{
			previewRenderTextures[j] = null;
		}
	}

	public void RenderOnce()
	{
		base.gameObject.SetActive(value: true);
		light.enabled = true;
		renderCamera.Render();
		renderCamera.enabled = false;
		light.enabled = false;
		base.gameObject.SetActive(value: false);
	}

	private IEnumerator DisableCameraInNextFrame()
	{
		return new _003CDisableCameraInNextFrame_003Ed__19(0)
		{
			_003C_003E4__this = this
		};
	}
}
