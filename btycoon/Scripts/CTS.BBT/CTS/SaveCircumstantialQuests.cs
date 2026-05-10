using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class SaveCircumstantialQuests : SaveContainer
	{
		public override void Clear()
		{
			base.Clear();
			(ComponentGetter.GetComponentSingleSingleton(typeof(CircumstantialQuestsManager)) as CircumstantialQuestsManager).Clear();
		}

		public override void Save(ES3Settings settings)
		{
			ES3.ReferenceMode referenceMode = settings.referenceMode;
			try
			{
				settings.referenceMode = ES3.ReferenceMode.ByValue;
				CircumstantialQuestsManager circumstantialQuestsManager = ComponentGetter.GetComponentSingleSingleton(typeof(CircumstantialQuestsManager)) as CircumstantialQuestsManager;
				if ((bool)circumstantialQuestsManager)
				{
					ES3.Save("CircumstantialQuests", circumstantialQuestsManager, settings);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
				settings.referenceMode = referenceMode;
			}
		}

		public override void LoadInit(ES3Settings settings)
		{
			CircumstantialQuestsManager circumstantialQuestsManager = ComponentGetter.GetComponentSingleSingleton(typeof(CircumstantialQuestsManager)) as CircumstantialQuestsManager;
			if ((bool)circumstantialQuestsManager)
			{
				LoadInto("CircumstantialQuests", circumstantialQuestsManager, settings);
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			CircumstantialQuestsManager circumstantialQuestsManager = ComponentGetter.GetComponentSingleSingleton(typeof(CircumstantialQuestsManager)) as CircumstantialQuestsManager;
			if ((bool)circumstantialQuestsManager)
			{
				LoadInto("CircumstantialQuests", circumstantialQuestsManager, settings);
			}
		}
	}
}
