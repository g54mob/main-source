using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Tools
{
	[MMRequiresConstantRepaint]
	[AddComponentMenu("More Mountains/Tools/Property Controllers/Shader Controller")]
	public class ShaderController : MMMonoBehaviour
	{
		public enum TargetTypes
		{
			Renderer = 0,
			Image = 1,
			RawImage = 2,
			Text = 3
		}

		public enum PropertyTypes
		{
			Bool = 0,
			Float = 1,
			Int = 2,
			Vector = 3,
			Keyword = 4,
			Color = 5
		}

		public enum ControlModes
		{
			PingPong = 0,
			Random = 1,
			OneTime = 2,
			AudioAnalyzer = 3,
			ToDestination = 4,
			Driven = 5,
			Loop = 6
		}

		public enum ColorModes
		{
			TwoColors = 0,
			ColorRamp = 1
		}

		[Header("Target")]
		[Tooltip("the type of renderer to pilot")]
		public TargetTypes TargetType;

		[Tooltip("the renderer with the shader you want to control")]
		[MMEnumCondition("TargetType", new int[] { 0 })]
		public Renderer TargetRenderer;

		[Tooltip("the ID of the material in the Materials array on the target renderer (usually 0)")]
		[MMEnumCondition("TargetType", new int[] { 0 })]
		public int TargetMaterialID;

		[Tooltip("the Image with the shader you want to control")]
		[MMEnumCondition("TargetType", new int[] { 1 })]
		public Image TargetImage;

		[Tooltip("if this is true, the 'materialForRendering' for this Image will be used, instead of the regular material")]
		[MMEnumCondition("TargetType", new int[] { 1 })]
		public bool UseMaterialForRendering;

		[Tooltip("the RawImage with the shader you want to control")]
		[MMEnumCondition("TargetType", new int[] { 2 })]
		public RawImage TargetRawImage;

		[Tooltip("the Text with the shader you want to control")]
		[MMEnumCondition("TargetType", new int[] { 3 })]
		public Text TargetText;

		[Tooltip("if this is true, material will be cached on Start")]
		public bool CacheMaterial = true;

		[Tooltip("if this is true, an instance of the material will be created on start so that this controller only affects its target")]
		public bool CreateMaterialInstance;

		[Tooltip("the EXACT name of the property to affect")]
		public string TargetPropertyName;

		[Tooltip("the type of the property to affect")]
		public PropertyTypes PropertyType = PropertyTypes.Float;

		[Tooltip("whether or not to affect its x component")]
		[MMEnumCondition("PropertyType", new int[] { 3 })]
		public bool X;

		[Tooltip("whether or not to affect its y component")]
		[MMEnumCondition("PropertyType", new int[] { 3 })]
		public bool Y;

		[Tooltip("whether or not to affect its z component")]
		[MMEnumCondition("PropertyType", new int[] { 3 })]
		public bool Z;

		[Tooltip("whether or not to affect its w component")]
		[MMEnumCondition("PropertyType", new int[] { 3 })]
		public bool W;

		[Header("Color")]
		[Tooltip("whether to move from a color to another, or to evalute colors on a ramp")]
		public ColorModes ColorMode;

		[Tooltip("the ramp along which to lerp when in ramp color mode")]
		[GradientUsage(true)]
		public Gradient ColorRamp;

		[Tooltip("the color to lerp from")]
		[ColorUsage(true, true)]
		public Color FromColor = Color.black;

		[Tooltip("the color to lerp to")]
		[ColorUsage(true, true)]
		public Color ToColor = Color.white;

		[Header("Global Settings")]
		[Tooltip("the control mode (ping pong or random)")]
		public ControlModes ControlMode;

		[Tooltip("whether or not the updated value should be added to the initial one")]
		public bool AddToInitialValue;

		[Tooltip("whether or not to use unscaled time")]
		public bool UseUnscaledTime = true;

		[Tooltip("whether or not you want to revert to the InitialValue after the control ends")]
		public bool RevertToInitialValueAfterEnd = true;

		[Tooltip("if this is true, this component will use material property blocks instead of working on an instance of the material.")]
		[MMEnumCondition("TargetType", new int[] { 0 })]
		public bool UseMaterialPropertyBlocks;

		[Tooltip("if using material property blocks on a sprite renderer, you'll want to make sure the sprite texture gets passed to the block when updating it. For that, you need to specify your sprite's material's shader's texture property name. If you're not working with a sprite renderer, you can safely ignore this.")]
		[MMCondition("UseMaterialPropertyBlocks", true)]
		public string SpriteRendererTextureProperty = "_MainTex";

		[Tooltip("whether or not to perform extra safety checks (safer, more costly)")]
		public bool SafeMode;

		[Header("Ping Pong")]
		[Tooltip("the curve to apply to the tween")]
		public MMTweenType Curve;

		[Tooltip("the minimum value for the ping pong")]
		public float MinValue;

		[Tooltip("the maximum value for the ping pong")]
		public float MaxValue = 5f;

		[Tooltip("the duration of one ping (or pong)")]
		public float Duration = 1f;

		[Tooltip("the duration of the pause between two ping (or pongs) (in seconds)")]
		public float PingPongPauseDuration = 1f;

		[Header("Loop")]
		[Tooltip("the curve to apply to the tween")]
		public MMTweenType LoopCurve;

		[Tooltip("the start value for the loop tween")]
		public float LoopStartValue;

		[Tooltip("the end value for the loop tween")]
		public float LoopEndValue = 5f;

		[Tooltip("the duration of one loop")]
		public float LoopDuration = 1f;

		[Tooltip("the duration of the pause between two loops (in seconds)")]
		public float LoopPauseDuration = 1f;

		[Header("Driven")]
		[Tooltip("the value that will be applied to the controlled float in driven mode")]
		public float DrivenLevel;

		[Header("Random")]
		[Tooltip("the noise amplitude")]
		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 Amplitude = new Vector2(0f, 5f);

		[Tooltip("the noise frequency")]
		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 Frequency = new Vector2(1f, 1f);

		[Tooltip("the noise shift")]
		[MMVector(new string[] { "Min", "Max" })]
		public Vector2 Shift = new Vector2(0f, 1f);

		[Tooltip("if this is true, will let you remap the noise value (without amplitude) to the bounds you've specified")]
		public bool RemapNoiseValues;

		[Tooltip("the value to which to remap the random's zero bound")]
		[MMCondition("RemapNoiseValues", true)]
		public float RemapNoiseZero;

		[Tooltip("the value to which to remap the random's one bound")]
		[MMCondition("RemapNoiseValues", true)]
		public float RemapNoiseOne = 1f;

		[Header("OneTime")]
		[Tooltip("the duration of the One Time shake")]
		public float OneTimeDuration = 1f;

		[Tooltip("the amplitude of the One Time shake (this will be multiplied by the curve's height)")]
		public float OneTimeAmplitude = 1f;

		[Tooltip("the low value to remap the normalized curve value to")]
		public float OneTimeRemapMin;

		[Tooltip("the high value to remap the normalized curve value to")]
		public float OneTimeRemapMax = 1f;

		[Tooltip("the curve to apply to the one time shake")]
		public AnimationCurve OneTimeCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f));

		[MMInspectorButton("OneTime")]
		[Tooltip("a test button for the one time shake")]
		public bool OneTimeButton;

		[Tooltip("whether or not this controller should go back to sleep after a OneTime")]
		public bool DisableAfterOneTime;

		[Tooltip("whether or not this controller should go back to sleep after a OneTime")]
		public bool DisableGameObjectAfterOneTime;

		[Tooltip("whether or not to initialize the initial value to the current value on a OneTime play")]
		public bool GetInitialValueOnOneTime;

		[Header("AudioAnalyzer")]
		[Tooltip("the bound audio analyzer used to drive this controller")]
		public MMAudioAnalyzer AudioAnalyzer;

		[Tooltip("the ID of the selected beat on the analyzer")]
		public int BeatID;

		[Tooltip("the multiplier to apply to the value out of the analyzer")]
		public float AudioAnalyzerMultiplier = 1f;

		[Tooltip("the offset to apply to the value out of the analyzer")]
		public float AudioAnalyzerOffset;

		[Tooltip("the speed at which to lerp the value")]
		public float AudioAnalyzerLerp = 60f;

		[Header("ToDestination")]
		[Tooltip("the value to go to when in ToDestination mode")]
		public float ToDestinationValue = 1f;

		[Tooltip("the duration of the ToDestination tween")]
		public float ToDestinationDuration = 1f;

		[Tooltip("the curve to use to tween to the ToDestination value")]
		public AnimationCurve ToDestinationCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.5f, 0.6f), new Keyframe(1f, 1f));

		[Tooltip("a test button for the one time shake")]
		[MMInspectorButton("ToDestination")]
		public bool ToDestinationButton;

		[Tooltip("whether or not this controller should go back to sleep after a OneTime")]
		public bool DisableAfterToDestination;

		[Header("Debug")]
		[Tooltip("the initial value of the controlled float")]
		[MMReadOnly]
		public float InitialValue;

		[Tooltip("the current value of the controlled float")]
		[MMReadOnly]
		public float CurrentValue;

		[Tooltip("the current value of the controlled float, normalized")]
		[MMReadOnly]
		public float CurrentValueNormalized;

		[Tooltip("the current value of the controlled float")]
		[MMReadOnly]
		public Color InitialColor;

		[Tooltip("the ID of the property")]
		[MMReadOnly]
		public int PropertyID;

		[Tooltip("whether or not the property got found")]
		[MMReadOnly]
		public bool PropertyFound;

		[Tooltip("the target material")]
		[MMReadOnly]
		public Material TargetMaterial;

		[HideInInspector]
		public float PingPong;

		[HideInInspector]
		public float LoopTime;

		protected float _randomAmplitude;

		protected float _randomFrequency;

		protected float _randomShift;

		protected float _elapsedTime;

		protected bool _shaking;

		protected float _startedTimestamp;

		protected float _remappedTimeSinceStart;

		protected Color _currentColor;

		protected Vector4 _vectorValue;

		protected float _pingPongDirection = 1f;

		protected float _lastPingPongPauseAt;

		protected float _lastLoopPauseAt;

		protected float _initialValue;

		protected Color _fromColorStorage;

		protected bool _activeLastFrame;

		protected MaterialPropertyBlock _propertyBlock;

		protected SpriteRenderer _spriteRenderer;

		protected Texture2D _spriteRendererTexture;

		protected bool SpriteRendererIsNull;

		public virtual bool FindShaderProperty(string propertyName)
		{
			if (TargetType == TargetTypes.Renderer)
			{
				if (CreateMaterialInstance)
				{
					TargetRenderer.materials[TargetMaterialID] = new Material(TargetRenderer.materials[TargetMaterialID]);
				}
				TargetMaterial = (UseMaterialPropertyBlocks ? TargetRenderer.sharedMaterials[TargetMaterialID] : TargetRenderer.materials[TargetMaterialID]);
			}
			else if (TargetType == TargetTypes.Image)
			{
				if (CreateMaterialInstance)
				{
					TargetImage.material = new Material(TargetImage.material);
				}
				TargetMaterial = TargetImage.material;
			}
			else if (TargetType == TargetTypes.RawImage)
			{
				if (CreateMaterialInstance)
				{
					TargetRawImage.material = new Material(TargetRawImage.material);
				}
				TargetMaterial = TargetRawImage.material;
			}
			else if (TargetType == TargetTypes.Text)
			{
				if (CreateMaterialInstance)
				{
					TargetText.material = new Material(TargetText.material);
				}
				TargetMaterial = TargetText.material;
			}
			if (PropertyType == PropertyTypes.Keyword)
			{
				PropertyFound = true;
				return true;
			}
			if (TargetMaterial.HasProperty(propertyName))
			{
				PropertyID = Shader.PropertyToID(propertyName);
				PropertyFound = true;
				return true;
			}
			return false;
		}

		protected virtual void Awake()
		{
			Initialization();
		}

		protected virtual void OnEnable()
		{
			InitialValue = GetInitialValue();
			if (PropertyType == PropertyTypes.Color)
			{
				InitialColor = TargetMaterial.GetColor(PropertyID);
			}
		}

		protected virtual bool RendererIsNull()
		{
			if (TargetType == TargetTypes.Renderer && TargetRenderer == null)
			{
				return true;
			}
			if (TargetType == TargetTypes.Image && TargetImage == null)
			{
				return true;
			}
			if (TargetType == TargetTypes.RawImage && TargetRawImage == null)
			{
				return true;
			}
			if (TargetType == TargetTypes.Text && TargetText == null)
			{
				return true;
			}
			return false;
		}

		public virtual void Initialization()
		{
			if (RendererIsNull() || string.IsNullOrEmpty(TargetPropertyName))
			{
				return;
			}
			if (TargetType != TargetTypes.Renderer)
			{
				UseMaterialPropertyBlocks = false;
			}
			StoreSpriteRenderer();
			PropertyFound = FindShaderProperty(TargetPropertyName);
			if (PropertyFound)
			{
				_elapsedTime = 0f;
				_randomAmplitude = Random.Range(Amplitude.x, Amplitude.y);
				_randomFrequency = Random.Range(Frequency.x, Frequency.y);
				_randomShift = Random.Range(Shift.x, Shift.y);
				if (TargetType == TargetTypes.Renderer && UseMaterialPropertyBlocks)
				{
					_propertyBlock = new MaterialPropertyBlock();
					TargetRenderer.GetPropertyBlock(_propertyBlock, TargetMaterialID);
				}
				InitialValue = GetInitialValue();
				if (PropertyType == PropertyTypes.Color)
				{
					InitialColor = TargetMaterial.GetColor(PropertyID);
				}
				_shaking = false;
				if (ControlMode == ControlModes.OneTime)
				{
					base.enabled = false;
				}
				StoreSpriteRendererTexture();
			}
		}

		public virtual void StoreSpriteRenderer()
		{
			_spriteRenderer = ((TargetRenderer != null) ? TargetRenderer.GetComponent<SpriteRenderer>() : null);
			SpriteRendererIsNull = _spriteRenderer == null;
		}

		public virtual void StoreSpriteRendererTexture()
		{
			if (!SpriteRendererIsNull)
			{
				_spriteRendererTexture = _spriteRenderer.sprite.texture;
			}
		}

		protected virtual void SetStoredSpriteRendererTexture(MaterialPropertyBlock block)
		{
			if (!SpriteRendererIsNull)
			{
				block.SetTexture(SpriteRendererTextureProperty, _spriteRendererTexture);
			}
		}

		public virtual void SetDrivenLevelAbsolute(float level)
		{
			DrivenLevel = level;
		}

		public virtual void SetDrivenLevelNormalized(float normalizedLevel, float remapZero, float remapOne)
		{
			DrivenLevel = MMMaths.Remap(normalizedLevel, 0f, 1f, remapZero, remapOne);
		}

		public virtual void OneTime()
		{
			if (!CacheMaterial)
			{
				Initialization();
			}
			if (GetInitialValueOnOneTime)
			{
				InitialValue = GetInitialValue();
			}
			if (!RendererIsNull() && PropertyFound)
			{
				base.gameObject.SetActive(value: true);
				base.enabled = true;
				ControlMode = ControlModes.OneTime;
				_startedTimestamp = GetTime();
				_shaking = true;
			}
		}

		public virtual void ToDestination()
		{
			if (!CacheMaterial)
			{
				Initialization();
			}
			if (!RendererIsNull() && PropertyFound)
			{
				base.enabled = true;
				if (PropertyType == PropertyTypes.Color)
				{
					_fromColorStorage = FromColor;
					FromColor = TargetMaterial.GetColor(PropertyID);
				}
				ControlMode = ControlModes.ToDestination;
				_startedTimestamp = GetTime();
				_shaking = true;
				_initialValue = GetInitialValue();
			}
		}

		public void SetFromColor(Color newColor)
		{
			FromColor = newColor;
		}

		public void SetToColor(Color newColor)
		{
			ToColor = newColor;
		}

		public virtual void SetRemapOneTimeMin(float newValue)
		{
			OneTimeRemapMin = newValue;
		}

		public virtual void SetRemapOneTimeMax(float newValue)
		{
			OneTimeRemapMax = newValue;
		}

		public virtual void SetToDestinationValue(float newValue)
		{
			ToDestinationValue = newValue;
		}

		protected float GetDeltaTime()
		{
			if (!UseUnscaledTime)
			{
				return Time.deltaTime;
			}
			return Time.unscaledDeltaTime;
		}

		protected float GetTime()
		{
			if (!UseUnscaledTime)
			{
				return Time.time;
			}
			return Time.unscaledTime;
		}

		protected virtual void Update()
		{
			UpdateValue();
		}

		protected virtual void OnDisable()
		{
			if (RevertToInitialValueAfterEnd)
			{
				CurrentValue = InitialValue;
				_currentColor = InitialColor;
				SetValue(CurrentValue);
			}
		}

		protected virtual void UpdateValue()
		{
			if (SafeMode && (RendererIsNull() || !PropertyFound))
			{
				return;
			}
			switch (ControlMode)
			{
			case ControlModes.PingPong:
				if (GetTime() - _lastPingPongPauseAt < PingPongPauseDuration)
				{
					return;
				}
				PingPong += GetDeltaTime() * _pingPongDirection;
				if (PingPong < 0f)
				{
					PingPong = 0f;
					_pingPongDirection = 0f - _pingPongDirection;
					_lastPingPongPauseAt = GetTime();
				}
				if (PingPong > Duration)
				{
					PingPong = Duration;
					_pingPongDirection = 0f - _pingPongDirection;
					_lastPingPongPauseAt = GetTime();
				}
				CurrentValue = MMTween.Tween(PingPong, 0f, Duration, MinValue, MaxValue, Curve);
				CurrentValueNormalized = MMMaths.Remap(CurrentValue, MinValue, MaxValue, 0f, 1f);
				break;
			case ControlModes.Loop:
				if (GetTime() - _lastLoopPauseAt < LoopPauseDuration)
				{
					return;
				}
				LoopTime += GetDeltaTime();
				if (LoopTime > LoopDuration)
				{
					LoopTime = 0f;
					_lastLoopPauseAt = GetTime();
				}
				CurrentValue = MMTween.Tween(LoopTime, 0f, LoopDuration, LoopStartValue, LoopEndValue, LoopCurve);
				CurrentValueNormalized = MMMaths.Remap(CurrentValue, LoopStartValue, LoopEndValue, 0f, 1f);
				break;
			case ControlModes.Random:
				_elapsedTime += GetDeltaTime();
				CurrentValueNormalized = Mathf.PerlinNoise(_randomFrequency * _elapsedTime, _randomShift);
				if (RemapNoiseValues)
				{
					CurrentValue = CurrentValueNormalized;
					CurrentValue = MMMaths.Remap(CurrentValue, 0f, 1f, RemapNoiseZero, RemapNoiseOne);
				}
				else
				{
					CurrentValue = (CurrentValueNormalized * 2f - 1f) * _randomAmplitude;
				}
				break;
			case ControlModes.AudioAnalyzer:
				CurrentValue = Mathf.Lerp(CurrentValue, AudioAnalyzer.Beats[BeatID].CurrentValue * AudioAnalyzerMultiplier + AudioAnalyzerOffset, AudioAnalyzerLerp * GetDeltaTime());
				CurrentValueNormalized = Mathf.Clamp(AudioAnalyzer.Beats[BeatID].CurrentValue, 0f, 1f);
				break;
			case ControlModes.Driven:
				CurrentValue = DrivenLevel;
				CurrentValueNormalized = Mathf.Clamp(CurrentValue, 0f, 1f);
				break;
			case ControlModes.OneTime:
				if (!_shaking)
				{
					return;
				}
				_remappedTimeSinceStart = MMMaths.Remap(GetTime() - _startedTimestamp, 0f, OneTimeDuration, 0f, 1f);
				CurrentValueNormalized = OneTimeCurve.Evaluate(_remappedTimeSinceStart);
				CurrentValue = MMMaths.Remap(CurrentValueNormalized, 0f, 1f, OneTimeRemapMin, OneTimeRemapMax);
				CurrentValue *= OneTimeAmplitude;
				break;
			case ControlModes.ToDestination:
			{
				if (!_shaking)
				{
					return;
				}
				_remappedTimeSinceStart = MMMaths.Remap(GetTime() - _startedTimestamp, 0f, ToDestinationDuration, 0f, 1f);
				float t = ToDestinationCurve.Evaluate(_remappedTimeSinceStart);
				CurrentValue = Mathf.LerpUnclamped(_initialValue, ToDestinationValue, t);
				CurrentValueNormalized = MMMaths.Remap(CurrentValue, _initialValue, ToDestinationValue, 0f, 1f);
				break;
			}
			}
			if (PropertyType == PropertyTypes.Color)
			{
				if (ColorMode == ColorModes.TwoColors)
				{
					_currentColor = Color.Lerp(FromColor, ToColor, CurrentValue);
				}
				else
				{
					_currentColor = ColorRamp.Evaluate(CurrentValue);
				}
			}
			if (AddToInitialValue)
			{
				CurrentValue += InitialValue;
			}
			if (ControlMode == ControlModes.OneTime && _shaking && GetTime() - _startedTimestamp > OneTimeDuration)
			{
				SetOneTimeFinalValue();
			}
			else if (ControlMode == ControlModes.ToDestination && _shaking && GetTime() - _startedTimestamp > ToDestinationDuration)
			{
				SetToDestinationFinalValue();
			}
			else
			{
				SetValue(CurrentValue);
			}
		}

		public virtual void SetFinalValue()
		{
			switch (ControlMode)
			{
			case ControlModes.OneTime:
				SetOneTimeFinalValue();
				break;
			case ControlModes.ToDestination:
				SetToDestinationFinalValue();
				break;
			}
		}

		protected virtual void SetToDestinationFinalValue()
		{
			_shaking = false;
			FromColor = _fromColorStorage;
			if (RevertToInitialValueAfterEnd)
			{
				CurrentValue = InitialValue;
				if (PropertyType == PropertyTypes.Color)
				{
					_currentColor = InitialColor;
				}
			}
			else
			{
				CurrentValue = ToDestinationValue;
			}
			SetValue(CurrentValue);
			if (DisableAfterToDestination)
			{
				base.enabled = false;
			}
		}

		protected virtual void SetOneTimeFinalValue()
		{
			_shaking = false;
			if (RevertToInitialValueAfterEnd)
			{
				CurrentValue = InitialValue;
				if (PropertyType == PropertyTypes.Color)
				{
					_currentColor = InitialColor;
				}
			}
			else
			{
				CurrentValue = OneTimeCurve.Evaluate(1f);
				CurrentValue = MMMaths.Remap(CurrentValue, 0f, 1f, OneTimeRemapMin, OneTimeRemapMax);
				CurrentValue *= OneTimeAmplitude;
				if (AddToInitialValue)
				{
					CurrentValue += InitialValue;
				}
			}
			SetValue(CurrentValue);
			if (DisableAfterOneTime)
			{
				base.enabled = false;
			}
			if (DisableGameObjectAfterOneTime)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		protected virtual float GetInitialValue()
		{
			if (TargetMaterial == null)
			{
				Debug.LogWarning("Material is null", this);
				return 0f;
			}
			switch (PropertyType)
			{
			case PropertyTypes.Bool:
				return TargetMaterial.GetInt(PropertyID);
			case PropertyTypes.Int:
				return TargetMaterial.GetInt(PropertyID);
			case PropertyTypes.Float:
				return TargetMaterial.GetFloat(PropertyID);
			case PropertyTypes.Vector:
				if (X)
				{
					return TargetMaterial.GetVector(PropertyID).x;
				}
				if (Y)
				{
					return TargetMaterial.GetVector(PropertyID).y;
				}
				if (Z)
				{
					return TargetMaterial.GetVector(PropertyID).z;
				}
				if (W)
				{
					return TargetMaterial.GetVector(PropertyID).w;
				}
				return TargetMaterial.GetVector(PropertyID).x;
			case PropertyTypes.Keyword:
				if (!TargetMaterial.IsKeywordEnabled(TargetPropertyName))
				{
					return 0f;
				}
				return 1f;
			case PropertyTypes.Color:
				if (ControlMode != ControlModes.ToDestination)
				{
					InitialColor = TargetMaterial.GetColor(PropertyID);
				}
				return 0f;
			default:
				return 0f;
			}
		}

		protected virtual void SetValue(float newValue)
		{
			if (TargetType == TargetTypes.Image && UseMaterialForRendering)
			{
				if (SafeMode && TargetImage == null)
				{
					return;
				}
				TargetMaterial = TargetImage.materialForRendering;
			}
			switch (PropertyType)
			{
			case PropertyTypes.Bool:
			{
				newValue = ((newValue > 0f) ? 1f : 0f);
				int value = Mathf.RoundToInt(newValue);
				if (UseMaterialPropertyBlocks)
				{
					if (!(TargetRenderer == null))
					{
						TargetRenderer.GetPropertyBlock(_propertyBlock, TargetMaterialID);
						StoreSpriteRendererTexture();
						_propertyBlock.SetInt(PropertyID, value);
						SetStoredSpriteRendererTexture(_propertyBlock);
						TargetRenderer.SetPropertyBlock(_propertyBlock, TargetMaterialID);
					}
				}
				else
				{
					TargetMaterial.SetInt(PropertyID, value);
				}
				break;
			}
			case PropertyTypes.Keyword:
				newValue = ((newValue > 0f) ? 1f : 0f);
				if (newValue == 0f)
				{
					TargetMaterial.DisableKeyword(TargetPropertyName);
				}
				else
				{
					TargetMaterial.EnableKeyword(TargetPropertyName);
				}
				break;
			case PropertyTypes.Int:
			{
				int value2 = Mathf.RoundToInt(newValue);
				if (UseMaterialPropertyBlocks)
				{
					if (!(TargetRenderer == null))
					{
						TargetRenderer.GetPropertyBlock(_propertyBlock, TargetMaterialID);
						StoreSpriteRendererTexture();
						_propertyBlock.SetInt(PropertyID, value2);
						SetStoredSpriteRendererTexture(_propertyBlock);
						TargetRenderer.SetPropertyBlock(_propertyBlock, TargetMaterialID);
					}
				}
				else
				{
					TargetMaterial.SetInt(PropertyID, value2);
				}
				break;
			}
			case PropertyTypes.Float:
				if (UseMaterialPropertyBlocks)
				{
					if (!(TargetRenderer == null))
					{
						TargetRenderer.GetPropertyBlock(_propertyBlock, TargetMaterialID);
						StoreSpriteRendererTexture();
						_propertyBlock.SetFloat(PropertyID, newValue);
						SetStoredSpriteRendererTexture(_propertyBlock);
						TargetRenderer.SetPropertyBlock(_propertyBlock, TargetMaterialID);
					}
				}
				else
				{
					TargetMaterial.SetFloat(PropertyID, newValue);
				}
				break;
			case PropertyTypes.Vector:
				_vectorValue = TargetMaterial.GetVector(PropertyID);
				if (X)
				{
					_vectorValue.x = newValue;
				}
				if (Y)
				{
					_vectorValue.y = newValue;
				}
				if (Z)
				{
					_vectorValue.z = newValue;
				}
				if (W)
				{
					_vectorValue.w = newValue;
				}
				if (UseMaterialPropertyBlocks)
				{
					if (!(TargetRenderer == null))
					{
						TargetRenderer.GetPropertyBlock(_propertyBlock, TargetMaterialID);
						_propertyBlock.SetVector(PropertyID, _vectorValue);
						SetStoredSpriteRendererTexture(_propertyBlock);
						TargetRenderer.SetPropertyBlock(_propertyBlock, TargetMaterialID);
					}
				}
				else
				{
					TargetMaterial.SetVector(PropertyID, _vectorValue);
				}
				break;
			case PropertyTypes.Color:
				if (UseMaterialPropertyBlocks)
				{
					if (!(TargetRenderer == null))
					{
						TargetRenderer.GetPropertyBlock(_propertyBlock, TargetMaterialID);
						StoreSpriteRendererTexture();
						_propertyBlock.SetColor(PropertyID, _currentColor);
						SetStoredSpriteRendererTexture(_propertyBlock);
						TargetRenderer.SetPropertyBlock(_propertyBlock, TargetMaterialID);
					}
				}
				else
				{
					TargetMaterial.SetColor(PropertyID, _currentColor);
				}
				break;
			}
		}

		public virtual void Stop()
		{
			_shaking = false;
			base.enabled = false;
		}

		public virtual void RestoreInitialValues()
		{
			_currentColor = InitialColor;
			SetValue(InitialValue);
		}
	}
}
