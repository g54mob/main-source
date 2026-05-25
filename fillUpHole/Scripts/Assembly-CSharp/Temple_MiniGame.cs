using UnityEngine;

public class Temple_MiniGame : MonoBehaviour
{
	public enum StageEnum
	{
		None = 0,
		Part1 = 1,
		Ending = 2
	}

	private StageEnum _stage;

	private Color _mainColor = Color.white;

	private bool _isSuccess;

	public bool IsSuccess => _isSuccess;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetParent(Compressor parent)
	{
	}

	public void SetMainColor(Color color)
	{
		if (_mainColor != color)
		{
			_mainColor = color;
		}
	}

	public void ChangeStage(StageEnum newStage)
	{
		if (_stage != newStage)
		{
			_stage = newStage;
			_isSuccess = false;
			switch (_stage)
			{
			}
		}
	}
}
