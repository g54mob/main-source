using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Mirror
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Network/Network Ping Display UI")]
	public class NetworkPingDisplayUI : MonoBehaviour
	{
		private enum PingStage
		{
			Good = 0,
			Warning = 1,
			Critical = 2
		}

		[Header("UI References")]
		public TMP_Text pingText;

		public Image signalIcon;

		[Header("Formatting")]
		public string suffix = "ms";

		[Range(0.05f, 1f)]
		public float updateInterval = 0.2f;

		[Header("Ping Thresholds (ms)")]
		public int goodMaxPingMs = 80;

		public int warningMaxPingMs = 150;

		[Header("Stage Sprites")]
		public Sprite goodSprite;

		public Sprite warningSprite;

		public Sprite criticalSprite;

		[Header("Stage Colors")]
		public Color goodColor = new Color(1f, 0.92f, 0.2f, 1f);

		public Color warningColor = new Color(1f, 0.55f, 0.1f, 1f);

		public Color criticalColor = new Color(1f, 0.2f, 0.2f, 1f);

		private float nextUpdateTime;

		private void Awake()
		{
			if (goodMaxPingMs < 0)
			{
				goodMaxPingMs = 0;
			}
			if (warningMaxPingMs < goodMaxPingMs)
			{
				warningMaxPingMs = goodMaxPingMs;
			}
		}

		private void OnEnable()
		{
			nextUpdateTime = 0f;
			if (IsHost())
			{
				DisableUIAndSelf();
			}
			else
			{
				SetUIObjectsActive(active: false);
			}
		}

		private void Start()
		{
			if (IsHost())
			{
				DisableUIAndSelf();
			}
		}

		private void Update()
		{
			if (!NetworkClient.active)
			{
				SetUIObjectsActive(active: false);
			}
			else if (!(Time.unscaledTime < nextUpdateTime))
			{
				nextUpdateTime = Time.unscaledTime + updateInterval;
				int pingMs = GetPingMs();
				UpdateText(pingMs);
				UpdateIcon(pingMs);
				SetUIObjectsActive(active: true);
			}
		}

		private bool IsHost()
		{
			if (NetworkServer.active)
			{
				return NetworkClient.active;
			}
			return false;
		}

		private void DisableUIAndSelf()
		{
			SetUIObjectsActive(active: false);
			base.enabled = false;
		}

		private void SetUIObjectsActive(bool active)
		{
			if (pingText != null && pingText.gameObject.activeSelf != active)
			{
				pingText.gameObject.SetActive(active);
			}
			if (signalIcon != null && signalIcon.gameObject.activeSelf != active)
			{
				signalIcon.gameObject.SetActive(active);
			}
		}

		private int GetPingMs()
		{
			double num = NetworkTime.rtt * 1000.0;
			if (num < 0.0)
			{
				num = 0.0;
			}
			return (int)Math.Round(num);
		}

		private PingStage GetStage(int pingMs)
		{
			if (pingMs <= goodMaxPingMs)
			{
				return PingStage.Good;
			}
			if (pingMs <= warningMaxPingMs)
			{
				return PingStage.Warning;
			}
			return PingStage.Critical;
		}

		private void UpdateText(int pingMs)
		{
			if (!(pingText == null))
			{
				pingText.text = $"{pingMs}{suffix}";
			}
		}

		private void UpdateIcon(int pingMs)
		{
			if (signalIcon == null)
			{
				return;
			}
			switch (GetStage(pingMs))
			{
			case PingStage.Good:
				if (goodSprite != null)
				{
					signalIcon.sprite = goodSprite;
				}
				signalIcon.color = goodColor;
				break;
			case PingStage.Warning:
				if (warningSprite != null)
				{
					signalIcon.sprite = warningSprite;
				}
				signalIcon.color = warningColor;
				break;
			default:
				if (criticalSprite != null)
				{
					signalIcon.sprite = criticalSprite;
				}
				signalIcon.color = criticalColor;
				break;
			}
		}
	}
}
