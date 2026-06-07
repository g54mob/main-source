using EnhancedUI.EnhancedScroller;
using UnityEngine;
using UnityEngine.UI;

namespace EnhancedScrollerDemos.SnappingDemo
{
	public class SnappingDemo : MonoBehaviour
	{
		private enum GameStateEnum
		{
			Initializing = 0,
			Playing = 1,
			GameOver = 2
		}

		private SlotController[] _slotControllers;

		private int[] _snappedDataIndices;

		private int _credits;

		private int _snapCount;

		private GameStateEnum _gameState;

		public float minVelocity;

		public float maxVelocity;

		public int cherryIndex;

		public int sevenIndex;

		public int tripleBarIndex;

		public int bigWinIndex;

		public int blankIndex;

		public Sprite[] slotSprites;

		public Button pullLeverButton;

		public Text creditsText;

		public int startingCredits;

		public GameObject playingPanel;

		public GameObject gameOverPanel;

		public PlayWin playWin;

		private int Credits
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private GameStateEnum GameState
		{
			get
			{
				return default(GameStateEnum);
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		public void PullLeverButton_OnClick()
		{
		}

		public void ResetButton_OnClick()
		{
		}

		private void ScrollerSnapped(EnhancedScroller scroller, int cellIndex, int dataIndex, EnhancedScrollerCellView cellView)
		{
		}

		private void TallyScore()
		{
		}
	}
}
