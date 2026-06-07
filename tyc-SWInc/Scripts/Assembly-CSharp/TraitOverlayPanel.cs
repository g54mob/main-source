using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TraitOverlayPanel : MonoBehaviour
{
	public struct TraitIcon
	{
		public Sprite Icon;

		public Color Color;

		public Vector2 Position;

		public TraitIcon(Sprite icon, Color color, Vector2 pos)
		{
			Icon = icon;
			Color = color;
			Position = pos;
		}
	}

	public static TraitOverlayPanel Instance;

	public Image TraitPrefab;

	public AnimationCurve IconSize;

	public float YOffset = 0.1f;

	public float MinSize = 0.3f;

	[NonSerialized]
	private List<TraitIcon> _icons = new List<TraitIcon>();

	[NonSerialized]
	private List<Image> _traits = new List<Image>();

	private bool _lastActive;

	private void Awake()
	{
		Instance = this;
	}

	public void AddTrait(Employee.Trait t, Color? color, Transform tr)
	{
		if (_lastActive && base.isActiveAndEnabled)
		{
			Color color2 = HUD.GetThemeColor(0);
			if (color.HasValue)
			{
				color2 = color.Value;
			}
			else if ((Employee.Trait.NightOwl | Employee.Trait.BornLeader | Employee.Trait.FirmwareInc | Employee.Trait.SuperFocus | Employee.Trait.Unphased | Employee.Trait.JustTheFlu | Employee.Trait.Detached | Employee.Trait.Watch | Employee.Trait.FriendMaker).HasBits(t))
			{
				color2 = HUD.GetThemeColor(1);
			}
			else if ((Employee.Trait.Stressed | Employee.Trait.Hypochondriac | Employee.Trait.SlowEater | Employee.Trait.NervousBladder | Employee.Trait.BumLeg | Employee.Trait.Forgetful | Employee.Trait.Cupholder | Employee.Trait.NeatFreak | Employee.Trait.SilentButDeadly | Employee.Trait.WalkInstead | Employee.Trait.UnderTheWeather | Employee.Trait.Claustrophobic).HasBits(t))
			{
				color2 = HUD.GetThemeColor(2);
			}
			_icons.Add(new TraitIcon(ObjectDatabase.Instance.GetTrait(t), color2, CameraScript.Instance.SSAScript.WorldToScreenPoint(tr.position + Vector3.up * YOffset)));
		}
	}

	private void FixedUpdate()
	{
		int i = 0;
		float num = IconSize.Evaluate((CameraScript.Instance.transform.position - CameraScript.Instance.mainCam.transform.position).magnitude);
		if (num > MinSize)
		{
			_lastActive = true;
			Vector3 localScale = Vector3.one * num;
			for (; i < _icons.Count; i++)
			{
				TraitIcon traitIcon = _icons[i];
				Image image;
				if (i < _traits.Count)
				{
					image = _traits[i];
					image.gameObject.SetActive(true);
				}
				else
				{
					image = UnityEngine.Object.Instantiate(TraitPrefab);
					image.transform.SetParent(base.transform, false);
					_traits.Add(image);
				}
				image.sprite = traitIcon.Icon;
				image.color = traitIcon.Color;
				image.rectTransform.anchoredPosition = new Vector2(traitIcon.Position.x, traitIcon.Position.y - (float)Screen.height);
				image.rectTransform.localScale = localScale;
			}
		}
		else
		{
			_lastActive = false;
		}
		for (int j = i; j < _traits.Count && _traits[j].gameObject.activeSelf; j++)
		{
			_traits[j].gameObject.SetActive(false);
		}
		_icons.Clear();
	}
}
