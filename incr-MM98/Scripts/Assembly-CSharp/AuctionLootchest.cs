using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using MessagePipe;
using R3;
using UnityEngine;

public class AuctionLootchest : MonoBehaviour
{
	[Serializable]
	private struct QualityConfig
	{
		public float LidOpenAngle;

		public float LidOpenDurationSeconds;

		public Ease LidOpenEase;

		public float LidOvershootAngle;

		public float LidOvershootDurationSeconds;

		public Ease LidOvershootEase;

		public float ItemRiseHeight;

		public float ItemRiseDurationSeconds;

		public Ease ItemRiseEase;

		public float ItemPopScale;

		public float ItemPopDurationSeconds;

		public Ease ItemPopEase;

		public float LightPeakIntensity;

		public float LightRampDurationSeconds;

		public Ease LightRampEase;

		public int LightPulseCount;

		public float LightPulseAmplitude;

		public float LightPulseDurationSeconds;

		public float ItemFloatAmplitude;

		public float ItemFloatPeriodSeconds;

		public float ItemFloatRotationDegrees;

		public AudioDataType sfx;
	}

	[Serializable]
	private struct SalvageConfig
	{
		public float ItemShakeDurationSeconds;

		public float ItemShakeStrength;

		public int ItemShakeVibrato;

		public float ItemSpinDegrees;

		public float ItemDropDistance;

		public float ItemDisappearDurationSeconds;

		public Ease ItemDisappearEase;

		public ParticleSystem SalvageParticles;

		public float LidCloseDurationSeconds;

		public Ease LidCloseEase;

		public float LightFadeDurationSeconds;

		public Ease LightFadeEase;

		public AudioDataType sfx;
	}

	[Serializable]
	private struct SellConfig
	{
		public float ItemFlashDurationSeconds;

		public Color ItemSellTint;

		public float ItemFlyUpDistance;

		public float ItemFlyDurationSeconds;

		public Ease ItemFlyEase;

		public float ItemDisappearDurationSeconds;

		public Ease ItemDisappearEase;

		public ParticleSystem SellParticles;

		public float LidCloseDurationSeconds;

		public Ease LidCloseEase;

		public float LightFadeDurationSeconds;

		public Ease LightFadeEase;

		public AudioDataType sfx;
	}

	private enum ChestState
	{
		Closed = 0,
		Opening = 1,
		OpenPresented = 2,
		Salvaging = 3,
		Selling = 4,
		Resetting = 5
	}

	[SerializeField]
	private QualityConfig commonConfig;

	[SerializeField]
	private QualityConfig uncommonConfig;

	[SerializeField]
	private QualityConfig rareConfig;

	[SerializeField]
	private QualityConfig legendaryConfig;

	[SerializeField]
	private SalvageConfig salvageConfig;

	[SerializeField]
	private SellConfig sellConfig;

	[SerializeField]
	private Transform topTransform;

	[SerializeField]
	private Transform lockTransform;

	[SerializeField]
	private Transform goldTransform;

	[SerializeField]
	private Light revealLight;

	[SerializeField]
	private SpriteRenderer itemSprite;

	private ChestState _state;

	private Quaternion _topClosedLocalRotation;

	private Vector3 _itemClosedLocalPosition;

	private Vector3 _itemOpenBaseLocalPosition;

	private Color _itemBaseColor;

	private float _lightBaseIntensity;

	private Color _lightBaseColor;

	private MotionHandle _itemIdleMotionPosition;

	private MotionHandle _itemIdleMotionRotation;

	private CancellationTokenSource _sequenceCts;

	private LootItemQuality _quality;

	private QualityConfig _config;

	private void Awake()
	{
		_topClosedLocalRotation = topTransform.localRotation;
		_itemClosedLocalPosition = itemSprite.transform.localPosition;
		_itemOpenBaseLocalPosition = _itemClosedLocalPosition;
		_itemBaseColor = itemSprite.color;
		_lightBaseIntensity = ((revealLight != null) ? revealLight.intensity : 0f);
		_lightBaseColor = ((revealLight != null) ? revealLight.color : Color.white);
		_state = ChestState.Closed;
		ApplyClosedVisuals();
	}

	private void Start()
	{
		EventHub.Scene.For(2).Subscribe(StartSalvageAnimation, Array.Empty<MessageHandlerFilter<SalvagedLootItem>>()).Subscribe(StartSellAnimation, Array.Empty<MessageHandlerFilter<SoldLootItem>>())
			.Build(this);
		(from x in Database.State.Auction.CurrentLootItem
			where x.HasValue
			select x.Value).Subscribe(StartRevealAnimation).AddTo(this);
	}

	private void OnDisable()
	{
		CancelCurrentSequence();
		StopItemIdle();
	}

	private void StartRevealAnimation(LootItem lootItem)
	{
		RevealSequenceAsync(lootItem, this.GetCancellationTokenOnDestroy()).ForgetSafe();
	}

	private void StartSalvageAnimation(SalvagedLootItem _)
	{
		SalvageSequenceAsync(this.GetCancellationTokenOnDestroy()).ForgetSafe();
	}

	private void StartSellAnimation(SoldLootItem _)
	{
		SellSequenceAsync(this.GetCancellationTokenOnDestroy()).ForgetSafe();
	}

	private async UniTask RevealSequenceAsync(LootItem lootItem, CancellationToken destroyToken)
	{
		if ((bool)lootItem.Sprite)
		{
			CancelCurrentSequence();
			_sequenceCts = CancellationTokenSource.CreateLinkedTokenSource(destroyToken);
			CancellationToken token = _sequenceCts.Token;
			_state = ChestState.Opening;
			_quality = lootItem.Quality;
			_config = GetQualityConfig(lootItem.Quality);
			StopItemIdle();
			Audio.PlaySfx(_config.sfx);
			itemSprite.sprite = lootItem.Sprite;
			itemSprite.enabled = false;
			itemSprite.transform.localPosition = _itemClosedLocalPosition;
			itemSprite.transform.localScale = Vector3.one;
			itemSprite.color = _itemBaseColor;
			revealLight.intensity = _lightBaseIntensity;
			revealLight.color = _lightBaseColor;
			revealLight.enabled = true;
			UniTask lightTasks = PlayRevealLightAsync(token);
			await PlayLidOpenAsync(token);
			itemSprite.enabled = true;
			UniTask uniTask = PlayItemPopAsync(token);
			UniTask uniTask2 = PlayItemRiseAsync(token);
			await UniTask.WhenAll(uniTask, uniTask2, lightTasks);
			_state = ChestState.OpenPresented;
			StartItemIdle();
		}
	}

	private async UniTask SalvageSequenceAsync(CancellationToken destroyToken)
	{
		if (_state == ChestState.Opening)
		{
			SkipRevealToOpenPresented();
		}
		CancelCurrentSequence();
		_sequenceCts = CancellationTokenSource.CreateLinkedTokenSource(destroyToken);
		CancellationToken token = _sequenceCts.Token;
		_state = ChestState.Salvaging;
		StopItemIdle();
		Audio.PlaySfx(salvageConfig.sfx);
		if ((bool)salvageConfig.SalvageParticles)
		{
			salvageConfig.SalvageParticles.Play(withChildren: true);
		}
		await ShakeItemAsync(salvageConfig.ItemShakeDurationSeconds, salvageConfig.ItemShakeStrength, salvageConfig.ItemShakeVibrato, token);
		float duration = Mathf.Max(0.01f, salvageConfig.ItemDisappearDurationSeconds);
		UniTask uniTask = LMotion.Create(itemSprite.transform.localPosition, itemSprite.transform.localPosition + new Vector3(0f, 0f - Mathf.Abs(salvageConfig.ItemDropDistance), 0f), duration).WithEase(salvageConfig.ItemDisappearEase).BindToLocalPosition(itemSprite.transform)
			.ToUniTask(token);
		UniTask uniTask2 = LMotion.Create(itemSprite.transform.localRotation, itemSprite.transform.localRotation * Quaternion.Euler(0f, 0f, salvageConfig.ItemSpinDegrees), duration).WithEase(salvageConfig.ItemDisappearEase).BindToLocalRotation(itemSprite.transform)
			.ToUniTask(token);
		UniTask uniTask3 = LMotion.Create(1f, 0f, duration).WithEase(salvageConfig.ItemDisappearEase).Bind(delegate(float x)
		{
			Color color = itemSprite.color;
			color.a = x;
			itemSprite.color = color;
		})
			.ToUniTask(token);
		UniTask uniTask4 = FadeLightToBaseAsync(salvageConfig.LightFadeDurationSeconds, salvageConfig.LightFadeEase, token);
		await UniTask.WhenAll(uniTask, uniTask2, uniTask3, uniTask4);
		itemSprite.enabled = false;
		_state = ChestState.Resetting;
		await CloseLidAsync(salvageConfig.LidCloseDurationSeconds, salvageConfig.LidCloseEase, token);
		ApplyClosedVisuals();
		_state = ChestState.Closed;
	}

	private async UniTask SellSequenceAsync(CancellationToken destroyToken)
	{
		if (_state == ChestState.Opening)
		{
			SkipRevealToOpenPresented();
		}
		CancelCurrentSequence();
		_sequenceCts = CancellationTokenSource.CreateLinkedTokenSource(destroyToken);
		CancellationToken token = _sequenceCts.Token;
		_state = ChestState.Selling;
		StopItemIdle();
		Audio.PlaySfx(sellConfig.sfx);
		if ((bool)sellConfig.SellParticles)
		{
			sellConfig.SellParticles.Play(withChildren: true);
		}
		await FlashItemTintAsync(sellConfig.ItemSellTint, sellConfig.ItemFlashDurationSeconds, token);
		UniTask uniTask = LMotion.Create(itemSprite.transform.localPosition, itemSprite.transform.localPosition + new Vector3(0f, Mathf.Abs(sellConfig.ItemFlyUpDistance), 0f), Mathf.Max(0.01f, sellConfig.ItemFlyDurationSeconds)).WithEase(sellConfig.ItemFlyEase).BindToLocalPosition(itemSprite.transform)
			.ToUniTask(token);
		UniTask uniTask2 = LMotion.Create(1f, 0f, Mathf.Max(0.01f, sellConfig.ItemDisappearDurationSeconds)).WithEase(sellConfig.ItemDisappearEase).Bind(delegate(float x)
		{
			Color color = itemSprite.color;
			color.a = x;
			itemSprite.color = color;
		})
			.ToUniTask(token);
		UniTask uniTask3 = FadeLightToBaseAsync(sellConfig.LightFadeDurationSeconds, sellConfig.LightFadeEase, token);
		await UniTask.WhenAll(uniTask, uniTask2, uniTask3);
		itemSprite.enabled = false;
		_state = ChestState.Resetting;
		await CloseLidAsync(sellConfig.LidCloseDurationSeconds, sellConfig.LidCloseEase, token);
		ApplyClosedVisuals();
		_state = ChestState.Closed;
	}

	private void SkipRevealToOpenPresented()
	{
		CancelCurrentSequence();
		StopItemIdle();
		topTransform.localRotation = _topClosedLocalRotation * Quaternion.Euler(0f - _config.LidOpenAngle, 0f, 0f);
		itemSprite.enabled = true;
		itemSprite.transform.localScale = Vector3.one;
		itemSprite.transform.localPosition = _itemClosedLocalPosition + new Vector3(0f, _config.ItemRiseHeight, 0f);
		Color color = itemSprite.color;
		color.a = 1f;
		itemSprite.color = color;
		revealLight.enabled = true;
		revealLight.color = _quality.Value();
		revealLight.intensity = Mathf.Max(_lightBaseIntensity, _config.LightPeakIntensity);
		_state = ChestState.OpenPresented;
	}

	private async UniTask PlayLidOpenAsync(CancellationToken token)
	{
		Quaternion openRot = _topClosedLocalRotation * Quaternion.Euler(0f - _config.LidOpenAngle, 0f, 0f);
		Quaternion overshootRot = _topClosedLocalRotation * Quaternion.Euler(0f - (_config.LidOpenAngle + _config.LidOvershootAngle), 0f, 0f);
		await LMotion.Create(_topClosedLocalRotation, openRot, Mathf.Max(0.01f, _config.LidOpenDurationSeconds)).WithEase(_config.LidOpenEase).BindToLocalRotation(topTransform)
			.ToUniTask(token);
		if (Mathf.Abs(_config.LidOvershootAngle) > 0.001f && _config.LidOvershootDurationSeconds > 0.001f)
		{
			await LMotion.Create(openRot, overshootRot, _config.LidOvershootDurationSeconds * 0.5f).WithEase(_config.LidOvershootEase).BindToLocalRotation(topTransform)
				.ToUniTask(token);
			await LMotion.Create(overshootRot, openRot, _config.LidOvershootDurationSeconds * 0.5f).WithEase(_config.LidOvershootEase).BindToLocalRotation(topTransform)
				.ToUniTask(token);
		}
	}

	private async UniTask CloseLidAsync(float durationSeconds, Ease ease, CancellationToken token)
	{
		await LMotion.Create(topTransform.localRotation, _topClosedLocalRotation, Mathf.Max(0.01f, durationSeconds)).WithEase(ease).BindToLocalRotation(topTransform)
			.ToUniTask(token);
	}

	private async UniTask PlayItemRiseAsync(CancellationToken token)
	{
		_itemOpenBaseLocalPosition = _itemClosedLocalPosition + new Vector3(0f, _config.ItemRiseHeight, 0f);
		await LMotion.Create(_itemClosedLocalPosition, _itemOpenBaseLocalPosition, Mathf.Max(0.01f, _config.ItemRiseDurationSeconds)).WithEase(_config.ItemRiseEase).BindToLocalPosition(itemSprite.transform)
			.ToUniTask(token);
	}

	private async UniTask PlayItemPopAsync(CancellationToken token)
	{
		float popScale = Mathf.Max(1f, _config.ItemPopScale);
		itemSprite.transform.localScale = Vector3.one;
		await LMotion.Create(0f, 1f, Mathf.Max(0.01f, _config.ItemPopDurationSeconds)).WithEase(_config.ItemPopEase).Bind(delegate(float t)
		{
			float num = ((t < 0.7f) ? Mathf.LerpUnclamped(0f, popScale, t / 0.7f) : Mathf.LerpUnclamped(popScale, 1f, (t - 0.7f) / 0.3f));
			itemSprite.transform.localScale = new Vector3(num, num, 1f);
		})
			.ToUniTask(token);
	}

	private async UniTask PlayRevealLightAsync(CancellationToken token)
	{
		revealLight.color = _quality.Value();
		await LMotion.Create(_lightBaseIntensity, _config.LightPeakIntensity, Mathf.Max(0.01f, _config.LightRampDurationSeconds)).WithEase(_config.LightRampEase).Bind(delegate(float x)
		{
			revealLight.intensity = x;
		})
			.ToUniTask(token);
		int pulseCount = Mathf.Max(0, _config.LightPulseCount);
		if (pulseCount <= 0 || _config.LightPulseDurationSeconds <= 0.001f || _config.LightPulseAmplitude <= 0.001f)
		{
			return;
		}
		for (int i = 0; i < pulseCount; i++)
		{
			await LMotion.Create(_config.LightPeakIntensity, _config.LightPeakIntensity + _config.LightPulseAmplitude, _config.LightPulseDurationSeconds * 0.5f).WithEase(Ease.InOutSine).Bind(delegate(float x)
			{
				revealLight.intensity = x;
			})
				.ToUniTask(token);
			await LMotion.Create(_config.LightPeakIntensity + _config.LightPulseAmplitude, _config.LightPeakIntensity, _config.LightPulseDurationSeconds * 0.5f).WithEase(Ease.InOutSine).Bind(delegate(float x)
			{
				revealLight.intensity = x;
			})
				.ToUniTask(token);
		}
	}

	private async UniTask FadeLightToBaseAsync(float durationSeconds, Ease ease, CancellationToken token)
	{
		await LMotion.Create(revealLight.intensity, _lightBaseIntensity, Mathf.Max(0.01f, durationSeconds)).WithEase(ease).Bind(delegate(float x)
		{
			revealLight.intensity = x;
		})
			.ToUniTask(token);
		revealLight.enabled = false;
	}

	private void StartItemIdle()
	{
		StopItemIdle();
		QualityConfig config = _config;
		if (config.ItemFloatAmplitude > 0.001f && config.ItemFloatPeriodSeconds > 0.001f)
		{
			_itemIdleMotionPosition = LMotion.Create(0f - _config.ItemFloatAmplitude, _config.ItemFloatAmplitude, _config.ItemFloatPeriodSeconds).WithLoops(-1, LoopType.Yoyo).WithEase(Ease.InOutSine)
				.Bind(delegate(float t)
				{
					Vector3 itemOpenBaseLocalPosition = _itemOpenBaseLocalPosition;
					itemOpenBaseLocalPosition.y += t;
					itemSprite.transform.localPosition = itemOpenBaseLocalPosition;
				});
		}
		if (Mathf.Abs(_config.ItemFloatRotationDegrees) > 0.001f && _config.ItemFloatPeriodSeconds > 0.001f)
		{
			_itemIdleMotionRotation = LMotion.Create(0f - _config.ItemFloatRotationDegrees, _config.ItemFloatRotationDegrees, _config.ItemFloatPeriodSeconds).WithLoops(-1, LoopType.Yoyo).WithEase(Ease.InOutSine)
				.Bind(delegate(float z)
				{
					itemSprite.transform.localRotation = Quaternion.identity * Quaternion.Euler(0f, 0f, z);
				});
		}
	}

	private async UniTask ShakeItemAsync(float durationSeconds, float strength, int vibrato, CancellationToken token)
	{
		Vector3 startPosition = itemSprite.transform.localPosition;
		await LMotion.Create(0f, 1f, durationSeconds).WithEase(Ease.Linear).Bind(delegate(float t)
		{
			float num = (float)vibrato / durationSeconds;
			float num2 = Mathf.PerlinNoise(0.13f, t * num);
			float num3 = Mathf.PerlinNoise(0.91f, t * num);
			float x = (num2 - 0.5f) * 2f * strength;
			float y = (num3 - 0.5f) * 2f * strength;
			itemSprite.transform.localPosition += new Vector3(x, y, 0f);
		})
			.ToUniTask(token);
		itemSprite.transform.localPosition = startPosition;
	}

	private async UniTask FlashItemTintAsync(Color tint, float durationSeconds, CancellationToken token)
	{
		await LMotion.Create(_itemBaseColor, tint, durationSeconds * 0.5f).WithEase(Ease.OutQuad).BindToColor(itemSprite)
			.ToUniTask(token);
		await LMotion.Create(tint, _itemBaseColor, durationSeconds * 0.5f).WithEase(Ease.InQuad).BindToColor(itemSprite)
			.ToUniTask(token);
		itemSprite.color = _itemBaseColor;
	}

	private QualityConfig GetQualityConfig(LootItemQuality quality)
	{
		return quality switch
		{
			LootItemQuality.Common => commonConfig, 
			LootItemQuality.Uncommon => uncommonConfig, 
			LootItemQuality.Rare => rareConfig, 
			LootItemQuality.Legendary => legendaryConfig, 
			_ => commonConfig, 
		};
	}

	private void ApplyClosedVisuals()
	{
		StopItemIdle();
		topTransform.localRotation = _topClosedLocalRotation;
		itemSprite.enabled = false;
		itemSprite.sprite = null;
		itemSprite.transform.localPosition = _itemClosedLocalPosition;
		itemSprite.transform.localRotation = Quaternion.identity;
		itemSprite.transform.localScale = Vector3.one;
		itemSprite.color = _itemBaseColor;
		revealLight.intensity = _lightBaseIntensity;
		revealLight.color = _lightBaseColor;
		revealLight.enabled = false;
	}

	private void StopItemIdle()
	{
		if (_itemIdleMotionPosition.IsActive())
		{
			_itemIdleMotionPosition.Cancel();
		}
		if (_itemIdleMotionRotation.IsActive())
		{
			_itemIdleMotionRotation.Cancel();
		}
	}

	private void CancelCurrentSequence()
	{
		if (_sequenceCts != null)
		{
			_sequenceCts.Cancel();
			_sequenceCts.Dispose();
			_sequenceCts = null;
		}
	}
}
