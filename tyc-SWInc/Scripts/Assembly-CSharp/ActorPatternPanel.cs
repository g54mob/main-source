using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ActorPatternPanel : MonoBehaviour
{
	public RectTransform MainPanel;

	public RectTransform ContentPanel;

	public Color SelectedColor;

	[NonSerialized]
	private ActorBodyItemToggle _toggle;

	[NonSerialized]
	private RawImage[] _patternImages;

	private bool _initialized;

	public void Init()
	{
		if (_initialized)
		{
			return;
		}
		_initialized = true;
		GameObject gameObject = ContentPanel.GetChild(0).gameObject;
		int patternSizeX = ActorGenerator.Instance.PatternSizeX;
		int patternSizeY = ActorGenerator.Instance.PatternSizeY;
		float num = 1f / (float)patternSizeX;
		float num2 = 1f / (float)patternSizeY;
		int num3 = 1;
		GameObject obj = UnityEngine.Object.Instantiate(gameObject);
		obj.transform.SetParent(ContentPanel, false);
		obj.transform.SetSiblingIndex(0);
		RawImage componentInChildren = obj.GetComponentInChildren<RawImage>();
		componentInChildren.uvRect = new Rect(0f, 1f - num2, num * 0.5f, num2 * 0.5f);
		obj.GetComponent<Button>().onClick.AddListener(delegate
		{
			SetPattern(0);
		});
		_patternImages = new RawImage[ActorGenerator.Instance.PatternGroups.SumSafe((ActorGenerator.PatternGroup x) => x.Patterns.Length) + 1];
		_patternImages[0] = componentInChildren;
		for (int num4 = 0; num4 < ActorGenerator.Instance.PatternGroups.Length; num4++)
		{
			int[] patterns = ActorGenerator.Instance.PatternGroups[num4].Patterns;
			foreach (int k in patterns)
			{
				GameObject obj2 = UnityEngine.Object.Instantiate(gameObject);
				obj2.transform.SetParent(ContentPanel, false);
				obj2.transform.SetSiblingIndex(num3);
				RawImage componentInChildren2 = obj2.GetComponentInChildren<RawImage>();
				componentInChildren2.uvRect = new Rect((float)(k % patternSizeX) * num, (float)(patternSizeY - 1 - k / patternSizeX) * num2, num * 0.5f, num2 * 0.5f);
				obj2.GetComponent<Button>().onClick.AddListener(delegate
				{
					SetPattern(k);
				});
				_patternImages[k] = componentInChildren2;
				num3++;
			}
		}
		gameObject.gameObject.SetActive(false);
	}

	public void SelectPattern(int p)
	{
		for (int i = 0; i < _patternImages.Length; i++)
		{
			_patternImages[i].color = ((p == i) ? SelectedColor : Color.white);
		}
	}

	public void Show(ActorBodyItemToggle toggle)
	{
		Init();
		if (ActorCustomization.Instance.ColorDialog.Window.Shown)
		{
			ActorCustomization.Instance.ApplyColor();
		}
		SelectPattern(toggle.ActiveItem.PatternIndex);
		_toggle = toggle;
		ActorCustomization.Instance.DeactivateDuringColor.ForEachEnum(delegate(GameObject x)
		{
			x.SetActive(false);
		});
		base.gameObject.SetActive(true);
		MainPanel.localScale = new Vector3(0f, 1f, 1f);
		MainPanel.DOScaleX(1f, 0.5f).SetEase(Ease.OutBounce);
	}

	public void SetPattern(int i)
	{
		if (_toggle.ActiveItem != null)
		{
			_toggle.ActiveItem.SetPattern(i);
			ActorCustomization.Instance.UpdateActiveThumb();
			SelectPattern(i);
			_toggle.CheckPatternMapping();
		}
	}

	public void Close()
	{
		GameObject[] deactivateDuringColor = ActorCustomization.Instance.DeactivateDuringColor;
		foreach (GameObject gameObject in deactivateDuringColor)
		{
			if (!ActorCustomization.Instance.GetShouldDisable().Contains(gameObject))
			{
				gameObject.SetActive(true);
			}
		}
		base.gameObject.SetActive(false);
	}
}
