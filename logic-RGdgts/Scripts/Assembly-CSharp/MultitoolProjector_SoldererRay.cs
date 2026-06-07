using DG.Tweening;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class MultitoolProjector_SoldererRay : MonoBehaviour
{
	public enum EditMode
	{
		Solder = 0,
		Unsolder = 1
	}

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

	public AnimationCurve movingDotCurve;

	private Vector3 movingDotStart;

	private Vector3 movingDotEnd;

	private Color boundsColor;

	private float isOn;

	private float startShowEditTime;

	public bool isVisible { get; private set; }

	private void Awake()
	{
	}

	public void SetBounds(Bounds bounds)
	{
	}

	private void RefreshBounds()
	{
	}

	public void ShowEdit(EditMode editMode)
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
