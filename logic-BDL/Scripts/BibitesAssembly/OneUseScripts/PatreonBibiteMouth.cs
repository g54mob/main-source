using ManagementScripts.SceneManagers;
using SimulationScripts;
using UnityEngine;

namespace OneUseScripts
{
	public class PatreonBibiteMouth : MonoBehaviour
	{
		public PatreonBibite bibite;

		private float biteProgress = 100f;

		private void Update()
		{
			if (!(biteProgress > 1f))
			{
				biteProgress += Time.deltaTime;
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (biteProgress < 1f)
			{
				return;
			}
			if (other.gameObject.CompareTag("bibite"))
			{
				PatreonBibite component = other.gameObject.GetComponent<PatreonBibite>();
				float dmg = ((bibite.tier == PatreonTier.Carnivore) ? 35f : 15f);
				Vector3 vector = other.transform.position - base.transform.position;
				if (component != null)
				{
					component.Attack(dmg, vector.normalized);
				}
			}
			else if (other.gameObject.CompareTag("pellet"))
			{
				MatterPellet component2 = other.gameObject.GetComponent<MatterPellet>();
				if (component2 != null)
				{
					component2.RemoveAmount(35f);
				}
			}
			biteProgress = 0f;
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			OnTriggerEnter2D(other);
		}
	}
}
