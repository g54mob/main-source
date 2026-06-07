using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Assets.Scripts.Flight.WorldObjects.Combat
{
	public class BombTargetScript : MonoBehaviour
	{
		public DecalProjector TargetProjector { get; private set; }

		protected virtual void Awake()
		{
			TargetProjector = GetComponentInChildren<DecalProjector>();
		}
	}
}
