using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters.IK
{
	[Serializable]
	[Title("Look at Targets")]
	[Category("Look at Targets")]
	[Image(typeof(IconEye), ColorTheme.Type.Green)]
	[Description("IK system that allows the Character to naturally look at points of interest using the whole upper-body chain of bones. Requires a humanoid character")]
	public class RigLookTo : TRigAnimatorIK
	{
		private class LookTargets : List<ILookTo>
		{
			public ILookTo Get(Vector3 target)
			{
				float num = float.PositiveInfinity;
				ILookTo result = null;
				using Enumerator enumerator = GetEnumerator();
				while (enumerator.MoveNext())
				{
					ILookTo current = enumerator.Current;
					if (current != null && current.Exists)
					{
						float num2 = Vector3.Distance(target, current.Position);
						if (!(num2 >= num))
						{
							result = current;
							num = num2;
						}
					}
				}
				return result;
			}
		}

		private class LookLayers : SortedDictionary<int, LookTargets>
		{
		}

		public const string RIG_NAME = "RigLookTo";

		private const float SMOOTH_TIME = 0.15f;

		private const float HORIZON = 10f;

		[SerializeField]
		private float m_TrackSpeed = 270f;

		[SerializeField]
		private float m_MaxAngle = 90f;

		[SerializeField]
		private LookSection[] m_Sections = new LookSection[3]
		{
			new LookSection(HumanBodyBones.Chest, 1f),
			new LookSection(HumanBodyBones.Neck, 2f),
			new LookSection(HumanBodyBones.Head, 3f)
		};

		[NonSerialized]
		private AnimFloat m_WeightTarget = new AnimFloat(0f, 0.15f);

		[NonSerialized]
		private Transform m_LookHandle;

		[NonSerialized]
		private Transform m_LookPoint;

		[NonSerialized]
		private ILookTo m_LookToTarget;

		[NonSerialized]
		private readonly LookLayers m_Layers = new LookLayers();

		[NonSerialized]
		private LookSection m_Head = new LookSection(HumanBodyBones.Head, 1f);

		public override string Title => "Look at Target";

		public override string Name => "RigLookTo";

		public override bool RequiresHuman => true;

		public override bool DisableOnBusy => true;

		public ILookTo LookToTarget => m_LookToTarget;

		public void SetTarget<T>(T look) where T : ILookTo
		{
			if (look != null)
			{
				if (!m_Layers.ContainsKey(look.Layer))
				{
					m_Layers[look.Layer] = new LookTargets();
				}
				if (!m_Layers[look.Layer].Contains(look))
				{
					m_Layers[look.Layer].Add(look);
				}
			}
		}

		public void RemoveTarget<T>(T look) where T : ILookTo
		{
			if (look != null && m_Layers.TryGetValue(look.Layer, out var value))
			{
				value.Remove(look);
			}
		}

		public void ClearTargets()
		{
			foreach (KeyValuePair<int, LookTargets> layer in m_Layers)
			{
				if (layer.Key != 0)
				{
					layer.Value.Clear();
				}
			}
		}

		protected override void DoEnable(Character character)
		{
			base.DoEnable(character);
			Initialize();
			base.Character.EventBeforeLateUpdate -= OnLateUpdate;
			base.Character.EventBeforeLateUpdate += OnLateUpdate;
		}

		protected override void DoDisable(Character character)
		{
			base.DoDisable(character);
			base.Character.EventBeforeLateUpdate -= OnLateUpdate;
		}

		protected override void DoUpdate(Character character)
		{
			base.DoUpdate(character);
			m_LookToTarget = GetLookTrackTarget(character);
			m_LookHandle.position = character.Eyes;
			ILookTo lookToTarget = m_LookToTarget;
			Vector3 vector;
			if (lookToTarget != null && lookToTarget.Exists)
			{
				m_WeightTarget.Target = 1f;
				Vector3 position = m_LookToTarget.Position;
				Vector3 forward = character.transform.forward;
				vector = position - character.Eyes;
				float num = Vector3.Angle(forward, vector);
				float num2 = Vector2.Distance(character.transform.position.XZ(), position.XZ());
				if (num > m_MaxAngle || num2 < character.Motion.Radius)
				{
					m_WeightTarget.Target = 0f;
					vector = character.transform.forward;
				}
			}
			else
			{
				m_WeightTarget.Target = 0f;
				vector = character.transform.forward;
			}
			m_WeightTarget.UpdateWithDelta(m_WeightTarget.Target, base.Character.Time.DeltaTime);
			m_LookHandle.rotation = Quaternion.RotateTowards(m_LookHandle.rotation, Quaternion.LookRotation(vector, Vector3.up), character.Time.DeltaTime * m_TrackSpeed);
		}

		private void OnLateUpdate()
		{
			Vector3 direction = m_LookPoint.position - m_LookHandle.position;
			Vector3 normalized = base.Character.transform.InverseTransformDirection(direction).normalized;
			float num = Mathf.Atan2(normalized.x, normalized.z) * 57.29578f;
			float num2 = Mathf.Asin(0f - normalized.y) * 57.29578f;
			m_Head.Transform.Rotate(base.Character.transform.right, num2 * m_WeightTarget.Current, Space.World);
			float num3 = 0f;
			LookSection[] sections = m_Sections;
			foreach (LookSection lookSection in sections)
			{
				if (lookSection.IsValid)
				{
					lookSection.Transform.localRotation *= lookSection.Rotation;
					num3 += lookSection.Weight;
				}
			}
			if (num3 <= float.Epsilon)
			{
				return;
			}
			sections = m_Sections;
			foreach (LookSection lookSection2 in sections)
			{
				if (lookSection2.IsValid)
				{
					float num4 = lookSection2.Weight / num3;
					lookSection2.Transform.Rotate(Vector3.up, num * (m_WeightTarget.Current * num4), Space.World);
				}
			}
		}

		protected override void DoChangeModel()
		{
			base.DoChangeModel();
			Initialize();
		}

		private bool GetBone(HumanBodyBones boneType, out Transform bone)
		{
			bone = base.Animator.GetBoneTransform(boneType);
			return bone != null;
		}

		private ILookTo GetLookTrackTarget(Character character)
		{
			foreach (KeyValuePair<int, LookTargets> layer in m_Layers)
			{
				ILookTo lookTo = layer.Value.Get(character.Eyes);
				if (lookTo != null && lookTo.Exists)
				{
					return lookTo;
				}
			}
			return null;
		}

		private void Initialize()
		{
			if (m_LookHandle == null || m_LookPoint == null)
			{
				if (m_LookHandle != null)
				{
					UnityEngine.Object.Destroy(m_LookHandle.gameObject);
				}
				if (m_LookPoint != null)
				{
					UnityEngine.Object.Destroy(m_LookPoint.gameObject);
				}
				GameObject gameObject = new GameObject("RigLookToHandle");
				GameObject gameObject2 = new GameObject("RigLookToPoint");
				gameObject.hideFlags = HideFlags.HideAndDontSave;
				gameObject2.hideFlags = HideFlags.HideAndDontSave;
				m_LookHandle = gameObject.transform;
				m_LookHandle.position = base.Character.Eyes;
				m_LookPoint = gameObject2.transform;
				m_LookPoint.SetParent(m_LookHandle);
				m_LookPoint.localPosition = Vector3.forward * 10f;
			}
			LookSection[] sections = m_Sections;
			foreach (LookSection lookSection in sections)
			{
				if (GetBone(lookSection.Bone, out var bone))
				{
					lookSection.Transform = bone;
				}
			}
			if (GetBone(m_Head.Bone, out var bone2))
			{
				m_Head.Transform = bone2;
			}
		}

		protected override void DoDrawGizmos(Character character)
		{
			base.DoDrawGizmos(character);
			Gizmos.color = Color.cyan;
			if (!(m_LookPoint == null))
			{
				Gizmos.DrawWireCube(m_LookPoint.position, Vector3.one * 0.1f);
				Gizmos.DrawLine(base.Character.Eyes, m_LookPoint.position);
			}
		}
	}
}
