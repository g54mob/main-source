using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services.BoxService
{
	public class BoxService : IBoxService, IService
	{
		private List<BoxOnLevel> currentBoxes = new List<BoxOnLevel>();

		public void SetCurrentBoxes(BoxOnLevel box)
		{
			currentBoxes.Add(box);
		}

		public List<BoxOnLevel> GetCurrentBoxes()
		{
			if (currentBoxes != null)
			{
				return currentBoxes;
			}
			Debug.Log("Нет коробок на этом уровне!");
			return null;
		}

		public void ClearCurrenBoxes()
		{
			currentBoxes.Clear();
		}
	}
}
