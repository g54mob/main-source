using System;
using System.Collections.Generic;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace OneUseScripts
{
	public class RadioZone : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer sr;

		[SerializeField]
		private Rigidbody2D rb;

		[NonSerialized]
		private Material radioMat;

		private int ID;

		private static int totalID;

		private BibiteBody radBibite;

		private Transform target;

		public static Color color = new Color32(176, byte.MaxValue, 0, 128);

		private static readonly int Color1 = Shader.PropertyToID("_Color");

		private List<BibiteGenes> affectedGenes = new List<BibiteGenes>();

		private bool fadingOut;

		private float fade;

		private MutationIncreases effect = new MutationIncreases
		{
			probabilityIncrease = 10f,
			intensityIncrease = 0.35f
		};

		private void Awake()
		{
			radioMat = new Material(sr.material);
			ID = totalID++;
			base.name = $"RadioZone {ID}";
			sr.material = radioMat;
			radioMat.SetColor(Color1, color);
		}

		public void SetAttachedBibite(BibiteBody attached)
		{
			attached.onDeath.AddListener(StartFading);
			radBibite = attached;
			target = attached.transform;
		}

		private void Update()
		{
			if (target == null && !fadingOut)
			{
				StartFading();
				return;
			}
			if (target != null)
			{
				rb.position = target.position;
			}
			if (fadingOut)
			{
				fade -= Time.deltaTime / 100f;
				Color value = color;
				value.a = fade;
				radioMat.SetColor(Color1, value);
				if (fade < 0f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}

		private void StartFading(BibiteBody bibite = null)
		{
			fadingOut = true;
			fade = color.a;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.isTrigger || !other.gameObject.CompareTag("bibitePart"))
			{
				return;
			}
			BibiteBody mainBody = other.GetComponent<BibitePart>().GetMainBody();
			if (!(mainBody == radBibite))
			{
				BibiteGenes gene = mainBody.gene;
				if (!affectedGenes.Contains(gene))
				{
					affectedGenes.Add(gene);
					gene.AddMutationFactor(effect, "RadZone");
				}
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (!other.isTrigger && other.gameObject.CompareTag("bibitePart"))
			{
				BibiteGenes gene = other.GetComponent<BibitePart>().GetMainBody().gene;
				if (affectedGenes.Contains(gene))
				{
					affectedGenes.Remove(gene);
				}
			}
		}
	}
}
