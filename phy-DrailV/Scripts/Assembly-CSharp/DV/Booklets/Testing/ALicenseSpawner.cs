using System.Collections;
using System.Collections.Generic;
using DV.Localization.Debug;
using UnityEngine;

namespace DV.Booklets.Testing
{
	public abstract class ALicenseSpawner<T> : MonoBehaviour
	{
		public BookletPlacer bookletPlacer;

		private const float X_OFFSET = -0.21f;

		protected virtual void Start()
		{
			if ((bool)bookletPlacer)
			{
				List<GameObject> list = new List<GameObject>();
				foreach (GameObject item in Spawn())
				{
					list.Add(item);
				}
				bookletPlacer.booklets = list.ToArray();
				bookletPlacer.Arrange();
				return;
			}
			int num = 0;
			foreach (GameObject item2 in Spawn())
			{
				item2.transform.Translate(new Vector3(-0.21f * (float)num, 0f, 0f));
				num++;
			}
		}

		protected IEnumerable Spawn()
		{
			IEnumerable<T> licenses = GetLicenses();
			foreach (T item in licenses)
			{
				yield return Create(item);
			}
		}

		protected abstract IEnumerable<T> GetLicenses();

		protected abstract GameObject Create(T license);
	}
}
