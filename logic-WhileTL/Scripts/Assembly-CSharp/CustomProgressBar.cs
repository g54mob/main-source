using App.Data;
using UnityEngine;
using UnityEngine.UI;

public class CustomProgressBar : ActiveComponent
{
	private Image hover;

	private Rect baseRect;

	private Image under;

	public bool vertical;

	public bool left;

	public bool inversiveColor;

	public bool showBorder;

	private Color green;

	private Color red;

	private GameObject borderObj;

	private GameObject border;

	private float curPerc;

	private float drawPerc;

	private float startPercTimer;

	private float barDelay = 0.2f;

	private float barSpeed;

	private float lastPerc = -1f;

	private bool init;

	private float curDrawPerc = -1f;

	public void SetBorder(App.Data.Result r)
	{
		if (showBorder)
		{
			if (border != null)
			{
				border.gameObject.SetActive(value: true);
			}
			else
			{
				border = Object.Instantiate(borderObj, base.transform.position, base.transform.rotation);
				border.transform.parent = base.gameObject.transform;
				border.transform.localScale = new Vector3(1.2f, 1f, 1f);
			}
			float height = base.gameObject.transform.GetComponent<RectTransform>().rect.height;
			border.transform.localPosition = new Vector3(0f, (float)(r.Accuracy - 50) * height / 100f, 0f);
		}
	}

	public void HideBorder()
	{
		if (border != null)
		{
			border.gameObject.SetActive(value: false);
		}
	}

	public void SetPercantage(float perc, bool left = false)
	{
		_ = lastPerc;
		lastPerc = perc;
		perc = Mathf.Min(perc, 1f);
		barSpeed = (perc - drawPerc) / barDelay;
		curPerc = perc;
		startPercTimer = Time.unscaledTime;
		init = true;
	}

	public void Clear()
	{
		drawPerc = 0f;
		barSpeed = 0f;
		RedrawBar();
	}

	public void RedrawBorder(App.Data.Result r)
	{
		SetBorder(r);
	}

	private void Awake()
	{
		hover = base.gameObject.GetComponentsInChildren<Image>()[1];
		baseRect = base.gameObject.GetComponent<RectTransform>().rect;
		borderObj = Resources.Load("Prefabs/BorderProgressBar") as GameObject;
		drawPerc = 0f;
	}

	private void RedrawBar()
	{
		if (Time.unscaledTime - startPercTimer < barDelay)
		{
			drawPerc += Time.unscaledDeltaTime * barSpeed;
		}
		float num = drawPerc;
		float perc = num;
		if (inversiveColor)
		{
			perc = 1f - num;
		}
		if (!vertical)
		{
			hover.rectTransform.sizeDelta = new Vector2(baseRect.width * num, baseRect.height);
			if (left)
			{
				hover.rectTransform.localPosition = new Vector2((0f - baseRect.width) / 2f * (1f - num), 0f);
			}
			else
			{
				hover.rectTransform.localPosition = new Vector2(baseRect.width / 2f * (1f - num), 0f);
			}
		}
		else
		{
			hover.rectTransform.sizeDelta = new Vector2(baseRect.width, baseRect.height * num);
			if (left)
			{
				hover.rectTransform.localPosition = new Vector2(0f, baseRect.height / 2f * (1f - num));
			}
			else
			{
				hover.rectTransform.localPosition = new Vector2(0f, (0f - baseRect.height) / 2f * (1f - num));
			}
		}
		hover.color = Logic.GetPercColor(perc);
	}

	private void Update()
	{
		if (init)
		{
			RedrawBar();
		}
	}
}
