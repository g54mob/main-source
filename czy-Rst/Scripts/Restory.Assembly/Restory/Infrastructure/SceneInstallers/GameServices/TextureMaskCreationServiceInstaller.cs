using Restory.Gameplay.TextureMasks;
using Restory.ObjectPools;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class TextureMaskCreationServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private ComputeShader computeShader;

		[SerializeField]
		private ComputeShader meshUvRasterizerShader;

		[SerializeField]
		private ComputeShader uvMaskPaddingAddingComputeShader;

		[SerializeField]
		private MaskPresetInfoBase defaultMaskPreset;

		public override void InstallBindings()
		{
			base.Container.Bind<RenderTexturePool>().FromNew().AsSingle();
			base.Container.Bind<ComputeShader>().WithId("TextureMaskComputeShader").FromInstance(computeShader);
			base.Container.Bind<ComputeShader>().WithId("MeshUVRasterizerShader").FromInstance(meshUvRasterizerShader);
			base.Container.Bind<MaskPresetInfoBase>().WithId("DefaultMaskPreset").FromInstance(defaultMaskPreset);
			base.Container.BindInterfacesAndSelfTo<TextureMaskCreationService>().AsSingle().WithArguments(computeShader, meshUvRasterizerShader, uvMaskPaddingAddingComputeShader, defaultMaskPreset);
			base.Container.BindInterfacesAndSelfTo<TextureCreationService>().FromNew().AsSingle();
		}
	}
}
