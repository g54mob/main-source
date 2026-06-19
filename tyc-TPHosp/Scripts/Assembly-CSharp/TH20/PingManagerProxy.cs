using System.Collections;
using UnityEngine;

namespace TH20
{
	public class PingManagerProxy : MustCallDestroy
	{
		private readonly GameObject _pingManagerGameObject;

		private readonly PingManager _pingManager;

		public PingManagerProxy()
		{
			_pingManagerGameObject = new GameObject("Ping Manager");
			_pingManager = _pingManagerGameObject.AddComponent<PingManager>();
		}

		public override void Destroy()
		{
			_pingManager.StopAllCoroutines();
			Object.Destroy(_pingManagerGameObject);
			base.Destroy();
		}

		public Coroutine StartBehaviour(IEnumerator routine)
		{
			return _pingManager.StartCoroutine(routine);
		}

		public void StopBehaviour(Coroutine behaviourToStop)
		{
			_pingManager.StopCoroutine(behaviourToStop);
		}
	}
}
