using UnityEngine;

namespace DV.Items.Brick
{
	public class BrickRomIntro : BrickRom
	{
		private const float INTRO_DURATION = 1.33f;

		private float elapsedTime;

		private const string CLIP_INTRO_PATH = "HandheldGameConsole/HandheldGameConsole_On_01";

		private const string TEXTURE_LOGO_PATH = "HandheldGameConsole/HandheldConsoleLogo";

		private AudioClip clipIntro;

		private Texture2D textureLogo;

		private BrickSprite spriteLogo;

		public override string GameName { get; protected set; } = "Intro";

		public BrickRomIntro(BrickAssets assets, BrickScreen screen, BrickAudio audio)
			: base(assets, screen, audio, null)
		{
			clipIntro = Resources.Load<AudioClip>("HandheldGameConsole/HandheldGameConsole_On_01");
			textureLogo = Resources.Load<Texture2D>("HandheldGameConsole/HandheldConsoleLogo");
			if (textureLogo == null)
			{
				Debug.LogError("Texture not found: HandheldGameConsole/HandheldConsoleLogo");
			}
			spriteLogo = new BrickSprite(textureLogo);
		}

		public override void Tick()
		{
			if (!base.GamePaused)
			{
				elapsedTime += 1f / 30f;
				if (elapsedTime > 1.33f)
				{
					EndGame();
				}
			}
		}

		protected override void StartGame()
		{
			screen.ClearScreen();
			int y = (screen.resolution.y - textureLogo.height) / 2;
			screen.DrawSprite(spriteLogo, new Vector2Int(0, y), includePadding: false);
			audio.PlayClip(clipIntro);
			FireGameStarted();
		}

		protected override void EndGame()
		{
			elapsedTime = 0f;
			screen.ClearScreen();
			FireGameEnded();
		}
	}
}
