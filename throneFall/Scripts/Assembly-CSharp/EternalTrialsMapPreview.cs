using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EternalTrialsMapPreview : MonoBehaviour
{
	public NightPreviewElement nightPreviewElementPrefab;

	public Transform nightPreviewParent;

	public UIParentResizer sizer;

	public TextMeshProUGUI goldNumber;

	private List<NightPreviewElement> previewElements = new List<NightPreviewElement>();

	public void SetData(List<WaveInfo> waves, int startingGold)
	{
		foreach (NightPreviewElement previewElement in previewElements)
		{
			previewElement.gameObject.SetActive(value: false);
		}
		int num = waves.Count - previewElements.Count;
		for (int i = 0; i < num; i++)
		{
			previewElements.Add(Object.Instantiate(nightPreviewElementPrefab, nightPreviewParent));
		}
		for (int j = 0; j < waves.Count; j++)
		{
			previewElements[j].gameObject.SetActive(value: true);
			previewElements[j].SetData(waves[j]);
		}
		goldNumber.text = "<sprite name=coin>" + startingGold;
		sizer.Trigger();
	}
}
