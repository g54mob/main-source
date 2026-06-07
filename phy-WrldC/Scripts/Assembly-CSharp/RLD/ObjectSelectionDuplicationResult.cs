using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class ObjectSelectionDuplicationResult
	{
		private List<GameObject> _duplicateParents;

		public List<GameObject> DuplicateParents => new List<GameObject>(_duplicateParents);

		public int NumDuplicateParents => _duplicateParents.Count;

		public ObjectSelectionDuplicationResult(List<GameObject> duplicatedParents)
		{
			_duplicateParents = new List<GameObject>(duplicatedParents);
		}

		public GameObject GetParentByIndex(int index)
		{
			return _duplicateParents[index];
		}
	}
}
