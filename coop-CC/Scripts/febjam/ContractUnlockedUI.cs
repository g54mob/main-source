using System.Collections;
using System.Collections.Generic;
using Aggro.Core;
using UnityEngine;

public class ContractUnlockedUI : MonoBehaviour, IInputController
{
	public GameObject container;

	public LocalizedText contractName;

	public GameObject boxTemplate;

	[Space]
	public GameObject kbmContainer;

	public GameObject gamepadContainer;

	private List<PoolableReference<ContractUnlockedBoxUI>> _boxes = new List<PoolableReference<ContractUnlockedBoxUI>>();

	private bool _continue;

	private const int POPULATE_AMOUNT = 4;

	public EaseUI easeUI;

	public GameObject clickCatch;

	private void Awake()
	{
		container.SetActive(value: false);
		clickCatch.SetActive(value: false);
		boxTemplate.PopulateForTemplatePool(4);
		boxTemplate.SetActive(value: false);
	}

	public IEnumerator ShowUnlockCo(ContractObject contract)
	{
		container.SetActive(value: true);
		clickCatch.SetActive(value: true);
		easeUI.transform.localScale = Vector3.zero;
		easeUI.EaseIn();
		_boxes.ReleaseToPool();
		_boxes.Clear();
		contractName.SetIndex(contract.title);
		for (int i = 0; i < contract.orders.Length; i++)
		{
			ShiftOrderObject order = contract.orders[i];
			PoolableReference<ContractUnlockedBoxUI> fromTemplatePool = boxTemplate.GetFromTemplatePool<ContractUnlockedBoxUI>();
			fromTemplatePool.component.Sync(order);
			_boxes.Add(fromTemplatePool);
		}
		AggroInputManager.PushController(this);
		_continue = false;
		while (!_continue)
		{
			switch (AggroInputManager.mode)
			{
			case InputMode.KBM:
				kbmContainer.SetActive(value: true);
				gamepadContainer.SetActive(value: false);
				break;
			case InputMode.Gamepad:
				kbmContainer.SetActive(value: false);
				gamepadContainer.SetActive(value: true);
				break;
			default:
				throw new InvalidEnumException();
			}
			yield return null;
			if (AggroInputManager.input.UnlockMenu.Continue.WasPerformedThisFrame())
			{
				_continue = true;
			}
		}
		easeUI.EaseOut();
		yield return new WaitForSeconds(0.3f);
		AggroInputManager.RemoveController(this);
		container.SetActive(value: false);
		clickCatch.SetActive(value: false);
	}

	public void OnContinue()
	{
		_continue = true;
	}

	public void OnInputControlGained()
	{
		AggroInputManager.input.UnlockMenu.Enable();
		AggroInputManager.EnableUIModule();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.input.UnlockMenu.Disable();
	}
}
