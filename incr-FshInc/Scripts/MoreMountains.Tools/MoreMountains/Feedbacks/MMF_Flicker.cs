using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Serialization;

namespace MoreMountains.Feedbacks
{
	[AddComponentMenu("")]
	[FeedbackHelp("This feedback lets you flicker the color of a specified renderer (sprite, mesh, etc) for a certain duration, at the specified octave, and with the specified color. Useful when a character gets hit, for example (but so much more!).")]
	[MovedFrom(false, null, "MoreMountains.Feedbacks", null)]
	[FeedbackPath("Renderer/Flicker")]
	public class MMF_Flicker : MMF_Feedback
	{
		public enum Modes
		{
			Color = 0,
			PropertyName = 1
		}

		public static bool FeedbackTypeAuthorized = true;

		[MMFInspectorGroup("Flicker", true, 61, true, false)]
		[Tooltip("the renderer to flicker when played")]
		public Renderer BoundRenderer;

		[Tooltip("more renderers to flicker when played")]
		public List<Renderer> ExtraBoundRenderers;

		[Tooltip("the selected mode to flicker the renderer")]
		public Modes Mode;

		[MMFEnumCondition("Mode", new int[] { 1 })]
		[Tooltip("the name of the property to target")]
		public string PropertyName = "_Tint";

		[Tooltip("the duration of the flicker when getting damage")]
		public float FlickerDuration = 0.2f;

		[Tooltip("the duration of the period for the flicker")]
		[FormerlySerializedAs("FlickerOctave")]
		public float FlickerPeriod = 0.04f;

		[Tooltip("the color we should flicker the sprite to")]
		[ColorUsage(true, true)]
		public Color FlickerColor = new Color32(byte.MaxValue, 20, 20, byte.MaxValue);

		[Tooltip("the list of material indexes we want to flicker on the target renderer. If left empty, will only target the material at index 0")]
		public int[] MaterialIndexes;

		[Tooltip("if this is true, this component will use material property blocks instead of working on an instance of the material.")]
		public bool UseMaterialPropertyBlocks;

		[Tooltip("if using material property blocks on a sprite renderer, you'll want to make sure the sprite texture gets passed to the block when updating it. For that, you need to specify your sprite's material's shader's texture property name. If you're not working with a sprite renderer, you can safely ignore this.")]
		[MMCondition("UseMaterialPropertyBlocks", true)]
		public string SpriteRendererTextureProperty = "_MainTex";

		protected const string _colorPropertyName = "_Color";

		protected int[] _propertyIDs;

		protected bool[] _propertiesFound;

		protected bool _spriteRendererIsNull;

		protected Coroutine[] _coroutines;

		protected List<Coroutine[]> _extraCoroutines;

		protected Color[] _initialFlickerColors;

		protected List<Color[]> _extraInitialFlickerColors;

		protected MaterialPropertyBlock _propertyBlock;

		protected List<MaterialPropertyBlock> _extraPropertyBlocks;

		protected SpriteRenderer _spriteRenderer;

		protected List<SpriteRenderer> _spriteRenderers;

		protected Texture2D _spriteRendererTexture;

		protected List<Texture2D> _spriteRendererTextures;

		public override bool HasAutomatedTargetAcquisition => true;

		public override float FeedbackDuration
		{
			get
			{
				return ApplyTimeMultiplier(FlickerDuration);
			}
			set
			{
				FlickerDuration = value;
			}
		}

		protected override void AutomateTargetAcquisition()
		{
			BoundRenderer = FindAutomatedTarget<Renderer>();
		}

		protected override void CustomInitialization(MMF_Player owner)
		{
			if (MaterialIndexes == null)
			{
				MaterialIndexes = Array.Empty<int>();
			}
			if (ExtraBoundRenderers == null)
			{
				ExtraBoundRenderers = new List<Renderer>();
			}
			if (MaterialIndexes.Length == 0)
			{
				MaterialIndexes = new int[1];
				MaterialIndexes[0] = 0;
			}
			_coroutines = new Coroutine[MaterialIndexes.Length];
			_initialFlickerColors = new Color[MaterialIndexes.Length];
			_extraCoroutines = new List<Coroutine[]>();
			_extraInitialFlickerColors = new List<Color[]>();
			foreach (Renderer extraBoundRenderer in ExtraBoundRenderers)
			{
				_ = extraBoundRenderer;
				_extraCoroutines.Add(new Coroutine[MaterialIndexes.Length]);
				_extraInitialFlickerColors.Add(new Color[MaterialIndexes.Length]);
			}
			_propertyIDs = new int[MaterialIndexes.Length];
			_propertiesFound = new bool[MaterialIndexes.Length];
			_propertyBlock = new MaterialPropertyBlock();
			AcquireRenderers(owner);
			StoreSpriteRendererTexture();
			for (int i = 0; i < MaterialIndexes.Length; i++)
			{
				_propertiesFound[i] = false;
				int num = MaterialIndexes[i];
				if (!Active || !(BoundRenderer != null))
				{
					continue;
				}
				if (Mode == Modes.Color)
				{
					_propertiesFound[i] = (UseMaterialPropertyBlocks ? BoundRenderer.sharedMaterials[num].HasProperty("_Color") : BoundRenderer.materials[num].HasProperty("_Color"));
					if (!_propertiesFound[i])
					{
						continue;
					}
					_initialFlickerColors[i] = (UseMaterialPropertyBlocks ? BoundRenderer.sharedMaterials[num].color : BoundRenderer.materials[num].color);
					foreach (Renderer extraBoundRenderer2 in ExtraBoundRenderers)
					{
						_extraInitialFlickerColors[ExtraBoundRenderers.IndexOf(extraBoundRenderer2)][i] = (UseMaterialPropertyBlocks ? extraBoundRenderer2.sharedMaterials[num].color : extraBoundRenderer2.materials[num].color);
					}
					continue;
				}
				_propertiesFound[i] = (UseMaterialPropertyBlocks ? BoundRenderer.sharedMaterials[num].HasProperty(PropertyName) : BoundRenderer.materials[num].HasProperty(PropertyName));
				if (!_propertiesFound[i])
				{
					continue;
				}
				_propertyIDs[i] = Shader.PropertyToID(PropertyName);
				_initialFlickerColors[i] = (UseMaterialPropertyBlocks ? BoundRenderer.sharedMaterials[num].GetColor(_propertyIDs[i]) : BoundRenderer.materials[num].GetColor(_propertyIDs[i]));
				foreach (Renderer extraBoundRenderer3 in ExtraBoundRenderers)
				{
					_extraInitialFlickerColors[ExtraBoundRenderers.IndexOf(extraBoundRenderer3)][i] = (UseMaterialPropertyBlocks ? extraBoundRenderer3.sharedMaterials[num].GetColor(_propertyIDs[i]) : extraBoundRenderer3.materials[num].GetColor(_propertyIDs[i]));
				}
			}
		}

		protected virtual void AcquireRenderers(MMF_Player owner)
		{
			if (Active && BoundRenderer == null && owner != null)
			{
				if (Owner.gameObject.MMFGetComponentNoAlloc<Renderer>() != null)
				{
					BoundRenderer = owner.GetComponent<Renderer>();
				}
				if (BoundRenderer == null)
				{
					BoundRenderer = owner.GetComponentInChildren<Renderer>();
				}
			}
			if (BoundRenderer == null)
			{
				Debug.LogWarning("[Flicker Feedback] The flicker feedback on " + Owner.name + " doesn't have a bound renderer, it won't work. You need to specify a renderer to flicker in its inspector.");
			}
			if (BoundRenderer != null)
			{
				_spriteRenderer = BoundRenderer.GetComponent<SpriteRenderer>();
			}
			_spriteRenderers = new List<SpriteRenderer>();
			foreach (Renderer extraBoundRenderer in ExtraBoundRenderers)
			{
				if (extraBoundRenderer.GetComponent<SpriteRenderer>() != null)
				{
					_spriteRenderers.Add(extraBoundRenderer.GetComponent<SpriteRenderer>());
				}
			}
			_spriteRendererIsNull = _spriteRenderer == null;
		}

		protected virtual void StoreSpriteRendererTexture()
		{
			if (!_spriteRendererIsNull)
			{
				_spriteRendererTexture = _spriteRenderer.sprite.texture;
				_spriteRendererTextures = new List<Texture2D>();
				for (int i = 0; i < ExtraBoundRenderers.Count; i++)
				{
					_spriteRendererTextures.Add(_spriteRenderers[i].sprite.texture);
				}
			}
		}

		protected override void CustomPlayFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized || BoundRenderer == null)
			{
				return;
			}
			for (int i = 0; i < MaterialIndexes.Length; i++)
			{
				if (_coroutines[i] != null)
				{
					Owner.StopCoroutine(_coroutines[i]);
				}
				_coroutines[i] = Owner.StartCoroutine(Flicker(BoundRenderer, i, _initialFlickerColors[i], FlickerColor, FlickerPeriod, FeedbackDuration));
				for (int j = 0; j < ExtraBoundRenderers.Count; j++)
				{
					_extraCoroutines[j][i] = Owner.StartCoroutine(Flicker(ExtraBoundRenderers[j], i, _extraInitialFlickerColors[j][i], FlickerColor, FlickerPeriod, FeedbackDuration));
				}
			}
		}

		protected override void CustomReset()
		{
			base.CustomReset();
			if (InCooldown)
			{
				return;
			}
			if (Active && FeedbackTypeAuthorized && BoundRenderer != null)
			{
				for (int i = 0; i < MaterialIndexes.Length; i++)
				{
					SetColor(BoundRenderer, i, _initialFlickerColors[i]);
				}
			}
			foreach (Renderer extraBoundRenderer in ExtraBoundRenderers)
			{
				for (int j = 0; j < MaterialIndexes.Length; j++)
				{
					SetColor(extraBoundRenderer, j, _extraInitialFlickerColors[ExtraBoundRenderers.IndexOf(extraBoundRenderer)][j]);
				}
			}
		}

		protected virtual void SetStoredSpriteRendererTexture(Renderer renderer, MaterialPropertyBlock block)
		{
			if (!_spriteRendererIsNull)
			{
				if (renderer == BoundRenderer)
				{
					block.SetTexture(SpriteRendererTextureProperty, _spriteRendererTexture);
				}
				else
				{
					block.SetTexture(SpriteRendererTextureProperty, _spriteRendererTextures[ExtraBoundRenderers.IndexOf(renderer)]);
				}
			}
		}

		public virtual IEnumerator Flicker(Renderer renderer, int materialIndex, Color initialColor, Color flickerColor, float flickerSpeed, float flickerDuration)
		{
			if (!(renderer == null) && _propertiesFound[materialIndex] && !(initialColor == flickerColor))
			{
				float flickerStop = FeedbackTime + flickerDuration;
				IsPlaying = true;
				StoreSpriteRendererTexture();
				while (FeedbackTime < flickerStop)
				{
					SetColor(renderer, materialIndex, flickerColor);
					yield return WaitFor(flickerSpeed);
					SetColor(renderer, materialIndex, initialColor);
					yield return WaitFor(flickerSpeed);
				}
				SetColor(renderer, materialIndex, initialColor);
				IsPlaying = false;
			}
		}

		protected virtual void SetColor(Renderer renderer, int materialIndex, Color color)
		{
			if (!_propertiesFound[materialIndex])
			{
				return;
			}
			if (Mode == Modes.Color)
			{
				if (UseMaterialPropertyBlocks)
				{
					renderer.GetPropertyBlock(_propertyBlock, MaterialIndexes[materialIndex]);
					_propertyBlock.SetColor("_Color", color);
					SetStoredSpriteRendererTexture(renderer, _propertyBlock);
					renderer.SetPropertyBlock(_propertyBlock, MaterialIndexes[materialIndex]);
				}
				else
				{
					renderer.materials[MaterialIndexes[materialIndex]].color = color;
				}
			}
			else if (UseMaterialPropertyBlocks)
			{
				renderer.GetPropertyBlock(_propertyBlock, MaterialIndexes[materialIndex]);
				_propertyBlock.SetColor(_propertyIDs[materialIndex], color);
				SetStoredSpriteRendererTexture(renderer, _propertyBlock);
				renderer.SetPropertyBlock(_propertyBlock, MaterialIndexes[materialIndex]);
			}
			else
			{
				renderer.materials[MaterialIndexes[materialIndex]].SetColor(_propertyIDs[materialIndex], color);
			}
		}

		protected override void CustomStopFeedback(Vector3 position, float feedbacksIntensity = 1f)
		{
			if (!Active || !FeedbackTypeAuthorized)
			{
				return;
			}
			base.CustomStopFeedback(position, feedbacksIntensity);
			IsPlaying = false;
			for (int i = 0; i < _coroutines.Length; i++)
			{
				if (_coroutines[i] != null)
				{
					Owner.StopCoroutine(_coroutines[i]);
				}
				_coroutines[i] = null;
			}
			foreach (Renderer extraBoundRenderer in ExtraBoundRenderers)
			{
				for (int j = 0; j < MaterialIndexes.Length; j++)
				{
					if (_extraCoroutines[ExtraBoundRenderers.IndexOf(extraBoundRenderer)][j] != null)
					{
						Owner.StopCoroutine(_extraCoroutines[ExtraBoundRenderers.IndexOf(extraBoundRenderer)][j]);
					}
					_extraCoroutines[ExtraBoundRenderers.IndexOf(extraBoundRenderer)][j] = null;
				}
			}
		}

		protected override void CustomRestoreInitialValues()
		{
			if (Active && FeedbackTypeAuthorized)
			{
				CustomReset();
			}
		}
	}
}
