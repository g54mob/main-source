using System.Collections.Generic;
using UnityEngine;

public class Helicopter_MiniGame : MonoBehaviour
{
	public enum StageEnum
	{
		None = 0,
		Part1 = 1,
		Ending = 2
	}

	private StageEnum _stage;

	private Color _mainColor = Color.white;

	public int SuccessCount;

	public GameObject Stick;

	public List<GameObject> Dots;

	private float _angle;

	private int _visibleDot = -1;

	private List<bool> _wasHit = new List<bool>();

	public Helicopter Parent;

	private SpriteRenderer _renderer;

	public bool AutoDevice;

	public bool IsSuccess
	{
		get
		{
			if (Helicopter.GlobalInfo.TotalEvilCount > 0 && AutoDevice)
			{
				return true;
			}
			return SuccessCount > 0;
		}
	}

	public void Awake()
	{
		_renderer = base.transform.Find("Radar").GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		ResetHits();
		SetVisibleDot();
	}

	private void FixedUpdate()
	{
		Helper.SetZForFocus(base.transform);
		if (_stage == StageEnum.Part1)
		{
			_angle += -90f * Time.fixedDeltaTime;
			if (_angle < -360f)
			{
				_angle += 360f;
				Parent.MiniGameCompleted();
			}
			Stick.transform.eulerAngles = new Vector3(0f, 0f, _angle);
		}
	}

	public void SetParent(Helicopter parent)
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
			switch (_stage)
			{
			case StageEnum.None:
				_angle = 0f;
				Stick.transform.eulerAngles = new Vector3(0f, 0f, _angle);
				_visibleDot = -1;
				ResetHits();
				SetVisibleDot();
				break;
			case StageEnum.Part1:
				_angle = 0f;
				Stick.transform.eulerAngles = new Vector3(0f, 0f, _angle);
				GetNewDot();
				SetVisibleDot();
				break;
			case StageEnum.Ending:
				_angle = 0f;
				Stick.transform.eulerAngles = new Vector3(0f, 0f, _angle);
				_visibleDot = -1;
				break;
			}
		}
	}

	private void OnMouseOver()
	{
		if (Helicopter.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.yellow;
		}
	}

	private void OnMouseExit()
	{
		if (Helicopter.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.white;
		}
	}

	private void OnMouseDown()
	{
		if (Sign.PreventEvent || _visibleDot == -1 || _stage != StageEnum.Part1)
		{
			return;
		}
		bool flag = false;
		float num = (float)(_visibleDot + 1) * -45f;
		float num2 = 20f;
		if (num + num2 > Stick.transform.eulerAngles.z && num - num2 < Stick.transform.eulerAngles.z)
		{
			flag = true;
		}
		if (num + num2 > Stick.transform.eulerAngles.z - 360f && num - num2 < Stick.transform.eulerAngles.z - 360f)
		{
			flag = true;
		}
		if (flag)
		{
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_click);
			_wasHit[_visibleDot] = true;
			GetNewDot();
			if (_visibleDot == -1)
			{
				SuccessCount++;
				ResetHits();
				GetNewDot();
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_success);
			}
			SetVisibleDot();
		}
	}

	private void GetNewDot()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < Dots.Count; i++)
		{
			if (!_wasHit[i])
			{
				list.Add(i);
			}
		}
		if (list.Count == 0)
		{
			_visibleDot = -1;
		}
		else
		{
			_visibleDot = list[Random.Range(0, list.Count)];
		}
	}

	private void SetVisibleDot()
	{
		for (int i = 0; i < Dots.Count; i++)
		{
			if (_visibleDot == i)
			{
				Dots[i].GetComponent<SpriteRenderer>().color = _mainColor;
				Dots[i].SetActive(value: true);
			}
			else if (_wasHit[i])
			{
				Dots[i].GetComponent<SpriteRenderer>().color = GameController.EvilColor;
				Dots[i].SetActive(value: true);
			}
			else
			{
				Dots[i].SetActive(value: false);
			}
		}
	}

	private void ResetHits()
	{
		_wasHit.Clear();
		for (int i = 0; i < Dots.Count; i++)
		{
			_wasHit.Add(item: false);
		}
	}
}
