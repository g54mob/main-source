using System;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	[Serializable]
	public class Waypoint
	{
		[SerializeField]
		private int[] _neighbors;

		[SerializeField]
		private int[] _prev;

		[SerializeField]
		private Vector3 _position;

		[SerializeField]
		private string _name;

		[SerializeField]
		private int _listIndex;

		[SerializeField]
		private bool _temporaryDisabled;

		public int[] Neighbors => null;

		public int[] Prev => null;

		public Vector3 Position => default(Vector3);

		public string Name => null;

		public int ListIndex => 0;

		public bool TemporaryDisabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Waypoint(string name, int listIndex, Vector3 position, int[] neighbors, int[] prev)
		{
		}
	}
}
