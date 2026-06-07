using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedText : Text
{
	public enum Animations
	{
		Rainbow = 1,
		Shake = 2,
		Bounce = 4,
		Wave = 8,
		Enthused = 0x10,
		Worried = 0x20
	}

	private List<UIVertex> _stream = new List<UIVertex>();

	public int MaxChars;

	public float CharSpeed = 0.1f;

	public float PeriodSpeed = 0.5f;

	public string Gender = "Female";

	private float _timer;

	private string _textNoSpaces;

	[SerializeField]
	[TextArea]
	private string _actualText;

	[NonSerialized]
	private byte[] _anims;

	private static Vector3[] _rndShake = new Vector3[31]
	{
		new Vector3(0f, 0f),
		new Vector3(1f, 0f),
		new Vector3(0f, 0f),
		new Vector3(0f, -1f),
		new Vector3(0f, 0f),
		new Vector3(0f, 0f),
		new Vector3(0f, -1f),
		new Vector3(-1f, 0f),
		new Vector3(0f, -1f),
		new Vector3(-1f, 1f),
		new Vector3(-1f, 0f),
		new Vector3(1f, -1f),
		new Vector3(0f, 0f),
		new Vector3(0f, -1f),
		new Vector3(-1f, 0f),
		new Vector3(-1f, -1f),
		new Vector3(1f, 0f),
		new Vector3(0f, -1f),
		new Vector3(0f, 0f),
		new Vector3(0f, -1f),
		new Vector3(0f, 1f),
		new Vector3(0f, 1f),
		new Vector3(-1f, 1f),
		new Vector3(0f, 1f),
		new Vector3(0f, 1f),
		new Vector3(-1f, -1f),
		new Vector3(-1f, 0f),
		new Vector3(0f, 1f),
		new Vector3(0f, -1f),
		new Vector3(-1f, -1f),
		new Vector3(0f, -1f)
	};

	public string ActualText
	{
		get
		{
			return _actualText;
		}
		set
		{
			_actualText = value;
			RefreshData();
		}
	}

	public bool Done
	{
		get
		{
			if (_actualText != null)
			{
				return MaxChars >= _textNoSpaces.Length;
			}
			return true;
		}
	}

	private static string CountNoWhiteSpace(string input)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < input.Length; i++)
		{
			if (!char.IsWhiteSpace(input[i]))
			{
				stringBuilder.Append(input[i]);
			}
		}
		return stringBuilder.ToString();
	}

	public void RefreshData()
	{
		m_Text = RecalculateText();
		MaxChars = 0;
		_timer = 0f;
	}

	private string RecalculateText()
	{
		if (_anims == null || _anims.Length != ActualText.Length)
		{
			_anims = new byte[ActualText.Length];
		}
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2 = new StringBuilder();
		StringBuilder stringBuilder3 = new StringBuilder();
		List<byte> list = new List<byte>();
		byte b = 0;
		byte b2 = 0;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < ActualText.Length; i++)
		{
			char c = ActualText[i];
			switch (num)
			{
			case 0:
				switch (c)
				{
				case '[':
					num = 1;
					break;
				case ']':
				{
					if (list.Count > 0)
					{
						list.RemoveAt(list.Count - 1);
					}
					b = 0;
					for (int j = 0; j < list.Count; j++)
					{
						b |= list[j];
					}
					break;
				}
				default:
					stringBuilder.Append(c);
					if (!char.IsWhiteSpace(c))
					{
						_anims[num2] = b;
						num2++;
						stringBuilder3.Append(c);
					}
					break;
				}
				break;
			case 1:
				switch (c)
				{
				case ',':
				{
					Animations result2;
					if (Enum.TryParse<Animations>(stringBuilder2.ToString(), true, out result2))
					{
						b2 |= (byte)result2;
					}
					stringBuilder2.Clear();
					break;
				}
				case ':':
				{
					Animations result;
					if (Enum.TryParse<Animations>(stringBuilder2.ToString(), true, out result))
					{
						b2 |= (byte)result;
					}
					list.Add(b2);
					b |= b2;
					b2 = 0;
					num = 0;
					stringBuilder2.Clear();
					break;
				}
				default:
					stringBuilder2.Append(c);
					break;
				}
				break;
			}
		}
		_textNoSpaces = stringBuilder3.ToString();
		return stringBuilder.ToString();
	}

	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		base.OnPopulateMesh(toFill);
		toFill.GetUIVertexStream(_stream);
		toFill.Clear();
		for (int i = 0; i < _stream.Count && i + 5 < _stream.Count; i += 6)
		{
			UIVertex v = _stream[i];
			UIVertex v2 = _stream[i + 1];
			UIVertex v3 = _stream[i + 2];
			UIVertex v4 = _stream[i + 4];
			int num = i / 6;
			if (num >= MaxChars)
			{
				v.color = Color.clear;
				v2.color = Color.clear;
				v3.color = Color.clear;
				v4.color = Color.clear;
			}
			else if (_anims != null && num < _anims.Length)
			{
				if ((_anims[num] & 1) > 0)
				{
					Rainbow(ref v, ref v2, ref v3, ref v4, num);
				}
				if ((_anims[num] & 2) > 0)
				{
					Shake(ref v, ref v2, ref v3, ref v4, num);
				}
				if ((_anims[num] & 4) > 0)
				{
					Bounce(ref v, ref v2, ref v3, ref v4, num);
				}
				if ((_anims[num] & 8) > 0)
				{
					Wave(ref v, ref v2, ref v3, ref v4, num);
				}
			}
			toFill.AddUIVertexQuad(new UIVertex[4] { v, v2, v3, v4 });
		}
		_stream.Clear();
	}

	private static void Rainbow(ref UIVertex v1, ref UIVertex v2, ref UIVertex v3, ref UIVertex v4, int c)
	{
		Color color = Utilities.HSVToRGBA((float)c / 10f - Time.realtimeSinceStartup, 1f, 1f);
		v1.color = color;
		v2.color = color;
		v3.color = color;
		v4.color = color;
	}

	private static void Shake(ref UIVertex v1, ref UIVertex v2, ref UIVertex v3, ref UIVertex v4, int c)
	{
		Vector3 vector = _rndShake[(Mathf.FloorToInt(Time.realtimeSinceStartup * 30f) + c * 3) % _rndShake.Length];
		v1.position += vector;
		v2.position += vector;
		v3.position += vector;
		v4.position += vector;
	}

	private static void Bounce(ref UIVertex v1, ref UIVertex v2, ref UIVertex v3, ref UIVertex v4, int c)
	{
		float num = Time.realtimeSinceStartup * 3f % 2f;
		num = Mathf.Abs(num - 1f).InOutCurve() * 3f;
		v1.position += new Vector3((0f - num) / 2f, num, 0f);
		v2.position += new Vector3(num / 2f, num, 0f);
	}

	private static void Wave(ref UIVertex v1, ref UIVertex v2, ref UIVertex v3, ref UIVertex v4, int c)
	{
		float num = ((float)c / 4f + Time.realtimeSinceStartup * 3f) % 2f;
		num = Mathf.Abs(num - 1f).InOutCurve() * 3f;
		Vector3 vector = new Vector3(0f, num, 0f);
		v1.position += vector;
		v2.position += vector;
		v3.position += vector;
		v4.position += vector;
	}

	private void Update()
	{
		if (_textNoSpaces == null || MaxChars >= _textNoSpaces.Length)
		{
			return;
		}
		int num = Mathf.Max(0, MaxChars - 1);
		char c = _textNoSpaces[num];
		if (char.IsLetterOrDigit(c) && (GameSettings.Instance.IsReferenceNull() || !GameSettings.Instance.MuteGuide))
		{
			string text = "Normal";
			if (_anims != null)
			{
				int num2 = Mathf.Clamp(num, 0, _anims.Length - 1);
				if ((_anims[num2] & 0x10) > 0)
				{
					text = "Enthused";
				}
				else if ((_anims[num2] & 0x20) > 0)
				{
					text = "Worried";
				}
			}
			UISoundFX.PlaySFX("Campaign" + Gender + text, UnityEngine.Random.Range(0.95f, 1.05f));
		}
		switch (c)
		{
		case '!':
		case '.':
		case ':':
		case '?':
			if (_timer >= PeriodSpeed)
			{
				_timer = 0f;
				MaxChars++;
			}
			break;
		case ',':
			if (_timer >= PeriodSpeed * 0.6f)
			{
				_timer = 0f;
				MaxChars++;
			}
			break;
		default:
			if (_timer >= CharSpeed)
			{
				_timer = 0f;
				MaxChars++;
			}
			break;
		}
		_timer += Time.deltaTime;
	}

	private void OnRenderObject()
	{
		SetVerticesDirty();
	}
}
