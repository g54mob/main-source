using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SceneRecorder
{
	public delegate void OnCapture();

	[Serializable]
	public class SceneCapture
	{
		[NonSerialized]
		public SceneRecorder recorder;

		public int id;

		public List<DynamicRecordPosition> drp;

		public float t;

		public bool k;

		public int l;

		public int a;

		public List<RoomCapture> rCap;

		public List<DoorCapture> dCap;

		public List<ActorCapture> aCap;

		public List<InteractableCapture> oCap;

		public List<InteractableStateCapture> oSCap;

		public SceneCapture(SceneRecorder newRecorder, bool detailedCapture, bool flashLightActive = false, bool flashActive = false, bool includePlayerModel = true, bool cctvCapture = false)
		{
		}

		public SceneCapture(SceneCapture copyFrom)
		{
		}

		public NewGameLocation GetCaptureGamelocation()
		{
			return null;
		}

		public NewRoom GetCaptureRoom()
		{
			return null;
		}

		public float GetDecimalClock()
		{
			return 0f;
		}

		public Vector3 GetCaptureWorldPosition()
		{
			return default(Vector3);
		}

		public Vector3 GetCaptureWorldRotation()
		{
			return default(Vector3);
		}

		public string GetUniqueIDForInstance()
		{
			return null;
		}
	}

	[Serializable]
	public class DynamicRecordPosition
	{
		public Vector3 pos;

		public Vector3 rot;
	}

	[Serializable]
	public class RoomCapture
	{
		public int id;

		public bool light;

		public NewRoom GetRoom()
		{
			return null;
		}
	}

	[Serializable]
	public class TransformCapture
	{
		public Vector3 wP;

		public Quaternion wR;

		public TransformCapture(Vector3 pos, Quaternion rot)
		{
		}
	}

	[Serializable]
	public class DoorCapture
	{
		public int id;

		public int a;

		public bool t;

		public DoorCapture(NewDoor door)
		{
		}

		public NewDoor GetDoor()
		{
			return null;
		}

		public bool IsOpen()
		{
			return false;
		}
	}

	[Serializable]
	public class InteractableCapture : TransformCapture
	{
		public string p;

		public List<string> d;

		[NonSerialized]
		public GameObject poser;

		public InteractableCapture(Interactable newInter)
			: base(default(Vector3), default(Quaternion))
		{
		}

		public InteractablePreset GetPreset()
		{
			return null;
		}

		public void Load()
		{
		}

		public void Unload()
		{
		}
	}

	[Serializable]
	public class InteractableStateCapture
	{
		public int id;

		public bool sw;

		public InteractableStateCapture(Interactable i)
		{
		}

		public void Load()
		{
		}

		public Interactable GetInteractable()
		{
			return null;
		}
	}

	[Serializable]
	public class ActorCapture
	{
		public int id;

		public int o;

		public Vector3 pos;

		public Vector3 rot;

		public int main;

		public int arms;

		public int sp;

		public List<LimbCapture> limb;

		public HandItemCapture lH;

		public HandItemCapture rH;

		[NonSerialized]
		public ScenePoserController poser;

		public ActorCapture(Human newHuman, bool limbCapture)
		{
		}

		public Human GetHuman()
		{
			return null;
		}

		public void Load()
		{
		}

		public void Unload()
		{
		}
	}

	[Serializable]
	public class LimbCapture : TransformCapture
	{
		public int a;

		public LimbCapture(CitizenOutfitController.CharacterAnchor anchor, Vector3 pos, Quaternion rot)
			: base(default(Vector3), default(Quaternion))
		{
		}
	}

	[Serializable]
	public class HandItemCapture : TransformCapture
	{
		public string i;

		public HandItemCapture(GameObject obj, Vector3 pos, Quaternion rot)
			: base(default(Vector3), default(Quaternion))
		{
		}
	}

	public Interactable interactable;

	public List<NewRoom> coversRooms;

	public Dictionary<NewNode, List<int>> coveredNodes;

	public static List<ScenePoserController> scenePoserPool;

	public static Dictionary<string, List<GameObject>> objectPoserPool;

	public float lastCaptureAt;

	public static int assignCapID;

	public event OnCapture OnNewCapture
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public SceneRecorder(Interactable newInteractable)
	{
	}

	public void RefreshCoveredArea()
	{
	}

	public SceneCapture ExecuteCapture(bool onlyIfMovement, bool detailedCapture = false, bool prepToSaveCapture = true, bool useFlashlight = false, bool useFlash = false, bool includePlayerModel = true, bool cctvCapture = false)
	{
		return null;
	}
}
