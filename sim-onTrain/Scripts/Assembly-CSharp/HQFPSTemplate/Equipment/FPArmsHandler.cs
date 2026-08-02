using UnityEngine;

namespace HQFPSTemplate.Equipment
{
	public class FPArmsHandler : MonoBehaviour
	{
		[SerializeField]
		private Animator m_Animator;

		[SerializeField]
		private EquipmentHandler m_EquipmentHandler;

		[Space]
		[SerializeField]
		private string m_FovProperty = "_FOV";

		[SerializeField]
		private SkinnedMeshRenderer m_LeftArm;

		[SerializeField]
		private SkinnedMeshRenderer m_RightArm;

		[Space]
		[SerializeField]
		[Reorderable]
		private FPArmsInfoList m_FPArms;

		public Animator Animator => m_Animator;

		public void UpdateArms(ref int selectedArmsIndex)
		{
			FPArmsInfo fPArmsInfo = m_FPArms.ToArray().Select(ref selectedArmsIndex, ItemSelection.Method.Sequence);
			m_LeftArm.sharedMesh = fPArmsInfo.LeftArm.sharedMesh;
			m_LeftArm.sharedMaterials = fPArmsInfo.LeftArm.sharedMaterials;
			m_RightArm.sharedMesh = fPArmsInfo.RightArm.sharedMesh;
			m_RightArm.sharedMaterials = fPArmsInfo.RightArm.sharedMaterials;
		}

		private void Awake()
		{
			m_EquipmentHandler.OnChangeItem.AddListener(UpdateFOV);
		}

		private void OnDestroy()
		{
			m_EquipmentHandler.OnChangeItem.RemoveListener(UpdateFOV);
		}

		private void UpdateFOV()
		{
			float targetFOV = m_EquipmentHandler.EquipmentItem.EModel.TargetFOV;
			Material[] sharedMaterials = m_LeftArm.sharedMaterials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				sharedMaterials[i].SetFloat(m_FovProperty, targetFOV);
			}
			sharedMaterials = m_RightArm.sharedMaterials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				sharedMaterials[i].SetFloat(m_FovProperty, targetFOV);
			}
		}
	}
}
