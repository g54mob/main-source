using System;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("First Person")]
	[Category("First Person")]
	[Image(typeof(IconShotFirstPerson), ColorTheme.Type.Blue)]
	[Description("Moves with the head of a Character")]
	public class ShotTypeFirstPerson : TShotType
	{
		private static readonly Transform[] EMPTY = Array.Empty<Transform>();

		[SerializeField]
		private ShotSystemFirstPerson m_FirstPerson;

		[SerializeField]
		private ShotSystemHeadBobbing m_HeadBobbing;

		[SerializeField]
		private ShotSystemHeadLeaning m_HeadLeaning;

		[SerializeField]
		private ShotSystemNoise m_Noise;

		public override Args Args
		{
			get
			{
				if (m_Args == null)
				{
					m_Args = new Args(m_ShotCamera, null);
				}
				m_Args.ChangeTarget(m_FirstPerson.GetTarget(this));
				return m_Args;
			}
		}

		public override Transform[] Ignore => EMPTY;

		public override bool UseSmoothPosition => false;

		public override bool UseSmoothRotation => false;

		public override bool HasTarget => false;

		public override Vector3 Target => m_Transform.position;

		public Character Character => m_FirstPerson.GetTarget(this);

		public ShotTypeFirstPerson()
		{
			m_FirstPerson = new ShotSystemFirstPerson();
			m_HeadBobbing = new ShotSystemHeadBobbing();
			m_HeadLeaning = new ShotSystemHeadLeaning();
			m_Noise = new ShotSystemNoise();
			m_ShotSystems.Add(m_FirstPerson.Id, m_FirstPerson);
			m_ShotSystems.Add(m_HeadBobbing.Id, m_HeadBobbing);
			m_ShotSystems.Add(m_HeadLeaning.Id, m_HeadLeaning);
			m_ShotSystems.Add(m_Noise.Id, m_Noise);
		}

		public void AddRotation(float pitch, float yaw)
		{
			m_FirstPerson.Pitch += pitch;
			m_FirstPerson.Yaw += yaw;
		}

		protected override void OnBeforeAwake(ShotCamera shotCamera)
		{
			base.OnBeforeAwake(shotCamera);
			m_FirstPerson?.OnAwake(this);
			m_HeadBobbing?.OnAwake(this);
			m_HeadLeaning?.OnAwake(this);
			m_Noise?.OnAwake(this);
		}

		protected override void OnBeforeStart(ShotCamera shotCamera)
		{
			base.OnBeforeStart(shotCamera);
			m_FirstPerson?.OnStart(this);
			m_HeadBobbing?.OnStart(this);
			m_HeadLeaning?.OnStart(this);
			m_Noise?.OnStart(this);
		}

		protected override void OnBeforeDestroy(ShotCamera shotCamera)
		{
			base.OnBeforeDestroy(shotCamera);
			m_FirstPerson?.OnDestroy(this);
			m_HeadBobbing?.OnDestroy(this);
			m_HeadLeaning?.OnDestroy(this);
			m_Noise?.OnDestroy(this);
		}

		protected override void OnBeforeEnable(TCamera camera)
		{
			base.OnBeforeEnable(camera);
			m_FirstPerson?.OnEnable(this, camera);
			m_HeadBobbing?.OnEnable(this, camera);
			m_HeadLeaning?.OnEnable(this, camera);
			m_Noise?.OnEnable(this, camera);
		}

		protected override void OnBeforeDisable(TCamera camera)
		{
			base.OnBeforeDisable(camera);
			m_FirstPerson?.OnDisable(this, camera);
			m_HeadBobbing?.OnDisable(this, camera);
			m_HeadLeaning?.OnDisable(this, camera);
			m_Noise?.OnDisable(this, camera);
		}

		protected override void OnBeforeUpdate()
		{
			base.OnBeforeUpdate();
			m_Recoil.Update(out var pitch, out var yaw);
			AddRotation(pitch, yaw);
			m_FirstPerson?.OnUpdate(this);
			m_HeadBobbing?.OnUpdate(this);
			m_HeadLeaning?.OnUpdate(this);
			m_Noise?.OnUpdate(this);
		}
	}
}
