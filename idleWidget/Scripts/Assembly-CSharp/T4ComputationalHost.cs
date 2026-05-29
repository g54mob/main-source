using System.Collections.Generic;
using Assets.Source.World;
using TMPro;
using UnityEngine;

public class T4ComputationalHost : MonoBehaviour
{
	[SerializeField]
	private TMP_Text _questionText;

	[SerializeField]
	private List<T4ComputationalButton> _buttons;

	private int _correctAnswer = -1;

	private ActiveWorldFrame _parentFrame;

	private float _newQuestionTimer;

	private void Start()
	{
		_parentFrame = GetComponentInParent<ActiveWorldFrame>();
		UpdateQuestion();
	}

	private void Update()
	{
		if (_newQuestionTimer > 0f)
		{
			_newQuestionTimer -= Time.deltaTime;
			if (_newQuestionTimer <= 0f)
			{
				UpdateQuestion();
			}
		}
	}

	public void UpdateQuestion()
	{
		int num = SeededRandom.Global.RandomRange(2, 10);
		int num2 = SeededRandom.Global.RandomRange(2, 10);
		char c;
		int num3;
		if (SeededRandom.Global.RandomBool())
		{
			c = '+';
			num3 = num + num2;
		}
		else
		{
			c = 'x';
			num3 = num * num2;
		}
		if (SeededRandom.Global.RandomBool())
		{
			int num4 = num;
			num = num3;
			num3 = num4;
			c = ((c == '+') ? '-' : '/');
		}
		int num5 = (_correctAnswer = SeededRandom.Global.RandomRange(0, _buttons.Count));
		int num6 = ((num3 <= 9) ? 1 : 2);
		int num7 = num3 - num6 * num5;
		for (int i = 0; i < _buttons.Count; i++)
		{
			_buttons[i].SetAnswer(num7 + i * num6);
		}
		_questionText.text = num + " " + c + " " + num2 + " = ?";
	}

	public void ClearQuestion()
	{
		_questionText.text = "";
		for (int i = 0; i < _buttons.Count; i++)
		{
			_buttons[i].SetAnswer(-1);
		}
	}

	public void ButtonClicked(int id)
	{
		ClearQuestion();
		if (id == _correctAnswer)
		{
			UISounds.CraftStep();
			_parentFrame.ActiveFrame.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
			_newQuestionTimer = 0.5f;
		}
		else
		{
			_parentFrame.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Input mismatch!");
			_newQuestionTimer = 1f;
		}
	}
}
