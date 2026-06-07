using FuryStudios.FurySDK;
using FuryStudios.FurySDK.Settings;
using Placemaker.Ui;
using Rewired;
using UnityEngine;

namespace Placemaker
{
	public class BootGameCore : MonoBehaviour
	{
		public enum State
		{
			None = 0,
			WaitingForSignIn = 1,
			SignedIn = 2,
			SignedOut = 3
		}

		[SerializeField]
		private PlatformSettings settings;

		private bool _userPrompted;

		private bool _signInFailedOnce;

		private Player _selectedPlayer;

		private IAsyncRequest _signInReq;

		private static bool firstSignIn;

		public BootMaster bootMaster;

		public UpdateState promptState;

		public CanvasGroup promptCanvasGroup;

		public State state;

		public void StartNewSignIn()
		{
		}

		private void Update()
		{
		}

		private void BootGameCore_OnComplete()
		{
		}

		private void OnEnable()
		{
		}
	}
}
