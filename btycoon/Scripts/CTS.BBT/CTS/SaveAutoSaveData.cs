using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CTS
{
	public class SaveAutoSaveData : SaveContainer
	{
		public override void Save(ES3Settings settings)
		{
			List<GameObject> list = new List<GameObject>();
			foreach (ES3AutoSave autoSafe in ES3AutoSaveMgr.Current.autoSaves)
			{
				if (autoSafe != null && autoSafe.enabled)
				{
					list.Add(autoSafe.gameObject);
				}
			}
			ES3.Save("AutoSaveData", list.OrderBy((GameObject x) => GetDepth(x.transform)).ToArray(), settings);
			static int GetDepth(Transform t)
			{
				int num = 0;
				while (t.parent != null)
				{
					t = t.parent;
					num++;
				}
				return num;
			}
		}

		public override void LoadInit(ES3Settings settings)
		{
			ES3.Load("AutoSaveData", Array.Empty<GameObject>(), SaveSettings.Cache);
		}

		public override void LoadPost(ES3Settings settings)
		{
			ES3.Load("AutoSaveData", Array.Empty<GameObject>(), SaveSettings.Cache);
		}
	}
}
