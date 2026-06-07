using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class TavernMapMarker : MapMarker
	{
		public string levelId;

		public RouteStop routeStop;

		public GameObject fireParticlePrefab;

		private GameObject fireParticleObj;

		[SerializeField]
		private TextMeshProI18n _tavernNameText;

		protected override void Start()
		{
		}

		public override void CheckState()
		{
		}

		public override void ShowVisual()
		{
		}

		protected override void SetupIdleAnimation()
		{
		}
	}
}
