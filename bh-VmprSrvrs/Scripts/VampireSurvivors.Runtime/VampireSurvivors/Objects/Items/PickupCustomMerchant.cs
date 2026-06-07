using System;
using System.Collections.Generic;
using Coherence.Toolkit;
using UnityEngine;
using VampireSurvivors.App.Data;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Items
{
	public class PickupCustomMerchant : NetworkPickup
	{
		private ParticleEmitterManager _particleEmitterManager;

		private ParticleSystem _pfxEmitter;

		protected CustomMerchantData _customMerchantData;

		private float _shopCooldownTimer;

		private bool _facePlayer;

		private float _shopCooldown;

		public readonly List<CustomActionInventoryItem> CustomActionInventoryItems;

		public CustomMerchantData CustomMerchantData => null;

		public bool SkipValidWeaponCheck { get; private set; }

		protected override bool UsesOrderedCommand => false;

		protected override void Awake()
		{
		}

		private void Update()
		{
		}

		public override void SetData(ItemType itemType)
		{
		}

		public void SetInventoryData(CustomMerchantData customMerchantData)
		{
		}

		[Command]
		public void SendMerchantData(byte[] serializedMerchantData)
		{
		}

		public void SetFacePlayerEnabled(bool isEnabled)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void UpdateDepth()
		{
		}

		public void UpdateShopCooldown(float newCooldown)
		{
		}

		public override void GetTaken()
		{
		}

		public override void GetOnlineTaken()
		{
		}

		public virtual bool IsMerchantSoldOut()
		{
			return false;
		}

		public void ForceGetTaken()
		{
		}

		protected virtual MerchantInventoryType GetInventoryType()
		{
			return default(MerchantInventoryType);
		}

		private void SetCharacterFrame()
		{
		}

		private void SetBodyOffset()
		{
		}

		private void GenerateParticleSystem()
		{
		}

		private void AddEffects()
		{
		}

		private void SpawnCursor()
		{
		}

		private void RemoveCursor()
		{
		}

		protected override void ToggleCursors(UISignals.ToggleGuidesSignal sig)
		{
		}

		private Sprite GetCustomMerchantCursorSprite()
		{
			return null;
		}

		private void LoadCharacterTextureAsync(string textureName, Action<bool> onTextureLoaded)
		{
		}
	}
}
