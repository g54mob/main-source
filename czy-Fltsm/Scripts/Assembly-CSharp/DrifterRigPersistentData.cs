using System;

[Serializable]
public class DrifterRigPersistentData
{
	public int AttributeVariation;

	public int BodyColor;

	public int Head;

	public int Ears;

	public int EyesLook;

	public int Eyes;

	public int Nose;

	public int MouthLook;

	public int Mouth;

	public int Body;

	public int HairColor;

	public int Haircut;

	public int Eyebrows;

	public int Moustache;

	public int Beard;

	public int TopColor;

	public int Top;

	public int PantsColor;

	public int Pants;

	public int ShoesColor;

	public int Shoes;

	public DrifterRigPersistentData(Agent agent)
	{
		DrifterLookProperties lookProperties = agent.Descriptor.LookProperties;
		DrifterLookProperties.Indices lookIndices = agent.Descriptor.LookIndices;
		AttributeVariation = agent.DrifterRig.AttributeVariation;
		BodyColor = ReturnPropertiesIndex(lookProperties.BodyMaterialProperties, lookIndices.BodyMaterial);
		Head = ReturnPropertiesIndex(lookProperties.Heads, lookIndices.Head);
		Ears = ReturnPropertiesIndex(lookProperties.Ears, lookIndices.Ears);
		EyesLook = ReturnPropertiesIndex(lookProperties.EyesMaterialProperties, lookIndices.EyesMaterial);
		Eyes = ReturnPropertiesIndex(lookProperties.Eyes, lookIndices.Eyes);
		Nose = ReturnPropertiesIndex(lookProperties.Noses, lookIndices.Nose);
		MouthLook = ReturnPropertiesIndex(lookProperties.MouthMaterialProperties, lookIndices.MouthMaterial);
		Mouth = ReturnPropertiesIndex(lookProperties.Mouths, lookIndices.Mouth);
		Body = ReturnPropertiesIndex(lookProperties.Bodies, lookIndices.Body);
		HairColor = ReturnPropertiesIndex(lookProperties.HairMaterialProperties, lookIndices.HairMaterial);
		Haircut = ReturnPropertiesIndex(lookProperties.Haircuts, lookIndices.Haircut);
		Eyebrows = ReturnPropertiesIndex(lookProperties.Eyebrows, lookIndices.Eyebrows);
		Moustache = ReturnPropertiesIndex(lookProperties.Moustaches, lookIndices.Moustache);
		Beard = ReturnPropertiesIndex(lookProperties.Beards, lookIndices.Beard);
		TopColor = ReturnPropertiesIndex(lookProperties.ClothingMaterialProperties, lookIndices.TopMaterial);
		Top = ReturnPropertiesIndex(lookProperties.Tops, lookIndices.Top);
		PantsColor = ReturnPropertiesIndex(lookProperties.ClothingMaterialProperties, lookIndices.PantsMaterial);
		Pants = ReturnPropertiesIndex(lookProperties.Pants, lookIndices.Pants);
		ShoesColor = ReturnPropertiesIndex(lookProperties.ClothingMaterialProperties, lookIndices.ShoesMaterial);
		Shoes = ReturnPropertiesIndex(lookProperties.Shoes, lookIndices.Shoes);
	}

	private int ReturnPropertiesIndex<T>(T[] propertiesList, int propertiesIndex) where T : PersistentProperties
	{
		if (propertiesIndex < 0 || propertiesList.Length <= propertiesIndex)
		{
			return -1;
		}
		return GameManager.PersistenceManager.ReturnPropertiesIndex(propertiesList[propertiesIndex]);
	}
}
