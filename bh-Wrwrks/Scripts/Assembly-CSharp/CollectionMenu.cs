using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectionMenu : Menu
{
	public SpriteRenderer items;

	public Checkbox upgChecker;

	public bool showUpgrades;

	public TMP_Text collectionText;

	public TMP_Text pageText;

	public List<Module> previews;

	public List<Module.Name> collection = new List<Module.Name>();

	private int currPage;

	private int maxPage;

	public List<Module> previewModules;

	public UIButton prevPage;

	public UIButton nextPage;

	private void Start()
	{
		items.sprite = Dungeon.Instance.currentLocale.collectionItems;
		InitCollection();
	}

	public override void BounceButton(UIButton b, int f = 2, bool silent = false)
	{
		if (f == 1)
		{
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.StartWire, 1.1f, 0.8f);
		}
		else
		{
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.DragModule, 0.9f, 0.5f);
		}
		base.BounceButton(b, f, silent);
	}

	public void InitCollection()
	{
		collection.Clear();
		List<Module.Name> list = new List<Module.Name>();
		list.AddRange(Dungeon.Instance.shop.GenericItems);
		list.AddRange(Dungeon.Instance.shop.Mechs);
		list.AddRange(Dungeon.Instance.shop.Pets);
		list.AddRange(Dungeon.Instance.shop.Wands);
		list.Remove(Module.Name.Mechatron);
		foreach (Module.Name item in list)
		{
			if (Dungeon.Instance.saveData.collection.Contains(item))
			{
				collection.Add(item);
			}
		}
		maxPage = Mathf.CeilToInt((float)collection.Count / 4f);
		float num = (float)collection.Count / (float)list.Count;
		num *= 100f;
		num = (int)num;
		string text = num.ToString((num > 99f) ? "000" : "00");
		collectionText.text = "            " + text + "%";
		ChangePage(0, silent: true);
	}

	public void ToggleUpgrade(bool state)
	{
		showUpgrades = state;
		ChangePage(0);
	}

	private void Update()
	{
		if (Input.mouseScrollDelta.y > 0f)
		{
			ChangePage(-1, silent: false, scroll: true);
		}
		if (Input.mouseScrollDelta.y < 0f)
		{
			ChangePage(1, silent: false, scroll: true);
		}
	}

	public void ChangePage(int x, bool silent = false, bool scroll = false)
	{
		if ((Camera.main.transform.position.x > -20f && !silent) || (currPage == 0 && x < 0) || (currPage == maxPage - 1 && x > 0))
		{
			return;
		}
		if (scroll)
		{
			Dungeon.Instance.tooltip.Hide(force: true);
			Dungeon.Instance.audioManager.PlaySound(AudioManager.Sound.StartWire, 1.1f, 0.8f);
		}
		currPage += x;
		pageText.text = "     " + (currPage + 1).ToString("00") + "/" + maxPage.ToString("00");
		prevPage.transform.localScale = Vector3.one;
		nextPage.transform.localScale = Vector3.one;
		if (currPage == 0)
		{
			prevPage.transform.localScale = Vector3.zero;
		}
		if (currPage + 1 == maxPage)
		{
			nextPage.transform.localScale = Vector3.zero;
		}
		foreach (Module previewModule in previewModules)
		{
			Object.Destroy(previewModule.gameObject);
		}
		previewModules.Clear();
		int num = currPage * 4;
		int num2 = 0;
		for (int i = num; i < num + 4 && i < collection.Count; i++)
		{
			Module component = Object.Instantiate(Dungeon.Instance.moduleObjects[(int)collection[i]]).GetComponent<Module>();
			component.SetPreview();
			previewModules.Add(component);
			component.transform.parent = base.transform;
			component.transform.localPosition = new Vector3(3.125f + (float)(num2 % 2 * 2) * 56f / 16f, 2.092803f - 4.125f * (float)(num2 / 2), 0f);
			previewModules.Add(component);
			if (showUpgrades)
			{
				component.ShopUp();
			}
			if (!silent)
			{
				StartCoroutine(jump(component.gameObject));
			}
			num2++;
		}
	}

	private IEnumerator jump(GameObject b, int f = 2)
	{
		bool sorter = true;
		if (Dungeon.Instance.mainmenu.anim != Mainmenu.animState.None)
		{
			sorter = false;
		}
		if (sorter)
		{
			SpriteRenderer[] componentsInChildren = b.GetComponentsInChildren<SpriteRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].sortingOrder += 10;
			}
		}
		for (int j = 0; j < f; j++)
		{
			if (b == null)
			{
				yield break;
			}
			b.transform.localPosition += new Vector3(0f, 0.0625f);
			yield return AnimationManager.WaitUI(1);
		}
		for (int j = 0; j < f; j++)
		{
			yield return AnimationManager.WaitUI(1);
			if (b == null)
			{
				yield break;
			}
			b.transform.localPosition -= new Vector3(0f, 0.0625f);
		}
		if (sorter)
		{
			SpriteRenderer[] componentsInChildren = b.GetComponentsInChildren<SpriteRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].sortingOrder += -10;
			}
		}
	}

	public override void CloseEffect()
	{
		StartCoroutine(_closeEffect());
	}

	private IEnumerator _closeEffect()
	{
		yield return Dungeon.WaitUI(7);
		foreach (Module previewModule in previewModules)
		{
			if (previewModule.GetUpgradePips() != null)
			{
				previewModule.GetUpgradePips().sortingOrder -= 2;
			}
		}
	}
}
