using System;
using UnityEngine;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
	protected const float LERP_SPEED = 5f;

	[SerializeField]
	[Tooltip("Whether or not the bar should hide when it's at min/max value. Mainly for world canvas bars such as enemy/module health.")]
	private bool hideOnMinMax = true;

	protected Image bgImage;

	[SerializeField]
	private FillBar fill;

	protected FillPointer pointer;

	protected RectTransform leftTf;

	protected RectTransform rightTf;

	[SerializeField]
	private GameObject segmentPrefab;

	private RectTransform[] segments;

	[NonSerialized]
	public bool isHidden;

	public FillBar Fill
	{
		get
		{
			return fill;
		}
		private set
		{
			fill = value;
		}
	}

	public FillBar Change { get; protected set; }

	protected void Awake()
	{
		bgImage = GetComponent<Image>();
		if (!fill)
		{
			fill = base.transform.Find("Fill").GetComponent<FillBar>();
		}
		leftTf = base.transform.Find("Left") as RectTransform;
		rightTf = base.transform.Find("Right") as RectTransform;
		Transform transform = base.transform.Find("Change");
		if ((bool)transform)
		{
			Change = transform.GetComponent<FillBar>();
		}
		Transform transform2 = base.transform.Find("Pointer");
		if ((bool)transform2)
		{
			pointer = transform2.GetComponent<FillPointer>();
		}
	}

	public void SetValues(float value01)
	{
		if (hideOnMinMax && (value01 == 0f || value01 == 1f))
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		if (!isHidden)
		{
			base.gameObject.SetActive(value: true);
		}
		fill.SetValue(value01);
		if ((bool)Change)
		{
			Change.SetValue(value01);
		}
		if ((bool)pointer)
		{
			pointer.SetValue(value01);
		}
	}

	public void SetSegmentCount(int count)
	{
		count--;
		if (segments != null && segments.Length != 0)
		{
			RectTransform[] array = segments;
			for (int i = 0; i < array.Length; i++)
			{
				UnityEngine.Object.Destroy(array[i].gameObject);
			}
		}
		segments = new RectTransform[count];
		float num = (Mathf.Abs(leftTf.anchoredPosition.x) + Mathf.Abs(rightTf.anchoredPosition.x)) / (float)(count + 1);
		for (int j = 0; j < count; j++)
		{
			Vector3 vector = new Vector3(leftTf.anchoredPosition.x + num * (float)j + num, -1f);
			GameObject gameObject = UnityEngine.Object.Instantiate(segmentPrefab, Vector3.zero, Quaternion.identity, base.transform);
			segments[j] = gameObject.transform as RectTransform;
			segments[j].anchoredPosition = vector;
		}
	}

	public void HideBar(bool hide)
	{
		if (hide)
		{
			base.gameObject.SetActive(value: false);
			isHidden = true;
		}
		else
		{
			base.gameObject.SetActive(value: true);
			isHidden = false;
		}
	}
}
