using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Looks/Properties")]
public class DrifterLookProperties : PersistentProperties
{
	[Flags]
	public enum FeatureList
	{
		None = 0,
		BodyMaterial = 1,
		EyesMaterial = 2,
		MouthMaterial = 4,
		HairMaterial = 8,
		ClothingMaterial = 0x10,
		Head = 0x20,
		Ears = 0x40,
		Eyes = 0x80,
		Nose = 0x100,
		Mouth = 0x200,
		Body = 0x400,
		Haircut = 0x800,
		Eyebrows = 0x1000,
		Moustache = 0x2000,
		Beard = 0x4000,
		Top = 0x8000,
		Pants = 0x10000,
		Shoes = 0x20000,
		All = 0x3FFFF
	}

	[Serializable]
	public struct Indices
	{
		public int BodyMaterial;

		public int EyesMaterial;

		public int MouthMaterial;

		public int Head;

		public int Ears;

		public int Eyes;

		public int Nose;

		public int Mouth;

		public int Body;

		public int HairMaterial;

		public int Haircut;

		public int Eyebrows;

		public int Moustache;

		public int Beard;

		public int TopMaterial;

		public int PantsMaterial;

		public int ShoesMaterial;

		public int Top;

		public int Pants;

		public int Shoes;
	}

	public DrifterRig RigPrefab;

	[Header("Body Parts")]
	public DrifterLookMaterialProperties[] BodyMaterialProperties;

	public DrifterLookMaterialProperties[] EyesMaterialProperties;

	public DrifterLookMaterialProperties[] MouthMaterialProperties;

	[Space]
	public DrifterLookPart[] Heads;

	public DrifterLookPart[] Ears;

	public DrifterLookPart[] Eyes;

	public DrifterLookPart[] Noses;

	public DrifterLookPart[] Mouths;

	public DrifterLookPart[] Bodies;

	[Header("Hair")]
	public DrifterLookMaterialProperties[] HairMaterialProperties;

	[Space]
	public DrifterLookPart[] Haircuts;

	public DrifterLookPart[] Eyebrows;

	public DrifterLookPart[] Moustaches;

	public DrifterLookPart[] Beards;

	[Header("Clothing")]
	public DrifterLookMaterialProperties[] ClothingMaterialProperties;

	[Space]
	public DrifterLookPart[] Tops;

	public DrifterLookPart[] Pants;

	public DrifterLookPart[] Shoes;

	[Header("Particle Systems")]
	public DrifterLookParticleSystem[] ParticleSystems;

	public override Types Type => Types.DrifterLookProperties;

	public Indices GetRandomIndices()
	{
		int index;
		return new Indices
		{
			Head = (Heads.TryGetRandomIndex(out index) ? index : (-1)),
			Ears = (Ears.TryGetRandomIndex(out index) ? index : (-1)),
			Eyes = (Eyes.TryGetRandomIndex(out index) ? index : (-1)),
			Nose = (Noses.TryGetRandomIndex(out index) ? index : (-1)),
			Body = (Bodies.TryGetRandomIndex(out index) ? index : (-1)),
			Haircut = (Haircuts.TryGetRandomIndex(out index) ? index : (-1)),
			Eyebrows = (Eyebrows.TryGetRandomIndex(out index) ? index : (-1)),
			Moustache = (Moustaches.TryGetRandomIndex(out index) ? index : (-1)),
			Beard = (Beards.TryGetRandomIndex(out index) ? index : (-1)),
			Top = (Tops.TryGetRandomIndex(out index) ? index : (-1)),
			Pants = (Pants.TryGetRandomIndex(out index) ? index : (-1)),
			Shoes = (Shoes.TryGetRandomIndex(out index) ? index : (-1)),
			BodyMaterial = (BodyMaterialProperties.TryGetRandomIndex(out index) ? index : (-1)),
			EyesMaterial = (EyesMaterialProperties.TryGetRandomIndex(out index) ? index : (-1)),
			MouthMaterial = (MouthMaterialProperties.TryGetRandomIndex(out index) ? index : (-1)),
			HairMaterial = (HairMaterialProperties.TryGetRandomIndex(out index) ? index : (-1)),
			TopMaterial = (ClothingMaterialProperties.TryGetRandomIndex(out index) ? index : (-1)),
			PantsMaterial = (ClothingMaterialProperties.TryGetRandomIndex(out index) ? index : (-1)),
			ShoesMaterial = (ClothingMaterialProperties.TryGetRandomIndex(out index) ? index : (-1))
		};
	}

	public void Apply(DrifterRig rig, DrifterLookCamera camera = DrifterLookCamera.Main)
	{
		ApplyIndices(rig, GetRandomIndices(), camera);
	}

	public void ApplyIndices(DrifterRig rig, Indices indices, DrifterLookCamera camera)
	{
		ApplyIndices(rig, indices);
		DrifterLookParticleSystem[] particleSystems = ParticleSystems;
		foreach (DrifterLookParticleSystem drifterLookParticleSystem in particleSystems)
		{
			if (drifterLookParticleSystem.TryReturnParticleSystemPrefab(camera, out var particleSystem))
			{
				rig.SetParticleSystem(particleSystem, drifterLookParticleSystem.Parent);
			}
		}
	}

	public void ApplyIndices(DrifterRig rig, Indices indices)
	{
		if (TryReturnMaterialProperties(BodyMaterialProperties, indices.BodyMaterial, out var materialProperties))
		{
			rig.BodyColor = materialProperties;
		}
		if (TryReturnMaterialProperties(EyesMaterialProperties, indices.EyesMaterial, out materialProperties))
		{
			rig.EyesLook = materialProperties;
		}
		if (TryReturnMaterialProperties(MouthMaterialProperties, indices.MouthMaterial, out materialProperties))
		{
			rig.MouthLook = materialProperties;
		}
		if (TryReturnMaterialProperties(HairMaterialProperties, indices.HairMaterial, out materialProperties))
		{
			rig.HairColor = materialProperties;
		}
		if (TryReturnMaterialProperties(ClothingMaterialProperties, indices.TopMaterial, out materialProperties))
		{
			rig.TopColor = materialProperties;
		}
		if (TryReturnMaterialProperties(ClothingMaterialProperties, indices.PantsMaterial, out materialProperties))
		{
			rig.PantsColor = materialProperties;
		}
		if (TryReturnMaterialProperties(ClothingMaterialProperties, indices.ShoesMaterial, out materialProperties))
		{
			rig.ShoesColor = materialProperties;
		}
		if (TryReturnDriftetLookPart(Heads, indices.Head, out var part))
		{
			rig.SetHead(part);
		}
		if (TryReturnDriftetLookPart(Ears, indices.Ears, out part))
		{
			rig.SetEars(part);
		}
		if (TryReturnDriftetLookPart(Eyes, indices.Eyes, out part))
		{
			rig.SetEyes(part);
		}
		if (TryReturnDriftetLookPart(Noses, indices.Nose, out part))
		{
			rig.SetNose(part);
		}
		if (TryReturnDriftetLookPart(Mouths, indices.Mouth, out part))
		{
			rig.SetMouth(part);
		}
		if (TryReturnDriftetLookPart(Bodies, indices.Body, out part))
		{
			rig.SetBody(part);
		}
		if (TryReturnDriftetLookPart(Haircuts, indices.Haircut, out part))
		{
			rig.SetHaircut(part);
		}
		if (TryReturnDriftetLookPart(Eyebrows, indices.Eyebrows, out part))
		{
			rig.SetEyebrows(part);
		}
		if (TryReturnDriftetLookPart(Moustaches, indices.Moustache, out part))
		{
			rig.SetMoustache(part);
		}
		if (TryReturnDriftetLookPart(Beards, indices.Beard, out part))
		{
			rig.SetBeard(part);
		}
		if (TryReturnDriftetLookPart(Tops, indices.Top, out part))
		{
			rig.SetTop(part);
		}
		if (TryReturnDriftetLookPart(Pants, indices.Pants, out part))
		{
			rig.SetPants(part);
		}
		if (TryReturnDriftetLookPart(Shoes, indices.Shoes, out part))
		{
			rig.SetShoes(part);
		}
		rig.ClearParticleSystems();
	}

	public void SetRandomBodyColor(DrifterRig rig)
	{
		rig.BodyColor = FlotsamGame.Random(BodyMaterialProperties);
	}

	public void SetRandomEyesLook(DrifterRig rig)
	{
		rig.EyesLook = FlotsamGame.Random(EyesMaterialProperties);
	}

	public void SetRandomMouthLook(DrifterRig rig)
	{
		rig.MouthLook = FlotsamGame.Random(MouthMaterialProperties);
	}

	public void SetRandomHairColor(DrifterRig rig)
	{
		rig.HairColor = FlotsamGame.Random(HairMaterialProperties);
	}

	public void SetRandomClothingColors(DrifterRig rig)
	{
		rig.TopColor = FlotsamGame.Random(ClothingMaterialProperties);
		rig.PantsColor = FlotsamGame.Random(ClothingMaterialProperties);
		rig.ShoesColor = FlotsamGame.Random(ClothingMaterialProperties);
	}

	public void SetRandomHead(DrifterRig rig)
	{
		DrifterLookPart head = FlotsamGame.Random(Heads);
		rig.SetHead(head);
	}

	public void SetRandomEars(DrifterRig rig)
	{
		DrifterLookPart ears = FlotsamGame.Random(Ears);
		rig.SetEars(ears);
	}

	public void SetRandomEyes(DrifterRig rig)
	{
		DrifterLookPart eyes = FlotsamGame.Random(Eyes);
		rig.SetEyes(eyes);
	}

	public void SetRandomNose(DrifterRig rig)
	{
		DrifterLookPart nose = FlotsamGame.Random(Noses);
		rig.SetNose(nose);
	}

	public void SetRandomMouth(DrifterRig rig)
	{
		DrifterLookPart mouth = FlotsamGame.Random(Mouths);
		rig.SetMouth(mouth);
	}

	public void SetRandomBody(DrifterRig rig)
	{
		DrifterLookPart body = FlotsamGame.Random(Bodies);
		rig.SetBody(body);
	}

	public void SetRandomHaircut(DrifterRig rig)
	{
		DrifterLookPart haircut = FlotsamGame.Random(Haircuts);
		rig.SetHaircut(haircut);
	}

	public void SetRandomEyebrows(DrifterRig rig)
	{
		DrifterLookPart eyebrows = FlotsamGame.Random(Eyebrows);
		rig.SetEyebrows(eyebrows);
	}

	public void SetRandomMoustache(DrifterRig rig)
	{
		if (Moustaches.Length != 0)
		{
			DrifterLookPart moustache = FlotsamGame.Random(Moustaches);
			rig.SetMoustache(moustache);
		}
	}

	public void SetRandomBeard(DrifterRig rig)
	{
		if (Beards.Length != 0)
		{
			DrifterLookPart beard = FlotsamGame.Random(Beards);
			rig.SetBeard(beard);
		}
	}

	public void SetRandomTop(DrifterRig rig)
	{
		DrifterLookPart top = FlotsamGame.Random(Tops);
		rig.SetTop(top);
	}

	public void SetRandomPants(DrifterRig rig)
	{
		DrifterLookPart pants = FlotsamGame.Random(Pants);
		rig.SetPants(pants);
	}

	public void SetRandomShoes(DrifterRig rig)
	{
		DrifterLookPart shoes = FlotsamGame.Random(Shoes);
		rig.SetShoes(shoes);
	}

	public Indices ReturnIndices(DrifterRig rig, out bool reapply)
	{
		reapply = false;
		return new Indices
		{
			BodyMaterial = ReturnMaterialIndex(BodyMaterialProperties, rig.BodyColor, ref reapply),
			EyesMaterial = ReturnMaterialIndex(EyesMaterialProperties, rig.EyesLook, ref reapply),
			MouthMaterial = ReturnMaterialIndex(MouthMaterialProperties, rig.MouthLook, ref reapply),
			Head = ReturnPartindex(Heads, rig.Head, ref reapply),
			Ears = ReturnPartindex(Ears, rig.Ears, ref reapply),
			Eyes = ReturnPartindex(Eyes, rig.Eyes, ref reapply),
			Nose = ReturnPartindex(Noses, rig.Nose, ref reapply),
			Mouth = ReturnPartindex(Mouths, rig.Mouth, ref reapply),
			Body = ReturnPartindex(Bodies, rig.Body, ref reapply),
			HairMaterial = ReturnMaterialIndex(HairMaterialProperties, rig.HairColor, ref reapply),
			Haircut = ReturnPartindex(Haircuts, rig.Haircut, ref reapply),
			Eyebrows = ReturnPartindex(Eyebrows, rig.Eyebrows, ref reapply),
			Moustache = ReturnPartindex(Moustaches, rig.Moustache, ref reapply),
			Beard = ReturnPartindex(Beards, rig.Beard, ref reapply),
			TopMaterial = ReturnMaterialIndex(ClothingMaterialProperties, rig.TopColor, ref reapply),
			PantsMaterial = ReturnMaterialIndex(ClothingMaterialProperties, rig.PantsColor, ref reapply),
			ShoesMaterial = ReturnMaterialIndex(ClothingMaterialProperties, rig.ShoesColor, ref reapply),
			Top = ReturnPartindex(Tops, rig.Top, ref reapply),
			Pants = ReturnPartindex(Pants, rig.Pants, ref reapply),
			Shoes = ReturnPartindex(Shoes, rig.Shoes, ref reapply)
		};
	}

	private int ReturnMaterialIndex(DrifterLookMaterialProperties[] materials, DrifterLookMaterialProperties material, ref bool reapply)
	{
		int num = materials.IndexOf(material);
		if (num < 0)
		{
			num = materials.GetRandomIndex();
			reapply = true;
			Debug.LogException(new Exception($"Unable to restore index for DrifterLookMaterialProperties '{material}'!"));
		}
		return num;
	}

	private int ReturnPartindex(DrifterLookPart[] parts, DrifterLookPart part, ref bool reapply)
	{
		int num = parts.IndexOf(part);
		if (num < 0)
		{
			num = parts.GetRandomIndex();
			reapply = true;
			Debug.LogException(new Exception($"Unable to restore index for DrifterLookPart '{part}'!"));
		}
		return num;
	}

	private bool TryReturnMaterialProperties(DrifterLookMaterialProperties[] materialPropertiesArray, int index, out DrifterLookMaterialProperties materialProperties)
	{
		if (-1 < index && index < materialPropertiesArray.Length)
		{
			materialProperties = materialPropertiesArray[index];
			return true;
		}
		materialProperties = null;
		return false;
	}

	private bool TryReturnDriftetLookPart(DrifterLookPart[] parts, int index, out DrifterLookPart part)
	{
		if (-1 < index && index < parts.Length)
		{
			part = parts[index];
			return true;
		}
		part = null;
		return false;
	}
}
