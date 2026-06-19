using System.Collections.Generic;
using Pug.Sprite;
using Pug.UnityExtensions;
using UnityEngine;
using UnityEngine.Serialization;

public class Flashable : MonoBehaviour
{
	public abstract class Effect
	{
		public SpriteRenderer sprite;

		public List<SpriteObject> spriteObjects;

		public List<SpriteRenderer> additionalSpriteRenderers;

		public List<Renderer> renderers;

		public abstract void Start(float duration);

		public abstract void Cancel();

		public abstract void Update();
	}

	public class FlashEffect : Effect
	{
		public Color flashColor = Color.white;

		public bool useCurve;

		public int multiplyFlashTintWithLight = -1;

		public AnimationCurve curve;

		public AnimationCurve defaultCurve;

		private Color m_backup;

		private List<Color> m_additionalBackups;

		private int m_multiplyFlashTintWithLightBackup;

		private List<int> m_multiplyFlashTintWithLightBackups;

		private float m_currentFlashAmount;

		private float m_flashDuration;

		private Color m_transparent = new Color(0f, 0f, 0f, 0f);

		public float currentFlashAmount
		{
			get
			{
				if (!useCurve)
				{
					return m_currentFlashAmount;
				}
				return curve.Evaluate(1f - m_currentFlashAmount);
			}
		}

		public override void Start(float duration)
		{
			m_flashDuration = duration;
			if (sprite != null)
			{
				m_backup = sprite.material.GetColor(Tint);
				sprite.material.SetColor(Tint, flashColor);
				m_multiplyFlashTintWithLightBackup = (sprite.material.HasProperty(MultiplyFlashTintWithLight) ? sprite.material.GetInt(MultiplyFlashTintWithLight) : 0);
				if (multiplyFlashTintWithLight != -1)
				{
					sprite.material.SetInt(MultiplyFlashTintWithLight, multiplyFlashTintWithLight);
				}
			}
			if (spriteObjects != null)
			{
				foreach (SpriteObject spriteObject in spriteObjects)
				{
					spriteObject.flashColor = m_transparent;
				}
			}
			if (renderers != null)
			{
				foreach (Renderer renderer in renderers)
				{
					if (renderer != null)
					{
						Material[] materials = renderer.materials;
						for (int i = 0; i < materials.Length; i++)
						{
							materials[i].SetColor(FlashColor, m_transparent);
						}
					}
				}
			}
			if (additionalSpriteRenderers.Count > 0)
			{
				m_additionalBackups = new List<Color>();
				m_multiplyFlashTintWithLightBackups = new List<int>();
			}
			for (int j = 0; j < additionalSpriteRenderers.Count; j++)
			{
				SpriteRenderer spriteRenderer = additionalSpriteRenderers[j];
				m_additionalBackups.Add(sprite.material.GetColor(Tint));
				m_multiplyFlashTintWithLightBackups.Add(sprite.material.HasProperty(MultiplyFlashTintWithLight) ? sprite.material.GetInt(MultiplyFlashTintWithLight) : 0);
				spriteRenderer.material.SetColor(Tint, flashColor);
			}
			m_currentFlashAmount = 1f;
		}

		public override void Cancel()
		{
			if (sprite != null)
			{
				sprite.material.SetColor(Tint, m_backup);
				sprite.material.SetInt(MultiplyFlashTintWithLight, m_multiplyFlashTintWithLightBackup);
				sprite.material.SetFloat(FlashAmount, 0f);
			}
			if (spriteObjects != null)
			{
				foreach (SpriteObject spriteObject in spriteObjects)
				{
					spriteObject.flashColor = m_transparent;
				}
			}
			if (renderers != null)
			{
				foreach (Renderer renderer in renderers)
				{
					if (renderer != null)
					{
						Material[] materials = renderer.materials;
						for (int i = 0; i < materials.Length; i++)
						{
							materials[i].SetColor(FlashColor, m_transparent);
						}
					}
				}
			}
			for (int j = 0; j < additionalSpriteRenderers.Count; j++)
			{
				additionalSpriteRenderers[j].material.SetColor(Tint, m_additionalBackups[j]);
				additionalSpriteRenderers[j].material.SetInt(MultiplyFlashTintWithLight, m_multiplyFlashTintWithLightBackups[j]);
				additionalSpriteRenderers[j].material.SetFloat(FlashAmount, 0f);
			}
		}

		public override void Update()
		{
			m_currentFlashAmount -= Time.deltaTime / m_flashDuration;
			if (m_currentFlashAmount > Mathf.Epsilon)
			{
				float num = m_currentFlashAmount;
				if (useCurve)
				{
					num = curve.Evaluate(1f - m_currentFlashAmount);
				}
				if (sprite != null)
				{
					sprite.material.SetFloat(FlashAmount, num);
				}
				if (spriteObjects != null)
				{
					foreach (SpriteObject spriteObject in spriteObjects)
					{
						spriteObject.flashColor = flashColor * num;
					}
				}
				if (renderers != null)
				{
					foreach (Renderer renderer in renderers)
					{
						if (renderer != null)
						{
							Material[] materials = renderer.materials;
							for (int i = 0; i < materials.Length; i++)
							{
								materials[i].SetColor(FlashColor, flashColor * num);
							}
						}
					}
				}
				for (int j = 0; j < additionalSpriteRenderers.Count; j++)
				{
					additionalSpriteRenderers[j].material.SetFloat(FlashAmount, num);
				}
				return;
			}
			if (sprite != null)
			{
				sprite.material.SetFloat(FlashAmount, 0f);
			}
			if (spriteObjects != null)
			{
				foreach (SpriteObject spriteObject2 in spriteObjects)
				{
					spriteObject2.flashColor = m_transparent;
				}
			}
			if (renderers != null)
			{
				foreach (Renderer renderer2 in renderers)
				{
					if (renderer2 != null)
					{
						Material[] materials = renderer2.materials;
						for (int i = 0; i < materials.Length; i++)
						{
							materials[i].SetColor(FlashColor, m_transparent);
						}
					}
				}
			}
			for (int k = 0; k < additionalSpriteRenderers.Count; k++)
			{
				additionalSpriteRenderers[k].material.SetFloat(FlashAmount, 0f);
			}
		}
	}

	public class BlinkEffect : Effect
	{
		public int framesOn = 2;

		public int framesOff = 2;

		private float startTimestamp;

		public override void Start(float duration)
		{
			if (sprite != null)
			{
				sprite.enabled = true;
			}
			startTimestamp = Time.time;
		}

		public override void Cancel()
		{
			if (sprite != null)
			{
				sprite.enabled = true;
			}
			for (int i = 0; i < additionalSpriteRenderers.Count; i++)
			{
				additionalSpriteRenderers[i].enabled = true;
			}
		}

		public override void Update()
		{
			bool enabled = Mathf.FloorToInt((Time.time - startTimestamp) * 60f) % (framesOn + framesOff) < framesOn;
			if (sprite != null)
			{
				sprite.enabled = enabled;
			}
			foreach (SpriteRenderer additionalSpriteRenderer in additionalSpriteRenderers)
			{
				additionalSpriteRenderer.enabled = enabled;
			}
		}
	}

	public class FlashBlinkEffect : Effect
	{
		public int rate = 2;

		public Color flashColor = Color.white;

		private Color backup;

		private List<Color> additionalBackups;

		private float startTimestamp;

		public int multiplyFlashTintWithLight = -1;

		private int multiplyFlashTintWithLightBackup;

		private List<int> multiplyFlashTintWithLightBackups;

		private Color transparent = new Color(0f, 0f, 0f, 0f);

		public override void Start(float duration)
		{
			if (sprite != null)
			{
				backup = sprite.material.GetColor(Tint);
				sprite.material.SetFloat(FlashAmount, 1f);
				multiplyFlashTintWithLightBackup = (sprite.material.HasProperty(MultiplyFlashTintWithLight) ? sprite.material.GetInt(MultiplyFlashTintWithLight) : 0);
				if (multiplyFlashTintWithLight != -1)
				{
					sprite.material.SetInt(MultiplyFlashTintWithLight, multiplyFlashTintWithLight);
				}
			}
			startTimestamp = Time.time;
			if (spriteObjects != null)
			{
				foreach (SpriteObject spriteObject in spriteObjects)
				{
					spriteObject.flashColor = flashColor * FlashAmount;
				}
			}
			if (renderers != null)
			{
				foreach (Renderer renderer in renderers)
				{
					if (renderer != null)
					{
						Material[] materials = renderer.materials;
						for (int i = 0; i < materials.Length; i++)
						{
							materials[i].SetColor(FlashColor, flashColor * FlashAmount);
						}
					}
				}
			}
			if (additionalSpriteRenderers.Count > 0)
			{
				additionalBackups = new List<Color>();
				multiplyFlashTintWithLightBackups = new List<int>();
			}
			for (int j = 0; j < additionalSpriteRenderers.Count; j++)
			{
				SpriteRenderer spriteRenderer = additionalSpriteRenderers[j];
				additionalBackups.Add(sprite.material.GetColor(Tint));
				multiplyFlashTintWithLightBackups.Add(sprite.material.HasProperty(MultiplyFlashTintWithLight) ? sprite.material.GetInt(MultiplyFlashTintWithLight) : 0);
				spriteRenderer.material.SetColor(Tint, flashColor);
				spriteRenderer.material.SetFloat(FlashAmount, 1f);
			}
		}

		public override void Cancel()
		{
			if (sprite != null)
			{
				sprite.material.SetColor(Tint, backup);
				sprite.material.SetInt(MultiplyFlashTintWithLight, multiplyFlashTintWithLightBackup);
				sprite.material.SetFloat(FlashAmount, 0f);
			}
			if (spriteObjects != null)
			{
				foreach (SpriteObject spriteObject in spriteObjects)
				{
					spriteObject.flashColor = transparent;
				}
			}
			if (renderers != null)
			{
				foreach (Renderer renderer in renderers)
				{
					if (renderer != null)
					{
						Material[] materials = renderer.materials;
						for (int i = 0; i < materials.Length; i++)
						{
							materials[i].SetColor(FlashColor, transparent);
						}
					}
				}
			}
			for (int j = 0; j < additionalSpriteRenderers.Count; j++)
			{
				additionalSpriteRenderers[j].material.SetColor(Tint, additionalBackups[j]);
				additionalSpriteRenderers[j].material.SetInt(MultiplyFlashTintWithLight, multiplyFlashTintWithLightBackups[j]);
				additionalSpriteRenderers[j].material.SetFloat(FlashAmount, 0f);
			}
		}

		public override void Update()
		{
			Color value = ((rate > 0 && Mathf.FloorToInt((Time.time - startTimestamp) * 60f) % (2 * rate) < rate) ? backup : flashColor);
			if (sprite != null)
			{
				sprite.material.SetColor(Tint, value);
			}
			if (spriteObjects != null)
			{
				foreach (SpriteObject spriteObject in spriteObjects)
				{
					spriteObject.flashColor = value;
				}
			}
			if (renderers != null)
			{
				foreach (Renderer renderer in renderers)
				{
					if (renderer != null)
					{
						Material[] materials = renderer.materials;
						for (int i = 0; i < materials.Length; i++)
						{
							materials[i].SetColor(FlashColor, value);
						}
					}
				}
			}
			for (int j = 0; j < additionalSpriteRenderers.Count; j++)
			{
				additionalSpriteRenderers[j].material.SetColor(Tint, value);
			}
		}
	}

	public Color customFlashColor;

	public AnimationCurve curve;

	public SpriteRenderer flashableSprite;

	public List<SpriteRenderer> additionalFlashableSprites;

	public List<SpriteObject> spriteObjects;

	[FormerlySerializedAs("meshRenderers")]
	public List<Renderer> renderers;

	private TimerSimple cooldown;

	private Effect currentEffect;

	private static readonly int Tint = Shader.PropertyToID("_Tint");

	private static readonly int FlashAmount = Shader.PropertyToID("_FlashAmount");

	private static readonly int MultiplyFlashTintWithLight = Shader.PropertyToID("_MultiplyFlashTintWithLight");

	private static readonly int FlashColor = Shader.PropertyToID("_FlashColor");

	public FlashEffect flashEffect { get; private set; }

	public BlinkEffect blinkEffect { get; private set; }

	public FlashBlinkEffect flashBlinkEffect { get; private set; }

	public bool isRunning => cooldown.isRunning;

	public void Awake()
	{
		cooldown = default(TimerSimple);
		if (spriteObjects == null || spriteObjects.Count == 0)
		{
			SpriteObject component = base.gameObject.GetComponent<SpriteObject>();
			if (component != null)
			{
				spriteObjects = new List<SpriteObject>();
				spriteObjects.Add(component);
			}
		}
		if (additionalFlashableSprites == null)
		{
			additionalFlashableSprites = new List<SpriteRenderer>();
		}
		flashEffect = new FlashEffect
		{
			sprite = flashableSprite,
			spriteObjects = spriteObjects,
			renderers = renderers,
			additionalSpriteRenderers = additionalFlashableSprites,
			curve = curve,
			defaultCurve = curve
		};
		blinkEffect = new BlinkEffect
		{
			sprite = flashableSprite,
			spriteObjects = spriteObjects,
			renderers = renderers,
			additionalSpriteRenderers = additionalFlashableSprites
		};
		flashBlinkEffect = new FlashBlinkEffect
		{
			sprite = flashableSprite,
			spriteObjects = spriteObjects,
			renderers = renderers,
			additionalSpriteRenderers = additionalFlashableSprites
		};
		base.enabled = false;
	}

	public void LateUpdate()
	{
		if (cooldown.isTimerElapsed)
		{
			CancelAndStopEffect();
		}
		else
		{
			currentEffect.Update();
		}
	}

	public void CancelAndStopEffect()
	{
		currentEffect?.Cancel();
		currentEffect = null;
		cooldown.Stop();
		base.enabled = false;
	}

	private void StartEffect(Effect effect, float duration)
	{
		CancelAndStopEffect();
		currentEffect = effect;
		currentEffect.Start(duration);
		cooldown.Start(duration);
		base.enabled = true;
	}

	public void FlashLinearNoCurve(float duration = 0.15f)
	{
		FlashLinearNoCurve(customFlashColor, duration);
	}

	public void FlashLinearNoCurve(Color flashColor, float duration = 0.15f)
	{
		flashEffect.flashColor = flashColor;
		flashEffect.useCurve = false;
		flashEffect.curve = flashEffect.defaultCurve;
		flashEffect.multiplyFlashTintWithLight = -1;
		StartEffect(flashEffect, duration);
	}

	public void Flash(float duration = 0.15f)
	{
		Flash(flashEffect.defaultCurve, customFlashColor, duration);
	}

	public void Flash(Color flashColor, float duration = 0.15f)
	{
		Flash(flashEffect.defaultCurve, flashColor, duration);
	}

	public void Flash(AnimationCurve curveToUse, Color flashColor, float duration = 0.15f, int multiplyFlashTintWithLight = -1)
	{
		flashEffect.flashColor = flashColor;
		flashEffect.useCurve = true;
		flashEffect.curve = curveToUse;
		flashEffect.multiplyFlashTintWithLight = multiplyFlashTintWithLight;
		StartEffect(flashEffect, duration);
	}

	public void Blink(int framesOn = 2, int framesOff = 2, float duration = 0.5f)
	{
		blinkEffect.framesOn = framesOn;
		blinkEffect.framesOff = framesOff;
		StartEffect(blinkEffect, duration);
	}

	public void FlashBlink(Color flashColor, int rate = 4, float duration = 0.5f)
	{
		flashBlinkEffect.flashColor = flashColor;
		flashBlinkEffect.rate = rate;
		flashBlinkEffect.multiplyFlashTintWithLight = -1;
		StartEffect(flashBlinkEffect, duration);
	}

	private void FlashCustomColor(float duration = 0.15f)
	{
		FlashLinearNoCurve(duration);
	}

	private void FlashCurveCustomColor(float duration = 0.15f)
	{
		Flash(flashEffect.defaultCurve, customFlashColor, duration);
	}
}
