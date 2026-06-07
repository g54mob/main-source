using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Compressor_MiniGame : MonoBehaviour
{
	public enum StageEnum
	{
		None = 0,
		Part1 = 1,
		Part2 = 2,
		Ending = 3
	}

	private StageEnum _stage;

	private Color _mainColor = Color.white;

	public Compressor_Button ButtonTop;

	public Compressor_Button ButtonBottom;

	public SpriteRenderer LeftDots;

	public SpriteRenderer RightDots;

	public List<Sprite> LeftSprites;

	public List<Sprite> RightSprites;

	public Sprite FullDotsSprite;

	private int _leftNumber = -1;

	private int _rightNumber = -1;

	private bool _isSuccess;

	private Vector3 _originalLeftDotLocation;

	private Tweener _movementAnim;

	public bool AutoDevice;

	public bool IsSuccess
	{
		get
		{
			if (Compressor.GlobalInfo.TotalEvilCount > 0 && AutoDevice)
			{
				return true;
			}
			return _isSuccess;
		}
	}

	public StageEnum Stage => _stage;

	private void Start()
	{
		_originalLeftDotLocation = LeftDots.transform.position;
	}

	private void Update()
	{
	}

	public void SetParent(Compressor parent)
	{
		ButtonTop.Parent = this;
		ButtonBottom.Parent = this;
	}

	public void SetMainColor(Color color)
	{
		if (_mainColor != color)
		{
			_mainColor = color;
			RightDots.color = _mainColor;
			LeftDots.color = _mainColor;
		}
	}

	public void ChangeStage(StageEnum newStage)
	{
		if (_stage == newStage)
		{
			return;
		}
		_stage = newStage;
		_isSuccess = false;
		switch (_stage)
		{
		case StageEnum.None:
			_leftNumber = -1;
			_rightNumber = -1;
			UpdateSide();
			break;
		case StageEnum.Part1:
			_leftNumber = Random.Range(0, 4);
			_rightNumber = -1;
			UpdateSide();
			break;
		case StageEnum.Part2:
			if (_leftNumber == _rightNumber && _rightNumber != -1)
			{
				_isSuccess = true;
			}
			MoveSide();
			break;
		case StageEnum.Ending:
			if (_leftNumber == _rightNumber && _rightNumber != -1)
			{
				_isSuccess = true;
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_success);
			}
			break;
		}
	}

	public void ButtonPressed(bool isTop)
	{
		if (_stage == StageEnum.Part1)
		{
			if (isTop)
			{
				_rightNumber--;
			}
			else
			{
				_rightNumber++;
			}
			if (_rightNumber < 0)
			{
				_rightNumber = 3;
			}
			if (_rightNumber > 3)
			{
				_rightNumber = 0;
			}
			UpdateSide();
		}
	}

	private void UpdateSide()
	{
		if (_leftNumber == -1)
		{
			LeftDots.sprite = FullDotsSprite;
		}
		else
		{
			LeftDots.sprite = LeftSprites[_leftNumber];
		}
		if (_rightNumber == -1)
		{
			RightDots.sprite = FullDotsSprite;
		}
		else
		{
			RightDots.sprite = RightSprites[_rightNumber];
		}
		LeftDots.transform.position = _originalLeftDotLocation;
	}

	private void MoveSide()
	{
		_movementAnim = LeftDots.transform.DOMoveX(RightDots.transform.position.x, 1f).SetEase(Ease.InOutSine);
	}
}
