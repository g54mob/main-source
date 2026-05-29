using CTS.BBT.AI;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class AgentVFXData : CTSBehaviour
	{
		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		private AgentAnimator _animator;

		[SerializeField]
		private SerializableDictionary<string, MonoRoutine> _effectList;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_animator.Events.OnPlayVFX += PlayVFX;
			_animator.Events.OnStopVFX += StopVFX;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_animator.Events.OnPlayVFX -= PlayVFX;
			_animator.Events.OnStopVFX -= StopVFX;
		}

		private void PlayVFX(string key)
		{
			if (_effectList.TryGetValue(key, out var value))
			{
				value.Play();
			}
		}

		private void StopVFX(string key)
		{
			if (_effectList.TryGetValue(key, out var value))
			{
				value.Stop();
			}
		}
	}
}
