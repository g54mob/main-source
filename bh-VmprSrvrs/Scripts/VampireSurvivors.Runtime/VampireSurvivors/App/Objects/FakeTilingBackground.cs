using VampireSurvivors.Graphics;
using VampireSurvivors.Objects;

namespace VampireSurvivors.App.Objects
{
	public class FakeTilingBackground : GameMonoBehaviour
	{
		private TileSprite _bgTile;

		private float _speedFactor;

		public TileSprite BgTile => null;

		public float SpeedFactor
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void OnUpdate()
		{
		}

		public void MakeBackground(string textureName, Stage stage)
		{
		}
	}
}
