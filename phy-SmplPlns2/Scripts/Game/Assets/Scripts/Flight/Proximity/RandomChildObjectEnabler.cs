using System.Collections.Generic;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Flight.Proximity
{
	public class RandomChildObjectEnabler : MonoBehaviour
	{
		[SerializeField]
		private int _numberToEnable = 1;

		protected virtual void Awake()
		{
			int childCount = base.transform.childCount;
			List<int> list = new List<int>(_numberToEnable);
			while (list.Count < childCount && list.Count < _numberToEnable)
			{
				int item = Random.Range(0, childCount);
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				Transform child = base.transform.GetChild(list[i]);
				if (child == null)
				{
					this.LogError("The child object could not be obtained.");
				}
				else
				{
					child.gameObject.SetActive(value: true);
				}
			}
		}
	}
}
