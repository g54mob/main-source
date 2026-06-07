using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using InputControl;
using SaveData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class PlayLogDialog : BaseDialog
	{
		[Serializable]
		private class ContentsPageInfo
		{
			public PageType pageType;

			public Toggle tabToggle;

			public GameObject tabOnObj;

			public FilterType filterType;

			public List<ContentsInfo> contentsInfos;

			public bool isChallenge => false;

			public bool isOnFavoriteFilter => false;

			public ContentsInfo GetContentsInfo(FilterType? targetFilterType = null)
			{
				return null;
			}

			public void SetFilter(FilterType filterType)
			{
			}
		}

		[Serializable]
		private class ContentsInfo
		{
			public FilterType filterType;

			public RectTransform contentsParent;

			public TMP_Text countText;

			public int page;

			public int pageMax;

			public int refleshPage;

			public int recordCount;

			public float contentsParentBasePositionX;

			public List<RecordItem> recordItems;

			public List<RecordItem> currentDisplayRecordItems => null;

			public bool isFavorite => false;

			public bool haveItems => false;
		}

		private enum PageType
		{
			Normal = 0,
			Challenge = 1
		}

		private enum FilterType
		{
			None = 0,
			Favorite = 1
		}

		[Serializable]
		public class PlayLogFavorite
		{
			public List<string> playLogFavoriteList;
		}

		[CompilerGenerated]
		private sealed class _003CExecuteAfterOneFrameCoroutine_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Action action;

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
			public _003CExecuteAfterOneFrameCoroutine_003Ed__51(int _003C_003E1__state)
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

		[Header("ContentsPages")]
		[SerializeField]
		private List<ContentsPageInfo> pageInfos;

		[Header("ItemPrefab")]
		[SerializeField]
		private RecordItem itemPrefab;

		[Header("MovePageButtons")]
		[SerializeField]
		private Button leftButton;

		[SerializeField]
		private Button rightButton;

		[SerializeField]
		private float onePageWidth;

		[SerializeField]
		private float pageMoveDuration;

		[Header("Count")]
		[SerializeField]
		private TMP_Text recordCountText;

		[Header("NoRecord")]
		[SerializeField]
		private GameObject noRecordObj;

		[Header("FilterToggle")]
		[SerializeField]
		private Toggle favoriteToggle;

		[SerializeField]
		private GameObject favoriteOnObj;

		[Header("MaxFavoriteErrorText")]
		[SerializeField]
		private GameObject maxFavoriteErrorObj;

		[SerializeField]
		private CanvasGroup maxFavoriteErrorGroup;

		[SerializeField]
		private CursorUIGroup cursorUIGroup;

		[SerializeField]
		private PadInputConfigure padInputConfigure;

		public GameObject tabGroupObj;

		public GameObject challengeTabObj;

		private bool isInitialized;

		private const int OnePageItemMax = 12;

		private bool isAnimation;

		private PageType nowPageType;

		private Tween errorAnimationTween;

		private PlayLogFavorite playLogFavorite;

		private bool isOnFavoriteFilter => false;

		private List<string> playLogFavoriteList
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private ContentsPageInfo GetContentsPageInfo()
		{
			return null;
		}

		private ContentsInfo GetContentsInfo()
		{
			return null;
		}

		public override void Init()
		{
		}

		private void InitRecordCount()
		{
		}

		private void UpdateContentsInfoAll()
		{
		}

		private void UpdateContentsInfo(bool isChallenge, ContentsInfo info)
		{
		}

		private void UpdateCountText(ContentsInfo info, int max)
		{
		}

		private void UpdateCountText(ContentsInfo info, bool isChallenge, FilterType? filterType = null)
		{
		}

		private void CreateItems(int page)
		{
		}

		public override void Open()
		{
		}

		public override void Back()
		{
		}

		private void OpenInit()
		{
		}

		private void ClearRefleshPageItems()
		{
		}

		private void UpdatePage(ContentsPageInfo pageInfo = null)
		{
		}

		private void DisableAllPages()
		{
		}

		private int GetPageContentsCountMax(ContentsPageInfo pageInfo)
		{
			return 0;
		}

		private int GetPageContentsCountMax(bool isChallenge, FilterType filterType)
		{
			return 0;
		}

		public override void SetInFront()
		{
		}

		public void InterchangeProcess(ref InGameData openData, string inGameJson)
		{
		}

		public void OpenResult(string filePath)
		{
		}

		public void SwitchFavorite(RecordItem item)
		{
		}

		private void ShowMaxFavoriteError()
		{
		}

		private void PadContentsUpdate()
		{
		}

		public void DelayPadSelect()
		{
		}

		[IteratorStateMachine(typeof(_003CExecuteAfterOneFrameCoroutine_003Ed__51))]
		private IEnumerator ExecuteAfterOneFrameCoroutine(Action action)
		{
			return null;
		}

		public void MovePage(int dir)
		{
		}

		public void OnChangeTab(bool isOn)
		{
		}

		public void OnChangeTab()
		{
		}

		public void SwitchFilter(bool isOn)
		{
		}

		public void SwitchFilter()
		{
		}

		public List<string> GetFavoriteList(bool isChallenge = false)
		{
			return null;
		}

		public void RefleshFavoriteList()
		{
		}

		public bool SetFavorite(string path)
		{
			return false;
		}

		public bool RemoveFavorite(string path)
		{
			return false;
		}

		public bool IsFavorite(string path)
		{
			return false;
		}

		private void SaveFavoriteList()
		{
		}
	}
}
