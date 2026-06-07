using System.Collections.Generic;
using UnityEngine;

namespace UI.ThreeDimensional.Examples
{
	public class ExampleController : MonoBehaviour
	{
		public Canvas Canvas;

		public List<GameObject> Examples;

		public GameObject WordSpaceText;

		public List<UIObject3D> gridItems;

		public void SelectExample(int number)
		{
		}

		public void SetCanvasMode(int mode)
		{
		}

		private void EnsureGridItemsCollectionIsPopulated()
		{
		}

		public void ToggleGridItemOutlines(bool toggle)
		{
		}

		public void ToggleGridItemRotation(bool toggle)
		{
		}

		public void ToggleImageColor(bool toggle)
		{
		}
	}
}
