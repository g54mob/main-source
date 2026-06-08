using System;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
	private static int caseHintsGiven = Save.GetHintsGiven();

	private static int queryHintsGiven = Save.GetQueryHintsGiven();

	private static int hintState = Save.GetHintState();

	private static int queryState = Save.GetQueryHintState();

	private static readonly HintTextGetter hintTextGetter = new HintTextGetter("Names/hints");

	private static readonly HintTextGetter queryHintTextGetter = new HintTextGetter("Names/query-hints");

	public static void SetQueryState(int queryState)
	{
		HintManager.queryState = queryState;
		Save.SaveQueryHintState(queryState);
		queryHintsGiven = 0;
		Save.SaveQueryHintGiven(0);
	}

	public static void ResetQueryState()
	{
		queryState = 0;
		Save.SaveQueryHintState(0);
	}

	public static void SetHintState(int hintLevel, int hintState, bool resetHintState = true)
	{
		if (hintLevel == LevelManager.GetCurrLevel() && HintManager.hintState < hintState)
		{
			SetHintState(hintState, resetHintState);
		}
	}

	public static void SetHintState(int hintState, bool resetHintState = true)
	{
		HintManager.hintState = hintState;
		Save.SaveHintState(hintState);
		if (resetHintState)
		{
			caseHintsGiven = 0;
			Save.SaveHintsGiven(0);
		}
	}

	public static void IncrementHintState(int incrementAmount)
	{
		if (GetIndex(hintState, incrementAmount) == 0)
		{
			hintState += incrementAmount;
			Save.SaveHintState(hintState);
		}
	}

	public static void SetHintsGiven(int hintsGiven)
	{
		caseHintsGiven = hintsGiven;
		Save.SaveHintsGiven(hintsGiven);
	}

	public static int GetHintState()
	{
		return hintState;
	}

	public static int GetQueryState()
	{
		return queryState;
	}

	public static void ResetHintState()
	{
		hintState = 0;
		caseHintsGiven = 0;
		Save.SaveHintState(0);
		Save.SaveHintsGiven(0);
	}

	private static void QuestionResponseHandler(AssistantDialogue dialogue, int incrementCount, int maxCase, Action<int> setDialogue, bool giveCaseHints = true)
	{
		dialogue.ClearQuestionAnswers();
		dialogue.SetThanksPrompt();
		int index = GetIndex(giveCaseHints ? caseHintsGiven : queryHintsGiven, incrementCount);
		setDialogue(index);
		if (index < maxCase)
		{
			if (giveCaseHints)
			{
				caseHintsGiven += incrementCount;
			}
			else
			{
				queryHintsGiven += incrementCount;
			}
		}
	}

	private static int GetIndex(int total, int value)
	{
		return total % (value * 10) / value;
	}

	public static void GetQueryHelp(AssistantDialogue dialogue)
	{
		int currentLevel = LevelManager.GetCurrLevel();
		switch (currentLevel)
		{
		case 0:
			dialogue.SetText(queryHintTextGetter.GetHint(currentLevel, 0, queryHintsGiven));
			break;
		case 1:
		case 2:
		case 3:
			switch (queryState)
			{
			case 0:
			case 1:
				PleaseReadBook();
				break;
			case 2:
				PleaseWriteQuery();
				break;
			default:
				dialogue.SetText(queryHintTextGetter.GetHint(currentLevel, Math.Min(queryState, 3), queryHintsGiven));
				break;
			}
			break;
		case 4:
			switch (queryState)
			{
			case 0:
			case 1:
				PleaseReadBook();
				break;
			case 3:
				PleaseWriteQuery();
				break;
			case 2:
			case 4:
				dialogue.SetText(queryHintTextGetter.GetHint(currentLevel, queryState, queryHintsGiven));
				if (queryState == 4 && queryHintsGiven > 3)
				{
					queryHintsGiven = -1;
				}
				break;
			}
			break;
		case 5:
			if (hintState <= 3)
			{
				dialogue.SetText(queryHintTextGetter.GetHint(currentLevel, (hintState >= 2) ? hintState : 0, queryHintsGiven));
				break;
			}
			if (queryState == 0)
			{
				PleaseReadBook();
				break;
			}
			dialogue.ClearQuestionAnswers();
			dialogue.EnableQuestions();
			dialogue.CreateQuestionAnswer("Question 2", delegate
			{
				int incrementCount = (int)Math.Pow(10.0, 3.0);
				QueryQuestionResponseHandler(currentLevel, incrementCount, 3, new List<string> { "movies", "reviews_ribbit78" });
			});
			dialogue.CreateQuestionAnswer("Question 3", delegate
			{
				int incrementCount = (int)Math.Pow(10.0, 4.0);
				QueryQuestionResponseHandler(currentLevel, incrementCount, 3, new List<string> { "nutrition_facts", "order_74b8s" });
			});
			dialogue.SetText("Which <i>selectyourstar</i> response\nare you trying to figure out?");
			break;
		case 6:
		{
			int num = queryState;
			if ((uint)num <= 1u)
			{
				PleaseReadBook();
			}
			else
			{
				dialogue.SetText(queryHintTextGetter.GetHint(currentLevel, 2, queryHintsGiven));
			}
			break;
		}
		case 7:
		{
			HashSet<string> allTableNames = DatabaseUtils.GetAllTableNames();
			if (!allTableNames.Contains("econ_hwk") && !allTableNames.Contains("sci_hwk") && !allTableNames.Contains("phil_hwk") && hintState < 8)
			{
				dialogue.SetText(queryHintTextGetter.GetHint(currentLevel, 0, queryHintsGiven));
				break;
			}
			dialogue.ClearQuestionAnswers();
			dialogue.EnableQuestions();
			if (allTableNames.Contains("econ_hwk"))
			{
				dialogue.CreateQuestionAnswer("Economics Homework", delegate
				{
					dialogue.ClearQuestionAnswers();
					dialogue.EnableQuestions();
					dialogue.CreateQuestionAnswer("Question 2", delegate
					{
						int incrementCount = (int)Math.Pow(10.0, 1.0);
						QueryQuestionResponseHandler(currentLevel, incrementCount, 5);
					});
					dialogue.CreateQuestionAnswer("Question 3", delegate
					{
						int incrementCount = (int)Math.Pow(10.0, 2.0);
						QueryQuestionResponseHandler(currentLevel, incrementCount, 5);
					});
					dialogue.SetText("Which question would you like\nhelp with?");
				});
			}
			if (allTableNames.Contains("sci_hwk"))
			{
				dialogue.CreateQuestionAnswer("Science Homework", delegate
				{
					dialogue.ClearQuestionAnswers();
					dialogue.EnableQuestions();
					dialogue.CreateQuestionAnswer("Question 2", delegate
					{
						int incrementCount = (int)Math.Pow(10.0, 3.0);
						QueryQuestionResponseHandler(currentLevel, incrementCount, 5);
					});
					dialogue.CreateQuestionAnswer("Question 3", delegate
					{
						int incrementCount = (int)Math.Pow(10.0, 4.0);
						QueryQuestionResponseHandler(currentLevel, incrementCount, 4);
					});
					dialogue.SetText("Which question would you like\nhelp with?");
				});
			}
			if (allTableNames.Contains("phil_hwk"))
			{
				dialogue.CreateQuestionAnswer("Philosophy Homework", delegate
				{
					dialogue.ClearQuestionAnswers();
					dialogue.EnableQuestions();
					dialogue.CreateQuestionAnswer("Question 2", delegate
					{
						int incrementCount = (int)Math.Pow(10.0, 5.0);
						QueryQuestionResponseHandler(currentLevel, incrementCount, 2);
					});
					dialogue.CreateQuestionAnswer("Question 3", delegate
					{
						int incrementCount = (int)Math.Pow(10.0, 6.0);
						QueryQuestionResponseHandler(currentLevel, incrementCount, 5);
					});
					dialogue.SetText("Which question would you like\nhelp with?");
				});
			}
			if (hintState >= 8)
			{
				dialogue.CreateQuestionAnswer("Finding Suspect Name", delegate
				{
					int incrementCount = (int)Math.Pow(10.0, 7.0);
					QueryQuestionResponseHandler(currentLevel, incrementCount, 6);
				});
			}
			dialogue.SetText("What do you need help with?");
			break;
		}
		case 8:
			if (queryState <= 2)
			{
				dialogue.SetText(queryHintTextGetter.GetHint(currentLevel, queryState, queryHintsGiven));
				break;
			}
			dialogue.ClearQuestionAnswers();
			dialogue.EnableQuestions();
			dialogue.CreateQuestionAnswer("Suit", delegate
			{
				dialogue.ClearQuestionAnswers();
				dialogue.SetThanksPrompt();
				dialogue.SetText(queryHintTextGetter.GetHint(currentLevel, 4, 0));
			});
			dialogue.CreateQuestionAnswer("Tie", delegate
			{
				dialogue.ClearQuestionAnswers();
				dialogue.EnableQuestions();
				dialogue.CreateQuestionAnswer("A3", delegate
				{
					int incrementCount = (int)Math.Pow(10.0, 2.0);
					QueryQuestionResponseHandler(currentLevel, incrementCount, 5);
				});
				dialogue.CreateQuestionAnswer("C7", delegate
				{
					int incrementCount = (int)Math.Pow(10.0, 3.0);
					QueryQuestionResponseHandler(currentLevel, incrementCount, 1);
				});
				dialogue.CreateQuestionAnswer("B2", delegate
				{
					int incrementCount = (int)Math.Pow(10.0, 4.0);
					QueryQuestionResponseHandler(currentLevel, incrementCount, 2);
				});
				dialogue.SetText(queryHintTextGetter.GetHint(currentLevel, 5, 0));
			});
			dialogue.SetText(queryHintTextGetter.GetHint(currentLevel, 3, 0));
			break;
		}
		queryHintsGiven++;
		Save.SaveQueryHintGiven(queryHintsGiven);
		void PleaseReadBook()
		{
			dialogue.SetText("Have you read the new chapter\navailable in the instructions manual?\nThere's some useful information there!");
		}
		void PleaseWriteQuery()
		{
			dialogue.SetText("Have you tried writing a query\nyourself first? If you want some\nexamples, there are some in the\ninstructions manual!");
		}
		void QueryQuestionResponseHandler(int level, int incrementCount, int maxHints, List<string> requiredTables = null)
		{
			QuestionResponseHandler(dialogue, incrementCount, maxHints, delegate(int switchCaseValue)
			{
				int num2 = incrementCount;
				int num3;
				if (requiredTables != null)
				{
					num3 = (ContainsTables() ? 1 : 0);
					if (num3 == 0)
					{
						num2--;
					}
				}
				else
				{
					num3 = 1;
				}
				dialogue.SetText(queryHintTextGetter.GetHint(level, num2, switchCaseValue));
				if (num3 == 0)
				{
					queryHintsGiven -= incrementCount;
				}
			}, giveCaseHints: false);
			bool ContainsTables()
			{
				HashSet<string> allTableNames2 = DatabaseUtils.GetAllTableNames();
				foreach (string requiredTable in requiredTables)
				{
					if (!allTableNames2.Contains(requiredTable))
					{
						return false;
					}
				}
				return true;
			}
		}
	}

	public static void GetCaseHelp(AssistantDialogue dialogue)
	{
		int currentLevel = LevelManager.GetCurrLevel();
		switch (currentLevel)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			SetHints(currentLevel, 1);
			break;
		case 4:
			SetHints(currentLevel, 2);
			break;
		case 5:
			if (hintState < 4)
			{
				SetHints(currentLevel, 3);
				break;
			}
			if (caseHintsGiven < 2)
			{
				dialogue.SetText(hintTextGetter.GetHint(currentLevel, hintState, caseHintsGiven));
				break;
			}
			dialogue.ClearQuestionAnswers();
			dialogue.EnableQuestions();
			dialogue.CreateQuestionAnswer("Question 1", delegate
			{
				int incrementCount = (int)Math.Pow(10.0, 2.0);
				QuestionResponseHandler(dialogue, incrementCount, 2, delegate(int switchCaseValue)
				{
					int num = incrementCount;
					bool num2 = GetIndex(hintState, 10000) > 0;
					if (!num2)
					{
						num--;
					}
					dialogue.SetText(hintTextGetter.GetHint(currentLevel, num, switchCaseValue));
					if (!num2)
					{
						caseHintsGiven -= incrementCount;
					}
				});
			});
			dialogue.CreateQuestionAnswer("Question 2", delegate
			{
				int incrementCount = (int)Math.Pow(10.0, 3.0);
				QuestionResponseHandler(dialogue, incrementCount, 2, delegate(int switchCaseValue)
				{
					int num = incrementCount;
					if (GetIndex(hintState, 100000) != 1)
					{
						num--;
					}
					dialogue.SetText(hintTextGetter.GetHint(currentLevel, num, switchCaseValue));
				});
			});
			dialogue.CreateQuestionAnswer("Question 3", delegate
			{
				int incrementCount = (int)Math.Pow(10.0, 4.0);
				QuestionResponseHandler(dialogue, incrementCount, 0, delegate(int switchCaseValue)
				{
					int num = incrementCount;
					if (GetIndex(hintState, 1000) != 1)
					{
						num--;
					}
					dialogue.SetText(hintTextGetter.GetHint(currentLevel, num, switchCaseValue));
				});
			});
			dialogue.CreateQuestionAnswer("Age", delegate
			{
				int incrementCount = (int)Math.Pow(10.0, 5.0);
				QuestionResponseHandler(dialogue, incrementCount, 2, delegate(int switchCaseValue)
				{
					dialogue.SetText(hintTextGetter.GetHint(currentLevel, incrementCount, switchCaseValue));
				});
			});
			dialogue.SetText("Which <i>selectyourstar</i> response\nare you trying to figure out?");
			break;
		case 6:
			SetHints(currentLevel, 8);
			if (hintState == 2 && caseHintsGiven >= 4)
			{
				caseHintsGiven = -1;
			}
			else if (hintState == 5)
			{
				caseHintsGiven--;
			}
			break;
		case 7:
			SetHints(currentLevel, 8);
			if (hintState == 8 && caseHintsGiven >= 4)
			{
				caseHintsGiven = -1;
			}
			break;
		case 8:
			if (hintState >= 1 && hintState <= 3)
			{
				dialogue.SetText(hintTextGetter.GetHint(currentLevel, 1, caseHintsGiven));
			}
			else if (hintState >= 5 && hintState <= 7)
			{
				dialogue.SetText(hintTextGetter.GetHint(currentLevel, 5, caseHintsGiven));
			}
			else
			{
				SetHints(currentLevel, 9);
			}
			break;
		}
		caseHintsGiven++;
		Save.SaveHintsGiven(caseHintsGiven);
		void LookAtEvidence()
		{
			dialogue.SetText("Have you tried looking at the\nevidence first?");
		}
		void SetHints(int level, int maxHintStates)
		{
			if (hintState == 0)
			{
				LookAtEvidence();
			}
			else
			{
				dialogue.SetText(hintTextGetter.GetHint(level, Math.Min(hintState, maxHintStates), caseHintsGiven));
			}
		}
	}
}
