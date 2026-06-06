using TMPro;
using UnityEngine;

public class DrifterSlot : MonoBehaviour
{
	[SerializeField]
	private GameObject _emptySlot;

	[SerializeField]
	private GameObject _drifterSlot;

	[SerializeField]
	private OutlinedImage _drifterPortrait;

	[SerializeField]
	private TextMeshProUGUI _drifterName;

	public void SetDrifter(Agent drifter)
	{
		if ((bool)drifter)
		{
			SetDrifter(drifter.Descriptor);
		}
		else
		{
			ClearDrifter();
		}
	}

	public void SetDrifter(AgentDescriptor descriptor)
	{
		if (descriptor != null)
		{
			_emptySlot.SetActive(value: false);
			_drifterSlot.SetActive(value: true);
			_drifterPortrait.Initialize(PortraitGenerator.ReturnStaticPortrait(descriptor));
			_drifterName.text = descriptor.Name;
		}
		else
		{
			ClearDrifter();
		}
	}

	public void ClearDrifter()
	{
		_drifterSlot.SetActive(value: false);
		_emptySlot.SetActive(value: true);
	}
}
