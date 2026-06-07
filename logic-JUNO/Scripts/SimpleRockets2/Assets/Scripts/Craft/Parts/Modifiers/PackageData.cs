using System;
using Assets.Scripts.Design;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Package")]
	[PartModifierTypeId("Package")]
	public class PackageData : PartModifierData<PackageScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _mass = 1f;

		public override float MassDry => _mass;

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnPartStyleChanged(delegate
			{
				InvokeParametersChangedOnSymmetricPartModifiers();
			});
		}

		private void InvokeParametersChangedOnSymmetricPartModifiers(bool synchronizePartModifiersFirst = true)
		{
			if (synchronizePartModifiersFirst)
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			}
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(PackageData modifier)
			{
				modifier.Script.UpdatePartStyle();
			});
		}
	}
}
