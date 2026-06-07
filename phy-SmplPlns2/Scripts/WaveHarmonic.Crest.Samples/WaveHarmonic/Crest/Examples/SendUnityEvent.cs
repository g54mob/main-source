using UnityEngine;
using UnityEngine.Events;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Examples
{
	[AddComponentMenu("")]
	[ExecuteAlways]
	internal sealed class SendUnityEvent : CustomBehaviour
	{
		[SerializeField]
		private float _ExecuteUpdateEvery;

		[SerializeField]
		private float _StopExecutingUpdateAfter = float.PositiveInfinity;

		[SerializeField]
		private UnityEvent _OnEnable = new UnityEvent();

		[SerializeField]
		private UnityEvent _OnDisable = new UnityEvent();

		[SerializeField]
		private UnityEvent<float> _OnUpdate = new UnityEvent<float>();

		[SerializeField]
		private UnityEvent _OnLegacyRenderPipeline = new UnityEvent();

		[SerializeField]
		private UnityEvent _OnHighDefinitionPipeline = new UnityEvent();

		[SerializeField]
		private UnityEvent _OnUniversalRenderPipeline = new UnityEvent();

		private float _TimeSinceEnabled;

		private float _LastUpdateTime;

		private protected override void OnEnable()
		{
			base.OnEnable();
			_TimeSinceEnabled = 0f;
			_OnEnable.Invoke();
			if (RenderPipelineHelper.IsHighDefinition)
			{
				_OnHighDefinitionPipeline?.Invoke();
			}
			else if (RenderPipelineHelper.IsUniversal)
			{
				_OnUniversalRenderPipeline?.Invoke();
			}
			else
			{
				_OnLegacyRenderPipeline?.Invoke();
			}
		}

		private void OnDisable()
		{
			_OnDisable.Invoke();
		}

		private void Update()
		{
			_TimeSinceEnabled += Time.deltaTime;
			_LastUpdateTime += Time.deltaTime;
			if (!(_LastUpdateTime < _ExecuteUpdateEvery))
			{
				_LastUpdateTime = 0f;
				if (!(_TimeSinceEnabled > _StopExecutingUpdateAfter))
				{
					_OnUpdate.Invoke(_TimeSinceEnabled);
				}
			}
		}
	}
}
