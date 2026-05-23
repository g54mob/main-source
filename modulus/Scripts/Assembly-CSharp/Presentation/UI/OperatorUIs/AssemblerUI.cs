#define ENABLE_DEBUG_LOGS
using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Data.FactoryFloor.Behaviours;
using Data.Shapes;
using Events;
using Logic.Assembling;
using Logic.Shapes;
using Presentation.Shapes;
using Presentation.UI.Menus.MenuEvents.MenuData;
using Presentation.UI.OperatorUIs.InsideOperatorUIs;
using TMPro;
using UnityEngine;
using Utils;

namespace Presentation.UI.OperatorUIs
{
	public class AssemblerUI : InsideOperatorUI
	{
		private const string AlphaParameterName = "_Alpha";

		private const string ColourParameterName = "_Color";

		[Header("References")]
		[SerializeField]
		private AssembleZone _assembleZone;

		[SerializeField]
		private AssembleStack _assembleStack;

		[SerializeField]
		private Material _boundsIndicatorMat;

		[SerializeField]
		protected ShapeMeshLibrary _shapeMeshLibrary;

		[SerializeField]
		[ColorUsage(true, true)]
		private Color _correctBoundsIndicatorColor;

		[SerializeField]
		[ColorUsage(true, true)]
		private Color _inCorrectBoundsIndicatorColor;

		[SerializeField]
		private TMP_Text _maxBoundsText;

		[SerializeField]
		private string _defaultTextLocaKey;

		[SerializeField]
		private string _maxBoundsTextLocaKey;

		[SerializeField]
		private AnimationCurve _correctBlinkAnim;

		[Space]
		[SerializeField]
		private List<OperatorUpdateFrequencyText> _inputFrequencyTexts;

		[SerializeField]
		private OperatorUpdateFrequencyText _outputFrequencyText;

		[Header("OnBoarding")]
		[SerializeField]
		private GameObject _shapeHologram;

		[SerializeField]
		private ShapeDataSO _onboardingShapeData;

		[SerializeField]
		private BaseEvent _showShapeHologramEvent;

		[SerializeField]
		private BaseEvent _hideShapeHologramEvent;

		private AssemblerBehaviour _behaviour;

		private ShapeLoader _boundsIndicator;

		private Shape _combinedPreviewHologramShape;

		private bool _updatesStackShapes = true;

		protected override void Awake()
		{
			base.Awake();
			_boundsIndicatorMat = new Material(_boundsIndicatorMat);
		}

		protected override void Reset(int param1)
		{
			base.Reset();
			if (!_updatesStackShapes)
			{
				_updatesStackShapes = true;
				_behaviour.OnCurrentResourcesUpdated.RegisterMainThread(UpdateStackShapes);
			}
			UpdateReadyVisuals();
			_outputFrequencyText.Populate(0);
			DestroyBoundIndicator();
			if (_assembleStack.TryResetSequence(out var sequence))
			{
				Sequence sequence2 = sequence;
				sequence2.onComplete = (TweenCallback)Delegate.Combine(sequence2.onComplete, new TweenCallback(_behaviour.Reset));
			}
			if (_assembleZone.TryResetSequence(out var sequence3))
			{
				Sequence sequence4 = sequence3;
				sequence4.onComplete = (TweenCallback)Delegate.Combine(sequence4.onComplete, (TweenCallback)delegate
				{
					_shapeHologram.SetActive(value: false);
				});
			}
		}

		private void UpdateReadyVisuals()
		{
			bool flag = CanReady();
			EnableReadyButton(flag);
			if (_shapeHologram.activeInHierarchy && flag)
			{
				_combinedPreviewHologramShape = CalculatePlacedShapesCombined();
				EnableReadyButton(_onboardingShapeData.Data.RotationIndependantHash.Contains(_combinedPreviewHologramShape.GetShapeHash()));
			}
			if (_behaviour.IsConfigured || flag)
			{
				_outputFrequencyText.Populate(_behaviour.FactoryObject.FactoryObjectData.UIData);
			}
			else
			{
				_outputFrequencyText.Populate(0);
			}
		}

		private bool CanReady()
		{
			DestroyBoundIndicator();
			_maxBoundsText.SetText(LocalizationUtility.GetLocalizedText(_defaultTextLocaKey));
			_maxBoundsText.color = Color.white;
			if (_behaviour.IsConfigured || _assembleZone.PlacedShapes.Count <= 1)
			{
				return false;
			}
			Vector3Int bounds = CalculateCombinedShapesBounds();
			int outputShapeMaxBound = _behaviour.OutputShapeMaxBound;
			if (bounds.x <= outputShapeMaxBound && bounds.y <= outputShapeMaxBound && bounds.z <= outputShapeMaxBound)
			{
				UpdateBoundIndicator(correct: true, bounds);
				return true;
			}
			UpdateBoundIndicator(correct: false, bounds);
			return false;
		}

		private void UpdateBoundIndicator(bool correct, Vector3Int bounds)
		{
			Shape shape = Shape.CreateCube(Vector3.zero, bounds, Color.white);
			Vector3 position = Vector3.one * 100000f;
			foreach (ClickableShape placedShape in _assembleZone.PlacedShapes)
			{
				Vector3Int bounds2 = placedShape.ShapeLoader.Shape.GetBounds();
				Vector3 position2 = placedShape.ShapeLoader.Position;
				position2.x -= (float)(bounds2.x - 1) / 2f * 0.1f;
				position2.z -= (float)(bounds2.z - 1) / 2f * 0.1f;
				position.x = Mathf.Min(position.x, position2.x);
				position.y = Mathf.Min(position.y, position2.y);
				position.z = Mathf.Min(position.z, position2.z);
			}
			position.x += (float)(bounds.x - 1) * 0.05f;
			position.z += (float)(bounds.z - 1) * 0.05f;
			_boundsIndicator = ShapeLoader.CreateFromShape(shape, _shapeMeshLibrary, _boundsIndicatorMat, position, Quaternion.identity);
			_boundsIndicator.MeshRenderer.sharedMaterial.SetFloat("_Alpha", 1f);
			if (correct)
			{
				_boundsIndicator.MeshRenderer.sharedMaterial.SetColor("_Color", _correctBoundsIndicatorColor);
				DOTween.To(() => _boundsIndicator.MeshRenderer.sharedMaterial.GetFloat("_Alpha"), delegate(float x)
				{
					_boundsIndicator.MeshRenderer.sharedMaterial.SetFloat("_Alpha", x);
				}, 0f, 1f).SetEase(_correctBlinkAnim);
			}
			else
			{
				_boundsIndicator.MeshRenderer.sharedMaterial.SetColor("_Color", _inCorrectBoundsIndicatorColor);
				_maxBoundsText.SetText(string.Format(LocalizationUtility.GetLocalizedText(_maxBoundsTextLocaKey), _behaviour.OutputShapeMaxBound));
				_maxBoundsText.color = Color.red;
			}
		}

		private void DestroyBoundIndicator()
		{
			if (!(_boundsIndicator == null))
			{
				UnityEngine.Object.Destroy(_boundsIndicator.gameObject);
				_boundsIndicator = null;
			}
		}

		protected override void Ready(int param1)
		{
			AssemblerBehaviour.ConfiguredAssemblerShape[] array = new AssemblerBehaviour.ConfiguredAssemblerShape[_behaviour.FactoryObject.DataInputPositions.Count];
			foreach (ClickableShape placedShape in _assembleZone.PlacedShapes)
			{
				array[placedShape.StackIndex] = new AssemblerBehaviour.ConfiguredAssemblerShape
				{
					Data = placedShape.ShapeLoader.ShapeData,
					Position = placedShape.ShapeLoader.Position,
					Rotation = placedShape.ShapeLoader.Rotation
				};
				this.Log($" Shapes Stack Index {placedShape.StackIndex}", "Ready", 201);
			}
			_behaviour.SetConfiguration(array.ToList());
			_shapeHologram.SetActive(value: false);
			base.Ready();
		}

		private void AddShapeToZone(ClickableShape shape, Vector3 pos)
		{
			ClickableShape clickableShape = ClickableShape.CreateClickableShape(shape.ShapeLoader.ShapeData, _shapeMeshLibrary, shape.ShapeLoader.MeshRenderer.sharedMaterial, _3DCamera, shape.StackIndex, shape.transform.position, Quaternion.identity);
			_assembleZone.HoldShape(clickableShape, clickableShape.transform.position - pos);
		}

		private Shape CalculatePlacedShapesCombined()
		{
			List<(ShapeData, Vector3, Vector3Int)> list = new List<(ShapeData, Vector3, Vector3Int)>();
			foreach (ClickableShape placedShape in _assembleZone.PlacedShapes)
			{
				list.Add((placedShape.ShapeLoader.ShapeData, placedShape.ShapeLoader.Position, placedShape.ShapeLoader.Rotation));
			}
			List<Shape> list2 = new List<Shape>();
			foreach (var item4 in list)
			{
				ShapeData item = item4.Item1;
				Vector3 item2 = item4.Item2;
				Vector3Int item3 = item4.Item3;
				Shape shape = Shape.Create(item);
				shape.Rotate(item3);
				shape.Position = item2;
				list2.Add(shape);
			}
			return list2[0].Combine(list2);
		}

		private Vector3Int CalculateCombinedShapesBounds()
		{
			List<(ShapeData, Vector3, Vector3Int)> list = new List<(ShapeData, Vector3, Vector3Int)>();
			foreach (ClickableShape placedShape in _assembleZone.PlacedShapes)
			{
				list.Add((placedShape.ShapeLoader.ShapeData, placedShape.ShapeLoader.Position, placedShape.ShapeLoader.Rotation));
			}
			List<Shape> list2 = new List<Shape>();
			foreach (var item4 in list)
			{
				ShapeData item = item4.Item1;
				Vector3 item2 = item4.Item2;
				Vector3Int item3 = item4.Item3;
				Shape shape = Shape.Create(item);
				shape.Rotate(item3);
				shape.Position = item2;
				list2.Add(shape);
			}
			return list2[0].GetCombinedShapeBounds(list2);
		}

		private void AddShapeBackToStackFromZone(ClickableShape shape)
		{
			_assembleStack.AddShapeBackToStackFromZone(shape);
			_audioManagerLocator.AudioManager.PlayShapeDrop();
			UpdateReadyVisuals();
		}

		private void OnPickupShapeInZone()
		{
			UpdateReadyVisuals();
			_audioManagerLocator.AudioManager.PlayShapePickup();
		}

		private void OnPlacedShapeInZone()
		{
			UpdateReadyVisuals();
			_audioManagerLocator.AudioManager.PlayShapeDrop();
		}

		private void UpdateStackShapes()
		{
			(ShapeData, int)[] shapesInBuffers = _behaviour.GetShapesInBuffers();
			(ShapeData, int)[] array = new(ShapeData, int)[shapesInBuffers.Length];
			Array.Copy(shapesInBuffers, array, shapesInBuffers.Length);
			foreach (ClickableShape placedShape in _assembleZone.PlacedShapes)
			{
				bool num = array[placedShape.StackIndex].Item2 > 0;
				bool flag = placedShape.ShapeLoader.ShapeData == array[placedShape.StackIndex].Item1;
				if (num && flag)
				{
					array[placedShape.StackIndex].Item2--;
				}
			}
			if (_assembleZone.IsHoldingShape)
			{
				bool num2 = array[_assembleZone.HoldingShapeIndex].Item2 > 0;
				bool flag2 = array[_assembleZone.HoldingShapeIndex].Item1 == _assembleZone.CurrentHoldingShape.ShapeLoader.ShapeData;
				if (num2 && flag2)
				{
					array[_assembleZone.HoldingShapeIndex].Item2--;
				}
			}
			_assembleStack.SetStackShapes(array);
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			UIMenuBehaviourData uIMenuBehaviourData = menuData as UIMenuBehaviourData;
			_behaviour = uIMenuBehaviourData.Behaviour as AssemblerBehaviour;
			_assembleStack.ResetStack();
			foreach (OperatorUpdateFrequencyText inputFrequencyText in _inputFrequencyTexts)
			{
				inputFrequencyText.Populate(_behaviour.FactoryObject.FactoryObjectData.UIData);
			}
			if (_behaviour.IsConfigured)
			{
				_assembleZone.AddShapes(_behaviour.ConfiguredShapes);
				_assembleStack.ShowPreviewStackShapes(_behaviour.GetShapesInBuffers());
				_updatesStackShapes = false;
				base.IsConfigured = true;
			}
			else
			{
				_assembleStack.SetStackShapes(_behaviour.GetShapesInBuffers());
				_updatesStackShapes = true;
				_behaviour.OnCurrentResourcesUpdated.RegisterMainThread(UpdateStackShapes);
				EnableReadyButton(enable: false);
			}
			UpdateReadyVisuals();
			_maxBoundsText.SetText(LocalizationUtility.GetLocalizedText(_defaultTextLocaKey));
			AssembleStack assembleStack = _assembleStack;
			assembleStack.OnTakeStackShape = (Action<ClickableShape, Vector3>)Delegate.Combine(assembleStack.OnTakeStackShape, new Action<ClickableShape, Vector3>(AddShapeToZone));
			AssembleZone assembleZone = _assembleZone;
			assembleZone.OnRemovedShape = (Action<ClickableShape>)Delegate.Combine(assembleZone.OnRemovedShape, new Action<ClickableShape>(AddShapeBackToStackFromZone));
			AssembleZone assembleZone2 = _assembleZone;
			assembleZone2.OnPlacedShape = (Action)Delegate.Combine(assembleZone2.OnPlacedShape, new Action(OnPlacedShapeInZone));
			AssembleZone assembleZone3 = _assembleZone;
			assembleZone3.OnPickupShape = (Action)Delegate.Combine(assembleZone3.OnPickupShape, new Action(OnPickupShapeInZone));
			_showShapeHologramEvent?.Register(ShowShapeHologram);
			_hideShapeHologramEvent?.Register(HideShapeHologram);
			base.ShowMenu(menuData);
		}

		public override void HideMenu()
		{
			base.HideMenu();
			_shapeHologram.SetActive(value: false);
			_assembleStack.ResetStack();
			_assembleZone.Reset();
			DestroyBoundIndicator();
			AssembleStack assembleStack = _assembleStack;
			assembleStack.OnTakeStackShape = (Action<ClickableShape, Vector3>)Delegate.Remove(assembleStack.OnTakeStackShape, new Action<ClickableShape, Vector3>(AddShapeToZone));
			AssembleZone assembleZone = _assembleZone;
			assembleZone.OnRemovedShape = (Action<ClickableShape>)Delegate.Remove(assembleZone.OnRemovedShape, new Action<ClickableShape>(AddShapeBackToStackFromZone));
			AssembleZone assembleZone2 = _assembleZone;
			assembleZone2.OnPlacedShape = (Action)Delegate.Remove(assembleZone2.OnPlacedShape, new Action(OnPlacedShapeInZone));
			AssembleZone assembleZone3 = _assembleZone;
			assembleZone3.OnPickupShape = (Action)Delegate.Remove(assembleZone3.OnPickupShape, new Action(OnPickupShapeInZone));
			_behaviour.OnCurrentResourcesUpdated.UnRegisterMainThread(UpdateStackShapes);
			_showShapeHologramEvent?.UnRegister(ShowShapeHologram);
			_hideShapeHologramEvent?.UnRegister(HideShapeHologram);
		}

		private void ShowShapeHologram()
		{
			if (!_shapeHologram.activeInHierarchy)
			{
				_shapeHologram.SetActive(value: true);
				ShapeLoader componentInChildren = _shapeHologram.GetComponentInChildren<ShapeLoader>();
				componentInChildren.LoadShapeData(componentInChildren.ShapeData);
				EnableReadyButton(enable: false);
			}
		}

		private void HideShapeHologram()
		{
			_shapeHologram.SetActive(value: false);
			EnableReadyButton();
		}
	}
}
