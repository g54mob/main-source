using UnityEngine;

public class LiquidShaderManager : MonoBehaviour
{
	[Tooltip("This is the value we pass to the shader when there is no water in the liquid storage. Play with the fill amount in the material to get the correct value and inverse it.")]
	public float BottomValue;

	[Tooltip("This is the value we pass to the shader when the liquid storage is filled to the brim. Play with the fill amount in the material to get the correct value and inverse it.")]
	public float TopValue;

	[Tooltip("This is the value we pass to the shader when the liquid count is 0. This is lower than the bottom value, as the waving of the shader can cause clipping.")]
	public float NoneValue = -0.27f;

	[Tooltip("The time the shader has to go from the previous fill amount to the current fill amount.")]
	public float LerpTime = 1f;

	private float _previousFillAmount;

	private float _currentFillAmount;

	private float _currentLerpTime;

	private Renderer _renderer;

	private Inventory _inventory;

	private bool _initialized;

	private void Awake()
	{
		_renderer = GetComponent<Renderer>();
	}

	public void Initialize(Inventory inventory)
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.AddListener(UpdateLiquidStorageVisuals);
		_inventory = inventory;
		_initialized = true;
	}

	private void Update()
	{
		if (_initialized && !Mathf.Approximately(_currentFillAmount, _previousFillAmount))
		{
			_currentLerpTime += Time.deltaTime;
			if (_currentLerpTime >= LerpTime)
			{
				_currentLerpTime = LerpTime;
				_previousFillAmount = _currentFillAmount;
			}
			float t = _currentLerpTime / LerpTime;
			float num = Mathf.Lerp(_previousFillAmount, _currentFillAmount, t);
			_renderer.material.SetFloat("_FillAmount", num);
			if (num == _currentFillAmount)
			{
				_currentLerpTime = 0f;
			}
		}
	}

	private void OnDestroy()
	{
		Community.PlayerCommunity.Inventory.InventoryUpdatedEvent.RemoveListener(UpdateLiquidStorageVisuals);
	}

	private void UpdateLiquidStorageVisuals()
	{
		float num = _inventory.ReturnCount(SubInventoryType.Liquid, includeReserved: true);
		if (num == 0f)
		{
			num = NoneValue;
		}
		else
		{
			num /= (float)_inventory.ReturnCapacity(SubInventoryType.Liquid);
			num *= TopValue - BottomValue;
			num += BottomValue;
		}
		UpdateFillAmount(num);
	}

	private void UpdateFillAmount(float fill)
	{
		if (fill != _currentFillAmount)
		{
			float t = _currentLerpTime / LerpTime;
			_previousFillAmount = Mathf.Lerp(_previousFillAmount, _currentFillAmount, t);
			_currentFillAmount = fill;
			_currentLerpTime = 0f;
		}
	}
}
