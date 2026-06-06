using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MinesweeperPopup : Popup
{
	[SerializeField]
	private CellVisualizer cellPrefab;

	[SerializeField]
	private GridLayoutGroup boardParent;

	[SerializeField]
	private RectTransform popupRect;

	[SerializeField]
	private RectTransform gameRect;

	[SerializeField]
	private RectTransform boardRect;

	[SerializeField]
	private Button optionsButton;

	[SerializeField]
	private GameObject gameDropDown;

	[SerializeField]
	private Button newGameButton;

	[SerializeField]
	private Button exitButton;

	[SerializeField]
	private Button difficultyBeginnerButton;

	[SerializeField]
	private Button difficultyAdvancedButton;

	[SerializeField]
	private Button difficultyExpertButton;

	[SerializeField]
	private Image difficultyBeginnerCheckmark;

	[SerializeField]
	private Image difficultyAdvancedCheckmark;

	[SerializeField]
	private Image difficultyExpertCheckmark;

	private MinesweeperDifficulty _currentDifficulty;

	public MinesweeperDifficulty CurrentDifficulty => _currentDifficulty;

	public MinesweeperDifficultyPreset CurrentPreset => MinesweeperDifficultyPresets.Get(_currentDifficulty);

	protected override void Start()
	{
		base.Start();
		RefreshCheckmarks();
	}

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		initializer.Context(optionsButton).AddListener(ToggleDropDown).Context(newGameButton)
			.AddListener(OnNewGame)
			.Context(exitButton)
			.AddListener(OnExit)
			.Context(difficultyBeginnerButton)
			.AddListener(delegate
			{
				SetDifficulty(MinesweeperDifficulty.Beginner);
			})
			.Context(difficultyAdvancedButton)
			.AddListener(delegate
			{
				SetDifficulty(MinesweeperDifficulty.Advanced);
			})
			.Context(difficultyExpertButton)
			.AddListener(delegate
			{
				SetDifficulty(MinesweeperDifficulty.Expert);
			});
	}

	private void Update()
	{
		if (gameDropDown.activeSelf && Mouse.current.leftButton.wasPressedThisFrame)
		{
			Vector2 screenPoint = Mouse.current.position.ReadValue();
			Camera worldCamera = GetComponentInParent<Canvas>().rootCanvas.worldCamera;
			RectTransform rect = (RectTransform)gameDropDown.transform;
			RectTransform rect2 = (RectTransform)optionsButton.transform;
			if (!RectTransformUtility.RectangleContainsScreenPoint(rect, screenPoint, worldCamera) && !RectTransformUtility.RectangleContainsScreenPoint(rect2, screenPoint, worldCamera))
			{
				CloseDropDown();
			}
		}
	}

	private void ToggleDropDown()
	{
		gameDropDown.SetActive(!gameDropDown.activeSelf);
	}

	private void CloseDropDown()
	{
		DropdownButtonHover[] componentsInChildren = gameDropDown.GetComponentsInChildren<DropdownButtonHover>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].ResetState();
		}
		gameDropDown.SetActive(value: false);
	}

	private void OnNewGame()
	{
		EventHub.Scene.Publish<MinesweeperRestarted>();
		CloseDropDown();
	}

	private void OnExit()
	{
		HideContent();
		CloseDropDown();
	}

	private void SetDifficulty(MinesweeperDifficulty difficulty)
	{
		_currentDifficulty = difficulty;
		RefreshCheckmarks();
		CloseDropDown();
		EventHub.Scene.Publish<MinesweeperRestarted>();
	}

	private void RefreshCheckmarks()
	{
		difficultyBeginnerCheckmark.enabled = _currentDifficulty == MinesweeperDifficulty.Beginner;
		difficultyAdvancedCheckmark.enabled = _currentDifficulty == MinesweeperDifficulty.Advanced;
		difficultyExpertCheckmark.enabled = _currentDifficulty == MinesweeperDifficulty.Expert;
	}

	public void CreateBoard(Vector2Int size, int mines, out MineBoard board, out CellVisualizer[,] cells)
	{
		board = new MineBoard(size, mines);
		cells = new CellVisualizer[size.x, size.y];
		foreach (Transform item in boardParent.transform)
		{
			Object.Destroy(item.gameObject);
		}
		CalculateLayout(size);
		CreateVisualBoard(size, board, cells);
	}

	private void CalculateLayout(Vector2Int size)
	{
		boardParent.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
		boardParent.constraintCount = size.x;
		Vector2 cellSize = boardParent.cellSize;
		Vector2 spacing = boardParent.spacing;
		RectOffset padding = boardParent.padding;
		float num = (float)size.x * cellSize.x + (float)(size.x - 1) * spacing.x + (float)padding.left + (float)padding.right;
		float num2 = (float)size.y * cellSize.y + (float)(size.y - 1) * spacing.y + (float)padding.top + (float)padding.bottom;
		float num3 = 0f - (boardRect.sizeDelta.x + gameRect.sizeDelta.x);
		float num4 = 0f - (boardRect.sizeDelta.y + gameRect.sizeDelta.y);
		popupRect.sizeDelta = new Vector2(num + num3, num2 + num4);
	}

	private void CreateVisualBoard(Vector2Int size, MineBoard board, CellVisualizer[,] cells)
	{
		for (int i = 0; i < size.y; i++)
		{
			for (int j = 0; j < size.x; j++)
			{
				CellVisualizer cellVisualizer = Object.Instantiate(cellPrefab, boardParent.transform);
				Vector2Int position = new Vector2Int(j, i);
				MineCellData cell = board.GetCell(position);
				cellVisualizer.Setup(cell, position);
				cells[j, i] = cellVisualizer;
			}
		}
	}
}
