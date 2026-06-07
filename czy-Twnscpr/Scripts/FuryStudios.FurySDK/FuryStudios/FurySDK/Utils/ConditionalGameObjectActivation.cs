using UnityEngine;
using UnityEngine.Events;

namespace FuryStudios.FurySDK.Utils
{
	public class ConditionalGameObjectActivation : MonoBehaviour
	{
		[SerializeField]
		private bool triggerOnAwake;

		[SerializeField]
		private bool triggerOnStart;

		[SerializeField]
		private bool triggerEveryUpdate;

		[Space]
		[SerializeReference]
		[SerializeField]
		private ICondition condition;

		[SerializeField]
		private GameObject[] gameObjectsToActiveIfSatisfied;

		[SerializeField]
		private GameObject[] gameObjectsToDeactiveIfSatisfied;

		[SerializeField]
		private GameObject[] gameObjectsToActiveIfNotSatisfied;

		[SerializeField]
		private GameObject[] gameObjectsToDeactiveIfNotSatisfied;

		[SerializeField]
		private SatisfiedEvent satisfiedEvent;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Trigger()
		{
		}

		public void AddListener(UnityAction<bool> listener)
		{
		}
	}
}
