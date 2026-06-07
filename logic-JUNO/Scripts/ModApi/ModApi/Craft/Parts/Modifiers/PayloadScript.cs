using System.Collections;
using UnityEngine;

namespace ModApi.Craft.Parts.Modifiers
{
	public class PayloadScript : PartModifierScript<PayloadData>
	{
		public override void OnActivated()
		{
			if (base.Data.CraftTrackingId != null)
			{
				StartCoroutine(TrackCraftNodeLater());
			}
			if (base.Data.CraftName != null)
			{
				StartCoroutine(RenameCraftNodeLater());
			}
		}

		private IEnumerator RenameCraftNodeLater()
		{
			yield return new WaitForSecondsRealtime(1f);
			base.PartScript.CraftScript.CraftNode.SetName(base.Data.CraftName);
		}

		private IEnumerator TrackCraftNodeLater()
		{
			yield return new WaitForSecondsRealtime(1f);
			base.PartScript.CraftScript.CraftNode.ContractTrackingId = base.Data.CraftTrackingId;
		}
	}
}
