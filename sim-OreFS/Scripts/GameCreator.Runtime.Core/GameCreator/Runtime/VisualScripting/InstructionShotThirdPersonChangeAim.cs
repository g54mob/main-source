using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Cameras;
using GameCreator.Runtime.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Change Aim")]
	[Category("Cameras/Shots/Third Person/Change Aim")]
	[Description("Changes the aim settings of a Shot keeping the focus point")]
	[Parameter("Shoulder", "The horizontal distance from the pivot")]
	[Parameter("Lift", "The amount of upwards distance from the pivot")]
	[Parameter("Radius", "The maximum amount of distance from the pivot allowed")]
	[Parameter("Keep Center", "If true the point at the center of the screen is kept when aiming")]
	[Parameter("Layer Mask", "The layer mask for the hit-scan to check the focus point")]
	public class InstructionShotThirdPersonChangeAim : TInstructionShotThirdPerson
	{
		private const float BIG_F_NUMBER = 999f;

		private static readonly RaycastHit[] HITS = new RaycastHit[32];

		[SerializeField]
		[FormerlySerializedAs("m_Shoulder")]
		private PropertyGetDecimal m_OffsetShoulder = GetDecimalDecimal.Create(0.25f);

		[SerializeField]
		[FormerlySerializedAs("m_Lift")]
		private PropertyGetDecimal m_OffsetLift = GetDecimalDecimal.Create(0.5f);

		[SerializeField]
		[FormerlySerializedAs("m_Radius")]
		private PropertyGetDecimal m_OffsetRadius = GetDecimalDecimal.Create(5f);

		[SerializeField]
		private EnablerLayerMask m_KeepCenter = new EnablerLayerMask(isEnabled: true);

		[SerializeField]
		private PropertyGetDecimal m_Duration = GetDecimalDecimal.Create(0.25f);

		public override string Title => $"Change {m_Shot}[Third Person] Aim";

		protected override Task Run(Args args)
		{
			ShotSystemThirdPerson shotSystem = GetShotSystem<ShotSystemThirdPerson>(args);
			if (shotSystem == null)
			{
				return Instruction.DefaultResult;
			}
			Transform transform = ShortcutMainCamera.Transform;
			if (transform == null)
			{
				return Instruction.DefaultResult;
			}
			float val = (float)m_Duration.Get(args);
			if (!m_KeepCenter.IsEnabled)
			{
				shotSystem.Aim((float)m_OffsetShoulder.Get(args), (float)m_OffsetLift.Get(args), (float)m_OffsetRadius.Get(args), Math.Max(val, 0f));
				return Instruction.DefaultResult;
			}
			Transform transform2 = ((shotSystem.Pivot != null) ? shotSystem.Pivot.transform : null);
			if (transform2 == null)
			{
				return Instruction.DefaultResult;
			}
			Vector3 vector = transform.TransformDirection(Vector3.forward);
			int num = Physics.RaycastNonAlloc(transform.position, vector, HITS, 999f, m_KeepCenter.Value, QueryTriggerInteraction.Ignore);
			bool flag = false;
			float num2 = -1f;
			Vector3 vector2 = Vector3.zero;
			for (int i = 0; i < num; i++)
			{
				RaycastHit raycastHit = HITS[i];
				if (!raycastHit.transform.IsChildOf(transform2) && (!(num2 >= 0f) || !(raycastHit.distance > num2)))
				{
					flag = true;
					vector2 = raycastHit.point;
					num2 = raycastHit.distance;
				}
			}
			Vector3 focus = (flag ? vector2 : (vector * 999f));
			shotSystem.Aim((float)m_OffsetShoulder.Get(args), (float)m_OffsetLift.Get(args), (float)m_OffsetRadius.Get(args), focus, Math.Max(val, 0f));
			return Instruction.DefaultResult;
		}
	}
}
