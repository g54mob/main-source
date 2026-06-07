using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class PartCollisionDetector
	{
		private HashSet<int> _selectedColliderIds;

		private List<PartColliderScript> _selectedColliderScripts;

		private List<PartScript> _symmetricParts;

		private Collider[] _tempCollisionTestResults = new Collider[100];

		public static float PartCollisionTolerance { get; set; }

		public bool Enabled { get; set; }

		public List<PartScript> SelectedParts { get; private set; }

		public PartCollisionDetector()
		{
			Enabled = true;
			SelectedParts = new List<PartScript>();
			_symmetricParts = new List<PartScript>();
			_selectedColliderIds = new HashSet<int>();
			_selectedColliderScripts = new List<PartColliderScript>();
		}

		public void AddPartSelection(PartScript part)
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
			return false;
		}

		private bool DetectCollisions(List<PartScript> parts)
		{
			return false;
		}
	}
}
