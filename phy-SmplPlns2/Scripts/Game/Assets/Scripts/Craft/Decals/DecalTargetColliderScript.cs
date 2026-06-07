using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Craft.Decals
{
	public class DecalTargetColliderScript : MonoBehaviour
	{
		[SerializeField]
		private List<DecalTargetScript> _decalTargets;

		public List<DecalTargetScript> DecalTargets => _decalTargets ?? (_decalTargets = new List<DecalTargetScript>());
	}
}
