using System;
using Unity.Mathematics;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public class SpringPose
	{
		[field: NonSerialized]
		public SpringVector3 Position { get; }

		[field: NonSerialized]
		public SpringQuaternion Rotation { get; }

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
			}
		}

		public SpringPose(float decay = 0.25f)
			: this(Vector3.zero, quaternion.identity, decay)
		{
		}

		public SpringPose(Vector3 position, Quaternion rotation, float decay = 0.25f)
		{
			Position = new SpringVector3(position, decay);
			Rotation = new SpringQuaternion(rotation, decay);
		}

		public void Update(float deltaTime)
		{
			Position.Update(deltaTime);
			Rotation.Update(deltaTime);
		}

		public void Update(float decay, float deltaTime)
		{
			Position.Update(decay, deltaTime);
			Rotation.Update(decay, deltaTime);
		}

		public void Update(Vector3 position, Quaternion rotation, float decay, float deltaTime)
		{
			Position.Update(position, decay, deltaTime);
			Rotation.Update(rotation, decay, deltaTime);
		}
	}
}
