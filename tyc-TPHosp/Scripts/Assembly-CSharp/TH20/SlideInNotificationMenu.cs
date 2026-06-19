using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class SlideInNotificationMenu : MenuBase
	{
		[Serializable]
		private struct RadioSongData
		{
			public RectTransform Parent;

			public TMP_Text SongLabel;

			public TMP_Text ArtistLabel;
		}

		[Serializable]
		private struct MonthMoneySummaryData
		{
			public RectTransform Parent;

			public LocalisedString RevenueLocalisedString;

			public LocalisedString ExpensesLocalisedString;

			public LocalisedString NetIncomeLocalisedString;

			public LocalisedString TotalSilverLocalisedString;

			public TMP_Text RevenueText;

			public TMP_Text ExpensesText;

			public TMP_Text NetIncomeText;
		}

		private struct QueueItem
		{
			public RadioSong RadioSong;

			public LevelStatsDatabase.MonthStats MonthStats;
		}

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		[SerializeField]
		private float _showDuration = 8f;

		[SerializeField]
		private float _introDuration = 1f;

		[SerializeField]
		private float _outroDuration = 4f;

		[SerializeField]
		private float _slideOffset = 100f;

		[SerializeField]
		private EasingsUtils.Functions _introEasing = EasingsUtils.Functions.ElasticEaseInOut;

		[SerializeField]
		private EasingsUtils.Functions _outroEasing = EasingsUtils.Functions.ElasticEaseInOut;

		[SerializeField]
		private RadioSongData _radioSongData;

		[SerializeField]
		private MonthMoneySummaryData _monthMoneySummaryData;

		private Level _level;

		private int _maxQueueLength = 5;

		private Vector2 _radioShowingAnchoredPosition;

		private Vector2 _monthSummaryAnchoredPosition;

		private Coroutine _activeCoroutine;

		private List<QueueItem> _queue = new List<QueueItem>();

		public void Setup(Level level)
		{
			_level = level;
			_level.InputManager.AddGraphicRayCaster(_graphicRaycaster);
			LevelStatsDatabase levelStatsDatabase = _level.LevelStatsDatabase;
			levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnMonthCompleted));
			_radioShowingAnchoredPosition = _radioSongData.Parent.anchoredPosition;
			_monthSummaryAnchoredPosition = _monthMoneySummaryData.Parent.anchoredPosition;
			ResetNotifications();
		}

		private void ResetNotifications()
		{
			_radioSongData.Parent.anchoredPosition = _radioShowingAnchoredPosition + new Vector2(_slideOffset, 0f);
			_monthMoneySummaryData.Parent.anchoredPosition = _monthSummaryAnchoredPosition + new Vector2(_slideOffset, 0f);
			_radioSongData.Parent.gameObject.SetActive(value: false);
			_monthMoneySummaryData.Parent.gameObject.SetActive(value: false);
		}

		public void HideNotifications()
		{
			_queue.Clear();
			ResetNotifications();
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine(_activeCoroutine);
				_activeCoroutine = StartCoroutine(UpdateCoroutine());
			}
		}

		private void OnMonthCompleted(LevelStatsDatabase.MonthStats monthStats)
		{
			if (_queue.Count > _maxQueueLength)
			{
				_queue.Clear();
			}
			_queue.Add(new QueueItem
			{
				MonthStats = monthStats
			});
		}

		protected void OnEnable()
		{
			_activeCoroutine = StartCoroutine(UpdateCoroutine());
		}

		protected void OnDisable()
		{
			StopCoroutine(_activeCoroutine);
			_activeCoroutine = null;
		}

		public void QueueRadioSong(RadioSong radioSong)
		{
			if (_queue.Count > _maxQueueLength)
			{
				_queue.Clear();
			}
			_queue.Add(new QueueItem
			{
				RadioSong = radioSong
			});
		}

		private IEnumerator UpdateCoroutine()
		{
			while (true)
			{
				yield return null;
				if (_queue.Count == 0)
				{
					continue;
				}
				RectTransform notificationParent = null;
				if (_queue[0].RadioSong != null)
				{
					_radioSongData.SongLabel.text = _queue[0].RadioSong.GetSongDisplayName();
					_radioSongData.ArtistLabel.text = _queue[0].RadioSong.GetArtistDisplayName();
					notificationParent = _radioSongData.Parent;
				}
				else if (_queue[0].MonthStats != null)
				{
					LevelStatsDatabase.MonthStats monthStats = _queue[0].MonthStats;
					int revenue = monthStats.Revenue;
					int regularExpenses = monthStats.RegularExpenses;
					int num = revenue - regularExpenses;
					_monthMoneySummaryData.RevenueText.text = _monthMoneySummaryData.RevenueLocalisedString.Translation.Replace("{[AMOUNT]}", StringUtils.FormatCurrency(revenue));
					_monthMoneySummaryData.ExpensesText.text = _monthMoneySummaryData.ExpensesLocalisedString.Translation.Replace("{[AMOUNT]}", StringUtils.FormatCurrency(regularExpenses));
					_monthMoneySummaryData.NetIncomeText.text = _monthMoneySummaryData.NetIncomeLocalisedString.Translation.Replace("{[AMOUNT]}", StringUtils.FormatCurrency(num));
					notificationParent = _monthMoneySummaryData.Parent;
				}
				_queue.RemoveAt(0);
				if (notificationParent != null)
				{
					notificationParent.gameObject.SetActive(value: true);
					float currentTime = 0f;
					while (currentTime < _introDuration)
					{
						currentTime += Time.unscaledDeltaTime;
						float num2 = EasingsUtils.Interpolate(1f - Mathf.Clamp01(currentTime / _introDuration), _introEasing);
						notificationParent.anchoredPosition = _radioShowingAnchoredPosition + new Vector2(num2 * _slideOffset, 0f);
						yield return null;
					}
					yield return new WaitForSecondsRealtime(_showDuration);
					currentTime = 0f;
					while (currentTime < _outroDuration)
					{
						currentTime += Time.unscaledDeltaTime;
						float num3 = EasingsUtils.Interpolate(Mathf.Clamp01(currentTime / _outroDuration), _outroEasing);
						notificationParent.anchoredPosition = _radioShowingAnchoredPosition + new Vector2(num3 * _slideOffset, 0f);
						yield return null;
					}
					notificationParent.gameObject.SetActive(value: false);
					yield return new WaitForSeconds(2f);
				}
			}
		}

		protected void OnDestroy()
		{
			LevelStatsDatabase levelStatsDatabase = _level.LevelStatsDatabase;
			levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Remove(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnMonthCompleted));
			_level.InputManager.RemoveGraphicRayCaster(_graphicRaycaster);
		}
	}
}
