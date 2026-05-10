using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class ParticleParenting : CTSBehaviour
	{
		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private ActivationEvents _activationEvents;

		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		private ParticleSystem[] _particleSystems;

		private Transform _parent;

		private Vector3 _localPos;

		protected override void OnAwake()
		{
			base.OnAwake();
			Transform transform = base.transform;
			_parent = transform.parent;
			_localPos = transform.localPosition;
			base.transform.SetParent(null);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if ((bool)_activationEvents)
			{
				_activationEvents.ActiveStatusChanged += OnParentActive;
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			if ((bool)_activationEvents)
			{
				_activationEvents.ActiveStatusChanged -= OnParentActive;
			}
		}

		private void OnParentActive(bool active)
		{
			if (active)
			{
				ParticleSystem[] particleSystems = _particleSystems;
				for (int i = 0; i < particleSystems.Length; i++)
				{
					particleSystems[i].Play(withChildren: false);
				}
			}
			else
			{
				ParticleSystem[] particleSystems = _particleSystems;
				for (int i = 0; i < particleSystems.Length; i++)
				{
					particleSystems[i].Stop(withChildren: false);
				}
			}
		}

		private void LateUpdate()
		{
			base.transform.position = _parent.TransformPoint(_localPos);
		}
	}
}
