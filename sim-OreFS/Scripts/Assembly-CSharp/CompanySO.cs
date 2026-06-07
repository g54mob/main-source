using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CompanyConfig", menuName = "Game/CompanySO")]
public class CompanySO : ScriptableObject
{
	[Header("Details")]
	[Tooltip("Şirketin benzersiz ID'si")]
	[SerializeField]
	private string companyId;

	[Tooltip("Şirket ismi")]
	public string companyName;

	[Tooltip("Şirket açıklaması için lokalizasyon key'i")]
	public string companyDescKey;

	[Header("Images")]
	[Tooltip("Şirket logosu")]
	public Sprite companyLogo;

	[Tooltip("Şirket arkaplan görseli")]
	public Sprite companyBackground;

	[Tooltip("Şirket logo rengi (SpriteRenderer materyali için)")]
	public Color logoColor = Color.black;

	[Header("Interested Categories")]
	[Tooltip("Şirketin ilgilendiği item kategorileri. Boş bırakılırsa tüm kategorilerden teklif verir.")]
	public List<FilterType> interestedCategories = new List<FilterType>();

	public string CompanyId => companyId;

	public bool IsInterestedIn(T_ItemSO item)
	{
		if (item == null)
		{
			return false;
		}
		if (interestedCategories == null || interestedCategories.Count == 0)
		{
			return true;
		}
		if (item.FilterTypes == null || item.FilterTypes.Count == 0)
		{
			return false;
		}
		foreach (FilterType interestedCategory in interestedCategories)
		{
			if (item.FilterTypes.Contains(interestedCategory))
			{
				return true;
			}
		}
		return false;
	}

	[ContextMenu("Regenerate Company ID")]
	private void RegenerateCompanyId()
	{
		companyId = Guid.NewGuid().ToString("N").Substring(0, 12)
			.ToUpper();
	}

	private void OnValidate()
	{
		if (string.IsNullOrEmpty(companyId))
		{
			RegenerateCompanyId();
		}
	}
}
