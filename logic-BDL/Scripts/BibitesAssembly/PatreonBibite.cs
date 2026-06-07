using System;
using ManagementScripts.SceneManagers;
using SimulationScripts.BibiteScripts;
using TMPro;
using UnityEngine;

public class PatreonBibite : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer sr;

	[SerializeField]
	private BibiteProceduralSpriter proc;

	[SerializeField]
	private BibiteGenes genes;

	[SerializeField]
	private Rigidbody2D rb;

	[SerializeField]
	private TextMeshProUGUI nameText;

	[SerializeField]
	private FieldOfView fow;

	private Material mat;

	public PatreonTier tier;

	public string patron;

	private float hurt;

	private float speed = 450f;

	private float health = 100f;

	private static readonly int Hurt = Shader.PropertyToID("_HurtAmount");

	private void Start()
	{
		fow.viewAngle = 180f;
		fow.viewRadius = 150f;
		fow.StartSeeing(int.MaxValue);
	}

	public void InitializePatron(PatreonInfo patronInfo)
	{
		tier = patronInfo.tier;
		if (tier == PatreonTier.RockStar)
		{
			base.transform.localScale = 1.5f * Vector3.one;
		}
		if (tier == PatreonTier.Carnivore)
		{
			base.transform.localScale = 1.25f * Vector3.one;
		}
		patron = patronInfo.name;
		nameText.text = patron;
		if (patronInfo.image != null)
		{
			sr.sprite = patronInfo.image;
			mat = sr.material;
		}
		else
		{
			genes.RandomGenes();
			genes.genes[16] = UnityEngine.Random.Range(0f, 5f);
			float num = UnityEngine.Random.Range(0.5f, 1.5f);
			genes.genes[3] = num;
			base.transform.localScale = Mathf.Sqrt(num) * Vector3.one;
			proc.InitSprites();
			proc.SpriteChangeFromGrowth(1f);
			rb.mass = 2f * num;
			mat = proc.RequestSkinMaterial();
		}
		speed *= base.transform.localScale.x;
	}

	private void Update()
	{
		if (!(hurt <= 0f))
		{
			hurt *= 1f - 0.9f * Time.deltaTime;
			hurt -= 0.05f * Time.deltaTime;
			mat.SetFloat(Hurt, hurt);
		}
	}

	private void FixedUpdate()
	{
		Vector2 vector = base.transform.up;
		Vector2 simulationBounds = PatreonSimulation.simulationBounds;
		float num = 0f;
		if (Mathf.Abs(base.transform.position.x) > simulationBounds.x || Mathf.Abs(base.transform.position.y) > simulationBounds.y)
		{
			num = Mathf.Max(Mathf.Abs(base.transform.position.x) - simulationBounds.x, Mathf.Abs(base.transform.position.y) - simulationBounds.y) / 100f;
			num = Mathf.Min(num, 1f);
			float num2 = Vector2.SignedAngle(vector, -base.transform.position);
			rb.AddTorque(num * num2 * speed / 10f);
		}
		switch (tier)
		{
		case PatreonTier.Egg:
			rb.AddForce(vector * genes.Gene(BibiteGenes.Genes.SizeRatio) * speed / 3f * (1.05f - fow.pelletConcentrationWeight));
			rb.AddTorque(fow.pelletConcentrationAngle * speed / 10f * genes.Gene(BibiteGenes.Genes.SizeRatio) * (1f - num));
			break;
		case PatreonTier.Herbivore:
			rb.AddForce(vector * speed / 1.5f * (1.05f - fow.pelletConcentrationWeight));
			rb.AddTorque(fow.pelletConcentrationAngle * speed / 2f * (1f - num));
			break;
		case PatreonTier.Carnivore:
			rb.AddForce(vector * speed * (1.05f - fow.bibiteConcentrationWeight - fow.meatConcentrationWeight));
			rb.AddTorque(fow.bibiteConcentrationAngle * speed / 2f * (1f - num));
			break;
		case PatreonTier.RockStar:
			rb.AddForce(vector * speed / 1.5f);
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
	}

	public void Attack(float dmg, Vector2 direction)
	{
		if (tier != PatreonTier.RockStar)
		{
			health -= dmg;
			hurt = 1f;
			rb.AddForce(1000f * direction, ForceMode2D.Impulse);
			if (health < 0f)
			{
				PatreonSimulation.instance.PatreonDeath(tier, patron);
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		_ = tier;
		_ = 4;
	}
}
