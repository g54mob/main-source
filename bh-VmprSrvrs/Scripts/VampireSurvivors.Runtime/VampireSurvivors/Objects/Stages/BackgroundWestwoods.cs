using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundWestwoods : BackgroundManager
	{
		private WestwoodsBounds _westwoodsBounds;

		private WestwoodsBounds.WestwoodsZone _currentUnlockedZone;

		private WestwoodsTrisectionManager _westwoodsTrisection;

		private WestwoodsWaterHue _westwoodsWaterHue;

		private PickupCustomMerchant _giacoreMerchant;

		private bool _giacoreRunning;

		private Vector3 _giacoreStartPosition;

		private Vector3 _giacoreTargetPosition;

		private float _giacoreRunTimer;

		private const float GiacoreRunDuration = 5f;

		private const string Zone1BarrierLayer = "Shadows";

		private const string Zone2BarrierLayer = "ShadowDecals";

		private float _barrier1Alpha;

		private float _barrier2Alpha;

		private bool _barrierFadeActive;

		private float _barrierFadeTimer;

		private Tilemap _barrier1Tilemap;

		private Tilemap _barrier2Tilemap;

		private const float BarrierFadeDuration = 0.5f;

		private const float Zone2MerchantXOffset = 14.3488f;

		private const float Zone3MerchantXOffset = 10.1f;

		private const string BACKGROUND_WESTWOODS = "background_westwoods_grayscale";

		private PhaserSprite _waterAnim;

		private TileSprite _water;

		private CustomActionInventoryItem _secretinoShopItem;

		public override bool HasCustomMadGrooveRestriction()
		{
			return false;
		}

		public override bool IsPositionPulledByMadGroove(float2 position)
		{
			return false;
		}

		public override void CustomPreload(Action onComplete)
		{
		}

		public override void Create()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnWestwoodsSpin(OnlineSignals.WestwoodsSpin spin)
		{
		}

		protected override void OnUpdate()
		{
		}

		public void TriggerMinigameTrisection()
		{
		}

		private void OnMinigameSuccess()
		{
		}

		private bool InitBounds(GameObject support)
		{
			return false;
		}

		private void InitWestwoodsTrisection()
		{
		}

		private bool InitWater(GameObject support)
		{
			return false;
		}

		private void SpawnGiocareMerchant(WestwoodsBounds.WestwoodsZone currentUnlockedZone)
		{
		}

		private void ConfigureGiocoreMerchant()
		{
		}

		private void RemoveSecretinoItem()
		{
		}

		private void UnlockNextZone(bool saveProgress)
		{
		}

		private Tilemap GetTilemap(string layerName)
		{
			return null;
		}

		private void SetTilemapAlpha(Tilemap tilemap, float alphaValue)
		{
		}

		public void DebugUnlockNextZone()
		{
		}
	}
}
