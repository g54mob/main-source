using System.Collections.Generic;
using UnityEngine;

public class WorkstationScreen : QuestScreen
{
	public enum State
	{
		Normal = 0,
		Anvil = 1,
		Cauldron = 2,
		FissureStone = 3,
		TriskelionStone = 4,
		MindStone = 5,
		MoondialStone = 6
	}

	public AnvilScreen anvilScreenPrefab;

	public CauldronScreen cauldronScreenPrefab;

	public AsciiString emptyWorkstationMessage;

	private AnvilScreen anvilScreen;

	private CauldronScreen cauldronScreen;

	public State currentState { get; private set; }

	protected override List<Data.Quest> GetDataList()
	{
		return QuestController.singleton.AvailableWorkstationQuests;
	}

	private void SetState(State newState)
	{
		switch (newState)
		{
		case State.Anvil:
			anvilScreen.Show();
			break;
		case State.Cauldron:
			cauldronScreen.Show();
			break;
		case State.FissureStone:
			FissureStoneScreen.singleton.Show();
			break;
		case State.TriskelionStone:
			TriskelionScreen.singleton.Show();
			break;
		case State.MindStone:
			MindStoneScreen.singleton.Show();
			break;
		case State.MoondialStone:
			MoondialScreen.singleton.Show();
			break;
		}
		currentState = newState;
	}

	public override void UpdateTic()
	{
		if (currentState == State.Anvil)
		{
			anvilScreen.UpdateTic();
			if (anvilScreen.CurrentState == AnvilScreen.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.Cauldron)
		{
			cauldronScreen.UpdateTic();
			if (cauldronScreen.currentState == CauldronScreen.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.FissureStone)
		{
			FissureStoneScreen.singleton.UpdateTic();
			if (FissureStoneScreen.singleton.currentState == PopUpModalScreen.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.TriskelionStone)
		{
			TriskelionScreen.singleton.UpdateTic();
			if (TriskelionScreen.singleton.currentState == PopUpModalScreen.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.MindStone)
		{
			MindStoneScreen.singleton.UpdateTic();
			if (MindStoneScreen.singleton.currentState == PopUpModalScreen.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else if (currentState == State.MoondialStone)
		{
			MoondialScreen.singleton.UpdateTic();
			if (MoondialScreen.singleton.currentState == PopUpModalScreen.State.Disabled)
			{
				SetState(State.Normal);
			}
		}
		else
		{
			base.UpdateTic();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		if (rows.Count == 0)
		{
			emptyWorkstationMessage.Draw(r, offsetX, offsetY);
		}
		if (currentState == State.Anvil)
		{
			anvilScreen.Draw(r, r.width >> 1, 1);
		}
		else if (currentState == State.Cauldron)
		{
			cauldronScreen.Draw(r, r.width >> 1, 1);
		}
		if (currentState == State.FissureStone)
		{
			FissureStoneScreen.singleton.Draw(r, r.width >> 1, 0);
		}
		else if (currentState == State.TriskelionStone)
		{
			TriskelionScreen.singleton.Draw(r, r.width >> 1, 0);
		}
		else if (currentState == State.MindStone)
		{
			MindStoneScreen.singleton.Draw(r, r.width >> 1, 0);
		}
		else if (currentState == State.MoondialStone)
		{
			MoondialScreen.singleton.Draw(r, r.width >> 1, 0);
		}
	}

	protected override void HandleOnRowPressed(DialogButton button)
	{
		WorkstationRow workstationRow = button as WorkstationRow;
		if (workstationRow.mode == QuestRow.Mode.Normal && workstationRow.QuestData.id == "anvil")
		{
			QuestController.singleton.MarkAsPlayed("anvil");
			SfxController.singleton.Play("confirm");
			SetState(State.Anvil);
		}
		else if (workstationRow.mode == QuestRow.Mode.Normal && workstationRow.QuestData.id == "brew_potion")
		{
			QuestController.singleton.MarkAsPlayed("brew_potion");
			SfxController.singleton.Play("confirm");
			SetState(State.Cauldron);
		}
		else if (workstationRow.mode == QuestRow.Mode.Normal && workstationRow.QuestData.id == "break_apart_items")
		{
			QuestController.singleton.MarkAsPlayed("break_apart_items");
			SfxController.singleton.Play("confirm");
			SetState(State.FissureStone);
		}
		else if (workstationRow.mode == QuestRow.Mode.Normal && workstationRow.QuestData.id == "fuse_enchantments")
		{
			QuestController.singleton.MarkAsPlayed("fuse_enchantments");
			SfxController.singleton.Play("confirm");
			SetState(State.TriskelionStone);
		}
		else if (workstationRow.mode == QuestRow.Mode.Normal && workstationRow.QuestData.id == "automate")
		{
			QuestController.singleton.MarkAsPlayed("automate");
			SfxController.singleton.Play("confirm");
			SetState(State.MindStone);
		}
		else if (workstationRow.mode == QuestRow.Mode.Normal && workstationRow.QuestData.id == "mutate")
		{
			QuestController.singleton.MarkAsPlayed("mutate");
			SfxController.singleton.Play("confirm");
			SetState(State.MoondialStone);
		}
		else
		{
			base.HandleOnRowPressed(button);
		}
	}

	public void ShowFissureScreen()
	{
		SetState(State.FissureStone);
	}

	private void Awake()
	{
		anvilScreen = Object.Instantiate(anvilScreenPrefab);
		cauldronScreen = Object.Instantiate(cauldronScreenPrefab);
	}

	public int GetStateNumericRepresentation()
	{
		int num = (int)currentState * 100;
		if (currentState == State.Anvil)
		{
			num += anvilScreen.GetStateNumericRepresentation();
		}
		else if (currentState == State.Cauldron)
		{
			num += cauldronScreen.GetStateNumericRepresentation();
		}
		else if (currentState == State.FissureStone)
		{
			num += FissureStoneScreen.singleton.GetStateNumericRepresentation();
		}
		else if (currentState == State.MoondialStone)
		{
			num += MoondialScreen.singleton.GetStateNumericRepresentation();
		}
		else if (currentState == State.TriskelionStone)
		{
			num += TriskelionScreen.singleton.GetStateNumericRepresentation();
		}
		return num;
	}
}
