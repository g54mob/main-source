using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Events.FactoryFloor;
using FMODUnity;
using Presentation.Locators;
using UnityEngine;

namespace Presentation.FactoryFloor
{
	public class FactoryBehaviorView<T> : MonoBehaviour where T : FactoryObjectBehaviour
	{
		[SerializeField]
		protected AudioManagerLocator _audioManagerLocator;

		[SerializeField]
		protected FactoryObjectView _objectView;

		[SerializeField]
		protected EventReference _activityStartSFX;

		protected bool _hasAudioManagerLocator;

		protected T _behaviour;

		protected virtual void Init()
		{
			if (_audioManagerLocator != null)
			{
				_hasAudioManagerLocator = true;
			}
		}

		protected virtual void PreviewInit(int objectId, BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
		}

		protected virtual void UpdatePreview(BlueprintViewEventDto blueprintViewEventDto, BlueprintViewDto.BlueprintViewElementDto element)
		{
		}

		protected virtual void Awake()
		{
			_objectView.FactoryObjectSet += SetFactoryObject;
			_objectView.FactoryObjectReset += ResetFactoryObjectView;
			_objectView.PreviewingPositions += PreviewingPositions;
			_objectView.OnInitPreview += PreviewInit;
			_objectView.OnUpdatePreview += UpdatePreview;
		}

		protected virtual void OnDestroy()
		{
			_objectView.FactoryObjectSet -= SetFactoryObject;
			_objectView.FactoryObjectReset -= ResetFactoryObjectView;
			_objectView.PreviewingPositions -= PreviewingPositions;
			_objectView.OnInitPreview -= PreviewInit;
			_objectView.OnUpdatePreview -= UpdatePreview;
			RemoveBehaviourListeners();
		}

		public virtual void SetFactoryObject(FactoryObject factoryObject, bool isGameLoading = false)
		{
			_behaviour = _objectView.FactoryObject.GetFactoryObjectBehaviour<T>();
			if (_behaviour != null)
			{
				_behaviour.OnActivityStart.RegisterMainThread(HandleActivityStart);
				_behaviour.OnActivityEnd.RegisterMainThread(HandleActivityEnd);
			}
			Init();
		}

		protected virtual void HandleActivityStart()
		{
			if (!_activityStartSFX.IsNull && _audioManagerLocator != null)
			{
				_audioManagerLocator.AudioManager.PlayFactoryBehaviourViewOneShot(_activityStartSFX, _objectView.transform.position, _objectView.FactoryObject.FactoryObjectData.ObjectSize);
			}
		}

		protected virtual void HandleActivityEnd()
		{
		}

		public virtual FactoryObject GetFactoryObject()
		{
			return _objectView.FactoryObject;
		}

		protected void ResetFactoryObjectView(FactoryObjectView _)
		{
			ResetFactoryObject();
		}

		protected virtual void ResetFactoryObject()
		{
			RemoveBehaviourListeners();
		}

		private void RemoveBehaviourListeners()
		{
			if (_behaviour != null)
			{
				_behaviour.OnActivityStart.UnRegisterMainThread(HandleActivityStart);
				_behaviour.OnActivityEnd.UnRegisterMainThread(HandleActivityEnd);
				_behaviour = null;
			}
		}

		protected virtual void PreviewingPositions(List<Vector3> allPositions)
		{
		}
	}
}
