using NaughtyAttributes;
using UnityEngine;

public class AnimatedTextureController : MonoBehaviour
{
	public enum SpecialCase
	{
		fireSmoke = 0
	}

	[Header("Components")]
	public Renderer animatedRenderer;

	[Header("Settings")]
	[Tooltip("How long it takes the animation to complete")]
	public float animationCycleTime;

	[Tooltip("Count of X/Y frames within the base texture.")]
	public Vector2 texTileCount;

	[Tooltip("Play this when active")]
	public bool playOnStart;

	[Tooltip("Destroy self on end")]
	public bool destroyOnEnd;

	[Tooltip("Destroy if inactive")]
	public bool destroyIfInactive;

	[Tooltip("Always face the camera")]
	[Header("Billboarding")]
	public bool billboardingOn;

	[EnableIf("billboardingOn")]
	[Tooltip("Only face towards camera when the animation starts playing...")]
	public bool faceOnStartOnly;

	[EnableIf("billboardingOn")]
	public SpecialCase specialCase;

	[Header("Extra VFX")]
	public bool alterEmission;

	[ColorUsage(true, true)]
	public Color startingEmission;

	[ColorUsage(true, true)]
	public Color midEmission;

	[ColorUsage(true, true)]
	public Color endEmission;

	[Space(5f)]
	public bool alterScale;

	public Transform parentScaleTransform;

	public AnimationCurve scaleX;

	public AnimationCurve scaleY;

	public AnimationCurve scaleZ;

	[Header("Audio")]
	public AudioEvent triggerAudio;

	public bool useSpeedOfSound;

	[Header("State")]
	private float animtionTimer;

	public float animationProgress;

	public bool isPlaying;

	public bool loop;

	public float nextFrameTimer;

	public int spriteCursorX;

	public int spriteCursorY;

	[Button(null, EButtonEnableMode.Always)]
	public virtual void Play()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public virtual void Stop()
	{
	}

	private void OnDisable()
	{
	}

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	private void Update()
	{
	}

	private void Billboard()
	{
	}

	protected virtual void ApplyOffset(Vector2 offset)
	{
	}

	protected virtual void ApplyScale(Vector2 scale)
	{
	}
}
