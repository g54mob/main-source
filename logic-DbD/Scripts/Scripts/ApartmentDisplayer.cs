using System.Collections.Generic;
using UnityEngine;

public class ApartmentDisplayer : MonoBehaviour
{
	private static Dictionary<string, ApartmentImage> apartmentImages = new Dictionary<string, ApartmentImage>();

	[SerializeField]
	private GameObject aptColors;

	[SerializeField]
	private GameObject aptResidues;

	private void Start()
	{
		ApartmentImage apartmentImage = GetApartmentImage(base.transform.parent.name);
		aptColors.transform.Find($"COLOR {apartmentImage.color}").gameObject.SetActive(value: true);
		aptResidues.transform.Find($"RESIDUE {apartmentImage.residue1}").gameObject.SetActive(value: true);
		if (apartmentImage.residue2 > 0)
		{
			MonoBehaviour.print($"apartmentDetails.residue2: {apartmentImage.residue2}");
			aptResidues.transform.Find($"RESIDUE {apartmentImage.residue2}").gameObject.SetActive(value: true);
		}
	}

	private static ApartmentImage GetApartmentImage(string apartmentName)
	{
		if (apartmentImages.ContainsKey(apartmentName))
		{
			return apartmentImages[apartmentName];
		}
		ApartmentImage apartmentImage = new ApartmentImage();
		apartmentImages.Add(apartmentName, apartmentImage);
		return apartmentImage;
	}
}
