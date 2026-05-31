using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class OrderNotebookProductEntry : MonoBehaviour, IPoolable
{
	public enum State
	{
		Undefined = 0,
		Invalid = 1,
		Valid = 2
	}

	private State m_State;

	[SerializeField]
	private Color[] m_StateColorMap;

	[SerializeField]
	private RawImage m_ProductIcon;

	[SerializeField]
	private TMP_Text m_NameText;

	[SerializeField]
	private TMP_Text m_CountText;

	[SerializeField]
	private TMP_Text m_PriceText;

	private int m_Count;

	private int m_ProductID;

	private int m_MaxCount;

	public int Count => 0;

	public int MaxCount => 0;

	public bool IsRequired => false;

	public OrderListData OrderData { get; set; }

	public float UnitPrice => 0f;

	public float TotalPrice => 0f;

	public void ClearValue(bool silent = false)
	{
	}

	public void AddValue(bool silent = false)
	{
	}

	public void RemoveValue(bool silent = false)
	{
	}

	public void SetProductID(int id)
	{
	}

	public void SetValue(int productId, int count, int maxCount)
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnLocaleChanged(Locale obj)
	{
	}

	public void UpdateDisplay()
	{
	}

	private void UpdateColor()
	{
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}
}
