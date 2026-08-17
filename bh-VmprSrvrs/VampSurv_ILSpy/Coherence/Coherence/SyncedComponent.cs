using System;
using System.Collections.Generic;

namespace Coherence;

public class SyncedComponent
{
	public string ComponentName;

	public bool NeedCachedProperty;

	public string Property;

	public string PropertyType;

	public string UnityComponentType;

	public bool OverrideSetter;

	public bool OverrideGetter;

	public int FieldMasks;

	public List<ComponentMember> MembersInfo;

	public string BakeConditional;

	public string FieldMasksString
	{
		get
		{
			//IL_0027: Expected I4, but got I8
			int flags = default(int);
			string text = System.ParseNumbers.IntToString(FieldMasks, 2, -1, ' ', flags);
			if (text != null)
			{
				return text.PadLeft(32, '0');
			}
			return (string)(object)new NullReferenceException();
		}
	}

	public SyncedComponent(string name, bool needsInitializer, string property, string propertyType, string unityComponentType, bool overrideSetter, bool overrideGetter, List<ComponentMember> membersInfo, string bakeConditional)
	{
		//IL_0033: Expected O, but got I
		ComponentName = name;
		NeedCachedProperty = needsInitializer;
		Property = property;
		PropertyType = bakeConditional;
		IntPtr intPtr = default(IntPtr);
		UnityComponentType = (string)(nint)intPtr;
		bool overrideSetter2 = default(bool);
		OverrideSetter = overrideSetter2;
		bool overrideGetter2 = default(bool);
		OverrideGetter = overrideGetter2;
		List<ComponentMember> membersInfo2 = default(List<ComponentMember>);
		MembersInfo = membersInfo2;
		string bakeConditional2 = default(string);
		BakeConditional = bakeConditional2;
	}
}
