using System.Collections;
using Pug.Sprite;
using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public class FeatherTree : Tree
{
	public SpriteObject spriteObject;

	public SpriteObject lightSpriteObject;

	[ColorUsage(true, true)]
	public Color purpleLightColor = new Color(0.45f, 0.2f, 0.3f, 1f);

	[ColorUsage(true, true)]
	public Color cyanLightColor = new Color(0.4f, 0.7f, 0.8f, 1f);

	public Vector2 glowingTipsMinRange = new Vector2(0.05f, 0.2f);

	public Vector2 glowingTipsMaxRange = new Vector2(20f, 30f);

	public float lightDurationInSeconds = 5f;

	public AnimationCurve lightAnimationCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	private Color _emissiveColor = Color.cyan;

	private bool _triggered;

	private float _currentLightIntensity;

	private float _currentTipIntensity;

	public override void OnOccupied()
	{
		base.OnOccupied();
		ObjectID objectID = base.objectInfo.objectID;
		if (objectID == ObjectID.FeatherTree || objectID == ObjectID.SmallFeatherTree)
		{
			_emissiveColor = purpleLightColor;
		}
		else
		{
			_emissiveColor = cyanLightColor;
		}
		_currentLightIntensity = 0f;
		lightSpriteObject.emissiveColor = _emissiveColor * _currentLightIntensity;
		_currentTipIntensity = PugRandom.Range(glowingTipsMinRange.x, glowingTipsMinRange.y, base.WorldPosition.GetHashCode());
		GlowingTipsEmissiveIntensity(_currentTipIntensity);
		_triggered = false;
	}

	private void GlowingTipsEmissiveIntensity(float value)
	{
		spriteObject.emissiveColor = new Color(1f, 1f, 1f, 1f) * value;
	}

	public void AE_Shake()
	{
		Manager.effects.PlayPuff(PuffID.SmallDirtSmoke, base.transform.position, 4);
		AudioManager.Sfx(SfxID.grassImpact, base.transform.position, 0.3f, 1.15f, 0.125f);
	}

	public override void OnNonPlayerTriggerEnter(Entity triggeringEntity)
	{
		base.OnNonPlayerTriggerEnter(triggeringEntity);
		Vector3 position = EntityMonoBehaviour.ToRenderFromWorld(EntityUtility.GetComponentData<LocalTransform>(triggeringEntity, base.world).Position);
		TreeImpactByEntity(position);
	}

	public override void OnPlayerTriggerEnter(PlayerController pc)
	{
		base.OnPlayerTriggerEnter(pc);
		TreeImpactByEntity(pc.RenderPosition);
	}

	private void TreeImpactByEntity(Vector3 position)
	{
		AudioManager.Sfx(SfxID.featherTreeInteract6, base.transform.position, 0.25f, 1.2f, 0.25f);
		AudioManager.Sfx(SfxID.featherTreeInteract3, base.transform.position, 0.1f, 1.1f, 0.125f);
		PlayShakeAnim(position, spriteObject, 2f, gentle: true);
		PlayShakeAnim(position, lightSpriteObject, 2f, gentle: true);
		if (!_triggered)
		{
			StartCoroutine(AnimateLights());
			_triggered = true;
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		lightSpriteObject.emissiveColor = _emissiveColor * 0f;
	}

	private IEnumerator AnimateLights()
	{
		float tipRandomMinValue = PugRandom.Range(glowingTipsMinRange.x, glowingTipsMinRange.y, base.WorldPosition.GetHashCode());
		float tipRandomMaxValue = PugRandom.Range(glowingTipsMaxRange.x, glowingTipsMaxRange.y, base.WorldPosition.GetHashCode());
		while (_currentLightIntensity < lightDurationInSeconds)
		{
			float num = lightAnimationCurve.Evaluate(_currentLightIntensity / lightDurationInSeconds);
			lightSpriteObject.emissiveColor = _emissiveColor * num;
			GlowingTipsEmissiveIntensity(Mathf.Lerp(tipRandomMinValue, tipRandomMaxValue, num));
			_currentLightIntensity += Time.deltaTime;
			yield return null;
		}
		_currentLightIntensity = 0f;
		lightSpriteObject.emissiveColor = _emissiveColor * _currentLightIntensity;
		_triggered = false;
	}
}
