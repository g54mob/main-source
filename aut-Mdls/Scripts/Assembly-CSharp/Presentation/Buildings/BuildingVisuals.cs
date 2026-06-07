using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Data.Buildings;
using Data.Shapes;
using Presentation.FactoryFloor.FactoryObjectViews.Buildings;
using Presentation.Shapes;
using UnityEngine;

namespace Presentation.Buildings
{
	public class BuildingVisuals : MonoBehaviour
	{
		public enum BuildingStageType
		{
			Single = 0,
			Bottom = 1,
			Middle = 2,
			Top = 3
		}

		[SerializeField]
		private Material _shapeMaterial;

		[SerializeField]
		private Transform _shapesParent;

		[SerializeField]
		private Transform _polishedPrefabParent;

		[SerializeField]
		private ParticleSystem _polishParticles;

		[SerializeField]
		private ShapeMeshLibrary _shapeMeshLibrary;

		private bool _isShowingPolishedVersion;

		private bool _hasTypePrefab;

		private BuildingStageType? _type;

		private BuildingObjectData _data;

		private BuildingCompletionEffect _buildingCompletionEffect;

		private bool _isAnimating;

		private Material _instancedShapesMat;

		private readonly Dictionary<ShapeHashPair, int> _shapeCount = new Dictionary<ShapeHashPair, int>();

		private Coroutine _completionCoroutine;

		private static readonly Vector3 SHAPE_SPAWN_POSITION_OFFSET = new Vector3(0f, 0.7f, 0f);

		private static readonly float SHAPES_RANDOM_OFFSET_STRENGTH = 0.5f;

		private static readonly float CRANES_TIME_TO_INPUT = 1.5f;

		private static readonly float COMPLETION_ANIM_TIME = 3f;

		private static readonly float PROPS_APPEAR_ANIM_TIME = 0.3f;

		private static readonly int StartTime = Shader.PropertyToID("_startTime");

		private static readonly int FloorOffset = Shader.PropertyToID("_floorOffset");

		public Transform PolishedParent => _polishedPrefabParent;

		public bool IsAnimating => _isAnimating;

		public Vector3 BoundsSize => _buildingCompletionEffect.BoundsSize;

		public Vector3 CenterPosition => _polishedPrefabParent.position;

		public BuildingCompletionEffect BuildingCompletionEffect => _buildingCompletionEffect;

		public event Action OnTransitionEnd;

		public void Init(BuildingObjectData data)
		{
			_data = data;
			_instancedShapesMat = new Material(_shapeMaterial);
			_polishedPrefabParent.transform.localPosition = new Vector3(data.MeshOffset.x, 0f, data.MeshOffset.z);
		}

		public void ShowHologramVisuals()
		{
			_buildingCompletionEffect.ShowHologram();
			_isShowingPolishedVersion = false;
		}

		public void ShowPolishedVisuals()
		{
			CleanupCompletionEffects();
			_isShowingPolishedVersion = true;
			if (_hasTypePrefab)
			{
				_buildingCompletionEffect.ShowPolished();
			}
		}

		public void PlayBuildingVisualsFinishedAnimation()
		{
			if (!_isShowingPolishedVersion && !_isAnimating && base.gameObject.activeInHierarchy)
			{
				_completionCoroutine = StartCoroutine(IPlayBuildingVisualsFinishedAnimation());
			}
		}

		private IEnumerator IPlayBuildingVisualsFinishedAnimation()
		{
			_isAnimating = true;
			_isShowingPolishedVersion = true;
			ParticleSystem particleSystem = UnityEngine.Object.Instantiate(_polishParticles, _polishedPrefabParent);
			Vector3 position = particleSystem.transform.position;
			position.y = base.transform.parent.position.y;
			particleSystem.transform.position = position;
			particleSystem.transform.localScale = new Vector3((float)_data.GetRelativeBounds().x - 1.525f, 1f, (float)_data.GetRelativeBounds().z - 1.525f);
			particleSystem.Play();
			_buildingCompletionEffect.StartTransition(COMPLETION_ANIM_TIME);
			_instancedShapesMat.SetFloat(StartTime, Time.time);
			_instancedShapesMat.SetFloat(FloorOffset, base.transform.position.y);
			yield return new WaitForSeconds(COMPLETION_ANIM_TIME);
			_buildingCompletionEffect.StartPropsTransition(PROPS_APPEAR_ANIM_TIME);
			yield return new WaitForSeconds(PROPS_APPEAR_ANIM_TIME);
			this.OnTransitionEnd?.Invoke();
			_isAnimating = false;
			ResetShapes();
			CleanupCompletionEffects();
		}

		private void CleanupCompletionEffects()
		{
			_shapesParent.gameObject.SetActive(value: false);
		}

		public void SpawnVisuals(BuildingStageType type)
		{
			if (type == _type)
			{
				return;
			}
			_type = type;
			DestroyOldPolishedBuilding();
			switch (_type)
			{
			case BuildingStageType.Single:
				if (!_data.SinglePrefabRef)
				{
					_hasTypePrefab = false;
					return;
				}
				_buildingCompletionEffect = UnityEngine.Object.Instantiate(_data.SinglePrefabRef, _polishedPrefabParent);
				break;
			case BuildingStageType.Bottom:
				if (!_data.BottomPrefabRef)
				{
					_hasTypePrefab = false;
					return;
				}
				_buildingCompletionEffect = UnityEngine.Object.Instantiate(_data.BottomPrefabRef, _polishedPrefabParent);
				break;
			case BuildingStageType.Middle:
				if (!_data.MiddlePrefabRef)
				{
					_hasTypePrefab = false;
					return;
				}
				_buildingCompletionEffect = UnityEngine.Object.Instantiate(_data.MiddlePrefabRef, _polishedPrefabParent);
				break;
			case BuildingStageType.Top:
				if (!_data.TopPrefabRef)
				{
					_hasTypePrefab = false;
					return;
				}
				_buildingCompletionEffect = UnityEngine.Object.Instantiate(_data.TopPrefabRef, _polishedPrefabParent);
				break;
			}
			_buildingCompletionEffect.Init();
			_hasTypePrefab = true;
		}

		private void DestroyOldPolishedBuilding()
		{
			if (_buildingCompletionEffect != null)
			{
				UnityEngine.Object.Destroy(_buildingCompletionEffect.gameObject);
			}
			_buildingCompletionEffect = null;
			if (_completionCoroutine != null)
			{
				StopCoroutine(_completionCoroutine);
			}
		}

		public void AddShape(ShapeData shapeData, int index, bool anim = true)
		{
			ShapeHashPair shapeHash = shapeData.GetShapeHash();
			if (_data == null || !_data.DioramaSave.DioramaShapesDictionary.ContainsKey(shapeHash))
			{
				return;
			}
			List<DioramaEditorSave.DioramaShape> shapes = _data.DioramaSave.DioramaShapesDictionary[shapeHash].Shapes;
			index = Mathf.Min(index, shapes.Count);
			if (index < 0 || shapes.Count <= 0)
			{
				return;
			}
			_shapeCount.TryAdd(shapeHash, 0);
			while (_shapeCount[shapeHash] < index)
			{
				DioramaEditorSave.DioramaShape dioramaShape = shapes.ElementAt(_shapeCount[shapeHash]);
				ShapeLoader newShape = ShapeLoader.CreateFromShapeData(shapeData, _shapeMeshLibrary, _instancedShapesMat);
				newShape.Rotate(dioramaShape.Rotation);
				newShape.transform.SetParent(_shapesParent);
				Vector3 targetPos = dioramaShape.Position - _data.DioramaSave.Center;
				if (anim)
				{
					newShape.transform.position = _shapesParent.position - SHAPE_SPAWN_POSITION_OFFSET;
					newShape.transform.localRotation = Quaternion.Euler(dioramaShape.Rotation);
					newShape.transform.localScale = Vector3.zero;
					Vector3 position = _shapesParent.position;
					position.y += SHAPE_SPAWN_POSITION_OFFSET.y;
					Vector2 vector = UnityEngine.Random.insideUnitCircle * SHAPES_RANDOM_OFFSET_STRENGTH;
					position.x += vector.x;
					position.z += vector.y;
					Sequence s = DOTween.Sequence();
					s.AppendInterval(CRANES_TIME_TO_INPUT);
					s.Append(newShape.transform.DOMove(position, 0.6f).SetEase(Ease.OutCubic));
					s.Join(newShape.transform.DOScale(Vector3.one * 0.5f, 0.3f).SetEase(Ease.InOutElastic));
					s.Append(newShape.transform.DOLocalMove(targetPos, 0.7f).SetEase(Ease.InOutBack));
					s.Join(newShape.transform.DOLocalRotate(Vector3.zero, 0.7f).SetEase(Ease.InOutBack));
					s.Join(newShape.transform.DOScale(Vector3.one, 0.7f).SetEase(Ease.InOutBack)).OnComplete(delegate
					{
						newShape.transform.localPosition = targetPos;
						newShape.transform.localScale = Vector3.one;
						newShape.transform.localRotation = Quaternion.identity;
					});
				}
				else
				{
					newShape.transform.localPosition = targetPos;
					newShape.transform.localScale = Vector3.one;
					newShape.transform.localRotation = Quaternion.identity;
				}
				_shapeCount[shapeHash]++;
			}
		}

		public void ResetShapes()
		{
			for (int num = _shapesParent.transform.childCount - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(_shapesParent.GetChild(num).gameObject);
			}
			_shapeCount.Clear();
		}

		public void Reset()
		{
			ResetShapes();
			DestroyOldPolishedBuilding();
			_shapeCount.Clear();
			_type = null;
			_isShowingPolishedVersion = false;
		}

		public void SetValid(bool isValid)
		{
			_buildingCompletionEffect.SetValid(isValid);
		}
	}
}
