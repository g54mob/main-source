using System.Collections.Generic;
using Assets.Behaviour.UI;
using Assets.Source.Player;
using Assets.Source.World;
using Assets.Source.World.Frames;
using UnityEngine;
using UnityEngine.UI;

public class OverviewPurchaseMenu : MonoBehaviour
{
	public static TechNode FrameCountTech = "t4u_eagle_eye";

	[SerializeField]
	private ScrollRect _scroll;

	[SerializeField]
	private OverviewPurchaseButton _buttonPrefab;

	[SerializeField]
	private RectTransform _buttonParent;

	[SerializeField]
	private Image _tierPrefab;

	private void OnDisable()
	{
		if (GamePlayer.Current != null)
		{
			WorldOverview.Instance.HighlightCell(null);
		}
	}

	private void Update()
	{
		float y = PlayerControls.TraversalDelta.y;
		if (y != 0f)
		{
			_scroll.verticalNormalizedPosition += y * Time.deltaTime * 2000f / _buttonParent.sizeDelta.y;
		}
	}

	public void UpdateContents()
	{
		_buttonParent.DestroyChildren();
		List<FramePrefabSet> list = new List<FramePrefabSet>(WorldManager.Instance.OrderedFramePrefabs);
		list.Sort((FramePrefabSet a, FramePrefabSet b) => a.GetPreview().RequiredTech.Ordinal - b.GetPreview().RequiredTech.Ordinal);
		int num = 1;
		float num2 = 8f;
		float num3 = 4f;
		float num4 = 0f;
		bool flag = true;
		bool flag2 = GamePlayer.Current.HasTech(FrameCountTech);
		Dictionary<string, int> dictionary = null;
		if (flag2)
		{
			dictionary = new Dictionary<string, int>();
			foreach (WorldFrame frame in WorldMap.Current.Frames)
			{
				dictionary.TryGetValue(frame.Identifier, out var value);
				dictionary[frame.Identifier] = value + 1;
			}
		}
		while (flag && num < 14)
		{
			flag = false;
			Image image = Object.Instantiate(_tierPrefab, _buttonParent);
			image.sprite = SpriteLibrary.Get("Numerals_" + (num - 1));
			image.rectTransform.anchoredPosition = new Vector2(num2, num3 + 16f);
			num2 += 108f;
			foreach (FramePrefabSet item in list)
			{
				WorldFrame preview = item.GetPreview();
				if (preview.IsUnlocked && preview.Buildable && preview.Tier == num)
				{
					flag = true;
					OverviewPurchaseButton overviewPurchaseButton = Object.Instantiate(_buttonPrefab, _buttonParent);
					overviewPurchaseButton.SetFrame(item, preview);
					if (preview is T1GlitchedFrame)
					{
						overviewPurchaseButton.gameObject.AddComponent<GlitchedIcon>();
					}
					if (flag2)
					{
						dictionary.TryGetValue(preview.Identifier, out var value2);
						overviewPurchaseButton.SetFrameCount(value2);
					}
					((RectTransform)overviewPurchaseButton.transform).anchoredPosition = new Vector2(num2, num3);
					num2 += 140f;
				}
			}
			if (flag)
			{
				num4 = Mathf.Max(num4, num2);
				num2 = 8f;
				num3 += 140f;
				num++;
			}
		}
		_buttonParent.sizeDelta = new Vector2(num4, num3);
		if (base.transform is RectTransform rectTransform)
		{
			rectTransform.sizeDelta = new Vector2(num4 + 24f, rectTransform.sizeDelta.y);
		}
	}
}
