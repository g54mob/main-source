using System;
using System.Collections.Generic;
using System.Linq;
using Tyd;
using UnityEngine;

public class TutorialMessage
{
	public enum HorizontalAnchor
	{
		Left = 0,
		Center = 1,
		Right = 2
	}

	public enum VerticalAnchor
	{
		Top = 0,
		Middle = 1,
		Bottom = 2
	}

	public class TutorialPoint
	{
		public Vector3 P;

		public bool ThreeD;

		public bool Angled;

		public bool FloorRel;

		public bool ForceShow;

		public float Angle;

		public string ElementAnchor;

		public HorizontalAnchor HAnchor;

		public VerticalAnchor VAnchor;

		public TutorialPoint(Vector3 p, bool threeD, bool angled, float angle, string elementAnchor, HorizontalAnchor hAnchor, VerticalAnchor vAnchor)
		{
			P = p;
			ThreeD = threeD;
			Angled = angled;
			Angle = angle;
			ElementAnchor = elementAnchor;
			HAnchor = hAnchor;
			VAnchor = vAnchor;
		}

		public TutorialPoint(TydCollection node)
		{
			float[] array = node.GetChild<TydCollection>("Position").GetChildValues<float>().ToArray();
			P = array.ToVector3();
			ThreeD = array.Length == 3;
			float? childValue = node.GetChildValue<float?>("Angle", false);
			Angled = childValue.HasValue;
			ForceShow = node.GetChildValue("ForceShow", false, false);
			if (Angled)
			{
				Angle = childValue.Value;
			}
			FloorRel = node.GetChildValue("RelativeToFloor", false, false);
			ElementAnchor = node.GetChildValue("Element", false);
			TydCollection child = node.GetChild<TydCollection>("Anchor");
			if (child != null)
			{
				string[] array2 = child.GetChildValues().ToArray();
				VAnchor = (VerticalAnchor)Enum.Parse(typeof(VerticalAnchor), array2[0], true);
				HAnchor = (HorizontalAnchor)Enum.Parse(typeof(HorizontalAnchor), array2[1], true);
			}
			else
			{
				VAnchor = VerticalAnchor.Top;
				HAnchor = HorizontalAnchor.Left;
			}
		}
	}

	public readonly string NonLoc;

	public readonly string Message;

	public readonly string ExamplePic;

	public readonly string StartScript;

	private readonly string[] _continueNames;

	private readonly Func<bool>[] _continues;

	public readonly bool ContinueOnAny;

	public readonly bool Shared;

	public readonly bool ShareSkip;

	public readonly bool ManualContinue;

	public readonly bool CanIgnore;

	public readonly bool Campaign;

	public readonly List<TutorialPoint> Points = new List<TutorialPoint>();

	public bool ShouldSkip()
	{
		bool flag = (GameSettings.Instance.IsReferenceNull() ? GameData.CampaignMode : GameSettings.Instance.CampaignMode);
		if (GameSettings.Instance.IsReferenceNull() || !Shared || !ShareSkip || !GameSettings.Instance.DisabledTutorials.Contains(Message))
		{
			return !Campaign && flag;
		}
		return true;
	}

	public bool CanContinue()
	{
		for (int i = 0; i < _continues.Length; i++)
		{
			bool flag = _continues[i]();
			if (!(ContinueOnAny ^ flag))
			{
				return flag;
			}
		}
		return !ContinueOnAny;
	}

	public TutorialMessage(TydCollection data, string id, bool shared)
	{
		Message = id;
		Shared = shared;
		NonLoc = data.GetChildValue("Message");
		CanIgnore = data.GetChildValue("CanIgnore", false, false);
		StartScript = data.GetChildValue("StartScript", false);
		ContinueOnAny = data.GetChildValue("ContinueOnAny", false, false);
		ShareSkip = data.GetChildValue("ShareSkip", false, true);
		ExamplePic = data.GetChildValue("ExamplePic", false);
		Campaign = data.GetChildValue("Campaign", false, true);
		TydCollection child = data.GetChild<TydCollection>("Continues");
		if (child != null)
		{
			string[] array = child.GetChildValues().ToArray();
			ManualContinue = false;
			_continueNames = new string[array.Length];
			_continues = new Func<bool>[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				_continueNames[i] = array[i];
				if (_continueNames[i][0] == '!')
				{
					_continueNames[i] = _continueNames[i].Substring(1);
					Func<bool> func = TutorialSystem.ContinueChecks.GetOrDefault(_continueNames[i], () => false);
					_continues[i] = () => !func();
				}
				else
				{
					_continues[i] = TutorialSystem.ContinueChecks.GetOrDefault(_continueNames[i], () => true);
				}
			}
		}
		else
		{
			ManualContinue = true;
		}
		TydCollection child2 = data.GetChild<TydCollection>("Points");
		if (child2 != null)
		{
			Points.AddRange(from x in child2.Nodes.OfType<TydCollection>()
				select new TutorialPoint(x));
		}
	}

	public void GetPoints(List<GameObject> result)
	{
		for (int i = 0; i < Points.Count; i++)
		{
			TutorialPoint tutorialPoint = Points[i];
			GameObject gameObject = TutorialSystem.Instance.InstantiateArrow();
			GUIArrow component = gameObject.GetComponent<GUIArrow>();
			component.ThreeD = tutorialPoint.ThreeD;
			component.Anchor = tutorialPoint.ElementAnchor;
			if (tutorialPoint.ThreeD)
			{
				component.ThreeDP = tutorialPoint.P;
				component.FloorRel = tutorialPoint.FloorRel;
			}
			else
			{
				component.ScreenParent = string.IsNullOrEmpty(tutorialPoint.ElementAnchor);
				component.Anchor = tutorialPoint.ElementAnchor;
				component.ThreeD = false;
				component.AnyAngle = !tutorialPoint.Angled;
				if (tutorialPoint.Angled)
				{
					component.Angle = tutorialPoint.Angle;
				}
				component.Offset = tutorialPoint.P;
				component.HorizontalAlign = tutorialPoint.HAnchor;
				component.VerticalAlign = tutorialPoint.VAnchor;
				component.ForceShow = tutorialPoint.ForceShow;
			}
			result.Add(gameObject);
		}
	}
}
