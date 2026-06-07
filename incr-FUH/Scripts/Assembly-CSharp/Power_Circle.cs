using System.Collections.Generic;
using UnityEngine;

public class Power_Circle : MonoBehaviour
{
	public class CircleInfo
	{
		public int ImageType;

		public int RotationType;

		public CircleInfo(int imageType, int rotationType)
		{
			ImageType = imageType;
			RotationType = rotationType;
		}
	}

	public List<Sprite> CircleSprites;

	public Power_MiniGame ParentPower;

	public static List<CircleInfo> CirclesInfo = new List<CircleInfo>
	{
		new CircleInfo(0, 0),
		new CircleInfo(1, 0),
		new CircleInfo(1, 1),
		new CircleInfo(3, 0),
		new CircleInfo(1, 2),
		new CircleInfo(5, 0),
		new CircleInfo(3, 1),
		new CircleInfo(4, 0),
		new CircleInfo(1, 3),
		new CircleInfo(3, 3),
		new CircleInfo(5, 1),
		new CircleInfo(4, 3),
		new CircleInfo(3, 2),
		new CircleInfo(4, 2),
		new CircleInfo(4, 1),
		new CircleInfo(2, 0)
	};

	public static List<List<int>> CircleGrid = new List<List<int>>
	{
		new List<int> { 12, 0, 0, 5, 0, 0, 3, 10, 10 },
		new List<int> { 12, 6, 12, 5, 5, 5, 3, 9, 3 },
		new List<int> { 12, 0, 0, 5, 6, 12, 3, 9, 3 },
		new List<int> { 12, 0, 0, 3, 12, 0, 0, 3, 10 },
		new List<int> { 12, 0, 0, 3, 10, 12, 0, 0, 3 },
		new List<int> { 12, 6, 12, 3, 9, 5, 0, 0, 3 },
		new List<int> { 10, 12, 0, 6, 9, 0, 3, 10, 10 },
		new List<int> { 10, 10, 12, 6, 10, 9, 3, 10, 10 },
		new List<int> { 10, 10, 12, 0, 6, 9, 0, 3, 10 },
		new List<int> { 10, 10, 12, 0, 0, 5, 0, 0, 3 },
		new List<int> { 10, 12, 0, 0, 3, 12, 0, 0, 3 },
		new List<int> { 10, 12, 0, 0, 5, 0, 0, 3, 10 }
	};

	private int _currentCicle;

	private int _currentRotation;

	private SpriteRenderer _renderer;

	public void Awake()
	{
		_renderer = GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
	}

	private void FixedUpdate()
	{
		Helper.SetZForFocus(base.transform);
	}

	private void OnMouseOver()
	{
		if (Power.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.yellow;
		}
	}

	private void OnMouseExit()
	{
		if (Power.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.white;
		}
	}

	private void OnMouseDown()
	{
		if (!Sign.PreventEvent)
		{
			int currentRotation = _currentRotation;
			currentRotation++;
			if (currentRotation >= 4)
			{
				currentRotation = 0;
			}
			SetCircle(_currentCicle, currentRotation);
			ParentPower.Verify();
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_click);
		}
	}

	public bool IsMatch(int index)
	{
		if (CirclesInfo[index].ImageType == 0)
		{
			return true;
		}
		if (_currentCicle == CirclesInfo[index].ImageType && _currentRotation == CirclesInfo[index].RotationType)
		{
			return true;
		}
		return false;
	}

	public void SetFromInfo(int index)
	{
		SetCircle(CirclesInfo[index].ImageType, CirclesInfo[index].RotationType);
	}

	public void SetForRandomFromInfo(int index)
	{
		int num = CirclesInfo[index].ImageType;
		int rotationType = CirclesInfo[index].RotationType;
		if (num == 0)
		{
			num = Random.Range(1, 6);
		}
		rotationType = Random.Range(0, 4);
		SetCircle(num, rotationType);
	}

	public void SetCircle(int newCircle, int newRotation)
	{
		if (newCircle == 0)
		{
			newRotation = 0;
		}
		if (newCircle == 2)
		{
			newRotation = 0;
		}
		if (newCircle == 5 && newRotation == 2)
		{
			newRotation = 0;
		}
		if (newCircle == 5 && newRotation == 3)
		{
			newRotation = 1;
		}
		if (_currentCicle != newCircle || _currentRotation != newRotation)
		{
			_currentCicle = newCircle;
			_currentRotation = newRotation;
			GetComponent<SpriteRenderer>().sprite = CircleSprites[_currentCicle];
			if (_currentRotation == 0)
			{
				base.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			}
			if (_currentRotation == 1)
			{
				base.transform.eulerAngles = new Vector3(0f, 0f, -90f);
			}
			if (_currentRotation == 2)
			{
				base.transform.eulerAngles = new Vector3(0f, 0f, -180f);
			}
			if (_currentRotation == 3)
			{
				base.transform.eulerAngles = new Vector3(0f, 0f, -270f);
			}
		}
	}
}
