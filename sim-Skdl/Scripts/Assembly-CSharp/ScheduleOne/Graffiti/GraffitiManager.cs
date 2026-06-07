using System.Collections.Generic;
using FishNet.Connection;
using ScheduleOne.DevUtilities;
using ScheduleOne.Levelling;
using ScheduleOne.Persistence;
using ScheduleOne.Persistence.Loaders;
using UnityEngine;

namespace ScheduleOne.Graffiti
{
	public class GraffitiManager : NetworkSingleton<GraffitiManager>, IBaseSaveable, ISaveable
	{
		private const string SPRAY_PAINT_STOCK_VARIABLE = "SprayPaintStock";

		private const string SPRAY_PAINTS_PURCHASED_VARIABLE = "SprayPaintsPurchased";

		[SerializeField]
		private AnimationCurve _falloffCurve;

		private Dictionary<byte, float[]> _falloffTableCache;

		private GraffitiLoader loader;

		private bool NetworkInitialize___EarlyScheduleOne_002EGraffiti_002EGraffitiManagerAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EGraffiti_002EGraffitiManagerAssembly_002DCSharp_002Edll_Excuted;

		public List<WorldSpraySurface> WorldSpraySurfaces { get; private set; }

		public string SaveFolderName => null;

		public string SaveFileName => null;

		public Loader Loader => null;

		public bool ShouldSaveUnderFolder => false;

		public List<string> LocalExtraFiles { get; set; }

		public List<string> LocalExtraFolders { get; set; }

		public bool HasChanged { get; set; }

		public int LoadOrder { get; }

		public override void Awake()
		{
		}

		public override void OnStartServer()
		{
		}

		public virtual void InitializeSaveable()
		{
		}

		private void SprayPaintPurchaseCountChanged(float newValue)
		{
		}

		private void RankChange(FullRank oldRank, FullRank newRank)
		{
		}

		private void UpdateSprayPaintStockVariable()
		{
		}

		public virtual string GetSaveString()
		{
			return null;
		}

		public void QueueSurfaceToReplicate(SpraySurface surface, NetworkConnection conn)
		{
		}

		public float GetPixelStrength(byte strokeSize, int pixelIndex)
		{
			return 0f;
		}

		private float[] GetFalloffTable(int strokeSize)
		{
			return null;
		}

		public override void NetworkInitialize___Early()
		{
		}

		public override void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		protected virtual void Awake_UserLogic_ScheduleOne_002EGraffiti_002EGraffitiManager_Assembly_002DCSharp_002Edll()
		{
		}
	}
}
