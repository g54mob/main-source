using System;
using System.Runtime.Serialization;

[Serializable]
public class DiseasePersistentData
{
	public int DiseaseProperties;

	public float CurrentTime;

	[OptionalField(VersionAdded = 2)]
	public int CurrentDay;

	public DiseasePersistentData(Disease disease)
	{
		DiseaseProperties = GameManager.PersistenceManager.ReturnPropertiesIndex(disease.PropertiesReference);
		CurrentTime = disease.CurrentTime;
		CurrentDay = disease.CurrentDay;
	}
}
