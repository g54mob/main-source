using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class Pingable : MustCallDestroy
	{
		private PingBehaviour _currentBehaviour;

		private Coroutine _behaviourCoroutine;

		public PingManagerProxy PingManagerProxy { get; private set; }

		public RectTransform RectTransform { get; private set; }

		public Image Image { get; private set; }

		public bool IsPinging { get; private set; }

		public Pingable(PingManagerProxy pingManagerProxy, RectTransform transform, Image image)
		{
			PingManagerProxy = pingManagerProxy;
			RectTransform = transform;
			Image = image;
		}

		public override void Destroy()
		{
			StopPing();
			base.Destroy();
		}

		public void Ping(PingInit init)
		{
			IsPinging = true;
			if (_currentBehaviour == null && _behaviourCoroutine == null && init != null)
			{
				_currentBehaviour = init.CreateBehaviour();
				_behaviourCoroutine = PingManagerProxy.StartBehaviour(_currentBehaviour.PingCoroutine(this));
			}
		}

		public void StopPing()
		{
			if (_currentBehaviour != null && _behaviourCoroutine != null)
			{
				PingManagerProxy.StopBehaviour(_behaviourCoroutine);
				_behaviourCoroutine = null;
				_currentBehaviour.OnPingReset(this);
				_currentBehaviour = null;
			}
			IsPinging = false;
		}
	}
}
