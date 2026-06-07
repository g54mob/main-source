using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class FateSpinner3DUIView : MonoBehaviour
	{
		private static readonly int SpinGreen;

		private static readonly int SpinRed;

		[SerializeField]
		private Animator _fateStateAnimator;

		private static readonly int Success;

		private static readonly int Failure;

		private static readonly int ChaosSuccess;

		private static readonly int SuccessAccept;

		[SerializeField]
		private Animator _fateSpinnerAnimator;

		private static readonly int RerollResult;

		private static readonly int AcceptResult;

		private static readonly int SpinResult;

		private static readonly int StopSpinTrigger;

		private static readonly int Chaosmeter;

		private static readonly int Chaosroll;

		private static readonly int Succeed;

		private static readonly int FasterIntro;

		[SerializeField]
		private Animator _chaosMeterAnimator;

		private static readonly int Fill1Slot;

		private static readonly int Fill2Slots;

		private static readonly int Fill3Slots;

		[SerializeField]
		private GameObject _fateSpinnerContainer;

		[SerializeField]
		private GameObject _resultParent;

		[SerializeField]
		private BaseInteractable3DUIView _stopFateSpinnerButton;

		[SerializeField]
		private BaseInteractable3DUIView _continueButton;

		[SerializeField]
		private Button3DUIView _rerollButton;

		[SerializeField]
		private GameObject[] _runePips;

		private Animator[] _runeAnimators;

		private List<Animator> _runeShuffledMap;

		private const string SPIN_STATE_INTRO = "intro";

		private const string SPIN_STATE_SPINNING = "spinning";

		private const string SPIN_STATE_WAITING_FOR_ACCEPT = "waiting_for_accept";

		private string _spinnerState;

		private int _rollResultRune;

		private bool _isSuccessSpin;

		private int _greenPips;

		private int _timesRolled;

		private float _introSpinTime;

		private float _rerollSpinTime;

		public bool debugMode;

		public int debugResult;

		private bool _closeOnOutro;

		private UINotificationData _uiData;

		private UIFatePageData _pageData;

		public const string FateSpinnerChaosMeterLevel = "FateSpinnerChaosMeterLevel";

		private const int MAX_CHAOS_METER = 12;

		private int _chaosMeterValue;

		private float _spinTimeRemaining;

		public string Skill { get; set; }

		public string Difficulty { get; set; }

		public int Seed { get; set; }

		public event EventHandler<EventArgs<bool>> SpinComplete
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

		private void Awake()
		{
		}

		private void OnFateSpinnerAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		public void SetData(UINotificationData uiData, UIFatePageData pageData)
		{
		}

		public static int GetChaosLevel(UINotificationData data)
		{
			return 0;
		}

		private void FateSpinnerStopClicked()
		{
		}

		public bool IsSpinnerActive()
		{
			return false;
		}

		public void Open(bool isFirstSpin)
		{
		}

		public void Close()
		{
		}

		private void ResetSpinner()
		{
		}

		public void ResetChaosMeter()
		{
		}

		private void ResetSpin()
		{
		}

		public void StartSpin(float spinTime)
		{
		}

		public void StopSpin()
		{
		}

		private void AcceptButtonClicked()
		{
		}

		private void SetMeterValue(int value)
		{
		}

		private void ReRollButtonClicked()
		{
		}

		public void PlayChaosMeterOutro(UINotificationData uiData)
		{
		}

		private void Update()
		{
		}

		private void UpdateSpinTime()
		{
		}

		private void ShowSuccessFailState()
		{
		}

		private void HideSuccessFailState()
		{
		}
	}
}
