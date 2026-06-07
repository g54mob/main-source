using System.Collections.Generic;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public abstract class UI_Manager<TManager> : CTSBehaviour, IRepaint where TManager : UI_Manager<TManager>
	{
		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		private List<UI_ManagerFeature<TManager>> _features = new List<UI_ManagerFeature<TManager>>();

		private void Start()
		{
			Repaint();
		}

		public void Repaint()
		{
			foreach (UI_ManagerFeature<TManager> feature in _features)
			{
				if (feature.isActiveAndEnabled)
				{
					feature.Repaint();
				}
			}
		}
	}
}
