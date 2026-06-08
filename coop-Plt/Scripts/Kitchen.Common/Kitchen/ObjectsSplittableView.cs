using System.Collections.Generic;
using UnityEngine;

namespace Kitchen
{
	public class ObjectsSplittableView : SplittableItemView
	{
		[SerializeField]
		[Header("References")]
		private List<GameObject> Objects;

		protected override void UpdateData(ViewData data)
		{
			if (data.Total == 0)
			{
				data.Remaining = 999;
			}
			for (int i = 0; i < Objects.Count; i++)
			{
				Objects[i].SetActive(i < data.Remaining);
			}
		}
	}
}
