using PajamaLlama.Generic;
using PajamaLlama.Math;
using TMPro;
using UnityEngine;

public class EnergyGridInfoPanel : MonoBehaviour, IBuildablePanelElement, IDecorationPanelElement
{
	[SerializeField]
	private TextMeshProUGUI _efficiency;

	[SerializeField]
	private RangedFloat _efficiencyNeedleLimits = new RangedFloat(-90f, 90f);

	[SerializeField]
	private RectTransform _efficiencyNeedle;

	private EnergyGridConnector _component;

	BuildablePanelElementId IBuildablePanelElement.Id => BuildablePanelElementId.EnergyGridInformation;

	DecorationPanelElementId IDecorationPanelElement.Id => DecorationPanelElementId.EnergyGridInformation;

	public bool Activate(Buildable buildable, bool finished)
	{
		if (finished && buildable.TryGetComponent<EnergyGridConnector>(out _component))
		{
			base.gameObject.SetActive(value: true);
			return true;
		}
		return false;
	}

	public void Activate(Decoration decoration)
	{
		base.gameObject.SetActive(value: true);
		_component = decoration.GetComponent<EnergyGridConnector>();
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
		_component = null;
	}

	private void Update()
	{
		_efficiency.text = $"{_component.EnergyGrid.GridEfficiency:0%}";
		_efficiencyNeedle.rotation = Quaternion.Euler(_efficiencyNeedle.rotation.eulerAngles.SetZ(_efficiencyNeedleLimits.Evaluate(_component.EnergyGrid.GridEfficiency)));
	}
}
