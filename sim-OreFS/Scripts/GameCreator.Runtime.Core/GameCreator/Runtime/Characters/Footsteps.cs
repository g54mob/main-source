using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	public class Footsteps : TPolymorphicList<Footstep>
	{
		private const float RAYCAST_DISTANCE_PERCENTAGE = 0.25f;

		private const int RAYCAST_BUFFER_SIZE = 5;

		private static readonly Color COLOR_GIZMO_GROUND_OFF = new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 0.25f);

		private static readonly Color COLOR_GIZMO_GROUND_ON = new Color(Color.green.r, Color.green.g, Color.green.b, 0.5f);

		[SerializeReference]
		private Footstep[] m_Feet = new Footstep[2]
		{
			new Footstep(HumanBodyBones.LeftFoot),
			new Footstep(HumanBodyBones.RightFoot)
		};

		[SerializeField]
		private MaterialSounds m_FootstepSounds = new MaterialSounds();

		[SerializeReference]
		private FootstepDetectorBase m_FootstepDetector = new FootstepDetectorAnimationCurves();

		[NonSerialized]
		private bool m_IsActive;

		[NonSerialized]
		private Character m_Character;

		[NonSerialized]
		private readonly RaycastHit[] m_HitsBuffer = new RaycastHit[5];

		public override int Length => m_Feet.Length;

		public IReadOnlyList<Footstep> Feet => m_Feet;

		public GameObject LastFootstep { get; private set; }

		public bool IsActive
		{
			get
			{
				return m_IsActive;
			}
			set
			{
				m_IsActive = value;
			}
		}

		public event Action<Transform> EventStep;

		internal void OnStartup(Character character)
		{
			m_Character = character;
			m_FootstepSounds.OnStartup();
			m_IsActive = true;
		}

		internal void AfterStartup(Character character)
		{
		}

		internal void OnDispose(Character character)
		{
			m_Character = character;
		}

		internal void OnEnable()
		{
			m_FootstepDetector?.OnEnable(m_Character);
		}

		internal void OnDisable()
		{
			m_FootstepDetector?.OnDisable(m_Character);
		}

		internal void OnUpdate()
		{
			m_FootstepDetector?.OnUpdate(m_Character);
		}

		public void ChangeFootstepSounds(MaterialSoundsAsset materialSoundsAsset)
		{
			m_FootstepSounds.ChangeSoundsAsset(materialSoundsAsset);
		}

		public void PlayFootstepSound(MaterialSoundsAsset materialSoundsAsset)
		{
			if (!(materialSoundsAsset == null))
			{
				RaycastHit groundHit = GetGroundHit(m_Character.Feet);
				if (!(groundHit.collider == null))
				{
					MaterialSounds.Play(new Args(m_Character.gameObject, groundHit.collider.gameObject), yaw: m_Character.transform.localRotation.eulerAngles.y, point: groundHit.point, normal: groundHit.normal, hit: groundHit.collider.gameObject, materialSounds: materialSoundsAsset);
				}
			}
		}

		public void OnStep(Transform bone)
		{
			if (m_IsActive)
			{
				LastFootstep = bone.gameObject;
				this.EventStep?.Invoke(bone);
				RaycastHit groundHit = GetGroundHit(bone.position);
				if (!(groundHit.collider == null))
				{
					float speed = Mathf.Clamp01((m_Character.Motion.LinearSpeed > 0f) ? (m_Character.Driver.WorldMoveDirection.magnitude / m_Character.Motion.LinearSpeed) : 0f);
					Args args = new Args(m_Character.gameObject, groundHit.collider.gameObject);
					float y = m_Character.transform.localRotation.eulerAngles.y;
					m_FootstepSounds.Play(bone, groundHit, speed, args, y);
				}
			}
		}

		private RaycastHit GetGroundHit(Vector3 position)
		{
			int num = Physics.RaycastNonAlloc(position, -m_Character.transform.up, m_HitsBuffer, m_Character.Motion.Height * 0.25f, m_FootstepSounds.LayerMask, QueryTriggerInteraction.Ignore);
			RaycastHit result = default(RaycastHit);
			float num2 = float.PositiveInfinity;
			for (int i = 0; i < num; i++)
			{
				float num3 = Vector3.Distance(m_HitsBuffer[i].transform.position, position);
				if (!(num3 > num2))
				{
					result = m_HitsBuffer[i];
					num2 = num3;
				}
			}
			return result;
		}

		internal void OnDrawGizmos(Character character)
		{
			Gizmos.color = Color.blue;
			m_FootstepDetector?.OnGizmos(character);
			if (!Application.isPlaying || !m_Character.Driver.IsGrounded)
			{
				return;
			}
			Animator animator = m_Character.Animim.Animator;
			if (animator == null)
			{
				return;
			}
			float radius = m_Character.Motion.Radius;
			for (int i = 0; i < m_Feet.Length && i < Phases.Count; i++)
			{
				Transform transform = m_Feet[i].Bone.GetTransform(animator);
				if (!(transform == null))
				{
					Gizmos.color = (m_Character.Phases.IsGround(i) ? COLOR_GIZMO_GROUND_ON : COLOR_GIZMO_GROUND_OFF);
					Vector3 position = transform.transform.position;
					position.y = m_Character.Feet.y;
					GizmosExtension.Circle(position, radius);
					GizmosExtension.Circle(position, radius);
				}
			}
		}
	}
}
