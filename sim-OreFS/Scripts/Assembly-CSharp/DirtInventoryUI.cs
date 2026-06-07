using System.Collections;
using TMPro;
using UnityEngine;

public class DirtInventoryUI : MonoBehaviour
{
	[Header("UI References")]
	public CanvasGroup panel;

	public TextMeshProUGUI countText;

	[Header("Settings")]
	public float hideDelay = 2f;

	private Coroutine hideCoroutine;

	private T_Equipments cachedEquipments;

	private void OnEnable()
	{
		TrySubscribe();
	}

	private void Start()
	{
		TrySubscribe();
	}

	private void TrySubscribe()
	{
		if (!(cachedEquipments != null))
		{
			T_Equipments t_Equipments = ((GameManager.Instance != null) ? GameManager.Instance.localEquipments : null);
			if (t_Equipments != null)
			{
				cachedEquipments = t_Equipments;
				cachedEquipments.OnDirtChanged += OnDirtChanged;
			}
		}
	}

	private void OnDisable()
	{
		if (cachedEquipments != null)
		{
			cachedEquipments.OnDirtChanged -= OnDirtChanged;
			cachedEquipments = null;
		}
	}

	private void OnDirtChanged(int current, int max)
	{
		UpdateDisplay(current, max);
	}

	public void Show()
	{
		if (!(panel == null))
		{
			if (hideCoroutine != null)
			{
				StopCoroutine(hideCoroutine);
				hideCoroutine = null;
			}
			panel.alpha = 1f;
			T_Equipments t_Equipments = ((GameManager.Instance != null) ? GameManager.Instance.localEquipments : null);
			if (t_Equipments != null)
			{
				UpdateDisplay(t_Equipments.currentDirt, t_Equipments.maxDirt);
			}
		}
	}

	public void ShowTemporary()
	{
		Show();
		if (hideCoroutine != null)
		{
			StopCoroutine(hideCoroutine);
		}
		hideCoroutine = StartCoroutine(HideAfterDelay());
	}

	private IEnumerator HideAfterDelay()
	{
		yield return new WaitForSeconds(hideDelay);
		Hide();
		hideCoroutine = null;
	}

	public void Hide()
	{
		if (!(panel == null))
		{
			panel.alpha = 0f;
		}
	}

	public void UpdateDisplay(int current, int max)
	{
		if (!(countText == null))
		{
			countText.text = $"{current}/{max}";
		}
	}
}
