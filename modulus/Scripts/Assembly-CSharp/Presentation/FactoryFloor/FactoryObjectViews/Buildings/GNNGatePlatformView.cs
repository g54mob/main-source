using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.Buildings
{
	public class GNNGatePlatformView : MonoBehaviour
	{
		[SerializeField]
		private List<MeshRenderer> _counterMeshRenderers = new List<MeshRenderer>();

		[SerializeField]
		private List<MeshRenderer> _pillarsVFX = new List<MeshRenderer>();

		[SerializeField]
		private List<Animator> _counterAnimators = new List<Animator>();

		[SerializeField]
		private Material _completingContourMat;

		[SerializeField]
		private Material _completedContourMat;

		[SerializeField]
		private Animator _fakeLightsAnimator;

		private int _countersTriggered = -1;

		private static readonly int TriggerCounter = Animator.StringToHash("TriggerCounter");

		private static readonly int FakeLightTrigger = Animator.StringToHash("TriggerLight");

		private static readonly int StartTime = Shader.PropertyToID("_StartTime");

		private static readonly int TransitionTime = Shader.PropertyToID("TransitionTime");

		private const float COUNTER_MAT_COMPLETION_ANIM_TIME = 1f;

		[Button(null, EButtonEnableMode.Always)]
		private void GetAnimators()
		{
			_counterAnimators.Clear();
			for (int i = 0; i < _counterMeshRenderers.Count; i++)
			{
				_counterAnimators.Add(_counterMeshRenderers[i].GetComponentInChildren<Animator>());
			}
		}

		private void Awake()
		{
			_countersTriggered = 0;
		}

		public void TriggerCounterAnimation(int index)
		{
			if (index != 0)
			{
				EnsurePreviousCountersCompletion(index);
				_countersTriggered = index - 1;
				StartCoroutine(SetCounterTransitionMatAnimation());
				if (_countersTriggered < _counterMeshRenderers.Count - 1)
				{
					_counterMeshRenderers[_countersTriggered + 1].sharedMaterial = _completingContourMat;
				}
			}
		}

		private void EnsurePreviousCountersCompletion(int index)
		{
			for (int i = _countersTriggered; i < index; i++)
			{
				_counterAnimators[i].SetTrigger(TriggerCounter);
				_counterMeshRenderers[i].sharedMaterial = _completedContourMat;
			}
			TogglePillar(index);
		}

		private void TogglePillar(int index)
		{
			if (index >= 5)
			{
				_pillarsVFX[index / 5 - 1].gameObject.SetActive(value: true);
			}
		}

		private IEnumerator SetCounterTransitionMatAnimation()
		{
			Material material = Object.Instantiate(_completedContourMat);
			material.SetFloat(StartTime, Time.time);
			material.SetFloat(TransitionTime, 1f);
			_counterMeshRenderers[_countersTriggered].material = material;
			yield return new WaitForSeconds(1f);
			_counterMeshRenderers[_countersTriggered].sharedMaterial = _completedContourMat;
			TogglePillar(_countersTriggered);
		}

		public void TriggerFakeLightsAnimation()
		{
			_fakeLightsAnimator.SetTrigger(FakeLightTrigger);
		}
	}
}
