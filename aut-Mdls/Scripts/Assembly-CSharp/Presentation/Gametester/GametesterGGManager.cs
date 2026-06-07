#define ENABLE_DEBUG_LOGS
using Data.FeatureFlags.Validators;
using UnityEngine;
using Utils;

namespace Presentation.Gametester
{
	public class GametesterGGManager : MonoBehaviour
	{
		[SerializeField]
		private FeatureFlagValidator _useGameTesterValidator;

		[SerializeField]
		[Header("Data")]
		private string _developerToken;

		[SerializeField]
		private GametesterGGWindow _gametesterGGWindow;

		public static bool UseGametesterAPI { get; private set; }

		public static bool IsUnlocked { get; private set; }

		public static GametesterGGManager Instance { get; private set; }

		private void Awake()
		{
			if (_useGameTesterValidator.IsEnabledFeatureFlag())
			{
				InitializeGameTester();
			}
			Instance = this;
			base.enabled = false;
		}

		public void Submit(string userPin)
		{
			InitializeGameTester();
			string text = userPin ?? string.Empty;
			if (text.Length > 0)
			{
				GameTester.SetPlayerPin(text);
			}
			StartCoroutine(GameTester.Api.Auth(delegate(GameTesterAuthResponse o)
			{
				if (o.Code == GameTesterResponseCode.Success)
				{
					_gametesterGGWindow.Hide();
					UseGametesterAPI = true;
					base.enabled = true;
				}
				else
				{
					_gametesterGGWindow.ShowErrorResult(o.Code.ToString());
				}
			}));
		}

		private void InitializeGameTester()
		{
			GameTester.Initialize(GameTesterMode.Production, _developerToken, debugLogging: true);
		}

		public static void CallDataPoint(int datapointId)
		{
			Instance.StartCoroutine(GameTester.Api.Datapoint(datapointId, delegate(GameTesterResponse o)
			{
				GameTesterCallback(o);
			}));
		}

		public static void UnlockTest()
		{
			Instance.StartCoroutine(GameTester.Api.UnlockTest(delegate(GameTesterResponse o)
			{
				if (o.Code == GameTesterResponseCode.Success || (o.Message != null && o.Message.Contains("already unlocked")))
				{
					IsUnlocked = true;
				}
				GameTesterCallback(o);
			}));
		}

		private static void GameTesterCallback(GameTesterResponse response)
		{
			typeof(GametesterGGManager).Log(response.ToString(), "GameTesterCallback", 71);
		}
	}
}
