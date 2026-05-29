using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class ConstructionSystemCanvasLocker : ConstructionSystemStatusUpdate
	{
		[SerializeField]
		[Inject(false)]
		private CanvasGroupController _canvasGroup;

		private LockToggle _lockToggle;

		protected override void OnAwake()
		{
			_lockToggle = new LockToggle(_canvasGroup);
			base.OnAwake();
		}

		protected override void OnConstructionOpened()
		{
			_lockToggle.Lock();
		}

		protected override void OnConstructionClosed()
		{
			_lockToggle.Unlock();
		}
	}
}
