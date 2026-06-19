using System.Collections.Generic;
using System.Linq;
using ModIO.Util;
using UnityEngine;

namespace ModIOBrowser
{
	public class SingletonAwakener : MonoBehaviour
	{
		private bool hasAwakened;

		public List<GameObject> singletons;

		private void Awake()
		{
			AttemptInitilization();
		}

		private void SetupSingletons()
		{
			singletons.SelectMany((GameObject x) => x.GetComponentsInChildren<ISimpleMonoSingleton>()).ToList().ForEach(delegate(ISimpleMonoSingleton x)
			{
				x.SetupSingleton();
			});
		}

		public void AttemptInitilization()
		{
			if (!hasAwakened)
			{
				SetupSingletons();
			}
		}
	}
}
