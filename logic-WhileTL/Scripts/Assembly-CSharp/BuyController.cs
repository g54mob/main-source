using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyController : ActiveComponent
{
	[SceneBind("ExitButton")]
	private Button ExitButton;

	[SceneBind("BuyAccept")]
	private Button BuyAccept;

	[SceneBind("BlockName")]
	private Text BlockName;

	[SceneBind("BlockDescr")]
	private Text BlockDescr;

	[SceneBind("LabelBlock")]
	private Image LabelBlock;

	[SceneBind("MoneyBlock/Money/MoneyText")]
	private Text Money;

	private GameObject AlgoContent;

	private GameObject BuyBlock;

	private List<GameObject> buyButtons = new List<GameObject>();

	private int curBlock;

	private bool startDrawMoney;

	public double _drawedMoney;

	private double _moneySpeed;

	private void ExitClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		base.gameObject.transform.parent.parent.gameObject.SetActive(value: false);
	}

	private void ApplyClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		if (ActiveComponent.Model.P.Money >= ActiveComponent._staticData.ConstructionBlocks[curBlock].MoneyCost)
		{
			ActiveComponent.Model.P.Money -= ActiveComponent._staticData.ConstructionBlocks[curBlock].MoneyCost;
			ActiveComponent.Model.P.extraUnlockedAlgos.Add(ActiveComponent._staticData.ConstructionBlocks[curBlock].KeyName);
			Logic.UpdateGameSaves();
			Redraw();
		}
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		AlgoContent = GameObject.Find("AlgoContent");
		BuyBlock = Resources.Load("Prefabs/BuyBlock") as GameObject;
		BuyAccept.onClick.AddListener(ApplyClick);
		ExitButton.onClick.AddListener(ExitClick);
		BuyAccept.gameObject.SetActive(value: false);
		BlockName.gameObject.SetActive(value: false);
		BlockDescr.gameObject.SetActive(value: false);
		LabelBlock.gameObject.SetActive(value: false);
	}

	public void Redraw()
	{
		BuyAccept.gameObject.SetActive(value: false);
		BlockName.gameObject.SetActive(value: false);
		BlockDescr.gameObject.SetActive(value: false);
		LabelBlock.gameObject.SetActive(value: false);
		ActiveComponent._controller._resourcesView.Redraw();
		foreach (GameObject buyButton in buyButtons)
		{
			UnityEngine.Object.Destroy(buyButton);
		}
		buyButtons.Clear();
		for (int i = 0; i < ActiveComponent._staticData.ConstructionBlocks.Count; i++)
		{
			if (ActiveComponent._staticData.ConstructionBlocks[i].Extra == 1)
			{
				ActiveComponent.Model.P.extraUnlockedAlgos.Contains(ActiveComponent._staticData.ConstructionBlocks[i].KeyName);
				if (true)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(BuyBlock, AlgoContent.transform.position, AlgoContent.transform.rotation).gameObject;
					gameObject.transform.parent = AlgoContent.transform;
					gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
					gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
					gameObject.GetComponent<BuyBlock>().Init(ActiveComponent._staticData.ConstructionBlocks[i]);
					buyButtons.Add(gameObject);
				}
			}
		}
		Money.text = ActiveComponent.Model.P.Money + "$";
	}

	private void Update()
	{
		if ((long)Math.Round(_drawedMoney) != ActiveComponent.Model.P.Money)
		{
			if (!startDrawMoney)
			{
				_moneySpeed = Mathf.Abs((float)((double)ActiveComponent.Model.P.Money - _drawedMoney) / 2f);
			}
			startDrawMoney = true;
			_drawedMoney = UnityUtils.MoveTowards(_drawedMoney, ActiveComponent.Model.P.Money, _moneySpeed * (double)Time.deltaTime);
			Money.text = Logic.ColorTransform("BAD", (int)_drawedMoney + "$");
		}
		else
		{
			Money.text = Logic.ColorTransform("MONEY", (int)_drawedMoney + "$");
			startDrawMoney = false;
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			base.transform.parent.parent.gameObject.SetActive(value: false);
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		}
	}
}
