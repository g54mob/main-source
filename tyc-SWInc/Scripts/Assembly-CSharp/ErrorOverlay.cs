using UnityEngine;
using UnityEngine.UI;

public class ErrorOverlay : MonoBehaviour
{
	private int Show;

	private bool Stay;

	private bool Timed;

	private bool AllowOverride;

	private float Timer = -1f;

	private string error;

	public RectTransform rect;

	public Text Label;

	public static ErrorOverlay Instance;

	public int LastShownFrame;

	private void Awake()
	{
		if (Instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
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

	public void ShowError(string nonloc, bool stay = false, bool timed = false, float timer = 0f, bool loc = true, bool allowOverride = false)
	{
		if (!string.IsNullOrEmpty(nonloc) && (!base.gameObject.activeSelf || (Time.frameCount != LastShownFrame && !allowOverride) || AllowOverride))
		{
			LastShownFrame = Time.frameCount;
			AllowOverride = allowOverride;
			base.gameObject.SetActive(true);
			Show = 4;
			Label.text = (loc ? nonloc.Loc() : nonloc);
			Stay = stay;
			Timed = timed;
			Timer = timer;
			LayoutRebuilder.ForceRebuildLayoutImmediate(rect);
		}
	}

	public void Clear()
	{
		base.gameObject.SetActive(false);
	}

	private void Update()
	{
		rect.anchoredPosition = new Vector2(Input.mousePosition.x, (float)(-Screen.height) + Input.mousePosition.y + 64f) * (1f / Options.UISize);
		if (Stay)
		{
			return;
		}
		if (Timed)
		{
			Timer -= Time.deltaTime;
			if (Timer <= 0f)
			{
				Timed = false;
				base.gameObject.SetActive(false);
			}
		}
		else
		{
			Show--;
			if (Show < 0)
			{
				base.gameObject.SetActive(false);
			}
		}
	}
}
