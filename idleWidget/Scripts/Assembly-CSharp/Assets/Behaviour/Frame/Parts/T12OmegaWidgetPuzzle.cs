using System.Collections;
using Assets.Source.World;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12OmegaWidgetPuzzle : MonoBehaviour
	{
		[SerializeField]
		private FrameGizmoShaker _casingShaker;

		[SerializeField]
		private FrameGizmoShaker _coreShaker;

		[SerializeField]
		private FrameGizmoShaker _processorShaker;

		[SerializeField]
		private FrameGizmoShaker _widgetShaker;

		[SerializeField]
		private FrameGizmoShaker _shieldShaker;

		[SerializeField]
		private T3PowerSwitch _casingLever;

		[SerializeField]
		private FrameButton _coreButton;

		[SerializeField]
		private FrameButton _processorButton;

		[SerializeField]
		private FrameButton _widgetButton;

		[SerializeField]
		private T6SiliconSlider _shieldSlider;

		[SerializeField]
		private FrameButton _finalButton;

		private bool _hasCasing;

		private bool _hasShielding;

		private bool _shieldWarned;

		private ActiveWorldFrame _parent;

		private void Start()
		{
			_parent = GetComponentInParent<ActiveWorldFrame>();
		}

		private void Update()
		{
			if (_casingLever.Progress > 0.95f && !_hasCasing)
			{
				UISounds.CraftStep();
				_casingLever.enabled = false;
				_hasCasing = true;
				_casingShaker.ForceActive = true;
			}
			if (_shieldSlider.Progress > 0.95f)
			{
				if (!_shieldWarned)
				{
					UISounds.CraftStep();
				}
				if (!_shieldWarned && _checkCasing() && _checkParts())
				{
					_shieldSlider.enabled = false;
					_hasShielding = true;
					_shieldShaker.ForceActive = true;
				}
				_shieldWarned = true;
			}
			else
			{
				_shieldWarned = false;
			}
		}

		public void CoreButtonClicked()
		{
			if (_checkCasing())
			{
				_coreButton.SetActive(active: false);
				_coreShaker.ForceActive = true;
			}
		}

		public void ProcessorButtonClicked()
		{
			if (_checkCasing())
			{
				_processorButton.SetActive(active: false);
				_processorShaker.ForceActive = true;
			}
		}

		public void WidgetButtonClicked()
		{
			if (_checkCasing())
			{
				_widgetButton.SetActive(active: false);
				_widgetShaker.ForceActive = true;
			}
		}

		private bool _checkCasing()
		{
			if (!_hasCasing)
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Casing not installed!");
				return false;
			}
			return true;
		}

		private bool _checkParts()
		{
			if (_coreButton.IsActive() || _processorButton.IsActive() || _widgetButton.IsActive())
			{
				_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Components not installed!");
				return false;
			}
			return true;
		}

		public void FinalizeButtonClicked()
		{
			if (_checkCasing() && _checkParts())
			{
				if (!_hasShielding)
				{
					_parent.ShowWarning(new WorldAnchor(WorldAnchorType.HandCraft, 0), "Shielding not charged!");
					return;
				}
				_finalButton.SetActive(active: false);
				_parent.ButtonClicked(new WorldAnchor(WorldAnchorType.HandCraft, 0));
				StartCoroutine(_setupPuzzle());
			}
		}

		private IEnumerator _setupPuzzle()
		{
			_casingLever.enabled = true;
			_shieldSlider.enabled = true;
			yield return new WaitForSeconds(1f);
			_hasShielding = false;
			_hasCasing = false;
			_coreButton.SetActive(active: true);
			_processorButton.SetActive(active: true);
			_widgetButton.SetActive(active: true);
			_finalButton.SetActive(active: true);
			_casingShaker.ForceActive = false;
			_coreShaker.ForceActive = false;
			_processorShaker.ForceActive = false;
			_widgetShaker.ForceActive = false;
			_shieldShaker.ForceActive = false;
		}
	}
}
