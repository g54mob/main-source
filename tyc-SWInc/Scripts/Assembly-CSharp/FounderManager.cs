using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FounderManager : MonoBehaviour
{
	public class FounderDescriptor
	{
		public bool Female;

		public bool ReadOnly;

		public string Name;

		public float[] Skills = new float[5];

		public float Creativity;

		public string LeadFocus;

		public float Age = 20f;

		public Employee.EmployeeRole? ForcedBrain;

		public ActorBodyItem.BodyItemObject[] Style;

		public HashSet<Employee.Trait> Traits = new HashSet<Employee.Trait>();

		public string[] Personality = new string[2];

		public bool HasChangedName;

		public Dictionary<string, int>[] Specializations = new Dictionary<string, int>[5]
		{
			new Dictionary<string, int>(),
			new Dictionary<string, int>(),
			new Dictionary<string, int>(),
			new Dictionary<string, int>(),
			new Dictionary<string, int>()
		};

		public FounderDescriptor(Employee emp, float age)
		{
			Female = emp.Female;
			ReadOnly = true;
			Name = emp.Name;
			Age = age;
			Skills = new float[5]
			{
				emp.GetSkillI(0),
				emp.GetSkillI(1),
				emp.GetSkillI(2),
				emp.GetSkillI(3),
				emp.GetSkillI(4)
			};
			Traits = Employee.EnumTraits(emp.Traits).ToHashSet();
			Style = emp.StyleGen;
			Personality = emp.PersonalityTraits;
			Specializations = emp.GetAllSpecializations();
		}

		public FounderDescriptor(float maxSkillPoints, string[] personality, Employee.Trait traits)
		{
			Female = Utilities.RandomValue > 0.5f;
			Name = GameData.GenerateName(!Female);
			Style = ActorGenerator.Instance.GenerateStyle(Female, "Default", 20f);
			for (int i = 0; i < Skills.Length; i++)
			{
				Skills[i] = maxSkillPoints / (float)Skills.Length;
			}
			Creativity = 0.5f;
			Personality = personality;
			SetTraits(traits);
			LeadFocus = "Operating System";
		}

		public void SetTraits(Employee.Trait traits)
		{
			Traits.Clear();
			for (int i = 0; i < 64; i++)
			{
				Employee.Trait trait = (Employee.Trait)(1L << i);
				if (traits.HasBits(trait))
				{
					Traits.Add(trait);
				}
			}
		}
	}

	public GameObject[] FounderButtons;

	public GameObject FirstFounderRemoveButton;

	public RawImage[] FounderThumbs;

	[NonSerialized]
	public FounderDescriptor[] Founders = new FounderDescriptor[4];

	public int ActiveFounder;

	public GameObject AddButton;

	public Color ActiveColor = new Color32(170, 249, 167, byte.MaxValue);

	public Camera Self;

	public Light FaceLight;

	public AnimationCurve LightIntensity;

	[NonSerialized]
	private Material[] _beforeThumb;

	private Quaternion _prevRot;

	public FounderDescriptor SelFounder
	{
		get
		{
			return Founders[ActiveFounder];
		}
	}

	public void GenerateInitialFounder(float maxSkillPoints, string[] personality)
	{
		PersonalityGraph personalities = ActorCustomization.Instance.GetPersonalities();
		Founders[0] = new FounderDescriptor(maxSkillPoints, personality, ActorCustomization.SelectOptimalTraits(ActorCustomization.GetForcedTraits(personality, personalities), personalities));
	}

	private void Awake()
	{
		for (int i = 0; i < FounderButtons.Length; i++)
		{
			FounderButtons[i].SetActive(i == 0);
			RenderTexture renderTexture = new RenderTexture(64, 64, 16);
			renderTexture.antiAliasing = 8;
			FounderThumbs[i].texture = renderTexture;
		}
		AddButton.SetActive(true);
		UpdateButtons();
		FounderButtons[0].GetComponent<Image>().color = ActiveColor;
	}

	public void SelectFounder(int i)
	{
		for (int j = 0; j < FounderButtons.Length; j++)
		{
			FounderButtons[j].GetComponent<Image>().color = ((j == i) ? ActiveColor : Color.white);
		}
		ActiveFounder = i;
		ActorCustomization.Instance.LoadFounder(Founders[i], i);
	}

	public void UpdateFounderThumb(int i)
	{
		Self.targetTexture = FounderThumbs[i].texture as RenderTexture;
		Self.enabled = true;
	}

	public void DeleteFounder(int i)
	{
		int num = ActiveFounder;
		if (num == i)
		{
			num = 0;
		}
		else if (num > i)
		{
			num--;
		}
		Founders[i] = null;
		Texture texture = FounderThumbs[i].texture;
		for (int j = i; j < Founders.Length; j++)
		{
			Founders[j] = ((j == Founders.Length - 1) ? null : Founders[j + 1]);
			FounderThumbs[j].texture = ((j == Founders.Length - 1) ? texture : FounderThumbs[j + 1].texture);
		}
		for (int k = 0; k < Founders.Length; k++)
		{
			FounderButtons[k].SetActive(Founders[k] != null);
		}
		RefreshNames();
		SelectFounder(num);
		UpdateButtons();
		ActorCustomization.Instance.UpdateMoneyDescription();
	}

	public void AddFounder()
	{
		for (int i = 0; i < FounderButtons.Length; i++)
		{
			if (!FounderButtons[i].activeSelf)
			{
				string[] personality = ActorCustomization.Instance.PersonalityChosen.SelectInPlace((GUICombobox x) => x.SelectedItemString);
				PersonalityGraph personalities = ActorCustomization.Instance.GetPersonalities();
				Founders[i] = new FounderDescriptor(ActorCustomization.Instance.GetDifficulty().MaxSkillPoints, personality, ActorCustomization.SelectOptimalTraits(ActorCustomization.GetForcedTraits(personality, personalities), personalities));
				SelectFounder(i);
				RectTransform component = FounderButtons[i].GetComponent<RectTransform>();
				component.sizeDelta = Vector2.zero;
				component.DOSizeDelta(new Vector2(64f, 64f), 0.5f, true).SetEase(Ease.OutBounce);
				FounderButtons[i].SetActive(true);
				break;
			}
		}
		UpdateButtons();
		RefreshNames();
		ActorCustomization.Instance.UpdateMoneyDescription();
	}

	public void RefreshNames()
	{
		for (int i = 0; i < FounderButtons.Length; i++)
		{
			if (FounderButtons[i].activeSelf)
			{
				FounderButtons[i].GetComponent<GUIToolTipper>().ToolTipValue = Founders[i].Name;
			}
		}
	}

	private void UpdateButtons()
	{
		int num;
		for (num = FounderButtons.Length - 1; num >= 0; num--)
		{
			if (FounderButtons[num].activeSelf)
			{
				num++;
				break;
			}
		}
		for (int i = 0; i < num; i++)
		{
			FounderButtons[i].GetComponent<Image>().sprite = ObjectDatabase.Instance.GetSprite(false, i == 0, i == num - 1, false);
		}
		AddButton.SetActive(num < 4);
		FirstFounderRemoveButton.SetActive(num > 1 && !Founders[0].ReadOnly);
	}

	private void OnPreCull()
	{
		FaceLight.enabled = true;
		FaceLight.intensity = LightIntensity.Evaluate(ActorCustomization.Instance.SkinColor.grayscale);
		ActorCustomization.Instance.Eyes.blink = 0f;
		ActorCustomization.Instance.Eyes.UpdateMe();
		_prevRot = ActorCustomization.Instance.transform.rotation;
		ActorCustomization.Instance.transform.rotation = Quaternion.identity;
	}

	private void OnPreRender()
	{
		ActorBodyItem actorBodyItem = ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
		_beforeThumb = null;
		if (actorBodyItem != null && actorBodyItem.rend.sharedMaterials.Length > 1)
		{
			_beforeThumb = actorBodyItem.rend.sharedMaterials.ToArray();
			actorBodyItem.rend.sharedMaterials = new Material[1] { actorBodyItem.rend.sharedMaterials[0] };
		}
	}

	private void OnRenderImage(RenderTexture src, RenderTexture dst)
	{
		Graphics.Blit(src, dst);
		Self.enabled = false;
		if (_beforeThumb != null)
		{
			ActorBodyItem actorBodyItem = ActorCustomization.Instance.BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head);
			if (actorBodyItem != null)
			{
				actorBodyItem.rend.sharedMaterials = _beforeThumb;
				_beforeThumb = null;
			}
		}
		FaceLight.enabled = false;
		ActorCustomization.Instance.transform.rotation = _prevRot;
	}

	private void OnDestroy()
	{
		for (int i = 0; i < FounderThumbs.Length; i++)
		{
			UnityEngine.Object.Destroy(FounderThumbs[i].texture);
		}
	}
}
