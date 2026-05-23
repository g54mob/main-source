using System;
using System.Collections.Generic;
using Data.FactoryFloor.Behaviours;
using Data.FactoryFloor.Resources;
using FMODUnity;
using UnityEngine;
using UnityEngine.VFX;

namespace Presentation.FactoryFloor
{
	public class ExtractorView : FactoryBehaviorView<ExtractorBehaviour>, IHeatmapView
	{
		private const string PLAY_EFFECT_NAME = "Play";

		[SerializeField]
		private ConveyorView _conveyorView;

		[SerializeField]
		private CallFakeAnimOnMaterial _passResourceAnimator;

		[SerializeField]
		protected EventReference _passResourceSFX;

		[SerializeField]
		private List<VisualEffect> _processVisualEffects = new List<VisualEffect>();

		public event Action OnInit;

		protected override void Init()
		{
			_behaviour.OnCreatedNewResource.RegisterMainThread(CreateNewResourceView);
			_behaviour.ConveyorBehaviour.OnOutputResource.RegisterMainThread(PreOnOutput);
			this.OnInit?.Invoke();
		}

		protected override void ResetFactoryObject()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnCreatedNewResource.UnRegisterMainThread(CreateNewResourceView);
				_behaviour.ConveyorBehaviour.OnOutputResource.UnRegisterMainThread(PreOnOutput);
			}
			base.ResetFactoryObject();
		}

		protected override void OnDestroy()
		{
			if ((bool)_behaviour)
			{
				_behaviour.OnCreatedNewResource.UnRegisterMainThread(CreateNewResourceView);
			}
			base.OnDestroy();
		}

		private void CreateNewResourceView(Resource resource)
		{
			ResourceView resourceView = ResourceViewManager.Instance.CreateNewResourceView(resource);
			resourceView.transform.position = _conveyorView.transform.position;
			_conveyorView.ReceiveResourceView(resourceView, 0);
		}

		private void PreOnOutput(Resource resource, int _)
		{
			_passResourceAnimator.PlayAnimation();
			_audioManagerLocator.AudioManager.PlayFactoryBehaviourViewOneShot(_passResourceSFX, _objectView.transform.position, _objectView.FactoryObject.FactoryObjectData.ObjectSize);
			foreach (VisualEffect processVisualEffect in _processVisualEffects)
			{
				processVisualEffect.SendEvent("Play");
			}
		}

		public ITrackActivity GetTrackActivity()
		{
			return _behaviour;
		}
	}
}
