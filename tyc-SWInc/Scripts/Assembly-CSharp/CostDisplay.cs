using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostDisplay : MonoBehaviour
{
	private class Floater
	{
		public Text Obj;

		public float Time = 1f;

		public Floater(Text t)
		{
			Obj = t;
		}
	}

	private List<Floater> Floaters = new List<Floater>();

	public Text FloaterPrefab;

	private Text _mainFloater;

	public RectTransform FloaterPanel;

	public static CostDisplay Instance;

	public float Speed = 0.5f;

	public float Up = 256f;

	public float SideSpeed = 4f;

	public float Wideness = 2f;

	public ObjectPool<Text> _floatPool;

	public void Show(float price, Vector2 pos, Color color)
	{
		Show((double)price, pos, color);
	}

	public void Show(double price, Vector2 pos, Color color)
	{
		_mainFloater.text = price.Currency();
		_mainFloater.rectTransform.anchoredPosition = pos;
		_mainFloater.color = color;
		_mainFloater.gameObject.SetActive(true);
	}

	public void Show(float price, Vector3 pos)
	{
		Show(price, pos, GameSettings.Instance.MyCompany.CanMakeTransaction(0f - price) ? Color.white : Color.red);
	}

	public void Show(double price, Vector3 pos)
	{
		Show(price, pos, GameSettings.Instance.MyCompany.CanMakeTransaction(0.0 - price) ? Color.white : Color.red);
	}

	public void Show(float price, Vector3 pos, Color color)
	{
		Show((double)price, pos, color);
	}

	public void Show(double price, Vector3 pos, Color color)
	{
		Vector3 vector = CameraScript.Instance.SSAScript.WorldToScreenPoint(pos) / Options.UISize;
		if (pos.z >= 0f)
		{
			float num = vector.y - (float)Screen.height / Options.UISize;
			if (CameraScript.Instance.TopDown)
			{
				num += 32f;
			}
			Show(price, new Vector2(vector.x, num), color);
		}
		else
		{
			Hide();
		}
	}

	public void Hide()
	{
		if (_mainFloater != null && _mainFloater.gameObject != null)
		{
			_mainFloater.gameObject.SetActive(false);
		}
	}

	public void FloatAway(float price)
	{
		FloatAway((double)price);
	}

	public void FloatAway(double price)
	{
		Text t = MakeFloater(price.Currency(), _mainFloater.rectTransform.anchoredPosition);
		Floaters.Add(new Floater(t));
		Hide();
	}

	public void FloatAway()
	{
		Text t = MakeFloater(_mainFloater.text, _mainFloater.rectTransform.anchoredPosition);
		Floaters.Add(new Floater(t));
		Hide();
	}

	private void Start()
	{
		Instance = this;
		_floatPool = new ObjectPool<Text>(NewFloater, delegate(Text x)
		{
			x.gameObject.SetActive(true);
		}, delegate(Text x)
		{
			x.gameObject.SetActive(false);
		});
		_mainFloater = MakeFloater("", new Vector2(-1024f, -1024f));
		_mainFloater.gameObject.SetActive(false);
	}

	private Text NewFloater()
	{
		Text text = UnityEngine.Object.Instantiate(FloaterPrefab);
		text.transform.SetParent(FloaterPanel, false);
		return text;
	}

	private Text MakeFloater(string text, Vector2 pos)
	{
		Text text2 = _floatPool.Get();
		text2.text = text;
		text2.rectTransform.anchoredPosition = pos;
		return text2;
	}

	public void ClearFloaters()
	{
		Floaters.ForEach(delegate(Floater x)
		{
			_floatPool.Release(x.Obj);
		});
		Floaters.Clear();
	}

	private void Update()
	{
		for (int i = 0; i < Floaters.Count; i++)
		{
			Floaters[i].Time -= Time.deltaTime * Speed;
			Floaters[i].Obj.rectTransform.anchoredPosition += new Vector2(Mathf.Sin(Floaters[i].Time * (float)Math.PI * SideSpeed) * Wideness, Time.deltaTime * Up);
			Floaters[i].Obj.color = Floaters[i].Obj.color.Alpha(Floaters[i].Time.MapRange(0f, 0.1f, 0f, 1f, true));
			if (Floaters[i].Time <= 0f)
			{
				_floatPool.Release(Floaters[i].Obj);
				Floaters.RemoveAt(i);
				i--;
			}
		}
	}
}
