using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class MaterialMeshParameters : MonoBehaviour
	{
		[SerializeField]
		private Renderer[] meshes;

		private SetShaderParam[] parameters;

		public Renderer[] Meshes => meshes;

		public void AddMesh(Renderer renderer)
		{
			if (meshes == null)
			{
				meshes = new Renderer[1] { renderer };
			}
			else
			{
				meshes = meshes.Append(renderer).ToArray();
			}
		}

		public void UpdateParameters(string materialId)
		{
			if (string.IsNullOrEmpty(materialId))
			{
				return;
			}
			bool isEnabled;
			if (meshes == null)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\MaterialMeshParameters.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Renderer is not assigned from editor on ");
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral("!");
				}
				Log.Warning(messageBuilder);
				return;
			}
			parameters = Repository<MaterialSettingsRepository, MaterialSettings>.Instance.GetByID(materialId).ShaderParameters;
			if (parameters == null)
			{
				FVLogWarningInterpolationHandler messageBuilder = new FVLogWarningInterpolationHandler(40, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\View\\Resources\\MaterialMeshParameters.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("There are no material (");
					messageBuilder.AppendFormatted(materialId);
					messageBuilder.AppendLiteral(") parameters on ");
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral("!");
				}
				Log.Warning(messageBuilder);
				return;
			}
			Renderer[] array = meshes;
			foreach (Renderer renderer in array)
			{
				if (!(renderer == null))
				{
					SetShaderParam[] array2 = parameters;
					for (int j = 0; j < array2.Length; j++)
					{
						array2[j].TryApply(renderer);
					}
				}
			}
		}
	}
}
