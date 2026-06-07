using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public class SpringVector3
	{
		[field: NonSerialized]
		private SpringFloat X { get; set; }

		[field: NonSerialized]
		private SpringFloat Y { get; set; }

		[field: NonSerialized]
		private SpringFloat Z { get; set; }

		public Vector3 Current
		{
			get
			{
				return new Vector3(X.Current, Y.Current, Z.Current);
			}
			set
			{
				X.Current = value.x;
				Y.Current = value.y;
				Z.Current = value.z;
			}
		}

		public Vector3 Target
		{
			get
			{
				return new Vector3(X.Target, Y.Target, Z.Target);
			}
			set
			{
				X.Target = value.x;
				Y.Target = value.y;
				Z.Target = value.z;
			}
		}

		public float Decay
		{
			get
			{
				return X.Decay;
			}
			set
			{
				X.Decay = value;
				Y.Decay = value;
				Z.Decay = value;
			}
		}

		public SpringVector3(float decay = 0.25f)
			: this(Vector3.zero, decay)
		{
		}

		public SpringVector3(Vector3 value, float decay = 0.25f)
		{
			X = new SpringFloat(value.x, decay);
			Y = new SpringFloat(value.y, decay);
			Z = new SpringFloat(value.z, decay);
		}

		public void Update(float deltaTime)
		{
			X.Update(deltaTime);
			Y.Update(deltaTime);
			Z.Update(deltaTime);
		}

		public void Update(float decay, float deltaTime)
		{
			Decay = decay;
			Update(deltaTime);
		}

		public void Update(Vector3 target, float decay, float deltaTime)
		{
			Target = target;
			Update(decay, deltaTime);
		}
	}
}
