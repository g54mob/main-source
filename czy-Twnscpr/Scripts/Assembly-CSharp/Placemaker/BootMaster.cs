using System.Collections.Generic;
using Placemaker.Ui;
using UnityEngine;

namespace Placemaker
{
	public class BootMaster : MonoBehaviour
	{
		public static BootMaster instance;

		public Dim dim;

		public LoadingUi loadingUi;

		public AudioListener audioListener;

		public WorldMaster worldMaster;

		public UiMaster uiMaster;

		public PlatformManager platformManager;

		public BootGameCore bootGameCore;

		private const string mainSceneName = "Placemaker";

		private const string flatscreenUiSceneName = "FlatscreenUi";

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private IEnumerator<bool> FirstBootWrapper()
		{
			return null;
		}

		private IEnumerator<bool> GameBootRoutine()
		{
			return null;
		}

		private IEnumerator<bool> UserBootRoutine()
		{
			return null;
		}

		public void OnSignedOut()
		{
		}

		private IEnumerator<bool> SignedOutBootWrapper()
		{
			return null;
		}

		public static void DoFullscreen()
		{
		}

		private void OnEnable()
		{
		}
	}
}
