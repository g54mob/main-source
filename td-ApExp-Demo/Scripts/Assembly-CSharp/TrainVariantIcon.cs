using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrainVariantIcon : MonoBehaviour
{
	[SerializeField]
	public Image Icon;

	[SerializeField]
	public Image Outline;

	[SerializeField]
	public Button Button;

	private NewTrainBase train;

	[field: SerializeField]
	public TextMeshProUGUI Name { get; private set; }

	[field: SerializeField]
	public TrainType TrainType { get; private set; }

	[field: SerializeField]
	public Sprite LockedIcon { get; private set; }

	[field: SerializeField]
	public List<Image> Bagdes { get; private set; }

	private void OnEnable()
	{
		foreach (NewTrainBase key in Train.Instance.trains.Keys)
		{
			if (key.trainType == TrainType)
			{
				train = key;
			}
		}
		if (Train.Instance.trains[train])
		{
			Name.text = "???";
			Icon.sprite = LockedIcon;
		}
		else
		{
			Name.text = train.NameTxt.GetLocalizedString();
			Icon.sprite = train.Icon;
		}
		for (int i = 0; i < Train.Instance.GetTrainByType(TrainType).WorldBeaten; i++)
		{
			Bagdes[i].enabled = true;
		}
	}
}
