namespace Restory.Gameplay.GameCursor
{
	public sealed class CursorDetectorService
	{
		private readonly UICursorDetector uiCursorDetector;

		private readonly GameCursorDetector gameCursorDetector;

		public UICursorDetector UIDetector => uiCursorDetector;

		public GameCursorDetector GameDetector => gameCursorDetector;

		public CursorDetectorService(UICursorDetector uiCursorDetector, GameCursorDetector gameCursorDetector)
		{
			this.uiCursorDetector = uiCursorDetector;
			this.gameCursorDetector = gameCursorDetector;
		}
	}
}
