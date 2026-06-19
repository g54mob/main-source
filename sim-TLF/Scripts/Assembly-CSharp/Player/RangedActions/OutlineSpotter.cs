using DG.Tweening;
using Extensions;
using JSAM;
using UnityEngine;

namespace Player.RangedActions
{
	[RequireComponent(typeof(Collider))]
	public class OutlineSpotter : MonoBehaviour
	{
		[Header("Parameters")]
		[SerializeField]
		private float _time;

		[SerializeField]
		private Ease _ease;

		public void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent<Outline>(out var component))
			{
				DrawOutline(component);
				AudioManager.PlaySound(InteractionLibrarySounds.PartOutlined, component.gameObject.transform);
			}
		}

		public void OnTriggerExit(Collider other)
		{
			if (other.TryGetComponent<Outline>(out var component))
			{
				HideOutline(component);
			}
		}

		private void DrawOutline(Outline outline)
		{
			outline.ShowOutline(_time, _ease);
		}

		private void HideOutline(Outline outline)
		{
			outline.HideOutline(_time, _ease);
		}
	}
}
