using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public class SpringTransform
	{
		[field: NonSerialized]
		public SpringVector3 Position { get; private set; }

		[field: NonSerialized]
		public SpringQuaternion Rotation { get; private set; }

		[field: NonSerialized]
		public SpringVector3 Scale { get; private set; }

		public float Decay
		{
			get
			{
				return Position.Decay;
			}
			set
			{
				Position.Decay = value;
				Rotation.Decay = value;
				Scale.Decay = value;
			}
		}

		public SpringTransform(Vector3 position, Quaternion rotation, Vector3 scale, float decay = 0.25f)
		{
			Position = new SpringVector3(position, decay);
			Rotation = new SpringQuaternion(rotation, decay);
			Scale = new SpringVector3(scale, decay);
		}

		public SpringTransform(Transform transform, bool inLocalSpace = false, float decay = 0.25f)
		{
			if (inLocalSpace)
			{
				Position = new SpringVector3(transform.localPosition, decay);
				Rotation = new SpringQuaternion(transform.localRotation, decay);
				Scale = new SpringVector3(transform.localScale, decay);
			}
			else
			{
				Position = new SpringVector3(transform.position, decay);
				Rotation = new SpringQuaternion(transform.rotation, decay);
				Scale = new SpringVector3(transform.lossyScale, decay);
			}
		}

		public void Update(float deltaTime)
		{
			Position.Update(deltaTime);
			Rotation.Update(deltaTime);
			Scale.Update(deltaTime);
		}

		public void Update(float decay, float deltaTime)
		{
			Position.Update(decay, deltaTime);
			Rotation.Update(decay, deltaTime);
			Scale.Update(decay, deltaTime);
		}

		public void Update(Vector3 position, Quaternion rotation, float decay, float deltaTime)
		{
			Position.Update(position, decay, deltaTime);
			Rotation.Update(rotation, decay, deltaTime);
			Scale.Update(decay, deltaTime);
		}
	}
}
