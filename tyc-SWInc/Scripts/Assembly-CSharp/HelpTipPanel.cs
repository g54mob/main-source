using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpTipPanel : MonoBehaviour
{
	public static HelpTipPanel Instance;

	public RectTransform Self;

	public Text Label;

	public HintController.Hints Hint;

	public GameObject[] Arrows;

	public Vector2[] Anchors;

	public Vector2[] Offsets;

	[NonSerialized]
	private RectTransform _target;

	[NonSerialized]
	private List<KeyValuePair<HintController.Hints, RectTransform>> _queue = new List<KeyValuePair<HintController.Hints, RectTransform>>();

	public static void Show(HintController.Hints hint, RectTransform target)
	{
		if (!(Instance != null) || !Options.HintsEnabled || !Options.HintEnabled(hint))
		{
			return;
		}
		if (Instance.gameObject.activeSelf)
		{
			if (Instance._queue.None((KeyValuePair<HintController.Hints, RectTransform> x) => x.Key.Equals(hint)))
			{
				Instance._queue.Add(new KeyValuePair<HintController.Hints, RectTransform>(hint, target));
			}
			return;
		}
		Instance.Label.text = hint.ToString().LocColor();
		Instance.gameObject.SetActive(true);
		LayoutRebuilder.ForceRebuildLayoutImmediate(Instance.Self);
		Instance._target = target;
		Instance.Hint = hint;
		Instance.Update();
	}

	public static void DismissHint(HintController.Hints hint)
	{
		if (Instance != null && Instance.Hint == hint && Instance.gameObject.activeSelf)
		{
			Instance.OnClick();
		}
	}

	private void Awake()
	{
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void Update()
	{
		if (_target != null && _target.gameObject != null && _target.gameObject.activeInHierarchy)
		{
			Vector2 pos;
			int side = GetSide(out pos);
			Self.pivot = Anchors[side];
			Self.anchoredPosition = new Vector2(pos.x, 0f - pos.y) + Offsets[side];
			for (int i = 0; i < 4; i++)
			{
				Arrows[i].SetActive(i == side);
			}
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	private int GetSide(out Vector2 pos)
	{
		Rect screen = RectTransformToScreenSpace(_target);
		float num = float.MaxValue;
		int num2 = 2;
		pos = new Vector2(0f, 0f);
		bool flag = false;
		if (screen.center.y < (float)Screen.height / 4f)
		{
			num2 = 1;
			num = screen.center.y - Self.rect.height / 2f;
			flag = true;
		}
		float num3 = screen.height - screen.center.y - Self.rect.height / 2f;
		if (screen.center.y > (float)Screen.height * 3f / 4f && num3 < num)
		{
			num2 = 3;
			num = num3;
			flag = true;
		}
		num3 = screen.center.x - Self.rect.width / 2f;
		if (screen.center.x < (float)Screen.width / 2f && num3 < num)
		{
			num2 = 0;
			num = num3;
			flag = true;
		}
		num3 = (float)Screen.width - screen.center.x - Self.rect.width / 2f;
		if (screen.center.x > (float)Screen.width * 3f / 4f && num3 < num)
		{
			num2 = 2;
			flag = true;
		}
		pos = PosFromSide(num2, screen);
		if (!flag && pos.x - Self.rect.width < 0f)
		{
			num2 = 1;
			pos = PosFromSide(num2, screen);
		}
		return num2;
	}

	private Vector2 PosFromSide(int res, Rect screen)
	{
		switch (res)
		{
		case 0:
			return new Vector2(screen.xMax, screen.center.y);
		case 1:
			return new Vector2(screen.center.x, screen.yMax);
		case 2:
			return new Vector2(screen.xMin, screen.center.y);
		case 3:
			return new Vector2(screen.center.x, screen.yMin);
		default:
			return Vector2.zero;
		}
	}

	public static Rect RectTransformToScreenSpace(RectTransform transform)
	{
		Vector2 vector = Vector2.Scale(transform.rect.size, transform.lossyScale);
		Vector2 vector2 = transform.GetUIScreenPosition() * (1f / Options.UISize);
		Rect result = new Rect(vector2.x, (float)Screen.height / Options.UISize - vector2.y, vector.x, vector.y);
		result.x -= transform.pivot.x * vector.x;
		result.y -= (1f - transform.pivot.y) * vector.y;
		return result;
	}

	public void OnClick()
	{
		Options.UpdateHint(Hint, false);
		base.gameObject.SetActive(false);
		if (_queue.Count > 0)
		{
			KeyValuePair<HintController.Hints, RectTransform> keyValuePair = _queue[0];
			_queue.RemoveAt(0);
			Show(keyValuePair.Key, keyValuePair.Value);
		}
	}
}
