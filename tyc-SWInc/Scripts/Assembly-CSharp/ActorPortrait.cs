using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class ActorPortrait : MonoBehaviour, IStylable
{
	private List<ActorBodyItem> _bodyItems = new List<ActorBodyItem>();

	public Color SkinColor;

	public Color HairColor;

	[SerializeField]
	private Transform _rootBone;

	public Transform Neck;

	public Transform Hips;

	public List<ActorBodyItem> BodyItems
	{
		get
		{
			return _bodyItems;
		}
		set
		{
			_bodyItems = value;
		}
	}

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

	private void Start()
	{
		foreach (ActorBodyItem item in from x in ActorGenerator.Instance.BodyItems
			where !x.Key.Equals("Shadow")
			select x.Value.GetComponent<ActorBodyItem>())
		{
			ActorBodyItem actorBodyItem = ActorGenerator.Instance.SetItem(this, false, item.Key, false);
			Renderer[] componentsInChildren = actorBodyItem.GetComponentsInChildren<Renderer>();
			foreach (Renderer obj in componentsInChildren)
			{
				obj.shadowCastingMode = ShadowCastingMode.On;
				obj.gameObject.layer = 8;
			}
			if (actorBodyItem.CreateMirrorVersion)
			{
				actorBodyItem = ActorGenerator.Instance.SetItem(this, true, item.Key, false);
				componentsInChildren = actorBodyItem.GetComponentsInChildren<Renderer>();
				foreach (Renderer obj2 in componentsInChildren)
				{
					obj2.shadowCastingMode = ShadowCastingMode.On;
					obj2.gameObject.layer = 8;
				}
			}
		}
	}

	public void ApplyStyle(Actor a)
	{
		ActorGenerator.Instance.CopyStyle(a, this, false);
		SetAge(a.employee.GetAge());
	}

	public void ApplyStyle(ActorBodyItem.BodyItemObject[] a, float age)
	{
		ActorGenerator.Instance.ApplySavedStyle(a, this, false);
		SetAge(age);
	}

	public void SetExpression(string expression, bool reset)
	{
		ActorBodyItem actorBodyItem = BodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head && x.gameObject.activeSelf);
		if (!(actorBodyItem != null))
		{
			return;
		}
		if (reset)
		{
			for (int num = 0; num < actorBodyItem.Blends.Length; num++)
			{
				ActorBodyItem.BlendKeys blendKeys = actorBodyItem.Blends[num];
				if (blendKeys.GroupName.Equals("Expressions"))
				{
					blendKeys.SetBlendValue(0f, actorBodyItem.rend as SkinnedMeshRenderer, actorBodyItem.LOD1Renderer);
				}
			}
			return;
		}
		for (int num2 = 0; num2 < actorBodyItem.Blends.Length; num2++)
		{
			ActorBodyItem.BlendKeys blendKeys2 = actorBodyItem.Blends[num2];
			if (blendKeys2.GroupName.Equals("Expressions"))
			{
				blendKeys2.SetBlendValue(blendKeys2.BlendName.Equals(expression) ? 100 : 0, actorBodyItem.rend as SkinnedMeshRenderer, actorBodyItem.LOD1Renderer);
			}
		}
	}

	public void SetExpressions(Dictionary<string, float> expressions)
	{
		ActorBodyItem actorBodyItem = BodyItems.First((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head && x.gameObject.activeSelf);
		for (int num = 0; num < actorBodyItem.Blends.Length; num++)
		{
			ActorBodyItem.BlendKeys blendKeys = actorBodyItem.Blends[num];
			float value;
			if (blendKeys.GroupName.Equals("Expressions") && expressions.TryGetValue(blendKeys.BlendName, out value))
			{
				blendKeys.SetBlendValue(value, actorBodyItem.rend as SkinnedMeshRenderer, actorBodyItem.LOD1Renderer);
			}
		}
	}

	public void SetRotation(string name)
	{
		System.Random rnd = new System.Random(name.GetHashCode());
		float num = rnd.Range(-30f, 30f);
		RootBone.localRotation = Quaternion.Euler(0f, 90f, -90f);
		Hips.localRotation = Quaternion.Euler(num, 0f, 8f);
		Neck.localRotation = Quaternion.Euler(0f - num + rnd.Range(-10f, 10f), 0f, 0f);
	}

	public void SetAge(float age)
	{
		float value = ((age >= 50f) ? ((age - 50f) / 10f) : 0f);
		value = Mathf.Clamp01(value);
		ActorBodyItem actorBodyItem = _bodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Hair && x.gameObject.activeSelf);
		if (actorBodyItem != null)
		{
			ActorBodyItem.ColorMapping colorMapping = actorBodyItem.Colormap.FirstOrDefault((ActorBodyItem.ColorMapping x) => x.ColorName.Equals("Hair"));
			if (colorMapping != null)
			{
				actorBodyItem.SetColorDirect(colorMapping.MaterialSlot, Color.Lerp(HairColor, Color.gray, value));
			}
		}
		ActorBodyItem actorBodyItem2 = _bodyItems.FirstOrDefault((ActorBodyItem x) => x.Type == ActorBodyItem.BodyType.Head && x.gameObject.activeSelf);
		if (actorBodyItem2 != null)
		{
			actorBodyItem2.rend.material.SetFloat("_Overlay2Factor", value);
			actorBodyItem2.SetBlendValue("Age", ActorGenerator.GetAgeWeight(age) * 100f);
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
