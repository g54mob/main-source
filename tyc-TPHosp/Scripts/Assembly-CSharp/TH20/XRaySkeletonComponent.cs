using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class XRaySkeletonComponent : EntityComponent
	{
		[SerializeField]
		private CharModule _charModule;

		private List<CharModule.ModuleInstance> _moduleInstances = new List<CharModule.ModuleInstance>();

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			Patient owner = GetOwner<Patient>();
			List<CharModule.CharModuleAssets> list = new List<CharModule.CharModuleAssets>();
			_charModule.GetRandomCharacterData((CharModule.Category)0, null, null, null, list);
			CharModuleUtils.BuildModularCharacterGameObject(list, owner.GameObject.transform, owner.Visual.RigBones, instantiateMaterials: true, null, _moduleInstances);
		}

		protected override Type ValidEntityType()
		{
			return typeof(Patient);
		}

		public override void Destroy()
		{
			CharModuleUtils.DestroyModularInstances(_moduleInstances);
			base.Destroy();
		}
	}
}
