using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Pug.Sprite;
using Pug.UnityExtensions;
using PugTilemap;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class WormSegment : EntityMonoBehaviour
{
	protected struct SegmentRotationData
	{
		public float3 prevTargetDirection;

		public bool hasPrevDirection;

		private void Reset()
		{
			prevTargetDirection = 0f;
			hasPrevDirection = false;
		}
	}

	public Transform headSegmentTransform;

	public float aboveGroundHeight;

	public float inWaterHeight;

	public float inPitHeight;

	public ParticleSystem burrowDirtParticles;

	public ParticleSystem scatterParticles;

	public ParticleSystem dustParticles;

	public Material pivotProjectionMaterial;

	public Material normalMaterial;

	public WaterSimAffector waterSimAffector;

	public Transform waterSimSpherePoint;

	public float waterSimSphereRadius;

	public ParticleSystem waterParticlesL;

	public ParticleSystem waterParticlesR;

	[MinValue(0)]
	[MaxValue(60)]
	public int waterParticleEmitsPerSecond;

	[MinValue(0)]
	public int waterParticlesPerEmit;

	[MinValue(0)]
	[MaxValue(60)]
	public int burrowParticleEmitsPerSecond;

	[MinValue(0)]
	public int burrowParticlesPerEmit;

	[MinValue(0)]
	[MaxValue(60)]
	public int scatterParticleEmitsPerSecond;

	[MinValue(0)]
	public int scatterParticlesPerEmit;

	[MinValue(0f)]
	[MaxValue(1f)]
	public float burrowAndScatterParticleLuminance;

	public SFXTableIDField growlSound;

	public List<WormSegmentTail> wormSegmentTails;

	[SerializeField]
	private SnakeBossSegmentSpriteController headController;

	private float[] _waterHeightAlphas;

	private float[] _pitHeightAlphas;

	private bool[] _isInWater;

	private bool[] _hasWallAheadOrBehind;

	private TileInfo[] _wallInfos;

	protected SegmentRotationData[] _segmentRotationData;

	private readonly List<AudioManager.RunningSfxReference> _growlAudioLoop = new List<AudioManager.RunningSfxReference>();

	private readonly List<AudioManager.RunningSfxReference> _diggingAudioLoop = new List<AudioManager.RunningSfxReference>();

	private float _currentDiggingAudioVolume;

	private bool _isInitialized;

	private TileTypeColorLookupSystem _colorLookupSystem;

	private Coroutine _deathCoroutine;

	protected Vector3 m_headPos;

	private int _fixedFrame = -1;

	protected override bool hideDirectlyOnDeath => false;

	public override void OnOccupied()
	{
		base.OnOccupied();
		_isInitialized = false;
		_currentDiggingAudioVolume = 0f;
		waterParticlesL.Stop();
		waterParticlesR.Stop();
		_colorLookupSystem = base.world.GetExistingSystemManaged<TileTypeColorLookupSystem>();
	}

	public override void OnFree()
	{
		ReleaseAudioLoops();
		if (_deathCoroutine != null)
		{
			StopCoroutine(_deathCoroutine);
			_deathCoroutine = null;
		}
		base.OnFree();
	}

	protected override void OnShow()
	{
		base.OnShow();
		if (_deathCoroutine != null)
		{
			StopCoroutine(_deathCoroutine);
			_deathCoroutine = null;
		}
		bool flag = (float)currentHealth <= 0f;
		for (int i = 0; i < wormSegmentTails.Count; i++)
		{
			wormSegmentTails[i].gameObject.SetActive(!flag);
		}
	}

	protected override void OnHide()
	{
		base.OnHide();
		_deathCoroutine = StartCoroutine(OnDeathCoroutine());
	}

	private void UpdateSegments(NativeArray<SnakeSegmentsBuffer> segments)
	{
		if (!EntityUtility.HasComponentData<LocalTransform>(segments[0].segment, base.world))
		{
			return;
		}
		m_headPos = EntityMonoBehaviour.ToRenderFromWorld(EntityUtility.GetComponentData<LocalTransform>(segments[0].segment, base.world).Position);
		SinglePugMap.TileLayerLookup tileLayerLookup = Manager.multiMap.GetTileLayerLookup();
		for (int i = 0; i < segments.Length; i++)
		{
			Entity segment = segments[0].segment;
			Entity segment2 = segments[i].segment;
			if (!EntityUtility.HasComponentData<LocalTransform>(segment, base.world) || !EntityUtility.HasComponentData<LocalTransform>(segment2, base.world))
			{
				continue;
			}
			float3 position = EntityUtility.GetComponentData<LocalTransform>(segment, base.world).Position;
			float3 float5 = EntityUtility.GetComponentData<LocalTransform>(segment2, base.world).Position - position;
			float3 float6 = new float3(base.WorldPosition.x, 0f, base.WorldPosition.z) + float5;
			bool flag = i == 0;
			Transform transform = (flag ? headSegmentTransform : wormSegmentTails[i - 1].transform);
			float3 float7 = GetDirection(segments, i);
			bool num = tileLayerLookup.HasTile(float6.RoundToInt2(), TileType.water) || tileLayerLookup.HasTile(float6.RoundToInt2(), TileType.pit);
			float3 float8 = float6 + float7 * 1f;
			float3 x = (num ? float8 : float6);
			bool flag2;
			_isInWater[i] = (flag2 = tileLayerLookup.HasTile(x.RoundToInt2(), TileType.water));
			bool flag3 = flag2;
			bool flag4 = tileLayerLookup.HasTile(x.RoundToInt2(), TileType.pit);
			float num2 = SetHeightAlpha(_waterHeightAlphas[i], flag3);
			_waterHeightAlphas[i] = num2;
			float num3 = SetHeightAlpha(_pitHeightAlphas[i], flag4);
			_pitHeightAlphas[i] = num3;
			float start = math.lerp(aboveGroundHeight, inWaterHeight, num2);
			float end = math.lerp(aboveGroundHeight, inPitHeight, num3);
			float num4 = math.lerp(start, end, num3);
			transform.localPosition = new Vector3(0f, num4, num4 / -3f * 0.001f) + new Vector3(float5.x, float5.y, float5.z);
			transform.position = math.round(transform.position * 16f) / 16f;
			if (flag)
			{
				Material material = ((flag3 || flag4) ? normalMaterial : pivotProjectionMaterial);
				foreach (SpriteObject spriteObject2 in spriteObjects)
				{
					if (!(spriteObject2.material == material))
					{
						spriteObject2.material = material;
						spriteObject2.ApplyVisualChange();
					}
				}
			}
			else
			{
				SpriteObject spriteObject = wormSegmentTails[i - 1].spriteObject;
				Material material2 = ((flag3 || flag4) ? normalMaterial : pivotProjectionMaterial);
				if (spriteObject.material != material2)
				{
					spriteObject.material = material2;
					spriteObject.ApplyVisualChange();
				}
			}
			SnakeBossSegmentSpriteController segmentController = (flag ? headController : wormSegmentTails[i - 1].controller);
			UpdateRotation(segments, i, float7, segmentController, transform);
			if (!float7.Equals(default(float3)))
			{
				float3 x2 = float6 + float7 * 0.25f;
				float3 x3 = float6 - float7 * 0.25f;
				TileInfo tileInfo;
				bool flag5 = tileLayerLookup.TryGetTileInfo(x2.RoundToInt2(), TileType.wall, out tileInfo);
				TileInfo tileInfo2;
				bool flag6 = tileLayerLookup.TryGetTileInfo(x3.RoundToInt2(), TileType.wall, out tileInfo2);
				bool flag7 = (flag5 && !flag6) || (!flag5 && flag6);
				TileInfo tileInfo3 = ((flag5 && !flag6) ? tileInfo : tileInfo2);
				_hasWallAheadOrBehind[i] = flag7;
				_wallInfos[i] = tileInfo3;
			}
		}
		static float SetHeightAlpha(float alpha, bool active)
		{
			alpha = ((!active) ? (alpha - Time.deltaTime * 4f) : (alpha + Time.deltaTime * 2f));
			return Mathf.Clamp01(alpha);
		}
	}

	public virtual void UpdateRotation(NativeArray<SnakeSegmentsBuffer> segments, int segmentIndex, float3 segmentDirection, SnakeBossSegmentSpriteController segmentController, Transform segmentTransform)
	{
		SegmentRotationData segmentRotationData = _segmentRotationData[segmentIndex];
		if (segmentDirection.Equals(default(float3)))
		{
			segmentRotationData.prevTargetDirection = 0f;
			segmentRotationData.hasPrevDirection = false;
			return;
		}
		GetFrontRearPos(segments, segmentIndex, out var frontPos, out var rearPos);
		if (Vector3.Angle(segmentDirection, segmentRotationData.prevTargetDirection) > 2f || !segmentRotationData.hasPrevDirection)
		{
			if (segmentIndex > 0 && segmentIndex < segments.Length - 1)
			{
				LocalTransform value;
				float3 float5 = (EntityUtility.TryGetComponentData<LocalTransform>(segments[segmentIndex].segment, base.world, out value) ? value.Position : default(float3));
				if (float5.z < rearPos.z && float5.z < frontPos.z)
				{
					segmentDirection.z = 0f;
					segmentDirection = math.normalizesafe(segmentDirection);
				}
			}
			segmentController.clockwiseAngle = Mathf.Atan2(segmentDirection.z, segmentDirection.x) * 57.29578f + 90f;
			segmentRotationData.prevTargetDirection = segmentDirection;
			segmentRotationData.hasPrevDirection = true;
		}
		float num = m_headPos.z - segmentTransform.position.z;
		float num2 = 1f + Vector2.Dot(new Vector2(segmentDirection.x, segmentDirection.z), Vector2.down);
		float num3 = num + num2 * 0.5f;
		segmentTransform.localPosition += new Vector3(0f, 1f, 1f) * num3 * 0.001f;
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		if (base.isHidden || !EntityUtility.EntityExists(base.entity, base.world) || (float)currentHealth <= 0f)
		{
			return;
		}
		using NativeArray<SnakeSegmentsBuffer> segments = EntityUtility.GetBuffer<SnakeSegmentsBuffer>(base.entity, base.world).ToNativeArray(Allocator.Temp);
		if (segments.Length == 0)
		{
			return;
		}
		if (!_isInitialized)
		{
			_isInitialized = true;
			_waterHeightAlphas = new float[segments.Length];
			_pitHeightAlphas = new float[segments.Length];
			_isInWater = new bool[segments.Length];
			_hasWallAheadOrBehind = new bool[segments.Length];
			_wallInfos = new TileInfo[segments.Length];
			_segmentRotationData = new SegmentRotationData[segments.Length];
			for (int i = 0; i < wormSegmentTails.Count; i++)
			{
				wormSegmentTails[i].gameObject.SetActive(i < segments.Length - 1);
				wormSegmentTails[i].gameObject.transform.localPosition = Vector3.zero;
				if (i == segments.Length - 2)
				{
					wormSegmentTails[i].isTail = true;
				}
			}
			return;
		}
		UpdateSegments(segments);
		if (!((float)currentHealth <= 0f) && lastAnim != -414722770)
		{
			UpdateAudioLoops(segments);
		}
		int num = (int)(1f / Time.fixedDeltaTime);
		_fixedFrame = (_fixedFrame + 1) % (num + 1);
		for (int j = 0; j < segments.Length; j++)
		{
			if (!_isInWater[j])
			{
				continue;
			}
			bool num2 = j == 0;
			SnakeBossSegmentSpriteController snakeBossSegmentSpriteController = (num2 ? headController : wormSegmentTails[j - 1].controller);
			Transform transform = (num2 ? waterSimSpherePoint : wormSegmentTails[j - 1].waterSimSpherePoint);
			float radius = (num2 ? waterSimSphereRadius : wormSegmentTails[j - 1].waterSimSphereRadius);
			WaterSimAffector waterSimAffector = (num2 ? this.waterSimAffector : wormSegmentTails[j - 1].waterSimAffector);
			if (GetSphereWaterIntersection(transform.position, radius, out var intersectionPosition, out var intersectionRadius))
			{
				float f = snakeBossSegmentSpriteController.clockwiseAngle * (MathF.PI / 180f);
				Vector3 vector = -new Vector3(Mathf.Cos(f), 0f, Mathf.Sin(f));
				waterSimAffector.gameObject.SetActive(value: true);
				waterSimAffector.transform.position = intersectionPosition;
				waterSimAffector.transform.localScale = Vector3.one * intersectionRadius * 2f;
				if (_fixedFrame % (num / waterParticleEmitsPerSecond) == 0)
				{
					Vector3 forward = Vector3.Cross(vector, Vector3.up);
					waterParticlesL.transform.position = intersectionPosition - vector * intersectionRadius;
					waterParticlesR.transform.position = intersectionPosition + vector * intersectionRadius;
					waterParticlesL.transform.rotation = Quaternion.LookRotation(forward, Vector3.up);
					waterParticlesR.transform.rotation = waterParticlesL.transform.rotation;
					waterParticlesL.Emit(waterParticlesPerEmit);
					waterParticlesR.Emit(waterParticlesPerEmit);
				}
			}
			else
			{
				waterSimAffector.gameObject.SetActive(value: false);
			}
		}
		Vector3 vector2 = new Vector3(0f, 0.1f, -0.233f);
		TileTypeColorLookupSystem.LookupHelper lookupHelper = _colorLookupSystem.CreateLookupHelper();
		for (int k = 0; k < segments.Length; k++)
		{
			bool flag = _hasWallAheadOrBehind[k];
			TileInfo tileInfo = _wallInfos[k];
			if (tileInfo.tileType == TileType.none)
			{
				continue;
			}
			bool flag2 = _fixedFrame % (num / burrowParticleEmitsPerSecond) == 0;
			bool flag3 = _fixedFrame % (num / scatterParticleEmitsPerSecond) == 0;
			if (flag && (flag2 || flag3))
			{
				ParticleSystem.MainModule main = burrowDirtParticles.main;
				ParticleSystem.MainModule main2 = scatterParticles.main;
				Color color = lookupHelper.GetTrueColorByTileType(tileInfo.tileset, tileInfo.tileType);
				if (burrowAndScatterParticleLuminance > 0f)
				{
					color = Pug.UnityExtensions.ColorUtility.IncreaseBrightness(color, burrowAndScatterParticleLuminance);
				}
				main.startColor = new ParticleSystem.MinMaxGradient(color);
				main2.startColor = new ParticleSystem.MinMaxGradient(color);
				Vector3 position = ((k == 0) ? waterSimSpherePoint : wormSegmentTails[k - 1].waterSimSpherePoint).position + vector2;
				burrowDirtParticles.transform.position = position;
				if (flag2)
				{
					burrowDirtParticles.Emit(burrowParticlesPerEmit);
					dustParticles.Emit(burrowParticlesPerEmit);
				}
				if (flag3)
				{
					scatterParticles.Emit(scatterParticlesPerEmit);
					dustParticles.Emit(burrowParticlesPerEmit);
				}
			}
		}
	}

	private static bool GetSphereWaterIntersection(Vector3 position, float radius, out Vector3 intersectionPosition, out float intersectionRadius)
	{
		intersectionPosition = position;
		intersectionRadius = -1f;
		float num = Mathf.Abs(-0.2f - position.y);
		if (num > radius)
		{
			return false;
		}
		float num2 = radius * radius - num * num;
		if (num2 < Mathf.Epsilon)
		{
			return false;
		}
		intersectionPosition.y = -0.2f;
		intersectionRadius = Mathf.Sqrt(num2);
		return true;
	}

	private void UpdateAudioLoops(NativeArray<SnakeSegmentsBuffer> segments)
	{
		if (base.world.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.simulationDisabled)
		{
			ReleaseAudioLoops();
			return;
		}
		if (_growlAudioLoop.Count == 0)
		{
			AudioManager.SfxFollowTransform(growlSound.value, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _growlAudioLoop);
		}
		if (_diggingAudioLoop.Count == 0)
		{
			AudioManager.SfxFollowTransform(SfxTableID.wormDiggingLoop, base.transform, 1f, 1f, loop: true, freeAudioSourceAfterItStoppedPlaying: true, AudioManager.MixerGroupEnum.EFFECTS, reuseSfxs: false, playOnGamepad: false, _diggingAudioLoop);
		}
		bool flag = Manager.multiMap.GetTileLayerLookup().HasTile(base.WorldPosition.RoundToInt2(), TileType.wall);
		_currentDiggingAudioVolume = Mathf.Lerp(_currentDiggingAudioVolume, flag ? 1f : 0f, Time.deltaTime * 2f);
		foreach (AudioManager.RunningSfxReference item in _growlAudioLoop)
		{
			item.SetVolume((1f - _currentDiggingAudioVolume) * 0.5f);
		}
		foreach (AudioManager.RunningSfxReference item2 in _diggingAudioLoop)
		{
			item2.SetVolume(_currentDiggingAudioVolume * 0.6f);
		}
	}

	private void ReleaseAudioLoops()
	{
		foreach (AudioManager.RunningSfxReference item in _growlAudioLoop)
		{
			item.FadeOutAndStop();
		}
		foreach (AudioManager.RunningSfxReference item2 in _diggingAudioLoop)
		{
			item2.FadeOutAndStop();
		}
		_growlAudioLoop.Clear();
		_diggingAudioLoop.Clear();
	}

	protected void GetFrontRearPos(NativeArray<SnakeSegmentsBuffer> segments, int segmentIndex, out float3 frontPos, out float3 rearPos)
	{
		int index = Mathf.Clamp(segmentIndex - 1, 0, segments.Length - 1);
		int index2 = Mathf.Clamp(segmentIndex + 1, 0, segments.Length - 1);
		frontPos = (EntityUtility.TryGetComponentData<LocalTransform>(segments[index].segment, base.world, out var value) ? value.Position : default(float3));
		rearPos = (EntityUtility.TryGetComponentData<LocalTransform>(segments[index2].segment, base.world, out var value2) ? value2.Position : default(float3));
	}

	private float3 GetDirection(NativeArray<SnakeSegmentsBuffer> segments, int segmentIndex)
	{
		GetFrontRearPos(segments, segmentIndex, out var frontPos, out var rearPos);
		float num = math.distance(frontPos, rearPos);
		if (num < 0.1f)
		{
			return default(float3);
		}
		return (frontPos - rearPos) / num;
	}

	private IEnumerator OnDeathCoroutine()
	{
		ReleaseAudioLoops();
		yield return new WaitForSeconds(0.5f);
		int i = wormSegmentTails.Count - 1;
		while (i >= 0)
		{
			if (wormSegmentTails[i].gameObject.activeInHierarchy)
			{
				AudioManager.Sfx(SfxTableID.wormSegmentSplatDeath, base.transform.position);
				SpawnDeathParticles(wormSegmentTails[i].gameObject);
				wormSegmentTails[i].gameObject.SetActive(value: false);
				wormSegmentTails[i].gameObject.transform.localPosition = Vector3.zero;
				yield return new WaitForSeconds(0.05f);
			}
			int num = i - 1;
			i = num;
		}
		AudioManager.Sfx(SfxTableID.wormSegmentSplatDeath, base.transform.position);
		SpawnDeathParticles(headSegmentTransform.gameObject);
		XScaler.gameObject.SetActive(value: false);
	}

	protected virtual void SpawnDeathParticles(GameObject segment)
	{
		Vector3 position = segment.transform.position + Vector3.up * 0.25f;
		Manager.effects.PlayPuff(PuffID.SmallPurplePuff, position, 8);
		Manager.effects.PlayPuff(PuffID.CoralDebrisPurple, position, 8);
		Manager.effects.PlayPuff(PuffID.BlackDebris, position, 8);
	}
}
