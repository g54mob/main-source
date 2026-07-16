using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReadyUpWindow : Menu
{
	[NonSerialized]
	public List<CardContainer> containers;

	[field: SerializeField]
	public GameObject mainPanel { get; private set; }

	[field: SerializeField]
	public GameObject choicePanel { get; private set; }

	[field: SerializeField]
	public Button discardButton { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI ScrapGainTxt { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI AmmoGainTxt { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI BossDamageGainTxt { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI ModuleGainTxt { get; private set; }

	[field: SerializeField]
	public TextMeshProUGUI RelicGainTxt { get; private set; }

	[field: SerializeField]
	public UnitAudioController unitAudioController { get; private set; }

	private void Start()
	{
		containers = new List<CardContainer>();
	}

	public void CouroutineStarter(IEnumerator coroutine)
	{
		StartCoroutine(coroutine);
	}

	protected override void OnOpen()
	{
		if (containers != null && containers.Count > 0)
		{
			StartCoroutine(ContainerDropCoroutine());
		}
	}

	protected override void OnClose()
	{
		if (containers == null || containers.Count <= 0)
		{
			return;
		}
		foreach (CardContainer container in containers)
		{
			container.gameObject.SetActive(value: false);
		}
	}

	private IEnumerator ContainerDropCoroutine()
	{
		foreach (CardContainer container in containers)
		{
			container.gameObject.SetActive(value: true);
			yield return new WaitForSecondsRealtime(0.1f);
		}
	}
}
