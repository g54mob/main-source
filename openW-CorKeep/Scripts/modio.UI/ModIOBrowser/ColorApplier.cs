using System.Collections;
using ModIO.Util;
using ModIOBrowser.Implementation;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	internal class ColorApplier<T> : MonoBehaviour where T : Graphic
	{
		public ColorSetterType color;

		public ColorScheme colorScheme;

		protected virtual T graphic => null;

		private void Start()
		{
			if (!Apply())
			{
				SelfInstancingMonoSingleton<CoroutineRunner>.Instance.Run(AttemptToRecolorSoon());
			}
		}

		private bool Apply()
		{
			if (this.colorScheme == null || SharedUi.colorScheme == null)
			{
				return false;
			}
			ColorScheme colorScheme = ((this.colorScheme == null) ? SharedUi.colorScheme : this.colorScheme);
			if (colorScheme != null)
			{
				graphic.color = colorScheme.GetSchemeColor(color);
				return true;
			}
			Debug.LogError("Unable to apply color to " + base.transform.FullPath());
			return false;
		}

		private IEnumerator AttemptToRecolorSoon()
		{
			yield return new WaitForEndOfFrame();
			while (!Apply())
			{
				yield return new WaitForSeconds(0.1f);
			}
		}
	}
}
