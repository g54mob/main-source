using System;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	[Serializable]
	public struct IntersectionDataType
	{
		[SerializeField]
		private IntersectionType _type;

		[SerializeField]
		private int _index;

		[SerializeField]
		private string _name;

		public readonly IntersectionType Type => default(IntersectionType);

		public readonly int OtherListIndex => 0;

		public IntersectionDataType(IntersectionType type, int index, string name)
		{
			_type = default(IntersectionType);
			_index = 0;
			_name = null;
		}
	}
}
