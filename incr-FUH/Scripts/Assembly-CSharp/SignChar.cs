using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SignChar : MonoBehaviour
{
	public class UpgradeInfo
	{
		public static int NewCharacterCost()
		{
			long num = 0L;
			if (GameController.Instance.PeonController.GetCharacterCount() == 0)
			{
				return (int)num;
			}
			num = (long)(MathF.Pow(1.25f, GameController.Instance.PeonController.GetCharacterCount() - 1) * 5f);
			for (int i = 0; i < House.GlobalInfo.CanHalfPeonCostAttribute.Level; i++)
			{
				num /= 2;
			}
			if (num > 9000000)
			{
				num = 9000000L;
			}
			return (int)num;
		}

		public static int GetMaxCharacterCount()
		{
			int levelBuildingSum = GameController.Instance.ColumnsController.GetLevelBuildingSum(BaseBuilding.BuildingTypeEnum.House);
			if (levelBuildingSum == 0)
			{
				return 1 + House.GlobalInfo.CanInitialMaxPeonAttribute.Level;
			}
			return House.GlobalInfo.GetDefaultMaxPeonPerFloor() * levelBuildingSum + House.GlobalInfo.CanInitialMaxPeonAttribute.Level;
		}
	}

	public GameObject SpawnLocation;

	public GameObject Glass;

	public GameObject Button;

	private Tween _pulseTween;

	public GameObject Square1Loc;

	public GameObject Square2Loc;

	public Sprite PeonSquareOnSprite;

	public Sprite PeonSquareOffSprite;

	public Sign Sign;

	private int _cachedTotalPeon;

	public int _cachedTotalMaxPeon;

	private List<SpriteRenderer> _peonSquare = new List<SpriteRenderer>();

	private float _squareDx;

	private float _squareDy;

	public UpgradeInfo Upgrades = new UpgradeInfo();

	private void Start()
	{
		Glass.SetActive(value: false);
		Square1Loc.SetActive(value: false);
		Square2Loc.SetActive(value: false);
		_squareDx = Square2Loc.transform.position.x - Square1Loc.transform.position.x;
		_squareDy = Square2Loc.transform.position.y - Square1Loc.transform.position.y;
		Sign.SetForChar(this);
	}

	private void Update()
	{
		if (_cachedTotalPeon != GameController.Instance.PeonController.GetCharacterCount() || _cachedTotalMaxPeon != UpgradeInfo.GetMaxCharacterCount())
		{
			_cachedTotalPeon = GameController.Instance.PeonController.GetCharacterCount();
			_cachedTotalMaxPeon = UpgradeInfo.GetMaxCharacterCount();
			int num = _cachedTotalPeon;
			if (num < _cachedTotalMaxPeon)
			{
				num = _cachedTotalMaxPeon;
			}
			for (int i = _peonSquare.Count; i < num; i++)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(Square1Loc, Square1Loc.transform.parent);
				float num2 = i % 8;
				float num3 = i / 8;
				num2 *= _squareDx;
				num3 *= _squareDy;
				gameObject.transform.position = new Vector3(Square1Loc.transform.position.x + num2, Square1Loc.transform.position.y + num3, Square1Loc.transform.position.z);
				_peonSquare.Add(gameObject.GetComponent<SpriteRenderer>());
			}
			for (int j = 0; j < _peonSquare.Count; j++)
			{
				if (j < _cachedTotalPeon)
				{
					_peonSquare[j].sprite = PeonSquareOnSprite;
					_peonSquare[j].gameObject.SetActive(value: true);
					if (j >= _cachedTotalMaxPeon && !Training.GlobalInfo.CanNoDeathAttribute.IsEnabled)
					{
						_peonSquare[j].color = Color.red;
					}
					else
					{
						_peonSquare[j].color = Color.white;
					}
				}
				else if (j < _cachedTotalMaxPeon)
				{
					_peonSquare[j].color = Color.white;
					_peonSquare[j].sprite = PeonSquareOffSprite;
					_peonSquare[j].gameObject.SetActive(value: true);
				}
				else
				{
					_peonSquare[j].gameObject.SetActive(value: false);
				}
			}
		}
		if (_cachedTotalPeon < _cachedTotalMaxPeon)
		{
			if (UpgradeInfo.NewCharacterCost() <= GameController.Instance.Money.Amount)
			{
				_peonSquare[_cachedTotalPeon].color = Color.yellow;
			}
			else
			{
				_peonSquare[_cachedTotalPeon].color = Color.white;
			}
		}
	}

	public void SpawnCharacter()
	{
		Music2Controller.Instance.PlayMainMusic();
		StartCoroutine(ExecuteSpawn());
	}

	private IEnumerator ExecuteSpawn()
	{
		GlobalSfx2Controller.Instance.PlayFromDistance(SoundManager.SoundTypeEnum.ga_new_peon, base.transform.position.x);
		CharV2 newPeon = GameController.Instance.PeonController.SpawnCharacterAtLocation(SpawnLocation.transform.position);
		newPeon.gameObject.SetActive(value: false);
		Glass.SetActive(value: true);
		yield return new WaitForSeconds(0.3f);
		Glass.SetActive(value: false);
		newPeon.gameObject.SetActive(value: true);
	}

	public void StartPulse()
	{
		Button.GetComponent<HoverExpand>().Pause();
		_pulseTween = Button.transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
	}

	public void HandleClick()
	{
		if (_pulseTween != null && _pulseTween.IsActive())
		{
			Button.transform.localScale = new Vector3(1f, 1f, 1f);
			_pulseTween.Kill();
			_pulseTween = null;
			Button.GetComponent<HoverExpand>().UnPause();
		}
		if (WorldCanvasController.Instance.CharacterPanel.gameObject.activeSelf)
		{
			WorldCanvasController.Instance.ClosePanel();
			return;
		}
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		WorldCanvasController.Instance.OpenCharacterPanel(base.gameObject.transform.position + new Vector3(4f, 0f, 0f));
	}
}
