using System;
using System.Collections;
using System.Collections.Generic;
using TH20.EventAwardSilver;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[DontSave]
	public class RewardNotificationMenu : MonoBehaviour, Interface, IGameEventCallback
	{
		private enum NotificationType
		{
			Money = 0,
			Silver = 1,
			Reputation = 2
		}

		[SerializeField]
		private Image _rewardNotificationImage;

		[SerializeField]
		private TMP_Text _rewardNotificationTitle;

		[SerializeField]
		private TMP_Text _rewardNotificationText;

		[SerializeField]
		private GameObject _rewardNotificationPanel;

		private bool _animating;

		private Level _level;

		private const string RewardMoneyAudioName = "Reward:Money";

		private const string RewardSilverAudioName = "Reward:Silver";

		private const string RewardReputationAudioName = "Reward:Animation";

		private readonly Queue<KeyValuePair<NotificationType, int>> _notificationsQueue = new Queue<KeyValuePair<NotificationType, int>>();

		public void Setup(Level level)
		{
			_level = level;
		}

		private void OnEnable()
		{
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnMoneyAwarded = (Action<int>)Delegate.Combine(financeManager.OnMoneyAwarded, new Action<int>(OnMoneyAwarded));
			_level.Metagame.OnSilverAwarded.Add(this);
			ReputationTracker reputationTracker = _level.ReputationTracker;
			reputationTracker.OnReputationAwarded = (Action<float>)Delegate.Combine(reputationTracker.OnReputationAwarded, new Action<float>(OnReputationAwarded));
		}

		private void OnDisable()
		{
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnMoneyAwarded = (Action<int>)Delegate.Remove(financeManager.OnMoneyAwarded, new Action<int>(OnMoneyAwarded));
			_level.Metagame.OnSilverAwarded.Remove(this);
			ReputationTracker reputationTracker = _level.ReputationTracker;
			reputationTracker.OnReputationAwarded = (Action<float>)Delegate.Remove(reputationTracker.OnReputationAwarded, new Action<float>(OnReputationAwarded));
		}

		private void Update()
		{
			if (_notificationsQueue.Count > 0 && !_animating)
			{
				KeyValuePair<NotificationType, int> keyValuePair = _notificationsQueue.Dequeue();
				switch (keyValuePair.Key)
				{
				case NotificationType.Money:
					_rewardNotificationImage.color = new Color(0.21f, 0.95f, 0.4f);
					_rewardNotificationTitle.text = "REWARD";
					_rewardNotificationText.text = StringUtils.FormatCurrency(keyValuePair.Value);
					AudioManager.Instance.Play("Reward:Money");
					break;
				case NotificationType.Silver:
					_rewardNotificationImage.color = new Color(0.73f, 0.73f, 0.73f);
					_rewardNotificationTitle.text = "REWARD";
					_rewardNotificationText.text = StringUtils.FormatSilverCurrency(keyValuePair.Value);
					AudioManager.Instance.Play("Reward:Silver");
					break;
				case NotificationType.Reputation:
					_rewardNotificationImage.color = new Color(0.9f, 1f, 0.5f);
					_rewardNotificationTitle.text = "REWARD";
					_rewardNotificationText.text = ((keyValuePair.Value > 0) ? ("Rep +" + keyValuePair.Value) : ("Rep " + keyValuePair.Value));
					AudioManager.Instance.Play("Reward:Animation");
					break;
				}
				StartCoroutine(ShowReward());
			}
		}

		private void OnMoneyAwarded(int amount)
		{
			if (amount != 0)
			{
				_notificationsQueue.Enqueue(new KeyValuePair<NotificationType, int>(NotificationType.Money, amount));
			}
		}

		public void OnSilverAwardedEvent(int amount)
		{
			if (amount != 0)
			{
				_notificationsQueue.Enqueue(new KeyValuePair<NotificationType, int>(NotificationType.Silver, amount));
			}
		}

		private void OnReputationAwarded(float amount)
		{
			_notificationsQueue.Enqueue(new KeyValuePair<NotificationType, int>(NotificationType.Reputation, (int)amount));
		}

		private IEnumerator ShowReward()
		{
			_animating = true;
			_rewardNotificationPanel.SetActive(value: true);
			for (float c = 0f; c <= 5f; c += 0.02f)
			{
				float y = (Mathf.Clamp01(Mathf.PingPong(c, 2.5f)) - 1f) * 40f;
				_rewardNotificationPanel.transform.localPosition = new Vector3(0f, y, 0f);
				yield return null;
			}
			_rewardNotificationPanel.SetActive(value: false);
			_animating = false;
		}
	}
}
