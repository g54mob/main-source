using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ItemController : MonoBehaviour
{
	public delegate void UpdateUnseenFacts(int val);

	[NonSerialized]
	public InfoWindow parentWindow;

	public WindowContentController childEvContent;

	public List<ButtonController> spawnedChildEvButtons;

	public WindowContentController factContent;

	public List<FactButtonController> spawnedFactButtons;

	public ButtonController newCustomFactButton;

	public int unSeenFacts;

	private int prevUnSeenFacts;

	public List<string> debugFacts;

	public event UpdateUnseenFacts OnUpdateUnseenFacts
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Setup(InfoWindow newParent)
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateNameDisplay()
	{
	}

	public void UpdateFactsDisplay()
	{
	}

	public void PositionSpawnedFacts(float edgeMargin = 10f, float iconMargin = 6f)
	{
	}

	public void UpdateUnSeenFacts()
	{
	}

	public void NewCustomFactButton(ButtonController thisButton)
	{
	}
}
