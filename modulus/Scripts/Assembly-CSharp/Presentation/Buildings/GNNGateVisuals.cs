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
	public class GNNGateVisuals : MonoBehaviour
	{
		[SerializeField]
		private Material _shapeMaterial;

		[SerializeField]
		private Transform _shapesParent;

		[SerializeField]
		private Transform _polishedPrefabParent;

		[SerializeField]
		private ParticleSystem _polishParticles;

		[SerializeField]
		protected ShapeMeshLibrary _shapeMeshLibrary;

		private bool _isShowingPolishedVersion;

		private BuildingObjectData _data;

		private BuildingCompletionEffect _buildingCompletionEffect;

		private bool _isAnimating;

		private Material _instancedShapesMat;

		private readonly Dictionary<ShapeData, int> _shapeCount = new Dictionary<ShapeData, int>();

		private Coroutine _completionCoroutine;

		private static readonly Vector3 SHAPE_SPAWN_POSITION_OFFSET = new Vector3(0f, 0.7f, 0f);

		private static readonly float SHAPES_RANDOM_OFFSET_STRENGTH = 0.5f;

		private static readonly float CRANES_TIME_TO_INPUT = 0.25f;

		private static readonly float COMPLETION_ANIM_TIME = 3f;

		private static readonly float PROPS_APPEAR_ANIM_TIME = 0.3f;

		private static readonly float CUBE_GO_DOWN_TIME = 1f;

		private static readonly int StartTime = Shader.PropertyToID("_startTime");

		private static readonly int FloorOffset = Shader.PropertyToID("_floorOffset");

		private GNNGateBehaviour _GNNGateBehaviour;

		private bool _hasUpgradeOverwrite;

		private GNNGateBehaviour.UpgradeOverwrite _currentUpgradeOverwrite;

		private Vector3 _polishedPrefabParentPos;

		public Transform PolishedParent => _polishedPrefabParent;

		public bool IsAnimating => _isAnimating;

		public Vector3 BoundsSize => _buildingCompletionEffect.BoundsSize;

		public Vector3 CenterPosition => _polishedPrefabParent.position;

		public BuildingCompletionEffect BuildingCompletionEffect => _buildingCompletionEffect;

		public event Action OnTransitionEnd;

		public void Init(BuildingObjectData data, GNNGateBehaviour gnnGateBehaviour, bool isActivated)
		{
			_data = data;
			_GNNGateBehaviour = gnnGateBehaviour;
			_instancedShapesMat = new Material(_shapeMaterial);
			_polishedPrefabParent.transform.localPosition = new Vector3(data.MeshOffset.x, 0f, data.MeshOffset.z);
			_polishedPrefabParentPos = _polishedPrefabParent.transform.localPosition;
			SpawnVisuals();
			if (isActivated)
			{
				SetGNNGateCompleteVisuals();
			}
		}

		public void SetUpgradeOverwrite(bool hasUpgradeOverwrite, GNNGateBehaviour.UpgradeOverwrite upgradeOverwrite)
		{
			Reset();
			_hasUpgradeOverwrite = hasUpgradeOverwrite;
			_currentUpgradeOverwrite = upgradeOverwrite;
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
			_buildingCompletionEffect.ShowPolished();
		}

		public void PlayBuildingVisualsFinishedAnimation()
		{
			if (!_isShowingPolishedVersion && !_isAnimating)
			{
				_completionCoroutine = StartCoroutine(IPlayGNNGateFloorFinishedAnimation());
			}
		}

		public void SetGNNGateCompleteVisuals()
		{
			_isShowingPolishedVersion = true;
			ResetShapes();
			CleanupCompletionEffects();
			_hasUpgradeOverwrite = false;
			SpawnVisuals();
			ShowPolishedVisuals();
		}

		private IEnumerator IPlayGNNGateFloorFinishedAnimation()
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
			_polishedPrefabParent.transform.DOLocalMove(_polishedPrefabParentPos + Vector3.up * -15f, CUBE_GO_DOWN_TIME).SetEase(Ease.InCubic);
			yield return new WaitForSeconds(CUBE_GO_DOWN_TIME);
			this.OnTransitionEnd?.Invoke();
			_isAnimating = false;
			ResetShapes();
			CleanupCompletionEffects();
		}

		private void CleanupCompletionEffects()
		{
			_shapesParent.gameObject.SetActive(value: false);
		}

		public void SpawnVisuals()
		{
			DestroyOldPolishedBuilding();
			_polishedPrefabParent.transform.DOLocalMove(_polishedPrefabParentPos, CUBE_GO_DOWN_TIME).SetEase(Ease.OutCubic);
			_instancedShapesMat.SetFloat(StartTime, float.PositiveInfinity);
			_shapesParent.gameObject.SetActive(value: true);
			BuildingCompletionEffect original = (_hasUpgradeOverwrite ? _currentUpgradeOverwrite.PolishedPrefab : _data.SinglePrefabRef);
			_buildingCompletionEffect = UnityEngine.Object.Instantiate(original, _polishedPrefabParent);
			_buildingCompletionEffect.Init();
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
				_isAnimating = false;
			}
		}

		private DioramaEditorSave GetDioramaSave()
		{
			if (_hasUpgradeOverwrite)
			{
				return _currentUpgradeOverwrite.DioramaSave;
			}
			return _data.DioramaSave;
		}

		public void AddShape(ShapeData shapeData, int index, bool anim = true)
		{
			DioramaEditorSave dioramaSave = GetDioramaSave();
			if (dioramaSave == null || !dioramaSave.DioramaShapesDictionary.TryGetValue(shapeData.GetShapeHash(), out var value))
			{
				return;
			}
			index = Mathf.Min(index, value.Shapes.Count);
			if (index < 0 || value.Shapes.Count <= 0)
			{
				return;
			}
			_shapeCount.TryAdd(shapeData, 0);
			while (_shapeCount[shapeData] < index)
			{
				DioramaEditorSave.DioramaShape dioramaShape = value.Shapes.ElementAt(_shapeCount[shapeData]);
				ShapeLoader newShape = ShapeLoader.CreateFromShapeData(shapeData, _shapeMeshLibrary, _instancedShapesMat);
				newShape.Rotate(dioramaShape.Rotation);
				newShape.transform.SetParent(_shapesParent);
				Vector3 targetPos = dioramaShape.Position - dioramaSave.Center;
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
				_shapeCount[shapeData]++;
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
			_isShowingPolishedVersion = false;
		}

		public void SetValid(bool isValid)
		{
			_buildingCompletionEffect.SetValid(isValid);
		}
	}
}
