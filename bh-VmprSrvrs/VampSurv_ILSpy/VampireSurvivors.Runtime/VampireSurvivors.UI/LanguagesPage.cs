using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class LanguagesPage : BaseUIPage
{
	private LanguageController controller;

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		Selectable component = BackButtonController.Instance.GetComponent<Selectable>();
		LanguageController languageController = controller;
		List<GameObject> spawned = languageController.spawned;
		if (spawned._size > 0)
		{
			GameObject[] items = spawned._items;
			Selectable component2 = items[0].GetComponent<Selectable>();
			SetNavigationDown(component, component2);
		}
		else
		{
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		}
	}

	protected override void OnHideFinish(GameObject g)
	{
		base.OnHideFinish(g);
	}
}
