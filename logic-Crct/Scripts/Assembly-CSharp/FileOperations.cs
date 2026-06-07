using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class FileOperations : MonoBehaviour
{
	[Serializable]
	public class SaveComponent
	{
		public int toolID;

		[SerializeField]
		public object[] data;

		public SaveComponent()
		{
		}

		public SaveComponent(int id, object[] d)
		{
		}
	}

	[Serializable]
	[XmlInclude(typeof(Vector3S))]
	[XmlInclude(typeof(QuaternionS))]
	[XmlInclude(typeof(ColorS))]
	[XmlInclude(typeof(TiePointID))]
	[XmlInclude(typeof(Vector3S[]))]
	[XmlInclude(typeof(SaveComponent))]
	[XmlInclude(typeof(bool[]))]
	[XmlInclude(typeof(TiePointID[]))]
	public class SaveData
	{
		public string name;

		public SaveComponent[] components;

		public byte[] imageData;

		public Vector3S pivotPos;

		public Vector3S pivotRot;

		public Vector3S camPos;

		public int frequency;

		public float timeStep;

		public bool throttling;

		public SaveData()
		{
		}

		public SaveData(List<BaseComponent> comps, string n)
		{
		}
	}

	public struct CHOOSECOLORW
	{
		public int lStructSize;

		public IntPtr hwndOwner;

		public IntPtr hInstance;

		public int rgbResult;

		public IntPtr lpCustColors;

		public int Flags;

		public long lCustData;

		public UIntPtr lpfnHook;

		public string lpTemplateName;
	}

	[Header("Window Text")]
	public string baseTitle;

	public string designTitle;

	public byte[] imageData;

	public Transform pivot;

	public Transform cam;

	private bool _designDirty;

	public Text designTitleText;

	private static readonly uint MB_OKCANCEL;

	private static readonly uint MB_ICONWARNING;

	private static byte[] customColors;

	private static readonly int CC_FULLOPEN;

	private static readonly int CC_RGBINIT;

	private static readonly int OFN_PATHMUSTEXIST;

	private static readonly int OFN_FILEMUSTEXIST;

	public static bool ResetWorkspace;

	private static readonly int OFN_OVERWRITEPROMPT;

	private static FileOperations inst { get; set; }

	public static string DesignTitle => null;

	public bool designDirty
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public static bool IsDesignDirty => false;

	private string currentFilepath { get; set; }

	public static string CurrentFilepath => null;

	private List<BaseComponent> components { get; set; }

	private string prevDir { get; set; }

	private void Awake()
	{
	}

	public void Exit()
	{
	}

	public void NewDesign()
	{
	}

	public static void NewMobileDesign()
	{
	}

	public void SaveFile()
	{
	}

	public static SaveData ReturnCurrentDesignSaveData()
	{
		return null;
	}

	public static void SaveDesignMobile(byte[] imageData)
	{
	}

	public static void IPC_SaveDesign(string filePath, byte[] imageData)
	{
	}

	public static void SaveAsDesignMobile(string name, byte[] imageData)
	{
	}

	public static void RegisterComponent(BaseComponent c)
	{
	}

	public static void RegisterComponent(BaseComponent c, Guid id)
	{
	}

	public static BaseComponent FindComponentFromID(Guid id)
	{
		return null;
	}

	public static bool RemoveComponent(Guid id)
	{
		return false;
	}

	public static List<BaseComponent> AllComponents()
	{
		return null;
	}

	private static int UnityColorToInt(Color col)
	{
		return 0;
	}

	public void OpenFile()
	{
	}

	private string ConvertToUsedSize(string str)
	{
		return null;
	}

	private void OpenFileDialogResult(string path)
	{
	}

	public static void OpenDesign(string path)
	{
	}

	public static void IPC_OpenExample(string len)
	{
	}

	public static void OpenExample(TextAsset textData)
	{
	}

	public static void DesignDirty()
	{
	}

	public static void DesignClean()
	{
	}

	public void SaveAsFile()
	{
	}

	private void SaveFileDialogResult(string path)
	{
	}
}
