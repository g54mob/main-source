using System;
using DG.Tweening;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using Events;
using Logic.Shapes;
using Presentation.Shapes;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.OperatorUIs.InsideOperatorUIs;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace Presentation.UI.OperatorUIs
{
	public class StamperMK2UI : InsideOperatorUI
	{
		private enum SelectedStampIdentifier
		{
			A = 0,
			B = 1
		}

		[Header("Refs")]
		[SerializeField]
		protected ShapeMeshLibrary _shapeMeshLibrary;

		[SerializeField]
		private Transform _shapeParent;

		[SerializeField]
		private Transform _shapeInputPos;

		[SerializeField]
		private Transform _stampOutputPos1;

		[SerializeField]
		private Transform _stampOutputPos2;

		[SerializeField]
		private Material _shapeMaterial;

		[SerializeField]
		private Material _stampedShapeMaterial;

		[SerializeField]
		private Material _indicatorShapeMaterial;

		[SerializeField]
		private Material _savedIndicatorAShapeMaterial;

		[SerializeField]
		private Material _savedIndicatorBShapeMaterial;

		[SerializeField]
		private ParticleSystem _shapeOutputParticle1;

		[SerializeField]
		private ParticleSystem _shapeOutputParticle2;

		[SerializeField]
		private ParticleSystem _shapeOutputParticleInitial;

		[SerializeField]
		private ShapeRotationControls _shapeRotationControls;

		[SerializeField]
		private Vector3 _stampedShapesOffset = Vector3.up;

		[Header("Shape Loaders")]
		[Space]
		[SerializeField]
		private OperatorUpdateFrequencyText _inputFrequencyText;

		[SerializeField]
		private OperatorUpdateFrequencyText _outputFrequencyText1;

		[SerializeField]
		private OperatorUpdateFrequencyText _outputFrequencyText2;

		[Header("Input")]
		[SerializeField]
		private InputActionReference _leftClick;

		[SerializeField]
		private InputActionReference _rightClick;

		[SerializeField]
		private InputActionReference _pointerPos;

		[SerializeField]
		private BaseEvent _updatePhysics;

		[Header("Animations")]
		[SerializeField]
		private float _enterAnimSpeed = 1f;

		[SerializeField]
		private AnimationCurve _enterAnimSpeedCurve;

		[SerializeField]
		private AnimationCurve _enterAnimScaleCurve;

		[Header("MK2 Specific multiple stamps")]
		[SerializeField]
		private MachineButton _stampASelectedButton;

		[SerializeField]
		private MachineButton _stampBSelectedButton;

		private ShapeLoader _shapeLoader;

		private Collider _shapeLoaderCollider;

		private bool _hasShape;

		private bool _hasSetPos1;

		private bool _onClickDown;

		private Vector2Int _pos1Stamp;

		private Vector2Int _pos2Stamp;

		private ShapeLoader _stampShape1;

		private ShapeLoader _stampShape2;

		private Sequence _currentSequence;

		private Sequence _resetSequence;

		private Sequence _firstEnterSequence;

		private ShapeLoader _indicatorShapeLoaderA;

		private ShapeLoader _indicatorShapeLoaderB;

		private ShapeLoader _previousIndicatorAShapeLoader;

		private ShapeLoader _previousIndicatorBShapeLoader;

		private SelectedStampIdentifier _selectedStampIdentifier;

		private Shape _excessShape;

		private StamperMK2Behaviour _behaviour;

		private Shape _currentShapeA;

		private Shape _currentShapeB;

		private Shape _selectedShapeA;

		private Shape _selectedShapeB;

		private Vector3Int _previousPos;

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			UIMenuBehaviourData uIMenuBehaviourData = menuData as UIMenuBehaviourData;
			_behaviour = uIMenuBehaviourData.Behaviour as StamperMK2Behaviour;
			_hasSetPos1 = false;
			_inputFrequencyText.Populate(_behaviour.FactoryObject.FactoryObjectData.UIData);
			UpdateOutputFrequencyText();
			SetupMultiStampShapeButtons();
			if (_behaviour.HasConfigResource)
			{
				ShowConfigShape(_behaviour.ConfigResourceShape);
				if (_behaviour.IsConfigured)
				{
					_shapeLoader.Position = ShapeUtils.SnapPositionToVoxelGrid(_shapeLoader.Position, _shapeLoader.Shape, _shapeParent.position);
					if (_behaviour.SelectedShapeA != null)
					{
						_selectedShapeA = Shape.CreateEmptyShape(_shapeParent.position, Vector3Int.zero, Color.black);
						_selectedShapeA.TrimBounds = false;
						_selectedShapeA.CopyData(_behaviour.SelectedShapeA);
						if (_previousIndicatorAShapeLoader != null)
						{
							UnityEngine.Object.Destroy(_previousIndicatorAShapeLoader.gameObject);
						}
						_previousIndicatorAShapeLoader = ShapeLoader.CreateFromShape(_selectedShapeA, _shapeMeshLibrary, _savedIndicatorAShapeMaterial, _shapeLoader.Position, Quaternion.identity);
						_previousIndicatorAShapeLoader.transform.SetParent(_shapeParent);
					}
					if (_behaviour.SelectedShapeB != null)
					{
						_selectedShapeB = Shape.CreateEmptyShape(_shapeParent.position, Vector3Int.zero, Color.black);
						_selectedShapeB.TrimBounds = false;
						_selectedShapeB.CopyData(_behaviour.SelectedShapeB);
						if (_previousIndicatorBShapeLoader != null)
						{
							UnityEngine.Object.Destroy(_previousIndicatorBShapeLoader.gameObject);
						}
						_previousIndicatorBShapeLoader = ShapeLoader.CreateFromShape(_selectedShapeB, _shapeMeshLibrary, _savedIndicatorBShapeMaterial, _shapeLoader.Position, Quaternion.identity);
						_previousIndicatorBShapeLoader.transform.SetParent(_shapeParent);
					}
					ShowStampedShapes();
					EnableStampButtons(enable: false);
					EnableReadyButton(enable: false);
				}
				else
				{
					EnableStampButtons(enable: true);
					EnableReadyButton(enable: false);
				}
			}
			else
			{
				_behaviour.OnSetConfigResource.RegisterMainThread(ShowConfigShape);
				EnableReadyButton(enable: false);
				EnableStampButtons(enable: true);
			}
			_leftClick.action.performed += OnClick;
			base.ShowMenu(menuData);
		}

		private void EnableStampButtons(bool enable)
		{
			_stampASelectedButton.Interactable = enable;
			_stampBSelectedButton.Interactable = enable;
		}

		private void SetupMultiStampShapeButtons()
		{
			_stampASelectedButton.OnClick += StampToggleClicked;
			_stampBSelectedButton.OnClick += StampToggleClicked;
			SelectStamp(SelectedStampIdentifier.A);
		}

		private void SelectStamp(SelectedStampIdentifier selectedStampIdentifier)
		{
			_selectedStampIdentifier = selectedStampIdentifier;
			switch (selectedStampIdentifier)
			{
			case SelectedStampIdentifier.A:
				_stampASelectedButton.IsPressed = true;
				_stampBSelectedButton.IsPressed = false;
				break;
			case SelectedStampIdentifier.B:
				_stampBSelectedButton.IsPressed = true;
				_stampASelectedButton.IsPressed = false;
				break;
			}
		}

		private void StampToggleClicked(int buttonParam, MachineButton button)
		{
			SelectStamp((SelectedStampIdentifier)buttonParam);
		}

		private void ShapeRotated(ShapeLoader shapeLoader, string axisName, bool inverseRotation)
		{
			if (_hasSetPos1)
			{
				_hasSetPos1 = false;
				ResetIndicator();
			}
			if (_stampShape1 != null)
			{
				RotateShapeLoader(_stampShape1, axisName, inverseRotation);
			}
			if (_stampShape2 != null)
			{
				RotateShapeLoader(_stampShape2, axisName, inverseRotation);
			}
			if (_previousIndicatorAShapeLoader != null)
			{
				RotateShapeLoader(_previousIndicatorAShapeLoader, axisName, inverseRotation);
				_previousIndicatorAShapeLoader.Position = _shapeLoader.Position;
			}
			if (_previousIndicatorBShapeLoader != null)
			{
				RotateShapeLoader(_previousIndicatorBShapeLoader, axisName, inverseRotation);
				_previousIndicatorBShapeLoader.Position = _shapeLoader.Position;
			}
			UpdateOutputFrequencyText();
		}

		private void RotateShapeLoader(ShapeLoader shapeLoader, string axisName, bool inverse)
		{
			if (!(axisName == "X"))
			{
				if (axisName == "Y")
				{
					shapeLoader.RotateShapeYAnimated(0.35f, inverse);
				}
			}
			else
			{
				shapeLoader.RotateShapeXAnimated(0.35f, inverse);
			}
		}

		private void ShowConfigShape(ShapeResource resource)
		{
			if ((bool)_shapeLoader)
			{
				return;
			}
			_behaviour.OnSetConfigResource.UnRegisterMainThread(ShowConfigShape);
			if (_shapeLoader != null)
			{
				UnityEngine.Object.Destroy(_shapeLoader.gameObject);
			}
			_shapeLoader = ShapeLoader.CreateFromShapeData(resource.ShapeData, _shapeMeshLibrary, _shapeMaterial, _shapeParent.transform.position, Quaternion.identity, createCollider: true);
			_shapeLoader.transform.SetParent(_shapeParent, worldPositionStays: true);
			_shapeLoaderCollider = _shapeLoader.GetComponent<Collider>();
			_shapeLoader.Position = ShapeUtils.SnapPositionToVoxelGrid(_shapeLoader.Position, _shapeLoader.Shape, _shapeParent.position);
			if (_behaviour.IsConfigured)
			{
				FinishSetupShowConfig();
				base.IsConfigured = true;
				return;
			}
			_firstEnterSequence = DOTween.Sequence();
			Vector3 position = _shapeInputPos.transform.position;
			Vector3 position2 = _shapeLoader.transform.position;
			_shapeLoader.transform.position = position;
			_shapeLoader.transform.localScale = Vector3.zero;
			_firstEnterSequence.Join(_shapeLoader.transform.DOMove(position2, _enterAnimSpeed).SetEase(_enterAnimSpeedCurve));
			_firstEnterSequence.Join(_shapeLoader.transform.DOScale(Vector3.one, _enterAnimSpeed).SetEase(_enterAnimScaleCurve));
			_firstEnterSequence.AppendCallback(delegate
			{
				FinishSetupShowConfig();
			});
			_audioManagerLocator.AudioManager.PlayInsideViewModuleEnter();
			_firstEnterSequence.Play();
			base.IsConfigured = false;
		}

		private void FinishSetupShowConfig()
		{
			_hasShape = true;
			_hasSetPos1 = false;
			_shapeRotationControls.Init(_shapeLoader);
			_shapeRotationControls.Show();
			ShapeRotationControls shapeRotationControls = _shapeRotationControls;
			shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Combine(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(ShapeRotated));
		}

		private void OnClick(InputAction.CallbackContext callbackContext)
		{
			if (!_behaviour.IsConfigured)
			{
				_onClickDown = callbackContext.ReadValueAsButton();
				if (_onClickDown)
				{
					SelectStartPos();
				}
				else
				{
					SelectEndPos();
				}
			}
		}

		private void Update()
		{
			if (!_hasShape)
			{
				return;
			}
			_updatePhysics.Fire();
			if (_behaviour.IsConfigured)
			{
				return;
			}
			if (PointerIsOnShapeCollider(out var hit))
			{
				Vector3 worldPos = hit.point + hit.normal * -0.05f;
				Vector3Int vector3Int = _shapeLoader.Shape.WorldPosToVoxelPos(worldPos);
				if (!(vector3Int == _previousPos))
				{
					_audioManagerLocator.AudioManager.PlayStamperSelection();
					_previousPos = vector3Int;
					Vector3Int bounds = _shapeLoader.Shape.GetBounds();
					if (vector3Int.x >= 0 && vector3Int.x < bounds.x && vector3Int.z >= 0 && vector3Int.z < bounds.z)
					{
						Vector3Int lowestValidVoxelPos = _shapeLoader.Shape.GetLowestValidVoxelPos(vector3Int);
						_currentShapeA = UpdateStampIndicator(SelectedStampIdentifier.A, vector3Int, lowestValidVoxelPos, ref _indicatorShapeLoaderA, ref _currentShapeA);
						_currentShapeB = UpdateStampIndicator(SelectedStampIdentifier.B, vector3Int, lowestValidVoxelPos, ref _indicatorShapeLoaderB, ref _currentShapeB);
					}
				}
			}
			else
			{
				ResetIndicator();
			}
		}

		private Shape UpdateStampIndicator(SelectedStampIdentifier givenStampIdentifier, Vector3Int pos, Vector3Int closestPos, ref ShapeLoader indicatorShapeLoader, ref Shape currentShape)
		{
			if (_selectedStampIdentifier == givenStampIdentifier)
			{
				ResetIndicator();
				Vector2Int vector2Int;
				Vector2Int rhs;
				if (!_hasSetPos1)
				{
					vector2Int = new Vector2Int(closestPos.x, closestPos.z);
					rhs = vector2Int;
				}
				else
				{
					vector2Int = _pos1Stamp;
					rhs = new Vector2Int(closestPos.x, closestPos.z);
				}
				Vector2Int vector2Int2 = Vector2Int.Min(vector2Int, rhs);
				Vector2Int vector2Int3 = Vector2Int.Max(vector2Int, rhs);
				Vector3Int minPos = new Vector3Int(vector2Int2.x, 0, vector2Int2.y);
				Vector3Int maxPos = new Vector3Int(vector2Int3.x, _shapeLoader.Shape.GetBounds().y, vector2Int3.y);
				if (!_hasSetPos1)
				{
					_shapeLoader.Shape.VoxelPosToWorldPos(_shapeLoader.Shape.GetLowestValidVoxelPos(closestPos));
				}
				else
				{
					Vector3Int pos2 = new Vector3Int(vector2Int2.x, _shapeLoader.Shape.GetBounds().y, vector2Int2.y);
					_shapeLoader.Shape.VoxelPosToWorldPos(_shapeLoader.Shape.GetLowestValidVoxelPos(pos2));
				}
				Shape item = _shapeLoader.Shape.Stamp(minPos, maxPos, calculateHash: true, calculateBounds: true, forceRecalculateOccupiedVoxels: true, trimBounds: false).Item1;
				item.Position = _shapeParent.position;
				item.VoxelPosToWorldPos(Vector3Int.zero);
				if (indicatorShapeLoader != null)
				{
					UnityEngine.Object.Destroy(indicatorShapeLoader.gameObject);
				}
				indicatorShapeLoader = ShapeLoader.CreateFromShape(item, _shapeMeshLibrary, _indicatorShapeMaterial, _shapeLoader.Position, Quaternion.identity);
				indicatorShapeLoader.transform.SetParent(_shapeParent);
				indicatorShapeLoader.name = "Indicator_ShapeLoader";
				return item;
			}
			return currentShape;
		}

		private void ResetIndicator()
		{
			if (_selectedStampIdentifier == SelectedStampIdentifier.A)
			{
				if (_indicatorShapeLoaderA != null)
				{
					UnityEngine.Object.Destroy(_indicatorShapeLoaderA.gameObject);
					_indicatorShapeLoaderA = null;
				}
			}
			else if (_indicatorShapeLoaderB != null)
			{
				UnityEngine.Object.Destroy(_indicatorShapeLoaderB.gameObject);
				_indicatorShapeLoaderB = null;
			}
		}

		private void SelectStartPos()
		{
			if (_hasShape)
			{
				if (PointerIsOnShapeCollider(out var hit))
				{
					Vector3 worldPos = hit.point + hit.normal * -0.05f;
					Vector3Int vector3Int = _shapeLoader.Shape.WorldPosToVoxelPos(worldPos);
					_pos1Stamp = new Vector2Int(vector3Int.x, vector3Int.z);
					_hasSetPos1 = true;
				}
				else
				{
					_hasSetPos1 = false;
				}
			}
		}

		private void SelectEndPos()
		{
			if (!_hasSetPos1 || !_hasShape)
			{
				return;
			}
			if (PointerIsOnShapeCollider(out var hit))
			{
				Vector3 worldPos = hit.point + hit.normal * -0.05f;
				Vector3Int vector3Int = _shapeLoader.Shape.WorldPosToVoxelPos(worldPos);
				_pos2Stamp = new Vector2Int(vector3Int.x, vector3Int.z);
				Vector2Int pos1Stamp = Vector2Int.Min(_pos1Stamp, _pos2Stamp);
				Vector2Int pos2Stamp = Vector2Int.Max(_pos1Stamp, _pos2Stamp);
				_pos1Stamp = pos1Stamp;
				_pos2Stamp = pos2Stamp;
				EnableReadyButton();
				if (_selectedStampIdentifier == SelectedStampIdentifier.A)
				{
					if (_selectedShapeA == null)
					{
						_selectedShapeA = Shape.CreateEmptyShape(_shapeParent.position, Vector3Int.zero, Color.black);
						_selectedShapeA.TrimBounds = false;
					}
					_selectedShapeA.CopyData(_currentShapeA);
					ShowPreviousIndicator(_selectedShapeA, _shapeLoader.Position);
				}
				else
				{
					if (_selectedShapeB == null)
					{
						_selectedShapeB = Shape.CreateEmptyShape(_shapeParent.position, Vector3Int.zero, Color.black);
						_selectedShapeB.TrimBounds = false;
					}
					_selectedShapeB.CopyData(_currentShapeB);
					ShowPreviousIndicator(_selectedShapeB, _shapeLoader.Position);
				}
				ShowStampedShapes();
			}
			_hasSetPos1 = false;
		}

		private bool PointerIsOnShapeCollider(out RaycastHit hit)
		{
			if (Physics.Raycast(_3DCamera.ScreenPointToRay(_pointerPos.action.ReadValue<Vector2>()), out hit) && Vector3.Dot(hit.normal, Vector3.up) > 0.9f)
			{
				return hit.collider == _shapeLoaderCollider;
			}
			return false;
		}

		private void ShowStampedShapes()
		{
			if (_currentSequence != null && _currentSequence.IsActive() && _currentSequence.IsPlaying())
			{
				_shapeOutputParticle1.Stop();
				_shapeOutputParticle2.Stop();
				_currentSequence.Kill();
				_currentSequence = null;
			}
			DestroyOldShapes();
			_currentSequence = DOTween.Sequence();
			_currentSequence.AppendCallback(delegate
			{
				if ((bool)_stampShape1)
				{
					UnityEngine.Object.Destroy(_stampShape1.gameObject);
				}
				if ((bool)_stampShape2)
				{
					UnityEngine.Object.Destroy(_stampShape2.gameObject);
				}
				Shape shape;
				Shape shape2;
				if (_behaviour.IsConfigured)
				{
					_excessShape = Shape.Create(_behaviour.ShapesToOutput[0].ShapeData);
					shape = Shape.Create(_behaviour.ShapesToOutput[1].ShapeData);
					shape2 = _excessShape;
				}
				else
				{
					shape = Shape.CreateEmptyShape(_shapeParent.position, Vector3Int.zero, Color.black);
					shape2 = Shape.CreateEmptyShape(_shapeParent.position, Vector3Int.zero, Color.black);
					shape.TrimBounds = false;
					shape2.TrimBounds = false;
					if (_selectedShapeA != null && _currentShapeB == null)
					{
						shape.CopyData(_selectedShapeA);
						shape2.CopyData(_shapeLoader.Shape.Subtract(_selectedShapeA, calculateHash: true, calculateBounds: true, trimBounds: false));
					}
					if (_selectedShapeB != null)
					{
						if (_selectedShapeA != null)
						{
							shape.CopyData(_selectedShapeA.Combine(_selectedShapeB, calculateHash: true, calculateBounds: true, trimBounds: false));
							shape2.CopyData(_shapeLoader.Shape.Subtract(shape, calculateHash: true, calculateBounds: true, trimBounds: false));
						}
						else
						{
							shape.CopyData(_selectedShapeB);
							shape2.CopyData(_shapeLoader.Shape.Subtract(_selectedShapeB, calculateHash: true, calculateBounds: true, trimBounds: false));
						}
					}
					if (_excessShape == null)
					{
						_excessShape = Shape.CreateEmptyShape(_shapeParent.position, Vector3Int.zero, Color.black);
					}
					_excessShape.TrimBounds = false;
					_excessShape.CopyData(shape2);
				}
				_stampShape1 = ShapeLoader.CreateFromShape(shape, _shapeMeshLibrary, _stampedShapeMaterial, _stampOutputPos1.transform.position + _stampedShapesOffset, Quaternion.identity);
				_stampShape2 = ShapeLoader.CreateFromShape(shape2, _shapeMeshLibrary, _stampedShapeMaterial, _stampOutputPos2.transform.position + _stampedShapesOffset, Quaternion.identity);
				_stampShape1.transform.localScale = Vector3.zero;
				_stampShape2.transform.localScale = Vector3.zero;
				_stampShape1.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
				_stampShape2.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
				UpdateOutputFrequencyText();
			});
			_currentSequence.Play();
		}

		private void DestroyOldShapes()
		{
			if ((bool)_stampShape1)
			{
				_shapeOutputParticle1.Play();
				AnimateDestroy(_currentSequence, _stampShape1, append: true);
			}
			if ((bool)_stampShape2)
			{
				_shapeOutputParticle2.Play();
				AnimateDestroy(_currentSequence, _stampShape2, _stampShape1 == null);
			}
		}

		private void AnimateDestroy(Sequence sequence, ShapeLoader shapeLoader, bool append)
		{
			shapeLoader.transform.localScale = Vector3.one;
			if (append)
			{
				sequence.Append(shapeLoader.transform.DOScale(Vector3.zero, 0.15f).SetEase(Ease.InBack));
			}
			else
			{
				sequence.Join(shapeLoader.transform.DOScale(Vector3.zero, 0.15f).SetEase(Ease.InBack));
			}
		}

		private void ShowPreviousIndicator(Shape shape, Vector3 position)
		{
			if (!_hasShape)
			{
				return;
			}
			if (_selectedStampIdentifier == SelectedStampIdentifier.A)
			{
				if (_previousIndicatorAShapeLoader != null)
				{
					UnityEngine.Object.Destroy(_previousIndicatorAShapeLoader.gameObject);
				}
				_previousIndicatorAShapeLoader = ShapeLoader.CreateFromShape(shape, _shapeMeshLibrary, _savedIndicatorAShapeMaterial, position, Quaternion.identity);
				_previousIndicatorAShapeLoader.transform.SetParent(_shapeParent);
				_previousIndicatorAShapeLoader.name = "Previous_ShapeLoader_Selection_A";
			}
			else
			{
				if (_previousIndicatorBShapeLoader != null)
				{
					UnityEngine.Object.Destroy(_previousIndicatorBShapeLoader.gameObject);
				}
				_previousIndicatorBShapeLoader = ShapeLoader.CreateFromShape(shape, _shapeMeshLibrary, _savedIndicatorBShapeMaterial, position, Quaternion.identity);
				_previousIndicatorBShapeLoader.transform.SetParent(_shapeParent);
				_previousIndicatorBShapeLoader.name = "Previous_ShapeLoader_Selection_B";
			}
		}

		protected override void Reset(int param1 = 0)
		{
			base.Reset(param1);
			if ((_firstEnterSequence != null && _firstEnterSequence.IsActive() && _firstEnterSequence.IsPlaying()) || (_resetSequence != null && _resetSequence.IsActive() && _resetSequence.IsPlaying()))
			{
				return;
			}
			DestroyAllIndicators();
			_resetSequence = DOTween.Sequence();
			if ((bool)_shapeLoader)
			{
				_shapeOutputParticleInitial.Play();
				AnimateDestroy(_resetSequence, _shapeLoader, append: false);
			}
			if ((bool)_stampShape1)
			{
				_shapeOutputParticle1.Play();
				AnimateDestroy(_resetSequence, _stampShape1, append: false);
			}
			if ((bool)_stampShape2)
			{
				_shapeOutputParticle2.Play();
				AnimateDestroy(_resetSequence, _stampShape2, append: false);
			}
			_currentShapeA = null;
			_currentShapeB = null;
			_selectedShapeA = null;
			_selectedShapeB = null;
			_excessShape = null;
			EnableStampButtons(enable: true);
			SelectStamp(SelectedStampIdentifier.A);
			_resetSequence.AppendCallback(delegate
			{
				base.Reset();
				_hasSetPos1 = false;
				ResubscribeToConfigShapeEvent();
				_shapeRotationControls.Hide();
				ShapeRotationControls shapeRotationControls = _shapeRotationControls;
				shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Remove(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(ShapeRotated));
				if ((bool)_shapeLoader)
				{
					UnityEngine.Object.Destroy(_shapeLoader.gameObject);
				}
				if ((bool)_stampShape1)
				{
					UnityEngine.Object.Destroy(_stampShape1.gameObject);
				}
				if ((bool)_stampShape2)
				{
					UnityEngine.Object.Destroy(_stampShape2.gameObject);
				}
				_shapeLoader = null;
				_stampShape1 = null;
				_stampShape2 = null;
				_hasShape = false;
				_behaviour.ResetStampConfig();
				UpdateOutputFrequencyText();
			});
			_resetSequence.Play();
		}

		private void DestroyAllIndicators()
		{
			if ((bool)_indicatorShapeLoaderA)
			{
				UnityEngine.Object.Destroy(_indicatorShapeLoaderA.gameObject);
				_indicatorShapeLoaderA = null;
			}
			if ((bool)_indicatorShapeLoaderB)
			{
				UnityEngine.Object.Destroy(_indicatorShapeLoaderB.gameObject);
				_indicatorShapeLoaderB = null;
			}
			if ((bool)_previousIndicatorAShapeLoader)
			{
				UnityEngine.Object.Destroy(_previousIndicatorAShapeLoader.gameObject);
				_previousIndicatorAShapeLoader = null;
			}
			if ((bool)_previousIndicatorBShapeLoader)
			{
				UnityEngine.Object.Destroy(_previousIndicatorBShapeLoader.gameObject);
				_previousIndicatorBShapeLoader = null;
			}
		}

		private void ResubscribeToConfigShapeEvent()
		{
			_behaviour.OnSetConfigResource.UnRegisterMainThread(ShowConfigShape);
			_behaviour.OnSetConfigResource.RegisterMainThread(ShowConfigShape);
		}

		protected override void Ready(int param1 = 0)
		{
			_behaviour.ApplyStampConfig(_stampShape1.Shape, _excessShape, _selectedShapeA, _selectedShapeB, _shapeLoader.Rotation, _shapeLoader.Shape);
			EnableStampButtons(enable: false);
			base.Ready();
		}

		private void UpdateOutputFrequencyText()
		{
			if (_stampShape1 != null && _stampShape1.Shape.OccupiedVoxels.Count > 0)
			{
				_outputFrequencyText1.Populate(_behaviour.FactoryObject.FactoryObjectData.UIData);
			}
			else
			{
				_outputFrequencyText1.Populate(0);
			}
			if (_stampShape2 != null && _stampShape2.Shape.OccupiedVoxels.Count > 0)
			{
				_outputFrequencyText2.Populate(_behaviour.FactoryObject.FactoryObjectData.UIData);
			}
			else
			{
				_outputFrequencyText2.Populate(0);
			}
		}

		public override void HideMenu()
		{
			base.HideMenu();
			_behaviour.OnReceivedShapeResource.UnRegisterMainThread(ShowConfigShape);
			if (_shapeLoader != null)
			{
				UnityEngine.Object.Destroy(_shapeLoader.gameObject);
				_shapeLoader = null;
			}
			if (_stampShape1 != null)
			{
				UnityEngine.Object.Destroy(_stampShape1.gameObject);
				_stampShape1 = null;
			}
			if (_stampShape2 != null)
			{
				UnityEngine.Object.Destroy(_stampShape2.gameObject);
				_stampShape2 = null;
			}
			DestroyAllIndicators();
			_hasShape = false;
			_excessShape = null;
			_currentShapeA = null;
			_currentShapeB = null;
			_selectedShapeA = null;
			_selectedShapeB = null;
			_shapeRotationControls.Hide();
			ShapeRotationControls shapeRotationControls = _shapeRotationControls;
			shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Remove(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(ShapeRotated));
			_leftClick.action.performed -= OnClick;
			_behaviour.OnSetConfigResource.UnRegisterMainThread(ShowConfigShape);
			_stampASelectedButton.OnClick -= StampToggleClicked;
			_stampBSelectedButton.OnClick -= StampToggleClicked;
		}
	}
}
