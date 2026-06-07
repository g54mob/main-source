using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Microsoft.Xbox
{
	public class Gdk : MonoBehaviour
	{
		public delegate void OnGameSaveLoadedHandler(object sender, GameSaveLoadedArgs e);

		public delegate void OnErrorHandler(object sender, ErrorEventArgs e);

		[Header("Changing the SCID here will also change the value in your MicrosoftGame.config")]
		[Tooltip("Service Configuration GUID in the form: 12345678-1234-1234-1234-123456789abc")]
		[Delayed]
		public string scid;

		[Tooltip("Will automatically sign the user in after XGameRuntime initialization if checked")]
		public bool signInOnStart;

		public Text gamertagLabel;

		private static Gdk _xboxHelpers;

		private static bool _initialized;

		private static Dictionary<int, string> _hresultToFriendlyErrorLookup;

		private string _lastScid;

		private const int _100PercentAchievementProgress = 100;

		private const string _GameSaveContainerName = "x_game_save_default_container";

		private const string _GameSaveBlobName = "x_game_save_default_blob";

		private const int _MaxAssociatedProductsToRetrieve = 25;

		public static Gdk Helpers => null;

		public event OnGameSaveLoadedHandler OnGameSaveLoaded
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

		public event OnErrorHandler OnError
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

		private bool ValidateGuid(string guid)
		{
			return false;
		}

		private void Start()
		{
		}

		private void _Initialize()
		{
		}

		private void InitializeHresultToFriendlyErrorLookup()
		{
		}

		public void SignIn()
		{
		}

		public void Save(byte[] data)
		{
		}

		public void LoadSaveData()
		{
		}

		public void UnlockAchievement(string achievementId)
		{
		}

		private void Update()
		{
		}

		protected static bool Succeeded(int hresult, string operationFriendlyName)
		{
			return false;
		}
	}
}
