using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T9HeliumParticle : MonoBehaviour
	{
		private void OnDisable()
		{
			Object.Destroy(base.gameObject);
		}

		private void OnMouseUpAsButton()
		{
			GetComponentInParent<ActiveWorldFrame>().ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			Object.Destroy(base.gameObject);
		}
	}
}
