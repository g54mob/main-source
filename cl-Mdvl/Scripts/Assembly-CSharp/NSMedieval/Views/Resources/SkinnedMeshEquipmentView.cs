using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class SkinnedMeshEquipmentView : EquipmentView
	{
		[SerializeField]
		private ApplyMeshFilterSkinnedMeshRenderer applyMeshFilterSkinnedMeshRenderer;

		[SerializeField]
		private Material defaultSkinnedMaterial;

		private Transform meshTransform;

		public override void Setup(Resource resource)
		{
			SetupSkinnedMesh(resource);
			base.Setup(resource);
		}

		private void SetupSkinnedMesh(Resource resource)
		{
			bool isEnabled;
			if (string.IsNullOrEmpty(resource.EquippedPrefabID))
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\SkinnedMeshEquipmentView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(resource);
					messageBuilder.AppendLiteral(" EquippedPrefabID is null or empty, returning ");
				}
				Log.Trace(messageBuilder);
				return;
			}
			if (string.IsNullOrEmpty(resource.SkinnedMeshID))
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(43, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\SkinnedMeshEquipmentView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(resource);
					messageBuilder.AppendLiteral(" SkinnedMeshID is null or empty, returning ");
				}
				Log.Trace(messageBuilder);
				return;
			}
			GameObject byAddress = MonoRepository<MeshRepository, KeyGameObjectPair>.Instance.GetByAddress(resource.SkinnedMeshID);
			if (byAddress == null)
			{
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(44, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\SkinnedMeshEquipmentView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("SkinnedMeshID ");
					messageBuilder.AppendFormatted(resource.SkinnedMeshID);
					messageBuilder.AppendLiteral(" couldn't be found, returning ");
				}
				Log.Trace(messageBuilder);
			}
			else
			{
				meshTransform = Object.Instantiate(byAddress, meshPrefabParent).transform;
				meshTransform.gameObject.name = resource.EquippedPrefabID;
				SkinnedMeshRenderer componentInChildren = meshTransform.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
				componentInChildren.material = defaultSkinnedMaterial;
				meshVariationHandler.AssignMeshes(componentInChildren.sharedMesh);
				materialMeshParameters.AddMesh(componentInChildren);
				applyMeshFilterSkinnedMeshRenderer.ApplySkinnedMeshRenderer(componentInChildren);
			}
		}
	}
}
