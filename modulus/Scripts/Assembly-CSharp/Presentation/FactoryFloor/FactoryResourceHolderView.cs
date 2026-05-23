using System;
using System.Collections.Generic;
using Data.FactoryFloor;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using Data.Operator;
using FMODUnity;
using Presentation.FactoryFloor.FactoryObjectViews;
using UnityEngine;
using UnityEngine.VFX;

namespace Presentation.FactoryFloor
{
	public abstract class FactoryResourceHolderView<T> : FactoryBehaviorView<T>, IResourceHolderView, IHeatmapView where T : ResourceHolderBehaviour, IResourceHolder
	{
		[SerializeField]
		protected EventReference _passResourceSFX;

		[SerializeField]
		private List<FactoryObjectAnimator> _startActivityAnimators;

		[SerializeField]
		private List<FactoryObjectAnimator> _passResourceAnimators;

		[SerializeField]
		private List<CallFakeAnimOnMaterial> _fakeAnimations;

		[SerializeField]
		private List<CallFakeAnimOnMaterial> _perOutputFakeAnims;

		[SerializeField]
		private List<VisualEffect> _processVisualEffects = new List<VisualEffect>();

		private int _passResourceAnimatorsCount;

		private int _perOutputFakeAnimsCount;

		protected static readonly Vector3 OUTPUT_OFFSET = new Vector3(0.5f, 0.275f, 0.5f);

		protected IResourceHolderView[] _outputResourceHolderViews = Array.Empty<IResourceHolderView>();

		protected bool[] _hasOutputResourceHolderView = Array.Empty<bool>();

		protected Dictionary<int, IResourceHolderView.ReceiveResourceViewEvent> _receiveResourceViewSubscribers = new Dictionary<int, IResourceHolderView.ReceiveResourceViewEvent>();

		private const string PLAY_EFFECT_NAME = "Play";

		protected event IResourceHolderView.ReceiveResourceViewEvent OnReceiveResourceView = delegate
		{
		};

		public event Action OnInit = delegate
		{
		};

		protected override void Init()
		{
			_behaviour.OnOutputUpdated.RegisterMainThread(UpdateOutputView);
			_behaviour.OnActivityStart.RegisterMainThread(PlayStartAnimation);
			if (TryGetComponent<ResourceInputJobAnimator>(out var component))
			{
				component.SetResourceHolderView(this);
			}
			_passResourceAnimatorsCount = _passResourceAnimators.Count;
			_perOutputFakeAnimsCount = _perOutputFakeAnims.Count;
			if (_behaviour.OutputFactoryObjects != null)
			{
				UpdateOutputView();
				this.OnInit?.Invoke();
				base.Init();
			}
		}

		protected override void ResetFactoryObject()
		{
			ResetResourceHolderView();
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			ResetResourceHolderView();
			base.OnDestroy();
		}

		private void ResetResourceHolderView()
		{
			FactoryObjectViewManager.Instance.OnFactoryObjectViewCreated -= OutputFactoryObjectViewCreated;
			if ((bool)_behaviour)
			{
				_behaviour.OnOutputUpdated.UnRegisterMainThread(UpdateOutputView);
				_behaviour.OnActivityStart.UnRegisterMainThread(PlayStartAnimation);
			}
			this.OnReceiveResourceView = delegate
			{
			};
			_receiveResourceViewSubscribers.Clear();
		}

		private void UpdateOutputView()
		{
			_outputResourceHolderViews = new IResourceHolderView[_behaviour.OutputFactoryObjects.Length];
			_hasOutputResourceHolderView = new bool[_behaviour.OutputFactoryObjects.Length];
			for (int i = 0; i < _behaviour.OutputFactoryObjects.Length; i++)
			{
				FactoryObject.OutputFactoryObject outputFactoryObject = _behaviour.OutputFactoryObjects[i];
				if (outputFactoryObject == null)
				{
					continue;
				}
				if (FactoryObjectViewManager.Instance.TryGetFactoryObjectView(outputFactoryObject.FactoryObject.CreatedId, out var view))
				{
					if (view.TryGetComponent<IResourceHolderView>(out var component))
					{
						_outputResourceHolderViews[i] = component;
						_hasOutputResourceHolderView[i] = true;
					}
					else
					{
						_outputResourceHolderViews[i] = null;
						_hasOutputResourceHolderView[i] = false;
					}
				}
				else
				{
					FactoryObjectViewManager.Instance.OnFactoryObjectViewCreated += OutputFactoryObjectViewCreated;
				}
			}
		}

		private void OutputFactoryObjectViewCreated(FactoryObjectView factoryObjectView, FactoryObject factoryObj)
		{
			IResourceHolderView component;
			bool flag = factoryObjectView.TryGetComponent<IResourceHolderView>(out component);
			for (int i = 0; i < _behaviour.OutputFactoryObjects.Length; i++)
			{
				FactoryObject.OutputFactoryObject outputFactoryObject = _behaviour.OutputFactoryObjects[i];
				if (outputFactoryObject != null && outputFactoryObject.FactoryObject == factoryObj)
				{
					if (flag)
					{
						_outputResourceHolderViews[i] = component;
						_hasOutputResourceHolderView[i] = true;
					}
					else
					{
						_outputResourceHolderViews[i] = null;
						_hasOutputResourceHolderView[i] = false;
					}
					FactoryObjectViewManager.Instance.OnFactoryObjectViewCreated -= OutputFactoryObjectViewCreated;
				}
			}
		}

		public virtual void ReceiveResourceView(ResourceView resource, int inputIndex, bool scaleUpResource = true)
		{
			if (_receiveResourceViewSubscribers.Count == 0)
			{
				ResourceViewManager.Instance.ReturnResourceToPool(resource);
			}
			this.OnReceiveResourceView(resource, inputIndex, Vector3.zero);
		}

		public void AddReceiveResourceViewListener(int createdId, IResourceHolderView.ReceiveResourceViewEvent resourceViewEvent)
		{
			if (_receiveResourceViewSubscribers.TryAdd(createdId, resourceViewEvent))
			{
				OnReceiveResourceView += resourceViewEvent;
			}
		}

		public void RemoveReceiveResourceViewListener(int createdId, IResourceHolderView.ReceiveResourceViewEvent resourceViewEvent)
		{
			if (_receiveResourceViewSubscribers.ContainsKey(createdId))
			{
				_receiveResourceViewSubscribers.Remove(createdId);
				OnReceiveResourceView += resourceViewEvent;
			}
		}

		protected void PassResource(Resource resource, int outputIdx)
		{
			if (_hasOutputResourceHolderView[outputIdx])
			{
				FactoryObject.OutputFactoryObject outputFactoryObject = _behaviour.OutputFactoryObjects[outputIdx];
				ResourceView resourceView = ResourceViewManager.Instance.CreateNewResourceView(resource);
				FactoryObjectData.OutputData outputData = outputFactoryObject.OutputData;
				Vector3 vector = _objectView.FactoryObject.DataPosToWorldPos(outputData.Position - outputData.Direction);
				resourceView.transform.position = vector + OUTPUT_OFFSET;
				_outputResourceHolderViews[outputIdx].ReceiveResourceView(resourceView, outputFactoryObject.InputData.Index);
				if (_hasAudioManagerLocator)
				{
					_audioManagerLocator.AudioManager.PlayItemExit(vector);
				}
				PlayPassResourceAnimation(outputIdx);
			}
		}

		public ITrackActivity GetTrackActivity()
		{
			return _behaviour;
		}

		public virtual void PlayStartAnimation()
		{
			foreach (CallFakeAnimOnMaterial fakeAnimation in _fakeAnimations)
			{
				fakeAnimation.PlayAnimation();
			}
			foreach (FactoryObjectAnimator startActivityAnimator in _startActivityAnimators)
			{
				startActivityAnimator.PlayActivityStart();
			}
			foreach (VisualEffect processVisualEffect in _processVisualEffects)
			{
				processVisualEffect.SendEvent("Play");
			}
		}

		public void PlayPassResourceAnimation(int outputIndex)
		{
			if (_audioManagerLocator != null && !_passResourceSFX.IsNull)
			{
				_audioManagerLocator.AudioManager.PlayFactoryBehaviourViewOneShot(_passResourceSFX, _objectView.transform.position, _objectView.FactoryObject.FactoryObjectData.ObjectSize);
			}
			if (outputIndex < _passResourceAnimatorsCount)
			{
				_passResourceAnimators[outputIndex].PlayActivityStart();
			}
			if (outputIndex < _perOutputFakeAnimsCount)
			{
				_perOutputFakeAnims[outputIndex].PlayAnimation();
			}
		}
	}
}
