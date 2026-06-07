using DG.Tweening;
using SE.EvilLib.AudioManager;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MultitoolProjector_PrintRay : MonoBehaviour
{
	public Transform dot;

	public Light2D dotLight;

	public SpriteRenderer dotSprite;

	public SpriteRenderer lineSprite;

	public Light2D lineLight;

	public float showTime;

	public float hideTime;

	public Ease dotSpriteShowEase;

	public Ease dotSpriteHideEase;

	private float dotLightIntensity;

	private Sequence tween;

	private Material lineMaterial;

	private PlayingSound loopSound;

	public bool isVisible { get; private set; }

	private void Awake()
	{
	}

	public void SetPosition(Vector3 position)
	{
	}

	public void Show(bool immediate = false)
	{
	}

	public void Hide()
	{
	}

	private void Update()
	{
	}
}
