using System.Collections;
using Mirror.Cloud.ListServerService;
using UnityEngine;

namespace Mirror.Cloud
{
	[DisallowMultipleComponent]
	public class ApiConnector : MonoBehaviour, IApiConnector, ICoroutineRunner, IUnityEqualCheck
	{
		[SerializeField]
		private string ApiAddress;

		[SerializeField]
		private string ApiKey;

		[SerializeField]
		private ServerListEvent _onServerListUpdated;

		private IRequestCreator requestCreator;

		public ListServer ListServer { get; private set; }

		private void Awake()
		{
		}

		private void InitListServer()
		{
		}

		public void OnDestroy()
		{
		}

		Coroutine ICoroutineRunner.StartCoroutine(IEnumerator routine)
		{
			return null;
		}

		void ICoroutineRunner.StopCoroutine(IEnumerator routine)
		{
		}

		void ICoroutineRunner.StopCoroutine(Coroutine routine)
		{
		}
	}
}
