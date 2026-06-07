using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.OrbSnatcher
{
	public class OrbChainScript : MonoBehaviour
	{
		public List<OrbScript> Orbs { get; private set; } = new List<OrbScript>();

		protected virtual void OnDestroy()
		{
			if (Orbs.Count > 0)
			{
				Orbs[0].OnChainDestroyed();
			}
		}
	}
}
