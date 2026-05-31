using CTS.Core;
using UnityEngine;

namespace CTS.UI
{
	public abstract class OpenCanvasAbstract : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CanvasGroupController _controller;

		public abstract bool CanBeOpenWithEscap();
	}
}
