using System;
using SettingScripts;
using UnityEngine;

namespace SimulationScripts.BibiteScripts
{
	public class BibiteArmor : BibiteSpatialOrgan
	{
		[NonSerialized]
		public float armorThickness;

		[NonSerialized]
		public float armorStrength;

		[NonSerialized]
		private float massDensity;

		[NonSerialized]
		private float energyDensity;

		[NonSerialized]
		private float cohesiveness;

		private MatterMaterialSettings armorMat;

		public override float mass => area * massDensity;

		protected override BibiteGenes.Genes apportionmentGene => BibiteGenes.Genes.ArmorWAG;

		public override void InitOrgan(BibiteBody bibite)
		{
			base.InitOrgan(bibite);
			armorMat = MatterMaterialManager.SettingsOfMaterial(MatterMaterialManager.Armor);
			if (organAreaPortion > 0f)
			{
				armorMat.onPhysicalParametersChange.AddListener(UpdateArmorParameters);
			}
			UpdateArmorParameters();
		}

		protected override void OnGrowth(float val = 1f)
		{
			base.OnGrowth(val);
			UpdateThickness();
		}

		public void UpdateArmorParameters()
		{
			massDensity = armorMat.massDensity.val;
			energyDensity = armorMat.energyDensity.val;
			cohesiveness = armorMat.cohesiveness.val;
			UpdateThickness();
		}

		public void UpdateThickness()
		{
			armorThickness = 5f * body.d1Size * (1f - Mathf.Sqrt(1f - organAreaPortion / (1f + body.inflateFactor)));
			armorStrength = armorThickness * cohesiveness;
		}

		public override void UpdateOrgan()
		{
		}

		private void OnDestroy()
		{
			if (organAreaPortion > 0f)
			{
				armorMat.onPhysicalParametersChange.RemoveListener(UpdateArmorParameters);
			}
		}
	}
}
