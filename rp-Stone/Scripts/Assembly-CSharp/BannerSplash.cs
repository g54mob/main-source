using System.Collections.Generic;
using UnityEngine;

public class BannerSplash : AsciiObject
{
	public enum State
	{
		Disabled = 0,
		Playing = 1,
		Done = 2
	}

	private class Row
	{
		public bool done;

		private float right;

		private float left;

		public float width;

		public int rightDelay;

		public int leftDelay;

		public float rightEaseOverX;

		public float leftEaseOverX;

		public float lerpSpeed;

		public float linearAdd;

		public int Left => (int)left;

		public int Right => (int)right;

		public void Reset()
		{
			done = false;
			right = -1f;
			left = -1f;
		}

		public void UpdateTic()
		{
			if (done)
			{
				return;
			}
			if (rightDelay > 0)
			{
				rightDelay--;
			}
			else if (right < width)
			{
				float num = Mathf.Abs(rightEaseOverX - right) * lerpSpeed;
				right += num + linearAdd;
				if (right > width)
				{
					right = width + 1f;
				}
			}
			if (leftDelay > 0)
			{
				leftDelay--;
			}
			else if (left < width)
			{
				float num2 = Mathf.Abs(leftEaseOverX - left) * lerpSpeed;
				left += num2 + linearAdd;
				if (left > width)
				{
					left = width + 1f;
				}
			}
			if (right >= width && left >= width)
			{
				done = true;
			}
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY, int leftSymbol, int centerSymbol, int rightSymbol, Color c)
		{
			int num = (int)left;
			int num2 = (int)right;
			for (int i = num + 1; i < num2 - 1; i++)
			{
				r.SetCell(offsetX + i, offsetY, centerSymbol, c);
			}
			r.SetCell(offsetX + num, offsetY, leftSymbol, c);
			r.SetCell(offsetX + num2 - 1, offsetY, rightSymbol, c);
		}
	}

	public int delayPerRow = 20;

	public int leftDelay = 30;

	public float rightEaseOverX = 31f;

	public float leftEaseOverX = 15f;

	public float lerpSpeed = 0.2f;

	public float linearAdd = 0.5f;

	public Color color = Color.white;

	public AsciiString line1;

	public AsciiString line2;

	private char leftSymbol = '/';

	private char rightSymbol = '/';

	private char topSymbol = '\u00af';

	private char bottomSymbol = '_';

	private State _currentState;

	private bool twoLines;

	private List<Row> rows;

	public State currentState => _currentState;

	public void Setup(string message1, string message2, Color message2Color)
	{
		if (message1.StartsWith("Pallas") && EventController.singleton.IsEventActiveAndStarted("halloween"))
		{
			message1 = "♪ Pallas, Prepped to Party ♫";
		}
		line1.SetValue(message1);
		twoLines = message2 != null;
		if (twoLines)
		{
			line2.SetValue(message2);
			line2.color = message2Color;
		}
		Reset();
	}

	public void Setup(string message1, string message2 = null)
	{
		Setup(message1, message2, line1.color);
	}

	public void Play()
	{
		_currentState = State.Playing;
	}

	private void Reset()
	{
		_currentState = State.Disabled;
		for (int i = 0; i < rows.Count; i++)
		{
			rows[i].Reset();
			rows[i].width = GameStates.Singleton.asciiRenderer.width;
			rows[i].rightDelay = i * delayPerRow;
			rows[i].leftDelay = rows[i].rightDelay + leftDelay;
			rows[i].rightEaseOverX = rightEaseOverX;
			rows[i].leftEaseOverX = leftEaseOverX;
			rows[i].lerpSpeed = lerpSpeed;
			rows[i].linearAdd = linearAdd;
		}
	}

	public override void UpdateTic()
	{
		if (_currentState != State.Playing)
		{
			return;
		}
		bool flag = true;
		for (int i = 0; i < rows.Count; i++)
		{
			rows[i].UpdateTic();
			if (!rows[i].done)
			{
				flag = false;
			}
		}
		if (flag)
		{
			_currentState = State.Done;
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		if (_currentState != State.Playing || !Hud.IsEnabled(Hud.Flag.BANNER))
		{
			return;
		}
		offsetX = offsetX;
		offsetY += r.height - rows.Count - 2 >> 1;
		int num = SpecialSymbols.Map(leftSymbol);
		int num2 = SpecialSymbols.Map(rightSymbol);
		int num3 = rows.Count;
		if (!twoLines)
		{
			num3--;
		}
		for (int i = 0; i < num3; i++)
		{
			int centerSymbol = ((i == 0) ? SpecialSymbols.Map(topSymbol) : ((i != num3 - 1) ? 32 : SpecialSymbols.Map(bottomSymbol)));
			rows[i].Draw(r, offsetX, offsetY + i, num, centerSymbol, num2, color);
			if (i == 1 || (i == 2 && twoLines))
			{
				r.PushClip(new AsciiRenderProcedural.Clip
				{
					left = rows[i].Left + offsetX + 1,
					right = r.width - rows[i].Right - offsetX + 1
				});
				((i == 1) ? line1 : line2).Draw(r, offsetX + (r.width >> 1), offsetY + i);
				r.PopClip();
			}
		}
	}

	private void Start()
	{
		rows = new List<Row>();
		for (int i = 0; i < 4; i++)
		{
			rows.Add(new Row());
		}
	}
}
