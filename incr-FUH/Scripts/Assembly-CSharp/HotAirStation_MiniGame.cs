using UnityEngine;

public class HotAirStation_MiniGame : MonoBehaviour
{
	public enum StageEnum
	{
		None = 0,
		Part1 = 1,
		Part2 = 2,
		Part3 = 3,
		Ending = 4
	}

	public GameObject StaticBar;

	public GameObject MovingBar;

	public float StaticBarStartX;

	public float StaticBarEndX;

	public float MovingBarStartX;

	public float MovingBarEndX;

	private StageEnum _stage;

	private Color _mainColor = Color.white;

	private bool _isSuccess;

	private float _movingSpeed;

	private SpriteRenderer _renderer;

	public bool AutoDevice;

	public StageEnum CurStage => _stage;

	public bool IsSuccess
	{
		get
		{
			if (HotAirStation.GlobalInfo.TotalEvilCount > 0 && AutoDevice)
			{
				return true;
			}
			return _isSuccess;
		}
	}

	public void Awake()
	{
		_renderer = base.transform.Find("StaticBar").GetComponent<SpriteRenderer>();
	}

	private void Start()
	{
		_movingSpeed = (MovingBarEndX - MovingBarStartX) / 3f;
	}

	private void FixedUpdate()
	{
		Helper.SetZForFocus(base.transform);
		if (_stage == StageEnum.Part2)
		{
			float x = _movingSpeed * Time.fixedDeltaTime;
			MovingBar.transform.localPosition += new Vector3(x, 0f, 0f);
		}
	}

	private void OnMouseOver()
	{
		if (HotAirStation.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.yellow;
		}
	}

	private void OnMouseExit()
	{
		if (HotAirStation.GlobalInfo.CanHighlightDevice())
		{
			_renderer.color = Color.white;
		}
	}

	private void OnMouseDown()
	{
		if (Sign.PreventEvent || _stage != StageEnum.Part2)
		{
			return;
		}
		if (MovingBar.transform.localPosition.x > StaticBar.transform.localPosition.x - 0.3f && MovingBar.transform.localPosition.x < StaticBar.transform.localPosition.x + 0.3f)
		{
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_click);
			if (!_isSuccess)
			{
				GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_minigame_success);
			}
			_isSuccess = true;
			MovingBar.GetComponent<SpriteRenderer>().color = GameController.EvilColor;
		}
		else
		{
			_isSuccess = false;
			MovingBar.GetComponent<SpriteRenderer>().color = Color.white;
		}
	}

	public void SetParent(HotAirStation parent)
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
				_isSuccess = false;
				MovingBar.GetComponent<SpriteRenderer>().color = Color.white;
				break;
			case StageEnum.Part1:
				_isSuccess = false;
				MovingBar.GetComponent<SpriteRenderer>().color = Color.white;
				StaticBar.transform.localPosition = new Vector3(Random.Range(StaticBarStartX, StaticBarEndX), StaticBar.transform.localPosition.y, StaticBar.transform.localPosition.z);
				MovingBar.transform.localPosition = new Vector3(MovingBarStartX, MovingBar.transform.localPosition.y, MovingBar.transform.localPosition.z);
				break;
			case StageEnum.Part2:
			case StageEnum.Part3:
			case StageEnum.Ending:
				break;
			}
		}
	}
}
