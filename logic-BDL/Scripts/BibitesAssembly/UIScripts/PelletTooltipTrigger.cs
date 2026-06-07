using System.Collections;
using ManagementScripts;
using SimulationScripts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UIScripts
{
	public class PelletTooltipTrigger : MonoBehaviour
	{
		private bool hovering;

		private readonly WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.5f);

		private Coroutine waiting;

		public bool active;

		private MatterPellet pellet;

		private void Awake()
		{
			pellet = GetComponent<MatterPellet>();
		}

		private void OnMouseEnter()
		{
			if (!EventSystem.current.IsPointerOverGameObject())
			{
				hovering = true;
				waiting = StartCoroutine(WaitForDelay());
			}
		}

		private void OnMouseExit()
		{
			hovering = false;
			if (waiting != null)
			{
				StopCoroutine(waiting);
			}
			HideTooltip();
		}

		private IEnumerator WaitForDelay()
		{
			yield return wait;
			if (hovering && !EventSystem.current.IsPointerOverGameObject())
			{
				TooltipSystem.ShowPelletTooltip(pellet);
				active = true;
			}
		}

		private void HideTooltip()
		{
			TooltipSystem.HidePelletTooltip();
			active = false;
		}

		private void OnDisable()
		{
			if (active)
			{
				HideTooltip();
			}
		}
	}
}
