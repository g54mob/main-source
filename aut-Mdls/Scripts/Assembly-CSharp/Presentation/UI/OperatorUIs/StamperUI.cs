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
	public class StamperUI : InsideOperatorUI
	{
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
		private Material _savedIndicatorShapeMaterial;

		[SerializeField]
		private ParticleSystem _shapeOutputParticle1;

		[SerializeField]
		private ParticleSystem _shapeOutputParticle2;

		[SerializeField]
		private ParticleSystem _shapeOutputParticleInitial;

		[SerializeField]
		private ShapeRotationControls _shapeRotationControls;

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

		private ShapeLoader _shapeLoader;

		private Collider _shapeLoaderCollider;

		private bool _hasShape;

		private bool _hasSetPos1;

		private bool _onClickDown;

		private Vector2Int _pos1;

		private Vector2Int _pos2;

		private ShapeLoader _stampShape1;

		private ShapeLoader _stampShape2;

		private Sequence _currentSequence;

		private Sequence _resetSequence;

		private Sequence _firstEnterSequence;

		private Vector3Int _oldPosForIndicator = new Vector3Int(99, 99, 99);

		private Vector2Int _indicatorVoxelPos1;

		private Vector2Int _indicatorVoxelPos2;

		private Vector3 _indicatorPos;

		private ShapeLoader _indicatorShapeLoader;

		private StamperBehaviour _behaviour;

		private ShapeLoader _previousIndicatorShapeLoader;

		private void ShapeRotated(ShapeLoader shapeLoader, string axisName, bool inverse)
		{
			EnableReadyButton(enable: false);
			_hasSetPos1 = false;
			ResetIndicator();
			if ((bool)_previousIndicatorShapeLoader)
			{
				UnityEngine.Object.Destroy(_previousIndicatorShapeLoader.gameObject);
				_previousIndicatorShapeLoader = null;
			}
			if ((bool)_stampShape1)
			{
				UnityEngine.Object.Destroy(_stampShape1.gameObject);
				_stampShape1 = null;
			}
			if ((bool)_stampShape2)
			{
				UnityEngine.Object.Destroy(_stampShape2.gameObject);
				_stampShape2 = null;
			}
			UpdateOutputFrequencyText();
		}

		private void ShowConfigShape(ShapeResource resource)
		{
			if ((bool)_shapeLoader)
			{
				return;
			}
			_behaviour.OnSetConfigResource.UnRegisterMainThread(ShowConfigShape);
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

		private void Update()
		{
			if (_hasShape)
			{
				_updatePhysics.Fire();
				UpdatePreviewShape();
			}
		}

		private void UpdatePreviewShape(bool forceUpdate = false)
		{
			if (PointerIsOnShapeCollider(out var hit))
			{
				Vector3 worldPos = hit.point + hit.normal * -0.05f;
				Vector3Int vector3Int = _shapeLoader.Shape.WorldPosToVoxelPos(worldPos);
				if (_oldPosForIndicator != vector3Int || forceUpdate)
				{
					_audioManagerLocator.AudioManager.PlayStamperSelection();
					_oldPosForIndicator = vector3Int;
					Vector3Int lowestValidVoxelPos = _shapeLoader.Shape.GetLowestValidVoxelPos(vector3Int);
					if (!_hasSetPos1)
					{
						_indicatorVoxelPos1 = new Vector2Int(lowestValidVoxelPos.x, lowestValidVoxelPos.z);
						_indicatorVoxelPos2 = _indicatorVoxelPos1;
					}
					else
					{
						Vector3Int lowestValidVoxelPos2 = _shapeLoader.Shape.GetLowestValidVoxelPos(new Vector3Int(_pos1.x, 12, _pos1.y));
						_indicatorVoxelPos1 = new Vector2Int(lowestValidVoxelPos2.x, lowestValidVoxelPos2.z);
						_indicatorVoxelPos2 = new Vector2Int(lowestValidVoxelPos.x, lowestValidVoxelPos.z);
					}
					Vector2Int vector2Int = Vector2Int.Min(_indicatorVoxelPos1, _indicatorVoxelPos2);
					Vector2Int vector2Int2 = Vector2Int.Max(_indicatorVoxelPos1, _indicatorVoxelPos2);
					Vector3Int minPos = new Vector3Int(vector2Int.x, 0, vector2Int.y);
					Vector3Int maxPos = new Vector3Int(vector2Int2.x, _shapeLoader.Shape.GetBounds().y, vector2Int2.y);
					if (!_hasSetPos1)
					{
						_indicatorPos = _shapeLoader.Shape.VoxelPosToWorldPos(_shapeLoader.Shape.GetLowestValidVoxelPos(lowestValidVoxelPos));
					}
					else
					{
						Vector3Int pos = new Vector3Int(vector2Int.x, _shapeLoader.Shape.GetBounds().y, vector2Int.y);
						_indicatorPos = _shapeLoader.Shape.VoxelPosToWorldPos(_shapeLoader.Shape.GetLowestValidVoxelPos(pos));
					}
					(Shape, Shape) tuple = _shapeLoader.Shape.Stamp(minPos, maxPos);
					tuple.Item1.Position = Vector3.zero;
					Vector3 vector = tuple.Item1.VoxelPosToWorldPos(Vector3Int.zero);
					if (_indicatorShapeLoader != null)
					{
						UnityEngine.Object.Destroy(_indicatorShapeLoader.gameObject);
					}
					_indicatorShapeLoader = ShapeLoader.CreateFromShape(tuple.Item1, _shapeMeshLibrary, _indicatorShapeMaterial, _indicatorPos - vector, Quaternion.identity);
				}
			}
			else
			{
				ResetIndicator();
			}
		}

		private void ResetIndicator()
		{
			if (_indicatorShapeLoader != null)
			{
				_oldPosForIndicator = new Vector3Int(99, 99, 99);
				UnityEngine.Object.Destroy(_indicatorShapeLoader.gameObject);
				_indicatorShapeLoader = null;
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
					_pos1 = new Vector2Int(vector3Int.x, vector3Int.z);
					_hasSetPos1 = true;
					UpdatePreviewShape(forceUpdate: true);
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
				_pos2 = new Vector2Int(vector3Int.x, vector3Int.z);
				Vector2Int pos = Vector2Int.Min(_pos1, _pos2);
				Vector2Int pos2 = Vector2Int.Max(_pos1, _pos2);
				_pos1 = pos;
				_pos2 = pos2;
				EnableReadyButton();
				ShowStampedShapes();
				if (_indicatorShapeLoader != null)
				{
					ShowPreviousIndicator(_indicatorShapeLoader.Shape, _indicatorShapeLoader.Position);
				}
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
			_currentSequence = DOTween.Sequence();
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
				(Shape, Shape) tuple = _shapeLoader.Shape.Stamp(new Vector3Int(_pos1.x, 0, _pos1.y), new Vector3Int(_pos2.x, _shapeLoader.Shape.GetBounds().y, _pos2.y));
				_stampShape1 = ShapeLoader.CreateFromShape(tuple.Item1, _shapeMeshLibrary, _stampedShapeMaterial, _stampOutputPos1.transform.position, Quaternion.identity);
				_stampShape2 = ShapeLoader.CreateFromShape(tuple.Item2, _shapeMeshLibrary, _stampedShapeMaterial, _stampOutputPos2.transform.position, Quaternion.identity);
				_stampShape1.transform.localScale = Vector3.zero;
				_stampShape2.transform.localScale = Vector3.zero;
				_stampShape1.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
				_stampShape2.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
				UpdateOutputFrequencyText();
			});
			_currentSequence.Play();
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

		private void ShowSavedIndicator()
		{
			Vector3Int minPos = new Vector3Int(_pos1.x, 0, _pos1.y);
			Vector3Int maxPos = new Vector3Int(_pos2.x, _shapeLoader.Shape.GetBounds().y, _pos2.y);
			Vector3Int pos = new Vector3Int(_pos1.x, _shapeLoader.Shape.GetBounds().y, _pos1.y);
			Vector3 vector = _shapeLoader.Shape.VoxelPosToWorldPos(_shapeLoader.Shape.GetLowestValidVoxelPos(pos));
			(Shape, Shape) tuple = _shapeLoader.Shape.Stamp(minPos, maxPos);
			tuple.Item1.Position = Vector3.zero;
			Vector3 vector2 = tuple.Item1.VoxelPosToWorldPos(Vector3Int.zero);
			ShowPreviousIndicator(tuple.Item1, vector - vector2);
		}

		private void ShowPreviousIndicator(Shape shape, Vector3 position)
		{
			if (_previousIndicatorShapeLoader != null)
			{
				UnityEngine.Object.Destroy(_previousIndicatorShapeLoader.gameObject);
			}
			_previousIndicatorShapeLoader = ShapeLoader.CreateFromShape(shape, _shapeMeshLibrary, _savedIndicatorShapeMaterial, position, Quaternion.identity);
		}

		protected override void Reset(int param1 = 0)
		{
			base.Reset(param1);
			if ((_firstEnterSequence != null && _firstEnterSequence.IsActive() && _firstEnterSequence.IsPlaying()) || (_resetSequence != null && _resetSequence.IsActive() && _resetSequence.IsPlaying()))
			{
				return;
			}
			DestroyIndicators();
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

		private void DestroyIndicators()
		{
			if ((bool)_indicatorShapeLoader)
			{
				UnityEngine.Object.Destroy(_indicatorShapeLoader.gameObject);
				_indicatorShapeLoader = null;
			}
			if ((bool)_previousIndicatorShapeLoader)
			{
				UnityEngine.Object.Destroy(_previousIndicatorShapeLoader.gameObject);
				_previousIndicatorShapeLoader = null;
			}
		}

		private void ResubscribeToConfigShapeEvent()
		{
			_behaviour.OnSetConfigResource.UnRegisterMainThread(ShowConfigShape);
			_behaviour.OnSetConfigResource.RegisterMainThread(ShowConfigShape);
		}

		protected override void Ready(int param1 = 0)
		{
			_behaviour.SetStampConfig(_pos1, _pos2, _shapeLoader.Rotation);
			base.Ready();
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			UIMenuBehaviourData uIMenuBehaviourData = menuData as UIMenuBehaviourData;
			_behaviour = uIMenuBehaviourData.Behaviour as StamperBehaviour;
			_hasSetPos1 = false;
			_inputFrequencyText.Populate(_behaviour.FactoryObject.FactoryObjectData.UIData);
			UpdateOutputFrequencyText();
			if (_behaviour.HasConfigResource)
			{
				ShowConfigShape(_behaviour.ConfigResource);
				if (_behaviour.IsConfigured)
				{
					_pos1 = _behaviour.StampStart;
					_pos2 = _behaviour.StampEnd;
					_shapeLoader.Rotate(_behaviour.Rotation);
					ShowStampedShapes();
					ShowSavedIndicator();
				}
				else
				{
					EnableReadyButton(enable: false);
				}
			}
			else
			{
				_behaviour.OnSetConfigResource.RegisterMainThread(ShowConfigShape);
				EnableReadyButton(enable: false);
			}
			_leftClick.action.performed += OnClick;
			base.ShowMenu(menuData);
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
			DestroyIndicators();
			_hasShape = false;
			_shapeRotationControls.Hide();
			ShapeRotationControls shapeRotationControls = _shapeRotationControls;
			shapeRotationControls.OnRotatedShape = (Action<ShapeLoader, string, bool>)Delegate.Remove(shapeRotationControls.OnRotatedShape, new Action<ShapeLoader, string, bool>(ShapeRotated));
			_leftClick.action.performed -= OnClick;
			_behaviour.OnSetConfigResource.UnRegisterMainThread(ShowConfigShape);
		}
	}
}
