using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class TownEnergyTrackerAnimationHandler : SceneBehaviour
{
	[SerializeField]
	private float _lowEnergyThreshold = 2000f;

	[SerializeField]
	private Image _border;

	[SerializeField]
	private Color _borderColorCooldown;

	[Range(1f, 100f)]
	[SerializeField]
	private float _borderColorLerpSpeed = 5f;

	private Animator _animator;

	private bool _isLowEnergy;

	private Color _borderColorDefault;

	protected override void Awake()
	{
		base.Awake();
		_borderColorDefault = _border.color;
	}

	private void Update()
	{
		float num = Community.PlayerCommunity.Engine.EnergyGrid.ReturnStorageEnergy();
		if (_isLowEnergy && num > _lowEnergyThreshold)
		{
			_isLowEnergy = false;
			_animator.SetBool("Is Low", _isLowEnergy);
		}
		else if (!_isLowEnergy && num <= _lowEnergyThreshold)
		{
			_isLowEnergy = true;
			_animator.SetBool("Is Low", _isLowEnergy);
		}
		if (Engine.IsCoolingDown)
		{
			float num2 = Engine.CooldownStartTime - Time.realtimeSinceStartup;
			_border.color = Color.Lerp(_borderColorDefault, _borderColorCooldown, (Mathf.Cos(num2 * _borderColorLerpSpeed) + 1f) / 2f);
		}
		else
		{
			_border.color = _borderColorDefault;
		}
	}

	private void OnEnable()
	{
		_animator = GetComponent<Animator>();
		float num = Community.PlayerCommunity.Engine.EnergyGrid.ReturnStorageEnergy();
		_isLowEnergy = num <= _lowEnergyThreshold;
		_animator.SetBool("Is Low", _isLowEnergy);
	}
}
