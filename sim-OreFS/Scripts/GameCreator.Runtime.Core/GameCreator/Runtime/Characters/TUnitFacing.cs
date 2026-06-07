using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Rotation")]
	public abstract class TUnitFacing : TUnit, IUnitFacing, IUnitCommon
	{
		private const float MAX_ANGLE_ERROR = 1f;

		private const float EPSILON_SPEED = 0.1f;

		[NonSerialized]
		protected Vector3 m_FaceDirection;

		[NonSerialized]
		protected float m_PivotSpeed;

		[NonSerialized]
		private Quaternion m_RotationVelocity = Quaternion.identity;

		[NonSerialized]
		private Dictionary<int, FacingLayer> m_LayersData;

		[NonSerialized]
		private List<int> m_LayersQueue;

		public Vector3 WorldFaceDirection => base.Transform.TransformDirection(Vector3.forward);

		public Vector3 LocalFaceDirection => Vector3.forward;

		public Vector3 WorldTargetFaceDirection => m_FaceDirection;

		public Vector3 LocalTargetFaceDirection => base.Transform.InverseTransformDirection(m_FaceDirection);

		public float PivotSpeed => m_PivotSpeed;

		public abstract Axonometry Axonometry { get; set; }

		public virtual void OnStartup(Character character)
		{
			base.Character = character;
			m_FaceDirection = character.transform.TransformDirection(Vector3.forward);
			m_PivotSpeed = 0f;
			m_LayersData = new Dictionary<int, FacingLayer>();
			m_LayersQueue = new List<int>();
		}

		public virtual void AfterStartup(Character character)
		{
			base.Character = character;
		}

		public virtual void OnDispose(Character character)
		{
			base.Character = character;
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void OnUpdate()
		{
			if (base.Character.IsDead)
			{
				return;
			}
			for (int num = m_LayersQueue.Count - 1; num >= 0; num--)
			{
				int key = m_LayersQueue[num];
				bool flag = true;
				if (m_LayersData.TryGetValue(key, out var value))
				{
					flag = value.Update(base.Character);
				}
				if (flag)
				{
					m_LayersData.Remove(key);
					m_LayersQueue.RemoveAt(num);
				}
			}
			if (m_LayersQueue.Count > 0)
			{
				int key2 = m_LayersQueue[0];
				m_FaceDirection = m_LayersData[key2].Direction;
			}
			else
			{
				m_FaceDirection = GetDefaultDirection();
			}
			Quaternion quaternion = Quaternion.LookRotation(m_FaceDirection);
			Quaternion rotation = base.Transform.rotation;
			Quaternion quaternion2 = Quaternion.Euler(0f, quaternion.eulerAngles.y, 0f);
			Quaternion a = ((base.Character.Motion.AngularSpeed >= 0f) ? QuaternionUtils.SmoothDamp(rotation, quaternion2, ref m_RotationVelocity, 1f / (base.Character.Motion.AngularSpeed / 360f), base.Character.Time.DeltaTime) : quaternion2);
			m_PivotSpeed = Vector3.SignedAngle(rotation * Vector3.forward, quaternion2 * Vector3.forward, Vector3.up);
			base.Transform.rotation = Quaternion.Lerp(a, rotation * base.Character.Animim.RootMotionDeltaRotation, base.Character.RootMotionRotation);
		}

		public virtual void OnFixedUpdate()
		{
		}

		protected abstract Vector3 GetDefaultDirection();

		protected Vector3 DecideDirection(Vector3 driverDirection)
		{
			Vector3 result = base.Transform.TransformDirection(Vector3.forward);
			if (!(driverDirection.magnitude > 0.1f))
			{
				return result;
			}
			return driverDirection;
		}

		public virtual void OnDrawGizmos(Character character)
		{
		}

		private int CreateLayer(bool autoDestroyOnReach)
		{
			int num = IntegerCounter.Generate();
			m_LayersQueue.Add(num);
			m_LayersData.Add(num, new FacingLayer(base.Character, autoDestroyOnReach));
			return num;
		}

		private int CreateLayer(float autoDestroyOnTimeout)
		{
			int num = IntegerCounter.Generate();
			m_LayersQueue.Add(num);
			m_LayersData.Add(num, new FacingLayer(base.Character, autoDestroyOnTimeout));
			return num;
		}

		public void DeleteLayer(int key)
		{
			m_LayersData.Remove(key);
			m_LayersQueue.Remove(key);
		}

		public int SetLayerDirection(int key, Vector3 direction, bool autoDestroyOnReach)
		{
			if (m_LayersData.TryGetValue(key, out var value))
			{
				value.SetDirection(direction);
			}
			else
			{
				float num = Vector3.Angle(direction, WorldFaceDirection);
				if (!autoDestroyOnReach || num > 1f)
				{
					key = CreateLayer(autoDestroyOnReach);
					m_LayersData[key].SetDirection(direction);
				}
			}
			return key;
		}

		public int SetLayerDirection(int key, Vector3 direction, float autoDestroyOnTimeout)
		{
			if (m_LayersData.TryGetValue(key, out var value))
			{
				value.SetDirection(direction);
			}
			else
			{
				key = CreateLayer(autoDestroyOnTimeout);
				m_LayersData[key].SetDirection(direction);
			}
			return key;
		}

		public int SetLayerTarget(int key, Transform target)
		{
			if (m_LayersData.TryGetValue(key, out var value))
			{
				value.SetTarget(target);
			}
			else
			{
				key = CreateLayer(autoDestroyOnReach: false);
				m_LayersData[key].SetTarget(target);
			}
			return key;
		}
	}
}
