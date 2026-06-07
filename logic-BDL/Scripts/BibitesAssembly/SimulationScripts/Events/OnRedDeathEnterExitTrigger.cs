using ScriptHelpers;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace SimulationScripts.Events
{
	public class OnRedDeathEnterExitTrigger : MonoBehaviour
	{
		private RedDeathBloomManager manager;

		private float triggerAngle;

		private float h = 1f;

		private float w = 1f;

		public void InitializeTrigger(RedDeathBloomManager manager, float angle, float width)
		{
			this.manager = manager;
			triggerAngle = angle;
			w = width;
			base.transform.localRotation = Quaternion.Euler(Vector3.forward * angle * 57.29578f);
			UpdatePosition(0f);
		}

		public void UpdatePosition(float t)
		{
			base.transform.localPosition = Vector2.left.Rotate(triggerAngle) * (1f + w - t) / 2f;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("bibitePart"))
			{
				BibiteBody mainBody = other.GetComponent<BibitePart>().GetMainBody();
				if (mainBody != null)
				{
					manager.OnBibiteEnter(mainBody);
				}
			}
			else if (other.CompareTag("pellet"))
			{
				MatterPellet component = other.GetComponent<MatterPellet>();
				if (component != null)
				{
					manager.OnPelletEnter(component);
				}
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.CompareTag("bibitePart"))
			{
				BibiteBody mainBody = other.GetComponent<BibitePart>().GetMainBody();
				if (mainBody != null)
				{
					manager.OnBibiteExit(mainBody);
				}
			}
			else if (other.CompareTag("pellet"))
			{
				MatterPellet component = other.GetComponent<MatterPellet>();
				if (component != null)
				{
					manager.OnPelletExit(component);
				}
			}
		}
	}
}
