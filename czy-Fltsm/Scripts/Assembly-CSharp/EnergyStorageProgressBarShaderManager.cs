using PajamaLlama.Generic;
using UnityEngine;

public class EnergyStorageProgressBarShaderManager : MonoBehaviour
{
	[SerializeField]
	private RangedFloat _fillAmountLimits;

	private Renderer _renderer;

	private IEnergyGridStorage _energyStorage;

	private void Awake()
	{
		_renderer = GetComponent<Renderer>();
	}

	public void Initialize(IEnergyGridStorage storage)
	{
		_energyStorage = storage;
		_energyStorage.OnEnergyUpdateEvent.AddListener(OnEnergyUpdate);
		OnEnergyUpdate();
	}

	private void OnDestroy()
	{
		if (_energyStorage != null)
		{
			_energyStorage.OnEnergyUpdateEvent.RemoveListener(OnEnergyUpdate);
		}
	}

	private void OnEnergyUpdate()
	{
		_renderer.material.SetFloat("_FillAmount", _fillAmountLimits.Evaluate(_energyStorage.NormalizedEnergyAmount));
	}
}
