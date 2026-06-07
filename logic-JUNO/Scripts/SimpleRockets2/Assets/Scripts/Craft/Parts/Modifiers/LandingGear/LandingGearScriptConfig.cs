using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingGear
{
	public class LandingGearScriptConfig : MonoBehaviour
	{
		[SerializeField]
		private List<Transform> _transformsToScaleWithBay;

		public List<Transform> TransformsToScaleWithBay => _transformsToScaleWithBay;
	}
}
