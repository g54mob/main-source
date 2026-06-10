using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "company_data", menuName = "Database/Company/Company Preset")]
public class CompanyPreset : SoCustomComparison
{
	public enum CompanyCategory
	{
		meal = 0,
		snack = 1,
		caffeine = 2,
		groceries = 3,
		washing = 4,
		medical = 5,
		recreational = 6,
		retail = 7
	}

	public enum SalaryRange
	{
		illegal = 0,
		minimumWage = 1,
		low = 2,
		average = 3,
		aboveAverage = 4,
		high = 5,
		veryHigh = 6,
		extreme = 7,
		millionaire = 8
	}

	public enum NameComponent
	{
		prefix = 0,
		main = 1,
		suffix = 2
	}

	[Serializable]
	public class TheRule
	{
		public NameComponent component;

		public bool exists;

		public float chanceModifier;
	}

	[Header("Category")]
	[Tooltip("The category of this company")]
	public List<CompanyCategory> companyCategories;

	public bool createMenu;

	[Header("Legality")]
	public bool isIllegal;

	[Header("Naming")]
	[Tooltip("Use a building's name as main if there is one")]
	public bool useBuildingName;

	[DisableIf("useBuildingName")]
	[Tooltip("Use a building's overidden name as main if there is one")]
	public bool useBuildingOverrideName;

	[Tooltip("If the above is used, add this extra suffix")]
	public List<string> overrideSuffixList;

	[Range(0f, 1f)]
	[Tooltip("Chances of using the street name as a main company name")]
	[Space(7f)]
	public float useStreetNameChance;

	[Range(0f, 1f)]
	[Tooltip("Chances of using the district name as a main company name")]
	public float useDistrictNameChance;

	[Range(0f, 1f)]
	[Tooltip("Chances of using the owner's first name as a main company name")]
	public float useOwnerFirstNameChance;

	[Tooltip("Chances of using the owner's sur name as a main company name")]
	[Range(0f, 1f)]
	public float useOwnerSurNameChance;

	[Range(0f, 1f)]
	[Tooltip("Chances of using the above name list as a main company name")]
	public float useCompanyNameListChance;

	[Tooltip("Chance of alliteration with prefix. This will add words with the same letter to the suffix to increase the chances of picking them by this amount")]
	[Range(0f, 15f)]
	public int aliterationWeight;

	[Space(5f)]
	[Range(0f, 1f)]
	public float prefixChance;

	[Tooltip("Use this name list to pick a prefix")]
	[ReorderableList]
	public List<string> prefixList;

	[Range(0f, 1f)]
	public float mainChance;

	[ReorderableList]
	[Tooltip("Use this name list to pick a main name")]
	public List<string> mainNamingList;

	[ReorderableList]
	[Tooltip("Append a random selection of this suffix list to the name")]
	public List<string> suffixList;

	[Tooltip("How likely is there to be 'the' appended to the start of this name")]
	public List<TheRule> theRules;

	[Header("Wages")]
	[Tooltip("How much the lowest rank jobs earn")]
	public SalaryRange minimumSalary;

	[Tooltip("How much the top rank jobs earn")]
	public SalaryRange topSalary;

	[Tooltip("The pay grade curve from lowest rank to top rank")]
	public AnimationCurve payGradeCurve;

	[Tooltip("Does this company need a storefront?")]
	[Header("Retail")]
	public bool publicFacing;

	[Tooltip("Is this company a self employed person?")]
	public bool isSelfEmployed;

	[EnableIf("isSelfEmployed")]
	[Tooltip("Automatically create self employed companies")]
	public bool autoCreate;

	[EnableIf("isSelfEmployed")]
	[Range(0f, 10f)]
	public int priority;

	[EnableIf("isSelfEmployed")]
	public float cityPopRatio;

	[EnableIf("isSelfEmployed")]
	public int minimumNumber;

	[EnableIf("isSelfEmployed")]
	public int maximumNumber;

	[Tooltip("If true, loitering behaviour is enabled")]
	public bool enableLoiteringBehaviour;

	[Tooltip("List of items that this shop stocks")]
	public List<MenuPreset> menus;

	public bool recordSalesData;

	[EnableIf("recordSalesData")]
	public int previousFakeSalesRecords;

	[EnableIf("recordSalesData")]
	[Tooltip("A citizen must have one of the following to log a sales record here...")]
	public List<CharacterTrait> requiredTraits;

	[Tooltip("Purchasing here also has a sell section")]
	public bool enableSelling;

	[EnableIf("enableSelling")]
	public bool enableSellingOfIllegalItems;

	[EnableIf("enableSelling")]
	public float sellValueMultiplier;

	[Header("Uniforms")]
	public List<Color> possibleUniformColours;

	[Tooltip("Preset detailing work hours")]
	[Header("Work Hours")]
	public CompanyOpenHoursPreset workHours;

	[Header("Hierarchy")]
	[Tooltip("This structure of this company detailing jobs")]
	public CompanyStructurePreset structure;

	[Header("Special cases")]
	[Tooltip("Controls surveillance of building")]
	public bool controlsBuildingSurveillance;

	[Tooltip("For easily identifying a hotel")]
	public bool isHotel;
}
