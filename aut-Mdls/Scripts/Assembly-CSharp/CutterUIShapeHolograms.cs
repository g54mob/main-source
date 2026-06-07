using System;
using System.Collections.Generic;
using DG.Tweening;
using Data.FactoryFloor.Resources;
using Data.Shapes;
using Logic.Shapes;
using Presentation.Locators;
using Presentation.Shapes;
using UnityEngine;
using Utils;

public class CutterUIShapeHolograms : MonoBehaviour
{
	[SerializeField]
	private Transform _shapeParent;

	[SerializeField]
	private Transform _shapeInputPos;

	[SerializeField]
	private Transform _outputShapeParent;

	[SerializeField]
	private Material _shapeMaterial;

	[SerializeField]
	protected ShapeMeshLibrary _shapeMeshLibrary;

	[SerializeField]
	private ParticleSystem _shapeDestroyParticle;

	[SerializeField]
	private ParticleSystem _shapeDestroyParticleInit;

	[Header("Quest")]
	[SerializeField]
	private GameObject _shapeHologram;

	[SerializeField]
	private Material _hologramMaterial;

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

	private ShapeLoader _shapeLoader;

	private ShapeLoader[] _cutShapes = Array.Empty<ShapeLoader>();

	private Sequence _currentSequence;

	private Sequence _resetSequence;

	private Sequence _firstEnterSequence;

	private ShapeLoader[] _hologramShapeLoaders;

	private ShapeLoader _tempHoloShapeLoader;

	public Action<ShapeResource, ShapeLoader> OnEnterSequenceComplete;

	public Action OnDestroySequenceComplete;

	public Action OnShapesCutSequenceComplete;

	public Action OnResetSequenceComplete;

	public ShapeLoader[] CutShapes => _cutShapes;

	public ShapeLoader ShapeLoader => _shapeLoader;

	public void ShowConfigShape(ShapeResource resource, IReadOnlyList<int> cuts = null, Vector3Int rotation = default(Vector3Int))
	{
		if ((bool)_shapeLoader)
		{
			return;
		}
		_shapeLoader = ShapeLoader.CreateFromShapeData(resource.ShapeData, _shapeMeshLibrary, _shapeMaterial, _shapeParent.transform.position, Quaternion.identity, createCollider: true);
		_shapeLoader.transform.SetParent(_shapeParent, worldPositionStays: true);
		if (rotation.sqrMagnitude > 0)
		{
			_shapeLoader.Rotate(rotation);
		}
		_shapeLoader.Position = ShapeUtils.SnapPositionToVoxelGrid(_shapeLoader.Position, _shapeLoader.Shape, _shapeParent.position);
		Vector3 position = _shapeInputPos.transform.position;
		Vector3 position2 = _shapeLoader.transform.position;
		if (cuts != null && cuts.Count > 0)
		{
			_shapeLoader.transform.position = position2;
			_shapeLoader.transform.localScale = Vector3.one;
			OnEnterSequenceComplete?.Invoke(resource, _shapeLoader);
		}
		else
		{
			_shapeLoader.transform.position = position;
			_shapeLoader.transform.localScale = Vector3.zero;
			_firstEnterSequence = DOTween.Sequence();
			_firstEnterSequence.Join(_shapeLoader.transform.DOMove(position2, _enterAnimSpeed).SetEase(_enterAnimSpeedCurve));
			_firstEnterSequence.Join(_shapeLoader.transform.DOScale(Vector3.one, _enterAnimSpeed).SetEase(_enterAnimScaleCurve));
			_firstEnterSequence.AppendCallback(delegate
			{
				OnEnterSequenceComplete?.Invoke(resource, _shapeLoader);
			});
			_firstEnterSequence.Play();
			_audioManagerLocator.AudioManager.PlayInsideViewModuleEnter();
		}
		_shapeLoader.SetShuffleState(_shapeLoader.Shape.GetBounds().x % 2 == 0);
	}

	public bool TryShowCutShapes(IReadOnlyList<int> cuts)
	{
		if (!_shapeLoader)
		{
			return false;
		}
		if (_currentSequence.IsActive() && _currentSequence.IsPlaying())
		{
			_shapeDestroyParticle.Stop();
			_currentSequence.Kill();
			_currentSequence = null;
		}
		_currentSequence = DOTween.Sequence();
		DestroyCutShapes(_currentSequence);
		if (cuts == null || cuts.Count == 0)
		{
			return true;
		}
		if (_currentSequence.IsPlaying())
		{
			_currentSequence.AppendCallback(delegate
			{
				Shape[] shapes2 = _shapeLoader.Shape.CutInterval(cuts);
				_cutShapes = CreateCutShapes(shapes2, _shapeMaterial);
			});
		}
		else
		{
			Shape[] shapes = _shapeLoader.Shape.CutInterval(cuts);
			_cutShapes = CreateCutShapes(shapes, _shapeMaterial);
		}
		_currentSequence.AppendCallback(delegate
		{
			OnShapesCutSequenceComplete?.Invoke();
		});
		_currentSequence.Play();
		return true;
	}

	public void Reset()
	{
		if ((_firstEnterSequence != null && _firstEnterSequence.IsActive() && _firstEnterSequence.IsPlaying()) || (_resetSequence != null && _resetSequence.IsPlaying()))
		{
			return;
		}
		_resetSequence = DOTween.Sequence();
		if ((bool)_shapeLoader)
		{
			_shapeDestroyParticleInit.Play();
			_shapeLoader.transform.localScale = Vector3.one;
			_resetSequence.Join(_shapeLoader.transform.DOScale(Vector3.zero, 0.15f).SetEase(Ease.InBack));
		}
		DestroyCutShapes(_resetSequence);
		_resetSequence.AppendCallback(delegate
		{
			if ((bool)_shapeLoader)
			{
				UnityEngine.Object.Destroy(_shapeLoader.gameObject);
				_shapeLoader = null;
			}
			OnResetSequenceComplete?.Invoke();
		});
		_resetSequence.Play();
	}

	public void HideInstant()
	{
		for (int i = 0; i < _cutShapes.Length; i++)
		{
			UnityEngine.Object.Destroy(_cutShapes[i].gameObject);
		}
		_cutShapes = Array.Empty<ShapeLoader>();
		if (_shapeLoader != null)
		{
			UnityEngine.Object.Destroy(_shapeLoader.gameObject);
			_shapeLoader = null;
		}
		_shapeHologram.SetActive(value: false);
	}

	private ShapeLoader[] CreateCutShapes(Shape[] shapes, Material material)
	{
		ShapeLoader[] array = new ShapeLoader[shapes.Length];
		int num = shapes.Length - 1;
		for (int i = 0; i < shapes.Length; i++)
		{
			num += shapes[i].GetBounds().x;
			Vector3 position = _outputShapeParent.position;
			array[i] = ShapeLoader.CreateFromShape(shapes[i], _shapeMeshLibrary, material, position, Quaternion.identity);
			array[i].transform.SetParent(_outputShapeParent);
		}
		int num2 = 0;
		float num3 = ((num % 2 == 0) ? 0f : (-0.05f));
		for (int j = 0; j < shapes.Length; j++)
		{
			int x = array[j].Shape.GetBounds().x;
			Vector3 localPosition = array[j].transform.localPosition;
			array[j].transform.localPosition = new Vector3((float)x * 0.05f + (float)num2 * 0.1f - (float)num * 0.05f + num3, localPosition.y, localPosition.z);
			num2 += x + 1;
		}
		for (int k = 0; k < array.Length; k++)
		{
			array[k].transform.localScale = Vector3.zero;
			_currentSequence.Join(array[k].transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack));
		}
		return array;
	}

	private void DestroyCutShapes(Sequence sequence)
	{
		if (_cutShapes.Length == 0)
		{
			return;
		}
		_shapeDestroyParticle.Play();
		for (int i = 0; i < _cutShapes.Length; i++)
		{
			_cutShapes[i].transform.localScale = Vector3.one;
			sequence.Join(_cutShapes[i].transform.DOScale(Vector3.zero, 0.15f).SetEase(Ease.InBack));
		}
		sequence.AppendCallback(delegate
		{
			for (int j = 0; j < _cutShapes.Length; j++)
			{
				UnityEngine.Object.Destroy(_cutShapes[j].gameObject);
			}
			_cutShapes = Array.Empty<ShapeLoader>();
			OnDestroySequenceComplete?.Invoke();
		});
	}

	public void HideShapeHologram()
	{
		_shapeHologram.SetActive(value: false);
		DestroyHologram();
	}

	private void DestroyHologram()
	{
		if (_tempHoloShapeLoader != null)
		{
			UnityEngine.Object.Destroy(_tempHoloShapeLoader.gameObject);
			_tempHoloShapeLoader = null;
		}
		if (_hologramShapeLoaders != null)
		{
			ShapeLoader[] hologramShapeLoaders = _hologramShapeLoaders;
			for (int i = 0; i < hologramShapeLoaders.Length; i++)
			{
				UnityEngine.Object.Destroy(hologramShapeLoaders[i].gameObject);
			}
		}
		_hologramShapeLoaders = null;
	}

	public void ShowShapeHologram((ShapeData shapeData, int interval) eventData)
	{
		DestroyHologram();
		_shapeHologram.SetActive(value: true);
		_tempHoloShapeLoader = ShapeLoader.CreateFromShapeData(eventData.shapeData, _shapeMeshLibrary, _hologramMaterial);
		Shape[] shapes = _tempHoloShapeLoader.Shape.CutInterval(eventData.interval);
		_hologramShapeLoaders = CreateCutShapes(shapes, _hologramMaterial);
		_tempHoloShapeLoader.gameObject.SetActive(value: false);
	}
}
