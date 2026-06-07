using UnityEngine;

public class MotorIngredientItem : Item, IPayable
{
	public enum Type
	{
		Fuel = 0,
		Oxidizer = 1
	}

	public GameObject itemPrefab;

	public Type ingredType;

	public int requiredGram;

	public float mass;

	public float thrustPow;

	public float duration;

	public Material propellentMat;

	public Color colr;

	public GameObject pourEffect;

	public Transform pourEffectPos;

	public GameObject pourObject;

	public float spawnRate;

	[SerializeField]
	private Renderer powderRenderer;

	public AnimationCurve curve;

	private MaterialPropertyBlock mpb;

	public bool isPayed { get; set; }

	private void Awake()
	{
		if (powderRenderer != null)
		{
			mpb = new MaterialPropertyBlock();
		}
	}

	private void Start()
	{
		outLine = GetComponent<Outline>();
		if (outLine != null)
		{
			outLine.enabled = false;
		}
		canGrab = true;
		isPayed = false;
	}

	public bool IsPayed()
	{
		return isPayed;
	}

	public override void Interact()
	{
		if (canGrab)
		{
			ShoppingBag component;
			if (GameManager.S.player.itemOnHand == null)
			{
				GameManager.S.player.GrabItem(base.gameObject);
			}
			else if (GameManager.S.player.itemOnHand.TryGetComponent<ShoppingBag>(out component))
			{
				component.PutAliveItemIntheBag(base.gameObject);
			}
			else
			{
				TryGrabItemWhenCannot();
			}
		}
	}

	public void SetPowderColor(Color colr)
	{
		powderRenderer.GetPropertyBlock(mpb);
		mpb.SetColor("_Colour", colr);
		mpb.SetColor("_TopColor", colr);
		mpb.SetColor("_FoamLineColor", colr);
		mpb.SetColor("_RimColor", colr);
		powderRenderer.SetPropertyBlock(mpb);
	}
}
