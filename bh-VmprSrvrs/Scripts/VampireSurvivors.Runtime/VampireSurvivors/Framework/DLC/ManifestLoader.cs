using System;
using JetBrains.Annotations;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;
using VampireSurvivors.Graphics;
using Zenject;

namespace VampireSurvivors.Framework.DLC
{
	[UsedImplicitly]
	public class ManifestLoader : IInitializable, IDisposable
	{
		[Inject]
		private DataManager _dataManager;

		[Inject]
		private SpriteManager _spriteManager;

		[Inject]
		private AdventureManager _adventureManager;

		private static ManifestLoader _sInstance;

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public static AssetBundle LoadAssetBundleFromPath(string bundlePath)
		{
			return null;
		}

		public static void LoadManifest(BundleManifestData bundleManifestData, DlcType dlcType, Action<BundleManifestData> onComplete)
		{
		}

		private static void ApplyBundleCore(DlcType dlcType, BundleManifestData manifest, Action<BundleManifestData> onComplete)
		{
		}

		public static void DoRuntimeReload()
		{
		}
	}
}
