using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScannerDevice : MonoBehaviour
{
	public GameObject marketApp;

	public bool IsScanning;

	public int SelectedProductID;

	public Action<ItemQuantity, SalesType> OnAddedItem;

	public Action<ItemQuantity> OnRemoveItem;

	[SerializeField]
	private Vector3 m_DisablePosition;

	[SerializeField]
	private Vector3 m_EnablePosition;

	[SerializeField]
	private ProductViewer m_ProductViewer;

	[SerializeField]
	private TMP_Text m_InventoryAmountText;

	[SerializeField]
	private TMP_Text m_UnitPriceText;

	[SerializeField]
	private TMP_Text m_QuantityText;

	[SerializeField]
	private RawImage m_ProductIcon;

	[SerializeField]
	private TMP_Text m_MultipleAmountText;

	[SerializeField]
	private Image m_AdditionFailedScreen;

	[SerializeField]
	private TMP_Text m_AdditionFailedTextScreen;

	[SerializeField]
	private Image m_After9PMScreen;

	[SerializeField]
	private TMP_Text m_After9PMTextScreen;

	[SerializeField]
	private AudioClip m_ScanSuccesClip;

	[SerializeField]
	private AudioClip m_ScanDeniedClip;

	[SerializeField]
	private Transform m_Scanner;

	[SerializeField]
	private float m_SwingTime;

	private AudioSource m_SFX;

	private Vector3 m_ScanAnimateTarget;

	private Vector3 m_ScanDefaultRotate;

	private Sequence m_Sequence;

	private Color m_DefaultTextColor;

	private Vector3 m_defaultScale;

	private bool m_IsGamepadMultipleButtonPressed;

	private const int m_MultipleSize = 5;

	public Action onTabletOpened;

	public Action onTabletClosed;

	public bool isOpened;

	public ProductViewer ProductViewer
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void Initialize()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGamepadMultiple(bool obj)
	{
	}

	private void OnGamepadConnected(bool obj)
	{
	}

	public void Animate(bool isOpen)
	{
	}

	public void ScannerDetechInteractable(IInteractable obj)
	{
	}

	public void UpdateScannerScreen(int _selectedProductID)
	{
	}

	public void PlayAudio(bool isFull)
	{
	}

	private void AnimateScanner()
	{
	}

	private void AdditionFailedScreen()
	{
	}

	public void AddCart(bool _)
	{
	}

	public void RemoveCart(bool _)
	{
	}
}
