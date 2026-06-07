using JBooth.MicroVerseCore.Browser;
using UnityEngine;

namespace JBooth.MicroVerseCore.Demo.TimeOfDay
{
	[ExecuteInEditMode]
	public class TimeOfDay : LightAnchor, IContentBrowserDropAction
	{
		private void Update()
		{
			if (!Application.isPlaying)
			{
				RenderSettings.sun.transform.rotation = base.transform.rotation;
			}
		}

		public void Execute(out bool destroyAfterExecute)
		{
			destroyAfterExecute = false;
			TimeOfDay[] array = Object.FindObjectsByType<TimeOfDay>(FindObjectsSortMode.None);
			foreach (TimeOfDay timeOfDay in array)
			{
				if (!(timeOfDay.transform == base.transform))
				{
					timeOfDay.transform.rotation = base.transform.rotation;
					destroyAfterExecute = true;
				}
			}
		}
	}
}
