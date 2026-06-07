using UnityEngine;

namespace EZhex1991.EZSoftBone
{
	public class EZSoftBoneForceField : MonoBehaviour
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float m_Conductivity = 0.15f;

		[SerializeField]
		[EZNestedEditor]
		private EZSoftBoneForce m_Force;

		public float conductivity
		{
			get
			{
				return m_Conductivity;
			}
			set
			{
				m_Conductivity = value;
			}
		}

		public EZSoftBoneForce force
		{
			get
			{
				return m_Force;
			}
			set
			{
				m_Force = value;
			}
		}

		public float time { get; set; }

		private void OnEnable()
		{
			time = 0f;
		}

		private void Update()
		{
			time += Time.deltaTime;
		}

		public Vector3 GetForce(float normalizedLength)
		{
			return base.transform.TransformDirection(force.GetForce(time - conductivity * normalizedLength));
		}
	}
}
