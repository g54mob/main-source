using System.Collections.Generic;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class PartCollisionDetector
	{
		private HashSet<int> _selectedColliderIds;

		private List<PartColliderScript> _selectedColliderScripts;

		private List<IPartScript> _symmetricParts;

		private Collider[] _tempCollisionTestResults = new Collider[100];

		public static float PartCollisionTolerance { get; set; }

		public bool Enabled { get; set; }

		public List<IPartScript> SelectedParts { get; private set; }

		public PartCollisionDetector()
		{
			Enabled = true;
			SelectedParts = new List<IPartScript>();
			_symmetricParts = new List<IPartScript>();
			_selectedColliderIds = new HashSet<int>();
			_selectedColliderScripts = new List<PartColliderScript>();
		}

		public void AddPartSelection(IPartScript part)
		{
			SelectedParts.Add(part);
		}

		public void ClearPartSelection()
		{
			SelectedParts.Clear();
			_symmetricParts.Clear();
			_selectedColliderIds.Clear();
			_selectedColliderScripts.Clear();
		}

		public bool DetectCollisions(bool updateMaterials)
		{
			if (!Enabled)
			{
				return false;
			}
			_symmetricParts = new List<IPartScript>();
			foreach (IPartScript selectedPart in SelectedParts)
			{
				_symmetricParts.AddRange(Symmetry.GetSymmetricPartScripts(selectedPart));
			}
			bool flag = DetectCollisions(SelectedParts) || DetectCollisions(_symmetricParts);
			if (updateMaterials)
			{
				foreach (IPartScript selectedPart2 in SelectedParts)
				{
					selectedPart2.PartMaterialScript.IsCollidingInDesigner = flag;
				}
				foreach (IPartScript symmetricPart in _symmetricParts)
				{
					symmetricPart.PartMaterialScript.IsCollidingInDesigner = flag;
				}
			}
			return flag;
		}

		private bool DetectCollisions(List<IPartScript> parts)
		{
			_selectedColliderIds.Clear();
			_selectedColliderScripts.Clear();
			foreach (IPartScript part in parts)
			{
				if (part.Data.IsDestroyed)
				{
					continue;
				}
				foreach (PartColliderScript collider3 in part.Colliders)
				{
					_selectedColliderScripts.Add(collider3);
					_selectedColliderIds.Add(collider3.Collider.GetInstanceID());
				}
			}
			foreach (PartColliderScript selectedColliderScript in _selectedColliderScripts)
			{
				if (!selectedColliderScript.gameObject.activeInHierarchy || selectedColliderScript.IgnoreDesignerCollisions)
				{
					continue;
				}
				Collider collider = selectedColliderScript.Collider;
				Bounds bounds = collider.bounds;
				int mask = -2147475456;
				int num;
				do
				{
					num = Physics.OverlapBoxNonAlloc(bounds.center, bounds.extents, _tempCollisionTestResults, Quaternion.identity, mask, QueryTriggerInteraction.Ignore);
					if (num == _tempCollisionTestResults.Length)
					{
						_tempCollisionTestResults = new Collider[_tempCollisionTestResults.Length * 2];
						num = _tempCollisionTestResults.Length;
					}
				}
				while (num == _tempCollisionTestResults.Length);
				Transform transform = collider.transform;
				for (int i = 0; i < num; i++)
				{
					Collider collider2 = _tempCollisionTestResults[i];
					_tempCollisionTestResults[i] = null;
					if (_selectedColliderIds.Contains(collider2.GetInstanceID()))
					{
						continue;
					}
					PartColliderScript component = collider2.GetComponent<PartColliderScript>();
					if (component == null || component.IgnoreDesignerCollisions)
					{
						continue;
					}
					Transform transform2 = collider2.transform;
					if (Physics.ComputePenetration(collider, transform.position, transform.rotation, collider2, transform2.position, transform2.rotation, out var _, out var distance) && distance > PartCollisionTolerance)
					{
						for (int j = i + 1; j < num; j++)
						{
							_tempCollisionTestResults[j] = null;
						}
						return true;
					}
				}
			}
			_selectedColliderIds.Clear();
			_selectedColliderScripts.Clear();
			return false;
		}
	}
}
