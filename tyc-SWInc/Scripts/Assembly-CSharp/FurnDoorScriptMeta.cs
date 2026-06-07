using System.Collections.Generic;
using Tyd;
using UnityEngine;

public class FurnDoorScriptMeta : FurnModMeta
{
	[FurnModAttr("Speed", FurnModAttr.VariableType.Float, ReflectTarget = true, Desc = "How fast the door closes in seconds")]
	public float Speed;

	[FurnModAttr("waitTime", FurnModAttr.VariableType.Float, ReflectTarget = true, Desc = "How long the door waits before closing again")]
	public float WaitTime;

	[FurnModAttr("Scale", FurnModAttr.VariableType.Bool, ReflectTarget = true, CallMethod = "OnSelect", Desc = "Whether the door should slide, otherwise it will swing open")]
	public bool Slide;

	[FurnModAttr("Reverse", FurnModAttr.VariableType.Bool, ReflectTarget = true, Desc = "If you placed the hinge the wrong way around, will avoid swinging into people")]
	public bool Reverse;

	[FurnModAttr("OpenSFX", FurnModAttr.VariableType.String, FetchList = "GetDoorOpenSounds", ReflectTarget = true, Desc = "Sound effect to play when the door opens")]
	public string OpenSoundEffect;

	[FurnModAttr("CloseSFX", FurnModAttr.VariableType.String, FetchList = "GetDoorCloseSounds", ReflectTarget = true, Desc = "Sound effect to play when the door closes")]
	public string CloseSoundEffect;

	[FurnModAttr("DoorCloseSoundOnClose", FurnModAttr.VariableType.Bool, ReflectTarget = true, Desc = "Whether to play the closing sound before the door closes or when it is closed")]
	public bool CloseSoundBefore;

	[FurnModAttr("MaxSoundDistance", FurnModAttr.VariableType.Float, ReflectTarget = true, Desc = "How far away the sound can be heard")]
	public float MaxSoundDistance;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformParent)]
	public GameObject Parent;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformPosition)]
	public Vector3 Position;

	[FurnModAttr(null, FurnModAttr.VariableType.TransformRotation, CallMethod = "RefreshRotation")]
	public Vector3 Rotation;

	public override string MetaName
	{
		get
		{
			return "Hinge";
		}
	}

	public FurnDoorScriptMeta(Component target)
		: base(target)
	{
	}

	public override void OnSelect()
	{
		DoorScript doorScript;
		if ((object)(doorScript = Target as DoorScript) != null)
		{
			Target.transform.localScale = Vector3.one;
			Target.transform.localRotation = doorScript.OriginalRot;
			FurnitureModdingTool.Instance.ActiveHinge = Target as DoorScript;
		}
	}

	public override void OnDeselect()
	{
		DoorScript doorScript;
		if ((object)(doorScript = Target as DoorScript) != null)
		{
			if (FurnitureModdingTool.Instance.ActiveHinge == doorScript)
			{
				FurnitureModdingTool.Instance.ActiveHinge = null;
			}
			Target.transform.localScale = Vector3.one;
			Target.transform.localRotation = doorScript.OriginalRot;
		}
	}

	public void RefreshRotation()
	{
		DoorScript doorScript;
		if ((object)(doorScript = Target as DoorScript) != null)
		{
			doorScript.OriginalRot = doorScript.transform.localRotation;
		}
	}

	[FurnModAction]
	public void Delete()
	{
		FurnitureModdingTool.Instance.CurrentMeta.Remove(this);
		FurnitureModdingTool.Instance.SetInspector(null);
		for (int num = Target.transform.childCount - 1; num >= 0; num--)
		{
			Target.transform.GetChild(num).SetParent(FurnitureModdingTool.Instance.ActiveObject.transform, true);
		}
		Object.Destroy(FurnitureModdingTool.Instance.MetaButtons[this]);
		FurnitureModdingTool.Instance.MetaButtons.Remove(this);
		FurnitureModdingTool.Instance.UpdateMetaDrops();
		Object.Destroy(Target.gameObject);
	}

	public IEnumerable<string> GetDoorOpenSounds()
	{
		foreach (GameObject roomSegment in ObjectDatabase.Instance.RoomSegments)
		{
			DoorScript[] h = roomSegment.GetComponent<RoomSegment>().Hinges;
			foreach (DoorScript doorScript in h)
			{
				if (!string.IsNullOrEmpty(doorScript.OpenSFX))
				{
					yield return doorScript.OpenSFX;
				}
			}
		}
	}

	public IEnumerable<string> GetDoorCloseSounds()
	{
		foreach (GameObject roomSegment in ObjectDatabase.Instance.RoomSegments)
		{
			DoorScript[] h = roomSegment.GetComponent<RoomSegment>().Hinges;
			foreach (DoorScript doorScript in h)
			{
				if (!string.IsNullOrEmpty(doorScript.CloseSFX))
				{
					yield return doorScript.CloseSFX;
				}
			}
		}
	}

	public override void WriteToTyD(TydTable root)
	{
		DoorScript doorScript;
		if ((object)(doorScript = Target as DoorScript) != null)
		{
			Target.transform.localRotation = doorScript.OriginalRot;
		}
		WriteTransform(root, Target.name, Target.transform, Parent);
		TydTable node = new TydTable("DoorScript", new TydString("TransformParent", Target.name), new TydString("Speed", Speed.ToString()), new TydString("waitTime", WaitTime.ToString()), new TydString("Scale", Slide.ToString()), new TydString("Reverse", Reverse.ToString()), new TydString("OpenSFX", OpenSoundEffect), new TydString("CloseSFX", CloseSoundEffect), new TydString("DoorCloseSoundOnClose", CloseSoundBefore.ToString()), new TydString("MaxSoundDistance", MaxSoundDistance.ToString()));
		root.AddChild(node);
	}

	public override string GetMetaGroup()
	{
		return "Hinges";
	}
}
