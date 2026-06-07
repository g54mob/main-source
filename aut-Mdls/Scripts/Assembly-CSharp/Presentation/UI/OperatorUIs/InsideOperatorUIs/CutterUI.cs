using System;
using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using Events;
using Events.Onboarding;
using Presentation.Shapes;
using Presentation.UI.Menus.MenuEvents.MenuData;
using UnityEngine;

namespace Presentation.UI.OperatorUIs.InsideOperatorUIs
{
	public class CutterUI : InsideOperatorUI
	{
		[Header("References")]
		[SerializeField]
		private CutterUIInterval _interval;

		[SerializeField]
		private CutterUIShapeHolograms _shapeHolograms;

		[SerializeField]
		private ShapeRotationControls _shapeRotationControls;

		[SerializeField]
		private ShapesDatabase _shapesDatabase;

		[Space]
		[SerializeField]
		private OperatorUpdateFrequencyText _inputFrequencyText;

		[SerializeField]
		private OperatorUpdateFrequencyText _outputFrequencyText;

		[SerializeField]
		private GameObject _outputTooMuchWarning;

		[SerializeField]
		private ConveyorBehaviour _conveyorBehaviour;

		[Header("Events")]
		[SerializeField]
		private ShowCutterShapeHologramEvent _showShapeHologramEvent;

		[SerializeField]
		private BaseEvent _hideShapeHologramEvent;

		private CutterBehaviour _behaviour;

		private List<ShapeDataSO> _onboardingShapeDatas;

		public ShapeLoader InputShape => _shapeHolograms.ShapeLoader;

		public ShapeLoader[] CutShapes => _shapeHolograms.CutShapes;

		public event Action<ShapeLoader> OnNewShapeEntered;

		protected override void Awake()
		{
			base.Awake();
			_showShapeHologramEvent.Register(ShowShapeHologram);
			_hideShapeHologramEvent.Register(HideShapeHologram);
			CutterUIInterval interval = _interval;
			interval.OnCutsChanged = (Action<IReadOnlyList<int>>)Delegate.Combine(interval.OnCutsChanged, new Action<IReadOnlyList<int>>(OnIntervalChanged));
			CutterUIShapeHolograms shapeHolograms = _shapeHolograms;
			shapeHolograms.OnEnterSequenceComplete = (Action<ShapeResource, ShapeLoader>)Delegate.Combine(shapeHolograms.OnEnterSequenceComplete, new Action<ShapeResource, ShapeLoader>(OnEnterSequenceComplete));
			CutterUIShapeHolograms shapeHolograms2 = _shapeHolograms;
			shapeHolograms2.OnShapesCutSequenceComplete = (Action)Delegate.Combine(shapeHolograms2.OnShapesCutSequenceComplete, new Action(OnShapesCutSequenceComplete));
			CutterUIShapeHolograms shapeHolograms3 = _shapeHolograms;
			shapeHolograms3.OnResetSequenceComplete = (Action)Delegate.Combine(shapeHolograms3.OnResetSequenceComplete, new Action(OnResetSequenceComplete));
			CutterUIShapeHolograms shapeHolograms4 = _shapeHolograms;
			shapeHolograms4.OnDestroySequenceComplete = (Action)Delegate.Combine(shapeHolograms4.OnDestroySequenceComplete, new Action(OnDestroySequenceComplete));
			_interval.Setup(this);
		}

		protected override void OnDestroy()
		{
			_showShapeHologramEvent.UnRegister(ShowShapeHologram);
			_hideShapeHologramEvent.UnRegister(HideShapeHologram);
			CutterUIInterval interval = _interval;
			interval.OnCutsChanged = (Action<IReadOnlyList<int>>)Delegate.Remove(interval.OnCutsChanged, new Action<IReadOnlyList<int>>(OnIntervalChanged));
			CutterUIShapeHolograms shapeHolograms = _shapeHolograms;
			shapeHolograms.OnEnterSequenceComplete = (Action<ShapeResource, ShapeLoader>)Delegate.Remove(shapeHolograms.OnEnterSequenceComplete, new Action<ShapeResource, ShapeLoader>(OnEnterSequenceComplete));
			CutterUIShapeHolograms shapeHolograms2 = _shapeHolograms;
			shapeHolograms2.OnShapesCutSequenceComplete = (Action)Delegate.Remove(shapeHolograms2.OnShapesCutSequenceComplete, new Action(OnShapesCutSequenceComplete));
			CutterUIShapeHolograms shapeHolograms3 = _shapeHolograms;
			shapeHolograms3.OnResetSequenceComplete = (Action)Delegate.Remove(shapeHolograms3.OnResetSequenceComplete, new Action(OnResetSequenceComplete));
			CutterUIShapeHolograms shapeHolograms4 = _shapeHolograms;
			shapeHolograms4.OnDestroySequenceComplete = (Action)Delegate.Combine(shapeHolograms4.OnDestroySequenceComplete, new Action(OnDestroySequenceComplete));
			base.OnDestroy();
		}

		private void ShapeRotated(ShapeLoader shapeLoader, string axisName, bool inverse)
		{
			this.OnNewShapeEntered?.Invoke(shapeLoader);
		}

		protected override void Reset(int param1 = 0)
		{
			_shapeHolograms.Reset();
		}

		protected override void Ready(int param1 = 0)
		{
			ShapeData orCreateShapeData = _shapesDatabase.GetOrCreateShapeData(InputShape.Shape);
			_behaviour.SetCuttingConfig(new List<int>(_interval.Cuts), _interval.CutInterval, _shapeHolograms.ShapeLoader.Rotation, orCreateShapeData);
			base.Ready();
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			CutterBehaviour cutterBehaviour = (_behaviour = (menuData as UIMenuBehaviourData).Behaviour as CutterBehaviour);
			_inputFrequencyText.Populate(_behaviour.FactoryObject.FactoryObjectData.UIData);
			UpdateOutputFrequencyText();
			base.ShowMenu(menuData);
			if (_behaviour.HasConfigResource)
			{
				if (cutterBehaviour.IsConfigured)
				{
					_shapeHolograms.ShowConfigShape(_behaviour.ConfigResource, cutterBehaviour.Cuts, cutterBehaviour.Rotation);
					_interval.SetCutsConfig(cutterBehaviour.Cuts, cutterBehaviour.CutInterval, this);
					base.IsConfigured = true;
				}
				else
				{
					_interval.Reset();
					_shapeHolograms.ShowConfigShape(_behaviour.ConfigResource);
				}
			}
			else
			{
				_interval.Reset();
				_behaviour.OnSetConfigResource.RegisterMainThread(ConfigResourceSet);
			}
			EnableReadyButton(enable: false);
		}

		public override void HideMenu()
		{
			base.HideMenu();
			_behaviour.OnReceivedShapeResource.UnRegisterMainThread(ConfigResourceSet);
			_shapeRotationControls.Hide();
			ShapeRotationControls shapeRotationControls = _shapeRotationControls;
			shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Remove(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(ShapeRotated));
			_behaviour.OnSetConfigResource.UnRegisterMainThread(ConfigResourceSet);
			_interval.Hide();
			_shapeHolograms.HideInstant();
			_outputTooMuchWarning.SetActive(value: false);
		}

		private void OnIntervalChanged(IReadOnlyList<int> cuts)
		{
			if (_shapeHolograms.TryShowCutShapes(cuts))
			{
				EnableReadyButton(_interval.HasCuts);
			}
			base.IsConfigured = false;
		}

		private void ConfigResourceSet(ShapeResource shapeResource)
		{
			_behaviour.OnSetConfigResource.UnRegisterMainThread(ConfigResourceSet);
			_shapeHolograms.ShowConfigShape(shapeResource, _interval.Cuts);
		}

		private void ShowShapeHologram((ShapeData, int) _)
		{
			EnableReadyButton(enable: false);
		}

		private void HideShapeHologram()
		{
			EnableReadyButton();
		}

		private void OnEnterSequenceComplete(ShapeResource resource, ShapeLoader shapeLoader)
		{
			_shapeRotationControls.Init(shapeLoader);
			_shapeRotationControls.Show();
			ShapeRotationControls shapeRotationControls = _shapeRotationControls;
			shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Combine(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(ShapeRotated));
			this.OnNewShapeEntered?.Invoke(shapeLoader);
		}

		private void OnShapesCutSequenceComplete()
		{
			UpdateOutputFrequencyText();
		}

		private void OnResetSequenceComplete()
		{
			base.Reset();
			_interval.Reset();
			_behaviour.OnSetConfigResource.RegisterMainThread(ConfigResourceSet);
			_shapeRotationControls.Hide();
			ShapeRotationControls shapeRotationControls = _shapeRotationControls;
			shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Remove(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(ShapeRotated));
			_behaviour.ResetCutterConfig();
		}

		private void OnDestroySequenceComplete()
		{
			_outputFrequencyText.Populate(0);
		}

		private void UpdateOutputFrequencyText()
		{
			if (_shapeHolograms.CutShapes.Length == 0)
			{
				_outputFrequencyText.Populate(0);
				return;
			}
			float num = _behaviour.UpdateFrequency;
			num /= (float)_shapeHolograms.CutShapes.Length;
			_outputFrequencyText.Populate(num);
			_outputTooMuchWarning.SetActive(num < (float)_conveyorBehaviour.VariableUpdateFrequency.Value);
		}

		private void Update()
		{
			ToggleReadyButtonDuringOnboarding();
		}

		private void ToggleReadyButtonDuringOnboarding()
		{
			if (_onboardingShapeDatas == null || _onboardingShapeDatas.Count <= 0)
			{
				return;
			}
			if (_shapeHolograms.CutShapes.Length != _onboardingShapeDatas.Count)
			{
				EnableReadyButton(enable: false);
				return;
			}
			for (int i = 0; i < _onboardingShapeDatas.Count; i++)
			{
				ShapeDataSO shapeDataSO = _onboardingShapeDatas[i];
				ShapeLoader shapeLoader = _shapeHolograms.CutShapes[i];
				RotationIndependentHash rotationIndependantHash = shapeDataSO.Data.RotationIndependantHash;
				bool flag = rotationIndependantHash.Contains(shapeLoader.Shape.GetShapeHash());
				if (shapeLoader.Shape == null || !flag)
				{
					EnableReadyButton(enable: false);
					return;
				}
			}
			EnableReadyButton();
		}

		public void SetRequiredOnboardingShapeData(List<ShapeDataSO> onboardingShapeDatas)
		{
			_onboardingShapeDatas = onboardingShapeDatas;
		}
	}
}
