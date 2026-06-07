using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class ParentFurnitures : MonoSingleton<ParentFurnitures>
	{
		protected override void SingletonAwake()
		{
			MapEditor.OnRefreshFurnitures += ClearAll;
		}

		protected override void OnSingletonDestroy()
		{
			MapEditor.OnRefreshFurnitures -= ClearAll;
		}

		private void ClearAll()
		{
			int childCount = base.transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Object.Destroy(base.transform.GetChild(i).gameObject);
			}
		}
	}
}
