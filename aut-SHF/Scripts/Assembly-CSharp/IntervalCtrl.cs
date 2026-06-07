using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IntervalCtrl : MonoBehaviour
{
	public Image mainImage;

	public RectTransform imageRect;

	public TMP_Text intervalTimeText;

	public Vector3 displayOffset;

	private bool _displayText;

	private double _maxIntervalTime;

	private double _intervalTime;

	private bool _isPlayInterval;

	private bool _imageOnlyMode;

	private UnityAction OnCompleteAction;

	private InputActionController input;

	public bool CompleteInterval => false;

	private void Awake()
	{
	}

	public void InitComponent(double timer, bool displayText = true, UnityAction OnCompleteAction = null)
	{
	}

	public void InitComponent()
	{
	}

	public void IntervalUpdate(double deltatime)
	{
	}

	public void ResetInterval()
	{
	}
}
