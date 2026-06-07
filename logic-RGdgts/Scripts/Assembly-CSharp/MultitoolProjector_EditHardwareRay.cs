using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MultitoolProjector_EditHardwareRay : MonoBehaviour
{
	public Transform[] dots;

	public SpriteRenderer[] lineSprites;

	public Light2D[] lineLights;

	public Light2D editLight;

	public Light2D editSceneLight;

	public SpriteRenderer editLightMask;

	public SpriteRenderer boundsRenderer;

	public float showTime;

	public float hideTime;

	public Ease dotSpriteShowEase;

	public Ease dotSpriteHideEase;

	public Ease editLightEase;

	public float editLightTime;

	public float editLightDelay;

	public float editLightIntensity;

	private Sequence showTween;

	private Sequence editTween;

	private Material[] lineMaterials;

	private Material boundsMaterial;

	private Material movingDotMaterial;

	private float editLightBaseIntensity;

	private Bounds bounds;

	private float showEditI;

	private Color boundsColor;

	public AnimationCurve movingDotCurve;

	private float isOn;

	private float startShowEditTime;

	public bool isVisible { get; private set; }

	private void Awake()
	{
	}

	public void SetBounds(Bounds bounds)
	{
	}

	public void ShowEdit()
	{
	}

	public void Show()
	{
	}

	public void Hide()
	{
	}

	private void LateUpdate()
	{
	}
}
