using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Pun.UtilityScripts
{
	public class CountdownTimer : MonoBehaviourPunCallbacks
	{
		public delegate void CountdownTimerHasExpired();

		public const string CountdownStartTime = "StartTime";

		[Header("Countdown time in seconds")]
		public float Countdown;

		private bool isTimerRunning;

		private int startTime;

		[Header("Reference to a Text component for visualizing the countdown")]
		public Text Text;

		public static event CountdownTimerHasExpired OnCountdownTimerHasExpired
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Start()
		{
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		public void Update()
		{
		}

		private void OnTimerRuns()
		{
		}

		private void OnTimerEnds()
		{
		}

		public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
		{
		}

		private void Initialize()
		{
		}

		private float TimeRemaining()
		{
			return 0f;
		}

		public static bool TryGetStartTime(out int startTimestamp)
		{
			startTimestamp = default(int);
			return false;
		}

		public static void SetStartTime()
		{
		}
	}
}
