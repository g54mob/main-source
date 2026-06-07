using System;
using System.Collections.Generic;
using UnityEngine;

public class ModulesDrawerGroupLayout : MonoBehaviour, ISerializationCallbackReceiver
{
	[Serializable]
	public class ModuleInfo
	{
		public ModuleGestaltVariationEnum id;

		public Module module;

		public int rotation;

		public float position => 0f;

		public float offset => 0f;

		public ModuleInfo(ModuleGestaltVariationEnum id, Module module, int rotation = 0)
		{
		}
	}

	public ModuleGestalt.ModuleCategory category;

	public ModuleGestalt.ModuleGroup group;

	public DrawerContentTextLabel label;

	public SpriteRenderer background;

	public SpriteRenderer topSeparator;

	public float length;

	public ModuleInfo[] modules;

	[NonSerialized]
	private Dictionary<ModuleGestaltVariationEnum, ModuleInfo> modulesDictionary;

	public void OnBeforeSerialize()
	{
	}

	public void OnAfterDeserialize()
	{
	}

	public ModuleInfo GetPositionInfo(ModuleGestaltVariationEnum moduleVariationId)
	{
		return null;
	}
}
