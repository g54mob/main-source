using System.Collections.Generic;
using UnityEngine;

public class ConferenceActor : MonoBehaviour, IStylable
{
	public Color SkinColor;

	public Color HairColor;

	[SerializeField]
	private Transform _rootBone;

	public Animator Anim;

	public List<ActorBodyItem> BodyItems { get; set; } = new List<ActorBodyItem>();

	public Transform RootBone
	{
		get
		{
			return _rootBone;
		}
		set
		{
			_rootBone = value;
		}
	}

	public Dictionary<string, Transform> Rig { get; set; }

	public bool UsesLOD1
	{
		get
		{
			return false;
		}
	}

	public bool NeedsDestruction
	{
		get
		{
			return true;
		}
	}

	public void CopyExisting(Actor a)
	{
		ActorGenerator.Instance.CopyStyle(a, this);
		SetAge(a.employee.GetAge());
		SetLayer();
	}

	public void Init()
	{
		ActorGenerator.Instance.ApplySavedStyle(ActorGenerator.Instance.GenerateStyle(Utilities.RandomValue > 0.5f, "Default", 20f), this);
		SetLayer();
	}

	private void Start()
	{
		ActorGenerator.Instance.InitShadow(this).GetComponentsInChildren<Transform>().ForEachEnum(delegate(Transform x)
		{
			x.gameObject.layer = 9;
		});
	}

	public void SetLayer()
	{
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].gameObject.layer = 9;
		}
	}

	public void SetAge(float age)
	{
		float value = ((age >= 50f) ? ((age - 50f) / 10f) : 0f);
		value = Mathf.Clamp01(value);
		ActorBodyItem actorBodyItem = BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Hair && x.gameObject.activeSelf);
		if (actorBodyItem != null)
		{
			ActorBodyItem.ColorMapping colorMapping = actorBodyItem.Colormap.FirstOrDefault((ActorBodyItem.ColorMapping x) => x.ColorName.Equals("Hair"));
			if (colorMapping != null)
			{
				actorBodyItem.SetColorDirect(colorMapping.MaterialSlot, Color.Lerp(HairColor, Color.gray, value));
			}
		}
		ActorBodyItem actorBodyItem2 = BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head && x.gameObject.activeSelf);
		if (actorBodyItem2 != null)
		{
			actorBodyItem2.rend.material.SetFloat("_Overlay2Factor", value);
		}
	}

	public Transform GetTransform()
	{
		return base.transform;
	}

	public void UpdateEyes()
	{
	}

	public void UpdateHairColor(Color col)
	{
		HairColor = col;
	}

	public void UpdateSkinColor(Color col)
	{
		SkinColor = col;
	}

	public void PostUpdate(bool allowHoliday)
	{
	}

	public void SetLOD2Color(string part, Color col)
	{
	}
}
