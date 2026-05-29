using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12ShieldingPuzzle : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _chargeSprite;

		[SerializeField]
		private Transform _targetSprite;

		[SerializeField]
		private float _maxCharge;

		[SerializeField]
		private T3PowerSwitch _lever;

		private ActiveWorldFrame _parent;

		private float _currentCharge;

		private float _targetCharge;

		private bool _discharging;

		private float _swapTimer;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
			SetupPuzzle();
		}

		private void SetupPuzzle()
		{
			_targetCharge = SeededRandom.Global.RandomRange(2f, 4f);
			_targetSprite.localPosition = new Vector3(_targetSprite.localPosition.x, _targetCharge - 2f, _targetSprite.localPosition.z);
		}

		private void Update()
		{
			_swapTimer -= Time.deltaTime;
			if (_swapTimer < 0f)
			{
				_chargeSprite.transform.localScale = new Vector3(_chargeSprite.transform.localScale.x * -1f, 1f, 1f);
				_swapTimer = 0.1f;
			}
			if (_discharging)
			{
				_currentCharge = Mathf.Max(0f, _currentCharge - Time.deltaTime * 4f);
				if (_currentCharge == 0f)
				{
					SetupPuzzle();
					_discharging = false;
				}
			}
			else if (_lever.Progress > 0.95f)
			{
				_currentCharge += Time.deltaTime * 2f;
				if (_currentCharge > _maxCharge)
				{
					_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Overcharged!");
					_discharging = true;
				}
			}
			else if (_currentCharge > 0f)
			{
				if (Mathf.Abs(_targetCharge - _currentCharge) < 0.15f)
				{
					UISounds.CraftStep();
					_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
				}
				else if (_targetCharge < _currentCharge)
				{
					_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Charge level exceeded!");
				}
				else
				{
					_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Insufficient charge!");
				}
				_discharging = true;
			}
			_chargeSprite.size = new Vector2(_chargeSprite.size.x, _currentCharge);
		}
	}
}
