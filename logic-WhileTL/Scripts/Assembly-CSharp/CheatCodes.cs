using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheatCodes : ActiveComponent
{
	[SceneBind("Blocker")]
	public Button Blocker;

	[SceneBind("CheatLine")]
	public InputField CheatLine;

	private bool state;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		Blocker.onClick.AddListener(delegate
		{
			ChangeState(state: false);
		});
		ChangeState(state: false);
	}

	private void Start()
	{
		base.Init();
	}

	private void ChangeState(bool state)
	{
		this.state = state;
		Blocker.gameObject.SetActive(state);
		if (state)
		{
			CheatLine.gameObject.SetActive(value: true);
			CheatLine.Select();
			CheatLine.text = "";
		}
		else
		{
			CheatLine.OnDeselect(new BaseEventData(EventSystem.current));
			CheatLine.gameObject.SetActive(value: false);
		}
	}

	private void RunCheat()
	{
		string text = CheatLine.text;
		ChangeState(state: false);
		ActiveComponent.Model.activatedCheats.Add(text.ToUpper());
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.BackQuote))
		{
			ChangeState(!state);
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ChangeState(state: false);
		}
		if (Input.GetKeyDown(KeyCode.Return) && state)
		{
			RunCheat();
		}
	}
}
