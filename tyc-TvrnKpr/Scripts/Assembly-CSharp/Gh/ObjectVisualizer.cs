using System;
using System.Collections.Generic;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	[Serializable]
	public class ObjectVisualizer : BaseStateVisualizer3D
	{
		public List<GameObject> enabledStateObjects;

		public List<GameObject> disabledStateObjects;

		public List<GameObject> pressedStateObjects;

		public List<GameObject> hoveredStateObjects;

		public List<GameObject> unselectedStateObjects;

		public List<GameObject> selectedStateObjects;

		private List<GameObject> _allObjects;

		private List<GameObject> GetAllObjects()
		{
			return null;
		}

		private void SetEnabled(IEnumerable<GameObject> objs)
		{
		}

		public override void VisualizeState(BaseInteractable3DUIView view)
		{
		}

		public override void CleanUp()
		{
		}
	}
}
