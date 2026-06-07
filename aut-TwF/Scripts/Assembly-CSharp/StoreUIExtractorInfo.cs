using UnityEngine;
using UnityEngine.UI;

public class StoreUIExtractorInfo : MonoBehaviour
{
	[SerializeField]
	private Image resourceImage;

	[SerializeField]
	private TooltipComponent_text resourceNameTooltip;

	private Extractor selectedExtractor;

	public Extractor SelectedExtractor
	{
		get
		{
			return selectedExtractor;
		}
		set
		{
			selectedExtractor = value;
			LoadData();
		}
	}

	private void LoadData()
	{
		resourceImage.sprite = (SelectedExtractor.ValidSources[0].Obj as Source).Resource.Image;
		resourceNameTooltip.TooltipText = (SelectedExtractor.ValidSources[0].Obj as Source).Resource.DisplayName;
	}
}
