using UnityEngine;

namespace Jobberwocky.GeometryAlgorithms.Source.Core
{
	public class Vertex
	{
		private int _003CId_003Ek__BackingField;

		private int _003CIndex_003Ek__BackingField;

		private Vector3 _003CPosition_003Ek__BackingField;

		public int Id
		{
			get
			{
				return _003CId_003Ek__BackingField;
			}
			set
			{
				_003CId_003Ek__BackingField = value;
			}
		}

		public int Index
		{
			get
			{
				return _003CIndex_003Ek__BackingField;
			}
			set
			{
				_003CIndex_003Ek__BackingField = value;
			}
		}

		public Vector3 Position
		{
			get
			{
				return _003CPosition_003Ek__BackingField;
			}
			set
			{
				_003CPosition_003Ek__BackingField = value;
			}
		}

		public Vertex(double x, double y, double z, int id)
			: this(x, y, z)
		{
			Id = id;
		}

		public Vertex(Vector3 vector, int id)
			: this(vector)
		{
			Id = id;
		}

		public Vertex(double x, double y, double z)
			: this(new Vector3((float)x, (float)y, (float)z))
		{
		}

		public Vertex(Vector3 vector)
		{
			Position = vector;
			Index = -1;
		}

		public bool Equals(Vertex v)
		{
			return Id == v.Id;
		}
	}
}
