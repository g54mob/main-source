using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dorfromantik;
using UnityEngine;

public class RewardTileViewerManager : Singleton<RewardTileViewerManager>
{
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public SessionQuest sessionQuest;

		internal bool _003CCreateTileViewer_003Eb__0(RewardImageData x)
		{
			return x.challenge == sessionQuest;
		}

		internal bool _003CCreateTileViewer_003Eb__1(RewardImageData x)
		{
			return x.challenge == sessionQuest;
		}
	}

	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	[SerializeField]
	private RewardTileViewer tileViewerPrefab;

	[SerializeField]
	private List<RewardImageData> preRenderedRewardImages;

	[SerializeField]
	private bool usePreRenderedImages = true;

	private Dictionary<SessionQuest, RewardTileViewer> tileViewerBySessionQuest = new Dictionary<SessionQuest, RewardTileViewer>();

	private Vector3 viewerSpawnOffset = new Vector3(0f, 0f, 0f);

	protected override void Awake()
	{
		base.Awake();
		Setup();
	}

	private void Setup()
	{
		for (int i = 0; i < sessionQuestManager.sessionQuests.Count; i++)
		{
			SessionQuest sessionQuest = sessionQuestManager.sessionQuests[i];
			if (sessionQuest.compositeParentQuest == null)
			{
				CreateTileViewer(sessionQuest);
			}
		}
	}

	private void CreateTileViewer(SessionQuest sessionQuest)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals6 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals6.sessionQuest = sessionQuest;
		RewardTileViewer rewardTileViewer = Object.Instantiate(tileViewerPrefab, viewerSpawnOffset + Vector3.right * 2f * tileViewerBySessionQuest.Count, Quaternion.identity, base.transform);
		if (usePreRenderedImages && Enumerable.Count(preRenderedRewardImages, (RewardImageData x) => x.challenge == CS_0024_003C_003E8__locals6.sessionQuest) > 0)
		{
			rewardTileViewer.Setup(CS_0024_003C_003E8__locals6.sessionQuest, Enumerable.First(preRenderedRewardImages, (RewardImageData x) => x.challenge == CS_0024_003C_003E8__locals6.sessionQuest).images);
		}
		else
		{
			rewardTileViewer.Setup(CS_0024_003C_003E8__locals6.sessionQuest, null);
		}
		tileViewerBySessionQuest.Add(CS_0024_003C_003E8__locals6.sessionQuest, rewardTileViewer);
	}

	public RewardTileViewer GetTileViewer(SessionQuest sessionQuest)
	{
		if (!tileViewerBySessionQuest.ContainsKey(sessionQuest) && (bool)sessionQuest.compositeParentQuest)
		{
			return tileViewerBySessionQuest[sessionQuest.compositeParentQuest];
		}
		if (!tileViewerBySessionQuest.ContainsKey(sessionQuest))
		{
			Debug.LogError($"no key for {sessionQuest} found");
		}
		return tileViewerBySessionQuest[sessionQuest];
	}

	private void RenderAllTiles()
	{
		foreach (KeyValuePair<SessionQuest, RewardTileViewer> item in tileViewerBySessionQuest)
		{
			item.Value.ClearRenderTextures();
			for (int i = 0; i < item.Key.LevelCount; i++)
			{
				RenderTile(item.Value, i, RewardState.Completed);
				RenderTile(item.Value, i, RewardState.InProgress);
			}
		}
	}

	private void RenderSpecificTile(SessionQuest challenge, int level, RewardState rewardState)
	{
		tileViewerBySessionQuest[challenge].ClearRenderTextures();
		RenderTile(tileViewerBySessionQuest[challenge], level, rewardState);
	}

	private void RenderTile(RewardTileViewer tileViewer, int level, RewardState rewardState)
	{
		RenderTexture renderTexture = (RenderTexture)tileViewer.GetRenderTexture(level, rewardState);
		if (renderTexture == null)
		{
			Debug.LogError($"no render texture for {tileViewer}, level {level}, state {rewardState}");
			return;
		}
		Texture2D texture2D = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, mipChain: false);
		RenderTexture.active = renderTexture;
		texture2D.ReadPixels(new Rect(0f, 0f, renderTexture.width, renderTexture.height), 0, 0);
		texture2D.Apply();
		byte[] bytes = ImageConversion.EncodeToPNG(texture2D);
		string path = $"{renderTexture.name}_{level:#0}_{rewardState}_{renderTexture.width}px.png";
		File.WriteAllBytes(Path.Combine(Application.persistentDataPath, "Renders", path), bytes);
	}
}
