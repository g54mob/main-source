using System;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class SaveSecondaryQuests : SaveContainer
	{
		public override void Clear()
		{
			SecondaryQuestsManager secondaryQuestsManager = ComponentGetter.GetComponentSingleSingleton(typeof(SecondaryQuestsManager)) as SecondaryQuestsManager;
			if ((bool)secondaryQuestsManager)
			{
				secondaryQuestsManager.Clear();
			}
		}

		public override void Save(ES3Settings settings)
		{
			ES3.ReferenceMode referenceMode = settings.referenceMode;
			try
			{
				settings.referenceMode = ES3.ReferenceMode.ByValue;
				SecondaryQuestsManager secondaryQuestsManager = ComponentGetter.GetComponentSingleSingleton(typeof(SecondaryQuestsManager)) as SecondaryQuestsManager;
				if ((bool)secondaryQuestsManager)
				{
					ES3.Save("SecondaryQuests", secondaryQuestsManager, settings);
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
			SecondaryQuestsManager secondaryQuestsManager = ComponentGetter.GetComponentSingleSingleton(typeof(SecondaryQuestsManager)) as SecondaryQuestsManager;
			if ((bool)secondaryQuestsManager)
			{
				LoadInto("SecondaryQuests", secondaryQuestsManager, settings);
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			SecondaryQuestsManager secondaryQuestsManager = ComponentGetter.GetComponentSingleSingleton(typeof(SecondaryQuestsManager)) as SecondaryQuestsManager;
			if ((bool)secondaryQuestsManager)
			{
				LoadInto("SecondaryQuests", secondaryQuestsManager, settings);
			}
		}
	}
}
