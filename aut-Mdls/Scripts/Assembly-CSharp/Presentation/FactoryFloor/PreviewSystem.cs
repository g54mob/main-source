#define ENABLE_DEBUG_EXCEPTIONS
using System.Collections.Generic;
using Data.Operator;
using Events;
using Events.FactoryFloor;
using Presentation.Locators;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor
{
	public class PreviewSystem : MonoBehaviour
	{
		[SerializeField]
		private PreviewSystemLocator _previewSystemLocator;

		[SerializeField]
		private BluePrintEvent _startPreviewEvent;

		[SerializeField]
		private BluePrintEvent _updatePreviewEvent;

		[SerializeField]
		private BaseEvent _stopPreviewEvent;

		[SerializeField]
		private Transform _moveParent;

		[SerializeField]
		private Vector3 _offset = Vector3.up;

		[Header("Juice")]
		[SerializeField]
		private float _rotationLerpSpeed = 10f;

		[SerializeField]
		private float _rotateAmountMin = 4f;

		[SerializeField]
		private float _rotateAmountMax = 8f;

		[SerializeField]
		private float _randomYRotationAmount = 10f;

		private readonly List<PreviewingObject> _previewingObjects = new List<PreviewingObject>();

		private readonly Dictionary<PreviewingObject, PreviewingTargetPosition> _previewTargetPositions = new Dictionary<PreviewingObject, PreviewingTargetPosition>();

		private int _firstElementRot;

		private int _currRotation;

		private Vector3 _currPosition;

		private Vector3 _lastElementPos;

		private Vector3 _angularVelocity;

		private int _previewingObjCount;

		private Vector3 _lastUpdatePos;

		private void Awake()
		{
			_startPreviewEvent.Register(StartPreview);
			_updatePreviewEvent.Register(UpdatePreview);
			_stopPreviewEvent.Register(StopPreview);
			_previewSystemLocator.PreviewSystem = this;
		}

		private void OnDestroy()
		{
			_startPreviewEvent.UnRegister(StartPreview);
			_updatePreviewEvent.UnRegister(UpdatePreview);
			_stopPreviewEvent.UnRegister(StopPreview);
		}

		private void Update()
		{
			UpdateAngularVelocity();
			AnimatePreviewObjects();
		}

		private void UpdateAngularVelocity()
		{
			_angularVelocity = Vector3.Lerp(_angularVelocity, Vector3.zero, Time.deltaTime * _rotationLerpSpeed);
		}

		private void AnimatePreviewObjects()
		{
			foreach (KeyValuePair<PreviewingObject, PreviewingTargetPosition> previewTargetPosition in _previewTargetPositions)
			{
				previewTargetPosition.Key.FactoryObjectView.transform.position = previewTargetPosition.Value.TargetPosition;
				Quaternion identity = Quaternion.identity;
				identity *= Quaternion.Euler(Vector3.forward * (Mathf.Lerp(_rotateAmountMax, _rotateAmountMin, previewTargetPosition.Value.Random) * _angularVelocity.x));
				identity *= Quaternion.Euler(Vector3.right * (Mathf.Lerp(_rotateAmountMax, _rotateAmountMin, previewTargetPosition.Value.Random) * (0f - _angularVelocity.z)));
				identity *= Quaternion.Euler(Vector3.up * (Mathf.Lerp(0f - _randomYRotationAmount, _randomYRotationAmount, previewTargetPosition.Value.Random) * (0f - _angularVelocity.magnitude)));
				identity *= previewTargetPosition.Value.TargetRotation;
				previewTargetPosition.Key.FactoryObjectView.transform.rotation = identity;
			}
		}

		private void StartPreview(BlueprintViewEventDto blueprintViewEventDto)
		{
			if (_currPosition == Vector3.zero)
			{
				_currPosition = blueprintViewEventDto.Blueprint.Position + _offset;
			}
			_angularVelocity = Vector3.zero;
			_moveParent.rotation = Quaternion.Euler(0f, blueprintViewEventDto.Blueprint.Rotation, 0f);
			for (int i = 0; i < blueprintViewEventDto.Blueprint.BlueprintViewElementDtos.Count; i++)
			{
				CreatePreviewObject(blueprintViewEventDto, blueprintViewEventDto.Blueprint.BlueprintViewElementDtos[i], i);
			}
		}

		private void CreatePreviewObject(BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element, int elementIndex)
		{
			FactoryObjectView factoryObjectView = FactoryObjectViewPoolManager.Instance.GetObject(element.ObjectId);
			factoryObjectView.transform.SetParent(_moveParent);
			factoryObjectView.gameObject.SetActive(value: true);
			PreviewingObject previewingObject = new PreviewingObject(element.ObjectId, factoryObjectView);
			_previewingObjects.Add(previewingObject);
			factoryObjectView.Select();
			factoryObjectView.transform.position = blueprintViewEventDto.Blueprint.Position + element.Position;
			Debug.DrawLine(factoryObjectView.transform.position, factoryObjectView.transform.position + Vector3.up * 3f, Color.green, 100f);
			factoryObjectView.transform.localRotation = Quaternion.Euler(0f, element.Rotation, 0f);
			factoryObjectView.transform.localScale = new Vector3((!element.Mirrored) ? 1 : (-1), 1f, 1f);
			factoryObjectView.SetAllPreviewPositions(element.AllPositions);
			factoryObjectView.InitPreview(element.ObjectId, blueprintViewEventDto, element);
			factoryObjectView.ValidPosition(blueprintViewEventDto.CanBePlaced(elementIndex));
			_previewTargetPositions.Add(previewingObject, new PreviewingTargetPosition(blueprintViewEventDto.Blueprint.Position + element.Position, factoryObjectView.transform.rotation, Random.Range(0f, 1f)));
		}

		private void UpdatePreview(BlueprintViewEventDto blueprintViewEventDto)
		{
			if (blueprintViewEventDto.Blueprint.BlueprintViewElementDtos.Count == 0)
			{
				this.DevException("Updating preview for empty selection!", "UpdatePreview", 116);
				return;
			}
			bool flag = _currRotation != blueprintViewEventDto.Blueprint.Rotation;
			_currRotation = blueprintViewEventDto.Blueprint.Rotation;
			flag = flag || _firstElementRot != blueprintViewEventDto.Blueprint.BlueprintViewElementDtos[0].Rotation;
			_firstElementRot = blueprintViewEventDto.Blueprint.BlueprintViewElementDtos[0].Rotation;
			List<BlueprintViewDto.BlueprintViewElementDto> blueprintViewElementDtos = blueprintViewEventDto.Blueprint.BlueprintViewElementDtos;
			Vector3 position = blueprintViewElementDtos[blueprintViewElementDtos.Count - 1].Position;
			_currPosition = blueprintViewEventDto.Blueprint.Position + _offset;
			bool flag2 = (flag || _currPosition != _lastUpdatePos || _previewingObjects.Count != _previewingObjCount || _lastElementPos != position) && _angularVelocity.sqrMagnitude < 0.25f;
			_angularVelocity += blueprintViewEventDto.Blueprint.Position + _offset - _currPosition;
			_lastElementPos = position;
			_previewingObjCount = _previewingObjects.Count;
			_moveParent.rotation = Quaternion.Euler(0f, blueprintViewEventDto.Blueprint.Rotation, 0f);
			CreateMissingObjects(blueprintViewEventDto);
			for (int i = 0; i < _previewingObjects.Count; i++)
			{
				PreviewingObject previewingObject = _previewingObjects[i];
				previewingObject.FactoryObjectView.transform.localRotation = Quaternion.Euler(0f, blueprintViewEventDto.Blueprint.BlueprintViewElementDtos[i].Rotation, 0f);
				previewingObject.FactoryObjectView.transform.localScale = new Vector3((!blueprintViewEventDto.Blueprint.BlueprintViewElementDtos[i].Mirrored) ? 1 : (-1), 1f, 1f);
				previewingObject.FactoryObjectView.SetAllPreviewPositions(blueprintViewEventDto.Blueprint.BlueprintViewElementDtos[i].AllPositions);
				if (flag || _previewTargetPositions[previewingObject].TargetPosition.y < -100f)
				{
					previewingObject.FactoryObjectView.transform.position = blueprintViewEventDto.Blueprint.Position + blueprintViewEventDto.Blueprint.BlueprintViewElementDtos[i].Position;
					_angularVelocity = Vector3.zero;
				}
				_previewTargetPositions[previewingObject] = new PreviewingTargetPosition(blueprintViewEventDto.Blueprint.Position + blueprintViewEventDto.Blueprint.BlueprintViewElementDtos[i].Position, previewingObject.FactoryObjectView.transform.rotation, _previewTargetPositions[previewingObject].Random);
				if (flag2)
				{
					previewingObject.FactoryObjectView.UpdatePreview(blueprintViewEventDto, blueprintViewEventDto.Blueprint.BlueprintViewElementDtos[i]);
					_lastUpdatePos = _currPosition;
				}
				previewingObject.FactoryObjectView.ValidPosition(blueprintViewEventDto.CanBePlaced(i));
			}
			AnimatePreviewObjects();
		}

		private void CreateMissingObjects(BlueprintViewEventDto blueprintViewEventDto)
		{
			List<(int, int, int)> list = new List<(int, int, int)>();
			int i;
			for (i = 0; i < blueprintViewEventDto.Blueprint.BlueprintViewElementDtos.Count; i++)
			{
				BlueprintViewDto.BlueprintViewElementDto blueprintViewElementDto = blueprintViewEventDto.Blueprint.BlueprintViewElementDtos[i];
				if (i >= _previewingObjects.Count)
				{
					CreatePreviewObject(blueprintViewEventDto, blueprintViewElementDto, i);
				}
				else if (_previewingObjects[i].ObjectId != blueprintViewElementDto.ObjectId)
				{
					list.Add((i, _previewingObjects[i].ObjectId, blueprintViewElementDto.ObjectId));
				}
			}
			while (list.Count > 0)
			{
				ResolveMismatchedPreviewObject(blueprintViewEventDto, list, i);
				list.RemoveAt(0);
			}
			while (i < _previewingObjects.Count)
			{
				RemovePreviewObject(i);
			}
		}

		private void ResolveMismatchedPreviewObject(BlueprintViewEventDto blueprintViewEventDto, List<(int index, int currentObjectId, int targetObjectId)> ToResolve, int inUsePreviewingObjectsCount)
		{
			(int index, int currentObjectId, int targetObjectId) tuple = ToResolve[0];
			int item = tuple.index;
			int item2 = tuple.currentObjectId;
			int item3 = tuple.targetObjectId;
			int item4;
			List<PreviewingObject> previewingObjects;
			int index;
			PreviewingObject previewingObject;
			PreviewingObject previewingObject2;
			PreviewingObject previewingObject3;
			for (int i = 1; i < ToResolve.Count; i++)
			{
				if (item3 == ToResolve[i].currentObjectId)
				{
					previewingObjects = _previewingObjects;
					item4 = ToResolve[i].index;
					List<PreviewingObject> previewingObjects2 = _previewingObjects;
					index = item;
					previewingObject = _previewingObjects[item];
					previewingObject2 = _previewingObjects[ToResolve[i].index];
					previewingObject3 = (previewingObjects[item4] = previewingObject);
					previewingObject3 = (previewingObjects2[index] = previewingObject2);
					ToResolve[i] = (ToResolve[i].index, item2, ToResolve[i].targetObjectId);
					return;
				}
			}
			for (int j = inUsePreviewingObjectsCount; j < _previewingObjects.Count; j++)
			{
				if (item3 == _previewingObjects[j].ObjectId)
				{
					List<PreviewingObject> previewingObjects3 = _previewingObjects;
					index = j;
					previewingObjects = _previewingObjects;
					item4 = item;
					previewingObject2 = _previewingObjects[item];
					previewingObject = _previewingObjects[j];
					previewingObject3 = (previewingObjects3[index] = previewingObject2);
					previewingObject3 = (previewingObjects[item4] = previewingObject);
					return;
				}
			}
			CreatePreviewObject(blueprintViewEventDto, blueprintViewEventDto.Blueprint.BlueprintViewElementDtos[item], item);
			item4 = (previewingObjects = _previewingObjects).Count - 1;
			List<PreviewingObject> previewingObjects4 = _previewingObjects;
			index = item;
			previewingObject = _previewingObjects[item];
			List<PreviewingObject> previewingObjects5 = _previewingObjects;
			previewingObject2 = previewingObjects5[previewingObjects5.Count - 1];
			previewingObject3 = (previewingObjects[item4] = previewingObject);
			previewingObject3 = (previewingObjects4[index] = previewingObject2);
			RemovePreviewObject(_previewingObjects.Count - 1);
		}

		private void RemovePreviewObject(int index)
		{
			PreviewingObject previewingObject = _previewingObjects[index];
			previewingObject.FactoryObjectView.DeSelect();
			previewingObject.FactoryObjectView.transform.SetParent(FactoryObjectViewPoolManager.Instance.transform);
			FactoryObjectViewPoolManager.Instance.ReturnFactoryObject(previewingObject.ObjectId, previewingObject.FactoryObjectView, wasPreview: true);
			_previewTargetPositions.Remove(previewingObject);
			_previewingObjects.RemoveAt(index);
		}

		private void StopPreview()
		{
			foreach (PreviewingObject previewingObject in _previewingObjects)
			{
				previewingObject.FactoryObjectView.DeSelect();
				previewingObject.FactoryObjectView.transform.SetParent(FactoryObjectViewPoolManager.Instance.transform);
				FactoryObjectViewPoolManager.Instance.ReturnFactoryObject(previewingObject.ObjectId, previewingObject.FactoryObjectView, wasPreview: true);
			}
			_previewingObjects.Clear();
			_previewTargetPositions.Clear();
		}

		public bool IsPreviewing(FactoryObjectView factoryObjectView)
		{
			foreach (PreviewingObject previewingObject in _previewingObjects)
			{
				if (previewingObject.FactoryObjectView == factoryObjectView)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsPreviewing(FactoryObjectData factoryObjectData)
		{
			foreach (PreviewingObject key in _previewTargetPositions.Keys)
			{
				if (key.ObjectId == factoryObjectData.ID)
				{
					return true;
				}
			}
			return false;
		}
	}
}
