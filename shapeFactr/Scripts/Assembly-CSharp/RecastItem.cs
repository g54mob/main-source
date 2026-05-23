using System;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class RecastItem : MonoBehaviour
{
	[SerializeField]
	private Image luggageIcon;

	[SerializeField]
	private Image coverGage;

	[SerializeField]
	private TMP_Text recastTimeText;

	[SerializeField]
	private RectTransform stockContent;

	[SerializeField]
	private GameObject stockAmmo;

	[SerializeField]
	private SkeletonGraphicController chainSpine;

	private readonly string LockOn;

	private readonly string LockLoop;

	private double _recastTimer;

	private double _maxRecastTime;

	private const int _maxDisplayStock = 20;

	private GameObject[] _stocks;

	private bool _isStock;

	private bool _isLock;

	private double _lockTimer;

	private Action _releaseLockAction;

	public eLuggage LuggageId { get; private set; }

	public void InitInstance(eLuggage luggage, string iconPath, double recastTime, bool isStock)
	{
	}

	public void UpdateGage(double deltatime)
	{
	}

	public void Lock(double lockTime, Action releaseLockAction = null)
	{
	}

	public void ChangeInterval(double newValue)
	{
	}
}
