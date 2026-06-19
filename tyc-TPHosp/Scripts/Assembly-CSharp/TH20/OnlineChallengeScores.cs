using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class OnlineChallengeScores : MonoBehaviour
	{
		[SerializeField]
		private List<OnlineChallengeLeaderboardItem> _leaderboardItems;

		[SerializeField]
		private List<Color> _playersTextColors;

		[SerializeField]
		private List<UILineRenderer> _graphLines;

		[SerializeField]
		private float _minGraphHeight = 0.2f;

		[SerializeField]
		private float _graphLineThickness = 2f;

		[SerializeField]
		private float _graphHeightBuffer = 0.1f;

		[SerializeField]
		private float _playerGraphLineThicknessMultiplier = 2f;

		[SerializeField]
		private Texture _gridSprite;

		[SerializeField]
		private Texture _gridZoomedSprite;

		[SerializeField]
		private RawImage _gridImage;

		[SerializeField]
		private ButtonAnimator _gridZoomButton;

		[SerializeField]
		private int _zoomedDaysLeft = 20;

		[SerializeField]
		private int _zoomedDaysRight = 10;

		[SerializeField]
		private ButtonAnimator _screenshotButton;

		[SerializeField]
		private TooltipSpawner _screenshotButtonTooltip;

		[SerializeField]
		private GameObject _screenshotsLeftGameObject;

		[SerializeField]
		private TMP_Text _screenshotsLeftLabel;

		[SerializeField]
		private InputField _captionInputField;

		[SerializeField]
		private Image _screenshotImage;

		[SerializeField]
		private Image _screenshotFlashEffect;

		[SerializeField]
		private float _flashInTime = 0.32f;

		[SerializeField]
		private float _flashOutTime = 1.2f;

		[SerializeField]
		private float _flashHoldTime = 0.12f;

		[SerializeField]
		private float _pictureHoldTime = 3.5f;

		[SerializeField]
		private float _pictureOutTime = 1.2f;

		[HideInInspector]
		public const int MaxCaptionLength = 64;

		private Coroutine _takeScreenshotCoroutine;

		private OnlineChallengeObjective _levelObjective;

		private bool _isGridZoomed;

		private readonly List<KeyValuePair<OnlinePlayerID, float>> _leaderboardList = new List<KeyValuePair<OnlinePlayerID, float>>();

		private readonly Dictionary<OnlinePlayerID, UILineRenderer> _graphEntries = new Dictionary<OnlinePlayerID, UILineRenderer>();

		public void Setup(OnlineChallengeObjective levelObjective, Level level)
		{
			_levelObjective = levelObjective;
			_graphEntries.Clear();
			_leaderboardList.Clear();
			_isGridZoomed = false;
			if (_takeScreenshotCoroutine != null)
			{
				StopCoroutine(_takeScreenshotCoroutine);
			}
			int num = 0;
			foreach (KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo> item in _levelObjective.PlayerInfoDictionary)
			{
				_graphEntries.Add(item.Key, _graphLines[num]);
				num++;
			}
			Refresh();
		}

		protected void OnEnable()
		{
			_gridZoomButton.Button.onPrimaryDown.AddListener(OnGridZoomPressed);
			_gridImage.texture = (_isGridZoomed ? _gridZoomedSprite : _gridSprite);
			_screenshotButton.Button.onPrimaryDown.AddListener(OnScreenshotPressed);
			_screenshotButtonTooltip.SetDataProvider(OnScreenshotButtonTooltip);
			GameObjectUtils.SetActive(_screenshotImage.gameObject, isActive: false);
			_screenshotImage.overrideSprite = null;
			_screenshotImage.color = Color.clear;
			_screenshotFlashEffect.color = Color.clear;
		}

		protected void OnDisable()
		{
			_gridZoomButton.Button.onPrimaryDown.RemoveListener(OnGridZoomPressed);
			_screenshotButton.Button.onPrimaryDown.RemoveListener(OnScreenshotPressed);
			_screenshotButtonTooltip.SetDataProvider(null);
			if (_takeScreenshotCoroutine != null)
			{
				StopCoroutine(_takeScreenshotCoroutine);
			}
		}

		public void OnFriendDataReceived()
		{
			Refresh();
		}

		public void OnTimelineUpdate()
		{
			Refresh();
		}

		public void OnSubGoalUpdated(ObjectiveSubGoal subGoal)
		{
			Refresh();
		}

		private void OnGridZoomPressed()
		{
			_isGridZoomed = !_isGridZoomed;
			_gridImage.texture = (_isGridZoomed ? _gridZoomedSprite : _gridSprite);
			RefreshGraph();
		}

		private void OnScreenshotButtonTooltip(Tooltip tooltip)
		{
			int num = _levelObjective.LocalPlayerScreenshotData.NumScreenshotRemaining();
			tooltip.Text = string.Format(ScriptLocalization.Online.ScreenshotTooltip_CS, num);
		}

		public int GetPlayerPosition(OnlinePlayerID onlinePlayerID)
		{
			for (int i = 0; i < _leaderboardList.Count; i++)
			{
				if (_leaderboardList[i].Key == onlinePlayerID)
				{
					return i;
				}
			}
			return -1;
		}

		public void Refresh()
		{
			RefreshLeaderboard();
			RefreshGraph();
			RefreshScreenshotButton();
		}

		private void RefreshLeaderboard()
		{
			_leaderboardList.Clear();
			foreach (KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo> item in _levelObjective.PlayerInfoDictionary)
			{
				ChallengeData data = _levelObjective.GetData(item.Key);
				if (data != null)
				{
					_leaderboardList.Add(new KeyValuePair<OnlinePlayerID, float>(item.Key, data.GetScore(_levelObjective.DaysElapsed)));
				}
				else
				{
					_leaderboardList.Add(new KeyValuePair<OnlinePlayerID, float>(item.Key, 0f));
				}
			}
			_leaderboardList.Sort((KeyValuePair<OnlinePlayerID, float> p1, KeyValuePair<OnlinePlayerID, float> p2) => p2.Value.CompareTo(p1.Value));
			for (int num = 0; num < _leaderboardItems.Count; num++)
			{
				if (num >= _leaderboardList.Count)
				{
					GameObjectUtils.SetActive(_leaderboardItems[num].gameObject, isActive: false);
					continue;
				}
				OnlinePlayerID key = _leaderboardList[num].Key;
				float value = _leaderboardList[num].Value;
				OnlineChallengeObjective.PlayerInfo playerInfo = _levelObjective.GetPlayerInfo(key);
				if (playerInfo == null)
				{
					GameObjectUtils.SetActive(_leaderboardItems[num].gameObject, isActive: false);
					continue;
				}
				_leaderboardItems[num].Setup(playerInfo, value);
				GameObjectUtils.SetActive(_leaderboardItems[num].gameObject, isActive: true);
			}
		}

		private void RefreshGraph()
		{
			float num = _minGraphHeight;
			foreach (KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo> item in _levelObjective.PlayerInfoDictionary)
			{
				ChallengeData data = _levelObjective.GetData(item.Key);
				if (data != null)
				{
					num = Mathf.Max(data.GetScore(_levelObjective.DaysElapsed) + _graphHeightBuffer, num);
				}
			}
			foreach (KeyValuePair<OnlinePlayerID, OnlineChallengeObjective.PlayerInfo> item2 in _levelObjective.PlayerInfoDictionary)
			{
				bool isLocalPlayer = item2.Value.IsLocalPlayer;
				if (!_graphEntries.TryGetValue(item2.Key, out var value))
				{
					continue;
				}
				value.color = _levelObjective.GetPlayerColor(item2.Key);
				value.LineThickness = (isLocalPlayer ? (_graphLineThickness * _playerGraphLineThicknessMultiplier) : _graphLineThickness);
				List<Vector2> list = new List<Vector2>();
				ChallengeData data2 = _levelObjective.GetData(item2.Key);
				if (data2 == null || data2.ScoreCount == 0)
				{
					list.Add(new Vector2(0f, 0f));
					value.Points = list.ToArray();
					value.SetAllDirty();
					continue;
				}
				if (_isGridZoomed)
				{
					int num2 = Mathf.Max(_levelObjective.DaysElapsed - _zoomedDaysLeft, 0);
					int num3 = Mathf.Min(_levelObjective.DaysElapsed + _zoomedDaysRight, _levelObjective.Definition.TimeLength);
					bool flag = false;
					for (int i = 0; i < data2.ScoreCount; i++)
					{
						OnlineChallengeEventScore onlineChallengeEventScore = data2[i];
						if (onlineChallengeEventScore.Day >= num2 && onlineChallengeEventScore.Day <= num3)
						{
							if (!flag)
							{
								flag = true;
								list.Add(new Vector2(-0.5f, Mathf.Clamp01((float)onlineChallengeEventScore.Score / num)));
							}
							if (onlineChallengeEventScore.Day > _levelObjective.DaysElapsed)
							{
								float graphXPos = GetGraphXPos(_levelObjective.DaysElapsed, num2, num3);
								list.Add(new Vector2(graphXPos, Mathf.Clamp01((float)onlineChallengeEventScore.Score / num)));
							}
							else
							{
								float graphXPos2 = GetGraphXPos(onlineChallengeEventScore.Day, num2, num3);
								list.Add(new Vector2(graphXPos2, Mathf.Clamp01((float)onlineChallengeEventScore.Score / num)));
							}
						}
					}
				}
				else
				{
					list.Add(new Vector2(0f, 0f));
					for (int j = 0; j < data2.ScoreCount; j++)
					{
						OnlineChallengeEventScore onlineChallengeEventScore2 = data2[j];
						if (onlineChallengeEventScore2.Day < _levelObjective.DaysElapsed)
						{
							list.Add(new Vector2((float)onlineChallengeEventScore2.Day / (float)_levelObjective.Definition.TimeLength, Mathf.Clamp01((float)onlineChallengeEventScore2.Score / num)));
						}
					}
					float score = data2.GetScore(_levelObjective.DaysElapsed);
					float num4 = ((data2.ScoreCount > 0) ? ((float)data2[data2.ScoreCount - 1].Day) : 0f);
					if ((float)_levelObjective.DaysElapsed < num4)
					{
						list.Add(new Vector2((float)_levelObjective.DaysElapsed / (float)_levelObjective.Definition.TimeLength, Mathf.Clamp01(score / num)));
					}
					else if (isLocalPlayer)
					{
						list.Add(new Vector2((float)_levelObjective.DaysElapsed / (float)_levelObjective.Definition.TimeLength, Mathf.Clamp01(score / num)));
					}
				}
				value.Points = list.ToArray();
				value.SetAllDirty();
			}
		}

		private float GetGraphXPos(int day, int firstDay, int lastDay)
		{
			int num = lastDay - firstDay;
			if (num == 0)
			{
				return 0f;
			}
			return (float)(day - firstDay) / (float)num;
		}

		private void RefreshScreenshotButton()
		{
			if (_levelObjective.LocalPlayerScreenshotData == null)
			{
				_screenshotButton.CurrentState = ButtonAnimator.State.Unselectable;
				GameObjectUtils.SetActive(_screenshotsLeftGameObject, isActive: false);
			}
			else
			{
				_screenshotsLeftLabel.text = _levelObjective.LocalPlayerScreenshotData.NumScreenshotRemaining().ToString();
				GameObjectUtils.SetActive(_screenshotsLeftGameObject, isActive: true);
				_screenshotButton.CurrentState = ((!_levelObjective.LocalPlayerScreenshotData.CanTakeScreenshotToday(_levelObjective.DaysElapsed)) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
		}

		private void OnScreenshotPressed()
		{
			if (_takeScreenshotCoroutine == null)
			{
				_takeScreenshotCoroutine = StartCoroutine(TakeScreenshotCoroutine());
			}
		}

		private IEnumerator TakeScreenshotCoroutine()
		{
			if (_levelObjective.LocalPlayerScreenshotData == null)
			{
				_takeScreenshotCoroutine = null;
				yield break;
			}
			OnlineScreenshotData.Screenshot screenshot = _levelObjective.TakeScreenshot(360, 240, _captionInputField.text.Truncate(64), 75);
			if (screenshot == null)
			{
				_takeScreenshotCoroutine = null;
				yield break;
			}
			Texture2D texture = screenshot.GetTexture();
			if (texture == null)
			{
				_takeScreenshotCoroutine = null;
				yield break;
			}
			RefreshScreenshotButton();
			_screenshotImage.overrideSprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
			_screenshotImage.color = Color.clear;
			_screenshotFlashEffect.color = Color.clear;
			_captionInputField.text = string.Empty;
			GameObjectUtils.SetActive(_screenshotImage.gameObject, isActive: true);
			float elapsedTime = 0f;
			while (elapsedTime < _flashInTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float p = elapsedTime / _flashInTime;
				_screenshotFlashEffect.color = new Color(1f, 1f, 1f, Mathf.Clamp01(EasingsUtils.CubicEaseInOut(p)));
				yield return null;
			}
			_screenshotFlashEffect.color = Color.white;
			_screenshotImage.color = Color.white;
			yield return new WaitForSecondsRealtime(_flashHoldTime);
			elapsedTime = 0f;
			while (elapsedTime < _flashOutTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float num = elapsedTime / _flashOutTime;
				_screenshotFlashEffect.color = new Color(1f, 1f, 1f, Mathf.Clamp01(EasingsUtils.CubicEaseInOut(1f - num)));
				yield return null;
			}
			_screenshotFlashEffect.color = Color.clear;
			yield return new WaitForSecondsRealtime(_pictureHoldTime);
			elapsedTime = 0f;
			while (elapsedTime < _pictureOutTime)
			{
				elapsedTime += Time.unscaledDeltaTime;
				float num2 = elapsedTime / _pictureOutTime;
				_screenshotImage.color = new Color(1f, 1f, 1f, Mathf.Clamp01(EasingsUtils.CubicEaseInOut(1f - num2)));
				yield return null;
			}
			_screenshotImage.color = Color.clear;
			GameObjectUtils.SetActive(_screenshotImage.gameObject, isActive: false);
			_takeScreenshotCoroutine = null;
		}
	}
}
