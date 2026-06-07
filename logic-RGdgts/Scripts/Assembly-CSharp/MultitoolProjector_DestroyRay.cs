using DG.Tweening;
using SE.EvilLib.AudioManager;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MultitoolProjector_DestroyRay : MonoBehaviour
{
	public Transform dot;

	public Light2D dotLight;

	public SpriteRenderer dotSprite;

	public SpriteRenderer lineSprite1;

	public SpriteRenderer lineSprite2;

	public Light2D lineLight1;

	public Light2D lineLight2;

	public float showTime;

	public float hideTime;

	public Ease dotSpriteShowEase;

	public Ease dotSpriteHideEase;

	private float dotLightIntensity;

	private Sequence tween;

	private Material lineMaterial;

	private float dotScaleY;

	private PlayingSound loopSound;

	public bool isVisible { get; private set; }

	private Vector3 min => default(Vector3);

	private Vector3 max => default(Vector3);

	private void Awake()
	{
	}

	public void SetPosition(Vector3 position, float width)
	{
	}

	public void Show()
	{
	}

	public void Hide()
	{
	}

	private void Update()
	{
	}
}
