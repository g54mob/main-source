using System;
using System.Collections.Generic;
using DG.Tweening;
using Libs;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.Render
{
	public class BattleRenderGroup : SingletonMonoBehaviour<BattleRenderGroup>
	{
		[Serializable]
		private class PageTextureGroup
		{
			public eStageDivision division;

			public List<PageTextures> texturesPair;
		}

		[Serializable]
		private struct PageTextures
		{
			public eTurnPage pageSet;

			public Texture pageTexture;
		}

		public enum RenderUIGroup
		{
			RouteChoiceUI = 0,
			EventChoiceUI = 1,
			Empty = 2
		}

		public GameObject uiRenderGroup;

		[SerializeField]
		private Image baseTexture;

		[SerializeField]
		private List<PageTextureGroup> pageTextures;

		[SerializeField]
		private List<PageTextures> _defaultPageSet;

		[SerializeField]
		private RectTransform[] _pageContents;

		[SerializeField]
		private Vector3[] _pagePos;

		[SerializeField]
		private RenderTexture _renderTexture;

		[SerializeField]
		private Image _bossField;

		[SerializeField]
		private RawImage _upperPageBG;

		[SerializeField]
		private RawImage _lowerPageBG;

		[SerializeField]
		private List<CanvasGroup> pageCanvasGrous;

		[Label("ラストバトルの途中で利用する特殊なページ")]
		[SerializeField]
		private List<PageTextures> _lastLoadPage;

		private Dictionary<eTurnPage, Texture> _pageTexturePairs;

		public Camera targetCamera;

		private RenderTexture waitTexture;

		private int _renderCount;

		private Material _material;

		private float _defaultEdge;

		private RenderUIGroup _nextTopUI;

		public eTurnPage NowPage { get; private set; }

		public eTurnPage NextPage { get; private set; }

		public bool TurnOk { get; private set; }

		public void Init()
		{
		}

		public void RenderingUITexture(eTurnPage upperPage, eTurnPage lowrPage)
		{
		}

		public void ApplyTexture(RenderTexture texture)
		{
		}

		public void SetBackgroundTexture(eTurnPage upperPage, eTurnPage lowerPage)
		{
		}

		public void DuplicateUIOnBook(int page, GameObject original, bool hiddenAll = true)
		{
		}

		public RectTransform GetParent(int parentIndex)
		{
			return null;
		}

		public void SetBackToFront(RenderUIGroup group)
		{
		}

		public void SetNextPage(eTurnPage nowPage, eTurnPage nextPage, RenderUIGroup group)
		{
		}

		public Sequence OpenPageSequence()
		{
			return null;
		}

		private void MoveParent(int parentIdx, int pageIdx)
		{
		}

		private void HiddenOtherTopUI(RenderUIGroup topUI)
		{
		}

		public void HiddenAllUI()
		{
		}

		private void CopyLocalPosition(Transform original, Transform target)
		{
		}

		public Sequence PlayDissolve(float duration, int page, float endValue = 1f, bool nowValueStart = false)
		{
			return null;
		}

		public Sequence PlayCanvasFade(float duration, float endValue)
		{
			return null;
		}

		private void SaveTexture(Texture2D texture)
		{
		}

		public void ReplacementPageTexture(eStageDivision division)
		{
		}

		private new void OnDestroy()
		{
		}

		private void Update()
		{
		}
	}
}
