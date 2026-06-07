using System;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchVisualizer : MonoBehaviour
{
	[SerializeField]
	private LocalizeStringHandler titleHandler;

	[SerializeField]
	private LocalizeStringHandler costHandler;

	[SerializeField]
	private Image costBackground;

	[SerializeField]
	private Image image;

	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject activeHeader;

	private ResearchNode _research;

	public event Action<ResearchNode> Selected;

	public void Setup(ResearchView.ResearchNodeDataWrapper data)
	{
		EventHub.Scene.Subscribe(delegate
		{
			HandleResearch();
		}, (ResearchBought ctx) => ctx.Research == _research).AddTo(this);
		Initializer.Assign(data.Research, out _research).Context(titleHandler).SetLocalized(data.Title)
			.Context(costHandler)
			.SetValue(data.Cost)
			.Context(image)
			.Sprite(data.Sprite)
			.Context(button)
			.AddListener(delegate
			{
				this.Selected?.Invoke(_research);
			})
			.Context(activeHeader)
			.SetActive(Database.State.Research.IsUnlocked(_research))
			.Invoke(delegate
			{
				costHandler.GetComponent<TMP_Text>().enabled = !Database.State.Research.IsUnlocked(_research);
			});
	}

	private void HandleResearch()
	{
		activeHeader.SetActive(value: true);
		costHandler.GetComponent<TMP_Text>().enabled = false;
		costBackground.enabled = false;
	}
}
