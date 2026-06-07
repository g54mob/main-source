using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC
{
	public class DlcLoader
	{
		private static Action<BundleManifestData> _onComplete;

		private static DlcType? _dlcType;

		private static int _initialProgress;

		private static int _totalLocations;

		private static int _completedLocations;

		private static List<Sprite> _sprites;

		private static BundleManifestData _manifest;

		private static DlcLoadState _spritesState;

		private static DlcLoadState _locationsState;

		private static DlcLoadState _manifestState;

		private static DlcType DlcType => default(DlcType);

		public static void ResetLoader()
		{
		}

		public static void LoadDlc(DlcType dlcType, Action<BundleManifestData> onComplete)
		{
		}

		private static void LoadDlcComplete()
		{
		}

		private static void UpdateProgress()
		{
		}

		private static bool IsTaskDone(DlcLoadState task)
		{
			return false;
		}

		private static bool DidTaskError(DlcLoadState task)
		{
			return false;
		}

		private static void LoadManifest(Action<BundleManifestData> onComplete)
		{
		}

		public static void LoadBundleManifestData(DlcType dlcType, Action<BundleManifestData> onComplete)
		{
		}

		private static void LoadSpriteLocations(Action onComplete)
		{
		}

		private static void IncrementAndCheckIfAllSpritesAreLoaded(Action onComplete)
		{
		}

		private static void LoadSprites(IList<IResourceLocation> locations, Action onComplete)
		{
		}

		private static void WaitForAsyncLoad<T>(AsyncOperationHandle<T> operationHandle, Action<T> onComplete, Action<T> onError, string errorPrefix = "WaitForAsyncLoad")
		{
		}
	}
}
