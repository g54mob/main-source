using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class IllnessMonoBrowComponent : EntityComponent
	{
		protected override Type ValidEntityType()
		{
			return typeof(Patient);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			RegisterAnimationEvent();
		}

		public override void Destroy()
		{
			MonoBeastSpawnEventListener component = GetOwner<Patient>().GameObject.GetComponent<MonoBeastSpawnEventListener>();
			if (component != null)
			{
				UnityEngine.Object.Destroy(component);
			}
			base.Destroy();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			RegisterAnimationEvent();
		}

		private void RegisterAnimationEvent()
		{
			Patient owner = GetOwner<Patient>();
			owner.GameObject.AddComponent<MonoBeastSpawnEventListener>().Owner = owner;
		}
	}
}
