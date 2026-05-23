using System;
using System.Collections.Generic;
using DG.Tweening;
using Data.Shapes;
using Presentation.FactoryFloor.ParticleSystemPool;
using Presentation.Locators;
using Presentation.Shapes;
using UnityEngine;
using Utils;

namespace Logic.Assembling
{
	public class AssembleStack : MonoBehaviour
	{
		private struct StackShape
		{
			public ClickableShape Shape;

			public bool IsOnStack;
		}

		[SerializeField]
		private Transform[] _stackShapePositions;

		[SerializeField]
		private Transform[] _stackShapeInputPositions;

		[SerializeField]
		private ParticleSystem _shapeExplodePrefabRef;

		[SerializeField]
		private Material _material;

		[SerializeField]
		private Camera _camera;

		[SerializeField]
		private Vector3 _offset = new Vector3(0f, 0.333f, 0f);

		[SerializeField]
		protected ShapeMeshLibrary _shapeMeshLibrary;

		[Header("Animations")]
		[SerializeField]
		private float _enterAnimSpeed = 1f;

		[SerializeField]
		private AnimationCurve _enterAnimSpeedCurve;

		[SerializeField]
		private AnimationCurve _enterAnimScaleCurve;

		[Header("Audio")]
		[SerializeField]
		private AudioManagerLocator _audioManagerLocator;

		private StackShape[] _stackShapes;

		public Action<ClickableShape, Vector3> OnTakeStackShape = delegate
		{
		};

		private Sequence _resetSequence;

		private Sequence[] _firstEnterSequences;

		private readonly List<ShapeLoader> _previewStackShapes = new List<ShapeLoader>();

		private ComponentPool<PoolableParticleSystem> _shapeExplodeParticlePool;

		private void Awake()
		{
			_shapeExplodeParticlePool = new ComponentPool<PoolableParticleSystem>(20, _shapeExplodePrefabRef.GetComponent<PoolableParticleSystem>(), base.transform);
		}

		private void PlayVFX(Vector3 worldPosition, Transform parent, ComponentPool<PoolableParticleSystem> pool)
		{
			PoolableParticleSystem component = pool.GetComponent();
			component.transform.SetParent(parent);
			component.transform.SetPositionAndRotation(worldPosition, Quaternion.identity);
			component.Init(pool);
		}

		public void SetStackShapes((ShapeData, int)[] stackShapes)
		{
			if (_resetSequence != null && _resetSequence.active && !_resetSequence.IsComplete())
			{
				_resetSequence.Complete();
			}
			if (_firstEnterSequences == null || _firstEnterSequences.Length != stackShapes.Length)
			{
				_firstEnterSequences = new Sequence[stackShapes.Length];
			}
			for (int i = 0; i < stackShapes.Length; i++)
			{
				if (!(stackShapes[i].Item1 == null) && !(_stackShapes[i].Shape != null))
				{
					_firstEnterSequences[i] = DOTween.Sequence();
					Vector3 position = _stackShapeInputPositions[i].transform.position;
					Vector3 endValue = _stackShapePositions[i].transform.position + _offset;
					ClickableShape clickableShape = ClickableShape.CreateClickableShape(stackShapes[i].Item1, _shapeMeshLibrary, _material, _camera, i, position, Quaternion.identity);
					_stackShapes[i].Shape = clickableShape;
					_stackShapes[i].IsOnStack = true;
					clickableShape.ShapeLoader.transform.position = position;
					clickableShape.ShapeLoader.transform.localScale = Vector3.zero;
					_firstEnterSequences[i].Join(clickableShape.ShapeLoader.transform.DOMove(endValue, _enterAnimSpeed).SetEase(_enterAnimSpeedCurve));
					_firstEnterSequences[i].Join(clickableShape.ShapeLoader.transform.DOScale(Vector3.one, _enterAnimSpeed).SetEase(_enterAnimScaleCurve));
					_firstEnterSequences[i].Play();
					int index = i;
					clickableShape.OnShapePressed = (Action<ClickableShape, Vector3>)Delegate.Combine(clickableShape.OnShapePressed, (Action<ClickableShape, Vector3>)delegate
					{
						_firstEnterSequences[index].Complete();
					});
					clickableShape.OnShapePressed = (Action<ClickableShape, Vector3>)Delegate.Combine(clickableShape.OnShapePressed, new Action<ClickableShape, Vector3>(TakeShapeFromStack));
				}
			}
			if (stackShapes.Length != 0)
			{
				_audioManagerLocator.AudioManager.PlayInsideViewModuleEnter();
			}
		}

		public void ShowPreviewStackShapes((ShapeData, int)[] stackShapes)
		{
			for (int i = 0; i < stackShapes.Length; i++)
			{
				if (!(stackShapes[i].Item1 == null))
				{
					ShapeLoader item = ShapeLoader.CreateFromShapeData(stackShapes[i].Item1, _shapeMeshLibrary, _material, _stackShapePositions[i].transform.position + _offset, Quaternion.identity);
					_previewStackShapes.Add(item);
				}
			}
		}

		public bool TryResetSequence(out Sequence sequence)
		{
			if (_resetSequence != null && _resetSequence.active && !_resetSequence.IsComplete())
			{
				sequence = _resetSequence;
				return false;
			}
			_resetSequence = DOTween.Sequence();
			for (int i = 0; i < _stackShapes.Length; i++)
			{
				if (!(_stackShapes[i].Shape == null) && _stackShapes[i].IsOnStack)
				{
					PlayVFX(_stackShapes[i].Shape.transform.position, base.transform, _shapeExplodeParticlePool);
					AnimateDestroy(_resetSequence, _stackShapes[i].Shape.transform, append: false);
				}
			}
			for (int j = 0; j < _previewStackShapes.Count; j++)
			{
				PlayVFX(_previewStackShapes[j].transform.position, base.transform, _shapeExplodeParticlePool);
				AnimateDestroy(_resetSequence, _previewStackShapes[j].transform, append: false);
			}
			_resetSequence.AppendCallback(ResetStack);
			_resetSequence.Play();
			sequence = _resetSequence;
			return true;
		}

		public void ResetStack()
		{
			if (_stackShapes != null)
			{
				for (int i = 0; i < _stackShapes.Length; i++)
				{
					if (_stackShapes[i].Shape != null)
					{
						UnityEngine.Object.Destroy(_stackShapes[i].Shape.gameObject);
					}
				}
			}
			foreach (ShapeLoader previewStackShape in _previewStackShapes)
			{
				UnityEngine.Object.Destroy(previewStackShape.gameObject);
			}
			_previewStackShapes.Clear();
			_stackShapes = new StackShape[_stackShapePositions.Length];
		}

		private void AnimateDestroy(Sequence sequence, Transform shapeLoader, bool append)
		{
			shapeLoader.localScale = Vector3.one;
			if (append)
			{
				sequence.Append(shapeLoader.DOScale(Vector3.zero, 0.15f).SetEase(Ease.InBack));
			}
			else
			{
				sequence.Join(shapeLoader.DOScale(Vector3.zero, 0.15f).SetEase(Ease.InBack));
			}
		}

		public void AddShapeBackToStackFromZone(ClickableShape clickableShape)
		{
			_stackShapes[clickableShape.StackIndex].Shape.gameObject.SetActive(value: true);
			_stackShapes[clickableShape.StackIndex].IsOnStack = true;
			_stackShapes[clickableShape.StackIndex].Shape.SetIsPressed(isPressed: false);
		}

		public void TakeShapeFromStack(ClickableShape clickableShape, Vector3 pos)
		{
			_stackShapes[clickableShape.StackIndex].Shape.gameObject.SetActive(value: false);
			_stackShapes[clickableShape.StackIndex].IsOnStack = false;
			OnTakeStackShape(clickableShape, pos);
		}
	}
}
