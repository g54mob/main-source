using System.Collections.Generic;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using UnityEngine.UI;

public class DatacenterVisualizer : MonoBehaviour, ITooltip, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public Datacenter datacenter;

	[SerializeField]
	private Tooltip tooltipBuy;

	[SerializeField]
	private Tooltip tooltipState;

	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject unprovisionedImage;

	[SerializeField]
	private GameObject nominalImage;

	[SerializeField]
	private GameObject degradedImage;

	[SerializeField]
	private GameObject criticalImage;

	[SerializeField]
	private GameObject selectionContainer;

	[SerializeField]
	private RectTransform spinnerRotator;

	[SerializeField]
	private Image segmentTemplate;

	[SerializeField]
	private float nominalSpeed = 100f;

	[SerializeField]
	private float degradedSpeed = 50f;

	[SerializeField]
	private float criticalSpeed = 15f;

	[SerializeField]
	private int maxSegments = 10;

	[SerializeField]
	private float maxSegmentGap = 90f;

	[SerializeField]
	private float minSegmentGap = 5f;

	private DatacenterData _data;

	private readonly List<Image> _engineerSegments = new List<Image>();

	private bool _isSelected;

	private float _speed;

	public Tooltip Tooltip
	{
		get
		{
			if (!Database.State.Datacenters.IsUnlocked(_data))
			{
				return tooltipBuy;
			}
			return tooltipState;
		}
	}

	private void Update()
	{
		if (_isSelected)
		{
			spinnerRotator.Rotate(Vector3.back * (_speed * Time.deltaTime));
		}
	}

	public void Setup()
	{
		Initializer.Assign(datacenter.Data(), out _data).Context(button).AddListener(delegate
		{
			Database.State.Datacenters.Selected.Value = datacenter;
		})
			.Context(segmentTemplate.gameObject)
			.SetInactive()
			.Context(selectionContainer)
			.SetInactive()
			.Invoke(InitializeTooltip)
			.Invoke(CheckState);
		selectionContainer.SetActive(value: false);
		Database.State.Datacenters.Selected.Subscribe(HandleDatacenterSelected).AddTo(this);
		Database.State.Datacenters.StateChanged.ForDatacenter(_data.ID, _data.prerequisite).Subscribe(delegate
		{
			CheckState();
		}).AddTo(this);
		Database.State.Datacenters.HireChanged.ForDatacenter(_data.ID).Subscribe(delegate
		{
			CheckState();
		}).AddTo(this);
	}

	private void HandleDatacenterSelected(Datacenter dc)
	{
		if ((!_isSelected || datacenter != dc) && (_isSelected || datacenter == dc))
		{
			_isSelected = datacenter == dc;
			selectionContainer.SetActive(_isSelected);
			CheckState();
		}
	}

	public void CheckState()
	{
		DatacenterDetails valueOrDefault = Database.State.Datacenters.Details.GetValueOrDefault(_data);
		bool flag = Database.State.Datacenters.IsAvailable(_data);
		DatacenterState datacenterState = valueOrDefault?.State.Value ?? DatacenterState.Unprovisioned;
		unprovisionedImage?.SetActive(flag && (datacenterState == DatacenterState.Unprovisioned || datacenterState == DatacenterState.Construction));
		nominalImage?.SetActive(flag && datacenterState == DatacenterState.Nominal);
		degradedImage?.SetActive(flag && datacenterState == DatacenterState.Degraded);
		criticalImage?.SetActive(flag && datacenterState == DatacenterState.Critical);
		tooltipState.SetVariable("datacenter_state", LocalizationUtility.For(datacenterState));
		RebuildSpinner(valueOrDefault);
	}

	private void RebuildSpinner(DatacenterDetails details)
	{
		if (!_isSelected)
		{
			return;
		}
		_speed = details?.State.Value switch
		{
			DatacenterState.Nominal => nominalSpeed, 
			DatacenterState.Degraded => degradedSpeed, 
			DatacenterState.Critical => criticalSpeed, 
			_ => 0f, 
		};
		int num = Mathf.Min(details?.Engineers.Value ?? 0, maxSegments);
		if (_engineerSegments.Count == num)
		{
			return;
		}
		foreach (Image engineerSegment in _engineerSegments)
		{
			Object.Destroy(engineerSegment.gameObject);
		}
		_engineerSegments.Clear();
		if (num > 0)
		{
			float num2 = Mathf.Lerp(maxSegmentGap, minSegmentGap, Mathf.InverseLerp(1f, 10f, num));
			float num3 = 360f / (float)num;
			float fillAmount = Mathf.Max(0.001f, (num3 - num2) / 360f);
			for (int i = 0; i < num; i++)
			{
				Image image = Object.Instantiate(segmentTemplate, spinnerRotator);
				image.gameObject.SetActive(value: true);
				image.rectTransform.anchoredPosition = Vector2.zero;
				image.fillAmount = fillAmount;
				image.rectTransform.localRotation = Quaternion.Euler(0f, 0f, (float)(-i) * num3);
				_engineerSegments.Add(image);
			}
		}
	}

	private void InitializeTooltip()
	{
		DoubleVariable item = new DoubleVariable();
		Database.Modifiers.Observe(ModifierType.DatacenterCost).Subscribe((_data, item), delegate(double _, (DatacenterData _data, DoubleVariable costVariable) state)
		{
			state.costVariable.Value = Database.Commands.Datacenters.CalculateCostDatacenter(state._data);
		}).AddTo(this);
		tooltipBuy.SetVariables(("datacenter_title", _data.TitleLocalized), ("datacenter_cost", item));
		tooltipState.SetVariable("datacenter_title", _data.TitleLocalized);
	}
}
