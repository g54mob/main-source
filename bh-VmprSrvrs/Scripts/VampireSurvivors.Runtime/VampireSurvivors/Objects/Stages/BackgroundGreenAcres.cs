using VampireSurvivors.Data;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Objects.Stages
{
	public class BackgroundGreenAcres : BackgroundManager
	{
		private bool _checkForEdgeOfTheWorld;

		private bool _canFallOffTheEdge;

		private float _worldEndX;

		private float _worldEndY;

		private bool _isOffTheEdge;

		private BgmType _savedBGM;

		private BgmModType _savedBgmMod;

		private TileSprite _missingBg;

		public override void Create()
		{
		}

		public void FallOffTheEdge()
		{
		}

		public void ResetTilemap()
		{
		}

		public override void CheckMinute(int minute)
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
