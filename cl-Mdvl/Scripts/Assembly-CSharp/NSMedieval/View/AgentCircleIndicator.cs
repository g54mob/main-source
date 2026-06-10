using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval.View
{
	public class AgentCircleIndicator : MonoBehaviour
	{
		[SerializeField]
		private List<MeshRenderer> meshes;

		public void SetCoverAngle(float coverAngle)
		{
			foreach (MeshRenderer mesh in meshes)
			{
				MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(mesh);
				materialPropertyBlock.SetFloat("_CoverAngle", coverAngle);
				mesh.SetPropertyBlock(materialPropertyBlock);
			}
		}

		public void SetHoldGroundVisual(bool isOn)
		{
			foreach (MeshRenderer mesh in meshes)
			{
				MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(mesh);
				materialPropertyBlock.SetFloat("_HoldGroundToggle", isOn ? 1 : 0);
				mesh.SetPropertyBlock(materialPropertyBlock);
			}
		}
	}
}
