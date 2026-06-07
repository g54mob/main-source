using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfGameController : MonoBehaviour
{
	public TMP_Text VersionText;

	public TMP_Text TimePlayedText;

	public TMP_Text TotalGarbageText;

	public TMP_Text TotalTossText;

	public TMP_Text TotalPeonTossText;

	public TMP_Text TotalCloudClickText;

	public TMP_Text TotalCloudDestroyedText;

	public TMP_Text TotalMoneyText;

	public TMP_Text TotalRPText;

	public TMP_Text TotalYellowText;

	public TMP_Text TotalBlueText;

	public TMP_Text TotalRedText;

	public TMP_Text TotalBookText;

	public TMP_Text TotalQuestText;

	public GameObject TopLeft;

	public GameObject BottomRight;

	public GameObject EndlessText;

	public GameObject DemoDescription;

	public GameObject EndGame1Description;

	public GameObject EndGame2Description;

	public GameObject GarbageSTemplate;

	public GameObject GarbageMTemplate;

	public GameObject GarbageLTemplate;

	public GameObject GarbageXLTemplate;

	public GameObject GarbageSEvilTemplate;

	public GameObject GarbageMEvilTemplate;

	public GameObject GarbageLEvilTemplate;

	public GameObject GarbageXLEvilTemplate;

	public CharDisplay Peon1;

	public CharDisplay Peon2;

	public CharDisplay PeonDown1;

	public CharDisplay PeonDown2;

	private List<GameObject> _garbages = new List<GameObject>();

	public static float Stats_TimePlayed;

	public static int Stats_TotalGarbageCreated;

	public static int Stats_TotalTossedGarbage;

	public static int Stats_TotalPeonGarbageTossed;

	public static int Stats_TotalCloudClick;

	public static int Stats_TotalCloudDestroyed;

	public static int Stats_TotalMoney;

	public static int Stats_TotalRP;

	public static int Stats_TotalYellow;

	public static int Stats_TotalBlue;

	public static int Stats_TotalRed;

	public static int Stats_TotalBook;

	public static int Stats_QuestDone;

	public static int Stats_QuestTotal;

	public static bool IsBadEnding = true;

	private float _jumpWait1 = 2f;

	private float _jumpWait2 = 1f;

	private void Start()
	{
		bool flag = false;
		VersionText.text = Installation.GetVersionString();
		TimePlayedText.text = GameController.DelaTimeToString(Stats_TimePlayed);
		TotalTossText.text = Stats_TotalTossedGarbage.ToNumber();
		TotalPeonTossText.text = Stats_TotalPeonGarbageTossed.ToNumber();
		TotalCloudClickText.text = Stats_TotalCloudClick.ToNumber();
		TotalCloudDestroyedText.text = Stats_TotalCloudDestroyed.ToNumber();
		TotalGarbageText.text = Stats_TotalGarbageCreated.ToNumber();
		TotalMoneyText.text = Stats_TotalMoney.ToNumber();
		TotalRPText.text = Stats_TotalRP.ToNumber();
		TotalYellowText.text = Stats_TotalYellow.ToNumber();
		TotalBlueText.text = Stats_TotalBlue.ToNumber();
		TotalRedText.text = Stats_TotalRed.ToNumber();
		TotalBookText.text = Stats_TotalBook.ToNumber();
		TotalQuestText.text = Stats_QuestDone + "/" + Stats_QuestTotal;
		Peon1.IgnoreBubble();
		Peon2.IgnoreBubble();
		Peon1.ChangeSide(CharDisplay.SideEnum.Left, forceChange: true);
		Peon2.ChangeSide(CharDisplay.SideEnum.Left, forceChange: true);
		Peon1.ChangeMovement(CharDisplay.MovementEnum.IdleHandDown, forceChange: true);
		Peon2.ChangeMovement(CharDisplay.MovementEnum.IdleHandDown, forceChange: true);
		PeonDown1.IgnoreBubble();
		PeonDown2.IgnoreBubble();
		PeonDown1.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		PeonDown1.ChangeEye(CharDisplay.EyeSpriteEnum.Big);
		PeonDown1.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenSmall);
		PeonDown2.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		PeonDown2.ChangeEye(CharDisplay.EyeSpriteEnum.Big);
		PeonDown2.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenSmall);
		if (Installation.IsDemo())
		{
			Peon1.gameObject.SetActive(value: true);
			Peon2.gameObject.SetActive(value: true);
			PeonDown1.gameObject.SetActive(value: false);
			PeonDown2.gameObject.SetActive(value: false);
		}
		else if (IsBadEnding)
		{
			Peon1.gameObject.SetActive(value: false);
			Peon2.gameObject.SetActive(value: true);
			PeonDown1.gameObject.SetActive(value: true);
			PeonDown2.gameObject.SetActive(value: false);
		}
		else
		{
			Peon1.gameObject.SetActive(value: true);
			Peon2.gameObject.SetActive(value: true);
			PeonDown1.gameObject.SetActive(value: false);
			PeonDown2.gameObject.SetActive(value: false);
		}
		if (Installation.IsDemo())
		{
			DemoDescription.SetActive(value: true);
			EndGame1Description.SetActive(value: false);
			EndGame2Description.SetActive(value: false);
		}
		else if (IsBadEnding)
		{
			DemoDescription.SetActive(value: false);
			EndGame1Description.SetActive(value: true);
			EndGame2Description.SetActive(value: false);
		}
		else
		{
			DemoDescription.SetActive(value: false);
			EndGame1Description.SetActive(value: false);
			EndGame2Description.SetActive(value: true);
		}
		for (int i = 0; i < 10; i++)
		{
			GameObject gameObject = Object.Instantiate(flag ? GarbageSEvilTemplate : GarbageSTemplate);
			gameObject.transform.parent = GarbageSTemplate.transform.parent;
			gameObject.transform.position = new Vector3(Random.Range(TopLeft.transform.position.x, BottomRight.transform.position.x), Random.Range(BottomRight.transform.position.y, TopLeft.transform.position.y), GarbageSTemplate.transform.position.z);
			_garbages.Add(gameObject);
		}
		for (int j = 0; j < 10; j++)
		{
			GameObject gameObject2 = Object.Instantiate(flag ? GarbageMEvilTemplate : GarbageMTemplate);
			gameObject2.transform.parent = GarbageSTemplate.transform.parent;
			gameObject2.transform.position = new Vector3(Random.Range(TopLeft.transform.position.x, BottomRight.transform.position.x), Random.Range(BottomRight.transform.position.y, TopLeft.transform.position.y), GarbageSTemplate.transform.position.z);
			_garbages.Add(gameObject2);
		}
		for (int k = 0; k < 10; k++)
		{
			GameObject gameObject3 = Object.Instantiate(flag ? GarbageLEvilTemplate : GarbageLTemplate);
			gameObject3.transform.parent = GarbageSTemplate.transform.parent;
			gameObject3.transform.position = new Vector3(Random.Range(TopLeft.transform.position.x, BottomRight.transform.position.x), Random.Range(BottomRight.transform.position.y, TopLeft.transform.position.y), GarbageSTemplate.transform.position.z);
			_garbages.Add(gameObject3);
		}
		for (int l = 0; l < 10; l++)
		{
			GameObject gameObject4 = Object.Instantiate(flag ? GarbageXLEvilTemplate : GarbageXLTemplate);
			gameObject4.transform.parent = GarbageSTemplate.transform.parent;
			gameObject4.transform.position = new Vector3(Random.Range(TopLeft.transform.position.x, BottomRight.transform.position.x), Random.Range(BottomRight.transform.position.y, TopLeft.transform.position.y), GarbageSTemplate.transform.position.z);
			_garbages.Add(gameObject4);
		}
		EndlessText.SetActive(CharDisplay.HasEndless);
		Music2Controller.Instance.PlayEndingMusic();
	}

	private void FixedUpdate()
	{
		int num = 0;
		foreach (GameObject garbage in _garbages)
		{
			int num2 = num % 2;
			int num3 = 3 + num % 5;
			num++;
			garbage.transform.position -= new Vector3(0f, (float)num3 * Time.fixedDeltaTime, 0f);
			if (num2 == 1)
			{
				garbage.transform.Rotate(0f, 0f, 30f * Time.fixedDeltaTime);
			}
			else
			{
				garbage.transform.Rotate(0f, 0f, -30f * Time.fixedDeltaTime);
			}
			if (garbage.transform.position.y < BottomRight.transform.position.y)
			{
				garbage.transform.position = new Vector3(Random.Range(TopLeft.transform.position.x, BottomRight.transform.position.x), TopLeft.transform.position.y, GarbageSTemplate.transform.position.z);
			}
		}
		_jumpWait1 -= Time.fixedDeltaTime;
		_jumpWait2 -= Time.fixedDeltaTime;
		if (_jumpWait1 <= 0f)
		{
			_jumpWait1 = Random.Range(1.2f, 4f);
			JumpPeon1();
		}
		if (_jumpWait2 <= 0f)
		{
			_jumpWait2 = Random.Range(1.2f, 4f);
			JumpPeon2();
		}
	}

	public void GoToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void OpenSteam()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		if (!Installation.IsSteamConnected() || !ApiManager.Instance.OpenSteamForWishlist())
		{
			Application.OpenURL(Global.SteamUrl);
		}
	}

	public void OpenItch()
	{
		GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ui_button1_click);
		Application.OpenURL(Global.ItchUrl);
	}

	private void JumpPeon1()
	{
		Sequence sequence = DOTween.Sequence();
		sequence.AppendCallback(delegate
		{
			Peon1.ChangeMovement(CharDisplay.MovementEnum.IdleHandUp, forceChange: true);
			Peon1.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenBig);
		});
		sequence.Append(Peon1.transform.DOMoveY(Peon1.transform.position.y + 2f, 0.5f).SetEase(Ease.OutQuad));
		sequence.AppendCallback(delegate
		{
			Peon1.ChangeMovement(CharDisplay.MovementEnum.IdleHandDown, forceChange: true);
			Peon1.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenSmall);
		});
		sequence.Append(Peon1.transform.DOMoveY(Peon1.transform.position.y, 0.5f).SetEase(Ease.InQuad));
		sequence.AppendCallback(delegate
		{
			Peon1.ChangeMouth(CharDisplay.MouthSpriteEnum.Normal);
		});
		sequence.Play();
	}

	private void JumpPeon2()
	{
		Sequence sequence = DOTween.Sequence();
		sequence.AppendCallback(delegate
		{
			Peon2.ChangeMovement(CharDisplay.MovementEnum.IdleHandUp, forceChange: true);
			Peon2.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenBig);
		});
		sequence.Append(Peon2.transform.DOMoveY(Peon2.transform.position.y + 2f, 0.5f).SetEase(Ease.OutQuad));
		sequence.AppendCallback(delegate
		{
			Peon2.ChangeMovement(CharDisplay.MovementEnum.IdleHandDown, forceChange: true);
			Peon2.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenSmall);
		});
		sequence.Append(Peon2.transform.DOMoveY(Peon2.transform.position.y, 0.5f).SetEase(Ease.InQuad));
		sequence.AppendCallback(delegate
		{
			Peon2.ChangeMouth(CharDisplay.MouthSpriteEnum.Normal);
		});
		sequence.Play();
	}
}
