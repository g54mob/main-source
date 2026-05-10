using TMPro;
using UnityEngine;

public class ScaleItemDetailEntry : MonoBehaviour
{
	public struct ScaleItemData
	{
		public WeightedProductSO ProductSO;

		public int Count;
	}

	[SerializeField]
	private TMP_Text m_NameText;

	[SerializeField]
	private TMP_Text m_UnitText;

	[SerializeField]
	private TMP_Text m_TotalText;

	private Canvas m_Canvas;

	private void Awake()
	{
	}

	public void Show()
	{
	}

	public void Hide()
	{
	}

	public void SetData(ScaleItemData data)
	{
	}
}
