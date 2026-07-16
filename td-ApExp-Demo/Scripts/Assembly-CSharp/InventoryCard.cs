using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class InventoryCard : MonoBehaviour
{
	[SerializeField]
	protected RectTransform rt;

	[SerializeField]
	protected TextMeshProUGUI textName;

	[SerializeField]
	protected TextMeshProUGUI textType;

	[SerializeField]
	protected TextMeshProUGUI textDesc;

	private void Awake()
	{
		Clear();
	}

	public virtual void SetEnhancement(Enhancement enh)
	{
		textName.text = enh.NameKey.GetLocalizedString();
		textType.text = StringFormatHelper.GetEnhancementString(enh);
		textDesc.text = enh.DescriptionKey.GetLocalizedString();
		LayoutRebuilder.ForceRebuildLayoutImmediate(rt);
	}

	public virtual void Clear()
	{
		textName.text = "";
		textType.text = "";
		textDesc.text = "";
	}
}
